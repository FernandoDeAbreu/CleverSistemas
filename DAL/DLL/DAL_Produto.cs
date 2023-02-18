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
    public class DAL_Produto
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;

        string sql;
        SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        #endregion

        #region CONSTRUTORES
        public DAL_Produto(DTO_Produto _Produto)
        {
            this.Produto = _Produto;
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

                #region PRODUTO
                if (Produto.ID == 0)
                {
                    sql = "INSERT INTO Produto_Servico ";
                    sql += "(ID_Grupo, Descricao, Referencia, Fabricante, Informacao, Barra, BarraTributavel, NCM, ";
                    sql += "ValorCompra, OutrosCustos, ValorIPI, ValorST, CustoFinal, UnidadeTributavel, Validade, Garantia, Tipo, EX_TIPI, ";
                    sql += "CNPJProdutor, ClasseEnquadramento, Cod_ANP, ProdutoEspecifico, PesoB, PesoL, Controle_Estoque, ";
                    sql += "InfoAdicional1, InfoAdicional2, ABC, ID_CEST) ";
                    sql += "VALUES ";
                    sql += "(@ID_Grupo, @Descricao, @Referencia, @Fabricante, @Informacao, @Barra, @BarraTributavel, @NCM, ";
                    sql += "@ValorCompra, @OutrosCustos, @ValorIPI, @ValorST, @CustoFinal, @UnidadeTributavel, @Validade, @Garantia, @Tipo, @EX_TIPI, ";
                    sql += "@CNPJProdutor, @ClasseEnquadramento, @Cod_ANP, @ProdutoEspecifico, @PesoB, @PesoL, @Controle_Estoque, ";
                    sql += "@InfoAdicional1, @InfoAdicional2, @ABC, @ID_CEST) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Grupo", Produto.ID_Grupo);
                    cmd.Parameters.AddWithValue("@Descricao", Produto.Descricao);
                    cmd.Parameters.AddWithValue("@Referencia", Produto.Referencia);
                    cmd.Parameters.AddWithValue("@Fabricante", Produto.Fabricante);
                    cmd.Parameters.AddWithValue("@Informacao", Produto.Informacao);
                    cmd.Parameters.AddWithValue("@Barra", Produto.Barra);
                    cmd.Parameters.AddWithValue("@BarraTributavel", Produto.BarraTributavel);
                    cmd.Parameters.AddWithValue("@NCM", Produto.NCM);
                    cmd.Parameters.AddWithValue("@ValorCompra", Produto.ValorCompra);
                    cmd.Parameters.AddWithValue("@ValorIPI", Produto.ValorIPI);
                    cmd.Parameters.AddWithValue("@ValorST", Produto.ValorST);
                    cmd.Parameters.AddWithValue("@OutrosCustos", Produto.OutrosCustos);
                    cmd.Parameters.AddWithValue("@CustoFinal", Produto.CustoFinal);
                    cmd.Parameters.AddWithValue("@UnidadeTributavel", Produto.UnidadeTributavel);
                    cmd.Parameters.AddWithValue("@Validade", Produto.Validade);
                    cmd.Parameters.AddWithValue("@Garantia", Produto.Garantia);
                    cmd.Parameters.AddWithValue("@Ativo", Produto.Ativo);
                    cmd.Parameters.AddWithValue("@Tipo", Produto.Tipo);
                    cmd.Parameters.AddWithValue("@EX_TIPI", Produto.EX_TIPI);
                    cmd.Parameters.AddWithValue("@CNPJProdutor", Produto.CNPJProdutor);
                    cmd.Parameters.AddWithValue("@Cod_ANP", Produto.Cod_ANP);
                    cmd.Parameters.AddWithValue("@ClasseEnquadramento", Produto.ClasseEnquadramento);
                    cmd.Parameters.AddWithValue("@ProdutoEspecifico", Produto.ProdutoEspecifico);
                    cmd.Parameters.AddWithValue("@PesoB", Produto.PesoB);
                    cmd.Parameters.AddWithValue("@PesoL", Produto.PesoL);
                    cmd.Parameters.AddWithValue("@Controle_Estoque", Produto.Controle_Estoque);
                    cmd.Parameters.AddWithValue("@InfoAdicional1", Produto.InfoAdicional1);
                    cmd.Parameters.AddWithValue("@InfoAdicional2", Produto.InfoAdicional2);
                    cmd.Parameters.AddWithValue("@ABC", Produto.ABC);
                    cmd.Parameters.AddWithValue("@ID_CEST", Produto.ID_CEST);

                    Produto.ID = conexao.Executa_ComandoID(cmd);

                    for (int i = 0; i <= Produto.lst_ID_Empresa.Length - 1; i++)
                    {
                        cmd = new SqlCommand();

                        sql = "INSERT INTO Produto_Parametro ";
                        sql += "(ID_Produto, ID_Empresa, Ativo) ";
                        sql += "VALUES ";
                        sql += "(@ID_Produto, @ID_Empresa, @Ativo) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                        cmd.Parameters.AddWithValue("@ID_Empresa", Produto.lst_ID_Empresa[i]);
                        cmd.Parameters.AddWithValue("@Ativo", Produto.Ativo);

                        conexao.Executa_Comando(cmd);
                    }

                }
                else
                {
                    sql = "UPDATE Produto_Servico SET ";
                    sql += "ID_Grupo = @ID_Grupo, ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Referencia = @Referencia, ";
                    sql += "Fabricante = @Fabricante, ";
                    sql += "Informacao = @Informacao, ";
                    sql += "Barra = @Barra, ";
                    sql += "BarraTributavel = @BarraTributavel, ";
                    sql += "NCM = @NCM, ";
                    sql += "ValorCompra = @ValorCompra, ";
                    sql += "ValorIPI = @ValorIPI, ";
                    sql += "ValorST = @ValorST, ";
                    sql += "OutrosCustos = @OutrosCustos, ";
                    sql += "CustoFinal = @CustoFinal, ";
                    sql += "UnidadeTributavel = @UnidadeTributavel, ";
                    sql += "Validade = @Validade, ";
                    sql += "Garantia = @Garantia, ";
                    sql += "Tipo = @Tipo, ";
                    sql += "EX_TIPI = @EX_TIPI, ";
                    sql += "CNPJProdutor = @CNPJProdutor, ";
                    sql += "ClasseEnquadramento = @ClasseEnquadramento, ";
                    sql += "ProdutoEspecifico = @ProdutoEspecifico, ";
                    sql += "Cod_ANP = @Cod_ANP, ";
                    sql += "PesoB = @PesoB, ";
                    sql += "PesoL = @PesoL, ";
                    sql += "Controle_Estoque = @Controle_Estoque, ";
                    sql += "InfoAdicional1 = @InfoAdicional1, ";
                    sql += "InfoAdicional2 = @InfoAdicional2, ";
                    sql += "ABC = @ABC, ";
                    sql += "ID_CEST = @ID_CEST ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Produto.ID);
                    cmd.Parameters.AddWithValue("@ID_Grupo", Produto.ID_Grupo);
                    cmd.Parameters.AddWithValue("@Descricao", Produto.Descricao);
                    cmd.Parameters.AddWithValue("@Referencia", Produto.Referencia);
                    cmd.Parameters.AddWithValue("@Fabricante", Produto.Fabricante);
                    cmd.Parameters.AddWithValue("@Informacao", Produto.Informacao);
                    cmd.Parameters.AddWithValue("@Barra", Produto.Barra);
                    cmd.Parameters.AddWithValue("@BarraTributavel", Produto.BarraTributavel);
                    cmd.Parameters.AddWithValue("@NCM", Produto.NCM);
                    cmd.Parameters.AddWithValue("@ValorCompra", Produto.ValorCompra);
                    cmd.Parameters.AddWithValue("@ValorIPI", Produto.ValorIPI);
                    cmd.Parameters.AddWithValue("@ValorST", Produto.ValorST);
                    cmd.Parameters.AddWithValue("@OutrosCustos", Produto.OutrosCustos);
                    cmd.Parameters.AddWithValue("@CustoFinal", Produto.CustoFinal);
                    cmd.Parameters.AddWithValue("@UnidadeTributavel", Produto.UnidadeTributavel);
                    cmd.Parameters.AddWithValue("@Validade", Produto.Validade);
                    cmd.Parameters.AddWithValue("@Garantia", Produto.Garantia);
                    cmd.Parameters.AddWithValue("@Tipo", Produto.Tipo);
                    cmd.Parameters.AddWithValue("@EX_TIPI", Produto.EX_TIPI);
                    cmd.Parameters.AddWithValue("@CNPJProdutor", Produto.CNPJProdutor);
                    cmd.Parameters.AddWithValue("@ClasseEnquadramento", Produto.ClasseEnquadramento);
                    cmd.Parameters.AddWithValue("@Cod_ANP", Produto.Cod_ANP);
                    cmd.Parameters.AddWithValue("@ProdutoEspecifico", Produto.ProdutoEspecifico);
                    cmd.Parameters.AddWithValue("@PesoB", Produto.PesoB);
                    cmd.Parameters.AddWithValue("@PesoL", Produto.PesoL);
                    cmd.Parameters.AddWithValue("@Controle_Estoque", Produto.Controle_Estoque);
                    cmd.Parameters.AddWithValue("@InfoAdicional1", Produto.InfoAdicional1);
                    cmd.Parameters.AddWithValue("@InfoAdicional2", Produto.InfoAdicional2);
                    cmd.Parameters.AddWithValue("@ABC", Produto.ABC);
                    cmd.Parameters.AddWithValue("@ID_CEST", Produto.ID_CEST);

                    conexao.Executa_Comando(cmd);
                }
                #endregion

                #region IMAGEM
                if (Produto.Imagem != null)
                {
                    cmd = new SqlCommand();

                    sql = "UPDATE Produto_Servico SET ";
                    sql += "Imagem = @Imagem ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Produto.ID);
                    cmd.Parameters.Add("@Imagem", SqlDbType.Binary, (int)Produto.Imagem.Length).Value = Produto.ArqByteArray;

                    conexao.Executa_Comando(cmd);
                }
                #endregion

                #region FORNECEDOR
                if (Produto.Fornecedor != null)
                    for (int i = 0; i <= Produto.Fornecedor.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        if (Produto.Fornecedor[i].ID == 0)
                        {
                            sql = "INSERT INTO Produto_Fornecedor ";
                            sql += "(ID_Produto, ID_Fornecedor, Codigo_Produto) ";
                            sql += "VALUES ";
                            sql += "(@ID_Produto, @ID_Fornecedor, @Codigo_Produto) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                            cmd.Parameters.AddWithValue("@ID_Fornecedor", Produto.Fornecedor[i].ID_Fornecedor);
                            cmd.Parameters.AddWithValue("@Codigo_Produto", Produto.Fornecedor[i].Codigo_Produto);
                        }
                        else
                        {
                            sql = "UPDATE Produto_Fornecedor SET ";
                            sql += "ID_Fornecedor = @ID_Fornecedor, ";
                            sql += "Codigo_Produto = @Codigo_Produto ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Produto.Fornecedor[i].ID);
                            cmd.Parameters.AddWithValue("@ID_Fornecedor", Produto.Fornecedor[i].ID_Fornecedor);
                            cmd.Parameters.AddWithValue("@Codigo_Produto", Produto.Fornecedor[i].Codigo_Produto);
                        }

                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region VALOR
                if (Produto.Valor != null)
                    for (int i = 0; i <= Produto.Valor.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        if (Produto.Valor[i].ID == 0)
                        {
                            sql = "INSERT INTO Produto_Valor ";
                            sql += "(ID_Produto, ID_Tabela, UltimoReajuste, MargemVenda, ValorVenda) ";
                            sql += "VALUES ";
                            sql += "(@ID_Produto, @ID_Tabela, @UltimoReajuste, @MargemVenda, @ValorVenda) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                            cmd.Parameters.AddWithValue("@ID_Tabela", Produto.Valor[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@UltimoReajuste", Produto.Valor[i].UltimoReajuste);
                            cmd.Parameters.AddWithValue("@MargemVenda", Produto.Valor[i].MargemVenda);
                            cmd.Parameters.AddWithValue("@ValorVenda", Produto.Valor[i].ValorVenda);
                        }
                        else
                        {
                            sql = "UPDATE Produto_Valor SET ";
                            sql += "UltimoReajuste = @UltimoReajuste, ";
                            sql += "MargemVenda = @MargemVenda, ";
                            sql += "ValorVenda = @ValorVenda ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Produto.Valor[i].ID);
                            cmd.Parameters.AddWithValue("@UltimoReajuste", Produto.Valor[i].UltimoReajuste);
                            cmd.Parameters.AddWithValue("@MargemVenda", Produto.Valor[i].MargemVenda);
                            cmd.Parameters.AddWithValue("@ValorVenda", Produto.Valor[i].ValorVenda);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region COMISSÃO
                if (Produto.Comissao != null)
                    for (int i = 0; i <= Produto.Comissao.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        if (Produto.Comissao[i].ID == 0)
                        {
                            sql = "INSERT INTO Produto_Comissao ";
                            sql += "(ID_Produto, ID_Usuario, ID_TipoComissao, Comissao) ";
                            sql += "VALUES ";
                            sql += "(@ID_Produto, @ID_Usuario, @ID_TipoComissao, @Comissao) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                            cmd.Parameters.AddWithValue("@ID_Usuario", Produto.Comissao[i].ID_Usuario);
                            cmd.Parameters.AddWithValue("@ID_TipoComissao", Produto.Comissao[i].ID_TipoComissao);
                            cmd.Parameters.AddWithValue("@Comissao", Produto.Comissao[i].Comissao);
                        }
                        else
                        {
                            sql = "UPDATE Produto_Comissao SET ";
                            sql += "ID_TipoComissao = @ID_TipoComissao, ";
                            sql += "Comissao = @Comissao ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Produto.Comissao[i].ID);
                            cmd.Parameters.AddWithValue("@ID_TipoComissao", Produto.Comissao[i].ID_TipoComissao);
                            cmd.Parameters.AddWithValue("@Comissao", Produto.Comissao[i].Comissao);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region ESTOQUE
                if (Produto.Estoque != null)
                    for (int i = 0; i <= Produto.Estoque.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        if (Produto.Estoque[i].ID == 0)
                        {
                            sql = "INSERT INTO Produto_Estoque ";
                            sql += "(ID_Produto, ID_Empresa, ID_Grade, EstoqueAtual, EstoqueIdeal, EstoqueMinimo, Localizacao) ";
                            sql += "VALUES ";
                            sql += "(@ID_Produto, @ID_Empresa, @ID_Grade, @EstoqueAtual, @EstoqueIdeal, @EstoqueMinimo, @Localizacao) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                            cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                            cmd.Parameters.AddWithValue("@ID_Grade", Produto.Estoque[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@EstoqueAtual", Produto.Estoque[i].Estoque_Atual);
                            cmd.Parameters.AddWithValue("@EstoqueIdeal", Produto.Estoque[i].Estoque_Ideal);
                            cmd.Parameters.AddWithValue("@EstoqueMinimo", Produto.Estoque[i].Estoque_Minimo);
                            cmd.Parameters.AddWithValue("@Localizacao", Produto.Estoque[i].Localizacao);
                        }
                        else
                        {
                            sql = "UPDATE Produto_Estoque SET ";
                            sql += "EstoqueAtual = @EstoqueAtual, ";
                            sql += "EstoqueIdeal = @EstoqueIdeal, ";
                            sql += "EstoqueMinimo = @EstoqueMinimo, ";
                            sql += "Localizacao = @Localizacao ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Produto.Estoque[i].ID);
                            cmd.Parameters.AddWithValue("@ID_Grade", Produto.Estoque[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@EstoqueAtual", Produto.Estoque[i].Estoque_Atual);
                            cmd.Parameters.AddWithValue("@EstoqueIdeal", Produto.Estoque[i].Estoque_Ideal);
                            cmd.Parameters.AddWithValue("@EstoqueMinimo", Produto.Estoque[i].Estoque_Minimo);
                            cmd.Parameters.AddWithValue("@Localizacao", Produto.Estoque[i].Localizacao);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region ESTRUTURA
                if (Produto.Estrutura != null)
                    for (int i = 0; i <= Produto.Estrutura.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        if (Produto.Estrutura[i].ID == 0)
                        {
                            sql = "INSERT INTO Produto_Estrutura ";
                            sql += "(ID_Produto, ID_Produto_Estrutura, ID_Grade_Estrutura, Quantidade) ";
                            sql += "VALUES ";
                            sql += "(@ID_Produto, @ID_Produto_Estrutura, @ID_Grade_Estrutura, @Quantidade) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto_Estrutura", Produto.Estrutura[i].ID_Produto_Estrutura);
                            cmd.Parameters.AddWithValue("@ID_Grade_Estrutura", Produto.Estrutura[i].ID_Grade_Estrutura);
                            cmd.Parameters.AddWithValue("@Quantidade", Produto.Estrutura[i].Quantidade);
                        }
                        else
                        {
                            sql = "UPDATE Produto_Estrutura SET ";
                            sql += "ID_Produto_Estrutura = @ID_Produto_Estrutura, ";
                            sql += "ID_Grade_Estrutura = @ID_Grade_Estrutura, ";
                            sql += "Quantidade = @Quantidade ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Produto.Estrutura[i].ID);
                            cmd.Parameters.AddWithValue("@ID_Produto_Estrutura", Produto.Estrutura[i].ID_Produto_Estrutura);
                            cmd.Parameters.AddWithValue("@ID_Grade_Estrutura", Produto.Estrutura[i].ID_Grade_Estrutura);
                            cmd.Parameters.AddWithValue("@Quantidade", Produto.Estrutura[i].Quantidade);
                        }
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region PARAMETROS
                cmd = new SqlCommand();

                sql = "UPDATE Produto_Parametro SET ";
                sql += "ID_Imposto = @ID_Imposto, ";
                sql += "Ativo = @Ativo ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID_Produto ";
                sql += "AND ID_Empresa = @ID_Empresa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                cmd.Parameters.AddWithValue("@ID_Imposto", Produto.ID_Imposto);
                cmd.Parameters.AddWithValue("@Ativo", Produto.Ativo);

                conexao.Executa_Comando(cmd);
                #endregion

                conexao.Commit_Conexao();

                return Produto.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Produto_Servico ";
                int aux_ID = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Produto_Servico, RESEED, " + aux_ID + ")";
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

        public void Grava_NovaEmpresa()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                DataTable _DT = new DataTable();
                DataTable _DT_Estoque = new DataTable();



                sql = "SELECT ID FROM Produto_Servico ";
                _DT = conexao.Consulta(sql);

                sql = "SELECT ID_Produto, ID_Grade FROM Produto_Estoque ";
                _DT_Estoque = conexao.Consulta(sql);

                conexao.Begin_Conexao();

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    cmd = new SqlCommand();

                    sql = "INSERT INTO Produto_Parametro ";
                    sql += "(ID_Produto, ID_Empresa, ID_Imposto, Ativo) ";
                    sql += "VALUES ";
                    sql += "(@ID_Produto, @ID_Empresa, @ID_Imposto, @Ativo) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Produto", _DT.Rows[i]["ID"]);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Imposto", 0);
                    cmd.Parameters.AddWithValue("@Ativo", Produto.Ativo);

                    conexao.Executa_Comando(cmd);
                }

                for (int i = 0; i <= _DT_Estoque.Rows.Count - 1; i++)
                {
                    cmd = new SqlCommand();

                    sql = "INSERT INTO Produto_Estoque ";
                    sql += "(ID_Produto, ID_Empresa, ID_Grade, EstoqueAtual, EstoqueIdeal, EstoqueMinimo, Localizacao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Produto, @ID_Empresa, @ID_Grade, @EstoqueAtual, @EstoqueIdeal, @EstoqueMinimo, @Localizacao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Produto", _DT_Estoque.Rows[i]["ID_Produto"]);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Grade", _DT_Estoque.Rows[i]["ID_Grade"]);
                    cmd.Parameters.AddWithValue("@EstoqueAtual", 0);
                    cmd.Parameters.AddWithValue("@EstoqueIdeal", 0);
                    cmd.Parameters.AddWithValue("@EstoqueMinimo", 0);
                    cmd.Parameters.AddWithValue("@Localizacao", "");

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

        public void Grava_Estoque()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Produto_Estoque SET ";
                sql += "EstoqueAtual = @Estoque ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID_Produto ";
                sql += "AND ID_Grade = @ID_Grade ";
                sql += "AND ID_Empresa = @ID_Empresa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Estoque", Produto.Estoque[0].Estoque_Atual);
                cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                cmd.Parameters.AddWithValue("@ID_Grade", Produto.Estoque[0].ID_Grade);
                cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);

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

        public void Grava_Produto_Fornecedor()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "INSERT INTO Produto_Fornecedor ";
                sql += "(ID_Produto, ID_Fornecedor, Codigo_Produto) ";
                sql += "VALUES ";
                sql += "(@ID_Produto, @ID_Fornecedor, @Codigo_Produto) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                cmd.Parameters.AddWithValue("@ID_Fornecedor", Produto.Fornecedor[0].ID_Fornecedor);
                cmd.Parameters.AddWithValue("@Codigo_Produto", Produto.Fornecedor[0].Codigo_Produto);

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

        public void Grava_Imposto()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Produto_Parametro SET ";
                sql += "ID_Imposto = @ID_Imposto ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID_Produto ";
                sql += "AND ID_Empresa = @ID_Empresa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Imposto", Produto.ID_Imposto);
                cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);

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

        public void Grava_Desconto()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                if (Produto.ID_Desconto == 0)
                {
                    sql = "INSERT INTO Produto_Desconto ";
                    sql += "(ID_Empresa, ID_Produto, Quantidade_Minima, Quantidade_Maxima, Desconto) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @ID_Produto, @Quantidade_Minima, @Quantidade_Maxima, @Desconto) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                    cmd.Parameters.AddWithValue("@Quantidade_Minima", Produto.Quantidade_Minima);
                    cmd.Parameters.AddWithValue("@Quantidade_Maxima", Produto.Quantidade_Maxima);
                    cmd.Parameters.AddWithValue("@Desconto", Produto.Desconto);

                    conexao.Executa_Comando(cmd);
                }
                else
                {
                    sql = "UPDATE Produto_Desconto SET ";
                    sql += "ID_Produto = @ID_Produto, ";
                    sql += "Quantidade_Minima = @Quantidade_Minima, ";
                    sql += "Quantidade_Maxima = @Quantidade_Maxima, ";
                    sql += "Desconto = @Desconto ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                    cmd.Parameters.AddWithValue("@Quantidade_Minima", Produto.Quantidade_Minima);
                    cmd.Parameters.AddWithValue("@Quantidade_Maxima", Produto.Quantidade_Maxima);
                    cmd.Parameters.AddWithValue("@Desconto", Produto.Desconto);
                    cmd.Parameters.AddWithValue("@ID", Produto.ID_Desconto);
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

        public void Grava_Desconto_Pessoa()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                for (int i = 0; i <= Produto.Desconto_Pessoa.Count - 1; i++)
                {
                    cmd = new SqlCommand();

                    if (Produto.Desconto_Pessoa[i].ID == 0)
                    {
                        sql = "INSERT INTO Produto_Desconto_Pessoa ";
                        sql += "(ID_Empresa, ID_Produto, TipoPessoa, ID_Pessoa, Tipo, Desconto) ";
                        sql += "VALUES ";
                        sql += "(@ID_Empresa, @ID_Produto, @TipoPessoa, @ID_Pessoa, @Tipo, @Desconto) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                        cmd.Parameters.AddWithValue("@TipoPessoa", Produto.TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", Produto.ID_Pessoa);
                        cmd.Parameters.AddWithValue("@ID_Produto", Produto.Desconto_Pessoa[i].ID_Produto);
                        cmd.Parameters.AddWithValue("@Tipo", Produto.Desconto_Pessoa[i].Tipo);
                        cmd.Parameters.AddWithValue("@Desconto", Produto.Desconto_Pessoa[i].Desconto);

                        conexao.Executa_Comando(cmd);
                    }
                    else
                    {
                        sql = "UPDATE Produto_Desconto_Pessoa SET ";
                        sql += "Tipo = @Tipo, ";
                        sql += "Desconto = @Desconto ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", Produto.Desconto_Pessoa[i].ID);
                        cmd.Parameters.AddWithValue("@Tipo", Produto.Desconto_Pessoa[i].Tipo);
                        cmd.Parameters.AddWithValue("@Desconto", Produto.Desconto_Pessoa[i].Desconto);
                        conexao.Executa_Comando(cmd);
                    }
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

        public void Grava_MovimentoProduto()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "INSERT INTO Produto_Movimento ";
                sql += "(ID_Empresa, Data, ID_Produto, Tipo, Quantidade, Informacao) ";
                sql += "VALUES ";
                sql += "(@ID_Empresa, @Data, @ID_Produto, @Tipo, @Quantidade, @Informacao) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                cmd.Parameters.AddWithValue("@Data", Produto.Data);
                cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                cmd.Parameters.AddWithValue("@Tipo", Produto.Tipo_Movimento);
                cmd.Parameters.AddWithValue("@Quantidade", Produto.Quantidade);
                cmd.Parameters.AddWithValue("@Informacao", Produto.Informacao);

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

        public void Atualiza_Estoque()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "Tipo, Controle_Estoque ";
                sql += "FROM Produto_Servico ";
                sql += "WHERE ID = " + Produto.ID + " ";

                DataTable _DT = new DataTable();
                _DT = conexao.Consulta(sql);

                Produto.Controle_Estoque = Convert.ToBoolean(_DT.Rows[0]["Controle_Estoque"]);
                Produto.Tipo = _DT.Rows[0]["Tipo"].ToString();

                if (Produto.Controle_Estoque == true)
                    switch (Convert.ToInt32(Produto.Tipo))
                    {
                        case 5: //KIT
                            sql = "SELECT ";
                            sql += "ID_Produto_Estrutura, ID_Grade_Estrutura, Quantidade ";
                            sql += "FROM Produto_Estrutura ";
                            sql += "WHERE ID_Produto = " + Produto.ID + " ";

                            _DT = new DataTable();
                            _DT = conexao.Consulta(sql);

                            conexao.Begin_Conexao();

                            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            {
                                cmd = new SqlCommand();

                                sql = "UPDATE ";
                                sql += "Produto_Estoque SET ";
                                sql += "EstoqueAtual = (EstoqueAtual - @Estoque) ";
                                sql += "WHERE ";
                                sql += "ID_Produto = @ID_Produto ";
                                sql += "AND ID_Grade = @ID_Grade ";
                                sql += "AND ID_Empresa = @ID_Empresa ";

                                cmd.CommandText = sql;
                                cmd.Parameters.AddWithValue("@Estoque", (Convert.ToDouble(_DT.Rows[i]["Quantidade"]) * Produto.Estoque[0].Estoque_Atual));
                                cmd.Parameters.AddWithValue("@ID_Produto", _DT.Rows[i]["ID_Produto_Estrutura"]);
                                cmd.Parameters.AddWithValue("@ID_Grade", _DT.Rows[i]["ID_Grade_Estrutura"]);
                                cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);

                                conexao.Executa_Comando(cmd);

                                cmd = new SqlCommand();

                                sql = "INSERT INTO Produto_Movimento ";
                                sql += "(ID_Empresa, Data, ID_Produto, Tipo, Quantidade, Informacao) ";
                                sql += "VALUES ";
                                sql += "(@ID_Empresa, @Data, @ID_Produto, @Tipo, @Quantidade, @Informacao) ";
                                cmd.CommandText = sql;
                                cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);
                                cmd.Parameters.AddWithValue("@Data", DateTime.Now);
                                cmd.Parameters.AddWithValue("@ID_Produto", _DT.Rows[i]["ID_Produto_Estrutura"]);
                                cmd.Parameters.AddWithValue("@Tipo", Produto.Tipo_Movimento);
                                cmd.Parameters.AddWithValue("@Quantidade", (Convert.ToDouble(_DT.Rows[i]["Quantidade"]) * Produto.Estoque[0].Estoque_Atual));
                                cmd.Parameters.AddWithValue("@Informacao", Produto.Informacao);

                                conexao.Executa_Comando(cmd);
                            }
                            conexao.Commit_Conexao();
                            break;

                        case 1: //PRODUTO VENDA
                        case 2: //MATÉRIA PRIMA
                        case 4: //IMOBILIZADO
                            conexao.Begin_Conexao();
                            cmd = new SqlCommand();

                            sql = "UPDATE ";
                            sql += "Produto_Estoque SET ";

                            if (Produto.Estoque[0].Adiciona == true)
                                sql += "EstoqueAtual = (EstoqueAtual + @Estoque) ";
                            else
                                sql += "EstoqueAtual = (EstoqueAtual - @Estoque) ";

                            sql += "WHERE ";
                            sql += "ID_Produto = @ID_Produto ";
                            sql += "AND ID_Grade = @ID_Grade ";
                            sql += "AND ID_Empresa = @ID_Empresa ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Estoque", Produto.Estoque[0].Estoque_Atual);
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                            cmd.Parameters.AddWithValue("@ID_Grade", Produto.Estoque[0].ID_Grade);
                            cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);

                            conexao.Executa_Comando(cmd);
                            conexao.Commit_Conexao();
                            break;
                    }
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

        public void Atualiza_Valor()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Produto_Servico SET ";
                sql += "ValorCompra = @ValorCompra, ";
                sql += "OutrosCustos = @OutrosCustos, ";
                sql += "ValorIPI = @ValorIPI, ";
                sql += "ValorST = @ValorST, ";
                sql += "CustoFinal = @CustoFinal ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto.ID);
                cmd.Parameters.AddWithValue("@ValorCompra", Produto.ValorCompra);
                cmd.Parameters.AddWithValue("@ValorIPI", Produto.ValorIPI);
                cmd.Parameters.AddWithValue("@ValorST", Produto.ValorST);
                cmd.Parameters.AddWithValue("@OutrosCustos", Produto.OutrosCustos);
                cmd.Parameters.AddWithValue("@CustoFinal", Produto.CustoFinal);

                conexao.Executa_Comando(cmd);

                #region VALOR DE VENDA
                if (Produto.Valor.Count > 0)
                    for (int i = 0; i <= Produto.Valor.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        if (Produto.Valor[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Produto_Valor ";
                            sql += "(ID_Produto, ID_Tabela, UltimoReajuste, MargemVenda, ValorVenda) ";
                            sql += "VALUES ";
                            sql += "(@ID_Produto, @ID_Tabela, @UltimoReajuste, @MargemVenda, @ValorVenda) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                            cmd.Parameters.AddWithValue("@ID_Tabela", Produto.Valor[i].ID_Tabela);
                            cmd.Parameters.AddWithValue("@UltimoReajuste", Produto.Valor[i].UltimoReajuste);
                            cmd.Parameters.AddWithValue("@MargemVenda", Produto.Valor[i].MargemVenda);
                            cmd.Parameters.AddWithValue("@ValorVenda", Produto.Valor[i].ValorVenda);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Produto_Valor SET ";
                            sql += "UltimoReajuste = @UltimoReajuste, ";
                            sql += "MargemVenda = @MargemVenda, ";
                            sql += "ValorVenda = @ValorVenda ";
                            sql += "WHERE ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Produto.Valor[i].ID);
                            cmd.Parameters.AddWithValue("@UltimoReajuste", Produto.Valor[i].UltimoReajuste);
                            cmd.Parameters.AddWithValue("@MargemVenda", Produto.Valor[i].MargemVenda);
                            cmd.Parameters.AddWithValue("@ValorVenda", Produto.Valor[i].ValorVenda);
                        }
                        conexao.Executa_Comando(cmd);
                    }
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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Ativo, Tipo, ID_Empresa, ID, ID AS ID_Produto, ID_Grupo, Cod_Grupo, DescricaoGrupo, ";

                if (Produto.ConsultaMarca == true)
                    sql += "Descricao + ' ' + Fabricante AS Descricao, ";
                else
                    sql += "Descricao, ";

                sql += "Referencia, Fabricante, Informacao, Barra, BarraTributavel, NCM, Imagem, ValorCompra, OutrosCustos, ValorIPI, ValorST, CustoFinal, UnidadeTributavel, ";
                sql += "Validade, Garantia, EX_TIPI, CNPJProdutor, ClasseEnquadramento, Cod_ANP, ProdutoEspecifico, ";
                sql += "PesoB, PesoL, DescricaoUnidade, ID_Imposto, DescricaoImposto, Controle_Estoque, InfoAdicional1, InfoAdicional2, ABC, ID_CEST ";
                sql += "FROM ";
                sql += "V_Produto_Servico ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                sql += "AND ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.ID > 0)
                    sql += "AND ID = " + Produto.ID + " ";

                if (Produto.Consulta_Tipo == true &&
                    Produto.Tipo != string.Empty)
                    sql += "AND Tipo IN (" + Produto.Tipo + ") ";

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Consulta_Ativo == true)
                    sql += "AND Ativo = '" + Produto.Ativo + "' ";

                if (Produto.Referencia != string.Empty)
                    if (Produto.Consulta_Referencia == true)
                        sql += "AND Referencia = '" + Produto.Referencia + "' ";
                    else
                        sql += "AND Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND Barra = '" + Produto.Barra + "' ";

                if (Produto.Fabricante != string.Empty)
                    sql += "AND Fabricante LIKE '" + Produto.Fabricante + "%' ";

                if (Produto.NCM != string.Empty)
                    sql += "AND NCM LIKE '" + Produto.NCM + "%' ";

                if (Produto.InfoAdicional1 != string.Empty)
                    sql += "AND InfoAdicional1 LIKE '" + Produto.InfoAdicional1 + "%' ";

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

        public DataTable Busca_PDV()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Ativo, Tipo, ID_Empresa, ID, ID AS ID_Produto, ID_Grupo, Cod_Grupo, DescricaoGrupo, Descricao, Referencia, Fabricante, ";
                sql += "Informacao, Barra, BarraTributavel, NCM, Imagem, ValorCompra, OutrosCustos, ValorIPI, ValorST, CustoFinal, UnidadeTributavel, ";
                sql += "Validade, Garantia, EX_TIPI, CNPJProdutor, ClasseEnquadramento, Cod_ANP, ProdutoEspecifico, ";
                sql += "PesoB, PesoL, DescricaoUnidade, ID_Imposto, DescricaoImposto, Controle_Estoque, InfoAdicional1, InfoAdicional2, ABC, ID_CEST ";
                sql += "FROM ";
                sql += "V_Produto_Servico ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                sql += "AND ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.Consulta_Tipo == true &&
                    Produto.Tipo != string.Empty)
                    sql += "AND Tipo IN (" + Produto.Tipo + ") ";

                sql += "AND ID = " + Produto.Consulta_PDV + " ";
                sql += "OR Barra = '" + Produto.Consulta_PDV + "' ";

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

        public DataTable Busca_Venda()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM ";
                sql += "V_Produto_Venda ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Empresa = " + Produto.ID_Empresa + " ";
                sql += "AND ID_Tabela = " + Produto.ID_Tabela + " ";

                if (Produto.Consulta_Tipo == true &&
                    Produto.Tipo != string.Empty)
                    sql += "AND Tipo IN (" + Produto.Tipo + ") ";

                if (Produto.ID > 0)
                    sql += "AND ID = " + Produto.ID + " ";

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Consulta_Ativo == true)
                    sql += "AND Ativo = '" + Produto.Ativo + "' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND Barra = '" + Produto.Barra + "' ";

                if (Produto.Fabricante != string.Empty)
                    sql += "AND Fabricante LIKE '" + Produto.Fabricante + "%' ";

                if (Produto.InfoAdicional1 != string.Empty)
                    sql += "AND InfoAdicional1 LIKE '" + Produto.InfoAdicional1 + "%' ";

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

        public DataTable Busca_AlteraValor()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID AS ID_Produto, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, ";
                sql += "P.ValorCompra, P.OutrosCustos, P.ValorIPI, P.ValorST, P.CustoFinal, ";
                sql += "PV.ID AS ID_Tabela, PV.ValorVenda, PV.MargemVenda ";
                sql += "FROM ";
                sql += "Produto_Servico AS P ";
                sql += "LEFT JOIN Produto_Valor AS PV ON PV.ID_Produto = P.ID ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";

                if (Produto.ID > 0)
                    sql += "AND P.ID = " + Produto.ID + " ";

                if (Produto.ID_Tabela > 0)
                    sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND P.Referencia = '" + Produto.Referencia + "'";

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

        public DataTable Busca_Etiqueta()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                switch (Produto.Consulta_Etiqueta)
                {
                    #region ETIQUETA PRODUTO AVULSO
                    case 1:
                        sql = "SELECT ";
                        sql += "P.ID, P.Descricao, P.Barra, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                        sql += "PV.ValorVenda, ";
                        sql += "REPLICATE('0', 6 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(P.ID_Empresa AS Varchar))) + CAST(P.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, 0 AS Quantidade ";
                        sql += "FROM ";
                        sql += "V_Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = P.ID_Empresa ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "WHERE ";
                        sql += "NOT P.ID IS NULL ";
                        sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";
                        sql += "AND P.ID_Empresa = " + Produto.ID_Empresa + " ";

                        if (Produto.Consulta_Tipo == true &&
                            Produto.Tipo != string.Empty)
                            sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                        if (Produto.ID > 0)
                            sql += "AND P.ID = " + Produto.ID + " ";

                        if (Produto.ListaID != string.Empty)
                            sql += "AND P.ID IN (" + Produto.ListaID + ") ";

                        if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                            sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                        if (Produto.Descricao != string.Empty)
                            sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                        if (Produto.Referencia != string.Empty)
                            sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                        if (Produto.Barra != string.Empty)
                            sql += "AND P.Barra = '" + Produto.Barra + "' ";

                        if (Produto.Consulta_Ativo == true)
                            sql += "AND P.Ativo = '" + Produto.Ativo + "' ";


                        sql += "ORDER BY P.Descricao ";
                        break;
                    #endregion

                    #region ETIQUETA PRODUTO ENTRADA
                    case 2:
                        sql = "SELECT ";
                        sql += "P.ID, P.Descricao, P.Barra, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                        sql += "PV.ValorVenda, ";
                        sql += "REPLICATE('0', 6 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(P.ID_Empresa AS Varchar))) + CAST(P.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, CI.Quantidade AS Quantidade ";
                        sql += "FROM ";
                        sql += "Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "INNER JOIN Produto_Entrada_Item AS CI ON CI.ID_Produto = P.ID ";
                        sql += "WHERE ";
                        sql += "NOT P.ID IS NULL ";
                        sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";

                        if (Produto.Consulta_Tipo == true &&
                            Produto.Tipo != string.Empty)
                            sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                        if (Produto.ID > 0)
                            sql += "AND P.ID = " + Produto.ID + " ";

                        if (Produto.ID_Produto_Entrada > 0)
                            sql += "AND CI.ID_Produto_Entrada = " + Produto.ID_Produto_Entrada + " ";

                        if (Produto.ListaID != string.Empty)
                            sql += "AND P.ID IN (" + Produto.ListaID + ") ";

                        if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                            sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                        if (Produto.Descricao != string.Empty)
                            sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                        if (Produto.Referencia != string.Empty)
                            sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                        if (Produto.Barra != string.Empty)
                            sql += "AND P.Barra = '" + Produto.Barra + "' ";

                        if (Produto.Consulta_Ativo == true)
                            sql += "AND PP.Ativo = '" + Produto.Ativo + "' ";

                        sql += "AND PP.ID_Empresa = " + Produto.ID_Empresa + " ";

                        sql += "ORDER BY P.Descricao ";
                        break;
                    #endregion

                    #region ETIQUETA PRODUTO ESTOQUE
                    case 3:
                        sql = "SELECT ";
                        sql += "P.ID, P.Descricao, P.Barra, P.InfoAdicional1, P.InfoAdicional2, P.ABC,  ";
                        sql += "PV.ValorVenda, ";
                        sql += "REPLICATE('0', 6 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(P.ID_Empresa AS Varchar))) + CAST(P.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, PE.EstoqueAtual AS Quantidade ";
                        sql += "FROM ";
                        sql += "Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "WHERE ";
                        sql += "NOT P.ID IS NULL ";
                        sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";

                        if (Produto.Consulta_Tipo == true &&
                            Produto.Tipo != string.Empty)
                            sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                        if (Produto.ID > 0)
                            sql += "AND P.ID = " + Produto.ID + " ";

                        if (Produto.ListaID != string.Empty)
                            sql += "AND P.ID IN (" + Produto.ListaID + ") ";

                        if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                            sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                        if (Produto.Descricao != string.Empty)
                            sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                        if (Produto.Referencia != string.Empty)
                            sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                        if (Produto.Barra != string.Empty)
                            sql += "AND P.Barra = '" + Produto.Barra + "' ";

                        if (Produto.Consulta_Ativo == true)
                            sql += "AND PP.Ativo = '" + Produto.Ativo + "' ";

                        sql += "AND PP.ID_Empresa = " + Produto.ID_Empresa + " ";

                        sql += "ORDER BY P.Descricao ";
                        break;
                    #endregion

                    #region ETIQUETA PRODUTO ENTRADA QUANTIDADE ESTOQUE
                    case 4:
                        sql = "SELECT ";
                        sql += "P.ID, P.Descricao, P.Barra, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                        sql += "PV.ValorVenda, ";
                        sql += "REPLICATE('0', 6 - LEN(CAST(PE.ID_Produto AS Varchar))) + CAST(PE.ID_Produto AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) + CAST(PE.ID_Grade AS Varchar) + ";
                        sql += "REPLICATE('0', 2 - LEN(CAST(P.ID_Empresa AS Varchar))) + CAST(P.ID_Empresa AS Varchar) AS Barra_Etiqueta, ";
                        sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade, PE.EstoqueAtual AS Quantidade ";
                        sql += "FROM ";
                        sql += "Produto_Servico AS P ";
                        sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                        sql += "INNER JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto AND PE.ID_Empresa = PP.ID_Empresa ";
                        sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                        sql += "INNER JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                        sql += "INNER JOIN Produto_Entrada_Item AS CI ON CI.ID_Produto = P.ID ";
                        sql += "WHERE ";
                        sql += "NOT P.ID IS NULL ";
                        sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";

                        if (Produto.Consulta_Tipo == true &&
                            Produto.Tipo != string.Empty)
                            sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                        if (Produto.ID > 0)
                            sql += "AND P.ID = " + Produto.ID + " ";

                        if (Produto.ID_Produto_Entrada > 0)
                            sql += "AND CI.ID_Produto_Entrada = " + Produto.ID_Produto_Entrada + " ";

                        if (Produto.ListaID != string.Empty)
                            sql += "AND P.ID IN (" + Produto.ListaID + ") ";

                        if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                            sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                        if (Produto.Descricao != string.Empty)
                            sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                        if (Produto.Referencia != string.Empty)
                            sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                        if (Produto.Barra != string.Empty)
                            sql += "AND P.Barra = '" + Produto.Barra + "' ";

                        if (Produto.Consulta_Ativo == true)
                            sql += "AND PP.Ativo = '" + Produto.Ativo + "' ";

                        sql += "AND PP.ID_Empresa = " + Produto.ID_Empresa + " ";

                        sql += "ORDER BY P.Descricao ";
                        break;
                        #endregion
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

        public DataTable Busca_ResumoVenda()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID, P.Descricao, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                sql += "P.CustoFinal, ";
                sql += "PV.ValorVenda, SUM(PV.Quantidade) AS Quantidade, ";
                sql += "G.Descricao AS DescricaoGrade ";
                sql += "FROM ";
                sql += "V_Produto_Servico AS P ";
                sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                sql += "INNER JOIN Venda_Item AS PV ON P.ID = PV.ID_Produto ";
                sql += "INNER JOIN Grade AS G ON PV.ID_Grade = G.ID ";
                sql += "INNER JOIN Venda AS PE ON PV.ID_Venda = PE.ID ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";

                if (Produto.Consulta_Tipo == true &&
                 Produto.Tipo != string.Empty)
                    sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                if (Produto.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PE.Data) BETWEEN CONVERT(DATE, '" + Produto.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Produto.Consulta_Emissao.Final + "') ";

                if (Produto.ID > 0)
                    sql += "AND P.ID = " + Produto.ID + " ";

                if (Produto.ListaID != string.Empty)
                    sql += "AND P.ID IN (" + Produto.ListaID + ") ";

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND P.Barra = '" + Produto.Barra + "' ";

                sql += "AND PP.ID_Empresa = " + Produto.ID_Empresa + " ";
                sql += "GROUP BY P.ID, P.Descricao, P.CustoFinal, P.InfoAdicional1, P.InfoAdicional2, P.ABC, PV.ValorVenda, G.Descricao ";
                sql += "ORDER BY P.Descricao, G.Descricao ";

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

        public DataTable Busca_Valor()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID, P.Cod_Grupo, P.Descricao, P.Referencia, P.Fabricante, P.Informacao, P.Barra, P.BarraTributavel, P.NCM, ";
                sql += "P.ValorCompra, P.OutrosCustos, P.CustoFinal, P.ValorIPI, P.ValorST, P.UnidadeTributavel, P.Validade, P.Garantia, P.Ativo, P.CustoFinal, ";
                sql += "P.Referencia, P.InfoAdicional1, P.InfoAdicional2, ";
                sql += "PV.ID AS ID_Tabela_Produto_Valor, PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste, PV.ID_Tabela ";
                sql += "FROM ";
                sql += "V_Produto_Servico AS P ";
                sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND P.ID_Empresa = " + Produto.ID_Empresa + " ";
                sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";

                if (Produto.Consulta_Tipo == true &&
                    Produto.Tipo != string.Empty)
                    sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                if (Produto.ID > 0)
                    sql += "AND P.ID = " + Produto.ID + " ";

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.InfoAdicional1 != string.Empty)
                    sql += "AND P.InfoAdicional1 LIKE '" + Produto.InfoAdicional1 + "%' ";

                if (Produto.Fabricante != string.Empty)
                    sql += "AND P.Fabricante LIKE '" + Produto.Fabricante + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND P.Barra = '" + Produto.Barra + "' ";

                if (Produto.Consulta_Ativo == true)
                    sql += "AND P.Ativo = '" + Produto.Ativo + "' ";

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

        public DataTable Busca_Valor_Imposto()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM V_Produto_Imposto ";
                sql += "WHERE ";
                sql += "NOT ID_Produto IS NULL ";
                sql += "AND ID_Tabela = " + Produto.ID_Tabela + " ";
                sql += "AND Tipo IN (" + Produto.Tipo + ") ";
                sql += "AND ID_Produto = " + Produto.ID + " ";
                sql += "AND ID_Empresa = " + Produto.ID_Empresa + " ";
                sql += "AND ID_UF = " + Produto.ID_UF + " ";
                sql += "AND Tipo_NF = " + Produto.Tipo_NF + " ";
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

        public DataTable Busca_Rel_TabelaValor()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID, P.Descricao, P.Barra, P.NCM, P.DescricaoGrupo, ";
                sql += "PV.ValorVenda ";
                sql += "FROM ";
                sql += "V_Produto_Servico AS P ";
                sql += "INNER JOIN Produto_Parametro AS PP ON PP.ID_Produto = P.ID ";
                sql += "LEFT JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";

                if (Produto.Consulta_Tipo == true &&
                    Produto.Tipo != string.Empty)
                    sql += "AND Tipo IN (" + Produto.Tipo + ") ";

                if (Produto.ID > 0)
                    sql += "AND P.ID = " + Produto.ID;

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND P.Barra = '" + Produto.Barra + "' ";

                if (Produto.Consulta_Ativo == true)
                    sql += "AND P.Ativo = '" + Produto.Ativo + "' ";

                sql += "AND PP.ID_Empresa = " + Produto.ID_Empresa + " ";
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

        public DataTable Busca_Imposto()
        {
            conexao.Abre_Conexao();
            try
            {
                conexao.Abre_Conexao();

                if (Produto.ID_UF > 0 && Produto.CFOP != string.Empty)
                {
                    sql = "SELECT ";
                    sql += "PI.ID_Imposto, ";
                    sql += "P.ID, P.EX_TIPI, P.CNPJProdutor, P.ClasseEnquadramento, P.Cod_ANP, P.ProdutoEspecifico, P.CEST, ";
                    sql += "I.CFOP, I.CST, I.Origem, I.ModalidadeBC, I.AliquotaICMS, I.PercentualReducao, I.ModalidadeBCST, I.AliquotaICMSST, I.PercentualReducaoST, ";
                    sql += "I.MargemVAdicionado, I.CSTPIS, I.AliquotaPIS, I.AliquotaPISST, I.CSTCOFINS, I.AliquotaCOFINS, I.AliquotaCOFINSST, I.CSTIPI, I.AliquotaIPI, I.Cod_Enquadramento ";
                    sql += "FROM ";
                    sql += "V_Produto_Servico AS P ";
                    sql += "INNER JOIN Produto_Imposto AS PI ON P.ID = PI.ID_Produto ";
                    sql += "INNER JOIN ImpostoControle AS IC ON PI.ID_Imposto = IC.ID_Imposto AND IC.ID_UF = " + Produto.ID_UF + " AND CFOP = '" + Produto.CFOP + "' ";
                    sql += "INNER JOIN Imposto AS I ON PI.ID_Imposto = I.ID ";
                    sql += "WHERE ";
                    sql += "NOT P.ID IS NULL ";
                    sql += "AND P.ID = " + Produto.ID;

                    return conexao.Consulta(sql);
                }
                else
                {
                    sql = "SELECT DISTINCT ";
                    sql += "PI.ID_Imposto, ";
                    sql += "I.CFOP, I.CST, I.Origem, I.AliquotaICMS, I.Descricao ";
                    sql += "FROM ";
                    sql += "V_Produto_Servico AS P ";
                    sql += "INNER JOIN Produto_Imposto AS PI ON P.ID = PI.ID_Produto ";
                    sql += "INNER JOIN ImpostoControle AS IC ON PI.ID_Imposto = IC.ID_Imposto ";
                    sql += "INNER JOIN Imposto AS I ON PI.ID_Imposto = I.ID ";
                    sql += "WHERE ";
                    sql += "NOT P.ID IS NULL ";
                    sql += "AND P.ID = " + Produto.ID;

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

        public DataTable Busca_Fornecedor()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PF.Nome_Razao AS Descricao, ";
                sql += "P.ID, P.ID_Fornecedor, P.Codigo_Produto ";
                sql += "FROM ";
                sql += "Pessoa AS PF ";
                sql += "INNER JOIN Produto_Fornecedor AS P ON P.ID_Fornecedor = PF.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND P.ID_Produto = " + Produto.ID + " ";
                sql += "AND PF.TipoPessoa = 3 ";

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

        public DataTable Busca_Produto_Fornecedor()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.ID, P.Descricao, ";
                sql += "PE.ID_Grade, ";
                sql += "PV.MargemVenda, PV.ValorVenda ";
                sql += "FROM ";
                sql += "Produto_Servico AS P ";
                sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                sql += "INNER JOIN Produto_Fornecedor AS PF ON P.ID = PF.ID_Produto ";
                sql += "INNER JOIN Produto_Estoque AS PE ON P.ID = PE.ID_Produto ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND PE.ID_Empresa = " + Produto.ID_Empresa + " ";
                sql += "AND PF.ID_Fornecedor = " + Produto.Fornecedor[0].ID_Fornecedor + " ";
                sql += "AND PF.Codigo_Produto = '" + Produto.Fornecedor[0].Codigo_Produto + "' ";

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

        public DataTable Busca_TabelaValor()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "TV.Descricao, ";
                sql += "PV.ID, PV.ID_Tabela, PV.MargemVenda, PV.ValorVenda, PV.UltimoReajuste ";
                sql += "FROM ";
                sql += "Produto_Valor AS PV ";
                sql += "INNER JOIN TabelaValor AS TV ON TV.ID = PV.ID_Tabela ";
                sql += "WHERE ";
                sql += "NOT PV.ID IS NULL ";
                sql += "AND PV.ID_Produto = " + Produto.ID;

                if (Produto.ID_Tabela > 0)
                    sql += "AND PV.ID_Tabela = " + Produto.ID_Tabela + " ";

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

                if (Produto.ID == 0)
                {
                    sql = "SELECT ";
                    sql += "ID AS ID_Usuario, Descricao AS Usuario ";
                    sql += "FROM  Usuario ";
                    sql += "WHERE NOT ID IS NULL ";
                }
                else
                {
                    sql = "SELECT ";
                    sql += "PC.ID, PC.ID_TipoComissao, PC.Comissao, ";
                    sql += "CASE PC.ID_TipoComissao ";
                    sql += "WHEN 1 THEN 'VALOR' ";
                    sql += "WHEN 2 THEN 'PORCENTAGEM' ";
                    sql += "END AS TipoComissao, ";
                    sql += "U.ID AS ID_Usuario, U.Descricao AS Usuario ";
                    sql += "FROM Produto_Comissao AS PC ";
                    sql += "RIGHT JOIN Usuario AS U ON PC.ID_Usuario = U.ID AND PC.ID_Produto = " + Produto.ID + " ";
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

        public DataTable Busca_Estoque()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Produto ";
                sql += "FROM Produto_Estoque ";
                sql += "WHERE ";
                sql += "ID_Produto = " + Produto.ID;

                if (conexao.Consulta(sql).Rows.Count == 0)
                    return null;

                else
                {
                    sql = "SELECT ";
                    sql += "P.Tipo, ";
                    sql += "PE.ID, PE.ID_Produto, PE.Localizacao, ";
                    sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, ";

                    sql += "REPLICATE('0', 6 - LEN(CAST(P.ID AS Varchar))) + CAST(P.ID AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) ";
                    sql += "+ CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Empresa AS Varchar))) + CAST(PE.ID_Empresa AS Varchar) AS Cod_Interno, ";

                    sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade ";
                    sql += "FROM Produto_Estoque AS PE ";
                    sql += "INNER JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                    sql += "INNER JOIN Produto_Servico AS P ON P.ID = PE.ID_Produto ";
                    sql += "WHERE ";
                    sql += "PE.ID_Empresa = " + Produto.ID_Empresa + " ";
                    sql += "AND PE.ID_Produto = " + Produto.ID + " ";

                    if (Produto.Estoque != null && Produto.Estoque[0].ID_Grade > 0)
                        sql += "AND PE.ID_Grade = " + Produto.Estoque[0].ID_Grade + " ";
                    else if (Produto.ID_Grade > 0)
                        sql += "AND PE.ID_Grade = " + Produto.ID_Grade + " ";
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

        public DataTable Busca_Estoque_Simples()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "P.Tipo, P.Descricao, ";
                sql += "PE.ID, PE.ID_Produto, PE.Localizacao, ";
                sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, ";

                sql += "REPLICATE('0', 6 - LEN(CAST(P.ID AS Varchar))) + CAST(P.ID AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) ";
                sql += "+ CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Empresa AS Varchar))) + CAST(PE.ID_Empresa AS Varchar) AS Cod_Interno, ";

                sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade ";
                sql += "FROM Produto_Estoque AS PE ";
                sql += "INNER JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                sql += "INNER JOIN Produto_Servico AS P ON P.ID = PE.ID_Produto ";
                sql += "WHERE ";
                sql += "PE.ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.ID > 0)
                    sql += "AND PE.ID_Produto = " + Produto.ID + " ";

                if (Produto.Estoque != null && Produto.Estoque[0].ID_Grade > 0)
                    sql += "AND PE.ID_Grade = " + Produto.Estoque[0].ID_Grade + " ";
                else if (Produto.ID_Grade > 0)
                    sql += "AND PE.ID_Grade = " + Produto.ID_Grade + " ";

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

        public DataTable Busca_Estrutura()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PE.ID, PE.ID_Produto_Estrutura, PE.ID_Grade_Estrutura, PE.Quantidade, ";
                sql += "P.Descricao ";
                sql += "FROM Produto_Estrutura AS PE ";
                sql += "INNER JOIN Produto_Servico AS P ON P.ID = PE.ID_Produto_Estrutura ";
                sql += "WHERE ";
                sql += "PE.ID_Produto = " + Produto.ID + " ";

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

        public DataTable Busca_Rel_Estoque()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PE.ID, PE.ID_Produto, PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, ";

                sql += "REPLICATE('0', 6 - LEN(CAST(P.ID AS Varchar))) + CAST(P.ID AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) ";
                sql += "+ CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Empresa AS Varchar))) + CAST(PE.ID_Empresa AS Varchar) AS Cod_Interno, ";

                sql += "P.Descricao, P.Barra, P.Referencia, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade ";
                sql += "FROM Produto_Estoque AS PE ";
                sql += "INNER JOIN V_Produto_Servico AS P ON P.ID = PE.ID_Produto AND P.ID_Empresa = PE.ID_Empresa ";
                sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND P.ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.ID > 0)
                    sql += "AND PE.ID_Produto = " + Produto.ID + " ";

                if (Produto.Consulta_PDV != null &&
                    Produto.Consulta_PDV != string.Empty)
                {
                    sql += "AND P.ID = " + Produto.Consulta_PDV + " ";
                    sql += "OR P.Barra = '" + Produto.Consulta_PDV + "' ";
                }

                if (Produto.Consulta_Tipo == true &&
                    Produto.Tipo != string.Empty)
                    sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                if (Produto.Consulta_Ativo == true)
                    sql += "AND P.Ativo = '" + Produto.Ativo + "' ";

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND P.Barra = '" + Produto.Barra + "' ";

                if (Produto.Fabricante != string.Empty)
                    sql += "AND P.Fabricante LIKE '" + Produto.Fabricante + "%' ";

                if (Produto.InfoAdicional1 != string.Empty)
                    sql += "AND P.InfoAdicional1 LIKE '" + Produto.InfoAdicional1 + "%' ";

                sql += "ORDER BY P.Descricao, G.Descricao ";
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

        public DataTable Busca_Rel_Estoque_Coletor()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PE.ID, PE.ID_Produto, PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, ";

                sql += "REPLICATE('0', 6 - LEN(CAST(P.ID AS Varchar))) + CAST(P.ID AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Grade AS Varchar))) ";
                sql += "+ CAST(PE.ID_Grade AS Varchar) + REPLICATE('0', 2 - LEN(CAST(PE.ID_Empresa AS Varchar))) + CAST(PE.ID_Empresa AS Varchar) AS Cod_Interno, ";

                sql += "P.Descricao, P.Barra, P.Referencia, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade ";
                sql += "FROM Produto_Estoque AS PE ";
                sql += "INNER JOIN V_Produto_Servico AS P ON P.ID = PE.ID_Produto AND P.ID_Empresa = PE.ID_Empresa ";
                sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND P.ID_Empresa = " + Produto.ID_Empresa + " ";

                sql += "AND P.ID NOT IN (" + Produto.ListaID + ") ";

                if (Produto.ConsultaInversa == false)
                {
                    if (Produto.ID > 0)
                        sql += "AND PE.ID_Produto = " + Produto.ID + " ";

                    if (Produto.Consulta_PDV != null &&
                        Produto.Consulta_PDV != string.Empty)
                    {
                        sql += "AND P.ID = " + Produto.Consulta_PDV + " ";
                        sql += "OR P.Barra = '" + Produto.Consulta_PDV + "' ";
                    }

                    if (Produto.Consulta_Tipo == true &&
                        Produto.Tipo != string.Empty)
                        sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                    if (Produto.Consulta_Ativo == true)
                        sql += "AND P.Ativo = '" + Produto.Ativo + "' ";

                    if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                        sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                    if (Produto.Descricao != string.Empty)
                        sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                    if (Produto.Referencia != string.Empty)
                        sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                    if (Produto.Barra != string.Empty)
                        sql += "AND P.Barra = '" + Produto.Barra + "' ";

                    if (Produto.Fabricante != string.Empty)
                        sql += "AND P.Fabricante LIKE '" + Produto.Fabricante + "%' ";
                }
                else
                {
                    if (Produto.ID > 0)
                        sql += "AND PE.ID_Produto <> " + Produto.ID + " ";

                    if (Produto.Consulta_PDV != null &&
                        Produto.Consulta_PDV != string.Empty)
                    {
                        sql += "AND P.ID <> " + Produto.Consulta_PDV + " ";
                        sql += "OR P.Barra <> '" + Produto.Consulta_PDV + "' ";
                    }

                    if (Produto.Consulta_Tipo == true &&
                        Produto.Tipo != string.Empty)
                        sql += "AND P.Tipo IN (" + Produto.Tipo + ") ";

                    if (Produto.Consulta_Ativo == true)
                        sql += "AND P.Ativo = '" + Produto.Ativo + "' ";

                    if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                        sql += "AND P.Cod_Grupo NOT LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                    if (Produto.Descricao != string.Empty)
                        sql += "AND P.Descricao NOT LIKE '" + Produto.Descricao + "%' ";

                    if (Produto.Referencia != string.Empty)
                        sql += "AND P.Referencia NOT LIKE '%" + Produto.Referencia + "%' ";

                    if (Produto.Barra != string.Empty)
                        sql += "AND P.Barra <> '" + Produto.Barra + "' ";

                    if (Produto.Fabricante != string.Empty)
                        sql += "AND P.Fabricante NOT LIKE '" + Produto.Fabricante + "%' ";
                }

                sql += "ORDER BY P.Descricao, G.Descricao ";
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

        public DataTable Busca_Estoque_Vlr()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PE.ID, PE.ID_Produto, ";
                sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, PE.EstoqueAtual, ";
                sql += "P.Descricao, P.CustoFinal, P.Barra, P.NCM, P.Referencia, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                sql += "P.DescricaoUnidade, ";
                sql += "PV.ValorVenda, ";
                sql += "TV.Descricao AS DescricaoTabelaValor, ";
                sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade ";
                sql += "FROM Produto_Estoque AS PE ";
                sql += "INNER JOIN V_Produto_Servico AS P ON P.ID = PE.ID_Produto AND P.ID_Empresa = PE.ID_Empresa ";
                sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                sql += "INNER JOIN TabelaValor AS TV ON PV.ID_Tabela = TV.ID ";
                sql += "LEFT JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND P.ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.ID_Tabela > 0)
                    sql += "AND TV.ID = " + Produto.ID_Tabela + " ";

                if (Produto.ID > 0)
                    sql += "AND PE.ID_Produto = " + Produto.ID + " ";

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND P.Barra LIKE '%" + Produto.Barra + "%' ";

                if (Produto.Consulta_EstoqueCritico == true)
                    sql += "AND PE.EstoqueAtual < PE.EstoqueMinimo ";

                if (Produto.Consulta_EstoqueCompra == true)
                    sql += "AND PE.EstoqueAtual < PE.EstoqueIdeal ";

                sql += "ORDER BY P.Descricao, G.Descricao, TV.Descricao ";
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

        public DataTable Busca_Estoque_Vlr_Data()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PE.ID, PE.ID_Produto, ";
                sql += "PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, (PE.EstoqueAtual - SUM(ISNULL(PM.Compra, 0))) + SUM(ISNULL(PM.Venda, 0)) AS EstoqueAtual, ";
                sql += "P.Descricao, P.CustoFinal, P.Barra, P.NCM, P.Referencia, P.InfoAdicional1, P.InfoAdicional2, P.ABC, ";
                sql += "PV.ValorVenda, ";
                sql += "TV.Descricao AS DescricaoTabelaValor, ";
                sql += "G.Descricao AS DescricaoGrade, G.ID_Grupo AS ID_GrupoGrade ";
                sql += "FROM Produto_Estoque AS PE ";
                sql += "INNER JOIN V_Produto_Servico AS P ON P.ID = PE.ID_Produto AND P.ID_Empresa = PE.ID_Empresa ";
                sql += "INNER JOIN Produto_Valor AS PV ON P.ID = PV.ID_Produto ";
                sql += "INNER JOIN TabelaValor AS TV ON PV.ID_Tabela = TV.ID ";
                sql += "INNER JOIN Grade AS G ON PE.ID_Grade = G.ID ";
                sql += "LEFT JOIN V_Produto_Movimento AS PM ON PM.ID_Produto = PE.ID_Produto ";

                if (Produto.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PM.Data) > CONVERT(DATE, '" + Produto.Consulta_Emissao.Inicial + "') ";

                sql += "WHERE ";
                sql += "NOT P.ID IS NULL ";
                sql += "AND P.ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.ID_Tabela > 0)
                    sql += "AND TV.ID = " + Produto.ID_Tabela + " ";

                if (Produto.ID > 0)
                    sql += "AND PE.ID_Produto = " + Produto.ID + " ";

                if (Produto.GrupoNivel.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.Cod_Grupo LIKE '" + Produto.GrupoNivel.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND P.Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Referencia != string.Empty)
                    sql += "AND P.Referencia LIKE '%" + Produto.Referencia + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND P.Barra LIKE '%" + Produto.Barra + "%' ";

                if (Produto.Consulta_EstoqueCritico == true)
                    sql += "AND PE.EstoqueAtual < PE.EstoqueMinimo ";

                if (Produto.Consulta_EstoqueCompra == true)
                    sql += "AND PE.EstoqueAtual < PE.EstoqueIdeal ";

                sql += "GROUP BY PE.ID, PE.ID_Produto, PE.ID_Grade, PE.EstoqueMinimo, PE.EstoqueIdeal, ";
                sql += "P.Descricao, P.CustoFinal, P.Barra, P.NCM, P.Referencia, P.InfoAdicional1, P.InfoAdicional2, P.ABC, PV.ValorVenda, ";
                sql += "TV.Descricao, pe.EstoqueAtual, ";
                sql += "G.Descricao , G.ID_Grupo ";

                sql += "ORDER BY P.Descricao, G.Descricao, TV.Descricao ";
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

        public DataTable Busca_Imagem()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "Imagem ";
                sql += "FROM ";
                sql += "Produto_Servico ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID = " + Produto.ID + " ";

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

        public DataTable Busca_ProdutoMovimento()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = " SELECT * ";
                sql += "FROM V_Produto_Movimento ";
                sql += "WHERE NOT ID_Produto IS NULL ";
                sql += "AND ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.ID > 0)
                    sql += "AND ID_Produto = " + Produto.ID + " ";

                if (Produto.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + Produto.Descricao + "%' ";

                if (Produto.Barra != string.Empty)
                    sql += "AND Barra = '" + Produto.Barra + "' ";


                if (Produto.Referencia != string.Empty)
                    sql += "AND Referencia = '" + Produto.Referencia + "' ";


                if (Produto.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, Data) BETWEEN CONVERT(DATE, '" + Produto.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Produto.Consulta_Emissao.Final + "') ";

                sql += "ORDER BY Data DESC ";

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

        public DataTable Busca_Desconto()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = " SELECT PD.ID, PD.Quantidade_Minima, PD.Quantidade_Maxima, PD.Desconto, ";
                sql += "P.Descricao, P.Referencia ";
                sql += "FROM Produto_Desconto AS PD ";
                sql += "INNER JOIN Produto_Servico AS P ON PD.ID_Produto = P.ID ";
                sql += "WHERE NOT PD.ID IS NULL ";

                sql += "AND PD.ID_Empresa = " + Produto.ID_Empresa + " ";

                if (Produto.ID > 0)
                    sql += "AND PD.ID_Produto = " + Produto.ID + " ";

                if (Produto.Consulta_Quantidade == true)
                {
                    sql += "AND PD.Quantidade_Minima <= '" + Math.Truncate(Produto.Quantidade) + "' ";
                    sql += "AND PD.Quantidade_Maxima >= '" + Math.Truncate(Produto.Quantidade) + "' ";
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

        public DataTable Busca_Desconto_Pessoa()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT P.ID AS ID_Produto, P.Descricao, P.Referencia, ";
                sql += "PD.ID, PD.TipoPessoa, PD.ID_Pessoa, PD.Tipo, PD.Desconto, ";
                sql += "CASE PD.Tipo ";
                sql += "WHEN 1 THEN 'Valor' ";
                sql += "WHEN 2 THEN 'Porcentagem' ";
                sql += "END AS TipoDesconto ";
                sql += "FROM Produto_Servico AS P ";
                sql += "LEFT JOIN Produto_Desconto_Pessoa AS PD ON PD.ID_Produto = P.ID ";
                sql += "AND PD.ID_Empresa = " + Produto.ID_Empresa + " ";
                sql += "AND PD.TipoPessoa = " + Produto.TipoPessoa + " ";
                sql += "AND PD.ID_Pessoa = " + Produto.ID_Pessoa + " ";

                if (Produto.ID > 0)
                    sql += "WHERE P.ID = " + Produto.ID + " ";

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

                #region CONSULTA PRODUTO EM OUTROS MODULOS
                sql = "SELECT ";
                sql += "ID_Produto ";
                sql += "FROM ";
                sql += "Venda_Item ";
                sql += "WHERE ";
                sql += "ID_Produto = " + Produto.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "VENDAS\n";

                sql = "SELECT ";
                sql += "ID_Produto ";
                sql += "FROM ";
                sql += "Orcamento_Item ";
                sql += "WHERE ";
                sql += "ID_Produto = " + Produto.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "ORÇAMENTOS\n";

                sql = "SELECT ";
                sql += "ID_Produto ";
                sql += "FROM ";
                sql += "Ordem_Servico_Item ";
                sql += "WHERE ";
                sql += "ID_Produto = " + Produto.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "ORDEM DE SERVIÇO\n";

                sql = "SELECT ";
                sql += "ID_Produto ";
                sql += "FROM ";
                sql += "Produto_Entrada_Item ";
                sql += "WHERE ";
                sql += "ID_Produto = " + Produto.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "ENTRADA DE PRODUTO\n";

                sql = "SELECT ";
                sql += "ID_Produto ";
                sql += "FROM ";
                sql += "Venda_Item_Mobile ";
                sql += "WHERE ";
                sql += "ID_Produto = " + Produto.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "VENDAS A FATURAR (MOBILE)\n";
                #endregion

                conexao.Begin_Conexao();

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_Exclui_Erro + msg);

                sql = "DELETE FROM ";
                sql += "Produto_Parametro ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto.ID);
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Fornecedor ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Valor ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Comissao ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Estoque ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Estrutura ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Servico ";
                sql += "WHERE ";
                sql += "ID =  @ID ";
                cmd.CommandText = sql;
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

        public void Exclui_Fornecedor()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Produto_Fornecedor ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto.Fornecedor[0].ID);

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

        public void Exclui_Valor()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Produto_Valor ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto.Valor[0].ID);

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

        public void Exclui_Estoque()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Produto_Estoque ";
                sql += "WHERE ";
                sql += "ID_Produto = @ID_Produto ";
                sql += "AND ID_Empresa = @ID_Empresa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Produto", Produto.ID);
                cmd.Parameters.AddWithValue("@ID_Empresa", Produto.ID_Empresa);

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

        public void Exclui_Estrutura()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Produto_Estrutura ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto.Estrutura[0].ID);

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

        public void Exclui_Imagem()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Produto_Servico SET ";
                sql += "Imagem = 'NULL' ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto.ID);

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

        public void Exclui_Desconto()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Produto_Desconto ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto.ID_Desconto);

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

        public void Exclui_Desconto_Pessoa()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "DELETE FROM ";
                sql += "Produto_Desconto_Pessoa ";
                sql += "WHERE ";
                sql += "TipoPessoa = @TipoPessoa ";
                sql += "AND ID_Pessoa = @ID_Pessoa ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@TipoPessoa", Produto.TipoPessoa);
                cmd.Parameters.AddWithValue("@ID_Pessoa", Produto.ID_Pessoa);

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

    public class DAL_Produto_Entrada
    {
        #region VARIAVEIS DE CLASSE
        Conexao conexao;
        #endregion

        #region VARIAVEIS DIVERSAS
        private static string sql;
        private SqlCommand cmd;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Produto_Entrada Produto_Entrada;
        #endregion

        #region CONSTRUTORES
        public DAL_Produto_Entrada(DTO_Produto_Entrada _Produto_Entrada)
        {
            this.Produto_Entrada = _Produto_Entrada;
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

                if (Produto_Entrada.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Produto_Entrada ";
                    sql += "(ID_Empresa, Tipo_Entrada, TipoPessoa, ID_Pessoa, TipoDocumento, Documento, Informacao, Data, Entrega, ID_Usuario, Situacao, Faturado) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Tipo_Entrada, @TipoPessoa, @ID_Pessoa, @TipoDocumento, @Documento, @Informacao, @Data, @Entrega, @ID_Usuario, @Situacao, @Faturado) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Produto_Entrada.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Tipo_Entrada", Produto_Entrada.Tipo_Entrada);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Produto_Entrada.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Produto_Entrada.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@TipoDocumento", Produto_Entrada.TipoDocumento);
                    cmd.Parameters.AddWithValue("@Documento", Produto_Entrada.Documento);
                    cmd.Parameters.AddWithValue("@Informacao", Produto_Entrada.Informacao);
                    cmd.Parameters.AddWithValue("@Data", Produto_Entrada.Data);
                    cmd.Parameters.AddWithValue("@Entrega", Produto_Entrada.Entrega);
                    cmd.Parameters.AddWithValue("@ID_Usuario", Produto_Entrada.ID_Usuario);
                    cmd.Parameters.AddWithValue("@Situacao", Produto_Entrada.Situacao);
                    cmd.Parameters.AddWithValue("@Faturado", Produto_Entrada.Faturado);

                    Produto_Entrada.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Produto_Entrada SET ";
                    sql += "Tipo_Entrada = @Tipo_Entrada, ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "TipoDocumento = @TipoDocumento, ";
                    sql += "Documento = @Documento, ";
                    sql += "Informacao = @Informacao, ";
                    sql += "Data = @Data, ";
                    sql += "Entrega = @Entrega, ";
                    sql += "ID_Usuario = @ID_Usuario, ";
                    sql += "Situacao = @Situacao, ";
                    sql += "Faturado = @Faturado ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Produto_Entrada.ID);
                    cmd.Parameters.AddWithValue("@Tipo_Entrada", Produto_Entrada.Tipo_Entrada);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Produto_Entrada.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Produto_Entrada.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@TipoDocumento", Produto_Entrada.TipoDocumento);
                    cmd.Parameters.AddWithValue("@Documento", Produto_Entrada.Documento);
                    cmd.Parameters.AddWithValue("@Informacao", Produto_Entrada.Informacao);
                    cmd.Parameters.AddWithValue("@Data", Produto_Entrada.Data);
                    cmd.Parameters.AddWithValue("@Entrega", Produto_Entrada.Entrega);
                    cmd.Parameters.AddWithValue("@ID_Usuario", Produto_Entrada.ID_Usuario);
                    cmd.Parameters.AddWithValue("@Situacao", Produto_Entrada.Situacao);
                    cmd.Parameters.AddWithValue("@Faturado", Produto_Entrada.Faturado);

                    conexao.Executa_Comando(cmd);
                }
                if (Produto_Entrada.ID == 0)
                    throw new Exception();

                #region GRAVA ITEM
                if (Produto_Entrada.Item != null && Produto_Entrada.Item.Count > 0)
                    for (int i = 0; i <= Produto_Entrada.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        if (Produto_Entrada.Item[i].ID == 0)
                        {
                            sql = "INSERT INTO Produto_Entrada_Item ";
                            sql += "(ID_Produto_Entrada, ID_Produto, Quantidade, ValorCompra, OutrosCustos, ID_Grade, ValorIPI, ValorST, ValorVenda, Margem, ValorAntigo, NFe_Descricao, NFe_CodigoProduto) ";
                            sql += "VALUES ";
                            sql += "(@ID_Produto_Entrada, @ID_Produto, @Quantidade, @ValorCompra, @OutrosCustos, @ID_Grade, @ValorIPI, @ValorST, @ValorVenda, @Margem, @ValorAntigo, @NFe_Descricao, @NFe_CodigoProduto) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Produto_Entrada", Produto_Entrada.ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto_Entrada.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", Produto_Entrada.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ValorCompra", Produto_Entrada.Item[i].ValorCompra);
                            cmd.Parameters.AddWithValue("@OutrosCustos", Produto_Entrada.Item[i].OutrosCustos);
                            cmd.Parameters.AddWithValue("@ID_Grade", Produto_Entrada.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorIPI", Produto_Entrada.Item[i].ValorIPI);
                            cmd.Parameters.AddWithValue("@ValorST", Produto_Entrada.Item[i].ValorST);
                            cmd.Parameters.AddWithValue("@ValorVenda", Produto_Entrada.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Margem", Produto_Entrada.Item[i].Margem);
                            cmd.Parameters.AddWithValue("@ValorAntigo", Produto_Entrada.Item[i].ValorAntigo);
                            cmd.Parameters.AddWithValue("@NFe_Descricao", Produto_Entrada.Item[i].NFe_Descricao);
                            cmd.Parameters.AddWithValue("@NFe_CodigoProduto", Produto_Entrada.Item[i].NFe_CodigoProduto);
                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            sql = "UPDATE Produto_Entrada_Item SET ";
                            sql += "ID_Produto = @ID_Produto, ";
                            sql += "Quantidade = @Quantidade, ";
                            sql += "ValorCompra = @ValorCompra, ";
                            sql += "OutrosCustos = @OutrosCustos, ";
                            sql += "ID_Grade = @ID_Grade, ";
                            sql += "ValorIPI = @ValorIPI, ";
                            sql += "ValorST = @ValorST, ";
                            sql += "ValorVenda = @ValorVenda, ";
                            sql += "Margem = @Margem, ";
                            sql += "ValorAntigo = @ValorAntigo, ";
                            sql += "NFe_Descricao = @NFe_Descricao, ";
                            sql += "NFe_CodigoProduto = @NFe_CodigoProduto ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Produto_Entrada.Item[i].ID);
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto_Entrada.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@Quantidade", Produto_Entrada.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ValorCompra", Produto_Entrada.Item[i].ValorCompra);
                            cmd.Parameters.AddWithValue("@OutrosCustos", Produto_Entrada.Item[i].OutrosCustos);
                            cmd.Parameters.AddWithValue("@ID_Grade", Produto_Entrada.Item[i].ID_Grade);
                            cmd.Parameters.AddWithValue("@ValorIPI", Produto_Entrada.Item[i].ValorIPI);
                            cmd.Parameters.AddWithValue("@ValorST", Produto_Entrada.Item[i].ValorST);
                            cmd.Parameters.AddWithValue("@ValorVenda", Produto_Entrada.Item[i].ValorVenda);
                            cmd.Parameters.AddWithValue("@Margem", Produto_Entrada.Item[i].Margem);
                            cmd.Parameters.AddWithValue("@ValorAntigo", Produto_Entrada.Item[i].ValorAntigo);
                            cmd.Parameters.AddWithValue("@NFe_Descricao", Produto_Entrada.Item[i].NFe_Descricao);
                            cmd.Parameters.AddWithValue("@NFe_CodigoProduto", Produto_Entrada.Item[i].NFe_CodigoProduto);
                            conexao.Executa_Comando(cmd);
                        }
                        if (Produto_Entrada.Entrada_XML_NFe == true)
                            if (Produto_Entrada.Item[i].ID_Fornecedor == 0)
                            {
                                cmd = new SqlCommand();
                                sql = "DELETE FROM Produto_Fornecedor WHERE ";
                                sql += "ID_Produto = @ID_Produto ";
                                sql += "AND ID_Fornecedor = @ID_Fornecedor; ";
                                sql += "INSERT INTO Produto_Fornecedor ";
                                sql += "(ID_Produto, ID_Fornecedor, Codigo_Produto) ";
                                sql += "VALUES ";
                                sql += "(@ID_Produto, @ID_Fornecedor, @Codigo_Produto) ";
                                cmd.CommandText = sql;
                                cmd.Parameters.AddWithValue("@ID_Produto", Produto_Entrada.Item[i].ID_Produto);
                                cmd.Parameters.AddWithValue("@ID_Fornecedor", Produto_Entrada.ID_Pessoa);
                                cmd.Parameters.AddWithValue("@Codigo_Produto", Produto_Entrada.Item[i].NFe_CodigoProduto);
                                conexao.Executa_Comando(cmd);
                            }
                    }
                #endregion

                conexao.Commit_Conexao();

                return Produto_Entrada.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();
                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Produto_Entrada";
                int aux_ID = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Produto_Entrada, RESEED, " + aux_ID + ")";
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

        public void Altera_Fatura()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();
                sql = "UPDATE ";
                sql += "Produto_Entrada SET ";
                sql += "Faturado = @Faturado ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto_Entrada.ID);
                cmd.Parameters.AddWithValue("@Faturado", Produto_Entrada.Faturado);

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

        public void Atualiza_ValorEstoque()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                #region LANÇA ESTOQUE
                if (Produto_Entrada.Item != null && Produto_Entrada.Item.Count > 0)
                    for (int i = 0; i <= Produto_Entrada.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        sql = "UPDATE ";
                        sql += "Produto_Estoque SET ";
                        sql += "EstoqueAtual = (EstoqueAtual + @Estoque) ";
                        sql += "WHERE ";
                        sql += "ID_Produto = @ID_Produto ";
                        sql += "AND ID_Grade = @ID_Grade ";
                        sql += "AND ID_Empresa = @ID_Empresa";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@Estoque", Produto_Entrada.Item[i].Quantidade);
                        cmd.Parameters.AddWithValue("@ID_Produto", Produto_Entrada.Item[i].ID_Produto);
                        cmd.Parameters.AddWithValue("@ID_Grade", Produto_Entrada.Item[i].ID_Grade);
                        cmd.Parameters.AddWithValue("@ID_Empresa", Produto_Entrada.ID_Empresa);

                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region ATUALIZA VALOR VENDA / MARGEM
                if (Produto_Entrada.Item != null && Produto_Entrada.Item.Count > 0)
                    for (int i = 0; i <= Produto_Entrada.Item.Count - 1; i++)
                    {
                        cmd = new SqlCommand();

                        sql = "UPDATE ";
                        sql += "Produto_Servico SET ";
                        sql += "ValorCompra = @ValorCompra, ";
                        sql += "OutrosCustos = @OutrosCustos, ";
                        sql += "ValorIPI = @ValorIPI, ";
                        sql += "ValorST = @ValorST, ";
                        sql += "CustoFinal = @CustoFinal ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", Produto_Entrada.Item[i].ID_Produto);
                        cmd.Parameters.AddWithValue("@ValorCompra", Produto_Entrada.Item[i].ValorCompra);
                        cmd.Parameters.AddWithValue("@ValorIPI", Produto_Entrada.Item[i].ValorIPI);
                        cmd.Parameters.AddWithValue("@ValorST", Produto_Entrada.Item[i].ValorST);
                        cmd.Parameters.AddWithValue("@OutrosCustos", Produto_Entrada.Item[i].OutrosCustos / Produto_Entrada.Item[i].Quantidade);
                        cmd.Parameters.AddWithValue("@CustoFinal", Produto_Entrada.Item[i].ValorCompra + Produto_Entrada.Item[i].ValorIPI + Produto_Entrada.Item[i].ValorST + (Produto_Entrada.Item[i].OutrosCustos / Produto_Entrada.Item[i].Quantidade));
                        conexao.Executa_Comando(cmd);

                        sql = "UPDATE ";
                        sql += "Produto_Valor SET ";
                        sql += "ValorVenda = @ValorVenda, ";
                        sql += "MargemVenda = @MargemVenda ";
                        sql += "WHERE ";
                        sql += "ID_Produto = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ValorVenda", Produto_Entrada.Item[i].ValorVenda);
                        cmd.Parameters.AddWithValue("@MargemVenda", Produto_Entrada.Item[i].Margem);
                        conexao.Executa_Comando(cmd);

                    }
                #endregion

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();
                cmd.Parameters.Clear();

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
                sql += "C.ID, C.Tipo_Entrada, C.ID_Empresa, C.TipoPessoa, C.ID_Pessoa, C.TipoDocumento, C.Documento, C.Informacao, C.Data, C.Entrega, C.ID_Usuario, C.Situacao, C.Faturado, ";
                sql += "P.Nome_Razao AS Descricao ";
                sql += "FROM Produto_Entrada AS C ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND C.ID_Empresa = " + Produto_Entrada.ID_Empresa + " ";

                if (Produto_Entrada.ID > 0)
                    sql += "AND C.ID = " + Produto_Entrada.ID + " ";

                if (Produto_Entrada.Tipo_Entrada > 0)
                    sql += "AND C.Tipo_Entrada = " + Produto_Entrada.Tipo_Entrada + " ";

                if (Produto_Entrada.TipoPessoa > 0)
                    sql += "AND C.TipoPessoa = " + Produto_Entrada.TipoPessoa + " ";

                if (Produto_Entrada.ID_Pessoa > 0)
                    sql += "AND C.ID_Pessoa  = " + Produto_Entrada.ID_Pessoa + " ";

                if (Produto_Entrada.Situacao > 0)
                    sql += "AND C.Situacao = " + Produto_Entrada.Situacao + " ";

                if (Produto_Entrada.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Data) BETWEEN CONVERT(DATE, '" + Produto_Entrada.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Produto_Entrada.Consulta_Emissao.Final + "') ";

                sql += "ORDER BY C.ID DESC ";

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
                sql += "C.ID, C.ID_Produto, C.Quantidade, C.ValorCompra, C.OutrosCustos, C.ValorIPI, C.ValorST, C.NFe_Descricao, C.NFe_CodigoProduto, ";
                sql += "((C.Quantidade * (C.ValorCompra + C.ValorIPI + C.ValorST)) + C.OutrosCustos) AS ValorTotal, C.ID_Grade, C.ValorVenda, C.Margem, C.ValorAntigo, ";
                sql += "CASE G.Descricao ";
                sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                sql += "END AS DescricaoProduto ";
                sql += "FROM ";
                sql += "Produto_Entrada_Item AS C ";
                sql += "LEFT JOIN Produto_Servico AS P ON P.ID = C.ID_Produto ";
                sql += "INNER JOIN Grade AS G ON G.ID = C.ID_Grade ";
                sql += "WHERE ";
                sql += "C.ID_Produto_Entrada = " + Produto_Entrada.ID;
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

        public DataTable Busca_HistoricoEntrada()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.Data, ";
                sql += "P.Nome_Razao AS Fornecedor, ";
                sql += "CI.Quantidade, CI.ValorCompra, CI.ValorIPI, CI.ValorST, CI.OutrosCustos ";
                sql += "FROM Produto_Entrada AS C ";
                sql += "INNER JOIN Pessoa AS P ON C.ID_Pessoa = P.ID_Pessoa AND C.TipoPessoa = P.TipoPessoa ";
                sql += "INNER JOIN Produto_Entrada_Item AS CI ON CI.ID_Produto_Entrada = C.ID ";
                sql += "WHERE ";
                sql += "C.Tipo_Entrada = " + Produto_Entrada.Tipo_Entrada + " ";
                sql += "AND CI.ID_Produto = " + Produto_Entrada.ID_Produto + " ";
                sql += "ORDER BY C.Data ";

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
                sql += "C.ID, C.ID_Empresa, C.TipoPessoa, C.ID_Pessoa, C.TipoDocumento, C.Documento, C.Informacao, C.Data, C.Entrega, C.ID_Usuario, C.Situacao, C.ID_Pagamento, ";
                sql += "P.Nome_Razao AS Descricao, ";
                sql += "PG.Descricao AS DescricaoPagamento, ";
                sql += "GS.Descricao AS DescricaoSituacao, ";
                sql += "GTD.Descricao AS DescricaoTipoDocumento ";
                sql += "FROM Produto_Entrada AS C ";
                sql += "LEFT JOIN Pessoa AS P ON P.TipoPessoa = C.TipoPessoa AND P.ID_Pessoa = C.ID_Pessoa ";
                sql += "LEFT JOIN Grupo AS PG ON PG.ID = C.ID_Pagamento ";
                sql += "LEFT JOIN Grupo AS GS ON GS.ID = C.Situacao ";
                sql += "LEFT JOIN Grupo AS GTD ON GTD.ID = C.TipoDocumento ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND C.ID_Empresa = " + Produto_Entrada.ID_Empresa + " ";
                sql += "AND C.ID = " + Produto_Entrada.ID + " ";

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

        public DataTable Busca_Item_Relatorio()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.ID, C.ID_Produto, C.Quantidade, C.ValorCompra, C.OutrosCustos, C.ValorIPI, C.ValorST, C.ID_Grade, ";
                sql += "CASE G.Descricao ";
                sql += "WHEN 'ÚNICO' THEN P.Descricao ";
                sql += "ELSE P.Descricao + ' - ' + G.Descricao  ";
                sql += "END AS DescricaoProduto ";
                sql += "FROM ";
                sql += "Produto_Entrada_Item AS C ";
                sql += "INNER JOIN Grade AS G ON G.ID = C.ID_Grade ";
                sql += "LEFT JOIN Produto_Servico AS P ON P.ID = C.ID_Produto ";
                sql += "WHERE ";
                sql += "C.ID_Produto_Entrada = " + Produto_Entrada.ID;
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

        public DataTable Busca_Produto_Entrada_Simplificado()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT PE.* ";
                sql += "FROM V_Produto_Entrada AS PE ";
                sql += "WHERE ";
                sql += "NOT PE.ID_Entrada IS NULL ";
                sql += "AND PE.ID_Empresa = " + Produto_Entrada.ID_Empresa + " ";

                if (Produto_Entrada.ID > 0)
                    sql += "AND PE.ID_Entrada = " + Produto_Entrada.ID + " ";

                if (Produto_Entrada.Tipo_Entrada > 0)
                    sql += "AND PE.Tipo_Entrada = " + Produto_Entrada.Tipo_Entrada + " ";

                if (Produto_Entrada.TipoPessoa > 0)
                    sql += "AND PE.TipoPessoa = " + Produto_Entrada.TipoPessoa + " ";

                if (Produto_Entrada.ID_Pessoa > 0)
                    sql += "AND PE.ID_Pessoa  = " + Produto_Entrada.ID_Pessoa + " ";

                if (Produto_Entrada.Pesquisa_Faturado == true)
                    sql += "AND PE.Faturado = '" + Produto_Entrada.Faturado + "' ";

                if (Produto_Entrada.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PE.Data) BETWEEN CONVERT(DATE, '" + Produto_Entrada.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Produto_Entrada.Consulta_Emissao.Final + "') ";

                sql += "ORDER BY PE.Data ";

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

        public DataTable Busca_Produto_Entrada_Detalhado()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT PE.*, ";
                sql += "PEI.Quantidade, PEI.ValorCompra, PEI.OutrosCustos, PEI.ValorIPI, PEI.ValorST, PEI.ValorVenda, PEI.Margem, PEI.ValorAntigo, ";
                sql += "P.Descricao AS DescricaoProduto, P.Referencia, P.ID AS ID_Produto, ";
                sql += "G.Descricao AS DescricaoGrade ";
                sql += "FROM V_Produto_Entrada AS PE ";
                sql += "INNER JOIN Produto_Entrada_Item AS PEI ON PE.ID_Entrada = PEI.ID_Produto_Entrada ";
                sql += "INNER JOIN Produto_Servico AS P ON P.ID = PEI.ID_Produto ";
                sql += "INNER JOIN Grade AS G ON G.ID = PEI.ID_Grade ";
                sql += "WHERE ";
                sql += "NOT PE.ID_Entrada IS NULL ";
                sql += "AND PE.ID_Empresa = " + Produto_Entrada.ID_Empresa + " ";

                if (Produto_Entrada.ID > 0)
                    sql += "AND PE.ID_Entrada = " + Produto_Entrada.ID + " ";

                if (Produto_Entrada.Tipo_Entrada > 0)
                    sql += "AND PE.Tipo_Entrada = " + Produto_Entrada.Tipo_Entrada + " ";

                if (Produto_Entrada.TipoPessoa > 0)
                    sql += "AND PE.TipoPessoa = " + Produto_Entrada.TipoPessoa + " ";

                if (Produto_Entrada.ID_Pessoa > 0)
                    sql += "AND PE.ID_Pessoa  = " + Produto_Entrada.ID_Pessoa + " ";

                if (Produto_Entrada.Pesquisa_Faturado == true)
                    sql += "AND PE.Faturado = '" + Produto_Entrada.Faturado + "' ";

                if (Produto_Entrada.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, PE.Data) BETWEEN CONVERT(DATE, '" + Produto_Entrada.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Produto_Entrada.Consulta_Emissao.Final + "') ";

                sql += "ORDER BY PE.Data ";

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
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                cmd = new SqlCommand();

                sql = "DELETE FROM ";
                sql += "Produto_Entrada_Item ";
                sql += "WHERE ";
                sql += "ID_Produto_Entrada = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto_Entrada.ID);
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Entrada ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                #region RETORNA ESTOQUE
                if (Produto_Entrada.Item != null && Produto_Entrada.Item.Count > 0)
                    for (int i = 0; i <= Produto_Entrada.Item.Count - 1; i++)
                        if (Produto_Entrada.Item[i].ID != 0)
                        {
                            cmd = new SqlCommand();
                            sql = "UPDATE ";
                            sql += "Produto_Estoque SET ";
                            sql += "EstoqueAtual = (EstoqueAtual - @Estoque) ";
                            sql += "WHERE ";
                            sql += "ID_Produto = @ID_Produto ";
                            sql += "AND ID_Grade = @ID_Grade ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@Estoque", Produto_Entrada.Item[i].Quantidade);
                            cmd.Parameters.AddWithValue("@ID_Produto", Produto_Entrada.Item[i].ID_Produto);
                            cmd.Parameters.AddWithValue("@ID_Grade", Produto_Entrada.Item[i].ID_Grade);
                            conexao.Executa_Comando(cmd);
                        }
                #endregion

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
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
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Produto_Entrada_Item ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Produto_Entrada.Item[0].ID);
                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    conexao.RollBack_Conexao();

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }
    }

    public class DAL_Produto_Locacao
    {
        #region PRODUTO LOCAÇÃO
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Locacao_Produto Locacao_Produto;
        #endregion

        #region CONSTRUTOR
        public DAL_Produto_Locacao(DTO_Locacao_Produto _Locacao_Produto)
        {
            Locacao_Produto = _Locacao_Produto;
        }

        public int Grava_Locacao()
        {
            return Locacao_Produto.ID;
        }
        #endregion

    }
}
