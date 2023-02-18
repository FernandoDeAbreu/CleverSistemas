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
    public class BLL_Sistema
    {
        public void Grava(DTO_Sistema _Sistema)
        {
            string msg = string.Empty;

            if (_Sistema.VersaoBanco == 0 && _Sistema.VersaoSistema == 0)
                msg += "Versão Banco / Versão Sistema";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Sistema obj = new DAL_Sistema(_Sistema);
            obj.Grava();
        }

        public DataTable Busca(DTO_Sistema _Sistema)
        {
            if (_Sistema.ID == 0)
                return null;

            DAL_Sistema obj = new DAL_Sistema(_Sistema);
            return obj.Busca();
        }

        public string Busca_Chave()
        {
            DAL_Sistema obj = new DAL_Sistema();
            return obj.Busca_Chave();
        }

        public void Atualiza(DTO_Sistema _Sistema)
        {
            DAL_Sistema obj = new DAL_Sistema(_Sistema);
            obj.AtualizaBanco();
        }

        public void Verifica_Conexao()
        {
            DAL_Sistema obj = new DAL_Sistema();
            obj.Verifica_Conexao();
        }

        public int Versao()
        {
            DAL_Sistema obj = new DAL_Sistema();
            return obj.Versao();
        }

        public string Executa_Comando(DTO_Sistema _Sistema)
        {
            DAL_Sistema obj = new DAL_Sistema(_Sistema);
            return obj.Executa_Comando();
        }

        public DataTable Consulta(DTO_Sistema _Sistema)
        {
            DAL_Sistema obj = new DAL_Sistema(_Sistema);
            return obj.Consulta();
        }
    }
}
