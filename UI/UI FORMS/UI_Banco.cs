using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Banco : Sistema.UI.UI_Modelo
    {
        public UI_Banco()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Banco BLL_Banco;
        BLL_Grupo BLL_Grupo;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ESTRUTURA
        DTO_Banco Banco;
        DTO_Grupo Grupo;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE BANCOS";

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            bt_Anterior.Enabled = true;
            bt_Proximo.Enabled = true;

            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Cod_Banco = new DataGridViewTextBoxColumn();
            col_Cod_Banco.DataPropertyName = "ID_Banco";
            col_Cod_Banco.HeaderText = "CÓD. BANCO";
            col_Cod_Banco.Width = 70;
            DG.Columns.Add(col_Cod_Banco);

            DataGridViewTextBoxColumn col_Agencia = new DataGridViewTextBoxColumn();
            col_Agencia.DataPropertyName = "Agencia";
            col_Agencia.HeaderText = "AGÊNCIA";
            col_Agencia.Width = 100;
            DG.Columns.Add(col_Agencia);

            DataGridViewTextBoxColumn col_Conta = new DataGridViewTextBoxColumn();
            col_Conta.DataPropertyName = "Conta";
            col_Conta.HeaderText = "CONTA";
            col_Conta.Width = 140;
            DG.Columns.Add(col_Conta);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "BANCO";
            col_Descricao.Width = 250;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);
        }

        private void CarregaCB()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);

            DataTable _DT = new DataTable();

            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Caixa);

            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_CaixaP);
            cb_ID_CaixaP.SelectedIndex = -1;
        }

        private void Limpa_Campo()
        {
            DG.DataSource = null;

            util_dados.LimpaCampos(this, gb_Cadastro);

            txt_Limite.Text = "0,00";
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Banco = new BLL_Banco();
                Banco = new DTO_Banco();

                Banco.ID = util_dados.Verifica_int(txt_ID.Text);
                Banco.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Banco.ID_Banco = util_dados.Verifica_int(txt_ID_Banco.Text);
                Banco.Descricao = txt_Descricao.Text;
                Banco.Agencia = txt_Agencia.Text;
                Banco.Conta = txt_Conta.Text;
                Banco.ID_Caixa = Convert.ToInt32(cb_ID_Caixa.SelectedValue);
                Banco.Limite = Convert.ToDouble(txt_Limite.Text);

                obj = BLL_Banco.Grava(Banco);

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
                BLL_Banco = new BLL_Banco();
                Banco = new DTO_Banco();

                Banco.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Banco.ID_Banco = util_dados.Verifica_int(txt_ID_BancoP.Text);
                Banco.Descricao = txt_DescricaoP.Text;
                Banco.Agencia = txt_AgenciaP.Text;
                Banco.Conta = txt_ContaP.Text;
                Banco.ID_Caixa = Convert.ToInt32(cb_ID_CaixaP.SelectedValue);

                DataTable _DT = new DataTable();
                _DT = BLL_Banco.Busca(Banco);
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

                BLL_Banco = new BLL_Banco();
                Banco = new DTO_Banco();

                Banco.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Banco.Exclui(Banco);

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
            Limpa_Campo();

            tabctl.SelectedTab = TabPage1;

            txt_ID_Banco.Focus();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Banco_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            CarregaCB();

        }

        private void UI_Banco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ID_Banco.Focused == true ||
               txt_ID_BancoP.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Agencia.Focused == true ||
                txt_AgenciaP.Focused == true ||
                txt_Conta.Focused == true ||
                txt_ContaP.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro_DOC(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Limite.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Banco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
               tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region TEXTBOX
        private void txt_Limite_Leave(object sender, EventArgs e)
        {
            if (txt_Limite.Text.Trim() == string.Empty)
                txt_Limite.Text = "0";

            txt_Limite.Text = util_dados.ConfigNumDecimal(txt_Limite.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Status = StatusForm.Consulta;
            Config_Botao();
        }
        #endregion

        #region BUTTON
        private void bt_Edita_Click(object sender, EventArgs e)
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion
    }
}