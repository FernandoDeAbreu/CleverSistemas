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
    public class BLL_CPagar
    {
        public int Grava(DTO_CPagar _CPagar)
        {
            string msg = string.Empty;
            
            if (_CPagar.ID_Conta == 0)
                msg += "Plano de Conta/n";

            if (_CPagar.ID_Pessoa == 0)
                msg += "Pessoa/n";

            if (_CPagar.Valor == 0)
                msg += "Valor/n";

            if (_CPagar.Situacao == 0)
                msg += "Situação/n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_CPagar obj = new DAL_CPagar(_CPagar);
            return obj.Grava();
        }

        public void Altera(DTO_CPagar _CPagar)
        {
            string msg = string.Empty;

            if (_CPagar.Altera_Registro == 1 && _CPagar.ID_Conta == 0)
                msg += "Plano de Conta/n";

            if (_CPagar.Altera_Registro == 2 && _CPagar.ID_Pessoa == 0)
                msg += "Pessoa/n";

            if (_CPagar.Altera_Registro == 3 && _CPagar.Valor == 0)
                msg += "Valor/n";

            if (_CPagar.Altera_Registro == 4 && _CPagar.Situacao == 0)
                msg += "Situação/n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_CPagar obj = new DAL_CPagar(_CPagar);
            obj.Altera();
        }

        public DataTable Busca(DTO_CPagar _CPagar)
        {
            DAL_CPagar obj = new DAL_CPagar(_CPagar);
            return obj.Busca();

        }

        public DataTable Busca_Resumo(DTO_CPagar _CPagar)
        {
            DAL_CPagar obj = new DAL_CPagar(_CPagar);
            return obj.Busca_Resumo();
        }

        public DataTable Busca_Conta(DTO_CPagar _CPagar)
        {
            DAL_CPagar obj = new DAL_CPagar(_CPagar);
            return obj.Busca_Conta();
        }

        public DataTable Busca_Planejamento(DTO_CPagar _CPagar)
        {
            DAL_CPagar obj = new DAL_CPagar(_CPagar);
            return obj.Busca_Planejamento();
        }

        public void Exclui(DTO_CPagar _CPagar)
        {
            if (_CPagar.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_CPagar obj = new DAL_CPagar(_CPagar);
            obj.Exclui();
        }
    }
}
