using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using Sistema.DTO;

namespace Sistema.DAL
{
    public class DAL_FolhaPagto
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_FolhaPagto FolhaPagto;
        #endregion

        #region CONSTRUTORES
        public DAL_FolhaPagto(DTO_FolhaPagto _FolhaPagto)
        {
            this.FolhaPagto = _FolhaPagto;
        }

        public DAL_FolhaPagto()
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

                if (FolhaPagto.ID == 0)
                {
                    sql = "INSERT INTO FolhaPagto ";
                    sql += "(ID_Pessoa, ID_Empresa, Periodo, Vencimento, Tipo)";
                    sql += "VALUES ";
                    sql += "(@ID_Pessoa, @ID_Empresa, @Periodo, @Vencimento, @Tipo)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Pessoa", FolhaPagto.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@ID_Empresa", FolhaPagto.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Periodo", FolhaPagto.Periodo.Date);
                    cmd.Parameters.AddWithValue("@Vencimento", FolhaPagto.Vencimento);
                    cmd.Parameters.AddWithValue("@Tipo", FolhaPagto.Tipo);

                    FolhaPagto.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE FolhaPagto ";
                    sql += "SET ID_Pessoa = @ID_Pessoa, ";
                    sql += "ID_Empresa = @ID_Empresa, ";
                    sql += "Periodo = @Periodo, ";
                    sql += "Vencimento = @Vencimento, ";
                    sql += "Tipo = @Tipo ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", FolhaPagto.ID);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", FolhaPagto.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@ID_Empresa", FolhaPagto.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Periodo", FolhaPagto.Periodo);
                    cmd.Parameters.AddWithValue("@Vencimento", FolhaPagto.Vencimento);
                    cmd.Parameters.AddWithValue("@Tipo", FolhaPagto.Tipo);

                    conexao.Executa_Comando(cmd);
                }

                #region GRAVA EVENTOS
                for (int i = 0; i <= FolhaPagto.FolhaPagto_Evento.Count - 1; i++)
                {
                    cmd = new SqlCommand();
                    if (FolhaPagto.FolhaPagto_Evento[i].ID == 0)
                    {
                        sql = "INSERT INTO FolhaPagto_Evento ";
                        sql += "(ID_FolhaPagto, ID_Evento, Valor) ";
                        sql += "VALUES ";
                        sql += "(@ID_FolhaPagto, @ID_Evento, @Valor);";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_FolhaPagto", FolhaPagto.ID);
                        cmd.Parameters.AddWithValue("@ID_Evento", FolhaPagto.FolhaPagto_Evento[i].ID_Evento);
                        cmd.Parameters.AddWithValue("@Valor", FolhaPagto.FolhaPagto_Evento[i].Valor);
                    }
                    else
                    {
                        sql = "UPDATE FolhaPagto_Evento ";
                        sql += "SET ID_Evento = @ID_Evento, ";
                        sql += "Valor = @Valor ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", FolhaPagto.FolhaPagto_Evento[i].ID);
                        cmd.Parameters.AddWithValue("@ID_Evento", FolhaPagto.FolhaPagto_Evento[i].ID_Evento);
                        cmd.Parameters.AddWithValue("@Valor", FolhaPagto.FolhaPagto_Evento[i].Valor);
                    }
                    conexao.Executa_Comando(cmd);
                }
                #endregion

                return FolhaPagto.ID;
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
                sql += "F.ID, F.ID_Pessoa, F.Periodo, F.Vencimento, Tipo, ";

                sql += "CASE DATEPART(MONTH, F.Periodo) ";
                sql += "WHEN 1 THEN 'JANEIRO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 2 THEN 'FEVEREIRO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 3 THEN 'MARÇO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 4 THEN 'ABRIL' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 5 THEN 'MAIO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 6 THEN 'JUNHO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 7 THEN 'JULHO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 8 THEN 'AGOSTO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 9 THEN 'SETEMBRO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 10 THEN 'OUTUBRO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 11 THEN 'NOVEMBRO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "WHEN 12 THEN 'DEZEMBRO' + '/' + convert(nvarchar(10),DATEPART(YEAR, F.Periodo)) ";
                sql += "END AS 'DescricaoPeriodo', ";

                sql += "P.Nome_Razao AS Descricao ";
                sql += "FROM FolhaPagto AS F ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 4 AND P.ID_Pessoa = F.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT F.ID IS NULL ";

                if (FolhaPagto.Tipo > 0)
                    sql += "AND F.Tipo = " + FolhaPagto.Tipo + " ";

                if (FolhaPagto.ID > 0)
                    sql += "AND F.ID = " + FolhaPagto.ID + " ";

                if (FolhaPagto.ID_Empresa > 0)
                    sql += "AND F.ID_Empresa = " + FolhaPagto.ID_Empresa + " ";

                if (FolhaPagto.ID_Pessoa > 0)
                    sql += "AND F.ID_Pessoa = " + FolhaPagto.ID_Pessoa + " ";

                if (FolhaPagto.Periodo.ToString().IndexOf("01/01/0001") == -1)
                    sql += "AND MONTH(F.Periodo) = '" + FolhaPagto.Periodo.ToString("MM") + "' AND YEAR(F.Periodo) = '" + FolhaPagto.Periodo.ToString("yyyy") + "' ";

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
                sql += "E.Descricao, E.Referencia, ";
                sql += "CASE E.Vencimento ";
                sql += "WHEN 'True' THEN FE.Valor ";
                sql += "WHEN 'False' THEN 0 ";
                sql += "END AS Vencimento, ";
                sql += "CASE E.Desconto ";
                sql += "WHEN 'True' THEN FE.Valor ";
                sql += "WHEN 'False' THEN 0 ";
                sql += "END AS Desconto, ";
                sql += "FE.ID, FE.ID_FolhaPagto, FE.ID_Evento ";
                sql += "FROM FolhaPagto_Evento AS FE ";
                sql += "INNER JOIN Evento AS E ON FE.ID_Evento = E.ID ";
                sql += "WHERE ";
                sql += "FE.ID_FolhaPagto = " + FolhaPagto.ID + " ";

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
                sql += "F.ID_Pessoa, F.Periodo, F.Vencimento AS DataVencimento, Tipo, ";
                sql += "P.Nome_Razao AS DescricaoPessoa, ";
                sql += "E.Descricao AS DescricaoEvento, E.Referencia, ";
                sql += "CASE E.Vencimento ";
                sql += "WHEN 'True' THEN FE.Valor ";
                sql += "WHEN 'False' THEN 0 ";
                sql += "END AS Vencimento, ";
                sql += "CASE E.Desconto ";
                sql += "WHEN 'True' THEN FE.Valor ";
                sql += "WHEN 'False' THEN 0 ";
                sql += "END AS Desconto, ";
                sql += "FE.ID_FolhaPagto, FE.ID_Evento ";
                sql += "FROM FolhaPagto AS F ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 4 AND P.ID_Pessoa = F.ID_Pessoa ";
                sql += "LEFT JOIN FolhaPagto_Evento AS FE ON FE.ID_FolhaPagto = F.ID ";
                sql += "INNER JOIN Evento AS E ON FE.ID_Evento = E.ID ";
                sql += "WHERE ";
                sql += "NOT F.ID IS NULL ";

                if (FolhaPagto.Tipo > 0)
                    sql += "AND F.Tipo = " + FolhaPagto.Tipo + " ";

                if (FolhaPagto.ID_Empresa > 0)
                    sql += "AND F.ID_Empresa = " + FolhaPagto.ID_Empresa + " ";

                if (FolhaPagto.ID_Pessoa > 0)
                    sql += "AND F.ID_Pessoa = " + FolhaPagto.ID_Pessoa + " ";

                if (FolhaPagto.Periodo.ToString().IndexOf("01/01/0001") == -1)
                    sql += "AND MONTH(F.Periodo) = '" + FolhaPagto.Periodo.ToString("MM") + "' AND YEAR(F.Periodo) = '" + FolhaPagto.Periodo.ToString("yyyy") + "' ";

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

                sql = "SELECT DISTINCT ";
                sql += "E.Descricao AS DescricaoEvento, E.Referencia, ";
                sql += "SUM(CASE E.Vencimento ";
                sql += "WHEN 'True' THEN FE.Valor ";
                sql += "WHEN 'False' THEN 0 ";
                sql += "END) AS Vencimento, ";
                sql += "SUM(CASE E.Desconto ";
                sql += "WHEN 'True' THEN FE.Valor ";
                sql += "WHEN 'False' THEN 0 ";
                sql += "END) AS Desconto ";
                sql += "FROM FolhaPagto AS F ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 4 AND P.ID_Pessoa = F.ID_Pessoa ";
                sql += "LEFT JOIN FolhaPagto_Evento AS FE ON FE.ID_FolhaPagto = F.ID ";
                sql += "INNER JOIN Evento AS E ON FE.ID_Evento = E.ID ";
                sql += "WHERE ";
                sql += "NOT F.ID IS NULL ";

                if (FolhaPagto.Tipo > 0)
                    sql += "AND F.Tipo = " + FolhaPagto.Tipo + " ";

                if (FolhaPagto.ID_Empresa > 0)
                    sql += "AND F.ID_Empresa = " + FolhaPagto.ID_Empresa + " ";

                if (FolhaPagto.ID_Pessoa > 0)
                    sql += "AND F.ID_Pessoa = " + FolhaPagto.ID_Pessoa + " ";

                if (FolhaPagto.Periodo.ToString().IndexOf("01/01/0001") == -1)
                    sql += "AND MONTH(F.Periodo) = '" + FolhaPagto.Periodo.ToString("MM") + "' AND YEAR(F.Periodo) = '" + FolhaPagto.Periodo.ToString("yyyy") + "' ";

                sql += "GROUP BY E.Descricao, E.Referencia, E.Vencimento, E.Desconto ";
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

                sql = "DELETE FROM FolhaPagto_Evento ";
                sql += "WHERE ";
                sql += "ID_FolhaPagto = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", FolhaPagto.ID);

                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM FolhaPagto ";
                sql += "WHERE ";
                sql += "ID = @ID ";
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

        public void Exclui_Item()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (FolhaPagto.ID == 0)
                {
                    sql = "DELETE FROM FolhaPagto_Evento ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", FolhaPagto.FolhaPagto_Evento[0].ID);

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

    public class DAL_Evento
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Evento Evento;
        #endregion

        #region CONSTRUTORES
        public DAL_Evento(DTO_Evento _Evento)
        {
            this.Evento = _Evento;
        }

        public DAL_Evento()
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

                if (Evento.ID == 0)
                {
                    sql = "INSERT INTO Evento ";
                    sql += "(Descricao, Vencimento, Desconto, Referencia)";
                    sql += "VALUES ";
                    sql += "(@Descricao, @Vencimento, @Desconto, @Referencia)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Descricao", Evento.Descricao);
                    cmd.Parameters.AddWithValue("@Vencimento", Evento.Vencimento);
                    cmd.Parameters.AddWithValue("@Desconto", Evento.Desconto);
                    cmd.Parameters.AddWithValue("@Referencia", Evento.Referencia);

                    Evento.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE Evento ";
                    sql += "SET Descricao = @Descricao, ";
                    sql += "Vencimento = @Vencimento, ";
                    sql += "Desconto = @Desconto, ";
                    sql += "Referencia = @Referencia ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Evento.ID);
                    cmd.Parameters.AddWithValue("@Descricao", Evento.Descricao);
                    cmd.Parameters.AddWithValue("@Vencimento", Evento.Vencimento);
                    cmd.Parameters.AddWithValue("@Desconto", Evento.Desconto);
                    cmd.Parameters.AddWithValue("@Referencia", Evento.Referencia);
                    conexao.Executa_Comando(cmd);
                }
                return Evento.ID;

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
                sql += "ID, Descricao, Vencimento, Desconto, Referencia, ";
                sql += "CASE Vencimento ";
                sql += "WHEN 'True' THEN 'Vencimento' ";
                sql += "WHEN 'False' THEN 'Desconto' ";
                sql += "END AS Vencimento_Desconto ";
                sql += "FROM Evento ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Evento.ID > 0)
                    sql += "AND ID = " + Evento.ID + " ";

                if (Evento.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + Evento.Descricao + "%' ";

                if (Evento.Referencia != string.Empty)
                    sql += "AND Referencia LIKE '" + Evento.Referencia + "%' ";

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

                sql = "DELETE FROM Evento ";
                sql += "WHERE ";
                sql += "ID = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Evento.ID);
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
