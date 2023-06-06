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
    public class DAL_Usuario
    {
        #region VARIAVEIS DE CLASSE
        Conexao conexao;
        #endregion

        #region VARIAVEIS DIVERSAS
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Usuario Usuario;
        DTO_Usuario_Parametros Usuario_Parametros;
        DTO_Log Log_Usuario;
        #endregion

        #region CONTRUTOR
        public DAL_Usuario(DTO_Usuario _Usuario)
        {
            this.Usuario = _Usuario;
        }

        public DAL_Usuario(DTO_Usuario_Parametros _Usuario_Parametros)
        {
            this.Usuario_Parametros = _Usuario_Parametros;
        }

        public DAL_Usuario(DTO_Log _Log)
        {
            this.Log_Usuario = _Log;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                if (Usuario.ID == 0)
                {
                    sql = "INSERT INTO Usuario ";
                    sql += "(Situacao, MultiEmpresa, ID_Empresa, Cadastrado, TipoPessoa, ID_Pessoa, Descricao, UsuarioSistema, SenhaSistema, ";
                    sql += "UsuarioMobile, SenhaMobile) ";
                    sql += "VALUES ";
                    sql += "(@Situacao, @MultiEmpresa, @ID_Empresa, @Cadastrado, @TipoPessoa, @ID_Pessoa, @Descricao, @UsuarioSistema, @SenhaSistema, ";
                    sql += "@UsuarioMobile, @SenhaMobile) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@Situacao", Usuario.Situacao);
                    cmd.Parameters.AddWithValue("@TipoUsuario", Usuario.Situacao);
                    cmd.Parameters.AddWithValue("@MultiEmpresa", Usuario.MultiEmpresa);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Usuario.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Cadastrado", Usuario.Cadastrado);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Usuario.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Usuario.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Descricao", Usuario.Descricao);
                    cmd.Parameters.AddWithValue("@UsuarioSistema", Usuario.UsuarioSistema);
                    cmd.Parameters.AddWithValue("@SenhaSistema", Usuario.SenhaSistema);
                    cmd.Parameters.AddWithValue("@UsuarioMobile", Usuario.UsuarioMobile);
                    cmd.Parameters.AddWithValue("@SenhaMobile", Usuario.SenhaMobile);

                    Usuario.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Usuario SET ";
                    sql += "Situacao = @Situacao, ";
                    sql += "MultiEmpresa = @MultiEmpresa, ";
                    sql += "ID_Empresa = @ID_Empresa, ";
                    sql += "Cadastrado = @Cadastrado, ";
                    sql += "TipoPessoa = @TipoPessoa, ";
                    sql += "ID_Pessoa = @ID_Pessoa, ";
                    sql += "Descricao = @Descricao, ";
                    sql += "UsuarioSistema = @UsuarioSistema, ";
                    sql += "SenhaSistema = @SenhaSistema, ";
                    sql += "UsuarioMobile = @UsuarioMobile, ";
                    sql += "SenhaMobile = @SenhaMobile ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Usuario.ID);
                    cmd.Parameters.AddWithValue("@Situacao", Usuario.Situacao);
                    cmd.Parameters.AddWithValue("@MultiEmpresa", Usuario.MultiEmpresa);
                    cmd.Parameters.AddWithValue("@ID_Empresa", Usuario.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Cadastrado", Usuario.Cadastrado);
                    cmd.Parameters.AddWithValue("@TipoPessoa", Usuario.TipoPessoa);
                    cmd.Parameters.AddWithValue("@ID_Pessoa", Usuario.ID_Pessoa);
                    cmd.Parameters.AddWithValue("@Descricao", Usuario.Descricao);
                    cmd.Parameters.AddWithValue("@UsuarioSistema", Usuario.UsuarioSistema);
                    cmd.Parameters.AddWithValue("@SenhaSistema", Usuario.SenhaSistema);
                    cmd.Parameters.AddWithValue("@UsuarioMobile", Usuario.UsuarioMobile);
                    cmd.Parameters.AddWithValue("@SenhaMobile", Usuario.SenhaMobile);

                    conexao.Executa_Comando(cmd);
                }

                return Usuario.ID;
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

        public void Grava_Parametros()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ID_Usuario ";
                sql += "FROM Parametro_Usuario ";
                sql += "WHERE ";
                sql += "ID_Usuario = " + Usuario_Parametros.ID_Usuario + " ";

                if (conexao.Consulta(sql).Rows.Count == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Parametro_Usuario ";
                    sql += "(ID_Usuario, Venda_Restrita, Comissao, Libera_Desconto, Venda_Fixa_logado, Permite_Faturar, Permite_AterarFaturado, Visualiza_ResumoVenda) ";
                    sql += "VALUES ";
                    sql += "(@ID_Usuario, @Venda_Restrita, @Comissao, @Libera_Desconto, @Venda_Fixa_logado, @Permite_Faturar, @Permite_AterarFaturado, @Visualiza_ResumoVenda) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Usuario", Usuario_Parametros.ID_Usuario);
                    cmd.Parameters.AddWithValue("@Venda_Restrita", Usuario_Parametros.Venda_Restrita);
                    cmd.Parameters.AddWithValue("@Comissao", Usuario_Parametros.Comissao);
                    cmd.Parameters.AddWithValue("@Libera_Desconto", Usuario_Parametros.Libera_Desconto);
                    cmd.Parameters.AddWithValue("@Venda_Fixa_logado", Usuario_Parametros.Venda_Fixa_logado);
                    cmd.Parameters.AddWithValue("@Permite_Faturar", Usuario_Parametros.Permite_Faturar);
                    cmd.Parameters.AddWithValue("@Permite_AterarFaturado", Usuario_Parametros.Permite_AterarFaturado);
                    cmd.Parameters.AddWithValue("@Visualiza_ResumoVenda", Usuario_Parametros.Visualiza_ResumoVenda);
                }
                else
                {
                    sql = "UPDATE Parametro_Usuario ";
                    sql += "SET ";
                    sql += "Venda_Restrita = @Venda_Restrita, ";
                    sql += "Comissao = @Comissao, ";
                    sql += "Libera_Desconto = @Libera_Desconto, ";
                    sql += "Venda_Fixa_logado = @Venda_Fixa_logado, ";
                    sql += "Permite_Faturar = @Permite_Faturar, ";
                    sql += "Permite_AterarFaturado = @Permite_AterarFaturado, ";
                    sql += "Visualiza_ResumoVenda = @Visualiza_ResumoVenda ";
                    sql += "WHERE ";
                    sql += "ID_Usuario = @ID_Usuario ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Usuario", Usuario_Parametros.ID_Usuario);
                    cmd.Parameters.AddWithValue("@Venda_Restrita", Usuario_Parametros.Venda_Restrita);
                    cmd.Parameters.AddWithValue("@Comissao", Usuario_Parametros.Comissao);
                    cmd.Parameters.AddWithValue("@Libera_Desconto", Usuario_Parametros.Libera_Desconto);
                    cmd.Parameters.AddWithValue("@Venda_Fixa_logado", Usuario_Parametros.Venda_Fixa_logado);
                    cmd.Parameters.AddWithValue("@Permite_Faturar", Usuario_Parametros.Permite_Faturar);
                    cmd.Parameters.AddWithValue("@Permite_AterarFaturado", Usuario_Parametros.Permite_AterarFaturado);
                    cmd.Parameters.AddWithValue("@Visualiza_ResumoVenda", Usuario_Parametros.Visualiza_ResumoVenda);
                }
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

        public void Grava_Comissao()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                for (int i = 0; i <= Usuario.lst_Comissao.Count - 1; i++)
                {
                    cmd = new SqlCommand();

                    if (Usuario.lst_Comissao[i].ID == 0)
                    {
                        sql = "INSERT INTO ";
                        sql += "Produto_Comissao ";
                        sql += "(ID_Produto, ID_Usuario, ID_TipoComissao, Comissao) ";
                        sql += "VALUES ";
                        sql += "(@ID_Produto, @ID_Usuario, @ID_TipoComissao, @Comissao) ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID_Produto", Usuario.lst_Comissao[i].ID_Produto);
                        cmd.Parameters.AddWithValue("@ID_Usuario", Usuario.ID);
                        cmd.Parameters.AddWithValue("@ID_TipoComissao", Usuario.lst_Comissao[i].ID_TipoComissao);
                        cmd.Parameters.AddWithValue("@Comissao", Usuario.lst_Comissao[i].Comissao);
                    }
                    else
                    {
                        sql = "UPDATE Produto_Comissao ";
                        sql += "SET ";
                        sql += "ID_TipoComissao = @ID_TipoComissao, ";
                        sql += "Comissao = @Comissao ";
                        sql += "WHERE ";
                        sql += "ID = @ID ";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@ID", Usuario.lst_Comissao[i].ID);
                        cmd.Parameters.AddWithValue("@ID_TipoComissao", Usuario.lst_Comissao[i].ID_TipoComissao);
                        cmd.Parameters.AddWithValue("@Comissao", Usuario.lst_Comissao[i].Comissao);
                    }
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

        public void Grava_Log()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
                {
                conexao.Abre_Conexao();

                sql = "INSERT INTO ";
                sql += "Log_Acesso ";
                sql += "(ID_Usuario, ID_Empresa, Data, Terminal) ";
                sql += "VALUES ";
                sql += "(@ID_Usuario, @ID_Empresa, @Data, @Terminal) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Usuario", Log_Usuario.ID_Usuario);
                cmd.Parameters.AddWithValue("@ID_Empresa", Log_Usuario.ID_Empresa);
                cmd.Parameters.AddWithValue("@Data", Log_Usuario.Data);
                cmd.Parameters.AddWithValue("@Terminal", Log_Usuario.Terminal);

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

        public void Grava_Saida_Log()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = " UPDATE ";
                sql += "Log_Acesso ";
                sql += "(DataSaida = @Data) ";
                sql += "WHERE ";
                sql += "(ID_Usuario = @ID_Usuario AND DataSaida IS NULL) ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Usuario", Log_Usuario.ID_Usuario);
                cmd.Parameters.AddWithValue("@ID_Empresa", Log_Usuario.ID_Empresa);
                cmd.Parameters.AddWithValue("@Data", Log_Usuario.Data);
                cmd.Parameters.AddWithValue("@Terminal", Log_Usuario.Terminal);

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
                sql += "ID, Situacao, MultiEmpresa, ID_Empresa, Cadastrado, TipoPessoa, ID_Pessoa, Descricao, UsuarioSistema, SenhaSistema, UsuarioMobile, SenhaMobile ";
                sql += "FROM ";
                sql += "Usuario  ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND (ID_Empresa = " + Usuario.ID_Empresa + " OR ID_Empresa = 0) ";

                if (Usuario.Filtra_Situacao == true)
                    sql += "AND Situacao = '" + Usuario.Situacao + "', ";

                if (Usuario.ID > 0)
                    sql += "AND ID = " + Usuario.ID + " ";

                if (Usuario.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + Usuario.Descricao + "%' ";

                if (Usuario.TipoPessoa > 0)
                    sql += "AND TipoPessoa = " + Usuario.TipoPessoa + " ";

                if (Usuario.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa  = " + Usuario.ID_Pessoa + " ";

                if (Usuario.SenhaSistema != string.Empty)
                    sql += "AND SenhaSistema  = " + Usuario.SenhaSistema + " ";

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

        public DataTable Busca_Usuario()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "U.ID ";
                sql += "FROM ";
                sql += "Usuario AS U ";
                sql += "INNER JOIN Parametro_Usuario AS UP ON U.ID = UP.ID_Usuario ";
                sql += "WHERE ";
                sql += "NOT U.ID IS NULL ";

                switch (Usuario.TipoConsulta)
                {
                    case 1: //LIBERA DESCONTO
                        sql += "AND UP.Libera_Desconto = 'true' ";
                        break;

                    case 2: //VISUALIZA RESUMO VENDA
                        sql += "AND UP.Visualiza_ResumoVenda = 'true' ";
                        break;

                }

                sql += "AND U.Descricao = '" + Usuario.Descricao + "' ";
                sql += "AND U.SenhaSistema  = '" + Usuario.SenhaSistema + "' ";

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

        public DataTable Busca_Nome()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "U.ID, U.Descricao ";
                sql += "FROM ";
                sql += "Usuario AS U ";
                sql += "LEFT JOIN Parametro_Usuario AS UP ON U.ID = UP.ID_Usuario ";
                sql += "WHERE ";
                sql += "NOT U.ID IS NULL ";
                sql += "AND (U.ID_Empresa = " + Usuario.ID_Empresa + " OR U.ID_Empresa = 0) ";

                if (Usuario.Filtra_Situacao == true)
                    sql += "AND U.Situacao = '" + Usuario.Situacao + "' ";

                if (Usuario.Filtra_Comissao == true)
                    sql += "AND UP.Comissao = '" + Usuario.Comissao + "' ";

                sql += "ORDER BY U.Descricao ";

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

        public DataTable Busca_Comissao()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Usuario ";
                sql += "FROM Produto_Comissao ";
                sql += "WHERE ";
                sql += "ID_Usuario = " + Usuario.ID;

                if (conexao.Consulta(sql).Rows.Count == 0)
                {
                    sql = "SELECT ";
                    sql += "P.Descricao AS Produto, P.ID AS ID_Produto ";
                    sql += "FROM  Produto_Servico AS P ";
                    sql += "WHERE NOT P.ID IS NULL ";
                    sql += "ORDER BY P.Descricao ";
                }
                else
                {
                    sql = "SELECT ";
                    sql += "PC.ID, PC.ID_TipoComissao, PC.Comissao, ";
                    sql += "CASE PC.ID_TipoComissao ";
                    sql += "WHEN 1 THEN 'Valor' ";
                    sql += "WHEN 2 THEN 'Porcentagem' ";
                    sql += "END AS TipoComissao, ";
                    sql += "P.Descricao AS Produto, P.ID AS ID_Produto ";
                    sql += "FROM Produto_Comissao AS PC ";
                    sql += "RIGHT JOIN Produto_Servico AS P ON PC.ID_Produto = P.ID AND PC.ID_Usuario = " + Usuario.ID + " ";
                    sql += "ORDER BY P.Descricao ";
                }

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

        public DataTable Busca_ComissaoValor()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PC.Comissao, ";
                sql += "CASE PC.ID_TipoComissao ";
                sql += "WHEN 1 THEN 'Valor' ";
                sql += "WHEN 2 THEN 'Porcentagem' ";
                sql += "END AS TipoComissao ";
                sql += "FROM Produto_Comissao AS PC ";
                sql += "WHERE ";
                sql += "PC.ID_Usuario = " + Usuario.ID + " ";
                sql += "AND PC.ID_Produto = " + Usuario.ID_Produto + " ";

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

        public DataTable Busca_Sistema()
        {
            conexao = new Conexao();

            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID, ID_Empresa, Descricao, UsuarioSistema, SenhaSistema, Situacao ";
                sql += "FROM ";
                sql += "Usuario ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND Descricao = '" + Usuario.Descricao + "' ";
                sql += "AND UsuarioSistema = '" + Usuario.UsuarioSistema + "' ";
                sql += "AND SenhaSistema = '" + Usuario.SenhaSistema + "' ";
                sql += "AND Situacao = '" + Usuario.Situacao + "' ";

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

        public DataTable Busca_Parametros()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "Comissao, Venda_Restrita, Libera_Desconto, Venda_Fixa_logado, Permite_Faturar, Permite_AterarFaturado, Visualiza_ResumoVenda ";
                sql += "FROM ";
                sql += "Parametro_Usuario ";
                sql += "WHERE ";
                sql += "NOT ID_Usuario IS NULL ";
                sql += "AND ID_Usuario = " + Usuario.ID;

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

                #region CONSULTA MÓDULOS
                sql = "SELECT ID_Usuario ";
                sql += "FROM PessoaCliente ";
                sql += "WHERE ";
                sql += "ID_Usuario = " + Usuario.ID + " ";

                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "USUÁRIO CADASTRO PESSOA\n";

                sql = "SELECT ID ";
                sql += "FROM Venda ";
                sql += "WHERE ";
                sql += "ID_UsuarioComissao1 = " + Usuario.ID + " OR ";
                sql += "ID_UsuarioComissao2 = " + Usuario.ID + " ";
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "VENDAS\n";

                sql = "SELECT ID ";
                sql += "FROM Orcamento ";
                sql += "WHERE ";
                sql += "ID_UsuarioComissao1 = " + Usuario.ID + " OR ";
                sql += "ID_UsuarioComissao2 = " + Usuario.ID + " ";
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "ORÇAMENTOS\n";

                sql = "SELECT ID ";
                sql += "FROM Ordem_Servico ";
                sql += "WHERE ";
                sql += "ID_UsuarioComissao1 = " + Usuario.ID + " OR ";
                sql += "ID_UsuarioComissao2 = " + Usuario.ID + " ";
                if (conexao.Consulta(sql).Rows.Count > 0)
                    msg += "ORDEM DE SERVIÇO\n";

                if (msg != string.Empty)
                    throw new Exception(util_msg.msg_DAL_Erro_Exclui + msg);
                #endregion

                sql = "DELETE FROM ";
                sql += "Usuario ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Usuario.ID);

                conexao.Executa_Comando(cmd);

                sql = "DELETE FROM ";
                sql += "Produto_Comissao ";
                sql += "WHERE ";
                sql += "ID_Usuario = @ID ";
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
    }

    public class DAL_Usuario_Acesso
    {
        #region VARIAVEIS DE CLASSE
        Conexao conexao;
        #endregion

        #region VARIAVEIS DIVERSAS
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_Usuario_Parametros Usuario_Parametros;
        #endregion

        #region CONSTRUTORES
        public DAL_Usuario_Acesso(DTO_Usuario_Parametros _Usuario_Parametros)
        {
            this.Usuario_Parametros = _Usuario_Parametros;
        }
        #endregion

        public void Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "ID_Usuario, Menu ";
                sql += "FROM ";
                sql += "PermissaoSistema ";
                sql += "WHERE ";
                sql += "ID_Usuario = " + Usuario_Parametros.ID_Usuario + " AND Menu = '" + Usuario_Parametros.Menu + "'";

                if (conexao.Consulta(sql).Rows.Count == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "PermissaoSistema ";
                    sql += "(ID_Usuario, Menu) ";
                    sql += "VALUES ";
                    sql += "(@ID_Usuario, @Menu)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Usuario", Usuario_Parametros.ID_Usuario);
                    cmd.Parameters.AddWithValue("@Menu", Usuario_Parametros.Menu);
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

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "PS.ID_Usuario, PS.Menu, U.Descricao ";
                sql += "FROM ";
                sql += "PermissaoSistema AS PS INNER JOIN Usuario AS U ON PS.ID_Usuario = U.ID ";
                sql += "WHERE ";
                sql += "NOT PS.ID_Usuario IS NULL ";
                if (Usuario_Parametros.ID_Usuario > 0)
                    sql += " AND PS.ID_Usuario = " + Usuario_Parametros.ID_Usuario;

                if (Usuario_Parametros.Menu != string.Empty)
                    sql += " AND PS.Menu = '" + Usuario_Parametros.Menu + "'";

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
                sql += "PermissaoSistema ";
                sql += "WHERE ";
                sql += "ID_Usuario = @ID_Usuario AND Menu = @Menu ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID_Usuario", Usuario_Parametros.ID_Usuario);
                cmd.Parameters.AddWithValue("@Menu", Usuario_Parametros.Menu);

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
