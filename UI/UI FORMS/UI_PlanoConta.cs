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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_PlanoConta : Sistema.UI.UI_Modelo
    {
        public UI_PlanoConta()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_PlanoConta BLL_PlanoConta;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSA
        int obj;
        string Nivel2;
        string Nivel3;
        string Conta;
        #endregion

        #region ESTRUTURA
        DTO_PlanoConta PlanoConta;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PLANO DE CONTAS";

            tabctl.TabPages.Remove(TabPage2);

            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            mk_Conta.Text = "00000000";

            dg_Nivel1.AutoGenerateColumns = false;
            dg_Nivel2.AutoGenerateColumns = false;
            dg_Nivel3.AutoGenerateColumns = false;
            dg_Nivel4.AutoGenerateColumns = false;

            CarregaConta(1);
        }

        private void CarregaConta(int _Nivel)
        {
            BLL_PlanoConta = new BLL_PlanoConta();
            PlanoConta = new DTO_PlanoConta();

            DataTable _DT_N1 = new DataTable();
            DataTable _DT_N2 = new DataTable();
            DataTable _DT_N3 = new DataTable();
            DataTable _DT_N4 = new DataTable();

            switch (_Nivel)
            {
                case 1:
                    PlanoConta.Nivel = 1;

                    _DT_N1 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel1.DataSource = _DT_N1;
                    break;
                case 2:
                    PlanoConta.Nivel = 2;
                    PlanoConta.Plano = txt_Nivel1.Text;

                    _DT_N2 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel2.DataSource = _DT_N2;
                    break;
                case 3:
                    PlanoConta.Nivel = 3;
                    PlanoConta.Plano = txt_Nivel1.Text + txt_Nivel2.Text;
                    _DT_N3 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel3.DataSource = _DT_N3;
                    break;
                case 4:
                    PlanoConta.Nivel = 4;
                    PlanoConta.Plano = txt_Nivel1.Text + txt_Nivel2.Text + txt_Nivel3.Text;
                    _DT_N4 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel4.DataSource = _DT_N4;
                    break;
            }
        }

        private void CarregaConta()
        {
            BLL_PlanoConta = new BLL_PlanoConta();
            PlanoConta = new DTO_PlanoConta();

            DataTable _DTConta = new DataTable();

            Conta = util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
            //Nivel 1
            if (Conta.Length == 2)
            {
                PlanoConta.Nivel = util_dados.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);
                //dg_ContaSuperior.DataSource = _DTConta;
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = util_dados.GravaCodigoDescritivo(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);

                if (_DTConta.Rows.Count == 0)
                {
                    //  dg_ContaSuperior.DataSource = null;
                    txt_ID.Text = "";
                    txt_Descricao.Text = "";
                    return;
                }

                util_dados.CarregaCampo(this, _DTConta, gb_Cadastro);
                return;
            }

            //Nivel 2
            if (Conta.Length == 4)
            {
                PlanoConta.Nivel = util_dados.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);
                //  dg_ContaSuperior.DataSource = _DTConta;
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = util_dados.GravaCodigoDescritivo(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);

                if (_DTConta.Rows.Count == 0)
                {
                    //     dg_ContaSuperior.DataSource = null;
                    txt_ID.Text = "";
                    txt_Descricao.Text = "";
                    return;
                }

                util_dados.CarregaCampo(this, _DTConta, gb_Cadastro);
                return;
            }

            //Nivel 3
            if (Conta.Length == 6)
            {
                PlanoConta.Nivel = util_dados.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);
                // dg_ContaSuperior.DataSource = _DTConta;
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = util_dados.GravaCodigoDescritivo(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);
                if (_DTConta.Rows.Count == 0)
                {
                    //    dg_ContaSuperior.DataSource = null;
                    txt_ID.Text = "";
                    txt_Descricao.Text = "";
                    return;
                }
                util_dados.CarregaCampo(this, _DTConta, gb_Cadastro);
                return;
            }

            //Nivel 4
            if (Conta.Length == 8)
            {
                PlanoConta.Nivel = util_dados.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);
                //  dg_ContaSuperior.DataSource = _DTConta;
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = util_dados.GravaCodigoDescritivo(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                _DTConta = BLL_PlanoConta.Busca(PlanoConta);
                if (_DTConta.Rows.Count == 0)
                {
                    //    dg_ContaSuperior.DataSource = null;
                    txt_ID.Text = "";
                    txt_Descricao.Text = "";
                    return;
                }
                util_dados.CarregaCampo(this, _DTConta, gb_Cadastro);
                return;
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_PlanoConta = new BLL_PlanoConta();
                PlanoConta = new DTO_PlanoConta();

                PlanoConta.ID = util_dados.Verifica_int(txt_ID.Text);
                PlanoConta.Nivel = util_dados.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = util_dados.GravaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
                PlanoConta.Codigo = util_dados.GravaCodigo(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoDescritivo = util_dados.GravaCodigoDescritivo(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text));
                PlanoConta.Descricao = txt_Descricao.Text;
                PlanoConta.Planejamento = Convert.ToBoolean(ck_Planejamento.Checked);

                obj = BLL_PlanoConta.Grava(PlanoConta);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }

                CarregaConta();
                CarregaConta(1);
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

                    mk_Conta.Text = txt_Nivel1.Text + txt_Nivel2.Text + txt_Nivel3.Text + txt_Nivel4.Text;

                BLL_PlanoConta = new BLL_PlanoConta();
                PlanoConta = new DTO_PlanoConta();

                PlanoConta.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_PlanoConta.Exclui(PlanoConta);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                CarregaConta();
                CarregaConta(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_PlanoConta.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT = new DataTable();

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_PlanoConta = new BLL_PlanoConta();

            _DT = BLL_PlanoConta.Busca_Relatorio();

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_PlanoConta = new ReportDataSource("ds_PlanoConta", _DT);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_PlanoConta);

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_PlanoConta.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

            rpt.ReportPath = Caminhorpt;

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT = new DataTable();

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_PlanoConta = new BLL_PlanoConta();

            _DT = BLL_PlanoConta.Busca_Relatorio();

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_PlanoConta = new ReportDataSource("ds_PlanoConta", _DT);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_PlanoConta);

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);
                imp.Imprimir(documento, Tipo_Impressao.Retrato);
                imp = null;
            }
        }
        #endregion

        #region FORM
        private void UI_PlanoConta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_PlanoConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_Nivel1.Focused == true & e.KeyCode == Keys.Right | e.KeyCode == Keys.Enter)
            {
                dg_Nivel2.Focus();
                return;
            }

            if (dg_Nivel2.Focused == true & e.KeyCode == Keys.Right | e.KeyCode == Keys.Enter)
            {
                dg_Nivel3.Focus();
                return;
            }

            if (dg_Nivel3.Focused == true & e.KeyCode == Keys.Right | e.KeyCode == Keys.Enter)
            {
                dg_Nivel4.Focus();
                return;
            }

            if (dg_Nivel4.Focused == true & e.KeyCode == Keys.Left)
            {
                dg_Nivel3.Focus();
                return;
            }

            if (dg_Nivel3.Focused == true & e.KeyCode == Keys.Left)
            {
                dg_Nivel2.Focus();
                return;
            }

            if (dg_Nivel2.Focused == true & e.KeyCode == Keys.Left)
            {
                dg_Nivel1.Focus();
                return;
            }
        }
        #endregion

        #region MASKEDBOX
        private void mk_Conta_Leave(object sender, EventArgs e)
        {
            mk_Conta.Text = mk_Conta.Text.Replace(" ", "0");
        }

        private void mk_Conta_TextChanged(object sender, EventArgs e)
        {
            txt_Nivel.Text = util_dados.VerificaNivel(mk_Conta.Text).ToString();
            if (mk_Conta.Text.Replace(".", "").Replace(" ", "") != string.Empty)
                if (Convert.ToString(util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text))).Length == 2 |
                    Convert.ToString(util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text))).Length == 4 |
                    (Convert.ToString(util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text))).Length == 6 |
                    Convert.ToString(util_dados.ConsultaCodigoPai(mk_Conta.Text, util_dados.Verifica_int(txt_Nivel.Text))).Length == 8))
                    CarregaConta();
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_Nivel1_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel1.Rows.Count == 0)
            {
                txt_Nivel1.Text = "00";
            }
        }

        private void dg_Nivel2_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel2.Rows.Count == 0)
            {
                txt_Nivel2.Text = "00";
            }
        }

        private void dg_Nivel3_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel3.Rows.Count == 0)
            {
                txt_Nivel3.Text = "00";
            }
        }

        private void dg_Nivel4_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel4.Rows.Count == 0)
            {
                txt_Nivel4.Text = "00";
            }
        }

        private void dg_Nivel1_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel1.Rows.Count > 0)
            {
                txt_Nivel1.Text = (string)dg_Nivel1.Rows[dg_Nivel1.CurrentRow.Index].Cells[0].Value;
            }
            CarregaConta(2);
        }

        private void dg_Nivel2_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel2.Rows.Count > 0)
            {
                txt_Nivel2.Text = (string)dg_Nivel2.Rows[dg_Nivel2.CurrentRow.Index].Cells[0].Value;
            }
            CarregaConta(3);
        }

        private void dg_Nivel3_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel3.Rows.Count > 0)
            {
                txt_Nivel3.Text = (string)dg_Nivel3.Rows[dg_Nivel3.CurrentRow.Index].Cells[0].Value;
            }
            CarregaConta(4);
        }

        private void dg_Nivel4_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel4.Rows.Count > 0)
            {
                txt_Nivel4.Text = (string)dg_Nivel4.Rows[dg_Nivel4.CurrentRow.Index].Cells[0].Value;
            }
        }

        private void dg_Nivel1_DoubleClick(object sender, EventArgs e)
        {
            int aux = dg_Nivel1.CurrentRow.Index;

            mk_Conta.Text = dg_Nivel1.Rows[aux].Cells["col_cod_Nivel1"].Value.ToString();
            txt_Descricao.Focus();

        }

        private void dg_Nivel2_DoubleClick(object sender, EventArgs e)
        {
            int aux1 = dg_Nivel1.CurrentRow.Index;
            int aux2 = dg_Nivel2.CurrentRow.Index;


            mk_Conta.Text = dg_Nivel1.Rows[aux1].Cells["col_cod_Nivel1"].Value.ToString() + dg_Nivel2.Rows[aux2].Cells["col_cod_Nivel2"].Value.ToString();
            txt_Descricao.Focus();
        }

        private void dg_Nivel3_DoubleClick(object sender, EventArgs e)
        {
            int aux1 = dg_Nivel1.CurrentRow.Index;
            int aux2 = dg_Nivel2.CurrentRow.Index;
            int aux3 = dg_Nivel3.CurrentRow.Index;

            mk_Conta.Text = dg_Nivel1.Rows[aux1].Cells["col_cod_Nivel1"].Value.ToString() + dg_Nivel2.Rows[aux2].Cells["col_cod_Nivel2"].Value.ToString() + dg_Nivel3.Rows[aux3].Cells["col_cod_Nivel3"].Value.ToString();
            txt_Descricao.Focus();
        }

        private void dg_Nivel4_DoubleClick(object sender, EventArgs e)
        {
            int aux1 = dg_Nivel1.CurrentRow.Index;
            int aux2 = dg_Nivel2.CurrentRow.Index;
            int aux3 = dg_Nivel3.CurrentRow.Index;
            int aux4 = dg_Nivel4.CurrentRow.Index;

            mk_Conta.Text = dg_Nivel1.Rows[aux1].Cells["col_cod_Nivel1"].Value.ToString() + dg_Nivel2.Rows[aux2].Cells["col_cod_Nivel2"].Value.ToString() + dg_Nivel3.Rows[aux3].Cells["col_cod_Nivel3"].Value.ToString() + dg_Nivel4.Rows[aux4].Cells["col_cod_Nivel4"].Value.ToString();
            txt_Descricao.Focus();
        }
        #endregion

        #region BUTTON
        private void bt_NovoNivel1_Click(object sender, EventArgs e)
        {
            string Valor;

            if (dg_Nivel1.Rows.Count == 0)
                Valor = "01";
            else
                Valor = (Convert.ToDouble(dg_Nivel1.Rows[dg_Nivel1.Rows.Count - 1].Cells["col_cod_Nivel1"].Value) + 1).ToString().PadLeft(2, '0');


            mk_Conta.Text = Valor;
            txt_Descricao.Focus();

            Config(StatusForm.Novo);
        }

        private void bt_NovoNivel2_Click(object sender, EventArgs e)
        {
            int aux1 = dg_Nivel1.CurrentRow.Index;
            string Valor;

            if (dg_Nivel2.Rows.Count == 0)
                Valor = "01";
            else
                Valor = (Convert.ToDouble(dg_Nivel2.Rows[dg_Nivel2.Rows.Count - 1].Cells["col_cod_Nivel2"].Value) + 1).ToString().PadLeft(2, '0');


            mk_Conta.Text = dg_Nivel1.Rows[aux1].Cells["col_cod_Nivel1"].Value.ToString() + Valor;
            txt_Descricao.Focus();

            Config(StatusForm.Novo);
        }

        private void bt_NovoNivel3_Click(object sender, EventArgs e)
        {
            int aux1 = dg_Nivel1.CurrentRow.Index;
            int aux2 = dg_Nivel2.CurrentRow.Index;
            string Valor;

            if (dg_Nivel3.Rows.Count == 0)
                Valor = "01";
            else
                Valor = (Convert.ToDouble(dg_Nivel3.Rows[dg_Nivel3.Rows.Count - 1].Cells["col_cod_Nivel3"].Value) + 1).ToString().PadLeft(2, '0');


            mk_Conta.Text = dg_Nivel1.Rows[aux1].Cells["col_cod_Nivel1"].Value.ToString() + dg_Nivel2.Rows[aux2].Cells["col_cod_Nivel2"].Value.ToString() + Valor;
            txt_Descricao.Focus();

            Config(StatusForm.Novo);
        }

        private void bt_NovoNivel4_Click(object sender, EventArgs e)
        {
            int aux1 = dg_Nivel1.CurrentRow.Index;
            int aux2 = dg_Nivel2.CurrentRow.Index;
            int aux3 = dg_Nivel3.CurrentRow.Index;
            string Valor;

            if (dg_Nivel4.Rows.Count == 0)
                Valor = "01";
            else
                Valor = (Convert.ToDouble(dg_Nivel4.Rows[dg_Nivel4.Rows.Count - 1].Cells["col_cod_Nivel4"].Value) + 1).ToString().PadLeft(2, '0');

            mk_Conta.Text = dg_Nivel1.Rows[aux1].Cells["col_cod_Nivel1"].Value.ToString() + dg_Nivel2.Rows[aux2].Cells["col_cod_Nivel2"].Value.ToString() + dg_Nivel3.Rows[aux3].Cells["col_cod_Nivel3"].Value.ToString() + Valor;
            txt_Descricao.Focus();

            Config(StatusForm.Novo);
        }
        #endregion

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Config(StatusForm.Consulta);
        }
    }
}
