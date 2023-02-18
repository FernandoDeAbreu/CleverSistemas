using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_Consulta_Grade : Form
    {
        public UI_Produto_Consulta_Grade()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        #endregion

        #region PROPRIEDADES
        public int ID_Produto { get; set; }
        public string Descricao { get; set; }

        public bool ConsultaSimples { get; set; }

        public List<DTO_Produto_Item> lst_Produto { get; set; }
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONSULTA GRADE";

            lb_Produto.Text = Descricao;

            dg_Grade.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn col_ID_Grade = new DataGridViewTextBoxColumn();
            col_ID_Grade.DataPropertyName = "ID_Grade";
            col_ID_Grade.Name = "col_ID_Grade";
            col_ID_Grade.HeaderText = "ID_Grade";
            col_ID_Grade.Width = 100;
            col_ID_Grade.Visible = false;
            dg_Grade.Columns.Add(col_ID_Grade);

            DataGridViewTextBoxColumn col_DescricaoGrade = new DataGridViewTextBoxColumn();
            col_DescricaoGrade.HeaderText = "GRADE";
            col_DescricaoGrade.Name = "col_DescricaoGrade";
            col_DescricaoGrade.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_DescricaoGrade.ReadOnly = true;
            dg_Grade.Columns.Add(col_DescricaoGrade);

            DataGridViewTextBoxColumn col_Estoque = new DataGridViewTextBoxColumn();
            col_Estoque.HeaderText = "ESTOQUE";
            col_Estoque.Width = 100;
            col_Estoque.Name = "Col_EstoqueAtual";
            col_Estoque.DefaultCellStyle.Format = "N2";
            col_Estoque.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col_Estoque.ReadOnly = true;
            dg_Grade.Columns.Add(col_Estoque);

            dg_Grade.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Grade.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Grade.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (ConsultaSimples == false &&
                Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Quantidade)
            {
                DataGridViewTextBoxColumn col_Quantidade = new DataGridViewTextBoxColumn();
                col_Quantidade.HeaderText = "QUANTIDADE";
                col_Quantidade.Width = 100;
                col_Quantidade.Name = "col_Quantidade";
                col_Quantidade.DefaultCellStyle.Format = "N3";
                col_Quantidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dg_Grade.Columns.Add(col_Quantidade);

                DataGridViewTextBoxColumn col_Informacao = new DataGridViewTextBoxColumn();
                col_Informacao.HeaderText = "INFORMAÇÃO";
                col_Informacao.Width = 150;
                col_Informacao.Name = "col_Informacao";
                col_Informacao.DefaultCellStyle.NullValue = string.Empty;
                dg_Grade.Columns.Add(col_Informacao);

                dg_Grade.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dg_Grade.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                dg_Grade.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }

            CarregaGrade();
        }

        public void CarregaGrade()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = ID_Produto;
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_Estoque(Produto);

            if (_DT.Rows.Count > 0)
                for (int i = 0; i < _DT.Rows.Count; i++)
                {
                    dg_Grade.Rows.Add();
                    dg_Grade.Rows[i].Cells["col_ID_Grade"].Value = _DT.Rows[i]["ID_Grade"];
                    dg_Grade.Rows[i].Cells["col_DescricaoGrade"].Value = _DT.Rows[i]["DescricaoGrade"];
                    dg_Grade.Rows[i].Cells["col_EstoqueAtual"].Value = _DT.Rows[i]["EstoqueAtual"];

                    if (ConsultaSimples == false &&
                        Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Quantidade)
                        dg_Grade.Rows[i].Cells["col_Quantidade"].Value = 0;
                }

            if (ConsultaSimples == false &&
                Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Quantidade)
                dg_Grade.Rows[0].Cells["col_Quantidade"].Selected = true;
        }

        private void Seleciona_Grade()
        {
            lst_Produto = new List<DTO_Produto_Item>();
            DTO_Produto_Item Produto_Item;

            if (ConsultaSimples == true ||
                Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Unico)
            {
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID_Grade = Convert.ToInt32(dg_Grade.Rows[dg_Grade.CurrentRow.Index].Cells["col_ID_Grade"].Value);
                Produto_Item.DescricaoGrade = dg_Grade.Rows[dg_Grade.CurrentRow.Index].Cells["col_DescricaoGrade"].Value.ToString();

                lst_Produto.Add(Produto_Item);
            }

            if (ConsultaSimples == false &&
                Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Quantidade)
                for (int i = 0; i < dg_Grade.Rows.Count; i++)
                    if (util_dados.Verifica_Double(dg_Grade.Rows[i].Cells["col_Quantidade"].Value.ToString()) > 0)
                    {
                        Produto_Item = new DTO_Produto_Item();

                        Produto_Item.ID_Grade = Convert.ToInt32(dg_Grade.Rows[i].Cells["col_ID_Grade"].Value);
                        Produto_Item.DescricaoGrade = dg_Grade.Rows[i].Cells["col_DescricaoGrade"].Value.ToString();
                        Produto_Item.Quantidade = Convert.ToDouble(dg_Grade.Rows[i].Cells["col_Quantidade"].Value);

                        if (dg_Grade.Rows[i].Cells["col_Informacao"].Value != null)
                            Produto_Item.Informacao = dg_Grade.Rows[i].Cells["col_Informacao"].Value.ToString();
                        lst_Produto.Add(Produto_Item);
                    }

            this.Close();
            this.Dispose();
        }
        #endregion

        #region FORM
        private void UI_Produto_Consulta_Grade_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Consulta_Grade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region BUTTON
        private void bt_SelecionaUnico_Click(object sender, EventArgs e)
        {
            Seleciona_Grade();
        }
        #endregion

        #region DATAGRID
        private void dg_Grade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Seleciona_Grade();
        }

        private void dg_Grade_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dg_Grade.Rows[e.RowIndex].Cells["col_Quantidade"].Value != null &&
                util_dados.Verifica_Double(dg_Grade.Rows[e.RowIndex].Cells["col_Quantidade"].Value.ToString()) > 0)
                dg_Grade.Rows[e.RowIndex].Cells["col_Quantidade"].Value = Convert.ToDouble(dg_Grade.Rows[e.RowIndex].Cells["col_Quantidade"].Value);
            else
                dg_Grade.Rows[e.RowIndex].Cells["col_Quantidade"].Value = "0,000";
        }
        #endregion
    }
}
