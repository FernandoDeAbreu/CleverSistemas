using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_UF_AliquotaICMS
    {
        public int ID_UF_Destino { get; set; }
        public double Aliquota { get; set; }
    }

    public class DTO_Municipio
    {
        public int ID { get; set; }
        public int ID_Municipio { get; set; }
        public int ID_Pais { get; set; }
        public int ID_UF { get; set; }

        private string descricao;
        public string Descricao
        {
            get
            {
                if (descricao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao);
            }

            set { descricao = value; }
        }

        private string sigla;
        public string Sigla
        {
            get
            {
                if (sigla == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(sigla);
            }

            set { sigla = value; }
        }

        public double Aliquota_Interna { get; set; }
        public double Aliquota_FCP { get; set; }

        public List<DTO_UF_AliquotaICMS> _lst_AliquotaICMS { get; set; }

        #region CONSULTA
        /// <summary>
        /// <para>1 - CONSULTA ALIQUOTA</para>
        /// <para>2 - CONSULTA PARA ALTERAÇÃO DE ALIQUOTA</para>
        /// <para>3 - CONSULTA PARA CADASTRO DE NOVAS ALIQUOTAS</para>
        /// </summary>
        public int Tipo_Consulta { get; set; }
        public int ID_UF_Origem { get; set; }
        public int ID_UF_Destino { get; set; }
        #endregion
    }
}
