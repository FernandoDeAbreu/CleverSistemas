using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.UTIL;
using Sistema.DTO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Globalization;

namespace Sistema.UI
{
    public partial class UI_FolhaPagto_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_FolhaPagto_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Evento BLL_Evento;
        BLL_FolhaPagto BLL_FolhaPagto;
        BLL_Grupo BLL_Grupo;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_FolhaPagto FolhaPagto;
        DTO_Grupo Grupo;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE FOLHA DE PAGAMENTO";

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Visible = true;
            bt_Imprime.Enabled = true;

            bt_Visualiza.Visible = true;
            bt_Visualiza.Enabled = true;

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;

            Carrega_CB();
        }

        private void Carrega_CB()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = 4;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Pessoa.FiltraSituacao = true;
            Pessoa.Situacao = true;

            DataTable _DT = new DataTable();

            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa_P);
            cb_ID_Pessoa_P.SelectedIndex = -1;

            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            _DT = new DataTable();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_FolhaPagto);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoP);
            cb_TipoP.SelectedIndex = -1;
        }
        #endregion

        #region MODIFICADORES
        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_FolhaPagto_Relatorio.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            FolhaPagto = new DTO_FolhaPagto();
            FolhaPagto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FolhaPagto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa_P.SelectedValue);
            FolhaPagto.Periodo = Convert.ToDateTime(@"01/" + mk_Periodo_P.Text);
            FolhaPagto.Tipo = Convert.ToInt32(cb_TipoP.SelectedValue);

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_Evento = new DataTable();
            DataTable _DT_Resumo = new DataTable();

            BLL_FolhaPagto = new BLL_FolhaPagto();
            _DT_Evento = BLL_FolhaPagto.Busca_Relatorio(FolhaPagto);
            _DT_Resumo = BLL_FolhaPagto.Busca_Resumo(FolhaPagto);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Eventos = new ReportDataSource("ds_FolhaPagto", _DT_Evento);
            ReportDataSource ds_Resumo = new ReportDataSource("ds_Resumo", _DT_Resumo);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Eventos);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Resumo);

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_FolhaPagto_Relatorio.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            FolhaPagto = new DTO_FolhaPagto();
            FolhaPagto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FolhaPagto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa_P.SelectedValue);
            FolhaPagto.Periodo = Convert.ToDateTime(@"01/" + mk_Periodo_P.Text);
            FolhaPagto.Tipo = Convert.ToInt32(cb_TipoP.SelectedValue);

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_Evento = new DataTable();
            DataTable _DT_Resumo = new DataTable();

            BLL_FolhaPagto = new BLL_FolhaPagto();
            _DT_Evento = BLL_FolhaPagto.Busca_Relatorio(FolhaPagto);
            _DT_Resumo = BLL_FolhaPagto.Busca_Resumo(FolhaPagto);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Eventos = new ReportDataSource("ds_FolhaPagto", _DT_Evento);
            ReportDataSource ds_Resumo = new ReportDataSource("ds_Resumo", _DT_Resumo);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Eventos);
            rpt.DataSources.Add(ds_Resumo);

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

        #region  FORM
        private void UI_FolhaPagto_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region MASKETBOX
        private void mk_Periodo_P_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact("01/" + mk_Periodo_P.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_Periodo_P.Text = util_dados.Config_Data(DateTime.Now, 19).ToString();
                mk_Periodo_P.Focus();
            }
        }
        #endregion
    }
}
