using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.DAL
{
    public class DAL_Imagem
    {
        #region VARIAVEIS DIVERSAS
        Conexao conexao;

        string sql;
        
        SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_Imagem Imagem;
        #endregion

        #region CONSTRUTOR
        public DAL_Imagem(DTO_Imagem _Imagem)
        {
            this.Imagem = _Imagem;
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
                sql += "ID ";
                sql += "FROM ";
                sql += "Imagem ";
                sql += "WHERE ";
                sql += "Tipo = " + Imagem.Tipo + " ";
                sql += "AND ID_Empresa = " + Imagem.ID_Empresa;

                if (conexao.Consulta(sql).Rows.Count == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Imagem ";
                    sql += "(ID_Empresa, Tipo, Imagem) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Tipo, @Imagem)";
                }
                else
                {
                    sql = "UPDATE ";
                    sql += "Imagem ";
                    sql += "SET Imagem = @Imagem ";
                    sql += "WHERE ";
                    sql += "Tipo = @Tipo ";
                    sql += "AND ID_Empresa = @ID_Empresa ";
                }
                cmd.CommandText = sql;
                cmd.Parameters.Add("@Imagem", SqlDbType.Binary, (int)Imagem.Imagem.Length).Value = Imagem.ArqByteArray;
                cmd.Parameters.AddWithValue("@Tipo", Imagem.Tipo);
                cmd.Parameters.AddWithValue("@ID_Empresa", Imagem.ID_Empresa);

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
                sql += "Imagem ";
                sql += "From ";
                sql += "Imagem ";
                sql += "WHERE ";
                sql += "Tipo = " + Imagem.Tipo + " ";
                sql += "AND ID_Empresa = " + Imagem.ID_Empresa;

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
    }
}
