using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;
using Sistema.DAL;
using Sistema.UTIL;

namespace Sistema.BLL
{
    public class BLL_Grupo
    {
        public int Grava(DTO_Grupo _Grupo)
        {
            string msg = string.Empty;

            if (_Grupo.Descricao == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Grupo obj = new DAL_Grupo(_Grupo);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Grupo _Grupo)
        {
            DAL_Grupo obj = new DAL_Grupo(_Grupo);
            return obj.Busca();
        }

        public void Exclui(DTO_Grupo _Grupo)
        {
            if (_Grupo.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Grupo obj = new DAL_Grupo(_Grupo);
            obj.Exclui();
        }
    }
}
