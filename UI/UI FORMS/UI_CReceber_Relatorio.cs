using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.BLL;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_CReceber_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_CReceber_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;
        DataTable DTPessoa;
        DataTable DTR_Empresa;
        DataTable DT_Classificar;
        DataTable DTTipoPessoa;

        DataRow DR;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_CReceber CReceber;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE CONTAS À RECEBER";

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            tabctl.SelectedTab = TabPage1;

            CarregaCB();

            DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
            mk_DataInicial.Text = Convert.ToString(Periodo);
            mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));
        }

        public void CarregaCB()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;

            List<string> aux = new List<string> { "TODOS", "EM ABERTO", "PAGO" };

            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 0;

            aux = new List<string>();
            aux.Add("CLASSIFICADO POR BAIXA(DIA)");
            aux.Add("CLASSIFICADO POR BAIXA(MÊS)");
            aux.Add("CLASSIFICADO POR Nº DOCUMENTO");
            aux.Add("RELATÓRIO POR CONTA*");
            aux.Add("RELATÓRIO POR PESSOA*");
            aux.Add("RELATÓRIO POR PESSOA SINTÉTICO ");
            aux.Add("CLASSIFICADO POR VENCIMENTO(DIA)");
            aux.Add("CLASSIFICADO POR VENCIMENTO(MÊS)*");
            aux.Add("RELATÓRIO POR CONTA SINTÉTICO");

            _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoRelatorio);
            cb_TipoRelatorio.SelectedIndex = 0;

            aux = new List<string>();
            aux.Add("BAIXA");
            aux.Add("EMISSÃO");
            aux.Add("VENCIMENTO");

            _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedIndex = 2;
        }

        public void CarregaPessoa()
        {

            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
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

            CarregaPessoa();
            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();
            
            string rpt_Nome = "";

            //1 - CLASSIFICADO POR BAIXA(DIA)
            //2 - CLASSIFICADO POR BAIXA(MÊS)
            //3 - CLASSIFICADO POR Nº DOCUMENTO
            //4 - RELATÓRIO POR CONTA
            //5 - RELATÓRIO POR PESSOA
            //6 - RELATÓRIO POR PESSOA SINTÉTICO
            //7 - CLASSIFICADO POR VENCIMENTO(DIA)
            //8 - CLASSIFICADO POR VENCIMENTO(MÊS)
            //9 - RELATÓRIO POR CONTA SINTÉTICO

            if (ck_JuroMulta.Checked == false)
                switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
                {

                    case 1:
                        rpt_Nome = "rpt_CR_Baixa_Dia.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_CR_Baixa.rdlc";
                        break;

                    case 3:
                        rpt_Nome = "rpt_CR_Vencimento_Documento.rdlc";
                        break;

                    case 4:
                        rpt_Nome = "rpt_CR_Conta.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_CR_Pessoa.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_CR_Pessoa_Sintetico.rdlc";
                        break;

                    case 7:
                        rpt_Nome = "rpt_CR_Vencimento_Dia.rdlc";
                        break;

                    case 8:
                        rpt_Nome = "rpt_CR_Vencimento.rdlc";
                        break;

                    case 9:
                        rpt_Nome = "rpt_CR_Conta_Sintetico.rdlc";
                        break;
                }
            else
                switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
                {
                    case 1:
                        rpt_Nome = "rpt_CR_Baixa_Dia.rdlc";
                        ck_JuroMulta.Checked = false;
                        break;

                    case 2:
                        rpt_Nome = "rpt_CR_Baixa.rdlc";
                        ck_JuroMulta.Checked = false;
                        break;

                    case 3:
                        rpt_Nome = "rpt_CR_Vencimento_Documento.rdlc";
                        ck_JuroMulta.Checked = false;
                        break;

                    case 4:
                        rpt_Nome = "rpt_CR_ContaJM.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_CR_PessoaJM.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_CR_Pessoa_Sintetico.rdlc";
                        ck_JuroMulta.Checked = false;
                        return;

                    case 7:
                        rpt_Nome = "rpt_CR_Vencimento_Dia.rdlc";
                        ck_JuroMulta.Checked = false;
                        return;

                    case 8:
                        rpt_Nome = "rpt_CR_VencimentoJM.rdlc";
                        break;

                    case 9:
                        rpt_Nome = "rpt_CR_Conta_Sintetico.rdlc";
                        break;
                }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);

            BLL_CReceber = new BLL_CReceber();
            CReceber = new DTO_CReceber();

            CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CReceber.GrupoConta = mk_Conta.Text;
            CReceber.Documento = txt_Documento.Text;
            CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            CReceber.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            CReceber.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);
            CReceber.Ordena_Por = 2;

            /* FILTRO BUSCA (DATA)
            1 - BAIXA
            2 - EMISSÃO
            3 - VENCIMENTO
            */
            if (cb_Periodo.SelectedIndex == 0)
            {
                CReceber.Consulta_Baixa.Filtra = true;
                CReceber.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CReceber.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 1)
            {
                CReceber.Consulta_Emissao.Filtra = true;
                CReceber.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CReceber.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 2)
            {
                CReceber.Consulta_Vencimento.Filtra = true;
                CReceber.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CReceber.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            DT = BLL_CReceber.Busca(CReceber);
            ReportDataSource Conta = new ReportDataSource("ds_Financeiro_CReceber", DT);

            ReportParameter p1 = new ReportParameter("DataInicial", mk_DataInicial.Text);
            ReportParameter p2 = new ReportParameter("DataFinal", mk_DataFinal.Text);
            ReportParameter p3 = new ReportParameter("Juros", txt_Juros.Text);
            ReportParameter p4 = new ReportParameter("Multa", txt_Multa.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(Conta);

            if (ck_JuroMulta.Checked == false)
                rpt.SetParameters(new ReportParameter[] { p1, p2 });
            else
                rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);

                switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
                {
                    case 1:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 2:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 3:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 4:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 5:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 6:
                        imp.Imprimir(documento, Tipo_Impressao.Retrato);
                        break;

                    case 7:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 8:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 9:
                        imp.Imprimir(documento, Tipo_Impressao.Retrato);
                        break;
                }
                imp = null;
            }
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "";

            //1 - CLASSIFICADO POR BAIXA(DIA)
            //2 - CLASSIFICADO POR BAIXA(MÊS)
            //3 - CLASSIFICADO POR Nº DOCUMENTO
            //4 - RELATÓRIO POR CONTA
            //5 - RELATÓRIO POR PESSOA
            //6 - RELATÓRIO POR PESSOA SINTÉTICO
            //7 - CLASSIFICADO POR VENCIMENTO(DIA)
            //8 - CLASSIFICADO POR VENCIMENTO(MÊS)
            //9 - RELATÓRIO POR CONTA SINTÉTICO

            if (ck_JuroMulta.Checked == false)
                switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
                {

                    case 1:
                        rpt_Nome = "rpt_CR_Baixa_Dia.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_CR_Baixa.rdlc";
                        break;

                    case 3:
                        rpt_Nome = "rpt_CR_Vencimento_Documento.rdlc";
                        break;

                    case 4:
                        rpt_Nome = "rpt_CR_Conta.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_CR_Pessoa.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_CR_Pessoa_Sintetico.rdlc";
                        break;

                    case 7:
                        rpt_Nome = "rpt_CR_Vencimento_Dia.rdlc";
                        break;

                    case 8:
                        rpt_Nome = "rpt_CR_Vencimento.rdlc";
                        break;

                    case 9:
                        rpt_Nome = "rpt_CR_Conta_Sintetico.rdlc";
                        break;
                }
            else
                switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
                {
                    case 1:
                        rpt_Nome = "rpt_CR_Baixa_Dia.rdlc";
                        ck_JuroMulta.Checked = false;
                        break;

                    case 2:
                        rpt_Nome = "rpt_CR_Baixa.rdlc";
                        ck_JuroMulta.Checked = false;
                        break;

                    case 3:
                        rpt_Nome = "rpt_CR_Vencimento_Documento.rdlc";
                        ck_JuroMulta.Checked = false;
                        break;

                    case 4:
                        rpt_Nome = "rpt_CR_ContaJM.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_CR_PessoaJM.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_CR_Pessoa_Sintetico.rdlc";
                        ck_JuroMulta.Checked = false;
                        return;

                    case 7:
                        rpt_Nome = "rpt_CR_Vencimento_Dia.rdlc";
                        ck_JuroMulta.Checked = false;
                        return;

                    case 8:
                        rpt_Nome = "rpt_CR_VencimentoJM.rdlc";
                        break;

                    case 9:
                        rpt_Nome = "rpt_CR_Conta_Sintetico.rdlc";
                        break;
                }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);

            BLL_CReceber = new BLL_CReceber();
            CReceber = new DTO_CReceber();

            CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CReceber.GrupoConta = mk_Conta.Text;
            CReceber.Documento = txt_Documento.Text;
            CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            CReceber.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            CReceber.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);
            CReceber.Ordena_Por = 2;

            /* FILTRO BUSCA (DATA)
            1 - BAIXA
            2 - EMISSÃO
            3 - VENCIMENTO
            */
            if (cb_Periodo.SelectedIndex == 0)
            {
                CReceber.Consulta_Baixa.Filtra = true;
                CReceber.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CReceber.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 1)
            {
                CReceber.Consulta_Emissao.Filtra = true;
                CReceber.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CReceber.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 2)
            {
                CReceber.Consulta_Vencimento.Filtra = true;
                CReceber.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CReceber.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            DT = BLL_CReceber.Busca(CReceber);
            ReportDataSource Conta = new ReportDataSource("ds_Financeiro_CReceber", DT);

            ReportParameter p1 = new ReportParameter("DataInicial", mk_DataInicial.Text);
            ReportParameter p2 = new ReportParameter("DataFinal", mk_DataFinal.Text);
            ReportParameter p3 = new ReportParameter("Juros", txt_Juros.Text);
            ReportParameter p4 = new ReportParameter("Multa", txt_Multa.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(Conta);

            if (ck_JuroMulta.Checked == false)
                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            else
                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        #endregion

        #region FORM
        private void UI_CReceber_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_CReceber_Relatorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Juros.Focused == true ||
                txt_Multa.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_CReceber_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
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

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
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
        #endregion

        #region CHECKBOX
        private void ck_JuroMulta_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cb_TipoRelatorio.SelectedValue) != 4 &&
               Convert.ToInt32(cb_TipoRelatorio.SelectedValue) != 5 &&
               Convert.ToInt32(cb_TipoRelatorio.SelectedValue) != 8)
                ck_JuroMulta.Checked = false;

            if (ck_JuroMulta.Checked == true)
            {
                txt_Juros.Enabled = true;
                txt_Multa.Enabled = true;
            }
            else
            {
                txt_Juros.Enabled = false;
                txt_Multa.Enabled = false;
            }
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
        #endregion
    }
}
