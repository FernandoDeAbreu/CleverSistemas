using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Duplicata : Sistema.UI.UI_Modelo
    {
        public UI_Duplicata()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;

        DataTable DTR_Empresa;
        DataTable DTPessoa;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "DUPLICATA";
            TabPage1.Text = "EMISSÃO DE DUPLICATA";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            mk_Emissao.Text = DateTime.Now.ToString();
            mk_Vencimento.Text = DateTime.Now.ToString();

            tabctl.SelectedTab = TabPage1;

            Carrega_CB();
        }

        private void Carrega_CB()
        {
            DataTable _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = 0;
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

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
            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_Duplicata.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            DataTable _DT = new DataTable();

            Pessoa.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
            Pessoa.ID = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);

            string numExtenso = util_dados.ValorExtenso(Convert.ToDecimal(txt_Valor.Text));

            ReportParameter p1 = new ReportParameter("NumeroFatura", txt_Documento.Text);
            ReportParameter p2 = new ReportParameter("Valor", txt_Valor.Text);
            ReportParameter p3 = new ReportParameter("ValorExtenso", numExtenso);
            ReportParameter p4 = new ReportParameter("NumeroDuplicata", txt_Duplicata.Text);
            ReportParameter p5 = new ReportParameter("Vencimento", mk_Vencimento.Text);
            ReportParameter p6 = new ReportParameter("Observacao", txt_Observacao.Text);
            ReportParameter p7 = new ReportParameter("DataEmissao", Convert.ToString(util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4)));

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7 });

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

            string rpt_Nome = "rpt_Duplicata.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            DataTable _DT = new DataTable();

            Pessoa.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
            Pessoa.ID = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);

            string numExtenso = util_dados.ValorExtenso(Convert.ToDecimal(txt_Valor.Text));

            ReportParameter p1 = new ReportParameter("NumeroFatura", txt_Documento.Text);
            ReportParameter p2 = new ReportParameter("Valor", txt_Valor.Text);
            ReportParameter p3 = new ReportParameter("ValorExtenso", numExtenso);
            ReportParameter p4 = new ReportParameter("NumeroDuplicata", txt_Duplicata.Text);
            ReportParameter p5 = new ReportParameter("Vencimento", mk_Vencimento.Text);
            ReportParameter p6 = new ReportParameter("Observacao", txt_Observacao.Text);
            ReportParameter p7 = new ReportParameter("DataEmissao", Convert.ToString(util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4)));

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7 });
            rpt.rpt_Viewer.RefreshReport();
        }

        #endregion

        #region FORM
        private void UI_Duplicata_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Duplicata_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (txt_Valor.Text.Trim() == string.Empty)
                txt_Valor.Text = "0";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }

        private void cb_ID_Pessoa_Leave(object sender, EventArgs e)
        {
            if (cb_ID_Pessoa.SelectedValue == null)
                txt_CNPJ_CPF.Text = string.Empty;
            else
            {
                int ID = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());
                if (ID > 0)
                {
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                    Pessoa.ID = ID;
                    Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    DTPessoa = BLL_Pessoa.Busca(Pessoa);

                    if (DTPessoa.Rows.Count == 1)
                        txt_CNPJ_CPF.Text = DTPessoa.Rows[0]["CNPJ_CPF"].ToString();
                }
            }
        }
        #endregion

        #region MASKEDBOX
        private void mk_Emissao_Leave(object sender, EventArgs e)
        {
            if (mk_Emissao.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

            DateTime.TryParseExact(mk_Emissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Emissao.Text = Convert.ToString(DateTime.Now);
                mk_Emissao.Focus();
            }
        }

        private void mk_Vencimento_Leave(object sender, EventArgs e)
        {
            if (mk_Vencimento.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

            DateTime.TryParseExact(mk_Vencimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Vencimento.Text = Convert.ToString(DateTime.Now);
                mk_Vencimento.Focus();
            }
        }
        #endregion


    }
}
