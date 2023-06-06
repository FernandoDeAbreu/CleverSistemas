using Sistema.DAL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Data;

namespace Sistema.BLL
{
    public class BLL_Grade
    {
        public int Grava(DTO_Grade _Grade)
        {
            string msg = string.Empty;

            if (_Grade.ID_Grupo == 0)
                msg += "Grupo\n";

            if (_Grade.Descricao == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Grade obj = new DAL_Grade(_Grade);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Grade _Grade)
        {
            DAL_Grade obj = new DAL_Grade(_Grade);
            return obj.Busca();
        }

        public void Exclui(DTO_Grade _Grade)
        {
            if (_Grade.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Grade obj = new DAL_Grade(_Grade);
            obj.Exclui();
        }
    }
}