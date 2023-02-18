using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Sistema.NFe
{
    [Serializable]
    [XmlRoot(ElementName = "envEvento", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class envEvento
    {
        #region Versao
        [XmlAttribute(AttributeName = "versao")]
        public string Versao { get; set; }
        #endregion

        #region idLote
        [XmlElement(ElementName = "idLote")]
        public int IdLote { get; set; }     
        #endregion
                
        [XmlElement(ElementName = "infEvento")]
        public infEvento Evento { get; set; }
    }

    [XmlRoot(ElementName = "infEvento")]
    public class infEvento
    {
        #region cOrgao
        [XmlElement(ElementName = "cOrgao")]
        public string cOrgao { get; set; }
        #endregion

        #region tpAmb
        [XmlElement(ElementName = "tpAmb")]
        public string tpAmb { get; set; }
        #endregion

        #region CNPJ
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }
        #endregion

        #region chNFe
        [XmlElement(ElementName = "chNFe")]
        public string chNFe { get; set; }
        #endregion

        #region dhEvento
        [XmlElement(ElementName = "dhEvento")]
        public string dhEvento { get; set; }
        #endregion

        #region tpEvento
        [XmlElement(ElementName = "tpEvento")]
        public string tpEvento { get; set; }
        #endregion

        #region nSeqEvento
        [XmlElement(ElementName = "nSeqEvento")]
        public string nSeqEvento { get; set; }
        #endregion

        #region verEvento
        [XmlElement(ElementName = "verEvento")]
        public string verEvento { get; set; }
        #endregion

        #region detEvento
        private detEvento _detevento;
        [XmlElement(ElementName = "detEvento")]
        public detEvento _detEvento
        {
            get { return _detevento; }
            set { _detevento = value; }
        }
        #endregion
    }

    [XmlRoot(ElementName = "detEvento")]
    public class detEvento
    {
        #region Versao
        [XmlAttribute(AttributeName = "versao")]
        public string Versao { get; set; }
        #endregion

        #region descEvento
        [XmlElement(ElementName = "descEvento")]
        public string descEvento { get; set; }
        #endregion

        #region xCorrecao
        [XmlElement(ElementName = "xCorrecao")]
        public string xCorrecao { get; set; }
        #endregion

        #region xCondUso
        [XmlElement(ElementName = "xCondUso")]
        public string xCondUso { get; set; }
        #endregion

        #region nProt
        [XmlElement(ElementName = "nProt")]
        public string nProt { get; set; }
        #endregion

        #region xJust
        [XmlElement(ElementName = "xJust")]
        public string xJust { get; set; }
        #endregion
    }
}
