using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Locacao_Baixa : Sistema.UI.UI_Modelo
    {
        public UI_Locacao_Baixa()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        BLL_Imovel_Locacao BLL_Imovel_Locacao;
        BLL_Imovel BLL_Imovel;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;
        DataTable DTTipoPessoa;
        DataTable DTR_Empresa;
        DataTable DT;
        DataTable DT_CReceber;
        DataTable DTPessoa;
        DataTable _DT_CR;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_CReceber CReceber;
        DTO_Pessoa Pessoa;
        DTO_Locacao_Locatario Locacao_Locatario;
        DTO_Locacao Locacao;
        DTO_Imovel Imovel;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RECIBO ALUGUEL";

            dg_CReceber.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);

            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Novo.Visible = false;
            bt_Exclui.Visible = false;

            bt_Visualiza.Enabled = true;
            bt_Imprime.Enabled = true;
            //  Carrega_CB();

            CarregaPessoa();
            Limpa_Campo();
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = 8;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
            }
            catch (Exception)
            {
            }
        }

        private void Busca_Aluguel(int ID_Pessoa)
        {
            try
            {
                BLL_CReceber = new BLL_CReceber();
                CReceber = new DTO_CReceber();

                CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                CReceber.TipoPessoa = 8;
                CReceber.ID_Pessoa = ID_Pessoa;
                CReceber.Situacao = 1;

                CReceber.Consulta_Vencimento.Filtra = true;
                CReceber.Consulta_Vencimento.Inicial = DateTime.Now.AddYears(-100);
                CReceber.Consulta_Vencimento.Final = Convert.ToDateTime(mk_Data.Text);

                _DT_CR = new DataTable();
                _DT_CR = BLL_CReceber.Busca(CReceber);

                _DT_CR.Columns.Add("Juros", typeof(double));
                _DT_CR.Columns.Add("Multa", typeof(double));

                for (int i = 0; i <= _DT_CR.Rows.Count - 1; i++)
                {
                    double Valor = Convert.ToDouble(_DT_CR.Rows[i]["Valor"]);
                    DateTime Vencimento = Convert.ToDateTime(_DT_CR.Rows[i]["Vencimento"]);

                    if (cb_ExibirJuros.Checked == true)
                    {
                        _DT_CR.Rows[i]["Multa"] = util_dados.Calcula_Porcentagem(Parametro_Financeiro.Tarifa_Multa, Valor);
                        _DT_CR.Rows[i]["Juros"] = util_dados.Calcula_Juro(Valor, Parametro_Financeiro.Tarifa_Juros, Vencimento, Convert.ToDateTime(mk_Data.Text));
                        _DT_CR.Rows[i]["Total"] = Convert.ToDouble(_DT_CR.Rows[i]["Multa"]) + Convert.ToDouble(_DT_CR.Rows[i]["Juros"]) + Convert.ToDouble(_DT_CR.Rows[i]["Valor"]);
                    }
                    else
                    {
                        _DT_CR.Rows[i]["Multa"] = 0;
                        _DT_CR.Rows[i]["Juros"] = 0;
                        _DT_CR.Rows[i]["Total"] = Convert.ToDouble(_DT_CR.Rows[i]["Valor"]);
                    }
                }

                dg_CReceber.DataSource = _DT_CR;
                txt_Total.Text = util_dados.ConfigNumDecimal(util_dados.Calcula_Campo_DT(_DT_CR, "Total"), 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Limpa_Campo()
        {
            mk_Data.Text = DateTime.Now.ToString();
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = 8;

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            if (UI_Pessoa_Consulta.TipoPessoa != 8)
                return;

            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            Busca_Aluguel(Convert.ToInt32(cb_ID_Pessoa.SelectedValue));
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = "";

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            if (_DT_CR.Rows.Count <= 7)
            {
                rpt_Nome = "rpt_ReciboAluguel2.rdlc";
                for (int i = _DT_CR.Rows.Count; i <= 6; i++)
                    _DT_CR.Rows.Add();
            }
            else
                rpt_Nome = "rpt_ReciboAluguel.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_CReceber = new ReportDataSource("ds_CReceber", _DT_CR);
            //string Info = Environment.NewLine + txt_Descricao.Text;

            string numExtenso = util_dados.ValorExtenso(Convert.ToDecimal(txt_Total.Text));
            ReportParameter p1 = new ReportParameter("Valor", txt_Total.Text);
            ReportParameter p2 = new ReportParameter("ValorExtenso", numExtenso.ToUpper());
            ReportParameter p3 = new ReportParameter("Pessoa", cb_ID_Pessoa.Text);
            ReportParameter p4 = new ReportParameter("Informacao", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
            ReportParameter p5 = new ReportParameter("Data", Convert.ToString(util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4)).ToUpper());
            ReportParameter p6 = new ReportParameter("Proprietario", txt_Proprietario.Text.ToString().ToUpper());

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_CReceber);
            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

            rpt.rpt_Viewer.RefreshReport();
            rpt.Show();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();
            string rpt_Nome = "";

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            if (_DT_CR.Rows.Count <= 7)
            {
                rpt_Nome = "rpt_ReciboAluguel2.rdlc";
                for (int i = _DT_CR.Rows.Count; i <= 6; i++)
                    _DT_CR.Rows.Add();
            }
            else
                rpt_Nome = "rpt_ReciboAluguel.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_CReceber = new ReportDataSource("ds_CReceber", _DT_CR);
            //string Info = Environment.NewLine + txt_Descricao.Text;

            string numExtenso = util_dados.ValorExtenso(Convert.ToDecimal(txt_Total.Text));
            ReportParameter p1 = new ReportParameter("Valor", txt_Total.Text);
            ReportParameter p2 = new ReportParameter("ValorExtenso", numExtenso.ToUpper());
            ReportParameter p3 = new ReportParameter("Pessoa", cb_ID_Pessoa.Text);
            ReportParameter p4 = new ReportParameter("Informacao", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
            ReportParameter p5 = new ReportParameter("Data", Convert.ToString(util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4)).ToUpper());
            ReportParameter p6 = new ReportParameter("Proprietario", txt_Proprietario.Text.ToString().ToUpper());

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_CReceber);
            rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

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

        #region COMBOBOX
        private void cb_ID_Pessoa_Leave(object sender, EventArgs e)
        {
            BLL_Imovel_Locacao = new BLL_Imovel_Locacao();
            BLL_Imovel = new BLL_Imovel();

            Locacao = new DTO_Locacao();
            CReceber = new DTO_CReceber();
            Locacao_Locatario = new DTO_Locacao_Locatario();

            Locacao.Locatario = new List<DTO_Locacao_Locatario>();

            Locacao_Locatario.ID_Locatario = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            Locacao.Locatario.Add(Locacao_Locatario);

            DataTable _DT = new DataTable();
            _DT = BLL_Imovel_Locacao.Busca_ResumoAluguel(Locacao);

            if (_DT.Rows.Count > 0)
            {
                DateTime PeriodoInicial = Convert.ToDateTime(_DT.Rows[0]["Inicio"]);

                if (PeriodoInicial.Day == 31)
                    PeriodoInicial = PeriodoInicial.AddDays(-1);

                if (PeriodoInicial.Day == 30 &&
                              PeriodoInicial.Month == 2)
                    PeriodoInicial = PeriodoInicial.AddDays(-2);

                if (PeriodoInicial.Day == 29 &&
                    DateTime.Now.Month == 2)
                    PeriodoInicial = PeriodoInicial.AddDays(-1);

                PeriodoInicial = Convert.ToDateTime(PeriodoInicial.Day + @"/" + DateTime.Now.Month + @"/" + DateTime.Now.Year);

                DateTime PeriodoFinal = Convert.ToDateTime(_DT.Rows[0]["Termino"]);

                if (PeriodoFinal.Day == 31)
                    PeriodoFinal = PeriodoFinal.AddDays(-1);

                if (PeriodoFinal.Day == 30 &&
                              PeriodoFinal.Month == 2)
                    PeriodoFinal = PeriodoFinal.AddDays(-2);

                if (PeriodoFinal.Day == 29 &&
                    PeriodoFinal.Month == 2)
                    PeriodoFinal = PeriodoFinal.AddDays(-1);

                PeriodoFinal = Convert.ToDateTime(PeriodoInicial.AddDays(-1).Day + @"/" + PeriodoInicial.AddMonths(1).Month + @"/" + DateTime.Now.AddMonths(1).Year);

                mk_DataInicial.Text = PeriodoInicial.ToString();
                mk_DataFinal.Text = PeriodoFinal.ToString();

                DataTable _DT_AUX = new DataTable();
                Imovel = new DTO_Imovel();

                Imovel.ID = Convert.ToInt32(_DT.Rows[0]["ID_Imovel"]);
                _DT_AUX = BLL_Imovel.Busca_Proprietario(Imovel);

                if (_DT_AUX.Rows.Count > 0)
                    txt_Proprietario.Text = _DT_AUX.Rows[0]["Descricao"].ToString();
            }
            else
            {
                mk_DataInicial.Text = DateTime.Now.AddMonths(-1).ToString();
                mk_DataFinal.Text = DateTime.Now.ToString();
            }
            Pesquisa();
        }
        #endregion

        #region FORM
        private void UI_Locacao_Baixa_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Locacao_Baixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataInicial.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataInicial.Text = Convert.ToString(DateTime.Now);
                mk_DataInicial.Focus();
            }

        }

        private void mk_DataFinal_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }

        }

        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data.Text = Convert.ToString(DateTime.Now);
                mk_Data.Focus();
            }

        }
        #endregion

        #region CHECKBOX
        private void cb_ExibirJuros_CheckedChanged(object sender, EventArgs e)
        {
            Pesquisa();
        }
        #endregion
    }
}
