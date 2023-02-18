using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Relatorio()
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
            this.Text = "RELATÓRIO DE PRODUTOS";
            TabPage1.Text = "PESQUISA";

            dg_Produto.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            mk_DataInicial.Text = DateTime.Now.ToString();

            CarregaCB();
        }

        public void CarregaCB()
        {
            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();

            DT = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(DT, "Descricao", "ID", cb_ID_Tabela);
            cb_ID_Tabela.SelectedIndex = 0;

            List<string> Relatorio = new List<string>();
            Relatorio.Add("RELATÓRIO DE ESTOQUE VALOR");
            Relatorio.Add("RELATÓRIO DE ESTOQUE SIMPLES");
            Relatorio.Add("RELATÓRIO CADASTRO FISCAL");
            Relatorio.Add("RELATÓRIO INFORMAÇÃO PRODUTO");
            Relatorio.Add("RELATÓRIO PARA ENTRADA DE PRODUTO");
            Relatorio.Add("RELATÓRIO TABELA DE VALOR");
            Relatorio.Add("RELATÓRIO TABELA DE VALOR C/ COD. BARRAS");
            Relatorio.Add("RELATÓRIO DE ESTOQUE VALOR POR DATA");
            Relatorio.Add("RELATÓRIO CADASTRO FISCAL - INVENTÁRIO");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Relatorio), "Descricao", "ID", cb_TipoRelatorio);
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_GrupoNivelP.Text;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_Referencia.Text;
            Produto.Barra = txt_Barra.Text;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
            Produto.Consulta_EstoqueCritico = Convert.ToBoolean(ck_EstoqueLimite.Checked);
            Produto.Consulta_EstoqueCompra = Convert.ToBoolean(ck_EstoqueCompra.Checked);

            DTProduto = BLL_Produto.Busca_Estoque_Vlr(Produto);
            dg_Produto.DataSource = DTProduto;
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            rpt.Show();

            string rpt_Nome = string.Empty;

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_GrupoNivelP.Text;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_Referencia.Text;
            Produto.Barra = txt_Barra.Text;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1";

            Produto.Consulta_EstoqueCritico = Convert.ToBoolean(ck_EstoqueLimite.Checked);
            Produto.Consulta_EstoqueCompra = Convert.ToBoolean(ck_EstoqueCompra.Checked);

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATÓRIO ESTOQUE COM VALOR
                    rpt_Nome = "rpt_Produto_Estoque_Valor.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 2: //RELATÓRIO ESTOQUE SIMPLES
                    rpt_Nome = "rpt_Produto_Estoque.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 3: //RELATÓRIO PRODUTO FISCAL
                    rpt_Nome = "rpt_Produto_Fiscal.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 4: //RELATÓRIO INFORMAÇÃO PRODUTO
                    rpt_Nome = "rpt_Produto_Completo.rdlc";
                    DTR_Produto = BLL_Produto.Busca_new(Produto);
                    break;

                case 5: //RELATÓRIO PARA ENTRADA DE PRODUTO
                    rpt_Nome = "rpt_Produto_Entrada.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 6: //RELATÓRIO TABELA DE VALOR
                    rpt_Nome = "rpt_TabelaValor.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Valor(Produto);
                    break;

                case 7: //RELATÓRIO TABELA DE VALOR CODIGO DE BARRAS
                    rpt_Nome = "rpt_TabelaValor_Barra.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Valor(Produto);
                    break;

                case 8: //RELATÓRIO ESTOQUE VALOR DATA
                    rpt_Nome = "rpt_Produto_Estoque_Valor_Data.rdlc";

                    Produto.Consulta_Emissao.Filtra = true;

                    if (!util_dados.Verifica_Data(mk_DataInicial.Text))
                        Produto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    else
                        Produto.Consulta_Emissao.Inicial = DateTime.Now;

                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr_Data(Produto);
                    break;

                case 9: //RELATÓRIO PRODUTO INVENTÁRIO
                    rpt_Nome = "rpt_Produto_Inventario.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_Produto", DTR_Produto);

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATÓRIO ESTOQUE COM VALOR
                case 2: //RELATÓRIO ESTOQUE SIMPLES
                case 3: //RELATÓRIO PRODUTO FISCAL
                case 4: //RELATÓRIO INFORMAÇÃO PRODUTO
                case 5: //RELATÓRIO PARA ENTRADA DE PRODUTO
                case 9: //RELATÓRIO PRODUTO INVENTÁRIO
                    rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                    rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);
                    break;

                case 6: //RELATÓRIO TABELA DE VALOR
                case 7: //RELATÓRIO TABELA DE VALOR CODIGO DE BARRAS                   
                    ReportParameter p1 = new ReportParameter("Tabela", cb_ID_Tabela.Text);
                    ReportParameter p2 = new ReportParameter("Informacao", txt_InformacaoAdicional.Text);
                    ReportParameter p3 = new ReportParameter("DataEmissao", util_dados.Config_Data(DateTime.Now, 3).ToString());

                    rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                    rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);
                    rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                    break;
                case 8: //RELATÓRIO ESTOQUE COM VALOR DATA
                    ReportParameter p4 = new ReportParameter("Data", mk_DataInicial.Text);

                    rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                    rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);
                    rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p4 });
                    break;
            }

            rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();

            string rpt_Nome = string.Empty;
            Tipo_Impressao _TipoImpressao = Tipo_Impressao.Retrato;

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
            Produto.GrupoNivel = mk_GrupoNivelP.Text;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_Referencia.Text;
            Produto.Barra = txt_Barra.Text;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1";

            Produto.Consulta_EstoqueCritico = Convert.ToBoolean(ck_EstoqueLimite.Checked);
            Produto.Consulta_EstoqueCompra = Convert.ToBoolean(ck_EstoqueCompra.Checked);

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATÓRIO ESTOQUE COM VALOR
                    rpt_Nome = "rpt_Produto_Estoque_Valor.rdlc";
                    _TipoImpressao = Tipo_Impressao.Paisagem;
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 2: //RELATÓRIO ESTOQUE SIMPLES
                    rpt_Nome = "rpt_Produto_Estoque.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 3: //RELATÓRIO PRODUTO FISCAL
                    rpt_Nome = "rpt_Produto_Fiscal.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 4: //RELATÓRIO INFORMAÇÃO PRODUTO
                    rpt_Nome = "rpt_Produto_Completo.rdlc";
                    DTR_Produto = BLL_Produto.Busca_new(Produto);
                    break;

                case 5: //RELATÓRIO PARA ENTRADA DE PRODUTO
                    rpt_Nome = "rpt_Produto_Entrada.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;

                case 6: //RELATÓRIO TABELA DE VALOR
                    rpt_Nome = "rpt_TabelaValor.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Valor(Produto);
                    break;

                case 7: //RELATÓRIO TABELA DE VALOR CODIGO DE BARRAS
                    rpt_Nome = "rpt_TabelaValor_Barra.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Valor(Produto);
                    break;

                case 8: //RELATÓRIO ESTOQUE COM VALOR DATA
                    rpt_Nome = "rpt_Produto_Estoque_Valor_Data.rdlc";
                    _TipoImpressao = Tipo_Impressao.Paisagem;
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr_Data(Produto);
                    break;

                case 9: //RELATÓRIO PRODUTO INVENTÁRIO
                    rpt_Nome = "rpt_Produto_Inventario.rdlc";
                    DTR_Produto = BLL_Produto.Busca_Estoque_Vlr(Produto);
                    break;
            }

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_Produto", DTR_Produto);

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATÓRIO ESTOQUE COM VALOR
                case 2: //RELATÓRIO ESTOQUE SIMPLES
                case 3: //RELATÓRIO PRODUTO FISCAL
                case 4: //RELATÓRIO INFORMAÇÃO PRODUTO
                case 5: //RELATÓRIO PARA ENTRADA DE PRODUTO
                case 9: //RELATÓRIO PRODUTO INVENTÁRIO
                    rpt.DataSources.Add(ds_Empresa);
                    rpt.DataSources.Add(ds_Produto);
                    break;

                case 6: //RELATÓRIO TABELA DE VALOR
                case 7: //RELATÓRIO TABELA DE VALOR CODIGO DE BARRAS
                    ReportParameter p1 = new ReportParameter("Tabela", cb_ID_Tabela.Text);
                    ReportParameter p2 = new ReportParameter("Informacao", txt_InformacaoAdicional.Text);
                    ReportParameter p3 = new ReportParameter("DataEmissao", util_dados.Config_Data(DateTime.Now, 3).ToString());

                    rpt.DataSources.Add(ds_Empresa);
                    rpt.DataSources.Add(ds_Produto);
                    rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                    break;

                case 8: //RELATÓRIO ESTOQUE COM VALOR DATA
                    ReportParameter p4 = new ReportParameter("Data", mk_DataInicial.Text);

                    rpt.DataSources.Add(ds_Empresa);
                    rpt.DataSources.Add(ds_Produto);
                    rpt.SetParameters(new ReportParameter[] { p4 });
                    break;
            }

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();

            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);
                imp.Imprimir(documento, _TipoImpressao);
                imp = null;
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_GrupoNivel_Consulta frm = new UI_GrupoNivel_Consulta();
            frm.ShowDialog();
            mk_GrupoNivelP.Text = frm.Cod_Conta;
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoRelatorio_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_TipoRelatorio.SelectedValue != null &&
                util_dados.Verifica_int(cb_TipoRelatorio.SelectedValue.ToString()) > 0)
                switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        txt_InformacaoAdicional.Enabled = false;
                        mk_DataInicial.Enabled = false;
                        break;

                    case 6:
                    case 7:
                        txt_InformacaoAdicional.Enabled = true;
                        mk_DataInicial.Enabled = false;
                        break;

                    case 8:
                        txt_InformacaoAdicional.Enabled = false;
                        mk_DataInicial.Enabled = true;
                        break;

                }
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
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_DataInicial.Text = Convert.ToString(DateTime.Now);
                mk_DataInicial.Focus();
            }
        }
        #endregion
    }
}
