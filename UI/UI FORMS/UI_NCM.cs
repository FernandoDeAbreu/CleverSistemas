using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_NCM : Sistema.UI.UI_Modelo
    {
        public UI_NCM()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_NCM BLL_NCM;
        BLL_Produto BLL_Produto;
        #endregion

        #region ESTRUTURA
        DTO_NCM NCM;
        DTO_Produto Produto;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE ALÍQUOTA DE IMPOSTO POR NCM";

            dg_Tabela.AutoGenerateColumns = false;
            dg_CEST.AutoGenerateColumns = false;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Novo.Visible = false;
            bt_Exclui.Visible = false;
            bt_Edita.Visible = false;
            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;
            bt_Pesquisa.Visible = false;

            bt_Grava.Text = "ATUALIZAR";
            tabctl.TabPages.Remove(TabPage2);
        }

        private void Carrega_Tabela(string _Arquivo)
        {
            try
            {
                dg_Tabela.DataSource = null;

                string _StringConexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _Arquivo + ";Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';";

                OleDbConnection _olecon = new OleDbConnection(_StringConexao);
                _olecon.Open();

                DataTable _Planilha = _olecon.GetSchema("Columns");

                string sql = "";
                sql += "SELECT DISTINCT codigo, ex, descricao, nacionalfederal, importadosfederal, estadual ";
                sql += "FROM [" + _Planilha.Rows[0]["TABLE_NAME"].ToString() + "] ";
                sql += "WHERE NOT codigo IS NULL ";
                sql += "AND tipo = 0 ";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, _olecon);

                DataTable DT = new DataTable();
                da.TableMappings.Add("Temporario", "Tab1");
                da.Fill(DT);

                _olecon.Close();

                if (DT.Rows.Count > 0)
                    dg_Tabela.DataSource = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Carrega_Tabela_CEST(string _Arquivo)
        {
            try
            {
                dg_CEST.DataSource = null;

                string _StringConexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _Arquivo + ";Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';";

                OleDbConnection _olecon = new OleDbConnection(_StringConexao);
                _olecon.Open();

                DataTable _Planilha = _olecon.GetSchema("Columns");

                string sql = "";
                sql += "SELECT DISTINCT NCM, CEST, Descricao ";
                sql += "FROM [" + _Planilha.Rows[0]["TABLE_NAME"].ToString() + "] ";
                sql += "WHERE NOT NCM IS NULL ";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, _olecon);

                DataTable DT = new DataTable();
                da.TableMappings.Add("Temporario", "Tab1");
                da.Fill(DT);

                _olecon.Close();

                if (DT.Rows.Count > 0)
                    dg_CEST.DataSource = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {

            DialogResult msgbox = MessageBox.Show(util_msg.msg_GravaAliqNCM, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            //GRAVA TABELA IBPT
            if (tabctl.SelectedTab == TabPage1)
            {

                BLL_NCM = new BLL_NCM();
                NCM = new DTO_NCM();

                BLL_NCM.Exclui(NCM);

                for (int i = 0; i <= dg_Tabela.Rows.Count - 1; i++)
                {
                    NCM = new DTO_NCM();
                    NCM.NCM = dg_Tabela.Rows[i].Cells["col_NCM"].Value.ToString();

                    if (dg_Tabela.Rows[i].Cells["col_Descricao"].Value.ToString().Length > 200)
                        NCM.Descricao = dg_Tabela.Rows[i].Cells["col_Descricao"].Value.ToString().Substring(0, 200);
                    else
                        NCM.Descricao = dg_Tabela.Rows[i].Cells["col_Descricao"].Value.ToString();

                    NCM.EX = util_dados.Verifica_int(dg_Tabela.Rows[i].Cells["col_EX"].Value.ToString());
                    NCM.AliqNacFederal = Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_AliqNacFederal"].Value.ToString().Replace(".", ","));
                    NCM.AliqImpFederal = Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_AliqImpFederal"].Value.ToString().Replace(".", ","));
                    NCM.AliqEstadual = Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_AliqEstadual"].Value.ToString().Replace(".", ","));

                    BLL_NCM.Grava(NCM);
                }
            }

            //GRAVA TABELA CEST
            if (tabctl.SelectedTab == tabPage3)
            {

                BLL_NCM = new BLL_NCM();
                NCM = new DTO_NCM();

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                BLL_NCM.Exclui_CEST(NCM);

                for (int i = 0; i <= dg_CEST.Rows.Count - 1; i++)
                {
                    NCM = new DTO_NCM();
                    NCM.NCM = dg_CEST.Rows[i].Cells["col_NCM_CEST"].Value.ToString().Replace(".", "").Replace(",", "").Replace(" ", "");
                    NCM.CEST = dg_CEST.Rows[i].Cells["col_CEST"].Value.ToString().Replace(".", "");

                    if (dg_CEST.Rows[i].Cells["col_DescricaoCEST"].Value.ToString().Length > 200)
                        NCM.Descricao = dg_CEST.Rows[i].Cells["col_DescricaoCEST"].Value.ToString().Substring(0, 200);
                    else
                        NCM.Descricao = dg_CEST.Rows[i].Cells["col_DescricaoCEST"].Value.ToString();

                    BLL_NCM.Grava_CEST(NCM);                 
                }

                BLL_NCM.Atualiza_NCM();
            }

            MessageBox.Show(util_msg.msg_Grava, this.Text);
        }
        #endregion

        #region FORM
        private void UI_NCM_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaTabela_Click(object sender, EventArgs e)
        {
            Pesquisa_Tabela.FileName = "";
            Pesquisa_Tabela.Title = "Selecione tabela atualizada IBPT";
            Pesquisa_Tabela.Filter = "Planilha Excel|*.xls;*.xlsx;*.xlsm";

            if (Pesquisa_Tabela.ShowDialog() == DialogResult.OK)
                if (Pesquisa_Tabela.CheckFileExists == true)
                    Carrega_Tabela(Pesquisa_Tabela.FileName);
        }
        #endregion

        private void bt_CEST_Click(object sender, EventArgs e)
        {
            Pesquisa_Tabela.FileName = "";
            Pesquisa_Tabela.Title = "Selecione tabela atualizada IBPT";
            Pesquisa_Tabela.Filter = "Planilha Excel|*.xls;*.xlsx;*.xlsm";

            if (Pesquisa_Tabela.ShowDialog() == DialogResult.OK)
                if (Pesquisa_Tabela.CheckFileExists == true)
                    Carrega_Tabela_CEST(Pesquisa_Tabela.FileName);
        }
    }
}
