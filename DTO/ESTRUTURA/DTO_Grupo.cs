using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Grupo
    {
        public int ID { get; set; }

        public int Tipo { get; set; }

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

        public bool Exibir { get; set; }

        #region CONSULTA
        public bool FiltraExibir { get; set; }
        #endregion
    }
}
