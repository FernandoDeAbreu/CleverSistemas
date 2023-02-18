using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_Produto_AjusteEstoque : Sistema.UI.UI_Modelo
    {
        public UI_Produto_AjusteEstoque()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        #endregion

        #region VERIAVEIS DIVERSAS
        bool Seleciona;
        #endregion

        #region
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "AJUSTE DE ESTOQUE - CORREÇÃO";

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;

            tabctl.SelectedTab = TabPage1;

            dg_Produto.AutoGenerateColumns = false;

            Config(StatusForm.Novo);
        }

        private void Ajuste_Estoque()
        {
            try
            {            
                    for (int i = 0; i <= dg_Produto.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_Produto.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {
                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();
                        Produto_Estoque = new DTO_Produto_Estoque();
                        Produto.Estoque = new List<DTO_Produto_Estoque>();

                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Produto.ID = util_dados.Verifica_int(dg_Produto.Rows[i].Cells["col_ID_Produto"].Value.ToString());
                        Produto.ID_Grade = util_dados.Verifica_int(dg_Produto.Rows[i].Cells["col_ID_Grade"].Value.ToString());

                        DataTable _DT = new DataTable();
                        _DT = BLL_Produto.Busca_ProdutoMovimento(Produto);

                        Produto_Estoque.ID_Grade = util_dados.Verifica_int(dg_Produto.Rows[i].Cells["col_ID_Grade"].Value.ToString());
                        Produto_Estoque.Estoque_Atual = util_dados.Calcula_Campo_DT(_DT, "Compra") - util_dados.Calcula_Campo_DT(_DT, "Venda");

                        Produto.Estoque.Add(Produto_Estoque);

                        BLL_Produto.Grava_Estoque(Produto);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.ID = util_dados.Verifica_int(txt_ID.Text);
                Produto.Descricao = txt_Descricao.Text;
                Produto.GrupoNivel = mk_GrupoNivelP.Text;
                Produto.Referencia = txt_Referencia.Text;

                DataTable _DT = new DataTable();
                _DT = BLL_Produto.Busca_Estoque_Simples(Produto);

                dg_Produto.DataSource = _DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void Gravar()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_AlteracaoEstoque, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                Ajuste_Estoque();

                Pesquisa();

                MessageBox.Show(util_msg.msg_Altera, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_AjusteEstoque_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_AjusteEstoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region DATAGRIDVIEW
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

        private void dg_Produto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_Produto.Rows[dg_Produto.CurrentRow.Index].Cells["col_Seleciona"].Value = true;
        }

        private void dg_Produto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Produto.Rows.Count - 1; i++)
                    dg_Produto.Rows[i].Cells[0].Value = Seleciona;
            }
        }
        #endregion


    }
}
