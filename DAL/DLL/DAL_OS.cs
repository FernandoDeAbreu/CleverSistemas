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
    public class DAL_OS
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;

        string sql;

        SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_OS OS;
        DTO_Produto_Item Item;
        #endregion

        #region CONSTRUTOR
        public DAL_OS(DTO_OS _OS)
        {
            this.OS = _OS;
        }

        public DAL_OS(DTO_Produto_Item _Item)
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
                if (OS.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Ordem_Servico ";
                    sql += "(ID_Empresa, TipoPessoa, ID_Pessoa, Data_Abertura, Garantia, Reclamacao, Observacao, TipoAtendimento, ";
                    sql += "Tipo_Equipamento, Marca, Info_Equip_1, Info_Equip_2, Info_Equip_3, Obs_Equip_1, Obs_Equip_2, ";
                    sql += "Status_OS, ID_UsuarioComissao1, ID_UsuarioComissao2, Faturado, NFe, Cancelado, CPF_CNPJ) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @TipoPessoa, @ID_Pessoa, @Data_Abertura, @Garantia, @Reclamacao, @Observacao, @TipoAtendimento, ";
                    sql += "@Tipo_Equipamento, @Marca, @Info_Equip_1, @Info_Equip_2, @Info_Equip_3, @Obs_Equip_1, @Obs_Equip_2, ";
                    sql += "@Status_OS, @ID_UsuarioComissao1, @ID_UsuarioComissao2, @Faturado, @NFe, @Cancelado, @CPF_CNPJ) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", OS.ID_Empresa);
                    cmd.Parameters.AddWithValue("@TipoPessoa", OS.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", OS.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Data_Abertura", OS.Data_Abertura);
                    cmd.Parameters.AddWithValue("@Garantia", OS.Garantia);
                    cmd.Parameters.AddWithValue("@Reclamacao", OS.Reclamacao);
                    cmd.Parameters.AddWithValue("@Observacao", OS.Observacao);
                    cmd.Parameters.AddWithValue("@TipoAtendimento", OS.TipoAtendimento);
                    cmd.Parameters.AddWithValue("@Tipo_Equipamento", OS.Tipo_Equipamento);
                    cmd.Parameters.AddWithValue("@Marca", OS.Marca);
                    cmd.Parameters.AddWithValue("@Info_Equip_1", OS.Info_Equip_1);
                    cmd.Parameters.AddWithValue("@Info_Equip_2", OS.Info_Equip_2);
                    cmd.Parameters.AddWithValue("@Info_Equip_3", OS.Info_Equip_3);
                    cmd.Parameters.AddWithValue("@Obs_Equip_1", OS.Obs_Equip_1);
                    cmd.Parameters.AddWithValue("@Obs_Equip_2", OS.Obs_Equip_2);
                    cmd.Parameters.AddWithValue("@Status_OS", OS.Status_OS);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao1", OS.ID_UsuarioComissao1);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao2", OS.ID_UsuarioComissao2);
                    cmd.Parameters.AddWithValue("@Faturado", OS.Faturado);
                    cmd.Parameters.AddWithValue("@NFe", OS.NFe);
                    cmd.Parameters.AddWithValue("@Cancelado", OS.Cancelado);
                    cmd.Parameters.AddWithValue("@CPF_CNPJ", OS.CPF_CNPJ);
                    OS.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Ordem_Servico SET ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "Data_Abertura = @Data_Abertura, ";
                    sql += "Garantia = @Garantia, ";
                    sql += "Reclamacao = @Reclamacao, ";
                    sql += "Observacao = @Observacao, ";
                    sql += "TipoAtendimento = @TipoAtendimento, ";
                    sql += "Tipo_Equipamento = @Tipo_Equipamento, ";
                    sql += "Marca = @Marca, ";
                    sql += "Info_Equip_1 = @Info_Equip_1, ";
                    sql += "Info_Equip_2 = @Info_Equip_2, ";
                    sql += "Info_Equip_3 = @Info_Equip_3, ";
                    sql += "Obs_Equip_1 = @Obs_Equip_1, ";
                    sql += "Obs_Equip_2 = @Obs_Equip_2, ";
                    sql += "Status_OS = @Status_OS, ";
                    sql += "ID_UsuarioComissao1 = @ID_UsuarioComissao1, ";
                    sql += "ID_UsuarioComissao2 = @ID_UsuarioComissao2, ";
                    sql += "Faturado = @Faturado, ";
                    sql += "NFe = @NFe, ";
                    sql += "Cancelado = @Cancelado, ";
                    sql += "CPF_CNPJ = @CPF_CNPJ ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", OS.ID);
                    cmd.Parameters.AddWithValue("@ID_Empresa", OS.ID_Empresa);
                    cmd.Parameters.AddWithValue("@TipoPessoa", OS.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", OS.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Data_Abertura", OS.Data_Abertura);
                    cmd.Parameters.AddWithValue("@Garantia", OS.Garantia);
                    cmd.Parameters.AddWithValue("@Reclamacao", OS.Reclamacao);
                    cmd.Parameters.AddWithValue("@Observacao", OS.Observacao);
                    cmd.Parameters.AddWithValue("@TipoAtendimento", OS.TipoAtendimento);
                    cmd.Parameters.AddWithValue("@Tipo_Equipamento", OS.Tipo_Equipamento);
                    cmd.Parameters.AddWithValue("@Marca", OS.Marca);
                    cmd.Parameters.AddWithValue("@Info_Equip_1", OS.Info_Equip_1);
                    cmd.Parameters.AddWithValue("@Info_Equip_2", OS.Info_Equip_2);
                    cmd.Parameters.AddWithValue("@Info_Equip_3", OS.Info_Equip_3);
                    cmd.Parameters.AddWithValue("@Obs_Equip_1", OS.Obs_Equip_1);
                    cmd.Parameters.AddWithValue("@Obs_Equip_2", OS.Obs_Equip_2);
                    cmd.Parameters.AddWithValue("@Status_OS", OS.Status_OS);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao1", OS.ID_UsuarioComissao1);
                    cmd.Parameters.AddWithValue("@ID_UsuarioComissao2", OS.ID_UsuarioComissao2);
                    cmd.Parameters.AddWithValue("@Faturado", OS.Faturado);
                    cmd.Parameters.AddWithValue("@NFe", OS.NFe);
                    cmd.Parameters.AddWithValue("@Cancelado", OS.Cancelado);
                    cmd.Parameters.AddWithValue("@CPF_CNPJ", OS.CPF_CNPJ);

                    conexao.Executa_Comando(cmd);
                }
                if (OS.ID == 0)
                    throw new Exception(util_msg.msg_Erro);

                #region GRAVA ITEM
                if (OS.Item != null && OS.Item.Count > 0)
                    for (int i = 0; i <= OS.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (OS.Item[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Ordem_Servico_Item ";
                            sql += "(ID_OS, ID_Produto, Quantidade, ID_Tabela, ";
                            sql += "ValorProduto, ValorVenda, Informacao, TipoSaida, ID_Grade, ValorCusto) ";
                            sql += "VALUES ";
                            sql += "(@ID_OS, @ID_Produto, @Quantidade, @ID_Tabela, ";
                            sql += "@ValorProduto, @ValorVenda, @Informacao, @TipoSaida, @ID_Grade, @ValorCusto) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_OS", OS.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", OS.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", OS.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", OS.Item[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorProduto", OS.Item[i].ValorProduto);
                            cmd.Parameters.AddWithValue("@ValorVenda", OS.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Informacao", OS.Item[i].Informacao);
                            cmd.Parameters.AddWithValue("@TipoSaida", OS.Item[i].TipoSaida);
                            cmd.Parameters.AddWithValue("@ID_Grade", OS.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorCusto", OS.Item[i].ValorCusto);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Ordem_Servico_Item SET ";
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
                            cmd.Parameters.AddWithValue("@ID", OS.Item[i].ID);
                            cmd.Parameters.AddWithValue("@ID_OS", OS.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", OS.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", OS.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Tabela", OS.Item[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@ValorProduto", OS.Item[i].ValorProduto);
                            cmd.Parameters.AddWithValue("@ValorVenda", OS.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Informacao", OS.Item[i].Informacao);
                            cmd.Parameters.AddWithValue("@TipoSaida", OS.Item[i].TipoSaida);
                            cmd.Parameters.AddWithValue("@ID_Grade", OS.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorCusto", OS.Item[i].ValorCusto);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                conexao.Commit_Conexao();
                return OS.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Ordem_Servico";
                int aux_ID = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Ordem_Servico, RESEED, " + aux_ID + ")";
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
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Ordem_Servico SET ";
                sql += "ID_NFe = @ID_NFe, ";
                sql += "NFe = @NFe  ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);
                cmd.Parameters.AddWithValue("@ID_NFe", OS.ID_NFe);
                cmd.Parameters.AddWithValue("@NFe", OS.NFe);

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
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Ordem_Servico SET ";
                sql += "NFe = @NFe  ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);
                cmd.Parameters.AddWithValue("@NFe", OS.NFe);

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
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Ordem_Servico SET ";
                sql += "Data_Entrega = @Data_Entrega, ";
                sql += "Status_OS = 6, ";
                sql += "Faturado = @Faturado ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);
                cmd.Parameters.AddWithValue("@Data_Entrega", OS.Data_Entrega);
                cmd.Parameters.AddWithValue("@Faturado", OS.Faturado);

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

        public void Altera_Status()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Ordem_Servico SET ";
                sql += "Status_OS = @status_OS, ";

                switch (OS.Status_OS)
                {
                    case 1://ABERTURA
                        sql += "Data_Abertura = @Data ";
                        break;

                    case 2://ORÇAMENTO
                        sql += "Data_Orcamento = @Data ";
                        break;

                    case 3://APROVADA
                        sql += "Data_Aprovacao = @Data ";
                        break;

                    case 4://APROVADA
                        sql += "Data_Montagem = @Data ";
                        break;

                    case 5://PRONTA
                        sql += "Data_Pronta = @Data ";
                        break;

                    case 6://ENTREGUE
                        sql += "Data_Entrega = @Data ";
                        break;
                }

                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);
                cmd.Parameters.AddWithValue("@Status_OS", OS.Status_OS);
                cmd.Parameters.AddWithValue("@Data", OS.Data);

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

        public void AlteraItemQuantidade()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                if (OS.Item != null && OS.Item.Count > 0)
                    for (int i = 0; i <= OS.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        sql = "UPDATE ";
                        sql += "Ordem_Servico_Item SET ";
                        sql += "Quantidade = (Quantidade - @Quantidade), ";
                        sql += "Informacao = Informacao + @Informacao ";
                        sql += "WHERE ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", OS.Item[i].ID);
                        cmd.Parameters.AddWithValue("@Quantidade", OS.Item[i].Quantidade);
                        cmd.Parameters.AddWithValue("@Informacao", OS.Item[i].Informacao);

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
                sql += "Ordem_Servico_Item SET ";
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

        public void Cancela_OrdemServico()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Ordem_Servico SET ";
                sql += "Cancelado = '" + OS.Cancelado + "', ";
                sql += "Observacao = '" + OS.Observacao + "' ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);
                cmd.Parameters.AddWithValue("@Cancelado", OS.Cancelado);
                cmd.Parameters.AddWithValue("@Observacao", OS.Observacao);

                conexao.Executa_Comando(cmd);

                #region RETORNA ESTOQUE
                if (OS.Item != null && OS.Item.Count > 0)
                    for (int i = 0; i <= OS.Item.Count - 1; i++)
                        if (OS.Item[i].ID != 0)
                        {
                            sql = "SELECT ";
                            sql += "pi.Quantidade_Entregue + pe.EstoqueAtual AS Total ";
                            sql += "FROM ";
                            sql += "Ordem_Servico_Item AS pi ";
                            sql += "INNER JOIN Produto_Estoque AS pe ON pi.ID_Produto = pe.ID_Produto ";
                            sql += "WHERE pi.ID = " + OS.Item[i].ID;

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

                                cmd.Parameters.AddWithValue("@ID_Grade", OS.Item[i].ID_Grade);
                                cmd.Parameters.AddWithValue("@ID_Produto", OS.Item[i].ID_Produto);
                                cmd.Parameters.AddWithValue("@EstoqueAtual", _DT.Rows[0]["Total"]);
                                conexao.Executa_Comando(cmd);
                            }
                        }
                #endregion

                cmd = new SqlCommand();
                sql = "UPDATE Ordem_Servico_Item SET ";
                sql += "Quantidade_Entregue = 0 ";
                sql += "WHERE ";
                sql += "ID_OS = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);

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

                sql = "SELECT ID_OS AS ID, * ";
                sql += "FROM V_Ordem_Servico ";
                sql += "WHERE ";
                sql += "NOT ID_OS IS NULL ";

                if (OS.ID_Empresa > 0)
                    sql += "AND ID_Empresa = " + OS.ID_Empresa + " ";

                if (OS.ID > 0)
                    sql += "AND ID_OS = " + OS.ID + " ";

                if (OS.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + OS.TipoPessoa + " ";

                if (OS.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa  = " + OS.ID_Pessoa + " ";

                if (OS.Pesquisa_Garantia == true)
                    sql += "AND Garantia = '" + OS.Garantia + "' ";

                if (OS.TipoAtendimento > 0)
                    sql += "AND TipoAtendimento = " + OS.TipoAtendimento + " ";

                if (OS.Tipo_Equipamento > 0)
                    sql += "AND Tipo_Equipamento = " + OS.Tipo_Equipamento + " ";

                if (OS.Marca > 0)
                    sql += "AND Marca = " + OS.Marca + " ";

                if (OS.Info_Equip_1 != string.Empty)
                    sql += "AND Info_Equip_1 LIKE '%" + OS.Info_Equip_1 + "%' ";

                if (OS.Info_Equip_2 != string.Empty)
                    sql += "AND Info_Equip_2 LIKE '%" + OS.Info_Equip_2 + "%' ";

                if (OS.Info_Equip_3 != string.Empty)
                    sql += "AND Info_Equip_3 LIKE '%" + OS.Info_Equip_3 + "%' ";

                if (OS.Pesquisa_Faturado == true)
                {
                    sql += "AND Faturado = '" + OS.Faturado + "' ";
                    sql += "AND Cancelado = '" + OS.Cancelado + "' ";
                }

                if (OS.Pesquisa_EmitidoNFe == true)
                    sql += "AND NFe = '" + OS.NFe + "' ";

                if (OS.Pesquisa_Cancelado == true)
                    sql += "AND Cancelado = '" + OS.Cancelado + "' ";

                if (OS.ID_UsuarioComissao1 > 0)
                    sql += "AND ID_UsuarioComissao1 = " + OS.ID_UsuarioComissao1 + " ";

                if (OS.ID_UsuarioComissao2 > 0)
                    sql += "AND ID_UsuarioComissao2 = " + OS.ID_UsuarioComissao2 + " ";

                if (OS.Status_OS > 0)
                    sql += "AND Status_OS = " + OS.Status_OS + " ";

                if (OS.Consulta_Status.Filtra == true)
                {
                    switch (OS.Status_OS)
                    {
                        case 1:
                            sql += "AND CONVERT(DATE, Data_Abertura) ";
                            break;

                        case 2:
                            sql += "AND CONVERT(DATE, Data_Orcamento) ";
                            break;

                        case 3:
                            sql += "AND CONVERT(DATE, Data_Aprovada) ";
                            break;

                        case 4:
                            sql += "AND CONVERT(DATE, Data_Montagem) ";
                            break;

                        case 5:
                            sql += "AND CONVERT(DATE, Data_Pronta) ";
                            break;

                        case 6:
                            sql += "AND CONVERT(DATE, Data_Entrega) ";
                            break;
                    }
                    if (OS.Status_OS != 0)
                        sql += "BETWEEN CONVERT(DATE, '" + OS.Consulta_Status.Inicial + "') AND CONVERT(DATE, '" + OS.Consulta_Status.Final + "') ";
                }

                sql += "ORDER BY Status_OS, ID_OS DESC ";

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

        public DataTable Busca_TotalOS()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "OS.ID_OS, OS.Descricao, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, OS.Data_Pronta, OS.Data_Entrega, ";
                sql += "OS.Reclamacao, OS.Observacao, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                sql += "OS.InformacaoCompleta, OS.DescricaoAtendimento, OS.DescricaoEquipamento, OS.DescricaoMarca, OS.Faturado, OS.NFe, OS.Cancelado, ";
                sql += "OS.ValorTotal, OS.CustoTotal, ";
                sql += "PG.Descricao AS DescricaoPagamento, SUM(PG.Credito) AS ValorPagto, SUM(PG.ValorPago) AS ValorPago, ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2 ";
                sql += "FROM V_Ordem_Servico AS OS ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                sql += "LEFT JOIN V_Ordem_Servico_ResumoPagto AS PG ON OS.ID_OS = PG.ID_OS ";
                sql += "LEFT JOIN Usuario AS PU1 ON OS.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON OS.ID_UsuarioComissao2 = PU2.ID ";
                sql += "WHERE ";
                sql += "NOT OS.ID_OS IS NULL ";
                sql += "AND OS.ID_Empresa = " + OS.ID_Empresa + " ";

                if (OS.ID > 0)
                    sql += "AND OS.ID_OS = " + OS.ID + " ";

                if (OS.TipoPessoa > 0)
                    sql += "AND OS.TipoPessoa = " + OS.TipoPessoa + " ";

                if (OS.ID_Pessoa > 0)
                    sql += "AND OS.ID_Pessoa  = " + OS.ID_Pessoa + " ";

                if (OS.Pesquisa_Faturado == true)
                {
                    sql += "AND OS.Faturado = '" + OS.Faturado + "' ";
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";
                }

                if (OS.Pesquisa_EmitidoNFe == true)
                    sql += "AND OS.NFe = '" + OS.NFe + "' ";

                if (OS.Pesquisa_Cancelado == true)
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";

                if (OS.ID_UsuarioComissao1 > 0)
                    sql += "AND OS.ID_UsuarioComissao1 = " + OS.ID_UsuarioComissao1 + " ";

                if (OS.ID_UsuarioComissao2 > 0)
                    sql += "AND OS.ID_UsuarioComissao2 = " + OS.ID_UsuarioComissao2 + " ";

                if (OS.Consulta_Status.Filtra == true)
                {
                    switch (OS.Status_OS)
                    {
                        case 1:
                            sql += "AND CONVERT(DATE, Data_Abertura) ";
                            break;

                        case 2:
                            sql += "AND CONVERT(DATE, Data_Orcamento) ";
                            break;

                        case 3:
                            sql += "AND CONVERT(DATE, Data_Aprovada) ";
                            break;

                        case 4:
                            sql += "AND CONVERT(DATE, Data_Montagem) ";
                            break;

                        case 5:
                            sql += "AND CONVERT(DATE, Data_Pronta) ";
                            break;

                        case 6:
                            sql += "AND CONVERT(DATE, Data_Entrega) ";
                            break;
                    }

                    sql += "BETWEEN CONVERT(DATE, '" + OS.Consulta_Status.Inicial + "') AND CONVERT(DATE, '" + OS.Consulta_Status.Final + "') ";
                }

                sql += "GROUP BY OS.ID_OS, OS.Descricao, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, OS.Data_Pronta, OS.Data_Entrega, ";
                sql += "OS.Reclamacao, OS.Observacao, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                sql += "OS.InformacaoCompleta, OS.DescricaoAtendimento, OS.DescricaoEquipamento, OS.DescricaoMarca, ";
                sql += "OS.ValorTotal, OS.CustoTotal, OS.ValorTotal, OS.CustoTotal, P.Nome_Razao, P.NomeFantasia, PU1.Descricao, PU2.Descricao, ";
                sql += "PG.Credito, OS.Descricao, PG.Descricao, OS.Faturado, OS.ValorTotal, OS.CustoTotal, OS.Faturado, OS.NFe, OS.Cancelado, ";
                sql += "OS.Descricao, OS.Faturado ";
                sql += "ORDER BY ";

                if (OS.Consulta_Status.Filtra == true)
                {
                    switch (OS.Status_OS)
                    {
                        case 1:
                            sql += "OS.Data_Abertura ";
                            break;

                        case 2:
                            sql += "OS.Data_Orcamento ";
                            break;

                        case 3:
                            sql += "OS.Data_Aprovada ";
                            break;

                        case 4:
                            sql += "OS.Data_Montagem ";
                            break;

                        case 5:
                            sql += "OS.Data_Pronta ";
                            break;

                        case 6:
                            sql += "OS.Data_Entrega ";
                            break;
                    }
                }
                else
                    sql += "OS.Data_Abertura ";


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

        public DataTable Busca_TotalOSResumo()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "OS.ID_OS, OS.Descricao, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, OS.Data_Pronta, OS.Data_Entrega, ";
                sql += "OS.Reclamacao, OS.Observacao, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                sql += "OS.InformacaoCompleta, OS.DescricaoAtendimento, OS.DescricaoEquipamento, OS.DescricaoMarca, OS.Faturado, OS.NFe, OS.Cancelado, ";
                sql += "OS.ValorTotal, OS.CustoTotal, ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2, ";
                sql += "OS.ValorTotal, OS.CustoTotal ";
                sql += "FROM V_Ordem_Servico AS OS ";
                sql += "INNER JOIN V_Ordem_Servico_Item AS PI ON OS.ID_OS = PI.ID_OS ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                sql += "LEFT JOIN Usuario AS PU1 ON OS.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON OS.ID_UsuarioComissao2 = PU2.ID ";
                sql += "WHERE ";
                sql += "NOT OS.ID_OS IS NULL ";
                sql += "AND OS.ID_Empresa = " + OS.ID_Empresa + " ";

                if (OS.ID > 0)
                    sql += "AND OS.ID_OS = " + OS.ID + " ";

                if (OS.TipoPessoa > 0)
                    sql += "AND OS.TipoPessoa = " + OS.TipoPessoa + " ";

                if (OS.ID_Pessoa > 0)
                    sql += "AND OS.ID_Pessoa  = " + OS.ID_Pessoa + " ";

                if (OS.Pesquisa_Faturado == true)
                {
                    sql += "AND OS.Faturado = '" + OS.Faturado + "' ";
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";
                }

                if (OS.Pesquisa_EmitidoNFe == true)
                    sql += "AND OS.NFe = '" + OS.NFe + "' ";

                if (OS.Pesquisa_Cancelado == true)
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";

                if (OS.ID_UsuarioComissao1 > 0)
                    sql += "AND OS.ID_UsuarioComissao1 = " + OS.ID_UsuarioComissao1 + " ";

                if (OS.ID_UsuarioComissao2 > 0)
                    sql += "AND OS.ID_UsuarioComissao2 = " + OS.ID_UsuarioComissao2 + " ";

                if (OS.Consulta_Status.Filtra == true)
                {
                    switch (OS.Status_OS)
                    {
                        case 1:
                            sql += "AND CONVERT(DATE, Data_Abertura) ";
                            break;

                        case 2:
                            sql += "AND CONVERT(DATE, Data_Orcamento) ";
                            break;

                        case 3:
                            sql += "AND CONVERT(DATE, Data_Aprovada) ";
                            break;

                        case 4:
                            sql += "AND CONVERT(DATE, Data_Montagem) ";
                            break;

                        case 5:
                            sql += "AND CONVERT(DATE, Data_Pronta) ";
                            break;

                        case 6:
                            sql += "AND CONVERT(DATE, Data_Entrega) ";
                            break;
                    }

                    sql += "BETWEEN CONVERT(DATE, '" + OS.Consulta_Status.Inicial + "') AND CONVERT(DATE, '" + OS.Consulta_Status.Final + "') ";
                }

                sql += "GROUP BY OS.ID_OS, OS.Descricao, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, OS.Data_Pronta, OS.Data_Entrega, ";
                sql += "OS.Reclamacao, OS.Observacao, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                sql += "OS.InformacaoCompleta, OS.DescricaoAtendimento, OS.DescricaoEquipamento, OS.DescricaoMarca, ";
                sql += "OS.ValorTotal, OS.CustoTotal, P.Nome_Razao, P.NomeFantasia, PU1.Descricao, PU2.Descricao, ";
                sql += "OS.Faturado, OS.Cancelado, OS.NFe ";
                sql += "ORDER BY ";


                if (OS.Consulta_Status.Filtra == true)
                {
                    switch (OS.Status_OS)
                    {
                        case 1:
                            sql += "OS.Data_Abertura ";
                            break;

                        case 2:
                            sql += "OS.Data_Orcamento ";
                            break;

                        case 3:
                            sql += "OS.Data_Aprovada ";
                            break;

                        case 4:
                            sql += "OS.Data_Montagem ";
                            break;

                        case 5:
                            sql += "OS.Data_Pronta ";
                            break;

                        case 6:
                            sql += "OS.Data_Entrega ";
                            break;
                    }
                }
                else
                    sql += "OS.Data_Abertura ";

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
                sql += "OS.ID_OS, OS.Descricao, OS.Complemento, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, OS.Data_Pronta, OS.Data_Entrega, ";
                sql += "OS.Reclamacao, OS.Observacao, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                sql += "OS.InformacaoCompleta, OS.DescricaoAtendimento, OS.DescricaoEquipamento, OS.DescricaoMarca, OS.Faturado, OS.NFe, OS.Cancelado, ";
                sql += "OS.ValorTotal, OS.CustoTotal, ";
                sql += "P.CNPJ_CPF, ";
                sql += "PG.Descricao AS DescricaoPagamento, PG.Credito AS ValorPagto, ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2, ";
                sql += "CASE GP.Descricao ";
                sql += "WHEN 'ÚNICO' THEN PD.Descricao ";
                sql += "ELSE PD.Descricao + ' - ' + GP.Descricao ";
                sql += "END AS DescricaoProduto, ";
                sql += "SUM(PI.Quantidade) QuantidadeTotal ";
                sql += "FROM V_Ordem_Servico AS OS ";
                sql += "INNER JOIN V_Ordem_Servico_Item AS PI ON OS.ID_OS = PI.ID_OS ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                sql += "LEFT JOIN V_Ordem_Servico_ResumoPagto AS PG ON OS.ID_OS = PG.ID_OS ";
                sql += "LEFT JOIN Usuario AS PU1 ON OS.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON OS.ID_UsuarioComissao2 = PU2.ID ";
                sql += "LEFT JOIN Produto AS PD ON PD.ID = PI.ID_Produto ";
                sql += "INNER JOIN Grade AS GP ON GP.ID = PI.ID_Grade ";
                sql += "WHERE ";
                sql += "NOT OS.ID_OS IS NULL ";
                sql += "AND OS.ID_Empresa = " + OS.ID_Empresa + " ";

                if (OS.ID > 0)
                    sql += "AND OS.ID_OS = " + OS.ID + " ";

                if (OS.TipoPessoa > 0)
                    sql += "AND OS.TipoPessoa = " + OS.TipoPessoa + " ";

                if (OS.ID_Pessoa > 0)
                    sql += "AND OS.ID_Pessoa  = " + OS.ID_Pessoa + " ";

                if (OS.Pesquisa_Faturado == true)
                {
                    sql += "AND OS.Faturado = '" + OS.Faturado + "' ";
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";
                }

                if (OS.Pesquisa_EmitidoNFe == true)
                    sql += "AND OS.NFe = '" + OS.NFe + "' ";

                if (OS.Pesquisa_Cancelado == true)
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";

                if (OS.ID_UsuarioComissao1 > 0)
                    sql += "AND OS.ID_UsuarioComissao1 = " + OS.ID_UsuarioComissao1 + " ";

                if (OS.ID_UsuarioComissao2 > 0)
                    sql += "AND OS.ID_UsuarioComissao2 = " + OS.ID_UsuarioComissao2 + " ";

                if (OS.Consulta_Status.Filtra == true)
                {
                    switch (OS.Status_OS)
                    {
                        case 1:
                            sql += "AND CONVERT(DATE, Data_Abertura) ";
                            break;

                        case 2:
                            sql += "AND CONVERT(DATE, Data_Orcamento) ";
                            break;

                        case 3:
                            sql += "AND CONVERT(DATE, Data_Aprovada) ";
                            break;

                        case 4:
                            sql += "AND CONVERT(DATE, Data_Montagem) ";
                            break;

                        case 5:
                            sql += "AND CONVERT(DATE, Data_Pronta) ";
                            break;

                        case 6:
                            sql += "AND CONVERT(DATE, Data_Entrega) ";
                            break;
                    }

                    sql += "BETWEEN CONVERT(DATE, '" + OS.Consulta_Status.Inicial + "') AND CONVERT(DATE, '" + OS.Consulta_Status.Final + "') ";
                }

                sql += "GROUP BY OS.ID_OS, OS.Descricao, OS.Complemento, OS.Data_Abertura, OS.Data_Orcamento, OS.Data_Aprovacao, OS.Data_Montagem, OS.Data_Pronta, OS.Data_Entrega, ";
                sql += "OS.Reclamacao, OS.Observacao, OS.Info_Equip_1, OS.Info_Equip_2, OS.Info_Equip_3, OS.Obs_Equip_1, OS.Obs_Equip_2, ";
                sql += "OS.InformacaoCompleta, OS.DescricaoAtendimento, OS.DescricaoEquipamento, OS.DescricaoMarca, OS.Faturado, OS.NFe, OS.Cancelado, ";
                sql += "OS.ValorTotal, OS.CustoTotal, P.CNPJ_CPF, ";
                sql += "PG.Descricao, PG.Credito, PU1.Descricao, PU2.Descricao, PD.Descricao, GP.Descricao ";

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

        /*
        public DataTable Busca_ResumoPedido()
        {
            try
            {
                sql = "SELECT ";
                sql += "OS.ID_OS, OS.Data, OS.Informacao, OS.Comprador, OS.Descricao, OS.Complemento, OS.Faturado, OS.Cancelado, OS.NFe,";
                sql += "PG.Descricao AS DescricaoPagamento, ";
                sql += "PU1.Descricao AS DescricaoUsuarioComissao1, ";
                sql += "PU2.Descricao AS DescricaoUsuarioComissao2, ";
                sql += "PU3.Descricao AS DescricaoUsuarioComissao3, ";
                sql += "CASE GP.Descricao ";
                sql += "WHEN 'ÚNICO' THEN PD.Descricao ";
                sql += "ELSE PD.Descricao + ' - ' + GP.Descricao ";
                sql += "END AS DescricaoProduto, ";
                sql += "PI.ID_Produto, PI.Quantidade, PI.ValorVenda, PI.Acrescimo, PI.Desconto, PI.ValorTotal, PI.ValorCusto, ";
                sql += "PI.ValorProduto, PI.DescricaoSaida AS  DescricaoTipoSaida ";
                sql += "FROM V_Pedido AS PV ";
                sql += "INNER JOIN V_Pedido_Item AS PI ON OS.ID_OS = PI.ID_OS ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                sql += "LEFT JOIN Pagamento AS PG ON OS.ID_Pagamento = PG.ID ";
                sql += "LEFT JOIN Usuario AS PU1 ON OS.ID_UsuarioComissao1 = PU1.ID ";
                sql += "LEFT JOIN Usuario AS PU2 ON OS.ID_UsuarioComissao2 = PU2.ID ";
                sql += "LEFT JOIN Usuario AS PU3 ON OS.ID_UsuarioComissao3 = PU3.ID ";
                sql += "LEFT JOIN Produto AS PD ON PD.ID = PI.ID_Produto ";
                sql += "INNER JOIN Grade AS GP ON GP.ID = PI.ID_Grade ";
                sql += "WHERE ";
                sql += "NOT OS.ID_OS IS NULL ";
                sql += "AND OS.ID_Empresa = " + OS.ID_Empresa + " ";

                if (OS.ID > 0)
                    sql += "AND OS.ID_OS = " + OS.ID + " ";

                if (OS.TipoPessoa > 0)
                    sql += "AND OS.TipoPessoa = " + OS.TipoPessoa + " ";

                if (OS.ID_Pessoa > 0)
                    sql += "AND OS.ID_Pessoa  = " + OS.ID_Pessoa + " ";

                if (OS.Pesquisa_Faturado == true)
                {
                    sql += "AND OS.Faturado = '" + OS.Faturado + "' ";
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";
                }

                if (OS.Pesquisa_NFe == true)
                    sql += "AND OS.NFe = '" + OS.NFe + "' ";

                if (OS.Pesquisa_Cancelado == true)
                    sql += "AND OS.Cancelado = '" + OS.Cancelado + "' ";

                if (OS.Tipo > 0)
                    sql += "AND Tipo = " + OS.Tipo + " ";

                if (OS.ID_UsuarioComissao1 > 0)
                    sql += "AND OS.ID_UsuarioComissao1 = " + OS.ID_UsuarioComissao1 + " ";

                if (OS.ID_UsuarioComissao2 > 0)
                    sql += "AND OS.ID_UsuarioComissao2 = " + OS.ID_UsuarioComissao2 + " ";

                if (OS.ID_UsuarioComissao3 > 0)
                    sql += "AND OS.ID_UsuarioComissao3 = " + OS.ID_UsuarioComissao3 + " ";

                if (OS.Consulta_Emissao.Filtra == true)
                    sql += "AND OS.Data BETWEEN '" + OS.Consulta_Emissao.Inicial + "' AND '" + OS.Consulta_Emissao.Final + "' ";

                if (OS.Consulta_Fatura.Filtra == true)
                    sql += "AND OS.DataFatura BETWEEN '" + OS.Consulta_Fatura.Inicial + "' AND '" + OS.Consulta_Fatura.Final + "' ";

                sql += "ORDER BY OS.Data, OS.ID_OS ";

                return conexao.Consulta(sql);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable Busca_Pessoa_Inativo()
        {
            try
            {
                sql = "SELECT * ";
                sql += "FROM V_Venda_PessoaInativo ";
                sql += "WHERE NOT ID_OS IS NULL ";

                sql += "AND TempoCompra > " + OS.Dias_Inativo + " ";

                if (OS.PesquisaInativo == true)
                    sql += "AND Situacao = '" + OS.SituacaoInativo + "' ";

                if (OS.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + OS.TipoPessoa + " ";

                if (OS.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa  = " + OS.ID_Pessoa + " ";

                if (OS.Pesquisa_Faturado == true)
                {
                    sql += "AND Faturado = '" + OS.Faturado + "' ";
                    sql += "AND Cancelado = '" + OS.Cancelado + "' ";
                }

                if (OS.Pesquisa_NFe == true)
                    sql += "AND NFe = '" + OS.NFe + "' ";

                if (OS.Pesquisa_Cancelado == true)
                    sql += "AND Cancelado = '" + OS.Cancelado + "' ";

                if (OS.Tipo > 0)
                    sql += "AND Tipo = " + OS.Tipo + " ";

                if (OS.ID_UsuarioComissao1 > 0)
                    sql += "AND ID_UsuarioComissao1 = " + OS.ID_UsuarioComissao1 + " ";

                return conexao.Consulta(sql);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable Busca_Fatura()
        {
            try
            {
                sql = "SELECT VP.ID_OS AS ID, VP.*, ";
                sql += "U.Descricao AS UsuarioComissao ";
                sql += "FROM V_Pedido AS VP ";
                sql += "LEFT JOIN Usuario AS U ON VP.ID_UsuarioComissao1 = U.ID ";
                sql += "WHERE ";
                //sql += "ID_Empresa = " + OS.ID_Empresa + " ";

                sql += "Faturado = '" + OS.Faturado + "' ";
                sql += "AND NFe = '" + OS.NFe + "' ";

                if (OS.ID > 0)
                    sql += "AND ID_OS = " + OS.ID + " ";

                if (OS.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + OS.TipoPessoa + " ";

                if (OS.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa  = " + OS.ID_Pessoa + " ";

                if (OS.Consulta_Emissao.Filtra == true)
                    sql += "AND Data BETWEEN '" + OS.Consulta_Emissao.Inicial + "' AND '" + OS.Consulta_Emissao.Final + "' ";

                if (OS.Consulta_Fatura.Filtra == true)
                    sql += "AND DataFatura BETWEEN '" + OS.Consulta_Fatura.Inicial + "' AND '" + OS.Consulta_Fatura.Final + "' ";

                sql += "ORDER BY ID_OS DESC ";

                return conexao.Consulta(sql);
            }
            catch (Exception)
            {
                return null;
            }
        }
        */
        public DataTable Busca_Relatorio()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID_OS AS ID, * ";
                sql += "FROM V_Ordem_Servico ";
                //sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = OS.TipoPessoa AND P.ID_Pessoa = OS.ID_Pessoa ";
                //sql += "LEFT JOIN Pagamento AS PG ON OS.ID_Pagamento = PG.ID ";
                sql += "WHERE ";
                sql += "NOT ID_OS IS NULL ";
                sql += "AND ID_OS = " + OS.ID + " ";

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
                sql += "V_Ordem_Servico_Item ";
                sql += "WHERE ID_OS = " + OS.ID + " ";
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

                sql = "SELECT Vencimento, Valor, PrevisaoPagto ";
                sql += "FROM ";
                sql += "V_CReceber ";
                sql += "WHERE ID_OS IS NOT NULL ";
                sql += "AND ID_OS = " + OS.ID + " ";
                sql += "ORDER BY Vencimento ";

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
                sql += "WHERE ID_OS IS NOT NULL ";
                sql += "AND ID_OS = " + OS.ID + " ";
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
       
        public DataTable Busca_Item_NF()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM V_Ordem_Servico_Item_Imposto ";
                sql += "WHERE ";
                sql += "NOT ID_Produto IS NULL ";
                sql += "AND ID_OS = " + OS.ID + " ";
                sql += "AND ID_Empresa = " + OS.ID_Empresa + " ";
                sql += "AND Tipo_NF = " + OS.Tipo_NF + " ";
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

        public DataTable Busca_Item_CF()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM V_Ordem_Servico_Item_Imposto_CF ";
                sql += "WHERE ";
                sql += "NOT ID_Produto IS NULL ";
                sql += "AND ID_OS = " + OS.ID + " ";
                sql += "AND ID_Empresa = " + OS.ID_Empresa + " ";
                sql += "AND Tipo_NF = " + OS.Tipo_NF + " ";
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

        public void Exclui()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Ordem_Servico ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);

                conexao.Executa_Comando(cmd);

                #region RETORNA ESTOQUE
                if (OS.Item != null && OS.Item.Count > 0)
                    for (int i = 0; i <= OS.Item.Count - 1; i++)
                        if (OS.Item[i].ID != 0)
                        {
                            sql = "SELECT ";
                            sql += "pi.Quantidade_Entregue + pe.EstoqueAtual AS Total ";
                            sql += "FROM ";
                            sql += "Ordem_Servico_Item AS pi ";
                            sql += "INNER JOIN Produto_Estoque AS pe ON pi.ID_Produto = pe.ID_Produto ";
                            sql += "WHERE pi.ID = " + OS.Item[i].ID;

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

                                cmd.Parameters.AddWithValue("@ID_Grade", OS.Item[i].ID_Grade);
                                cmd.Parameters.AddWithValue("@ID_Produto", OS.Item[i].ID_Produto);
                                cmd.Parameters.AddWithValue("@EstoqueAtual", _DT.Rows[0]["Total"]);
                                conexao.Executa_Comando(cmd);
                            }
                        }

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Ordem_Servico_Item ";
                sql += "WHERE ";
                sql += "ID_OS = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", OS.ID);

                conexao.Executa_Comando(cmd);

                /*
                cmd = new SqlCommand();
                sql = "UPDATE ";
                sql += "Produto_Estoque SET ";
                sql += "EstoqueAtual = (EstoqueAtual + @Estoque) ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID_Produto ";
                sql += "AND ID_Grade = @ID_Grade ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Estoque", OS.Item[i].Quantidade_Entregue);
                cmd.Parameters.AddWithValue("@ID_Produto", OS.Item[i].ID_Produto);
                cmd.Parameters.AddWithValue("@ID_Grade", OS.Item[i].ID_Grade);
                conexao.Executa_Comando(cmd);*/
                #endregion
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
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                if (OS.Item != null && OS.Item.Count > 0)
                    for (int i = 0; i <= OS.Item.Count - 1; i++)
                        if (OS.Item[i].ID != 0)
                        {
                            sql = "SELECT ";
                            sql += "pi.Quantidade_Entregue + pe.EstoqueAtual AS Total ";
                            sql += "FROM ";
                            sql += "Ordem_Servico_Item AS pi ";
                            sql += "INNER JOIN Produto_Estoque AS pe ON pi.ID_Produto = pe.ID_Produto ";
                            sql += "WHERE pi.ID = " + OS.Item[0].ID;

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

                                cmd.Parameters.AddWithValue("@ID_Grade", OS.Item[i].ID_Grade);
                                cmd.Parameters.AddWithValue("@ID_Produto", OS.Item[i].ID_Produto);
                                cmd.Parameters.AddWithValue("@EstoqueAtual", _DT.Rows[0]["Total"]);
                                conexao.Executa_Comando(cmd);
                            }

                            cmd = new SqlCommand();
                            sql = "DELETE FROM ";
                            sql += "Ordem_Servico_Item ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", OS.Item[0].ID);

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
}
