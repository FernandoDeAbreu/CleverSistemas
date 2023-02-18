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
    public class DAL_Orcamento
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Orcamento Orcamento;
        DTO_Produto_Item Item;
        #endregion

        #region CONSTRUTOR
        public DAL_Orcamento(DTO_Orcamento _Orcamento)
        {
            this.Orcamento = _Orcamento;
        }

        public DAL_Orcamento(DTO_Produto_Item _Item)
        {
            Item = _Item;
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

                if (Orcamento.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Orcamento ";
                    sql += "(ID_Empresa, TipoPessoa, ID_Pessoa, Data, Informacao, ID_UsuarioComissao1) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @TipoPessoa, @ID_Pessoa, @Data, @Informacao, @ID_UsuarioComissao1) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Orcamento.ID_Empresa);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Orcamento.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Orcamento.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Data", Orcamento.Data);
                    cmd.Parameters.AddWithValue("@Informacao", Orcamento.Informacao);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao1", Orcamento.ID_UsuarioComissao1);

                    Orcamento.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Orcamento SET ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "Data = @Data, ";
                    sql += "Informacao = @Informacao, ";
                    sql += "ID_UsuarioComissao1 = @ID_UsuarioComissao1 ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Orcamento.ID);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Orcamento.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Orcamento.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Data", Orcamento.Data);
                    cmd.Parameters.AddWithValue("@Informacao", Orcamento.Informacao);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao1", Orcamento.ID_UsuarioComissao1);

                    conexao.Executa_Comando(cmd);
                }

                #region GRAVA ITEM
                if (Orcamento.Item != null && Orcamento.Item.Count > 0)
                    for (int i = 0; i <= Orcamento.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (Orcamento.Item[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Orcamento_Item ";
                            sql += "(ID_Orcamento, ID_Produto, Quantidade, ID_Tabela, ";
                            sql += "ValorProduto, ValorVenda, Informacao, TipoSaida, ID_Grade, ValorCusto) ";
                            sql += "VALUES ";
                            sql += "(@ID_Orcamento, @ID_Produto, @Quantidade, @ID_Tabela, ";
                            sql += "@ValorProduto, @ValorVenda, @Informacao, @TipoSaida, @ID_Grade, @ValorCusto) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Orcamento", Orcamento.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", Orcamento.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", Orcamento.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", Orcamento.Item[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorProduto", Orcamento.Item[i].ValorProduto);
                            cmd.Parameters.AddWithValue("@ValorVenda", Orcamento.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Informacao", Orcamento.Item[i].Informacao);
                            cmd.Parameters.AddWithValue("@TipoSaida", Orcamento.Item[i].TipoSaida);
                            cmd.Parameters.AddWithValue("@ID_Grade", Orcamento.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorCusto", Orcamento.Item[i].ValorCusto);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Orcamento_Item SET ";
                            sql += "ID_Produto = @ID_Produto, ";
                            sql += "Quantidade = @Quantidade, ";
                            sql += "ID_Tabela = @ID_Tabela, ";
                            sql += "ValorProduto = @ValorProduto, ";
                            sql += "ValorVenda = @ValorVenda, ";
                            sql += "Informacao = @Informacao, ";
                            sql += "TipoSaida = @TipoSaida, ";
                            sql += "ID_Grade = @ID_Grade, ";
                            sql += "ValorCusto = @ValorCusto ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Orcamento.Item[i].ID);
                            cmd.Parameters.AddWithValue("@ID_Orcamento", Orcamento.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", Orcamento.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", Orcamento.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", Orcamento.Item[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorProduto", Orcamento.Item[i].ValorProduto);
                            cmd.Parameters.AddWithValue("@ValorVenda", Orcamento.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Informacao", Orcamento.Item[i].Informacao);
                            cmd.Parameters.AddWithValue("@TipoSaida", Orcamento.Item[i].TipoSaida);
                            cmd.Parameters.AddWithValue("@ID_Grade", Orcamento.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorCusto", Orcamento.Item[i].ValorCusto);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion
                conexao.Commit_Conexao();

                return Orcamento.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();
                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Orcamento";
                int aux_ID = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Orcamento, RESEED, " + aux_ID + ")";
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

                sql = "SELECT ID_Orcamento AS ID, * ";
                sql += "FROM V_Orcamento ";
                sql += "WHERE ";
                sql += "ID_Empresa = " + Orcamento.ID_Empresa + " ";

                if (Orcamento.ID > 0)
                    sql += "AND ID_Orcamento = " + Orcamento.ID + " ";

                if (Orcamento.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + Orcamento.TipoPessoa + " ";

                if (Orcamento.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa  = " + Orcamento.ID_Pessoa + " ";

                if (Orcamento.Situacao > 0)
                    sql += "AND Situacao = " + Orcamento.Situacao + " ";

                if (Orcamento.ID_UsuarioComissao1 > 0)
                    sql += "AND ID_UsuarioComissao1 = " + Orcamento.ID_UsuarioComissao1 + " ";

                if (Orcamento.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, Data) BETWEEN CONVERT(DATE, '" + Orcamento.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Orcamento.Consulta_Emissao.Final + "') ";

                sql += "ORDER BY ID_Orcamento DESC ";

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

                sql = "SELECT ID_Orcamento AS ID, * ";
                sql += "FROM V_Orcamento ";
                sql += "WHERE ";
                sql += "NOT ID_Orcamento IS NULL ";
                sql += "AND ID_Orcamento = " + Orcamento.ID + " ";

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

        public DataTable Busca_Item()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM ";
                sql += "V_Orcamento_Item ";
                sql += "WHERE ID_Orcamento = " + Orcamento.ID + " ";
                sql += "ORDER BY DescricaoProduto ";

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
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Orcamento ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Orcamento.ID);

                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Orcamento_Item ";
                sql += "WHERE ";
                sql += "ID_Orcamento = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Orcamento.ID);

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

        public void Exclui_Item()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Orcamento_Item ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Orcamento.Item[0].ID);

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
