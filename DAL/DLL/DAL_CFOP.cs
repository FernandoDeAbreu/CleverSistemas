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
    public class DAL_CFOP
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_CFOP CFOP;
        #endregion

        #region CONSTRUTOR
        public DAL_CFOP(DTO_CFOP _CFOP)
        {
            CFOP = _CFOP;
        }

        public DAL_CFOP()
        {
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                cmd = new SqlCommand();
                if (CFOP.ID == 0)
                {
                    sql = "INSERT INTO CFOP ";
                    sql += "(CFOP, Descricao, Ajuda) ";
                    sql += "VALUES ";
                    sql += "(@CFOP, @Descricao, @Ajuda) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@CFOP", CFOP.CFOP);
                    cmd.Parameters.AddWithValue("@Descricao", CFOP.Descricao);
                    cmd.Parameters.AddWithValue("@Ajuda", CFOP.Ajuda);

                    CFOP.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE CFOP ";
                    sql += "SET ";
                    sql += "CFOP = @CFOP, ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Ajuda = @Ajuda ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", CFOP.ID);
                    cmd.Parameters.AddWithValue("@CFOP", CFOP.CFOP);
                    cmd.Parameters.AddWithValue("@Descricao", CFOP.Descricao);
                    cmd.Parameters.AddWithValue("@Ajuda", CFOP.Ajuda);
                    conexao.Executa_Comando(cmd);
                }
                return CFOP.ID;
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

                if (CFOP.Busca_CFOP == false)
                {
                    sql = "SELECT ";
                    sql += "ID, CFOP, Descricao, Ajuda ";
                    sql += "FROM CFOP ";
                    sql += "WHERE ";
                    sql += "NOT ID IS NULL ";

                    if (CFOP.CFOP != null)
                        sql += "AND CFOP LIKE '" + CFOP.CFOP + "%' ";

                    if (CFOP.Descricao != null)
                        sql += "AND Descricao LIKE '" + CFOP.Descricao + "%' ";

                    sql += "ORDER BY CFOP ";

                    return conexao.Consulta(sql);
                }
                else
                {
                    sql = "SELECT ";
                    sql += "CFOP, CONVERT(NVARCHAR(4), CFOP) + ' - ' + CONVERT(NVARCHAR(200), Descricao) AS Descricao ";
                    sql += "FROM CFOP ";
                    sql += "WHERE ";
                    sql += "NOT CFOP IS NULL ";
                    sql += "ORDER BY CFOP ";

                    return conexao.Consulta(sql);
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

        public void Exclui()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                cmd = new SqlCommand();

                sql = "SELECT CFOP ";
                sql += "FROM NotaFiscal_Item ";
                sql += "WHERE ";
                sql += "CFOP = '" + CFOP.CFOP + "' ";
                if (conexao.Consulta(sql).Rows.Count > 0)
                    throw new Exception(util_msg.msg_DAL_Erro_Exclui + "Nota Fiscal");

                sql = "DELETE FROM CFOP ";
                sql += "WHERE ";
                sql += "ID = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", CFOP.ID);
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
