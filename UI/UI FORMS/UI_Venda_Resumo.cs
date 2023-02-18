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
    public partial class UI_Venda_Resumo : Form
    {
        public UI_Venda_Resumo()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_CReceber BLL_CReceber;
        #endregion

        #region ESTRUTURA
        DTO_CReceber CReceber;
        #endregion

        #region PROPRIEDADES
        public List<DTO_Produto_Item> _lst_Produto { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            dg_Financeiro.AutoGenerateColumns = false;
            dg_Itens.AutoGenerateColumns = false;

            Carrega_Item();

            Busca_Financeiro();
        }

        private void Carrega_Item()
        {
            dg_Itens.Rows.Clear();
            double SubTotal = 0;
            double TotalCusto = 0;
            double TotalLucro = 0;

            for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            {
                dg_Itens.Rows.Add();
                dg_Itens.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
                dg_Itens.Rows[i].Cells["col_Descricao"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens.Rows[i].Cells["col_ValorVenda"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;
                dg_Itens.Rows[i].Cells["col_CustoFinal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorCusto;
                dg_Itens.Rows[i].Cells["col_Lucro"].Value = _lst_Produto[i].Quantidade * (_lst_Produto[i].ValorVenda - _lst_Produto[i].ValorCusto);

                SubTotal += _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;
                TotalCusto += _lst_Produto[i].Quantidade * _lst_Produto[i].ValorCusto;
                TotalLucro += _lst_Produto[i].Quantidade * (_lst_Produto[i].ValorVenda - _lst_Produto[i].ValorCusto);
            }

            dg_Itens.RefreshEdit();

            txt_TotalProduto.Text = util_dados.ConfigNumDecimal(SubTotal, 2);
            txt_TotalCusto.Text = util_dados.ConfigNumDecimal(TotalCusto, 2);
            txt_TotalLucro.Text = "R$ " + util_dados.ConfigNumDecimal(TotalLucro, 2) + " (" + util_dados.ConfigNumDecimal(((SubTotal - TotalCusto) / TotalCusto) * 100, 2) + " %)";
        }

        private void Busca_Financeiro()
        {
            BLL_CReceber = new BLL_CReceber();
            CReceber = new DTO_CReceber();

            CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CReceber.Situacao = 1;
            CReceber.TipoPessoa = TipoPessoa;
            CReceber.ID_Pessoa = ID_Pessoa;
            CReceber.Ordena_Por = 4;

            DataTable _DT = new DataTable();

            _DT = BLL_CReceber.Busca(CReceber);

            dg_Financeiro.DataSource = _DT;

            txt_TotalCReceber.Text = util_dados.ConfigNumDecimal(util_dados.Calcula_Campo_DT(_DT, "Total"), 2);

            Config_DG();
        }

        private void Config_DG()
        {
            DateTime DataDG;
            DateTime DataPC = DateTime.Now;
            for (int i = 0; i <= dg_Financeiro.Rows.Count - 1; i++)
            {
                DataDG = Convert.ToDateTime(dg_Financeiro.Rows[i].Cells["col_Vencimento"].Value);

                if (DataDG < DataPC)
                    dg_Financeiro.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            }
        }
        #endregion

        #region FORM
        private void UI_Venda_Resumo_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        private void UI_Venda_Resumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
    }
}
