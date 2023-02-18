using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Sistema.DTO;
using Sistema.DAL;
using Sistema.UTIL;

namespace Sistema.BLL
{
    public class BLL_FolhaPagto
    {
        public int Grava(DTO_FolhaPagto _FolhaPagto)
        {
            string msg = string.Empty;

            if (_FolhaPagto.Tipo == 0)
                msg += "Tipo\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_FolhaPagto obj = new DAL_FolhaPagto(_FolhaPagto);
            return obj.Grava();
        }

        public DataTable Busca(DTO_FolhaPagto _FolhaPagto)
        {
            DAL_FolhaPagto obj = new DAL_FolhaPagto(_FolhaPagto);
            return obj.Busca();
        }

        public DataTable Busca_Item(DTO_FolhaPagto _FolhaPagto)
        {
            DAL_FolhaPagto obj = new DAL_FolhaPagto(_FolhaPagto);
            return obj.Busca_Item();
        }

        public DataTable Busca_Relatorio(DTO_FolhaPagto _FolhaPagto)
        {
            DAL_FolhaPagto obj = new DAL_FolhaPagto(_FolhaPagto);
            return obj.Busca_Relatorio();
        }

        public DataTable Busca_Resumo(DTO_FolhaPagto _FolhaPagto)
        {
            DAL_FolhaPagto obj = new DAL_FolhaPagto(_FolhaPagto);
            return obj.Busca_Resumo();
        }

        public void Exclui(DTO_FolhaPagto _FolhaPagto)
        {
            if (_FolhaPagto.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_FolhaPagto obj = new DAL_FolhaPagto(_FolhaPagto);
            obj.Exclui();
        }

        public void Exclui_Item(DTO_FolhaPagto _FolhaPagto)
        {
            if (_FolhaPagto.FolhaPagto_Evento[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_FolhaPagto obj = new DAL_FolhaPagto(_FolhaPagto);
            obj.Exclui_Item();
        }
    }

    public class BLL_Evento
    {
        public int Grava(DTO_Evento _Evento)
        {
            string msg = string.Empty;

            if (_Evento.Descricao == string.Empty)
                msg += "Descrição\n";

            if (_Evento.Vencimento == _Evento.Desconto)
                msg += "Vencimento/Desconto\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Evento obj = new DAL_Evento(_Evento);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Evento _Evento)
        {
            DAL_Evento obj = new DAL_Evento(_Evento);
            return obj.Busca();
        }

        public void Exclui(DTO_Evento _Evento)
        {
            if (_Evento.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Evento obj = new DAL_Evento(_Evento);
            obj.Exclui();
        }
    }
}
