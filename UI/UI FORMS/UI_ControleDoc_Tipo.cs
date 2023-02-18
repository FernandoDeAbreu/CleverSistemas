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
    public partial class UI_ControleDoc_Tipo : Sistema.UI.UI_Modelo
    {
        public UI_ControleDoc_Tipo()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_ControleDoc_Tipo BLL_ControleDoc_Tipo;
        BLL_Grupo BLL_Grupo;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ESTRUTURA
        DTO_ControleDoc_Tipo ControleDoc_Tipo;
        DTO_Grupo Grupo;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "DOCUMENTOS CONTÁBEIS";

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "DescricaoTipo";
            col_Descricao.HeaderText = "TIPO";
            col_Descricao.Width = 200;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Descricao_Tipo = new DataGridViewTextBoxColumn();
            col_Descricao_Tipo.DataPropertyName = "Descricao";
            col_Descricao_Tipo.HeaderText = "DOCUMENTO";
            col_Descricao_Tipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao_Tipo);

            CarregaCB();

            cb_ID_Tipo.Focus();
        }

        private void CarregaCB()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_DocumentoContabil);

            DataTable _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Tipo);
            cb_ID_Tipo.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_TipoP);
            cb_ID_TipoP.SelectedIndex = -1;
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            BLL_ControleDoc_Tipo = new BLL_ControleDoc_Tipo();
            ControleDoc_Tipo = new DTO_ControleDoc_Tipo();

            ControleDoc_Tipo.ID = util_dados.Verifica_int(txt_ID.Text);
            ControleDoc_Tipo.ID_Tipo = Convert.ToInt32(cb_ID_Tipo.SelectedValue);
            ControleDoc_Tipo.Descricao = txt_Descricao.Text;

            obj = BLL_ControleDoc_Tipo.Grava(ControleDoc_Tipo);

            try
            {
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
                BLL_ControleDoc_Tipo = new BLL_ControleDoc_Tipo();
                ControleDoc_Tipo = new DTO_ControleDoc_Tipo();

                ControleDoc_Tipo.ID_Tipo = Convert.ToInt32(cb_ID_TipoP.SelectedValue);
                ControleDoc_Tipo.Descricao = txt_DescricaoP.Text;

                DataTable _DT = new DataTable();
                _DT = BLL_ControleDoc_Tipo.Busca(ControleDoc_Tipo);
                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex, this.Text);
            }
        }

        public override void Excluir()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_ControleDoc_Tipo = new BLL_ControleDoc_Tipo();
                ControleDoc_Tipo = new DTO_ControleDoc_Tipo();

                ControleDoc_Tipo.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_ControleDoc_Tipo.Exclui(ControleDoc_Tipo);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);

            DG.DataSource = null;
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_ControleDoc_Tipo_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_ControleDoc_Tipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
               tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region BUTTON
        private void bt_Novo_Click(object sender, EventArgs e)
        {
            cb_ID_Tipo.SelectedIndex = 0;
        }
        #endregion

        #region COMBOBOX
        private void cb_ID_TipoP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_TipoP.SelectedIndex = -1;
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
