using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_Locacao_Produto : Sistema.UI.UI_Modelo
    {
        public UI_Locacao_Produto()
        {
            InitializeComponent();
        
        }

        #region VARIAVEIS DE CLASSE
        BLL_TabelaValor BLL_TabelaValor;
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        BLL_Produto BLL_Produto;
        BLL_Usuario BLL_Usuario;
        BLL_Orcamento BLL_Orcamento;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;
        DataRow DRPessoa;
        DataRow DREndereco;
        DataRow DRTelefone;
        DataRow DRProduto;
        DataTable DTUsuario;
        DataTable DTTabelaValor;
        DataTable DTProduto;
        DataTable DTPessoa;
        DataTable DTEndereco;
        DataTable DTTelefone;
        DataTable DTGrupo;
        DataTable DTR_Empresa;
        DataTable DTR_Orcamento;
        DataTable DTR_Pessoa;
        DataTable DTR_Endereco;
        DataTable DTR_Telefone;
        DataTable DTR_Email;
        DataTable DTR_ItemOrcamento;

        int ID_Grade;
        public int ID_Temp;

        int obj;
        string DescricaoGrade;

        bool Edita_Item = false;

        List<DTO_Produto_Item> lst_Produto;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_TabelaValor TabelaValor;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Produto Produto;
        DTO_Usuario Usuario;
        DTO_Orcamento Orcamento;
        DTO_Produto_Item Produto_Item;
        DTO_CReceber CReceber;
        #endregion

        private void Inicia_Form()
        {
            this.Text = "LOCAÇÃO DE PRODUTOS";

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            #region MONTA GRID CONSULTA
            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Data = new DataGridViewTextBoxColumn();
            col_Data.DataPropertyName = "Data";
            col_Data.HeaderText = "DATA";
            col_Data.Width = 70;
            col_Data.DefaultCellStyle.Format = "d";
            DG.Columns.Add(col_Data);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "PESSOA";
            col_Descricao.Width = 400;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Complemento = new DataGridViewTextBoxColumn();
            col_Complemento.DataPropertyName = "Complemento";
            col_Complemento.HeaderText = "COMPLEMENTO";
            col_Complemento.Width = 400;
            col_Complemento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Complemento);

            DataGridViewTextBoxColumn col_Valor = new DataGridViewTextBoxColumn();
            col_Valor.DataPropertyName = "ValorTotal";
            col_Valor.HeaderText = "VALOR";
            col_Valor.Width = 80;
            col_Valor.DefaultCellStyle.Format = "C2";
            col_Valor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG.Columns.Add(col_Valor);
            #endregion

            Limpa_Campos();
        }
        private void Limpa_Campos()
        {
            DG.DataSource = null;

            //txt_ValorUnitario.Text = "0,00";
            //txt_Quantidade.Text = "1,000";
            //txt_ValorFinal.Text = "0,00";
            //txt_Acrescimo.Text = "0,00";
            //txt_Desconto.Text = "0,00";

            //lb_Comissao1.Text = Parametro_Venda.Descricao_Comissao;

            mk_Data.Text = DateTime.Now.ToString();

            //if (Parametro_Usuario.Venda_Restrita == true)
            //{
            //    cb_TipoPessoa.SelectedValue = Parametro_Sistema.TipoPessoaPadrao;
            //    cb_TipoPessoa.Enabled = false;
            //    cb_TipoPessoaP.SelectedValue = Parametro_Sistema.TipoPessoaPadrao;
            //    cb_TipoPessoaP.Enabled = false;
            //}
            //else
            //{
            //    cb_TipoPessoa.SelectedValue = Parametro_Sistema.TipoPessoaPadrao;
            //    cb_TipoPessoa.Enabled = true;
            //    cb_TipoPessoaP.Enabled = true;
            //}

            //dg_Itens.Rows.Clear();
            //lst_Produto = new List<DTO_Produto_Item>();

            //cb_ID_Tabela.SelectedIndex = 0;
            //cb_TipoVendaProduto.SelectedValue = 0;

            //cb_ID_Pessoa.SelectedValue = Parametro_Venda.ID_ConsumidorFinal;

            //cb_ID_Pessoa.Focus();
        }
        public void CarregaCB()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();

            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Comissao = true;
            Usuario.Comissao = true;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

           

           

            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();
                       

            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedValue = 1;

            //_DT = util_Param.Tipo_Pessoa();
            //util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            //cb_TipoPessoaP.SelectedIndex = -1;
        }
        public void CarregaPessoa(int _Tipo)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                switch (_Tipo)
                {
                    case 1: //Tab Principal
                        if (util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString()) == 0)
                            return;

                        cb_ID_Pessoa.DataSource = null;

                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        Pessoa.FiltraSituacao = true;
                        Pessoa.Situacao = true;

                        DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
                        cb_ID_Pessoa.SelectedIndex = -1;

                        txt_CNPJ_CPF.Text = string.Empty;
                        txt_Telefone.Text = string.Empty;
                        txt_Logradouro.Text = string.Empty;
                        txt_Numero.Text = string.Empty;
                        txt_Bairro.Text = string.Empty;
                        txt_Municipio_UF.Text = string.Empty;
                        break;

                    case 2://Tab Pesquisa Orcamento
                        if (util_dados.Verifica_int(cb_TipoPessoaP.SelectedValue.ToString()) == 0)
                            return;

                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                        Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_PessoaP);
                        cb_ID_PessoaP.SelectedIndex = -1;
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        public void CarregaProduto()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 3, 5";

            if (Parametro_Venda.Produto_Marca == true)
                Produto.ConsultaMarca = true;

            DTProduto = BLL_Produto.Busca(Produto);
            util_dados.CarregaCombo(DTProduto, "Descricao", "ID", cb_ID_Produto);
        }
        private void Carrega_Item(List<DTO_Produto_Item> lst_Produto)
        {
            dg_Itens.Rows.Clear();
            double SubTotal = 0;
            double TotalDesconto = 0;
            double Quantidade = 0;


            //for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            //{
            //    dg_Itens.Rows.Add();
            //    dg_Itens.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
            //    dg_Itens.Rows[i].Cells["col_Descricao_Produto"].Value = _lst_Produto[i].Descricao_Produto;
            //    dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
            //    dg_Itens.Rows[i].Cells["col_Acrescimo"].Value = _lst_Produto[i].Acrescimo;

            //    if (Parametro_Venda.Desconto_Padrao == 1)
            //        dg_Itens.Rows[i].Cells["col_Desconto"].Value = _lst_Produto[i].Desconto;
            //    else
            //        dg_Itens.Rows[i].Cells["col_Desconto"].Value = util_dados.ConfigNumDecimal(util_dados.Verifica_Porcentagem(_lst_Produto[i].ValorProduto, _lst_Produto[i].ValorVenda), 2) + "%";

            //    dg_Itens.Rows[i].Cells["col_Valor"].Value = _lst_Produto[i].ValorProduto;
            //    dg_Itens.Rows[i].Cells["col_ValorFinal"].Value = _lst_Produto[i].ValorVenda;
            //    dg_Itens.Rows[i].Cells["col_Informacao"].Value = _lst_Produto[i].Informacao;
            //    dg_Itens.Rows[i].Cells["col_TipoSaida"].Value = _lst_Produto[i].Descricao_Saida;
            //    dg_Itens.Rows[i].Cells["col_ValorTotal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;

            //    SubTotal += _lst_Produto[i].Quantidade * (_lst_Produto[i].ValorProduto + _lst_Produto[i].Acrescimo);
            //    TotalDesconto += _lst_Produto[i].Quantidade * _lst_Produto[i].Desconto;
            //    Quantidade += _lst_Produto[i].Quantidade;
            //}

            dg_Itens.RefreshEdit();

            if (dg_Itens.Rows.Count > 0)
            {
                dg_Itens.Rows[dg_Itens.Rows.Count - 1].Selected = true;
                dg_Itens.FirstDisplayedScrollingRowIndex = dg_Itens.Rows.Count - 1;
            }

            txt_SubTotal.Text = util_dados.ConfigNumDecimal(SubTotal, 2);
            txt_TotalDesconto.Text = util_dados.ConfigNumDecimal(TotalDesconto, 2);
            txt_ValorOrcamento.Text = util_dados.ConfigNumDecimal(SubTotal - TotalDesconto, 2);

            lb_Quantidade.Text = util_msg.msg_Quantidade_Item + util_dados.ConfigNumDecimal(Quantidade, 3);
            lb_DescontoTotal.Text = util_msg.msg_Desconto_Total + util_dados.ConfigNumDecimal(util_dados.Verifica_Porcentagem(SubTotal, SubTotal - TotalDesconto), 2) + " %";
        }


        private void Consulta_Pessoa()
        {
            if (tabctl.SelectedTab == TabPage1)
            {
                UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
                UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

                if (Parametro_Usuario.Venda_Restrita == true)
                    UI_Pessoa_Consulta.Usuario_Restrito = true;

                UI_Pessoa_Consulta.ShowDialog();

                if (UI_Pessoa_Consulta.NovoCadastro == true)
                {
                    bool aux = false;
                    foreach (Form Frm in this.MdiParent.MdiChildren)
                    {
                        if (Frm is UI_Pessoa)
                        {
                            DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msgbox == DialogResult.No)
                            {
                                Frm.BringToFront();
                                aux = true;
                                return;
                            }
                            Frm.Close();
                            aux = false;
                        }
                    }
                    if (aux == false)
                    {
                        UI_Pessoa UI_Pessoa = new UI_Pessoa();

                        UI_Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        util_dados.CarregaForm(UI_Pessoa, this.MdiParent);

                        return;
                    }
                }

                if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                    return;

                if (Parametro_Usuario.Venda_Restrita == true &&
                UI_Pessoa_Consulta.TipoPessoa != 1)
                    return;

                cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                CarregaPessoa(Convert.ToInt32(cb_TipoPessoa.SelectedValue));

                cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                txt_ID_Pessoa.Text = UI_Pessoa_Consulta.ID_Pessoa.ToString();

               // cb_TipoVendaProduto.Focus();
            }

            if (tabctl.SelectedTab == TabPage2)
            {
                UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
                UI_Pessoa_Consulta.OcultaNovoCadastro = true;
               // UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

                if (Parametro_Usuario.Venda_Restrita == true)
                    UI_Pessoa_Consulta.Usuario_Restrito = true;

                UI_Pessoa_Consulta.ShowDialog();

                if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                    return;

                if (Parametro_Usuario.Venda_Restrita == true &&
                UI_Pessoa_Consulta.TipoPessoa != 1)
                    return;

              //  cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                //CarregaPessoa(2);
                //cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                //cb_ID_PessoaP.Focus();
            }
        }
        private void Busca_Pessoa(int _ID)
        {
            txt_CNPJ_CPF.Text = string.Empty;
            txt_Telefone.Text = string.Empty;
            txt_Logradouro.Text = string.Empty;
            txt_Numero.Text = string.Empty;
            txt_Bairro.Text = string.Empty;
            txt_Municipio_UF.Text = string.Empty;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = _ID;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DTPessoa = BLL_Pessoa.Busca(Pessoa);
            if (DTPessoa.Rows.Count > 0)
            {
                DRPessoa = DTPessoa.Rows[0];
                txt_CNPJ_CPF.Text = Convert.ToString(DRPessoa["CNPJ_CPF"]);
                txt_Informacao_Venda.Text = Convert.ToString(DRPessoa["Informacao_Venda"]);

                if (Parametro_Usuario.Venda_Fixa_logado == false)
                {
                    //if (Convert.ToInt32(cb_TipoPessoa.SelectedValue) == 1)
                    //    if (Convert.ToInt32(DRPessoa["ID_Usuario"]) > 0)
                    //    {
                    //        //cb_ID_UsuarioComissao1.Enabled = false;
                    //        //cb_ID_UsuarioComissao1.SelectedValue = DRPessoa["ID_Usuario"];
                    //    }
                    //    else
                    //      //  cb_ID_UsuarioComissao1.Enabled = true;
                }
                else
                {
                    //cb_ID_UsuarioComissao1.Enabled = false;
                    //cb_ID_UsuarioComissao1.SelectedValue = Parametro_Usuario.ID_Usuario_Ativo;
                }
            }

            Endereco.Principal = true;
            Pessoa.Endereco.Add(Endereco);
            DTEndereco = BLL_Pessoa.Busca_Endereco(Pessoa);

            if (DTEndereco.Rows.Count > 0)
            {
                DREndereco = DTEndereco.Rows[0];
                txt_Logradouro.Text = Convert.ToString(DREndereco["Logradouro"]);
                txt_Numero.Text = Convert.ToString(DREndereco["NumeroEndereco"]);
                txt_Bairro.Text = Convert.ToString(DREndereco["Bairro"]);
                txt_Municipio_UF.Text = Convert.ToString(DREndereco["Municipio_UF"]);
            }

            Telefone.Principal = true;
            Pessoa.Telefone.Add(Telefone);
            DTTelefone = BLL_Pessoa.Busca_Telefone(Pessoa);

            if (DTTelefone.Rows.Count > 0)
            {
                DRTelefone = DTTelefone.Rows[0];
                txt_Telefone.Text = "(" + DRTelefone["DDD"] + ") " + DRTelefone["NumeroTelefone"];
            }
        }

        private void Consulta_Produto()
        {
            ID_Grade = 0;

            UI_Produto_Consulta frm = new UI_Produto_Consulta();
         //   frm.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;

            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = frm.ID_Produto;
            ID_Grade = frm.ID_Grade;
            txt_ID_Produto.Text = frm.ID_Produto.ToString();

            txt_Quantidade.Focus();
        }
        private void bt_PesquisaPessoa_Click(object sender, EventArgs e)
        {
            Consulta_Pessoa();

        }

        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, "DATA");
                mk_Data.Text = Convert.ToString(DateTime.Now);
                mk_Data.Focus();
            }
        }

        private void UI_Locacao_Produto_Load(object sender, EventArgs e)
        {
            dg_Itens.AutoGenerateColumns = false;

            dg_Itens.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Itens.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            bt_Imprime.Visible = true;
            CarregaCB();
            CarregaProduto();

            Novo();
            Inicia_Form();
        }

        private void UI_Locacao_Produto_KeyDown(object sender, KeyEventArgs e)        {

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();

            if (e.KeyCode == Keys.F10 &&
              tabctl.SelectedTab == TabPage1)
             Consulta_Produto();

            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        private void Verifica_CReceber(int _ID)
        {
            if (Parametro_Venda.DiasBloqueioVenda == 0 ||
                util_dados.Verifica_int(txt_ID.Text) > 0)
                return;

            BLL_CReceber = new BLL_CReceber();
            CReceber = new DTO_CReceber();

            CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CReceber.Situacao = 1;
            CReceber.Vencimento = DateTime.Now.AddDays(Parametro_Venda.DiasBloqueioVenda * -1).Date;
            CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            CReceber.ID_Pessoa = _ID;

            DataTable _DT = new DataTable();
            _DT = BLL_CReceber.Busca_ContaAtraso(CReceber);

            if (_DT.Rows.Count > 0)
                MessageBox.Show(string.Format(util_msg.msg_CReceberEmAberto, Parametro_Venda.DiasBloqueioVenda), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void cb_ID_Pessoa_Leave(object sender, EventArgs e)
        {
            if (cb_ID_Pessoa.SelectedValue != null &&
           Convert.ToInt32(cb_ID_Pessoa.SelectedValue) != Parametro_Venda.ID_ConsumidorFinal)
                Verifica_CReceber(util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString()));

            if (txt_Informacao_Venda.Text.Trim() != string.Empty)
                MessageBox.Show("ATENÇÃO\n" + DRPessoa["Informacao_Venda"].ToString(), this.Text);
        }

        private void cb_ID_Pessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_ID_Pessoa.Text.Trim() != string.Empty)
                    if (cb_ID_Pessoa.SelectedValue.GetType() == typeof(int) &&
                        Convert.ToInt32(cb_ID_Pessoa.SelectedValue) > 0)
                        Busca_Pessoa(Convert.ToInt32(cb_ID_Pessoa.SelectedValue));
            }
            catch (Exception)
            {
                 txt_ID_Produto.Text = "0";
            }
        }

        private void bt_PesquisaProduto_Click(object sender, EventArgs e)
        {
            Consulta_Produto();
        }

        private void bt_AdicionaProduto_Click(object sender, EventArgs e)
        {
            if (cb_ID_Produto.SelectedValue != null)
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);

                List<DTO_Produto_Item> lst_Grade = new List<DTO_Produto_Item>();

                if (ID_Grade > 0)
                    Produto.ID_Grade = ID_Grade;

                DataTable _DT = new DataTable();


                _DT = BLL_Produto.Busca_Estoque(Produto);
                if (_DT == null)
                {
                    MessageBox.Show("Estoque não cadastrado!");
                    return;
                }

                int TipoProduto = Convert.ToInt32(_DT.Rows[0]["Tipo"]);

                if (_DT.Rows.Count == 1 ||
                    ID_Grade > 0)
                {
                    DR = _DT.Rows[0];
                    ID_Grade = Convert.ToInt32(DR["ID_Grade"]);

                    if (Convert.ToString(DR["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
                        DescricaoGrade = " - " + Convert.ToString(DR["DescricaoGrade"]);
                    else
                        DescricaoGrade = string.Empty;

                    if (Parametro_Venda.Bloquear_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                {
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);
                                    return;
                                }

                    if (Parametro_Venda.msg_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);
                }
                else
                {
                    UI_Produto_Consulta_Grade frm = new UI_Produto_Consulta_Grade();
                    frm.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                    frm.Descricao = cb_ID_Produto.Text;

                    frm.ShowDialog();

                    lst_Grade = new List<DTO_Produto_Item>();
                    lst_Grade = frm.lst_Produto;

                    if (lst_Grade == null)
                    {
                        MessageBox.Show("Selecione uma Grade!");
                        return;
                    }

                    if (Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Unico)
                    {
                        ID_Grade = lst_Grade[0].ID_Grade;
                        DescricaoGrade = " - " + lst_Grade[0].DescricaoGrade;
                    }

                    if (Parametro_Venda.Bloquear_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                {
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);
                                    return;
                                }

                    if (Parametro_Venda.msg_EstoqueNegativo == true)
                        for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                            if (Convert.ToInt32(_DT.Rows[i]["ID_Grade"]) == ID_Grade)
                                if ((Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]) - Convert.ToDouble(txt_Quantidade.Text)) < 0)
                                    MessageBox.Show(util_msg.msg_EstoqueNegativo, this.Text);

                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        if (lst_Produto[i].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
                            lst_Produto[i].Descricao_Saida == cb_TipoVendaProduto.Text &&
                           lst_Produto[i].ID_Grade == ID_Grade &&
                            TipoProduto != 3)
                        {
                            if (lst_Grade.Count == 1)
                                lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + lst_Grade[0].Quantidade;
                            else
                                lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + Convert.ToDouble(txt_Quantidade.Text);

                            Carrega_Item(lst_Produto);

                            ID_Grade = 0;
                            cb_ID_Produto.SelectedIndex = -1;
                            txt_Quantidade.Text = "1,000";
                            cb_ID_Produto.Focus();
                            return;
                        }
                }
                if (Convert.ToInt32(cb_TipoVendaProduto.SelectedValue) != 0)
                {
                    txt_ValorFinal.Text = "0,00";
                    txt_ValorTotal.Text = "0,00";
                    txt_ValorUnitario.Text = "0,00";
                    txt_Acrescimo.Text = "0,00";
                    txt_Desconto.Text = "0,00";
                }

                if (Parametro_Venda.Agrupar_Produto == true)
                {
                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        if (lst_Produto[i].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
                            lst_Produto[i].Descricao_Saida == cb_TipoVendaProduto.Text &&
                            lst_Produto[i].ID_Grade == ID_Grade)
                        {
                            if (Edita_Item == true)
                            {
                                Edita_Item = false;
                                lst_Produto[i].Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                            }
                            else
                                lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + Convert.ToDouble(txt_Quantidade.Text);

                            lst_Produto[i].ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                            lst_Produto[i].Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                            lst_Produto[i].Desconto = Convert.ToDouble(txt_Desconto.Text);
                            lst_Produto[i].Informacao = txt_InformacaoItem.Text;

                            Carrega_Item(lst_Produto);

                            ID_Grade = 0;
                            cb_ID_Produto.SelectedIndex = -1;
                            txt_Quantidade.Text = "1,000";
                            cb_ID_Produto.Focus();
                            return;
                        }
                }

                if (lst_Produto == null)
                    lst_Produto = new List<DTO_Produto_Item>();

                BLL_Orcamento = new BLL_Orcamento();
                Produto_Item = new DTO_Produto_Item();

                if (ID_Grade == 0 &&
                    lst_Grade.Count > 0)
                {
                    for (int i = 0; i < lst_Grade.Count; i++)
                    {
                        bool _Novo = true;
                        for (int ii = 0; ii <= lst_Produto.Count - 1; ii++)
                        {
                            if (lst_Produto[ii].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
                                lst_Produto[ii].ID_Grade == lst_Grade[i].ID_Grade)
                            {
                                lst_Produto[ii].Quantidade = lst_Produto[ii].Quantidade + lst_Grade[i].Quantidade;
                                _Novo = false;
                            }
                        }
                        if (_Novo == true)
                        {
                            Produto_Item = new DTO_Produto_Item();

                            Produto_Item.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                            Produto_Item.ValorCusto = Convert.ToDouble(txt_ValorCusto.Text);
                            Produto_Item.ValorProduto = Convert.ToDouble(txt_ValorUnitario.Text);
                            Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                            Produto_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                            Produto_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
                            Produto_Item.Descricao_Saida = cb_TipoVendaProduto.Text;
                            Produto_Item.TipoSaida = Convert.ToInt32(cb_TipoVendaProduto.SelectedValue);
                            Produto_Item.Descricao_Produto = cb_ID_Produto.Text + " - " + lst_Grade[i].DescricaoGrade;
                            Produto_Item.Informacao = lst_Grade[i].Informacao;
                            Produto_Item.ID_Grade = lst_Grade[i].ID_Grade;
                            Produto_Item.Quantidade = lst_Grade[i].Quantidade;

                            //VALIDA INFORMAÇÕES
                            if (!BLL_Orcamento.Grava_Item(Produto_Item))
                                return;

                            //ADICIONA A LISTA
                            lst_Produto.Add(Produto_Item);
                        }
                    }
                }
                else
                {
                    Produto_Item = new DTO_Produto_Item();

                    Produto_Item.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                    Produto_Item.Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                    Produto_Item.ValorCusto = Convert.ToDouble(txt_ValorCusto.Text);
                    Produto_Item.ValorProduto = Convert.ToDouble(txt_ValorUnitario.Text);
                    Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                    Produto_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                    Produto_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
                    Produto_Item.Descricao_Saida = cb_TipoVendaProduto.Text;
                    Produto_Item.TipoSaida = Convert.ToInt32(cb_TipoVendaProduto.SelectedValue);
                    Produto_Item.Descricao_Produto = cb_ID_Produto.Text + DescricaoGrade;
                    Produto_Item.Informacao = txt_InformacaoItem.Text;
                    Produto_Item.ID_Grade = ID_Grade;

                    //VALIDA INFORMAÇÕES
                    if (!BLL_Orcamento.Grava_Item(Produto_Item))
                        return;

                    //ADICIONA A LISTA
                    lst_Produto.Add(Produto_Item);
                }

                Carrega_Item(lst_Produto);
                ID_Grade = 0;
                cb_ID_Produto.SelectedIndex = -1;
                txt_Quantidade.Text = "1,000";
                cb_ID_Produto.Focus();
            }
        }

        private void bt_ExibeResumo_Click(object sender, EventArgs e)
        {
            UI_Senha_Supervidor UI_Senha_Supervidor = new UI_Senha_Supervidor();
            UI_Senha_Supervidor.DescricaoLiberacao = "EXIBIR RESUMO VENDA";
            UI_Senha_Supervidor.Tipo = 2;
            UI_Senha_Supervidor.ShowDialog();

            if (UI_Senha_Supervidor.Liberado == false)
                return;

            UI_Venda_Resumo UI_Venda_Resumo = new UI_Venda_Resumo();
            UI_Venda_Resumo._lst_Produto = lst_Produto;
            UI_Venda_Resumo.TipoPessoa = util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString());
            UI_Venda_Resumo.ID_Pessoa = util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString());

            UI_Venda_Resumo.Show();
        }
    }

}
