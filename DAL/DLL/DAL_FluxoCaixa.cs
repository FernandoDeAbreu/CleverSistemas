using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;

namespace Sistema.DAL
{
    public class DAL_FluxoCaixa
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_FluxoCaixa FluxoCaixa;
        #endregion

        #region CONSTRUTOR
        public DAL_FluxoCaixa(DTO_FluxoCaixa _FluxoCaixa)
        {
            FluxoCaixa = _FluxoCaixa;
        }

        public DAL_FluxoCaixa()
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

                if (FluxoCaixa.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += " FluxoCaixa ";
                    sql += "(ID_Empresa, Emissao, Caixa, Documento, ID_Conta, Credito, Debito, Informacao, ID_Cheque, Conciliado, ID_Pagamento, Planejamento) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Emissao, @Caixa, @Documento, @ID_Conta, @Credito, @Debito, @Informacao, @ID_Cheque, @Conciliado, @ID_Pagamento, @Planejamento) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", FluxoCaixa.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Emissao", FluxoCaixa.Emissao);
                    cmd.Parameters.AddWithValue("@Caixa", FluxoCaixa.Caixa);
                    cmd.Parameters.AddWithValue("@Documento", FluxoCaixa.Documento);
                    cmd.Parameters.AddWithValue("@ID_Conta", FluxoCaixa.ID_Conta);
                    cmd.Parameters.AddWithValue("@Credito", FluxoCaixa.Credito);
                    cmd.Parameters.AddWithValue("@Debito", FluxoCaixa.Debito);
                    cmd.Parameters.AddWithValue("@Informacao", FluxoCaixa.Informacao);
                    cmd.Parameters.AddWithValue("@ID_Cheque", FluxoCaixa.ID_Cheque);
                    cmd.Parameters.AddWithValue("@Conciliado", FluxoCaixa.Conciliado);
                    cmd.Parameters.AddWithValue("@ID_Pagamento", FluxoCaixa.ID_Pagamento);
                    cmd.Parameters.AddWithValue("@Planejamento", FluxoCaixa.Planejamento);

                    FluxoCaixa.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "FluxoCaixa SET ";
                    sql += "Emissao = @Emissao, ";
                    sql += "Caixa = @Caixa, ";
                    sql += "Documento = @Documento, ";
                    sql += "ID_Conta = @ID_Conta, ";
                    sql += "Credito = @Credito, ";
                    sql += "Debito = @Debito, ";
                    sql += "Informacao = @Informacao, ";
                    sql += "Conciliado = @Conciliado, ";
                    sql += "ID_Pagamento = @ID_Pagamento, ";
                    sql += "Planejamento = @Planejamento ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", FluxoCaixa.ID);
                    cmd.Parameters.AddWithValue("@ID_Empresa", FluxoCaixa.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Emissao", FluxoCaixa.Emissao);
                    cmd.Parameters.AddWithValue("@Caixa", FluxoCaixa.Caixa);
                    cmd.Parameters.AddWithValue("@Documento", FluxoCaixa.Documento);
                    cmd.Parameters.AddWithValue("@ID_Conta", FluxoCaixa.ID_Conta);
                    cmd.Parameters.AddWithValue("@Credito", FluxoCaixa.Credito);
                    cmd.Parameters.AddWithValue("@Debito", FluxoCaixa.Debito);
                    cmd.Parameters.AddWithValue("@Informacao", FluxoCaixa.Informacao);
                    cmd.Parameters.AddWithValue("@Conciliado", FluxoCaixa.Conciliado);
                    cmd.Parameters.AddWithValue("@ID_Pagamento", FluxoCaixa.ID_Pagamento);
                    cmd.Parameters.AddWithValue("@Planejamento", FluxoCaixa.Planejamento);

                    conexao.Executa_Comando(cmd);
                }
                return FluxoCaixa.ID;
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

