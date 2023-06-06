using Sistema.DAL.DLL;
using System.Data;

namespace Sistema.BLL.DLL
{
    public class BLL_LogAcesso
    {
        private DAL_LogAcesso obj = new DAL_LogAcesso();

        public DataTable Busca()
        {
            return obj.Busca();
        }
    }
}