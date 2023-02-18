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
    public class BLL_Boleto
    {
        public int Grava(DTO_Boleto _Boleto)
        {
            string msg = string.Empty;

            if (_Boleto.ID_Pessoa == 0)
                msg += "Pessoa\n";
        
            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            return obj.Grava();
        }

        public int Grava_Remessa(DTO_Boleto _Boleto)
        {
            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            return obj.Grava_Remessa();
        }

        public void Grava_Barra(DTO_Boleto _Boleto)
        {
            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            obj.Grava_Barra();
        }

        public void Grava_Controle(DTO_Boleto _Boleto)
        {
            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            obj.Grava_Controle();
        }

        public void Baixa(DTO_Boleto _Boleto)
        {
            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            obj.Baixa();
        }

        public void Altera_NossoNumero(DTO_Boleto _Boleto)
        {
            if (_Boleto.NossoNumero == string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + "Nosso Número");

            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            obj.Altera_NossoNumero();
        }

        public DataTable Busca(DTO_Boleto _Boleto)
        {
            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            return obj.Busca();
        }

        public DataTable Busca_Remessa(DTO_Boleto _Boleto)
        {
            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            return obj.Busca_Remessa();
        }

        public DataTable Busca_Controle(DTO_Boleto _Boleto)
        {
            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            return obj.Busca_Controle();
        }

        public void Exclui(DTO_Boleto _Boleto)
        {
            if (_Boleto.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Boleto obj = new DAL_Boleto(_Boleto);
            obj.Exclui();
        }
    }
}
