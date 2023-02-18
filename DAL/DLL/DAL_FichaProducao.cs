using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Sistema.DTO;
using Sistema.UTIL;
using System.Data;

namespace Sistema.DAL
{
    public class DAL_FichaProducao
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;
        SqlCommand cmd;

        string sql;
        string msg;
        #endregion

        #region ESTRUTURA
        DTO_FichaProducao FichaProducao;
        #endregion

        #region CONSTRUTOR
        public DAL_FichaProducao(DTO_FichaProducao _FichaProducao)
        {
            this.FichaProducao = _FichaProducao;
        }
        #endregion

        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                if (FichaProducao.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "FichaProducao ";
                    sql += "(ID_Empresa, ID_Venda, Situacao, Entrada, Saida, Transportadora, ID_Item_Venda, AnoModelo, CorCouro, Costura, Logomarca, ";
                    sql += "Laterais_Porta, ApoioCabeca, TipoAcento, TipoEncosto, ABD, ABT, Observacao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @ID_Venda, @Situacao, @Entrada, @Saida, @Transportadora, @ID_Item_Venda, @AnoModelo, @CorCouro, @Costura, @Logomarca, ";
                    sql += "@Laterais_Porta, @ApoioCabeca, @TipoAcento, @TipoEncosto, @ABD, @ABT, @Observacao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", FichaProducao.ID_Empresa);
                    cmd.Parameters.AddWithValue("@ID_Venda", FichaProducao.ID_Venda);
                    cmd.Parameters.AddWithValue("@Situacao", FichaProducao.Situacao);
                    cmd.Parameters.AddWithValue("@Entrada", FichaProducao.Entrada);
                    cmd.Parameters.AddWithValue("@Saida", FichaProducao.Saida);
                    cmd.Parameters.AddWithValue("@Transportadora", FichaProducao.Transportadora);
                    cmd.Parameters.AddWithValue("@ID_Item_Venda", FichaProducao.ID_Item_Venda);
                    cmd.Parameters.AddWithValue("@AnoModelo", FichaProducao.AnoModelo);
                    cmd.Parameters.AddWithValue("@CorCouro", FichaProducao.CorCouro);
                    cmd.Parameters.AddWithValue("@Costura", FichaProducao.Costura);
                    cmd.Parameters.AddWithValue("@Logomarca", FichaProducao.Logomarca);
                    cmd.Parameters.AddWithValue("@Laterais_Porta", FichaProducao.Laterais_Porta);
                    cmd.Parameters.AddWithValue("@ApoioCabeca", FichaProducao.ApoioCabeca);
                    cmd.Parameters.AddWithValue("@TipoAcento", FichaProducao.TipoAcento);
                    cmd.Parameters.AddWithValue("@TipoEncosto", FichaProducao.TipoEncosto);
                    cmd.Parameters.AddWithValue("@ABD", FichaProducao.ABD);
                    cmd.Parameters.AddWithValue("@ABT", FichaProducao.ABT);
                    cmd.Parameters.AddWithValue("@Observacao", FichaProducao.Observacao);

