using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.BLL;

namespace Sistema.UI
{
    public partial class UI_Produto_EstoqueMovimento : Sistema.UI.UI_Modelo
    {
        public UI_Produto_EstoqueMovimento()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        #endregion

        #region VARIAVEIS DIVERSAS
        string lst_CodigoProduto = string.Empty;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Produto Produto;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "MOVIMENTAÇÃO DE ESTOQUE";

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Pesquisa.Visible = false;
            tabctl.SelectedTab = TabPage1;

            Carrega_CB();

            mk_Data.Text = DateTime.Now.ToString();

            DataGridViewTextBoxColumn col_ID_Produto = new DataGridViewTextBoxColumn();
            col_ID_Produto.DataPropertyName = "ID_Produto";
            col_ID_Produto.HeaderText = "CÓD. PRODUTO";
            col_ID_Produto.Width = 70;
            dg_Produto.Columns.Add(col_ID_Produto);

            DataGridViewTextBoxColumn col_Produto = new DataGridViewTextBoxColumn();
            col_Produto.DataPropertyName = "Descricao";
            col_Produto.HeaderText = "PRODUTO";
            col_Produto.Width = 200;
            col_Produto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Produto.Columns.Add(col_Produto);

            DataGridViewTextBoxColumn col_Data = new DataGridViewTextBoxColumn();
            col_Data.DataPropertyName = "Data";
            col_Data.HeaderText = "DATA";
            col_Data.Width = 80;
            dg_Produto.Columns.Add(col_Data);

            DataGridViewTextBoxColumn col_UltimoLanc = new DataGridViewTextBoxColumn();
            col_UltimoLanc.DataPropertyName = "UltimoLancamento";
            col_UltimoLanc.HeaderText = "ÚLTIMA MOVIMENTAÇÃO";
            col_UltimoLanc.Width = 180;
            dg_Produto.Columns.Add(col_UltimoLanc);

            DataGridViewTextBoxColumn col_Pessoa = new DataGridViewTextBoxColumn();
            col_Pessoa.DataPropertyName = "Pessoa";
            col_Pessoa.HeaderText = "PESSOA";
            col_Pessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_Produto.Columns.Add(col_Pessoa);

            DataGridViewTextBoxColumn col_Tipo = new DataGridViewTextBoxColumn();
            col_Tipo.DataPropertyName = "Tipo";
            col_Tipo.HeaderText = "TIPO";
            col_Tipo.Width = 80;
            dg_Produto.Columns.Add(col_Tipo);

            DataGridViewTextBoxColumn col_Qt_Compra = new DataGridViewTextBoxColumn();
            col_Qt_Compra.DataPropertyName = "Compra";
            col_Qt_Compra.HeaderText = "QT. ENTRADA";
            col_Qt_Compra.Width = 100;
            col_Qt_Compra.DefaultCellStyle.Format = "N3";
            col_Qt_Compra.DefaultCellStyle.NullValue = "";
            col_Qt_Compra.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_Produto.Columns.Add(col_Qt_Compra);

            DataGridViewTextBoxColumn col_Qt_Venda = new DataGridViewTextBoxColumn();
            col_Qt_Venda.DataPropertyName = "Venda";
            col_Qt_Venda.HeaderText = "QT. SAÍDA";
            col_Qt_Venda.Width = 100;
            col_Qt_Venda.DefaultCellStyle.Format = "N3";
            col_Qt_Venda.DefaultCellStyle.NullValue = "";
            col_Qt_Venda.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg_Produto.Columns.Add(col_Qt_Venda);

            dg_Produto.AutoGenerateColumns = false;
        }

        private void Carrega_CB()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;

            DataTable _DT = new DataTable();

