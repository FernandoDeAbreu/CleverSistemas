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
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Venda_Transporte : Sistema.UI.UI_Modelo
    {
        public UI_Venda_Transporte()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Venda BLL_Venda;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS VARIAVEIS
        DataTable DTRelatorio;
        DataTable DTR_Empresa;

        bool Seleciona;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Venda Venda;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE PRODUTOS PARA TRANSPORTE";
            TabPage1.Text = "RELATÓRIO";

            dg_Venda.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            mk_DataInicial.Text = Convert.ToString(DateTime.Now);
            mk_DataFinal.Text = Convert.ToString(DateTime.Now);

            CarregaCB();
        }

        public void CarregaCB()
        {
            DataTable _DT = new DataTable();
            _DT = util_Param.Pesquisa_NFE();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_NFe);
            cb_NFe.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_Fatura();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 0;

            List<string> aux = new List<string> { "EMISSÃO", "FATURAMENTO" };
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedIndex = 0;
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        Venda.Consulta_Emissao.Filtra = true;
                        Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;

                    case "FATURAMENTO":
                        Venda.Consulta_Fatura.Filtra = true;
                        Venda.Consulta_Fatura.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Fatura.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                }

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 3)
                    {
                        Venda.Pesquisa_Cancelado = true;
                        Venda.Cancelado = true;
                    }
                    else
                    {
                        Venda.Pesquisa_Faturado = true;
                        if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                            Venda.Faturado = true;
                        else
                            Venda.Faturado = false;
                    }
                }

                if (Convert.ToInt32(cb_NFe.SelectedValue) > 0)
                {
                    Venda.Pesquisa_EmitidoNFe = true;
                    if (Convert.ToInt32(cb_NFe.SelectedValue) == 1)
                        Venda.NFe = true;
                    else
                        Venda.NFe = false;
                }

                DataTable _DT = new DataTable();
                _DT = BLL_Venda.Busca(Venda);
                dg_Venda.DataSource = _DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Imprimir()
        {
            try
            {
                string strPedidos = "0";
                for (int i = 0; i <= dg_Venda.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dg_Venda.Rows[i].Cells[0].Value) == true)
                        strPedidos = strPedidos + ", " + dg_Venda.Rows[i].Cells[1].Value;
                }

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.lst_ID_Venda = strPedidos;
                DTRelatorio = BLL_Venda.Busca_ItemTransporte(Venda);

                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Produto_Transporte.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                ReportDataSource ds_Produtos = new ReportDataSource("ds_Produto_Transporte", DTRelatorio);

                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Produtos);

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
                string strPedidos = "0";
                for (int i = 0; i <= dg_Venda.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dg_Venda.Rows[i].Cells[0].Value) == true)
                        strPedidos = strPedidos + ", " + dg_Venda.Rows[i].Cells[1].Value;
                }

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.lst_ID_Venda = strPedidos;
                DTRelatorio = BLL_Venda.Busca_ItemTransporte(Venda);

                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Produto_Transporte.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                ReportDataSource ds_Produtos = new ReportDataSource("ds_Produto_Transporte", DTRelatorio);

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produtos);

                frm_rpt.rpt_Viewer.RefreshReport();
                frm_rpt.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Venda_Transporte_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Venda_Transporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region DATAGRID
        private void dg_Venda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Venda.Rows.Count - 1; i++)
                    dg_Venda.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Venda_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                try
                {
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    }

                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top + 1, e.CellBounds.Right, e.CellBounds.Top + 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);

                    Image imgChecked = (Image)UI.Properties.Resources._checked;
                    Image imgUnchecked = (Image)UI.Properties.Resources._unchecked;

                    int X = e.CellBounds.Left + ((e.CellBounds.Width - imgChecked.Width) / 2) - 1;
                    int Y = e.CellBounds.Top + ((e.CellBounds.Height - imgChecked.Height) / 2) - 1;

                    if (Seleciona)
                        e.Graphics.DrawImage(imgChecked, X, Y);
                    else
                        e.Graphics.DrawImage(imgUnchecked, X, Y);

                    e.Handled = true;
                }
                catch
                {
                }
            }
        }
        #endregion

        #region MASKEDBOX
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
        #endregion
    }
}
