using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Imposto
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }

        private string descricao;
        public string Descricao
        {
            get
            {
                if (descricao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao)
                    ;
            }
            set { descricao = value; }
        }

        public List<DTO_Tributacao> lst_Tributacao { get; set; }

        #region CONSULTA
        public bool FiltraConsultaEstado { get; set; }
        public int[] Produto { get; set; }
        public int ID_Produto { get; set; }
        public int ID_Tributacao { get; set; }
        #endregion
    }
    public class DTO_Tributacao
    {
        public int ID { get; set; }
        public int ID_Imposto { get; set; }

        public int Tipo_NF { get; set; }
        public string DescricaoTipoEmissao { get; set; }

        //CFOP
        private string cfop;
        public string CFOP
        {
            get
            {
                if (cfop == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cfop)
                    ;
            }
            set { cfop = value; }
        }

        //ICMS
        public int CST { get; set; }
        public int Origem { get; set; }
        public int ModalidadeBC { get; set; }
        public double AliquotaICMS { get; set; }
        public double PercentualReducao { get; set; }
        public int ModalidadeBCST { get; set; }
        public double AliquotaICMSST { get; set; }
        public double PercentualReducaoST { get; set; }
        public double MargemVLAdicionado { get; set; }
        public double vICMSDeson { get; set; }
        public double vICMSOp { get; set; }
        public double pDif { get; set; }
        public double vICMSDif { get; set; }

        //PIS
        public int CSTPIS { get; set; }
        public double AliquotaPIS { get; set; }
        public double AliquotaPISST { get; set; }

        //COFINS
        public int CSTCOFINS { get; set; }
        public double AliquotaCOFINS { get; set; }
        public double AliquotaCOFINSST { get; set; }

        //IPI
        public int CSTIPI { get; set; }
        public double AliquotaIPI { get; set; }
        private string cod_enquadramento;
        public string Cod_Enquadramento
        {
            get
            {
                if (cod_enquadramento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cod_enquadramento)
                    ;
            }
            set { cod_enquadramento = value; }
        }

        public int[] lst_UF { get; set; }

        #region CONSULTA
        public int ID_UF { get; set; }
        #endregion
    }
}
