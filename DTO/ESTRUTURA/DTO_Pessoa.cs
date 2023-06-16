using Sistema.UTIL;
using System;
using System.Collections.Generic;

namespace Sistema.DTO
{
    public class DTO_Pessoa
    {
        public int ID { get; set; }

        #region CLIENTE

        public int ID_Usuario { get; set; }

        #endregion CLIENTE

        #region CLIENTE E FORNECEDOR

        private string referencia;

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

        #endregion CLIENTE E FORNECEDOR

        #region FUNCIONARIO

        public double Salario { get; set; }

        private string carteiraprofissional;

        public string CarteiraProfissional
        {
            get
            {
                if (carteiraprofissional == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(carteiraprofissional);
            }

            set { carteiraprofissional = value; }
        }

        private string pis;

        public string PIS
        {
            get
            {
                if (pis == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(pis);
            }

            set { pis = value; }
        }

        #endregion FUNCIONARIO

        public bool MultiEmpresa { get; set; }
        public int ID_Empresa { get; set; }

        /// <summary>
        /// <para>1 - CLIENTE</para>
        /// <para>2 - EMPRESA</para>
        /// <para>3 - FORNECEDOR</para>
        /// <para>4 - FUNCIONARIO</para>
        /// <para>5 - TRANSPORTADORA</para>
        /// <para>6 - RESPONSÁVEL</para>
        /// <para>7 - PROPRIETÁRIO</para>
        /// <para>8 - LOCATÁRIO</para>
        /// <para>9 - FIADOR</para>
        /// </summary>
        public int TipoPessoa { get; set; }

        /// <summary>
        /// <para>1 - CNPJ</para>
        /// <para>2 - CPF</para>
        /// </summary>
        public int TipoDocumento { get; set; }

        private string cnpj_cpf;

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

        private string matricula;

        public string Matricula
        {
            get
            {
                if (matricula == null)
                {
                    return string.Empty;
                }
                else
                    return util_dados.RemoveAspa(matricula);
            }
            set
            {
                matricula = value;
            }
        }

        private string nome_razao;

        public string Nome_Razao
        {
            get
            {
                if (nome_razao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(nome_razao);
            }

            set { nome_razao = value; }
        }

        private string nomefantasia;

        public string NomeFantasia
        {
            get
            {
                if (nomefantasia == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(nomefantasia);
            }

            set { nomefantasia = value; }
        }

        private string contato;

        public string Contato
        {
            get
            {
                if (contato == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(contato);
            }

            set { contato = value; }
        }

        private string ie_rg;

        public string IE_RG
        {
            get
            {
                if (ie_rg == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ie_rg);
            }

            set { ie_rg = value; }
        }

        private string im;

        public string IM
        {
            get
            {
                if (im == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(im);
            }

            set { im = value; }
        }

        public DateTime Cadastro { get; set; }
        public DateTime Nascimento_Fundacao { get; set; }

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

        public int ID_Grupo { get; set; }

        private string ramo_profissao;

        public string Ramo_Profissao
        {
            get
            {
                if (ramo_profissao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ramo_profissao);
            }

            set { ramo_profissao = value; }
        }

        private string descricao1;

        public string Descricao1
        {
            get
            {
                if (descricao1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao1);
            }

            set { descricao1 = value; }
        }

        private string descricao2;

        public string Descricao2
        {
            get
            {
                if (descricao2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao2);
            }

            set { descricao2 = value; }
        }

        private string descricao3;

        public string Descricao3
        {
            get
            {
                if (descricao3 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao3);
            }

            set { descricao3 = value; }
        }

        public double Limite { get; set; }
        public double ValorMensalidade { get; set; }
        public int DiaFaturamento { get; set; }

        public bool Situacao { get; set; }

        private string cei;

        public string CEI
        {
            get
            {
                if (cei == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cei);
            }

            set { cei = value; }
        }

        public int ID_Municipio { get; set; }
        public bool FiltraEmpresa { get; set; }

        public bool FiltraSituacao { get; set; }

        private string conjuge;

        public string Conjuge
        {
            get
            {
                if (conjuge == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(conjuge);
            }

            set { conjuge = value; }
        }

        private string cpf_conjuge;

        public string CPF_Conjuge
        {
            get
            {
                if (cpf_conjuge == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cpf_conjuge);
            }

            set { cpf_conjuge = value; }
        }

        private string rg_conjuge;

        public string RG_Conjuge
        {
            get
            {
                if (rg_conjuge == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(rg_conjuge);
            }

            set { rg_conjuge = value; }
        }

        private string profissao_conjuge;

        public string Profissao_Conjuge
        {
            get
            {
                if (profissao_conjuge == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(profissao_conjuge);
            }

            set { profissao_conjuge = value; }
        }

        private string informacao_venda;

        public string Informacao_Venda
        {
            get
            {
                if (informacao_venda == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(informacao_venda);
            }

            set { informacao_venda = value; }
        }

        private string dia_faturamento;

        public string Dia_Faturamento
        {
            get
            {
                if (dia_faturamento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(dia_faturamento);
            }

            set { dia_faturamento = value; }
        }

        public int ID_EmpresaResponsavel { get; set; }

        public int TipoPessoa_EmpresaResponsavel { get; set; }

        private List<DTO_Pessoa_Endereco> endereco;

        public List<DTO_Pessoa_Endereco> Endereco
        {
            get
            {
                if (endereco == null)
                    endereco = new List<DTO_Pessoa_Endereco>();
                return endereco;
            }

            set { endereco = value; }
        }

        private List<DTO_Pessoa_Telefone> telefone;

        public List<DTO_Pessoa_Telefone> Telefone
        {
            get
            {
                if (telefone == null)
                    telefone = new List<DTO_Pessoa_Telefone>();
                return telefone;
            }

            set { telefone = value; }
        }

        private List<DTO_Pessoa_Email> email;

        public List<DTO_Pessoa_Email> Email
        {
            get
            {
                if (email == null)
                    email = new List<DTO_Pessoa_Email>();
                return email;
            }

            set { email = value; }
        }

        private List<DTO_Pessoa_EmpresaResponsavel> pessoa_empresaresponsavel;

        public List<DTO_Pessoa_EmpresaResponsavel> Pessoa_EmpresaResponsavel
        {
            get
            {
                if (pessoa_empresaresponsavel == null)
                    pessoa_empresaresponsavel = new List<DTO_Pessoa_EmpresaResponsavel>();
                return pessoa_empresaresponsavel;
            }

            set { pessoa_empresaresponsavel = value; }
        }

        #region CONSULTA

        public string ListaID { get; set; }

        /// <summary>
        /// <para>1 - Descrição</para>
        /// <para>2 - Municipio</para>
        /// </summary>
        public int Classifica { get; set; }

        private string pesquisatelefone { get; set; }

        public string PesquisaTelefone
        {
            get
            {
                if (pesquisatelefone == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(pesquisatelefone);
            }

            set { pesquisatelefone = value; }
        }

        private string pesquisalogradouro { get; set; }

        public string PesquisaLogradouro
        {
            get
            {
                if (pesquisalogradouro == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(pesquisalogradouro);
            }

            set { pesquisalogradouro = value; }
        }

        #endregion CONSULTA
    }

    public class DTO_Pessoa_Endereco
    {
        public int ID { get; set; }
        public bool Principal { get; set; }
        public int Tipo { get; set; }

        private string logradouro;

        public string Logradouro
        {
            get
            {
                if (logradouro == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(logradouro);
            }

            set { logradouro = value; }
        }

        private string numero;

        public string Numero
        {
            get
            {
                if (numero == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numero);
            }

            set { numero = value; }
        }

        private string complemento;

        public string Complemento
        {
            get
            {
                if (complemento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(complemento);
            }

            set { complemento = value; }
        }

        private string bairro;

        public string Bairro
        {
            get
            {
                if (bairro == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(bairro);
            }

            set { bairro = value; }
        }

        public int ID_Municipio { get; set; }

        private string cep;

        public string CEP
        {
            get
            {
                if (cep == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cep);
            }

            set { cep = value; }
        }

        public int ID_Pais { get; set; }
        public int ID_UF { get; set; }

        public string Descricao_Municipio { get; set; }
        public string DescricaoTipo { get; set; }
    }

    public class DTO_Pessoa_Telefone
    {
        public int ID { get; set; }
        public bool Principal { get; set; }
        public int Tipo { get; set; }

        private string ddd;

        public string DDD
        {
            get
            {
                if (ddd == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ddd);
            }

            set { ddd = value; }
        }

        private string numero;

        public string Numero
        {
            get
            {
                if (numero == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numero);
            }

            set { numero = value; }
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

        public string DescricaoTipo { get; set; }
    }

    public class DTO_Pessoa_Email
    {
        public int ID { get; set; }
        public bool Principal { get; set; }
        public int Tipo { get; set; }
        private string email;

        public string Email
        {
            get
            {
                if (email == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(email);
            }

            set { email = value; }
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

        public string DescricaoTipo { get; set; }
    }

    public class DTO_Pessoa_EmpresaResponsavel
    {
        public int ID { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public string Descricao { get; set; }
    }
}