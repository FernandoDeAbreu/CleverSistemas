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
    public class BLL_PlanoConta
    {
        public int Grava(DTO_PlanoConta _PlanoConta)
        {
            string msg = string.Empty;

            if (_PlanoConta.Nivel == 0)
                msg += "Nível\n";

            if (_PlanoConta.Codigo == string.Empty)
                msg += "Código\n";

            if (_PlanoConta.Descricao == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_PlanoConta obj = new DAL_PlanoConta(_PlanoConta);
            return obj.Grava();
        }

        public DataTable Busca(DTO_PlanoConta _PlanoConta)
        {
            if (_PlanoConta.Codigo == null)
                _PlanoConta.Codigo = string.Empty;

            if (_PlanoConta.CodigoPai == null)
                _PlanoConta.CodigoPai = string.Empty;

            if (_PlanoConta.Plano == null)
                _PlanoConta.Plano = string.Empty;

            if (_PlanoConta.CodigoDescritivo == null)
                _PlanoConta.CodigoDescritivo = string.Empty;

            DAL_PlanoConta obj = new DAL_PlanoConta(_PlanoConta);
            return obj.Busca();
        }

        public DataTable Busca_Codigo(DTO_PlanoConta _PlanoConta)
        {
            DAL_PlanoConta obj = new DAL_PlanoConta(_PlanoConta);
            return obj.Busca_Codigo();
        }

        public DataTable Busca_Relatorio()
        {
            DAL_PlanoConta obj = new DAL_PlanoConta();
            return obj.Busca_Relatorio();
        }

        public void Exclui(DTO_PlanoConta _PlanoConta)
        {
            if (_PlanoConta.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_PlanoConta obj = new DAL_PlanoConta(_PlanoConta);
            obj.Exclui();
        }
    }
}
