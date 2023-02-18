using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Imovel
    {
        public int ID { get; set; }
        public int ID_Tipo { get; set; }
        public double Valor { get; set; }
        public int Tipo_Imovel { get; set; }
        public double Area { get; set; }
        public double Comissao_Porc { get; set; }
        public double Comissao_Valor { get; set; }

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

        private string rgi;
        public string RGI
        {
            get
            {
                if (rgi == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(rgi);
            }

            set { rgi = value; }
        }

        private string uc;
        public string UC
        {
            get
            {
                if (uc == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(uc);
            }

            set { uc = value; }
        }

        private string ci;
        public string CI
        {
            get
            {
                if (ci == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ci);
            }

            set { ci = value; }
        }

        private string matricula;
        public string Matricula
        {
            get
            {
                if (matricula == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(matricula);
            }

            set { matricula = value; }
        }

        public DTO_Imovel_Endereco Endereco { get; set; }
        public List<DTO_Imovel_Proprietario> Proprietario { get; set; }
        public List<DTO_Imovel_Imagem> Imagem { get; set; }
        public List<DTO_Imovel_Custo> Custo { get; set; }
        public List<DTO_Imovel_Vistoria> Vistoria { get; set; }
    }

    public class DTO_Imovel_Endereco
    {
        public int ID_Imovel { get; set; }

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

        public int ID_Municipio { get; set; }
    }

    public class DTO_Imovel_Custo
    {
        public int ID { get; set; }
        public int ID_Imovel { get; set; }
        public int ID_Tipo { get; set; }
        public double Valor { get; set; }

        private string descricaocusto;
        public string DescricaoCusto
        {
            get
            {
                if (descricaocusto == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricaocusto);
            }

            set { descricaocusto = value; }
        }
    }

    public class DTO_Imovel_Imagem
    {
        public int ID { get; set; }
        public int ID_Imovel { get; set; }
        public FileStream Imagem { get; set; }
        public object ArqByteArray { get; set; }

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
    }

    public class DTO_Imovel_Vistoria
    {
        public int ID { get; set; }
        public int ID_Imovel { get; set; }

        private string local;
        public string Local
        {
            get
            {
                if (local == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(local);
            }

            set { local = value; }
        }

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
    }

    public class DTO_Imovel_Proprietario
    {
        public int ID { get; set; }
        public int ID_Imovel { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        private string descricaopessoa;
        public string DescricaoPessoa
        {
            get
            {
                if (descricaopessoa == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricaopessoa);
            }

            set { descricaopessoa = value; }
        }
    }

    public class DTO_Imovel_ContratoServico
    {
        public int ID { get; set; }
        public int ID_Proprietario { get; set; }
        public DateTime Emissao { get; set; }

        private string descricao_test1;
        public string Descricao_Test1
        {
            get
            {
                if (descricao_test1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_test1);
            }

            set { descricao_test1 = value; }
        }

        private string descricao_test2;
        public string Descricao_Test2
        {
            get
            {
                if (descricao_test2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_test2);
            }

            set { descricao_test2 = value; }
        }

        private string doc_test1;
        public string Doc_Test1
        {
            get
            {
                if (doc_test1 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(doc_test1);
            }

            set { doc_test1 = value; }
        }

        private string doc_test2;
        public string Doc_Test2
        {
            get
            {
                if (doc_test2 == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(doc_test2);
            }

            set { doc_test2 = value; }
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
        #endregion
    }
}
