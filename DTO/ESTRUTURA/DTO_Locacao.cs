using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Locacao
    {
        public int ID { get; set; }
        public int ID_Imovel { get; set; }
        public DateTime Data { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public int DiaVencimento { get; set; }
        public double Valor { get; set; }

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

        private string observacao;
        public string Observacao
        {
            get
            {
                if (observacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(observacao);
            }

            set { observacao = value; }
        }

        public List<DTO_Locacao_Locatario> Locatario { get; set; }
        public List<DTO_Locacao_Fiador> Fiador { get; set; }
        public List<DTO_Locacao_Custo> Custo { get; set; }

        public int ID_Documento { get; set; }
        private string descricao_documento;
        public string Descricao_Documento
        {
            get
            {
                if (descricao_documento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_documento);
            }

            set { descricao_documento = value; }
        }

        public FileStream Arq_Documento { get; set; }
        public object ArqByteArray { get; set; }

        #region CONSULTA
        private DTO_Data consulta_periodo;
        public DTO_Data Consulta_Periodo
        {
            get
            {
                if (consulta_periodo == null)
                {
                    consulta_periodo = new DTO_Data();
                    return consulta_periodo;
                }
                else
                    return consulta_periodo;
            }
            set
            {
                consulta_periodo = new DTO_Data();
                consulta_periodo = value;
            }
        }
        #endregion
    }

    public class DTO_Locacao_Locatario
    {
        public int ID { get; set; }
        public int ID_Locacao { get; set; }
        public int ID_Locatario { get; set; }

        private string descricao_locatario;
        public string Descricao_Locatario
        {
            get
            {
                if (descricao_locatario == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_locatario);
            }

            set { descricao_locatario = value; }
        }
    }

    public class DTO_Locacao_Fiador
    {
        public int ID { get; set; }
        public int ID_Locacao { get; set; }
        public int ID_Fiador { get; set; }

        private string descricao_fiador;
        public string Descricao_Fiador
        {
            get
            {
                if (descricao_fiador == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao_fiador);
            }

            set { descricao_fiador = value; }
        }
    }

    public class DTO_Locacao_Custo
    {
        public int ID { get; set; }
        public int ID_Locacao { get; set; }
        public int ID_Imovel_Custo { get; set; }
    }
}
