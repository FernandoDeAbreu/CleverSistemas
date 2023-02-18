using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_CReceber
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }

        public int ID_Conta { get; set; }

        /// <summary>
        /// <para>1 - EM ABERTO</para>
        /// <para>2 - PAGO</para>
        /// </summary>
        public int Situacao { get; set; }

        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataBaixa { get; set; }

        public int ID_UsuarioLancamento { get; set; }

        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        public double Desconto { get; set; }
        public double Acrescimo { get; set; }
        public double Valor { get; set; }

        public int QuantidadeParcela { get; set; }
        public int Parcela { get; set; }
        public int Controle { get; set; }

        private string documento { get; set; }
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

        public int ID_NFe { get; set; }

        public int ID_Venda { get; set; }
        public int ID_OS { get; set; }
        public int ID_PrevisaoPagto { get; set; }

        public int Altera_Registro { get; set; }

        #region CONSULTA
        public bool Filtra_Boleto { get; set; }
        public bool Boleto { get; set; }

        /// <summary>
        ///<para> 1 - TipoPessoa, ID_Pessoa, Vencimento</para>
        ///<para> 2 - Vencimento, TipoPessoa, ID_Pessoa</para> 
        /// </summary>
        public int Ordena_Por { get; set; }

        public string ListaID { get; set; }

        private DTO_Data consulta_vencimento { get; set; }
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

        private DTO_Data consulta_baixa { get; set; }
        public DTO_Data Consulta_Baixa
        {
            get
            {
                if (consulta_baixa == null)
                {
                    consulta_baixa = new DTO_Data();
                    return consulta_baixa;
                }
                else
                    return consulta_baixa;
            }
            set
            {
                consulta_baixa = new DTO_Data();
                consulta_baixa = value;
            }
        }

        private string grupoconta { get; set; }
        public string GrupoConta
        {
            get
            {
                if (grupoconta == null)
                    return string.Empty;
                else
                {
                    if (grupoconta.Substring(0, 1) == "0")
                        if (grupoconta.Substring(1, 1) == "0")
                            return " " + grupoconta.Substring(2).Replace("00", "").Replace(".0", ". ");
                        else
                            return " " + grupoconta.Substring(1).Replace("00", "").Replace(".0", ". ");
                    else
                        return grupoconta.Replace("00", "").Replace(".0", ". ");
                }
            }

            set { grupoconta = value; }
        }
        #endregion
    }

    public class DTO_CPagar
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }

        public int ID_Conta { get; set; }

        /// <summary>
        /// <para>1 - EM ABERTO</para>
        /// <para>2 - PAGO</para>
        /// </summary>
        public int Situacao { get; set; }

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

        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataBaixa { get; set; }

        public int ID_UsuarioLancamento { get; set; }

        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        public double Desconto { get; set; }
        public double Acrescimo { get; set; }
        public double Valor { get; set; }

        public int QuantidadeParcela { get; set; }
        public int Parcela { get; set; }
        public int Controle { get; set; }

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

        private string informacaobaixa { get; set; }
        public string InformacaoBaixa
        {
            get
            {
                if (informacaobaixa == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(informacaobaixa);
            }

            set { informacaobaixa = value; }
        }

        public int Altera_Registro { get; set; }

        #region CONSULTA
        private DTO_Data consulta_vencimento { get; set; }
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

        private DTO_Data consulta_baixa { get; set; }
        public DTO_Data Consulta_Baixa
        {
            get
            {
                if (consulta_baixa == null)
                {
                    consulta_baixa = new DTO_Data();
                    return consulta_baixa;
                }
                else
                    return consulta_baixa;
            }
            set
            {
                consulta_baixa = new DTO_Data();
                consulta_baixa = value;
            }
        }


        /// <summary>
        ///<para> 1 - TipoPessoa, ID_Pessoa, Vencimento</para>
        ///<para> 2 - Vencimento, TipoPessoa, ID_Pessoa</para> 
        /// </summary>
        public int Ordena_Por { get; set; }

        private string grupoconta { get; set; }
        public string GrupoConta
        {
            get
            {
                if (grupoconta == null)
                    return string.Empty;
                else
                {
                    if (grupoconta.Substring(0, 1) == "0")
                        if (grupoconta.Substring(1, 1) == "0")
                            return " " + grupoconta.Substring(2).Replace("00", "").Replace(".0", ". ");
                        else
                            return " " + grupoconta.Substring(1).Replace("00", "").Replace(".0", ". ");
                    else
                        return grupoconta.Replace("00", "").Replace(".0", ". ");
                }
            }

            set { grupoconta = value; }
        }

        public string ListaID { get; set; }
        #endregion
    }

    public class DTO_FluxoCaixa
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public DateTime Emissao { get; set; }
        public int Caixa { get; set; }

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

        public int ID_Conta { get; set; }
        public double Credito { get; set; }
        public double Debito { get; set; }

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

        public int ID_Cheque { get; set; }
        public int ID_CPagar { get; set; }
        public int ID_CReceber { get; set; }
        public bool Conciliado { get; set; }
        public int ID_Pagamento { get; set; }
        public bool Planejamento { get; set; }

        #region CONSULTA
        private string grupoconta { get; set; }
        public string GrupoConta
        {
            get
            {
                if (grupoconta == null)
                    return string.Empty;
                else
                {
                    if (grupoconta.Substring(0, 1) == "0")
                        if (grupoconta.Substring(1, 1) == "0")
                            return " " + grupoconta.Substring(2).Replace("00", "").Replace(".0", ". ");
                        else
                            return " " + grupoconta.Substring(1).Replace("00", "").Replace(".0", ". ");
                    else
                        return grupoconta.Replace("00", "").Replace(".0", ". ");
                }
            }

            set { grupoconta = value; }
        }

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

        public string ListaID { get; set; }

        public bool SomenteCheque { get; set; }
        #endregion
    }
}
