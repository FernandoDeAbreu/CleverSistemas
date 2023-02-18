using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;

namespace Sistema.DAL
{
    public class DAL_PlanoConta
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_PlanoConta PlanoConta;
        #endregion

        #region CONSTRUTOR
        public DAL_PlanoConta(DTO_PlanoConta _PlanoConta)
        {
            this.PlanoConta = _PlanoConta;
        }

        public DAL_PlanoConta()
        {
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (PlanoConta.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "PlanoConta ";
                    sql += "(Nivel, CodigoPai, Codigo, CodigoDescritivo, Descricao, Planejamento) ";
                    sql += "Values ";
                    sql += "(@Nivel, @CodigoPai, @Codigo, @CodigoDescritivo, @Descricao, @Planejamento) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Nivel", PlanoConta.Nivel);
                    cmd.Parameters.AddWithValue("@CodigoPai", PlanoConta.CodigoPai);
                    cmd.Parameters.AddWithValue("@Codigo", PlanoConta.Codigo);
                    cmd.Parameters.AddWithValue("@CodigoDescritivo", PlanoConta.CodigoDescritivo);
                    cmd.Parameters.AddWithValue("@Descricao", PlanoConta.Descricao);
                    cmd.Parameters.AddWithValue("@Planejamento", PlanoConta.Planejamento);

                    PlanoConta.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "PlanoConta SET ";
                    sql += "Nivel = @Nivel, ";
                    sql += "CodigoPai = @CodigoPai, ";
                    sql += "Codigo = @Codigo, ";
                    sql += "CodigoDescritivo = @CodigoDescritivo, ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Planejamento = @Planejamento ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", PlanoConta.ID);
                    cmd.Parameters.AddWithValue("@Nivel", PlanoConta.Nivel);
                    cmd.Parameters.AddWithValue("@CodigoPai", PlanoConta.CodigoPai);
                    cmd.Parameters.AddWithValue("@Codigo", PlanoConta.Codigo);
                    cmd.Parameters.AddWithValue("@CodigoDescritivo", PlanoConta.CodigoDescritivo);
                    cmd.Parameters.AddWithValue("@Descricao", PlanoConta.Descricao);
                    cmd.Parameters.AddWithValue("@Planejamento", PlanoConta.Planejamento);

                    conexao.Executa_Comando(cmd);
                }

                return PlanoConta.ID;
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
                sql += "ID, ID AS IDConta, ID AS IDConta1, Nivel, CodigoPai, Codigo, CodigoDescritivo, ";
                sql += "CodigoDescritivo AS Complemento, Descricao, Descricao AS DescricaoConta, Descricao AS DescricaoConta1, Planejamento ";
                sql += "FROM PlanoConta ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (PlanoConta.Planejamento == true)
                    sql += "AND Planejamento = '" + PlanoConta.Planejamento + "' ";

                if (PlanoConta.CodigoPai != string.Empty && PlanoConta.Plano == string.Empty)
                {
                    if (PlanoConta.CodigoPai.Length == 2)
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + PlanoConta.CodigoPai + "') ";

                    if (PlanoConta.CodigoPai.Length == 4)
                    {
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + PlanoConta.CodigoPai.Substring(0, 2) + "') ";
                        sql += "OR (CodigoPai = '" + PlanoConta.CodigoPai.Substring(0, 2) + "' AND Codigo = '" + PlanoConta.CodigoPai.Substring(2, 2) + "') ";
                    }

                    if (PlanoConta.CodigoPai.Length == 6)
                    {
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + PlanoConta.CodigoPai.Substring(0, 2) + "') ";
                        sql += "OR (CodigoPai = '" + PlanoConta.CodigoPai.Substring(0, 2) + "' AND Codigo = '" + PlanoConta.CodigoPai.Substring(2, 2) + "') ";
                        sql += "OR (CodigoPai = '" + PlanoConta.CodigoPai.Substring(0, 4) + "' AND Codigo = '" + PlanoConta.CodigoPai.Substring(4, 2) + "') ";
                    }

                    if (PlanoConta.CodigoPai.Length == 8)
                    {
                        sql += "AND (CodigoPai = '0' AND Codigo = '" + PlanoConta.CodigoPai.Substring(0, 2) + "') ";
                        sql += "OR (CodigoPai = '" + PlanoConta.CodigoPai.Substring(0, 2) + "' AND Codigo = '" + PlanoConta.CodigoPai.Substring(2, 2) + "') ";
                        sql += "OR (CodigoPai = '" + PlanoConta.CodigoPai.Substring(0, 4) + "' AND Codigo = '" + PlanoConta.CodigoPai.Substring(4, 2) + "') ";
                        sql += "OR (CodigoPai = '" + PlanoConta.CodigoPai.Substring(0, 6) + "' AND Codigo = '" + PlanoConta.CodigoPai.Substring(6, 2) + "') ";
                    }

                }

                else if (PlanoConta.Plano != string.Empty)
                    sql += "AND CodigoPai = '" + PlanoConta.Plano + "' ";

                if (PlanoConta.ID > 0)
                    sql += "AND ID = " + PlanoConta.ID + " ";

                if (PlanoConta.Codigo != string.Empty)
                    sql += "AND Codigo = '" + PlanoConta.Codigo + "' ";

                if (PlanoConta.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + PlanoConta.Descricao + "%' ";

                if (PlanoConta.CodigoDescritivo != string.Empty)
                    sql += "AND CodigoDescritivo = '" + PlanoConta.CodigoDescritivo + "' ";

                if (PlanoConta.Nivel > 0)
                    sql += "AND Nivel = " + PlanoConta.Nivel + " ";

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

        public DataTable Busca_Codigo()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "CodigoDescritivo ";
                sql += "FROM PlanoConta ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID = " + PlanoConta.ID + " ";

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
                sql += "CASE Nivel ";
                sql += "WHEN 1 THEN ";
                sql += "CodigoDescritivo + ' - ' + Descricao ";
                sql += "WHEN 2 THEN ";
                sql += "CodigoDescritivo + ' - ' + Descricao ";
                sql += "WHEN 3 THEN ";
                sql += "CodigoDescritivo + ' - ' + Descricao ";
                sql += "WHEN 4 THEN ";
                sql += "CodigoDescritivo + ' - ' + Descricao ";
                sql += "END AS DescricaoConta, ";
                sql += "Planejamento ";
                sql += "FROM PlanoConta ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "ORDER BY CodigoDescritivo ";

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
                sql += "PlanoConta ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", PlanoConta.ID);
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
