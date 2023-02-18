using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;
using Sistema.DAL;

namespace Sistema.BLL
{
    public class BLL_Parametro
    {
        public int Grava(DTO_Parametro _Parametro)
        {
            DAL_Parametro obj = new DAL_Parametro(_Parametro);
            return obj.Grava();
        }

        public void Grava_Padrao(DTO_Parametro _Parametro)
        {            
            DAL_Parametro obj = new DAL_Parametro(_Parametro);
            obj.Grava_Padrao();
        }

        public DataTable Busca(DTO_Parametro _Parametro)
        {
            DAL_Parametro obj = new DAL_Parametro(_Parametro);
            return obj.Busca();
        }
    }
}
