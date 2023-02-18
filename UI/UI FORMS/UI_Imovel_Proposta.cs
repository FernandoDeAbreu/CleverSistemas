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
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;

namespace Sistema.UI
{
    public partial class UI_Imovel_Proposta : Sistema.UI.UI_Modelo
    {
        public UI_Imovel_Proposta()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PROPOSTA DE AQUISIÇÃO";

            TabPage1.Text = "PROPOSTA";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();
            string rpt_Nome = "rpt_PropostaAquisicao.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DT = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DT);

            rpt.DataSources.Add(ds_Empresa);
            
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
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = "rpt_PropostaAquisicao.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DT = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DT);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);

            rpt.rpt_Viewer.RefreshReport();
            rpt.Show();
        }
        #endregion

        #region FORM
        private void frm_Proposta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion
    }
}
