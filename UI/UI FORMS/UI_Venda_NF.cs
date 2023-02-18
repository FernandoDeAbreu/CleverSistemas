using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    public partial class UI_Venda_NF : Sistema.UI.UI_Modelo
    {
        public UI_Venda_NF()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Venda BLL_Venda;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;
        DataTable DTPessoa;
        DateTime ValidaData;

        List<DTO_Produto_Item> lst_Produto;

        bool Ativo = false;
        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Venda Venda;
        DTO_Produto_Item Produto_Item;
        #endregion

        #region PROPRIEDADES
        public bool Filtra_Empresa { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            tabctl.TabPages.Remove(TabPage2);
            this.Text = "NOTA FISCAL (VENDA)";

            bt_Edita.Visible = false;
            bt_Exclui.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Text = "NOTA FISCAL";

            dg_Vendas.AutoGenerateColumns = false;
            dg_Itens.AutoGenerateColumns = false;

            Carrega_CB();

            Ativo = true;
        }

        private void Carrega_CB()
        {
            DataTable _DT;
            List<string> aux;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;

            _DT = new DataTable();
            aux = new List<string> { "EMISSÃO", "FATURAMENTO" };
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_NFE();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_NFe);
            cb_NFe.SelectedValue = 2;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_Fatura();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedValue = 1;
        }

        public void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Busca_Item()
        {
            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            for (int i = 0; i <= dg_Vendas.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Vendas.Rows[i].Cells["col_Seleciona"].Value) == true)
                    Venda.lst_ID_Venda += dg_Vendas.Rows[i].Cells["col_ID"].Value + ", ";

            if (Venda.lst_ID_Venda == null)
                return;

            Venda.lst_ID_Venda = Venda.lst_ID_Venda.Substring(0, Venda.lst_ID_Venda.Length - 2);

            DataTable _DT = new DataTable();
            _DT = BLL_Venda.Busca_Item(Venda);

            lst_Produto = new List<DTO_Produto_Item>();

            BLL_Venda = new BLL_Venda();
            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID = (int)_DT.Rows[i]["IDItem"];
                Produto_Item.ID_Produto = (int)_DT.Rows[i]["ID_Produto"];
                Produto_Item.Quantidade = Double.Parse(_DT.Rows[i]["Quantidade"].ToString());
                Produto_Item.ID_Tabela = (int)_DT.Rows[i]["ID_Tabela"];
                Produto_Item.ValorCusto = Double.Parse(_DT.Rows[i]["ValorCusto"].ToString());
                Produto_Item.ValorProduto = Double.Parse(_DT.Rows[i]["ValorProduto"].ToString());
                Produto_Item.ValorVenda = Double.Parse(_DT.Rows[i]["ValorVenda"].ToString());
                Produto_Item.Acrescimo = Double.Parse(_DT.Rows[i]["Acrescimo"].ToString());
                Produto_Item.Desconto = Double.Parse(_DT.Rows[i]["Desconto"].ToString());
                Produto_Item.Descricao_Produto = _DT.Rows[i]["DescricaoProduto"].ToString();
                Produto_Item.Descricao_Saida = _DT.Rows[i]["DescricaoSaida"].ToString();
                Produto_Item.Informacao = _DT.Rows[i]["Informacao"].ToString();
                Produto_Item.TipoSaida = (int)_DT.Rows[i]["TipoSaida"];
                Produto_Item.ID_Grade = (int)_DT.Rows[i]["ID_Grade"]; ;

                lst_Produto.Add(Produto_Item);
            }
            if (lst_Produto.Count > 0)
                Carrega_Item(lst_Produto);
        }

        private void LimpaCampo()
        {
            dg_Vendas.DataSource = null;
            dg_Itens.Rows.Clear();

            util_dados.LimpaCampos(this, gb_Produto);
        }

        private void Carrega_Item(List<DTO_Produto_Item> _lst_Produto)
        {
            dg_Itens.Rows.Clear();
            double SubTotal = 0;
            double TotalDesconto = 0;

            for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            {
                dg_Itens.Rows.Add();
                dg_Itens.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
                dg_Itens.Rows[i].Cells["col_Descricao_Produto"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens.Rows[i].Cells["col_Acrescimo"].Value = _lst_Produto[i].Acrescimo;
                dg_Itens.Rows[i].Cells["col_Desconto"].Value = _lst_Produto[i].Desconto;
                dg_Itens.Rows[i].Cells["col_Valor"].Value = _lst_Produto[i].ValorProduto;
                dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = _lst_Produto[i].ValorVenda;
                dg_Itens.Rows[i].Cells["col_Informacao"].Value = _lst_Produto[i].Informacao;
                dg_Itens.Rows[i].Cells["col_TipoSaida"].Value = _lst_Produto[i].Descricao_Saida;
                dg_Itens.Rows[i].Cells["col_ValorTotal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;

                SubTotal += _lst_Produto[i].Quantidade * (_lst_Produto[i].ValorProduto + _lst_Produto[i].Acrescimo);
                TotalDesconto += _lst_Produto[i].Quantidade * _lst_Produto[i].Desconto;
            }

            // txt_SubTotal.Text = util_dados.ConfigNumDecimal(SubTotal, 2);
            // txt_TotalDesconto.Text = util_dados.ConfigNumDecimal(TotalDesconto, 2);
            txt_ValorVenda.Text = util_dados.ConfigNumDecimal(SubTotal - TotalDesconto, 2);
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
        public override void Pesquisa()
        {
            LimpaCampo();

            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            //if (Filtra_Empresa == true)
            //  Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Venda.ID = util_dados.Verifica_int(txt_IDVenda.Text);

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

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
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

            DT = BLL_Venda.Busca(Venda);
            dg_Vendas.DataSource = DT;

            if (DT.Rows.Count == 0)
                dg_Itens.DataSource = null;

            util_dados.CarregaCampo(this, DT, gb_Produto);
        }

        //MODIFICADO PARA GERAR NOTA FISCAL
        public override void Gravar()
        {
            if (dg_Vendas.Rows.Count == 0)
                return;

            int _aux = 0;
            string ID_Pessoa = string.Empty;

            for (int i = 0; i <= dg_Vendas.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Vendas.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    if (_aux >= 1)
                        if (ID_Pessoa != dg_Vendas.Rows[i].Cells["col_ID_Pessoa"].Value.ToString())
                        {
                            MessageBox.Show(util_msg.msg_PessoaDiferente, this.Text);
                            return;
                        }

                    ID_Pessoa = dg_Vendas.Rows[i].Cells["col_ID_Pessoa"].Value.ToString();
                    _aux++;
                }

            bool aux = false;
            foreach (Form Frm in this.ParentForm.MdiChildren)
                if (Frm is UI_NFe_Emissor_Completo)
                {
                    Frm.Close();
                    aux = false;
                }

            if (aux == false)
            {
                _aux = 0;
                string lst_ID_Venda = string.Empty;

                for (int i = 0; i <= dg_Vendas.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_Vendas.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {
                        lst_ID_Venda += dg_Vendas.Rows[i].Cells["col_ID"].Value + ", ";
                        _aux++;
                    }

                if (lst_ID_Venda == string.Empty)
                    return;

                lst_ID_Venda = lst_ID_Venda.Substring(0, lst_ID_Venda.Length - 2);

                UI_NFe_Emissor_Completo UI_NFe_Emissor_Completo = new UI_NFe_Emissor_Completo();
                UI_NFe_Emissor_Completo.NF_Venda = true;

                if (_aux > 1)
                    UI_NFe_Emissor_Completo.lst_ID_Venda = Venda.lst_ID_Venda;
                else
                    UI_NFe_Emissor_Completo.ID_Pedido = Convert.ToInt32(lst_ID_Venda);

                util_dados.CarregaForm(UI_NFe_Emissor_Completo, this.ParentForm);
            }

            Pesquisa();
        }
        #endregion

        #region FORM
        private void UI_Venda_Fatura_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Venda_Fatura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }

        private void UI_Venda_NF_Activated(object sender, EventArgs e)
        {
            if (Ativo == true)
                Pesquisa();
        }

        private void UI_Venda_NF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_IDVenda.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
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

        #region DATAGRID
        private void dg_Vendas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Vendas.Rows.Count - 1; i++)
                    dg_Vendas.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Vendas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dg_Vendas_DoubleClick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value = true;
        }

        private void dg_Vendas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Busca_Item();
        }
        #endregion
    }
}
