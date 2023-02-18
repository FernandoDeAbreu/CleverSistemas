using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Imovel_ContratoServico : Sistema.UI.UI_Modelo
    {
        public UI_Imovel_ContratoServico()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Imovel_ContratoServico BLL_Imovel_ContratoServico;

        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Imovel_ContratoServico ContratoServico;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONTRATO PRESTAÇÃO DE SERVIÇO";

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 80;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "DESCRIÇÃO";
            col_Descricao.Width = 200;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;
        }

        private void Carrega_CB()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            cb_ID_Proprietario.DataSource = null;

            Pessoa.TipoPessoa = 7;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();

            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Proprietario);
            cb_ID_Proprietario.SelectedIndex = -1;

            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa_P);
            cb_ID_Pessoa_P.SelectedIndex = -1;
        }

        private void Limpa_Campo()
        {
            mk_Emissao.Text = DateTime.Now.ToString();
            cb_ID_Proprietario.Focus();
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = 7;

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            if (UI_Pessoa_Consulta.TipoPessoa != 7)
                return;

            if (tabctl.SelectedTab == TabPage1)
            {
                cb_ID_Proprietario.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_Proprietario.Focus();
            }

            if (tabctl.SelectedTab == TabPage2)
            {
                cb_ID_Pessoa_P.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_Pessoa_P.Focus();
            }
        }
        #endregion

        #region FORM
        private void UI_Imovel_Contrato_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            Carrega_CB();
        }

        private void UI_Imovel_ContratoServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Imovel_ContratoServico = new BLL_Imovel_ContratoServico();
                ContratoServico = new DTO_Imovel_ContratoServico();

                ContratoServico.ID = util_dados.Verifica_int(txt_ID.Text);
                ContratoServico.ID_Proprietario = util_dados.Verifica_int(cb_ID_Proprietario.SelectedValue.ToString());
                ContratoServico.Emissao = Convert.ToDateTime(mk_Emissao.Text);
                ContratoServico.Descricao_Test1 = txt_Descricao_Test1.Text;
                ContratoServico.Descricao_Test2 = txt_Descricao_Test2.Text;
                ContratoServico.Doc_Test1 = txt_Doc_Test1.Text;
                ContratoServico.Doc_Test2 = txt_Doc_Test2.Text;

                obj = BLL_Imovel_ContratoServico.Grava(ContratoServico);

                if (obj > 0)
                    Config(StatusForm.Consulta);

                if (obj > 0)
                {
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            Limpa_Campo();
        }

        public override void Pesquisa()
        {
            BLL_Imovel_ContratoServico = new BLL_Imovel_ContratoServico();
            ContratoServico = new DTO_Imovel_ContratoServico();

            ContratoServico.ID = util_dados.Verifica_int(txt_ID_P.Text);
            ContratoServico.ID_Proprietario = Convert.ToInt32(cb_ID_Pessoa_P.SelectedValue);

            DataTable _DT = new DataTable();
            _DT = BLL_Imovel_ContratoServico.Busca(ContratoServico);

            DG.DataSource = _DT;
            util_dados.CarregaCampo(this, _DT, gb_Cadastro);
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();
            string rpt_Nome = "rpt_Imovel_ContratoServico.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            BLL_Imovel_ContratoServico = new BLL_Imovel_ContratoServico();

            Pessoa = new DTO_Pessoa();

            DataTable _DT = new DataTable();
            DataTable DT_Empresa = new DataTable();
            DataTable DT_Proprietario = new DataTable();

            string lst_ID = string.Empty;

            //BUSCA INFORMACAO EMPRESA
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
            DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            #region BUSCA Proprietario

            Pessoa = new DTO_Pessoa();
            Pessoa.TipoPessoa = 7;
            Pessoa.ID = Convert.ToInt32(cb_ID_Proprietario.SelectedValue);

            DT_Proprietario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
            #endregion

            ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
            ReportDataSource ds_Proprietario = new ReportDataSource("ds_Proprietario", DT_Proprietario);

            ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4).ToString());
            ReportParameter p2 = new ReportParameter("Descricao_Test1", txt_Descricao_Test1.Text);
            ReportParameter p3 = new ReportParameter("Descricao_Test2", txt_Descricao_Test2.Text);
            ReportParameter p4 = new ReportParameter("Doc_Test1", txt_Doc_Test1.Text);
            ReportParameter p5 = new ReportParameter("Doc_Test2", txt_Doc_Test2.Text);
            ReportParameter p6 = new ReportParameter("NumeroContrato", txt_ID.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Proprietario);

            rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

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
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = "rpt_Imovel_ContratoServico.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            BLL_Imovel_ContratoServico = new BLL_Imovel_ContratoServico();

            Pessoa = new DTO_Pessoa();

            DataTable _DT = new DataTable();
            DataTable DT_Empresa = new DataTable();
            DataTable DT_Proprietario = new DataTable();

            string lst_ID = string.Empty;

            //BUSCA INFORMACAO EMPRESA
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
            DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            #region BUSCA Proprietario

            Pessoa = new DTO_Pessoa();
            Pessoa.TipoPessoa = 7;
            Pessoa.ID = Convert.ToInt32(cb_ID_Proprietario.SelectedValue);

            DT_Proprietario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
            #endregion

            ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
            ReportDataSource ds_Proprietario = new ReportDataSource("ds_Proprietario", DT_Proprietario);

            ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4).ToString());
            ReportParameter p2 = new ReportParameter("Descricao_Test1", txt_Descricao_Test1.Text);
            ReportParameter p3 = new ReportParameter("Descricao_Test2", txt_Descricao_Test2.Text);
            ReportParameter p4 = new ReportParameter("Doc_Test1", txt_Doc_Test1.Text);
            ReportParameter p5 = new ReportParameter("Doc_Test2", txt_Doc_Test2.Text);
            ReportParameter p6 = new ReportParameter("NumeroContrato", txt_ID.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Proprietario);

            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 }); frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);

            frm_rpt.rpt_Viewer.RefreshReport();
            frm_rpt.Show();
        }

        public override void Excluir()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_Imovel_ContratoServico = new BLL_Imovel_ContratoServico();
                ContratoServico = new DTO_Imovel_ContratoServico();

                ContratoServico.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Imovel_ContratoServico.Exclui(ContratoServico);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Config(StatusForm.Consulta);
        }
        #endregion
    }
}
