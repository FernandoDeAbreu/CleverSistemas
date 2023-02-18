using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.IO;
using Sistema.UTIL;
using Sistema.DTO;
using System.Windows.Forms;

namespace Sistema.NFe
{
    public class NFe_CertificadoDigital
    {
        public DTO_CertificadoDigital Seleciona_Certificado()
        {
            try
            {
                X509Certificate2 _509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);

                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                X509Certificate2Collection collection2 = (X509Certificate2Collection)collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);
                X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificados Digitais disponíveis", "Selecione o certificado digital para uso no aplicativo", X509SelectionFlag.SingleSelection);

                if (scollection.Count == 0)
                    throw new Exception(util_msg.msg_Cert_NaoEncontrado);
                else
                {
                    if (Convert.ToInt32(DateTime.Compare(DateTime.Now, collection1[0].NotAfter)) > 0)
                        throw new Exception(util_msg.msg_Cert_Vencido);

                    _509Cert = scollection[0];

                    DTO_CertificadoDigital _Cert = new DTO_CertificadoDigital();
                    _Cert.Certificado = _509Cert;
                    _Cert.ResumoCertificado = _509Cert.Subject;
                    _Cert.ValidadeInicial = _509Cert.NotBefore;
                    _Cert.ValidadeFinal = _509Cert.NotAfter;

                    return _Cert;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        public DTO_CertificadoDigital Carrega_Certificado(string _nome)
        {
            try
            {
                X509Certificate2 _509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, _nome, false);

                if (collection1.Count == 0)
                    throw new Exception(util_msg.msg_Cert_NaoEncontrado);
                else
                {
                    if (Convert.ToInt32(DateTime.Compare(DateTime.Now, collection1[0].NotAfter)) > 0)
                        throw new Exception(util_msg.msg_Cert_Vencido);

                    _509Cert = collection1[0];

                    DTO_CertificadoDigital _Cert = new DTO_CertificadoDigital();

                    _Cert.Certificado = _509Cert;
                    _Cert.ResumoCertificado = _509Cert.Subject;
                    _Cert.ValidadeInicial = _509Cert.NotBefore;
                    _Cert.ValidadeFinal = _509Cert.NotAfter;

                    return _Cert;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        public void Assina_XML(string _XML, string _Certificado)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.Load(_XML);

                X509Certificate2 _509Cert = new X509Certificate2();
                _509Cert = Carrega_Certificado(_Certificado).Certificado;

                int qtdeRef = doc.GetElementsByTagName("infNFe").Count;

                if (qtdeRef != 1)
                    throw new Exception(util_msg.msg_NFe_ErroTag);
                else
                    if (doc.GetElementsByTagName("Signature").Count == 0)
                    {
                        SignedXml signedXml = new SignedXml(doc);
                        signedXml.SigningKey = _509Cert.PrivateKey;
                        Reference reference = new Reference();
                        XmlAttributeCollection _Uri = doc.GetElementsByTagName("infNFe").Item(0).Attributes;
                        foreach (XmlAttribute _atributo in _Uri)
                        {
                            if (_atributo.Name == "Id")
                                reference.Uri = "#" + _atributo.InnerText;
                        }

                        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                        reference.AddTransform(env);

                        XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                        reference.AddTransform(c14);

                        signedXml.AddReference(reference);

                        KeyInfo keyInfo = new KeyInfo();

                        keyInfo.AddClause(new KeyInfoX509Data(_509Cert));

                        signedXml.KeyInfo = keyInfo;
                        signedXml.ComputeSignature();

                        XmlElement xmlDigitalSignature = signedXml.GetXml();

                        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                        XmlDocument aux = new XmlDocument();
                        aux.PreserveWhitespace = false;
                        aux = doc;

                        string XML_Assinado = aux.OuterXml;

                        StreamWriter SW_2 = File.CreateText(_XML);
                        SW_2.Write(XML_Assinado);
                        SW_2.Close();
                    }

                if (!Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Assinado))
                    System.IO.Directory.CreateDirectory(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Assinado);

                string XML_aux2 = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Assinado + _XML.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Envia, "");

                if (Directory.Exists(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro))
                {
                    string XML_aux = Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Erro + _XML.Replace(Parametro_NFe_NFC_SAT.Caminho_NFe + util_Param.XML_Envia, "");

                    if (File.Exists(XML_aux))
                        File.Delete(XML_aux);
                }

                if (File.Exists(XML_aux2))
                    File.Delete(XML_aux2);

                File.Move(_XML, XML_aux2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Assina_XML(XmlDocument doc, string _Certificado)
        {
            try
            {
                X509Certificate2 _509Cert = new X509Certificate2();
                _509Cert = Carrega_Certificado(_Certificado).Certificado;

                int qtdeRef = doc.GetElementsByTagName("infEvento").Count;

                if (qtdeRef != 1)
                    throw new Exception(util_msg.msg_NFe_ErroTag);
                else
                    if (doc.GetElementsByTagName("Signature").Count == 0)
                    {
                        SignedXml signedXml = new SignedXml(doc);
                        signedXml.SigningKey = _509Cert.PrivateKey;
                        Reference reference = new Reference();
                        XmlAttributeCollection _Uri = doc.GetElementsByTagName("infEvento").Item(0).Attributes;
                        foreach (XmlAttribute _atributo in _Uri)
                        {
                            if (_atributo.Name == "Id")
                                reference.Uri = "#" + _atributo.InnerText;
                        }

                        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                        reference.AddTransform(env);

                        XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                        reference.AddTransform(c14);

                        signedXml.AddReference(reference);

                        KeyInfo keyInfo = new KeyInfo();

                        keyInfo.AddClause(new KeyInfoX509Data(_509Cert));

                        signedXml.KeyInfo = keyInfo;
                        signedXml.ComputeSignature();

                        XmlElement xmlDigitalSignature = signedXml.GetXml();

                        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                        XmlDocument aux = new XmlDocument();
                        aux.PreserveWhitespace = false;
                        aux = doc;

                        return aux.OuterXml;
                    }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Assina_XMLInut(XmlDocument doc, string _Certificado)
        {
            try
            {
                X509Certificate2 _509Cert = new X509Certificate2();
                _509Cert = Carrega_Certificado(_Certificado).Certificado;

                int qtdeRef = doc.GetElementsByTagName("infInut").Count;

                if (qtdeRef != 1)
                    throw new Exception(util_msg.msg_NFe_ErroTag);
                else
                    if (doc.GetElementsByTagName("Signature").Count == 0)
                    {
                        SignedXml signedXml = new SignedXml(doc);
                        signedXml.SigningKey = _509Cert.PrivateKey;
                        Reference reference = new Reference();
                        XmlAttributeCollection _Uri = doc.GetElementsByTagName("infInut").Item(0).Attributes;
                        foreach (XmlAttribute _atributo in _Uri)
                        {
                            if (_atributo.Name == "Id")
                                reference.Uri = "#" + _atributo.InnerText;
                        }

                        XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                        reference.AddTransform(env);

                        XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                        reference.AddTransform(c14);

                        signedXml.AddReference(reference);

                        KeyInfo keyInfo = new KeyInfo();

                        keyInfo.AddClause(new KeyInfoX509Data(_509Cert));

                        signedXml.KeyInfo = keyInfo;
                        signedXml.ComputeSignature();

                        XmlElement xmlDigitalSignature = signedXml.GetXml();

                        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                        XmlDocument aux = new XmlDocument();
                        aux.PreserveWhitespace = false;
                        aux = doc;

                        return aux.OuterXml;
                    }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
