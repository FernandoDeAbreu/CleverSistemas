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
    public class DAL_CPagar
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;

        SqlCommand cmd;

        string sql;
        #endregion

        #region ESTRUTURA
        DTO_CPagar CPagar;
        #endregion

        #region CONSTRUTOR
        public DAL_CPagar(DTO_CPagar _CPagar)
        {
            CPagar = _CPagar;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (CPagar.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "CPagar ";
                    sql += "(ID_Empresa, ID_Conta, GrupoConta, Situacao, Documento, Emissao, Vencimento, TipoPessoa, ID_Pessoa, ";
                    sql += "Valor, QuantidadeParcela, Parcela, Descricao, Desconto, Acrescimo, Controle) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @ID_Conta, @GrupoConta, @Situacao, @Documento, @Emissao, @Vencimento, @TipoPessoa, @ID_Pessoa, ";
                    sql += "@Valor, @QuantidadeParcela, @Parcela, @Descricao, @Desconto, @Acrescimo, @Controle) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", CPagar.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Conta", CPagar.ID_Conta);
                    cmd.Parameters.AddWithValue("@GrupoConta", CPagar.GrupoConta);
                    cmd.Parameters.AddWithValue("@Situacao", CPagar.Situacao);
                    cmd.Parameters.AddWithValue("@Documento", CPagar.Documento);
                    cmd.Parameters.AddWithValue("@Emissao", CPagar.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", CPagar.Vencimento);
                    cmd.Parameters.AddWithValue("@TipoPessoa", CPagar.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", CPagar.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Valor", CPagar.Valor);
                    cmd.Parameters.AddWithValue("@QuantidadeParcela", CPagar.QuantidadeParcela);
                    cmd.Parameters.AddWithValue("@Parcela", CPagar.Parcela);
                    cmd.Parameters.AddWithValue("@Descricao", CPagar.Descricao);
                    cmd.Parameters.AddWithValue("@Desconto", CPagar.Desconto);
                    cmd.Parameters.AddWithValue("@Acrescimo", CPagar.Acrescimo);
                    cmd.Parameters.AddWithValue("@Controle", CPagar.Controle);

                    CPagar.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "CPagar SET ";
                    sql += "ID_Conta = @ID_Conta, ";
                    sql += "GrupoConta = @GrupoConta, ";
                    sql += "Situacao = @Situacao, ";
                    sql += "Documento = @Documento, ";
                    sql += "Emissao = @Emissao, ";
                    sql += "Vencimento = @Vencimento, ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "Valor = @Valor, ";
                    sql += "QuantidadeParcela = @QuantidadeParcela, ";
                    sql += "Parcela = @Parcela, ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Desconto = @Desconto, ";
                    sql += "Acrescimo = @Acrescimo, ";
                    sql += "Controle = @Controle ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", CPagar.ID);
                    cmd.Parameters.AddWithValue("@ID_Conta", CPagar.ID_Conta);
                    cmd.Parameters.AddWithValue("@GrupoConta", CPagar.GrupoConta);
                    cmd.Parameters.AddWithValue("@Situacao", CPagar.Situacao);
                    cmd.Parameters.AddWithValue("@Documento", CPagar.Documento);
                    cmd.Parameters.AddWithValue("@Emissao", CPagar.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", CPagar.Vencimento);
                    cmd.Parameters.AddWithValue("@TipoPessoa", CPagar.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", CPagar.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Valor", CPagar.Valor);
                    cmd.Parameters.AddWithValue("@QuantidadeParcela", CPagar.QuantidadeParcela);
                    cmd.Parameters.AddWithValue("@Parcela", CPagar.Parcela);
                    cmd.Parameters.AddWithValue("@Descricao", CPagar.Descricao);
                    cmd.Parameters.AddWithValue("@Desconto", CPagar.Desconto);
                    cmd.Parameters.AddWithValue("@Acrescimo", CPagar.Acrescimo);
                    cmd.Parameters.AddWithValue("@Controle", CPagar.Controle);

                    conexao.Executa_Comando(cmd);
                }
                return CPagar.ID;
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

        public void Altera()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                switch (CPagar.Altera_Registro)
                {
                    case 1: //ALTERAR GRUPO CONTA LANÇAMENTO
                        sql = "UPDATE ";
                        sql += "CPagar SET ";
                        sql += "ID_Conta = @ID_Conta, ";
                        sql += "GrupoConta = @GrupoConta ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CPagar.ID);
                        cmd.Parameters.AddWithValue("@ID_Conta", CPagar.ID_Conta);
                        cmd.Parameters.AddWithValue("@GrupoConta", CPagar.GrupoConta);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 2: //ALTERAR PESSOA
                        sql = "UPDATE ";
                        sql += "CPagar SET ";
                        sql += "TipoPessoa = @TipoPessoa, ";
                        sql += "ID_Pessoa = @ID_Pessoa ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CPagar.ID);
                        cmd.Parameters.AddWithValue("@TipoPessoa", CPagar.TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", CPagar.ID_Pessoa);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 3: //ALTERAR VALOR
                        sql = "UPDATE ";
                        sql += "CPagar SET ";
                        sql += "Valor = @Valor, ";
                        sql += "Desconto = @Desconto, ";
                        sql += "Acrescimo = @Acrescimo ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CPagar.ID);
                        cmd.Parameters.AddWithValue("@Valor", CPagar.Valor);
                        cmd.Parameters.AddWithValue("@Desconto", CPagar.Desconto);
                        cmd.Parameters.AddWithValue("@Acrescimo", CPagar.Acrescimo);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 4: //ALTERAR LANÇAMENTO
                        sql = "UPDATE ";
                        sql += "CPagar SET ";
                        sql += "ID_Conta = @ID_Conta, ";
                        sql += "Situacao = @Situacao, ";
                        sql += "Documento = @Documento, ";
                        sql += "Emissao = @Emissao, ";
                        sql += "Vencimento = @Vencimento, ";
                        sql += "TipoPessoa = @TipoPessoa, ";
                        sql += "ID_Pessoa = @ID_Pessoa, ";
                        sql += "Descricao = @Descricao, ";
                        sql += "Valor = @Valor ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CPagar.ID);
                        cmd.Parameters.AddWithValue("@ID_Conta", CPagar.ID_Conta);
                        cmd.Parameters.AddWithValue("@Situacao", CPagar.Situacao);
                        cmd.Parameters.AddWithValue("@Documento", CPagar.Documento);
                        cmd.Parameters.AddWithValue("@Emissao", CPagar.Emissao);
                        cmd.Parameters.AddWithValue("@Vencimento", CPagar.Vencimento);
                        cmd.Parameters.AddWithValue("@TipoPessoa", CPagar.TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", CPagar.ID_Pessoa);
                        cmd.Parameters.AddWithValue("@Descricao", CPagar.Descricao);
                        cmd.Parameters.AddWithValue("@Valor", CPagar.Valor);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 5: //ALTERAR INFORMAÇÕES DE BAIXA
                        sql = "UPDATE ";
                        sql += "CPagar SET ";
                        sql += "Situacao = @Situacao, ";
                        sql += "DataBaixa = @DataBaixa, ";
                        sql += "Desconto = @Desconto, ";
                        sql += "Acrescimo = @Acrescimo ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CPagar.ID);
                        cmd.Parameters.AddWithValue("@Situacao", CPagar.Situacao);
                        cmd.Parameters.AddWithValue("@DataBaixa", CPagar.DataBaixa);
                        cmd.Parameters.AddWithValue("@Desconto", CPagar.Desconto);
                        cmd.Parameters.AddWithValue("@Acrescimo", CPagar.Acrescimo);

                        conexao.Executa_Comando(cmd);
                        break;

                    case 6: //DATA VENCIMENTO
                        sql = "UPDATE ";
                        sql += "CPagar SET ";
                        sql += "Vencimento = @Vencimento ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CPagar.ID);
                        cmd.Parameters.AddWithValue("@Vencimento", CPagar.Vencimento);

                        conexao.Executa_Comando(cmd);
                        break;
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
                sql += "ID, ID_Empresa, ID_Conta, Situacao, Documento, Emissao, Vencimento, TipoPessoa, ID_Pessoa, Valor, Total, ";
                sql += "QuantidadeParcela, Parcela, ResumoParcela, Descricao, DataBaixa, Desconto, Acrescimo, Controle,  ";
                sql += "Conta, DescricaoConta, Nivel, Conta1, DescricaoConta1, Conta2, DescricaoConta2, Conta3, DescricaoConta3, ";
                sql += "DescricaoPessoa, DescricaoSituacao ";
                sql += "FROM V_CPagar ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Empresa = " + CPagar.ID_Empresa + " ";

                if (CPagar.ID > 0)
                    sql += "AND ID = " + CPagar.ID + " ";

                if (CPagar.Situacao > 0)
                    sql += "AND Situacao = " + CPagar.Situacao + " ";

                if (CPagar.Documento != String.Empty)
                    sql += "AND Documento = '" + CPagar.Documento + "' ";

                if (CPagar.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + CPagar.TipoPessoa + " ";

                if (CPagar.TipoPessoa > 0 && CPagar.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa = " + CPagar.ID_Pessoa + " ";

                if (CPagar.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND Conta LIKE '" + CPagar.GrupoConta.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (CPagar.Consulta_Baixa.Filtra == true)
                    sql += "AND CONVERT(DATE, DataBaixa) BETWEEN CONVERT(DATE, '" + CPagar.Consulta_Baixa.Inicial + "') AND CONVERT(DATE, '" + CPagar.Consulta_Baixa.Final + "') ";

                if (CPagar.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, Emissao) BETWEEN CONVERT(DATE, '" + CPagar.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + CPagar.Consulta_Emissao.Final + "') ";

                if (CPagar.Consulta_Vencimento.Filtra == true)
                    sql += "AND CONVERT(DATE, Vencimento) BETWEEN CONVERT(DATE, '" + CPagar.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + CPagar.Consulta_Vencimento.Final + "') ";

                if (CPagar.Ordena_Por == 1)
                    sql += "ORDER BY TipoPessoa, ID_Pessoa, Vencimento ";

                if (CPagar.Ordena_Por == 2)
                    sql += "ORDER BY Vencimento, TipoPessoa, ID_Pessoa ";

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

        public DataTable Busca_Resumo()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, C.Parcelado, ";
                sql += "C.QuantidadeParcela, C.Parcela, ";
                sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) AS ResumoParcela, ";
                sql += "C.Descricao, C.DataBaixa, C.Desconto, ";
                sql += "C.Acrescimo, C.Caixa, C.ID_Pagamento, C.InformacaoBaixa, C.Controle,  ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, ";
                sql += "Pessoa.Nome_Razao AS DescricaoPessoa, ";
                sql += "Grupo.Descricao AS DescricaoSituacao ";
                sql += "FROM CPagar AS C ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = C.ID_Conta ";
                sql += "LEFT JOIN Grupo AS Grupo ON Grupo.ID = C.Situacao ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = C.TipoPessoa AND Pessoa.ID_Pessoa = C.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND C.ID IN (" + CPagar.ListaID + ") ";
                sql += "ORDER BY C.Vencimento, C.TipoPessoa, C.ID_Pessoa ";

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

        public DataTable Busca_Conta()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.ID, C.Documento, C.Emissao, C.Vencimento, C.Valor, C.DataBaixa, ";
                sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) AS ResumoParcela, ";
                sql += " C.Desconto, C.Acrescimo, C.Controle,  ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, ";
                sql += "Pessoa.Nome_Razao AS DescricaoPessoa, ";
                sql += "PG.Descricao AS TipoPagamento ";
                sql += "FROM CPagar AS C ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = C.ID_Conta ";
                sql += "LEFT JOIN Pagamento AS PG ON PG.ID = C.ID_Pagamento ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = C.TipoPessoa AND Pessoa.ID_Pessoa = C.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";

                if (CPagar.ID > 0)
                    sql += "AND C.ID = " + CPagar.ID + " ";

                sql += "ORDER BY C.Vencimento, C.TipoPessoa, C.ID_Pessoa ";

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

        public DataTable Busca_Planejamento()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, C.Total, ";
                sql += "C.QuantidadeParcela, C.Parcela, C.ResumoParcela, C.Descricao, C.DataBaixa, C.Desconto, C.Acrescimo, C.Controle,  ";
                sql += "C.Conta, C.DescricaoConta, C.DescricaoPessoa, C.DescricaoSituacao ";
                sql += "FROM V_CPagar AS C ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = C.ID_Conta ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND P.Planejamento = 'true'";

                if (CPagar.Situacao > 0)
                    sql += "AND C.Situacao = 1 ";

                if (CPagar.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND C.GrupoConta LIKE '" + CPagar.GrupoConta.Replace(".  ", "") + "%' ";

                sql += "AND CONVERT(DATE, C.Vencimento) BETWEEN CONVERT(DATE, '" + CPagar.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + CPagar.Consulta_Vencimento.Final + "') ";
                sql += "AND C.ID_Empresa = " + CPagar.ID_Empresa + " ";

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
                sql += "CPagar ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", CPagar.ID);

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
