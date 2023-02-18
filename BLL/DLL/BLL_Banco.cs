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
    public class BLL_Banco
    {
        public int Grava(DTO_Banco _Banco)
        {
            string msg = string.Empty;

            if (_Banco.Descricao.Trim() == string.Empty)
                msg += "Descrição\n";

            if (_Banco.Agencia.Trim() == string.Empty)
                msg += "Agência\n";

            if (_Banco.Conta.Trim() == string.Empty)
                msg += "Conta\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Banco obj = new DAL_Banco(_Banco);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Banco _Banco)
        {
            DAL_Banco obj = new DAL_Banco(_Banco);
            return obj.Busca();
        }

        public void Exclui(DTO_Banco _Banco)
        {
            if (_Banco.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Banco obj = new DAL_Banco(_Banco);
            obj.Exclui();
        }
    }

    public class BLL_Cedente
    {
        public int Grava(DTO_Cedente _Cedente)
        {
            string msg = string.Empty;

            if (_Cedente.Descricao.Trim() == string.Empty)
                msg += "Descrição\n";

            if (_Cedente.Carteira == 0)
                msg += "Carteira\n";

            if (_Cedente.Cod_Cedente == 0)
                msg += "Código Cedente\n";

            if (_Cedente.ID_Banco == 0)
                msg += "Banco\n";

            if (_Cedente.ID_Conta == 0)
                msg += "Conta Tarifa\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Cedente obj = new DAL_Cedente(_Cedente);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Cedente _Cedente)
        {
            DAL_Cedente obj = new DAL_Cedente(_Cedente);
            return obj.Busca();
        }

        public void Exclui(DTO_Cedente _Cedente)
        {
            if (_Cedente.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Cedente obj = new DAL_Cedente(_Cedente);
            obj.Exclui();
        }
    }
}
