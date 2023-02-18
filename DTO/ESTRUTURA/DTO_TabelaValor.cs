using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
   public class DTO_TabelaValor
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

        public double Margem { get; set; }
        public double CustoOperacional { get; set; }
    }
}
