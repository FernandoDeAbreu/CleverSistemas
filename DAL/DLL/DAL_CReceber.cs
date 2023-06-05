using Sistema.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.DAL
{
    public class DAL_CReceber
    {
        #region VARIAVEIS DIVERSAS

        private Conexao conexao;

        private string sql;

        private SqlCommand cmd;

        #endregion VARIAVEIS DIVERSAS

        #region ESTRUTURA

        private DTO_CReceber CReceber;

        #endregion ESTRUTURA

        #region CONSTRUTOR

        public DAL_CReceber(DTO_CReceber _CReceber)
        {
            CReceber = _CReceber;
        }

        #endregion CONSTRUTOR

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (CReceber.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "CReceber ";
                    sql += "(ID_Empresa, ID_Conta, Situacao, Documento, Emissao, Vencimento, TipoPessoa, ID_Pessoa, ";
                    sql += "Valor, QuantidadeParcela, Parcela, Descricao, Desconto, Acrescimo, ";
                    sql += "Controle, Boleto, ID_Venda, ID_PrevisaoPagto, ID_OS) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @ID_Conta, @Situacao, @Documento, @Emissao, @Vencimento, @TipoPessoa, @ID_Pessoa, ";
                    sql += "@Valor, @QuantidadeParcela, @Parcela, @Descricao, @Desconto, @Acrescimo, ";
                    sql += "@Controle, @Boleto, @ID_Venda, @ID_PrevisaoPagto, @ID_OS) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", CReceber.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Conta", CReceber.ID_Conta);
                    cmd.Parameters.AddWithValue("@Situacao", CReceber.Situacao);
                    cmd.Parameters.AddWithValue("@Documento", CReceber.Documento);
                    cmd.Parameters.AddWithValue("@Emissao", CReceber.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", CReceber.Vencimento);
                    cmd.Parameters.AddWithValue("@TipoPessoa", CReceber.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", CReceber.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Valor", CReceber.Valor);
                    cmd.Parameters.AddWithValue("@QuantidadeParcela", CReceber.QuantidadeParcela);
                    cmd.Parameters.AddWithValue("@Parcela", CReceber.Parcela);
                    cmd.Parameters.AddWithValue("@Descricao", CReceber.Descricao);
                    cmd.Parameters.AddWithValue("@Desconto", CReceber.Desconto);
                    cmd.Parameters.AddWithValue("@Acrescimo", CReceber.Acrescimo);
                    cmd.Parameters.AddWithValue("@Controle", CReceber.Controle);
                    cmd.Parameters.AddWithValue("@Boleto", "False");
                    cmd.Parameters.AddWithValue("@ID_Venda", CReceber.ID_Venda);
                    cmd.Parameters.AddWithValue("@ID_PrevisaoPagto", CReceber.ID_PrevisaoPagto);
                    cmd.Parameters.AddWithValue("@ID_OS", CReceber.ID_OS);
                    CReceber.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "CReceber SET ";
                    sql += "ID_Conta = @ID_Conta, ";
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
                    sql += "Controle = @Controle, ";
                    sql += "ID_PrevisaoPagto = @ID_PrevisaoPagto ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                    cmd.Parameters.AddWithValue("@ID_Conta", CReceber.ID_Conta);
                    cmd.Parameters.AddWithValue("@Situacao", CReceber.Situacao);
                    cmd.Parameters.AddWithValue("@Documento", CReceber.Documento);
                    cmd.Parameters.AddWithValue("@Emissao", CReceber.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", CReceber.Vencimento);
                    cmd.Parameters.AddWithValue("@TipoPessoa", CReceber.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", CReceber.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Valor", CReceber.Valor);
                    cmd.Parameters.AddWithValue("@QuantidadeParcela", CReceber.QuantidadeParcela);
                    cmd.Parameters.AddWithValue("@Parcela", CReceber.Parcela);
                    cmd.Parameters.AddWithValue("@Descricao", CReceber.Descricao);
                    cmd.Parameters.AddWithValue("@Desconto", CReceber.Desconto);
                    cmd.Parameters.AddWithValue("@Acrescimo", CReceber.Acrescimo);
                    cmd.Parameters.AddWithValue("@Controle", CReceber.Controle);
                    cmd.Parameters.AddWithValue("@ID_PrevisaoPagto", CReceber.ID_PrevisaoPagto);

                    conexao.Executa_Comando(cmd);
                }
                return CReceber.ID;
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

                switch (CReceber.Altera_Registro)
                {
                    case 1: //ALTERAR GRUPO CONTA LANÇAMENTO
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "ID_Conta = @ID_Conta ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@ID_Conta", CReceber.ID_Conta);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 2: //ALTERAR PESSOA
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "TipoPessoa = @TipoPessoa, ";
                        sql += "ID_Pessoa = @ID_Pessoa ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@TipoPessoa", CReceber.TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", CReceber.ID_Pessoa);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 3: //ALTERAR VALOR
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "Valor = @Valor, ";
                        sql += "Desconto = @Desconto, ";
                        sql += "Acrescimo = @Acrescimo ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@Valor", CReceber.Valor);
                        cmd.Parameters.AddWithValue("@Desconto", CReceber.Desconto);
                        cmd.Parameters.AddWithValue("@Acrescimo", CReceber.Acrescimo);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 4: //ALTERAR LANÇAMENTO
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "ID_Conta = @ID_Conta, ";
                        sql += "GrupoConta = @GrupoConta, ";
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
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@ID_Conta", CReceber.ID_Conta);
                        cmd.Parameters.AddWithValue("@GrupoConta", CReceber.GrupoConta);
                        cmd.Parameters.AddWithValue("@Situacao", CReceber.Situacao);
                        cmd.Parameters.AddWithValue("@Documento", CReceber.Documento);
                        cmd.Parameters.AddWithValue("@Emissao", CReceber.Emissao);
                        cmd.Parameters.AddWithValue("@Vencimento", CReceber.Vencimento);
                        cmd.Parameters.AddWithValue("@TipoPessoa", CReceber.TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", CReceber.ID_Pessoa);
                        cmd.Parameters.AddWithValue("@Descricao", CReceber.Descricao);
                        cmd.Parameters.AddWithValue("@Valor", CReceber.Valor);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 5: //ALTERAR BOLETO
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "Boleto = @Boleto ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@Boleto", CReceber.Boleto);
                        conexao.Executa_Comando(cmd);
                        break;

                    case 6: //ALTERAR INFORMAÇÕES DE BAIXA
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "Situacao = @Situacao, ";
                        sql += "DataBaixa = @DataBaixa, ";
                        sql += "Desconto = @Desconto, ";
                        sql += "Acrescimo = @Acrescimo ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@Situacao", CReceber.Situacao);
                        cmd.Parameters.AddWithValue("@DataBaixa", CReceber.DataBaixa);
                        cmd.Parameters.AddWithValue("@Desconto", CReceber.Desconto);
                        cmd.Parameters.AddWithValue("@Acrescimo", CReceber.Acrescimo);

                        conexao.Executa_Comando(cmd);
                        break;

                    case 7: //DATA DE VENCIMENTO
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "Vencimento = @Vencimento ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@Vencimento", CReceber.Vencimento);

                        conexao.Executa_Comando(cmd);
                        break;

                    case 8: //ALTERA DESCRIÇÃO CONTA
                        sql = "UPDATE ";
                        sql += "CReceber SET ";
                        sql += "Descricao = Descricao + @Descricao ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", CReceber.ID);
                        cmd.Parameters.AddWithValue("@Descricao", CReceber.Descricao);

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
                sql += "DescricaoPessoa, DescricaoSituacao, Boleto, ID_Venda, PrevisaoPagto, ID_PrevisaoPagto ";
                sql += "FROM V_CReceber ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Empresa = " + CReceber.ID_Empresa + " ";

                if (CReceber.Filtra_Boleto == true)
                    sql += "AND Boleto = '" + CReceber.Boleto + "' ";

                if (CReceber.ID > 0)
                    sql += "AND ID = " + CReceber.ID + " ";

                if (CReceber.Situacao > 0)
                    sql += "AND Situacao = " + CReceber.Situacao + " ";

                if (CReceber.ID_PrevisaoPagto > 0)
                    sql += "AND ID_PrevisaoPagto = " + CReceber.ID_PrevisaoPagto + " ";

                if (CReceber.Documento != String.Empty)
                    sql += "AND Documento = '" + CReceber.Documento + "' ";

                if (CReceber.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + CReceber.TipoPessoa + " ";

                if (CReceber.TipoPessoa > 0 && CReceber.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa = " + CReceber.ID_Pessoa + " ";

                if (CReceber.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND Conta LIKE '" + CReceber.GrupoConta.Replace(".  ", "").Replace(" ", "0") + "%' ";

                if (CReceber.Consulta_Baixa.Filtra == true)
                    sql += "AND CONVERT(DATE, DataBaixa) BETWEEN CONVERT(DATE, '" + CReceber.Consulta_Baixa.Inicial + "') AND CONVERT(DATE, '" + CReceber.Consulta_Baixa.Final + "') ";

                if (CReceber.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, Emissao) BETWEEN CONVERT(DATE, '" + CReceber.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + CReceber.Consulta_Emissao.Final + "') ";

                if (CReceber.Consulta_Vencimento.Filtra == true)
                    sql += "AND CONVERT(DATE, Vencimento) BETWEEN CONVERT(DATE, '" + CReceber.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + CReceber.Consulta_Vencimento.Final + "') ";

                if (CReceber.Ordena_Por == 1)
                    sql += "ORDER BY TipoPessoa, ID_Pessoa, Vencimento ";

                if (CReceber.Ordena_Por == 2)
                    sql += "ORDER BY  Vencimento, TipoPessoa, ID_Pessoa ";

                if (CReceber.Ordena_Por == 3)
                    sql += "ORDER BY  DataBaixa, TipoPessoa, ID_Pessoa ";

                if (CReceber.Ordena_Por == 4)
                    sql += "ORDER BY  Vencimento, ID_PrevisaoPagto, ID ";

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

        public DataTable Busca_Boleto()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "BC.ID_Conta ";
                sql += "FROM BoletoControle AS BC ";
                sql += "INNER JOIN Boleto AS B ON B.ID = BC.ID_Boleto ";
                sql += "WHERE ";
                sql += "NOT BC.ID IS NULL ";
                sql += "AND BC.ID_Conta IN (" + CReceber.ListaID + ") ";
                sql += "AND B.Cancelado = 'false' ";

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

        public DataTable Busca_Informe()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.Vencimento, C.DataBaixa, C.Valor, C.Documento, ";
                sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) AS ResumoParcela ";

                sql += "FROM CReceber AS C ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND C.ID_Empresa = " + CReceber.ID_Empresa + " ";

                if (CReceber.Situacao > 0)
                    sql += "AND C.Situacao = " + CReceber.Situacao + " ";

                if (CReceber.Documento != String.Empty)
                    sql += "AND C.Documento LIKE '" + CReceber.Documento + "' ";

                if (CReceber.TipoPessoa > 0)
                    sql += "AND C.TipoPessoa = " + CReceber.TipoPessoa + " ";

                if (CReceber.TipoPessoa > 0 && CReceber.ID_Pessoa > 0)
                    sql += "AND C.ID_Pessoa = " + CReceber.ID_Pessoa + " ";

                if (CReceber.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND C.GrupoConta LIKE '" + CReceber.GrupoConta.Replace(".  ", "") + "%' ";

                if (CReceber.Consulta_Baixa.Filtra == true)
                    sql += "AND CONVERT(DATE, C.DataBaixa) BETWEEN CONVERT(DATE, '" + CReceber.Consulta_Baixa.Inicial + "') AND CONVERT(DATE, '" + CReceber.Consulta_Baixa.Final + "') ";

                if (CReceber.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Emissao) BETWEEN CONVERT(DATE, '" + CReceber.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + CReceber.Consulta_Emissao.Final + "') ";

                if (CReceber.Consulta_Vencimento.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Vencimento) BETWEEN CONVERT(DATE, '" + CReceber.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + CReceber.Consulta_Vencimento.Final + "') ";

                sql += "ORDER BY C.Parcela ";

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
                sql += "C.ID, C.ID_Empresa, C.ID_Conta, C.GrupoConta, C.Situacao, C.Documento, C.Emissao, C.Vencimento, C.TipoPessoa, C.ID_Pessoa, C.Valor, C.Parcelado, ";
                sql += "C.QuantidadeParcela, C.Parcela, ";
                sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) AS ResumoParcela, ";
                sql += "C.Descricao, C.DataBaixa, C.Desconto, ";
                sql += "C.Acrescimo, C.Caixa, C.ID_Pagamento, C.InformacaoBaixa, C.Controle,  ";
                sql += "P.CodigoDescritivo AS Conta, P.Descricao AS DescricaoConta, ";
                sql += "Pessoa.Nome_Razao AS DescricaoPessoa, ";

                sql += "CASE C.Situacao ";
                sql += "WHEN 1 THEN 'EM ABERTO' ";
                sql += "WHEN 2 THEN 'PAGO' ";
                sql += "END AS DescricaoSituacao ";

                sql += "FROM CReceber AS C ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = C.ID_Conta ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = C.TipoPessoa AND Pessoa.ID_Pessoa = C.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND C.ID IN (" + CReceber.ListaID + ") ";
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
                sql += "FROM CReceber AS C ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = C.ID_Conta ";
                sql += "LEFT JOIN Pagamento AS PG ON PG.ID = C.ID_Pagamento ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = C.TipoPessoa AND Pessoa.ID_Pessoa = C.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";

                if (CReceber.ID > 0)
                    sql += "AND C.ID = " + CReceber.ID + " ";

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
                sql += "C.Conta, C.DescricaoConta, C.DescricaoPessoa, C.DescricaoSituacao, C.Boleto, C.ID_Venda, C.PrevisaoPagto, C.ID_PrevisaoPagto ";
                sql += "FROM V_CReceber AS C ";
                sql += "LEFT JOIN PlanoConta AS P ON P.ID = C.ID_Conta ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND P.Planejamento = 'true'";

                if (CReceber.Situacao > 0)
                    sql += "AND C.Situacao = 1 ";

                if (CReceber.GrupoConta.Replace(" ", "").Replace(".", "") != "")
                    sql += "AND C.GrupoConta LIKE '" + CReceber.GrupoConta.Replace(".  ", "") + "%' ";

                sql += "AND CONVERT(DATE, C.Vencimento) BETWEEN CONVERT(DATE, '" + CReceber.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + CReceber.Consulta_Vencimento.Final + "') ";
                sql += "AND C.ID_Empresa = " + CReceber.ID_Empresa + " ";

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

        public DataTable Busca_NFe()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                //CASE WHEN devido a PK

                sql = "SELECT ";
                sql += "CASE WHEN C.Vencimento IS NULL THEN '9' + CAST(R.Id AS VARCHAR(10)) ELSE '8' + CAST(C.Id AS VARCHAR(10)) END AS NumeroDuplicata, ";
                sql += "ISNULL(C.Valor, R.Valor) AS Valor, ISNULL(C.Vencimento, R.Vencimento) as Vencimento ";
                sql += "FROM CReceber R ";
                sql += "LEFT JOIN Cartao_Controle AS CC on CC.ID_CReceber = R.ID ";
                sql += "LEFT JOIN Cartao AS C on C.ID = CC.ID_Cartao ";
                sql += "WHERE ";
                sql += "NOT R.ID IS NULL ";

                if (CReceber.ID_Venda > 0)
                    sql += "AND R.ID_Venda = " + CReceber.ID_Venda + " ";

                if (CReceber.ID_OS > 0)
                    sql += "AND R.ID_OS = " + CReceber.ID_OS + " ";

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

        public DataTable Busca_Fatura_NFe()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                sql = "SELECT ";
                sql += "C.ID, (C.Acrescimo + C.Valor) AS Valor, C.Desconto,  C.Vencimento,  ";
                sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) AS ResumoParcela, ";
                sql += "P.Descricao AS Pagamento ";
                sql += "FROM CReceber AS C ";
                sql += "INNER JOIN Pagamento AS P ON C.ID_Pagamento = P.ID ";
                sql += "WHERE ";
                sql += "C.ID_NFe = " + CReceber.ID_NFe + " ";
                sql += "AND C.ID_Empresa = " + CReceber.ID_Empresa + " ";
                sql += "ORDER BY C.ID ";

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

        public DataTable Busca_ContaAtraso()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "Vencimento, ResumoParcela, Descricao, Total, DescricaoSituacao ";
                sql += "FROM V_CReceber ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Empresa = " + CReceber.ID_Empresa + " ";
                sql += "AND Situacao = " + CReceber.Situacao + " ";
                sql += "AND ID_PrevisaoPagto <> 2 ";
                sql += "AND TipoPessoa = " + CReceber.TipoPessoa + " ";
                sql += "AND ID_Pessoa = " + CReceber.ID_Pessoa + " ";
                sql += "AND Vencimento < '" + CReceber.Vencimento + "' ";

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
                sql += "CReceber ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", CReceber.ID);

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