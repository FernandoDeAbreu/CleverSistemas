using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI.Locacao
{
    public partial class frm_Locacao : Form
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);
        string ID_FLUXOCAIXA = "";

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;
        DataTable DTR_Empresa;
        DataTable DTPessoa;
        DateTime ValidaData;

        int print_Contrato;

        #endregion

        public frm_Locacao()
        {
            InitializeComponent();
        }

        #region GEOLOCALIZAÇÃO


        private bool VerificaNavegador()
        {
            int versaoNavegador;
            int RegVal;
            try
            {
                // obtem a versão instalada do IE
                using (WebBrowser Wb = new WebBrowser())
                {
                    versaoNavegador = Wb.Version.Major;
                }

                // define a versão do IE
                if (versaoNavegador >= 11)
                    RegVal = 11001;
                else if (versaoNavegador == 10)
                    RegVal = 10001;
                else if (versaoNavegador == 9)
                    RegVal = 9999;
                else if (versaoNavegador == 8)
                    RegVal = 8888;
                else
                    RegVal = 7000;

                // define a chave atual
                RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
                Key.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void dgv_ItensLocados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string street = "";
            SqlCommand cmd = new SqlCommand(
            " SELECT                   " +
            " E.ID_Endereco,           " +
            " E.Logradouro,            " +
            " E.NumeroEndereco,        " +
            " E.Bairro,                " +
            " E.ID_Municipio,          " +
            " M.Descricao,             " +
            " U.ID,                    " +
            " U.Sigla,                 " +
            " E.CEP                    " +
            "                          " +
            " FROM                     " +
            " PessoaEndereco E,        " +
            " Municipios     M,        " +
            " UF U                     " +
            " WHERE                    " +
            " E.ID_Municipio = M.ID AND" +
            " M.ID_UF = U.ID_UF   AND  E.ID_Endereco = " + dgv_ItensLocados.CurrentRow.Cells[9].Value.ToString(), sqlConn);

            sqlConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                street = dr["Logradouro"].ToString() + ", " + dr["NumeroEndereco"].ToString() + ", " + dr["ID_Municipio"].ToString() + ", " + dr["Sigla"].ToString();

                o++;
            }
            sqlConn.Close();


            if (VerificaNavegador())
            {

                try

                {
                    webBrowser1.AllowWebBrowserDrop = false;
                    webBrowser1.ScriptErrorsSuppressed = true;
                    webBrowser1.WebBrowserShortcutsEnabled = false;
                    webBrowser1.IsWebBrowserContextMenuEnabled = false;



                    StringBuilder queryAddress = new StringBuilder();

                    queryAddress.Append("http://maps.google.com/maps?q=");


                    queryAddress.Append(street + ',' + '+');


                    webBrowser1.Navigate(queryAddress.ToString());
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("O Naveador usado é Incompatível", "Aviso");

            }
        }




        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        private void consultarItensLocados()
        {
            dgv_ItensLocados.Rows.Clear();

               SqlCommand cmd = new SqlCommand(" SELECT                           " +
                                            " I.ID,                               " +
                                            " I.ID_Produto,                       " +
                                            " P.Descricao,                        " +
                                            " I.qtde,                             " +
                                            " I.dt_inicial,                       " +
                                            " I.dt_final,                         " +
                                            " I.vlr,                              " +
                                            " L.ID_Cliente,                       " +
                                            " C.Nome_Razao,                       " +
                                            " I.id_endereco,                      " +
                                            " E.Logradouro,                       " +
                                            " E.NumeroEndereco,                   " +
                                            " E.Bairro,                           " +
                                            " E.ID_Municipio,                     " +
                                            " M.Descricao Cidade                  " +
                                            "                                     " +
                                            " FROM                                " +
                                            " LocProduto_Itens I,                 " +
                                            " locProduto       L,                 " +
                                            " Produto          P,                 " +
                                            " PessoaEndereco   E,                 " +
                                            " Municipios       M,                 " +
                                            " Pessoa           C                  " +
                                            "                                     " +
                                            " WHERE                               " +
                                            " I.ID_LocProduto = L.ID AND          " +
                                            " I.id_endereco   = E.ID_Endereco AND " +
                                            " I.ID_Produto    = P.ID   AND        " +
                                            " E.ID_Municipio  = M.ID   AND        " +
                                            " L.ID_Cliente    = C.ID_Pessoa AND   " +
                                            " I.DT_DEVOLUCAO  IS NULL AND         " +
                                            " C.TipoPessoa    = 1                 ", sqlConn);
            sqlConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dgv_ItensLocados.Rows.Add();
                dgv_ItensLocados.Rows[o].Cells[0].Value = dr["ID"].ToString();
                dgv_ItensLocados.Rows[o].Cells[1].Value = dr["ID_Produto"].ToString();
                dgv_ItensLocados.Rows[o].Cells[2].Value = dr["Descricao"].ToString();
                dgv_ItensLocados.Rows[o].Cells[3].Value = dr["qtde"].ToString();
                dgv_ItensLocados.Rows[o].Cells[4].Value = Convert.ToDateTime(dr["dt_inicial"].ToString()).ToShortDateString();
                dgv_ItensLocados.Rows[o].Cells[5].Value = Convert.ToDateTime(dr["dt_final"].ToString()).ToShortDateString();
                dgv_ItensLocados.Rows[o].Cells[6].Value = Double.Parse(dr["vlr"].ToString()).ToString("N2");
                dgv_ItensLocados.Rows[o].Cells[7].Value = dr["ID_Cliente"].ToString();
                dgv_ItensLocados.Rows[o].Cells[8].Value = dr["Nome_Razao"].ToString();
                dgv_ItensLocados.Rows[o].Cells[9].Value = dr["id_endereco"].ToString();
                dgv_ItensLocados.Rows[o].Cells[10].Value = dr["Logradouro"].ToString() + ", " + dr["NumeroEndereco"].ToString() + ", " + dr["Bairro"].ToString() + ", " + dr["Cidade"].ToString();


                o++;
            }
            sqlConn.Close();

            for (int i = 0; i < dgv_ItensLocados.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dgv_ItensLocados.Rows[i].Cells[5].Value) < DateTime.Now)
                {
                    dgv_ItensLocados.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        private void retornaID_locProduto()
        {


            SqlCommand cmd = new SqlCommand("Select max(ID) ID from locProduto ", sqlConn);
            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {

                tbox_numcontrato.Text = dr["ID"].ToString();

                o++;

            }


            sqlConn.Close();
        }
        private void retornaID_FluxoCaixa()
        {

            SqlCommand cmd = new SqlCommand("SELECT MAX(ID) ID_FLUXOCAIXA FROM FLUXOCAIXA", sqlConn);

            sqlConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                ID_FLUXOCAIXA = dr["ID_FLUXOCAIXA"].ToString();

                o++;
            }
            sqlConn.Close();
        }
        private void consultarProduto()
        {
            SqlCommand cmd = new SqlCommand(
              " SELECT                 " +
              " P.ID,                  " +
              " P.Descricao,           " +
              " E.EstoqueAtual         " +
              " FROM                   " +
              " Produto_Servico P,     " +
              " Produto_Estoque E      " +
              " WHERE                  " +
              " P.ID = E.ID_Produto AND" +
              " E.ID_Grade = 1 AND Referencia = @Referencia", sqlConn);


            cmd.Parameters.Add(new SqlParameter("@Referencia", textBox4.Text));


            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {

                tbox_codProduto.Text = dr["ID"].ToString();
                tbox_Descricao.Text = dr["Descricao"].ToString();
                tbox_Disponivel.Text = dr["EstoqueAtual"].ToString();

                o++;

            }
            if (o == 0)
            {
                MessageBox.Show("Produto não encontrado.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_codProduto.Clear();
                tbox_Descricao.Clear();
            }
            sqlConn.Close();
        }
        private void retornarItenInserido()
        {
            dgv_itens_inseridos.Rows.Clear();
            SqlCommand cmd = new SqlCommand(" SELECT                              " +
                                        " I.ID,                               " +
                                        " I.ID_Produto,                       " +
                                        " P.Descricao,                        " +
                                        " I.qtde,                             " +
                                        " I.dt_inicial,                       " +
                                        " I.dt_final,                     " +
                                        " I.vlr,                              " +
                                        " L.ID_Cliente,                       " +
                                        " C.Nome_Razao,                       " +
                                        " I.id_endereco,                      " +
                                        " E.Logradouro,                       " +
                                        " E.NumeroEndereco,                   " +
                                        " E.Bairro,                           " +
                                        " E.ID_Municipio,                     " +
                                        " M.Descricao Cidade                  " +
                                        "                                     " +
                                        " FROM                                " +
                                        " LocProduto_Itens I,                 " +
                                        " locProduto       L,                 " +
                                        " Produto          P,                 " +
                                        " PessoaEndereco   E,                 " +
                                        " Municipios       M,                 " +
                                        " Pessoa           C                  " +
                                        "                                     " +
                                        " WHERE                               " +
                                        " I.ID_LocProduto = L.ID AND          " +
                                        " I.id_endereco   = E.ID_Endereco AND " +
                                        " I.ID_Produto    = P.ID   AND        " +
                                        " E.ID_Municipio  = M.ID   AND        " +
                                        " L.ID_Cliente    = C.ID_Pessoa AND   " +
                                        " I.DT_DEVOLUCAO  IS NULL AND   " +
                                        " C.TipoPessoa    = 1      AND  I.ID_LOCPRODUTO  = " + tbox_numcontrato.Text /*+ " AND I.ID_Produto = " + tbox_codProduto.Text*/, sqlConn);
            sqlConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dgv_itens_inseridos.Rows.Add();
                dgv_itens_inseridos.Rows[o].Cells[0].Value = dr["ID"].ToString();
                dgv_itens_inseridos.Rows[o].Cells[1].Value = dr["ID_Produto"].ToString();
                dgv_itens_inseridos.Rows[o].Cells[2].Value = dr["Descricao"].ToString();
                dgv_itens_inseridos.Rows[o].Cells[3].Value = dr["qtde"].ToString();
                dgv_itens_inseridos.Rows[o].Cells[4].Value = Convert.ToDateTime(dr["dt_inicial"].ToString()).ToShortDateString();
                dgv_itens_inseridos.Rows[o].Cells[5].Value = Convert.ToDateTime(dr["dt_final"].ToString()).ToShortDateString();
                dgv_itens_inseridos.Rows[o].Cells[6].Value = Double.Parse(dr["vlr"].ToString()).ToString("N2");
                dgv_itens_inseridos.Rows[o].Cells[7].Value = dr["ID_Cliente"].ToString();
                dgv_itens_inseridos.Rows[o].Cells[8].Value = dr["Nome_Razao"].ToString();
                dgv_itens_inseridos.Rows[o].Cells[9].Value = dr["id_endereco"].ToString();
                dgv_itens_inseridos.Rows[o].Cells[10].Value = dr["Logradouro"].ToString() + ", " + dr["NumeroEndereco"].ToString() + ", " + dr["Bairro"].ToString() + ", " + dr["Cidade"].ToString();


                o++;
            }
            calcularTotal();
            sqlConn.Close();
        }


        #region NOVO CONTRATO
        private void gravarLocProduto()
        {


            //definição do comando sql
            string sql = "INSERT INTO locProduto( " +
                                    "ID_Empresa, " +
                                    "ID_Cliente, " +
                                    "Dt_Emissao, " +
                                    "Dt_Locacao, " +
                                    "Dt_Entrega, " +
                                    "Dt_Retirada," +
                                    "ContratoExterno, " +
                                    "Observacao )" +
                                    " VALUES ( " +
                                    "@ID_Empresa, " +
                                    "@ID_Cliente, " +
                                    "@Dt_Emissao, " +
                                    "@Dt_Locacao, " +
                                    "@Dt_Entrega, " +
                                    "@Dt_Retirada," +
                                    "@ContratoExterno, " +
                                    "@Observacao )";

            try
            {
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("@ID_Empresa", 1));
                comando.Parameters.Add(new SqlParameter("@ID_Cliente", tbox_codClinte.Text));
                comando.Parameters.Add(new SqlParameter("@Dt_Emissao", tbox_dtemissao.Text));
                comando.Parameters.Add(new SqlParameter("@Dt_Locacao", tbox_dtinilocacao.Text));
                comando.Parameters.Add(new SqlParameter("@Dt_Entrega", tbox_dtentrega.Text));
                comando.Parameters.Add(new SqlParameter("@Dt_Retirada", tbox_dtretirada.Text));
                comando.Parameters.Add(new SqlParameter("@ContratoExterno", tbox_numContratoExterno.Text));
                comando.Parameters.Add(new SqlParameter("@Observacao", tbox_Obs.Text));
                sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();

                retornaID_locProduto();

            }
            catch
            {
                throw new Exception(util_msg.msg_DAL_Erro_Grava);
            }
            finally
            {

            }
        }
        private void gravarLocProduto_Itens()
        {
            //definição do comando sql
            for (int i = 0; i < dgv_itens_inseridos.RowCount; i++)
            {
                string sql = "INSERT INTO LocProduto_Itens( " +
                                    "  ID_LocProduto  " +
                                    " ,ID_Produto     " +
                                    " ,qtde           " +
                                    " ,dt_inicial     " +
                                    " ,dt_final   " +
                                    " ,vlr            " +
                                    " ,id_endereco )   " +
                                    " VALUES ( " +
                                    "  @ID_LocProduto  " +
                                    " ,@ID_Produto     " +
                                    " ,@qtde           " +
                                    " ,@dt_inicial     " +
                                    " ,@dt_final   " +
                                    " ,@vlr            " +
                                    " ,@id_endereco )   ";

                try
                {
                    SqlCommand comando = new SqlCommand(sql, sqlConn);
                    comando.Parameters.Add(new SqlParameter("@ID_LocProduto", Convert.ToInt32(tbox_numcontrato.Text)));
                    comando.Parameters.Add(new SqlParameter("@ID_Produto", Convert.ToInt32(tbox_codProduto.Text)));
                    comando.Parameters.Add(new SqlParameter("@qtde", Convert.ToDecimal(tbox_qdte.Text)));
                    comando.Parameters.Add(new SqlParameter("@dt_inicial", Convert.ToDateTime(tbox_dtini.Text)));
                    comando.Parameters.Add(new SqlParameter("@dt_final", Convert.ToDateTime(tbox_dtfim.Text)));
                    comando.Parameters.Add(new SqlParameter("@vlr", Convert.ToDecimal(tbox_valorLocacao.Text)));
                    comando.Parameters.Add(new SqlParameter("@id_endereco", Convert.ToInt32(tbox_codEnderecoCliente.Text)));

                    sqlConn.Open();
                    comando.ExecuteNonQuery();
                    sqlConn.Close();



                }
                catch
                {
                    throw new Exception(util_msg.msg_DAL_Erro_Grava);
                }
            }
           

        }
        private void gravarCReceber()
        {
            //definição do comando sql
            string sql = "INSERT INTO CRECEBER(    " +
                              "       ID_Empresa        " +
                              "      ,ID_Conta          " +
                              //  "      ,GrupoConta        " +
                              "      ,Situacao          " +
                              "      ,Documento         " +
                              "      ,Emissao           " +
                              "      ,Vencimento        " +
                              "      ,TipoPessoa        " +
                              "      ,ID_Pessoa         " +
                              "      ,Valor             " +
                              //  "      ,Parcelado         " +
                              "      ,QuantidadeParcela " +
                              "      ,Parcela           " +
                              "      ,Descricao         " +
                              "      ,DataBaixa         " +
                              "      ,Desconto          " +
                              "      ,Acrescimo         " +
                              //"      ,Caixa             " +
                              //"      ,ID_Pagamento      " +
                              //"      ,InformacaoBaixa   " +
                              "      ,Controle          " +
                              "      ,Boleto            " +
                              "      ,ID_Venda          " +
                              "      ,ID_PrevisaoPagto  " +
                              "      ,ID_OS             " +
                              "      ,ID_LocProduto)    " +
                              "  VALUES(                " +
                              "       @ID_Empresa       " +
                              "      ,@ID_Conta         " +
                              //  "      ,@GrupoConta       " +
                              "      ,@Situacao         " +
                              "      ,@Documento        " +
                              "      ,@Emissao          " +
                              "      ,@Vencimento       " +
                              "      ,@TipoPessoa       " +
                              "      ,@ID_Pessoa        " +
                              "      ,@Valor            " +
                              //  "      ,@Parcelado        " +
                              "      ,@QuantidadeParcela" +
                              "      ,@Parcela          " +
                              "      ,@Descricao        " +
                              "      ,@DataBaixa        " +
                              "      ,@Desconto         " +
                              "      ,@Acrescimo        " +
                              //"      ,@Caixa            " +
                              //"      ,@ID_Pagamento     " +
                              //"      ,@InformacaoBaixa  " +
                              "      ,@Controle         " +
                              "      ,@Boleto           " +
                              "      ,@ID_Venda         " +
                              "      ,@ID_PrevisaoPagto " +
                              "      ,@ID_OS            " +
                              "      ,@ID_LocProduto)   ";

            try
            {
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("@ID_Empresa", 1));
                comando.Parameters.Add(new SqlParameter("@ID_Conta", 43)); //locação de produtos
                                                                           // comando.Parameters.Add(new SqlParameter("@GrupoConta",        ""));
                comando.Parameters.Add(new SqlParameter("@Situacao", 1));  // aberto
                comando.Parameters.Add(new SqlParameter("@Documento", tbox_numcontrato.Text));
                comando.Parameters.Add(new SqlParameter("@Emissao", DateTime.Now));
                comando.Parameters.Add(new SqlParameter("@Vencimento", DateTime.Now));
                comando.Parameters.Add(new SqlParameter("@TipoPessoa", 1));
                comando.Parameters.Add(new SqlParameter("@ID_Pessoa", Convert.ToInt32(tbox_codClinte.Text)));
                comando.Parameters.Add(new SqlParameter("@Valor", Convert.ToDecimal(tbox_Total.Text)));
                //comando.Parameters.Add(new SqlParameter("@Parcelado",         ""));
                comando.Parameters.Add(new SqlParameter("@QuantidadeParcela", 1));
                comando.Parameters.Add(new SqlParameter("@Parcela", 1));
                comando.Parameters.Add(new SqlParameter("@Descricao", "LOCAÇÃO DE PRODUTOS Nº " + tbox_numcontrato.Text));
                comando.Parameters.Add(new SqlParameter("@DataBaixa", ""));
                comando.Parameters.Add(new SqlParameter("@Desconto", Convert.ToDecimal("0,00")));
                comando.Parameters.Add(new SqlParameter("@Acrescimo", Convert.ToDecimal("0,00")));
                //comando.Parameters.Add(new SqlParameter("@Caixa",             ""));
                //comando.Parameters.Add(new SqlParameter("@ID_Pagamento",      ""));
                //comando.Parameters.Add(new SqlParameter("@InformacaoBaixa",   ""));
                comando.Parameters.Add(new SqlParameter("@Controle", "0"));
                comando.Parameters.Add(new SqlParameter("@Boleto", "0"));
                comando.Parameters.Add(new SqlParameter("@ID_Venda", "0"));
                comando.Parameters.Add(new SqlParameter("@ID_PrevisaoPagto", 1));
                comando.Parameters.Add(new SqlParameter("@ID_OS", "0"));
                comando.Parameters.Add(new SqlParameter("@ID_LocProduto", Convert.ToInt32(tbox_numcontrato.Text)));


                sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();

                gravarFluxoCaixa();

            }
            catch
            {
                MessageBox.Show(util_msg.msg_DAL_Erro_Grava);
            }
            finally
            {

            }
        }
        private void gravarFluxoCaixa()
        {

            string sql = " INSERT INTO FLUXOCAIXA (" +
                                  "  ID_Empresa            " +
                                  " ,Emissao               " +
                                  " ,Caixa                 " +
                                  " ,Documento             " +
                                  " ,ID_Conta              " +
                                  // " ,GrupoConta            " +
                                  " ,Credito               " +
                                  " ,Debito                " +
                                  " ,Informacao            " +
                                  " ,Conciliado            " +
                                  " ,ID_Cheque             " +
                                  " ,ID_Pagamento          " +
                                  " ,Planejamento)         " +
                                  " VALUES (                " +
                                  "  @ID_Empresa           " +
                                  " ,@Emissao              " +
                                  " ,@Caixa                " +
                                  " ,@Documento            " +
                                  " ,@ID_Conta             " +
                                  // " ,@GrupoConta           " +
                                  " ,@Credito              " +
                                  " ,@Debito               " +
                                  " ,@Informacao           " +
                                  " ,@Conciliado           " +
                                  " ,@ID_Cheque            " +
                                  " ,@ID_Pagamento         " +
                                  " ,@Planejamento)        ";

            try
            {
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("@ID_Empresa", 1));
                comando.Parameters.Add(new SqlParameter("@Emissao", DateTime.Now));
                comando.Parameters.Add(new SqlParameter("@Caixa", 50));
                comando.Parameters.Add(new SqlParameter("@Documento", tbox_numcontrato.Text));
                comando.Parameters.Add(new SqlParameter("@ID_Conta", Convert.ToInt32(43))); //locação de produtos
                comando.Parameters.Add(new SqlParameter("@Credito", Convert.ToDecimal(tbox_Total.Text)));
                comando.Parameters.Add(new SqlParameter("@Debito", Convert.ToDecimal("0,00")));
                comando.Parameters.Add(new SqlParameter("@Informacao", "LOCAÇÃO DE PRODUTOS Nº " + tbox_numcontrato.Text));
                comando.Parameters.Add(new SqlParameter("@Conciliado", Convert.ToInt32(1)));
                comando.Parameters.Add(new SqlParameter("@ID_Cheque", Convert.ToInt32(0)));
                comando.Parameters.Add(new SqlParameter("@ID_Pagamento", Convert.ToInt32(1)));
                comando.Parameters.Add(new SqlParameter("@Planejamento", Convert.ToInt32(0)));

                sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();
                gravarFluxoCaixa_Controle();

            }
            catch
            {
                MessageBox.Show(util_msg.msg_DAL_Erro_Grava);
            }
            finally
            {

            }
        }
        private void gravarFluxoCaixa_Controle()
        {

            retornaID_FluxoCaixa();

            string sql = " INSERT INTO FLUXOCAIXA_CONTROLE (ID_FLUXOCAIXA, ID_CPAGAR, ID_CRECEBER) VALUES (@ID_FLUXOCAIXA, @ID_CPAGAR, @ID_CRECEBER)";


            try
            {
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("@ID_FLUXOCAIXA", ID_FLUXOCAIXA));
                comando.Parameters.Add(new SqlParameter("@ID_CPAGAR", Convert.ToInt32(0)));
                comando.Parameters.Add(new SqlParameter("@ID_CRECEBER", tbox_numcontrato.Text));

                sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();

            }
            catch
            {
                MessageBox.Show(util_msg.msg_DAL_Erro_Grava);
            }
            finally
            {

            }
        }
        private void atualizarEstoque()
        {
            //try
            //{

                for (int i = 0; i < dgv_itens_inseridos.RowCount; i++)
                {
                    string sql = "UPDATE PRODUTO_ESTOQUE SET ESTOQUEATUAL = (ESTOQUEATUAL - @ESTOQUEATUAL) WHERE ID_PRODUTO = @ID_PRODUTO ";

                    
                        SqlCommand comando = new SqlCommand(sql, sqlConn);
                        comando.Parameters.Add(new SqlParameter("@ID_PRODUTO",   dgv_itens_inseridos.Rows[i].Cells["ID_PRODUTO1"].Value.ToString()));
                        comando.Parameters.Add(new SqlParameter("@ESTOQUEATUAL", Convert.ToDecimal(dgv_itens_inseridos.Rows[i].Cells["QTDE1"].Value.ToString())));

                        sqlConn.Open();
                        comando.ExecuteNonQuery();
                        sqlConn.Close();

                  
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Ocorreu um erro ao atualizar estoque","Clever Sistema",MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        private void calcularTotal()
        {
            decimal total = 0;
            tbox_Total.Text = "0,00";
            for (int i = 0; i < dgv_itens_inseridos.Rows.Count; i++)
            {
                total = Convert.ToDecimal(dgv_itens_inseridos.Rows[i].Cells["VALOR1"].Value) + total;
                tbox_Total.Text = Convert.ToString(total);
            }
        }
        private void limparCampos()
        {
            
            tbox_codClinte.Text = "";
            tbox_nomeCliente.Clear();
            tbox_dtemissao.Value = DateTime.Now;
            tbox_dtinilocacao.Value = DateTime.Now;
            tbox_dtentrega.Value = DateTime.Now;
            tbox_dtretirada.Value = DateTime.Now;
            tbox_numContratoExterno.Clear();
            tbox_Obs.Clear();
            textBox4.Clear();
            tbox_codProduto.Clear();
            tbox_Descricao.Clear();
            tbox_Disponivel.Clear();
            tbox_qdte.Text = "1,00";
            tbox_dtini.Value = DateTime.Now;
            tbox_dtfim.Value = DateTime.Now;
            tbox_codEnderecoCliente.Clear();
            tbox_EnderecoCliente.Clear();
            tbox_valorLocacao.Clear();
            dgv_itens_inseridos.Rows.Clear();
            tbox_Total.Text = "0,00";
            tbox_numcontrato.Text = "000";
        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            int a;
            int b = Convert.ToInt32(dgv_itens_inseridos.CurrentRow.Cells["ID_PRODUTO1"].Value.ToString());

            for (int i = 0; i < dgv_itens_inseridos.RowCount; i++)
            {
                a = Convert.ToInt32(dgv_itens_inseridos.Rows[i].Cells["ID_PRODUTO1"].Value.ToString());

                if (a == b)
                {
                    dgv_itens_inseridos.Rows.RemoveAt(i);
                }
            }

            calcularTotal();
        }


        private void Visualizar()
        {

            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();

          rpt.Sql_Relatorio =  " SELECT           " +
            " I.ID,                               " +
            " I.ID_Produto,                       " +
            " P.Descricao,                        " +
            " I.qtde,                             " +
            " I.dt_inicial,                       " +
            " I.dt_final,                     " +
            " I.vlr,                              " +
            " L.ID_Cliente,                       " +
            " C.Nome_Razao,                       " +
            " I.id_endereco,                      " +
            " E.Logradouro,                       " +
            " E.NumeroEndereco,                   " +
            " E.Bairro,                           " +
            " E.ID_Municipio,                     " +
            " M.Descricao Cidade,                  " +
            " L.Observacao,                        " +
            " L.ContratoExterno                   " +
            " FROM                                " +
            " LocProduto_Itens I,                 " +
            " locProduto       L,                 " +
            " Produto          P,                 " +
            " PessoaEndereco   E,                 " +
            " Municipios       M,                 " +
            " Pessoa           C                  " +
            "                                     " +
            " WHERE                               " +
            " I.ID_LocProduto = L.ID AND          " +
            " I.id_endereco   = E.ID_Endereco AND " +
            " I.ID_Produto    = P.ID   AND        " +
            " E.ID_Municipio  = M.ID   AND        " +
            " L.ID_Cliente    = C.ID_Pessoa AND   " +
            " C.TipoPessoa    = 1      AND  I.ID_LOCPRODUTO  =  " + print_Contrato;

            rpt.Dataset_Relatorio = "DataSet_Itens_Locacao";
            string rpt_Nome = "rpt_ItensLocados.rdlc";


            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;
            rpt.rpt_Viewer.RefreshReport();
            rpt.Show();




            
        }


        #endregion
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            UI.UI_Pessoa_Consulta a = new UI_Pessoa_Consulta(this);
            a.rotina = "Locação de Equipamento";
            a.cb_TipoPessoa.Enabled = false;
            a.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
           
        }
        private void bt_Novo_Click(object sender, EventArgs e)
        {
            if (tbox_codClinte.Text == "")
            {
                MessageBox.Show("Favor informar Cliente", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_codClinte.Focus();
                return;
            }
            if (tbox_numContratoExterno.Text == "")
            {
                MessageBox.Show("Favor informar o Nº contrato", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_dtemissao.Focus();
                return;
            }

            gravarLocProduto();
            panel1.Enabled = false;
            bt_Grava.Enabled = true;
            bt_Novo.Enabled = false;

        }
        private void btn_Incluir_Click(object sender, EventArgs e)
        {
            if (tbox_codProduto.Text == "")
            {
                MessageBox.Show("Favor informar o produto.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_codProduto.Focus();
                return;
            }

            if (tbox_codEnderecoCliente.Text == "")
            {
                MessageBox.Show("Favor informar a Localização.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_codEnderecoCliente.Focus();
                return;
            }

            if (Convert.ToDecimal(tbox_valorLocacao.Text) <= 0)
            {
                MessageBox.Show("Valor informado memor ou igual a zero.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_valorLocacao.Focus();
                return;
            }
            if (Convert.ToDecimal(tbox_qdte.Text) <= 0)
            {
                MessageBox.Show("Quantidade informado memor ou igual a zero.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_qdte.Focus();
                return;
            }
            if (Convert.ToDecimal(tbox_Disponivel.Text) <= 0)
            {
                MessageBox.Show("Estoque disponivel memor ou igual a zero.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_qdte.Focus();
                return;
            }
            if (Convert.ToDecimal(tbox_qdte.Text) > Convert.ToDecimal(tbox_Disponivel.Text))
            {
                MessageBox.Show("Quantidade informado maior que estoque disponível", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToDateTime(tbox_dtini.Text).Date > Convert.ToDateTime(tbox_dtfim.Text).Date)
            {
                MessageBox.Show("Data inicial não pode ser maior que a data de devolução", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_dtini.Focus();
                return;
            }
            if (Convert.ToDateTime(tbox_dtfim.Text).Date < DateTime.Now.Date)
            {
                MessageBox.Show("Data de devolução não pode ser menor que data atual", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_dtfim.Focus();
                return;
            }
           

            for (int i = 0; i < dgv_itens_inseridos.Rows.Count; i++)
            {
                if (tbox_codProduto.Text == dgv_itens_inseridos.Rows[i].Cells["ID_PRODUTO1"].Value.ToString())
                {
                    MessageBox.Show("Item já incluso neste contrato.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
             }


            int o = dgv_itens_inseridos.RowCount;
            dgv_itens_inseridos.Rows.Add();
          
            dgv_itens_inseridos.Rows[o].Cells[1].Value = tbox_codProduto.Text;
            dgv_itens_inseridos.Rows[o].Cells[2].Value = tbox_Descricao.Text;
            dgv_itens_inseridos.Rows[o].Cells[3].Value = tbox_qdte.Text;
            dgv_itens_inseridos.Rows[o].Cells[4].Value = tbox_dtini.Text;
            dgv_itens_inseridos.Rows[o].Cells[5].Value = tbox_dtfim.Text;
            dgv_itens_inseridos.Rows[o].Cells[6].Value = tbox_valorLocacao.Text;
            dgv_itens_inseridos.Rows[o].Cells[7].Value = tbox_codClinte.Text;
            dgv_itens_inseridos.Rows[o].Cells[8].Value = tbox_nomeCliente.Text;
            dgv_itens_inseridos.Rows[o].Cells[9].Value = tbox_codEnderecoCliente.Text;
            dgv_itens_inseridos.Rows[o].Cells[10].Value = tbox_EnderecoCliente.Text;



            calcularTotal();

            //gravarLocProduto_Itens();
            //retornarItenInserido();



        }
        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            consultarProduto();

        }
        private void TextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                consultarProduto();
            }
        }
        private void btn_pesquisarEnderecoCliente_Click(object sender, EventArgs e)
        {
            frm_PesquisarEndereco a = new frm_PesquisarEndereco(this);
            a.codCliente = this.tbox_codClinte.Text;
            a.rotina = "LOCACAO";
            a.ShowDialog();
        }
        private void frm_Locacao_Load(object sender, EventArgs e)
        {
            consultarItensLocados();
           
        }
        private void tbox_valorLocacao_Leave(object sender, EventArgs e)
        {
            try
            {
                tbox_valorLocacao.Text = double.Parse(tbox_valorLocacao.Text).ToString("N2");
            }
            catch (Exception)
            {
                tbox_valorLocacao.Text = "0,00";


            }
        }
        private void tbox_qdte_Leave(object sender, EventArgs e)
        {
            try
            {
                tbox_qdte.Text = double.Parse(tbox_qdte.Text).ToString("N2");
            }
            catch (Exception)
            {
                tbox_qdte.Text = "0,00";


            }
        }
        private void bt_Grava_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o contrato de locação?","Clever Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gravarLocProduto();
                retornaID_locProduto();
                gravarLocProduto_Itens();
                atualizarEstoque();
                // gravarCReceber(); Desativado a pedido do Cliente //

                print_Contrato = Convert.ToInt32(tbox_numcontrato.Text);
                Visualizar();
                limparCampos();
            }

        }
        private void bt_Fecha_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //***** MANUTENÇÃO DE CONTRATO *************
        #region MANUTENÇÃO DE CONTRATO 

        private void itens_do_contrato()
        {
            dgv_itens_do_contrato.Rows.Clear();
            SqlCommand cmd = new SqlCommand(" SELECT                              " +
                                        " I.ID,                               " +
                                        " I.ID_Produto,                       " +
                                        " P.Descricao,                        " +
                                        " I.qtde,                             " +
                                        " I.dt_inicial,                       " +
                                        " I.dt_final,                     " +
                                        " I.vlr,                              " +
                                        " I.dt_devolucao,                     " +
                                        " L.ID_Cliente,                       " +
                                        " C.Nome_Razao,                       " +
                                        " I.id_endereco,                      " +
                                        " E.Logradouro,                       " +
                                        " E.NumeroEndereco,                   " +
                                        " E.Bairro,                           " +
                                        " E.ID_Municipio,                     " +
                                        " M.Descricao Cidade                  " +
                                        "                                     " +
                                        " FROM                                " +
                                        " LocProduto_Itens I,                 " +
                                        " locProduto       L,                 " +
                                        " Produto          P,                 " +
                                        " PessoaEndereco   E,                 " +
                                        " Municipios       M,                 " +
                                        " Pessoa           C                  " +
                                        "                                     " +
                                        " WHERE                               " +
                                        " I.ID_LocProduto = L.ID AND          " +
                                        " I.id_endereco   = E.ID_Endereco AND " +
                                        " I.ID_Produto    = P.ID   AND        " +
                                        " E.ID_Municipio  = M.ID   AND        " +
                                        " L.ID_Cliente    = C.ID_Pessoa AND   " +
                                        " C.TipoPessoa    = 1      AND  I.ID_LOCPRODUTO  = " + dgv_contratos.CurrentRow.Cells["NUMCONTRATO"].Value.ToString(), sqlConn);
            sqlConn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dgv_itens_do_contrato.Rows.Add();
                dgv_itens_do_contrato.Rows[o].Cells[0].Value = dr["ID"].ToString();
                dgv_itens_do_contrato.Rows[o].Cells[1].Value = dr["ID_Produto"].ToString();
                dgv_itens_do_contrato.Rows[o].Cells[2].Value = dr["Descricao"].ToString();
                dgv_itens_do_contrato.Rows[o].Cells[3].Value = dr["qtde"].ToString();
                dgv_itens_do_contrato.Rows[o].Cells[4].Value = Convert.ToDateTime(dr["dt_inicial"].ToString()).ToShortDateString();
                dgv_itens_do_contrato.Rows[o].Cells[5].Value = Convert.ToDateTime(dr["dt_final"].ToString()).ToShortDateString();
                try
                {
                    dgv_itens_do_contrato.Rows[o].Cells[6].Value = Convert.ToDateTime(dr["dt_devolucao"].ToString()).ToShortDateString();
                }
                catch (Exception)
                {

                }

                dgv_itens_do_contrato.Rows[o].Cells[7].Value = Double.Parse(dr["vlr"].ToString()).ToString("N2");
                dgv_itens_do_contrato.Rows[o].Cells[8].Value = dr["ID_Cliente"].ToString();
                dgv_itens_do_contrato.Rows[o].Cells[9].Value = dr["Nome_Razao"].ToString();
                dgv_itens_do_contrato.Rows[o].Cells[10].Value = dr["id_endereco"].ToString();
                dgv_itens_do_contrato.Rows[o].Cells[11].Value = dr["Logradouro"].ToString() + ", " + dr["NumeroEndereco"].ToString() + ", " + dr["Bairro"].ToString() + ", " + dr["Cidade"].ToString();


                o++;
            }
            sqlConn.Close();
        }

        private void bt_Pesquisa_Click(object sender, EventArgs e)
        {
            dgv_contratos.Rows.Clear();

            string codcliente = "";
            string contratoExterno = "";

            if (tbox_codCliente2.Text == "")
            {
                codcliente = " IS NOT NULL";
            }
            else
            {
                codcliente = " = '"  + tbox_codCliente2.Text + "'";
            }

            if (tbox_contatoExterno.Text == "")
            {
                contratoExterno = " IS NOT NULL";
            }
            else
            {
                contratoExterno = " = '" + tbox_contatoExterno.Text + "'";
            }

            SqlCommand cmd = new SqlCommand(
                      " SELECT                          "+
                      " L.ID,                           "+
                      " L.ID_Cliente,                   "+
                      " P.Nome_Razao,                   "+
                      " L.Dt_Emissao,                   "+
                      " L.ContratoExterno               "+
                      "                                 "+
                      " FROM                            "+
                      " LOCPRODUTO L,                   "+
                      " Pessoa     P                    "+
                      " WHERE                           "+
                      " L.ID_Cliente = P.ID_Pessoa AND  "+
                      " P.TipoPessoa = 1  AND    L.ID_Cliente  "  + codcliente +
                                        " AND L.ContratoExterno " + contratoExterno +
                                        " AND L.Dt_Emissao BETWEEN '" + tbox_dtiniEmissao.Text + "' AND '" + tbox_dtfimEmissao.Text + "'", sqlConn);

           // cmd.Parameters.Add(new SqlParameter("@Referencia", textBox4.Text));


            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dgv_contratos.Rows.Add();
                dgv_contratos.Rows[o].Cells["CODCLIENTE"].Value = dr["ID_Cliente"].ToString();
                dgv_contratos.Rows[o].Cells["CLIENTE"].Value = dr["Nome_Razao"].ToString();
                dgv_contratos.Rows[o].Cells["NUMCONTRATO"].Value = dr["ID"].ToString();
                dgv_contratos.Rows[o].Cells["CONTRATOEXTERNO"].Value = dr["ContratoExterno"].ToString();
                dgv_contratos.Rows[o].Cells["DTEMISSAO"].Value = Convert.ToDateTime(dr["Dt_Emissao"].ToString()).ToShortDateString();
               
                o++;

            }
            if (o == 0)
            {
                MessageBox.Show("Produto não encontrado.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_codProduto.Clear();
                tbox_Descricao.Clear();
            }
            sqlConn.Close();
        }

        private void tbox_pesquisarCliente2_Click(object sender, EventArgs e)
        {
            UI.UI_Pessoa_Consulta a = new UI_Pessoa_Consulta(this);
            a.rotina = "Locação de Equipamento 2";
            a.cb_TipoPessoa.Enabled = false;
            a.ShowDialog();
        }

        private void dgv_contratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            itens_do_contrato();
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_devolucao_Click(object sender, EventArgs e)
        {
               if (dgv_itens_do_contrato.CurrentRow.Cells["DTDEVOLUCAO"].Value == null)
                {
                    #region Atulalizar tabela LOCPRODUTO_ITENS

                    string sql = "UPDATE LOCPRODUTO_ITENS SET DT_DEVOLUCAO = @DT_DEVOLUCAO WHERE ID_LOCPRODUTO = @ID_LOCPRODUTO AND ID_PRODUTO = @ID_PRODUTO";

                    try
                    {
                        SqlCommand comando = new SqlCommand(sql, sqlConn);
                        comando.Parameters.Add(new SqlParameter("@DT_DEVOLUCAO", DateTime.Now.ToShortDateString()));
                        comando.Parameters.Add(new SqlParameter("@ID_LOCPRODUTO", dgv_contratos.CurrentRow.Cells["NUMCONTRATO"].Value.ToString()));
                        comando.Parameters.Add(new SqlParameter("@ID_PRODUTO", dgv_itens_do_contrato.CurrentRow.Cells["ID_PRODUTO2"].Value.ToString()));

                        sqlConn.Open();
                        comando.ExecuteNonQuery();
                        sqlConn.Close();

                        MessageBox.Show("Item devolvido com sucesso", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Ocerreu um erro ao devolver o item.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    finally
                    {

                    }
                    #endregion

                    #region Atualizar o estoque
                    string sql2 = "UPDATE PRODUTO_ESTOQUE SET ESTOQUEATUAL = (ESTOQUEATUAL + @ESTOQUEATUAL) WHERE ID_PRODUTO = @ID_PRODUTO ";

                    try
                    {
                        SqlCommand comando = new SqlCommand(sql2, sqlConn);
                        comando.Parameters.Add(new SqlParameter("@ID_PRODUTO", dgv_itens_do_contrato.CurrentRow.Cells["ID_PRODUTO2"].Value.ToString()));
                        comando.Parameters.Add(new SqlParameter("@ESTOQUEATUAL", Convert.ToDecimal(dgv_itens_do_contrato.CurrentRow.Cells["QTDE2"].Value.ToString())));

                        sqlConn.Open();
                        comando.ExecuteNonQuery();
                        sqlConn.Close();

                    }
                    catch
                    {


                    }
                itens_do_contrato();

                #endregion

            }
            else
                {
                    MessageBox.Show("Item já devolvido.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

        }

        private void Btn_imprimir_Click(object sender, EventArgs e)
        {

            print_Contrato = Convert.ToInt32(dgv_contratos.CurrentRow.Cells["NUMCONTRATO"].Value);
            Visualizar();
        }

        #endregion

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            
        }
        private void Btn_pesquisarProduto_Click(object sender, EventArgs e)
        {
            UI.UI_Produto_Consulta a = new UI_Produto_Consulta(this);
            a.rotina = "Locação";
            a.ShowDialog();
            consultarProduto();

        }

        private void Dgv_ItensLocados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                consultarItensLocados();
            }
        }

        private void Dgv_contratos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                itens_do_contrato();

            }
            if (e.KeyCode == Keys.Down)
            {
                itens_do_contrato();

            }
        }
    }

}
