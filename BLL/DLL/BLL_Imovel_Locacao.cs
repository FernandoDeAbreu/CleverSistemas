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
    public class BLL_Imovel_Locacao
    {
        public int Grava(DTO_Locacao _Locacao)
        {
            string msg = string.Empty;

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Locacao _Locacao)
        {
            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            return obj.Busca();
        }

        public DataTable Busca_Locatario(DTO_Locacao _Locacao)
        {
            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            return obj.Busca_Locatario();
        }

        public DataTable Busca_Fiador(DTO_Locacao _Locacao)
        {
            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            return obj.Busca_Fiador();
        }

        public void Exclui(DTO_Locacao _Locacao)
        {
            if (_Locacao.ID == 0)
                throw new Exception(Info.ErroExclusaoNull);

            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            obj.Exclui();
        }

        public void Exclui_Locatario(DTO_Locacao _Locacao)
        {
            if (_Locacao.Locatario[0].ID == 0)
                throw new Exception(Info.ErroExclusaoNull);

            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            obj.Exclui_Locatario();
        }

        public void Exclui_Fiador(DTO_Locacao _Locacao)
        {
            if (_Locacao.Fiador[0].ID == 0)
                throw new Exception(Info.ErroExclusaoNull);

            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            obj.Exclui_Fiador();
        }
    }
}
