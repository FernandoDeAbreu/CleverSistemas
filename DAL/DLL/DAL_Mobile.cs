using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_Mobile
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Mobile Mobile;
        #endregion

        #region CONSTRUTOR
        public DAL_Mobile(DTO_Mobile _Mobile)
        {
            Mobile = _Mobile;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                              if (Mobile.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Mobile ";
                    sql += "(IMEI, Equipamento, Ativo) ";
                    sql += "VALUES ";
                    sql += "(@IMEI, @Equipamento, @Ativo) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@IMEI", Mobile.IMEI);
                    cmd.Parameters.AddWithValue("@Equipamento", Mobile.Equipamento);
                    cmd.Parameters.AddWithValue("@Ativo", Mobile.Ativo);

                    Mobile.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Mobile ";
                    sql += "SET ";
                    sql += "IMEI = @IMEI, ";
                    sql += "Equipamento = @Equipamento, ";
                    sql += "Ativo = @Ativo ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Mobile.ID);
                    cmd.Parameters.AddWithValue("@IMEI", Mobile.IMEI);
                    cmd.Parameters.AddWithValue("@Equipamento", Mobile.Equipamento);
                    cmd.Parameters.AddWithValue("@Ativo", Mobile.Ativo);

                    conexao.Executa_Comando(cmd);
                }

                conexao.Commit_Conexao();

                return Mobile.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Mobile";
                int aux = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Mobile, RESEED, " + aux + ")";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);
                #endregion

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Altera_Situacao()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "UPDATE ";
                sql += "Mobile ";
                sql += "SET ";
                sql += "Ativo = @Ativo ";
                sql += "WHERE ";
                sql += "ID = @ID ";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Mobile.ID);
                cmd.Parameters.AddWithValue("@Ativo", Mobile.Ativo);

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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, IMEI, Equipamento, Ativo ";
                sql += "FROM Mobile ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Mobile.ID > 0)
                    sql += "AND ID = " + Mobile.ID + " ";

              //  if (Mobile.IMEI != string.Empty)
                //    sql += "AND IMEI = '" + Mobile.IMEI + "' ";

                sql += "ORDER BY Equipamento ";

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
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Mobile ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Mobile.ID);
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
    }
}
