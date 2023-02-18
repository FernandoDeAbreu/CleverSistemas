using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_GrupoNivel
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_GrupoNivel GrupoNivel;
        #endregion

        #region CONSTRUTORES
        public DAL_GrupoNivel(DTO_GrupoNivel _GrupoNivel)
        {
            GrupoNivel = _GrupoNivel;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (GrupoNivel.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "GrupoNivel ";
                    sql += "(Nivel, CodigoPai, Codigo, CodigoDescritivo, Descricao) ";
                    sql += "Values ";
                    sql += "(@Nivel, @CodigoPai, @Codigo, @CodigoDescritivo, @Descricao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Nivel", GrupoNivel.Nivel);
                    cmd.Parameters.AddWithValue("@CodigoPai", GrupoNivel.CodigoPai);
                    cmd.Parameters.AddWithValue("@Codigo", GrupoNivel.Codigo);
                    cmd.Parameters.AddWithValue("@CodigoDescritivo", GrupoNivel.CodigoDescritivo);
                    cmd.Parameters.AddWithValue("@Descricao", GrupoNivel.Descricao);
                    GrupoNivel.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "GrupoNivel ";
                    sql += "SET ";
                    sql += "Nivel = @Nivel, ";
                    sql += "CodigoPai = @CodigoPai, ";
                    sql += "Codigo = @Codigo, ";
                    sql += "CodigoDescritivo = @CodigoDescritivo, ";
                    sql += "Descricao = @Descricao ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", GrupoNivel.ID);
                    cmd.Parameters.AddWithValue("@Nivel", GrupoNivel.Nivel);
                    cmd.Parameters.AddWithValue("@CodigoPai", GrupoNivel.CodigoPai);
                    cmd.Parameters.AddWithValue("@Codigo", GrupoNivel.Codigo);
                    cmd.Parameters.AddWithValue("@CodigoDescritivo", GrupoNivel.CodigoDescritivo);
                    cmd.Parameters.AddWithValue("@Descricao", GrupoNivel.Descricao);

                    conexao.Executa_Comando(cmd);
                }
                return GrupoNivel.ID;
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
                sql += "ID, ID AS IDConta, Nivel, CodigoPai, Codigo, CodigoDescritivo, CodigoDescritivo AS Complemento, Descricao, Descricao AS DescricaoConta ";
                sql += "FROM GrupoNivel ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (GrupoNivel.CodigoPai != string.Empty && GrupoNivel.Plano == string.Empty)
                {
                    if (GrupoNivel.CodigoPai.Length == 2)
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + GrupoNivel.CodigoPai + "') ";

                    if (GrupoNivel.CodigoPai.Length == 4)
                    {
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(0, 2) + "') ";
                        sql += "OR (CodigoPai = '" + GrupoNivel.CodigoPai.Substring(0, 2) + "' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(2, 2) + "') ";
                    }

                    if (GrupoNivel.CodigoPai.Length == 6)
                    {
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(0, 2) + "') ";
                        sql += "OR (CodigoPai = '" + GrupoNivel.CodigoPai.Substring(0, 2) + "' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(2, 2) + "') ";
                        sql += "OR (CodigoPai = '" + GrupoNivel.CodigoPai.Substring(0, 4) + "' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(4, 2) + "') ";
                    }

                    if (GrupoNivel.CodigoPai.Length == 8)
                    {
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(0, 2) + "') ";
                        sql += "OR (CodigoPai = '" + GrupoNivel.CodigoPai.Substring(0, 2) + "' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(2, 2) + "') ";
                        sql += "OR (CodigoPai = '" + GrupoNivel.CodigoPai.Substring(0, 4) + "' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(4, 2) + "') ";
                        sql += "OR (CodigoPai = '" + GrupoNivel.CodigoPai.Substring(0, 6) + "' AND Codigo = '" + GrupoNivel.CodigoPai.Substring(6, 2) + "') ";
                    }
                }
                else if (GrupoNivel.Plano != String.Empty && GrupoNivel.Plano != null)
                    sql += "AND CodigoPai = '" + GrupoNivel.Plano + "' ";

                if (GrupoNivel.ID > 0)
                    sql += "AND ID = " + GrupoNivel.ID + " ";

                if (GrupoNivel.Codigo != String.Empty && GrupoNivel.Codigo != null)
                    sql += "AND Codigo = '" + GrupoNivel.Codigo + "' ";

                if (GrupoNivel.Descricao != String.Empty && GrupoNivel.Descricao != null)
                    sql += "AND Descricao LIKE '" + GrupoNivel.Descricao + "%' ";

                if (GrupoNivel.CodigoDescritivo != String.Empty && GrupoNivel.CodigoDescritivo != null)
                    sql += "AND CodigoDescritivo = '" + GrupoNivel.CodigoDescritivo + "' ";

                if (GrupoNivel.Nivel > 0)
                    sql += "AND Nivel = " + GrupoNivel.Nivel + " ";

                sql += "ORDER BY CodigoPai ";

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
                sql += "GrupoNivel ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", GrupoNivel.ID);

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
