using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.UTIL;
using Sistema.DTO;
using Sistema.BLL;

namespace Sistema.UI
{
    public partial class UI_TabelaValor : Sistema.UI.UI_Modelo
    {
        public UI_TabelaValor()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_TabelaValor BLL_TabelaValor;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ESTRUTURA
        DTO_TabelaValor TabelaValor;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE TABELA DE VALOR";

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "DESCRIÇÃO";
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_TabelaValor = new BLL_TabelaValor();
                TabelaValor = new DTO_TabelaValor();

                TabelaValor.ID = util_dados.Verifica_int(txt_ID.Text);
                TabelaValor.Descricao = txt_Descricao.Text;
                TabelaValor.Margem = Convert.ToDouble(txt_Margem.Text);
                TabelaValor.CustoOperacional = Convert.ToDouble(txt_CustoOperacional.Text);

                obj = BLL_TabelaValor.Grava(TabelaValor);
                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Pesquisa()
        {
            try
            {
                DataTable _DT = new DataTable();

                BLL_TabelaValor = new BLL_TabelaValor();
                TabelaValor = new DTO_TabelaValor();

                TabelaValor.ID = util_dados.Verifica_int(txt_IDP.Text);
                TabelaValor.Descricao = txt_DescricaoP.Text;

                _DT = BLL_TabelaValor.Busca(TabelaValor);

                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_TabelaValor = new BLL_TabelaValor();
                TabelaValor = new DTO_TabelaValor();

                TabelaValor.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_TabelaValor.Exclui(TabelaValor);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            tabctl.SelectedTab = TabPage1;

            util_dados.LimpaCampos(this, gb_Cadastro);

            txt_Descricao.Focus();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region BUTTON
        private void bt_Novo_Click(object sender, EventArgs e)
        {
            txt_Margem.Text = "0,00";
            txt_CustoOperacional.Text = "0,00";
        }
        #endregion

        #region FORM
        private void UI_TabelaValor_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_TabelaValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Margem.Focused == true ||
                txt_CustoOperacional.Focused == true)
            {
                short KeyAscii = (short)(e.KeyChar);
                KeyAscii = (short)util_dados.NumDecimal(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_TabelaValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region TEXTBOX
        private void txt_Margem_Leave(object sender, EventArgs e)
        {
            txt_Margem.Text = util_dados.ConfigNumDecimal(txt_Margem.Text, 2);
        }

        private void txt_CustoOperacional_Leave(object sender, EventArgs e)
        {
            txt_CustoOperacional.Text = util_dados.ConfigNumDecimal(txt_CustoOperacional.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Config(StatusForm.Consulta);
        }
        #endregion
    }
}
