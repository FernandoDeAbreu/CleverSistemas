using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
   public class DTO_GrupoNivel
    {
        public int ID { get; set; }
        public int Nivel { get; set; }
        public string CodigoPai { get; set; }
        public string Codigo { get; set; }
        public string CodigoDescritivo { get; set; }

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

        private string plano;
        public string Plano
        {
            get
            {
                if (plano == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(plano);
            }

            set { plano = value; }
        }
    }
}
