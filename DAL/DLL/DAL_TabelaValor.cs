using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_TabelaValor
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_TabelaValor TabelaValor;
        #endregion

        #region CONSTRUTORES
        public DAL_TabelaValor(DTO_TabelaValor _TabelaValor)
        {
            this.TabelaValor = _TabelaValor;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (TabelaValor.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "TabelaValor ";
                    sql += "(Descricao, Margem, CustoOperacional) ";
                    sql += "VALUES ";
                    sql += "(@Descricao, @Margem, @CustoOperacional) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Descricao", TabelaValor.Descricao);
                    cmd.Parameters.AddWithValue("@Margem", TabelaValor.Margem);
                    cmd.Parameters.AddWithValue("@CustoOperacional", TabelaValor.CustoOperacional);

                    TabelaValor.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "TabelaValor SET ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Margem = @Margem, ";
                    sql += "CustoOperacional = @CustoOperacional ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", TabelaValor.ID);
                    cmd.Parameters.AddWithValue("@Descricao", TabelaValor.Descricao);
                    cmd.Parameters.AddWithValue("@Margem", TabelaValor.Margem);
                    cmd.Parameters.AddWithValue("@CustoOperacional", TabelaValor.CustoOperacional);

                    conexao.Executa_Comando(cmd);
                }
                return TabelaValor.ID;
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
                sql += "ID, Descricao, Margem, CustoOperacional ";
                sql += "FROM TabelaValor ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (TabelaValor.ID > 0)
                    sql += "AND ID = " + TabelaValor.ID + " ";

                if (TabelaValor.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + TabelaValor.Descricao + "%' ";

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
            conexao = new Conexao();
            cmd = new SqlCommand();

            string msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Tabela ";
                sql += "FROM ";
                sql += "Venda_Item ";
                sql += "WHERE ";
                sql += "ID_Tabela = " + TabelaValor.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Venda\n";

                sql = "SELECT ";
                sql += "ID_Tabela ";
                sql += "FROM ";
                sql += "Orcamento_Item ";
                sql += "WHERE ";
                sql += "ID_Tabela = " + TabelaValor.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Orçamento\n";

                sql = "SELECT ";
                sql += "ID_Tabela ";
                sql += "FROM ";
                sql += "Ordem_Servico_Item ";
                sql += "WHERE ";
                sql += "ID_Tabela   = " + TabelaValor.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Ordem Serviço\n";

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_Exclui_Erro + msg);

                sql = "DELETE FROM ";
                sql += "TabelaValor ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", TabelaValor.ID);

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
