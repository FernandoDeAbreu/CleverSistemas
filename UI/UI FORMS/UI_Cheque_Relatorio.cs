using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Cheque_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Cheque_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Cheque BLL_Cheque;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_CReceber BLL_CReceber;
        BLL_CPagar BLL_CPagar;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        string obj;
        DataRow DR;

        DataTable DTTipoPessoa;
        DataTable DTPessoa;
        DataTable DTChequeSituacao;
        DataTable DTFluxoCaixa;
        DataTable DTConta;
        DataTable DTGrupo;
        DataTable DTR_Empresa;

        double TotalControleCheque;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Cheque Cheque;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_CReceber CReceber;
        DTO_CPagar CPagar;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE CHEQUES";

            TabPage1.Text = "RELATÓRIO";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            bt_Novo.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            tabctl.SelectedTab = TabPage1;

            DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
            mk_DataInicial.Text = Convert.ToString(Periodo);
            mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();

            List<string> aux = new List<string> { "TODOS", "DISPONÍVEL", "DEVOLVIDO", "DEPOSITADO", "PAGTO. TERCEIRO", "COMPENSADO" };

            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;

            aux = new List<string> { "RELATÓRIO DE CHEQUE SIMPLES", "RELATÓRIO DE CHEQUE DETALHADO" };
            _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoRelatorio);
            cb_TipoRelatorio.SelectedIndex = 0;

            aux = new List<string> { "EMISSÃO", "VENCIMENTO" };
            _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedIndex = 0;
        }

        private void CarregaPessoa(int intTipoPessoa)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
            }
            catch (Exception)
            {
            }
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

            CarregaPessoa(UI_Pessoa_Consulta.TipoPessoa);
            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
        }
        #endregion

        #region MODIFICADORES
        public override void Visualizar()
        {
            BLL_Cheque = new BLL_Cheque();
            Cheque = new DTO_Cheque();

            Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Cheque.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Cheque.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            Cheque.Documento = txt_Documento.Text;
            Cheque.Banco = txt_Banco.Text;
            Cheque.Agencia = txt_Agencia.Text;
            Cheque.Conta = txt_Conta.Text;
            Cheque.Cheque = txt_Cheque.Text;
            Cheque.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);

            if (cb_Periodo.SelectedIndex == 0)
            {
                Cheque.Consulta_Emissao.Filtra = true;
                Cheque.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Cheque.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 1)
            {
                Cheque.Consulta_Vencimento.Filtra = true;
                Cheque.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Cheque.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = string.Empty;

            DataTable _DT = new DataTable();

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATORIO SIMPLES DE CHEQUE
                    rpt_Nome = "rpt_Cheque.rdlc";

                    _DT = BLL_Cheque.Busca(Cheque);

                    break;

                case 2: //RELATORIO DETALHADO DE CHEQUE
                    rpt_Nome = "rpt_Cheque_Detalhado.rdlc";

                    _DT = BLL_Cheque.Busca_ResumoRelatorio(Cheque);
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Cheque = new ReportDataSource("ds_Cheque", _DT);

            ReportParameter p1 = new ReportParameter("Emissao", this.Text);
            ReportParameter p2 = new ReportParameter("Periodo", mk_DataInicial.Text + " A " + mk_DataFinal.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Cheque);

            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

            frm_rpt.rpt_Viewer.RefreshReport();
            frm_rpt.Show();
        }

        public override void Imprimir()
        {
            BLL_Cheque = new BLL_Cheque();
            Cheque = new DTO_Cheque();

            Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Cheque.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Cheque.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            Cheque.Documento = txt_Documento.Text;
            Cheque.Banco = txt_Banco.Text;
            Cheque.Agencia = txt_Agencia.Text;
            Cheque.Conta = txt_Conta.Text;
            Cheque.Cheque = txt_Cheque.Text;
            Cheque.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);

            if (cb_Periodo.SelectedIndex == 0)
            {
                Cheque.Consulta_Emissao.Filtra = true;
                Cheque.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Cheque.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 1)
            {
                Cheque.Consulta_Vencimento.Filtra = true;
                Cheque.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Cheque.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }


            LocalReport rpt = new LocalReport();
            string rpt_Nome = string.Empty;

            DataTable _DT = new DataTable();

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATORIO SIMPLES DE CHEQUE
                    rpt_Nome = "rpt_Cheque.rdlc";

                    _DT = BLL_Cheque.Busca(Cheque);

                    break;

                case 2: //RELATORIO DETALHADO DE CHEQUE
                    rpt_Nome = "rpt_Cheque_Detalhado.rdlc";

                    _DT = BLL_Cheque.Busca_ResumoRelatorio(Cheque);
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Cheque = new ReportDataSource("ds_Cheque", _DT);

            ReportParameter p1 = new ReportParameter("Emissao", this.Text);
            ReportParameter p2 = new ReportParameter("Periodo", mk_DataInicial.Text + " A " + mk_DataFinal.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Cheque);

            rpt.SetParameters(new ReportParameter[] { p1, p2 });

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
        private void UI_Cheque_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            CarregaCB();
        }

        private void UI_Cheque_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(1);
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
    }
}
