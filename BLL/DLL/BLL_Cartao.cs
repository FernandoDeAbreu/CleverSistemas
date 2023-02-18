using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.UTIL;
using Sistema.DTO;
using Sistema.DAL;

namespace Sistema.BLL
{
    public class BLL_Cartao
    {
        public int Grava(DTO_Cartao _Cartao)
        {
            string msg = string.Empty;

            if (_Cartao.Valor == 0)
                msg += "Valor\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Cartao obj = new DAL_Cartao(_Cartao);
            return obj.Grava();
        }

        public void Baixa(DTO_Cartao _Cartao)
        {
            DAL_Cartao obj = new DAL_Cartao(_Cartao);
            obj.Baixa();

        }

        public DataTable Busca(DTO_Cartao _Cartao)
        {
            DAL_Cartao obj = new DAL_Cartao(_Cartao);
            return obj.Busca();
        }

        public DataTable Busca_Lancamento(DTO_Cartao _Cartao)
        {
            DAL_Cartao obj = new DAL_Cartao(_Cartao);
            return obj.Busca_Lancamento();
        }

        public void Exclui(DTO_Cartao _Cartao)
        {
            if (_Cartao.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Cartao obj = new DAL_Cartao(_Cartao);
            obj.Exclui();
        }
    }
}
