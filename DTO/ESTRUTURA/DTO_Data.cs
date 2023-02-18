using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.DTO
{
    public class DTO_Data
    {
        private DateTime inicial { get; set; }
        public DateTime Inicial
        {
            get
            { return inicial; }
            set { inicial = value; }
        }

        private DateTime final { get; set; }
        public DateTime Final
        {
            get
            { return final; }
            set { final = value; }
        }

        public DateTime Data { get; set; }

        public bool Filtra { get; set; }


    }
}
