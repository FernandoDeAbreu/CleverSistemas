using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Backup
    {
        public string Banco { get; set; }

        private string local;
        public string Local
        {
            get
            {
                if (local == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(local);
            }
            set { local = value; }
        }
    }
}
