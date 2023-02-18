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
    public class BLL_Orcamento
    {
        public int Grava(DTO_Orcamento _Orcamento)
        {
            string msg = string.Empty;

            if (_Orcamento.ID_Pessoa == 0)
                msg += "Pessoa\n";

            if (_Orcamento.Item.Count == 0)
                msg += "Nenhum Item\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Orcamento obj = new DAL_Orcamento(_Orcamento);
            return obj.Grava();
        }

        public bool Grava_Item(DTO_Produto_Item _Item)
        {
            if (_Item.ID_Produto == 0)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + "Produto");

            return true;
        }

        public DataTable Busca(DTO_Orcamento _Orcamento)
        {
            DAL_Orcamento obj = new DAL_Orcamento(_Orcamento);
            return obj.Busca();
        }

        public DataTable Busca_Relatorio(DTO_Orcamento _Orcamento)
        {
            DAL_Orcamento obj = new DAL_Orcamento(_Orcamento);
            return obj.Busca_Relatorio();
        }

        public DataTable Busca_Item(DTO_Orcamento _Orcamento)
        {
            DAL_Orcamento obj = new DAL_Orcamento(_Orcamento);
            return obj.Busca_Item();
        }

        public void Exclui(DTO_Orcamento _Orcamento)
        {
            if (_Orcamento.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Orcamento obj = new DAL_Orcamento(_Orcamento);
            obj.Exclui();
        }

        public void Exclui_Item(DTO_Orcamento _Orcamento)
        {
            DAL_Orcamento obj = new DAL_Orcamento(_Orcamento);
            obj.Exclui_Item();
        }
    }
}
