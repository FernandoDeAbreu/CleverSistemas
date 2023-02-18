using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Sistema.NFe.ws_NFeRetRecepcao2;
using Sistema.UTIL;
using Sistema.DTO;
using Sistema.BLL;

namespace Sistema.NFe
{
    public class NFe_RetRecepcao2
    {
        public string ConsultaProcesso(string XML, string Protocolo, string Certificado)
        {
            #region CARREGA CERTIFICADO
            NFe_CertificadoDigital _cert = new NFe_CertificadoDigital();
            DTO_CertificadoDigital CertificadoDigital = new DTO_CertificadoDigital();

            CertificadoDigital = _cert.Carrega_Certificado(Certificado);
            #endregion

            #region TRATA XML
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
            #endregion

            #region CRIANDO XML MENSAGEM
            DataSet ds_xml = new DataSet();
            DataRow DR;

            ds_xml.ReadXmlSchema(Parametro_Sistema.Caminho_Sistema + util_Param.Schemas + "consReciNFe_v2.00.xsd");
            ds_xml.EnforceConstraints = false;

            DR = ds_xml.Tables["consReciNFe"].NewRow();

            DR["versao"] = "2.00";
            DR["tpAmb"] = Parametro_NFe_NFC_SAT.AmbienteNFe;
            DR["nRec"] = Protocolo;

            ds_xml.Tables["consReciNFe"].Rows.Add(DR);

            StringWriter txt_XML = new StringWriter();
            txt_XML.NewLine = "";

            ds_xml.WriteXml(txt_XML);

            string Aux = util_dados.Limpa_StringXML(txt_XML.ToString());

            txt_XML.GetStringBuilder().Replace(Aux, "").Replace("<NewDataSet", "");
            txt_XML.GetStringBuilder().Replace(Aux, "").Replace("</NewDataSet>", "");

            txt_XML.GetStringBuilder().Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.portalfiscal.inf.br/nfe\">  ", "");
            txt_XML.GetStringBuilder().Replace(Aux, "").Replace("<consReciNFe", "<consReciNFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"");

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(txt_XML.ToString());
            #endregion

            NfeRetRecepcao2 ws = new NfeRetRecepcao2();
            ws.Url = Endereco_ws(UF, Amb);
            ws.ClientCertificates.Add(CertificadoDigital.Certificado);
            ws.nfeCabecMsgValue = Cabecalho(UF, Amb);

            return ws.nfeRetRecepcao2(xdoc).OuterXml;
        }

        private static nfeCabecMsg Cabecalho(string _UF, string _Amb)
        {
            try
            {
                nfeCabecMsg cabec = new nfeCabecMsg();

                cabec.cUF = _UF;
                cabec.versaoDados = "2.00";

                return cabec;
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        private static string Endereco_ws(string _UF, string _Amb)
        {
            switch (_Amb)
            {
                case "1":
                    switch (_UF)
                    {
                        case "35":
                            return "https://nfe.fazenda.sp.gov.br/nfeweb/services/nferetrecepcao2.asmx";

                    }
                    break;

                case "2":
                    switch (_UF)
                    {
                        case "35":
                            return "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeRetRecepcao2.asmx";

                    }
                    break;
            }
            return string.Empty;
        }
    }
}
