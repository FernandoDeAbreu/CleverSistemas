using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.UTIL;
using Sistema.BLL;
using Sistema.DTO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_Etiqueta_Producao : Sistema.UI.UI_Modelo
    {
        public UI_Etiqueta_Producao()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Venda BLL_Venda;
        #endregion

        #region VARIAVEIS DIVERSAS
        string lst_Venda;

        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Venda Venda;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "ETIQUETA PRODUÇÃO";

            dg_PesquisaVenda.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            bt_Novo.Visible = false;
            bt_Proximo.Visible = false;
            bt_Anterior.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            bt_Exclui.Visible = false;

            mk_DataInicial.Text = DateTime.Now.ToString();
            mk_DataFinal.Text = DateTime.Now.ToString();

            Carrega_CB();
        }

        public void Carrega_CB()
        {
            DataTable _DT = new DataTable();
            _DT = util_Param.Pesquisa_NFE();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_NFe);
            cb_NFe.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_Fatura();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                if (util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString()) == 0)
                    return;

                cb_ID_Pessoa.DataSource = null;

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DataTable _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                dg_PesquisaVenda.Rows.Clear();

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.ID = util_dados.Verifica_int(txt_IDPedido.Text);
                Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Venda.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

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

                Venda.Consulta_Emissao.Filtra = true;
                Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);

                DataTable _DT = new DataTable();
                _DT = BLL_Venda.Busca(Venda);

                if (_DT.Rows.Count > 0)
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        dg_PesquisaVenda.Rows.Add();
                        dg_PesquisaVenda.Rows[i].Cells["col_ID_Pedido"].Value = _DT.Rows[i]["ID_Venda"];
                        dg_PesquisaVenda.Rows[i].Cells["col_Pessoa"].Value = _DT.Rows[i]["Descricao"];
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Visualizar()
        {
            DataTable _DT = new DataTable();

            _DT.Columns.Add("Pessoa", typeof(string));
            _DT.Columns.Add("Numero_Pedido", typeof(string));
            _DT.Columns.Add("OC", typeof(string));
            _DT.Columns.Add("Referencia", typeof(string));
            _DT.Columns.Add("Cor", typeof(string));
            _DT.Columns.Add("Numeracao", typeof(string));
            _DT.Columns.Add("Quantidade", typeof(string));

            int aux = 0;

            for (int i = 0; i < Convert.ToInt32(txt_InicioEtiqueta.Text); i++)
            {
                _DT.Rows.Add();
                _DT.AcceptChanges();
                aux++;
            }

            for (int i = 0; i <= dg_PesquisaVenda.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_PesquisaVenda.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    _DT.Rows.Add();
                    _DT.Rows[aux]["Pessoa"] = "NOME: " + dg_PesquisaVenda.Rows[i].Cells["col_Pessoa"].Value;
                    _DT.Rows[aux]["Numero_Pedido"] = "PED. Nº " + dg_PesquisaVenda.Rows[i].Cells["col_ID_Pedido"].Value;
                    _DT.Rows[aux]["OC"] = "O.C.: " + dg_PesquisaVenda.Rows[i].Cells["col_OC"].Value;
                    _DT.Rows[aux]["Referencia"] = dg_PesquisaVenda.Rows[i].Cells["col_Referencia"].Value;
                    _DT.Rows[aux]["Cor"] = dg_PesquisaVenda.Rows[i].Cells["col_Cor"].Value;
                    _DT.Rows[aux]["Numeracao"] = dg_PesquisaVenda.Rows[i].Cells["col_Numeracao"].Value;
                    _DT.Rows[aux]["Quantidade"] = dg_PesquisaVenda.Rows[i].Cells["col_Quantidade"].Value;
                    _DT.AcceptChanges();
                    aux++;
                }

            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_EtiquetaA46284.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            DataTable _DT_Empresa = new DataTable();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Producao = new ReportDataSource("ds_ResumoProducao", _DT);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Producao);

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            DataTable _DT = new DataTable();

            _DT.Columns.Add("Pessoa", typeof(string));
            _DT.Columns.Add("Numero_Pedido", typeof(string));
            _DT.Columns.Add("OC", typeof(string));
            _DT.Columns.Add("Referencia", typeof(string));
            _DT.Columns.Add("Cor", typeof(string));
            _DT.Columns.Add("Numeracao", typeof(string));
            _DT.Columns.Add("Quantidade", typeof(string));

            int aux = 0;

            for (int i = 0; i < Convert.ToInt32(txt_InicioEtiqueta.Text); i++)
            {
                _DT.Rows.Add();
                _DT.AcceptChanges();
                aux++;
            }

            for (int i = 0; i <= dg_PesquisaVenda.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_PesquisaVenda.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    _DT.Rows.Add();
                    _DT.Rows[aux]["Pessoa"] = "NOME: " + dg_PesquisaVenda.Rows[i].Cells["col_Pessoa"].Value;
                    _DT.Rows[aux]["Numero_Pedido"] = "PED. Nº " + dg_PesquisaVenda.Rows[i].Cells["col_ID_Pedido"].Value;
                    _DT.Rows[aux]["OC"] = "O.C.: " + dg_PesquisaVenda.Rows[i].Cells["col_OC"].Value;
                    _DT.Rows[aux]["Referencia"] = dg_PesquisaVenda.Rows[i].Cells["col_Referencia"].Value;
                    _DT.Rows[aux]["Cor"] = dg_PesquisaVenda.Rows[i].Cells["col_Cor"].Value;
                    _DT.Rows[aux]["Numeracao"] = dg_PesquisaVenda.Rows[i].Cells["col_Numeracao"].Value;
                    _DT.Rows[aux]["Quantidade"] = dg_PesquisaVenda.Rows[i].Cells["col_Quantidade"].Value;
                    _DT.AcceptChanges();
                    aux++;
                }

            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_EtiquetaA46284.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            DataTable _DT_Empresa = new DataTable();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Producao = new ReportDataSource("ds_ResumoProducao", _DT);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Producao);

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
        private void UI_Etiqueta_Producao_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Etiqueta_Producao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region DATAGRID
        private void dg_PesquisaVenda_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_PesquisaVenda.Rows.Count - 1; i++)
                    dg_PesquisaVenda.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_PesquisaVenda_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dg_PesquisaVenda_DoubleClick(object sender, EventArgs e)
        {
            if (dg_PesquisaVenda.Rows.Count == 0)
                return;

            if (Convert.ToBoolean(dg_PesquisaVenda.Rows[dg_PesquisaVenda.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_PesquisaVenda.Rows[dg_PesquisaVenda.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_PesquisaVenda.Rows[dg_PesquisaVenda.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_PesquisaVenda.Rows[dg_PesquisaVenda.CurrentRow.Index].Cells["col_Seleciona"].Value = true;
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }
        #endregion

       
    }
}
