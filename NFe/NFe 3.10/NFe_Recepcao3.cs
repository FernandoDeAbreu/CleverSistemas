using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Sistema.NFe.ws_NFeAutorizacao3;
using Sistema.UTIL;
using Sistema.DTO;
using Sistema.BLL;

namespace Sistema.NFe
{
    public class NFe_Recepcao3
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
                int Mod = 0;

                foreach (XmlNode _aux in _ide)
                {
                    XmlElement _elemento = (XmlElement)_aux;
                    UF = _elemento.GetElementsByTagName("cUF")[0].InnerText;
                    Amb = _elemento.GetElementsByTagName("tpAmb")[0].InnerText;
                    Mod = Convert.ToInt32(_elemento.GetElementsByTagName("mod")[0].InnerText);
                }

                string aux = xml.InnerXml;
                string Tipo_Processo = "<indSinc>0</indSinc>";
                aux = aux.Replace("<NFe", "<enviNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"3.10\"><idLote>1</idLote>" + Tipo_Processo + "<NFe");
                aux = aux.Replace("</NFe>", "</NFe></enviNFe>");

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(aux.ToString());

                NfeAutorizacao ws = new NfeAutorizacao();
                ws.Url = Endereco_ws(UF, Amb, Mod);
                ws.ClientCertificates.Add(CertificadoDigital.Certificado);
                ws.nfeCabecMsgValue = Cabecalho(UF, Amb);

                return ws.nfeAutorizacaoLote(xdoc).OuterXml;
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

        private string Endereco_ws(string _UF, string _Amb, int _Mod)
        {
            if (_Mod == 55)
                switch (_Amb)
                {
                    case "1":
                        switch (_UF)
                        {
                            case "31":
                                return "https://nfe.fazenda.mg.gov.br/nfe2/services/NfeAutorizacao";

                            case "35":
                                return "https://nfe.fazenda.sp.gov.br/ws/nfeautorizacao.asmx";

                        }
                        break;

                    case "2":
                        switch (_UF)
                        {
                            case "31":
                                return "https://hnfe.fazenda.mg.gov.br/nfe2/services/NfeAutorizacao";

                            case "35":
                                return "https://homologacao.nfe.fazenda.sp.gov.br/ws/nfeautorizacao.asmx";

                            case "28":
                                return "https://nfe-homologacao.svrs.rs.gov.br/ws/NfeAutorizacao/NFeAutorizacao.asmx";
                        }
                        break;
                }

            if (_Mod == 65)
                switch (_Amb)
                {
                    case "1":
                        switch (_UF)
                        {
                            case "35":
                                return "https://nfce.fazenda.sp.gov.br/ws/nfeautorizacao.asmx";

                        }
                        break;

                    case "2":
                        switch (_UF)
                        {
                            case "35":
                                return "https://homologacao.nfce.fazenda.sp.gov.br/ws/nfeautorizacao.asmx";

                        }
                        break;
                }
            return string.Empty;
        }
    }
}
