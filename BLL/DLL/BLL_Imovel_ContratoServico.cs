using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Sistema.DTO;
using Sistema.DAL;
using Sistema.UTIL;

namespace Sistema.BLL
{
    public class BLL_Imovel_ContratoServico
    {
        public int Grava(DTO_Imovel_ContratoServico _ContratoServico)
        {
            string msg = string.Empty;

            if (_ContratoServico.ID_Proprietario == 0)
                msg += Info.CampoInvalido + "Proprietário/n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);
            
            DAL_Imovel_ContratoServico obj = new DAL_Imovel_ContratoServico(_ContratoServico);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Imovel_ContratoServico _ContratoServico)
        {
            DAL_Imovel_ContratoServico obj = new DAL_Imovel_ContratoServico(_ContratoServico);
            return obj.Busca();
        }

        public void Exclui(DTO_Imovel_ContratoServico _ContratoServico)
        {
            if (_ContratoServico.ID == 0)
                throw new Exception(Info.ErroExclusaoNull);

            DAL_Imovel_ContratoServico obj = new DAL_Imovel_ContratoServico(_ContratoServico);
            obj.Exclui();
        }
    }
}
