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
    public class DAL_Imposto
    {
        #region VARIAVEIS DIVERSAS
        string sql;
        Conexao conexao;
        SqlCommand cmd;
        #endregion

        #region ESTRUTURA
        DTO_Imposto Imposto;
        #endregion

        #region CONSTRUTORES
        public DAL_Imposto(DTO_Imposto _Imposto)
        {
            this.Imposto = _Imposto;
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

                if (Imposto.ID == 0)
                {
                    sql = "INSERT INTO ";
                    sql += "Imposto ";
                    sql += "(ID_Empresa, Descricao) ";
                    sql += "VALUES ";
                    sql += "(@ID_Empresa, @Descricao) ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID_Empresa", Imposto.ID_Empresa);
                    cmd.Parameters.AddWithValue("@Descricao", Imposto.Descricao);

                    Imposto.ID = conexao.Executa_ComandoID(cmd);
                }
                else
                {
                    sql = "UPDATE Imposto ";
                    sql += "SET Descricao = @Descricao ";
                    sql += "WHERE ";
                    sql += "ID = @ID ";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@ID", Imposto.ID);
                    cmd.Parameters.AddWithValue("@Descricao", Imposto.Descricao);

                    conexao.Executa_Comando(cmd);
                }

                #region GRAVA TRIBUTAÇÃO
                if (Imposto.lst_Tributacao != null &&
                    Imposto.lst_Tributacao.Count > 0)
                    for (int i = 0; i <= Imposto.lst_Tributacao.Count - 1; i++)
                    {
                        cmd = new SqlCommand();
                        if (Imposto.lst_Tributacao[i].ID == 0)
                        {
                            sql = "INSERT INTO ";
                            sql += "Imposto_Tributacao ";
                            sql += "(ID_Imposto, Tipo_NF, CFOP, CST, Origem, ModalidadeBC, AliquotaICMS, PercentualReducao, ModalidadeBCST, AliquotaICMSST, PercentualReducaoST, ";
                            sql += "MargemVAdicionado, vICMSDeson, vICMSOp, pDif, vICMSDif, CSTPIS, AliquotaPIS, AliquotaPISST, CSTCOFINS, AliquotaCOFINS, AliquotaCOFINSST, CSTIPI, AliquotaIPI, Cod_Enquadramento) ";
                            sql += "VALUES ";
                            sql += "(@ID_Imposto, @Tipo_NF, @CFOP, @CST, @Origem, @ModalidadeBC, @AliquotaICMS, @PercentualReducao, @ModalidadeBCST, @AliquotaICMSST, @PercentualReducaoST, ";
                            sql += "@MargemVAdicionado, @vICMSDeson, @vICMSOp, @pDif, @vICMSDif, @CSTPIS, @AliquotaPIS, @AliquotaPISST, @CSTCOFINS, @AliquotaCOFINS, @AliquotaCOFINSST, @CSTIPI, @AliquotaIPI, @Cod_Enquadramento) ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Imposto", Imposto.ID);
                            cmd.Parameters.AddWithValue("@Tipo_NF", Imposto.lst_Tributacao[i].Tipo_NF);
                            cmd.Parameters.AddWithValue("@CFOP", Imposto.lst_Tributacao[i].CFOP);
                            cmd.Parameters.AddWithValue("@CST", Imposto.lst_Tributacao[i].CST);
                            cmd.Parameters.AddWithValue("@Origem", Imposto.lst_Tributacao[i].Origem);
                            cmd.Parameters.AddWithValue("@ModalidadeBC", Imposto.lst_Tributacao[i].ModalidadeBC);
                            cmd.Parameters.AddWithValue("@AliquotaICMS", Imposto.lst_Tributacao[i].AliquotaICMS);
                            cmd.Parameters.AddWithValue("@PercentualReducao", Imposto.lst_Tributacao[i].PercentualReducao);
                            cmd.Parameters.AddWithValue("@ModalidadeBCST", Imposto.lst_Tributacao[i].ModalidadeBCST);
                            cmd.Parameters.AddWithValue("@AliquotaICMSST", Imposto.lst_Tributacao[i].AliquotaICMSST);
                            cmd.Parameters.AddWithValue("@PercentualReducaoST", Imposto.lst_Tributacao[i].PercentualReducaoST);
                            cmd.Parameters.AddWithValue("@MargemVAdicionado", Imposto.lst_Tributacao[i].MargemVLAdicionado);
                            cmd.Parameters.AddWithValue("@vICMSDeson", Imposto.lst_Tributacao[i].vICMSDeson);
                            cmd.Parameters.AddWithValue("@vICMSOp", Imposto.lst_Tributacao[i].vICMSOp);
                            cmd.Parameters.AddWithValue("@pDif", Imposto.lst_Tributacao[i].pDif);
                            cmd.Parameters.AddWithValue("@vICMSDif", Imposto.lst_Tributacao[i].vICMSDif);
                            cmd.Parameters.AddWithValue("@CSTPIS", Imposto.lst_Tributacao[i].CSTPIS);
                            cmd.Parameters.AddWithValue("@AliquotaPIS", Imposto.lst_Tributacao[i].AliquotaPIS);
                            cmd.Parameters.AddWithValue("@AliquotaPISST", Imposto.lst_Tributacao[i].AliquotaPISST);
                            cmd.Parameters.AddWithValue("@CSTCOFINS", Imposto.lst_Tributacao[i].CSTCOFINS);
                            cmd.Parameters.AddWithValue("@AliquotaCOFINS", Imposto.lst_Tributacao[i].AliquotaCOFINS);
                            cmd.Parameters.AddWithValue("@AliquotaCOFINSST", Imposto.lst_Tributacao[i].AliquotaCOFINSST);
                            cmd.Parameters.AddWithValue("@CSTIPI", Imposto.lst_Tributacao[i].CSTIPI);
                            cmd.Parameters.AddWithValue("@AliquotaIPI", Imposto.lst_Tributacao[i].AliquotaIPI);
                            cmd.Parameters.AddWithValue("@Cod_Enquadramento", Imposto.lst_Tributacao[i].Cod_Enquadramento);

                            Imposto.lst_Tributacao[i].ID = conexao.Executa_ComandoID(cmd);
                        }
                        else
                        {
                            sql = "UPDATE Imposto_Tributacao SET ";
                            sql += "Tipo_NF = @Tipo_NF, ";
                            sql += "CFOP = @CFOP, ";
                            sql += "CST = @CST, ";
                            sql += "Origem = @Origem, ";
                            sql += "ModalidadeBC = @ModalidadeBC, ";
                            sql += "AliquotaICMS = @AliquotaICMS, ";
                            sql += "PercentualReducao = @PercentualReducao, ";
                            sql += "ModalidadeBCST = @ModalidadeBCST, ";
                            sql += "AliquotaICMSST = @AliquotaICMSST, ";
                            sql += "PercentualReducaoST = @PercentualReducaoST, ";
                            sql += "MargemVAdicionado = @MargemVAdicionado, ";
                            sql += "vICMSDeson = @vICMSDeson, ";
                            sql += "vICMSOp = @vICMSOp, ";
                            sql += "pDif = @pDif, ";
                            sql += "vICMSDif = @vICMSDif, ";
                            sql += "CSTPIS = @CSTPIS, ";
                            sql += "AliquotaPIS = @AliquotaPIS, ";
                            sql += "AliquotaPISST = @AliquotaPISST, ";
                            sql += "CSTCOFINS = @CSTCOFINS, ";
                            sql += "AliquotaCOFINS = @AliquotaCOFINS, ";
                            sql += "AliquotaCOFINSST = @AliquotaCOFINSST, ";
                            sql += "CSTIPI = @CSTIPI, ";
                            sql += "AliquotaIPI = @AliquotaIPI, ";
                            sql += "Cod_Enquadramento = @Cod_Enquadramento ";
                            sql += "WHERE ";
                            sql += "ID = @ID ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID", Imposto.lst_Tributacao[i].ID);
                            cmd.Parameters.AddWithValue("@Tipo_NF", Imposto.lst_Tributacao[i].Tipo_NF);
                            cmd.Parameters.AddWithValue("@CFOP", Imposto.lst_Tributacao[i].CFOP);
                            cmd.Parameters.AddWithValue("@CST", Imposto.lst_Tributacao[i].CST);
                            cmd.Parameters.AddWithValue("@Origem", Imposto.lst_Tributacao[i].Origem);
                            cmd.Parameters.AddWithValue("@ModalidadeBC", Imposto.lst_Tributacao[i].ModalidadeBC);
                            cmd.Parameters.AddWithValue("@AliquotaICMS", Imposto.lst_Tributacao[i].AliquotaICMS);
                            cmd.Parameters.AddWithValue("@PercentualReducao", Imposto.lst_Tributacao[i].PercentualReducao);
                            cmd.Parameters.AddWithValue("@ModalidadeBCST", Imposto.lst_Tributacao[i].ModalidadeBCST);
                            cmd.Parameters.AddWithValue("@AliquotaICMSST", Imposto.lst_Tributacao[i].AliquotaICMSST);
                            cmd.Parameters.AddWithValue("@PercentualReducaoST", Imposto.lst_Tributacao[i].PercentualReducaoST);
                            cmd.Parameters.AddWithValue("@MargemVAdicionado", Imposto.lst_Tributacao[i].MargemVLAdicionado);
                            cmd.Parameters.AddWithValue("@vICMSDeson", Imposto.lst_Tributacao[i].vICMSDeson);
                            cmd.Parameters.AddWithValue("@vICMSOp", Imposto.lst_Tributacao[i].vICMSOp);
                            cmd.Parameters.AddWithValue("@pDif", Imposto.lst_Tributacao[i].pDif);
                            cmd.Parameters.AddWithValue("@vICMSDif", Imposto.lst_Tributacao[i].vICMSDif);
                            cmd.Parameters.AddWithValue("@CSTPIS", Imposto.lst_Tributacao[i].CSTPIS);
                            cmd.Parameters.AddWithValue("@AliquotaPIS", Imposto.lst_Tributacao[i].AliquotaPIS);
                            cmd.Parameters.AddWithValue("@AliquotaPISST", Imposto.lst_Tributacao[i].AliquotaPISST);
                            cmd.Parameters.AddWithValue("@CSTCOFINS", Imposto.lst_Tributacao[i].CSTCOFINS);
                            cmd.Parameters.AddWithValue("@AliquotaCOFINS", Imposto.lst_Tributacao[i].AliquotaCOFINS);
                            cmd.Parameters.AddWithValue("@AliquotaCOFINSST", Imposto.lst_Tributacao[i].AliquotaCOFINSST);
                            cmd.Parameters.AddWithValue("@CSTIPI", Imposto.lst_Tributacao[i].CSTIPI);
                            cmd.Parameters.AddWithValue("@AliquotaIPI", Imposto.lst_Tributacao[i].AliquotaIPI);
                            cmd.Parameters.AddWithValue("@Cod_Enquadramento", Imposto.lst_Tributacao[i].Cod_Enquadramento);

                            conexao.Executa_Comando(cmd);
                        }
                    }
                #endregion

                #region GRAVA TRIBUTAÇÃO UF
                if (Imposto.lst_Tributacao.Count > 0)
                    for (int i = 0; i <= Imposto.lst_Tributacao.Count - 1; i++)
                        if (Imposto.lst_Tributacao[i].lst_UF != null)
                        {
                            cmd = new SqlCommand();

                            sql = "DELETE FROM ";
                            sql += "Imposto_UF ";
                            sql += "WHERE ID_Tributacao = @ID_Tributacao ";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@ID_Tributacao", Imposto.lst_Tributacao[i].ID);

                            conexao.Executa_Comando(cmd);

                            for (int y = 0; y <= Imposto.lst_Tributacao[i].lst_UF.Length - 1; y++)
                            {
                                cmd = new SqlCommand();

                                sql = "INSERT INTO ";
                                sql += "Imposto_UF ";
                                sql += "(ID_Tributacao, ID_UF) ";
                                sql += "VALUES ";
                                sql += "(@ID_Tributacao, @ID_UF) ";
                                cmd.CommandText = sql;
                                cmd.Parameters.AddWithValue("@ID_Tributacao", Imposto.lst_Tributacao[i].ID);
                                cmd.Parameters.AddWithValue("@ID_UF", Imposto.lst_Tributacao[i].lst_UF[y]);

                                conexao.Executa_Comando(cmd);
                            }
                        }
                #endregion

                conexao.Commit_Conexao();
                return Imposto.ID;
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

                sql = "SELECT ";
                sql += "ID, ID_Empresa, Descricao ";
                sql += "FROM ";
                sql += "Imposto ";
                sql += "WHERE ";
                sql += "NOT ID IS NULL ";
                sql += "AND ID_Empresa = " + Imposto.ID_Empresa + " ";

                if (Imposto.ID > 0)
                    sql += "AND ID = " + Imposto.ID + " ";

                if (Imposto.Descricao != string.Empty)
                    sql += "AND Descricao LIKE '" + Imposto.Descricao + "%' ";

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

        public DataTable Busca_Tributacao()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "TE.Descricao AS TipoEmissao, ";
                sql += "T.ID, T.ID_Imposto, T.Tipo_NF, T.CFOP, T.CST, T.Origem, T.ModalidadeBC, T.AliquotaICMS, T.PercentualReducao, T.ModalidadeBCST, T.AliquotaICMSST, T.PercentualReducaoST, ";
                sql += "T.MargemVAdicionado, T.vICMSDeson, T.vICMSOp, T.pDif, T.vICMSDif, T.CSTPIS, T.AliquotaPIS, T.AliquotaPISST, T.CSTCOFINS, T.AliquotaCOFINS, T.AliquotaCOFINSST, T.CSTIPI, T.AliquotaIPI, T.Cod_Enquadramento ";
                sql += "FROM ";
                sql += "Imposto_Tributacao AS T ";
                sql += "INNER JOIN NF_TipoEmissao AS TE ON T.Tipo_NF = TE.ID ";
                sql += "WHERE ";
                sql += "NOT T.ID IS NULL ";

                if (Imposto.ID > 0)
                    sql += "AND T.ID_Imposto = " + Imposto.ID + " ";

                if (Imposto.lst_Tributacao != null &&
                    Imposto.lst_Tributacao[0].ID > 0)
                    sql += "AND T.ID = " + Imposto.lst_Tributacao[0].ID + " ";

                sql += "ORDER BY TE.Descricao, T.CFOP ";

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

        public DataTable Busca_UF()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                sql = "SELECT ";
                sql += "IUF.ID_UF, UF.Sigla ";
                sql += "FROM ";
                sql += "Imposto_UF AS IUF ";
                sql += "INNER JOIN UF ON IUF.ID_UF = UF.ID_UF ";
                sql += "WHERE ";
                sql += "NOT IUF.ID_Tributacao IS NULL ";
                sql += "AND IUF.ID_Tributacao = " + Imposto.ID_Tributacao + " ";

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
                
                sql = "SELECT ";
                sql += "ID ";
                sql += "FROM ";
                sql += "Imposto_Tributacao ";
                sql += "WHERE ";
                sql += "ID_Imposto = " + Imposto.ID + " ";

                string lst_ID = string.Empty;
                DataTable _DT = new DataTable();

                _DT = conexao.Consulta(sql);

                conexao.Begin_Conexao();

                if (_DT.Rows.Count > 0)
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                        lst_ID += _DT.Rows[i]["ID"].ToString() + ", ";

                    sql = "DELETE FROM ";
                    sql += "Imposto_UF ";
                    sql += "WHERE ";
                    sql += "ID_Tributacao IN (" + lst_ID.Substring(0, lst_ID.Length - 2) + ") ";
                    cmd.CommandText = sql;
                    conexao.Executa_Comando(cmd);
                }

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Imposto_Tributacao ";
                sql += "WHERE ";
                sql += "ID_Imposto = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imposto.ID);
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Imposto ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imposto.ID);
                conexao.Executa_Comando(cmd);

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

        public void Exclui_Tributacao()
        {
            conexao = new Conexao();

            cmd = new SqlCommand();
            try
            {
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                sql = "DELETE FROM ";
                sql += "Imposto_UF ";
                sql += "WHERE ";
                sql += "ID_Tributacao = " + Imposto.ID_Tributacao + " ";
                cmd.CommandText = sql;
                conexao.Executa_Comando(cmd);

                cmd = new SqlCommand();
                sql = "DELETE FROM ";
                sql += "Imposto_Tributacao ";
                sql += "WHERE ";
                sql += "ID = @ID ";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ID", Imposto.ID_Tributacao);
                conexao.Executa_Comando(cmd);

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
    }
}
