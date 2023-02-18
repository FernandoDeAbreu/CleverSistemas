using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_NCM
    {
        public int ID { get; set; }

        private string ncm;
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

        public string CEST { get; set; }
        public int EX { get; set; }

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

        public double AliqNacFederal { get; set; }
        public double AliqImpFederal { get; set; }
        public double AliqEstadual { get; set; }
    }
}
