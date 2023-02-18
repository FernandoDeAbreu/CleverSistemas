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
    public class BLL_CFOP
    {
        public int Grava(DTO_CFOP _CFOP)
        {
            string msg = string.Empty;

            if (_CFOP.CFOP == string.Empty)
                msg += "CFOP\n";

            if (_CFOP.Descricao == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_CFOP obj = new DAL_CFOP(_CFOP);
            return obj.Grava();
        }

        public DataTable Busca(DTO_CFOP _CFOP)
        {
            DAL_CFOP obj = new DAL_CFOP(_CFOP);
            return obj.Busca();
        }

        public void Exclui(DTO_CFOP _CFOP)
        {
            if (_CFOP.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_CFOP obj = new DAL_CFOP(_CFOP);
            obj.Exclui();
        }
    }
}
