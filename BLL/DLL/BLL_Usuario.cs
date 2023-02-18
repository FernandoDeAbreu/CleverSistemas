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
    public class BLL_Usuario
    {
        public int Grava(DTO_Usuario _Usuario)
        {
            string msg = string.Empty;

            if (_Usuario.Descricao == string.Empty)
                msg += "DESCRIÇÃO\n";

            if (_Usuario.UsuarioSistema == true && _Usuario.SenhaSistema == string.Empty)
                msg += "SENHA SISTEMA\n";

            if (_Usuario.UsuarioMobile == true && _Usuario.SenhaMobile == string.Empty)
                msg += "SENHA MOBILE\n";

            if (_Usuario.Cadastrado == true && _Usuario.ID_Pessoa == 0)
                msg += "PESSOA\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Grava();
        }

        public void Grava_Comissao(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            obj.Grava_Comissao();
        }

        public void Grava_Parametros(DTO_Usuario_Parametros _Usuario_Parametros)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario_Parametros);
            obj.Grava_Parametros();
        }

        public void Grava_Log(DTO_Log _Log)
        {
            DAL_Usuario obj = new DAL_Usuario(_Log);
            obj.Grava_Log();
        }
     
        public DataTable Busca(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca();
        }

        public DataTable Busca_Usuario(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca_Usuario();
        }

        public DataTable Busca_Nome(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca_Nome();
        }

        public DataTable Busca_Comissao(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca_Comissao();
        }

        public DataTable Busca_ComissaoValor(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca_ComissaoValor();
        }

        public DataTable Busca_Sistema(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca_Sistema();
        }

        public DataTable Busca_Parametros(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca_Parametros();
        }

        /*
        public DataTable Busca_Mobile(DTO_Usuario _Usuario)
        {
            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            return obj.Busca_Mobile();
        }*/

        public void Exclui(DTO_Usuario _Usuario)
        {
            if (_Usuario.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Usuario obj = new DAL_Usuario(_Usuario);
            obj.Exclui();
        }
    }

    public class BLL_Usuario_Acesso
    {
        public void Grava(DTO_Usuario_Parametros _Usuario_Parametros)
        {
            string msg = string.Empty;

            if (_Usuario_Parametros.ID_Usuario == 0)
                msg += "USUÁRIO\n";

            if (_Usuario_Parametros.Menu == string.Empty)
                msg += "MENU\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Usuario_Acesso obj = new DAL_Usuario_Acesso(_Usuario_Parametros);
            obj.Grava();
        }

        public DataTable Busca(DTO_Usuario_Parametros _Usuario_Parametros)
        {
            DAL_Usuario_Acesso obj = new DAL_Usuario_Acesso(_Usuario_Parametros);
            return obj.Busca();
        }

        public void Exclui(DTO_Usuario_Parametros _Usuario_Parametros)
        {
            string msg = string.Empty;

            if (_Usuario_Parametros.ID_Usuario == 0)
                msg += "USUÁRIO\n";

            if (_Usuario_Parametros.Menu == string.Empty)
                msg += "MENU\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Usuario_Acesso obj = new DAL_Usuario_Acesso(_Usuario_Parametros);
            obj.Exclui();
        }
    }
}