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
    public class DAL_Cheque
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Cheque Cheque;
        #endregion

        #region CONSTRUTOR
        public DAL_Cheque(DTO_Cheque _Cheque)
        {
            Cheque = _Cheque;
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

                if (Cheque.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Cheque ";
                    sql += "(ID_Empresa, Tipo, TipoPessoa, ID_Pessoa, Documento, Emissao, Vencimento, Banco, Agencia, Conta, Cheque, Situacao, Informacao, Valor)";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Tipo, @TipoPessoa, @ID_Pessoa, @Documento, @Emissao, @Vencimento, @Banco, @Agencia, @Conta, @Cheque, @Situacao, @Informacao, @Valor)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Cheque.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Tipo", Cheque.Tipo);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Cheque.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Cheque.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Documento", Cheque.Documento);
                    cmd.Parameters.AddWithValue("@Emissao", Cheque.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", Cheque.Vencimento);
                    cmd.Parameters.AddWithValue("@Banco", Cheque.Banco);
                    cmd.Parameters.AddWithValue("@Agencia", Cheque.Agencia);
                    cmd.Parameters.AddWithValue("@Conta", Cheque.Conta);
                    cmd.Parameters.AddWithValue("@Cheque", Cheque.Cheque);
                    cmd.Parameters.AddWithValue("@Situacao", Cheque.Situacao);
                    cmd.Parameters.AddWithValue("@Informacao", Cheque.Informacao);
                    cmd.Parameters.AddWithValue("@Valor", Cheque.Valor);
                    Cheque.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Cheque SET ";
                    sql += "ID_Empresa =@ID_Empresa, ";
                    sql += "Tipo = @Tipo, ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "Documento = @Documento, ";
                    sql += "Emissao = @Emissao, ";
                    sql += "Vencimento = @Vencimento, ";
                    sql += "Banco = @Banco, ";
                    sql += "Agencia = @Agencia, ";
                    sql += "Conta = @Conta, ";
                    sql += "Cheque = @Cheque, ";
                    sql += "Situacao = @Situacao, ";
                    sql += "Informacao = @Informacao, ";
                    sql += "Valor = @Valor ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Cheque.ID);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Cheque.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Tipo", Cheque.Tipo);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Cheque.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Cheque.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Documento", Cheque.Documento);
                    cmd.Parameters.AddWithValue("@Emissao", Cheque.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", Cheque.Vencimento);
                    cmd.Parameters.AddWithValue("@Banco", Cheque.Banco);
                    cmd.Parameters.AddWithValue("@Agencia", Cheque.Agencia);
                    cmd.Parameters.AddWithValue("@Conta", Cheque.Conta);
                    cmd.Parameters.AddWithValue("@Cheque", Cheque.Cheque);
                    cmd.Parameters.AddWithValue("@Situacao", Cheque.Situacao);
                    cmd.Parameters.AddWithValue("@Informacao", Cheque.Informacao);
                    cmd.Parameters.AddWithValue("@Valor", Cheque.Valor);
                    conexao.Executa_Comando(cmd);
                }
                conexao.Commit_Conexao();

                return Cheque.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Cheque";
                int aux_ID = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Cheque, RESEED, " + aux_ID + ")";
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

        public void Altera_Situacao()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "UPDATE ";
                sql += "Cheque SET ";
                sql += "Situacao = @Situacao ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Cheque.ID);
                cmd.Parameters.AddWithValue("@Situacao", Cheque.Situacao);
                conexao.Executa_Comando(cmd);

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
                sql += "C.ID, C.ID_Empresa, C.Tipo, C.TipoPessoa, C.ID_Pessoa, C.Documento, C.Emissao, C.Vencimento, ";
                sql += "C.Banco, C.Agencia, C.Conta, C.Cheque, C.Situacao, C.Informacao AS Descricao, C.Valor, ";
                sql += "Pessoa.Nome_Razao AS DescricaoPessoa, Pessoa.Nome_Razao AS Titular, ";

                sql += "CASE C.Situacao ";
                sql += "WHEN 1 THEN 'DISPONÍVEL' ";
                sql += "WHEN 2 THEN 'DEVOLVIDO' ";
                sql += "WHEN 3 THEN 'DEPOSITADO' ";
                sql += "WHEN 4 THEN 'PAGTO. TERCEIRO' ";
                sql += "WHEN 5 THEN 'COMPENSADO' ";
                sql += "END AS DescricaoSituacao ";

                sql += "FROM Cheque AS C ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = C.TipoPessoa AND Pessoa.ID_Pessoa = C.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";

                if (Cheque.Tipo > 0)
                    sql += "AND C.Tipo = " + Cheque.Tipo + " ";

                if (Cheque.ID > 0)
                    sql += "AND C.ID = " + Cheque.ID + " ";

                if (Cheque.Situacao > 0)
                    sql += "AND C.Situacao = " + Cheque.Situacao + " ";

                if (Cheque.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Emissao) BETWEEN CONVERT(DATE, '" + Cheque.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Cheque.Consulta_Emissao.Final + "') ";

                if (Cheque.Consulta_Vencimento.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Vencimento) BETWEEN CONVERT(DATE, '" + Cheque.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + Cheque.Consulta_Vencimento.Final + "') ";

                if (Cheque.Documento != null &&
                    Cheque.Documento != String.Empty)
                    sql += "AND C.Documento = '" + Cheque.Documento + "' ";

                if (Cheque.Banco != null &&
                    Cheque.Banco != String.Empty)
                    sql += "AND C.Banco = '" + Cheque.Banco + "' ";

                if (Cheque.Agencia != null &&
                    Cheque.Agencia != String.Empty)
                    sql += "AND C.Agencia = '" + Cheque.Agencia + "' ";

                if (Cheque.Conta != null &&
                    Cheque.Conta != String.Empty)
                    sql += "AND C.Conta = '" + Cheque.Conta + "' ";

                if (Cheque.Cheque != null &&
                    Cheque.Cheque != String.Empty)
                    sql += "AND C.Cheque = '" + Cheque.Cheque + "' ";

                if (Cheque.TipoPessoa > 0)
                    sql += "AND C.TipoPessoa = " + Cheque.TipoPessoa + " ";

                if (Cheque.TipoPessoa > 0 && Cheque.ID_Pessoa > 0)
                    sql += "AND C.ID_Pessoa = " + Cheque.ID_Pessoa + " ";

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

        public DataTable Busca_Resumo()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_CPagar, ID_CReceber, Documento, DataBaixa, Descricao, DescricaoPessoa, DescricaoConta, Credito, Debito, ID_Cheque, Total, ";
                sql += "ID_FluxoCaixa, Emissao, DescricaoCaixa, ID_Caixa, ID_Pagamento, DescricaoContaFluxo, CreditoFluxo, DebitoFluxo ";
                sql += "FROM V_Cheque_Historico ";
                sql += "WHERE ";
                sql += "ID_Cheque = " + Cheque.ID + " ";
                sql += "ORDER BY ID_FluxoCaixa ";

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

        public DataTable Busca_ResumoRelatorio()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.ID, C.ID_Empresa, C.Tipo, C.TipoPessoa, C.ID_Pessoa, C.Documento, C.Emissao, C.Vencimento, ";
                sql += "C.Banco, C.Agencia, C.Conta, C.Cheque, C.Situacao, C.Informacao AS Descricao, C.Valor, ";
                sql += "Pessoa.Nome_Razao AS DescricaoPessoa, Pessoa.Nome_Razao AS Titular, ";

                sql += "CASE C.Situacao ";
                sql += "WHEN 1 THEN 'DISPONÍVEL' ";
                sql += "WHEN 2 THEN 'DEVOLVIDO' ";
                sql += "WHEN 3 THEN 'DEPOSITADO' ";
                sql += "WHEN 4 THEN 'PAGTO. TERCEIRO' ";
                sql += "WHEN 5 THEN 'COMPENSADO' ";
                sql += "END AS DescricaoSituacao, ";

                sql += "V_C.DescricaoPessoa AS Pessoa_FluxoCaixa, V_C.DescricaoConta, V_C.Documento AS Documento_FluxoCaixa, V_C.Credito, V_C.Debito, V_C.Total, ";
                sql += "V_C.Emissao AS EmissaoFluxoCaixa, V_C.DescricaoCaixa, V_C.DescricaoContaFluxo ";

                sql += "FROM Cheque AS C ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = C.TipoPessoa AND Pessoa.ID_Pessoa = C.ID_Pessoa ";
                sql += "LEFT JOIN V_Cheque_Historico AS V_C ON V_C.ID_Cheque = C.ID ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                //sql += "AND C.Tipo = " + Cheque.Tipo + " ";

                if (Cheque.ID > 0)
                    sql += "AND C.ID = " + Cheque.ID + " ";

                if (Cheque.Situacao > 0)
                    sql += "AND C.Situacao = " + Cheque.Situacao + " ";

                if (Cheque.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Emissao) BETWEEN CONVERT(DATE, '" + Cheque.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Cheque.Consulta_Emissao.Final + "') ";

                if (Cheque.Consulta_Vencimento.Filtra == true)
                    sql += "AND CONVERT(DATE, C.Vencimento) BETWEEN CONVERT(DATE, '" + Cheque.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + Cheque.Consulta_Vencimento.Final + "') ";

                if (Cheque.Documento != null &&
                    Cheque.Documento != String.Empty)
                    sql += "AND C.Documento = '" + Cheque.Documento + "' ";

                if (Cheque.Banco != null &&
                    Cheque.Banco != String.Empty)
                    sql += "AND C.Banco = '" + Cheque.Banco + "' ";

                if (Cheque.Agencia != null &&
                    Cheque.Agencia != String.Empty)
                    sql += "AND C.Agencia = '" + Cheque.Agencia + "' ";

                if (Cheque.Conta != null &&
                    Cheque.Conta != String.Empty)
                    sql += "AND C.Conta = '" + Cheque.Conta + "' ";

                if (Cheque.Cheque != null &&
                    Cheque.Cheque != String.Empty)
                    sql += "AND C.Cheque = '" + Cheque.Cheque + "' ";

                if (Cheque.TipoPessoa > 0)
                    sql += "AND C.TipoPessoa = " + Cheque.TipoPessoa + " ";

                if (Cheque.TipoPessoa > 0 && Cheque.ID_Pessoa > 0)
                    sql += "AND C.ID_Pessoa = " + Cheque.ID_Pessoa + " ";

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

        public void Exclui()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Cheque ";
                sql += "FROM ";
                sql += "FluxoCaixa ";
                sql += "WHERE ";
                sql += "ID_Cheque = " + Cheque.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    throw new Exception(util_msg.msg_DAL_Erro_Exclui + "Fluxo de Caixa");

                sql = "DELETE FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Cheque.ID);
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
