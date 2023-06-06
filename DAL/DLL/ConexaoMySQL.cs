using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Sistema.DAL.DLL
{
    public class ConexaoMySQL
    {
        private MySqlConnection conexao;
        private MySqlTransaction Trans;
        private MySqlCommand cmd;

        public void Abre_Conecao()
        {
            try
            {
                conexao = new MySqlConnection("server=srv643.hstgr.io;uid=u764159413_root;pwd=a7>m;X@E0gG;database=u764159413_Clever");
                conexao.Open();
                cmd = conexao.CreateCommand();
                cmd.CommandText = "SET LANGUAGE PORTUGUESE";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
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
            catch (MySqlException ex)
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

        public void Executa_Comando(MySqlCommand cmd)
        {
            try
            {
                cmd.Connection = conexao;
                cmd.Transaction = Trans;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Executa_ComandoID(MySqlCommand cmd)
        {
            try
            {
                cmd.Connection = conexao;
                cmd.Transaction = Trans;
                cmd.CommandText += "; SELECT @@IDENTITY";

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
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
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexao);
                da.TableMappings.Add("Temporario", "Tab1");
                da.Fill(DT);

                return DT;
            }
            catch (MySqlException ex)
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