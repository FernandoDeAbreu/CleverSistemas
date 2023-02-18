using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;
using System.IO;

namespace Sistema.DAL
{
    public class DAL_Boleto
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Boleto Boleto;
        #endregion

        #region CONSTRUTOR
        public DAL_Boleto(DTO_Boleto _Boleto)
        {
            this.Boleto = _Boleto;
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

                if (Boleto.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Boleto ";
                    sql += "(NossoNumero, TipoPessoa, ID_Pessoa, ID_Empresa, ID_Cedente, Valor, Acrescimo, Desconto, Emissao, Vencimento, ";
                    sql += "Documento, Liquidado, Remessa, Tipo_Remessa, Cancelado) ";
                    sql += "VALUES ";
                    sql += "(@NossoNumero, @TipoPessoa, @ID_Pessoa, @ID_Empresa, @ID_Cedente, @Valor, @Acrescimo, @Desconto, @Emissao, @Vencimento, ";
                    sql += "@Documento, @Liquidado, @Remessa, @Tipo_Remessa, @Cancelado) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NossoNumero", Boleto.NossoNumero);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Boleto.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Boleto.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Boleto.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Cedente", Boleto.ID_Cedente);
                    cmd.Parameters.AddWithValue("@Valor", Boleto.Valor);
                    cmd.Parameters.AddWithValue("@Acrescimo", Boleto.Acrescimo);
                    cmd.Parameters.AddWithValue("@Desconto", Boleto.Desconto);
                    cmd.Parameters.AddWithValue("@Emissao", Boleto.Emissao);
                    cmd.Parameters.AddWithValue("@Vencimento", Boleto.Vencimento);
                    cmd.Parameters.AddWithValue("@Documento", Boleto.Documento);
                    cmd.Parameters.AddWithValue("@Liquidado", Boleto.Liquidado);
                    cmd.Parameters.AddWithValue("@Remessa", Boleto.Remessa);
                    cmd.Parameters.AddWithValue("@Tipo_Remessa", Boleto.Movimento_Remessa);
                    cmd.Parameters.AddWithValue("@Cancelado", Boleto.Cancelado);

                    Boleto.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    if (Boleto.Movimento_Remessa == 2) // REMESSA GERADA, SÓ ALTERA VENCIMENTO
                    {
                        sql = "UPDATE Boleto SET ";
                        sql += "Vencimento = @Vencimento ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", Boleto.ID);
                        cmd.Parameters.AddWithValue("@Vencimento", Boleto.Vencimento);
                    }
                    if (Boleto.Movimento_Remessa == 1) // REMESSA NÃO GERADA, PERMITE ALTERAÇÃO TOTAL
                    {
                        sql = "UPDATE Boleto SET ";
                        sql += "TipoPessoa = @TipoPessoa, ";
                        sql += "ID_Pessoa = @ID_Pessoa, ";
                        sql += "ID_Empresa = @ID_Empresa, ";
                        sql += "Valor = @Valor, ";
                        sql += "Acrescimo = @Acrescimo, ";
                        sql += "Desconto = @Desconto, ";
                        sql += "Emissao = @Emissao, ";
                        sql += "Vencimento = @Vencimento, ";
                        sql += "Documento = @Documento, ";
                        sql += "Liquidado = @Liquidado, ";
                        sql += "Remessa = @Remessa, ";
                        sql += "Tipo_Remessa = @Tipo_Remessa, ";
                        sql += "Cancelado = @Cancelado ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", Boleto.ID);
                        cmd.Parameters.AddWithValue("@TipoPessoa", Boleto.TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", Boleto.ID_Pessoa);
                        cmd.Parameters.AddWithValue("@ID_Empresa", Boleto.ID_Empresa);
                        cmd.Parameters.AddWithValue("@Valor", Boleto.Valor);
                        cmd.Parameters.AddWithValue("@Acrescimo", Boleto.Acrescimo);
                        cmd.Parameters.AddWithValue("@Desconto", Boleto.Desconto);
                        cmd.Parameters.AddWithValue("@Emissao", Boleto.Emissao);
                        cmd.Parameters.AddWithValue("@Vencimento", Boleto.Vencimento);
                        cmd.Parameters.AddWithValue("@Documento", Boleto.Documento);
                        cmd.Parameters.AddWithValue("@Liquidado", Boleto.Liquidado);
                        cmd.Parameters.AddWithValue("@Remessa", Boleto.Remessa);
                        cmd.Parameters.AddWithValue("@Tipo_Remessa", Boleto.Movimento_Remessa);
                        cmd.Parameters.AddWithValue("@Cancelado", Boleto.Cancelado);
                    }

