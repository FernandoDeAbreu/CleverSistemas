using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Cheque
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }

        /// <summary>
        /// <para>1 - EMITIDOS</para>
        /// <para>2 - RECEBIDOS</para>
        /// </summary>
        public int Tipo { get; set; }

        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }

        /// <summary>
        /// <para>1 - DISPONIVEL</para>
        /// <para>2 - DEVOLVIDO</para>
        /// <para>3 - DEPOSITADO</para>
        /// <para>4 - PAGTO TERCEIRO</para>
        /// <para>5 - COMPENSADO</para>
        /// </summary>
        public int Situacao { get; set; }

        public double Valor { get; set; }
        public int ID_Conta { get; set; }
        public int ID_Cheque { get; set; }

        private string documento;
        public string Documento
        {
            get
            {
                if (documento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(documento);
            }

            set { documento = value; }
        }

        private string banco;
        public string Banco
        {
            get
            {
                if (banco == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(banco);
            }

            set { banco = value; }
        }

        private string agencia;
        public string Agencia
        {
            get
            {
                if (agencia == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(agencia);
            }

            set { agencia = value; }
        }

        private string conta;
        public string Conta
        {
            get
            {
                if (conta == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(conta);
            }

            set { conta = value; }
        }

        private string cheque;
        public string Cheque
        {
            get
            {
                if (cheque == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cheque);
            }

            set { cheque = value; }
        }

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

        #region CONSULTA
        private DTO_Data consulta_emissao;
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

        private DTO_Data consulta_vencimento;
        public DTO_Data Consulta_Vencimento
        {
            get
            {
                if (consulta_vencimento == null)
                {
                    consulta_vencimento = new DTO_Data();
                    return consulta_vencimento;
                }
                else
                    return consulta_vencimento;
            }
            set
            {
                consulta_vencimento = new DTO_Data();
                consulta_vencimento = value;
            }
        }
        
        public int ID_Caixa { get; set; }        
        #endregion
    }
}
