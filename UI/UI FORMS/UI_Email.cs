using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Net.Configuration;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.BLL;

namespace Sistema.UI
{
    public partial class UI_Email : Sistema.UI.UI_Modelo
    {
        public UI_Email()
        {
            InitializeComponent();
        }
        #region VARIAVEIS DE CLASSE
        BLL_Email BLL_Email;
        BLL_Parametro BLL_Parametro;
        #endregion

        #region VARIAVEIS DIVERSAS
        string SMTP;
        string Email_Remetente;
        string De;
        string Usuario;
        string Senha;

        int Porta;

        bool SSL;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Email Email;
        DTO_Parametro Parametro;
        #endregion

        #region PROPRIEDADES
        public string Anexo { get; set; }
        public string Endereco { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE EMAIL";
            TabPage1.Text = "EMAIL";
            TabPage2.Text = "CAIXA DE SAIDA";

            DataGridViewTextBoxColumn col_Data = new DataGridViewTextBoxColumn();
            col_Data.DataPropertyName = "Data";
            col_Data.HeaderText = "DATA";
            col_Data.Width = 75;
            DG.Columns.Add(col_Data);


            DataGridViewTextBoxColumn col_Para = new DataGridViewTextBoxColumn();
            col_Para.DataPropertyName = "Para";
            col_Para.HeaderText = "PARA";
            col_Para.Width = 250;
            DG.Columns.Add(col_Para);

            DataGridViewTextBoxColumn col_Assunto = new DataGridViewTextBoxColumn();
            col_Assunto.DataPropertyName = "Assunto";
            col_Assunto.HeaderText = "ASSUNTO";
            col_Assunto.Width = 250;
            DG.Columns.Add(col_Assunto);

            DataGridViewTextBoxColumn col_Conteudo = new DataGridViewTextBoxColumn();
            col_Conteudo.DataPropertyName = "Conteudo";
            col_Conteudo.HeaderText = "CONTEÚDO";
            col_Conteudo.Width = 400;
            col_Conteudo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Conteudo);

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            bt_Anterior.Enabled = true;
            bt_Proximo.Enabled = true;

            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            mk_Data.Text = DateTime.Now.ToString();

