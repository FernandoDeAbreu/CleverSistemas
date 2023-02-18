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
    public partial class UI_NFe_TipoEmissao : Sistema.UI.UI_Modelo
    {
        public UI_NFe_TipoEmissao()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_NF_TipoEmissao BLL_NF_TipoEmissao;
        #endregion

        #region ESTRUTURA
        DTO_NF_TipoEmissao NF_TipoEmissao;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "TIPO DE EMISSÃO";

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Serie = new DataGridViewTextBoxColumn();
            col_Serie.DataPropertyName = "Serie";
            col_Serie.HeaderText = "SERIE";
            col_Serie.Width = 70;
            DG.Columns.Add(col_Serie);

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
                BLL_NF_TipoEmissao = new BLL_NF_TipoEmissao();
                NF_TipoEmissao = new DTO_NF_TipoEmissao();

                NF_TipoEmissao.ID = util_dados.Verifica_int(txt_ID.Text);
                NF_TipoEmissao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                NF_TipoEmissao.Descricao = txt_Descricao.Text;
                NF_TipoEmissao.Serie = Convert.ToInt32(txt_Serie.Text);

                obj = BLL_NF_TipoEmissao.Grava(NF_TipoEmissao);

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
                BLL_NF_TipoEmissao = new BLL_NF_TipoEmissao();
                NF_TipoEmissao = new DTO_NF_TipoEmissao();

                NF_TipoEmissao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                NF_TipoEmissao.Descricao = txt_DescricaoP.Text;
                NF_TipoEmissao.Serie = util_dados.Verifica_int(txt_SerieP.Text);

                DataTable _DT = new DataTable();

                _DT = BLL_NF_TipoEmissao.Busca(NF_TipoEmissao);
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

                BLL_NF_TipoEmissao = new BLL_NF_TipoEmissao();
                NF_TipoEmissao = new DTO_NF_TipoEmissao();

                NF_TipoEmissao.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_NF_TipoEmissao.Exclui(NF_TipoEmissao);

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
            DG.DataSource = null;

            tabctl.SelectedTab = TabPage1;

            util_dados.LimpaCampos(this, gb_Cadastro);

            txt_Serie.Text = "0";
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_NFe_TipoEmissao_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_NFe_TipoEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Serie.Focused == true ||
                txt_SerieP.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_NFe_TipoEmissao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Status = StatusForm.Consulta;
            Config_Botao();
        }
        #endregion
    }
}