                    conexao.Executa_Comando(cmd);
                }

                conexao.Commit_Conexao();
                return Boleto.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Boleto";
                int aux = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = "DBCC CHECKIDENT(Boleto,RESEED, " + aux + ")";
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

        public int Grava_Remessa()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "INSERT INTO ";
                sql += "Boleto_Remessa ";
                sql += "(Emissao, Arquivo) ";
                sql += "VALUES ";
                sql += "(@Emissao, @Arquivo) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Emissao", Boleto.Emissao);
                cmd.Parameters.AddWithValue("@Arquivo", Boleto.Arquivo);

                Boleto.ID_Remessa = conexao.Executa_ComandoID(cmd);

                for (int i = 0; i <= Boleto.ID_Boleto.Length - 1; i++)
                {
                    cmd = new SqlCommand();

                    sql = "INSERT INTO ";
                    sql += "Boleto_RemessaControle ";
                    sql += "(ID_Remessa, ID_Boleto, Movimento) ";
                    sql += "VALUES ";
                    sql += "(@ID_Remessa, @ID_Boleto, @Movimento) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Remessa", Boleto.ID_Remessa);
                    cmd.Parameters.AddWithValue("@ID_Boleto", Boleto.ID_Boleto[i]);
                    cmd.Parameters.AddWithValue("@Movimento", Boleto.Movimento_Remessa);

                    conexao.Executa_Comando(cmd);

                    cmd = new SqlCommand();

                    sql = "UPDATE Boleto SET ";
                    sql += "Remessa = @Remessa ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Remessa", Boleto.Remessa);
                    cmd.Parameters.AddWithValue("@ID", Boleto.ID_Boleto[i]);

                    conexao.Executa_Comando(cmd);
                }

                conexao.Commit_Conexao();

                return Boleto.ID_Remessa;
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

        public void Grava_Barra()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE ";
                sql += "Boleto ";
                sql += "SET CodigoBarra = @Imagem ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Boleto.ID);
                cmd.Parameters.Add("@Imagem", SqlDbType.Binary, (int)Boleto.Imagem.Length).Value = Boleto.ArqByteArray;

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

        public void Grava_Controle()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "INSERT INTO ";
                sql += "BoletoControle ";
                sql += "(ID_Boleto, ID_Conta) ";
                sql += "VALUES ";
                sql += "(@ID_Boleto, @ID_Conta) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Boleto", Boleto.ID);
                cmd.Parameters.AddWithValue("@ID_Conta", Boleto.ID_Conta);

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

        public void Baixa()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Boleto SET ";
                sql += "Acrescimo = @Acrescimo, ";
                sql += "Desconto = @Desconto, ";
                sql += "DataBaixa = @DataBaixa, ";
                sql += "Liquidado = @Liquidado, ";
                sql += "Remessa = @Remessa, ";
                sql += "Tipo_Remessa = @Tipo_Remessa, ";
                sql += "Cancelado = @Cancelado ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Boleto.ID);
                cmd.Parameters.AddWithValue("@Acrescimo", Boleto.Acrescimo);
                cmd.Parameters.AddWithValue("@Desconto", Boleto.Desconto);
                cmd.Parameters.AddWithValue("@DataBaixa", Boleto.DataBaixa);
                cmd.Parameters.AddWithValue("@Liquidado", Boleto.Liquidado);
                cmd.Parameters.AddWithValue("@Remessa", Boleto.Remessa);
                cmd.Parameters.AddWithValue("@Tipo_Remessa", Boleto.Movimento_Remessa);
                cmd.Parameters.AddWithValue("@Cancelado", Boleto.Cancelado);
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

        public void Altera_NossoNumero()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE Boleto SET ";
                sql += "NossoNumero = @NossoNumero ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Boleto.ID);
                cmd.Parameters.AddWithValue("@NossoNumero", Boleto.NossoNumero);

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

                sql = "SELECT ";
                sql += "B.ID, B.ID AS ID_Boleto, B.NossoNumero, B.TipoPessoa, B.ID_Pessoa, B.ID_Empresa, B.ID_Cedente, B.Valor, B.Acrescimo, ";
                sql += "B.Desconto, B.Emissao, B.Vencimento, B.Documento, B.CodigoBarra, ";
                sql += "B.Liquidado, B.Remessa, B.Tipo_Remessa, B.Cancelado, ";

                sql += "CASE B.Liquidado ";
                sql += "WHEN 'true' THEN B.DataBaixa ";
                sql += "WHEN 'false' THEN NULL ";
                sql += "END AS DataBaixa, ";

                sql += "CASE B.Tipo_Remessa ";
                sql += "WHEN 1 THEN 'REGISTRO DE TÍTULO' ";
                sql += "WHEN 2 THEN 'ALTERAÇÃO DE DATA' ";
                sql += "WHEN 3 THEN 'BAIXA DE TÍTULO' ";
                sql += "WHEN 4 THEN 'PROTESTAR' ";
                sql += "WHEN 5 THEN 'SUSTAR PROTESTO E BAIXA DE TÍTULO' ";
                sql += "WHEN 6 THEN 'ALTERAÇÕES DIVERSAS' ";
                sql += "END AS Descricao_Movimento, ";

                sql += "CASE B.Remessa ";
                sql += "WHEN 'true' THEN 'GERADO'";
                sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                sql += "END AS Descricao_Remessa, ";

                sql += "C.Cod_Cedente, C.Carteira, C.Juros, C.DiasJuros, C.Multa, C.DiasMulta, ";
                sql += "C.CNPJ_CPF_Cedente, C.Razao_Cedente, C.UtilizaTarifa, C.Tarifa, C.Instrucao_1, C.Instrucao_2, C.Altera_Data, ";
                sql += "BC.Agencia, BC.Conta, BC.ID_Banco, ";
                sql += "Pessoa.Nome_Razao AS DescricaoPessoa ";
                sql += "FROM Boleto AS B ";
                sql += "INNER JOIN Pessoa AS Pessoa ON Pessoa.TipoPessoa = B.TipoPessoa AND Pessoa.ID_Pessoa = B.ID_Pessoa ";
                sql += "INNER JOIN Cedente AS C ON B.ID_Cedente = C.ID ";
                sql += "INNER JOIN Banco AS BC ON BC.ID = C.ID_Banco ";
                sql += "WHERE ";
                sql += "NOT B.ID IS NULL ";
                sql += "AND B.ID_Empresa = " + Boleto.ID_Empresa + " ";

                if (Boleto.Filtra_Cancelado == true)
                    sql += "AND Cancelado = '" + Boleto.Cancelado + "' ";

                if (Boleto.ID > 0)
                    sql += "AND B.ID = " + Boleto.ID + " ";

                if (Boleto.ID_Cedente > 0)
                    sql += "AND ID_Cedente = " + Boleto.ID_Cedente + " ";

                if (Boleto.TipoPessoa > 0)
                    sql += "AND B.TipoPessoa = " + Boleto.TipoPessoa + " ";

                if (Boleto.ID_Pessoa > 0)
                    sql += "AND B.ID_Pessoa = " + Boleto.ID_Pessoa + " ";

                if (Boleto.Consulta_Baixa.Filtra == true)
                    sql += "AND CONVERT(DATE, B.DataBaixa) BETWEEN CONVERT(DATE, '" + Boleto.Consulta_Baixa.Inicial + "') AND CONVERT(DATE, '" + Boleto.Consulta_Baixa.Final + "') ";

                if (Boleto.Consulta_Emissao.Filtra == true)
                    sql += "AND CONVERT(DATE, B.Emissao) BETWEEN CONVERT(DATE, '" + Boleto.Consulta_Emissao.Inicial + "') AND CONVERT(DATE, '" + Boleto.Consulta_Emissao.Final + "') ";

                if (Boleto.Consulta_Vencimento.Filtra == true)
                    sql += "AND CONVERT(DATE, B.Vencimento) BETWEEN CONVERT(DATE, '" + Boleto.Consulta_Vencimento.Inicial + "') AND CONVERT(DATE, '" + Boleto.Consulta_Vencimento.Final + "') ";

                if (Boleto.List_ID != string.Empty && Boleto.List_ID != null)
                    sql += "AND B.ID IN(" + Boleto.List_ID + ") ";

                if (Boleto.Filtra_Liquidado == true)
                    sql += "AND Liquidado = '" + Boleto.Liquidado + "' ";

                if (Boleto.Filtra_Remessa == true)
                    sql += "AND Remessa = '" + Boleto.Remessa + "' ";


                sql += "ORDER BY B.Vencimento ";

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

        public DataTable Busca_Remessa()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "R.ID AS ID_Remessa, R.Emissao, RIGHT('000000' + convert(varchar(6), R.ID), 6) + '_' + R.Arquivo AS Arquivo, ";
                sql += "RC.Movimento, ";

                sql += "CASE RC.Movimento ";
                sql += "WHEN 1 THEN 'REGISTRO DE TÍTULO' ";
                sql += "WHEN 2 THEN 'ALTERAÇÃO DE DATA' ";
                sql += "WHEN 3 THEN 'BAIXA DE TÍTULO' ";
                sql += "WHEN 4 THEN 'PROTESTAR' ";
                sql += "WHEN 5 THEN 'SUSTAR PROTESTO E BAIXA DE TÍTULO' ";
                sql += "WHEN 6 THEN 'ALTERAÇÕES DIVERSAS' ";
                sql += "END AS Descricao_Movimento, ";

                sql += "B.ID, B.ID AS ID_Boleto, B.NossoNumero, B.TipoPessoa, B.ID_Pessoa, B.ID_Empresa, B.ID_Cedente, B.Valor, B.Acrescimo, ";
                sql += "B.Desconto, B.Emissao, B.Vencimento, B.Documento, B.CodigoBarra, ";
                sql += "B.Liquidado, B.Remessa, ";

                sql += "CASE B.Remessa ";
                sql += "WHEN 'true' THEN 'GERADO'";
                sql += "WHEN 'false' THEN 'NÃO GERADO' ";
                sql += "END AS Descricao_Remessa, ";

                sql += "C.Cod_Cedente, C.Carteira, C.Juros, C.DiasJuros, C.Multa, C.DiasMulta, ";
                sql += "C.CNPJ_CPF_Cedente, C.Razao_Cedente, C.UtilizaTarifa, C.Tarifa, C.Instrucao_1, C.Instrucao_2, ";
                sql += "BC.Agencia, BC.ID_Banco, ";
                sql += "P.Nome_Razao, P.Nome_Razao AS DescricaoPessoa, P.CNPJ_CPF, ";

                sql += "PEND.Logradouro, PEND.NumeroEndereco, PEND.Bairro, PEND.CEP, PEND.Complemento, ";
                sql += "UPPER(M.Descricao) AS NomeMunicipio, ";
                sql += "UF.Sigla ";

                sql += "FROM Boleto_Remessa AS R ";
                sql += "INNER JOIN Boleto_RemessaControle AS RC ON R.ID = RC.ID_Remessa ";
                sql += "INNER JOIN Boleto AS B ON B.ID = RC.ID_Boleto ";
                sql += "INNER JOIN Cedente AS C ON B.ID_Cedente = C.ID ";
                sql += "INNER JOIN Banco AS BC ON BC.ID = C.ID_Banco ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = B.TipoPessoa AND P.ID_Pessoa = B.ID_Pessoa ";
                sql += "LEFT JOIN PessoaEndereco as PEND ON PEND.ID_Pessoa = P.ID_Pessoa AND PEND.TipoPessoa = P.TipoPessoa AND PEND.PrincipalEndereco = 'True' ";
                sql += "LEFT JOIN Municipios AS M ON PEND.ID_Municipio = M.ID ";
                sql += "LEFT JOIN UF ON M.ID_UF = UF.ID_UF ";

                sql += "WHERE ";
                sql += "NOT B.ID IS NULL ";
                sql += "AND B.ID_Empresa = " + Boleto.ID_Empresa + " ";

                if (Boleto.ID_Cedente > 0)
                    sql += "AND C.ID = " + Boleto.ID_Cedente + " ";

                if (Boleto.ID_Remessa > 0)
                    sql += "AND RC.ID_Remessa = " + Boleto.ID_Remessa + " ";

                sql += "ORDER BY B.Vencimento ";

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
                sql += "ID_Boleto, ID_Conta ";
                sql += "FROM BoletoControle ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Boleto.ID > 0)
                    sql += "AND ID_Boleto = " + Boleto.ID + " ";

                if (Boleto.ID_Conta > 0)
                    sql += "AND ID_Conta = " + Boleto.ID_Conta + " ";

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
            DataTable DT;
            DataRow DR;
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID_Conta ";
                sql += "FROM BoletoControle ";
                sql += "WHERE ";
                sql += "ID_Boleto = " + Boleto.ID;
                DT = conexao.Consulta(sql);

                if (DT.Rows.Count > 0)
                    for (int i = 0; i <= DT.Rows.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        DR = DT.Rows[i];
                        sql = "UPDATE CReceber ";
                        sql += "SET Boleto = 'false' ";
                        sql += "WHERE ID = @ID";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", DR["ID_Conta"]);
                        conexao.Executa_Comando(cmd);
                    }

                cmd = new SqlCommand();
                sql = "UPDATE Boleto SET ";
                sql += "Cancelado = @Cancelado, ";
                sql += "Remessa = @Remessa, ";
                sql += "Tipo_Remessa = @Tipo_Remessa ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Boleto.ID);
                cmd.Parameters.AddWithValue("@Cancelado", Boleto.Cancelado);
                cmd.Parameters.AddWithValue("@Remessa", Boleto.Remessa);
                cmd.Parameters.AddWithValue("@Tipo_Remessa", Boleto.Movimento_Remessa);
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