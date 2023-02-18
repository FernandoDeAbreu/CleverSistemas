using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Sistema.NFe.ws_NFeRecepcao2;
using Sistema.UTIL;
using Sistema.DTO;
using Sistema.BLL;

namespace Sistema.NFe
{
    public class NFe_Recepcao2
    {
        public string Transmite_XML(string XML, string Certificado)
        {
            try
            {
                #region CARREGA CERTIFICADO
                NFe_CertificadoDigital _cert = new NFe_CertificadoDigital();
                DTO_CertificadoDigital CertificadoDigital = new DTO_CertificadoDigital();

                CertificadoDigital = _cert.Carrega_Certificado(Certificado);
                #endregion


                XmlDocument xml = new XmlDocument();
                xml.Load(XML);

                XmlNodeList _ide = xml.GetElementsByTagName("ide");

                string UF = string.Empty;
                string Amb = string.Empty;

                foreach (XmlNode _aux in _ide)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    UF = _elemento.GetElementsByTagName("cUF")[0].InnerText;
                    Amb = _elemento.GetElementsByTagName("tpAmb")[0].InnerText;
                }

                string aux = xml.InnerXml;
                aux = aux.Replace("<NFe", "<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"2.00\"><idLote>1</idLote><NFe");
                aux = aux.Replace("</NFe>", "</NFe></enviNFe>");

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(aux.ToString());

                NfeRecepcao2 ws = new NfeRecepcao2();
                ws.Url = Endereco_ws(UF, Amb);
                ws.ClientCertificates.Add(CertificadoDigital.Certificado);
                ws.nfeCabecMsgValue = Cabecalho(UF, Amb);
                
                return ws.nfeRecepcaoLote2(xdoc).OuterXml;
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
                cabec.versaoDados = "3.10";

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
                            return "https://nfe.fazenda.sp.gov.br/nfeweb/services/nferecepcao2.asmx";

                    }
                    break;

                case "2":
                    switch (_UF)
                    {
                        case "35":
                            return "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeRecepcao2.asmx";

                    }
                    break;
            }
            return string.Empty;
        }
    }
}
