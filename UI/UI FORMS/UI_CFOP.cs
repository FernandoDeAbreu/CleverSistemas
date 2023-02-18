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
    public partial class UI_CFOP : Sistema.UI.UI_Modelo
    {
        public UI_CFOP()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_CFOP BLL_CFOP;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ESTRUTURA
        DTO_CFOP CFOP;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE CFOP";

            DG.AutoGenerateColumns = false;

            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_CFOP = new DataGridViewTextBoxColumn();
            col_CFOP.DataPropertyName = "CFOP";
            col_CFOP.HeaderText = "CFOP";
            col_CFOP.Width = 70;
            DG.Columns.Add(col_CFOP);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "USUÁRIO";
            col_Descricao.Width = 400;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_CFOP = new BLL_CFOP();
                CFOP = new DTO_CFOP();

                CFOP.ID = util_dados.Verifica_int(txt_ID.Text);
                CFOP.CFOP = txt_CFOP.Text;
                CFOP.Descricao = txt_Descricao.Text;
                CFOP.Ajuda = txt_Ajuda.Text;

                obj = BLL_CFOP.Grava(CFOP);

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
                BLL_CFOP = new BLL_CFOP();
                CFOP = new DTO_CFOP();

                CFOP.CFOP = txt_CFOPP.Text;
                CFOP.Descricao = txt_DescricaoP.Text;

                DataTable _DT = new DataTable();
                _DT = BLL_CFOP.Busca(CFOP);
                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                tabctl.SelectedTab = TabPage2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
        }

        public override void Excluir()
        {
            try
            {
                BLL_CFOP = new BLL_CFOP();
                CFOP = new DTO_CFOP();

                CFOP.ID = util_dados.Verifica_int(txt_ID.Text);
                CFOP.CFOP = txt_CFOP.Text;

                BLL_CFOP.Exclui(CFOP);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Novo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_CFOP_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_CFOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Config(StatusForm.Consulta);
        }
    }
}
