using Sistema.DAL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sistema.BLL
{
    public class BLL_FichaProducao
    {
        public int Grava(DTO_FichaProducao _FichaProducao)
        {
            string msg = string.Empty;

            if (_FichaProducao.ID_Venda == 0)
                msg += "Nº Venda\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_FichaProducao obj = new DAL_FichaProducao(_FichaProducao);
            return obj.Grava();
        }

        public void Altera_Situacao(DTO_FichaProducao _FichaProducao)
        {
            if (_FichaProducao.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_FichaProducao obj = new DAL_FichaProducao(_FichaProducao);
            obj.Altera_Situacao();
        }

        public DataTable Busca(DTO_FichaProducao _FichaProducao)
        {
            DAL_FichaProducao obj = new DAL_FichaProducao(_FichaProducao);
            return obj.Busca();
        }

        public void Exclui(DTO_FichaProducao _FichaProducao)
        {
            if (_FichaProducao.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_FichaProducao obj = new DAL_FichaProducao(_FichaProducao);
            obj.Exclui();
        }
    }
}
