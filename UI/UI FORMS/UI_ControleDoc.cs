using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.UTIL;
using Sistema.DTO;

namespace Sistema.UI
{
    public partial class UI_ControleDoc : Sistema.UI.UI_Modelo
    {
        public UI_ControleDoc()
        {
            InitializeComponent();
        }

        #region PROPRIEDADES
        /// <summary>
        /// <para>1 - GRAVA CONFIG</para>
        /// <para>2 - GRAVA CONTROLE</para>
        /// </summary>
        public int Tipo { get; set; }
        #endregion

        #region VARIAVEIS DE CLASSE
        BLL_ControleDoc BLL_ControleDoc;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTR_Empresa;

        DataRow DR;

        int obj;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURAS
        DTO_ControleDoc ControleDoc;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            mk_Periodo.Text = Convert.ToString(DateTime.Now.ToString().Substring(3, 7));
            mk_PeriodoP.Text = Convert.ToString(DateTime.Now.ToString().Substring(3, 7));

            bt_Novo.Visible = false;
            bt_Exclui.Visible = false;

            bt_Imprime.Visible = true;
            bt_Visualiza.Visible = true;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            bt_Edita.Visible = false;

            switch (Tipo)
            {
                case 1:
                    this.Text = "CONTROLE DE DOCUMENTOS - TIPOS";
                    tabctl.TabPages.Remove(TabPage1);
                    tabctl.TabPages.Remove(TabPage2);
                    Carrega_Doc();
                    break;

                case 2:
                    this.Text = "CONTROLE DE DOCUMENTOS";
                    tabctl.TabPages.Remove(TabPage2);
                    tabctl.TabPages.Remove(tabPage3);
                    break;
            }

            CarregaPessoa();
        }

        private void Carrega_Doc_Entrada()
        {
            string TipoDocumento = "";

            BLL_ControleDoc = new BLL_ControleDoc();
            ControleDoc = new DTO_ControleDoc();

            ControleDoc.TipoPessoa = 1;
            ControleDoc.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            ControleDoc.Entregue = ck_ExibeEntregue.Checked;

            ControleDoc.ConsultaPeriodo.Filtra = true;
            ControleDoc.ConsultaPeriodo.Inicial = Convert.ToDateTime(@"01/" + mk_PeriodoP.Text);
            ControleDoc.ConsultaPeriodo.Final = Convert.ToDateTime(@"01/" + mk_PeriodoP.Text);

            DataTable _DT = new DataTable();
            _DT = BLL_ControleDoc.Busca(ControleDoc);

            ListViewGroup grupo1 = default(ListViewGroup);
            ListViewItem item1 = default(ListViewItem);

            lts_menu.Columns.Add("Documento", 500, HorizontalAlignment.Left);

            foreach (DataRow DR in _DT.Rows)
            {
                if (TipoDocumento != DR["TipoDocumento"].ToString())
                    grupo1 = new ListViewGroup(DR["TipoDocumento"].ToString());

                TipoDocumento = DR["TipoDocumento"].ToString();

                item1 = new ListViewItem(DR["Documento"].ToString(), grupo1);
                lts_menu.Groups.AddRange(new ListViewGroup[] { grupo1 });
                item1.Tag = DR["ID"];

                if (Convert.ToBoolean(DR["Entregue"]) == true)
                    item1.Checked = true;
                else
                    item1.Checked = false;

                lts_menu.Items.AddRange(new ListViewItem[] { item1 });
            }
        }

        private void Carrega_Doc_Config()
        {
            BLL_ControleDoc = new BLL_ControleDoc();
            ControleDoc = new DTO_ControleDoc();

            ControleDoc.TipoPessoa = 1;
            ControleDoc.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

            ControleDoc.ConsultaPeriodo.Filtra = true;
            ControleDoc.ConsultaPeriodo.Inicial = Convert.ToDateTime(@"01/" + mk_Periodo.Text);
            ControleDoc.ConsultaPeriodo.Final = Convert.ToDateTime(Convert.ToString(Convert.ToDateTime(@"01/" + mk_Periodo.Text).AddMonths(1).AddDays(-1)));

            DataTable _DT = new DataTable();
            _DT = BLL_ControleDoc.Busca(ControleDoc);

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    for (int ii = 0; ii <= dg_Config_Doc.Rows.Count - 1; ii++)
                        if (dg_Config_Doc.Rows[ii].Cells["col_ID_Doc"].Value != null && Convert.ToInt32(_DT.Rows[i]["ID_Documento"]) == Convert.ToInt32(dg_Config_Doc.Rows[ii].Cells["col_ID_Doc"].Value))
                        {
                            dg_Config_Doc.Rows[ii].Cells["col_ID"].Value = _DT.Rows[i]["ID"];
                            dg_Config_Doc.Rows[ii].Cells["col_Seleciona"].Value = true;
                        }
        }

