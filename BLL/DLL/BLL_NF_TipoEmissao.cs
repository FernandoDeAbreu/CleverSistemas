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
    public class BLL_NF_TipoEmissao
    {
        public int Grava(DTO_NF_TipoEmissao _NF_TipoEmissao)
        {
            string msg = string.Empty;
            if (_NF_TipoEmissao.Descricao.Trim() == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_NF_TipoEmissao obj = new DAL_NF_TipoEmissao(_NF_TipoEmissao);
            return obj.Grava();
        }

        public DataTable Busca(DTO_NF_TipoEmissao _NF_TipoEmissao)
        {
            DAL_NF_TipoEmissao obj = new DAL_NF_TipoEmissao(_NF_TipoEmissao);
            return obj.Busca();
        }

        public void Exclui(DTO_NF_TipoEmissao _NF_TipoEmissao)
        {
            if (_NF_TipoEmissao.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF_TipoEmissao obj = new DAL_NF_TipoEmissao(_NF_TipoEmissao);
            obj.Exclui();
        }
    }
}
