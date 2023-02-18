using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Banco
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Banco { get; set; }

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
        public int ID_Caixa { get; set; }
        public double Limite { get; set; }
    }

    public class DTO_Cedente
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }

        public bool Ativo { get; set; }

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

        private string instrucao_1;
        public string Instrucao_1
        {
            get
            {
                if (instrucao_1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(instrucao_1);
            }

            set { instrucao_1 = value; }
        }

        private string instrucao_2;
        public string Instrucao_2
        {
            get
            {
                if (instrucao_2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(instrucao_2);
            }

            set { instrucao_2 = value; }
        }

        public int Cod_Cedente { get; set; }
        public int Carteira { get; set; }

        public double Juros { get; set; }
        public int DiasJuros { get; set; }

        public double Multa { get; set; }
        public int DiasMulta { get; set; }

        public int ID_Banco { get; set; }

        public int ID_Conta { get; set; }

        public int Tipo_Doc_Cedente { get; set; }

        private string cnpj_cpf_cedente;
        public string CNPJ_CPF_Cedente
        {
            get
            {
                if (cnpj_cpf_cedente == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpj_cpf_cedente);
            }

            set { cnpj_cpf_cedente = value; }
        }

        private string razao_cedente { get; set; }
        public string Razao_Cedente
        {
            get
            {
                if (razao_cedente == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(razao_cedente);
            }

            set { razao_cedente = value; }
        }

        public bool UtilizaTarifa { get; set; }
        public double Tarifa { get; set; }

        public int Cod_Protesto { get; set; }
        public int DiaProtesto { get; set; }
        public bool Aceite { get; set; }
        
        public int Tipo_Cobranca { get; set; }

        /// <summary>
        /// <para>1 - EMISSÃO CEDENTE</para>
        /// <para>2 - EMISSÃO BANCO</para>
        /// </summary>
        public int Tipo_Emissao { get; set; }

        public bool Altera_Data { get; set; }

        #region INFORMAÇÕES RETORNO/REMESSA
        public int TipoDocumento { get; set; }

        private string cnpj_cpf { get; set; }
        public string CNPJ_CPF
        {
            get
            {
                if (cnpj_cpf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpj_cpf);
            }

            set { cnpj_cpf = value; }
        }

        private string descricaoempresa { get; set; }
        public string DescricaoEmpresa
        {
            get
            {
                if (descricaoempresa == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricaoempresa);
            }

            set { descricaoempresa = value; }
        }

        public string descricaobanco { get; set; }
        public string DescricaoBanco
        {
            get
            {
                if (descricaobanco == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricaobanco);
            }

            set { descricaobanco = value; }
        }
        #endregion

        #region CONSULTA
        public bool FiltraAtivo { get; set; }
        #endregion
    }
}
