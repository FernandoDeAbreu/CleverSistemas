using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Produto_AtualizaValorXLS : Sistema.UI.UI_Modelo
    {
        public UI_Produto_AtualizaValorXLS()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_GrupoNivel BLL_GrupoNivel;
        BLL_Grupo BLL_Grupo;
        BLL_TabelaValor BLL_TabelaValor;
        BLL_Grade BLL_Grade;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        string Conta;

        bool Seleciona = false;
        #endregion

        #region ESTRUTURAS
        DTO_Produto Produto;
        DTO_GrupoNivel GrupoNivel;
        DTO_Grupo Grupo;
        DTO_Produto_Valor Produto_Valor;
        DTO_TabelaValor TabelaValor;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Grade Grade;
        DTO_Pessoa Pessoa;
        #endregion

        #region PROPRIEDADES
        /// <summary>
        /// 1 - ATUALIZAÇÃO DE VALOR
        /// 2 - CADASTRO DE PRODUTO
        /// </summary>
        public int Tipo { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            switch (Tipo)
            {
                case 1:
                    this.Text = "ATUALIZAÇÃO DE PRODUTOS (VALOR)";
                    bt_Edita.Visible = false;
                    bt_Grava.Enabled = true;
                    bt_Grava.Text = "ATUALIZAR";
                    gb_CadastroProduto.Visible = false;
                    dg_Tabela.Height = 480;
                    break;

                case 2:
                    this.Text = "CADASTRO DE PRODUTO TABELA";
                    bt_Grava.Visible = false;
                    bt_Edita.Enabled = true;
                    bt_Edita.Text = "CADASTRAR";
                    break;
            }
            dg_Tabela.AutoGenerateColumns = false;

            bt_Novo.Visible = false;
            bt_Exclui.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;

            tabctl.TabPages.Remove(TabPage2);
        }

        private void Carrega_Tabela(DataTable _DT)
        {
            dg_Tabela.Rows.Clear();

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            DataTable DT_Temp = new DataTable();
            int aux = 0;

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                if (_DT.Rows[i]["grava"].ToString().Trim().ToUpper().Replace("Ã", "A") != "NAO" &&
                   util_dados.Verifica_Double(_DT.Rows[i]["valorcompra"].ToString()) > 0 &&
                   util_dados.Verifica_Double(_DT.Rows[i]["valorvenda"].ToString()) > 0)
                    if (_DT.Rows[i]["marca"].ToString().ToUpper().IndexOf(txt_Fabricante.Text.ToUpper()) != -1 ||
                        txt_Fabricante.Text.Trim() == string.Empty)
                    {
                        Produto.Referencia = _DT.Rows[i]["referencia"].ToString().Trim();
                        Produto.Descricao = _DT.Rows[i]["descricao"].ToString().TrimEnd().TrimStart();
                        Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

                        DT_Temp = BLL_Produto.Busca_AlteraValor(Produto);

                        if (DT_Temp.Rows.Count > 0)
                        {
                            if (Tipo == 1)
                            {
                                dg_Tabela.Rows.Add();
                                dg_Tabela.Rows[aux].Cells["col_Descricao"].Value = _DT.Rows[i]["descricao"].ToString().ToUpper();
                                dg_Tabela.Rows[aux].Cells["col_Referencia"].Value = _DT.Rows[i]["referencia"].ToString().ToUpper();
                                dg_Tabela.Rows[aux].Cells["col_NCM"].Value = _DT.Rows[i]["ncm"].ToString().Replace(".", "");
                                dg_Tabela.Rows[aux].Cells["col_ValorCompra"].Value = _DT.Rows[i]["valorcompra"];
                                dg_Tabela.Rows[aux].Cells["col_ValorVenda"].Value = _DT.Rows[i]["valorvenda"];

                                dg_Tabela.Rows[aux].Cells["col_ID_Produto"].Value = DT_Temp.Rows[0]["ID_Produto"];
                                dg_Tabela.Rows[aux].Cells["col_ID_TabelaValor"].Value = DT_Temp.Rows[0]["ID_Tabela"];

                                aux++;
                            }
                        }
                        else
                        {
                            dg_Tabela.Rows.Add();
                            dg_Tabela.Rows[aux].Cells["col_Descricao"].Value = _DT.Rows[i]["descricao"].ToString().ToUpper();
                            dg_Tabela.Rows[aux].Cells["col_Referencia"].Value = _DT.Rows[i]["referencia"].ToString().ToUpper();
                            dg_Tabela.Rows[aux].Cells["col_NCM"].Value = _DT.Rows[i]["ncm"].ToString().Replace(".", "");
                            dg_Tabela.Rows[aux].Cells["col_ValorCompra"].Value = _DT.Rows[i]["valorcompra"];
                            dg_Tabela.Rows[aux].Cells["col_ValorVenda"].Value = _DT.Rows[i]["valorvenda"];

                            aux++;
                        }

                    }
        }

        private void CarregaConta()
        {
            BLL_GrupoNivel = new BLL_GrupoNivel();
            GrupoNivel = new DTO_GrupoNivel();

            DataTable _DT = new DataTable();

            int Nivel = util_dados.VerificaNivel(mk_Conta.Text);

            Conta = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);
            //Nivel 1
            if (Conta.Length == 2)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                    if (i == _DT.Rows.Count - 1)
                        txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                }
                txt_DescricaoConta.Text = Descricao;

                if (_DT.Rows.Count == 0)
                {
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                return;
            }
            //Nivel 2
            if (Conta.Length == 4)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                    if (i == _DT.Rows.Count - 1)
                        txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                }
                txt_DescricaoConta.Text = Descricao;

                if (_DT.Rows.Count == 0)
                {
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                return;
            }
            //Nivel 3
            if (Conta.Length == 6)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                    if (i == _DT.Rows.Count - 1)
                        txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                }
                txt_DescricaoConta.Text = Descricao;

                if (_DT.Rows.Count == 0)
                {
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                return;
            }
            //Nivel 4
            if (Conta.Length == 8)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                    if (i == _DT.Rows.Count - 1)
                        txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                }
                txt_DescricaoConta.Text = Descricao;

                if (_DT.Rows.Count == 0)
                {
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                return;
            }
        }

        private void CarregaCB()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            DataTable _DT = new DataTable();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Unidade);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_UnidadeTributavel);
            cb_UnidadeTributavel.SelectedIndex = 0;

            _DT = new DataTable();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Grade);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_GrupoGrade);
            cb_ID_GrupoGrade.SelectedIndex = 0;

            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();
            _DT = new DataTable();
            _DT = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Tabela);
            cb_ID_Tabela.SelectedIndex = 0;
        }

        private int[] Busca_lst_Empresa()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = 2;

            DataTable _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            int[] aux = new int[_DT.Rows.Count];

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                aux[i] = Convert.ToInt32(_DT.Rows[i]["ID"]);

            return aux;
        }

        private void Grava_Informacao()
        {
            try
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                switch (Tipo)
                {
                    case 1: //ATUALIZAR VALOR
                        for (int i = 0; i <= dg_Tabela.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_Tabela.Rows[i].Cells["col_Seleciona"].Value) == true)
                            {
                                Produto.ID = Convert.ToInt32(dg_Tabela.Rows[i].Cells["col_ID_Produto"].Value);

                                if (Produto.ID > 0)
                                {
                                    #region TABELA VALOR
                                    Produto.Valor = new List<DTO_Produto_Valor>();

                                    Produto_Valor = new DTO_Produto_Valor();
                                    Produto_Valor.ID = Convert.ToInt32(dg_Tabela.Rows[i].Cells["col_ID_TabelaValor"].Value);
                                    Produto_Valor.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                                    Produto_Valor.MargemVenda = util_dados.CalculaMargem(Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_ValorCompra"].Value), Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_ValorVenda"].Value));
                                    Produto_Valor.ValorVenda = Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_ValorVenda"].Value);
                                    Produto_Valor.UltimoReajuste = DateTime.Now;

                                    Produto.Valor.Add(Produto_Valor);
                                    #endregion

                                    Produto.ValorCompra = double.Parse(dg_Tabela.Rows[i].Cells["col_ValorCompra"].Value.ToString());
                                    Produto.OutrosCustos = 0;
                                    Produto.CustoFinal = double.Parse(dg_Tabela.Rows[i].Cells["col_ValorCompra"].Value.ToString());

                                    BLL_Produto.Atualiza_Valor(Produto);
                                }
                            }
                        break;

                    case 2:
                        for (int i = 0; i <= dg_Tabela.Rows.Count - 1; i++)
                            if (Convert.ToBoolean(dg_Tabela.Rows[i].Cells["col_Seleciona"].Value) == true)
                            {
                                Produto = new DTO_Produto();
                                Produto.Comissao = new List<DTO_Comissao>();

                                Produto.ID = Convert.ToInt32(dg_Tabela.Rows[i].Cells["col_ID_Produto"].Value);
                                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                Produto.Descricao = dg_Tabela.Rows[i].Cells["col_Descricao"].Value.ToString().TrimEnd();
                                Produto.Referencia = dg_Tabela.Rows[i].Cells["col_Referencia"].Value.ToString().Trim();

                                Produto.lst_ID_Empresa = Busca_lst_Empresa();

                                Produto.ID_Grupo = util_dados.Verifica_int(txt_ID_Conta.Text);
                                Produto.Fabricante = txt_Fabricante.Text;
                                Produto.Informacao = txt_Informacao.Text;
                                Produto.Barra = string.Empty;
                                Produto.BarraTributavel = string.Empty;
                                Produto.NCM = dg_Tabela.Rows[i].Cells["col_NCM"].Value.ToString();
                                Produto.UnidadeTributavel = Convert.ToInt32(cb_UnidadeTributavel.SelectedValue);
                                Produto.Validade = 0;
                                Produto.Garantia = 0;
                                Produto.Ativo = Convert.ToBoolean(ck_Ativo.Checked);
                                Produto.EX_TIPI = string.Empty;
                                Produto.ProdutoEspecifico = false;
                                Produto.CNPJProdutor = string.Empty;
                                Produto.Consulta_Tipo = true;
                                Produto.Tipo = "1";
                                Produto.Controle_Estoque = true;

                                Produto.ValorCompra = double.Parse(dg_Tabela.Rows[i].Cells["col_ValorCompra"].Value.ToString());
                                Produto.OutrosCustos = 0;
                                Produto.ValorIPI = 0;
                                Produto.ValorST = 0;
                                Produto.CustoFinal = double.Parse(dg_Tabela.Rows[i].Cells["col_ValorCompra"].Value.ToString());
                                Produto.PesoB = 0;
                                Produto.PesoL = 0;

                                #region TABELA VALOR
                                Produto.Valor = new List<DTO_Produto_Valor>();

                                Produto_Valor = new DTO_Produto_Valor();
                                Produto_Valor.ID = Convert.ToInt32(dg_Tabela.Rows[i].Cells["col_ID_TabelaValor"].Value);
                                Produto_Valor.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                                Produto_Valor.MargemVenda = util_dados.CalculaMargem(Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_ValorCompra"].Value), Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_ValorVenda"].Value));
                                Produto_Valor.ValorVenda = Convert.ToDouble(dg_Tabela.Rows[i].Cells["col_ValorVenda"].Value);
                                Produto_Valor.UltimoReajuste = DateTime.Now;
                                Produto.Valor.Add(Produto_Valor);
                                #endregion

                                #region ESTOQUE
                                Produto.Estoque = new List<DTO_Produto_Estoque>();
                                if (Produto.ID == 0)
                                {
                                    BLL_Grade = new BLL_Grade();
                                    Grade = new DTO_Grade();

                                    Grade.ID_Grupo = Convert.ToInt32(cb_ID_GrupoGrade.SelectedValue);
                                    DataTable DT = new DataTable();
                                    DT = BLL_Grade.Busca(Grade);

                                    if (DT.Rows.Count > 0)
                                    {
                                        Produto_Estoque = new DTO_Produto_Estoque();
                                        Produto_Estoque.ID = 0;
                                        Produto_Estoque.ID_Grade = Convert.ToInt32(DT.Rows[0]["ID"]);
                                        Produto_Estoque.Estoque_Atual = 0;
                                        Produto_Estoque.Estoque_Ideal = 0;
                                        Produto_Estoque.Estoque_Minimo = 0;

                                        Produto.Estoque.Add(Produto_Estoque);
                                    }
                                }
                                #endregion

                                BLL_Produto.Grava(Produto);
                            }
                        break;
                }
                MessageBox.Show(util_msg.msg_Grava, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message);
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_AtualizaValorXLS_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            CarregaCB();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaXLS_Click(object sender, EventArgs e)
        {
            Pesquisaxls.Filter = "Arquivos Excel|*.xls; *.xlsx";
            Pesquisaxls.ShowDialog();

            txt_Caminho.Text = Pesquisaxls.FileName;
        }

        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_GrupoNivel_Consulta frm = new UI_GrupoNivel_Consulta();
            frm.ShowDialog();
            mk_Conta.Text = frm.Cod_Conta;
            CarregaConta();
        }

        private void bt_Estrutura_Click(object sender, EventArgs e)
        {
            UI_Estruturaxls frm = new UI_Estruturaxls();
            frm.ShowDialog();
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                if (Tipo == 1)
                    bt_Edita.Enabled = true;

                if (Tipo == 2)
                    bt_Grava.Enabled = true;

                string _Arquivo = @txt_Caminho.Text;
                string _StringConexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _Arquivo + ";Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';";

                OleDbConnection _olecon = new OleDbConnection(_StringConexao);
                _olecon.Open();

                string sql = "";
                sql += "SELECT descricao, referencia, ncm, valorcompra, valorvenda, grava, marca ";
                sql += "FROM [tabela$]";
                sql += "WHERE NOT descricao IS NULL ";

                if (txt_ReferenciaP.Text != string.Empty)
                    sql += "AND referencia LIKE '" + txt_ReferenciaP.Text + "%' ";

                if (txt_DescricaoP.Text != string.Empty)
                    sql += "AND descricao LIKE '" + txt_DescricaoP.Text + "%' ";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, _olecon);

                DataTable DT = new DataTable();
                da.TableMappings.Add("Temporario", "Tab1");
                da.Fill(DT);

                _olecon.Close();

                if (DT.Rows.Count > 0)
                    Carrega_Tabela(DT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //MODIFICADO PARA CADASTRAR PRODUTO
        public override void Edita()
        {
            Grava_Informacao();
        }

        //MODIFICADO PARA ALTERAR VALOR
        public override void Gravar()
        {
            Grava_Informacao();
        }
        #endregion

        #region MASKEDBOX
        private void mk_Conta_Leave(object sender, EventArgs e)
        {
            CarregaConta();
        }
        #endregion

        #region DATAGRID
        private void dg_Tabela_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Tabela.Rows.Count - 1; i++)
                    dg_Tabela.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Tabela_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        #endregion

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
