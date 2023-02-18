using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.DTO
{
    public class DTO_Mobile
    {
        public int ID { get; set; }
        public string IMEI { get; set; }
        public string Equipamento { get; set; }
        public bool Ativo { get; set; }

        public int ID_Tabela { get; set; }
        public int ID_Venda { get; set; }
    }
}
