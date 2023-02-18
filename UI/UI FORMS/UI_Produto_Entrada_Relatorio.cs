using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_Entrada_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Entrada_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        BLL_Produto_Entrada BLL_Produto_Entrada;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTUsuario;
        DataTable DTPessoa;

        DataTable DTR_Empresa;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_GrupoNivel GrupoNivel;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_TabelaValor TabelaValor;
        DTO_Pagamento Pagamento;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Usuario Usuario;
        DTO_Produto_Entrada Produto_Entrada;
        DTO_Produto_Item Produto_Item;
        DTO_Pagamento_Lanca Pagamento_Lanca;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE ENTRADA DE PRODUTOS";

            tabctl.TabPages.Remove(TabPage2);
            TabPage1.Text = "RELATÓRIOS";

            bt_Imprime.Visible = true;
            bt_Visualiza.Visible = true;
            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            mk_DataInicial.Text = util_dados.Config_Data(DateTime.Now, 11).ToString();
            mk_DataFinal.Text = util_dados.Config_Data(DateTime.Now, 12).ToString();
        }

        public void CarregaCB()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();
            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Comissao = true;
            Usuario.Comissao = true;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

            DataTable _DT = new DataTable();
            List<string> aux = new List<string>();
            aux.Add("RESUMO DE ENTRADA SIMPLIFICADO");
            aux.Add("RESUMO DE ENTRADA DETALHADO");

            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoRelatorio);
            cb_TipoRelatorio.SelectedIndex = 0;

            _DT = new DataTable();
            aux = new List<string> { "EMISSÃO" };
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;

            _DT = new DataTable();
            aux = new List<string> { "TODOS", "FATURADOS/FINALIZADOS", "NÃO FATURADOS/FINALIZADOS" };
            _DT = util_dados.CarregaComboDinamico(0, aux);

            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);

            _DT = new DataTable();
            aux = new List<string> { "TODOS", "COMPRA DE PRODUTOS", "ENTRADA DE PRODUÇÃO" };
            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo_Entrada);
        }

        public void CarregaPessoa()
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
            try
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = string.Empty;

                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    case 1:
                        rpt_Nome = "rpt_Produto_Entrada_Simples.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_Produto_Entrada_Detalhado.rdlc";
                        break;
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Produto_Entrada = new BLL_Produto_Entrada();
                Produto_Entrada = new DTO_Produto_Entrada();

                Produto_Entrada.ID = util_dados.Verifica_int(txt_ID.Text);
                Produto_Entrada.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto_Entrada.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Produto_Entrada.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Produto_Entrada.Tipo_Entrada = Convert.ToInt32(cb_Tipo_Entrada.SelectedValue);

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    Produto_Entrada.Pesquisa_Faturado = true;

                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                        Produto_Entrada.Faturado = true;
                    else
                        Produto_Entrada.Faturado = false;
                }

                switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        Produto_Entrada.Consulta_Emissao.Filtra = true;
                        Produto_Entrada.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Produto_Entrada.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                }

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalEntrada;
                ReportDataSource ds_ResumoProduto;

                ReportParameter p1;

                DataTable _DT;
                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    #region RESUMO PRODUTO ENTRADA
                    case 1:

                        _DT = BLL_Produto_Entrada.Busca_Produto_Entrada_Simplificado(Produto_Entrada);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_TotalEntrada = new ReportDataSource("ds_ResumoEntrada", _DT);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_TotalEntrada);

                        rpt.SetParameters(new ReportParameter[] { p1 });
                        break;
                    #endregion

                    #region RESUMO PRODUTO
                    case 2:
                        _DT = BLL_Produto_Entrada.Busca_Produto_Entrada_Detalhado(Produto_Entrada);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoProduto = new ReportDataSource("ds_ResumoEntrada", _DT);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoProduto);

                        rpt.SetParameters(new ReportParameter[] { p1 });
                        break;
                        #endregion
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
                rpt.Show();

                string rpt_Nome = string.Empty;

                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    case 1:
                        rpt_Nome = "rpt_Produto_Entrada_Simples.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_Produto_Entrada_Detalhado.rdlc";
                        break;
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Produto_Entrada = new BLL_Produto_Entrada();
                Produto_Entrada = new DTO_Produto_Entrada();

                Produto_Entrada.ID = util_dados.Verifica_int(txt_ID.Text);
                Produto_Entrada.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto_Entrada.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Produto_Entrada.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Produto_Entrada.Tipo_Entrada = Convert.ToInt32(cb_Tipo_Entrada.SelectedValue);

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    Produto_Entrada.Pesquisa_Faturado = true;

                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                        Produto_Entrada.Faturado = true;
                    else
                        Produto_Entrada.Faturado = false;
                }

                switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        Produto_Entrada.Consulta_Emissao.Filtra = true;
                        Produto_Entrada.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Produto_Entrada.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                }

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalVenda;
                ReportDataSource ds_ResumoProduto;
                ReportDataSource ds_ResumoPedido;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;
                ReportParameter p4;

                DataTable _DT = new DataTable();
                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    #region RESUMO ENTRADA
                    case 1:
                        _DT = BLL_Produto_Entrada.Busca_Produto_Entrada_Simplificado(Produto_Entrada);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_TotalVenda = new ReportDataSource("ds_ResumoEntrada", _DT);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_TotalVenda);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });
                        break;
                    #endregion

                    #region RESUMO PRODUTO ENTRADA
                    case 2:
                        _DT = BLL_Produto_Entrada.Busca_Produto_Entrada_Detalhado(Produto_Entrada);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoProduto = new ReportDataSource("ds_ResumoEntrada", _DT);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoProduto);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });
                        break;
                        #endregion
                }
                rpt.rpt_Viewer.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Venda_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();

            CarregaCB();
        }

        private void UI_Venda_Relatorio_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void UI_Venda_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
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
