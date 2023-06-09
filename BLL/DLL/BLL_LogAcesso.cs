using Sistema.DAL;
using Sistema.DTO;
using System.Data;

namespace Sistema.BLL
{
    public class BLL_LogAcesso
    {
        public int Grava(DTO_LogAcesso _LogAcesso)
        {
            DAL_LogAcesso obj = new DAL_LogAcesso(_LogAcesso);
            return obj.Grava();
        }

        public DataTable Busca(DTO_LogAcesso _LogAcesso)
        {
            DAL_LogAcesso obj = new DAL_LogAcesso(_LogAcesso);
            return obj.Busca();
        }

        public DataTable BuscaNovaVersao(DTO_LogAcesso _Sistema)
        {
            DAL_LogAcesso obj = new DAL_LogAcesso(_Sistema);
            return obj.BuscaNovaVersao();
        }
    }
}