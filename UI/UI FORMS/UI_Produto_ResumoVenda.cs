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
    public partial class UI_Produto_ResumoVenda : Sistema.UI.UI_Modelo
    {
        public UI_Produto_ResumoVenda()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_Pessoa BLL_Pessoa;
        BLL_TabelaValor BLL_TabelaValor;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTR_Empresa;
        DataTable DTR_Produto;
        DataTable DTProduto;
        DataTable DT;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Pessoa Pessoa;
        DTO_TabelaValor TabelaValor;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RESUMO DE VENDAS DE PRODUTOS";
            TabPage1.Text = "PESQUISA";

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
            mk_DataInicial.Text = Convert.ToString(Periodo);
            mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));

            dg_Estoque.AutoGenerateColumns = false;
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ListaID = txt_ID.Text;
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_GrupoNivel.Text;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_ReferenciaP.Text;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1";

            Produto.Consulta_Emissao.Filtra = true;
            Produto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            Produto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);

            DTProduto = BLL_Produto.Busca_ResumoVenda(Produto);
            dg_Estoque.DataSource = DTProduto;
        }

        public override void Visualizar()
        {
            if (DTProduto == null ||
                DTProduto.Rows.Count == 0)
                return;

            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome;

            rpt_Nome = "rpt_Produto_ResumoVenda.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_ResumoVenda", DTProduto);

            ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " A " + mk_DataFinal.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);
            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

            frm_rpt.rpt_Viewer.RefreshReport();
            frm_rpt.Show();
        }

        public override void Imprimir()
        {
            if (DTProduto == null ||
                DTProduto.Rows.Count == 0)
                return;

            LocalReport rpt = new LocalReport();
            string rpt_Nome;

            rpt_Nome = "rpt_Produto_ResumoVenda.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_ResumoVenda", DTProduto);

            ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " A " + mk_DataFinal.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Produto);
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
        #endregion

        #region FORM
        private void UI_Produto_ResumoVenda_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_ResumoVenda_KeyDown(object sender, KeyEventArgs e)
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

        #region BUTTON
        private void bt_PesquisaGrupo_Click(object sender, EventArgs e)
        {
            UI_GrupoNivel_Consulta frm = new UI_GrupoNivel_Consulta();
            frm.ShowDialog();
            mk_GrupoNivel.Text = frm.Cod_Conta;
        }
        #endregion
    }
}
