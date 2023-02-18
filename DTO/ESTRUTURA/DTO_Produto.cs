using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Produto
    {
        public int ID { get; set; }

        /// <summary>
        /// <para>1 - PRODUTO VENDA</para>
        /// <para>2 - MATÉRIA-PRIMA</para>
        /// <para>3 - SERVIÇO</para>
        /// <para>4 - IMOBILIZADO / USO PRÓPRIO</para>
        /// <para>5 - KIT</para>
        /// </summary>
        public string Tipo { get; set; }

        public int ID_Empresa { get; set; }

        public bool Ativo { get; set; }

        public int[] lst_ID_Empresa { get; set; }

        public int ID_Grupo { get; set; }

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

        private string referencia { get; set; }
        public string Referencia
        {
            get
            {
                if (referencia == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(referencia);
            }

            set { referencia = value; }
        }

        private string infoadicional1 { get; set; }
        public string InfoAdicional1
        {
            get
            {
                if (infoadicional1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(infoadicional1);
            }

            set { infoadicional1 = value; }
        }

        private string infoadicional2 { get; set; }
        public string InfoAdicional2
        {
            get
            {
                if (infoadicional2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(infoadicional2);
            }

            set { infoadicional2 = value; }
        }

        private string abc { get; set; }
        public string ABC
        {
            get
            {
                if (abc == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(abc);
            }

            set { abc = value; }
        }

        private string fabricante { get; set; }
        public string Fabricante
        {
            get
            {
                if (fabricante == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(fabricante);
            }

            set { fabricante = value; }
        }

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

        private string barra { get; set; }
        public string Barra
        {
            get
            {
                if (barra == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(barra);
            }

            set { barra = value; }
        }

        private string barratributavel { get; set; }
        public string BarraTributavel
        {
            get
            {
                if (barratributavel == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(barratributavel);
            }

            set { barratributavel = value; }
        }

        private string ncm { get; set; }
        public string NCM
        {
            get
            {
                if (ncm == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ncm);
            }

            set { ncm = value; }
        }

        public int ID_CEST { get; set; }

        public int UnidadeTributavel { get; set; }
        public int Validade { get; set; }
        public int Garantia { get; set; }

        private string localizacao { get; set; }
        public string Localizacao
        {
            get
            {
                if (localizacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(localizacao);
            }

            set { localizacao = value; }
        }

        private string ex_tipi { get; set; }
        public string EX_TIPI
        {
            get
            {
                if (ex_tipi == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ex_tipi);
            }

            set { ex_tipi = value; }
        }

        private string cnpjprodutor { get; set; }
        public string CNPJProdutor
        {
            get
            {
                if (cnpjprodutor == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpjprodutor);
            }

            set { cnpjprodutor = value; }
        }

        private string classeenquadramento { get; set; }
        public string ClasseEnquadramento
        {
            get
            {
                if (classeenquadramento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(classeenquadramento);
            }

            set { classeenquadramento = value; }
        }

        public bool ProdutoEspecifico { get; set; }
        public int Cod_ANP { get; set; }

        public double ValorCompra { get; set; }

        public double OutrosCustos { get; set; }
        public double ValorIPI { get; set; }
        public double ValorST { get; set; }

        public double CustoFinal { get; set; }

        public int ID_Imposto { get; set; }

        public int ID_Desconto { get; set; }

        public double Quantidade_Minima { get; set; }
        public double Quantidade_Maxima { get; set; }
        public double Desconto { get; set; }


        /// <summary>
        /// TIPO DE MOVIMENTAÇÃO DE ESTOQUE
        /// <para>1 - ENTRADA</para>
        /// <para>2 - SAÍDA</para>
        /// </summary>
        public int Tipo_Movimento { get; set; }
        public double Quantidade { get; set; }
        public DateTime Data { get; set; }

        public List<DTO_Produto_Fornecedor> Fornecedor { get; set; }
        public List<DTO_Comissao> Comissao { get; set; }
        public List<DTO_Produto_Estoque> Estoque { get; set; }
        public List<DTO_Produto_Valor> Valor { get; set; }
        public List<DTO_Produto_Estrutura> Estrutura { get; set; }

        public List<DTO_Produto_Desconto_Pessoa> Desconto_Pessoa { get; set; }

        public int ID_Tabela { get; set; }

        public double PesoB { get; set; }
        public double PesoL { get; set; }

        public int ID_Grade { get; set; }

        public FileStream Imagem { get; set; }
        public object ArqByteArray { get; set; }

        public bool Controle_Estoque { get; set; }

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

        public bool Consulta_Ativo { get; set; }
        public bool Consulta_Tipo { get; set; }

        public bool Consulta_Quantidade { get; set; }

        private string listaid { get; set; }
        public string ListaID
        {
            get
            {
                if (listaid == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(listaid);
            }

            set { listaid = value; }
        }

        private string cod_interno { get; set; }
        public string Cod_Interno
        {
            get
            {
                if (cod_interno == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cod_interno);
            }

            set { cod_interno = value; }
        }

        public int ID_UF { get; set; }

        private string cfop { get; set; }
        public string CFOP
        {
            get
            {
                if (cfop == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cfop);
            }

            set { cfop = value; }
        }

        public int Tipo_NF { get; set; }

        public bool Consulta_Referencia { get; set; }

        private string gruponivel { get; set; }
        public string GrupoNivel
        {
            get
            {
                if (gruponivel == null)
                    return string.Empty;
                else
                    if (gruponivel.Substring(0, 1) == "0")
                    if (gruponivel.Substring(1, 1) == "0")
                        return " " + gruponivel.Substring(2).Replace("00", "").Replace(".0", ". ");
                    else
                        return " " + gruponivel.Substring(1).Replace("00", "").Replace(".0", ". ");
                else
                    return gruponivel.Replace("00", "").Replace(".0", ". ");
            }

            set { gruponivel = value; }
        }

        private string consulta_pdv { get; set; }
        public string Consulta_PDV
        {
            get
            {
                if (consulta_pdv == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(consulta_pdv);
            }

            set { consulta_pdv = value; }
        }

        public bool ConsultaMarca { get; set; }

        private string lst_codigo { get; set; }
        public string lst_Codigo
        {
            get
            {
                if (lst_codigo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(lst_codigo);
            }

            set { lst_codigo = value; }
        }

        /// <summary>
        /// <para>1 - ETIQUETA PRODUTO AVULSO</para>
        /// <para>2 - ETIQUETA PRODUTO COMPRA</para>
        /// <para>3 - ETIQUETA PRODUTO ESTOQUE</para>
        /// <para>4 - ETIQUETA COMPRA COM QUANTIDADE ESTOQUE</para>
        /// </summary>
        public int Consulta_Etiqueta { get; set; }

        public int ID_Produto_Entrada { get; set; }

        public bool Consulta_EstoqueCritico { get; set; }

        public bool Consulta_EstoqueCompra { get; set; }

        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        public bool ConsultaInversa { get; set; }
        #endregion
    }

    public class DTO_Produto_Fornecedor
    {
        public int ID { get; set; }
        public int ID_Produto { get; set; }
        public int ID_Fornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string Codigo_Produto { get; set; }
    }

    public class DTO_Produto_Valor
    {
        public int ID { get; set; }
        public int ID_Tabela { get; set; }
        public DateTime UltimoReajuste { get; set; }

        public double MargemVenda { get; set; }
        public double ValorVenda { get; set; }
        public string DescricaoTabela { get; set; }
    }

    public class DTO_Produto_Estoque
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Grade { get; set; }
        public double Estoque_Atual { get; set; }
        public double Estoque_Ideal { get; set; }
        public double Estoque_Minimo { get; set; }

        public string Cod_Interno { get; set; }

        private string localizacao { get; set; }
        public string Localizacao
        {
            get
            {
                if (localizacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(localizacao);
            }

            set { localizacao = value; }
        }

        public string DescricaoGrade { get; set; }

        public bool Adiciona { get; set; }
    }

    public class DTO_Produto_Estrutura
    {
        public int ID { get; set; }
        public int ID_Produto { get; set; }
        public int ID_Produto_Estrutura { get; set; }
        public int ID_Grade_Estrutura { get; set; }
        public string DescricaoProduto { get; set; }
        public double Quantidade { get; set; }
    }

    public class DTO_Produto_Desconto_Pessoa
    {
        public int ID { get; set; }
        public int ID_Produto { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        /// <summary>
        /// <para>1 - VALOR</para>
        /// <para>2 - PORCENTAGEM</para> 
        /// </summary>
        public int Tipo { get; set; }
        public double Desconto { get; set; }
    }

    public class DTO_Produto_Entrada
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }

        /// <summary>
        /// <para>1 - COMPRA</para>
        /// <para>2 - PRODUÇÃO</para>
        /// <para>3 - XML NFe</para>
        /// </summary>
        public int Tipo_Entrada { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public int TipoDocumento { get; set; }

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

        public DateTime Data { get; set; }
        public DateTime Entrega { get; set; }

        public int ID_Usuario { get; set; }
        public int Situacao { get; set; }

        public bool Faturado { get; set; }
        public bool AtualizaValorVenda { get; set; }

        public bool Entrada_XML_NFe { get; set; }

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

        public int ID_Produto { get; set; }

        public bool Pesquisa_Faturado { get; set; }
        #endregion
    }

}
