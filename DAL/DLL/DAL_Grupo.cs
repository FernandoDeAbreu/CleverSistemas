using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_Grupo
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        #endregion

        #region CONSTRUTORES
        public DAL_Grupo(DTO_Grupo _Grupo)
        {
            this.Grupo = _Grupo;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();
                if (Grupo.ID == 0)
                {
                    sql = "INSERT INTO Grupo ";
                    sql += "(Tipo, Descricao, Exibir) ";
                    sql += "VALUES ";
                    sql += "(@Tipo, @Descricao, @Exibir) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Tipo", Grupo.Tipo);
                    cmd.Parameters.AddWithValue("@Descricao", Grupo.Descricao);
                    cmd.Parameters.AddWithValue("@Exibir", Grupo.Exibir);

                    Grupo.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE Grupo ";
                    sql += "SET ";
                    sql += "Descricao = @Descricao, ";
                    sql += "Exibir = @Exibir ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Grupo.ID);
                    cmd.Parameters.AddWithValue("@Descricao", Grupo.Descricao);
                    cmd.Parameters.AddWithValue("@Exibir", Grupo.Exibir);

                    conexao.Executa_Comando(cmd);
                }
                return Grupo.ID;
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
                sql += "ID, Tipo, Descricao, Exibir ";
                sql += "FROM Grupo ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";

                if (Grupo.FiltraExibir == true)
                    sql += "AND Exibir = '" + Grupo.Exibir + "' ";

                if (Grupo.ID > 0)
                    sql += "AND ID = " + Grupo.ID + " ";

                if (Grupo.Tipo > 0)
                    sql += "AND Tipo = " + Grupo.Tipo + " ";

                if (Grupo.Descricao != null)
                    sql += "AND Descricao LIKE '" + Grupo.Descricao + "%' ";

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
            cmd = new SqlCommand();
            conexao = new Conexao();

            msg = string.Empty;
            try
            {
                conexao.Abre_Conexao();

                #region CONSULTA MÓDULOS
                sql = "SELECT ID ";
                sql += "FROM Cheque ";
                sql += "WHERE ";
                sql += "Tipo = " + Grupo.ID + " ";
                sql += "OR Situacao = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";

                sql = "SELECT ID ";
                sql += "FROM Cpagar ";
                sql += "WHERE ";
                sql += "Situacao = " + Grupo.ID + " ";
                sql += "OR Caixa = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Contas à Pagar.\n";

                sql = "SELECT ID ";
                sql += "FROM CReceber ";
                sql += "WHERE ";
                sql += "Situacao = " + Grupo.ID + " ";
                sql += "OR Caixa = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Contas à Receber.\n";

                sql = "SELECT ID ";
                sql += "FROM Compra ";
                sql += "WHERE ";
                sql += "TipoDocumento = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Entrada Produto.\n";

                sql = "SELECT ID ";
                sql += "FROM FluxoCaixa ";
                sql += "WHERE ";
                sql += "Caixa = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Caixa.\n";

                sql = "SELECT ID ";
                sql += "FROM Ordem_Servico ";
                sql += "WHERE ";
                sql += "TipoAtendimento = " + Grupo.ID + " ";
                sql += "OR Tipo_Equipamento = " + Grupo.ID + " ";

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Ordem de Serviço.\n";

                sql = "SELECT ID_Email ";
                sql += "FROM PessoaEmail ";
                sql += "WHERE ";
                sql += "TipoEmail = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Cadastro Pessoa (Email).\n";

                sql = "SELECT ID_Endereco ";
                sql += "FROM PessoaEndereco ";
                sql += "WHERE ";
                sql += "TipoEndereco = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Cadastro Pessoa (Endereço).\n";

                sql = "SELECT ID_Telefone ";
                sql += "FROM PessoaTelefone ";
                sql += "WHERE ";
                sql += "TipoTelefone = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Cadastro Pessoa (Telefone).\n";

                sql = "SELECT ID_Grupo ";
                sql += "FROM Grade ";
                sql += "WHERE ";
                sql += "ID_Grupo = " + Grupo.ID;

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "Grade.\n";
                #endregion

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_DAL_Erro_Exclui + msg);

                sql = "DELETE FROM ";
                sql += "Grupo ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Grupo.ID);
                conexao.Executa_Comando(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
