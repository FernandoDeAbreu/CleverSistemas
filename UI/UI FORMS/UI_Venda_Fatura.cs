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
    public partial class UI_Venda_Fatura : Sistema.UI.UI_Modelo
    {
        public UI_Venda_Fatura()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_PlanoConta BLL_PlanoConta;
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        BLL_Produto BLL_Produto;
        BLL_Venda BLL_Venda;
        #endregion

        #region VARIAVEIS DIVERSAS
        List<DTO_Produto_Item> lst_Produto;
        #endregion

        #region ESTRUTURA
        DTO_PlanoConta PlanoConta;
        DTO_CReceber CReceber;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Venda Venda;
        DTO_Produto_Item Produto_Item;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            tabctl.TabPages.Remove(TabPage2);
            this.Text = "FATURA VENDAS";

            bt_Edita.Visible = false;
            bt_Exclui.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Text = "FATURAR";

            dg_Vendas.AutoGenerateColumns = false;
            dg_Itens.AutoGenerateColumns = false;

            mk_DataFatura.Text = DateTime.Now.ToString();

            CarregaCB();
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
            txt_ValorPedido.Text = util_dados.ConfigNumDecimal(SubTotal - TotalDesconto, 2);
        }

        public void CarregaCB()
        {
            List<string> Conferido = new List<string>();
            Conferido.Add("NÃO FILTRAR");
            Conferido.Add("EM CONFERÊNCIA");
            Conferido.Add("CONFERIDOS");

            DataTable _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(0, Conferido);

            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Conferencia);
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                LimpaCampo();

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.Pesquisa_Faturado = true;
                Venda.Faturado = false;

                Venda.Pesquisa_Cancelado = true;
                Venda.Cancelado = false;

                Venda.Situacao_Conferencia = Convert.ToInt32(cb_Conferencia.SelectedValue);

                DataTable _DT = new DataTable();
                _DT = BLL_Venda.Busca_Fatura(Venda);
                dg_Vendas.DataSource = _DT;

                if (_DT.Rows.Count == 0)
                    dg_Itens.DataSource = null;

                util_dados.CarregaCampo(this, _DT, gb_Produto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        //MODIFICADO PARA ABRIR FATURAMENTO
        public override void Gravar()
        {
            try
            {
                if (dg_Vendas.Rows.Count == 0)
                    return;

                bool Finaliza_Venda = true;

                #region LANÇA FINANCEIRO VENDA
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                bool Faturamento_Personalizado = false;
                string Faturamento = string.Empty;

                Pessoa.TipoPessoa = int.Parse(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_TipoPessoa"].Value.ToString());
                Pessoa.ID = int.Parse(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_ID_Pessoa"].Value.ToString());
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();
                _DT = BLL_Pessoa.Busca(Pessoa);
                if (_DT.Rows.Count > 0)
                    if (util_dados.Verifica_int(_DT.Rows[0]["Dia_Faturamento"].ToString().Replace("/", "")) != 0)
                    {
                        Faturamento_Personalizado = true;
                        Faturamento = _DT.Rows[0]["Dia_Faturamento"].ToString();
                    }

                UI_Venda_Lanca frm = new UI_Venda_Lanca();

                frm.Documento = txt_ID.Text;
                frm.TipoPessoa = int.Parse(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_TipoPessoa"].Value.ToString());
                frm.ID_Pessoa = int.Parse(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_ID_Pessoa"].Value.ToString());
                frm.Descricao_Pessoa = dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_DescricaoPessoa"].Value.ToString();
                frm.Valor = Convert.ToDouble(txt_ValorPedido.Text);
                frm.Emissao = Convert.ToDateTime(mk_DataFatura.Text);
                frm.ID_Pagamento = int.Parse(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_ID_Pagamento"].Value.ToString());
                frm.ID_Parcelamento = int.Parse(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_ID_Parcelamento"].Value.ToString());
                frm.Finaliza_Venda = Finaliza_Venda;
                frm.Faturamento_Personalizado = Faturamento_Personalizado;
                frm.Faturamento = Faturamento;
                frm.ShowDialog();

                if (frm.Concluido == false)
                    return;
                #endregion

                #region ALTERA SITUAÇÃO PEDIDO
                Venda = new DTO_Venda();
                BLL_Venda = new BLL_Venda();

                Venda.ID = int.Parse(txt_ID.Text);
                Venda.Faturado = true;
                Venda.DataFatura = Convert.ToDateTime(mk_DataFatura.Text);

                BLL_Venda.Altera_Fatura(Venda);
                BLL_Venda.Altera_NFe(Venda);
                #endregion

                #region BAIXA DE ESTOQUE
                _DT = new DataTable();
                _DT = BLL_Venda.Busca_Item(Venda);

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();
                Produto_Estoque = new DTO_Produto_Estoque();
                Produto.Estoque = new List<DTO_Produto_Estoque>();

                Produto_Item = new DTO_Produto_Item();

                Produto.Estoque.Add(Produto_Estoque);

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    double Quantidade = util_dados.Verifica_Double(_DT.Rows[i]["Quantidade"].ToString()) - util_dados.Verifica_Double(_DT.Rows[i]["Quantidade_Entregue"].ToString());

                    if (Quantidade > 0)
                    {
                        Produto.Estoque[0].Estoque_Atual = Quantidade;
                        Produto.Estoque[0].ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID_Grade"]);
                        Produto.Estoque[0].Adiciona = false;

                        Produto.ID = Convert.ToInt32(_DT.Rows[i]["ID_Produto"]);
                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Produto.Tipo_Movimento = 2;
                        Produto.Informacao = "VENDA KIT (" + _DT.Rows[i]["DescricaoProduto"].ToString() + ") VENDA Nº " + Venda.ID;

                        BLL_Produto.Atualiza_Estoque(Produto);

                        Produto_Item.ID = Convert.ToInt32(_DT.Rows[i]["IDItem"]);
                        Produto_Item.Quantidade_Entregue = Quantidade;

                        BLL_Venda.Altera_Qt_Entregue(Produto_Item);
                    }
                }
                #endregion

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ImprimeVenda, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.Yes)
                    Imprimir();

                Pesquisa();
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
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();
                Endereco = new DTO_Pessoa_Endereco();
                Telefone = new DTO_Pessoa_Telefone();
                Email = new DTO_Pessoa_Email();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(txt_ID.Text);

                DataTable DTR_Pedido = BLL_Venda.Busca_Relatorio(Venda);
                DataTable DTR_ItemPedido = BLL_Venda.Busca_Item(Venda);
                DataTable DTR_Financeiro = BLL_Venda.Busca_Financeiro(Venda);

                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
                frm_rpt.Show();

                string rpt_Nome = "";

                string TipoPagto = string.Empty;
                string Financeiro = string.Empty;

                if (DTR_Financeiro.Rows.Count > 0)
                    for (int i = 0; i <= DTR_Financeiro.Rows.Count - 1; i++)
                    {
                        if (TipoPagto != DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString())
                        {
                            TipoPagto = DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString();

                            Financeiro += DTR_Financeiro.Rows[i]["PrevisaoPagto"] + "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                              + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";
                        }
                        else
                            Financeiro += "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                        + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";

                    }

                if (DTR_ItemPedido.Rows.Count <= 11 && Parametro_Venda.Permitir2Vias == true)
                {
                    rpt_Nome = "rpt_Venda2.rdlc";
                    for (int i = DTR_ItemPedido.Rows.Count; i <= 11; i++)
                    {
                        DTR_ItemPedido.Rows.Add();
                        DTR_ItemPedido.Rows[i]["DescricaoProduto"] = "";
                        DTR_ItemPedido.Rows[i]["ValorVenda"] = 0;
                        DTR_ItemPedido.Rows[i]["Quantidade"] = 0;
                        DTR_ItemPedido.Rows[i]["Desconto"] = 0;
                        DTR_ItemPedido.Rows[i]["Acrescimo"] = 0;
                        DTR_ItemPedido.AcceptChanges();
                    }
                }
                else
                    rpt_Nome = "rpt_Venda.rdlc";

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                Pessoa.TipoPessoa = 1;
                Pessoa.ID = Convert.ToInt32(dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_ID_Pessoa"].Value);
                DataTable DTR_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);

                Endereco.Principal = true;
                Pessoa.Endereco.Add(Endereco);
                DataTable DTR_Endereco = BLL_Pessoa.Busca_Endereco(Pessoa);

                Telefone.Principal = true;
                Pessoa.Telefone.Add(Telefone);
                DataTable DTR_Telefone = BLL_Pessoa.Busca_Telefone(Pessoa);

                Email.Principal = true;
                Pessoa.Email.Add(Email);
                DataTable DTR_Email = BLL_Pessoa.Busca_Email(Pessoa);

                ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda_Pedido", DTR_Pedido);
                ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item_Pedido", DTR_ItemPedido);
                ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
                ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
                ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
                ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

                ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
                ReportParameter p2 = new ReportParameter("TotalPedido", util_dados.ConfigNumDecimal(txt_ValorPedido.Text, 2));
                ReportParameter p3 = new ReportParameter("Vendedor", dg_Vendas.Rows[dg_Vendas.CurrentRow.Index].Cells["col_Usuario"].Value.ToString());

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pedido);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemPedido);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

                frm_rpt.rpt_Viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_Pedido_TextChanged(object sender, EventArgs e)
        {
            if (txt_ID.Text.Trim() != string.Empty)
                Busca_Item(util_dados.Verifica_int(txt_ID.Text));
        }
        #endregion
    }
}
