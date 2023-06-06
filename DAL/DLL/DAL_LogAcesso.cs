using MySql.Data.MySqlClient;
using Sistema.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.DAL
{
    public class DAL_LogAcesso
    {
        #region VARIAVEIS DE CLASSE

        private Conexao conexao;
        private ConexaoMySQL conexaoMySQL;

        #endregion VARIAVEIS DE CLASSE

        #region VARIAVEIS DIVERSAS

        private SqlCommand cmd;
        private MySqlCommand cmdMySql;

        private string sql;
        private string msg;

        #endregion VARIAVEIS DIVERSAS

        #region ESTRUTURA

        private DTO_Usuario Usuario;
        private DTO_Usuario_Parametros Usuario_Parametros;
        private DTO_Log Log_Usuario;
        private DTO_LogAcesso logAcesso;

        #endregion ESTRUTURA

        #region CONSTRUTORES

        public DAL_LogAcesso(DTO_LogAcesso logAcesso)
        {
            this.logAcesso = logAcesso;
        }

        #endregion CONSTRUTORES

        public int Grava()
        {
            conexaoMySQL = new ConexaoMySQL();
            cmdMySql = new MySqlCommand();

            try
            {
                conexaoMySQL.Abre_Conecao();
                sql  = "INSERT INTO LogAcesso ";
                sql += "(NomeEmpresa, NomeUsuario, DataConexao, Terminal, VersaoSistema, VersaoBanco, ChaveBanco) ";
                sql += "VALUES ";
                sql += "(@NomeEmpresa, @NomeUsuario, @DataConexao, @Terminal, @VersaoSistema, @VersaoBanco, @ChaveBanco) ";
                cmdMySql.CommandText = sql;
                cmdMySql.Parameters.AddWithValue("@NomeEmpresa", logAcesso.NomeEmpresa);
                cmdMySql.Parameters.AddWithValue("@NomeUsuario", logAcesso.NomeUsuario);
                cmdMySql.Parameters.AddWithValue("@DataConexao", logAcesso.DataConexao);
                cmdMySql.Parameters.AddWithValue("@Terminal", logAcesso.Terminal);
                cmdMySql.Parameters.AddWithValue("@VersaoSistema", logAcesso.VersaoSistema);
                cmdMySql.Parameters.AddWithValue("@VersaoBanco", logAcesso.VersaoBanco);
                cmdMySql.Parameters.AddWithValue("@ChaveBanco", logAcesso.ChaveBanco);

                conexaoMySQL.Executa_Comando(cmdMySql);

                return logAcesso.ID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexaoMySQL.Fecha_Conexao();
            }
        }

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                sql = "SELECT ";
                sql += "TOP 1 Pessoa.Nome_Razao, Usuario.Descricao, L.Data, l.Terminal ";
                sql += "FROM ";
                sql += "Log_Acesso L ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = 2 AND Pessoa.ID_Pessoa = L.ID_Empresa ";
                sql += "INNER JOIN Usuario AS Usuario ON Usuario.TipoPessoa = 4 AND Usuario.ID = L.ID_Usuario ";
                sql += "ORDER BY L.ID DESC";

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
    }
}