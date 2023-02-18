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
    public class BLL_Pagamento
    {
        public int Grava(DTO_Pagamento _Pagamento)
        {
            string msg = string.Empty;

            if (_Pagamento.Descricao == string.Empty)
                msg += "Descrição\n";

            if (_Pagamento.Parcelamento.Count == 0)
                msg += "Parcelamento\n";

            if (_Pagamento.Tipo == 0)
                msg += "Tipo de Pagamento\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Pagamento obj = new DAL_Pagamento(_Pagamento);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Pagamento _Pagamento)
        {
            DAL_Pagamento obj = new DAL_Pagamento(_Pagamento);
            return obj.Busca();
        }

        public DataTable Busca_Parc(DTO_Pagamento _Pagamento)
        {
            DAL_Pagamento obj = new DAL_Pagamento(_Pagamento);
            return obj.Busca_Parc();
        }

        public void Exclui(DTO_Pagamento _Pagamento)
        {
            if (_Pagamento.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Pagamento obj = new DAL_Pagamento(_Pagamento);
            obj.Exclui();
        }

        public void Exclui_Parc(DTO_Pagamento _Pagamento)
        {
            if (_Pagamento.Parcelamento[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Pagamento obj = new DAL_Pagamento(_Pagamento);
            obj.Exclui_Parc();
        }
    }
}
