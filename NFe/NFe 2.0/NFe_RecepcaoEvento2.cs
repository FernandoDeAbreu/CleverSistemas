using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Data;
using Sistema.NFe.ws_NFeRecepcaoEvento2;
using Sistema.UTIL;
using Sistema.DTO;

namespace Sistema.NFe
{
    public class NFe_RecepcaoEvento2
    {
        public string Cancela_NFe(string XML, string Certificado)
        {
            try
            {
                #region CARREGA CERTIFICADO
                NFe_CertificadoDigital _cert = new NFe_CertificadoDigital();
                DTO_CertificadoDigital CertificadoDigital = new DTO_CertificadoDigital();

                CertificadoDigital = _cert.Carrega_Certificado(Certificado);
                #endregion

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(XML);

                XmlNodeList _inf = xml.GetElementsByTagName("infEvento");

                string UF = string.Empty;
                string Amb = string.Empty;

                foreach (XmlNode _aux in _inf)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    UF = _elemento.GetElementsByTagName("cOrgao")[0].InnerText;
                    Amb = _elemento.GetElementsByTagName("tpAmb")[0].InnerText;
                }

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(XML);

                RecepcaoEvento ws = new RecepcaoEvento();
                ws.Url = Endereco_ws(UF, Amb);
                ws.ClientCertificates.Add(CertificadoDigital.Certificado);
                ws.nfeCabecMsgValue = Cabecalho(UF, Amb);

                return ws.nfeRecepcaoEvento(xdoc).OuterXml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private nfeCabecMsg Cabecalho(string _UF, string _Amb)
        {
            try
            {
                nfeCabecMsg cabec = new nfeCabecMsg();

                cabec.cUF = _UF;
                cabec.versaoDados = "1.00";

                return cabec;
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        private string Endereco_ws(string _UF, string _Amb)
        {
            switch (_Amb)
            {
                case "1":
                    switch (_UF)
                    {
                        case "35":
                            return "https://nfe.fazenda.sp.gov.br/eventosWEB/services/RecepcaoEvento.asmx";

                    }
                    break;

                case "2":
                    switch (_UF)
                    {
                        case "35":
                            return "https://homologacao.nfe.fazenda.sp.gov.br/eventosWEB/services/RecepcaoEvento.asmx";

                    }
                    break;
            }
            return string.Empty;
        }
    }
}
