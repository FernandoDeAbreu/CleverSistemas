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
    public class BLL_Municipio
    {
        public int Grava_Pais(DTO_Municipio _Municipio)
        {
            string msg = string.Empty;

            if (_Municipio.ID_Pais == 0)
                msg += "Código Pais\n";

            if (_Municipio.Descricao == string.Empty)
                msg += "Descrição";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            return obj.Grava_Pais();
        }

        public int Grava_Municipio(DTO_Municipio _Municipio)
        {
            string msg = string.Empty;

            if (_Municipio.ID_Pais == 0)
                msg += "Código Pais\n";

            if (_Municipio.ID_UF == 0)
                msg += "UF\n";

            if (_Municipio.ID_Municipio == 0)
                msg += "Código Município\n";

            if (_Municipio.Descricao == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            return obj.Grava_Municipio();
        }

        public int Grava_UF(DTO_Municipio _Municipio)
        {
            string msg = string.Empty;           

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            return obj.Grava_UF();
        }

        public DataTable Busca_UF(DTO_Municipio _Municipio)
        {
            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            return obj.Busca_UF();
        }

        public DataTable Busca_UF_Aliquota_Inter(DTO_Municipio _Municipio)
        {
            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            return obj.Busca_UF_Aliquota_Inter();
        }

        public DataTable Busca_Municipio(DTO_Municipio _Municipio)
        {
            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            return obj.Busca_Municipio();
        }

        public DataTable Busca_Pais(DTO_Municipio _Municipio)
        {
            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            return obj.Busca_Pais();
        }

        public void Exclui_Pais(DTO_Municipio _Municipio)
        {
            if (_Municipio.ID_Pais == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            obj.Exclui_Pais();
        }

        public void Exclui_Municipio(DTO_Municipio _Municipio)
        {
            if (_Municipio.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Municipio obj = new DAL_Municipio(_Municipio);
            obj.Exclui_Municipio();
        }
    }
}
