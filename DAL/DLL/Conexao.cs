using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class Conexao
    {
        SqlConnection conexao;
        SqlTransaction Trans;
        SqlCommand cmd;

        public void Abre_Conexao()
        {
            try
            {
                conexao = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);
                conexao.Open();
                cmd = conexao.CreateCommand();
                cmd.CommandText = "SET LANGUAGE PORTUGUESE";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Fecha_Conexao()
        {
            try
            {
                conexao.Close();
                conexao.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Begin_Conexao()
        {
            Trans = conexao.BeginTransaction();
            cmd.Transaction = Trans;
        }

        public void Commit_Conexao()
        {
            Trans.Commit();
        }

        public void RollBack_Conexao()
        {
            Trans.Rollback();
        }

        public void Executa_Comando(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = conexao;
                cmd.Transaction = Trans;
                cmd.ExecuteNonQuery();
                                            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Executa_ComandoID(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = conexao;
                cmd.Transaction = Trans;
                cmd.CommandText += "; SELECT @@IDENTITY";

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Consulta(string query)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, conexao);
                da.TableMappings.Add("Temporario", "Tab1");
                da.Fill(DT);

                return DT;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
