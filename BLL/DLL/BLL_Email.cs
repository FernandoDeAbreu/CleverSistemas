using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.UTIL;
using Sistema.DAL;
using Sistema.DTO;

namespace Sistema.BLL
{
    public class BLL_Email
    {
        public int Grava(DTO_Email _Email)
        {
            string msg = string.Empty;

            if (_Email.Assunto.Trim() == string.Empty)
                msg += "Assunto\n";

            if (_Email.Para.Trim() == string.Empty &&
                _Email.CC.Trim() == string.Empty &&
                _Email.CCO.Trim() == string.Empty)
                msg += "Destinatário\n";

            if (_Email.Conteudo.Trim() == string.Empty)
                msg += "Conteúdo\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Email obj = new DAL_Email(_Email);
            return obj.Grava();
        }

        public DataTable Busca(DTO_Email _Email)
        {
            DAL_Email obj = new DAL_Email(_Email);
            return obj.Busca();
        }

        public void Exclui(DTO_Email _Email)
        {
            if (_Email.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Email obj = new DAL_Email(_Email);
            obj.Exclui();
        }
    }
}
