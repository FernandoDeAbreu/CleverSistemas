using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_Cartao
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Cartao Cartao;
        #endregion

        #region CONSTRUTOR
        public DAL_Cartao(DTO_Cartao _Cartao)
        {
            this.Cartao = _Cartao;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                if (Cartao.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Cartao ";
                    sql += "(ID_Empresa, ID_Pagamento, Emissao, Vencimento, Valor, QuantidadeParcela, Parcela, Baixado) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @ID_Pagamento, @Emissao, @Vencimento, @Valor, @QuantidadeParcela, @Parcela, @Baixado) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Cartao.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Pagamento", Cartao.ID_Pagamento);
                    cmd.Parameters.AddWithValue("@Emissao", Cartao.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", Cartao.Vencimento);
                    cmd.Parameters.AddWithValue("@Valor", Cartao.Valor);
                    cmd.Parameters.AddWithValue("@QuantidadeParcela", Cartao.QuantidadeParcela);
                    cmd.Parameters.AddWithValue("@Parcela", Cartao.Parcela);
                    cmd.Parameters.AddWithValue("@Baixado", Cartao.Baixado);

                    Cartao.ID = conexao.Executa_ComandoID(cmd);

                    if (Cartao.lst_CReceber != null)
                    {
                        for (int i = 0; i <= Cartao.lst_CReceber.Count - 1; i++)
                        {
                            cmd = new SqlCommand();

                            sql = "INSERT INTO ";
                            sql += "Cartao_Controle ";
                            sql += "(ID_Cartao, ID_CReceber) ";
                            sql += "VALUES ";
                            sql += "(@ID_Cartao, @ID_CReceber) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Cartao", Cartao.ID);
                            cmd.Parameters.AddWithValue("@ID_CReceber", Cartao.lst_CReceber[i].ID);

                            conexao.Executa_Comando(cmd);
                        }
                    }
                    else
                    {
                        cmd = new SqlCommand();

                        sql = "INSERT INTO ";
                        sql += "Cartao_Controle ";
                        sql += "(ID_Cartao, ID_CReceber) ";
                        sql += "VALUES ";
                        sql += "(@ID_Cartao, @ID_CReceber) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Cartao", Cartao.ID);
                        cmd.Parameters.AddWithValue("@ID_CReceber", Cartao.ID_CReceber);

                        conexao.Executa_Comando(cmd);
                    }
                }
                else
                {
                    sql = "UPDATE Cartao SET ";
                    sql += "ID_Pagamento = @ID_Pagamento, ";
                    sql += "Emissao =  @Emissao, ";
                    sql += "Vencimento = @Vencimento, ";
                    sql += "Valor = @Valor, ";
                    sql += "QuantidadeParcela = @QuantidadeParcela, ";
                    sql += "Parcela = @Parcela, ";
                    sql += "Baixado = @Baixado ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Cartao.ID);
                    cmd.Parameters.AddWithValue("@ID_Pagamento", Cartao.ID_Pagamento);
                    cmd.Parameters.AddWithValue("@Emissao", Cartao.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", Cartao.Vencimento);
                    cmd.Parameters.AddWithValue("@Valor", Cartao.Valor);
                    cmd.Parameters.AddWithValue("@QuantidadeParcela", Cartao.QuantidadeParcela);
                    cmd.Parameters.AddWithValue("@Parcela", Cartao.Parcela);
                    cmd.Parameters.AddWithValue("@Baixado", Cartao.Baixado);

                    conexao.Executa_Comando(cmd);
                }
                return Cartao.ID;
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

        public void Baixa()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Cartao SET ";
                sql += "Baixado = @Baixado, ";
                sql += "Data_Baixa = @Data_Baixa ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Cartao.ID);
                cmd.Parameters.AddWithValue("@Baixado", Cartao.Baixado);
                cmd.Parameters.AddWithValue("@Data_Baixa", Cartao.Data_Baixa);

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

                sql = "SELECT DISTINCT ";
                sql += "C.ID, C.ID_Empresa, C.ID_Pagamento, C.Emissao, C.Vencimento, C.Valor, C.QuantidadeParcela, C.Parcela, C.Baixado, ";
                sql += "CAST(C.Parcela AS VARCHAR(10)) + '/' + CAST(C.QuantidadeParcela AS VARCHAR(10)) AS ResumoParcela, C.Data_Baixa, ";
                sql += "((P.Porc_Custo / 100) * C.Valor) AS Desconto, ";
                sql += "(C.Valor - ((P.Porc_Custo / 100) * C.Valor)) AS Valor_Liquido, ";

                sql += "STUFF((SELECT CAST('(' AS VARCHAR(MAX)) + CR.Documento + CAST(')' AS VARCHAR(MAX)) ";
                sql += " FROM Cartao_Controle AS CC ";
                sql += " INNER JOIN V_CReceber AS CR ON CC.ID_CReceber = CR.ID ";
                sql += " WHERE CC.ID_Cartao = C.ID ";
                sql += " ORDER BY CR.Documento ";
                sql += " FOR XML PATH('')), 1, 1, '(') AS Documento, ";

                sql += "P.Descricao ";
                sql += "FROM Cartao AS C ";
                sql += "INNER JOIN Cartao_Controle AS CC ON CC.ID_Cartao = C.ID ";
                sql += "INNER JOIN Pagamento AS P ON P.ID = C.ID_Pagamento ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";

                if (Cartao.Filtra_Baixado == true)
                    sql += "AND C.Baixado = '" + Cartao.Baixado + "' ";

                if (Cartao.ID > 0)
                    sql += "AND C.ID = " + Cartao.ID + " ";

                if (Cartao.ID_Pagamento > 0)
                    sql += "AND C.ID_Pagamento = " + Cartao.ID_Pagamento + " ";

                if (Cartao.Consulta_Baixa.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Data_Baixa) BETWEEN CONVERT(DATE, '" + Cartao.Consulta_Baixa.Inicial + "') AND CONVERT(DATE, '" + Cartao.Consulta_Baixa.Final + "') ";

                if (Cartao.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Emissao) BETWEEN CONVERT(DATE, '" + Cartao.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Cartao.Consulta_Emissao.Final + "') ";

                if (Cartao.Consulta_Vencimento.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Vencimento) BETWEEN CONVERT(DATE, '" + Cartao.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + Cartao.Consulta_Vencimento.Final + "') ";

                sql += "GROUP BY  C.ID, C.ID_Empresa, C.ID_Pagamento, C.Emissao, C.Vencimento, C.Valor, ";
                sql += "C.QuantidadeParcela, C.Parcela, C.Baixado, C.Data_Baixa, P.Descricao, P.Porc_Custo, cc.ID_CReceber ";
                sql += "ORDER BY C.Vencimento ";

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

        public DataTable Busca_Lancamento()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "V_CR.ID AS ID_CReceber, V_CR.DescricaoPessoa, V_CR.Documento  ";
                sql += "FROM Cartao_Controle AS CC  ";
                sql += "LEFT JOIN V_CReceber AS V_CR ON V_CR.ID = CC.ID_CReceber ";
                sql += "WHERE ";
                sql += "NOT CC.ID_Cartao IS NULL ";

                if (Cartao.ID > 0)
                    sql += "AND CC.ID_Cartao = " + Cartao.ID + " ";

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

            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM Cartao_Controle ";
                sql += "WHERE ";
                sql += "ID_Cartao = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Cartao.ID);
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM Cartao ";
                sql += "WHERE ";
                sql += "ID = @ID";
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
    }
}