                    FichaProducao.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE FichaProducao SET ";
                    sql += "ID_Venda = @ID_Venda, ";
                    sql += "Situacao = @Situacao, ";
                    sql += "Entrada =  @Entrada, ";
                    sql += "Saida = @Saida, ";
                    sql += "Transportadora = @Transportadora, ";
                    sql += "ID_Item_Venda = @ID_Item_Venda, ";
                    sql += "AnoModelo = @AnoModelo, ";
                    sql += "CorCouro = @CorCouro, ";
                    sql += "Costura = @Costura, ";
                    sql += "Logomarca = @Logomarca, ";
                    sql += "Laterais_Porta = @Laterais_Porta, ";
                    sql += "ApoioCabeca = @ApoioCabeca, ";
                    sql += "TipoAcento = @TipoAcento, ";
                    sql += "TipoEncosto = @TipoEncosto, ";
                    sql += "ABD = @ABD, ";
                    sql += "ABT = @ABT, ";
                    sql += "Observacao = @Observacao ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", FichaProducao.ID);
                    cmd.Parameters.AddWithValue("@ID_Venda", FichaProducao.ID_Venda);
                    cmd.Parameters.AddWithValue("@Situacao", FichaProducao.Situacao);
                    cmd.Parameters.AddWithValue("@Entrada", FichaProducao.Entrada);
                    cmd.Parameters.AddWithValue("@Saida", FichaProducao.Saida);
                    cmd.Parameters.AddWithValue("@Transportadora", FichaProducao.Transportadora);
                    cmd.Parameters.AddWithValue("@ID_Item_Venda", FichaProducao.ID_Item_Venda);
                    cmd.Parameters.AddWithValue("@AnoModelo", FichaProducao.AnoModelo);
                    cmd.Parameters.AddWithValue("@CorCouro", FichaProducao.CorCouro);
                    cmd.Parameters.AddWithValue("@Costura", FichaProducao.Costura);
                    cmd.Parameters.AddWithValue("@Logomarca", FichaProducao.Logomarca);
                    cmd.Parameters.AddWithValue("@Laterais_Porta", FichaProducao.Laterais_Porta);
                    cmd.Parameters.AddWithValue("@ApoioCabeca", FichaProducao.ApoioCabeca);
                    cmd.Parameters.AddWithValue("@TipoAcento", FichaProducao.TipoAcento);
                    cmd.Parameters.AddWithValue("@TipoEncosto", FichaProducao.TipoEncosto);
                    cmd.Parameters.AddWithValue("@ABD", FichaProducao.ABD);
                    cmd.Parameters.AddWithValue("@ABT", FichaProducao.ABT);
                    cmd.Parameters.AddWithValue("@Observacao", FichaProducao.Observacao);
                    conexao.Executa_Comando(cmd);
                }
                return FichaProducao.ID;
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

        public void Altera_Situacao()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "UPDATE FichaProducao SET ";
                sql += "Situacao = @Situacao ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", FichaProducao.ID);
                cmd.Parameters.AddWithValue("@Situacao", FichaProducao.Situacao);

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
                sql += "ID, ID_Empresa, ID_Venda, Situacao, DataVenda, Entrada, Saida, Transportadora, ID_Item_Venda, AnoModelo, CorCouro, Costura, Logomarca, ";
                sql += "Laterais_Porta, ApoioCabeca, TipoAcento, TipoEncosto, ABD, ABT, Observacao, DescricaoSituacao, DescricaoLogomarca, ";
                sql += "DescricaoPessoa, DescricaoProduto, InfoAdicional1, DescricaoUsuarioComissao1, DescricaoProdutoInfo ";
                sql += "FROM V_FichaProducao ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Empresa = " + FichaProducao.ID_Empresa + " ";

                if (FichaProducao.ID > 0)
                    sql += "AND ID = " + FichaProducao.ID + " ";

                if (FichaProducao.Situacao > 0)
                    sql += "AND Situacao = " + FichaProducao.Situacao + " ";

                if (FichaProducao.ID_Pessoa > 0)
                    sql += "AND ID_Pessoa = " + FichaProducao.ID_Pessoa + " ";

                if (FichaProducao.ID_Venda > 0)
                    sql += "AND ID_Venda = " + FichaProducao.ID_Venda + " ";

                if (FichaProducao.DescricaoPessoa != string.Empty)
                    sql += "AND DescricaoPessoa LIKE '" + FichaProducao.DescricaoPessoa + "%' ";

                if (FichaProducao.Consulta_Entrada.Filtra == true)
                    sql += "AND CONVERT(DATE, Entrada) BETWEEN CONVERT(DATE, '" + FichaProducao.Consulta_Entrada.Inicial + "') AND CONVERT(DATE, '" + FichaProducao.Consulta_Entrada.Final + "') ";

                if (FichaProducao.Consulta_Saida.Filtra == true)
                    sql += "AND CONVERT(DATE, Saida) BETWEEN CONVERT(DATE, '" + FichaProducao.Consulta_Saida.Inicial + "') AND CONVERT(DATE, '" + FichaProducao.Consulta_Saida.Final + "') ";
                
                sql += "ORDER BY ID, DescricaoPessoa ";

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

                sql = "DELETE FROM FichaProducao ";
                sql += "WHERE ";
                sql += "ID = @ID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", FichaProducao.ID);
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
