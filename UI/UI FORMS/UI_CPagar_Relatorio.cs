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
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_CPagar_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_CPagar_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_CPagar BLL_CPagar;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;
        DataTable DTPessoa;
        DataTable DTR_Empresa;

        DataRow DR;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_CPagar CPagar;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE CONTAS À PAGAR";

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

        private void CarregaCB()
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
            aux.Add("RELATÓRIO POR CONTA");
            aux.Add("RELATÓRIO POR PESSOA");
            aux.Add("RELATÓRIO POR PESSOA SINTÉTICO ");
            aux.Add("CLASSIFICADO POR VENCIMENTO(DIA)");
            aux.Add("CLASSIFICADO POR VENCIMENTO(MÊS)");
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

        private void CarregaPessoa()
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
            //3 - RELATÓRIO POR CONTA
            //4 - RELATÓRIO POR PESSOA
            //5 - RELATÓRIO POR PESSOA SINTÉTICO
            //6 - CLASSIFICADO POR VENCIMENTO(DIA)
            //7 - CLASSIFICADO POR VENCIMENTO(MÊS)
            //8 - RELATÓRIO POR CONTA SINTÉTICO
            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1:
                    rpt_Nome = "rpt_CP_Baixa.rdlc";
                    break;

                case 2:
                    rpt_Nome = "rpt_CP_Baixa_Dia.rdlc";
                    break;

                case 3:
                    rpt_Nome = "rpt_CP_Conta.rdlc";
                    break;

                case 4:
                    rpt_Nome = "rpt_CP_Pessoa.rdlc";
                    break;

                case 5:
                    rpt_Nome = "rpt_CP_Pessoa_Sintetico.rdlc";
                    break;

                case 6:
                    rpt_Nome = "rpt_CP_Vencimento_Dia.rdlc";
                    break;

                case 7:
                    rpt_Nome = "rpt_CP_Vencimento.rdlc";
                    break;

                case 8:
                    rpt_Nome = "rpt_CP_Conta_Sintetico.rdlc";
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);

            BLL_CPagar = new BLL_CPagar();

            CPagar = new DTO_CPagar();

            CPagar.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CPagar.GrupoConta = mk_Conta.Text;
            CPagar.Documento = txt_Documento.Text;
            CPagar.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            CPagar.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            CPagar.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);

            /* FILTRO BUSCA (DATA)
           1 - BAIXA
           2 - EMISSÃO
           3 - VENCIMENTO
           */
            if (cb_Periodo.SelectedIndex == 0)
            {
                CPagar.Consulta_Baixa.Filtra = true;
                CPagar.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CPagar.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 1)
            {
                CPagar.Consulta_Emissao.Filtra = true;
                CPagar.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CPagar.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 2)
            {
                CPagar.Consulta_Vencimento.Filtra = true;
                CPagar.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CPagar.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }
            CPagar.Ordena_Por = 2;

            DT = BLL_CPagar.Busca(CPagar);
            ReportDataSource Conta = new ReportDataSource("ds_Financeiro_CPagar", DT);

            ReportParameter p1 = new ReportParameter("DataInicial", mk_DataInicial.Text);
            ReportParameter p2 = new ReportParameter("DataFinal", mk_DataFinal.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(Conta);

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
                        imp.Imprimir(documento, Tipo_Impressao.Retrato);
                        break;

                    case 6:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 7:
                        imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                        break;

                    case 8:
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
            //3 - RELATÓRIO POR CONTA
            //4 - RELATÓRIO POR PESSOA
            //5 - RELATÓRIO POR PESSOA SINTÉTICO
            //6 - CLASSIFICADO POR VENCIMENTO(DIA)
            //7 - CLASSIFICADO POR VENCIMENTO(MÊS)
            //8 - RELATÓRIO POR CONTA SINTÉTICO
            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1:
                    rpt_Nome = "rpt_CP_Baixa.rdlc";
                    break;

                case 2:
                    rpt_Nome = "rpt_CP_Baixa_Dia.rdlc";
                    break;

                case 3:
                    rpt_Nome = "rpt_CP_Conta.rdlc";
                    break;

                case 4:
                    rpt_Nome = "rpt_CP_Pessoa.rdlc";
                    break;

                case 5:
                    rpt_Nome = "rpt_CP_Pessoa_Sintetico.rdlc";
                    break;

                case 6:
                    rpt_Nome = "rpt_CP_Vencimento_Dia.rdlc";
                    break;

                case 7:
                    rpt_Nome = "rpt_CP_Vencimento.rdlc";
                    break;
                    
                case 8:
                    rpt_Nome = "rpt_CP_Conta_Sintetico.rdlc";
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);

            BLL_CPagar = new BLL_CPagar();

            CPagar = new DTO_CPagar();

            CPagar.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CPagar.GrupoConta = mk_Conta.Text;
            CPagar.Documento = txt_Documento.Text;
            CPagar.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            CPagar.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            CPagar.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);

            /* FILTRO BUSCA (DATA)
           1 - BAIXA
           2 - EMISSÃO
           3 - VENCIMENTO
           */
            if (cb_Periodo.SelectedIndex == 0)
            {
                CPagar.Consulta_Baixa.Filtra = true;
                CPagar.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CPagar.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 1)
            {
                CPagar.Consulta_Emissao.Filtra = true;
                CPagar.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CPagar.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            if (cb_Periodo.SelectedIndex == 2)
            {
                CPagar.Consulta_Vencimento.Filtra = true;
                CPagar.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                CPagar.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }
            CPagar.Ordena_Por = 2;

            DT = BLL_CPagar.Busca(CPagar);
            ReportDataSource Conta = new ReportDataSource("ds_Financeiro_CPagar", DT);

            ReportParameter p1 = new ReportParameter("DataInicial", mk_DataInicial.Text);
            ReportParameter p2 = new ReportParameter("DataFinal", mk_DataFinal.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(Conta);

            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            frm_rpt.rpt_Viewer.RefreshReport();
        }
        #endregion

        #region FORM
        private void UI_CPagar_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_CPagar_Relatorio_KeyDown(object sender, KeyEventArgs e)
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
    }
}
