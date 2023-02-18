using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using Sistema.UTIL;
using Sistema.DTO;
using Sistema.BLL;

namespace Sistema.UI
{
    public partial class UI_NFe_CFe_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_NFe_CFe_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_NF BLL_NF;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;

        DataRow DR;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_NF NF;
        #endregion

        #region PROPRIEDADES
        public Tipo_NF_SAT Tipo { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            switch (Tipo)
            {
                case Tipo_NF_SAT.NFe:
                    this.Text = "CONTROLE DE EMISSÃO NOTA FISCAL (NF-e)";
                    break;

                case Tipo_NF_SAT.SAT:
                    this.Text = "CONTROLE DE EMISSÃO CUPOM FISCAL (CF-e SAT)";
                    break;
            }

            tabctl.TabPages.Remove(TabPage2);

            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            mk_DataInicial.Text = util_dados.Config_Data(DateTime.Now, 11).ToString();
            mk_DataFinal.Text = util_dados.Config_Data(DateTime.Now, 12).ToString();

            CarregaCB();
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PessoaP);
                cb_ID_PessoaP.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void CarregaCB()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();

            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;
            List<string> aux;

            switch (Tipo)
            {
                case Tipo_NF_SAT.NFe:
                    _DT = new DataTable();

                    aux = new List<string> { "TODAS", "ASSINADA", "AUTORIZADA",
                                                  "CANCELADA", "DENEGADA", "EM DIGITAÇÃO",
                                                  "VALIDADA", "EM PROCESSAMENTO" };

                    _DT = util_dados.CarregaComboDinamico(0, aux);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_SituacaoNFeP);
                    cb_SituacaoNFeP.SelectedIndex = -1;
                    break;

                case Tipo_NF_SAT.SAT:
                    _DT = new DataTable();
                    _DT.Columns.Add("ID");
                    _DT.Columns.Add("Descricao");

                    DR = _DT.NewRow();
                    DR["ID"] = "0";
                    DR["Descricao"] = "TODAS";

                    _DT.Rows.Add(DR);

                    DR = _DT.NewRow();
                    DR["ID"] = "3";
                    DR["Descricao"] = "CANCELADA";

                    _DT.Rows.Add(DR);

                    DR = _DT.NewRow();
                    DR["ID"] = "7";
                    DR["Descricao"] = "EM PROCESSAMENTO";

                    _DT.Rows.Add(DR);

                    DR = _DT.NewRow();
                    DR["ID"] = "8";
                    DR["Descricao"] = "CF-e AUTORIZADO";

                    _DT.Rows.Add(DR);

                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_SituacaoNFeP);
                    cb_SituacaoNFeP.SelectedIndex = -1;
                    break;
            }

            aux = new List<string> {"1 - RELATÓRIO DE (NF-e / CF-e) EMITIDOS",
                                    "2 - RELATÓRIO DE (NF-e / CF-e) EMITIDOS CFOP" ,
                                    "3 - RELATÓRIO DE QUANTIDADE DE PRODUTOS EMITIDOS NF-e/CF-e" };

            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoRelatorio);
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

            CarregaPessoa();
            cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_PessoaP.Focus();
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {
            string rpt_Nome = string.Empty;

            LocalReport rpt = new LocalReport();

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            NF.Consulta_Emissao.Filtra = true;
            NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            NF.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            NF.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            NF.Serie = util_dados.Verifica_int(txt_Serie.Text);
            NF.ID_NFe = util_dados.Verifica_int(txt_ID_NFeP.Text);
            NF.Situacao = Convert.ToInt32(cb_SituacaoNFeP.SelectedValue);
            NF.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
            NF.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

            switch (Tipo)
            {
                case Tipo_NF_SAT.NFe:
                    NF.Modelo = 55;
                    break;

                case Tipo_NF_SAT.SAT:
                    NF.Modelo = 59;
                    break;
            }

            DataTable DTR_NF = new DataTable();

            ReportDataSource ds_NF = new ReportDataSource();

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATÓRIO SIMPLES
                    rpt_Nome = "rpt_NFe.rdlc";
                    DTR_NF = BLL_NF.Busca_NF_Relatorio(NF);

                    ds_NF = new ReportDataSource("ds_NF", DTR_NF);

                    break;

                case 2: //RELATÓRIO POR DIA
                    rpt_Nome = "rpt_NFe_CFOP.rdlc";
                    DTR_NF = BLL_NF.Busca_NF_Relatorio_CFOP(NF);

                    ds_NF = new ReportDataSource("ds_NF", DTR_NF);
                    break;

                case 3: //RELATÓRIO POR DIA
                    rpt_Nome = "rpt_NFe_Produto.rdlc";
                    DTR_NF = BLL_NF.Busca_NF_Relatorio_Produto(NF);

                    ds_NF = new ReportDataSource("ds_Produto", DTR_NF);
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);

            ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_NF);

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

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            rpt.Show();

            string rpt_Nome = string.Empty;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            NF.Consulta_Emissao.Filtra = true;
            NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            NF.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            NF.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            NF.Serie = util_dados.Verifica_int(txt_Serie.Text);
            NF.ID_NFe = util_dados.Verifica_int(txt_ID_NFeP.Text);
            NF.Situacao = Convert.ToInt32(cb_SituacaoNFeP.SelectedValue);
            NF.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
            NF.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

            switch (Tipo)
            {
                case Tipo_NF_SAT.NFe:
                    NF.Modelo = 55;
                    break;

                case Tipo_NF_SAT.SAT:
                    NF.Modelo = 59;
                    break;
            }

            DataTable DTR_NF = new DataTable();

            ReportDataSource ds_NF = new ReportDataSource();

            switch (Convert.ToInt32(cb_TipoRelatorio.SelectedValue))
            {
                case 1: //RELATÓRIO SIMPLES
                    rpt_Nome = "rpt_NFe.rdlc";
                    DTR_NF = BLL_NF.Busca_NF_Relatorio(NF);

                     ds_NF = new ReportDataSource("ds_NF", DTR_NF);

                    break;

                case 2: //RELATÓRIO POR DIA
                    rpt_Nome = "rpt_NFe_CFOP.rdlc";
                    DTR_NF = BLL_NF.Busca_NF_Relatorio_CFOP(NF);

                     ds_NF = new ReportDataSource("ds_NF", DTR_NF);
                    break;

                case 3: //RELATÓRIO POR DIA
                    rpt_Nome = "rpt_NFe_Produto.rdlc";
                    DTR_NF = BLL_NF.Busca_NF_Relatorio_Produto(NF);

                    ds_NF = new ReportDataSource("ds_Produto", DTR_NF);
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);

            ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_NF);

            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

            rpt.rpt_Viewer.RefreshReport();
        }
        #endregion

        private void UI_NFe_CFe_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void cb_TipoPessoaP_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }

        private void UI_NFe_CFe_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }

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
    }
}
