using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using Sistema.DTO;
using System.Data;

namespace Sistema.DAL
{
    public class DAL_NCM
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_NCM NCM;
        #endregion

        #region CONSTRUTOR
        public DAL_NCM(DTO_NCM _NCM)
        {
            this.NCM = _NCM;
        }

        public DAL_NCM()
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

                if (NCM.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "NCM ";
                    sql += "(NCM, Descricao, EX, AliqNacFederal, AliqImpFederal, AliqEstadual) ";
                    sql += "VALUES ";
                    sql += "(@NCM, @Descricao, @EX, @AliqNacFederal, @AliqImpFederal, @AliqEstadual) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NCM", NCM.NCM);
                    cmd.Parameters.AddWithValue("@Descricao", NCM.Descricao);
                    cmd.Parameters.AddWithValue("@EX", NCM.EX);
                    cmd.Parameters.AddWithValue("@AliqNacFederal", NCM.AliqNacFederal);
                    cmd.Parameters.AddWithValue("@AliqImpFederal", NCM.AliqImpFederal);
                    cmd.Parameters.AddWithValue("@AliqEstadual", NCM.AliqEstadual);

                    NCM.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "NCM ";
                    sql += "SET ";
                    sql += "NCM = @NCM, ";
                    sql += "EX = @EX, ";
                    sql += "Descricao = @Descricao, ";
                    sql += "AliqNacFederal = @AliqNacFederal, ";
                    sql += "AliqImpFederal = @AliqImpFederal, ";
                    sql += "AliqEstadual = @AliqEstadual ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", NCM.ID);
                    cmd.Parameters.AddWithValue("@NCM", NCM.NCM);
                    cmd.Parameters.AddWithValue("@Descricao", NCM.Descricao);
                    cmd.Parameters.AddWithValue("@EX", NCM.EX);
                    cmd.Parameters.AddWithValue("@AliqNacFederal", NCM.AliqNacFederal);
                    cmd.Parameters.AddWithValue("@AliqImpFederal", NCM.AliqImpFederal);
                    cmd.Parameters.AddWithValue("@AliqEstadual", NCM.AliqEstadual);

                    conexao.Executa_Comando(cmd);
                }

                return NCM.ID;
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

        public int Grava_CEST()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                if (NCM.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "CEST ";
                    sql += "(NCM, CEST, Descricao) ";
                    sql += "VALUES ";
                    sql += "(@NCM, @CEST, @Descricao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NCM", NCM.NCM);
                    cmd.Parameters.AddWithValue("@CEST", NCM.CEST);
                    cmd.Parameters.AddWithValue("@Descricao", NCM.Descricao);

                    NCM.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "CEST ";
                    sql += "SET ";
                    sql += "NCM = @NCM, ";
                    sql += "CEST = @CEST, ";
                    sql += "Descricao = @Descricao ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", NCM.ID);
                    cmd.Parameters.AddWithValue("@NCM", NCM.NCM);
                    cmd.Parameters.AddWithValue("@CEST", NCM.CEST);
                    cmd.Parameters.AddWithValue("@Descricao", NCM.Descricao);

                    conexao.Executa_Comando(cmd);
                }

                return NCM.ID;
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

        public void Atualiza_NCM()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                DataTable _DT_CEST = new DataTable();

                sql = "SELECT ID, NCM ";
                sql += "FROM CEST ";

                _DT_CEST = conexao.Consulta(sql);

                if (_DT_CEST.Rows.Count > 0)
                    for (int i = 0; i <= _DT_CEST.Rows.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        sql = "UPDATE Produto_Servico SET ";
                        sql += "ID_CEST = @ID_CEST ";
                        sql += "WHERE SUBSTRING(NCM, 1, LEN(@NCM)) = @NCM ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_CEST", _DT_CEST.Rows[i]["ID"]);
                        cmd.Parameters.AddWithValue("@NCM", _DT_CEST.Rows[i]["NCM"]);

                        conexao.Executa_Comando(cmd);
                    }

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
                sql += "ID, NCM, Descricao, EX, AliqNacFederal, AliqImpFederal, AliqEstadual ";
                sql += "FROM NCM ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (NCM.ID > 0)
                    sql += "AND ID = " + NCM.ID + " ";

                if (NCM.EX > 0)
                    sql += "AND EX = " + NCM.EX + " ";


                if (NCM.NCM != string.Empty)
                    sql += "AND NCM = " + NCM.NCM + " ";

                if (NCM.Descricao != null)
                    sql += "AND Descricao LIKE '" + NCM.Descricao + "%' ";

                sql += "ORDER BY Descricao ";

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

        public DataTable Busca_CEST()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, NCM, CEST, Descricao, (CEST + '-' + UPPER(Descricao)) AS DescricaoCompleta ";
                sql += "FROM CEST ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (NCM.ID > 0)
                    sql += "AND ID = " + NCM.ID + " ";

                if (NCM.EX > 0)
                    sql += "AND CEST = " + NCM.CEST + " ";

                if (NCM.NCM != string.Empty)
                    sql += "AND NCM = LEFT(" + NCM.NCM + ", LEN(NCM)) ";

                if (NCM.Descricao != null)
                    sql += "AND Descricao LIKE '" + NCM.Descricao + "%' ";

                sql += "ORDER BY Descricao ";

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
            msg = "";
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "NCM; ";

                sql += "TRUNCATE TABLE ";
                sql += "NCM ";
                cmd.CommandText = sql;

                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
        }

        public void Exclui_CEST()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = "";
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "CEST; ";

                sql += "TRUNCATE TABLE ";
                sql += "CEST ";
                cmd.CommandText = sql;

                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
        }
    }
}
