using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Venda_Devolucao : Sistema.UI.UI_Modelo
    {
        public UI_Venda_Devolucao()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Venda BLL_Venda;
        BLL_Produto BLL_Produto;
        BLL_Parametro BLL_Parametro;
        BLL_Pessoa BLL_Pessoa;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        #endregion

        #region ESTRUTURA
        DTO_Venda Venda;
        DTO_Produto Produto;
        DTO_Parametro Parametro;
        DTO_Pessoa Pessoa;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Produto_Item Produto_Item;
        DTO_FluxoCaixa FluxoCaixa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "DEVOLUÇÃO DE VENDAS";

            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;
            bt_Edita.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            dg_Itens.AutoGenerateColumns = false;

            tabctl.TabPages.Remove(TabPage2);

            Carrega_Parametro();
        }

        private void Consulta_Produto()
        {
            UI_Produto_Consulta frm = new UI_Produto_Consulta();
            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;

            txt_ID_Produto.Text = frm.ID_Produto.ToString();
            txt_DescricaoProduto.Text = frm.Descricao;

            txt_InformacaoItem.Focus();
        }

        private void Carrega_Parametro()
        {
            BLL_Parametro = new BLL_Parametro();
            Parametro = new DTO_Parametro();

            Parametro.Tipo = 2;
            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count > 0)
            {
                Parametro_Venda.ID_TabelaVendaPadrao = Convert.ToInt32(_DT.Rows[0]["ID_TabelaVenda"]);
                Parametro_Venda.ID_ConsumidorFinal = Convert.ToInt32(_DT.Rows[0]["ID_ConsumidorFinal"]);
            }
        }

        private void Busca_Produto()
        {
            if (util_dados.Verifica_int64(txt_Barra.Text) == 0)
                return;

            try
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.Consulta_PDV = txt_Barra.Text;
                Produto.Consulta_Tipo = true;
                Produto.Tipo = "1, 3, 5";
                Produto.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();

                _DT = BLL_Produto.Busca_PDV(Produto);

                if (_DT.Rows.Count == 1)
                {
                    txt_ID_Produto.Text = _DT.Rows[0]["ID_Produto"].ToString();
                    txt_DescricaoProduto.Text = _DT.Rows[0]["Descricao"].ToString();

                    txt_InformacaoItem.Focus();
                }
                else
                {
                    util_dados.LimpaCampos(this, gb_Produto);
                    txt_Quantidade.Text = "1,00";

                    txt_Barra.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Devolver(double _Quantidade, int _ID_Produto)
        {
            double _Qt_Vendida = 0;
            double _Qt_Devolvido = 0;
            int _Qt_item = 0;
            try
            {
                for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value) == _ID_Produto)
                    {
                        _Qt_Vendida += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Quantidade"].Value);
                        _Qt_Devolvido += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value);
                        _Qt_item++;
                    }
                }

                if (_Qt_Vendida == 0)
                    throw new Exception(util_msg.msg_Devolucao_Produto_Null);

                if (_Qt_Vendida - _Qt_Devolvido < _Quantidade)
                    throw new Exception(util_msg.msg_Devolucao_Qt_Maior);

                if (_Qt_item == 1)
                {
                    for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                        if (Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value) == _ID_Produto)
                            dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value = _Quantidade + _Qt_Devolvido;
                }

                if (_Qt_item > 1)
                {
                    for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                        if (Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value) == _ID_Produto)
                        {
                            double Qt_Temp = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Quantidade"].Value) - Convert.ToDouble(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value);

                            if (Qt_Temp > 0)
                            {
                                if (Qt_Temp < _Quantidade)
                                {
                                    dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value = Qt_Temp;
                                    _Quantidade = _Quantidade - Qt_Temp;
                                }
                                else
                                {
                                    dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value = _Quantidade;
                                    break;
                                }
                            }
                        }
                }

                util_dados.LimpaCampos(this, gb_Produto);
                txt_Quantidade.Text = "1,00";

                txt_Barra.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Limpa_Campo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Pessoa);
            util_dados.LimpaCampos(this, gb_Produto);

            dg_Itens.DataSource = null;

            txt_Quantidade.Text = "0,00";
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            util_dados.LimpaCampos(this, gb_Pessoa);
            dg_Itens.DataSource = null;

            if (util_dados.Verifica_int(txt_ID.Text) == 0)
                return;

            try
            {
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(txt_ID.Text);
                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Venda.Pesquisa_Cancelado = true;
                Venda.Cancelado = false;

                DataTable _DT = new DataTable();

                _DT = BLL_Venda.Busca(Venda);

                if (_DT.Rows.Count > 0)
                {
                    DG.DataSource = _DT;
                    util_dados.CarregaCampo(this, _DT, gb_Pessoa);

                    _DT = new DataTable();
                    _DT = BLL_Venda.Busca_Item(Venda);

                    dg_Itens.DataSource = _DT;

                    bt_Grava.Enabled = true;
                }
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
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaDevolucao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Produto = new BLL_Produto();
                BLL_Venda = new BLL_Venda();
                Produto = new DTO_Produto();
                Produto_Estoque = new DTO_Produto_Estoque();
                Produto_Item = new DTO_Produto_Item();
                Venda = new DTO_Venda();
                Venda.Item = new List<DTO_Produto_Item>();
                Produto.Estoque = new List<DTO_Produto_Estoque>();

                Produto.Estoque.Add(Produto_Estoque);
                Venda.Item.Add(Produto_Item);

                double Valor_Devolucao = 0;
                #region LANÇA ESTOQUE E MOVIMENTAÇÃO DE PRODUTO DEVOLVIDO
                for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                    if (dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value != null &&
                        util_dados.Verifica_Double(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value.ToString()) > 0)
                    {
                        if (ck_Faturado.Checked == true)
                        {
                            Produto.Estoque[0].Estoque_Atual = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value);
                            Produto.Estoque[0].ID_Grade = Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Grade"].Value);
                            Produto.Estoque[0].Adiciona = true;

                            Produto.ID = Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value);
                            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                            BLL_Produto.Atualiza_Estoque(Produto);//ATUALIZA ESTOQUE PRODUTO

                            Produto.Data = DateTime.Now;
                            Produto.Tipo_Movimento = 1;
                            Produto.Informacao = "DEVOLUÇÃO VENDA Nº " + txt_ID.Text;
                            Produto.Quantidade = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value);

                            BLL_Produto.Grava_MovimentoProduto(Produto);//LANÇA MOVIMENTAÇÃO DE PRODUTO

                            Venda.Item[0].ID = Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Tabela"].Value);
                            Venda.Item[0].Quantidade = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value);
                            Venda.Item[0].Informacao = Convert.ToString("Devolução de " + util_dados.ConfigNumDecimal(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value, 3) + " Itens.");
                        }
                        BLL_Venda.Altera_Qt_Item(Venda); //ATUALIZA INFORMAÇÃO NA VENDA

                        Valor_Devolucao += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_QuantidadeDevolvida"].Value) * Convert.ToDouble(dg_Itens.Rows[i].Cells["col_ValorVenda"].Value);
                    }
                #endregion

                #region LANÇA DEVOLUÇÃO DE VALOR
                if (ck_Faturado.Checked == true)
                {
                    BLL_FluxoCaixa = new BLL_FluxoCaixa();
                    FluxoCaixa = new DTO_FluxoCaixa();

                    FluxoCaixa.ID = 0;
                    FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    FluxoCaixa.Emissao = DateTime.Now;
                    FluxoCaixa.Caixa = Parametro_Financeiro.ID_Caixa_Principal;
                    FluxoCaixa.Documento = txt_ID.Text;
                    FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_ContaDevolucaoVenda;
                    FluxoCaixa.Credito = 0;
                    FluxoCaixa.Debito = Valor_Devolucao;
                    FluxoCaixa.Informacao = "DEVOLUÇÃO VENDA Nº " + txt_ID.Text;
                    FluxoCaixa.Conciliado = true;
                    FluxoCaixa.ID_Pagamento = Parametro_Venda.PagamentoTrocoDevolucao;
                    FluxoCaixa.Planejamento = false;

                    BLL_FluxoCaixa.Grava(FluxoCaixa);
                }
                #endregion

                MessageBox.Show(util_msg.msg_Grava, this.Text);

                Limpa_Campo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Imprimir()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
                return;

            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_Venda_Conferencia.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_Venda = new DataTable();
            DataTable _DT_Item = new DataTable();

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = util_dados.Verifica_int(txt_ID.Text);

            _DT_Venda = BLL_Venda.Busca(Venda);
            _DT_Item = BLL_Venda.Busca_Item(Venda);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda", _DT_Venda);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item", _DT_Item);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pedido);
            rpt.DataSources.Add(ds_ItemPedido);

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

        public override void Visualizar()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
                return;

            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_Venda_Conferencia.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_Venda = new DataTable();
            DataTable _DT_Item = new DataTable();

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = util_dados.Verifica_int(txt_ID.Text);

            _DT_Venda = BLL_Venda.Busca(Venda);
            _DT_Item = BLL_Venda.Busca_Item(Venda);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda", _DT_Venda);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item", _DT_Item);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pedido);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemPedido);

            frm_rpt.rpt_Viewer.RefreshReport();
        }
        #endregion

        #region FORM
        private void UI_Venda_Conferencia_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Venda_Conferencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F3)
                txt_Barra.Focus();

            if (e.KeyCode == Keys.F10)
                Consulta_Produto();
        }

        private void UI_Venda_Conferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Barra.Focused == true)
            {

                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0 ||
                    KeyAscii == 13)
                    e.Handled = true;
            }
        }
        #endregion

        #region BUTTON
        private void bt_Produto_Click(object sender, EventArgs e)
        {
            Consulta_Produto();
        }

        private void bt_PesquisaVenda_Click(object sender, EventArgs e)
        {
            Pesquisa();
        }

        private void bt_Conferir_Click(object sender, EventArgs e)
        {
            Devolver(Convert.ToDouble(txt_Quantidade.Text), util_dados.Verifica_int(txt_ID_Produto.Text));
        }
        #endregion

        #region TEXTBOX
        private void txt_Barra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space ||
               e.KeyCode == Keys.Multiply) //PESQUISA PRODUTO
            {
                if (util_dados.Verifica_Double(txt_Barra.Text.Replace("*", "")) > 0)
                    txt_Quantidade.Text = util_dados.ConfigNumDecimal(txt_Barra.Text, 3);

                txt_Barra.Text = string.Empty;
                txt_Barra.Focus();
            }

            if (e.KeyCode == Keys.Enter) //PESQUISA PRODUTO
                Busca_Produto();
        }

        private void txt_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //PESQUISA PRODUTO
                Pesquisa();
        }
        private void txt_Barra_Leave(object sender, EventArgs e)
        {
            if (txt_Barra.Text.Trim() != string.Empty)
                Busca_Produto();
        }
        #endregion
    }
}
