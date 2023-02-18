using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;
using Sistema.DAL;

namespace Sistema.BLL
{
    public class BLL_Imagem
    {
        public void Grava(DTO_Imagem _Imagem)
        {
            DAL_Imagem obj = new DAL_Imagem(_Imagem);
            obj.Grava();
        }

        public DataTable Busca(DTO_Imagem _Imagem)
        {
            DAL_Imagem obj = new DAL_Imagem(_Imagem);
            return obj.Busca();
        }
    }
}
