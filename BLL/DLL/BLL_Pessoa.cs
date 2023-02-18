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
    public class BLL_Pessoa
    {
        public int Grava(DTO_Pessoa _Pessoa)
        {
            string msg = string.Empty;

            if (_Pessoa.CNPJ_CPF == string.Empty)
                msg += "CNPJ/CPF\n";

            if (_Pessoa.Nome_Razao == string.Empty)
                msg += "Razão/Nome\n";

            if (_Pessoa.IE_RG == string.Empty)
                msg += "Inscrição/RG\n";

            if (_Pessoa.TipoPessoa == 6 &&
                _Pessoa.Pessoa_EmpresaResponsavel.Count == 0)
                msg += "Empresas\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Grava();
        }

        public void Verifica_Endereco(DTO_Pessoa_Endereco _Endereco)
        {
            string msg = string.Empty;

            if (_Endereco.Tipo == 0)
                msg += "Tipo\n";

            if (_Endereco.Logradouro == string.Empty)
                msg += "Logradouro\n";

            if (_Endereco.Numero == string.Empty)
                msg += "Número\n";

            if (_Endereco.Bairro == string.Empty)
                msg += "Bairro\n";

            if (_Endereco.ID_Municipio == 0)
                msg += "Município\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);
        }

        public void Verifica_Telefone(DTO_Pessoa_Telefone _Telefone)
        {
            string msg = string.Empty;

            if (_Telefone.Tipo == 0)
                msg += "Tipo\n";

            if (_Telefone.Numero == string.Empty)
                msg += "Número\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);
        }

        public void Verifica_Email(DTO_Pessoa_Email _Email)
        {
            string msg = string.Empty;

            if (_Email.Tipo == 0)
                msg += "Tipo\n";

            if (_Email.Email == string.Empty)
                msg += "Email\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);
        }

        public DataTable Busca(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca();
        }

        public DataTable Busca_Completa(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Completa();
        }

        public DataTable Busca_Relatorio(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Relatorio();
        }

        public DataTable Busca_Info_Relatorio(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Info_Relatorio();
        }

        public DataTable Busca_Relatorio_Pessoa(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Relatorio_Pessoa();
        }

        public DataTable Busca_Nome(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Nome();
        }

        public DataTable Busca_Endereco(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Endereco();
        }

        public DataTable Busca_Telefone(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Telefone();
        }

        public DataTable Busca_Email(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Email();
        }

        public DataTable Busca_EmailEnvio(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_EmailEnvio();
        }

        public DataTable Busca_PessoaResponsavel(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_PessoaResponsavel();
        }

        public DataTable Busca_EmpresaResponsavel(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_EmpresaResponsavel();
        }

        public DataTable Busca_Empresa_Estoque(DTO_Pessoa _Pessoa)
        {
            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            return obj.Busca_Empresa_Estoque();
        }

        public void Exclui(DTO_Pessoa _Pessoa)
        {
            if (_Pessoa.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            obj.Exclui();
        }

        public void Exclui_Endereco(DTO_Pessoa _Pessoa)
        {
            if (_Pessoa.Endereco[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            obj.Exclui_Endereco();
        }

        public void Exclui_Telefone(DTO_Pessoa _Pessoa)
        {
            if (_Pessoa.Telefone[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            obj.Exclui_Telefone();
        }

        public void Exclui_Email(DTO_Pessoa _Pessoa)
        {
            if (_Pessoa.Email[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            obj.Exclui_Email();
        }

        public void Exclui_EmpresaResponsavel(DTO_Pessoa _Pessoa)
        {
            if (_Pessoa.ID_EmpresaResponsavel == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Pessoa obj = new DAL_Pessoa(_Pessoa);
            obj.Exclui_EmpresaResponsavel();
        }
    }
}
