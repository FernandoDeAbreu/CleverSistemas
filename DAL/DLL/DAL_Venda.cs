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
    public class DAL_Venda
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        string sql;
        SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_Venda Venda;
        DTO_Produto_Item Item;
        #endregion

        #region CONSTRUTORES
        public DAL_Venda(DTO_Venda _Venda)
        {
            this.Venda = _Venda;
        }

        public DAL_Venda(DTO_Produto_Item _Item)
        {
            Item = _Item;
        }
        #endregion

        public int Grava()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                if (Venda.ID == 0)
                {
                    sql = "INSERT INTO Venda ";
                    sql += "(ID_Empresa, TipoPessoa, ID_Pessoa, Data, Entrega, Informacao, ID_UsuarioComissao1, ";
                    sql += "ID_UsuarioComissao2, DataFatura, Comprador, Faturado, NFe, ";
                    sql += "ID_Pagamento, ID_Parcelamento, Cancelado, Situacao_Entrega, Situacao_Conferencia, CPF_CNPJ) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @TipoPessoa, @ID_Pessoa, @Data, @Entrega, @Informacao, @ID_UsuarioComissao1, ";
                    sql += "@ID_UsuarioComissao2, @DataFatura, @Comprador, @Faturado, @NFe, ";
                    sql += "@ID_Pagamento, @ID_Parcelamento, @Cancelado, @Situacao_Entrega, @Situacao_Conferencia, @CPF_CNPJ) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Venda.ID_Empresa);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Venda.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Venda.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Data", Venda.Data);
                    cmd.Parameters.AddWithValue("@Entrega", Venda.Entrega);
                    cmd.Parameters.AddWithValue("@Informacao", Venda.Informacao);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao1", Venda.ID_UsuarioComissao1);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao2", Venda.ID_UsuarioComissao2);
                    cmd.Parameters.AddWithValue("@DataFatura", Venda.DataFatura);
                    cmd.Parameters.AddWithValue("@Comprador", Venda.Comprador);
                    cmd.Parameters.AddWithValue("@Faturado", Venda.Faturado);
                    cmd.Parameters.AddWithValue("@NFe", Venda.NFe);
                    cmd.Parameters.AddWithValue("@ID_Pagamento", Venda.ID_Pagamento);
                    cmd.Parameters.AddWithValue("@ID_Parcelamento", Venda.ID_Parcelamento);
                    cmd.Parameters.AddWithValue("@Cancelado", Venda.Cancelado);
                    cmd.Parameters.AddWithValue("@Situacao_Entrega", Venda.Situacao_Entrega);
                    cmd.Parameters.AddWithValue("@Situacao_Conferencia", Venda.Situacao_Conferencia);
                    cmd.Parameters.AddWithValue("@CPF_CNPJ", Venda.CPF_CNPJ);
                    Venda.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Venda SET ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "Data = @Data, ";
                    sql += "Entrega = @Entrega, ";
                    sql += "Informacao = @Informacao, ";
                    sql += "ID_UsuarioComissao1 = @ID_UsuarioComissao1, ";
                    sql += "ID_UsuarioComissao2 = @ID_UsuarioComissao2, ";
                    sql += "DataFatura = @DataFatura, ";
                    sql += "Comprador = @Comprador, ";
                    sql += "Faturado = @Faturado, ";
                    sql += "NFe = @NFe, ";
                    sql += "ID_Pagamento = @ID_Pagamento, ";
                    sql += "ID_Parcelamento = @ID_Parcelamento, ";
                    sql += "Situacao_Entrega = @Situacao_Entrega, ";
                    sql += "Situacao_Conferencia = @Situacao_Conferencia, ";
                    sql += "CPF_CNPJ = @CPF_CNPJ ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Venda.ID);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Venda.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Venda.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Data", Venda.Data);
                    cmd.Parameters.AddWithValue("@Entrega", Venda.Entrega);
                    cmd.Parameters.AddWithValue("@Informacao", Venda.Informacao);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao1", Venda.ID_UsuarioComissao1);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao2", Venda.ID_UsuarioComissao2);
                    cmd.Parameters.AddWithValue("@DataFatura", Venda.DataFatura);
                    cmd.Parameters.AddWithValue("@Comprador", Venda.Comprador);
                    cmd.Parameters.AddWithValue("@Faturado", Venda.Faturado);
                    cmd.Parameters.AddWithValue("@NFe", Venda.NFe);
                    cmd.Parameters.AddWithValue("@ID_Pagamento", Venda.ID_Pagamento);
                    cmd.Parameters.AddWithValue("@ID_Parcelamento", Venda.ID_Parcelamento);
                    cmd.Parameters.AddWithValue("@Situacao_Entrega", Venda.Situacao_Entrega);
                    cmd.Parameters.AddWithValue("@Situacao_Conferencia", Venda.Situacao_Conferencia);
                    cmd.Parameters.AddWithValue("@CPF_CNPJ", Venda.CPF_CNPJ);

                    conexao.Executa_Comando(cmd);
                }

                #region GRAVA ITEM
                if (Venda.Item != null && Venda.Item.Count > 0)
                    for (int i = 0; i <= Venda.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (Venda.Item[i].ID == 0)
                        {
                            sql = "INSERT INTO Venda_Item ";
                            sql += "(ID_Venda, ID_Produto, Quantidade, ID_Tabela, ";
                            sql += "ValorProduto, ValorVenda, Informacao, TipoSaida, ID_Grade, ValorCusto, Quantidade_Conferido) ";
                            sql += "VALUES ";
                            sql += "(@ID_Venda, @ID_Produto, @Quantidade, @ID_Tabela, ";
                            sql += "@ValorProduto, @ValorVenda, @Informacao, @TipoSaida, @ID_Grade, @ValorCusto, @Quantidade_Conferido) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Venda", Venda.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", Venda.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", Venda.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", Venda.Item[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorProduto", Venda.Item[i].ValorProduto);
                            cmd.Parameters.AddWithValue("@ValorVenda", Venda.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Informacao", Venda.Item[i].Informacao);
                            cmd.Parameters.AddWithValue("@TipoSaida", Venda.Item[i].TipoSaida);
                            cmd.Parameters.AddWithValue("@ID_Grade", Venda.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorCusto", Venda.Item[i].ValorCusto);
                            cmd.Parameters.AddWithValue("@Quantidade_Conferido", Venda.Item[i].Quantidade_Conferido);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Venda_Item SET ";
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
                            cmd.Parameters.AddWithValue("@ID", Venda.Item[i].ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", Venda.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", Venda.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", Venda.Item[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorProduto", Venda.Item[i].ValorProduto);
                            cmd.Parameters.AddWithValue("@ValorVenda", Venda.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Informacao", Venda.Item[i].Informacao);
                            cmd.Parameters.AddWithValue("@TipoSaida", Venda.Item[i].TipoSaida);
                            cmd.Parameters.AddWithValue("@ID_Grade", Venda.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorCusto", Venda.Item[i].ValorCusto);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                conexao.Commit_Conexao();

                return Venda.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();
                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Venda";
                int aux_ID = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Venda, RESEED, " + aux_ID + ")";
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

        public void Altera_NFe()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Venda SET ";
                sql += "ID_NFe = @ID_NFe, ";
                sql += "NFe = @NFe  ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);
                cmd.Parameters.AddWithValue("@ID_NFe", Venda.ID_NFe);
                cmd.Parameters.AddWithValue("@NFe", Venda.NFe);

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

        public void Altera_CFe()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Venda SET ";
                sql += "NFe = @NFe  ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);
                cmd.Parameters.AddWithValue("@NFe", Venda.NFe);

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

        public void Altera_Fatura()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Venda SET ";
                sql += "DataFatura = @DataFatura, ";
                sql += "Faturado = @Faturado ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);
                cmd.Parameters.AddWithValue("@DataFatura", Venda.DataFatura);
                cmd.Parameters.AddWithValue("@Faturado", Venda.Faturado);

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

        public void Altera_Qt_Item()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                if (Venda.Item != null &&
                    Venda.Item.Count > 0)
                    for (int i = 0; i <= Venda.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        sql = "UPDATE ";
                        sql += "Venda_Item SET ";
                        sql += "Quantidade = (Quantidade - @Quantidade), ";
                        sql += "Informacao = Informacao + @Informacao ";
                        sql += "WHERE ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", Venda.Item[i].ID);
                        cmd.Parameters.AddWithValue("@Quantidade", Venda.Item[i].Quantidade);
                        cmd.Parameters.AddWithValue("@Informacao", Venda.Item[i].Informacao);

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

        public void Altera_Qt_Entregue()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                cmd = new SqlCommand();
                sql = "UPDATE ";
                sql += "Venda_Item SET ";
                sql += "Quantidade_Entregue = @Quantidade ";
                sql += "WHERE ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Item.ID);
                cmd.Parameters.AddWithValue("@Quantidade", Item.Quantidade_Entregue);

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

        public void Altera_Qt_Conferido()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                cmd = new SqlCommand();
                sql = "UPDATE ";
                sql += "Venda_Item SET ";
                sql += "Quantidade_Conferido = @Quantidade ";
                sql += "WHERE ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Item.ID);
                cmd.Parameters.AddWithValue("@Quantidade", Item.Quantidade_Conferido);

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

        public void Altera_Status_Conferencia()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "UPDATE ";
                sql += "Venda SET ";
                sql += "Situacao_Conferencia = @Situacao_Conferencia, ";
                sql += "ID_Usuario_Conferencia = @ID_Usuario_Conferencia ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);
                cmd.Parameters.AddWithValue("@Situacao_Conferencia", Venda.Situacao_Conferencia);
                cmd.Parameters.AddWithValue("@ID_Usuario_Conferencia", Venda.ID_Usuario_Conferencia);

                conexao.Executa_Comando(cmd);

                for (int i = 0; i <= Venda.Item.Count - 1; i++)
                {
                    cmd = new SqlCommand();

                    sql = "UPDATE ";
                    sql += "Venda_Item SET ";
                    sql += "Quantidade_Conferido = @Quantidade_Conferido ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Venda.Item[i].ID);
                    cmd.Parameters.AddWithValue("@Quantidade_Conferido", Venda.Item[i].Quantidade_Conferido);

                    conexao.Executa_Comando(cmd);
                }

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

        public void Cancela_Venda()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Venda SET ";
                sql += "Cancelado = '" + Venda.Cancelado + "', ";
                sql += "Informacao = '" + Venda.Informacao + "' ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);
                cmd.Parameters.AddWithValue("@Cancelado", Venda.Cancelado);
                cmd.Parameters.AddWithValue("@Informacao", Venda.Informacao);

                conexao.Executa_Comando(cmd);

                #region RETORNA ESTOQUE
                if (Venda.Item != null && Venda.Item.Count > 0)
                    for (int i = 0; i <= Venda.Item.Count - 1; i++)
                        if (Venda.Item[i].ID != 0)
                        {
                            sql = "SELECT ";
                            sql += "VI.Quantidade_Entregue + PE.EstoqueAtual AS Total ";
                            sql += "FROM ";
                            sql += "Venda_Item AS VI ";
                            sql += "INNER JOIN Produto_Estoque AS PE ON VI.ID_Produto = PE.ID_Produto ";
                            sql += "WHERE VI.ID = " + Venda.Item[i].ID + " ";
                            sql += "AND PE.ID_Grade = " + Venda.Item[i].ID_Grade + " ";

                            DataTable _DT = conexao.Consulta(sql);

                            if (_DT.Rows[0]["Total"].ToString().Trim() != string.Empty)
                            {
                                cmd = new SqlCommand();
                                sql = "UPDATE ";
                                sql += "Produto_Estoque SET ";
                                sql += "EstoqueAtual = @EstoqueAtual ";
                                sql += "WHERE ";
                                sql += "ID_Produto = @ID_Produto ";
                                sql += "AND ID_Grade = @ID_Grade ";
                                cmd.CommandText = sql;

                                cmd.Parameters.AddWithValue("@ID_Grade", Venda.Item[i].ID_Grade);
                                cmd.Parameters.AddWithValue("@ID_Produto", Venda.Item[i].ID_Produto);
                                cmd.Parameters.AddWithValue("@EstoqueAtual", _DT.Rows[0]["Total"]);
                                conexao.Executa_Comando(cmd);
                            }
                        }
                #endregion

                cmd = new SqlCommand();
                sql = "UPDATE Venda_Item SET ";
                sql += "Quantidade_Entregue = Quantidade ";
                sql += "WHERE ";
                sql += "ID_Venda = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);

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

        public DataTable Busca()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID_Venda AS ID, * ";
                sql += "FROM V_Venda ";
                sql += "WHERE ";
                sql += "NOT ID_Venda IS NULL ";

                if (Venda.ID_Empresa > 0)
                    sql += "AND ID_Empresa = " + Venda.ID_Empresa + " ";

                if (Venda.ID > 0)
                    sql += "AND ID_Venda = " + Venda.ID + " ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa  = " + Venda.ID_Pessoa + " ";

                if (Venda.Pesquisa_Faturado == true)
                {
                    sql += "AND Faturado = '" + Venda.Faturado + "' ";
                    sql += "AND Cancelado = '" + Venda.Cancelado + "' ";
                }

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID_UsuarioComissao1 > 0)
                    sql += "AND ID_UsuarioComissao1 = " + Venda.ID_UsuarioComissao1 + " ";

                if (Venda.ID_UsuarioComissao2 > 0)
                    sql += "AND ID_UsuarioComissao2 = " + Venda.ID_UsuarioComissao2 + " ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, Data) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Emissao.Final + "') ";

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "AND CONVERT(DATE, DataFatura) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Fatura.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Fatura.Final + "') ";

                sql += "ORDER BY ID_Venda DESC ";

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

        public DataTable Busca_TotalVenda()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PV.ID_Venda, PV.Data, PV.Descricao, PV.Faturado, PV.NFe, ";
                sql += "PG.Descricao AS DescricaoPagamento, SUM(PG.Credito) AS ValorPagto, SUM(PG.ValorPago) AS ValorPago, ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2, ";
                sql += "PV.ValorTotal, PV.CustoTotal ";
                sql += "FROM V_Venda AS PV ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                sql += "LEFT JOIN V_Venda_ResumoPagto AS PG ON PV.ID_Venda = PG.ID_Venda ";
                sql += "LEFT JOIN Usuario AS PU1 ON PV.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON PV.ID_UsuarioComissao2 = PU2.ID ";
                sql += "WHERE ";
                sql += "NOT PV.ID_Venda IS NULL ";
                sql += "AND PV.ID_Empresa = " + Venda.ID_Empresa + " ";

                if (Venda.ID > 0)
                    sql += "AND PV.ID_Venda = " + Venda.ID + " ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND PV.TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND PV.ID_Pessoa  = " + Venda.ID_Pessoa + " ";
                if (Venda.Pesquisa_Faturado == true)
                {
                    sql += "AND PV.Faturado = '" + Venda.Faturado + "' ";
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";
                }

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND PV.NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID_UsuarioComissao1 > 0)
                    sql += "AND PV.ID_UsuarioComissao1 = " + Venda.ID_UsuarioComissao1 + " ";

                if (Venda.ID_UsuarioComissao2 > 0)
                    sql += "AND PV.ID_UsuarioComissao2 = " + Venda.ID_UsuarioComissao2 + " ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.Data) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Emissao.Final + "') ";

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.DataFatura) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Fatura.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Fatura.Final + "') ";

                if (Venda.Consulta_Entrega.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.Entrega) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Entrega.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Entrega.Final + "') ";

                sql += "GROUP BY PV.ID_Venda, PV.Data, P.Nome_Razao, P.NomeFantasia, PU1.Descricao, PU2.Descricao,  ";
                sql += "PG.Credito, PV.Descricao, PG.Descricao, PV.Faturado, PV.NFe, PV.ValorTotal, PV.CustoTotal, ";
                sql += "PV.Descricao, PV.Faturado, PV.ValorTotal, PV.CustoTotal ";
                sql += "ORDER BY PV.Data ";

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

        public DataTable Busca_TotalVendaResumo()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PV.ID_Venda, PV.Data, PV.Descricao, PV.Faturado, PV.Cancelado, PV.NFe, ";
                sql += "PG.Descricao AS DescricaoPagamento,  ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2, ";
                sql += "PV.ValorTotal, PV.CustoTotal ";
                sql += "FROM V_Venda AS PV ";
                sql += "INNER JOIN V_Venda_Item AS PI ON PV.ID_Venda = PI.ID_Venda ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                sql += "LEFT JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
                sql += "LEFT JOIN Usuario AS PU1 ON PV.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON PV.ID_UsuarioComissao2 = PU2.ID ";
                sql += "WHERE ";
                sql += "NOT PV.ID_Venda IS NULL ";
                sql += "AND PV.ID_Empresa = " + Venda.ID_Empresa + " ";

                if (Venda.ID > 0)
                    sql += "AND PV.ID_Venda = " + Venda.ID + " ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND PV.TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND PV.ID_Pessoa  = " + Venda.ID_Pessoa + " ";

                if (Venda.Pesquisa_Faturado == true)
                {
                    sql += "AND PV.Faturado = '" + Venda.Faturado + "' ";
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";
                }

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND PV.NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID_UsuarioComissao1 > 0)
                    sql += "AND PV.ID_UsuarioComissao1 = " + Venda.ID_UsuarioComissao1 + " ";

                if (Venda.ID_UsuarioComissao2 > 0)
                    sql += "AND PV.ID_UsuarioComissao2 = " + Venda.ID_UsuarioComissao2 + " ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.Data) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Emissao.Final + "') ";

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.DataFatura) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Fatura.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Fatura.Final + "') ";

                sql += "GROUP BY PV.ID_Venda, PV.Data, P.Nome_Razao, P.NomeFantasia, PU1.Descricao, PU2.Descricao, ";
                sql += "PV.Descricao, PG.Descricao, PV.Faturado, PV.Cancelado, PV.NFe, PV.ValorTotal, PV.CustoTotal ";
                sql += "ORDER BY PV.Data ";

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

        public DataTable Busca_ResumoProduto()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PV.ID_Venda, PV.Data, PV.Descricao, PV.Complemento, PV.Faturado, ";
                sql += "P.CNPJ_CPF, ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2, ";
                sql += "CASE GP.Descricao ";
                sql += "WHEN 'ÚNICO' THEN PD.Descricao ";
                sql += "ELSE PD.Descricao + ' - ' + GP.Descricao ";
                sql += "END AS DescricaoProduto, ";
                sql += "SUM(PI.Quantidade) QuantidadeTotal ";
                sql += "FROM V_Venda AS PV ";
                sql += "INNER JOIN V_Venda_Item AS PI ON PV.ID_Venda = PI.ID_Venda ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                sql += "LEFT JOIN Usuario AS PU1 ON PV.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON PV.ID_UsuarioComissao2 = PU2.ID ";
                sql += "LEFT JOIN Produto AS PD ON PD.ID = PI.ID_Produto ";
                sql += "INNER JOIN Grade AS GP ON GP.ID = PI.ID_Grade ";
                sql += "WHERE ";
                sql += "NOT PV.ID_Venda IS NULL ";
                sql += "AND PV.ID_Empresa = " + Venda.ID_Empresa + " ";

                if (Venda.ID > 0)
                    sql += "AND PV.ID_Venda = " + Venda.ID + " ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND PV.TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND PV.ID_Pessoa  = " + Venda.ID_Pessoa + " ";

                if (Venda.Pesquisa_Faturado == true)
                {
                    sql += "AND PV.Faturado = '" + Venda.Faturado + "' ";
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";
                }

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND PV.NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID_UsuarioComissao1 > 0)
                    sql += "AND PV.ID_UsuarioComissao1 = " + Venda.ID_UsuarioComissao1 + " ";

                if (Venda.ID_UsuarioComissao2 > 0)
                    sql += "AND PV.ID_UsuarioComissao2 = " + Venda.ID_UsuarioComissao2 + " ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.Data) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Emissao.Final + "') ";

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.DataFatura) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Fatura.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Fatura.Final + "') ";

                sql += "GROUP BY PV.ID_Venda, PV.Data, PV.Descricao, PV.Complemento, PV.Faturado, P.CNPJ_CPF, ";
                sql += "PU1.Descricao, PU2.Descricao, PD.Descricao, GP.Descricao ";
                sql += "ORDER BY PD.Descricao ";

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

        public DataTable Busca_ResumoVenda()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PV.ID_Venda, PV.Data, PV.Informacao, PV.Comprador, PV.Descricao, PV.Complemento, PV.Faturado, PV.Cancelado, PV.NFe,";
                sql += "PG.Descricao AS DescricaoPagamento, ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2, ";
                sql += "CASE GP.Descricao ";
                sql += "WHEN 'ÚNICO' THEN PD.Descricao ";
                sql += "ELSE PD.Descricao + ' - ' + GP.Descricao ";
                sql += "END AS DescricaoProduto, PD.Referencia, PD.ABC, ";
                sql += "PI.ID_Produto, PI.Quantidade, PI.ValorVenda, PI.Acrescimo, PI.Desconto, PI.ValorTotal, PI.ValorCusto, ";
                sql += "PI.ValorProduto, PI.DescricaoSaida AS DescricaoTipoSaida, PI.Informacao AS InformacaoProduto ";
                sql += "FROM V_Venda AS PV ";
                sql += "INNER JOIN V_Venda_Item AS PI ON PV.ID_Venda = PI.ID_Venda ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = PV.TipoPessoa AND P.ID_Pessoa = PV.ID_Pessoa ";
                sql += "LEFT JOIN Pagamento AS PG ON PV.ID_Pagamento = PG.ID ";
                sql += "LEFT JOIN Usuario AS PU1 ON PV.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON PV.ID_UsuarioComissao2 = PU2.ID ";
                sql += "LEFT JOIN Produto_Servico AS PD ON PD.ID = PI.ID_Produto ";
                sql += "INNER JOIN Grade AS GP ON GP.ID = PI.ID_Grade ";
                sql += "WHERE ";
                sql += "NOT PV.ID_Venda IS NULL ";
                sql += "AND PV.ID_Empresa = " + Venda.ID_Empresa + " ";

                if (Venda.ID > 0)
                    sql += "AND PV.ID_Venda = " + Venda.ID + " ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND PV.TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND PV.ID_Pessoa  = " + Venda.ID_Pessoa + " ";

                if (Venda.Pesquisa_Faturado == true)
                {
                    sql += "AND PV.Faturado = '" + Venda.Faturado + "' ";
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";
                }

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND PV.NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID_UsuarioComissao1 > 0)
                    sql += "AND PV.ID_UsuarioComissao1 = " + Venda.ID_UsuarioComissao1 + " ";

                if (Venda.ID_UsuarioComissao2 > 0)
                    sql += "AND PV.ID_UsuarioComissao2 = " + Venda.ID_UsuarioComissao2 + " ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.Data) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Emissao.Final + "') ";

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.DataFatura) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Fatura.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Fatura.Final + "') ";

                if (Venda.Consulta_Entrega.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.Entrega) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Entrega.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Entrega.Final + "') ";

                sql += "ORDER BY PV.Data, PV.ID_Venda ";

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

        public DataTable Busca_Pessoa_Inativo()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM V_Venda_PessoaInativo ";
                sql += "WHERE NOT ID_Venda IS NULL ";

                sql += "AND TempoCompra > " + Venda.Dias_Inativo + " ";

                if (Venda.PesquisaInativo == true)
                    sql += "AND Situacao = '" + Venda.SituacaoInativo + "' ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa  = " + Venda.ID_Pessoa + " ";

                if (Venda.Pesquisa_Faturado == true)
                {
                    sql += "AND Faturado = '" + Venda.Faturado + "' ";
                    sql += "AND Cancelado = '" + Venda.Cancelado + "' ";
                }

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID_UsuarioComissao1 > 0)
                    sql += "AND ID_UsuarioComissao1 = " + Venda.ID_UsuarioComissao1 + " ";

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

        public DataTable Busca_Fatura()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT VP.ID_Venda AS ID, VP.*, ";
                sql += "U.Descricao AS UsuarioComissao ";
                sql += "FROM V_Venda AS VP ";
                sql += "LEFT JOIN Usuario AS U ON VP.ID_UsuarioComissao1 = U.ID ";
                sql += "WHERE ";
                sql += "NOT ID_Venda IS NULL ";

                if (Venda.Pesquisa_Faturado == true)
                    sql += "AND Faturado = '" + Venda.Faturado + "' ";

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID > 0)
                    sql += "AND ID_Venda = " + Venda.ID + " ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND VP.TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND VP.ID_Pessoa  = " + Venda.ID_Pessoa + " ";

                if (Venda.Situacao_Conferencia > 0)
                    sql += "AND VP.Situacao_Conferencia  = " + Venda.Situacao_Conferencia + " ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, Data) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Emissao.Final + "') ";

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "AND CONVERT(DATE, DataFatura) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Fatura.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Fatura.Final + "') ";

                sql += "ORDER BY ID_Venda DESC ";

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

                sql = "SELECT ID_Venda AS ID, * ";
                sql += "FROM V_Venda ";
                sql += "WHERE ";
                sql += "NOT ID_Venda IS NULL ";

                sql += "AND ID_Venda = " + Venda.ID + " ";

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

                sql = "SELECT *, DescricaoProduto + ' ' + Informacao AS DescricaoProdutoInfo ";
                sql += "FROM ";
                sql += "V_Venda_Item ";
                sql += "WHERE NOT ID_Venda IS NULL ";

                if (Venda.ID > 0)
                    sql += "AND ID_Venda = " + Venda.ID + " ";

                if (Venda.lst_ID_Venda != null &&
                    Venda.lst_ID_Venda != string.Empty)
                    sql += "AND ID_Venda IN (" + Venda.lst_ID_Venda + ") ";

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

        public DataTable Busca_Financeiro()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ISNULL(C.Vencimento, R.Vencimento) as Vencimento, ISNULL(C.Valor, R.Valor) AS Valor, PrevisaoPagto ";
                sql += "FROM V_CReceber R ";
                sql += "LEFT JOIN Cartao_Controle AS CC on CC.ID_CReceber = R.ID ";
                sql += "LEFT JOIN Cartao AS C on C.ID = CC.ID_Cartao ";
                sql += "WHERE R.ID_Venda = " + Venda.ID + " ";
                sql += "ORDER BY ISNULL(C.Vencimento, R.Vencimento) ";

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

        public DataTable Busca_PagamentoSAT()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT SUM(CR.Valor) AS Valor, ";
                sql += "P.Tipo ";
                sql += "FROM ";
                sql += "V_CReceber AS CR ";
                sql += "INNER JOIN Pagamento AS P ON CR.ID_PrevisaoPagto = P.ID ";
                sql += "WHERE ID_Venda IS NOT NULL ";
                sql += "AND ID_Venda = " + Venda.ID + " ";
                sql += "GROUP BY P.Tipo ";

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

        public DataTable Busca_ItemFiscal()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PV.ID AS IDItem, PV.ID_Venda, PV.ID_Produto, PV.Quantidade, PV.ID_Tabela, PV.ValorMinimo, PV.Valor, PV.Acrescimo, PV.Desconto, PV.ValorFinal, (PV.ValorFinal * PV.Quantidade) AS ValorTotal, PV.Informacao, PV.TipoVendaProduto, PV.ID_Grade, ";

                sql += "CASE G.Descricao ";
                sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                sql += "END AS DescricaoProduto, ";

                sql += "PI.ID_Imposto, ";
                sql += "P.EX_TIPI, P.ClasseEnquadramento, P.CNPJProdutor, P.CodigoEnquadramento, P.CustoFinal AS ValorCusto, P.PesoB, P.PesoL, ";
                sql += "GP.Descricao AS DescricaoVendaProduto, ";

                sql += "I.CFOP, I.CST, I.Origem, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, ";
                sql += "I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                sql += "FROM ";
                sql += "Venda_Item AS PV ";
                sql += "INNER JOIN Produto_Imposto AS PI ON PV.ID_Produto = PI.ID_Produto ";
                sql += "INNER JOIN ImpostoControle AS IC ON PI.ID_Imposto = IC.ID_Imposto AND IC.ID_UF = " + Venda.ID_UF + " ";
                sql += "INNER JOIN Imposto AS I ON PI.ID_Imposto = I.ID ";
                sql += "INNER JOIN Grade AS G ON G.ID = PV.ID_Grade ";
                sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                sql += "LEFT JOIN Grupo AS GP ON PV.TipoVendaProduto = GP.ID ";
                sql += "WHERE ";
                sql += "PV.ID_Venda = " + Venda.ID + " ";
                sql += "AND I.ID_Empresa = " + Venda.ID_Empresa + " ";
                sql += "ORDER BY P.Descricao ";

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

        public DataTable Busca_Item_NF()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM V_Venda_Item_Imposto ";
                sql += "WHERE ";
                sql += "NOT ID_Produto IS NULL ";
                sql += "AND ID_Venda = " + Venda.ID + " ";
                sql += "AND ID_Empresa = " + Venda.ID_Empresa + " ";
                sql += "AND Tipo_NF = " + Venda.Tipo_NF + " ";
                sql += "AND ValorTotal > 0 ";
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

        public DataTable Busca_Item_NF_CF()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM V_Venda_Item_Imposto_CF ";
                sql += "WHERE ";
                sql += "NOT ID_Produto IS NULL ";
                sql += "AND ID_Venda = " + Venda.ID + " ";
                sql += "AND ID_Empresa = " + Venda.ID_Empresa + " ";
                sql += "AND Tipo_NF = " + Venda.Tipo_NF + " ";
                sql += "AND ValorTotal > 0 ";
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

        public DataTable Busca_ItemTransporte()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PV.ID_Produto AS ID, SUM(PV.Quantidade) AS Quantidade, ";
                sql += "P.Descricao, ";
                sql += "PE.EstoqueAtual ";
                sql += "FROM ";
                sql += "Venda_Item AS PV ";
                sql += "LEFT JOIN Produto AS P ON P.ID = PV.ID_Produto ";
                sql += "LEFT JOIN Produto_Estoque AS PE ON PE.ID_Produto = PV.ID_Produto ";
                sql += "WHERE ";
                sql += "PV.ID_Venda IN (" + Venda.lst_ID_Venda + ") ";
                sql += "GROUP BY PV.ID_Produto, P.Descricao, PE.EstoqueAtual ";
                sql += "ORDER BY P.Descricao ";

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

        public DataTable Busca_Comissao()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT PV.DataFatura, PV.Data, PV.ID_Venda, ";
                sql += "SUM(PDI.Quantidade * PDI.ValorProduto) AS TotalVenda, SUM(PDI.Quantidade * PDI.Desconto) AS TotalDesconto, SUM(PDI.Quantidade * PDI.Acrescimo) AS TotalAcrescimo, SUM(PDI.Quantidade * PDI.ValorVenda) AS TotalFinal, ";
                sql += "SUM(CASE PC.ID_TipoComissao ";
                sql += "WHEN 1 THEN ";
                sql += "PC.Comissao ";
                sql += "WHEN 2 THEN ";
                sql += "((PC.Comissao / 100) * (PDI.Quantidade * PDI.ValorVenda)) ";
                sql += "END) AS Comissao, ";
                sql += "P.Nome_Razao ";
                sql += "FROM V_Venda AS PV ";
                sql += "LEFT JOIN V_Venda_Item AS PDI ON PDI.ID_Venda = PV.ID_Venda ";
                sql += "INNER JOIN Produto_Comissao AS PC ON PDI.ID_Produto = PC.ID_Produto ";
                sql += "LEFT JOIN Pessoa AS P ON PV.TipoPessoa = P.TipoPessoa AND PV.ID_Pessoa = P.ID_Pessoa ";
                sql += "WHERE NOT PDI.ID_Venda IS NULL ";
                sql += "AND PV.ID_Empresa = " + Venda.ID_Empresa + " ";

                if (Venda.Pesquisa_Faturado == true)
                {
                    sql += "AND PV.Faturado = '" + Venda.Faturado + "' ";
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";
                }

                if (Venda.Pesquisa_EmitidoNFe == true)
                    sql += "AND PV.NFe = '" + Venda.NFe + "' ";

                if (Venda.Pesquisa_Cancelado == true)
                    sql += "AND PV.Cancelado = '" + Venda.Cancelado + "' ";

                if (Venda.ID_UsuarioComissao1 > 0)
                {
                    sql += "AND PV.ID_UsuarioComissao1 = " + Venda.ID_UsuarioComissao1 + " ";
                    sql += "AND PC.ID_Usuario = " + Venda.ID_UsuarioComissao1 + " ";
                }
                if (Venda.ID_UsuarioComissao2 > 0)
                {
                    sql += "AND PV.ID_UsuarioComissao2 = " + Venda.ID_UsuarioComissao2 + " ";
                    sql += "AND PC.ID_Usuario = " + Venda.ID_UsuarioComissao2 + " ";
                }

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.DataFatura) BETWEEN CONVERT(DATE,'" + Venda.Consulta_Fatura.Inicial + "') AND CONVERT(DATE,'" + Venda.Consulta_Fatura.Final + "') ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PV.Data) BETWEEN CONVERT(DATE, '" + Venda.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Venda.Consulta_Emissao.Final + "') ";

                if (Venda.Consulta_Fatura.Filtra == true)
                    sql += "GROUP BY P.Nome_Razao, PV.ID_Venda, PV.Data, PV.DataFatura ";

                if (Venda.Consulta_Emissao.Filtra == true)
                    sql += "GROUP BY P.Nome_Razao, PV.ID_Venda, PV.Data, PV.DataFatura ";

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

        public double Busca_UltimoValor()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PI.ValorVenda ";
                sql += "FROM Venda_Item AS PI ";
                sql += "WHERE PI.ID = (";
                sql += "SELECT MAX(PI.ID) AS ID ";
                sql += "FROM Venda_Item AS PI ";
                sql += "INNER JOIN Venda AS P ON PI.ID_Venda = P.ID ";
                sql += "WHERE NOT PI.ID IS NULL ";
                sql += "AND P.ID_Empresa = " + Venda.ID_Empresa + " ";
                sql += "AND PI.ID_Produto = " + Venda.ID_Produto + " ";

                if (Venda.TipoPessoa > 0)
                    sql += "AND P.TipoPessoa = " + Venda.TipoPessoa + " ";

                if (Venda.ID_Pessoa > 0)
                    sql += "AND P.ID_Pessoa = " + Venda.ID_Pessoa + ") ";

                DataTable _DT = conexao.Consulta(sql);

                if (_DT.Rows.Count > 0 && Convert.ToDouble(_DT.Rows[0]["ValorVenda"]) > 0)
                    return Convert.ToDouble(_DT.Rows[0]["ValorVenda"]);
                else
                    return 0;
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
                sql += "Venda ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);

                conexao.Executa_Comando(cmd);

                #region RETORNA ESTOQUE
                if (Venda.Item != null && Venda.Item.Count > 0)
                    for (int i = 0; i <= Venda.Item.Count - 1; i++)
                        if (Venda.Item[i].ID != 0)
                        {
                            sql = "SELECT ";
                            sql += "VI.Quantidade_Entregue + PE.EstoqueAtual AS Total ";
                            sql += "FROM ";
                            sql += "Venda_Item AS VI ";
                            sql += "INNER JOIN Produto_Estoque AS PE ON VI.ID_Produto = PE.ID_Produto ";
                            sql += "WHERE VI.ID = " + Venda.Item[i].ID + " ";
                            sql += "AND PE.ID_Grade = " + Venda.Item[i].ID_Grade + " ";

                            DataTable _DT = conexao.Consulta(sql);

                            if (_DT.Rows[0]["Total"].ToString().Trim() != string.Empty)
                            {
                                cmd = new SqlCommand();
                                sql = "UPDATE ";
                                sql += "Produto_Estoque SET ";
                                sql += "EstoqueAtual = @EstoqueAtual ";
                                sql += "WHERE ";
                                sql += "ID_Produto = @ID_Produto ";
                                sql += "AND ID_Grade = @ID_Grade ";
                                cmd.CommandText = sql;

                                cmd.Parameters.AddWithValue("@ID_Grade", Venda.Item[i].ID_Grade);
                                cmd.Parameters.AddWithValue("@ID_Produto", Venda.Item[i].ID_Produto);
                                cmd.Parameters.AddWithValue("@EstoqueAtual", _DT.Rows[0]["Total"]);
                                conexao.Executa_Comando(cmd);
                            }
                        }
                #endregion

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Venda_Item ";
                sql += "WHERE ";
                sql += "ID_Venda = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Venda.ID);

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

        public void Exclui_Item()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                if (Venda.Item != null && Venda.Item.Count > 0)
                    for (int i = 0; i <= Venda.Item.Count - 1; i++)
                        if (Venda.Item[i].ID != 0)
                        {
                            sql = "SELECT ";
                            sql += "VI.Quantidade_Entregue + PE.EstoqueAtual AS Total ";
                            sql += "FROM ";
                            sql += "Venda_Item AS VI ";
                            sql += "INNER JOIN Produto_Estoque AS PE ON VI.ID_Produto = PE.ID_Produto ";
                            sql += "WHERE VI.ID = " + Venda.Item[0].ID;

                            DataTable _DT = conexao.Consulta(sql);

                            if (_DT.Rows[0]["Total"].ToString().Trim() != string.Empty)
                            {
                                cmd = new SqlCommand();
                                sql = "UPDATE ";
                                sql += "Produto_Estoque SET ";
                                sql += "EstoqueAtual = @EstoqueAtual ";
                                sql += "WHERE ";
                                sql += "ID_Produto = @ID_Produto ";
                                sql += "AND ID_Grade = @ID_Grade ";
                                cmd.CommandText = sql;

                                cmd.Parameters.AddWithValue("@ID_Grade", Venda.Item[i].ID_Grade);
                                cmd.Parameters.AddWithValue("@ID_Produto", Venda.Item[i].ID_Produto);
                                cmd.Parameters.AddWithValue("@EstoqueAtual", _DT.Rows[0]["Total"]);
                                conexao.Executa_Comando(cmd);
                            }

                            cmd = new SqlCommand();
                            sql = "DELETE FROM ";
                            sql += "Venda_Item ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Venda.Item[0].ID);

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
    }

    public class DAL_Venda_Mobile
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Mobile Mobile;
        #endregion

        #region CONSTRUTOR
        public DAL_Venda_Mobile(DTO_Mobile _Mobile)
        {
            this.Mobile = _Mobile;
        }
        #endregion

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT *, Pagamento + '(' + Parcelamento + ')' AS DescricaoPagamento ";
                sql += "FROM V_Venda_Mobile ";
                sql += "ORDER BY IMEI, ID ";

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

                sql = "SELECT ";
                sql += "VIM.ID, VIM.ID_Produto, VIM.Quantidade, VIM.Informacao, VIM.TipoSaida, ";
                sql += "P.Descricao, P.CustoFinal AS ValorCusto, ";
                sql += "TP.ValorVenda AS ValorProduto, (VIM.Quantidade * TP.ValorVenda) AS ValorTotal, ";
                sql += "CASE VIM.TipoSaida ";
                sql += "WHEN 0 THEN 'VENDA' ";
                sql += "WHEN 1 THEN 'TROCA' ";
                sql += "WHEN 2 THEN 'BONIFICAÇÃO' ";
                sql += "END AS DescricaoTipoSaida ";
                sql += "FROM ";
                sql += "Venda_Item_Mobile AS VIM ";
                sql += "LEFT JOIN Produto_Servico AS P ON P.ID = VIM.ID_Produto ";
                sql += "INNER JOIN Produto_Valor AS TP ON P.ID = TP.ID_Produto AND TP.ID_Tabela = " + Mobile.ID_Tabela + " ";
                sql += "WHERE ";
                sql += "NOT VIM.ID IS NULL ";
                sql += "AND VIM.ID_Venda = " + Mobile.ID_Venda + " ";
                sql += "AND VIM.IMEI = '" + Mobile.IMEI + "' ";

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

        public void Exclui_VendaMobile()
        {
            conexao = new Conexao();
            try
            {
                cmd = new SqlCommand();

                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Venda_Mobile ";
                sql += "WHERE ";
                sql += "ID_Venda = " + Mobile.ID_Venda + " ";
                sql += "AND IMEI = '" + Mobile.IMEI + "' ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Venda_Item_Mobile ";
                sql += "WHERE ";
                sql += "ID_Venda = " + Mobile.ID_Venda + " ";
                sql += "AND IMEI = '" + Mobile.IMEI + "' ";
                cmd.CommandText = sql;
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