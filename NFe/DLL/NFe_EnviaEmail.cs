using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;
using System.Net.Mime;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;
using System.Xml;

namespace Sistema.NFe
{
    public class NFe_EnviaEmail
    {
        #region VARIAVEIS DE CLASSE
        BLL_Parametro BLL_Parametro;
        BLL_NF BLL_NF;
        #endregion

        #region ESTRUTURAS
        DTO_Parametro Parametro;
        DTO_NF NFe;
        #endregion

        #region VARIAVEIS DIVERSAS
        string SMTP;
        string Email;
        string De;
        string Usuario;
        string Senha;

        int Porta;

        bool SSL;

        ArrayList Anexos;
        #endregion

        #region ROTINAS
        private void CarregaConfigEmail()
        {
            BLL_Parametro = new BLL_Parametro();
            Parametro = new DTO_Parametro();

            Parametro.Tipo = 9;
            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count > 0 &&
                _DT.Rows[0]["De"].ToString() != string.Empty &&
                _DT.Rows[0]["Email"].ToString() != string.Empty)
            {
                SMTP = Parametro_Sistema.SMTP;
                Porta = Parametro_Sistema.Porta;
                SSL = Parametro_Sistema.SSL;
                De = _DT.Rows[0]["De"].ToString();
                Usuario = Parametro_Sistema.Usuario_email;
                Senha = Parametro_Sistema.Senha_email;
                Email = _DT.Rows[0]["Email"].ToString();
            }
        }

        private string Carrega_Email(int _ID_NFe)
        {
            BLL_NF = new BLL_NF();
            NFe = new DTO_NF();

            NFe.ID = _ID_NFe;
            DataTable DT = new DataTable();
            DT = BLL_NF.Busca_NF_Email(NFe);

            if (DT.Rows.Count > 0)
                return DT.Rows[0]["Email"].ToString();
            else
                return string.Empty;
        }

        public void Envia_NFe(string _XML, string _PDF)
        {
            try
            {
                int ID_NFe = 0;
                string num_NFe = string.Empty;
                string serie_NFe = string.Empty;
                string valor_NFe = string.Empty;
                string emitente_NFe = string.Empty;
                string cnpj_emitente_NFe = string.Empty;
                string emissao_NFe = string.Empty;

                XmlDocument xml = new XmlDocument();
                xml.Load(_XML);

                XmlNodeList _ide = xml.GetElementsByTagName("ide");

                foreach (XmlNode _aux in _ide)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    ID_NFe = Convert.ToInt32(_elemento.GetElementsByTagName("cNF")[0].InnerText);
                    num_NFe = _elemento.GetElementsByTagName("nNF")[0].InnerText;
                    serie_NFe = _elemento.GetElementsByTagName("serie")[0].InnerText;
                    emissao_NFe = util_dados.Config_Data(Convert.ToDateTime(_elemento.GetElementsByTagName("dhEmi")[0].InnerText), 3).ToString();
                }

                XmlNodeList _emi = xml.GetElementsByTagName("emit");

                foreach (XmlNode _aux in _emi)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    cnpj_emitente_NFe = util_dados.Conf_CPF_CNPJ(_elemento.GetElementsByTagName("CNPJ")[0].InnerText, Documento.CNPJ);
                    emitente_NFe = _elemento.GetElementsByTagName("xFant")[0].InnerText;
                }

