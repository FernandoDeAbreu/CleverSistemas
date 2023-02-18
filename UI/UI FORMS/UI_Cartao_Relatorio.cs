using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_Cartao_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Cartao_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Cartao BLL_Cartao;
        BLL_Pagamento BLL_Pagamento;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Cartao Cartao;
        DTO_Pagamento Pagamento;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE RECEBIMENTO CARTÃO";

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            tabctl.SelectedTab = TabPage1;

            mk_DataInicial.Text = util_dados.Config_Data(DateTime.Now, 11).ToString();
            mk_DataFinal.Text = util_dados.Config_Data(DateTime.Now, 12).ToString();

            Carrega_CB();
        }

        private void Carrega_CB()
        {
            DataTable _DT = new DataTable();
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            Pagamento.FiltraPagamento = true;
            Pagamento.Recebimento = true;
            Pagamento.Tipo = 2;

            _DT = new DataTable();
            _DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Cartao);
            cb_ID_Cartao.SelectedIndex = -1;

            List<string> lst_Periodo = new List<string>();
            lst_Periodo.Add("EMISSÃO");
            lst_Periodo.Add("VENCIMENTO");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, lst_Periodo), "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedValue = 2;

            List<string> lst_Situacao = new List<string>();
            lst_Situacao.Add("TODOS");
            lst_Situacao.Add("EM ABERTO");
            lst_Situacao.Add("PAGO");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, lst_Situacao), "Descricao", "ID", cb_Situacao);
            cb_Periodo.SelectedValue = 2;
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {
            try
            {
                LocalReport rpt = new LocalReport();

                string rpt_Nome = "rpt_Cartao_Relatorio.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT_Empresa = new DataTable();
                _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Cartao = new BLL_Cartao();
                Cartao = new DTO_Cartao();

                Cartao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 0)
                    Cartao.Filtra_Baixado = false;
                else
                {
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                    {
                        Cartao.Filtra_Baixado = true;
                        Cartao.Baixado = false;
                    }

                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 2)
                    {
                        Cartao.Filtra_Baixado = true;
                        Cartao.Baixado = true;
                    }
                }

                Cartao.ID_Pagamento = Convert.ToInt32(cb_ID_Cartao.SelectedValue);

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                         mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    if (cb_Periodo.Text == "EMISSÃO")
                    {
                        Cartao.Consulta_Emissao.Filtra = true;
                        Cartao.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Cartao.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                    if (cb_Periodo.Text == "VENCIMENTO")
                    {
                        Cartao.Consulta_Vencimento.Filtra = true;
                        Cartao.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Cartao.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                }

                DataTable _DT_Cartao = new DataTable();
                _DT_Cartao = BLL_Cartao.Busca(Cartao);

                ReportDataSource ds_InfoEmitente = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
                ReportDataSource ds_Cartao = new ReportDataSource("ds_Cartao", _DT_Cartao);

                ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " à " + mk_DataFinal.Text);

                rpt.DataSources.Add(ds_InfoEmitente);
                rpt.DataSources.Add(ds_Cartao);

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
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Visualizar()
        {
            try
            {
                UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Cartao_Relatorio.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;
                rpt.Show();

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT_Empresa = new DataTable();
                _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Cartao = new BLL_Cartao();
                Cartao = new DTO_Cartao();

                Cartao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 0)
                    Cartao.Filtra_Baixado = false;
                else
                {
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                    {
                        Cartao.Filtra_Baixado = true;
                        Cartao.Baixado = false;
                    }

                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 2)
                    {
                        Cartao.Filtra_Baixado = true;
                        Cartao.Baixado = true;
                    }
                }

                Cartao.ID_Pagamento = Convert.ToInt32(cb_ID_Cartao.SelectedValue);

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                         mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    if (cb_Periodo.Text == "EMISSÃO")
                    {
                        Cartao.Consulta_Emissao.Filtra = true;
                        Cartao.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Cartao.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                    if (cb_Periodo.Text == "VENCIMENTO")
                    {
                        Cartao.Consulta_Vencimento.Filtra = true;
                        Cartao.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Cartao.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                }

                DataTable _DT_Cartao = new DataTable();
                _DT_Cartao = BLL_Cartao.Busca(Cartao);

                ReportDataSource ds_InfoEmitente = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
                ReportDataSource ds_Cartao = new ReportDataSource("ds_Cartao", _DT_Cartao);

                ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " à " + mk_DataFinal.Text);

                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_InfoEmitente);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Cartao);

                rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

                rpt.rpt_Viewer.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_FichaProducao_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

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
            if (mk_DataFinal.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }
        }

        private void UI_Cartao_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
    }
}
