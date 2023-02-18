using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.DTO;
using Sistema.DAL;
using System.Data;
using Sistema.UTIL;

namespace Sistema.BLL
{
    public class BLL_ControleDoc
    {
        public int Grava(DTO_ControleDoc _Controle_Documento)
        {
            if (_Controle_Documento.ID_Pessoa == 0)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + "Pessoa\n");

            DAL_ControleDoc obj = new DAL_ControleDoc(_Controle_Documento);
            return obj.Grava();
        }

        public void Baixa(DTO_ControleDoc _Controle_Documento)
        {
            DAL_ControleDoc obj = new DAL_ControleDoc(_Controle_Documento);
             obj.Baixa();
        }

        public DataTable Busca(DTO_ControleDoc _Controle_Documento)
        {
            DAL_ControleDoc obj = new DAL_ControleDoc(_Controle_Documento);
            return obj.Busca();
        }

        public DataTable Busca_Config(DTO_ControleDoc _Controle_Documento)
        {
            DAL_ControleDoc obj = new DAL_ControleDoc(_Controle_Documento);
            return obj.Busca_Config();
        }

        public void Exclui(DTO_ControleDoc _Controle_Documento)
        {
            if (_Controle_Documento.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_ControleDoc obj = new DAL_ControleDoc(_Controle_Documento);
            obj.Exclui();
        }
    }

    public class BLL_ControleDoc_Tipo
    {
        public int Grava(DTO_ControleDoc_Tipo _ControleDoc_Tipo)
        {
            if (_ControleDoc_Tipo.Descricao == string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + "Descrição\n");

            DAL_ControleDoc_Tipo obj = new DAL_ControleDoc_Tipo(_ControleDoc_Tipo);
            return obj.Grava();
        }

        public DataTable Busca(DTO_ControleDoc_Tipo _ControleDoc_Tipo)
        {
            DAL_ControleDoc_Tipo obj = new DAL_ControleDoc_Tipo(_ControleDoc_Tipo);
            return obj.Busca();
        }

        public void Exclui(DTO_ControleDoc_Tipo _ControleDoc_Tipo)
        {
            if (_ControleDoc_Tipo.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_ControleDoc_Tipo obj = new DAL_ControleDoc_Tipo(_ControleDoc_Tipo);
            obj.Exclui();
        }
    }
}
