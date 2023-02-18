using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using Microsoft.Reporting.WinForms;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_Imposto : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Imposto()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_Imposto BLL_Imposto;
        #endregion

        #region VARIAVEIS DIVERSAS
        bool Seleciona = false;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_Imposto Imposto;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PRODUTO - CONFIGURAÇÃO DE IMPOSTO";
            TabPage1.Text = "PRODUTOS";

            dg_Produto.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            CarregaCB();
        }

        private void CarregaCB()
        {
            BLL_Imposto = new BLL_Imposto();
            Imposto = new DTO_Imposto();
            Imposto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Imposto.Busca(Imposto);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Imposto);
        }

        private void Carrega_DG(DataTable _DT)
        {
            dg_Produto.Rows.Clear();

            if (_DT.Rows != null &&
                _DT.Rows.Count == 0)
                return;

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                dg_Produto.Rows.Add();
                dg_Produto.Rows[i].Cells["col_ID_Produto"].Value = _DT.Rows[i]["ID_Produto"];
                dg_Produto.Rows[i].Cells["col_Descricao"].Value = _DT.Rows[i]["Descricao"];
                dg_Produto.Rows[i].Cells["col_Barra"].Value = _DT.Rows[i]["Barra"];
                dg_Produto.Rows[i].Cells["col_NCM"].Value = _DT.Rows[i]["NCM"];
                dg_Produto.Rows[i].Cells["col_DescricaoTributacao"].Value = _DT.Rows[i]["DescricaoImposto"];
                dg_Produto.Rows[i].Cells["col_ID_Imposto"].Value = _DT.Rows[i]["ID_Imposto"];
                dg_Produto.Rows[i].Cells["col_ID_Empresa"].Value = _DT.Rows[i]["ID_Empresa"];
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_GrupoNivelP.Text;
            Produto.Descricao = txt_Descricao.Text;
            Produto.Referencia = txt_Referencia.Text;
            Produto.Barra = txt_Barra.Text;
            Produto.Fabricante = txt_MarcaP.Text;
            Produto.NCM = txt_NCM.Text;

            if (Parametro_Venda.Produto_Marca == true)
                Produto.ConsultaMarca = true;

            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1";
            
            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca(Produto);

            Carrega_DG(_DT);
        }

        public override void Gravar()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_Alteracao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            MessageBox.Show(util_msg.msg_ProcessoDemorado, this.Text);

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            for (int i = 0; i <= dg_Produto.Rows.Count - 1; i++)
                if (util_dados.Verifica_int(dg_Produto.Rows[i].Cells["col_ID_Imposto"].Value.ToString()) > 0)
                {
                    Produto = new DTO_Produto();
                    Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Produto.ID = Convert.ToInt32(dg_Produto.Rows[i].Cells["col_ID_Produto"].Value);
                    Produto.ID_Imposto = Convert.ToInt32(dg_Produto.Rows[i].Cells["col_ID_Imposto"].Value);

                    BLL_Produto.Grava_Imposto(Produto);
                }

            MessageBox.Show(util_msg.msg_Grava, this.Text);

            Pesquisa();
        }       
        #endregion

        #region FORM
        private void UI_Produto_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Relatorio_KeyDown(object sender, KeyEventArgs e)
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

        private void bt_Pesquisa_CaminhoNFe_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dg_Produto.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Produto.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    dg_Produto.Rows[i].Cells["col_DescricaoTributacao"].Value = cb_Imposto.Text;
                    dg_Produto.Rows[i].Cells["col_ID_Imposto"].Value = cb_Imposto.SelectedValue;

                    dg_Produto.Rows[i].Cells["col_Seleciona"].Value = false;
                }
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_Produto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Produto.Rows.Count - 1; i++)
                    dg_Produto.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Produto_DoubleClick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value = true;
        }

        private void dg_Produto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                    Image imgChecked = (Image)Sistema.UI.Properties.Resources._checked;
                    Image imgUnchecked = (Image)Sistema.UI.Properties.Resources._unchecked;

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
        
    }
}
