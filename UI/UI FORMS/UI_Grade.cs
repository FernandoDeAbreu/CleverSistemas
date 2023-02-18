using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.UTIL;
using Sistema.BLL;
using Sistema.DTO;

namespace Sistema.UI
{
    public partial class UI_Grade : Sistema.UI.UI_Modelo
    {
        public UI_Grade()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        BLL_Grade BLL_Grade;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;

        bool aux = false;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_Grade Grade;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE GRADE";

            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;
            bt_Proximo.Visible = false;
            bt_Anterior.Visible = false;

            tabctl.TabPages.Remove(TabPage2);

            dg_Grade.AutoGenerateColumns = false;

            Carrega_CB();
        }

        private void Carrega_CB()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Grade);
            DataTable _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
            cb_ID_Grupo.SelectedIndex = 0;
            aux = true;
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Grade = new BLL_Grade();
                Grade = new DTO_Grade();

                Grade.ID = util_dados.Verifica_int(txt_ID.Text);
                Grade.ID_Grupo = Convert.ToInt32(cb_ID_Grupo.SelectedValue);
                Grade.Descricao = txt_Descricao.Text;
                obj = BLL_Grade.Grava(Grade);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);

                    Pesquisa();
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
                BLL_Grade = new BLL_Grade();
                Grade = new DTO_Grade();

                Grade.ID_Grupo = Convert.ToInt32(cb_ID_Grupo.SelectedValue);

                DataTable _DT = new DataTable();
                _DT = BLL_Grade.Busca(Grade);
                dg_Grade.DataSource = _DT;
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

                BLL_Grade = new BLL_Grade();
                Grade = new DTO_Grade();

                Grade.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Grade.Exclui(Grade);

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
            dg_Grade.DataSource = null;
        }
        #endregion

        #region FORM
        private void UI_Grade_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Grade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region COMBOBOX
        private void cb_ID_Grupo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (aux == true &&
                    util_dados.Verifica_int(txt_ID.Text) > 0)
                    Pesquisa();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_Grade_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Grade.Rows.Count == 0)
            {
                txt_ID.Text = string.Empty;
                txt_Descricao.Text = string.Empty;
            }
        }
        #endregion
    }
}
