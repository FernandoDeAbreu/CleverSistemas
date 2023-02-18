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
    public class BLL_Venda
    {
        public int Grava(DTO_Venda _Venda)
        {
            string msg = string.Empty;

            if (_Venda.ID_Pessoa == 0)
                msg += "Pessoa\n";

            if (_Venda.Item.Count == 0)
                msg += "Produto\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Grava();
        }

        public bool Grava_Item(DTO_Produto_Item _Item)
        {
            if (_Item.ID_Produto == 0)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + "Produto");

            return true;
        }

        public void Altera_Qt_Item(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Altera_Qt_Item();
        }

        public void Altera_Qt_Entregue(DTO_Produto_Item _Item)
        {
            DAL_Venda obj = new DAL_Venda(_Item);
            obj.Altera_Qt_Entregue();
        }

        public void Altera_Qt_Conferido(DTO_Produto_Item _Item)
        {
            DAL_Venda obj = new DAL_Venda(_Item);
            obj.Altera_Qt_Conferido();
        }

        public void Altera_NFe(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Altera_NFe();
        }

        public void Altera_CFe(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Altera_CFe();
        }

        public void Altera_Fatura(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Altera_Fatura();
        }

        public void Cancela_Venda(DTO_Venda _Venda)
        {
            string msg = string.Empty;

            if (_Venda.ID == 0)
                msg += util_msg.msg_NenhumRegistro;

            if (msg != string.Empty)
                throw new Exception(msg);

            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Cancela_Venda();
        }

        public void Altera_Status_Conferencia(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Altera_Status_Conferencia();
        }

        public DataTable Busca(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca();
        }

        public DataTable Busca_TotalVenda(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_TotalVenda();
        }

        public DataTable Busca_TotalVendaResumo(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_TotalVendaResumo();
        }

        public DataTable Busca_ResumoProduto(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_ResumoProduto();
        }

        public DataTable Busca_ResumoVenda(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_ResumoVenda();
        }

        public DataTable Busca_Pessoa_Inativo(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Pessoa_Inativo();
        }

        public DataTable Busca_Comissao(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Comissao();
        }

        public DataTable Busca_Fatura(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Fatura();
        }

        public DataTable Busca_Relatorio(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Relatorio();
        }

        public DataTable Busca_Item(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Item();
        }

        public DataTable Busca_Financeiro(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Financeiro();
        }

        public DataTable Busca_PagamentoSAT(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_PagamentoSAT();
        }

        public DataTable Busca_ItemFiscal(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_ItemFiscal();
        }

        public DataTable Busca_Item_NF(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Item_NF();
        }

        public DataTable Busca_Item_NF_CF(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_Item_NF_CF();
        }

        public DataTable Busca_ItemTransporte(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_ItemTransporte();
        }

        public double Busca_UltimoValor(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            return obj.Busca_UltimoValor();
        }

        public void Exclui(DTO_Venda _Venda)
        {
            if (_Venda.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Exclui();
        }

        public void Exclui_Item(DTO_Venda _Venda)
        {
            DAL_Venda obj = new DAL_Venda(_Venda);
            obj.Exclui_Item();
        }
    }

    public class BLL_Venda_Mobile
    {
        public DataTable Busca(DTO_Mobile _Mobile)
        {
            DAL_Venda_Mobile obj = new DAL_Venda_Mobile(_Mobile);
            return obj.Busca();
        }

        public DataTable Busca_Item(DTO_Mobile _Mobile)
        {
            DAL_Venda_Mobile obj = new DAL_Venda_Mobile(_Mobile);
            return obj.Busca_Item();
        }

        public void Exclui_VendaMobile(DTO_Mobile _Mobile)
        {
            DAL_Venda_Mobile obj = new DAL_Venda_Mobile(_Mobile);
            obj.Exclui_VendaMobile();
        }
    }
}
