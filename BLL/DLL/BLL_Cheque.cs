using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;
using Sistema.DAL;
using Sistema.UTIL;

namespace Sistema.BLL
{
    public class BLL_Cheque
    {
        public int Grava(DTO_Cheque _Cheque)
        {
            string msg = string.Empty;

            if (_Cheque.ID_Pessoa == 0)
                msg += "Pessoa\n";

            if (_Cheque.Valor == 0)
                msg += "Valor\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Cheque obj = new DAL_Cheque(_Cheque);
            return obj.Grava();
        }

        public string Valida(DTO_Cheque _Cheque)
        {
            string msg = string.Empty;

            if (_Cheque.ID_Pessoa == 0)
                msg += "Pessoa\n";

            if (_Cheque.Situacao == 0)
                msg += "Situação\n";

            if (_Cheque.Valor == 0)
                msg += "Valor\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            return null;
        }

        public void Altera_Situacao(DTO_Cheque _Cheque)
        {
            if (_Cheque.ID == 0)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + "Cheque");

            DAL_Cheque obj = new DAL_Cheque(_Cheque);
            obj.Altera_Situacao();
        }

        public DataTable Busca(DTO_Cheque _Cheque)
        {
            DAL_Cheque obj = new DAL_Cheque(_Cheque);
            return obj.Busca();
        }

        public DataTable Busca_Resumo(DTO_Cheque _Cheque)
        {
            DAL_Cheque obj = new DAL_Cheque(_Cheque);
            return obj.Busca_Resumo();
        }

        public DataTable Busca_ResumoRelatorio(DTO_Cheque _Cheque)
        {
            DAL_Cheque obj = new DAL_Cheque(_Cheque);
            return obj.Busca_ResumoRelatorio();
        }

        public void Exclui(DTO_Cheque _Cheque)
        {
            if (_Cheque.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Cheque obj = new DAL_Cheque(_Cheque);
            obj.Exclui();
        }
    }
}
