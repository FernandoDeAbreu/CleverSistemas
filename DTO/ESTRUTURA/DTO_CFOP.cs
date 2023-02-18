using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO 
{
   public class DTO_CFOP
    {
        public int ID { get; set; }

        private string cfop;
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

        private string ajuda;
        public string Ajuda
        {
            get
            {
                if (ajuda == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ajuda);
            }

            set { ajuda = value; }
        }

        public bool Busca_CFOP { get; set; }
    }
}
    