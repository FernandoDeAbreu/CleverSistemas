using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
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
    public partial class UI_Venda_Manutacao : Sistema.UI.UI_Modelo
    {
        public UI_Venda_Manutacao()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        BLL_Venda BLL_Venda;
        #endregion

        #region ESTRUTURA
        DTO_Venda Venda;
        DTO_Produto_Item Produto_Item;

        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Usuario Usuario;
        #endregion

        #region PROPRIEDADES
        public Manutencao_Venda Tipo_Manutencao { get; set; }
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;

        bool Seleciona = false;

        List<DTO_Produto_Item> lst_Produto;

        DataTable DTR_Empresa;
        DataTable DTR_Pedido;
        DataTable DTR_ItemPedido;
        DataTable DTR_Financeiro;
        DataTable DTR_Pessoa;
        DataTable DTR_Endereco;
        DataTable DTR_Telefone;
        DataTable DTR_Email;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            switch (Tipo_Manutencao)
            {
                case Manutencao_Venda.Cancelamento:
                    this.Text = "CANCELAMENTO DE VENDAS";
                    dg_Vendas.Columns.RemoveAt(0);
                    break;

                case Manutencao_Venda.Impressao:
                    this.Text = "IMPRESSÃO DE VENDAS";
                    bt_Cancela.Visible = false;
                    bt_Excluir.Visible = false;
                    bt_Imprime.Enabled = true;
                    break;
            }


            this.Text = "MANUTENÇÃO DE VENDAS";

            TabPage1.Text = "VENDAS";

            tabctl.TabPages.Remove(TabPage2);
            tabctl.SelectedTab = TabPage1;

            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;

            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            dg_Vendas.AutoGenerateColumns = false;
            dg_Itens.AutoGenerateColumns = false;

            CarregaCB();
        }

        public void CarregaCB()
        {
            DataTable _DT = new DataTable();
            List<string> aux = new List<string> { "EMISSÃO", "FATURAMENTO" };
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;


            _DT = new DataTable();
            _DT = util_Param.Pesquisa_NFE();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_NFe);
            cb_NFe.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_Fatura();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 0;
        }

        private void Busca_Item(int _ID)
        {
            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = _ID;
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
            else
                dg_Itens.Rows.Clear();
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
                dg_Itens.Rows[i].Cells["col_Descricao"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens.Rows[i].Cells["col_Acrescimo"].Value = _lst_Produto[i].Acrescimo;
                dg_Itens.Rows[i].Cells["col_Desconto"].Value = _lst_Produto[i].Desconto;
                dg_Itens.Rows[i].Cells["col_ValorUnitario"].Value = _lst_Produto[i].ValorProduto;
                //dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = _lst_Produto[i].ValorVenda;
                //dg_Itens.Rows[i].Cells["col_Informacao"].Value = _lst_Produto[i].Informacao;
                dg_Itens.Rows[i].Cells["col_TipoSaida"].Value = _lst_Produto[i].Descricao_Saida;
                dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;

                SubTotal += _lst_Produto[i].Quantidade * (_lst_Produto[i].ValorProduto + _lst_Produto[i].Acrescimo);
                TotalDesconto += _lst_Produto[i].Quantidade * _lst_Produto[i].Desconto;
            }

            txt_Total.Text = util_dados.ConfigNumDecimal(SubTotal - TotalDesconto, 2);
        }

        public void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
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
            try
            {
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

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

                Venda.ID = util_dados.Verifica_int(txt_IDP.Text);
                Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Venda.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

                switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                            mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                        {
                            Venda.Consulta_Emissao.Filtra = true;
                            Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                            Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        }
                        break;

                    case "FATURAMENTO":
                        if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                            mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                        {
                            Venda.Consulta_Fatura.Filtra = true;
                            Venda.Consulta_Fatura.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                            Venda.Consulta_Fatura.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        }
                        break;
                }
                DataTable _DT = new DataTable();

                _DT = BLL_Venda.Busca(Venda);

                dg_Vendas.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Itens);
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
                int aux = 0;

                for (int i = 0; i <= dg_Vendas.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_Vendas.Rows[i].Cells["col_Seleciona"].Value) == true)
                        aux++;

                if (aux == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                    return;
                }

                string Impressora = string.Empty;
                PrintDialog EscolheImpressora = new PrintDialog();
                PrintDocument documento;
                util_Impressao imp = new util_Impressao();

                if (EscolheImpressora.ShowDialog() == DialogResult.OK)
                {
                    documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                }
                else
                    return;

                for (int i = 0; i <= dg_Vendas.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_Vendas.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {
                        LocalReport rpt = new LocalReport();
                        string rpt_Nome = string.Empty;

                        BLL_Pessoa = new BLL_Pessoa();
                        Pessoa = new DTO_Pessoa();
                        Endereco = new DTO_Pessoa_Endereco();
                        Telefone = new DTO_Pessoa_Telefone();
                        Email = new DTO_Pessoa_Email();

                        Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                        DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                        BLL_Venda = new BLL_Venda();
                        Venda = new DTO_Venda();

                        Venda.ID = Convert.ToInt32(dg_Vendas.Rows[i].Cells["col_ID_Venda"].Value);

                        DTR_Pedido = BLL_Venda.Busca_Relatorio(Venda);
                        DTR_ItemPedido = BLL_Venda.Busca_Item(Venda);
                        DTR_Financeiro = BLL_Venda.Busca_Financeiro(Venda);

                        string Financeiro = string.Empty;
                        string TipoPagto = string.Empty;

                        if (DTR_Financeiro.Rows.Count > 0)
                        {
                            for (int y = 0; y <= DTR_Financeiro.Rows.Count - 1; y++)
                            {
                                if (TipoPagto != DTR_Financeiro.Rows[y]["PrevisaoPagto"].ToString())
                                {
                                    TipoPagto = DTR_Financeiro.Rows[y]["PrevisaoPagto"].ToString();

                                    Financeiro += DTR_Financeiro.Rows[y]["PrevisaoPagto"] + "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[y]["Vencimento"].ToString()), 3)
                                                      + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[y]["Valor"], 2) + ")";
                                }
                                else
                                    Financeiro += "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[y]["Vencimento"].ToString()), 3)
                                                + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[y]["Valor"], 2) + ")";
                            }
                        }
                        else
                            Financeiro = DTR_Pedido.Rows[0]["PrevisaoPagto"].ToString();

                        if (DTR_ItemPedido.Rows.Count <= 11 && Parametro_Venda.Permitir2Vias == true)
                        {
                            rpt_Nome = "rpt_Venda2.rdlc";
                            for (int y = DTR_ItemPedido.Rows.Count; y <= 11; y++)
                            {
                                DTR_ItemPedido.Rows.Add();
                                DTR_ItemPedido.Rows[y]["DescricaoProduto"] = "";
                                DTR_ItemPedido.Rows[y]["ValorVenda"] = 0;
                                DTR_ItemPedido.Rows[y]["Quantidade"] = 0;
                                DTR_ItemPedido.Rows[y]["Desconto"] = 0;
                                DTR_ItemPedido.Rows[y]["Acrescimo"] = 0;
                                DTR_ItemPedido.AcceptChanges();
                            }
                        }
                        else
                            rpt_Nome = "rpt_Venda.rdlc";

                        string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                        rpt.ReportPath = Caminhorpt;

                        Pessoa.TipoPessoa = Convert.ToInt32(dg_Vendas.Rows[i].Cells["col_TipoPessoa"].Value);
                        Pessoa.ID = Convert.ToInt32(dg_Vendas.Rows[i].Cells["col_ID_Pessoa"].Value);

                        DTR_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);

                        Endereco.Principal = true;
                        Pessoa.Endereco.Add(Endereco);
                        DTR_Endereco = BLL_Pessoa.Busca_Endereco(Pessoa);

                        Telefone.Principal = true;
                        Pessoa.Telefone.Add(Telefone);
                        DTR_Telefone = BLL_Pessoa.Busca_Telefone(Pessoa);

                        Email.Principal = true;
                        Pessoa.Email.Add(Email);
                        DTR_Email = BLL_Pessoa.Busca_Email(Pessoa);

                        ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda_Pedido", DTR_Pedido);
                        ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item_Pedido", DTR_ItemPedido);
                        ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
                        ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
                        ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
                        ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

                        ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
                        ReportParameter p2 = new ReportParameter("TotalPedido", util_dados.ConfigNumDecimal(DTR_ItemPedido.Compute("Sum(ValorTotal)", "ValorTotal > 0"), 2));

                        BLL_Usuario = new BLL_Usuario();
                        Usuario = new DTO_Usuario();
                        Usuario.ID = Convert.ToInt32(DTR_Pedido.Rows[0]["ID_UsuarioComissao1"]);
                        Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;


                        DataTable _DT = new DataTable();
                        _DT = BLL_Usuario.Busca(Usuario);

                        ReportParameter p3;
                        if (_DT.Rows.Count > 0 &&
                            Usuario.ID > 0)
                            p3 = new ReportParameter("Vendedor", _DT.Rows[0]["Descricao"].ToString());
                        else
                            p3 = new ReportParameter("Vendedor", "");

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_Pedido);
                        rpt.DataSources.Add(ds_ItemPedido);
                        rpt.DataSources.Add(ds_Pessoa);
                        rpt.DataSources.Add(ds_Endereco);
                        rpt.DataSources.Add(ds_Telefone);
                        rpt.DataSources.Add(ds_Email);

                        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });

                        rpt.Refresh();

                        imp.Cria_lst_Relatorio(rpt);
                    }

                imp.Imprime_lst_Relatorio(documento);
                imp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Venda_Manutacao_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Venda_Manutacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_IDP.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Venda_Manutacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

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
            if (mk_DataFinal.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

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
            if (Tipo_Manutencao == Manutencao_Venda.Cancelamento)
                return;

            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Vendas.Rows.Count - 1; i++)
                    dg_Vendas.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Vendas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (Tipo_Manutencao == Manutencao_Venda.Cancelamento)
                return;

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

        private void dg_Vendas_DoubleClick(object sender, EventArgs e)
        {
            if (Tipo_Manutencao == Manutencao_Venda.Cancelamento)
                return;

            if (Convert.ToBoolean(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Seleciona"].Value = true;

        }
        #endregion

        #region TEXTBOX
        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) > 0)
                Busca_Item(Convert.ToInt32(txt_ID.Text));
        }
        #endregion

        #region BUTTON
        private void bt_Cancela_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Cancelado"].Value) == true)
                {
                    MessageBox.Show(util_msg.msg_ErroRegistroJaCancelado, this.Text);
                    return;
                }

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaCancelamento, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = Convert.ToInt32(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_ID_Venda"].Value);

                Venda.Item = lst_Produto;
                Venda.Cancelado = true;
                Venda.Informacao = "(VENDA CANCELADA) - " + txt_Informacao.Text;

                BLL_Venda.Cancela_Venda(Venda);

                MessageBox.Show(util_msg.msg_RegistroCancelado, this.Text);
                MessageBox.Show(util_msg.msg_Altera_Financeiro, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex, this.Text);
            }
        }

        private void bt_Excluir_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Cancelado"].Value) == true)
            {
                MessageBox.Show(util_msg.msg_ErroRegistroJaCancelado, this.Text);
                return;
            }

            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoVenda, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = Convert.ToInt32(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_ID_Venda"].Value);

                Venda.Item = lst_Produto;

                BLL_Venda.Exclui(Venda);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex, this.Text);
            }
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
