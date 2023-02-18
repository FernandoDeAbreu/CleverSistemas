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
    public class BLL_CReceber
    {
        public int Grava(DTO_CReceber _CReceber)
        {
            string msg = string.Empty;

            if (_CReceber.ID_Conta == 0)
                msg += "Plano de Conta/n";

            if (_CReceber.ID_Pessoa == 0)
                msg += "Pessoa/n";

            if (_CReceber.Valor == 0)
                msg += "Valor/n";

            if (_CReceber.Situacao == 0)
                msg += "Situação/n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Grava();
        }

        public void Altera(DTO_CReceber _CReceber)
        {
            string msg = string.Empty;

            if (_CReceber.Altera_Registro == 1 && _CReceber.ID_Conta == 0)
                msg += "Plano de Conta/n";

            if (_CReceber.Altera_Registro == 2 && _CReceber.ID_Pessoa == 0)
                msg += "Pessoa/n";

            if (_CReceber.Altera_Registro == 3 && _CReceber.Valor == 0)
                msg += "Valor/n";

            if (_CReceber.Altera_Registro == 4 && _CReceber.Situacao == 0)
                msg += "Situação/n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            obj.Altera();
        }

        public DataTable Busca(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca();
        }

        public DataTable Busca_Boleto(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_Boleto();
        }

        public DataTable Busca_Informe(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_Informe();

        }

        public DataTable Busca_Resumo(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_Resumo();
        }

        public DataTable Busca_Conta(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_Conta();
        }

        public DataTable Busca_Planejamento(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_Planejamento();
        }

        public DataTable Busca_NFe(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_NFe();
        }

        public DataTable Busca_Fatura_NFe(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_Fatura_NFe();
        }

        public DataTable Busca_ContaAtraso(DTO_CReceber _CReceber)
        {
            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            return obj.Busca_ContaAtraso();
        }

        public void Exclui(DTO_CReceber _CReceber)
        {
            if (_CReceber.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_CReceber obj = new DAL_CReceber(_CReceber);
            obj.Exclui();
        }
    }
}
