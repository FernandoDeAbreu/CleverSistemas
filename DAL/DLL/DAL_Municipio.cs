using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_Municipio
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Municipio Municipio;
        #endregion

        #region CONSTRUTORES
        public DAL_Municipio(DTO_Municipio _Municipio)
        {
            Municipio = _Municipio;
        }
        #endregion

        public int Grava_Pais()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (Municipio.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Pais ";
                    sql += "(ID_Pais, Descricao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Pais, @Descricao)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Pais", Municipio.ID_Pais);
                    cmd.Parameters.AddWithValue("@Descricao", Municipio.Descricao);
                    Municipio.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Pais ";
                    sql += "SET ";
                    sql += "ID_Pais = @ID_Pais, ";
                    sql += "Descricao = @Descricao ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Municipio.ID);
                    cmd.Parameters.AddWithValue("@ID_Pais", Municipio.ID_Pais);
                    cmd.Parameters.AddWithValue("@Descricao", Municipio.Descricao);
                    conexao.Executa_Comando(cmd);
                }
                return Municipio.ID;
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

        public int Grava_Municipio()
        {
            conexao = new Conexao();

            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (Municipio.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Municipios ";
                    sql += "(ID_Pais, ID_UF, ID_Municipio, Descricao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Pais, @ID_UF, @ID_Municipio, @Descricao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Pais", Municipio.ID_Pais);
                    cmd.Parameters.AddWithValue("@ID_UF", Municipio.ID_UF);
                    cmd.Parameters.AddWithValue("@ID_Municipio", Municipio.ID_Municipio);
                    cmd.Parameters.AddWithValue("@Descricao", Municipio.Descricao);
                    Municipio.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Municipios ";
                    sql += "SET ";
                    sql += "ID_Pais = @ID_Pais, ";
                    sql += "ID_UF = @ID_UF, ";
                    sql += "ID_Municipio = @ID_Municipio, ";
                    sql += "Descricao = @Descricao ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Municipio.ID);
                    cmd.Parameters.AddWithValue("@ID_Pais", Municipio.ID_Pais);
                    cmd.Parameters.AddWithValue("@ID_UF", Municipio.ID_UF);
                    cmd.Parameters.AddWithValue("@ID_Municipio", Municipio.ID_Municipio);
                    cmd.Parameters.AddWithValue("@Descricao", Municipio.Descricao);
                    conexao.Executa_Comando(cmd);
                }
                return Municipio.ID;
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

        public int Grava_UF()
        {
            conexao = new Conexao();

            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "UPDATE UF SET ";
                sql += "Aliquota_Interna = @Aliquota_Interna, ";
                sql += "Aliquota_FCP = @Aliquota_FCP ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Municipio.ID);
                cmd.Parameters.AddWithValue("@Aliquota_Interna", Municipio.Aliquota_Interna);
                cmd.Parameters.AddWithValue("@Aliquota_FCP", Municipio.Aliquota_FCP);
                conexao.Executa_Comando(cmd);

                #region GRAVA ALIQUOTA ICMS PARTILHA
                if (Municipio._lst_AliquotaICMS.Count > 0)
                {
                    sql = "DELETE FROM UF_AliquotaICMS ";
                    sql += "WHERE ID_UF_Origem = " + Municipio.ID_UF;

                    for (int i = 0; i <= Municipio._lst_AliquotaICMS.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        sql = "INSERT INTO UF_AliquotaICMS ";
                        sql += "(ID_UF_Origem, ID_UF_Destino, Aliquota) ";
                        sql += "VALUES ";
                        sql += "(@ID_UF_Origem, @ID_UF_Destino, @Aliquota) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_UF_Origem", Municipio.ID_UF);
                        cmd.Parameters.AddWithValue("@ID_UF_Destino", Municipio._lst_AliquotaICMS[i].ID_UF_Destino);
                        cmd.Parameters.AddWithValue("@Aliquota", Municipio._lst_AliquotaICMS[i].Aliquota);
                        conexao.Executa_Comando(cmd);
                    }
                }
                #endregion
                conexao.Commit_Conexao();
                return Municipio.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
            finally
            {
                ////conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca_UF()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, ID_Pais AS Pais, ID_UF, Sigla, Upper(Descricao) AS Descricao, Aliquota_Interna, Aliquota_FCP ";
                sql += "FROM UF ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Municipio.ID > 0)
                    sql += "AND ID = " + Municipio.ID + " ";

                if (Municipio.ID_Pais > 0)
                    if (Municipio.ID_Pais == 1058)
                        sql += "AND ID_Pais = " + Municipio.ID_Pais + " ";
                    else
                        sql += "AND ID_Pais = 1 ";

                if (Municipio.ID_UF > 0)
                    sql = "AND ID_UF = " + Municipio.ID_UF + " ";

                if (Municipio.Descricao != string.Empty &&
                    Municipio.Descricao != null)
                    sql += "AND Descricao LIKE '" + Municipio.Descricao + "%' ";

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

        public DataTable Busca_UF_Aliquota_Inter()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                switch (Municipio.Tipo_Consulta)
                {
                    case 1:
                        sql = "SELECT ";
                        sql += "UFA.Aliquota AS Aliquota_Interestadual, ";
                        sql += "UF.Aliquota_Interna, UF.Aliquota_FCP ";
                        sql += "FROM UF_AliquotaICMS AS UFA ";
                        sql += "INNER JOIN UF ON UFA.ID_UF_Destino = UF.ID_UF ";
                        sql += "WHERE ";

                        sql += "UFA.ID_UF_Origem = " + Municipio.ID_UF_Origem + " ";

                        if (Municipio.ID_UF_Destino > 0)
                            sql += "AND UFA.ID_UF_Destino = " + Municipio.ID_UF_Destino + " ";
                        break;

                    case 2:
                        sql = "SELECT ";
                        sql += "UF.Sigla, ";
                        sql += "UFA.ID_UF_Destino, UFA.Aliquota ";
                        sql += "FROM UF ";
                        sql += "INNER JOIN UF_AliquotaICMS AS UFA ON UF.ID_UF = UFA.ID_UF_Destino ";
                        sql += "WHERE ";

                        sql += "UFA.ID_UF_Origem = " + Municipio.ID_UF_Origem + " ";

                        if (Municipio.ID_UF_Destino > 0)
                            sql = "AND UFA.ID_UF_Destino = " + Municipio.ID_UF_Destino + " ";

                        sql += "ORDER BY Sigla";
                        break;

                    case 3:
                        sql = "SELECT ";
                        sql += "ID_UF AS ID_UF_Destino, Sigla, 0.0 AS Aliquota ";
                        sql += "FROM UF ";
                        sql += "ORDER BY Sigla";
                        break;
                }

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

        public DataTable Busca_Pais()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, ID_Pais, Descricao ";
                sql += "FROM Pais ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Municipio.ID > 0)
                    sql += "AND ID = " + Municipio.ID + " ";

                if (Municipio.ID_Pais > 0)
                    sql = "AND ID_Pais = " + Municipio.ID_Pais + " ";

                if (Municipio.Descricao != string.Empty &&
                    Municipio.Descricao != null)
                    sql += "AND Descricao LIKE '" + Municipio.Descricao + "%' ";

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

        public DataTable Busca_Municipio()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, ID_Pais, ID_Pais AS Pais, ID_UF, ID_UF AS UF, ID_Municipio, UPPER(Descricao) AS Descricao ";
                sql += "FROM Municipios ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Municipio.ID > 0)
                    sql += "AND ID = " + Municipio.ID + " ";

                if (Municipio.ID_Municipio > 0)
                    sql += "AND ID_Municipio = " + Municipio.ID_Municipio + " ";

                if (Municipio.ID_Pais > 0)
                    if (Municipio.ID_Pais == 1058)
                        sql += "AND ID_Pais = " + Municipio.ID_Pais + " ";
                    else
                        sql += "AND ID_Pais = 1 ";

                if (Municipio.ID_UF > 0)
                    sql += "AND ID_UF = " + Municipio.ID_UF + " ";

                if (Municipio.Descricao != string.Empty &&
                    Municipio.Descricao != null)
                    sql += "AND Descricao LIKE '" + Municipio.Descricao + "%' ";

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

        public void Exclui_Pais()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            msg = string.Empty;

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Pais ";
                sql += "FROM ";
                sql += "Municipios ";
                sql += "WHERE ";
                sql += "ID_Pais = " + Municipio.ID_Pais + " ";
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Município";

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_Exclui_Erro + msg);

                sql = "DELETE FROM ";
                sql += "Pais ";
                sql += "WHERE ";
                sql += "ID_Pais = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Municipio.ID_Pais);
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

        public void Exclui_Municipio()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Municipio ";
                sql += "FROM ";
                sql += "PessoaEndereco ";
                sql += "WHERE ";
                sql += "ID_Municipio = " + Municipio.ID + " ";
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Cadastro de Pessoa";

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_Exclui_Erro + msg);

                sql = "DELETE FROM ";
                sql += "Municipios ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Municipio.ID);
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
