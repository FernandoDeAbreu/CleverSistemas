using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Produto_Item
    {
        public int ID { get; set; }
        public int ID_Produto { get; set; }
        public string Barra { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; }
        public int Tipo { get; set; }
        public int ID_Empresa { get; set; }

        public double Quantidade { get; set; }
        public double Quantidade_Entregue { get; set; }
        public double Quantidade_Conferido { get; set; }

        public int ID_Tabela { get; set; }
        public int ID_Grade { get; set; }
        public string DescricaoGrade { get; set; }

        public double ValorCusto { get; set; }
        public double ValorProduto { get; set; }
        public double ValorVenda { get; set; }

        public double ValorIPI { get; set; }
        public double ValorST { get; set; }
        public double ValorTotal { get; set; }

        public double Margem { get; set; }
        public double Reajuste { get; set; }
        public double ValorAntigo { get; set; }

        private string informacao;
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

        /// <summary>
        ///<para>0 - VENDA</para>
        ///<para>1 - TROCA</para>
        ///<para>2 - BONIFICAÇÃO</para>
        ///<para>3 - COMODATO</para>
        /// </summary>
        public int TipoSaida { get; set; }

        public double Acrescimo { get; set; }
        public double Desconto { get; set; }

        private string descricao_produto;
        public string Descricao_Produto
        {
            get
            {
                if (descricao_produto == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_produto);
            }

            set { descricao_produto = value; }
        }

        private string descricao_saida;
        public string Descricao_Saida
        {
            get
            {
                if (descricao_saida == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_saida);
            }

            set { descricao_saida = value; }
        }

        public int ID_Fornecedor { get; set; }

        private string nfe_unidade;
        public string NFe_Unidade
        {
            get
            {
                if (nfe_unidade == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(nfe_unidade);
            }

            set { nfe_unidade = value; }
        }


        private string nfe_descricao;
        public string NFe_Descricao
        {
            get
            {
                if (nfe_descricao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(nfe_descricao);
            }

            set { nfe_descricao = value; }
        }


        private string nfe_codigoproduto;
        public string NFe_CodigoProduto
        {
            get
            {
                if (nfe_codigoproduto == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(nfe_codigoproduto);
            }

            set { nfe_codigoproduto = value; }
        }
        #region CONSULTA
        private string descricao { get; set; }
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

        private string marca { get; set; }
        public string Marca
        {
            get
            {
                if (marca == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(marca);
            }

            set { marca = value; }
        }

        public double ValorCompra { get; set; }
        public double OutrosCustos { get; set; }
        #endregion
    }
}
