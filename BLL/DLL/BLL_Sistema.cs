using Sistema.DAL;
using Sistema.DTO;
using System.Data;

namespace Sistema.BLL
{
    public class BLL_Sistema
    {
        public void Grava(DTO_Sistema _Sistema)
        {
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

        public int VersaoBD()
        {
            DAL_Sistema obj = new DAL_Sistema();
            return obj.Versao();
        }

        public int VersaoSistema()
        {
            DAL_Sistema obj = new DAL_Sistema();
            return obj.VersaoSistema();
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