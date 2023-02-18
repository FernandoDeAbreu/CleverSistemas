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
    public partial class UI_Venda_Conferencia : Sistema.UI.UI_Modelo
    {
        public UI_Venda_Conferencia()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Venda BLL_Venda;
        BLL_Produto BLL_Produto;
        BLL_Parametro BLL_Parametro;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        int Situacao_Conferencia = 0;
        #endregion

        #region ESTRUTURA
        DTO_Venda Venda;
        DTO_Produto Produto;
        DTO_Parametro Parametro;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONFERÊNCIA DE VENDAS";

            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;
            bt_Edita.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

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

        private void Confere_Produto(double _Quantidade, int _ID_Produto)
        {
            Verifica_Conferencia(true);

            double _Qt_Vendida = 0;
            double _Qt_Conferido = 0;
            int _Qt_item = 0;
            try
            {
                for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value) == _ID_Produto)
                    {
                        _Qt_Vendida += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Quantidade"].Value);
                        _Qt_Conferido += Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value);
                        _Qt_item++;
                    }
                }

                if (_Qt_Vendida == 0)
                    throw new Exception(util_msg.msg_Conferencia_Produto_Null);

                if (_Qt_Vendida - _Qt_Conferido < _Quantidade)
                    throw new Exception(util_msg.msg_Conferencia_Qt_Maior);

                if (_Qt_item == 1)
                {
                    for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                        if (Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value) == _ID_Produto)
                            dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value = _Quantidade + _Qt_Conferido;
                }

                if (_Qt_item > 1)
                {
                    for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
                        if (Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value) == _ID_Produto)
                        {
                            double Qt_Temp = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Quantidade"].Value) - Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value);

                            if (Qt_Temp > 0)
                            {
                                if (Qt_Temp < _Quantidade)
                                {
                                    dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value = Qt_Temp;
                                    _Quantidade = _Quantidade - Qt_Temp;
                                }
                                else
                                {
                                    dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value = _Quantidade;
                                    break;
                                }
                            }
                        }
                }

                Config_DG();
                util_dados.LimpaCampos(this, gb_Produto);
                txt_Quantidade.Text = "1,00";

                txt_Barra.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Config_DG()
        {
            double Quantidade = 0;
            double Qt_Conferido = 0;

            for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
            {
                Quantidade = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Quantidade"].Value);
                Qt_Conferido = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value);

                if (Quantidade == Qt_Conferido)
                    dg_Itens.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;

                if (Quantidade > Qt_Conferido)
                    dg_Itens.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
            }

            dg_Itens.ClearSelection();
        }

        private List<DTO_Produto_Item> Carrega_DG()
        {
            DTO_Produto_Item _Item;
            List<DTO_Produto_Item> _lst_Item = new List<DTO_Produto_Item>();

            for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
            {
                _Item = new DTO_Produto_Item();

                _Item.ID = Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Tabela"].Value);
                _Item.Quantidade_Conferido = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value);

                _lst_Item.Add(_Item);
            }

            return _lst_Item;
        }

        private void Verifica_Conferencia(bool _Grava)
        {
            Situacao_Conferencia = 1; //EM CONFERENCIA

            double Quantidade = 0;
            double Qt_Conferido = 0;

            bool Concluido = true;

            for (int i = 0; i <= dg_Itens.Rows.Count - 1; i++)
            {
                Quantidade = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Quantidade"].Value);
                Qt_Conferido = Convert.ToDouble(dg_Itens.Rows[i].Cells["col_Qt_Conferido"].Value);

                if (Quantidade != Qt_Conferido)
                    Concluido = false;
            }

            if (Concluido == true)
            {
                Situacao_Conferencia = 2; //CONFERIDO

                if (_Grava == false)
                    Gravar();
            }
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
                Verifica_Conferencia(true);

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(txt_ID.Text);
                Venda.Situacao_Conferencia = Situacao_Conferencia;
                Venda.ID_Usuario_Conferencia = Parametro_Usuario.ID_Usuario_Ativo;

                Venda.Item = new List<DTO_Produto_Item>();
                Venda.Item = Carrega_DG();

                BLL_Venda.Altera_Status_Conferencia(Venda);

                MessageBox.Show(util_msg.msg_Grava, this.Text);

                Status = StatusForm.Consulta;
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
            Confere_Produto(Convert.ToDouble(txt_Quantidade.Text), util_dados.Verifica_int(txt_ID_Produto.Text));
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
            {
                Busca_Produto();
            }
        }

        private void txt_ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //PESQUISA PRODUTO
            {
                Pesquisa();
            }
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_Itens_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Config_DG();
        }
        #endregion
    }
}
