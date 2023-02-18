using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_ManutencaoBD : Sistema.UI.UI_Modelo
    {
        public UI_ManutencaoBD()
        {
            InitializeComponent();
        }
        #region VARIAVEIS DE CLASSE
        BLL_Sistema BLL_Sistema;
        #endregion

        #region ESTRUTURA
        DTO_Sistema Sistema;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "MANUTENÇÃO BANCO DE DADOS";

            tabctl.TabPages.Remove(TabPage2);
            tabctl.SelectedTab = TabPage1;

            bt_Imprime.Visible = false;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Proximo.Visible = false;
            bt_Anterior.Visible = false;
            bt_Edita.Visible = false;

            txt_Descricao.Enabled = false;
        }

        private void Verifica_Senha(string _Senha)
        {
            if (_Senha == Parametro_Sistema.Acesso_Config)
            {
                BLL_Sistema = new BLL_Sistema();
                Sistema = new DTO_Sistema();
                DataTable _DT = new DataTable();

                Sistema.TipoComando = 2;

                _DT = BLL_Sistema.Consulta(Sistema);
                dg_Tabelas.DataSource = _DT;

                txt_Descricao.Enabled = true;
                txt_Acesso.Clear();
            }
        }

        private void Comando()
        {
            BLL_Sistema = new BLL_Sistema();
            Sistema = new DTO_Sistema();

            DialogResult msgbox = MessageBox.Show("Confirma comando?\n\n(" + txt_Descricao.SelectedText +")", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            Sistema.ComandoSQL = txt_Descricao.SelectedText;
            try
            {
                if (txt_Descricao.SelectedText.IndexOf("INSERT") != -1)
                {
                    Sistema.TipoComando = 2;
                    txt_ID.Text = Convert.ToString(BLL_Sistema.Executa_Comando(Sistema));
                    return;
                }

                if (txt_Descricao.SelectedText.ToUpper().IndexOf("SELECT") != -1)
                {
                    Sistema.TipoComando = 1;
                    DataTable _DT = new DataTable();

                    _DT = BLL_Sistema.Consulta(Sistema);
                    string Tabela = tab_Consulta.SelectedTab.ToString();
                    switch (Tabela)
                    {
                        case "TabPage: {CONSULTA 1}":
                            dg_Consulta1.DataSource = _DT;
                            break;
                        case "TabPage: {CONSULTA 2}":
                            dg_Consulta2.DataSource = _DT;
                            break;
                        case "TabPage: {CONSULTA 3}":
                            dg_Consulta3.DataSource = _DT;
                            break;
                        case "TabPage: {CONSULTA 4}":
                            dg_Consulta4.DataSource = _DT;
                            break;
                        case "TabPage: {CONSULTA 5}":
                            dg_Consulta5.DataSource = _DT;
                            break;
                    }
                    return;
                }
                if (txt_Descricao.SelectedText.ToUpper().IndexOf("UPDATE") != -1 ||
                    txt_Descricao.SelectedText.ToUpper().IndexOf("DELETE") != -1)
                    if (txt_Descricao.SelectedText.ToUpper().IndexOf("WHERE") == -1)
                    {
                        DialogResult _msgbox = MessageBox.Show("Executar UPDATE/DELETE sem WHERE?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (_msgbox == DialogResult.No)
                            return;
                    }

       

                Sistema.TipoComando = 1;
                txt_ID.Text = Convert.ToString(BLL_Sistema.Executa_Comando(Sistema));
                return;
            }
            catch (Exception ex)
            {
                txt_ID.Text = ex.ToString();
            }
        }
        #endregion

        #region FORM
        private void UI_ManutencaoBD_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_ManutencaoBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Comando();
        }
        #endregion

        #region TEXTBOX
        private void txt_Acesso_Leave(object sender, EventArgs e)
        {
            Verifica_Senha(txt_Acesso.Text);
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaPessoa_Click(object sender, EventArgs e)
        {
            Comando();
        }
        #endregion

        #region TEXTBOX
        private void dg_Tabelas_DoubleClick(object sender, EventArgs e)
        {
            txt_Descricao.Text = txt_Descricao.Text + Environment.NewLine;
            txt_Descricao.Text = txt_Descricao.Text + "\n\nSELECT * FROM " + dg_Tabelas.Rows[dg_Tabelas.CurrentRow.Index].Cells[0].Value;
        }
        #endregion
    }
}
