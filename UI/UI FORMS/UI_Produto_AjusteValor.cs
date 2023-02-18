using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_AjusteValor : Sistema.UI.UI_Modelo
    {
        public UI_Produto_AjusteValor()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_TabelaValor BLL_TabelaValor;
        #endregion

        #region VARIAVEIS DIVERSAS
        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_Produto_Valor Produto_Valor;
        DTO_TabelaValor TabelaValor;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "AJUSTE DE VALOR DE VENDA";

            dg_Produto.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Edita.Visible = false;
            bt_Novo.Visible = false;

            tabctl.SelectedTab = TabPage1;

            switch (Parametro_Venda.Produto_PrecoVenda)
            {
                case Composicao_PrecoVenda.Custo_Final:
                    lb_ValorVenda.Text = util_msg.msg_ValorVenda_CustoFinal;
                    break;

                case Composicao_PrecoVenda.Preco_Compra:
                    lb_ValorVenda.Text = util_msg.msg_ValorVenda_ValorCompra;
                    break;
            }

            Carrega_CB();
        }

        private void Carrega_CB(bool Atualiza_TipoReajuste = false)
        {
            List<string> TipoReajuste = new List<string>();

            if (Atualiza_TipoReajuste == true)
            {
                if (Convert.ToInt32(cb_Tipo_ValorPorcentagem.SelectedValue) == 1)
                    TipoReajuste.Add("DEFINIR");

                TipoReajuste.Add("AUMENTAR");
                TipoReajuste.Add("DIMINUIR");

                util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, TipoReajuste), "Descricao", "ID", cb_TipoReajuste);

                return;
            }

            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();

            DataTable _DT = new DataTable();
            _DT = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Tabela);
            cb_ID_Tabela.SelectedIndex = 0;

            List<string> _aux = new List<string>();
            _aux.Add("TODOS");
            _aux.Add("ATIVOS");
            _aux.Add("INATIVOS");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, _aux), "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 1;

            List<string> TipoComissao = new List<string>();
            TipoComissao.Add("VALOR");
            TipoComissao.Add("PORCENTAGEM");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, TipoComissao), "Descricao", "ID", cb_Tipo_ValorPorcentagem);


            if (Convert.ToInt32(cb_Tipo_ValorPorcentagem.SelectedValue) == 1)
                TipoReajuste.Add("DEFINIR");

            TipoReajuste.Add("AUMENTAR");
            TipoReajuste.Add("DIMINUIR");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, TipoReajuste), "Descricao", "ID", cb_TipoReajuste);
        }

        private void Altera_ValorVenda()
        {
            try
            {
                double ValorCompra = 0;
                double OutrosCustos = 0;
                double ValorIPI = 0;
                double ValorST = 0;
                double Margem = 0;
                double ValorVenda = 0;
                double ValorAlteracao = 0;

                for (int i = 0; i <= dg_Produto.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dg_Produto.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {

                        ValorCompra = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorCompra"].Value);
                        OutrosCustos = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_OutrosCustos"].Value);
                        ValorIPI = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorIPI"].Value);
                        ValorST = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorST"].Value);
                        Margem = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_Margem"].Value);
                        ValorVenda = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorVenda"].Value);
                        ValorAlteracao = Convert.ToDouble(txt_Valor.Text);

                        dg_Produto.Rows[i].Cells["col_ValorVenda"].Style.BackColor = Color.LightGray;
                        dg_Produto.Rows[i].Cells["col_Atualiza"].Value = true;

                        switch (Convert.ToInt32(cb_Tipo_ValorPorcentagem.SelectedValue))
                        {
                            case 1: //VALOR
                                switch (Convert.ToInt32(cb_TipoReajuste.SelectedValue))
                                {
                                    case 1: //DEFINIR
                                        switch (Parametro_Venda.Produto_PrecoVenda)
                                        {
                                            case Composicao_PrecoVenda.Custo_Final:
                                                double CustoFinal = ValorCompra;
                                                CustoFinal += ValorIPI;
                                                CustoFinal += ValorST;
                                                CustoFinal += OutrosCustos;

                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, ValorAlteracao), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;

                                            case Composicao_PrecoVenda.Preco_Compra:
                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorCompra, ValorAlteracao - ValorIPI - ValorST - OutrosCustos), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;
                                        }
                                        break;

                                    case 2: //AUMENTAR
                                        ValorAlteracao = ValorVenda + ValorAlteracao;

                                        switch (Parametro_Venda.Produto_PrecoVenda)
                                        {
                                            case Composicao_PrecoVenda.Custo_Final:
                                                double CustoFinal = ValorCompra;
                                                CustoFinal += ValorIPI;
                                                CustoFinal += ValorST;
                                                CustoFinal += OutrosCustos;

                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, ValorAlteracao), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;

                                            case Composicao_PrecoVenda.Preco_Compra:
                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorCompra, ValorAlteracao - ValorIPI - ValorST - OutrosCustos), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;
                                        }
                                        break;

                                    case 3: //DIMINUIR
                                        ValorAlteracao = ValorVenda - ValorAlteracao;

                                        switch (Parametro_Venda.Produto_PrecoVenda)
                                        {
                                            case Composicao_PrecoVenda.Custo_Final:
                                                double CustoFinal = ValorCompra;
                                                CustoFinal += ValorIPI;
                                                CustoFinal += ValorST;
                                                CustoFinal += OutrosCustos;

                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, ValorAlteracao), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;

                                            case Composicao_PrecoVenda.Preco_Compra:
                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorCompra, ValorAlteracao - ValorIPI - ValorST - OutrosCustos), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;
                                        }
                                        break;
                                }
                                break;

                            case 2: //PORCENTAGEM
                                switch (Convert.ToInt32(cb_TipoReajuste.SelectedValue))
                                {
                                    case 1: //AUMENTAR
                                        ValorAlteracao = ValorVenda + util_dados.Calcula_Porcentagem(ValorAlteracao, ValorVenda);

                                        switch (Parametro_Venda.Produto_PrecoVenda)
                                        {
                                            case Composicao_PrecoVenda.Custo_Final:
                                                double CustoFinal = ValorCompra;
                                                CustoFinal += ValorIPI;
                                                CustoFinal += ValorST;
                                                CustoFinal += OutrosCustos;

                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, ValorAlteracao), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;

                                            case Composicao_PrecoVenda.Preco_Compra:
                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorCompra, ValorAlteracao - ValorIPI - ValorST - OutrosCustos), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;
                                        }
                                        break;

                                    case 2: //DIMINUIR
                                        ValorAlteracao = ValorVenda - util_dados.Calcula_Porcentagem(ValorAlteracao, ValorVenda);

                                        switch (Parametro_Venda.Produto_PrecoVenda)
                                        {
                                            case Composicao_PrecoVenda.Custo_Final:
                                                double CustoFinal = ValorCompra;
                                                CustoFinal += ValorIPI;
                                                CustoFinal += ValorST;
                                                CustoFinal += OutrosCustos;

                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, ValorAlteracao), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;

                                            case Composicao_PrecoVenda.Preco_Compra:
                                                dg_Produto.Rows[i].Cells["col_Margem"].Value = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorCompra, ValorAlteracao - ValorIPI - ValorST - OutrosCustos), 2);
                                                dg_Produto.Rows[i].Cells["col_ValorVenda"].Value = util_dados.ConfigNumDecimal(ValorAlteracao, 2);
                                                break;
                                        }
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message);
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

                Produto.ID = util_dados.Verifica_int(txt_IDP.Text);
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.GrupoNivel = mk_Cod_GrupoP.Text;
                Produto.Descricao = txt_DescricaoP.Text;
                Produto.Referencia = txt_ReferenciaP.Text;
                Produto.Barra = txt_BarraP.Text;
                Produto.Fabricante = txt_FabricanteP.Text;
                Produto.InfoAdicional1 = txt_InfoAdicional1P.Text;

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    Produto.Consulta_Ativo = true;

                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                        Produto.Ativo = true;
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 2)
                        Produto.Ativo = false;
                }

                Produto.ID_Tabela = util_dados.Verifica_int(cb_ID_Tabela.SelectedValue.ToString());

                DataTable _DT = new DataTable();
                _DT = BLL_Produto.Busca_Valor(Produto);

                dg_Produto.DataSource = _DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Gravar()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_AlteracaoCritica, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Produto = new BLL_Produto();

                for (int i = 0; i <= dg_Produto.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dg_Produto.Rows[i].Cells["col_Atualiza"].Value) == true)
                    {
                        Produto = new DTO_Produto();
                        Produto.Valor = new List<DTO_Produto_Valor>();
                        Produto_Valor = new DTO_Produto_Valor();

                        Produto.ID = Convert.ToInt32(dg_Produto.Rows[i].Cells["col_ID_Produto"].Value);

                        Produto.ValorCompra = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorCompra"].Value);
                        Produto.OutrosCustos = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_OutrosCustos"].Value);
                        Produto.ValorIPI = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorIPI"].Value);
                        Produto.ValorST = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorST"].Value);
                        Produto.CustoFinal = Produto.ValorCompra + Produto.OutrosCustos + Produto.ValorIPI + Produto.ValorST;

                        Produto_Valor.ID = Convert.ToInt32(dg_Produto.Rows[i].Cells["col_ID_TabelaProdutoValor"].Value);
                        Produto_Valor.ID_Tabela = Convert.ToInt32(dg_Produto.Rows[i].Cells["col_ID_Tabela"].Value);
                        Produto_Valor.UltimoReajuste = DateTime.Now;
                        Produto_Valor.MargemVenda = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_Margem"].Value);
                        Produto_Valor.ValorVenda = Convert.ToDouble(dg_Produto.Rows[i].Cells["col_ValorVenda"].Value);

                        Produto.Valor.Add(Produto_Valor);

                        BLL_Produto.Atualiza_Valor(Produto);
                    }
                }
                MessageBox.Show(util_msg.msg_Altera, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message);
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_AjusteValor_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_AjusteValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Valor.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Produto_AjusteValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region DATAGRID
        private void dg_Produto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Produto.Rows.Count - 1; i++)
                    dg_Produto.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Produto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                try
                {
                    //Erase the cell
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
        #endregion

        #region BUTTON
        private void bt_ComissaoTodos_Click(object sender, EventArgs e)
        {
            Altera_ValorVenda();
        }
        #endregion

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            txt_Valor.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Valor.Text), 2);
        }
        #endregion

        #region COMBOBOX
        private void cb_Tipo_ValorPorcentagem_Leave(object sender, EventArgs e)
        {
            Carrega_CB(true);
        }
        #endregion
    }
}
