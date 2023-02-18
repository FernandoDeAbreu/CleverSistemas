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
    public class BLL_Imposto
    {
        public int Grava(DTO_Imposto _Imposto)
        {
            string msg = string.Empty;

            if (_Imposto.Descricao == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Imposto obj = new DAL_Imposto(_Imposto);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Imposto _Imposto)
        {
            DAL_Imposto obj = new DAL_Imposto(_Imposto);
            return obj.Busca();
        }

        public DataTable Busca_Tributacao(DTO_Imposto _Imposto)
        {
            DAL_Imposto obj = new DAL_Imposto(_Imposto);
            return obj.Busca_Tributacao();
        }

        public DataTable Busca_UF(DTO_Imposto _Imposto)
        {
            DAL_Imposto obj = new DAL_Imposto(_Imposto);
            return obj.Busca_UF();
        }

        public void Exclui(DTO_Imposto _Imposto)
        {
            if (_Imposto.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imposto obj = new DAL_Imposto(_Imposto);
            obj.Exclui();
        }

        public void Exclui_Tributacao(DTO_Imposto _Imposto)
        {
            if (_Imposto.ID_Tributacao == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imposto obj = new DAL_Imposto(_Imposto);
            obj.Exclui_Tributacao();
        }
    }
}
