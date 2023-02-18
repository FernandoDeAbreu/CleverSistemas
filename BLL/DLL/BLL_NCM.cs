using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;
using Sistema.DAL;

namespace Sistema.BLL
{
    public class BLL_NCM
    {
        public int Grava(DTO_NCM _NCM)
        {
            DAL_NCM obj = new DAL_NCM(_NCM);
            return obj.Grava();
        }

        public int Grava_CEST(DTO_NCM _NCM)
        {
            DAL_NCM obj = new DAL_NCM(_NCM);
            return obj.Grava_CEST();
        }

        public void Atualiza_NCM()
        {
            DAL_NCM obj = new DAL_NCM();
            obj.Atualiza_NCM();
        }

        public DataTable Busca(DTO_NCM _NCM)
        {
            DAL_NCM obj = new DAL_NCM(_NCM);
            return obj.Busca();
        }

        public DataTable Busca_CEST(DTO_NCM _NCM)
        {
            DAL_NCM obj = new DAL_NCM(_NCM);
            return obj.Busca_CEST();
        }

        public void Exclui(DTO_NCM _NCM)
        {
            try
            {
                DAL_NCM obj = new DAL_NCM(_NCM);
                obj.Exclui();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Exclui_CEST(DTO_NCM _NCM)
        {
            try
            {
                DAL_NCM obj = new DAL_NCM(_NCM);
                obj.Exclui_CEST();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
