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
using System.IO;

namespace Sistema.UI
{
    public partial class UI_Produto_Consulta : Form
    {
        Locacao.frm_Locacao inst_locacao;
        public string rotina;
        public UI_Produto_Consulta()
        {
            InitializeComponent();
        }

        public UI_Produto_Consulta(Locacao.frm_Locacao locacao)
        {
            InitializeComponent();
            inst_locacao = locacao;
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        #endregion

        #region PROPRIEDADES
        public int ID_Produto { get; set; }
        public int ID_Tabela { get; set; }
        public int ID_Grade { get; set; }
        public string Descricao { get; set; }
        public string Referencia { get; set; }
        public string Codigo_ConsultaPDV { get; set; }
        public bool ConsultaPDV { get; set; }
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            DG.AutoGenerateColumns = false;

            lb_InfoAdicional1.Text = Parametro_CadastroPersonalizado.Info_Produto1;

            if (ID_Tabela == 0)
            {
                DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
                col_ID.Name = "col_ID";
                col_ID.DataPropertyName = "ID";
                col_ID.HeaderText = "CÓDIGO";
                col_ID.Width = 70;
                DG.Columns.Add(col_ID);

                DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
                col_Descricao.Name = "col_Descricao";
                col_Descricao.DataPropertyName = "Descricao";
                col_Descricao.HeaderText = "DESCRIÇÃO";
                col_Descricao.Width = 430;
                //col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DG.Columns.Add(col_Descricao);

                DataGridViewTextBoxColumn col_Referencia = new DataGridViewTextBoxColumn();
                col_Referencia.Name = "col_Referencia";
                col_Referencia.DataPropertyName = "Referencia";
                col_Referencia.HeaderText = "REFERÊNCIA";
                col_Referencia.Width = 100;
                DG.Columns.Add(col_Referencia);

                DataGridViewTextBoxColumn col_Fabricante = new DataGridViewTextBoxColumn();
                col_Fabricante.Name = "col_Fabricante";
                col_Fabricante.DataPropertyName = "Fabricante";
                col_Fabricante.HeaderText = "FABRICANTE";
                col_Fabricante.Width = 120;
                DG.Columns.Add(col_Fabricante);

                DataGridViewTextBoxColumn col_ID_Grade = new DataGridViewTextBoxColumn();
                col_ID_Grade.Name = "col_ID_Grade";
                col_ID_Grade.DataPropertyName = "ID_Grade";
                col_ID_Grade.HeaderText = "ID_Grade";
                col_ID_Grade.Visible = false;
                col_ID_Grade.Width = 120;
                DG.Columns.Add(col_ID_Grade);

                DataGridViewTextBoxColumn col_InfoAdicional1 = new DataGridViewTextBoxColumn();
                col_InfoAdicional1.Name = "col_InfoAdicional1";
                col_InfoAdicional1.DataPropertyName = "InfoAdicional1";
                col_InfoAdicional1.HeaderText = Parametro_CadastroPersonalizado.Info_Produto1;
                col_InfoAdicional1.Width = 120;
                DG.Columns.Add(col_InfoAdicional1);
            }

            if (ID_Tabela > 0)
            {
                DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
                col_ID.Name = "col_ID";
                col_ID.DataPropertyName = "ID";
                col_ID.HeaderText = "CÓDIGO";
                col_ID.Width = 70;
                DG.Columns.Add(col_ID);

                DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
                col_Descricao.Name = "col_Descricao";
                col_Descricao.DataPropertyName = "DescricaoCompleta";
                col_Descricao.HeaderText = "DESCRIÇÃO";
                col_Descricao.Width = 400;
                //col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DG.Columns.Add(col_Descricao);

                DataGridViewTextBoxColumn col_Referencia = new DataGridViewTextBoxColumn();
                col_Referencia.Name = "col_Referencia";
                col_Referencia.DataPropertyName = "Referencia";
                col_Referencia.HeaderText = "REFERÊNCIA";
                col_Referencia.Width = 100;
                DG.Columns.Add(col_Referencia);

                DataGridViewTextBoxColumn col_Fabricante = new DataGridViewTextBoxColumn();
                col_Fabricante.Name = "col_Fabricante";
                col_Fabricante.DataPropertyName = "Fabricante";
                col_Fabricante.HeaderText = "FABRICANTE";
                col_Fabricante.Width = 100;
                DG.Columns.Add(col_Fabricante);

                DataGridViewTextBoxColumn col_Valor = new DataGridViewTextBoxColumn();
                col_Valor.Name = "col_Valor";
                col_Valor.DataPropertyName = "ValorVenda";
                col_Valor.HeaderText = "VALOR VENDA";
                col_Valor.Width = 90;
                col_Valor.DefaultCellStyle.Format = "N2";
                DG.Columns.Add(col_Valor);

                DataGridViewTextBoxColumn col_Estoque = new DataGridViewTextBoxColumn();
                col_Estoque.Name = "col_Estoque";
                col_Estoque.DataPropertyName = "EstoqueAtual";
                col_Estoque.HeaderText = "ESTOQUE";
                col_Estoque.Width = 90;
                col_Estoque.DefaultCellStyle.Format = "N2";
                DG.Columns.Add(col_Estoque);

                DataGridViewTextBoxColumn col_ID_Grade = new DataGridViewTextBoxColumn();
                col_ID_Grade.Name = "col_ID_Grade";
                col_ID_Grade.DataPropertyName = "ID_Grade";
                col_ID_Grade.HeaderText = "ID_Grade";
                col_ID_Grade.Visible = false;
                col_ID_Grade.Width = 120;
                DG.Columns.Add(col_ID_Grade);

                DataGridViewTextBoxColumn col_InfoAdicional1 = new DataGridViewTextBoxColumn();
                col_InfoAdicional1.Name = "col_InfoAdicional1";
                col_InfoAdicional1.DataPropertyName = "InfoAdicional1";
                col_InfoAdicional1.HeaderText = Parametro_CadastroPersonalizado.Info_Produto1;
                col_InfoAdicional1.Width = 120;
                DG.Columns.Add(col_InfoAdicional1);
            }

            if (ConsultaPDV == true)
                Pesquisa();
        }

