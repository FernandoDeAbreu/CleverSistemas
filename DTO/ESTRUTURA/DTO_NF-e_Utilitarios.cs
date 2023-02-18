using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Sistema.DTO
{
    public class DTO_CertificadoDigital
    {
        public X509Certificate2 Certificado { get; set; }
        public DateTime ValidadeInicial { get; set; }
        public DateTime ValidadeFinal { get; set; }
        public string ResumoCertificado { get; set; }
    }

    public class DTO_NFe_Retorno
    {
        public int tpAmb { get; set; }
        public string verAplic { get; set; }
        public string cStat { get; set; }
        public string xMotivo { get; set; }
        public string cUF { get; set; }
        public DateTime dhRecbto { get; set; }
        public string nRec { get; set; }
        public string Chave { get; set; }
    }
}