        private void Carrega_Doc()
        {
            dg_Config_Doc.Rows.Clear();

            BLL_ControleDoc = new BLL_ControleDoc();
            ControleDoc = new DTO_ControleDoc();

            DataTable _DT = new DataTable();
            _DT = BLL_ControleDoc.Busca_Config(ControleDoc);

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    dg_Config_Doc.Rows.Add();
                    dg_Config_Doc.Rows[i].Cells["col_Tipo"].Value = _DT.Rows[i]["TipoDocumento"];
                    dg_Config_Doc.Rows[i].Cells["col_Documento"].Value = _DT.Rows[i]["Documento"];
                    dg_Config_Doc.Rows[i].Cells["col_ID_Doc"].Value = _DT.Rows[i]["ID_Doc"];
                }
        }

        public void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = 1;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DataTable _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);

                _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PessoaP);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            #region GRAVA CONTROLE
            if (Tipo == 1)
            {
                DateTime Periodo = Convert.ToDateTime(@"01/" + mk_Periodo.Text);

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaInfo, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_ControleDoc = new BLL_ControleDoc();
                ControleDoc = new DTO_ControleDoc();
                ControleDoc.Documento = new DTO_ControleDoc_Tipo();
                try
                {
                    //  DataTable _DT = new DataTable();
                    //  _DT = BLL_ControleDoc.Busca_Config(ControleDoc);

                    for (int ii = 0; ii < Convert.ToInt32(txt_QuantidadeLancar.Text); ii++)
                    {
                        for (int i = 0; i <= dg_Config_Doc.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_Config_Doc.Rows[i].Cells["col_Seleciona"].Value) == true)
                            {
                                if (dg_Config_Doc.Rows[i].Cells["col_ID"].Value == null)
                                {
                                    ControleDoc.Documento.ID = Convert.ToInt32(dg_Config_Doc.Rows[i].Cells["col_ID_Doc"].Value);
                                    ControleDoc.TipoPessoa = 1;
                                    ControleDoc.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                                    ControleDoc.Periodo = Periodo;
                                    ControleDoc.Entregue = false;

                                    int fd = BLL_ControleDoc.Grava(ControleDoc);
                                }
                            }
                            else
                            {
                                if (dg_Config_Doc.Rows[i].Cells["col_ID"].Value != null)
                                {
                                    ControleDoc.ID = Convert.ToInt32(dg_Config_Doc.Rows[i].Cells["col_ID"].Value);

                                    BLL_ControleDoc.Exclui(ControleDoc);
                                }
                            }

                        Periodo = Periodo.AddMonths(1);
                    }

                    MessageBox.Show(util_msg.msg_Grava, this.Text);

                    Carrega_Doc();
                    Carrega_Doc_Config();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
                }
            }
            #endregion

            #region BAIXA DOCUMENTO
            if (Tipo == 2)
            {
                BLL_ControleDoc = new BLL_ControleDoc();
                ControleDoc = new DTO_ControleDoc();
                ControleDoc.Documento = new DTO_ControleDoc_Tipo();

                for (int i = 0; i <= lts_menu.Items.Count - 1; i++)
                    if (lts_menu.Items[i].Checked == true)
                    {
                        ControleDoc.ID = Convert.ToInt32(lts_menu.Items[i].Tag);
                        ControleDoc.DataEntrada = DateTime.Now;
                        ControleDoc.Entregue = true;

                        BLL_ControleDoc.Baixa(ControleDoc);
                    }
                    else
                    {
                        ControleDoc.ID = Convert.ToInt32(lts_menu.Items[i].Tag);
                        ControleDoc.DataEntrada = DateTime.Now;
                        ControleDoc.Entregue = false;

                        BLL_ControleDoc.Baixa(ControleDoc);
                    }

                MessageBox.Show(util_msg.msg_Baixa, this.Text);

                lts_menu.Clear();
                Carrega_Doc_Entrada();
            }
            #endregion

            Status = StatusForm.Edita;
            Config_Botao();
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = "rpt_Check_Documento.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_ControleDoc = new BLL_ControleDoc();
            ControleDoc = new DTO_ControleDoc();

            ControleDoc.TipoPessoa = 1;
            ControleDoc.Entregue = ck_ExibeEntregue.Checked;

            if (Tipo == 1)
            {
                ControleDoc.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                ControleDoc.ConsultaPeriodo.Filtra = true;
                ControleDoc.ConsultaPeriodo.Inicial = Convert.ToDateTime(@"01/" + mk_Periodo.Text);
                ControleDoc.ConsultaPeriodo.Final = Convert.ToDateTime(@"01/" + mk_Periodo.Text);
            }
            if (Tipo == 2)
            {
                ControleDoc.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                ControleDoc.ConsultaPeriodo.Filtra = true;
                ControleDoc.ConsultaPeriodo.Inicial = Convert.ToDateTime(@"01/" + mk_PeriodoP.Text);
                ControleDoc.ConsultaPeriodo.Final = Convert.ToDateTime(@"01/" + mk_PeriodoP.Text);
            }
            // ControleDoc.Entregue = false;

            DataTable _DT = new DataTable();
            _DT = BLL_ControleDoc.Busca(ControleDoc);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Documento = new ReportDataSource("ds_Documento", _DT);

            ReportParameter p1 = null;

            if (Tipo == 1)
                p1 = new ReportParameter("Pessoa", cb_ID_PessoaP.Text);

            if (Tipo == 2)
                p1 = new ReportParameter("Pessoa", cb_ID_Pessoa.Text);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Documento);

            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

            rpt.rpt_Viewer.RefreshReport();
            rpt.Show();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();
            string rpt_Nome = "rpt_Check_Documento.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_ControleDoc = new BLL_ControleDoc();
            ControleDoc = new DTO_ControleDoc();

            ControleDoc.TipoPessoa = 1;
            ControleDoc.Entregue = ck_ExibeEntregue.Checked;

            if (Tipo == 1)
            {
                ControleDoc.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                ControleDoc.ConsultaPeriodo.Filtra = true;
                ControleDoc.ConsultaPeriodo.Inicial = Convert.ToDateTime(@"01/" + mk_Periodo.Text);
                ControleDoc.ConsultaPeriodo.Final = Convert.ToDateTime(@"01/" + mk_Periodo.Text);
            }
            if (Tipo == 2)
            {
                ControleDoc.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                ControleDoc.ConsultaPeriodo.Filtra = true;
                ControleDoc.ConsultaPeriodo.Inicial = Convert.ToDateTime(@"01/" + mk_PeriodoP.Text);
                ControleDoc.ConsultaPeriodo.Final = Convert.ToDateTime(@"01/" + mk_PeriodoP.Text);
            }
            //ControleDoc.Entregue = false;

            DataTable _DT = new DataTable();
            _DT = BLL_ControleDoc.Busca(ControleDoc);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Documento = new ReportDataSource("ds_Documento", _DT);

            ReportParameter p1 = null;

            if (Tipo == 1)
                p1 = new ReportParameter("Pessoa", cb_ID_PessoaP.Text);

            if (Tipo == 2)
                p1 = new ReportParameter("Pessoa", cb_ID_Pessoa.Text);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Documento);

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

        public override void Pesquisa()
        {
            switch (Tipo)
            {
                case 1:
                    Carrega_Doc();
                    Carrega_Doc_Config();
                    break;

                case 2:
                    lts_menu.Clear();
                    Carrega_Doc_Entrada();
                    break;
            }
        }
        #endregion

        #region FORM
        private void UI_ControleDoc_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_ControleDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_QuantidadeLancar.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_ControleDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
               tabctl.SelectedTab == TabPage1)
                Pesquisa();
        }
        #endregion

        #region MASKEDBOX
        private void mk_Periodo_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact((@"01/" + mk_Periodo.Text).ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Perído Inválido!", "Erro");
                mk_Periodo.Text = Convert.ToString(DateTime.Now.ToString().Substring(3, 7));
                mk_Periodo.Focus();
            }
           
        }

        private void mk_PeriodoP_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact((@"01/" + mk_PeriodoP.Text).ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Perído Inválido!", "Erro");
                mk_PeriodoP.Text = Convert.ToString(DateTime.Now.ToString().Substring(3, 7));
                mk_PeriodoP.Focus();
            }
           

        }
        #endregion

        #region BUTTON
        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_Pessoa_Consulta frm = new UI_Pessoa_Consulta();
            frm.TipoPessoa = 1;

            frm.ShowDialog();

            if (frm.ID_Pessoa == 0)
                return;

            cb_ID_Pessoa.SelectedValue = frm.ID_Pessoa;

            cb_ID_Pessoa.Focus();
        }
        #endregion
    }
}
