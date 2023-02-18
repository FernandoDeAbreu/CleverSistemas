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
    public class BLL_OS
    {
        public int Grava(DTO_OS _OS)
        {
            string msg = string.Empty;

            if (_OS.ID_Pessoa == 0)
                msg += "Pessoa\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_OS obj = new DAL_OS(_OS);
            return obj.Grava();
        }

        public void Grava_Item(DTO_Produto_Item _Item)
        {
            if (_Item.ID_Produto == 0)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + "Produto");
        }

        public void AlteraItemQuantidade(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            obj.AlteraItemQuantidade();
        }

        public void Altera_Qt_Entregue(DTO_Produto_Item _Item)
        {
            DAL_OS obj = new DAL_OS(_Item);
            obj.Altera_Qt_Entregue();
        }

        public void Altera_NFe(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            obj.Altera_NFe();
        }

        public void Altera_CFe(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            obj.Altera_CFe();
        }

        public void Altera_Fatura(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            obj.Altera_Fatura();
        }

        public void Altera_Status(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            obj.Altera_Status();
        }

        public void Cancela_OrdemServico(DTO_OS _OS)
        {
            string msg = string.Empty;

            if (_OS.ID == 0)
                msg += util_msg.msg_NenhumRegistro;

            if (msg != string.Empty)
                throw new Exception(msg);

            DAL_OS obj = new DAL_OS(_OS);
            obj.Cancela_OrdemServico();
        }

        public DataTable Busca(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca();
        }

        public DataTable Busca_TotalOS(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_TotalOS();
        }

        public DataTable Busca_TotalOSResumo(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_TotalOSResumo();
        }

        public DataTable Busca_ResumoProduto(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_ResumoProduto();
        }
        /*
        public DataTable Busca_ResumoPedido(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_ResumoPedido();
        }

        public DataTable Busca_Pessoa_Inativo(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Pessoa_Inativo();
        }

        public DataTable Busca_Comissao(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Comissao();
        }

        public DataTable Busca_Fatura(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Fatura();
        }
        */
        public DataTable Busca_Relatorio(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Relatorio();
        }

        public DataTable Busca_Item(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Item();
        }

        public DataTable Busca_Financeiro(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Financeiro();
        }

        public DataTable Busca_PagamentoSAT(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_PagamentoSAT();
        }

        public DataTable Busca_Item_NF(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Item_NF();
        }

        public DataTable Busca_Item_CF(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            return obj.Busca_Item_CF();
        }

        public void Exclui(DTO_OS _OS)
        {
            if (_OS.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_OS obj = new DAL_OS(_OS);
            obj.Exclui();
        }

        public void Exclui_Item(DTO_OS _OS)
        {
            DAL_OS obj = new DAL_OS(_OS);
            obj.Exclui_Item();
        }
    }
}