            _DT = BLL_Produto.Busca(Produto);

            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Produto);

            List<string> _aux = new List<string>();

            _aux.Add("ENTRADA");
            _aux.Add("SÁIDA");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, _aux), "Descricao", "ID", cb_Tipo);
        }

        private void Busca_Produto()
        {
            UI_Produto_Consulta UI_Produto_Consulta = new UI_Produto_Consulta();
            
            UI_Produto_Consulta.ShowDialog();

            if (UI_Produto_Consulta.ID_Produto == 0)
                return;

            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = UI_Produto_Consulta.ID_Produto;

            cb_ID_Grade.Focus();
        }

        private void Busca_Grade(int _ID)
        {
            BLL_Produto = new BLL_Produto();

            Produto = new DTO_Produto();

            Produto.ID = _ID;
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();

            _DT = BLL_Produto.Busca_Estoque(Produto);

            if (_DT == null)
            {
                MessageBox.Show("Estoque não cadastrado!");
                return;
            }

            util_dados.CarregaCombo(_DT, "DescricaoGrade", "ID_Grade", cb_ID_Grade);
            util_dados.CarregaCampo(this, _DT, gb_Pesquisa);
        }

        private void Busca_Movimentacao(int _ID)
        {
            BLL_Produto = new BLL_Produto();

            Produto = new DTO_Produto();

            Produto.ID = _ID;
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();

            _DT = BLL_Produto.Busca_ProdutoMovimento(Produto);
            dg_Produto.DataSource = _DT;
        }

        private void Lanca_Movimento()
        {
            if (txt_InformacaoItem.Text.Trim() == string.Empty)
            {
                MessageBox.Show(util_msg.msg_InformacaoProdutoNull, this.Text);
                return;
            }

            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_AlteracaoEstoque, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_Produto = new BLL_Produto();

                Produto = new DTO_Produto();
                Produto_Estoque = new DTO_Produto_Estoque();
                Produto.Estoque = new List<DTO_Produto_Estoque>();
                Produto.Estoque.Add(Produto_Estoque);

                double EstoqueAtual = Convert.ToDouble(txt_EstoqueAtual.Text);
                double Quantidade_Movimentar = Convert.ToDouble(txt_Quantidade.Text);
                
                Produto.Estoque[0].ID_Grade = Convert.ToInt32(cb_ID_Grade.SelectedValue);

                Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);

                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.Data = Convert.ToDateTime(mk_Data.Text);

                if (Convert.ToInt32(cb_Tipo.SelectedValue) == 1) //ENTRADA
                {
                    Produto.Estoque[0].Estoque_Atual = EstoqueAtual + Quantidade_Movimentar;

                    Produto.Tipo_Movimento = 1;
                    Produto.Informacao = txt_InformacaoItem.Text;
                    Produto.Quantidade = Quantidade_Movimentar;
                    BLL_Produto.Grava_MovimentoProduto(Produto);
                }

                if (Convert.ToInt32(cb_Tipo.SelectedValue) == 2) //SAÍDA
                {
                    Produto.Estoque[0].Estoque_Atual = EstoqueAtual - Quantidade_Movimentar;

                    Produto.Tipo_Movimento = 2;
                    Produto.Informacao = txt_InformacaoItem.Text;
                    Produto.Quantidade = Quantidade_Movimentar;
                    BLL_Produto.Grava_MovimentoProduto(Produto);
                }

                BLL_Produto.Grava_Estoque(Produto);

                MessageBox.Show(util_msg.msg_Altera, this.Text);

                Busca_Grade(util_dados.Verifica_int(cb_ID_Produto.SelectedValue.ToString()));
                Busca_Movimentacao(util_dados.Verifica_int(cb_ID_Produto.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_EstoqueMovimento_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_EstoqueMovimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Busca_Produto();
        }
        #endregion

        #region BUTTON

        private void bt_LancaMovimento_Click(object sender, EventArgs e)
        {
            Lanca_Movimento();
        }
        #endregion

        #region COMBOBOX
        private void cb_ID_Produto_Leave(object sender, EventArgs e)
        {
            if (cb_ID_Produto.SelectedValue != null)
            {
                Busca_Grade(util_dados.Verifica_int(cb_ID_Produto.SelectedValue.ToString()));
                Busca_Movimentacao(util_dados.Verifica_int(cb_ID_Produto.SelectedValue.ToString()));
            }

        }
        #endregion

        #region TEXTBOX
        private void txt_Quantidade_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Quantidade.Text) == 0)
                txt_Quantidade.Text = "1,000";

            txt_Quantidade.Text = util_dados.ConfigNumDecimal(txt_Quantidade.Text, 3);
        }
        #endregion

        #region MASKEDBOX
        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data.Text = Convert.ToString(DateTime.Now);
                mk_Data.Focus();
            }
        }
        #endregion
    }
}
