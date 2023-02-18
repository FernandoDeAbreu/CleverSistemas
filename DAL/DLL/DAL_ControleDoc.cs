using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Sistema.DTO;

namespace Sistema.DAL
{
    public class DAL_ControleDoc
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;

        string sql;
        string msg;

        private SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_ControleDoc ControleDoc;
        #endregion

        #region CONTRUTOR
        public DAL_ControleDoc(DTO_ControleDoc _ControleDoc)
        {
            this.ControleDoc = _ControleDoc;
        }
        #endregion

        public int Grava()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "INSERT INTO ";
                sql += "ControleDoc ";
                sql += "(ID_Documento, TipoPessoa, ID_Pessoa, Periodo, Entregue) ";
                sql += "VALUES ";
                sql += "(@ID_Documento, @TipoPessoa, @ID_Pessoa, @Periodo, @Entregue) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Documento", ControleDoc.Documento.ID);
                cmd.Parameters.AddWithValue("@TipoPessoa", ControleDoc.TipoPessoa);
                cmd.Parameters.AddWithValue("@ID_Pessoa", ControleDoc.ID_Pessoa);
                cmd.Parameters.AddWithValue("@Periodo", ControleDoc.Periodo);
                cmd.Parameters.AddWithValue("@Entregue", ControleDoc.Entregue);

                return conexao.Executa_ComandoID(cmd);
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

        public void Baixa()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "ControleDoc ";
                sql += "SET ";
                sql += "DataEntrada = @DataEntrada, ";
                sql += "Entregue = @Entregue ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", ControleDoc.ID);
                cmd.Parameters.AddWithValue("@DataEntrada", ControleDoc.DataEntrada);
                cmd.Parameters.AddWithValue("@Entregue", ControleDoc.Entregue);

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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "CD.ID, CD.ID_Documento, CD.TipoPessoa, CD.ID_Pessoa, CD.Periodo, CD.DataEntrada, CD.Entregue, ";
                sql += "G.Descricao AS TipoDocumento, ";
                sql += "D.Descricao AS Documento ";
                sql += "FROM ControleDoc AS CD ";
                sql += "INNER JOIN ControleDoc_Tipo AS D ON D.ID = CD.ID_Documento ";
                sql += "INNER JOIN Grupo AS G ON G.ID = D.ID_Tipo ";
                sql += "WHERE ";
                sql += "NOT CD.ID IS NULL ";

                if (ControleDoc.Entregue == false)
                    sql += "AND CD.Entregue = 'false' ";

                if (ControleDoc.ID > 0)
                    sql += "AND CD.ID = '" + ControleDoc.ID + "' ";

                if (ControleDoc.TipoPessoa > 0)
                    sql += "AND CD.TipoPessoa = " + ControleDoc.TipoPessoa + " ";

                if (ControleDoc.ID_Pessoa > 0)
                    sql += "AND CD.ID_Pessoa = " + ControleDoc.ID_Pessoa + " ";

                if (ControleDoc.ConsultaEntrada.Filtra == true)
                    sql += "AND CONVERT(DATE, CD.DataEntrada) BETWEEN CONVERT(DATE, '" + ControleDoc.ConsultaEntrada.Inicial + "') AND CONVERT(DATE, '" + ControleDoc.ConsultaEntrada.Final + "') ";

                if (ControleDoc.ConsultaPeriodo.Filtra == true)
                    sql += "AND CONVERT(DATE, CD.Periodo) BETWEEN CONVERT(DATE, '" + ControleDoc.ConsultaPeriodo.Inicial + "') AND CONVERT(DATE, '" + ControleDoc.ConsultaPeriodo.Final + "') ";

                sql += "ORDER BY G.Descricao, CD.Entregue, CD.DataEntrada ";

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

        public DataTable Busca_Config()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "D.Descricao AS Documento, D.ID AS ID_Doc, ";
                sql += "G.Descricao AS TipoDocumento ";
                sql += "FROM ControleDoc_Tipo D ";
                sql += "INNER JOIN Grupo AS G ON G.ID = D.ID_Tipo ";

                sql += "ORDER BY G.Descricao ";

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
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "ControleDoc ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", ControleDoc.ID);
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

    public class DAL_ControleDoc_Tipo
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;

        string sql;
        string msg;

        private SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_ControleDoc_Tipo ControleDoc_Tipo;
        #endregion

        #region CONSTRUTOR
        public DAL_ControleDoc_Tipo(DTO_ControleDoc_Tipo _ControleDoc_Tipo)
        {
            this.ControleDoc_Tipo = _ControleDoc_Tipo;
        }
        #endregion

        public int Grava()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                if (ControleDoc_Tipo.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "ControleDoc_Tipo ";
                    sql += "(ID_Tipo, Descricao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Tipo, @Descricao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Tipo", ControleDoc_Tipo.ID_Tipo);
                    cmd.Parameters.AddWithValue("@Descricao", ControleDoc_Tipo.Descricao);

                    ControleDoc_Tipo.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "ControleDoc_Tipo ";
                    sql += "SET ";
                    sql += "ID_Tipo = @ID_Tipo, ";
                    sql += "Descricao = @Descricao ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", ControleDoc_Tipo.ID);
                    cmd.Parameters.AddWithValue("@ID_Tipo", ControleDoc_Tipo.ID_Tipo);
                    cmd.Parameters.AddWithValue("@Descricao", ControleDoc_Tipo.Descricao);

                    conexao.Executa_Comando(cmd);
                }
                return ControleDoc_Tipo.ID;
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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "CD.ID, CD.ID_Tipo, CD.Descricao, ";
                sql += "G.Descricao AS DescricaoTipo ";
                sql += "FROM ControleDoc_Tipo AS CD ";
                sql += "INNER JOIN Grupo AS G ON G.ID = CD.ID_Tipo ";
                sql += "WHERE ";
                sql += "NOT CD.ID IS NULL ";

                if (ControleDoc_Tipo.ID > 0)
                    sql += "AND CD.ID = " + ControleDoc_Tipo.ID + " ";

                if (ControleDoc_Tipo.ID_Tipo > 0)
                    sql += "AND CD.ID_Tipo = " + ControleDoc_Tipo.ID_Tipo + " ";

                if (ControleDoc_Tipo.Descricao != null)
                    sql += "AND CD.Descricao LIKE '" + ControleDoc_Tipo.Descricao + "%' ";

                sql += "ORDER BY CD.Descricao ";

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
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "ControleDoc_Tipo ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", ControleDoc_Tipo.ID);

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
