using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using Sistema.UTIL;
using Sistema.BLL;
using Sistema.DTO;

namespace Sistema.UI
{
    public partial class UI_Produto_Balanco : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Balanco()
        {
            InitializeComponent();
        }
        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        string lst_CodigoProduto = string.Empty;
        #endregion

        #region ESTRUTURA
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Produto Produto;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "BALANÇO DE ESTOQUE";

            tabctl.TabPages.Remove(TabPage2);
            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            tabctl.SelectedTab = TabPage1;

            dg_Estoque.AutoGenerateColumns = false;

            lb_Info_Adicional.Text = Parametro_CadastroPersonalizado.Info_Produto1;

            Carrega_CB();
        }

        private void Carrega_CB()
        {
            List<string> _aux = new List<string>();
            _aux.Add("TODOS");
            _aux.Add("PRODUTO VENDA");
            _aux.Add("MATÉRIA-PRIMA");
            _aux.Add("SERVIÇO");
            _aux.Add("IMOBILIZADO / USO PRÓPRIO");
            _aux.Add("KIT");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, _aux), "Descricao", "ID", cb_TipoP);

            _aux = new List<string>();
            _aux.Add("TODOS");
            _aux.Add("ATIVOS");
            _aux.Add("INATIVOS");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, _aux), "Descricao", "ID", cb_Situacao);
        }

        private void Carrega_Produto_Coletor()
        {
            try
            {
                DataRow DR;

                DataTable _DT_Produto = new DataTable("Produto");
                _DT_Produto.Columns.Add("ID_Produto", typeof(int));
                _DT_Produto.Columns.Add("ID_Grade", typeof(int));
                _DT_Produto.Columns.Add("Descricao");
                _DT_Produto.Columns.Add("Barra");
                _DT_Produto.Columns.Add("DescricaoGrade");
                _DT_Produto.Columns.Add("EstoqueIdeal", typeof(double));
                _DT_Produto.Columns.Add("EstoqueMinimo", typeof(double));
                _DT_Produto.Columns.Add("EstoqueAtual", typeof(double));
                _DT_Produto.Columns.Add("Qt_Aferido", typeof(double));

                BLL_Produto = new BLL_Produto();

                lst_CodigoProduto = string.Empty;

                #region PESQUISA E CARREGA PRODUTOS DO COLETOR
                Pesquisa_Arquivo.Filter = "Arquivos Texto|*.txt";
                Pesquisa_Arquivo.ShowDialog();

                string Arquivo = Pesquisa_Arquivo.FileName;

                string line = string.Empty;
                string[] Codigo;

                //LISTAR PRODUTOS NÃO CAPTURADOS PELO COLETOR
                string _lst_ID_Produto = string.Empty;

                int ID_Grade = 0;
                string DescricaoGrade;

                DataTable _DT;

                bool Adiciona = true;

                StreamReader file = new System.IO.StreamReader(Arquivo);
                while ((line = file.ReadLine()) != null)
                {
                    Adiciona = true;

                    Codigo = line.Split(';');

                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();
                    Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Produto.Consulta_PDV = util_dados.Verifica_int(Codigo[0]).ToString();

                    _DT = new DataTable();
                    _DT = BLL_Produto.Busca_Rel_Estoque(Produto);

                    if (_DT.Rows.Count > 1)
                    {
                        UI_Produto_Consulta frm = new UI_Produto_Consulta();
                        frm.ConsultaPDV = true;
                        frm.Codigo_ConsultaPDV = util_dados.Verifica_int(Codigo[0]).ToString();

                        frm.ShowDialog();

                        if (frm.ID_Produto > 0)
                            Produto.ID = frm.ID_Produto;
                        else
                        {
                            MessageBox.Show("Nenhum produto selecionado!");
                            Adiciona = false;
                        }
                    }

                    if (_DT.Rows.Count == 1)
                        Produto.ID = Convert.ToInt32(_DT.Rows[0]["ID_Produto"]);

                    if (_DT.Rows.Count == 0)
                    {
                        MessageBox.Show("Código não encontrado!");
                        Adiciona = false;
                    }

                    DataTable _DT_Estoque = new DataTable();
                    _DT_Estoque = BLL_Produto.Busca_Estoque(Produto);

                    if (_DT_Estoque == null)
                    {
                        MessageBox.Show("Estoque não cadastrado!");
                        Adiciona = false;
                    }

                    if (_DT_Estoque != null)
                        if (_DT_Estoque.Rows.Count == 1 ||
                            ID_Grade > 0)
                        {
                            ID_Grade = Convert.ToInt32(_DT_Estoque.Rows[0]["ID_Grade"]);

                            if (Convert.ToString(_DT_Estoque.Rows[0]["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
                                DescricaoGrade = " - " + Convert.ToString(_DT.Rows[0]["DescricaoGrade"]);
                            else
                                DescricaoGrade = string.Empty;
                        }
                        else
                        {
                            bool Altera_Consulta_Grade = false;

                            if (Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Quantidade)
                            {
                                Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Unico;
                                Altera_Consulta_Grade = true;
                            }

                            UI_Produto_Consulta_Grade frm = new UI_Produto_Consulta_Grade();
                            frm.ID_Produto = Convert.ToInt32(_DT_Produto.Rows[0]["ID"]);
                            frm.Descricao = _DT_Produto.Rows[0]["Descricao"].ToString();

                            frm.ShowDialog();

                            List<DTO_Produto_Item> lst_Grade = new List<DTO_Produto_Item>();
                            lst_Grade = frm.lst_Produto;

                            if (lst_Grade == null)
                            {
                                MessageBox.Show("Selecione uma Grade!");
                                Adiciona = false;
                            }

                            ID_Grade = lst_Grade[0].ID_Grade;
                            DescricaoGrade = " - " + lst_Grade[0].DescricaoGrade;

                            if (Altera_Consulta_Grade == true)
                                Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Quantidade;
                        }

                    if (Adiciona == true)
                    {
                        DR = _DT_Produto.NewRow();

                        DR["ID_Produto"] = Convert.ToInt32(_DT.Rows[0]["ID_Produto"]);
                        DR["ID_Grade"] = Convert.ToInt32(_DT.Rows[0]["ID_Grade"]);
                        DR["Descricao"] = _DT.Rows[0]["Descricao"];
                        DR["Barra"] = _DT.Rows[0]["Barra"];
                        DR["DescricaoGrade"] = _DT_Estoque.Rows[0]["DescricaoGrade"];
                        DR["EstoqueIdeal"] = Convert.ToDouble(_DT_Estoque.Rows[0]["EstoqueIdeal"]);
                        DR["EstoqueMinimo"] = Convert.ToDouble(_DT_Estoque.Rows[0]["EstoqueMinimo"]);
                        DR["EstoqueAtual"] = Convert.ToDouble(_DT_Estoque.Rows[0]["EstoqueAtual"]);
                        DR["Qt_Aferido"] = Convert.ToDouble(Codigo[1]);

                        _DT_Produto.Rows.Add(DR);

                        _lst_ID_Produto += _DT.Rows[0]["ID_Produto"].ToString() + ", ";
                    }
                }
                file.Close();
                #endregion

                #region LISTA TODOS PRODUTOS NÃO COLETADOS
                if (ck_ListaProduto.Checked == true)
                {
                    _lst_ID_Produto = _lst_ID_Produto.Substring(0, _lst_ID_Produto.Length - 2);

                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();

                    Produto.ID = util_dados.Verifica_int(txt_IDP.Text);
                    Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Produto.GrupoNivel = mk_Cod_GrupoP.Text;
                    Produto.Descricao = txt_DescricaoP.Text;
                    Produto.Referencia = txt_ReferenciaP.Text;
                    Produto.Barra = txt_BarraP.Text;
                    Produto.Fabricante = txt_FabricanteP.Text;
                    Produto.ListaID = _lst_ID_Produto;

                    if (ck_ConsultaInversa.Checked == true)
                        Produto.ConsultaInversa = true;

                    _DT = new DataTable();
                    _DT = BLL_Produto.Busca_Rel_Estoque_Coletor(Produto);

                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        DR = _DT_Produto.NewRow();

                        DR["ID_Produto"] = Convert.ToInt32(_DT.Rows[i]["ID_Produto"]);
                        DR["ID_Grade"] = ID_Grade;
                        DR["Descricao"] = _DT.Rows[i]["Descricao"];
                        DR["Barra"] = _DT.Rows[i]["Barra"];
                        DR["DescricaoGrade"] = _DT.Rows[i]["DescricaoGrade"];
                        DR["EstoqueIdeal"] = Convert.ToDouble(_DT.Rows[i]["EstoqueIdeal"]);
                        DR["EstoqueMinimo"] = Convert.ToDouble(_DT.Rows[i]["EstoqueMinimo"]);
                        DR["EstoqueAtual"] = Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]);
                        DR["Qt_Aferido"] = 0;

                        _DT_Produto.Rows.Add(DR);
                    }
                }
                #endregion

                dg_Estoque.DataSource = _DT_Produto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
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
            Produto.InfoAdicional1 = txt_InfoAdicional.Text;

            if (lst_CodigoProduto != string.Empty)
                Produto.lst_Codigo = lst_CodigoProduto;

            if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
            {
                Produto.Consulta_Ativo = true;

                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                    Produto.Ativo = true;
                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 2)
                    Produto.Ativo = false;
            }

            if (Convert.ToInt32(cb_TipoP.SelectedValue) > 0)
            {
                Produto.Consulta_Tipo = true;
                Produto.Tipo = cb_TipoP.SelectedValue.ToString();
            }

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_Rel_Estoque(Produto);
            dg_Estoque.DataSource = _DT;
        }

        public override void Gravar()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_AlteracaoEstoque, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_Produto = new BLL_Produto();

                for (int i = 0; i <= dg_Estoque.Rows.Count - 1; i++)
                {
                    if (dg_Estoque.Rows[i].Cells["col_QtAferido"].Value != null &&
                        dg_Estoque.Rows[i].Cells["col_QtAferido"].Value.ToString().Trim() != string.Empty)
                    {
                        Produto = new DTO_Produto();
                        Produto_Estoque = new DTO_Produto_Estoque();
                        Produto.Estoque = new List<DTO_Produto_Estoque>();
                        Produto.Estoque.Add(Produto_Estoque);

                        double EstoqueAtual = Convert.ToDouble(dg_Estoque.Rows[i].Cells["col_EstoqueAtual"].Value);
                        double Estoque_Aferido = Convert.ToDouble(dg_Estoque.Rows[i].Cells["col_QtAferido"].Value);

                        Produto.Estoque[0].Estoque_Atual = Estoque_Aferido;
                        Produto.Estoque[0].ID_Grade = Convert.ToInt32(dg_Estoque.Rows[i].Cells["col_ID_Grade"].Value);

                        Produto.ID = Convert.ToInt32(dg_Estoque.Rows[i].Cells["col_ID_Produto"].Value);
                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Produto.Data = DateTime.Now;

                        if (EstoqueAtual > Estoque_Aferido)
                        {
                            Produto.Tipo_Movimento = 2;
                            Produto.Informacao = "BALANÇO DE ESTOQUE";
                            Produto.Quantidade = EstoqueAtual - Estoque_Aferido;
                            BLL_Produto.Grava_MovimentoProduto(Produto);
                        }

                        if (EstoqueAtual < Estoque_Aferido)
                        {
                            Produto.Tipo_Movimento = 1;
                            Produto.Informacao = "BALANÇO DE ESTOQUE";
                            Produto.Quantidade = Estoque_Aferido - EstoqueAtual;
                            BLL_Produto.Grava_MovimentoProduto(Produto);
                        }

                        BLL_Produto.Grava_Estoque(Produto);
                    }
                }
                MessageBox.Show(util_msg.msg_Altera, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome;

            rpt_Nome = "rpt_Produto_Estoque.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = new DataTable();
            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_IDP.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_Cod_GrupoP.Text;
            Produto.Descricao = txt_DescricaoP.Text;
            Produto.Referencia = txt_ReferenciaP.Text;
            Produto.Barra = txt_BarraP.Text;
            Produto.Fabricante = txt_FabricanteP.Text;

            if (lst_CodigoProduto != string.Empty)
                Produto.lst_Codigo = lst_CodigoProduto;

            if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
            {
                Produto.Consulta_Ativo = true;

                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                    Produto.Ativo = true;
                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 2)
                    Produto.Ativo = false;
            }

            if (Convert.ToInt32(cb_TipoP.SelectedValue) > 0)
            {
                Produto.Consulta_Tipo = true;
                Produto.Tipo = cb_TipoP.SelectedValue.ToString();
            }

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_Rel_Estoque(Produto);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_Produto", _DT);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);

            frm_rpt.rpt_Viewer.RefreshReport();
            frm_rpt.Show();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();
            string rpt_Nome;

            rpt_Nome = "rpt_Produto_Estoque.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = new DataTable();
            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID = util_dados.Verifica_int(txt_IDP.Text);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.GrupoNivel = mk_Cod_GrupoP.Text;
            Produto.Descricao = txt_DescricaoP.Text;
            Produto.Referencia = txt_ReferenciaP.Text;
            Produto.Barra = txt_BarraP.Text;
            Produto.Fabricante = txt_FabricanteP.Text;

            if (lst_CodigoProduto != string.Empty)
                Produto.lst_Codigo = lst_CodigoProduto;

            if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
            {
                Produto.Consulta_Ativo = true;

                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                    Produto.Ativo = true;
                if (Convert.ToInt32(cb_Situacao.SelectedValue) == 2)
                    Produto.Ativo = false;
            }

            if (Convert.ToInt32(cb_TipoP.SelectedValue) > 0)
            {
                Produto.Consulta_Tipo = true;
                Produto.Tipo = cb_TipoP.SelectedValue.ToString();
            }

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_Rel_Estoque(Produto);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Produto = new ReportDataSource("ds_Produto", _DT);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Produto);

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
        #endregion

        #region FORM
        private void UI_Produto_Balanco_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_Balanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region BUTTON
        private void bt_Coletor_Click(object sender, EventArgs e)
        {
            Carrega_Produto_Coletor();
        }

        private void bt_PesquisaGrupoP_Click(object sender, EventArgs e)
        {
            UI_GrupoNivel_Consulta frm = new UI_GrupoNivel_Consulta();
            frm.ShowDialog();
            mk_Cod_GrupoP.Text = frm.Cod_Conta;
        }
        #endregion

        #region DATAGRID
        private void dg_Estoque_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_QtAferido"].Value.ToString().Trim() != string.Empty)
                    dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_QtAferido"].Value = util_dados.ConfigNumDecimal(dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_QtAferido"].Value, 2);
            }
            catch (Exception)
            {
                dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_QtAferido"].Value = string.Empty;
            }
        }
        #endregion

    }
}
