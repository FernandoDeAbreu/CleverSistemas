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
    public partial class UI_Pagamento : Sistema.UI.UI_Modelo
    {
        public UI_Pagamento()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pagamento BLL_Pagamento;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ESTRUTURA
        DTO_Pagamento Pagamento;
        DTO_Parcelamento Parcelamento;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "TIPO DE PAGAMENTO";

            bt_Proximo.Visible = true;
            bt_Proximo.Enabled = true;

            bt_Anterior.Visible = true;
            bt_Anterior.Enabled = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "PAGAMENTO";
            col_Descricao.Width = 250;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Descricao_Tipo = new DataGridViewTextBoxColumn();
            col_Descricao_Tipo.DataPropertyName = "Descricao_Tipo";
            col_Descricao_Tipo.HeaderText = "TIPO DE PAGAMENTO";
            col_Descricao_Tipo.Width = 250;
            col_Descricao_Tipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao_Tipo);

            dg_Parcelamento.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Parcelamento.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

            CarregaCB();
        }

        private void CarregaCB()
        {
            List<string> Tipo = new List<string>();
            Tipo.Add("BOLETO");
            Tipo.Add("CARTÃO CRÉDITO/DÉBITO");
            Tipo.Add("CHEQUE");
            Tipo.Add("DINHEIRO");
            Tipo.Add("CARTEIRA");
            Tipo.Add("OUTROS");

            DataTable _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(1, Tipo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo);

            Tipo = new List<string>();
            Tipo.Add("TODOS");
            Tipo.Add("BOLETO");
            Tipo.Add("CARTÃO CRÉDITO/DÉBITO");
            Tipo.Add("CHEQUE");
            Tipo.Add("DINHEIRO");
            Tipo.Add("CARTEIRA");
            Tipo.Add("OUTROS");
            _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(0, Tipo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoP);
        }

        private void Carrega_Parcelamento()
        {
            try
            {
                dg_Parcelamento.Rows.Clear();

                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();

                Pagamento.ID = util_dados.Verifica_int(txt_ID.Text);

                DataTable _DT = new DataTable();
                _DT = BLL_Pagamento.Busca_Parc(Pagamento);

                if (_DT.Rows.Count == 0)
                    return;

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    dg_Parcelamento.Rows.Add();
                    dg_Parcelamento.Rows[i].Cells["col_Personalizado"].Value = _DT.Rows[i]["Personalizado"];
                    dg_Parcelamento.Rows[i].Cells["col_Parcela"].Value = _DT.Rows[i]["Parcelamento"];
                    dg_Parcelamento.Rows[i].Cells["col_ID_Parc"].Value = _DT.Rows[i]["ID"];
                    dg_Parcelamento.Rows[i].Cells["col_Periodo"].Value = _DT.Rows[i]["Periodo"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private List<DTO_Parcelamento> Carrega_lst_Parcelamento()
        {
            List<DTO_Parcelamento> aux = new List<DTO_Parcelamento>();

            for (int i = 0; i <= dg_Parcelamento.Rows.Count - 1; i++)
            {
                Parcelamento = new DTO_Parcelamento();

                Parcelamento.ID = Convert.ToInt32(dg_Parcelamento.Rows[i].Cells["col_ID_Parc"].Value);
                Parcelamento.Personalizado = Convert.ToBoolean(dg_Parcelamento.Rows[i].Cells["col_Personalizado"].Value);
                Parcelamento.Parcelamento = dg_Parcelamento.Rows[i].Cells["col_Parcela"].Value.ToString();
                Parcelamento.Periodo = Convert.ToInt32(dg_Parcelamento.Rows[i].Cells["col_Periodo"].Value);
                aux.Add(Parcelamento);
            }

            return aux;
        }

        private void Limpa_Campo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Lancamento);
            util_dados.LimpaCampos(this, gb_Parcelamento);

            txt_Porc_Custo.Text = "0,00";
            txt_ParcelaMinima.Text = "1";
            txt_ParcelaMaxima.Text = "1";
            txt_Periodo.Text = "30";
            txt_Dia_Lancamento.Text = "0";

            ck_Personalizado.Checked = false;

            dg_Parcelamento.Rows.Clear();
        }

        private void Limpa_Campo_Parc()
        {
            util_dados.LimpaCampos(this, gb_Parcelamento);

            txt_ParcelaMinima.Text = "1";
            txt_ParcelaMaxima.Text = "1";
            txt_Periodo.Text = "30";

            ck_Personalizado.Checked = false;
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();

                Pagamento.ID = util_dados.Verifica_int(txt_ID.Text);
                Pagamento.Descricao = txt_Descricao.Text;
                Pagamento.Tipo = Convert.ToInt32(cb_Tipo.SelectedValue);
                Pagamento.Porc_Custo = Convert.ToDouble(txt_Porc_Custo.Text);
                Pagamento.Recebimento = ck_Recebimento.Checked;
                Pagamento.Pagamento = ck_Pagamento.Checked;
                Pagamento.Dia_Lancamento = util_dados.Verifica_int(txt_Dia_Lancamento.Text);

                Pagamento.Parcelamento = new List<DTO_Parcelamento>();
                Pagamento.Parcelamento = Carrega_lst_Parcelamento();

                obj = BLL_Pagamento.Grava(Pagamento);

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
                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();

                Pagamento.ID = util_dados.Verifica_int(txt_IDP.Text);
                Pagamento.Descricao = txt_DescricaoP.Text;
                Pagamento.Tipo = Convert.ToInt32(cb_TipoP.SelectedValue);

                DataTable _DT = new DataTable();

                _DT = BLL_Pagamento.Busca(Pagamento);
                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                util_dados.CarregaCampo(this, _DT, gb_Lancamento);
                util_dados.CarregaCampo(this, _DT, gb_Parcelamento);
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

                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();

                Pagamento.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Pagamento.Exclui(Pagamento);
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

            txt_Descricao.Focus();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Pagamento_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Pagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Porc_Custo.Focused == true)
            {
                short KeyAscii = (short)(e.KeyChar);
                KeyAscii = (short)util_dados.NumDecimal(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Parcela.Focused == true)
            {
                short KeyAscii = (short)(e.KeyChar);
                KeyAscii = (short)util_dados.NumInteiro_Parc(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Dia_Lancamento.Focused == true)
            {
                short KeyAscii = (short)(e.KeyChar);
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Pagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
               tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region TEXTBOX
        private void txt_Porc_Custo_Leave(object sender, EventArgs e)
        {
            if (txt_Porc_Custo.Text == string.Empty)
                txt_Porc_Custo.Text = "0";

            txt_Porc_Custo.Text = util_dados.ConfigNumDecimal(txt_Porc_Custo.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) != 0)
            {
                Carrega_Parcelamento();

                Status = StatusForm.Consulta;
                Config_Botao();
            }
        }
        #endregion

        #region BUTTON
        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Limpa_Campo();
        }

        private void bt_Incluir_Click(object sender, EventArgs e)
        {
            int _index = 0;

            if (util_dados.Verifica_int(txt_ID_Parc.Text) == 0)
            {
                _index = dg_Parcelamento.Rows.Count;
                dg_Parcelamento.Rows.Add();
            }
            else
                for (int i = 0; i <= dg_Parcelamento.Rows.Count - 1; i++)
                    if (Convert.ToInt32(dg_Parcelamento.Rows[i].Cells["col_ID_Parc"].Value) == util_dados.Verifica_int(txt_ID_Parc.Text))
                        _index = i;

            dg_Parcelamento.Rows[_index].Cells["col_Personalizado"].Value = ck_Personalizado.Checked;
            dg_Parcelamento.Rows[_index].Cells["col_ID_Parc"].Value = util_dados.Verifica_int(txt_ID_Parc.Text);

            if (ck_Personalizado.Checked == true)
            {
                dg_Parcelamento.Rows[_index].Cells["col_Parcela"].Value = txt_Parcela.Text;
                dg_Parcelamento.Rows[_index].Cells["col_Periodo"].Value = 0;
            }
            else
            {
                dg_Parcelamento.Rows[_index].Cells["col_Parcela"].Value = txt_ParcelaMinima.Text + "-" + txt_ParcelaMaxima.Text;
                dg_Parcelamento.Rows[_index].Cells["col_Periodo"].Value = txt_Periodo.Text;
            }

            Limpa_Campo_Parc();
        }

        private void bt_Excluir_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            int _ID_Parc = util_dados.Verifica_int(dg_Parcelamento.Rows[dg_Parcelamento.CurrentRow.Index].Cells["col_ID_Parc"].Value.ToString());

            if (_ID_Parc > 0)
            {
                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();
                Parcelamento = new DTO_Parcelamento();
                Pagamento.Parcelamento = new List<DTO_Parcelamento>();

                Parcelamento.ID = _ID_Parc;

                Pagamento.Parcelamento.Add(Parcelamento);

                BLL_Pagamento.Exclui_Parc(Pagamento);
            }

            dg_Parcelamento.Rows.RemoveAt(dg_Parcelamento.CurrentRow.Index);

            Limpa_Campo_Parc();
        }

        private void bt_Editar_Click(object sender, EventArgs e)
        {
            int _index = dg_Parcelamento.CurrentRow.Index;

            txt_ID_Parc.Text = dg_Parcelamento.Rows[_index].Cells["col_ID_Parc"].Value.ToString();

            if (Convert.ToBoolean(dg_Parcelamento.Rows[_index].Cells["col_Personalizado"].Value) == true)
            {
                ck_Personalizado.Checked = true;
                txt_Parcela.Text = dg_Parcelamento.Rows[_index].Cells["col_Parcela"].Value.ToString();
            }
            else
            {
                ck_Personalizado.Checked = false;
                string[] Parcela = dg_Parcelamento.Rows[_index].Cells["col_Parcela"].Value.ToString().Split('-');

                txt_ParcelaMinima.Text = Parcela[0];
                txt_ParcelaMaxima.Text = Parcela[1];

                txt_Periodo.Text = dg_Parcelamento.Rows[_index].Cells["col_Periodo"].Value.ToString();
            }
        }
        #endregion

        #region CHECKBOX
        private void ck_Personalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Personalizado.Checked == true)
            {
                txt_ParcelaMinima.Enabled = false;
                txt_ParcelaMaxima.Enabled = false;
                txt_Periodo.Enabled = false;

                txt_Parcela.Enabled = true;
            }
            else
            {
                txt_ParcelaMinima.Enabled = true;
                txt_ParcelaMaxima.Enabled = true;
                txt_Periodo.Enabled = true;

                txt_Parcela.Enabled = false;
            }
        }
        #endregion           
    }
}
