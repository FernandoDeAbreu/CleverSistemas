using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_Pessoa
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        #endregion

        #region CONSTRUTOR
        public DAL_Pessoa(DTO_Pessoa _Pessoa)
        {
            this.Pessoa = _Pessoa;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            int ID_Pessoa_Temp = 0;
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                switch (Pessoa.TipoPessoa)
                {
                    #region CLIENTE
                    case 1:
                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaCliente ";
                            sql += "(ID_Usuario, Referencia) ";
                            sql += "VALUES ";
                            sql += "(@ID_Usuario, @Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);

                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaCliente SET ";
                            sql += "ID_Usuario = @ID_Usuario, ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region EMPRESA
                    case 2:

                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaEmpresa ";
                            sql += "(Referencia) ";
                            sql += "VALUES ";
                            sql += "(@Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);

                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaEmpresa SET ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region FORNECEDOR
                    case 3:

                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaFornecedor ";
                            sql += "(Referencia) ";
                            sql += "VALUES ";
                            sql += "(@Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);
                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaFornecedor SET ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region FUNCIONARIO
                    case 4:

                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaFuncionario ";
                            sql += "(Matricula, Referencia, Salario, CarteiraProfissional, PIS) ";
                            sql += "VALUES ";
                            sql += "(@Matricula, @Referencia, @Salario, @CarteiraProfissional, @PIS) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Matricula", Pessoa.Matricula);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);
                            cmd.Parameters.AddWithValue("@Salario", Pessoa.Salario);
                            cmd.Parameters.AddWithValue("@CarteiraProfissional", Pessoa.CarteiraProfissional);
                            cmd.Parameters.AddWithValue("@PIS", Pessoa.PIS);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);

                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaFuncionario SET ";
                            sql += "Matricula = @Matricula, ";
                            sql += "Referencia = @Referencia, ";
                            sql += "Salario = @Salario, ";
                            sql += "CarteiraProfissional = @CarteiraProfissional, ";
                            sql += "PIS = @PIS ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@Matricula", Pessoa.Matricula);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);
                            cmd.Parameters.AddWithValue("@Salario", Pessoa.Salario);
                            cmd.Parameters.AddWithValue("@CarteiraProfissional", Pessoa.CarteiraProfissional);
                            cmd.Parameters.AddWithValue("@PIS", Pessoa.PIS);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region TRANSPORTADORA
                    case 5:

                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaTransportadora ";
                            sql += "(Referencia) ";
                            sql += "VALUES ";
                            sql += "(@Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);
                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaTransportadora SET ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region RESPONSAVEL
                    case 6:
                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaResponsavel ";
                            sql += "(Referencia) ";
                            sql += "VALUES ";
                            sql += "(@Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);
                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaResponsavel SET ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region PROPRIETARIO
                    case 7:
                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaProprietario ";
                            sql += "(ID_Usuario, Referencia) ";
                            sql += "VALUES ";
                            sql += "(@ID_Usuario, @Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);
                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaProprietario SET ";
                            sql += "ID_Usuario = @ID_Usuario, ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region LOCATARIO
                    case 8:
                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaLocatario ";
                            sql += "(ID_Usuario, Referencia) ";
                            sql += "VALUES ";
                            sql += "(@ID_Usuario, @Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);

                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaLocatario SET ";
                            sql += "ID_Usuario = @ID_Usuario, ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                    #endregion

                    #region FIADOR
                    case 9:
                        if (Pessoa.ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaFiador ";
                            sql += "(ID_Usuario, Referencia) ";
                            sql += "VALUES ";
                            sql += "(@ID_Usuario, @Referencia) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            ID_Pessoa_Temp = conexao.Executa_ComandoID(cmd);

                            if (ID_Pessoa_Temp == 0)
                                throw new Exception(util_msg.msg_DAL_Erro_Grava);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaFiador SET ";
                            sql += "ID_Usuario = @ID_Usuario, ";
                            sql += "Referencia = @Referencia ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@ID_Usuario", Pessoa.ID_Usuario);
                            cmd.Parameters.AddWithValue("@Referencia", Pessoa.Referencia);

                            conexao.Executa_Comando(cmd);
                        }
                        break;
                        #endregion
                }

                cmd = new SqlCommand();

                #region GRAVA PESSOA
                if (Pessoa.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Pessoa ";
                    sql += "(MultiEmpresa, ID_Empresa, TipoPessoa, ID_Pessoa, TipoDocumento, CNPJ_CPF, Nome_Razao, NomeFantasia, Contato, IE_RG, IM, Cadastro, ";
                    sql += "Informacao, ID_Grupo, Nascimento_Fundacao, Ramo_Profissao, Descricao1, Descricao2, Descricao3, Limite, DiaFaturamento, Situacao, CEI, ";
                    sql += "ValorMensalidade, Conjuge, CPF_Conjuge, RG_Conjuge, Profissao_Conjuge, Informacao_Venda, Dia_Faturamento) ";
                    sql += "VALUES ";
                    sql += "(@MultiEmpresa, @ID_Empresa, @TipoPessoa, @ID_Pessoa, @TipoDocumento, @CNPJ_CPF, @Nome_Razao, @NomeFantasia, @Contato, @IE_RG, @IM, @Cadastro, ";
                    sql += "@Informacao, @ID_Grupo, @Nascimento_Fundacao, @Ramo_Profissao, @Descricao1, @Descricao2, @Descricao3, @Limite, @DiaFaturamento, @Situacao, @CEI, ";
                    sql += "@ValorMensalidade, @Conjuge, @CPF_Conjuge, @RG_Conjuge, @Profissao_Conjuge, @Informacao_Venda, @Dia_Faturamento) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@MultiEmpresa", Pessoa.MultiEmpresa);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Pessoa.ID_Empresa);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", ID_Pessoa_Temp);
                    cmd.Parameters.AddWithValue("@TipoDocumento", Pessoa.TipoDocumento);
                    cmd.Parameters.AddWithValue("@CNPJ_CPF", Pessoa.CNPJ_CPF);
                    cmd.Parameters.AddWithValue("@Nome_Razao", Pessoa.Nome_Razao);
                    cmd.Parameters.AddWithValue("@NomeFantasia", Pessoa.NomeFantasia);
                    cmd.Parameters.AddWithValue("@Contato", Pessoa.Contato);
                    cmd.Parameters.AddWithValue("@IE_RG", Pessoa.IE_RG);
                    cmd.Parameters.AddWithValue("@IM", Pessoa.IM);
                    cmd.Parameters.AddWithValue("@Cadastro", Pessoa.Cadastro);
                    cmd.Parameters.AddWithValue("@Informacao", Pessoa.Informacao);
                    cmd.Parameters.AddWithValue("@ID_Grupo", Pessoa.ID_Grupo);
                    cmd.Parameters.AddWithValue("@Nascimento_Fundacao", Pessoa.Nascimento_Fundacao);
                    cmd.Parameters.AddWithValue("@Ramo_Profissao", Pessoa.Ramo_Profissao);
                    cmd.Parameters.AddWithValue("@Descricao1", Pessoa.Descricao1);
                    cmd.Parameters.AddWithValue("@Descricao2", Pessoa.Descricao2);
                    cmd.Parameters.AddWithValue("@Descricao3", Pessoa.Descricao3);
                    cmd.Parameters.AddWithValue("@Limite", Pessoa.Limite);
                    cmd.Parameters.AddWithValue("@DiaFaturamento", Pessoa.DiaFaturamento);
                    cmd.Parameters.AddWithValue("@Situacao", Pessoa.Situacao);
                    cmd.Parameters.AddWithValue("@CEI", Pessoa.CEI);
                    cmd.Parameters.AddWithValue("@ValorMensalidade", Pessoa.ValorMensalidade);
                    cmd.Parameters.AddWithValue("@Conjuge", Pessoa.Conjuge);
                    cmd.Parameters.AddWithValue("@CPF_Conjuge", Pessoa.CPF_Conjuge);
                    cmd.Parameters.AddWithValue("@RG_Conjuge", Pessoa.RG_Conjuge);
                    cmd.Parameters.AddWithValue("@Profissao_Conjuge", Pessoa.Profissao_Conjuge);
                    cmd.Parameters.AddWithValue("@Informacao_Venda", Pessoa.Informacao_Venda);
                    cmd.Parameters.AddWithValue("@Dia_Faturamento", Pessoa.Dia_Faturamento);
                    conexao.Executa_Comando(cmd);

                    Pessoa.ID = ID_Pessoa_Temp;
                }
                #endregion
                else
                #region ALTERA PESSOA
                {
                    sql = "UPDATE ";
                    sql += "Pessoa SET ";
                    sql += "MultiEmpresa = @MultiEmpresa, ";
                    sql += "ID_Empresa = @ID_Empresa, ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "TipoDocumento = @TipoDocumento, ";
                    sql += "CNPJ_CPF = @CNPJ_CPF, ";
                    sql += "Nome_Razao =@Nome_Razao, ";
                    sql += "NomeFantasia = @NomeFantasia, ";
                    sql += "Contato = @Contato, ";
                    sql += "IE_RG = @IE_RG, ";
                    sql += "IM = @IM, ";
                    sql += "Cadastro = @Cadastro, ";
                    sql += "Informacao = @Informacao, ";
                    sql += "ID_Grupo = @ID_Grupo, ";
                    sql += "Nascimento_Fundacao = @Nascimento_Fundacao, ";
                    sql += "Ramo_Profissao = @Ramo_Profissao, ";
                    sql += "Descricao1 = @Descricao1, ";
                    sql += "Descricao2 = @Descricao2, ";
                    sql += "Descricao3 = @Descricao3, ";
                    sql += "Limite = @Limite, ";
                    sql += "DiaFaturamento = @DiaFaturamento, ";
                    sql += "Situacao = @Situacao, ";
                    sql += "CEI = @CEI, ";
                    sql += "ValorMensalidade = @ValorMensalidade, ";
                    sql += "Conjuge = @Conjuge, ";
                    sql += "CPF_Conjuge = @CPF_Conjuge, ";
                    sql += "RG_Conjuge = @RG_Conjuge, ";
                    sql += "Profissao_Conjuge = @Profissao_Conjuge, ";
                    sql += "Informacao_Venda = @Informacao_Venda, ";
                    sql += "Dia_Faturamento = @Dia_Faturamento ";
                    sql += "WHERE ";
                    sql += "TipoPessoa = @TipoPessoa ";
                    sql += "AND ID_Pessoa = @ID_Pessoa ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@MultiEmpresa", Pessoa.MultiEmpresa);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Pessoa.ID_Empresa);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                    cmd.Parameters.AddWithValue("@TipoDocumento", Pessoa.TipoDocumento);
                    cmd.Parameters.AddWithValue("@CNPJ_CPF", Pessoa.CNPJ_CPF);
                    cmd.Parameters.AddWithValue("@Nome_Razao", Pessoa.Nome_Razao);
                    cmd.Parameters.AddWithValue("@NomeFantasia", Pessoa.NomeFantasia);
                    cmd.Parameters.AddWithValue("@Contato", Pessoa.Contato);
                    cmd.Parameters.AddWithValue("@IE_RG", Pessoa.IE_RG);
                    cmd.Parameters.AddWithValue("@IM", Pessoa.IM);
                    cmd.Parameters.AddWithValue("@Cadastro", Pessoa.Cadastro);
                    cmd.Parameters.AddWithValue("@Informacao", Pessoa.Informacao);
                    cmd.Parameters.AddWithValue("@ID_Grupo", Pessoa.ID_Grupo);
                    cmd.Parameters.AddWithValue("@Nascimento_Fundacao", Pessoa.Nascimento_Fundacao);
                    cmd.Parameters.AddWithValue("@Ramo_Profissao", Pessoa.Ramo_Profissao);
                    cmd.Parameters.AddWithValue("@Descricao1", Pessoa.Descricao1);
                    cmd.Parameters.AddWithValue("@Descricao2", Pessoa.Descricao2);
                    cmd.Parameters.AddWithValue("@Descricao3", Pessoa.Descricao3);
                    cmd.Parameters.AddWithValue("@Limite", Pessoa.Limite);
                    cmd.Parameters.AddWithValue("@DiaFaturamento", Pessoa.DiaFaturamento);
                    cmd.Parameters.AddWithValue("@Situacao", Pessoa.Situacao);
                    cmd.Parameters.AddWithValue("@CEI", Pessoa.CEI);
                    cmd.Parameters.AddWithValue("@ValorMensalidade", Pessoa.ValorMensalidade);
                    cmd.Parameters.AddWithValue("@Conjuge", Pessoa.Conjuge);
                    cmd.Parameters.AddWithValue("@CPF_Conjuge", Pessoa.CPF_Conjuge);
                    cmd.Parameters.AddWithValue("@RG_Conjuge", Pessoa.RG_Conjuge);
                    cmd.Parameters.AddWithValue("@Profissao_Conjuge", Pessoa.Profissao_Conjuge);
                    cmd.Parameters.AddWithValue("@Informacao_Venda", Pessoa.Informacao_Venda);
                    cmd.Parameters.AddWithValue("@Dia_Faturamento", Pessoa.Dia_Faturamento);

                    conexao.Executa_Comando(cmd);
                }
                #endregion

                #region ENDEREÇO
                if (Pessoa.Endereco.Count > 0)
                    for (int i = 0; i <= Pessoa.Endereco.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (Pessoa.Endereco[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaEndereco ";
                            sql += "(TipoPessoa, ID_Pessoa, PrincipalEndereco, TipoEndereco, Logradouro, NumeroEndereco, Complemento, Bairro, ID_Municipio, CEP, ID_Pais) ";
                            sql += "VALUES ";
                            sql += "(@TipoPessoa, @ID_Pessoa, @PrincipalEndereco, @TipoEndereco, @Logradouro, @NumeroEndereco, @Complemento, @Bairro, @ID_Municipio, @CEP, @ID_Pais) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                            cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@PrincipalEndereco", Pessoa.Endereco[i].Principal);
                            cmd.Parameters.AddWithValue("@TipoEndereco", Pessoa.Endereco[i].Tipo);
                            cmd.Parameters.AddWithValue("@Logradouro", Pessoa.Endereco[i].Logradouro);
                            cmd.Parameters.AddWithValue("@NumeroEndereco", Pessoa.Endereco[i].Numero);
                            cmd.Parameters.AddWithValue("@Complemento", Pessoa.Endereco[i].Complemento);
                            cmd.Parameters.AddWithValue("@Bairro", Pessoa.Endereco[i].Bairro);
                            cmd.Parameters.AddWithValue("@ID_Municipio", Pessoa.Endereco[i].ID_Municipio);
                            cmd.Parameters.AddWithValue("@CEP", Pessoa.Endereco[i].CEP);
                            cmd.Parameters.AddWithValue("@ID_Pais", Pessoa.Endereco[i].ID_Pais);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaEndereco SET ";
                            sql += "PrincipalEndereco = @PrincipalEndereco, ";
                            sql += "TipoEndereco = @TipoEndereco, ";
                            sql += "Logradouro = @Logradouro, ";
                            sql += "NumeroEndereco = @NumeroEndereco, ";
                            sql += "Complemento = @Complemento, ";
                            sql += "Bairro = @Bairro, ";
                            sql += "ID_Municipio = @ID_Municipio, ";
                            sql += "CEP = @CEP, ";
                            sql += "ID_Pais = @ID_Pais ";
                            sql += "WHERE ";
                            sql += "ID_Endereco = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.Endereco[i].ID);
                            cmd.Parameters.AddWithValue("@PrincipalEndereco", Pessoa.Endereco[i].Principal);
                            cmd.Parameters.AddWithValue("@TipoEndereco", Pessoa.Endereco[i].Tipo);
                            cmd.Parameters.AddWithValue("@Logradouro", Pessoa.Endereco[i].Logradouro);
                            cmd.Parameters.AddWithValue("@NumeroEndereco", Pessoa.Endereco[i].Numero);
                            cmd.Parameters.AddWithValue("@Complemento", Pessoa.Endereco[i].Complemento);
                            cmd.Parameters.AddWithValue("@Bairro", Pessoa.Endereco[i].Bairro);
                            cmd.Parameters.AddWithValue("@ID_Municipio", Pessoa.Endereco[i].ID_Municipio);
                            cmd.Parameters.AddWithValue("@CEP", Pessoa.Endereco[i].CEP);
                            cmd.Parameters.AddWithValue("@ID_Pais", Pessoa.Endereco[i].ID_Pais);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region TELEFONE
                if (Pessoa.Telefone.Count > 0)
                    for (int i = 0; i <= Pessoa.Telefone.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (Pessoa.Telefone[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaTelefone ";
                            sql += "(TipoPessoa, ID_Pessoa, PrincipalTelefone, TipoTelefone, DDD, NumeroTelefone, InformacaoTelefone) ";
                            sql += "VALUES ";
                            sql += "(@TipoPessoa, @ID_Pessoa, @PrincipalTelefone, @TipoTelefone, @DDD, @NumeroTelefone, @InformacaoTelefone) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                            cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@PrincipalTelefone", Pessoa.Telefone[i].Principal);
                            cmd.Parameters.AddWithValue("@TipoTelefone", Pessoa.Telefone[i].Tipo);
                            cmd.Parameters.AddWithValue("@DDD", Pessoa.Telefone[i].DDD);
                            cmd.Parameters.AddWithValue("@NumeroTelefone", Pessoa.Telefone[i].Numero);
                            cmd.Parameters.AddWithValue("@InformacaoTelefone", Pessoa.Telefone[i].Informacao);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaTelefone SET ";
                            sql += "PrincipalTelefone = @PrincipalTelefone, ";
                            sql += "TipoTelefone = @TipoTelefone, ";
                            sql += "DDD = @DDD, ";
                            sql += "NumeroTelefone = @NumeroTelefone, ";
                            sql += "InformacaoTelefone = @InformacaoTelefone ";
                            sql += "WHERE ";
                            sql += "ID_Telefone = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.Telefone[i].ID);
                            cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                            cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@PrincipalTelefone", Pessoa.Telefone[i].Principal);
                            cmd.Parameters.AddWithValue("@TipoTelefone", Pessoa.Telefone[i].Tipo);
                            cmd.Parameters.AddWithValue("@DDD", Pessoa.Telefone[i].DDD);
                            cmd.Parameters.AddWithValue("@NumeroTelefone", Pessoa.Telefone[i].Numero);
                            cmd.Parameters.AddWithValue("@InformacaoTelefone", Pessoa.Telefone[i].Informacao);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region EMAIL
                if (Pessoa.Email.Count > 0)
                    for (int i = 0; i <= Pessoa.Email.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (Pessoa.Email[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "PessoaEmail ";
                            sql += "(TipoPessoa, ID_Pessoa, PrincipalEmail, TipoEmail, Email, InformacaoEmail) ";
                            sql += "VALUES ";
                            sql += "(@TipoPessoa, @ID_Pessoa, @PrincipalEmail, @TipoEmail, @Email, @InformacaoEmail) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                            cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@PrincipalEmail", Pessoa.Email[i].Principal);
                            cmd.Parameters.AddWithValue("@TipoEmail", Pessoa.Email[i].Tipo);
                            cmd.Parameters.AddWithValue("@Email", Pessoa.Email[i].Email);
                            cmd.Parameters.AddWithValue("@InformacaoEmail", Pessoa.Email[i].Informacao);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "PessoaEmail SET ";
                            sql += "PrincipalEmail = @PrincipalEmail, ";
                            sql += "TipoEmail = @TipoEmail, ";
                            sql += "Email = @Email, ";
                            sql += "InformacaoEmail = @InformacaoEmail ";
                            sql += "WHERE ";
                            sql += "ID_Email = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pessoa.Email[i].ID);
                            cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                            cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                            cmd.Parameters.AddWithValue("@PrincipalEmail", Pessoa.Email[i].Principal);
                            cmd.Parameters.AddWithValue("@TipoEmail", Pessoa.Email[i].Tipo);
                            cmd.Parameters.AddWithValue("@Email", Pessoa.Email[i].Email);
                            cmd.Parameters.AddWithValue("@InformacaoEmail", Pessoa.Email[i].Informacao);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region EMPRESA RESPONSAVEL
                if (Pessoa.Pessoa_EmpresaResponsavel.Count > 0)
                {
                    cmd = new SqlCommand();

                    sql = "DELETE FROM ";
                    sql += "Pessoa_EmpresaResponsavel ";
                    sql += "WHERE ";
                    sql += "ID_Pessoa = @ID_Pessoa ";
                    sql += "AND TipoPessoa = @TipoPessoa ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                    conexao.Executa_Comando(cmd);

                    for (int i = 0; i <= Pessoa.Pessoa_EmpresaResponsavel.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        sql = "INSERT INTO ";
                        sql += "Pessoa_EmpresaResponsavel ";
                        sql += "(ID_Pessoa, TipoPessoa, TipoPessoaResponsavel, ID_PessoaResponsavel) ";
                        sql += "VALUES ";
                        sql += "(@ID_Pessoa, @TipoPessoa, @TipoPessoaResponsavel, @ID_PessoaResponsavel) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                        cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                        cmd.Parameters.AddWithValue("@TipoPessoaResponsavel", Pessoa.Pessoa_EmpresaResponsavel[i].TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_PessoaResponsavel", Pessoa.Pessoa_EmpresaResponsavel[i].ID_Pessoa);

                        conexao.Executa_Comando(cmd);
                    }
                }
                #endregion

                conexao.Commit_Conexao();

                return Pessoa.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                if (ID_Pessoa_Temp > 0)
                    switch (Pessoa.TipoPessoa)
                    {
                        #region CLIENTE
                        case 1:
                            sql = " DBCC CHECKIDENT(PessoaCliente, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region EMPRESA
                        case 2:
                            sql = " DBCC CHECKIDENT(PessoaEmpresa, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region FORNECEDOR
                        case 3:
                            sql = " DBCC CHECKIDENT(PessoaFornecedor, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region FUNCIONARIO
                        case 4:
                            sql = " DBCC CHECKIDENT(PessoaFuncionario, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region TRANSPORTADORA
                        case 5:
                            sql = " DBCC CHECKIDENT(PessoaTransportadora, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region RESPONSAVEL
                        case 6:
                            sql = " DBCC CHECKIDENT(PessoaResponsavel, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region PROPRIETARIO
                        case 7:
                            sql = " DBCC CHECKIDENT(PessoaProprietario, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region LOCATARIO
                        case 8:
                            sql = " DBCC CHECKIDENT(PessoaLocatario, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                        #endregion

                        #region FIADOR
                        case 9:
                            sql = " DBCC CHECKIDENT(PessoaFiador, RESEED, " + ID_Pessoa_Temp + ")";
                            cmd.CommandText = sql;
                            conexao.Executa_Comando(cmd);
                            break;
                            #endregion
                    }

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                switch (Pessoa.TipoPessoa)
                {
                    case 1:
                        sql += "P.ID, ID_Usuario, Referencia, ";
                        break;
                    case 2:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 3:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 4:
                        sql += "P.ID, Matricula, Referencia, Salario, CarteiraProfissional, PIS, ";
                        break;
                    case 5:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 6:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 7:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 8:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 9:
                        sql += "P.ID, Referencia, ";
                        break;
                }
                sql += "MultiEmpresa, ID_Empresa, TipoPessoa, ID_Pessoa, TipoDocumento, CNPJ_CPF, Nome_Razao AS Descricao, NomeFantasia, NomeFantasia AS Complemento, Contato, IE_RG, IM, Cadastro, ";
                sql += "Informacao, ID_Grupo, Nascimento_Fundacao, Ramo_Profissao, Descricao1, Descricao2, Descricao3, Limite, DiaFaturamento, Situacao, CEI, ValorMensalidade, Conjuge, ";
                sql += "CPF_Conjuge, RG_Conjuge, Profissao_Conjuge, Informacao_Venda, Dia_Faturamento ";
                sql += "FROM ";
                sql += "Pessoa ";

                switch (Pessoa.TipoPessoa)
                {
                    case 1:
                        sql += "INNER JOIN PessoaCliente AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 2:
                        sql += "INNER JOIN PessoaEmpresa AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 3:
                        sql += "INNER JOIN PessoaFornecedor AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 4:
                        sql += "INNER JOIN PessoaFuncionario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 5:
                        sql += "INNER JOIN PessoaTransportadora AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 6:
                        sql += "INNER JOIN PessoaResponsavel AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 7:
                        sql += "INNER JOIN PessoaProprietario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 8:
                        sql += "INNER JOIN PessoaLocatario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 9:
                        sql += "INNER JOIN PessoaFiador AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                }
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND TipoPessoa = " + Pessoa.TipoPessoa + " ";

                if (Pessoa.ID > 0)
                    sql += "AND P.ID = " + Pessoa.ID + " ";

                if (Pessoa.CNPJ_CPF != string.Empty)
                    sql += "AND CNPJ_CPF = '" + Pessoa.CNPJ_CPF + "' ";

                if (Pessoa.Nome_Razao != string.Empty)
                    sql += "AND Nome_Razao LIKE '" + Pessoa.Nome_Razao + "%' ";

                if (Pessoa.NomeFantasia != string.Empty)
                    sql += "AND NomeFantasia LIKE '" + Pessoa.NomeFantasia + "%' ";

                if (Pessoa.Matricula != string.Empty)
                    sql += "AND Matricula LIKE '" + Pessoa.Matricula + "%' ";

                if (Pessoa.ID_Usuario > 0)
                    sql += "AND (ID_Usuario = " + Pessoa.ID_Usuario + " OR ID_Usuario = 0) ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Completa()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID_Pessoa AS ID, P.TipoPessoa, P.Nome_Razao AS Descricao, P.NomeFantasia, P.TipoDocumento, P.CNPJ_CPF, P.IE_RG, P.ValorMensalidade AS Mensalidade, P.DiaFaturamento AS Vencimento, ";
                sql += "P.Descricao1, P.Descricao2, P.Descricao3, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, P.Informacao_Venda, ";

                if (Pessoa.TipoPessoa == 1)
                    sql += "PC.Referencia, ";
                else
                    sql += "P.Informacao AS Referencia, ";

                sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, PEND.ID_Pais, ";
                sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                sql += "PEMAIL.Email, ";
                sql += "UPPER(M.Descricao) AS NomeMunicipio, M.ID_UF, M.ID_Municipio, ";
                sql += "UF.Sigla, ";
                sql += "PA.Descricao AS Pais, ";
                sql += "(PEND.Logradouro + ', ' + PEND.NumeroEndereco + ' - ' + PEND.Bairro + ' - ' + ";
                sql += "UPPER(M.Descricao) + '-' + UF.Sigla) AS Resumo_End ";

                sql += "FROM ";
                sql += "Pessoa AS P ";

                if (Pessoa.TipoPessoa == 1)
                    sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";

                if (Pessoa.TipoPessoa == 6)
                    sql += "LEFT JOIN PessoaResponsavel AS PC ON P.ID_Pessoa = PC.ID ";

                sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = " + Pessoa.TipoPessoa + "  AND PEND.PrincipalEndereco = 'True' ";
                sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = " + Pessoa.TipoPessoa + " AND PTEL.PrincipalTelefone = 'True' ";
                sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = " + Pessoa.TipoPessoa + " AND PEMAIL.PrincipalEmail = 'True' ";
                sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                sql += "LEFT JOIN Pais AS PA ON PEND.ID_Pais = PA.ID_Pais ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                sql += "WHERE NOT P.ID IS NULL ";
                sql += "AND P.TipoPessoa = " + Pessoa.TipoPessoa + " ";

                if (Pessoa.ID > 0)
                    sql += "AND P.ID_Pessoa = " + Pessoa.ID + " ";

                if (Pessoa.CNPJ_CPF != string.Empty)
                    sql += "AND P.CNPJ_CPF = '" + Pessoa.CNPJ_CPF + "' ";

                if (Pessoa.Nome_Razao != string.Empty)
                    sql += "AND P.Nome_Razao LIKE '" + Pessoa.Nome_Razao + "%' ";

                if (Pessoa.NomeFantasia != string.Empty)
                    sql += "AND P.NomeFantasia LIKE '" + Pessoa.NomeFantasia + "%' ";

                if (Pessoa.ID_Usuario > 0)
                    sql += "AND (P.ID_Usuario = " + Pessoa.ID_Usuario + " OR P.ID_Usuario = 0) ";

                if (Pessoa.PesquisaTelefone != string.Empty)
                    sql += "AND (PTEL.NumeroTelefone = '" + Pessoa.PesquisaTelefone + "') ";

                if (Pessoa.PesquisaLogradouro != string.Empty)
                    sql += "AND (PEND.Logradouro LIKE '" + Pessoa.PesquisaLogradouro + "%') ";

                sql += "ORDER BY Descricao ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Relatorio()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";

                switch (Pessoa.TipoPessoa)
                {
                    case 1:
                        sql += "P.ID, ID_Usuario, Referencia, ";
                        break;
                    case 2:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 3:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 4:
                        sql += "P.ID, Referencia, Salario, CarteiraProfissional, PIS, ";
                        break;
                    case 5:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 6:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 7:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 8:
                        sql += "P.ID, Referencia, ";
                        break;
                    case 9:
                        sql += "P.ID, Referencia, ";
                        break;
                }

                sql += "MultiEmpresa, ID_Empresa, TipoPessoa, ID_Pessoa, TipoDocumento, CNPJ_CPF, Nome_Razao AS Descricao, NomeFantasia, Contato, IE_RG, IM, Cadastro, ";
                sql += "Informacao, ID_Grupo, Nascimento_Fundacao, Ramo_Profissao, Descricao1, Descricao2, Descricao3, Limite, DiaFaturamento, Situacao, CEI, ValorMensalidade, ";
                sql += "Conjuge, CPF_Conjuge, RG_Conjuge, Profissao_Conjuge, Informacao_Venda ";
                sql += "FROM ";
                sql += "Pessoa ";

                switch (Pessoa.TipoPessoa)
                {
                    case 1:
                        sql += "INNER JOIN PessoaCliente AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 2:
                        sql += "INNER JOIN PessoaEmpresa AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 3:
                        sql += "INNER JOIN PessoaFornecedor AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 4:
                        sql += "INNER JOIN PessoaFuncionario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 5:
                        sql += "INNER JOIN PessoaTransportadora AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 6:
                        sql += "INNER JOIN PessoaResponsavel AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 7:
                        sql += "INNER JOIN PessoaProprietario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 8:
                        sql += "INNER JOIN PessoaLocatario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 9:
                        sql += "INNER JOIN PessoaFiador AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                }

                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND TipoPessoa = " + Pessoa.TipoPessoa + " ";

                if (Pessoa.ID > 0)
                    sql += "AND P.ID = " + Pessoa.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Info_Relatorio()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PE.ID, ";
                sql += "P.Nome_Razao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.Descricao1, P.Descricao2, P.Descricao3, P.Informacao, P.CEI, P.Conjuge, P.CPF_Conjuge, ";
                sql += "P.RG_Conjuge, P.Profissao_Conjuge, P.Informacao_Venda, ";
                sql += "GS.Descricao AS DescricaoGrupo, ";
                sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                sql += "PEMAIL.Email, ";
                sql += "I.Imagem AS Imagem_rpt, ";
                sql += "M.Descricao AS Municipio, M.ID_Pais, M.ID_UF, M.ID_Municipio, ";
                sql += "UF.Sigla AS UF, ";
                sql += "PA.Descricao AS Pais, ";
                sql += "P.Contato ";
                sql += "FROM ";
                sql += "PessoaEmpresa AS PE ";
                sql += "INNER JOIN Pessoa AS P ON P.ID_Pessoa = PE.ID AND P.TipoPessoa = 2 ";
                sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = PE.ID AND PEND.TipoPessoa = 2 AND PEND.PrincipalEndereco = 'True' ";
                sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = PE.ID AND PTEL.TipoPessoa = 2 AND PTEL.PrincipalTelefone = 'True'";
                sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = PE.ID AND PEMAIL.TipoPessoa = 2 AND PEMAIL.PrincipalEmail = 'True'";
                sql += "LEFT JOIN Grupo AS GS ON P.ID_Grupo = GS.ID AND GS.Tipo = 5 ";
                sql += "LEFT JOIN Imagem AS I ON PE.ID = I.ID_Empresa AND I.Tipo = 1 ";
                sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                sql += "WHERE PE.ID = " + Pessoa.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Relatorio_Pessoa()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID_Pessoa AS ID, P.Nome_Razao AS Descricao, P.NomeFantasia, P.CNPJ_CPF, P.IE_RG, P.ValorMensalidade AS Mensalidade, P.DiaFaturamento AS Vencimento, ";
                sql += "P.Descricao1, P.Descricao2, P.Descricao3, P.Conjuge, P.CPF_Conjuge, P.RG_Conjuge, P.Profissao_Conjuge, P.Informacao_Venda, ";

                sql += "'' AS Doc_Estrangeiro , ";
                if (Pessoa.TipoPessoa == 1)
                    sql += "PC.Referencia, ";
                else
                    sql += "P.Informacao AS Referencia, ";

                sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, PEND.ID_Pais, ";
                sql += "PTEL.DDD, PTEL.NumeroTelefone, ";
                sql += "PEMAIL.Email, ";
                sql += "UPPER(M.Descricao) AS NomeMunicipio, M.ID_UF, M.ID_Municipio, ";
                sql += "UF.Sigla, ";
                sql += "PA.Descricao AS Pais ";
                sql += "FROM ";
                sql += "Pessoa AS P ";

                if (Pessoa.TipoPessoa == 1)
                    sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";

                if (Pessoa.TipoPessoa == 6)
                    sql += "LEFT JOIN PessoaResponsavel AS PC ON P.ID_Pessoa = PC.ID ";

                sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = " + Pessoa.TipoPessoa + "  AND PEND.PrincipalEndereco = 'True' ";
                sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = " + Pessoa.TipoPessoa + " AND PTEL.PrincipalTelefone = 'True' ";
                sql += "LEFT JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = " + Pessoa.TipoPessoa + " AND PEMAIL.PrincipalEmail = 'True' ";
                sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                sql += "LEFT JOIN Pais AS PA ON PEND.ID_Pais = PA.ID_Pais ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";
                sql += "WHERE NOT P.ID IS NULL ";
                sql += "AND P.TipoPessoa = " + Pessoa.TipoPessoa + " ";

                if (Pessoa.ListaID != null && Pessoa.ListaID != string.Empty)
                    sql += "AND P.ID_Pessoa IN (" + Pessoa.ListaID + ") ";

                if (Pessoa.ID_Usuario > 0 && Pessoa.TipoPessoa == 1)
                    sql += "AND PC.ID_Usuario = " + Pessoa.ID_Usuario + " ";

                if (Pessoa.ID > 0)
                    sql += "AND P.ID_Pessoa = " + Pessoa.ID + " ";

                if (Pessoa.Nome_Razao != string.Empty)
                    sql += "AND P.Nome_Razao LIKE '" + Pessoa.Nome_Razao + "%' ";

                if (Pessoa.ID_Grupo > 0)
                    sql += "AND P.ID_Grupo = " + Pessoa.ID_Grupo + " ";

                if (Pessoa.Endereco.Count > 0 && Pessoa.Endereco[0].ID_Municipio > 0)
                    sql += "AND PEND.ID_Municipio = " + Pessoa.Endereco[0].ID_Municipio + " ";

                switch (Pessoa.Classifica)
                {
                    case 1:
                        sql += "ORDER BY Descricao ";
                        break;

                    case 2:
                        sql += "ORDER BY Sigla, NomeMunicipio, Descricao ";
                        break;
                }
                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Nome()
        {
            if (Pessoa.TipoPessoa == 0)
                return null;

            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";

                switch (Pessoa.TipoPessoa)
                {
                    case 1:
                        sql += "P.ID, ";
                        break;
                    case 2:
                        sql += "P.ID, P.ID AS ID_Empresa, ";
                        break;
                    case 3:
                        sql += "P.ID, P.ID AS ID_Fornecedor, ";
                        break;
                    case 4:
                        sql += "P.ID, ";
                        break;
                    default:
                        sql += "P.ID, ";
                        break;
                }

                sql += "Nome_Razao AS Descricao, CNPJ_CPF ";
                sql += "FROM ";
                sql += "Pessoa ";

                switch (Pessoa.TipoPessoa)
                {
                    case 1:
                        sql += "INNER JOIN PessoaCliente AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 2:
                        sql += "INNER JOIN PessoaEmpresa AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 3:
                        sql += "INNER JOIN PessoaFornecedor AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 4:
                        sql += "INNER JOIN PessoaFuncionario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 5:
                        sql += "INNER JOIN PessoaTransportadora AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 6:
                        sql += "INNER JOIN PessoaResponsavel AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 7:
                        sql += "INNER JOIN PessoaProprietario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 8:
                        sql += "INNER JOIN PessoaLocatario AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                    case 9:
                        sql += "INNER JOIN PessoaFiador AS P ON P.ID = Pessoa.ID_Pessoa ";
                        break;
                }

                sql += "WHERE ";
                sql += "NOT ID_Pessoa IS NULL ";
                sql += "AND TipoPessoa = " + Pessoa.TipoPessoa + " ";

                if (Pessoa.ID > 0)
                    sql += "AND ID_Pessoa = " + Pessoa.ID + " ";

                if (Pessoa.FiltraEmpresa == true)
                    sql += "AND (ID_Empresa = " + Pessoa.ID_Empresa + " OR ID_Empresa = 0) ";

                if (Pessoa.FiltraSituacao == true)
                    sql += "AND Situacao = '" + Pessoa.Situacao + "' ";

                sql += "ORDER BY Nome_Razao ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Endereco()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PE.ID_Endereco, PE.TipoPessoa, PE.ID_Pessoa, PE.PrincipalEndereco, PE.TipoEndereco, PE.Logradouro, PE.NumeroEndereco, ";
                sql += "PE.Complemento, PE.Bairro, PE.ID_Municipio, PE.CEP, PE.ID_Pais, ";
                sql += "GS.Descricao AS DescricaoTipoEndereco, ";
                sql += "M.ID_UF, M.ID_Pais, M.ID_Municipio AS ID_MunicipioIBGE, UPPER(M.Descricao) AS NomeMunicipio, ";
                sql += "UF.Sigla, ";
                sql += "UPPER(M.Descricao) + '-'+ UF.Sigla AS Municipio_UF ";
                sql += "FROM ";
                sql += "PessoaEndereco AS PE ";
                sql += "INNER JOIN Grupo AS GS ON PE.TipoEndereco = GS.ID ";
                sql += "LEFT OUTER JOIN Municipios AS M ON PE.ID_Municipio = M.ID ";
                sql += "LEFT OUTER JOIN UF ON M.ID_UF = UF.ID_UF ";
                sql += "WHERE ";
                sql += "NOT PE.ID_Endereco IS NULL ";
                sql += "AND PE.TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND PE.ID_Pessoa = " + Pessoa.ID + " ";

                if (Pessoa.Endereco[0].Principal == true)
                    sql += "AND PE.PrincipalEndereco = '" + Pessoa.Endereco[0].Principal + "' ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Telefone()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Telefone, TipoPessoa, ID_Pessoa, PrincipalTelefone, TipoTelefone, DDD, NumeroTelefone, InformacaoTelefone, ";
                sql += "Grupo.Descricao AS DescricaoTipoTelefone ";
                sql += "FROM ";
                sql += "PessoaTelefone ";
                sql += "INNER JOIN Grupo ON PessoaTelefone.TipoTelefone = Grupo.ID ";
                sql += "WHERE ";
                sql += "NOT ID_Telefone IS NULL ";
                sql += "AND TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID + " ";

                if (Pessoa.Telefone[0].Principal == true)
                    sql += "AND PrincipalTelefone = '" + Pessoa.Telefone[0].Principal + "' ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Email()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Email, TipoPessoa, ID_Pessoa, PrincipalEmail, TipoEmail, Email, InformacaoEmail, ";
                sql += "Grupo.Descricao AS DescricaoTipoEmail ";
                sql += "FROM ";
                sql += "PessoaEmail ";
                sql += "INNER JOIN Grupo ON PessoaEmail.TipoEmail = Grupo.ID ";
                sql += "WHERE ";
                sql += "NOT ID_Email IS NULL ";
                sql += "AND TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID + " ";

                if (Pessoa.Email[0].Principal == true)
                    sql += "AND PrincipalEmail = '" + Pessoa.Email[0].Principal + "' ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_EmailEnvio()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.Nome_Razao, P.NomeFantasia,";
                sql += "PEMAIL.Email ";
                sql += "FROM ";
                sql += "Pessoa AS P ";

                if (Pessoa.TipoPessoa == 1)
                    sql += "LEFT JOIN PessoaCliente AS PC ON P.ID_Pessoa = PC.ID AND P.TipoPessoa = 1 ";

                if (Pessoa.TipoPessoa == 6)
                    sql += "LEFT JOIN PessoaResponsavel AS PC ON P.ID_Pessoa = PC.ID ";

                sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = " + Pessoa.TipoPessoa + "  AND PEND.PrincipalEndereco = 'True' ";
                sql += "LEFT JOIN PessoaTelefone as PTEL ON PTEL.ID_Pessoa = P.ID_Pessoa AND PTEL.TipoPessoa = " + Pessoa.TipoPessoa + " AND PTEL.PrincipalTelefone = 'True' ";

                sql += "INNER JOIN PessoaEmail as PEMAIL ON PEMAIL.ID_Pessoa = P.ID_Pessoa AND PEMAIL.TipoPessoa = " + Pessoa.TipoPessoa + " ";
                if (Pessoa.Email[0].Principal == true)
                    sql += "AND PEMAIL.PrincipalEmail = 'True' ";

                sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                sql += "LEFT JOIN Pais AS PA ON M.ID_Pais = PA.ID_Pais ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";

                sql += "WHERE NOT P.ID IS NULL ";
                sql += "AND (P.ID_Empresa = " + Pessoa.ID_Empresa + " OR P.ID_Empresa = 0) ";
                sql += "AND P.TipoPessoa = " + Pessoa.TipoPessoa + " ";

                if (Pessoa.ListaID != null && Pessoa.ListaID != string.Empty)
                    sql += "AND P.ID_Pessoa IN (" + Pessoa.ListaID + ") ";

                if (Pessoa.ID_Usuario > 0 && Pessoa.TipoPessoa == 1)
                    sql += "AND PC.ID_Usuario = " + Pessoa.ID_Usuario + " ";

                if (Pessoa.ID > 0)
                    sql += "AND P.ID_Pessoa = " + Pessoa.ID + " ";

                if (Pessoa.ID_Grupo > 0)
                    sql += "AND P.ID_Grupo = " + Pessoa.ID_Grupo + " ";

                if (Pessoa.Endereco.Count > 0 && Pessoa.Endereco[0].ID_Municipio > 0)
                    sql += "AND PEND.ID_Municipio = " + Pessoa.Endereco[0].ID_Municipio + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_PessoaResponsavel()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Pessoa_EmpresaResponsavel ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_PessoaResponsavel = " + Pessoa.ID + " ";
                sql += "AND TipoPessoaResponsavel = " + Pessoa.TipoPessoa + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_EmpresaResponsavel()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID_Pessoa AS ID_PessoaResponsavel, P.Nome_Razao AS Descricao, P.TipoPessoa, ";
                sql += "PR.ID, PR.ID_Pessoa ";
                sql += "FROM ";
                sql += "Pessoa AS P ";
                sql += "INNER JOIN Pessoa_EmpresaResponsavel AS PR ON P.TipoPessoa = PR.TipoPessoaResponsavel AND P.ID_Pessoa = PR.ID_PessoaResponsavel ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND PR.TipoPessoa = " + Pessoa.TipoPessoa + " ";

                if (Pessoa.ID > 0)
                    sql += "AND PR.ID_Pessoa = " + Pessoa.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_Empresa_Estoque()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Pessoa AS ID, Nome_Razao AS Descricao ";
                sql += "FROM ";
                sql += "Pessoa ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND Situacao = 'true' ";
                sql += "AND TipoPessoa = 2 ";
                sql += "AND ID_Pessoa <> " + Pessoa.ID + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = string.Empty;

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Venda ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Vendas\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Produto_Entrada ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Compra/Entrada de Produto\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Orcamento ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Orçamento\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Ordem_Servico ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Ordem de Serviço\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "CPagar ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Contas a Pagar\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "CReceber ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Contas a Receber\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Usuario ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Usuário\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Imovel_Proprietario ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Proprietário de Imóvel\n";

                sql = "SELECT ";
                sql += "ID_Pessoa ";
                sql += "FROM ";
                sql += "Imovel_Proprietario ";
                sql += "WHERE ";
                sql += "TipoPessoa = " + Pessoa.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + Pessoa.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Proprietário de Imóvel\n";


                if (Pessoa.TipoPessoa == 8)
                {
                    sql = "SELECT ";
                    sql += "ID_Locatario ";
                    sql += "FROM ";
                    sql += "Locacao_Locatario ";
                    sql += "WHERE ";
                    sql += "ID_Locatario = " + Pessoa.ID;
                    if (conexao.Consulta(sql).Rows.Count > 0)
                        msg += "Locatário de Imóvel\n";
                }

                if (Pessoa.TipoPessoa == 9)
                {
                    sql = "SELECT ";
                    sql += "ID_Fiador ";
                    sql += "FROM ";
                    sql += "Locacao_Fiador ";
                    sql += "WHERE ";
                    sql += "ID_Fiador = " + Pessoa.ID;
                    if (conexao.Consulta(sql).Rows.Count > 0)
                        msg += "Fiador de Imóvel\n";
                }

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_Exclui_Erro + msg);

                if (Pessoa.TipoPessoa == 2 &&
                    Parametro_Sistema.Usuario_Suporte == false)
                    throw new Exception("Consulte o Suporte Técnico para Excluir Empresa!");

                conexao.Begin_Conexao();

                cmd = new SqlCommand();
                sql = "DELETE FROM ";

                switch (Pessoa.TipoPessoa)
                {
                    case 1:
                        sql += "PessoaCliente ";
                        break;
                    case 2:
                        sql += "PessoaEmpresa ";
                        break;
                    case 3:
                        sql += "PessoaFornecedor ";
                        break;
                    case 4:
                        sql += "PessoaFuncionario ";
                        break;
                    case 5:
                        sql += "PessoaTransportadora ";
                        break;
                    case 6:
                        sql += "PessoaResponsavel ";
                        break;
                    case 7:
                        sql += "PessoaProprietario ";
                        break;
                    case 8:
                        sql += "PessoaLocatario ";
                        break;
                    case 9:
                        sql += "PessoaFiador ";
                        break;

                }
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Pessoa.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "PessoaEndereco ";
                sql += "WHERE ";
                sql += "TipoPessoa = @TipoPessoa ";
                sql += "AND ID_Pessoa = @ID_Pessoa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "PessoaTelefone ";
                sql += "WHERE ";
                sql += "TipoPessoa = @TipoPessoa ";
                sql += "AND ID_Pessoa = @ID_Pessoa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "PessoaEmail ";
                sql += "WHERE ";
                sql += "TipoPessoa = @TipoPessoa ";
                sql += "AND ID_Pessoa = @ID_Pessoa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Pessoa ";
                sql += "WHERE ";
                sql += "TipoPessoa = @TipoPessoa ";
                sql += "AND ID_Pessoa = @ID_Pessoa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                conexao.Executa_Comando(cmd);

                if (Pessoa.TipoPessoa == 6)
                {
                    cmd = new SqlCommand();
                    sql = "DELETE FROM ";
                    sql += "Pessoa_EmpresaResponsavel ";
                    sql += "WHERE ";
                    sql += "ID_Pessoa = @ID_Pessoa ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                    conexao.Executa_Comando(cmd);
                }

                if (Pessoa.TipoPessoa == 2 &&
                    Parametro_Sistema.Usuario_Suporte == true)
                {
                    cmd = new SqlCommand();
                    sql = "DELETE FROM ";
                    sql += "Parametro_Sistema ";
                    sql += "WHERE ";
                    sql += "ID_Empresa = @ID_Empresa ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Pessoa.ID);
                    conexao.Executa_Comando(cmd);

                    cmd = new SqlCommand();
                    sql = "DELETE FROM ";
                    sql += "Produto_Estoque ";
                    sql += "WHERE ";
                    sql += "ID_Empresa = @ID_Empresa ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Pessoa.ID);
                    conexao.Executa_Comando(cmd);

                    cmd = new SqlCommand();
                    sql = "DELETE FROM ";
                    sql += "Produto_Parametro ";
                    sql += "WHERE ";
                    sql += "ID_Empresa = @ID_Empresa ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Pessoa.ID);
                    conexao.Executa_Comando(cmd);
                }

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_Endereco()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "PessoaEndereco ";
                sql += "WHERE ";
                sql += "ID_Endereco = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Pessoa.Endereco[0].ID);

                conexao.Executa_Comando(cmd);
                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_Telefone()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "PessoaTelefone ";
                sql += "WHERE ";
                sql += "ID_Telefone = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Pessoa.Telefone[0].ID);
                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_Email()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "PessoaEmail ";
                sql += "WHERE ";
                sql += "ID_Email = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Pessoa.Email[0].ID);

                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui_EmpresaResponsavel()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Pessoa_EmpresaResponsavel ";
                sql += "WHERE ";
                sql += "ID_Pessoa = @ID_Pessoa ";
                sql += "AND TipoPessoa = @TipoPessoa ";
                sql += "AND TipoPessoaResponsavel = @TipoPessoaResponsavel ";
                sql += "AND ID_PessoaResponsavel = @ID_PessoaResponsavel ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Pessoa", Pessoa.ID);
                cmd.Parameters.AddWithValue("@TipoPessoa", Pessoa.TipoPessoa);
                cmd.Parameters.AddWithValue("@TipoPessoaResponsavel", Pessoa.TipoPessoa_EmpresaResponsavel);
                cmd.Parameters.AddWithValue("@ID_PessoaResponsavel", Pessoa.ID_EmpresaResponsavel);

                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }
    }
}
