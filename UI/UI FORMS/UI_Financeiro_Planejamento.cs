using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using Microsoft.Reporting.WinForms;

namespace Sistema.UI
{
    public partial class UI_Financeiro_Planejamento : Sistema.UI.UI_Modelo
    {
        public UI_Financeiro_Planejamento()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Banco BLL_Banco;
        BLL_Grupo BLL_Grupo;
        BLL_Cheque BLL_Cheque;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_CReceber BLL_CReceber;
        BLL_CPagar BLL_CPagar;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS        
        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Banco Banco;
        DTO_Grupo Grupo;
        DTO_Cheque Cheque;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_CReceber CReceber;
        DTO_CPagar CPagar;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PLANEJAMENTO FINANCEIRO";

            bt_Proximo.Visible = false;
            bt_Anterior.Visible = false;
            bt_Edita.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Exclui.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            dg_Planejamento.AutoGenerateColumns = false;
            dg_FluxoCaixa.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);
            tabctl.SelectedTab = TabPage1;

            DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
            mk_DataInicial.Text = Convert.ToString(Periodo);
            mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            FluxoCaixa = new DTO_FluxoCaixa();

            BLL_FluxoCaixa.Atualiza_Planejamento();
        }

        private void Exibe_FluxoCaixa()
        {
            dg_FluxoCaixa.Rows.Clear();

            string _DescricaoCaixa = string.Empty;
            double _SaldoConta = 0;
            double _LimiteConta = 0;

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            BLL_Grupo = new BLL_Grupo();
            BLL_Banco = new BLL_Banco();

            Banco = new DTO_Banco();
            Grupo = new DTO_Grupo();
            FluxoCaixa = new DTO_FluxoCaixa();

            DataTable _DT = new DataTable();
            DataTable _DT_aux;

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);
            Grupo.FiltraExibir = true;
            Grupo.Exibir = true;
            _DT = BLL_Grupo.Busca(Grupo);

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                double _SaldoConta_aux = 0;
                double _LimiteConta_aux = 0;
                _DT_aux = new DataTable();

                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FluxoCaixa.Caixa = Convert.ToInt32(_DT.Rows[i]["ID"]);
                FluxoCaixa.Conciliado = Convert.ToBoolean(ck_Conciliado.Checked);
                FluxoCaixa.Planejamento = false;

                _DescricaoCaixa = _DT.Rows[i]["Descricao"].ToString();

                _DT_aux = BLL_FluxoCaixa.Busca_Saldo(FluxoCaixa);

                if (_DT_aux.Rows.Count > 0)
                    _SaldoConta_aux = Convert.ToDouble(_DT_aux.Rows[0]["Saldo"]);

                if (ck_LimiteVirtual.Checked == false)
                {
                    _DT_aux = new DataTable();
                    Banco.ID_Caixa = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    _DT_aux = BLL_Banco.Busca(Banco);

                    if (_DT_aux.Rows.Count > 0)
                        _LimiteConta_aux = Convert.ToDouble(_DT_aux.Rows[0]["Limite"]);
                }

                dg_FluxoCaixa.Rows.Add();
                dg_FluxoCaixa.Rows[i].Cells["col_ContaDescricao"].Value = _DescricaoCaixa;
                dg_FluxoCaixa.Rows[i].Cells["col_SaldoConta"].Value = _SaldoConta_aux;
                dg_FluxoCaixa.Rows[i].Cells["col_Limite"].Value = _LimiteConta_aux;
                dg_FluxoCaixa.Rows[i].Cells["col_SaldoTotal"].Value = _SaldoConta_aux + _LimiteConta_aux;

                _SaldoConta += _SaldoConta_aux;
                _LimiteConta += _LimiteConta_aux;
            }

            txt_Saldo.Text = util_dados.ConfigNumDecimal(_SaldoConta, 2);
            txt_Limite.Text = util_dados.ConfigNumDecimal(_LimiteConta, 2);
            txt_SaldoTotal.Text = util_dados.ConfigNumDecimal(_SaldoConta + _LimiteConta, 2);
        }

        private void Carrega_Planejamento()
        {
            try
            {
                dg_Planejamento.DataSource = null;

                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                FluxoCaixa = new DTO_FluxoCaixa();

                DataTable _DT = new DataTable();
                DataTable _DT_Planejamento = new DataTable();

                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FluxoCaixa.Planejamento = true;
                FluxoCaixa.Consulta_Emissao.Filtra = true;
                FluxoCaixa.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                FluxoCaixa.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);

                _DT = BLL_FluxoCaixa.Busca_Planejamento(FluxoCaixa);

                double _Saldo = Convert.ToDouble(txt_SaldoTotal.Text);
                double _DebitoMes = 0;
                double _CreditoMes = 0;
                DateTime Vencimento = DateTime.Now;

                if (_DT.Rows.Count > 0)
                {
                    Vencimento = Convert.ToDateTime(_DT.Rows[0]["Vencimento"]);

                    _DT_Planejamento = _DT.Clone();
                }

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    if (Vencimento.Month != Convert.ToDateTime(_DT.Rows[i]["Vencimento"]).Month)
                    {
                        _DT_Planejamento.Rows.Add();
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                        _DT_Planejamento.Rows.Add();
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["DescricaoPessoa"] = util_dados.Config_Data(Vencimento, 20).ToString().ToUpper() + " TOTAL MÊS: ";
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Credito"] = _CreditoMes;
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Debito"] = _DebitoMes;
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Saldo"] = _CreditoMes - _DebitoMes;
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                        _DT_Planejamento.Rows.Add();
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                        _DebitoMes = 0;
                        _CreditoMes = 0;
                    }

                    double Credito = Convert.ToDouble(_DT.Rows[i]["Credito"]);
                    double Debito = Convert.ToDouble(_DT.Rows[i]["Debito"]);

                    _Saldo = (_Saldo + Credito) - Debito;

                    _DebitoMes += Debito;
                    _CreditoMes += Credito;

                    _DT.Rows[i]["Saldo"] = _Saldo;

                    _DT_Planejamento.ImportRow(_DT.Rows[i]);

                    Vencimento = Convert.ToDateTime(_DT.Rows[i]["Vencimento"]);

                    if (i == _DT.Rows.Count - 1)
                    {
                        _DT_Planejamento.Rows.Add();
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                        _DT_Planejamento.Rows.Add();
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["DescricaoPessoa"] = util_dados.Config_Data(Vencimento, 20).ToString().ToUpper() + " TOTAL MÊS: ";
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Credito"] = _CreditoMes;
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Debito"] = _DebitoMes;
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Saldo"] = _CreditoMes - _DebitoMes;
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                        _DT_Planejamento.Rows.Add();
                        _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                    }
                }

                _DT.AcceptChanges();
                _DT_Planejamento.AcceptChanges();

                dg_Planejamento.DataSource = _DT_Planejamento;

                Configura_Grid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
                dg_Planejamento.DataSource = null;
            }
        }

        private void Configura_Grid()
        {
            for (int i = 0; i <= dg_Planejamento.Rows.Count - 1; i++)
            {
                if (dg_Planejamento.Rows[i].Cells["col_Tipo"].Value.ToString() == "RR")
                {
                    dg_Planejamento.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dg_Planejamento.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            Exibe_FluxoCaixa();
            Carrega_Planejamento();
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_Planejamento.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            DataTable _DT = new DataTable();
            DataTable _DT_Planejamento = new DataTable();

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Planejamento = true;
            FluxoCaixa.Consulta_Emissao.Filtra = true;
            FluxoCaixa.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            FluxoCaixa.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);

            _DT = BLL_FluxoCaixa.Busca_Planejamento(FluxoCaixa);

            double _Saldo = Convert.ToDouble(txt_SaldoTotal.Text);
            double _DebitoMes = 0;
            double _CreditoMes = 0;
            DateTime Vencimento = DateTime.Now;

            if (_DT.Rows.Count > 0)
            {
                Vencimento = Convert.ToDateTime(_DT.Rows[0]["Vencimento"]);

                _DT_Planejamento = _DT.Clone();
            }

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                if (Vencimento.Month != Convert.ToDateTime(_DT.Rows[i]["Vencimento"]).Month)
                {
                    _DT_Planejamento.Rows.Add();
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                    _DT_Planejamento.Rows.Add();
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["DescricaoPessoa"] = util_dados.Config_Data(Vencimento, 20).ToString().ToUpper() + " TOTAL MÊS: ";
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Credito"] = _CreditoMes;
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Debito"] = _DebitoMes;
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Saldo"] = _CreditoMes - _DebitoMes;
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                    _DT_Planejamento.Rows.Add();
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                    _DebitoMes = 0;
                    _CreditoMes = 0;
                }

                double Credito = Convert.ToDouble(_DT.Rows[i]["Credito"]);
                double Debito = Convert.ToDouble(_DT.Rows[i]["Debito"]);

                _Saldo = (_Saldo + Credito) - Debito;

                _DebitoMes += Debito;
                _CreditoMes += Credito;

                _DT.Rows[i]["Saldo"] = _Saldo;

                _DT_Planejamento.ImportRow(_DT.Rows[i]);

                Vencimento = Convert.ToDateTime(_DT.Rows[i]["Vencimento"]);

                if (i == _DT.Rows.Count - 1)
                {
                    _DT_Planejamento.Rows.Add();
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                    _DT_Planejamento.Rows.Add();
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["DescricaoPessoa"] = util_dados.Config_Data(Vencimento, 20).ToString().ToUpper() + " TOTAL MÊS: ";
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Credito"] = _CreditoMes;
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Debito"] = _DebitoMes;
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Saldo"] = _CreditoMes - _DebitoMes;
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                    _DT_Planejamento.Rows.Add();
                    _DT_Planejamento.Rows[_DT_Planejamento.Rows.Count - 1]["Tipo"] = "RR";
                }
            }

            _DT.AcceptChanges();
            _DT_Planejamento.AcceptChanges();


            DataTable _DT_Empresa = new DataTable();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Planejamento = new ReportDataSource("ds_Planejamento", _DT_Planejamento);

            ReportParameter p1 = new ReportParameter("Periodo", (mk_DataInicial.Text + " À " + mk_DataFinal.Text).ToString());

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Planejamento);
            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

            frm_rpt.rpt_Viewer.RefreshReport();
        }
        #endregion

        #region FORM
        private void UI_Financeiro_Planejamento_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Financeiro_Planejamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion        

        #region BUTTON
        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_PlanoConta_Consulta frm = new UI_PlanoConta_Consulta();
            frm.ShowDialog();
            mk_Conta.Text = frm.Cod_Conta;
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataInicial.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_DataInicial.Text = Convert.ToString(DateTime.Now);
                mk_DataInicial.Focus();
            }
        }

        private void mk_DataFinal_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_DataInicial.Text = Convert.ToString(DateTime.Now);
                mk_DataInicial.Focus();
            }
        }
        #endregion

        #region CHECKBOX
        private void ck_Conciliado_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Conciliado.Checked == true)
                ck_Conciliado.BackColor = Color.LightGray;
            else
                ck_Conciliado.BackColor = Color.White;

            Exibe_FluxoCaixa();
            Pesquisa();
        }

        private void ck_LimiteVirtual_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_LimiteVirtual.Checked == true)
                ck_LimiteVirtual.BackColor = Color.LightGray;
            else
                ck_LimiteVirtual.BackColor = Color.White;

            Exibe_FluxoCaixa();
            Pesquisa();
        }
        #endregion

        private void dg_FluxoCaixa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null &&
             e.ColumnIndex == 1)
                if (util_dados.Verifica_Double(e.Value.ToString()) >= 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Red;

            if (e.Value != null &&
            e.ColumnIndex == 2)
                if (util_dados.Verifica_Double(e.Value.ToString()) >= 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Red;

            if (e.Value != null &&
           e.ColumnIndex == 3)
                if (util_dados.Verifica_Double(e.Value.ToString()) >= 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Red;
        }

        private void dg_FluxoCaixa_SelectionChanged(object sender, EventArgs e)
        {
            dg_FluxoCaixa.ClearSelection();
        }

        private void dg_Planejamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null &&
         e.ColumnIndex == 6)
                if (util_dados.Verifica_Double(e.Value.ToString()) >= 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Red;

            if (e.Value != null &&
         e.ColumnIndex == 7)
                e.CellStyle.ForeColor = Color.Red;

            if (e.Value != null &&
         e.ColumnIndex == 8)
                if (util_dados.Verifica_Double(e.Value.ToString()) >= 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Red;


        }

        private void dg_Planejamento_SelectionChanged(object sender, EventArgs e)
        {
            dg_Planejamento.ClearSelection();
        }
    }
}
