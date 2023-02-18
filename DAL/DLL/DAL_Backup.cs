using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sistema.DTO;

namespace Sistema.DAL
{
    public class DAL_Backup
    {
        Conexao conexao;

        #region VARIAVEIS DIVERSAS
        string sql;

        SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_Backup Backup;
        #endregion

        #region CONSTRUTORES
        public DAL_Backup(DTO_Backup _Backup)
        {
            this.Backup = _Backup;
        }

        public DAL_Backup()
        {
        }
        #endregion

        public void Grava_Backup()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            try
            {
                conexao.Abre_Conexao();

                sql = "BACKUP DATABASE ";
                sql += Backup.Banco + " ";
                sql += "TO DISK = '" + @Backup.Local + "' ";

                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);
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

        public DataTable Lista_BD()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();
                sql = "SELECT name FROM sys.databases WHERE name LIKE 'BD%' ";

                return conexao.Consulta(sql);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }
    }
}
