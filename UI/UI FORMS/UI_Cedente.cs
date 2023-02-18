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
    public partial class UI_Cedente : Sistema.UI.UI_Modelo
    {
        public UI_Cedente()
        {
            InitializeComponent();
        }
        #region VARIAVEIS DE CLASSE
        BLL_Banco BLL_Banco;
        BLL_Cedente BLL_Cedente;
        BLL_PlanoConta BLL_PlanoConta;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;

        string Conta;
        #endregion

        #region ESTRUTURA
        DTO_Banco Banco;
        DTO_Cedente Cedente;
        DTO_PlanoConta PlanoConta;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE CEDENTE";

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

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "BANCO";
            col_Descricao.Width = 250;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Cod_Cedente = new DataGridViewTextBoxColumn();
            col_Cod_Cedente.DataPropertyName = "Cod_Cedente";
            col_Cod_Cedente.HeaderText = "CÓD. CEDENTE";
            col_Cod_Cedente.Width = 150;
            DG.Columns.Add(col_Cod_Cedente);
        }

        private void CarregaConta()
        {
            BLL_PlanoConta = new BLL_PlanoConta();
            PlanoConta = new DTO_PlanoConta();

            DataTable _DT = new DataTable();

            int Nivel = util_dados.VerificaNivel(mk_Conta.Text);

            Conta = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);
            //Nivel 1

            if (Conta.Length == 2)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

                string Descricao = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                    if (i == _DT.Rows.Count - 1)
                        txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                }
                txt_DescricaoConta.Text = Descricao;

                if (_DT.Rows.Count == 0)
                {
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                return;
            }
            //Nivel 2
            if (Conta.Length == 4)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 1)
                {
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                    }

                    txt_DescricaoConta.Text = Descricao;
                }
                return;
            }
            //Nivel 3
            if (Conta.Length == 6)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 2)
                {
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                    }
                    txt_DescricaoConta.Text = Descricao;
                }
                return;
            }
            //Nivel 4
            if (Conta.Length == 8)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 3)
                {
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                    }
                    txt_DescricaoConta.Text = Descricao;
                }
                return;
            }

        }

        public void CarregaCB()
        {
            DataTable _DT = new DataTable();

            BLL_Banco = new BLL_Banco();
            Banco = new DTO_Banco();

            _DT = BLL_Banco.Busca(Banco);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Banco);

            List<string> _lst = new List<string> { "CNPJ", "CPF" };
            _DT = util_dados.CarregaComboDinamico(1, _lst);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo_Doc_Cedente);
            cb_Tipo_Doc_Cedente.SelectedIndex = 0;

            _DT = new DataTable();
            _lst = new List<string> { "1 - EMISSÃO SISTEMA", "2 - EMISSÃO BANCO" };
            _DT = util_dados.CarregaComboDinamico(1, _lst);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo_Emissao);
            cb_Tipo_Emissao.SelectedIndex = 0;
        }

        public void Limpa_Campos()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_GrupoNivel);

            txt_Juros.Text = "0,00";
            txt_Multa.Text = "0,00";
            txt_DiasMulta.Text = "0";
            txt_DiasJuros.Text = "0";
            txt_Cod_Protesto.Text = "0";
            txt_DiaProtesto.Text = "0";
            txt_Tipo_Cobranca.Text = "0";

            cb_Tipo_Doc_Cedente.SelectedIndex = 0;
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Cedente = new BLL_Cedente();
                Cedente = new DTO_Cedente();

                Cedente.ID = util_dados.Verifica_int(txt_ID.Text);
                Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Cedente.Descricao = txt_Descricao.Text;
                Cedente.Cod_Cedente = Convert.ToInt32(txt_Cod_Cedente.Text);
                Cedente.Carteira = Convert.ToInt32(txt_Carteira.Text);
                Cedente.Juros = Convert.ToDouble(txt_Juros.Text);
                Cedente.DiasJuros = Convert.ToInt32(txt_DiasJuros.Text);
                Cedente.Multa = Convert.ToDouble(txt_Multa.Text);
                Cedente.DiasMulta = Convert.ToInt32(txt_DiasMulta.Text);
                Cedente.Instrucao_1 = txt_Instrucao_1.Text;
                Cedente.Instrucao_2 = txt_Instrucao_2.Text;
                Cedente.ID_Banco = Convert.ToInt32(cb_ID_Banco.SelectedValue);
                Cedente.ID_Conta = Convert.ToInt32(txt_ID_Conta.Text);
                Cedente.Tipo_Doc_Cedente = Convert.ToInt32(cb_Tipo_Doc_Cedente.SelectedValue);
                Cedente.CNPJ_CPF_Cedente = txt_CNPJ_CPF_Cedente.Text;
                Cedente.Razao_Cedente = txt_Razao_Cedente.Text;
                Cedente.UtilizaTarifa = ck_UtilizaTarifa.Checked;
                Cedente.Tarifa = Convert.ToDouble(txt_Tarifa.Text);
                Cedente.Cod_Protesto = Convert.ToInt32(txt_Cod_Protesto.Text);
                Cedente.DiaProtesto = Convert.ToInt32(txt_DiaProtesto.Text);
                Cedente.Aceite = ck_Aceite.Checked;
                Cedente.Tipo_Emissao = Convert.ToInt32(cb_Tipo_Emissao.SelectedValue);
                Cedente.Tipo_Cobranca = util_dados.Verifica_int(txt_Tipo_Cobranca.Text);
                Cedente.Ativo = ck_Ativo.Checked;
                Cedente.Altera_Data = ck_Altera_Data.Checked;

                obj = BLL_Cedente.Grava(Cedente);

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
                BLL_Cedente = new BLL_Cedente();
                Cedente = new DTO_Cedente();

                Cedente.ID = util_dados.Verifica_int(txt_IDP.Text);
                Cedente.Descricao = txt_DescricaoP.Text;
                Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();
                _DT = BLL_Cedente.Busca(Cedente);

                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                util_dados.CarregaCampo(this, _DT, gb_GrupoNivel);
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

                BLL_Cedente = new BLL_Cedente();
                Cedente = new DTO_Cedente();

                Cedente.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Cedente.Exclui(Cedente);

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
            tabctl.SelectedTab = TabPage1;

            txt_Descricao.Focus();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Cedente_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            CarregaCB();
        }

        private void UI_Cedente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Cod_Cedente.Focused == true ||
                txt_Carteira.Focused == true ||
                txt_DiasJuros.Focused == true ||
                txt_DiasMulta.Focused == true ||
                txt_IDP.Focused == true ||
                txt_DiaProtesto.Focused == true ||
                txt_Cod_Protesto.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Juros.Focused == true ||
                txt_Multa.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Cedente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
               tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region TEXTBOX
        private void txt_Juros_Leave(object sender, EventArgs e)
        {
            if (txt_Juros.Text.Trim() == string.Empty)
                txt_Juros.Text = "0";

            txt_Juros.Text = util_dados.ConfigNumDecimal(txt_Juros.Text, 2);
        }

        private void txt_Multa_Leave(object sender, EventArgs e)
        {
            if (txt_Multa.Text.Trim() == string.Empty)
                txt_Multa.Text = "0";

            txt_Multa.Text = util_dados.ConfigNumDecimal(txt_Multa.Text, 2);
        }

        private void txt_Tarifa_Leave(object sender, EventArgs e)
        {
            if (txt_Tarifa.Text.Trim() == string.Empty)
                txt_Tarifa.Text = "0";

            txt_Tarifa.Text = util_dados.ConfigNumDecimal(txt_Tarifa.Text, 2);
        }

        private void txt_CNPJ_CPF_Cedente_Leave(object sender, EventArgs e)
        {
            string CNPJ_CPF = txt_CNPJ_CPF_Cedente.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace("0", "");

            if (CNPJ_CPF != string.Empty)
                if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPF_Cedente.Text) == false)
                {
                    MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);

                    txt_CNPJ_CPF_Cedente.Focus();
                    return;
                }
        }

        private void txt_CNPJ_CPF_Cedente_TextChanged(object sender, EventArgs e)
        {
            txt_CNPJ_CPF_Cedente.Text = util_dados.Digita_CNPJ_CPF(txt_CNPJ_CPF_Cedente.Text, Convert.ToInt32(cb_Tipo_Doc_Cedente.SelectedValue));
            SendKeys.Send("{end}");
        }

        private void txt_CNPJ_CPF_Cedente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && txt_CNPJ_CPF_Cedente.Text.Trim() != string.Empty)
            {
                if ((txt_CNPJ_CPF_Cedente.Text.Substring(txt_CNPJ_CPF_Cedente.Text.Length - 1) == ".") ||
                (txt_CNPJ_CPF_Cedente.Text.Substring(txt_CNPJ_CPF_Cedente.Text.Length - 1) == "-") ||
                (txt_CNPJ_CPF_Cedente.Text.Substring(txt_CNPJ_CPF_Cedente.Text.Length - 1) == "/"))
                    txt_CNPJ_CPF_Cedente.Text = txt_CNPJ_CPF_Cedente.Text.Substring(0, txt_CNPJ_CPF_Cedente.Text.Length - 2);
            }
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Status = StatusForm.Consulta;
            Config_Botao();
        }
        #endregion

        #region BUTTON
        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Limpa_Campos();
        }

        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_PlanoConta_Consulta frm = new UI_PlanoConta_Consulta();
            frm.ShowDialog();
            mk_Conta.Text = frm.Cod_Conta;
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region MASKEDBOX
        private void mk_Conta_TextChanged(object sender, EventArgs e)
        {
            CarregaConta();
        }
        #endregion

        #region COMBOBOX
        private void cb_Tipo_Doc_Cedente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_Tipo_Doc_Cedente.SelectedIndex == 0 && cb_Tipo_Doc_Cedente.Items.Count > 0)
                txt_CNPJ_CPF_Cedente.MaxLength = 18;

            if (cb_Tipo_Doc_Cedente.SelectedIndex == 1 && cb_Tipo_Doc_Cedente.Items.Count > 0)
                txt_CNPJ_CPF_Cedente.MaxLength = 14;
        }
        #endregion


    }
}