        public void Grava_Controle()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "INSERT INTO ";
                sql += "FluxoCaixa_Controle ";
                sql += "(ID_FluxoCaixa, ID_CPagar, ID_CReceber)";
                sql += "VALUES ";
                sql += "(@ID_FluxoCaixa, @ID_CPagar, @ID_CReceber)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_FluxoCaixa", FluxoCaixa.ID);
                cmd.Parameters.AddWithValue("@ID_CPagar", FluxoCaixa.ID_CPagar);
                cmd.Parameters.AddWithValue("@ID_CReceber", FluxoCaixa.ID_CReceber);

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

        public void Altera_Lancamento_Cheque()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "FluxoCaixa SET ";
                sql += "Emissao = @Emissao, ";
                sql += "Conciliado = @Conciliado, ";
                sql += "Planejamento = @Planejamento ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", FluxoCaixa.ID);
                cmd.Parameters.AddWithValue("@Emissao", FluxoCaixa.Emissao);
                cmd.Parameters.AddWithValue("@Conciliado", FluxoCaixa.Conciliado);
                cmd.Parameters.AddWithValue("@Planejamento", FluxoCaixa.Planejamento);
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

        public void Altera_Conciliado()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "FluxoCaixa SET ";
                sql += "Conciliado = @Conciliado, ";
                sql += "Emissao = @Emissao ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", FluxoCaixa.ID);
                cmd.Parameters.AddWithValue("@Conciliado", FluxoCaixa.Conciliado);
                cmd.Parameters.AddWithValue("@Emissao", FluxoCaixa.Emissao);
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

        public void Atualiza_Planejamento()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE FluxoCaixa ";
                sql += "SET Planejamento = 'False' ";
                sql += "WHERE ";
                sql += "Planejamento = 'True' ";
                sql += "AND Emissao <= '" + DateTime.Now.AddDays(3).Date + "' ";
                //sql += "AND Credito = 0 ";
                sql += "AND ID_Cheque > 0 ";
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

        public DataTable BuscaSimples()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "FC.ID, FC.ID AS ID_FluxoCaixa, FC.ID_Empresa, FC.Emissao, FC.Caixa, FC.Documento, FC.ID_Conta, FC.Credito, FC.Debito, FC.Informacao, ";
                sql += "FC.ID_Cheque, FC.Conciliado, FC.ID_Pagamento, FC.Planejamento, '' AS Valor, 0.0 AS Saldo, 0.0 AS Provisionado, ";
                sql += "PG.Descricao AS DescricaoPagamento, FC.Informacao + ' (' + PG.Descricao + ')' AS Historico, ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, P.CodigoDescritivo + ' - ' + P.Descricao AS DescricaoContaDetalhado ";
                sql += "FROM FluxoCaixa AS FC ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = FC.ID_Conta ";
                sql += "LEFT JOIN Pagamento AS PG ON FC.ID_Pagamento = PG.ID ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";
                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

                if (FluxoCaixa.Informacao != string.Empty)
                    sql += "AND FC.Informacao LIKE '%" + FluxoCaixa.Informacao + "%' ";

                if (FluxoCaixa.GrupoConta != string.Empty)
                    sql += "AND P.CodigoDescritivo LIKE '" + FluxoCaixa.GrupoConta + "%' ";

                sql += "AND CONVERT(DATE, FC.Emissao) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";

                sql += "AND FC.Planejamento = '" + FluxoCaixa.Planejamento + "' ";

                if (FluxoCaixa.Conciliado == true)
                    sql += "AND FC.Conciliado = 'True' ";

                sql += "UNION SELECT ";
                sql += "FC.ID, FC.ID AS ID_FluxoCaixa, FC.ID_Empresa, FC.Emissao, FC.Caixa, FC.Documento, FC.ID_Conta, FC.Credito, FC.Debito, FC.Informacao, ";
                sql += "FC.ID_Cheque, FC.Conciliado, FC.ID_Pagamento, FC.Planejamento, '' AS Valor, 0.0 AS Saldo, 0.0 AS Provisionado, ";
                sql += "PG.Descricao AS DescricaoPagamento, FC.Informacao + ' (' + PG.Descricao + ')' AS Historico, ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, P.CodigoDescritivo + ' - ' + P.Descricao AS DescricaoContaDetalhado ";
                sql += "FROM FluxoCaixa AS FC ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = FC.ID_Conta ";
                sql += "LEFT JOIN Pagamento AS PG ON FC.ID_Pagamento = PG.ID ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";
                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

                if (FluxoCaixa.Informacao != string.Empty)
                    sql += "AND FC.Informacao LIKE '%" + FluxoCaixa.Informacao + "%' ";

                if (FluxoCaixa.GrupoConta != string.Empty)
                    sql += "AND P.CodigoDescritivo LIKE '" + FluxoCaixa.GrupoConta + "%' ";

                sql += "AND FC.Planejamento = '" + FluxoCaixa.Planejamento + "' ";

                if (FluxoCaixa.Conciliado == true)
                {
                    sql += "AND CONVERT(DATE, FC.Emissao) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";
                    sql += "AND FC.Conciliado = 'True' ";
                }
                else
                    sql += "AND FC.Conciliado = 'False' ";

                sql += "ORDER BY FC.Conciliado DESC, FC.Emissao, FC.ID";

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

        public DataTable BuscaDetalhado()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "FC.ID, FC.ID AS ID_FluxoCaixa, FC.ID_Empresa, FC.Emissao, FC.Caixa, FC.Documento, FC.ID_Conta, FC.Credito, FC.Debito, FC.Informacao, ";
                sql += "FC.ID_Cheque, FC.Conciliado, FC.ID_Pagamento, FC.Planejamento, '' AS Valor, 0.0 AS Saldo, 0.0 AS Provisionado, ";
                sql += "PG.Descricao AS DescricaoPagamento, FC.Informacao + ' (' + PG.Descricao + ')' AS Historico, ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, P.CodigoDescritivo + ' - ' + P.Descricao AS DescricaoContaDetalhado, ";
                sql += "CP.ID AS IDCP, CP.DescricaoPessoa AS DescricaoPessoaCP , CP.Conta + ' - ' + CP.DescricaoConta AS DescricaoContaCP, CP.Valor AS ValorCP, ";
                sql += "CR.ID AS IDCR, CR.DescricaoPessoa AS DescricaoPessoaCR, CR.Conta + ' - ' + CR.DescricaoConta AS DescricaoContaCR, CR.Valor AS ValorCR ";
                sql += "FROM FluxoCaixa AS FC ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = FC.ID_Conta ";
                sql += "LEFT JOIN Pagamento AS PG ON FC.ID_Pagamento = PG.ID ";
                sql += "LEFT JOIN FluxoCaixa_Controle AS FCC_Pagar ON FCC_Pagar.ID_FluxoCaixa = FC.ID AND FCC_Pagar.ID_CPagar > 0 ";
                sql += "LEFT JOIN FluxoCaixa_Controle AS FCC_Receber ON FCC_Receber.ID_FluxoCaixa = FC.ID AND FCC_Receber.ID_CReceber > 0 ";
                sql += "LEFT JOIN V_CPagar AS CP ON FCC_Pagar.ID_CPagar = CP.ID ";
                sql += "LEFT JOIN V_CReceber AS CR ON FCC_Receber.ID_CReceber = CR.ID ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";
                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

                if (FluxoCaixa.GrupoConta != string.Empty)
                    sql += "AND P.CodigoDescritivo LIKE '" + FluxoCaixa.GrupoConta + "%' ";

                sql += "AND CONVERT(DATE, FC.Emissao) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";

                sql += "AND FC.Planejamento = '" + FluxoCaixa.Planejamento + "' ";

                if (FluxoCaixa.Conciliado == true)
                    sql += "AND FC.Conciliado = 'True' ";

                sql += "UNION SELECT ";
                sql += "FC.ID, FC.ID AS ID_FluxoCaixa, FC.ID_Empresa, FC.Emissao, FC.Caixa, FC.Documento, FC.ID_Conta, FC.Credito, FC.Debito, FC.Informacao, ";
                sql += "FC.ID_Cheque, FC.Conciliado, FC.ID_Pagamento, FC.Planejamento, '' AS Valor, 0.0 AS Saldo, 0.0 AS Provisionado, ";
                sql += "PG.Descricao AS DescricaoPagamento, FC.Informacao + ' (' + PG.Descricao + ')' AS Historico, ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, P.CodigoDescritivo + ' - ' + P.Descricao AS DescricaoContaDetalhado, ";
                sql += "CP.ID AS IDCP, CP.DescricaoPessoa AS DescricaoPessoaCP , CP.Conta + ' - ' + CP.DescricaoConta AS DescricaoContaCP, CP.Valor AS ValorCP, ";
                sql += "CR.ID AS IDCR, CR.DescricaoPessoa AS DescricaoPessoaCR, CR.Conta + ' - ' + CR.DescricaoConta AS DescricaoContaCR, CR.Valor AS ValorCR ";
                sql += "FROM FluxoCaixa AS FC ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = FC.ID_Conta ";
                sql += "LEFT JOIN Pagamento AS PG ON FC.ID_Pagamento = PG.ID ";
                sql += "LEFT JOIN FluxoCaixa_Controle AS FCC_Pagar ON FCC_Pagar.ID_FluxoCaixa = FC.ID AND FCC_Pagar.ID_CPagar > 0 ";
                sql += "LEFT JOIN FluxoCaixa_Controle AS FCC_Receber ON FCC_Receber.ID_FluxoCaixa = FC.ID AND FCC_Receber.ID_CReceber > 0 ";
                sql += "LEFT JOIN V_CPagar AS CP ON FCC_Pagar.ID_CPagar = CP.ID ";
                sql += "LEFT JOIN V_CReceber AS CR ON FCC_Receber.ID_CReceber = CR.ID ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";
                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

                if (FluxoCaixa.GrupoConta != string.Empty)
                    sql += "AND P.CodigoDescritivo LIKE '" + FluxoCaixa.GrupoConta + "%' ";

                sql += "AND FC.Planejamento = '" + FluxoCaixa.Planejamento + "' ";

                if (FluxoCaixa.Conciliado == true)
                {
                    sql += "AND CONVERT(DATE, FC.Emissao) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";
                    sql += "AND FC.Conciliado = 'True' ";
                }
                else
                    sql += "AND FC.Conciliado = 'False' ";

                sql += "ORDER BY FC.Conciliado DESC, FC.Emissao, FC.ID";

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

        public DataTable BuscaBalanco()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT DISTINCT ";
                sql += "FC.ID, FC.Credito, FC.Debito, FC.Emissao, ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, P.CodigoDescritivo + ' - ' + P.Descricao AS DescricaoContaDetalhado ";
                sql += "FROM FluxoCaixa AS FC ";
                sql += "LEFT OUTER JOIN FluxoCaixa_Controle AS FCC ON FCC.ID_FluxoCaixa = FC.ID ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = FC.ID_Conta ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";
                sql += "AND FCC.ID_FluxoCaixa IS NULL ";

                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

                if (FluxoCaixa.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.CodigoDescritivo LIKE '" + FluxoCaixa.GrupoConta.Replace(".  ", "").Replace(" ", "0") + "%' ";

                sql += "AND CONVERT(DATE, FC.Emissao) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";

                sql += "AND FC.Planejamento = 'False' ";
                sql += "AND FC.Conciliado = 'True' ";
                sql += "AND P.Planejamento = 'True' ";

                sql += "UNION ";

                sql += "SELECT DISTINCT ";
                sql += "CR.ID, ";
                sql += "CASE ";
                sql += "WHEN CC.ID_CReceber IS NULL ";
                sql += "THEN CR.Total ";
                sql += "WHEN CC.ID_CReceber IS NOT NULL ";
                sql += "THEN FC.Credito ";
                sql += "END AS Credito, ";
                sql += "0.0 AS Debito, ";
                sql += "FC.Emissao, ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, P.CodigoDescritivo + ' - ' + P.Descricao AS DescricaoContaDetalhado ";
                sql += "FROM V_CReceber AS CR ";
                sql += "LEFT OUTER JOIN FluxoCaixa_Controle AS FCC ON FCC.ID_CReceber = CR.ID ";
                sql += "LEFT JOIN FluxoCaixa AS FC ON FCC.ID_FluxoCaixa = FC.ID ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = CR.ID_Conta ";
                sql += "LEFT JOIN Cartao_Controle AS CC ON CR.ID = CC.ID_CReceber ";
                sql += "WHERE ";
                sql += "NOT CR.ID IS NULL ";
                sql += "AND NOT FCC.ID_FluxoCaixa IS NULL ";
                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

                if (FluxoCaixa.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.CodigoDescritivo LIKE '" + FluxoCaixa.GrupoConta.Replace(".  ", "").Replace(" ", "0") + "%' ";

                sql += "AND CONVERT(DATE, FC.Emissao) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";

                sql += "AND FC.Planejamento = 'False' ";
                sql += "AND FC.Conciliado = 'True' ";
                sql += "AND P.Planejamento = 'True' ";

                sql += "UNION ";

                sql += "SELECT DISTINCT ";
                sql += "CP.ID, 0.0 AS Credito, CP.Total AS Debito, ";
                sql += "FC.Emissao, ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, P.CodigoDescritivo + ' - ' + P.Descricao AS DescricaoContaDetalhado ";
                sql += "FROM V_CPagar AS CP ";
                sql += "LEFT OUTER JOIN FluxoCaixa_Controle AS FCC ON FCC.ID_CPagar = CP.ID ";
                sql += "LEFT JOIN FluxoCaixa AS FC ON FCC.ID_FluxoCaixa = FC.ID ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = CP.ID_Conta ";
                sql += "WHERE ";
                sql += "NOT CP.ID IS NULL ";
                sql += "AND NOT FCC.ID_FluxoCaixa IS NULL ";
                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

                if (FluxoCaixa.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND P.CodigoDescritivo LIKE '" + FluxoCaixa.GrupoConta.Replace(".  ", "").Replace(" ", "0") + "%' ";

                sql += "AND CONVERT(DATE, FC.Emissao) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";
                sql += "AND FC.Planejamento = 'False' ";
                sql += "AND FC.Conciliado = 'True' ";
                sql += "AND P.Planejamento = 'True' ";

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

                sql = "SELECT * ";
                sql += "FROM V_Planejamento ";
                sql += "WHERE ";
                sql += "ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";
                sql += "AND CONVERT(DATE, Vencimento) BETWEEN CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + FluxoCaixa.Consulta_Emissao.Final + "') ";
                sql += "ORDER BY Vencimento";

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
                sql += "FC.Emissao, FC.Credito, FC.Debito,  ";

                sql += "CASE FC.Conciliado ";
                sql += "WHEN 'True' THEN 'SIM' ";
                sql += "WHEN 'False' THEN 'NÃO' ";
                sql += "END AS Conciliado, ";

                sql += "C.Banco, C.Cheque, C.Vencimento, C.Valor, ";
                sql += "PG.Descricao AS DescricaoPagamento, ";
                sql += "GC.Descricao AS DescricaoCaixa, ";

                sql += "CASE C.Situacao ";
                sql += "WHEN 1 THEN 'DISPONÍVEL' ";
                sql += "WHEN 2 THEN 'DEVOLVIDO' ";
                sql += "WHEN 3 THEN 'DEPOSITADO' ";
                sql += "WHEN 4 THEN 'PAGTO. TERCEIRO' ";
                sql += "WHEN 5 THEN 'COMPENSADO' ";
                sql += "END AS SituacaoCheque ";

                sql += "FROM FluxoCaixa AS FC ";
                sql += "LEFT JOIN Pagamento AS PG ON FC.ID_Pagamento = PG.ID ";
                sql += "LEFT JOIN Cheque AS C ON FC.ID_Cheque = C.ID ";
                sql += "LEFT JOIN Grupo AS GC ON FC.Caixa = GC.ID ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";

                sql += "AND FC.ID IN (" + FluxoCaixa.ListaID + ") ";

                if (FluxoCaixa.SomenteCheque == true)
                    sql += "AND FC.ID_Cheque > 0 ";

                sql += "ORDER BY FC.Emissao, FC.ID ";

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

        public DataTable Busca_Controle()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "FC.ID_FluxoCaixa, FC.ID_CPagar, FC.ID_CReceber ";
                sql += "FROM FluxoCaixa_Controle AS FC ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";

                if (FluxoCaixa.ID > 0)
                    sql += "AND FC.ID_FluxoCaixa = " + FluxoCaixa.ID + " ";

                if (FluxoCaixa.ID_CPagar > 0)
                    sql += "AND FC.ID_CPagar = " + FluxoCaixa.ID_CPagar + " ";

                if (FluxoCaixa.ID_CReceber > 0)
                    sql += "AND FC.ID_CReceber = " + FluxoCaixa.ID_CReceber + " ";

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

        public DataTable Busca_Saldo()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "(SUM(FC.Credito) - SUM(FC.Debito)) AS Saldo ";
                sql += "FROM FluxoCaixa AS FC ";
                sql += "WHERE ";
                sql += "NOT FC.ID IS NULL ";
                sql += "AND FC.ID_Empresa = " + FluxoCaixa.ID_Empresa + " ";

                if (FluxoCaixa.Planejamento == false)
                    sql += "AND Planejamento = 'false' ";

                if (FluxoCaixa.Conciliado == true)
                    sql += "AND FC.Conciliado = 'true' ";

                if (FluxoCaixa.Caixa > 0)
                    sql += "AND FC.Caixa = " + FluxoCaixa.Caixa + " ";

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

                sql = "DELETE FROM FluxoCaixa ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", FluxoCaixa.ID);
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
