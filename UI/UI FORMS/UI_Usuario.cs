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
    public partial class UI_Usuario : Sistema.UI.UI_Modelo
    {
        public UI_Usuario()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Usuario Usuario;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            this.Text = "CADASTRO DE USUÁRIOS";

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "USUÁRIO";
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            CarregaCB();
        }

        private void CarregaCB()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();

            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedValue = 4;
        }

        private void CarregaPessoa(int _TipoPessoa)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = _TipoPessoa;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;
                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);

                if (util_dados.Verifica_int(txt_ID_Pessoa.Text) > 0)
                    cb_ID_Pessoa.SelectedValue = Convert.ToInt32(txt_ID_Pessoa.Text);
                else
                    cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Limpa_Campos()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);

            DG.DataSource = null;

            cb_TipoPessoa.SelectedValue = 4;

            ck_Situacao.Checked = true;
            ck_Cadastrado.Checked = true;
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

            CarregaPessoa(UI_Pessoa_Consulta.TipoPessoa);
            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                if (util_dados.Verifica_int(txt_ID.Text) > 0)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_Alteracao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;
                }

                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();

                Usuario.ID = util_dados.Verifica_int(txt_ID.Text);
                Usuario.MultiEmpresa = ck_MultiEmpresa.Checked;
                Usuario.Situacao = ck_Situacao.Checked;
                Usuario.ID_Empresa = (ck_MultiEmpresa.Checked == true ? 0 : Parametro_Empresa.ID_Empresa_Ativa);
                Usuario.Cadastrado = ck_Cadastrado.Checked;
                Usuario.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Usuario.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Usuario.Descricao = txt_Descricao.Text;
                Usuario.UsuarioSistema = ck_UsuarioSistema.Checked;
                Usuario.SenhaSistema = txt_SenhaSistema.Text;
                Usuario.UsuarioMobile = ck_UsuarioMobile.Checked;
                Usuario.SenhaMobile = txt_SenhaMobile.Text;

                obj = BLL_Usuario.Grava(Usuario);

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
                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();

                Usuario.ID = util_dados.Verifica_int(txt_IDP.Text);
                Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Usuario.Descricao = txt_DescricaoP.Text;

                DataTable _DT = new DataTable();

                _DT = BLL_Usuario.Busca(Usuario);
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

                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();

                Usuario.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Usuario.Exclui(Usuario);
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
            Limpa_Campos();

            ExibeRegistro();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                txt_SenhaSistema.UseSystemPasswordChar = false;
                txt_SenhaMobile.UseSystemPasswordChar = false;
            }

            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }

        private void UI_Usuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                txt_SenhaSistema.UseSystemPasswordChar = true;
                txt_SenhaMobile.UseSystemPasswordChar = true;
            }
        }

        private void UI_Usuario_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region CHECKBOX
        private void ck_Cadastrado_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Cadastrado.Checked == true)
            {
                lb_TipoPessoa.Enabled = true;
                lb_DescricaoPessoa.Enabled = true;
                cb_TipoPessoa.Enabled = true;
                cb_ID_Pessoa.Enabled = true;
            }
            else
            {
                lb_TipoPessoa.Enabled = false;
                lb_DescricaoPessoa.Enabled = false;
                cb_TipoPessoa.Enabled = false;
                cb_ID_Pessoa.Enabled = false;
            }
        }

        private void ck_UsuarioSistema_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_UsuarioSistema.Checked == true)
            {
                lb_senhaSistema.Enabled = true;
                txt_SenhaSistema.Enabled = true;
            }
            else
            {
                lb_senhaSistema.Enabled = false;
                txt_SenhaSistema.Enabled = false;
            }
        }

        private void ck_UsuarioMobile_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_UsuarioMobile.Checked == true)
            {
                lb_SenhaMobile.Enabled = true;
                txt_SenhaMobile.Enabled = true;
            }
            else
            {
                lb_SenhaMobile.Enabled = false;
                txt_SenhaMobile.Enabled = false;
            }
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_TipoPessoa.SelectedValue != null &&
                util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString()) > 0)
                CarregaPessoa(Convert.ToInt32(cb_TipoPessoa.SelectedValue));
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Status = StatusForm.Consulta;
            Config_Botao();
        }

        private void txt_TipoPessoa_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_TipoPessoa.Text) > 0)
                cb_TipoPessoa.SelectedValue = Convert.ToInt32(txt_TipoPessoa.Text);
            else
                cb_TipoPessoa.SelectedValue = 4; //TIPO FUNCIONARIO
        }

        private void txt_ID_Pessoa_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID_Pessoa.Text) > 0)
                cb_ID_Pessoa.SelectedValue = Convert.ToInt32(txt_ID_Pessoa.Text);
            else
                cb_ID_Pessoa.SelectedValue = -1;
        }
        #endregion
    }
}
