using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_ControleDoc
    {
        public int ID { get; set; }
        
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        public DateTime Periodo { get; set; }
        public DateTime DataEntrada { get; set; }

        /// <summary>
        /// <para>true = Entregue</para>
        /// <para>false = Falta</para>
        /// </summary>
        public bool Entregue { get; set; }

        private DTO_Data consultaentrada;
        public DTO_Data ConsultaEntrada
        {
            get
            {
                if (consultaentrada == null)
                {
                    consultaentrada = new DTO_Data();
                    return consultaentrada;
                }
                else
                    return consultaentrada;
            }
            set
            {
                consultaentrada = new DTO_Data();
                consultaentrada = value;
            }
        }

        private DTO_Data consultaperiodo;
        public DTO_Data ConsultaPeriodo
        {
            get
            {
                if (consultaperiodo == null)
                {
                    consultaperiodo = new DTO_Data();
                    return consultaperiodo;
                }
                else
                    return consultaperiodo;
            }
            set
            {
                consultaperiodo = new DTO_Data();
                consultaperiodo = value;
            }
        }

        public DTO_ControleDoc_Tipo Documento { get; set; }
    }

    public class DTO_ControleDoc_Tipo
    {
        public int ID { get; set; }
        public int ID_Tipo { get; set; }

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
}