        private void Pesquisa()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_IDProdutoP.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_GrupoNivel.Text;
            Produto.Descricao = txt_DescricaoProdutoP.Text;
            Produto.Referencia = txt_ReferenciaP.Text;
            Produto.Barra = txt_BarraP.Text;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 3, 5";
            Produto.ID_Tabela = ID_Tabela;
            Produto.Fabricante = txt_FabricanteP.Text;
            Produto.InfoAdicional1 = txt_InfoProduto1.Text;

            DataTable _DT = new DataTable();

            if (ConsultaPDV == false)
            {
                if (ID_Tabela > 0)
                    _DT = BLL_Produto.Busca_new(Produto);
                else
                    _DT = BLL_Produto.Busca(Produto);

            }
            else
            {
                Produto.Consulta_PDV = Codigo_ConsultaPDV;
                _DT = BLL_Produto.Busca_PDV(Produto);
            }
            DG.DataSource = _DT;
            util_dados.CarregaCampo(this, _DT, gb_Imagem);

            DG.Focus();
        }

        private void Seleciona_Produto()
        {

          
            try
            {
                ID_Produto = Convert.ToInt32(DG.Rows[DG.CurrentRow.Index].Cells["col_ID"].Value);
                ID_Grade = Convert.ToInt32(DG.Rows[DG.CurrentRow.Index].Cells["col_ID_Grade"].Value);
                Descricao = DG.Rows[DG.CurrentRow.Index].Cells["col_Descricao"].Value.ToString();
                Referencia = DG.Rows[DG.CurrentRow.Index].Cells["col_Referencia"].Value.ToString();

                if (rotina == "Locação")
                {
                    inst_locacao.textBox4.Text = DG.Rows[DG.CurrentRow.Index].Cells["col_Referencia"].Value.ToString();
                    this.Close();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Grava_Historico();
                this.Close();
            }
        }

        private void Grava_Historico()
        {
            util_Temp.ID = txt_IDProdutoP.Text;
            util_Temp.Codigo_Grupo = mk_GrupoNivel.Text;
            util_Temp.Descricao = txt_DescricaoProdutoP.Text;
            util_Temp.Referencia = txt_ReferenciaP.Text;
            util_Temp.Barra = txt_BarraP.Text;
            util_Temp.Fabricante = txt_FabricanteP.Text;
            util_Temp.InformacaoAdicional = txt_InfoProduto1.Text;
        }

        private void Busca_Historico()
        {
            txt_IDProdutoP.Text = util_Temp.ID;
            mk_GrupoNivel.Text = util_Temp.Codigo_Grupo;
            txt_DescricaoProdutoP.Text = util_Temp.Descricao;
            txt_ReferenciaP.Text = util_Temp.Referencia;
            txt_BarraP.Text = util_Temp.Barra;
            txt_FabricanteP.Text = util_Temp.Fabricante;
            txt_InfoProduto1.Text = util_Temp.InformacaoAdicional;
        }

        #endregion

        #region BUTTON
        private void bt_Seleciona_Click(object sender, EventArgs e)
        {
            Seleciona_Produto();
           
           
         
        }

        private void bt_Localizar_Click(object sender, EventArgs e)
        {
            Pesquisa();
        }

        private void bt_PesquisaGrupo_Click(object sender, EventArgs e)
        {
            UI_GrupoNivel_Consulta frm = new UI_GrupoNivel_Consulta();
            frm.ShowDialog();
            mk_GrupoNivel.Text = frm.Cod_Conta;
        }
        #endregion

        #region FORM
        private void UI_Produto_Consulta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Consulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Busca_Historico();
        }

