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
    public class BLL_NF
    {
        public int Grava(DTO_NF _NFe)
        {
            string msg = string.Empty;

            if (_NFe.ID_Pessoa == 0)
                msg += "Pessoa\n";

            //if (_NFe.Itens.Count == 0)
            //   msg += "Produto\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Grava();
        }

        public int Grava_Evento(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Grava_Evento();
        }

        public void Grava_Chave(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            obj.Grava_Chave();
        }

        public void Grava_Inutilizacao(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            obj.Grava_Inutilizacao();
        }

        public void Altera_Situacao(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            obj.Altera_Situacao();
        }

        public void Altera_Sessao(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            obj.Altera_Sessao();
        }

        public void Altera_Status_CFe(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            obj.Altera_Status_CFe();
        }

        public void Altera_Chave(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            obj.Altera_Chave();
        }

        public int Busca_ID_NF(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_ID_NF();
        }

        public DataTable Busca_CFe_Emitido(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_CFe_Emitido();
        }

        public DataTable Busca_NF(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF();
        }

        public DataTable Busca_NF_Sintegra(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Sintegra();
        }

        public DataTable Busca_NF_Sintegra_ST(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Sintegra_ST();
        }

        public DataTable Busca_NF_Sintegra_Item(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Sintegra_Item();
        }


        public DataTable Busca_NF_SAT(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_SAT();
        }

        public DataTable Busca_NF_Relatorio(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Relatorio();
        }

        public DataTable Busca_NF_Relatorio_CFOP(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Relatorio_CFOP();
        }

        public DataTable Busca_NF_Relatorio_Produto(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Relatorio_Produto();
        }

        public DataTable Busca_NF_Referenciada(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Referenciada();
        }

        public DataTable Busca_NF_Ent_Ret(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Ent_Ret();
        }

        public DataTable Busca_NF_AutorizadoXML(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_AutorizadoXML();
        }

        public DataTable Busca_NF_Transp(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Transp();
        }

        public DataTable Busca_NF_Volume(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Volume();
        }

        public DataTable Busca_NF_Lacre(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Lacre();
        }

        public DataTable Busca_NF_Importacao(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Importacao();
        }

        public DataTable Busca_NF_Adicao(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Adicao();
        }

        public DataTable Busca_NF_Item(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Item();
        }

        public DataTable Busca_NF_Duplicata(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Duplicata();
        }

        public DataTable Busca_NF_Cobranca(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Cobranca();
        }

        public DataTable Busca_NF_Evento(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Evento();
        }

        public DataTable Busca_NF_Email(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_NF_Email();
        }

        public DataTable Busca_Inutilizacao(DTO_NF _NFe)
        {
            DAL_NF obj = new DAL_NF(_NFe);
            return obj.Busca_Inutilizacao();
        }

        public void Exclui(DTO_NF _NFe)
        {
            if (_NFe.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui();
        }

        public void Exclui_NF_Duplicata(DTO_NF _NFe)
        {
            if (_NFe.Duplicata[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui_NF_Duplicata();
        }

        public void Exclui_NF_Cobranca(DTO_NF _NFe)
        {
            if (_NFe.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui_NF_Cobranca();
        }

        public void Exclui_NF_Transportadora(DTO_NF _NFe)
        {
            if (_NFe.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui_NF_Transportadora();
        }

        public void Exclui_NF_Item(DTO_NF _NFe)
        {
            if (_NFe.Itens[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui_NF_Item();
        }

        public void Exclui_NF_Volume(DTO_NF _NFe)
        {
            if (_NFe.Volume[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui_NF_Volume();
        }

        public void Exclui_NF_AutorizadoXML(DTO_NF _NFe)
        {
            if (_NFe.Autorizacao_XML[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui_NF_AutorizadoXML();
        }

        public void Exclui_NF_Referenciada(DTO_NF _NFe)
        {
            if (_NFe.Referenciada[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_NF obj = new DAL_NF(_NFe);
            obj.Exclui_NF_Referenciada();
        }
    }
}