            txt_Anexo.Text = Anexo;
            txt_Assunto.Text = Assunto;
            txt_Conteudo.Text = Mensagem;
            txt_Para.Text = Endereco;
        }

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
                Usuario = Parametro_Sistema.Senha_email;
                Senha = Parametro_Sistema.Senha_email;
                Email_Remetente = _DT.Rows[0]["Email"].ToString();
            }
            else
                MessageBox.Show(util_msg.msg_ConfigEmail_Invalido, this.Text);
        }

        private void ValidaEnderecoEmail(string enderecoEmail)
        {
            try
            {
                string texto_Validar = enderecoEmail;

                Regex expressaoRegex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (!expressaoRegex.IsMatch(texto_Validar))
                    throw new Exception("Email inválido!");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void EnviaEmail(string Para, string CC, string CCO, string Assunto, string Mensagem)
        {
            try
            {
                string[] split;

                List<string> lts_Para = new List<string>();
                split = Para.Split(new char[] { ';', ';' });

                if (Para.ToString().Trim() != "")
                    for (int i = 0; i <= split.Length - 1; i++)
                    {
                        if (split[i].Trim() == "")
                            break;

                        lts_Para.Add(split[i]);
                        ValidaEnderecoEmail(lts_Para[i]);
                    }

                List<string> lts_CC = new List<string>();
                split = CC.Split(new char[] { ';', ';' });
                if (CC.ToString().Trim() != "")
                    for (int i = 0; i <= split.Length - 1; i++)
                    {

                        if (split[i].Trim() == "")
                            break;

                        lts_CC.Add(split[i]);
                        ValidaEnderecoEmail(lts_CC[i]);
                    }

                List<string> lts_CCO = new List<string>();
                split = CCO.Split(new char[] { ';', ';' });
                if (CCO.ToString().Trim() != "")
                    for (int i = 0; i <= split.Length - 1; i++)
                    {
                        if (split[i].Trim() == "")
                            break;

                        lts_CCO.Add(split[i]);
                        ValidaEnderecoEmail(lts_CCO[i]);
                    }

                MailMessage mensagemEmail = new MailMessage();

                for (int i = 0; i <= lts_Para.Count - 1; i++)
                    mensagemEmail.To.Add(lts_Para[i]);

                for (int i = 0; i <= lts_CC.Count - 1; i++)
                    mensagemEmail.CC.Add(lts_CC[i]);

                for (int i = 0; i <= lts_CCO.Count - 1; i++)
                    mensagemEmail.Bcc.Add(lts_CCO[i]);

                mensagemEmail.From = new MailAddress(Email_Remetente, De);
                mensagemEmail.Subject = Assunto;
                mensagemEmail.Body = "<pre>" + Mensagem + "</pre>";

                // if (ck_HTML.Checked == true)
                mensagemEmail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Host = SMTP;
                client.Port = Porta;
                client.EnableSsl = SSL;

                NetworkCredential cred = new NetworkCredential(Usuario, Senha);
                client.Credentials = cred;
                client.Send(mensagemEmail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EnviaEmailComAnexos(string Para, string CC, string CCO, string Assunto, string Mensagem, ArrayList anexos)
        {
            try
            {
                string[] split;

                List<string> lts_Para = new List<string>();
                split = Para.Split(new char[] { ';', ';' });
                if (Para.ToString().Trim() != "")
                    for (int i = 0; i <= split.Length - 1; i++)
                    {
                        if (split[i].Trim() == "")
                            break;

                        lts_Para.Add(split[i]);
                        ValidaEnderecoEmail(lts_Para[i]);
                    }

                List<string> lts_CC = new List<string>();
                split = CC.Split(new char[] { ';', ';' });
                if (CC.ToString().Trim() != "")
                    for (int i = 0; i <= split.Length - 1; i++)
                    {
                        if (split[i].Trim() == "")
                            break;

                        lts_CC.Add(split[i]);
                        ValidaEnderecoEmail(lts_CC[i]);
                    }

                List<string> lts_CCO = new List<string>();
                split = CCO.Split(new char[] { ';', ';' });
                if (CCO.ToString().Trim() != "")
                    for (int i = 0; i <= split.Length - 1; i++)
                    {
                        if (split[i].Trim() == "")
                            break;

                        lts_CCO.Add(split[i]);
                        ValidaEnderecoEmail(lts_CCO[i]);
                    }

                MailMessage mensagemEmail = new MailMessage();

                for (int i = 0; i <= lts_Para.Count - 1; i++)
                    mensagemEmail.To.Add(lts_Para[i]);

                for (int i = 0; i <= lts_CC.Count - 1; i++)
                    mensagemEmail.CC.Add(lts_CC[i]);

                for (int i = 0; i <= lts_CCO.Count - 1; i++)
                    mensagemEmail.Bcc.Add(lts_CCO[i]);

                mensagemEmail.From = new MailAddress(Email_Remetente, De);
                mensagemEmail.Subject = Assunto;
                mensagemEmail.Body = Mensagem;

                // if (ck_HTML.Checked == true)
                mensagemEmail.IsBodyHtml = true;

                foreach (string anexo in anexos)
                {
                    Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                    mensagemEmail.Attachments.Add(anexado);
                }

                SmtpClient client = new SmtpClient();
                client.Host = SMTP;
                client.Port = Porta;
                client.EnableSsl = SSL;

                NetworkCredential cred = new NetworkCredential(Usuario, Senha);
                client.Credentials = cred;
                client.Send(mensagemEmail);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_Email = new BLL_Email();
            Email = new DTO_Email();

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                      mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                Email.Consulta_Data.Filtra = true;
                Email.Consulta_Data.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Email.Consulta_Data.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            Email.Assunto = txt_AssuntoP.Text;

            DataTable _DT = new DataTable();
            _DT = BLL_Email.Busca(Email);

            DG.DataSource = _DT;

            util_dados.CarregaCampo(this, _DT, gb_Destinatario);
            util_dados.CarregaCampo(this, _DT, gb_Conteudo);
            util_dados.CarregaCampo(this, _DT, gb_Anexo);
        }

        public override void Gravar()
        {
            BLL_Email = new BLL_Email();
            Email = new DTO_Email();

            Email.Para = txt_Para.Text;
            Email.Data = Convert.ToDateTime(mk_Data.Text);
            Email.CC = txt_CC.Text;
            Email.CCO = txt_CCO.Text;
            Email.Assunto = txt_Assunto.Text;
            Email.Conteudo = rtc_Conteudo.Text;
            Email.Anexo = txt_Anexo.Text;

            BLL_Email.Grava(Email);
        }

        public override void Excluir()
        {
            BLL_Email = new BLL_Email();
            Email = new DTO_Email();

            Email.ID = Convert.ToInt32(txt_ID.Text);

            BLL_Email.Exclui(Email);
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Destinatario);
            util_dados.LimpaCampos(this, gb_Conteudo);
            util_dados.LimpaCampos(this, gb_Anexo);

            mk_Data.Text = DateTime.Now.ToString();

            txt_Para.Focus();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Email_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaPara_Click(object sender, EventArgs e)
        {
            UI_Pessoa_Email frm = new UI_Pessoa_Email();
            frm.ShowDialog();
            txt_Para.Text = frm.lst_Email;
        }

        private void bt_PesquisaCC_Click(object sender, EventArgs e)
        {
            UI_Pessoa_Email frm = new UI_Pessoa_Email();
            frm.ShowDialog();
            txt_CC.Text = frm.lst_Email;
        }

        private void bt_PesquisaCCO_Click(object sender, EventArgs e)
        {
            UI_Pessoa_Email frm = new UI_Pessoa_Email();
            frm.ShowDialog();
            txt_CCO.Text = frm.lst_Email;
        }

        private void bt_BuscaAnexo_Click(object sender, EventArgs e)
        {
            if (ProcuraAnexo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] arr = ProcuraAnexo.FileNames;

                    ArrayList Anexos = new ArrayList();
                    Anexos.AddRange(arr);

                    foreach (string s in Anexos)
                    {
                        if (txt_Anexo.Text.IndexOf(s) != -1)
                            MessageBox.Show("Arquivo já anexado!", this.Text);
                        else
                            txt_Anexo.Text += s + "; ";

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text);
                }

            }
        }

        private void bt_Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregaConfigEmail();

                if (De == null)
                    return;

                if (String.IsNullOrEmpty(txt_Assunto.Text))
                {
                    MessageBox.Show("Assunto Inválido!", this.Text);
                    return;
                }

                if (String.IsNullOrEmpty(rtc_Conteudo.Text))
                {
                    MessageBox.Show("Mensagem inválida.", this.Text);
                    return;
                }

                string[] arr = txt_Anexo.Text.Split(';');

                ArrayList Anexo = new ArrayList();

                for (int i = 0; i < arr.Length; i++)
                    if (!String.IsNullOrEmpty(arr[i].ToString().Trim()))
                        Anexo.Add(arr[i].ToString().Trim());

                if (Anexo.Count > 0)
                    EnviaEmailComAnexos(txt_Para.Text, txt_CC.Text, txt_CCO.Text, txt_Assunto.Text, rtc_Conteudo.Text, Anexo);
                else
                    EnviaEmail(txt_Para.Text, txt_CC.Text, txt_CCO.Text, txt_Assunto.Text, rtc_Conteudo.Text);

                Gravar();

                MessageBox.Show("Email enviado com sucesso!", this.Text);

                Novo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MASKEDBOX
        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data.Text = Convert.ToString(DateTime.Now);
                mk_Data.Focus();
            }


        }

        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataInicial.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataInicial.Text = Convert.ToString(DateTime.Now);
                mk_DataInicial.Focus();
            }


        }

        private void mk_DataFinal_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }


        }
        #endregion

        #region TEXTBOX
        private void txt_Conteudo_TextChanged(object sender, EventArgs e)
        {
            rtc_Conteudo.Text = txt_Conteudo.Text;
        }
        #endregion

        private void rtc_Conteudo_KeyDown(object sender, KeyEventArgs e)
        {
            // if (e.KeyCode == Keys.Enter)
            // {
            //     rtc_Conteudo.Text = rtc_Conteudo.Text + Environment.NewLine;
            //      SendKeys.Send("{end}");
            // }
        }
    }
}
