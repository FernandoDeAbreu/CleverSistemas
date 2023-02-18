using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_FolhaPagto
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Pessoa { get; set; }
        public int Tipo { get; set; }
        public DateTime Periodo { get; set; }
        public DateTime Vencimento { get; set; }
        public List<DTO_FolhaPagto_Evento> FolhaPagto_Evento { get; set; }
    }

    public class DTO_FolhaPagto_Evento
    {
        public int ID { get; set; }
        public int ID_Folha { get; set; }
        public int ID_Evento { get; set; }
        public double Valor { get; set; }

        public string Descricao { get; set; }
        public string Referencia { get; set; }
        public double Desconto { get; set; }
        public double Vencimento { get; set; }
    }

    public class DTO_Evento
    {
        public int ID { get; set; }

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

        public bool Vencimento { get; set; }
        public bool Desconto { get; set; }

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
    }
}
