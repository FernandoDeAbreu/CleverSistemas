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
    public class BLL_Mobile
    {
        public int Grava(DTO_Mobile _Mobile)
        {
            string msg = string.Empty;

            if (_Mobile.IMEI == string.Empty)
                msg += "EMEI\n";

            if (_Mobile.Equipamento == string.Empty)
                msg += "Equipamento\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Mobile obj = new DAL_Mobile(_Mobile);
            return obj.Grava();
        }

        public void Altera_Situacao(DTO_Mobile _Mobile)
        {
            DAL_Mobile obj = new DAL_Mobile(_Mobile);
            obj.Altera_Situacao();
        }

        public DataTable Busca(DTO_Mobile _Mobile)
        {
            DAL_Mobile obj = new DAL_Mobile(_Mobile);
            return obj.Busca();
        }

        public void Exclui(DTO_Mobile _Mobile)
        {
            if (_Mobile.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Mobile obj = new DAL_Mobile(_Mobile);
            obj.Exclui();
        }
    }
}
