using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_OS
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public DateTime Data { get; set; }
        public DateTime Data_Abertura { get; set; }
        public DateTime Data_Orcamento { get; set; }
        public DateTime Data_Aprovacao { get; set; }
        public DateTime Data_Montagem { get; set; }
        public DateTime Data_Pronta { get; set; }
        public DateTime Data_Entrega { get; set; }

        public bool Garantia { get; set; }

        private string reclamacao { get; set; }
        public string Reclamacao
        {
            get
            {
                if (reclamacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(reclamacao);
            }

            set { reclamacao = value; }
        }

        private string observacao { get; set; }
        public string Observacao
        {
            get
            {
                if (observacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(observacao);
            }

            set { observacao = value; }
        }

        public int TipoAtendimento { get; set; }

        public int Tipo_Equipamento { get; set; }
        public int Marca { get; set; }

        private string info_equip_1 { get; set; }
        public string Info_Equip_1
        {
            get
            {
                if (info_equip_1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(info_equip_1);
            }

            set { info_equip_1 = value; }
        }

        private string info_equip_2 { get; set; }
        public string Info_Equip_2
        {
            get
            {
                if (info_equip_2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(info_equip_2);
            }

            set { info_equip_2 = value; }
        }

        private string info_equip_3 { get; set; }
        public string Info_Equip_3
        {
            get
            {
                if (info_equip_3 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(info_equip_3);
            }

            set { info_equip_3 = value; }
        }

        private string obs_equip_1 { get; set; }
        public string Obs_Equip_1
        {
            get
            {
                if (obs_equip_1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(obs_equip_1);
            }

            set { obs_equip_1 = value; }
        }

        private string obs_equip_2 { get; set; }
        public string Obs_Equip_2
        {
            get
            {
                if (obs_equip_2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(obs_equip_2);
            }

            set { obs_equip_2 = value; }
        }

        /// <summary>
        /// <para>1 - ABERTA</para>
        /// <para>2 - EM ORÇAMENTO</para>
        /// <para>3 - APROVADA</para>
        /// <para>4 - MONTAGEM</para>
        /// <para>5 - PRONTA</para>
        /// <para>6 - CONCLUÍDA</para>
        /// </summary>
        public int Status_OS { get; set; }

        /// <summary>
        /// ORÇAMENTO
        /// </summary>
        public int ID_UsuarioComissao1 { get; set; }

        /// <summary>
        /// MONTAGEM
        /// </summary>
        public int ID_UsuarioComissao2 { get; set; }

        public bool Faturado { get; set; }
        public bool NFe { get; set; }
        public int ID_NFe { get; set; }
        public bool Cancelado { get; set; }
        public string CPF_CNPJ { get; set; }

        public int ID_Pagamento { get; set; }
        public int ID_Parcelamento { get; set; }

        public List<DTO_Produto_Item> Item { get; set; }

        #region CONSULTA
        private DTO_Data consulta_status { get; set; }
        public DTO_Data Consulta_Status
        {
            get
            {
                if (consulta_status == null)
                {
                    consulta_status = new DTO_Data();
                    return consulta_status;
                }
                else
                    return consulta_status;
            }
            set
            {
                consulta_status = new DTO_Data();
                consulta_status = value;
            }
        }

        public int ID_UF { get; set; }
        public int Tipo_NF { get; set; }

        public int ID_Produto { get; set; }

        public bool Pesquisa_Faturado { get; set; }
        public bool Pesquisa_Cancelado { get; set; }
        public bool Pesquisa_EmitidoNFe { get; set; }
        public bool Pesquisa_Garantia { get; set; }
        #endregion
    }
}