                XmlNodeList _total = xml.GetElementsByTagName("total");
                foreach (XmlNode _aux in _total)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    valor_NFe = _elemento.GetElementsByTagName("vNF")[0].InnerText;
                }

                string email = Carrega_Email(ID_NFe);

                if (!util_dados.Verifica_email(email))
                    throw new Exception(util_msg.msg_Email_Invalido);

                CarregaConfigEmail();

                if (De == null)
                    throw new Exception(util_msg.msg_ConfigEmail_Invalido);

                MailMessage mensagemEmail = new MailMessage();

                mensagemEmail.To.Add(email);

                mensagemEmail.From = new MailAddress(Email, De);
                mensagemEmail.Subject = util_msg.msg_Assunto_Email_NFe.Replace("#num_nota#", num_NFe);

                string _msg = util_msg.msg_Mensagem_Email_NFe;
                _msg = _msg.Replace("#num_nota#", num_NFe);
                _msg = _msg.Replace("#serie_nota#", serie_NFe);
                _msg = _msg.Replace("#nome_emitente#", emitente_NFe);
                _msg = _msg.Replace("#valor_nota#", valor_NFe);

                mensagemEmail.Body = _msg;

                Attachment anexado = new Attachment(_XML, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);

                anexado = new Attachment(_PDF, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);

                SmtpClient client = new SmtpClient();
                client.Host = SMTP;
                client.Port = Porta;
                client.EnableSsl = SSL;

                NetworkCredential cred = new NetworkCredential(Usuario, Senha);
                client.Credentials = cred;
                client.Send(mensagemEmail);

                try
                {
                    BLL_Email BLL_Email = new BLL_Email();
                    DTO_Email DTO_Email = new DTO_Email();

                    DTO_Email.Para = email;
                    DTO_Email.Data = DateTime.Now;
                    DTO_Email.Assunto = util_msg.msg_Assunto_Email_NFe.Replace("#num_nota#", num_NFe);
                    DTO_Email.Conteudo = _msg;
                    DTO_Email.Anexo = _XML + "; " + _PDF;

                    BLL_Email.Grava(DTO_Email);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Envia_Canc(string _XML, string _XML_NFe)
        {
            try
            {
                int ID_NFe = 0;
                string num_NFe = string.Empty;
                string serie_NFe = string.Empty;
                string valor_NFe = string.Empty;
                string emitente_NFe = string.Empty;
                string cnpj_emitente_NFe = string.Empty;
                string emissao_NFe = string.Empty;
                string Chave_NFe = string.Empty;
                string Protocolo = string.Empty;
                string Justificativa = string.Empty;
                string Data_Canc = string.Empty;

                XmlDocument xml = new XmlDocument();
                xml.Load(_XML);

                XmlNodeList _infEvento = xml.GetElementsByTagName("infEvento");

                foreach (XmlNode _aux in _infEvento)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    Justificativa = _elemento.GetElementsByTagName("xJust")[0].InnerText;
                    Chave_NFe = _elemento.GetElementsByTagName("chNFe")[0].InnerText;
                    Data_Canc = util_dados.Config_Data(Convert.ToDateTime(_elemento.GetElementsByTagName("dhEvento")[0].InnerText), 3).ToString();
                    break;
                }

                xml = new XmlDocument();
                xml.Load(_XML_NFe);
                XmlNodeList _ide = xml.GetElementsByTagName("ide");

                foreach (XmlNode _aux in _ide)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    ID_NFe = Convert.ToInt32(_elemento.GetElementsByTagName("cNF")[0].InnerText);
                    num_NFe = _elemento.GetElementsByTagName("nNF")[0].InnerText;
                    serie_NFe = _elemento.GetElementsByTagName("serie")[0].InnerText;
                    emissao_NFe = util_dados.Config_Data(Convert.ToDateTime(_elemento.GetElementsByTagName("dhEmi")[0].InnerText), 3).ToString();
                }

                XmlNodeList _emi = xml.GetElementsByTagName("emit");

                foreach (XmlNode _aux in _emi)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    cnpj_emitente_NFe = util_dados.Conf_CPF_CNPJ(_elemento.GetElementsByTagName("CNPJ")[0].InnerText, Documento.CNPJ);
                    emitente_NFe = _elemento.GetElementsByTagName("xFant")[0].InnerText;
                }

                XmlNodeList _total = xml.GetElementsByTagName("total");
                foreach (XmlNode _aux in _total)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    valor_NFe = _elemento.GetElementsByTagName("vNF")[0].InnerText;
                }

                string email = Carrega_Email(ID_NFe);

                if (!util_dados.Verifica_email(email))
                    throw new Exception(util_msg.msg_Email_Invalido);

                CarregaConfigEmail();

                MailMessage mensagemEmail = new MailMessage();

                mensagemEmail.To.Add(email);

                //mensagemEmail.CC.Add(lts_CC[i]);

                // mensagemEmail.Bcc.Add(lts_CCO[i]);

                mensagemEmail.From = new MailAddress(Email, De);
                mensagemEmail.Subject = util_msg.msg_Assunto_Email_Canc.Replace("#num_nota#", num_NFe);

                string _msg = util_msg.msg_Mensagem_Email_Canc;
                _msg = _msg.Replace("#num_nota#", num_NFe);
                _msg = _msg.Replace("#serie_nota#", serie_NFe);
                _msg = _msg.Replace("#nome_emitente#", emitente_NFe);
                _msg = _msg.Replace("#cnpj_emitente#", cnpj_emitente_NFe);
                _msg = _msg.Replace("#chave_acesso#", Chave_NFe);
                _msg = _msg.Replace("#emissao_documento#", emissao_NFe);
                _msg = _msg.Replace("#justificativa#", Justificativa);
                _msg = _msg.Replace("#protocolo#", Protocolo);
                _msg = _msg.Replace("#data#", Data_Canc);

                mensagemEmail.Body = _msg;

                Attachment anexado = new Attachment(_XML, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);

                SmtpClient client = new SmtpClient();
                client.Host = SMTP;
                client.Port = Porta;
                client.EnableSsl = SSL;

                NetworkCredential cred = new NetworkCredential(Usuario, Senha);
                client.Credentials = cred;
                client.Send(mensagemEmail);

                try
                {
                    BLL_Email BLL_Email = new BLL_Email();
                    DTO_Email DTO_Email = new DTO_Email();

                    DTO_Email.Para = email;
                    DTO_Email.Data = DateTime.Now;
                    DTO_Email.Assunto = util_msg.msg_Assunto_Email_Canc.Replace("#num_nota#", num_NFe);
                    DTO_Email.Conteudo = _msg;

                    BLL_Email.Grava(DTO_Email);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Envia_CCe(string _XML, string _PDF, string _XML_NFe)
        {
            try
            {
                int ID_NFe = 0;
                string num_NFe = string.Empty;
                string emitente_NFe = string.Empty;

                XmlDocument xml = new XmlDocument();
                xml.Load(_XML_NFe);

                XmlNodeList _ide = xml.GetElementsByTagName("ide");

                foreach (XmlNode _aux in _ide)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    ID_NFe = Convert.ToInt32(_elemento.GetElementsByTagName("cNF")[0].InnerText);
                    num_NFe = _elemento.GetElementsByTagName("nNF")[0].InnerText;
                }

                XmlNodeList _emi = xml.GetElementsByTagName("emit");

                foreach (XmlNode _aux in _emi)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    emitente_NFe = _elemento.GetElementsByTagName("xFant")[0].InnerText;
                }

                string email = Carrega_Email(ID_NFe);

                if (!util_dados.Verifica_email(email))
                    throw new Exception(util_msg.msg_Email_Invalido);

                CarregaConfigEmail();

                MailMessage mensagemEmail = new MailMessage();

                mensagemEmail.To.Add(email);

                //mensagemEmail.CC.Add(lts_CC[i]);

                // mensagemEmail.Bcc.Add(lts_CCO[i]);

                mensagemEmail.From = new MailAddress(Email, De);
                mensagemEmail.Subject = util_msg.msg_Assunto_Email_CCe.Replace("#num_nota#", num_NFe);

                string _msg = util_msg.msg_Mensagem_Email_CCe;
                _msg = _msg.Replace("#num_nota#", num_NFe);
                _msg = _msg.Replace("#nome_emitente#", emitente_NFe);

                mensagemEmail.Body = _msg;

                Attachment anexado = new Attachment(_XML, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);

                anexado = new Attachment(_PDF, MediaTypeNames.Application.Octet);
                mensagemEmail.Attachments.Add(anexado);

                SmtpClient client = new SmtpClient();
                client.Host = SMTP;
                client.Port = Porta;
                client.EnableSsl = SSL;

                NetworkCredential cred = new NetworkCredential(Usuario, Senha);
                client.Credentials = cred;
                client.Send(mensagemEmail);

                try
                {
                    BLL_Email BLL_Email = new BLL_Email();
                    DTO_Email DTO_Email = new DTO_Email();

                    DTO_Email.Para = email;
                    DTO_Email.Data = DateTime.Now;
                    DTO_Email.Assunto = util_msg.msg_Assunto_Email_CCe.Replace("#num_nota#", num_NFe);
                    DTO_Email.Conteudo = _msg;

                    BLL_Email.Grava(DTO_Email);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
