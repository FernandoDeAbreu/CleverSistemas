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
    public class BLL_FluxoCaixa
    {
        public int Grava(DTO_FluxoCaixa _FluxoCaixa)
        {
            string msg = string.Empty;

            if (_FluxoCaixa.Credito == 0 &&
                _FluxoCaixa.Debito == 0)
                msg += "Valor Movimentação\n";

            if (_FluxoCaixa.ID_Conta == 0)
                msg += "Conta\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.Grava();
        }

        public void Grava_Controle(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            obj.Grava_Controle();
        }

        public void Altera_Lancamento_Cheque(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            obj.Altera_Lancamento_Cheque();
        }

        public void Altera_Conciliado(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            obj.Altera_Conciliado();
        }

        public void Atualiza_Planejamento()
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa();
            obj.Atualiza_Planejamento();
        }

        public DataTable BuscaSimples(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.BuscaSimples();
        }

        public DataTable BuscaDetalhado(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.BuscaDetalhado();
        }

        public DataTable BuscaBalanco(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.BuscaBalanco();
        }

        public DataTable Busca_Planejamento(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.Busca_Planejamento();
        }

        public DataTable Busca_Saldo(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.Busca_Saldo();
        }

        public DataTable Busca_Resumo(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.Busca_Resumo();
        }

        public DataTable Busca_Controle(DTO_FluxoCaixa _FluxoCaixa)
        {
            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            return obj.Busca_Controle();
        }

        public void Exclui(DTO_FluxoCaixa _FluxoCaixa)
        {
            if (_FluxoCaixa.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_FluxoCaixa obj = new DAL_FluxoCaixa(_FluxoCaixa);
            obj.Exclui();
        }
    }
}
