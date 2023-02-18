using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;
using Sistema.DAL;
using Sistema.UTIL;

namespace Sistema.BLL
{
    public class BLL_Backup
    {
        public void Grava_Backup(DTO_Backup _Backup)
        {
            string msg = string.Empty;

            if (_Backup.Local.Trim() == string.Empty)
                msg += "Caminho\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);
            
            DAL_Backup obj = new DAL_Backup(_Backup);
            obj.Grava_Backup();
                    }

        public DataTable Lista_BD()
        {
            DAL_Backup obj = new DAL_Backup();
            return obj.Lista_BD();
        }
    }
}
