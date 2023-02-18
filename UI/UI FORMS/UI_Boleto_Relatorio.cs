using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Boleto_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Boleto_Relatorio()
        {
            InitializeComponent();
        }
        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Boleto BLL_Boleto;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Boleto Boleto;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTR_Empresa;

        DateTime ValidaData;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE COBRANÇA BANCÁRIA";

            dg_Boletos.AutoGenerateColumns = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;
            bt_Novo.Visible = false;
            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;
            bt_Grava.Visible = false;
            bt_Exclui.Visible = false;
            bt_Edita.Visible = false;

            tabctl.TabPages.Remove(TabPage2);

            cb_PeriodoBoleto.SelectedIndex = 2;
            cb_sit_Boleto.SelectedIndex = 1;

            CarregaCB();

            if (Parametro_Empresa.Tipo_Sistema == Tipo_Sistema.Imobiliaria)
                cb_TipoPessoa.SelectedValue = 8;
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                DataTable _DT = new DataTable();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                BLL_Boleto = new BLL_Boleto();
                Boleto = new DTO_Boleto();

                Boleto.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Boleto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                     mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    if (cb_PeriodoBoleto.SelectedIndex == 0)
                    {
                        Boleto.Consulta_Baixa.Filtra = true;
                        Boleto.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Boleto.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }

                    if (cb_PeriodoBoleto.SelectedIndex == 1)
                    {
                        Boleto.Consulta_Emissao.Filtra = true;
                        Boleto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Boleto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }

                    if (cb_PeriodoBoleto.SelectedIndex == 2)
                    {
                        Boleto.Consulta_Vencimento.Filtra = true;
                        Boleto.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Boleto.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                }

                if (cb_sit_Boleto.Text == "TODOS")
                    Boleto.Filtra_Liquidado = false;
                else
                {
                    Boleto.Filtra_Liquidado = true;
                    if (cb_sit_Boleto.Text == "LIQUIDADOS")
                        Boleto.Liquidado = true;

                    if (cb_sit_Boleto.Text == "EM ABERTO")
                        Boleto.Liquidado = false;
                }

                Boleto.Filtra_Cancelado = true;
                Boleto.Cancelado = false;

                DataTable _DT = new DataTable();
                _DT = BLL_Boleto.Busca(Boleto);
                dg_Boletos.DataSource = _DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Imprimir()
        {
            BLL_Boleto = new BLL_Boleto();
            Boleto = new DTO_Boleto();

            Boleto.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Boleto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                 mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                if (cb_PeriodoBoleto.SelectedIndex == 0)
                {
                    Boleto.Consulta_Baixa.Filtra = true;
                    Boleto.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Boleto.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                if (cb_PeriodoBoleto.SelectedIndex == 1)
                {
                    Boleto.Consulta_Emissao.Filtra = true;
                    Boleto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Boleto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                if (cb_PeriodoBoleto.SelectedIndex == 2)
                {
                    Boleto.Consulta_Vencimento.Filtra = true;
                    Boleto.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Boleto.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }
            }

            if (cb_sit_Boleto.Text == "TODOS")
                Boleto.Filtra_Liquidado = false;
            else
            {
                Boleto.Filtra_Liquidado = true;
                if (cb_sit_Boleto.Text == "LIQUIDADOS")
                    Boleto.Liquidado = true;

                if (cb_sit_Boleto.Text == "EM ABERTO")
                    Boleto.Liquidado = false;
            }

            Boleto.Filtra_Cancelado = true;
            Boleto.Cancelado = false;

            DataTable _DT = new DataTable();
            _DT = BLL_Boleto.Busca(Boleto);

            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_Boleto_Relatorio.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Boleto = new ReportDataSource("ds_Boleto", _DT);

            ReportParameter p1 = new ReportParameter("Período", mk_DataInicial.Text + " à " + mk_DataFinal.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Boleto);

            rpt.SetParameters(new ReportParameter[] { p1 });

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

        public override void Visualizar()
        {
            BLL_Boleto = new BLL_Boleto();
            Boleto = new DTO_Boleto();

            Boleto.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Boleto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                 mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                if (cb_PeriodoBoleto.SelectedIndex == 0)
                {
                    Boleto.Consulta_Baixa.Filtra = true;
                    Boleto.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Boleto.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                if (cb_PeriodoBoleto.SelectedIndex == 1)
                {
                    Boleto.Consulta_Emissao.Filtra = true;
                    Boleto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Boleto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                if (cb_PeriodoBoleto.SelectedIndex == 2)
                {
                    Boleto.Consulta_Vencimento.Filtra = true;
                    Boleto.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Boleto.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }
            }

            if (cb_sit_Boleto.Text == "TODOS")
                Boleto.Filtra_Liquidado = false;
            else
            {
                Boleto.Filtra_Liquidado = true;
                if (cb_sit_Boleto.Text == "LIQUIDADOS")
                    Boleto.Liquidado = true;

                if (cb_sit_Boleto.Text == "EM ABERTO")
                    Boleto.Liquidado = false;
            }

            Boleto.Filtra_Cancelado = true;
            Boleto.Cancelado = false;

            DataTable _DT = new DataTable();
            _DT = BLL_Boleto.Busca(Boleto);

            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_Boleto_Relatorio.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Boleto = new ReportDataSource("ds_Boleto", _DT);

            ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " à " + mk_DataFinal.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Boleto);

            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

            frm_rpt.rpt_Viewer.RefreshReport();
        }
        #endregion

        #region FORM
        private void UI_Boleto_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Boleto_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

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
            if (mk_DataFinal.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }
        #endregion
    }
}
