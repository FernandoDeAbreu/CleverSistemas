using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Pagamento
    {
        public int ID { get; set; }

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

        /// <summary>
        ///<para>1 - BOLETO</para> 
        ///<para>2 - CARTÃO CRÉDITO / DÉBITO</para> 
        ///<para>3 - CHEQUE</para> 
        ///<para>4 - DINHEIRO</para> 
        ///<para>5 - CARTEIRA</para>
        ///<para>6 - OUTROS</para>
        /// </summary>
        public int Tipo { get; set; }        
        
        public bool Recebimento { get; set; }
        public bool Pagamento { get; set; }

        public double Porc_Custo { get; set; }

        public int Dia_Lancamento { get; set; }

        public List<DTO_Parcelamento> Parcelamento { get; set; }

        #region CONSULTA
        public bool FiltraPagamento { get; set; }
        public bool FiltraBaixa { get; set; }
        #endregion
    }

    public class DTO_Parcelamento
    {
        public int ID { get; set; }
        public bool Personalizado { get; set; }
        public string Parcelamento { get; set; }
        public int  Periodo { get; set; }
    }

    public class DTO_Pagamento_Lanca
    {

        public int ID { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public bool Concluido { get; set; }

        /// <summary>
        /// <para>1 - PAGAMENTO CONTA</para>
        /// <para>2 - RECEBIMENTO CONTA</para>
        /// <para>3 - RECEBIMENTO VENDA</para>
        /// </summary>
        public int TipoLancamento { get; set; }

        public string GrupoConta { get; set; }
        public string Cod_Banco { get; set; }
        public string Agencia { get; set; }
        public string Documento { get; set; }
        public int[] ID_Cheque { get; set; }
        public int[] ID_FluxoCaixa { get; set; }
        public double ValorTotal { get; set; }
        public int Caixa { get; set; }
        public string ContaLancamento { get; set; }
        public int ID_TipoPagamento { get; set; }
    }

    public class DTO_Lancamento
    {
        /// <summary>
        ///<para>1 - BOLETO</para> 
        ///<para>2 - CARTÃO</para> 
        ///<para>3 - CHEQUE</para> 
        ///<para>4 - DINHEIRO</para> 
        ///<para>5 - CARTEIRA</para>
        ///<para>6 - OUTROS</para>
        /// </summary>
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public DTO_CReceber CReceber { get; set; }
        public DTO_CPagar CPagar { get; set; }
        public DTO_Cheque Cheque { get; set; }
        public DTO_FluxoCaixa FluxoCaixa { get; set; }
        public DTO_Cartao Cartao { get; set; }
    }

    public class DTO_ValorParcela
    {
        public int Periodo { get; set; }
        public double ValorParcela { get; set; }
    }
}
