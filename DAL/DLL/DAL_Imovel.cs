using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;

namespace Sistema.DAL
{
    #region IMOVEL
    public class DAL_Imovel
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Imovel Imovel;
        #endregion

        #region CONTRUTOR
        public DAL_Imovel(DTO_Imovel _Imovel)
        {
            Imovel = _Imovel;
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

                #region GRAVA IMOVEL
                if (Imovel.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Imovel ";
                    sql += "(ID_Tipo, Valor, Tipo_Imovel, Area, Comissao_Porc, Comissao_Valor, Descricao, Logradouro, Numero, Complemento, Bairro, ";
                    sql += "CEP, ID_Municipio, RGI, UC, CI, Matricula) ";
                    sql += "VALUES ";
                    sql += "(@ID_Tipo, @Valor, @Tipo_Imovel, @Area, @Comissao_Porc, @Comissao_Valor, @Descricao, @Logradouro, @Numero, @Complemento, @Bairro, ";
                    sql += "@CEP, @ID_Municipio, @RGI, @UC, @CI, @Matricula) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Tipo", Imovel.ID_Tipo);
                    cmd.Parameters.AddWithValue("@Valor", Imovel.Valor);
                    cmd.Parameters.AddWithValue("@Tipo_Imovel", Imovel.Tipo_Imovel);
                    cmd.Parameters.AddWithValue("@Area", Imovel.Area);
                    cmd.Parameters.AddWithValue("@Comissao_Porc", Imovel.Comissao_Porc);
                    cmd.Parameters.AddWithValue("@Comissao_Valor", Imovel.Comissao_Valor);
                    cmd.Parameters.AddWithValue("@Descricao", Imovel.Descricao);
                    cmd.Parameters.AddWithValue("@Logradouro", Imovel.Endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", Imovel.Endereco.Numero);
                    cmd.Parameters.AddWithValue("@Complemento", Imovel.Endereco.Complemento);
                    cmd.Parameters.AddWithValue("@Bairro", Imovel.Endereco.Bairro);
                    cmd.Parameters.AddWithValue("@CEP", Imovel.Endereco.CEP);
                    cmd.Parameters.AddWithValue("@ID_Municipio", Imovel.Endereco.ID_Municipio);
                    cmd.Parameters.AddWithValue("@RGI", Imovel.RGI);
                    cmd.Parameters.AddWithValue("@UC", Imovel.UC);
                    cmd.Parameters.AddWithValue("@CI", Imovel.CI);
                    cmd.Parameters.AddWithValue("@Matricula", Imovel.Matricula);

                    Imovel.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Imovel ";
                    sql += "SET ";
                    sql += "ID_Tipo = @ID_Tipo, ";
                    sql += "Valor = @Valor, ";
                    sql += "Tipo_Imovel = @Tipo_Imovel, ";
                    sql += "Area = @Area, ";
                    sql += "Comissao_Porc = @Comissao_Porc, ";
                    sql += "Comissao_Valor = @Comissao_Valor, ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Logradouro = @Logradouro, ";
                    sql += "Numero = @Numero, ";
                    sql += "Complemento = @Complemento, ";
                    sql += "Bairro = @Bairro, ";
                    sql += "CEP = @CEP, ";
                    sql += "ID_Municipio = @ID_Municipio, ";
                    sql += "RGI = @RGI, ";
                    sql += "UC = @UC, ";
                    sql += "CI = @CI, ";
                    sql += "Matricula = @Matricula ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Imovel.ID);
                    cmd.Parameters.AddWithValue("@ID_Tipo", Imovel.ID_Tipo);
                    cmd.Parameters.AddWithValue("@Valor", Imovel.Valor);
                    cmd.Parameters.AddWithValue("@Tipo_Imovel", Imovel.Tipo_Imovel);
                    cmd.Parameters.AddWithValue("@Area", Imovel.Area);
                    cmd.Parameters.AddWithValue("@Comissao_Porc", Imovel.Comissao_Porc);
                    cmd.Parameters.AddWithValue("@Comissao_Valor", Imovel.Comissao_Valor);
                    cmd.Parameters.AddWithValue("@Descricao", Imovel.Descricao);
                    cmd.Parameters.AddWithValue("@Logradouro", Imovel.Endereco.Logradouro);
                    cmd.Parameters.AddWithValue("@Numero", Imovel.Endereco.Numero);
                    cmd.Parameters.AddWithValue("@Complemento", Imovel.Endereco.Complemento);
                    cmd.Parameters.AddWithValue("@Bairro", Imovel.Endereco.Bairro);
                    cmd.Parameters.AddWithValue("@CEP", Imovel.Endereco.CEP);
                    cmd.Parameters.AddWithValue("@ID_Municipio", Imovel.Endereco.ID_Municipio);
                    cmd.Parameters.AddWithValue("@RGI", Imovel.RGI);
                    cmd.Parameters.AddWithValue("@UC", Imovel.UC);
                    cmd.Parameters.AddWithValue("@CI", Imovel.CI);
                    cmd.Parameters.AddWithValue("@Matricula", Imovel.Matricula);

                    conexao.Executa_Comando(cmd);
                }
                #endregion

                #region GRAVA CUSTO
                if (Imovel.Proprietario != null &&
                    Imovel.Proprietario.Count > 0)
                    for (int i = 0; i <= Imovel.Proprietario.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();

                        if (Imovel.Proprietario[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Imovel_Proprietario ";
                            sql += "(ID_Imovel, TipoPessoa, ID_Pessoa) ";
                            sql += "VALUES ";
                            sql += "(@ID_Imovel, @TipoPessoa, @ID_Pessoa) ";
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Imovel_Proprietario SET ";
                            sql += "TipoPessoa = @TipoPessoa, ";
                            sql += "ID_Pessoa = @ID_Pessoa ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";

                            cmd.Parameters.AddWithValue("@ID", Imovel.Proprietario[i].ID);
                        }
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Imovel", Imovel.ID);
                        cmd.Parameters.AddWithValue("@TipoPessoa", Imovel.Proprietario[i].TipoPessoa);
                        cmd.Parameters.AddWithValue("@ID_Pessoa", Imovel.Proprietario[i].ID_Pessoa);
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region GRAVA IMAGEM
                if (Imovel.Imagem != null &&
                    Imovel.Imagem.Count > 0)
                    for (int i = 0; i <= Imovel.Imagem.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();

                        if (Imovel.Imagem[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Imovel_Imagem ";
                            sql += "(ID_Imovel, Informacao, Imagem) ";
                            sql += "VALUES ";
                            sql += "(@ID_Imovel, @Informacao, @Imagem) ";

                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Imovel", Imovel.ID);
                            cmd.Parameters.AddWithValue("@Informacao", Imovel.Imagem[i].Informacao);
                            cmd.Parameters.Add("@Imagem", SqlDbType.Binary, (int)Imovel.Imagem[i].Imagem.Length).Value = Imovel.Imagem[i].ArqByteArray;

                            conexao.Executa_Comando(cmd);
                        }
                    }
                #endregion

                #region GRAVA CUSTO
                if (Imovel.Custo != null &&
                    Imovel.Custo.Count > 0)
                    for (int i = 0; i <= Imovel.Custo.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();

                        if (Imovel.Custo[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Imovel_Custo ";
                            sql += "(ID_Imovel, ID_Tipo, Valor) ";
                            sql += "VALUES ";
                            sql += "(@ID_Imovel, @ID_Tipo, @Valor) ";
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Imovel_Custo SET ";
                            sql += "ID_Tipo = @ID_Tipo, ";
                            sql += "Valor = @Valor ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";

                            cmd.Parameters.AddWithValue("@ID", Imovel.Custo[i].ID);
                        }
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Imovel", Imovel.ID);
                        cmd.Parameters.AddWithValue("@ID_Tipo", Imovel.Custo[i].ID_Tipo);
                        cmd.Parameters.AddWithValue("@Valor", Imovel.Custo[i].Valor);
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region GRAVA VISTORIA
                if (Imovel.Vistoria != null &&
                    Imovel.Vistoria.Count > 0)
                    for (int i = 0; i <= Imovel.Vistoria.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();

                        if (Imovel.Vistoria[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Imovel_Vistoria ";
                            sql += "(ID_Imovel, Local, Descricao) ";
                            sql += "VALUES ";
                            sql += "(@ID_Imovel, @Local, @Descricao) ";
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Imovel_Vistoria SET ";
                            sql += "Local = @Local, ";
                            sql += "Descricao = @Descricao ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";

                            cmd.Parameters.AddWithValue("@ID", Imovel.Vistoria[i].ID);
                        }
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Imovel", Imovel.ID);
                        cmd.Parameters.AddWithValue("@Local", Imovel.Vistoria[i].Local);
                        cmd.Parameters.AddWithValue("@Descricao", Imovel.Vistoria[i].Descricao);
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                conexao.Commit_Conexao();

                return Imovel.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Imovel";
                int aux_ID_Imovel = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Imovel, RESEED, " + aux_ID_Imovel + ")";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "SELECT MAX(ID) AS ID FROM Imovel_Imagem";
                int aux_ID_Imagem = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Imovel_Imagem,RESEED, " + aux_ID_Imagem + ")";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "SELECT MAX(ID) AS ID FROM Imovel_Custo";
                int aux_ID_Custo = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Imovel_Custo,RESEED, " + aux_ID_Custo + ")";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "SELECT MAX(ID) AS ID FROM Imovel_Vistoria";
                int aux_ID_Vistoria = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Imovel_Vistoria,RESEED, " + aux_ID_Vistoria + ")";
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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT DISTINCT ";
                sql += "I.ID, I.ID_Tipo, I.Valor, I.Tipo_Imovel, I.Area, I.Comissao_Porc, I.Comissao_Valor, I.Descricao, I.Logradouro, I.Numero, ";
                sql += "I.Complemento, I.Bairro, I.CEP, I.RGI, I.UC, I.CI, I.Matricula, ";
                sql += "(I.Logradouro + ', ' + I.Numero + ' ' + I.Complemento + ' - ' + I.Bairro) AS Endereco, ";
                sql += "(I.Descricao + ' - ' + I.Logradouro + ', ' + I.Numero + ' ' + I.Complemento + ' - ' + I.Bairro) AS DescricaoCombo, ";
                sql += "GT.Descricao AS DescricaoTipoImovel, ";
                sql += "M.ID_UF AS UF, M.ID AS Cidade ";
                sql += "FROM Imovel AS I ";
                sql += "LEFT JOIN Imovel_Proprietario AS IP ON I.ID = IP.ID_Imovel ";
                sql += "LEFT JOIN Municipios AS M ON I.ID_Municipio = M.ID ";
                sql += "LEFT JOIN Grupo AS GT ON I.Tipo_Imovel = GT.ID ";
                sql += "WHERE ";
                sql += "NOT I.ID IS NULL ";

                if (Imovel.ID > 0)
                    sql += "AND I.ID = " + Imovel.ID + " ";

                if (Imovel.Proprietario != null)
                {
                    if (Imovel.Proprietario[0].TipoPessoa > 0)
                        sql += "AND IP.TipoPessoa = " + Imovel.Proprietario[0].TipoPessoa + " ";

                    if (Imovel.Proprietario[0].ID_Pessoa > 0)
                        sql += "AND IP.ID_Pessoa = " + Imovel.Proprietario[0].ID_Pessoa + " ";
                }

                sql += "ORDER BY I.Descricao ";

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

        public DataTable Busca_Custo()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "IC.ID, IC.ID_Tipo, IC.Valor, ";
                sql += "G.Descricao ";
                sql += "FROM Imovel_Custo AS IC ";
                sql += "INNER JOIN Grupo AS G ON G.ID = IC.ID_Tipo ";
                sql += "WHERE ";
                sql += "NOT IC.ID IS NULL ";

                if (Imovel.ID > 0)
                    sql += "AND IC.ID_Imovel = " + Imovel.ID + " ";

                sql += "ORDER BY G.Descricao ";

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
                sql += "ID, ID_Imovel, Informacao, Imagem ";
                sql += "FROM Imovel_Imagem ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Imovel.ID > 0)
                    sql += "AND ID_Imovel = " + Imovel.ID + " ";

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

        public DataTable Busca_Proprietario()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "IC.ID, IC.ID_Imovel, IC.TipoPessoa, IC.ID_Pessoa, ";
                sql += "P.Nome_Razao AS Descricao, ";
                sql += "CASE IC.TipoPessoa ";
                sql += "WHEN 7 THEN 'PROPRIETÁRIO' ";
                sql += "WHEN 8 THEN 'LOCATÁRIO' ";
                sql += "WHEN 9 THEN 'FIADOR' ";
                sql += "END AS DescricaoTipoPessoa ";
                sql += "FROM Imovel_Proprietario AS IC ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = IC.TipoPessoa AND P.ID_Pessoa = IC.ID_Pessoa ";
                sql += "WHERE ";
                sql += "NOT IC.ID IS NULL ";

                if (Imovel.ID > 0)
                    sql += "AND IC.ID_Imovel = " + Imovel.ID + " ";

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

        public DataTable Busca_Vistoria()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, Local, Descricao ";
                sql += "FROM Imovel_Vistoria ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Imovel.ID > 0)
                    sql += "AND ID_Imovel = " + Imovel.ID + " ";

                sql += "ORDER BY Local ";

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
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();
                /*
                #region Consulta Módulos
                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Imovel_Proprietario ";
                sql += "WHERE ";
                sql += "ID_Imovel = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imovel.ID);
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Imovel_Imagem ";
                sql += "WHERE ";
                sql += "ID_Imovel = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Imovel_Custo ";
                sql += "WHERE ";
                sql += "ID_Imovel = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Imovel_Vistoria ";
                sql += "WHERE ";
                sql += "ID_Imovel = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Imovel ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
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

        public void Exclui_Proprietario()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();
                /*
                #region Consulta Módulos
                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Imovel_Proprietario ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imovel.Proprietario[0].ID);
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

        public void Exclui_Imagem()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();
                /*
                #region Consulta Módulos
                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Imovel_Imagem ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imovel.Imagem[0].ID);
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

        public void Exclui_Custo()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();
                /*
                #region Consulta Módulos
                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Imovel_Custo ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imovel.Custo[0].ID);
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

        public void Exclui_Vistoria()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();
                /*
                #region Consulta Módulos
                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Imovel_Vistoria ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imovel.Vistoria[0].ID);
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
    #endregion

    #region IMOVEL CONTRATO SERVIÇO
    public class DAL_Imovel_ContratoServico
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURAS
        DTO_Imovel_ContratoServico Contrato;
        #endregion

        #region CONSTRUTOR
        public DAL_Imovel_ContratoServico(DTO_Imovel_ContratoServico _Contrato)
        {
            Contrato = _Contrato;
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

                if (Contrato.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Imovel_Contrato ";
                    sql += "(ID_Proprietario, Emissao, Descricao_Test1, Descricao_Test2, Doc_Test1, Doc_Test2) ";
                    sql += "VALUES ";
                    sql += "(@ID_Proprietario, @Emissao, @Descricao_Test1, @Descricao_Test2, @Doc_Test1, @Doc_Test2) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Proprietario", Contrato.ID_Proprietario);
                    cmd.Parameters.AddWithValue("@Emissao", Contrato.Emissao);
                    cmd.Parameters.AddWithValue("@Descricao_Test1", Contrato.Descricao_Test1);
                    cmd.Parameters.AddWithValue("@Descricao_Test2", Contrato.Descricao_Test2);
                    cmd.Parameters.AddWithValue("@Doc_Test1", Contrato.Doc_Test1);
                    cmd.Parameters.AddWithValue("@Doc_Test2", Contrato.Doc_Test2);

                    Contrato.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Imovel_Contrato ";
                    sql += "SET ";
                    sql += "ID_Proprietario = @ID_Proprietario, ";
                    sql += "Emissao = @Emissao, ";
                    sql += "Descricao_Test1 = @Descricao_Test1, ";
                    sql += "Descricao_Test2 = @Descricao_Test2, ";
                    sql += "Doc_Test1 = @Doc_Test1, ";
                    sql += "Doc_Test2 = @Doc_Test2 ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Contrato.ID);
                    cmd.Parameters.AddWithValue("@ID_Proprietario", Contrato.ID_Proprietario);
                    cmd.Parameters.AddWithValue("@Emissao", Contrato.Emissao);
                    cmd.Parameters.AddWithValue("@Descricao_Test1", Contrato.Descricao_Test1);
                    cmd.Parameters.AddWithValue("@Descricao_Test2", Contrato.Descricao_Test2);
                    cmd.Parameters.AddWithValue("@Doc_Test1", Contrato.Doc_Test1);
                    cmd.Parameters.AddWithValue("@Doc_Test2", Contrato.Doc_Test2);

                    conexao.Executa_Comando(cmd);
                }
                conexao.Commit_Conexao();

                return Contrato.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Locacao";
                int aux_ID_Imovel = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Locacao,RESEED, " + aux_ID_Imovel + ")";
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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT DISTINCT ";
                sql += "IC.ID, IC.ID_Proprietario, IC.Emissao, IC.Descricao_Test1, IC.Descricao_Test2, IC.Doc_Test1, IC.Doc_Test2, ";
                sql += "P.Nome_Razao AS Descricao ";
                sql += "FROM Imovel_Contrato AS IC ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 7 AND P.ID_Pessoa = IC.ID_Proprietario ";
                sql += "WHERE ";
                sql += "NOT IC.ID IS NULL ";

                if (Contrato.ID > 0)
                    sql += "AND IC.ID = " + Contrato.ID + " ";

                if (Contrato.ID_Proprietario > 0)
                    sql += "AND IC.ID_Proprietario = " + Contrato.ID_Proprietario + " ";

                sql += "ORDER BY IC.Emissao ";

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
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                #region Consulta Módulos
                /* sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;
                *
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                 * */
    #endregion

                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Imovel_Contrato ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Contrato.ID);
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
    #endregion

    #region IMOVEL LOCAÇÃO
    public class DAL_Imovel_Locacao
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Locacao Locacao;
        #endregion

        #region CONTRUTOR
        public DAL_Imovel_Locacao(DTO_Locacao _Locacao)
        {
            Locacao = _Locacao;
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

                #region GRAVA IMOVEL
                if (Locacao.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Locacao ";
                    sql += "(ID_Imovel, Data, Inicio, Termino, DiaVencimento, Valor, Descricao_Test1, Descricao_Test2, Doc_Test1, Doc_Test2, Observacao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Imovel, @Data, @Inicio, @Termino, @DiaVencimento, @Valor, @Descricao_Test1, @Descricao_Test2, @Doc_Test1, @Doc_Test2, @Observacao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Imovel", Locacao.ID_Imovel);
                    cmd.Parameters.AddWithValue("@Data", Locacao.Data);
                    cmd.Parameters.AddWithValue("@Inicio", Locacao.Inicio);
                    cmd.Parameters.AddWithValue("@Termino", Locacao.Termino);
                    cmd.Parameters.AddWithValue("@DiaVencimento", Locacao.DiaVencimento);
                    cmd.Parameters.AddWithValue("@Valor", Locacao.Valor);
                    cmd.Parameters.AddWithValue("@Descricao_Test1", Locacao.Descricao_Test1);
                    cmd.Parameters.AddWithValue("@Descricao_Test2", Locacao.Descricao_Test2);
                    cmd.Parameters.AddWithValue("@Doc_Test1", Locacao.Doc_Test1);
                    cmd.Parameters.AddWithValue("@Doc_Test2", Locacao.Doc_Test2);
                    cmd.Parameters.AddWithValue("@Observacao", Locacao.Observacao);

                    Locacao.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Locacao ";
                    sql += "SET ";
                    sql += "ID_Imovel = @ID_Imovel, ";
                    sql += "Data = @Data, ";
                    sql += "Inicio = @Inicio, ";
                    sql += "Termino = @Termino, ";
                    sql += "DiaVencimento = @DiaVencimento, ";
                    sql += "Valor = @Valor, ";
                    sql += "Descricao_Test1 = @Descricao_Test1, ";
                    sql += "Descricao_Test2 = @Descricao_Test2, ";
                    sql += "Doc_Test1 = @Doc_Test1, ";
                    sql += "Doc_Test2 = @Doc_Test2, ";
                    sql += "Observacao = @Observacao ";

                    sql += "WHERE ";
                    sql += "ID = @ID ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Locacao.ID);
                    cmd.Parameters.AddWithValue("@ID_Imovel", Locacao.ID_Imovel);
                    cmd.Parameters.AddWithValue("@Data", Locacao.Data);
                    cmd.Parameters.AddWithValue("@Inicio", Locacao.Inicio);
                    cmd.Parameters.AddWithValue("@Termino", Locacao.Termino);
                    cmd.Parameters.AddWithValue("@DiaVencimento", Locacao.DiaVencimento);
                    cmd.Parameters.AddWithValue("@Valor", Locacao.Valor);
                    cmd.Parameters.AddWithValue("@Descricao_Test1", Locacao.Descricao_Test1);
                    cmd.Parameters.AddWithValue("@Descricao_Test2", Locacao.Descricao_Test2);
                    cmd.Parameters.AddWithValue("@Doc_Test1", Locacao.Doc_Test1);
                    cmd.Parameters.AddWithValue("@Doc_Test2", Locacao.Doc_Test2);
                    cmd.Parameters.AddWithValue("@Observacao", Locacao.Observacao);

                    conexao.Executa_Comando(cmd);
                }
                #endregion

                #region GRAVA LOCATARIO
                if (Locacao.Locatario.Count > 0)
                    for (int i = 0; i <= Locacao.Locatario.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();

                        if (Locacao.Locatario[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Locacao_Locatario ";
                            sql += "(ID_Locacao, ID_Locatario) ";
                            sql += "VALUES ";
                            sql += "(@ID_Locacao, @ID_Locatario) ";
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Locacao_Locatario SET ";
                            sql += "ID_Locacao = @ID_Locacao, ";
                            sql += "ID_Locatario = @ID_Locatario ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";

                            cmd.Parameters.AddWithValue("@ID", Locacao.Locatario[i].ID);
                        }
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Locacao", Locacao.ID);
                        cmd.Parameters.AddWithValue("@ID_Locatario", Locacao.Locatario[i].ID_Locatario);
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                #region GRAVA FIADOR
                if (Locacao.Fiador.Count > 0)
                    for (int i = 0; i <= Locacao.Fiador.Count - 1; i++)
                    {
                        cmd.Parameters.Clear();

                        if (Locacao.Fiador[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Locacao_Fiador ";
                            sql += "(ID_Locacao, ID_Fiador) ";
                            sql += "VALUES ";
                            sql += "(@ID_Locacao, @ID_Fiador) ";
                        }
                        else
                        {
                            sql = "UPDATE ";
                            sql += "Locacao_Fiador SET ";
                            sql += "ID_Locacao = @ID_Locacao, ";
                            sql += "ID_Fiador = @ID_Fiador ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";

                            cmd.Parameters.AddWithValue("@ID", Locacao.Fiador[i].ID);
                        }
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Locacao", Locacao.ID);
                        cmd.Parameters.AddWithValue("@ID_Fiador", Locacao.Fiador[i].ID_Fiador);
                        conexao.Executa_Comando(cmd);
                    }
                #endregion

                conexao.Commit_Conexao();

                return Locacao.ID;
            }
            catch (Exception ex)
            {
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                #region RetornaID
                sql = "SELECT MAX(ID) AS ID FROM Locacao";
                int aux_ID_Imovel = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Locacao,RESEED, " + aux_ID_Imovel + ")";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "SELECT MAX(ID) AS ID FROM Locacao_Locatario";
                int aux_ID_Imagem = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Locacao_Locatario,RESEED, " + aux_ID_Imagem + ")";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "SELECT MAX(ID) AS ID FROM Locacao_Fiador";
                int aux_ID_Custo = Convert.ToInt32(conexao.Consulta(sql).Rows[0]["ID"]);
                sql = " DBCC CHECKIDENT(Locacao_Fiador,RESEED, " + aux_ID_Custo + ")";
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

        public void Grava_Documento()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                if (Locacao.ID == 0)
                {
                    sql = "INSERT INTO Locacao_Documento ";
                    sql += "(ID_Contrato, Descricao, Documento) ";
                    sql += "VALUES ";
                    sql += "(@ID_Contrato, @Descricao, @Documento) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Contrato", Locacao.ID);
                    cmd.Parameters.AddWithValue("@Descricao", Locacao.Descricao_Documento);
                    cmd.Parameters.Add("@Contrato", SqlDbType.Binary, (int)Locacao.Arq_Documento.Length).Value = Locacao.ArqByteArray;

                    Locacao.ID_Documento = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE Locacao_Contrato SET ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Documento = @Documento ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Locacao.ID_Documento);
                    cmd.Parameters.AddWithValue("@Descricao", Locacao.Descricao_Documento);
                    cmd.Parameters.Add("@Documento", SqlDbType.Binary, (int)Locacao.Arq_Documento.Length).Value = Locacao.ArqByteArray;

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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT DISTINCT ";
                sql += "L.ID, L.ID_Imovel, L.Data, L.Inicio, L.Termino, L.DiaVencimento, L.Valor, L.Descricao_Test1, ";
                sql += "L.Descricao_Test2, L.Doc_Test1, L.Doc_Test2, L.Observacao, ";
                sql += "I.Descricao, (I.Logradouro + ', ' + I.Numero + ' ' + I.Bairro) AS Endereco ";
                sql += "FROM Locacao AS L ";
                sql += "INNER JOIN Imovel AS I ON I.ID  = L.ID_Imovel ";
                sql += "WHERE ";
                sql += "NOT L.ID IS NULL ";

                if (Locacao.ID > 0)
                    sql += "AND L.ID = " + Locacao.ID + " ";

                sql += "ORDER BY L.ID ";

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

        public DataTable Busca_ResumoAluguel()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT * ";
                sql += "FROM V_ResumoLocacao ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Locacao.Locatario[0].ID_Locatario > 0)
                    sql += "AND ID_Pessoa = " + Locacao.Locatario[0].ID_Locatario + " ";

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

        public DataTable Busca_Locatario()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "L.ID, L.ID_Locatario, ";
                sql += "P.Nome_Razao AS Descricao ";
                sql += "FROM Locacao_Locatario AS L ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 8 AND P.ID_Pessoa = L.ID_Locatario ";
                sql += "WHERE ";
                sql += "NOT L.ID IS NULL ";

                if (Locacao.ID > 0)
                    sql += "AND L.ID_Locacao = " + Locacao.ID + " ";

                sql += "ORDER BY P.Nome_Razao  ";

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

        public DataTable Busca_Fiador()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "F.ID, F.ID_Fiador, ";
                sql += "P.Nome_Razao AS Descricao ";
                sql += "FROM Locacao_Fiador AS F ";
                sql += "INNER JOIN Pessoa AS P ON P.TipoPessoa = 9 AND P.ID_Pessoa = F.ID_Fiador ";
                sql += "WHERE ";
                sql += "NOT F.ID IS NULL ";

                if (Locacao.ID > 0)
                    sql += "AND F.ID_Locacao = " + Locacao.ID + " ";

                sql += "ORDER BY P.Nome_Razao  ";

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

        public DataTable Busca_Documento()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, ID_Contrato, Descricao, Documento ";
                sql += "FROM Locacao_Documento ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                sql += "AND ID_Contrato = " + Locacao.ID + " ";

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
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                #region Consulta Módulos
                /* sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
    #endregion

                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Locacao_Locatario ";
                sql += "WHERE ";
                sql += "ID_Locacao = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Locacao.ID);
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Locacao_Fiador ";
                sql += "WHERE ";
                sql += "ID_Locacao = @ID ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Locacao ";
                sql += "WHERE ";
                sql += "ID_Locacao = @ID ";
                cmd.CommandText = sql;
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

        public void Exclui_Locatario()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                #region Consulta Módulos
                /* sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                #endregion

                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Locacao_Locatario ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Locacao.Locatario[0].ID);
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

        public void Exclui_Fiador()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                #region Consulta Módulos
                /* sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo_Simples.ID + " ";
                sql += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);
                */
                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                #endregion

                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Locacao_Fiador ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Locacao.Fiador[0].ID);
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
    #endregion
}
