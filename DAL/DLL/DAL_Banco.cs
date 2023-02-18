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
    public class DAL_Banco
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Banco Banco;
        #endregion

        #region CONSTRUTOR
        public DAL_Banco(DTO_Banco _Banco)
        {
            this.Banco = _Banco;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                if (Banco.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Banco ";
                    sql += "(ID_Empresa, ID_Banco, Descricao, Agencia, Conta, ID_Caixa, Limite) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @ID_Banco, @Descricao, @Agencia, @Conta, @ID_Caixa, @Limite) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Banco.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Banco", Banco.ID_Banco);
                    cmd.Parameters.AddWithValue("@Descricao", Banco.Descricao);
                    cmd.Parameters.AddWithValue("@Agencia", Banco.Agencia);
                    cmd.Parameters.AddWithValue("@Conta", Banco.Conta);
                    cmd.Parameters.AddWithValue("@ID_Caixa", Banco.ID_Caixa);
                    cmd.Parameters.AddWithValue("@Limite", Banco.Limite);

                    Banco.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE Banco SET ";
                    sql += "ID_Banco = @ID_Banco, ";
                    sql += "Descricao =  @Descricao, ";
                    sql += "Agencia = @Agencia, ";
                    sql += "Conta = @Conta, ";
                    sql += "ID_Caixa = @ID_Caixa, ";
                    sql += "Limite = @Limite ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Banco.ID);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Banco.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Banco", Banco.ID_Banco);
                    cmd.Parameters.AddWithValue("@Descricao", Banco.Descricao);
                    cmd.Parameters.AddWithValue("@Agencia", Banco.Agencia);
                    cmd.Parameters.AddWithValue("@Conta", Banco.Conta);
                    cmd.Parameters.AddWithValue("@ID_Caixa", Banco.ID_Caixa);
                    cmd.Parameters.AddWithValue("@Limite", Banco.Limite);

                    conexao.Executa_Comando(cmd);
                }
                return Banco.ID;
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
                sql += "ID, replicate('0', 3-LEN(ID_Banco)) + CONVERT(varchar,ID_Banco) ID_Banco, Descricao, Agencia, Conta, ID_Caixa, Limite ";
                sql += "FROM Banco ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Banco.ID > 0)
                    sql += "AND ID = " + Banco.ID + " ";

                if (Banco.ID_Caixa > 0)
                    sql += "AND ID_Caixa = " + Banco.ID_Caixa + " ";

                if (Banco.Agencia != String.Empty &&
                    Banco.Agencia != null)
                    sql += "AND Agencia LIKE '" + Banco.Agencia + "%' ";

                if (Banco.Conta != String.Empty &&
                    Banco.Conta != null)
                    sql += "AND Conta LIKE '" + Banco.Conta + "%' ";

                if (Banco.Descricao != String.Empty &&
                    Banco.Descricao != null)
                    sql += "AND Descricao LIKE '" + Banco.Descricao + "%' ";

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

        public void Exclui()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Banco ";
                sql += "FROM Cedente ";
                sql += "WHERE ";
                sql += "ID_Banco = " + Banco.ID;
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Cedente\n";

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_Exclui_Erro + msg);

                sql = "DELETE FROM Banco ";
                sql += "WHERE ";
                sql += "ID = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Banco.ID);
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

    public class DAL_Cedente
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Cedente Cedente;
        #endregion

        #region CONSTRUTOR
        public DAL_Cedente(DTO_Cedente _Cedente)
        {
            this.Cedente = _Cedente;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (Cedente.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Cedente ";
                    sql += "(Descricao, Cod_Cedente, Carteira, Juros, DiasJuros, Multa, DiasMulta, Instrucao_1, Instrucao_2, ID_Banco, ID_Conta, ";
                    sql += "ID_Empresa, Tipo_Doc_Cedente, CNPJ_CPF_Cedente, Razao_Cedente, UtilizaTarifa, Tarifa, DiaProtesto, Aceite, Tipo_Emissao, ";
                    sql += "Cod_Protesto, Tipo_Cobranca, Ativo, Altera_Data) ";
                    sql += "VALUES ";
                    sql += "(@Descricao, @Cod_Cedente, @Carteira, @Juros, @DiasJuros, @Multa, @DiasMulta, @Instrucao_1, @Instrucao_2, @ID_Banco, @ID_Conta, ";
                    sql += "@ID_Empresa, @Tipo_Doc_Cedente, @CNPJ_CPF_Cedente, @Razao_Cedente, @UtilizaTarifa, @Tarifa, @DiaProtesto, @Aceite, @Tipo_Emissao, ";
                    sql += "@Cod_Protesto, @Tipo_Cobranca, @Ativo, @Altera_Data) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Descricao", Cedente.Descricao);
                    cmd.Parameters.AddWithValue("@Cod_Cedente", Cedente.Cod_Cedente);
                    cmd.Parameters.AddWithValue("@Carteira", Cedente.Carteira);
                    cmd.Parameters.AddWithValue("@Juros", Cedente.Juros);
                    cmd.Parameters.AddWithValue("@DiasJuros", Cedente.DiasJuros);
                    cmd.Parameters.AddWithValue("@Multa", Cedente.Multa);
                    cmd.Parameters.AddWithValue("@DiasMulta", Cedente.DiasMulta);
                    cmd.Parameters.AddWithValue("@Instrucao_1", Cedente.Instrucao_1);
                    cmd.Parameters.AddWithValue("@Instrucao_2", Cedente.Instrucao_2);
                    cmd.Parameters.AddWithValue("@ID_Banco", Cedente.ID_Banco);
                    cmd.Parameters.AddWithValue("@ID_Conta", Cedente.ID_Conta);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Cedente.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Tipo_Doc_Cedente", Cedente.Tipo_Doc_Cedente);
                    cmd.Parameters.AddWithValue("@CNPJ_CPF_Cedente", Cedente.CNPJ_CPF_Cedente);
                    cmd.Parameters.AddWithValue("@Razao_Cedente", Cedente.Razao_Cedente);
                    cmd.Parameters.AddWithValue("@UtilizaTarifa", Cedente.UtilizaTarifa);
                    cmd.Parameters.AddWithValue("@Tarifa", Cedente.Tarifa);
                    cmd.Parameters.AddWithValue("@DiaProtesto", Cedente.DiaProtesto);
                    cmd.Parameters.AddWithValue("@Aceite", Cedente.Aceite);
                    cmd.Parameters.AddWithValue("@Tipo_Emissao", Cedente.Tipo_Emissao);
                    cmd.Parameters.AddWithValue("@Cod_Protesto", Cedente.Cod_Protesto);
                    cmd.Parameters.AddWithValue("@Tipo_Cobranca", Cedente.Tipo_Cobranca);
                    cmd.Parameters.AddWithValue("@Ativo", Cedente.Ativo);
                    cmd.Parameters.AddWithValue("@Altera_Data", Cedente.Altera_Data);
                    Cedente.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Cedente ";
                    sql += "SET ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Cod_Cedente = @Cod_Cedente, ";
                    sql += "Carteira = @Carteira, ";
                    sql += "Juros = @Juros, ";
                    sql += "DiasJuros = @DiasJuros, ";
                    sql += "Multa = @Multa, ";
                    sql += "DiasMulta = @DiasMulta, ";
                    sql += "Instrucao_1 = @Instrucao_1, ";
                    sql += "Instrucao_2 = @Instrucao_2, ";
                    sql += "ID_Banco = @ID_Banco, ";
                    sql += "ID_Conta = @ID_Conta, ";
                    sql += "ID_Empresa = @ID_Empresa, ";
                    sql += "Tipo_Doc_Cedente = @Tipo_Doc_Cedente, ";
                    sql += "CNPJ_CPF_Cedente = @CNPJ_CPF_Cedente, ";
                    sql += "Razao_Cedente = @Razao_Cedente, ";
                    sql += "UtilizaTarifa = @UtilizaTarifa, ";
                    sql += "Tarifa = @Tarifa, ";
                    sql += "DiaProtesto = @DiaProtesto, ";
                    sql += "Aceite = @Aceite, ";
                    sql += "Tipo_Emissao = @Tipo_Emissao, ";
                    sql += "Cod_Protesto = @Cod_Protesto, ";
                    sql += "Tipo_Cobranca = @Tipo_Cobranca, ";
                    sql += "Ativo = @Ativo, ";
                    sql += "Altera_Data = @Altera_Data ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Cedente.ID);
                    cmd.Parameters.AddWithValue("@Descricao", Cedente.Descricao);
                    cmd.Parameters.AddWithValue("@Cod_Cedente", Cedente.Cod_Cedente);
                    cmd.Parameters.AddWithValue("@Carteira", Cedente.Carteira);
                    cmd.Parameters.AddWithValue("@Juros", Cedente.Juros);
                    cmd.Parameters.AddWithValue("@DiasJuros", Cedente.DiasJuros);
                    cmd.Parameters.AddWithValue("@Multa", Cedente.Multa);
                    cmd.Parameters.AddWithValue("@DiasMulta", Cedente.DiasMulta);
                    cmd.Parameters.AddWithValue("@Instrucao_1", Cedente.Instrucao_1);
                    cmd.Parameters.AddWithValue("@Instrucao_2", Cedente.Instrucao_2);
                    cmd.Parameters.AddWithValue("@ID_Banco", Cedente.ID_Banco);
                    cmd.Parameters.AddWithValue("@ID_Conta", Cedente.ID_Conta);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Cedente.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Tipo_Doc_Cedente", Cedente.Tipo_Doc_Cedente);
                    cmd.Parameters.AddWithValue("@CNPJ_CPF_Cedente", Cedente.CNPJ_CPF_Cedente);
                    cmd.Parameters.AddWithValue("@Razao_Cedente", Cedente.Razao_Cedente);
                    cmd.Parameters.AddWithValue("@UtilizaTarifa", Cedente.UtilizaTarifa);
                    cmd.Parameters.AddWithValue("@Tarifa", Cedente.Tarifa);
                    cmd.Parameters.AddWithValue("@DiaProtesto", Cedente.DiaProtesto);
                    cmd.Parameters.AddWithValue("@Aceite", Cedente.Aceite);
                    cmd.Parameters.AddWithValue("@Tipo_Emissao", Cedente.Tipo_Emissao);
                    cmd.Parameters.AddWithValue("@Cod_Protesto", Cedente.Cod_Protesto);
                    cmd.Parameters.AddWithValue("@Tipo_Cobranca", Cedente.Tipo_Cobranca);
                    cmd.Parameters.AddWithValue("@Ativo", Cedente.Ativo);
                    cmd.Parameters.AddWithValue("@Altera_Data", Cedente.Altera_Data);

                    conexao.Executa_Comando(cmd);
                }
                return Cedente.ID;
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
            try
            {
                conexao = new Conexao();
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "C.ID, C.Descricao, C.Cod_Cedente, C.Carteira, C.Juros, C.DiasJuros, C.Multa, C.DiasMulta, C.Instrucao_1, C.Instrucao_2, C.ID_Banco,  ";
                sql += "C.ID_Conta, C.Tipo_Doc_Cedente, C.CNPJ_CPF_Cedente, C.Razao_Cedente, C.UtilizaTarifa, C.Tarifa, C.DiaProtesto, C.Aceite, ";
                sql += "C.Tipo_Emissao, C.Cod_Protesto, C.Tipo_Cobranca, C.Ativo, ";
                sql += "B.ID_Caixa, ";
                sql += "PC.CodigoDescritivo AS Conta ";
                sql += "FROM Cedente AS C ";
                sql += "INNER JOIN Banco AS B ON B.ID = C.ID_Banco ";
                sql += "LEFT JOIN PlanoConta AS PC ON PC.ID = C.ID_Conta ";
                sql += "WHERE ";
                sql += "NOT C.ID IS NULL ";
                sql += "AND C.ID_Empresa = " + Cedente.ID_Empresa + " ";

                if (Cedente.ID > 0)
                    sql += "AND C.ID = " + Cedente.ID + " ";

                if (Cedente.FiltraAtivo == true)
                    sql += "AND C.Ativo = '" + Cedente.Ativo + "' ";

                if (Cedente.Descricao != null &&
                    Cedente.Descricao != String.Empty)
                    sql += "AND C.Descricao LIKE '" + Cedente.Descricao + "%' ";

                sql += "ORDER BY C.Descricao ";

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

                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM Boleto ";
                sql += "WHERE ";
                sql += "ID_Cedente = " + Cedente.ID + " ";
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Boleto\n";

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_Exclui_Erro + msg);

                sql = "DELETE FROM Cedente ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Cedente.ID);

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
