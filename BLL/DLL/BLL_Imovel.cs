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
    public class BLL_Imovel
    {
        public int Grava(DTO_Imovel _Imovel)
        {
            string msg = string.Empty;

            if (_Imovel.Descricao == string.Empty)
                msg += "Descricao\n";

            if (_Imovel.Proprietario == null ||
                _Imovel.Proprietario.Count == 0)
                msg += "Proprietário\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Imovel _Imovel)
        {
            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            return obj.Busca();
        }

        public DataTable Busca_Proprietario(DTO_Imovel _Imovel)
        {
            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            return obj.Busca_Proprietario();
        }

        public DataTable Busca_Imagem(DTO_Imovel _Imovel)
        {
            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            return obj.Busca_Imagem();
        }

        public DataTable Busca_Custo(DTO_Imovel _Imovel)
        {
            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            return obj.Busca_Custo();
        }

        public DataTable Busca_Vistoria(DTO_Imovel _Imovel)
        {
            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            return obj.Busca_Vistoria();
        }

        public void Exclui(DTO_Imovel _Imovel)
        {
            if (_Imovel.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            obj.Exclui();
        }

        public void Exclui_Proprietario(DTO_Imovel _Imovel)
        {
            if (_Imovel.Proprietario[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            obj.Exclui_Proprietario();
        }

        public void Exclui_Imagem(DTO_Imovel _Imovel)
        {
            if (_Imovel.Imagem[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            obj.Exclui_Imagem();
        }

        public void Exclui_Custo(DTO_Imovel _Imovel)
        {
            if (_Imovel.Custo[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            obj.Exclui_Custo();
        }

        public void Exclui_Vistoria(DTO_Imovel _Imovel)
        {
            if (_Imovel.Vistoria[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel obj = new DAL_Imovel(_Imovel);
            obj.Exclui_Vistoria();
        }
    }

    public class BLL_Imovel_ContratoServico
    {
        public int Grava(DTO_Imovel_ContratoServico _ContratoServico)
        {
            string msg = string.Empty;

            if (_ContratoServico.ID_Proprietario == 0)
                msg += "Proprietário\n";

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
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel_ContratoServico obj = new DAL_Imovel_ContratoServico(_ContratoServico);
            obj.Exclui();
        }
    }

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

        public void Grava_Documento(DTO_Locacao _Locacao)
        {
            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            obj.Grava_Documento();
        }

        public DataTable Busca(DTO_Locacao _Locacao)
        {
            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            return obj.Busca();
        }

        public DataTable Busca_ResumoAluguel(DTO_Locacao _Locacao)
        {
            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            return obj.Busca_ResumoAluguel();
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

        public DataTable Busca_Documento(DTO_Locacao _Locacao)
        {
            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            return obj.Busca_Documento();
        }

        public void Exclui(DTO_Locacao _Locacao)
        {
            if (_Locacao.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            obj.Exclui();
        }

        public void Exclui_Locatario(DTO_Locacao _Locacao)
        {
            if (_Locacao.Locatario[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            obj.Exclui_Locatario();
        }

        public void Exclui_Fiador(DTO_Locacao _Locacao)
        {
            if (_Locacao.Fiador[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Imovel_Locacao obj = new DAL_Imovel_Locacao(_Locacao);
            obj.Exclui_Fiador();
        }
    }
}
