using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DAL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.BLL
{
    public class BLL_TabelaValor
    {
        public int Grava(DTO_TabelaValor _TabelaValor)
        {
            string msg = string.Empty;

            if (_TabelaValor.Descricao == string.Empty)
                msg += "Descrição";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_TabelaValor obj = new DAL_TabelaValor(_TabelaValor);
            return obj.Grava();
        }

        public DataTable Busca(DTO_TabelaValor _TabelaValor)
        {
            DAL_TabelaValor obj = new DAL_TabelaValor(_TabelaValor);
            return obj.Busca();
        }

        public void Exclui(DTO_TabelaValor _TabelaValor)
        {
            if (_TabelaValor.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_TabelaValor obj = new DAL_TabelaValor(_TabelaValor);
            obj.Exclui();
        }
    }
}
