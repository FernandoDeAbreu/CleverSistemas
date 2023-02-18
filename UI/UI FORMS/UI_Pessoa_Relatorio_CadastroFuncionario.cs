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
    public partial class UI_Pessoa_Relatorio_CadastroFuncionario : Sistema.UI.UI_Modelo
    {
        public UI_Pessoa_Relatorio_CadastroFuncionario()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE CADASTRO DE FUNCIONÁRIO";

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Visible = true;
            bt_Imprime.Enabled = true;

            bt_Visualiza.Visible = true;
            bt_Visualiza.Enabled = true;

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            tabctl.SelectedTab = TabPage1;

            Carrega_Pessoa();
        }

        private void Carrega_Pessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = 1;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
            }
            catch (Exception)
            {
            }
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.Usuario_Restrito = true;
            UI_Pessoa_Consulta.TipoPessoa = 1;

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();

        }
        #endregion

        #region MODIFICADORES
        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_Cont_Funcionario.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_Pessoa = new DataTable();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            _DT_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);


            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", _DT_Pessoa);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_Cont_Funcionario.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_Pessoa = new DataTable();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            _DT_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);


            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", _DT_Pessoa);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pessoa);

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
        private void UI_Pessoa_Relatorio_CadastroFuncionario_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Pessoa_Relatorio_CadastroFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion
    }
}
