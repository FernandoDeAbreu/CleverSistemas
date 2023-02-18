using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_Recibo : Sistema.UI.UI_Modelo
    {
        public UI_Recibo()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;

        DataTable DTTipoPessoa;
        DataTable DTR_Empresa;
        DataTable DTPessoa;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RECIBO";
            TabPage1.Text = "EMISSÃO DE RECIBO";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            tabctl.SelectedTab = TabPage1;

            Carrega_CB();
            cb_TipoRecibo.SelectedIndex = 0;
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
        public override void Visualizar()
        {
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();

            string rpt_Nome = string.Empty;

            if (cb_TipoRecibo.Text == "PAGAMENTO")
            {
                if (ck_2Vias.Checked == true)
                    rpt_Nome = "rpt_Pagamento2.rdlc";
                else
                    rpt_Nome = "rpt_Pagamento.rdlc";
            }
            else
            {
                if (ck_2Vias.Checked == true)
                    rpt_Nome = "rpt_Recibo2.rdlc";
                else
                    rpt_Nome = "rpt_Recibo.rdlc";
            }

            if (Parametro_Venda.TipoImpressoraTermica == 1)
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaImpressaoA4, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    rpt_Nome = "rpt_Recibo_Termica.rdlc";
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_Emitente", DTR_Empresa);

            string Info = Environment.NewLine + txt_Referente.Text;

            string numExtenso = util_dados.ValorExtenso(Convert.ToDecimal(txt_Valor.Text));
            ReportParameter p1 = new ReportParameter("Valor", txt_Valor.Text);
            ReportParameter p2 = new ReportParameter("ValorExtenso", numExtenso.ToUpper());
            ReportParameter p3 = new ReportParameter("Pessoa", cb_ID_Pessoa.Text);
            ReportParameter p4 = new ReportParameter("Informacao", Info);
            ReportParameter p5 = new ReportParameter("Data", Convert.ToString(util_dados.Config_Data(DateTime.Now, 4)).ToUpper());
            ReportParameter p6 = new ReportParameter("Documento", txt_CNPJ_CPF.Text);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

            rpt.rpt_Viewer.RefreshReport();
            rpt.Show();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();
            string rpt_Nome = "";
            if (cb_TipoRecibo.Text == "PAGAMENTO")
            {
                if (ck_2Vias.Checked == true)
                    rpt_Nome = "rpt_Pagamento2.rdlc";
                else
                    rpt_Nome = "rpt_Pagamento.rdlc";
            }
            else
            {
                if (ck_2Vias.Checked == true)
                    rpt_Nome = "rpt_Recibo2.rdlc";
                else
                    rpt_Nome = "rpt_Recibo.rdlc";
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_Emitente", DTR_Empresa);

            string Info = Environment.NewLine + txt_Referente.Text;

            string numExtenso = util_dados.ValorExtenso(Convert.ToDecimal(txt_Valor.Text));
            ReportParameter p1 = new ReportParameter("Valor", txt_Valor.Text);
            ReportParameter p2 = new ReportParameter("ValorExtenso", numExtenso.ToUpper());
            ReportParameter p3 = new ReportParameter("Pessoa", cb_ID_Pessoa.Text);
            ReportParameter p4 = new ReportParameter("Informacao", Info);
            ReportParameter p5 = new ReportParameter("Data", Convert.ToString(util_dados.Config_Data(DateTime.Now, 4)).ToUpper());
            ReportParameter p6 = new ReportParameter("Documento", txt_CNPJ_CPF.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

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
        private void UI_Recibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Valor.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Recibo_Load(object sender, EventArgs e)
        {
            Inicia_Form();

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

        #region BUTTON
        private void UI_Recibo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion
    }
}
