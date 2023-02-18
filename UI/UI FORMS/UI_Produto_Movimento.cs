using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_Movimento : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Movimento()
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

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO MOVIMENTAÇÃO DE PRODUTO";
            TabPage1.Text = "RELATÓRIO";

            tabctl.TabPages.Remove(TabPage1);

            tabctl.SelectedTab = TabPage2;

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Pesquisa.Visible = true;
            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            DataGridViewTextBoxColumn col_ID_Produto = new DataGridViewTextBoxColumn();
            col_ID_Produto.DataPropertyName = "ID_Produto";
            col_ID_Produto.HeaderText = "CÓD. PRODUTO";
            col_ID_Produto.Width = 70;
            DG.Columns.Add(col_ID_Produto);

            DataGridViewTextBoxColumn col_Produto = new DataGridViewTextBoxColumn();
            col_Produto.DataPropertyName = "Descricao";
            col_Produto.HeaderText = "PRODUTO";
            col_Produto.Width = 200;
            col_Produto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Produto);

            DataGridViewTextBoxColumn col_Data = new DataGridViewTextBoxColumn();
            col_Data.DataPropertyName = "Data";
            col_Data.HeaderText = "DATA";
            col_Data.Width = 80;
            DG.Columns.Add(col_Data);

            DataGridViewTextBoxColumn col_UltimoLanc = new DataGridViewTextBoxColumn();
            col_UltimoLanc.DataPropertyName = "UltimoLancamento";
            col_UltimoLanc.HeaderText = "ÚLTIMA MOVIMENTAÇÃO";
            col_UltimoLanc.Width = 180;
            DG.Columns.Add(col_UltimoLanc);

            DataGridViewTextBoxColumn col_Pessoa = new DataGridViewTextBoxColumn();
            col_Pessoa.DataPropertyName = "Pessoa";
            col_Pessoa.HeaderText = "PESSOA";
            col_Pessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Pessoa);

            DataGridViewTextBoxColumn col_Tipo = new DataGridViewTextBoxColumn();
            col_Tipo.DataPropertyName = "Tipo";
            col_Tipo.HeaderText = "TIPO";
            col_Tipo.Width = 120;
            DG.Columns.Add(col_Tipo);

            DataGridViewTextBoxColumn col_Qt_Compra = new DataGridViewTextBoxColumn();
            col_Qt_Compra.DataPropertyName = "Compra";
            col_Qt_Compra.HeaderText = "QT. ENTRADA";
            col_Qt_Compra.Width = 85;
            col_Qt_Compra.DefaultCellStyle.Format = "N3";
            col_Qt_Compra.DefaultCellStyle.NullValue = "";
            col_Qt_Compra.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Columns.Add(col_Qt_Compra);

            DataGridViewTextBoxColumn col_Qt_Venda = new DataGridViewTextBoxColumn();
            col_Qt_Venda.DataPropertyName = "Venda";
            col_Qt_Venda.HeaderText = "QT. SAÍDA";
            col_Qt_Venda.Width = 85;
            col_Qt_Venda.DefaultCellStyle.Format = "N3";
            col_Qt_Venda.DefaultCellStyle.NullValue = "";
            col_Qt_Venda.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Columns.Add(col_Qt_Venda);

            DG.AllowUserToResizeColumns = true;
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            DataTable _DT = new DataTable();

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_ReferenciaP.Text;
            Produto.Barra = txt_Barra.Text;

            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 2, 3, 4";

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                      mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                Produto.Consulta_Emissao.Filtra = true;
                Produto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Produto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            _DT = BLL_Produto.Busca_ProdutoMovimento(Produto);
            DG.DataSource = _DT;
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = string.Empty;
            rpt_Nome = "rpt_Produto_Movimento.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_ReferenciaP.Text;
            Produto.Barra = txt_Barra.Text;

            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1";

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                      mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                Produto.Consulta_Emissao.Filtra = true;
                Produto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Produto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_ProdutoMovimento(Produto);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_Produto", _DT);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);

            rpt.rpt_Viewer.RefreshReport();
            rpt.Show();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_Produto_Movimento.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;

            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_ReferenciaP.Text;
            Produto.Barra = txt_Barra.Text;

            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1";

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                      mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                Produto.Consulta_Emissao.Filtra = true;
                Produto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Produto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_ProdutoMovimento(Produto);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_Produto", _DT);


            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Produto);

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();

            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;

                util_Impressao imp = util_Impressao.Novo(rpt);
                imp.Imprimir(documento, Tipo_Impressao.Paisagem);
                imp = null;
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_Movimento_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Movimento_KeyDown(object sender, KeyEventArgs e)
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
    }
}