        private void UI_Produto_Consulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region DATAGRID
        private void dg_PesquisaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Seleciona_Produto();
        }
        #endregion

        #region TEXTBOX
        private void txt_DescricaoProdutoP_TextChanged(object sender, EventArgs e)
        {
            if (Parametro_Venda.Consulta_RapidaProduto == false)
                return;

            if (txt_DescricaoProdutoP.Text.Length >= 1)
            {
                Pesquisa();
                txt_DescricaoProdutoP.Focus();
                txt_DescricaoProdutoP.Select(txt_DescricaoProdutoP.Text.Length, 0);
            }
        }

        private void txt_DescricaoProdutoP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DG.Focus();
        }

        private void txt_IDProdutoP_TextChanged(object sender, EventArgs e)
        {
            if (Parametro_Venda.Consulta_RapidaProduto == false)
                return;

            if (txt_IDProdutoP.Text.Length >= 1)
            {
                Pesquisa();
                txt_IDProdutoP.Focus();
                txt_IDProdutoP.Select(txt_IDProdutoP.Text.Length, 0);
            }
        }

        private void txt_IDProdutoP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DG.Focus();
        }

        private void txt_ReferenciaP_TextChanged(object sender, EventArgs e)
        {
            if (Parametro_Venda.Consulta_RapidaProduto == false)
                return;

            if (txt_ReferenciaP.Text.Length >= 1)
            {
                Pesquisa();
                txt_ReferenciaP.Focus();
                txt_ReferenciaP.Select(txt_ReferenciaP.Text.Length, 0);
            }
        }

        private void txt_ReferenciaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DG.Focus();
        }

        private void txt_FabricanteP_TextChanged(object sender, EventArgs e)
        {
            if (Parametro_Venda.Consulta_RapidaProduto == false)
                return;

            if (txt_FabricanteP.Text.Length >= 1)
            {
                Pesquisa();
                txt_FabricanteP.Focus();
                txt_FabricanteP.Select(txt_FabricanteP.Text.Length, 0);
            }
        }

        private void txt_FabricanteP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DG.Focus();
        }

        private void txt_Imagem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Imagem.Text.Trim() != string.Empty)
                {
                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();

                    Produto.ID = util_dados.Verifica_int(txt_ID.Text);
                    Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    DataTable _DT = new DataTable();
                    _DT = BLL_Produto.Busca_Imagem(Produto);

                    byte[] bits = (byte[])(_DT.Rows[0][0]);
                    MemoryStream memorybits = new MemoryStream(bits);
                    Bitmap ImagemConvertida = new Bitmap(memorybits);
                    pc_Imagem.Image = ImagemConvertida;
                }
                else
                    pc_Imagem.Image = null;
            }
            catch (Exception)
            {
                pc_Imagem.Image = null;
            }
        }
        #endregion

        #region PICTUREBOX
        private void pc_Imagem_DoubleClick(object sender, EventArgs e)
        {
            if (txt_Imagem.Text.Trim() == string.Empty)
                return;

            UI_Imagem UI_Imagem = new UI_Imagem();
            UI_Imagem.Tipo = 1;
            UI_Imagem.ID_Produto = util_dados.Verifica_int(txt_ID.Text);

            UI_Imagem.ShowDialog();
        }
        #endregion

        private void DG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleciona_Produto();

        }
    }
}
