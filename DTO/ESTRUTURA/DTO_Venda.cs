using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Venda
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public DateTime Data { get; set; }
        public DateTime Entrega { get; set; }
        public DateTime DataFatura { get; set; }

        private string informacao { get; set; }
        public string Informacao
        {
            get
            {
                if (informacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(informacao);
            }

            set { informacao = value; }
        }

        public int ID_UsuarioComissao1 { get; set; }
        public int ID_UsuarioComissao2 { get; set; }

        private string comprador { get; set; }
        public string Comprador
        {
            get
            {
                if (comprador == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(comprador);
            }

            set { comprador = value; }
        }

        public bool Faturado { get; set; }
        public bool NFe { get; set; }
        public int ID_NFe { get; set; }
        public bool Cancelado { get; set; }

        public int ID_Pagamento { get; set; }
        public int ID_Parcelamento { get; set; }

        /// <summary>
        /// <para>0 - ENTREGUE</para>
        /// <para>1 - AGUARDANDO</para>
        /// <para>2 - ENTREGA PARCIAL</para>
        /// </summary>
        public int Situacao_Entrega { get; set; }

        /// <summary>
        /// <para>0 - NÃO CONFERIDO</para>
        /// <para>1 - EM CONFERENCIA</para>
        /// <para>2 - CONFERIDO</para>
        /// </summary>
        public int Situacao_Conferencia { get; set; }
        public int ID_Usuario_Conferencia { get; set; }
        public string CPF_CNPJ { get; set; }
        public List<DTO_Produto_Item> Item { get; set; }

        #region CONSULTA
        private DTO_Data consulta_emissao { get; set; }
        public DTO_Data Consulta_Emissao
        {
            get
            {
                if (consulta_emissao == null)
                {
                    consulta_emissao = new DTO_Data();
                    return consulta_emissao;
                }
                else
                    return consulta_emissao;
            }
            set
            {
                consulta_emissao = new DTO_Data();
                consulta_emissao = value;
            }
        }

        private DTO_Data consulta_fatura { get; set; }
        public DTO_Data Consulta_Fatura
        {
            get
            {
                if (consulta_fatura == null)
                {
                    consulta_fatura = new DTO_Data();
                    return consulta_fatura;
                }
                else
                    return consulta_fatura;
            }
            set
            {
                consulta_fatura = new DTO_Data();
                consulta_fatura = value;
            }
        }

        private DTO_Data consulta_entrega { get; set; }
        public DTO_Data Consulta_Entrega
        {
            get
            {
                if (consulta_entrega == null)
                {
                    consulta_entrega = new DTO_Data();
                    return consulta_entrega;
                }
                else
                    return consulta_entrega;
            }
            set
            {
                consulta_entrega = new DTO_Data();
                consulta_entrega = value;
            }
        }

        public int ID_UF { get; set; }
        public int Tipo_NF { get; set; }

        public int ID_Produto { get; set; }

        public bool Pesquisa_Faturado { get; set; }
        public bool Pesquisa_Cancelado { get; set; }
        public bool Pesquisa_EmitidoNFe { get; set; }

        public int Dias_Inativo { get; set; }

        public bool PesquisaInativo { get; set; }
        public bool SituacaoInativo { get; set; }

        public string lst_ID_Venda { get; set; }
        #endregion
    }
}
