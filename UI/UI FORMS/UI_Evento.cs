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
    public partial class UI_Evento : Sistema.UI.UI_Modelo
    {
        public UI_Evento()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Evento BLL_Evento;
        #endregion

        #region ESTRUTURA
        DTO_Evento Evento;
        #endregion;

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE EVENTO";

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


            DataGridViewTextBoxColumn col_Referencia = new DataGridViewTextBoxColumn();
            col_Referencia.DataPropertyName = "Referencia";
            col_Referencia.HeaderText = "REFERÊNCIA";
            col_Referencia.Width = 200;
            DG.Columns.Add(col_Referencia);
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Evento = new BLL_Evento();
                Evento = new DTO_Evento();

                Evento.ID = util_dados.Verifica_int(txt_ID.Text);
                Evento.Descricao = txt_Descricao.Text;
                Evento.Vencimento = Convert.ToBoolean(ck_Vencimento.Checked);
                Evento.Desconto = Convert.ToBoolean(ck_Desconto.Checked);
                Evento.Referencia = txt_Referencia.Text;

                obj = BLL_Evento.Grava(Evento);

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
                BLL_Evento = new BLL_Evento();
                Evento = new DTO_Evento();

                Evento.ID = util_dados.Verifica_int(txt_ID_P.Text);
                Evento.Descricao = txt_Descricao_P.Text;
                Evento.Referencia = txt_Referencia_P.Text;

                DataTable _DT = new DataTable();
                _DT = BLL_Evento.Busca(Evento);

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

                BLL_Evento = new BLL_Evento();
                Evento = new DTO_Evento();

                Evento.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Evento.Exclui(Evento);

                Pesquisa();

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            txt_Descricao.Focus();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Evento_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Evento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region CHECKBOX
        private void ck_Vencimento_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Vencimento.Checked == true)
                ck_Desconto.Checked = false;
            else
                ck_Desconto.Checked = true;
        }

        private void ck_Desconto_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Desconto.Checked == true)
                ck_Vencimento.Checked = false;
            else
                ck_Vencimento.Checked = true;
        }



        #endregion        
    }
}
