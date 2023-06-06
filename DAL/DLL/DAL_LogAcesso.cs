using Sistema.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.DAL.DLL
{
    public class DAL_LogAcesso
    {
        #region VARIAVEIS DE CLASSE

        private Conexao conexao;

        #endregion VARIAVEIS DE CLASSE

        #region VARIAVEIS DIVERSAS

        private SqlCommand cmd;

        private string sql;
        private string msg;

        #endregion VARIAVEIS DIVERSAS

        #region ESTRUTURA

        private DTO_Usuario Usuario;
        private DTO_Usuario_Parametros Usuario_Parametros;
        private DTO_Log Log_Usuario;

        #endregion ESTRUTURA

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