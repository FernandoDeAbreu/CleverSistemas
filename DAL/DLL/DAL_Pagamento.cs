using Sistema.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.DAL
{
    public class DAL_Pagamento
    {
        #region VARIAVEIS DIVERSAS

        private Conexao conexao;
        private SqlCommand cmd;

        private string sql;
        private string msg;

        #endregion VARIAVEIS DIVERSAS

        #region ESTRUTURA

        private DTO_Pagamento Pagamento;

        #endregion ESTRUTURA

        #region CONSTRUTOR

        public DAL_Pagamento(DTO_Pagamento _Pagamento)
        {
            this.Pagamento = _Pagamento;
        }

        #endregion CONSTRUTOR

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                #region LANÇA PAGAMENTO

                if (Pagamento.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Pagamento ";
                    sql += "(Descricao, Tipo, Recebimento, Pagamento, Porc_Custo, Dia_Lancamento) ";
                    sql += "VALUES ";
                    sql += "(@Descricao, @Tipo, @Recebimento, @Pagamento, @Porc_Custo, @Dia_Lancamento) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Descricao", Pagamento.Descricao);
                    cmd.Parameters.AddWithValue("@Tipo", Pagamento.Tipo);
                    cmd.Parameters.AddWithValue("@Recebimento", Pagamento.Recebimento);
                    cmd.Parameters.AddWithValue("@Pagamento", Pagamento.Pagamento);
                    cmd.Parameters.AddWithValue("@Porc_Custo", Pagamento.Porc_Custo);
                    cmd.Parameters.AddWithValue("@Dia_Lancamento", Pagamento.Dia_Lancamento);

                    Pagamento.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Pagamento SET ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Tipo = @Tipo, ";
                    sql += "Recebimento = @Recebimento, ";
                    sql += "Pagamento = @Pagamento, ";
                    sql += "Porc_Custo = @Porc_Custo, ";
                    sql += "Dia_Lancamento = @Dia_Lancamento ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Pagamento.ID);
                    cmd.Parameters.AddWithValue("@Descricao", Pagamento.Descricao);
                    cmd.Parameters.AddWithValue("@Tipo", Pagamento.Tipo);
                    cmd.Parameters.AddWithValue("@Recebimento", Pagamento.Recebimento);
                    cmd.Parameters.AddWithValue("@Pagamento", Pagamento.Pagamento);
                    cmd.Parameters.AddWithValue("@Porc_Custo", Pagamento.Porc_Custo);
                    cmd.Parameters.AddWithValue("@Dia_Lancamento", Pagamento.Dia_Lancamento);

                    conexao.Executa_Comando(cmd);
                }

                #endregion LANÇA PAGAMENTO

                #region LANÇA PARCELAMENTO

                if (Pagamento.Parcelamento.Count > 0)
                    for (int i = 0; i <= Pagamento.Parcelamento.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (Pagamento.Parcelamento[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Pagamento_Parc ";
                            sql += "(ID_Pagamento, Personalizado, Parcelamento, Periodo)";
                            sql += "VALUES ";
                            sql += "(@ID_Pagamento, @Personalizado, @Parcelamento, @Periodo)";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Pagamento", Pagamento.ID);
                            cmd.Parameters.AddWithValue("@Personalizado", Pagamento.Parcelamento[i].Personalizado);
                            cmd.Parameters.AddWithValue("@Parcelamento", Pagamento.Parcelamento[i].Parcelamento);
                            cmd.Parameters.AddWithValue("@Periodo", Pagamento.Parcelamento[i].Periodo);

                            conexao.Executa_Comando(cmd);
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Pagamento_Parc SET ";
                            sql += "Personalizado = @Personalizado, ";
                            sql += "Parcelamento = @Parcelamento, ";
                            sql += "Periodo = @Periodo ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Pagamento.Parcelamento[i].ID);
                            cmd.Parameters.AddWithValue("@Personalizado", Pagamento.Parcelamento[i].Personalizado);
                            cmd.Parameters.AddWithValue("@Parcelamento", Pagamento.Parcelamento[i].Parcelamento);
                            cmd.Parameters.AddWithValue("@Periodo", Pagamento.Parcelamento[i].Periodo);

                            conexao.Executa_Comando(cmd);
                        }
                    }

                #endregion LANÇA PARCELAMENTO

                conexao.Commit_Conexao();

                return Pagamento.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID

                sql = "SELECT MAX(ID) AS ID FROM Pagamento";
                int aux_ID = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Pagamento ,RESEED, " + aux_ID + ")";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                #endregion RetornaID

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
                sql += "ID, Descricao, Tipo, Recebimento, Pagamento, Porc_Custo, Dia_Lancamento, ";
                sql += "CASE Tipo ";
                sql += "WHEN 1 THEN 'BOLETO' ";
                sql += "WHEN 2 THEN 'CARTÃO DE CRÉDITO/DÉBITO' ";
                sql += "WHEN 3 THEN 'CHEQUE' ";
                sql += "WHEN 4 THEN 'DINHEIRO' ";
                sql += "WHEN 5 THEN 'CARTEIRA' ";
                sql += "WHEN 6 THEN 'OUTROS' ";
                sql += "END AS Descricao_Tipo ";
                sql += "FROM ";
                sql += "Pagamento ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Pagamento.ID > 0)
                    sql += "AND ID = " + Pagamento.ID + " ";

                if (Pagamento.Tipo > 0)
                    sql += "AND Tipo = " + Pagamento.Tipo + " ";

                if (Pagamento.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + Pagamento.Descricao + "%' ";

                if (Pagamento.FiltraPagamento == true)
                {
                    if (Pagamento.Recebimento == true)
                    {
                        sql += "AND Recebimento = 'True' ";

                        if (Pagamento.FiltraBaixa == true)
                            sql += "AND Tipo IN (2, 3, 4, 6) ";
                    }

                    if (Pagamento.Pagamento == true)
                    {
                        sql += "AND Pagamento = 'True' ";

                        if (Pagamento.FiltraBaixa == true)
                            sql += "AND Tipo IN (1, 3, 4, 5, 6) ";
                    }
                }

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

        public DataTable Busca_Parc()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Personalizado, Parcelamento, Periodo ";
                sql += "FROM ";
                sql += "Pagamento_Parc ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Pagamento = " + Pagamento.ID + " ";

                sql += "ORDER BY Parcelamento ";

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
                sql += "Pagamento ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Pagamento.ID);
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Pagamento_Parc ";
                sql += "WHERE ";
                sql += "ID_Pagamento = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
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

        public void Exclui_Parc()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Pagamento_Parc ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Pagamento.Parcelamento[0].ID);

                conexao.Executa_Comando(cmd);

                conexao.Commit_Conexao();
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