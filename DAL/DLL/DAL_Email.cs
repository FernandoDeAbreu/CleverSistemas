using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_Email
    {
        #region VARIAVEIS DE CLASSE
        Conexao conexao;
        #endregion

        #region VARIAVEIS DIVERSAS
        string sql;
        string msg;

        SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_Email Email;
        #endregion

        #region CONSTRUTORES
        public DAL_Email(DTO_Email _Email)
        {
            this.Email = _Email;
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

                #region GRAVA IMOVEL
                if (Email.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Email ";
                    sql += "(Data, Para, CC, CCO, Assunto, Conteudo, Anexo) ";
                    sql += "VALUES ";
                    sql += "(@Data, @Para, @CC, @CCO, @Assunto, @Conteudo, @Anexo) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Data", Email.Data);
                    cmd.Parameters.AddWithValue("@Para", Email.Para);
                    cmd.Parameters.AddWithValue("@CC", Email.CC);
                    cmd.Parameters.AddWithValue("@CCO", Email.CCO);
                    cmd.Parameters.AddWithValue("@Assunto", Email.Assunto);
                    cmd.Parameters.AddWithValue("@Conteudo", Email.Conteudo);
                    cmd.Parameters.AddWithValue("@Anexo", Email.Anexo);

                    Email.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Email ";
                    sql += "SET ";
                    sql += "Data = @Data, ";
                    sql += "Para = @Para, ";
                    sql += "CC = @CC, ";
                    sql += "CCO = @CCO, ";
                    sql += "Assunto = @Assunto, ";
                    sql += "Conteudo = @Conteudo, ";
                    sql += "Anexo = @Anexo ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Email.ID);
                    cmd.Parameters.AddWithValue("@Data", Email.Data);
                    cmd.Parameters.AddWithValue("@Para", Email.Para);
                    cmd.Parameters.AddWithValue("@CC", Email.CC);
                    cmd.Parameters.AddWithValue("@CCO", Email.CCO);
                    cmd.Parameters.AddWithValue("@Assunto", Email.Assunto);
                    cmd.Parameters.AddWithValue("@Conteudo", Email.Conteudo);
                    cmd.Parameters.AddWithValue("@Anexo", Email.Anexo);

                    conexao.Executa_Comando(cmd);
                }
                #endregion

                conexao.Commit_Conexao();

                return Email.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Email";
                int aux = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Email,RESEED, " + aux + ")";
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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID, Data, Para, CC, CCO, Assunto, Conteudo, Anexo ";
                sql += "FROM Email ";
                sql += "WHERE ";
                sql += "ID IS NOT NULL ";
                if (Email.ID > 0)
                    sql += "AND ID = " + Email.ID + " ";

                if (Email.Consulta_Data.Filtra == true)
                    sql += "AND CONVERT(DATE, Data) BETWEEN CONVERT(DATE, '" + Email.Consulta_Data.Inicial + "') AND CONVERT(DATE, '" + Email.Consulta_Data.Final + "') ";

                if (Email.Assunto.Trim() != string.Empty)
                    sql += "AND Assunto LIKE '%" + Email.Assunto + "%' ";

                sql += "ORDER BY Data DESC ";

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

                #region Consulta Módulos
                /* sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "ControleCheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                #endregion

                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Email ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Email.ID);
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