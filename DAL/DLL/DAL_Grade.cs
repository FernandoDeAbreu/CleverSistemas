using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;

namespace Sistema.DAL
{
    public class DAL_Grade
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Grade Grade;
        #endregion

        #region CONSTRUTORES
        public DAL_Grade(DTO_Grade _Grade)
        {
            this.Grade = _Grade;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (Grade.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Grade ";
                    sql += "(ID_Grupo, Descricao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Grupo, @Descricao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Grupo", Grade.ID_Grupo);
                    cmd.Parameters.AddWithValue("@Descricao", Grade.Descricao);

                    Grade.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Grade SET ";
                    sql += "ID_Grupo = @ID_Grupo, ";
                    sql += "Descricao = @Descricao ";
                    sql += "WHERE ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Grade.ID);
                    cmd.Parameters.AddWithValue("@ID_Grupo", Grade.ID_Grupo);
                    cmd.Parameters.AddWithValue("@Descricao", Grade.Descricao);

                    conexao.Executa_Comando(cmd);
                }
                return Grade.ID;
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
                sql += "G.ID, G.ID_Grupo, G.ID_Grupo AS ID_GrupoGrade, G.Descricao, ";
                sql += "Grupo.Descricao AS DescricaoGrupo ";
                sql += "FROM ";
                sql += "Grade AS G INNER JOIN Grupo AS Grupo ON G.ID_Grupo = Grupo.ID ";
                sql += "WHERE ";
                sql += "NOT G.ID IS NULL ";

                if (Grade.ID > 0)
                    sql += "AND G.ID = " + Grade.ID + " ";

                if (Grade.ID_Grupo > 0)
                    sql += "AND G.ID_Grupo = " + Grade.ID_Grupo + " ";

                sql += "ORDER BY G.Descricao";

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
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Grade ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Grade.ID);

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
