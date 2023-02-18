using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_Etiqueta : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Etiqueta()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_Pessoa BLL_Pessoa;
        BLL_TabelaValor BLL_TabelaValor;
        #endregion

        #region VARIAVEIS LOCAIS
        DataTable DTR_Empresa;
        DataTable DTProduto;
        DataTable DT;
        DataTable DT_Etiqueta;

        DataRow DR;
        DataRow DREtiqueta;

        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_Pessoa Pessoa;
        DTO_TabelaValor TabelaValor;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "IMPRESSÃO DE ETIQUETAS";
            TabPage1.Text = "PESQUISA";

            dg_Etiqueta.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Imprime.Visible = true;
            bt_Visualiza.Enabled = true;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            bt_Imprime.Visible = false;

            CarregaCB();
        }

        private void CarregaCB()
        {
            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();

            DT = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(DT, "Descricao", "ID", cb_ID_Tabela);
            cb_ID_Tabela.SelectedIndex = 0;

            List<string> _aux = new List<string>();
            _aux.Add("Etiqueta A4051/A4251/A4351 (Pimaco)");
            _aux.Add("Etiqueta Carta 6087/6187/6287 (Pimaco)");
            _aux.Add("Etiqueta Carta 6080/6180/6280/62580 (Pimaco)");
            _aux.Add("Etiqueta Argox 3 Coluna 34x23");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, _aux), "Descricao", "ID", cb_Etiqueta);
            cb_Etiqueta.SelectedIndex = 0;
        }

        private void CarregaValor(DataTable DT)
        {
            int aux = 0;
            dg_Etiqueta.Rows.Clear();

            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                dg_Etiqueta.Rows.Add();
                dg_Etiqueta.Rows[aux].Cells["col_ID_Produto"].Value = DT.Rows[i]["ID"];
                dg_Etiqueta.Rows[aux].Cells["col_Descricao"].Value = DT.Rows[i]["Descricao"];
                dg_Etiqueta.Rows[aux].Cells["col_Barra"].Value = DT.Rows[i]["Barra"];
                dg_Etiqueta.Rows[aux].Cells["col_Grade"].Value = DT.Rows[i]["DescricaoGrade"];
                dg_Etiqueta.Rows[aux].Cells["col_Valor"].Value = DT.Rows[i]["ValorVenda"];

                int Quantidade = util_dados.Verifica_int(txt_Qtd_Etiqueta.Text);

                if (util_dados.Verifica_int(txt_ID_Entrada.Text) > 0 ||
                    ck_Estoque.Checked == true)
                    Quantidade = Convert.ToInt32(DT.Rows[i]["Quantidade"]);

                if (Quantidade < 0)
                    Quantidade = 0;

                dg_Etiqueta.Rows[aux].Cells["col_Quantidade"].Value = Quantidade;

                if (util_dados.Verifica_int(txt_Parcela.Text) == 1)
                    dg_Etiqueta.Rows[aux].Cells["col_Valor"].Value = "R$ " + util_dados.ConfigNumDecimal(DT.Rows[i]["ValorVenda"], 2);
                else
                    dg_Etiqueta.Rows[aux].Cells["col_Valor"].Value = txt_Parcela.Text + " X R$ " + util_dados.ConfigNumDecimal(Convert.ToDouble(DT.Rows[i]["ValorVenda"]) / Convert.ToDouble(txt_Parcela.Text), 2);
                aux++;
            }
        }

        private void CarregaDT(DataTable DT)
        {
            bool Inicio = true;

            DT_Etiqueta = new DataTable("Etiqueta");
            DT_Etiqueta.Columns.Add("ID");
            DT_Etiqueta.Columns.Add("Descricao");
            DT_Etiqueta.Columns.Add("BarraEtiqueta");
            DT_Etiqueta.Columns.Add("ValorVenda");
            DT_Etiqueta.Columns.Add("DescricaoGrade");
            DT_Etiqueta.Columns.Add("Informacao");
            DT_Etiqueta.Columns.Add("InfoAdicional1");
            DT_Etiqueta.Columns.Add("InfoAdicional2");

            for (int i = 0; i <= DT.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Etiqueta.Rows[i].Cells["col_Seleciona"].Value) == true)
                    if (util_dados.Verifica_int(dg_Etiqueta.Rows[i].Cells["col_Quantidade"].Value.ToString()) > 0)
                        for (int x = 0; x <= Convert.ToInt32(dg_Etiqueta.Rows[i].Cells["col_Quantidade"].Value) - 1; x++)
                        {
                            if (util_dados.Verifica_int(txt_Inicio.Text) > 0 && Inicio == true)
                            {
                                for (int y = 0; y <= util_dados.Verifica_int(txt_Inicio.Text) - 1; y++)
                                {
                                    DR = DT_Etiqueta.NewRow();
                                    DR["ID"] = "";
                                    DR["Descricao"] = "";
                                    DR["BarraEtiqueta"] = "";
                                    DR["DescricaoGrade"] = "";
                                    DR["ValorVenda"] = "";
                                    DR["Informacao"] = "";
                                    DR["InfoAdicional1"] = "";
                                    DR["InfoAdicional2"] = "";
                                    DT_Etiqueta.Rows.Add(DR);
                                    DT_Etiqueta.AcceptChanges();
                                }
                                Inicio = false;
                            }

                            DR = DT_Etiqueta.NewRow();
                            DR["ID"] = DT.Rows[i]["ID"];
                            DR["Descricao"] = DT.Rows[i]["Descricao"];
                            DR["BarraEtiqueta"] = DT.Rows[i]["Barra_Etiqueta"];
                            DR["DescricaoGrade"] = DT.Rows[i]["DescricaoGrade"];
                            DR["Informacao"] = txt_InformacaoAdicional.Text;
                            DR["InfoAdicional1"] = DT.Rows[i]["InfoAdicional1"];
                            DR["InfoAdicional2"] = DT.Rows[i]["InfoAdicional2"];

                            if (util_dados.Verifica_int(txt_Parcela.Text) == 1)
                                DR["ValorVenda"] = "R$ " + util_dados.ConfigNumDecimal(DT.Rows[i]["ValorVenda"], 2);
                            else
                                DR["ValorVenda"] = txt_Parcela.Text + " X R$ " + util_dados.ConfigNumDecimal(Convert.ToDouble(DT.Rows[i]["ValorVenda"]) / Convert.ToDouble(txt_Parcela.Text), 2);

                            DT_Etiqueta.Rows.Add(DR);
                            DT_Etiqueta.AcceptChanges();
                        }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ListaID = txt_ID.Text;
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_GrupoNivelP.Text;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_Referencia.Text;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1";
            Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

            Produto.Consulta_Etiqueta = 1;

            Produto.ID_Produto_Entrada = util_dados.Verifica_int(txt_ID_Entrada.Text);

            if (ck_Estoque.Checked == true)
                Produto.Consulta_Etiqueta = 3;

            if (util_dados.Verifica_int(txt_ID_Entrada.Text) > 0 &&
                ck_Estoque.Checked == true)
                Produto.Consulta_Etiqueta = 4;

            if (util_dados.Verifica_int(txt_ID_Entrada.Text) > 0 &&
                ck_Estoque.Checked == false)
                Produto.Consulta_Etiqueta = 2;

            DTProduto = BLL_Produto.Busca_Etiqueta(Produto);
            CarregaValor(DTProduto);
        }

        public override void Visualizar()
        {
            CarregaDT(DTProduto);
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = string.Empty;

            if (cb_Etiqueta.Text == "Etiqueta A4051/A4251/A4351 (Pimaco)")
                rpt_Nome = "rpt_EtiquetaA4251.rdlc";

            if (cb_Etiqueta.Text == "Etiqueta Carta 6087/6187/6287 (Pimaco)")
                rpt_Nome = "rpt_EtiquetaC6187.rdlc";

            if (cb_Etiqueta.Text == "Etiqueta Carta 6080/6180/6280/62580 (Pimaco)")
                rpt_Nome = "rpt_EtiquetaC6180.rdlc";

            if (cb_Etiqueta.Text == "Etiqueta Argox 3 Coluna 34x23")
                rpt_Nome = "rpt_EtiquetaR3Coluna34x23.rdlc";

            if (rpt_Nome == string.Empty)
                return;

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Produto = new ReportDataSource("ds_Etiqueta", DT_Etiqueta);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);

            frm_rpt.rpt_Viewer.RefreshReport();
        }
        #endregion

        #region FORM
        private void UI_Produto_Etiqueta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Etiqueta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ID.Focused == true ||
              txt_Qtd_Etiqueta.Focused == true ||
              txt_Parcela.Focused ||
              txt_Inicio.Focused == true ||
              txt_ID_Entrada.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Produto_Etiqueta_KeyDown(object sender, KeyEventArgs e)
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

        #region DATAGRIDVIEW
        private void dg_Etiqueta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dg_Etiqueta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Seleciona"].Value = true;
        }

        private void dg_Etiqueta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Etiqueta.Rows.Count - 1; i++)
                    dg_Etiqueta.Rows[i].Cells[0].Value = Seleciona;
            }
        }
        #endregion
    }
}