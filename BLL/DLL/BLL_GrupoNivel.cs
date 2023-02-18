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
    public class BLL_GrupoNivel
    {
        public int Grava(DTO_GrupoNivel _GrupoNivel)
        {
            string msg = string.Empty;

            if (_GrupoNivel.Nivel == 0)
                msg += "Nível\n";

            if (_GrupoNivel.Codigo == string.Empty)
                msg += "Código\n";

            if (_GrupoNivel.Descricao == string.Empty)
                msg += "Descrição\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);


            DAL_GrupoNivel obj = new DAL_GrupoNivel(_GrupoNivel);
            return obj.Grava();
        }

        public DataTable Busca(DTO_GrupoNivel _GrupoNivel)
        {
            if (_GrupoNivel.Codigo == null)
                _GrupoNivel.Codigo = string.Empty;

            if (_GrupoNivel.CodigoPai == null)
                _GrupoNivel.CodigoPai = string.Empty;

            if (_GrupoNivel.Plano == null)
                _GrupoNivel.Plano = string.Empty;

            if (_GrupoNivel.CodigoDescritivo == null)
                _GrupoNivel.CodigoDescritivo = string.Empty;

            DAL_GrupoNivel obj = new DAL_GrupoNivel(_GrupoNivel);
            return obj.Busca();
        }

        public void Exclui(DTO_GrupoNivel _GrupoNivel)
        {
            if (_GrupoNivel.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_GrupoNivel obj = new DAL_GrupoNivel(_GrupoNivel);
            obj.Exclui();
        }
    }
}
