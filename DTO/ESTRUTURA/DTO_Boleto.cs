using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Boleto
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }

        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public int ID_Cedente { get; set; }

        public double Valor { get; set; }
        public double Desconto { get; set; }
        public double Acrescimo { get; set; }

        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataBaixa { get; set; }

        public FileStream Imagem { get; set; }
        public object ArqByteArray { get; set; }

        public int ID_Conta { get; set; }

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

        private string nossonumero { get; set; }
        public string NossoNumero
        {
            get
            {
                if (nossonumero == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(nossonumero);
            }

            set { nossonumero = value; }
        }

        public bool Liquidado { get; set; }

        public int[] ID_Boleto { get; set; }
        public int ID_Remessa { get; set; }
        public string  Arquivo { get; set; }

        /// <summary>
        /// <para>1 - REGISTRO DE TITULO</para>
        /// <para>2 - ALTERAÇÃO DE VENCIMENTO</para>
        /// <para>3 - BAIXA DE TITULO</para>
        /// <para>4 - PROTESTAR</para>
        /// <para>5 - SUSTAR PROTESTO E BAIXA DE TITULO</para>
        /// <para>6 - ALTERAÇÃO DIVERSAS</para>
        /// </summary>
        public int Movimento_Remessa { get; set; }

        public bool Cancelado { get; set; }

        #region CONSULTA
        public bool Filtra_Liquidado { get; set; }

        private DTO_Data consulta_vencimento { get; set; }
        private DTO_Data consulta_emissao { get; set; }
        private DTO_Data consulta_baixa { get; set; }

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
                consulta_emissao = new DTO_Data();
                consulta_emissao = value;
            }
        }

        public string List_ID { get; set; }

        public bool Filtra_Remessa { get; set; }
        public bool Remessa { get; set; }

        public bool Filtra_Cancelado { get; set; }
        #endregion
    }

    public class DTO_Retorno_Header400
    {
        public int Tipo { get; set; }
        public int Operacao { get; set; }
        public string DescricaoOperacao { get; set; }
        public int Servico { get; set; }
        public string DescricaoServico { get; set; }

        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        private DTO_Cedente cedente { get; set; }
        public DTO_Cedente Cedente
        {
            get
            {
                if (cedente == null)
                {
                    cedente = new DTO_Cedente();
                    return cedente;
                }
                else
                    return cedente;
            }
            set
            {
                cedente = new DTO_Cedente();
                cedente = value;
            }
        }

        public string ID_Banco { get; set; }
        public DateTime DataRetorno { get; set; }

        public bool Tratado { get; set; }
    }

    public class DTO_Retorno_Detalhe400
    {
        public int Tipo { get; set; }

        private DTO_Cedente cedente { get; set; }
        public DTO_Cedente Cedente
        {
            get
            {
                if (cedente == null)
                {
                    cedente = new DTO_Cedente();
                    return cedente;
                }
                else
                    return cedente;
            }
            set
            {
                cedente = new DTO_Cedente();
                cedente = value;
            }
        }

        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        public string NossoNumero { get; set; }
        public int Parcela { get; set; }
        public int Cod_Baixa { get; set; }
        public int Carteira { get; set; }
        public int Movimento { get; set; }
        public DateTime Data_Liquidacao { get; set; }
        public string Documento { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public double Valor { get; set; }
        public string Banco_Recebedor { get; set; }
        public string Agencia_Recebedor { get; set; }
        public int Tipo_Titulo { get; set; }
        public DateTime Data_Credito { get; set; }
        public double Tarifa { get; set; }
        public double OutrasDespesas { get; set; }
        public double ValorAbatimento { get; set; }
        public double Juros { get; set; }
        public double Desconto { get; set; }
        public double ValorPago { get; set; }
        public double ValorCreditado { get; set; }
    }

    public class DTO_Retorno_Trailler400
    {
        public int Tipo { get; set; }

        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }
    }

    public class DTO_Retorno_HeaderAquivo240
    {
        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        public int ID_Lote_Servico { get; set; }
        public int Tipo { get; set; }

        private DTO_Cedente cedente { get; set; }
        public DTO_Cedente Cedente
        {
            get
            {
                if (cedente == null)
                {
                    cedente = new DTO_Cedente();
                    return cedente;
                }
                else
                    return cedente;
            }
            set
            {
                cedente = new DTO_Cedente();
                cedente = value;
            }
        }

        public int Remessa_Retorno { get; set; }
        public DateTime DataGer_Arq { get; set; }
        public int Seq_Arquivo { get; set; }
        public int VersaoLayout { get; set; }

        public bool Tratado { get; set; }
    }

    public class DTO_Retorno_HeaderLote240
    {
        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        public int ID_Lote_Retorno { get; set; }
        public int Tipo { get; set; }
        public string Operacao { get; set; }
        public string Servico { get; set; }
        public int VersaoLayout { get; set; }

        private DTO_Cedente cedente { get; set; }
        public DTO_Cedente Cedente
        {
            get
            {
                if (cedente == null)
                {
                    cedente = new DTO_Cedente();
                    return cedente;
                }
                else
                    return cedente;
            }
            set
            {
                cedente = new DTO_Cedente();
                cedente = value;
            }
        }

        public int ID_Retorno { get; set; }
        public DateTime DataGer_Arq { get; set; }
    }

    public class DTO_Retorno_SegmentoT
    {
        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        public int ID_Lote_Retorno { get; set; }
        public int Tipo { get; set; }
        public int Seq_RegistroLote { get; set; }
        public string Cod_Segmento { get; set; }
        public int ID_Movimento { get; set; }

        private DTO_Cedente cedente { get; set; }
        public DTO_Cedente Cedente
        {
            get
            {
                if (cedente == null)
                {
                    cedente = new DTO_Cedente();
                    return cedente;
                }
                else
                    return cedente;
            }
            set
            {
                cedente = new DTO_Cedente();
                cedente = value;
            }
        }

        public string NossoNumero { get; set; }
        public int Carteira { get; set; }
        public string Documento { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
        public string Banco_Recebedor { get; set; }
        public string Agencia_Recebedor { get; set; }
        public int Tipo_Documento { get; set; }
        public string CNPJ_CPF_Sacado { get; set; }
        public string Nome_Sacado { get; set; }
        public string Conta_Cobranca { get; set; }
        public double Tarifa { get; set; }
        public int[] Ocorrencia { get; set; }
    }

    public class DTO_Retorno_SegmentoU
    {
        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        public int ID_Lote_Servico { get; set; }
        public int Tipo { get; set; }
        public int Seq_RegistroLote { get; set; }
        public string Cod_Segmento { get; set; }
        public int Cod_Movimento { get; set; }
        public double Acrescimo { get; set; }
        public double Desconto { get; set; }
        public double Abatimento { get; set; }
        public double IOF { get; set; }
        public double ValorPago { get; set; }
        public double ValorCreditado { get; set; }
        public double Despesas { get; set; }
        public double Creditos { get; set; }
        public DateTime Data_Ocorrencia { get; set; }
        public DateTime Data_Efetivacao { get; set; }
        public int Cod_Ocorrencia { get; set; }
        public DateTime Data_Ocorrencia_Sacado { get; set; }
        public double ValorOcorrencia { get; set; }
        public string Comp_Ocorrencia { get; set; }
        public int Cod_Banco_Correspondente { get; set; }
    }

    public class DTO_Retorno_TrailerArquivo240
    {
        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        public int ID_Lote_Remessa { get; set; }
        public int Tipo { get; set; }
        public int Qt_Lote { get; set; }
        public int Qt_Registro { get; set; }
    }

    public class DTO_Retorno_TrailerLote240
    {
        private DTO_Banco banco { get; set; }
        public DTO_Banco Banco
        {
            get
            {
                if (banco == null)
                {
                    banco = new DTO_Banco();
                    return banco;
                }
                else
                    return banco;
            }
            set
            {
                banco = new DTO_Banco();
                banco = value;
            }
        }

        public int ID_Lote_Servico { get; set; }
        public int Tipo { get; set; }
        public int Qt_Registro { get; set; }
        public int Qt_Cob_Simples { get; set; }
        public double Total_Cob_Simples { get; set; }
        public int Qt_Cob_Vinculada { get; set; }
        public double Total_Cob_Vinculada { get; set; }
        public int Qt_Cob_Caucionada { get; set; }
        public double Total_Cob_Caucionada { get; set; }
        public int Qt_Cob_Descontada { get; set; }
        public double Total_Cob_Descontada { get; set; }
        public int Numero_Aviso { get; set; }
    }

    public class DTO_Retorno_Santander240
    {
        public DTO_Retorno_HeaderAquivo240 Header_Arq { get; set; }
        public DTO_Retorno_HeaderLote240 Header_Lote { get; set; }
        public List<DTO_Retorno_SegmentoT> Seg_T { get; set; }
        public List<DTO_Retorno_SegmentoU> Seg_U { get; set; }
        public DTO_Retorno_TrailerLote240 Trailer_Lote { get; set; }
        public DTO_Retorno_TrailerArquivo240 Trailer_Arq { get; set; }
    }

    public class DTO_Retorno_Caixa240
    {
        public DTO_Retorno_HeaderAquivo240 Header_Arq { get; set; }
        public DTO_Retorno_HeaderLote240 Header_Lote { get; set; }
        public List<DTO_Retorno_SegmentoT> Seg_T { get; set; }
        public List<DTO_Retorno_SegmentoU> Seg_U { get; set; }
        public DTO_Retorno_TrailerLote240 Trailer_Lote { get; set; }
        public DTO_Retorno_TrailerArquivo240 Trailer_Arq { get; set; }
    }

    public class DTO_Retorno_Sicoob400
    {
        public DTO_Retorno_Header400 Header { get; set; }
        public List<DTO_Retorno_Detalhe400> Detalhe { get; set; }
        public DTO_Retorno_Trailler400 Trailler { get; set; }
    }

    public class DTO_Retorno_Bradesco400
    {
        public DTO_Retorno_Header400 Header { get; set; }
        public List<DTO_Retorno_Detalhe400> Detalhe { get; set; }
        public DTO_Retorno_Trailler400 Trailler { get; set; }
    }

    public class DTO_Remessa_Header400
    {
        public int ID_Registro { get; set; }
        public int Operacao { get; set; }
        public string Descricao_Operacao { get; set; }
        public int TipoServico { get; set; }
        public string Descricao_TipoServico { get; set; }
        public int Agencia { get; set; }
        public int DV_Agencia { get; set; }
        public int Codigo_Cliente { get; set; }
        public int DV_Codigo_Cliente { get; set; }
        public string Descricao_Cedente { get; set; }
        public string Descricao_Banco { get; set; }
        public DateTime Data_Remessa { get; set; }
        public int ID_Sequencial { get; set; }
        public int Sequencial_Registro { get; set; }
    }

    public class DTO_Remessa_Trailler400
    {
        public int ID_Registro { get; set; }
        public string Msg_Cedente_1 { get; set; }
        public string Msg_Cedente_2 { get; set; }
        public string Msg_Cedente_3 { get; set; }
        public string Msg_Cedente_4 { get; set; }
        public string Msg_Cedente_5 { get; set; }
        public int Sequencial_Registro { get; set; }
    }

    public class DTO_Remessa_Detalhe400
    {
        public int ID_Registro { get; set; }
        public int Tipo_Doc_Cedente { get; set; }
        public string Doc_Cedente { get; set; }
        public int Agencia { get; set; }
        public int DV_Agencia { get; set; }
        public int Conta_Corrente { get; set; }
        public int DV_Conta_Corrente { get; set; }
        public int Convenio { get; set; }
        public string NossoNumero { get; set; }
        public int Parcela { get; set; }
        public int Carteira { get; set; }
        public int Tipo_Movimento { get; set; }
        public int ID_Boleto { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
        public int NumeroBanco { get; set; }
        public int Tipo_Titulo { get; set; }
        public int Aceite { get; set; }
        public DateTime Emissao { get; set; }
        public int Instrucao_Codificada1 { get; set; }
        public int Instrucao_Codificada2 { get; set; }
        public double Juros_Mes { get; set; }
        public double Multa_Mes { get; set; }
        public int Tipo_Doc_Sacado { get; set; }
        public string Doc_Sacado { get; set; }
        public string Descricao_Sacado { get; set; }
        public string Endereco_Sacado { get; set; }
        public string Bairro_Sacado { get; set; }
        public string CEP_Sacado { get; set; }
        public string Cidade_Sacado { get; set; }
        public string UF_Sacado { get; set; }
        public int Dia_Protesto { get; set; }
        public int ID_Sequencial { get; set; }
    }

    public class DTO_Remessa_Sicoob400
    {
        public DTO_Remessa_Header400 Header { get; set; }
        public List<DTO_Remessa_Detalhe400> Detalhe { get; set; }
        public DTO_Remessa_Trailler400 Trailler { get; set; }
    }
}