using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;
using System.Data.SqlClient;

namespace Sistema.DAL
{
    public class DAL_NF_TipoEmissao
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
        DTO_NF_TipoEmissao NF_TipoEmissao;
        #endregion

        #region CONSTRUTORES
        public DAL_NF_TipoEmissao(DTO_NF_TipoEmissao _NF_TipoEmissao)
        {
            this.NF_TipoEmissao = _NF_TipoEmissao;
        }
        #endregion

        public int Grava()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                if (NF_TipoEmissao.ID == 0)
                {
                    sql = "INSERT INTO NF_TipoEmissao ";
                    sql += "(ID_Empresa, Descricao, Serie) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Descricao, @Serie) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", NF_TipoEmissao.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Descricao", NF_TipoEmissao.Descricao);
                    cmd.Parameters.AddWithValue("@Serie", NF_TipoEmissao.Serie);

                    NF_TipoEmissao.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE NF_TipoEmissao SET ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Serie = @Serie ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", NF_TipoEmissao.ID);
                    cmd.Parameters.AddWithValue("@Descricao", NF_TipoEmissao.Descricao);
                    cmd.Parameters.AddWithValue("@Serie", NF_TipoEmissao.Serie);

                    conexao.Executa_Comando(cmd);
                }
                return NF_TipoEmissao.ID;
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
                sql += "ID, Descricao, Serie ";
                sql += "FROM ";
                sql += "NF_TipoEmissao ";
                sql += "WHERE ";
                sql += "ID_Empresa = " + NF_TipoEmissao.ID_Empresa + " ";

                if (NF_TipoEmissao.Serie > 0)
                    sql += "AND Serie = " + NF_TipoEmissao.Serie + " ";

                if (NF_TipoEmissao.ID > 0)
                    sql += "AND ID = " + NF_TipoEmissao.ID + " ";

                if (NF_TipoEmissao.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + NF_TipoEmissao.Descricao + "%' ";

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

            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "Serie ";
                sql += "FROM ";
                sql += "NotaFiscal ";
                sql += "WHERE ";
                sql += "Serie = " + NF_TipoEmissao.ID + " ";

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Nota Fiscal\n";

                if (msg != string.Empty)
                    throw new Exception(msg);             

                sql = "DELETE FROM ";
                sql += "NF_TipoEmissao ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", NF_TipoEmissao.ID);

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
