using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;
using Sistema.NFe;
using System.Data.OleDb;
using System.Xml;
using System.IO;

namespace Sistema.UI
{
    public partial class UI_Produto_Entrada : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Entrada()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        BLL_Pessoa BLL_Pessoa;
        BLL_Produto BLL_Produto;
        BLL_Produto_Entrada BLL_Produto_Entrada;
        BLL_TabelaValor BLL_TabelaValor;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;
        DataRow DRPessoa;
        DataRow DREndereco;
        DataRow DRTelefone;
        DataRow DRProduto;
        DataTable DT;
        DataTable DTProduto;
        DataTable DTPessoa;
        DataTable DTEndereco;
        DataTable DTTelefone;
        DataTable DTGrupo;
        DataTable DTR_Empresa;
        DataTable DTR_Compra;
        DataTable DTR_Pessoa;
        DataTable DTR_Endereco;
        DataTable DTR_Telefone;
        DataTable DTR_Email;
        DataTable DTR_Compra_Item;

        bool Edita_Item = false;
        int Edita_ID = 0;

        int ID_Grade;
        public int ID_Temp;

        int obj;

        string DescricaoGrade;

        List<DTO_Produto_Item> lst_Produto;

        DateTime ValidaData;
        #endregion

        #region PROPRIEDADES
        public Tipo_Entrada_Produto Tipo { get; set; }
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Produto_Entrada Produto_Entrada;
        DTO_Produto_Item Produto_Item;
        DTO_TabelaValor TabelaValor;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            switch (Parametro_Venda.Produto_PrecoVenda)
            {
                case Composicao_PrecoVenda.Custo_Final:
                    lb_TipoValorVenda.Text = util_msg.msg_ValorVenda_CustoFinal;
                    break;

                case Composicao_PrecoVenda.Preco_Compra:
                    lb_TipoValorVenda.Text = util_msg.msg_ValorVenda_ValorCompra;
                    break;
            }

            switch (Tipo)
            {
                case Tipo_Entrada_Produto.Compra:
                    this.Text = "COMPRA DE PRODUTO";
                    ck_Faturado.Text = "FATURADO";
                    break;

                case Tipo_Entrada_Produto.Producao:
                    this.Text = "ENTRADA DE PRODUÇÃO";
                    ck_Faturado.Text = "LANÇADO";
                    break;
            }

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

            DataGridViewCheckBoxColumn col_Faturado = new DataGridViewCheckBoxColumn();
            col_Faturado.DataPropertyName = "Faturado";

            if (Tipo == Tipo_Entrada_Produto.Compra)
                col_Faturado.HeaderText = "FATURADO";

            if (Tipo == Tipo_Entrada_Produto.Producao)
                col_Faturado.HeaderText = "LANÇADO";

            col_Faturado.Width = 80;
            DG.Columns.Add(col_Faturado);
            #endregion

            Limpa_Campos();
        }

        private void CarregaCB()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);

            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;

            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();

            _DT = new DataTable();
            _DT = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Tabela);
        }

        private void CarregaProduto()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 2, 4";

            if (Parametro_Venda.Produto_Marca == true)
                Produto.ConsultaMarca = true;

            DTProduto = BLL_Produto.Busca(Produto);
            util_dados.CarregaCombo(DTProduto, "Descricao", "ID", cb_ID_Produto);
            cb_ID_Produto.SelectedIndex = -1;
        }

        private void Busca_Produto(int _ID)
        {
            txt_ValorIPI.Text = "0,00";
            txt_ValorST.Text = "0,00";
            txt_ValorCompra.Text = "0,00";
            txt_ValorTotal.Text = "0,00";

            try
            {
                Produto = new DTO_Produto();

                Produto.ID = _ID;
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa; ;
                Produto.Consulta_Tipo = true;
                Produto.Tipo = "1, 2, 4";
                Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

                DTProduto = BLL_Produto.Busca_new(Produto);

                if (DTProduto.Rows.Count > 0)
                {
                    txt_ValorCompra.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["ValorCompra"]), 2);
                    txt_ValorIPI.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["ValorIPI"]), 2);
                    txt_ValorST.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["ValorST"]), 2);

                    double CustoFinal = 0;
                    CustoFinal += Convert.ToDouble(txt_ValorCompra.Text);
                    CustoFinal += Convert.ToDouble(txt_ValorIPI.Text);
                    CustoFinal += Convert.ToDouble(txt_ValorST.Text);

                    switch (Parametro_Venda.Produto_PrecoVenda)
                    {
                        case Composicao_PrecoVenda.Custo_Final:
                            if (Parametro_Cadastro.EntradaProduto == 1) //ATUALIZA MARGEM
                            {
                                txt_Margem.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, Convert.ToDouble(DTProduto.Rows[0]["ValorVenda"])), 2);
                                txt_ValorVenda.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["ValorVenda"]), 2);
                            }
                            if (Parametro_Cadastro.EntradaProduto == 2) //ATUALIZA VALOR DE VENDA
                            {
                                txt_Margem.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["MargemVenda"]), 2);
                                txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(CustoFinal, Convert.ToDouble(DTProduto.Rows[0]["MargemVenda"])), 2);
                            }
                            break;

                        case Composicao_PrecoVenda.Preco_Compra:
                            if (Parametro_Cadastro.EntradaProduto == 1) //ATUALIZA MARGEM
                            {
                                txt_Margem.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(Convert.ToDouble(txt_ValorCompra.Text), Convert.ToDouble(DTProduto.Rows[0]["ValorVenda"]) - Convert.ToDouble(txt_ValorIPI.Text) - Convert.ToDouble(txt_ValorST.Text)), 2);
                                txt_ValorVenda.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["ValorVenda"]), 2);
                            }
                            if (Parametro_Cadastro.EntradaProduto == 2) //ATUALIZA VALOR DE VENDA
                            {
                                txt_Margem.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["MargemVenda"]), 2);
                                txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(Convert.ToDouble(txt_ValorCompra.Text), Convert.ToDouble(DTProduto.Rows[0]["MargemVenda"])) + Convert.ToDouble(txt_ValorIPI.Text) + Convert.ToDouble(txt_ValorST.Text), 2);
                            }
                            break;
                    }

                    txt_ValorVendaAntigo.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["ValorVenda"]), 2);

                    Calcula_Item();
                }
            }
            catch (Exception)
            {
                throw;
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

        private void Busca_Item(int _ID)
        {
            BLL_Produto_Entrada = new BLL_Produto_Entrada();
            Produto_Entrada = new DTO_Produto_Entrada();

            Produto_Entrada.ID = _ID;
            DataTable _DT = new DataTable();
            _DT = BLL_Produto_Entrada.Busca_Item(Produto_Entrada);

            lst_Produto = new List<DTO_Produto_Item>();
            dg_Itens.Rows.Clear();

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID = (int)_DT.Rows[i]["ID"];
                Produto_Item.ID_Produto = (int)_DT.Rows[i]["ID_Produto"];
                Produto_Item.Quantidade = Double.Parse(_DT.Rows[i]["Quantidade"].ToString());
                Produto_Item.ValorCompra = Double.Parse(_DT.Rows[i]["ValorCompra"].ToString());
                Produto_Item.OutrosCustos = Double.Parse(_DT.Rows[i]["OutrosCustos"].ToString());
                Produto_Item.ValorIPI = Double.Parse(_DT.Rows[i]["ValorIPI"].ToString());
                Produto_Item.ValorST = Double.Parse(_DT.Rows[i]["ValorST"].ToString());
                Produto_Item.ValorTotal = Double.Parse(_DT.Rows[i]["ValorTotal"].ToString());
                Produto_Item.Descricao_Produto = _DT.Rows[i]["DescricaoProduto"].ToString();
                Produto_Item.ID_Grade = (int)_DT.Rows[i]["ID_Grade"];
                Produto_Item.ValorVenda = Double.Parse(_DT.Rows[i]["ValorVenda"].ToString());
                Produto_Item.Margem = Double.Parse(_DT.Rows[i]["Margem"].ToString());
                Produto_Item.ValorAntigo = Double.Parse(_DT.Rows[i]["ValorAntigo"].ToString());
                Produto_Item.Reajuste = (((Double.Parse(_DT.Rows[i]["ValorTotal"].ToString()) / Double.Parse(_DT.Rows[i]["Quantidade"].ToString())) / Convert.ToDouble(_DT.Rows[i]["ValorAntigo"].ToString()) - 1) * 100);

                lst_Produto.Add(Produto_Item);
            }
            if (lst_Produto.Count > 0)
                Carrega_Item(lst_Produto);
        }

        private void CarregaPessoa(int _Tipo)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                switch (_Tipo)
                {
                    case 1: //Tab Principal
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

                    case 2://Tab Pesquisa Compra
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

        private void Calcula_OutrosCustos()
        {
            try
            {
                double TotalProduto = 0;
                double OutrosCustos = Convert.ToDouble(txt_OutrosCustos.Text);

                if (lst_Produto.Count > 0)
                {
                    #region SOMA VALOR TOTAL DO CUSTO DE COMPRA
                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        TotalProduto += lst_Produto[i].ValorCompra * lst_Produto[i].Quantidade;
                    #endregion

                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                    {
                        double aux;

                        aux = (lst_Produto[i].ValorCompra * 100) / TotalProduto;

                        lst_Produto[i].OutrosCustos = (OutrosCustos * (aux / 100)) * lst_Produto[i].Quantidade;

                        double aux_Quantidade = lst_Produto[i].Quantidade;
                        double aux_ValorCompra = lst_Produto[i].ValorCompra;
                        double aux_OutrosCustos = lst_Produto[i].OutrosCustos;
                        double aux_ValorIPI = lst_Produto[i].ValorIPI;
                        double aux_ValorST = lst_Produto[i].ValorST;

                        switch (Parametro_Venda.Produto_PrecoVenda)
                        {
                            case Composicao_PrecoVenda.Custo_Final:
                                if (Parametro_Cadastro.EntradaProduto == 1) //ATUALIZA MARGEM
                                {
                                    lst_Produto[i].Margem = util_dados.CalculaMargem((lst_Produto[i].ValorCompra + lst_Produto[i].ValorIPI + lst_Produto[i].ValorST + (lst_Produto[i].OutrosCustos / lst_Produto[i].Quantidade)), lst_Produto[i].ValorVenda);
                                }
                                if (Parametro_Cadastro.EntradaProduto == 2) //ATUALIZA VALOR DE VENDA
                                {
                                    lst_Produto[i].ValorVenda = util_dados.CalculaValor(lst_Produto[i].ValorCompra + lst_Produto[i].ValorIPI + lst_Produto[i].ValorST + (lst_Produto[i].OutrosCustos / lst_Produto[i].Quantidade), lst_Produto[i].Margem);
                                }

                                //  lst_Produto[i].Margem = util_dados.CalculaMargem((lst_Produto[i].ValorCompra + lst_Produto[i].ValorIPI + lst_Produto[i].ValorST + (lst_Produto[i].OutrosCustos / lst_Produto[i].Quantidade)), lst_Produto[i].ValorVenda);
                                break;

                            case Composicao_PrecoVenda.Preco_Compra:
                                if (Parametro_Cadastro.EntradaProduto == 1) //ATUALIZA MARGEM
                                {
                                    lst_Produto[i].Margem = util_dados.CalculaMargem(lst_Produto[i].ValorCompra, lst_Produto[i].ValorVenda - lst_Produto[i].ValorIPI - lst_Produto[i].ValorST - (lst_Produto[i].OutrosCustos / lst_Produto[i].Quantidade));
                                }
                                if (Parametro_Cadastro.EntradaProduto == 2) //ATUALIZA VALOR DE VENDA
                                {
                                    lst_Produto[i].ValorVenda = util_dados.CalculaValor(lst_Produto[i].ValorCompra, lst_Produto[i].Margem) + lst_Produto[i].ValorIPI + lst_Produto[i].ValorST + (lst_Produto[i].OutrosCustos / lst_Produto[i].Quantidade);
                                }
                                break;
                        }

                        lst_Produto[i].ValorTotal = (aux_Quantidade * (aux_ValorCompra + aux_ValorIPI + aux_ValorST)) + aux_OutrosCustos;
                    }
                }
                else
                {
                    txt_TotalProduto.Text = "0,00";
                    txt_TotalCompra.Text = "0,00";
                }
                Carrega_Item(lst_Produto);
            }
            catch (Exception)
            {
            }
        }

        private void Calcula_Item()
        {
            try
            {
                double Quantidade = Convert.ToDouble(txt_Quantidade.Text);

                double ValorUnitario = Convert.ToDouble(txt_ValorCompra.Text);
                double ValorIPI = Convert.ToDouble(txt_ValorIPI.Text);
                double ValorST = Convert.ToDouble(txt_ValorST.Text);

                txt_ValorTotal.Text = util_dados.ConfigNumDecimal((ValorUnitario + ValorIPI + ValorST) * Quantidade, 2);

                double CustoFinal = ValorUnitario + ValorIPI + ValorST;
                double ValorVenda = Convert.ToDouble(txt_ValorVenda.Text);
                double Margem = Convert.ToDouble(txt_Margem.Text);

                switch (Parametro_Venda.Produto_PrecoVenda)
                {
                    case Composicao_PrecoVenda.Custo_Final:
                        if (Parametro_Cadastro.EntradaProduto == 1) //ATUALIZA MARGEM
                        {
                            txt_Margem.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, ValorVenda), 2);
                            txt_ValorVenda.Text = util_dados.ConfigNumDecimal(ValorVenda, 2);

                            //ValorVenda = util_dados.CalculaValor(CustoFinal, Convert.ToDouble(txt_Margem.Text));
                        }
                        if (Parametro_Cadastro.EntradaProduto == 2) //ATUALIZA VALOR DE VENDA
                        {
                            txt_Margem.Text = util_dados.ConfigNumDecimal(Margem, 2);
                            txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(CustoFinal, Margem), 2);
                        }
                        break;

                    case Composicao_PrecoVenda.Preco_Compra:
                        if (Parametro_Cadastro.EntradaProduto == 1) //ATUALIZA MARGEM
                        {
                            txt_Margem.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorUnitario, ValorVenda) - ValorIPI - ValorST, 2);
                            txt_ValorVenda.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(DTProduto.Rows[0]["ValorVenda"]), 2);

                            //  ValorVenda = util_dados.CalculaValor(ValorUnitario, Convert.ToDouble(txt_Margem.Text)) + ValorIPI + ValorST;
                        }
                        if (Parametro_Cadastro.EntradaProduto == 2) //ATUALIZA VALOR DE VENDA
                        {
                            txt_Margem.Text = util_dados.ConfigNumDecimal(Margem, 2);
                            txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(ValorUnitario, Margem) + ValorIPI + ValorST, 2);
                        }
                        break;
                }

              //  txt_ValorVenda.Text = util_dados.ConfigNumDecimal(ValorVenda, 2);

                if (Convert.ToDouble(txt_ValorVendaAntigo.Text) > Convert.ToDouble(txt_ValorVenda.Text))
                {
                    txt_ValorVendaAntigo.BackColor = Color.White;

                    txt_ValorVenda.BackColor = Color.Red;
                    txt_ValorVenda.ForeColor = Color.White;
                }

                if (Convert.ToDouble(txt_ValorVendaAntigo.Text) < Convert.ToDouble(txt_ValorVenda.Text))
                {
                    txt_ValorVendaAntigo.BackColor = Color.Red;
                    txt_ValorVendaAntigo.ForeColor = Color.White;

                    txt_ValorVenda.BackColor = Color.LightGray;
                    txt_ValorVenda.ForeColor = Color.Black;
                }

                if (Convert.ToDouble(txt_ValorVendaAntigo.Text) == Convert.ToDouble(txt_ValorVenda.Text))
                {
                    txt_ValorVendaAntigo.BackColor = Color.White;

                    txt_ValorVenda.BackColor = Color.LightGray;
                    txt_ValorVenda.ForeColor = Color.Black;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Limpa_Campos()
        {
            DG.DataSource = null;

            txt_Quantidade.Text = "1,000";
            txt_ValorCompra.Text = "0,00";
            txt_ValorIPI.Text = "0,00";
            txt_ValorST.Text = "0,00";

            Edita_Item = false;

            mk_Data.Text = DateTime.Now.ToString();
            mk_Entrega.Text = DateTime.Now.ToString();

            dg_Itens.Rows.Clear();
            lst_Produto = new List<DTO_Produto_Item>();

            switch (Tipo)
            {
                case Tipo_Entrada_Produto.Compra:
                    cb_TipoPessoa.SelectedValue = 3;
                    break;

                case Tipo_Entrada_Produto.Producao:
                    cb_TipoPessoa.SelectedValue = 2;
                    cb_ID_Pessoa.SelectedValue = Parametro_Empresa.ID_Empresa_Ativa;
                    break;
            }


            txt_OutrosCustos.Text = "0,00";

            cb_ID_Pessoa.Focus();

            lb_Quantidade.Text = util_msg.msg_Quantidade_Item + "0,000";
        }

        private void Carrega_Item(List<DTO_Produto_Item> _lst_Produto)
        {
            dg_Itens.Rows.Clear();
            double TotalProduto = 0;
            double Total_IPI = 0;
            double Total_ST = 0;
            double TotalCompra = 0;
            double OutrosCustos = 0;
            double Quantidade = 0;

            for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            {
                dg_Itens.Rows.Add();
                dg_Itens.Rows[i].Cells["col_ID"].Value = _lst_Produto[i].ID;
                dg_Itens.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
                dg_Itens.Rows[i].Cells["col_Descricao_Produto"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens.Rows[i].Cells["col_ValorCompra"].Value = _lst_Produto[i].ValorCompra;
                dg_Itens.Rows[i].Cells["col_OutrosCustos"].Value = _lst_Produto[i].OutrosCustos;
                dg_Itens.Rows[i].Cells["col_ValorIPI"].Value = _lst_Produto[i].ValorIPI;
                dg_Itens.Rows[i].Cells["col_ValorST"].Value = _lst_Produto[i].ValorST;
                dg_Itens.Rows[i].Cells["col_ValorTotal"].Value = _lst_Produto[i].ValorTotal;
                dg_Itens.Rows[i].Cells["col_ID_Grade"].Value = _lst_Produto[i].ID_Grade;
                dg_Itens.Rows[i].Cells["col_Reajuste"].Value = _lst_Produto[i].Reajuste;

                OutrosCustos += lst_Produto[i].OutrosCustos;

                TotalProduto += _lst_Produto[i].Quantidade * _lst_Produto[i].ValorCompra;
                Total_IPI += _lst_Produto[i].Quantidade * _lst_Produto[i].ValorIPI;
                Total_ST += _lst_Produto[i].Quantidade * _lst_Produto[i].ValorST;

                TotalCompra += _lst_Produto[i].ValorTotal;
                Quantidade += _lst_Produto[i].Quantidade;
            }

            txt_TotalProduto.Text = util_dados.ConfigNumDecimal(TotalProduto, 2);
            txt_Total_IPI.Text = util_dados.ConfigNumDecimal(Total_IPI, 2);
            txt_Total_ST.Text = util_dados.ConfigNumDecimal(Total_ST, 2);

            txt_TotalCompra.Text = util_dados.ConfigNumDecimal(TotalCompra, 2);

            txt_OutrosCustos.Text = util_dados.ConfigNumDecimal(OutrosCustos, 2);

            lb_Quantidade.Text = util_msg.msg_Quantidade_Item + util_dados.ConfigNumDecimal(Quantidade, 3);
        }

        private void Pesquisa_Pessoa()
        {
            UI_Pessoa_Consulta frm = new UI_Pessoa_Consulta();
            frm.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

            frm.ShowDialog();

            if (frm.ID_Pessoa == 0)
                return;

            cb_TipoPessoa.SelectedValue = frm.TipoPessoa;
            cb_ID_Pessoa.SelectedValue = frm.ID_Pessoa;
            txt_ID_Pessoa.Text = frm.ID_Pessoa.ToString();

            cb_ID_Produto.Focus();
        }

        private void Pesquisa_Produto()
        {
            UI_Produto_Consulta frm = new UI_Produto_Consulta();
            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;
            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = frm.ID_Produto;

            txt_Quantidade.Focus();
        }

        private void Importa_Excel(string _Arquivo)
        {
            try
            {
                string _StringConexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _Arquivo + ";Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';";

                OleDbConnection _olecon = new OleDbConnection(_StringConexao);
                _olecon.Open();

                string sql = "";
                sql += "SELECT * ";
                sql += "FROM [rpt_Produto_Entrada$]";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, _olecon);

                DataTable _DT = new DataTable();
                da.TableMappings.Add("Temporario", "Tab1");
                da.Fill(_DT);

                _olecon.Close();

                BLL_Produto_Entrada = new BLL_Produto_Entrada();
                BLL_Produto = new BLL_Produto();


                lst_Produto = new List<DTO_Produto_Item>();

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    if (_DT.Rows[i]["QUANTIDADE_COMPRA"] != DBNull.Value &&
                        Convert.ToDouble(_DT.Rows[i]["QUANTIDADE_COMPRA"]) > 0)
                    {
                        Produto = new DTO_Produto();
                        Produto.ID = Convert.ToInt32(_DT.Rows[i]["CODIGO"]);
                        Produto.ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID_GRADE"]);
                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

                        DataTable _DT_Produto = new DataTable();

                        _DT_Produto = BLL_Produto.Busca_AlteraValor(Produto);

                        Produto_Item = new DTO_Produto_Item();

                        Produto_Item = new DTO_Produto_Item();
                        Produto_Item.ID_Produto = Convert.ToInt32(_DT.Rows[i]["CODIGO"]);
                        Produto_Item.Quantidade = Convert.ToDouble(_DT.Rows[i]["QUANTIDADE_COMPRA"]);
                        Produto_Item.ValorCompra = Convert.ToDouble(_DT_Produto.Rows[0]["ValorCompra"]);
                        Produto_Item.ValorIPI = Convert.ToDouble(_DT_Produto.Rows[0]["ValorIPI"]);
                        Produto_Item.ValorST = Convert.ToDouble(_DT_Produto.Rows[0]["ValorST"]);
                        Produto_Item.ValorTotal = Produto_Item.Quantidade * (Produto_Item.ValorCompra + Produto_Item.ValorIPI + Produto_Item.ValorST);
                        Produto_Item.Descricao_Produto = _DT_Produto.Rows[0]["Descricao"].ToString();
                        Produto_Item.ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID_GRADE"]);
                        Produto_Item.Margem = Convert.ToDouble(_DT_Produto.Rows[0]["MargemVenda"]);
                        Produto_Item.ValorVenda = Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"]);
                        Produto_Item.ValorAntigo = Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"]);
                        Produto_Item.Reajuste = 0;

                        //VALIDA INFORMAÇÕES
                        BLL_Produto_Entrada.Grava_Item(Produto_Item);

                        //ADICIONA A LISTA
                        lst_Produto.Add(Produto_Item);
                    }

                Calcula_OutrosCustos();

                cb_ID_Produto.Focus();
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
            util_dados.LimpaCampos(this, gb_Cadastro);

            BLL_Produto_Entrada = new BLL_Produto_Entrada();
            Produto_Entrada = new DTO_Produto_Entrada();

            Produto_Entrada.ID = util_dados.Verifica_int(txt_IDP.Text);
            Produto_Entrada.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto_Entrada.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
            Produto_Entrada.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);

            if (Tipo == Tipo_Entrada_Produto.Compra)
                Produto_Entrada.Tipo_Entrada = 1;

            if (Tipo == Tipo_Entrada_Produto.Producao)
                Produto_Entrada.Tipo_Entrada = 2;

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                     mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                Produto_Entrada.Consulta_Emissao.Filtra = true;
                Produto_Entrada.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                Produto_Entrada.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            }

            DT = BLL_Produto_Entrada.Busca(Produto_Entrada);

            DG.DataSource = DT;
            util_dados.CarregaCampo(this, DT, gb_Cadastro);
            util_dados.CarregaCampo(this, DT, gb_Pessoa);

            DG.Focus();
        }

        public override void Gravar()
        {
            try
            {
                if (ck_Faturado.Checked == true)
                    return;

                BLL_Produto_Entrada = new BLL_Produto_Entrada();
                Produto_Entrada = new DTO_Produto_Entrada();

                Produto_Entrada.Item = lst_Produto;
                Produto_Entrada.ID = util_dados.Verifica_int(txt_ID.Text);

                if (Tipo == Tipo_Entrada_Produto.Compra)
                    Produto_Entrada.Tipo_Entrada = 1;

                if (Tipo == Tipo_Entrada_Produto.Producao)
                    Produto_Entrada.Tipo_Entrada = 2;

                Produto_Entrada.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto_Entrada.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Produto_Entrada.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Produto_Entrada.Documento = txt_Documento.Text;
                Produto_Entrada.Informacao = txt_informacao.Text;
                Produto_Entrada.Data = Convert.ToDateTime(mk_Data.Text);
                Produto_Entrada.Entrega = Convert.ToDateTime(mk_Entrega.Text);
                Produto_Entrada.ID_Usuario = Parametro_Usuario.ID_Usuario_Ativo;

                obj = BLL_Produto_Entrada.Grava(Produto_Entrada);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();

                    Busca_Item(obj);

                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }

                if (ck_Faturado.Checked == false)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_Encerrar_EntradaProduto, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;

                    #region LANÇA FINANCEIRO COMPRA
                    if (Tipo == Tipo_Entrada_Produto.Compra)
                    {
                        UI_Compra_Lanca frm = new UI_Compra_Lanca();

                        frm.Documento = txt_ID.Text;
                        frm.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        frm.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                        frm.Descricao_Pessoa = cb_ID_Pessoa.Text;
                        frm.Valor = Convert.ToDouble(txt_TotalCompra.Text);
                        frm.Emissao = Convert.ToDateTime(mk_Data.Text);

                        frm.ShowDialog();

                        if (frm.Concluido == false)
                            return;
                    }
                    #endregion

                    #region ALTERA SITUAÇÃO COMPRA
                    Produto_Entrada.Faturado = true;
                    Produto_Entrada.ID = int.Parse(txt_ID.Text);
                    Produto_Entrada.Item = lst_Produto;
                    Produto_Entrada.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    BLL_Produto_Entrada.Altera_Fatura(Produto_Entrada);
                    BLL_Produto_Entrada.Atualiza_ValorEstoque(Produto_Entrada);

                    ck_Faturado.Checked = true;
                    #endregion
                }

                MessageBox.Show(util_msg.msg_EntradaProdutConcluida, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Pessoa);
            util_dados.LimpaCampos(this, gb_Itens);

            ExibeRegistro();
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Produto_Entrada = new BLL_Produto_Entrada();
                Produto_Entrada = new DTO_Produto_Entrada();

                Produto_Entrada.ID = util_dados.Verifica_int(txt_ID.Text);
                Produto_Entrada.Item = lst_Produto;

                BLL_Produto_Entrada.Exclui(Produto_Entrada);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Novo();
                Limpa_Campos();
            }
            catch (Exception ex)
            {
                throw new Exception(util_msg.msg_Erro + ex.Message);
            }
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }

        public override void Imprimir()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
            {
                MessageBox.Show("Nenhuma compra selecionada!");
                return;
            }

            LocalReport rpt = new LocalReport();
            string rpt_Nome = "rpt_Compra.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Produto_Entrada = new BLL_Produto_Entrada();
            Produto_Entrada = new DTO_Produto_Entrada();

            Produto_Entrada.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto_Entrada.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Compra = BLL_Produto_Entrada.Busca_Relatorio(Produto_Entrada);
            DTR_Compra_Item = BLL_Produto_Entrada.Busca_Item_Relatorio(Produto_Entrada);

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
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
            ReportDataSource ds_Compra = new ReportDataSource("ds_Compra", DTR_Compra);
            ReportDataSource ds_Compra_Item = new ReportDataSource("ds_Compra_Item", DTR_Compra_Item);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("TotalCompra", util_dados.ConfigNumDecimal(txt_ValorCompra.Text, 3));

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Compra);
            rpt.DataSources.Add(ds_Compra_Item);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.DataSources.Add(ds_Endereco);
            rpt.DataSources.Add(ds_Telefone);
            rpt.DataSources.Add(ds_Email);
            rpt.SetParameters(new ReportParameter[] { p1 });

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                //Impressora = EscolheImpressora.PrinterSettings.PrinterName;

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
            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = "rpt_Compra.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Produto_Entrada = new BLL_Produto_Entrada();
            Produto_Entrada = new DTO_Produto_Entrada();

            Produto_Entrada.ID = util_dados.Verifica_int(txt_ID.Text);
            Produto_Entrada.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DTR_Compra = BLL_Produto_Entrada.Busca_Relatorio(Produto_Entrada);
            DTR_Compra_Item = BLL_Produto_Entrada.Busca_Item_Relatorio(Produto_Entrada);

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
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
            ReportDataSource ds_Compra = new ReportDataSource("ds_Compra", DTR_Compra);
            ReportDataSource ds_Compra_Item = new ReportDataSource("ds_Compra_Item", DTR_Compra_Item);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("TotalCompra", util_dados.ConfigNumDecimal(txt_ValorCompra.Text, 3));

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Compra);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Compra_Item);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

            rpt.rpt_Viewer.RefreshReport();
            rpt.Show();
        }
        #endregion

        #region FORM
        private void UI_Venda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ValorCompra.Focused == true ||
                txt_Quantidade.Focused == true ||
                txt_ValorIPI.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Venda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Pesquisa_Pessoa();

            if (e.KeyCode == Keys.F10)
                Pesquisa_Produto();
        }

        private void UI_Venda_Load(object sender, EventArgs e)
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

            //Novo();
            Inicia_Form();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaPessoa_Click(object sender, EventArgs e)
        {
            Pesquisa_Pessoa();
        }

        private void bt_PesquisaProduto_Click(object sender, EventArgs e)
        {
            Pesquisa_Produto();
        }

        private void bt_AdicionaProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (util_dados.Verifica_Double(txt_ValorTotal.Text) == 0 ||
                    util_dados.Verifica_Double(txt_ValorVenda.Text) == 0)
                    return;

                if (cb_ID_Produto.SelectedValue != null)
                {
                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();
                    Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                    Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    List<DTO_Produto_Item> lst_Grade = new List<DTO_Produto_Item>();

                    DT = BLL_Produto.Busca_Estoque(Produto);
                    if (DT == null)
                    {
                        MessageBox.Show("Estoque não cadastrado!");
                        return;
                    }

                    if (DT.Rows.Count == 1)
                    {
                        DR = DT.Rows[0];
                        ID_Grade = Convert.ToInt32(DR["ID_Grade"]);

                        if (Convert.ToString(DR["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
                            DescricaoGrade = " - " + Convert.ToString(DR["DescricaoGrade"]);
                        else
                            DescricaoGrade = string.Empty;
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

                        if (Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Unico ||
                            lst_Grade.Count == 1)
                        {
                            ID_Grade = lst_Grade[0].ID_Grade;
                            DescricaoGrade = " - " + lst_Grade[0].DescricaoGrade;
                        }

                        for (int i = 0; i <= lst_Produto.Count - 1; i++)
                            if (lst_Produto[i].ID_Produto == Convert.ToInt32(cb_ID_Produto.SelectedValue) &&
                                lst_Produto[i].ID_Grade == ID_Grade)
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

                    if (lst_Produto == null)
                        lst_Produto = new List<DTO_Produto_Item>();

                    BLL_Produto_Entrada = new BLL_Produto_Entrada();
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
                                if (Edita_Item == true)
                                {
                                    lst_Produto[Edita_ID].ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                                    lst_Produto[Edita_ID].ValorCompra = Convert.ToDouble(txt_ValorCompra.Text);
                                    lst_Produto[Edita_ID].ValorIPI = Convert.ToDouble(txt_ValorIPI.Text);
                                    lst_Produto[Edita_ID].ValorST = Convert.ToDouble(txt_ValorST.Text);
                                    lst_Produto[Edita_ID].ValorTotal = Convert.ToDouble(txt_ValorTotal.Text);
                                    lst_Produto[Edita_ID].Descricao_Produto = cb_ID_Produto.Text + " - " + lst_Grade[i].DescricaoGrade;
                                    lst_Produto[Edita_ID].Quantidade = lst_Grade[i].Quantidade;
                                    lst_Produto[Edita_ID].ID_Grade = lst_Grade[i].ID_Grade;
                                    lst_Produto[Edita_ID].Margem = Convert.ToDouble(txt_Margem.Text);
                                    lst_Produto[Edita_ID].ValorVenda = Convert.ToDouble(txt_ValorVenda.Text);
                                    lst_Produto[Edita_ID].ValorAntigo = Convert.ToDouble(txt_ValorVendaAntigo.Text);
                                    lst_Produto[Edita_ID].Reajuste = (((Convert.ToDouble(txt_ValorVenda.Text) / Convert.ToDouble(txt_Quantidade.Text)) / Convert.ToDouble(txt_ValorVendaAntigo.Text) - 1) * 100);

                                    Edita_Item = false;
                                }
                                else
                                {
                                    Produto_Item = new DTO_Produto_Item();

                                    Produto_Item.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                                    Produto_Item.ValorCompra = Convert.ToDouble(txt_ValorCompra.Text);
                                    Produto_Item.ValorIPI = Convert.ToDouble(txt_ValorIPI.Text);
                                    Produto_Item.ValorST = Convert.ToDouble(txt_ValorST.Text);
                                    Produto_Item.ValorTotal = Convert.ToDouble(txt_ValorTotal.Text);
                                    Produto_Item.Descricao_Produto = cb_ID_Produto.Text + " - " + lst_Grade[i].DescricaoGrade;
                                    Produto_Item.Quantidade = lst_Grade[i].Quantidade;
                                    Produto_Item.ID_Grade = lst_Grade[i].ID_Grade;
                                    Produto_Item.Margem = Convert.ToDouble(txt_Margem.Text);
                                    Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorVenda.Text);
                                    Produto_Item.ValorAntigo = Convert.ToDouble(txt_ValorVendaAntigo.Text);
                                    Produto_Item.Reajuste = (((Convert.ToDouble(txt_ValorVenda.Text) / Convert.ToDouble(txt_Quantidade.Text)) / Convert.ToDouble(txt_ValorVendaAntigo.Text) - 1) * 100);

                                    //VALIDA INFORMAÇÕES
                                    BLL_Produto_Entrada.Grava_Item(Produto_Item);

                                    //ADICIONA A LISTA
                                    lst_Produto.Add(Produto_Item);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Edita_Item == true)
                        {
                            lst_Produto[Edita_ID].ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                            lst_Produto[Edita_ID].ValorCompra = Convert.ToDouble(txt_ValorCompra.Text);
                            lst_Produto[Edita_ID].ValorIPI = Convert.ToDouble(txt_ValorIPI.Text);
                            lst_Produto[Edita_ID].ValorST = Convert.ToDouble(txt_ValorST.Text);
                            lst_Produto[Edita_ID].ValorTotal = Convert.ToDouble(txt_ValorTotal.Text);
                            lst_Produto[Edita_ID].Descricao_Produto = cb_ID_Produto.Text + DescricaoGrade;
                            lst_Produto[Edita_ID].Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                            lst_Produto[Edita_ID].ID_Grade = ID_Grade;
                            lst_Produto[Edita_ID].Margem = Convert.ToDouble(txt_Margem.Text);
                            lst_Produto[Edita_ID].ValorVenda = Convert.ToDouble(txt_ValorVenda.Text);
                            lst_Produto[Edita_ID].ValorAntigo = Convert.ToDouble(txt_ValorVendaAntigo.Text);
                            lst_Produto[Edita_ID].Reajuste = (((Convert.ToDouble(txt_ValorVenda.Text) / Convert.ToDouble(txt_Quantidade.Text)) / Convert.ToDouble(txt_ValorVendaAntigo.Text) - 1) * 100);

                            Edita_Item = false;
                        }
                        else
                        {
                            Produto_Item = new DTO_Produto_Item();
                            Produto_Item.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                            Produto_Item.Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                            Produto_Item.ValorCompra = Convert.ToDouble(txt_ValorCompra.Text);
                            Produto_Item.ValorIPI = Convert.ToDouble(txt_ValorIPI.Text);
                            Produto_Item.ValorST = Convert.ToDouble(txt_ValorST.Text);
                            Produto_Item.ValorTotal = Convert.ToDouble(txt_ValorTotal.Text);
                            Produto_Item.Descricao_Produto = cb_ID_Produto.Text + DescricaoGrade;
                            Produto_Item.ID_Grade = ID_Grade;
                            Produto_Item.Margem = Convert.ToDouble(txt_Margem.Text);
                            Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorVenda.Text);
                            Produto_Item.ValorAntigo = Convert.ToDouble(txt_ValorVendaAntigo.Text);
                            Produto_Item.Reajuste = (((Convert.ToDouble(txt_ValorVenda.Text) / Convert.ToDouble(txt_Quantidade.Text)) / Convert.ToDouble(txt_ValorVendaAntigo.Text) - 1) * 100);

                            //VALIDA INFORMAÇÕES
                            BLL_Produto_Entrada.Grava_Item(Produto_Item);

                            //ADICIONA A LISTA
                            lst_Produto.Add(Produto_Item);
                        }
                    }

                    Calcula_OutrosCustos();

                    cb_ID_Produto.Focus();
                    ID_Grade = 0;
                    cb_ID_Produto.SelectedIndex = -1;
                    txt_Quantidade.Text = "1,000";
                    txt_ValorCompra.Text = "0,00";
                    txt_ValorIPI.Text = "0,00";
                    txt_ValorST.Text = "0,00";
                    txt_ValorTotal.Text = "0,00";
                    txt_ValorVenda.Text = "0,00";
                    txt_ValorVendaAntigo.Text = "0,00";
                    cb_ID_Produto.Focus();

                    Calcula_Item();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_ExcluiProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_Itens.Rows.Count == 0)
                    return;

                if (ck_Faturado.Checked == true)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (util_dados.Verifica_int(txt_ID.Text) > 0 &&
                    lst_Produto[dg_Itens.CurrentRow.Index].ID > 0)
                {
                    BLL_Produto_Entrada = new BLL_Produto_Entrada();
                    Produto_Entrada = new DTO_Produto_Entrada();
                    Produto_Item = new DTO_Produto_Item();
                    List<DTO_Produto_Item> _Item = new List<DTO_Produto_Item>();

                    Produto_Item.ID = Convert.ToInt32(lst_Produto[dg_Itens.CurrentRow.Index].ID);
                    _Item.Add(Produto_Item);

                    Produto_Entrada.Item = _Item;

                    BLL_Produto_Entrada.Exclui_Item(Produto_Entrada);

                    if (ck_Faturado.Checked == true)
                    {
                        msgbox = MessageBox.Show(util_msg.msg_Confirma_RetiradaEstoque, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msgbox == DialogResult.No)
                            return;

                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();
                        Produto.Estoque = new List<DTO_Produto_Estoque>();
                        Produto_Estoque = new DTO_Produto_Estoque();

                        Produto_Estoque.Estoque_Atual = Convert.ToDouble(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_Quantidade"].Value);
                        Produto_Estoque.ID_Grade = Convert.ToInt32(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ID_Grade"].Value);
                        Produto_Estoque.Adiciona = false;

                        Produto.Estoque.Add(Produto_Estoque);
                        Produto.ID = Convert.ToInt32(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ID_Produto"].Value);
                        Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        BLL_Produto.Atualiza_Estoque(Produto);
                    }

                    Busca_Item(Convert.ToInt32(txt_ID.Text));
                }
                else
                    lst_Produto.RemoveAt(dg_Itens.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

            Calcula_OutrosCustos();

            cb_ID_Produto.Focus();
        }

        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Limpa_Campos();

            cb_ID_Tabela.SelectedIndex = 0;
        }

        private void bt_ImportaExcel_Click(object sender, EventArgs e)
        {
            Pesquisa_Arquivo.Filter = "Arquivos Excel|*.xls; *.xlsx";
            Pesquisa_Arquivo.ShowDialog();

            if (Pesquisa_Arquivo.FileName.ToString() != string.Empty)
                Importa_Excel(Pesquisa_Arquivo.FileName);
        }        
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(1);
        }

        private void cb_TipoPessoaP_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(2);
        }

        private void cb_ID_Pessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_ID_Pessoa.Text.Trim() != string.Empty)
                    if (cb_ID_Pessoa.SelectedValue.GetType() == typeof(int) && Convert.ToInt32(cb_ID_Pessoa.SelectedValue) > 0)
                        Busca_Pessoa(Convert.ToInt32(cb_ID_Pessoa.SelectedValue));
            }
            catch (Exception)
            {
                //  txt_ID_Produto.Text = "0";
            }
        }

        private void cb_ID_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_Produto.SelectedIndex = -1;
        }

        private void cb_ID_Produto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_ID_Produto.Focused == true)
                    if (cb_ID_Produto.SelectedValue.GetType() == typeof(int) && Convert.ToInt32(cb_ID_Produto.SelectedValue) > 0)
                        Busca_Produto(Convert.ToInt32(cb_ID_Produto.SelectedValue));
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_ValorCompra_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorCompra.Text) == 0)
                txt_ValorCompra.Text = "0";

            txt_ValorCompra.Text = util_dados.ConfigNumDecimal(txt_ValorCompra.Text, 2);

            Calcula_Item();
        }

        private void txt_Quantidade_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Quantidade.Text) == 0)
                txt_Quantidade.Text = "1,000";

            txt_Quantidade.Text = util_dados.ConfigNumDecimal(txt_Quantidade.Text, 3);

            Calcula_Item();
        }

        private void txt_ValorIPI_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorIPI.Text) == 0)
                txt_ValorIPI.Text = "0";

            txt_ValorIPI.Text = util_dados.ConfigNumDecimal(txt_ValorIPI.Text, 2);

            Calcula_Item();
        }

        private void txt_ValorST_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorST.Text) == 0)
                txt_ValorST.Text = "0";

            txt_ValorST.Text = util_dados.ConfigNumDecimal(txt_ValorST.Text, 2);

            Calcula_Item();
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Busca_Item(util_dados.Verifica_int(txt_ID.Text));
            Config(StatusForm.Consulta);
        }

        private void txt_OutrosCustos_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_OutrosCustos.Text) == 0)
                txt_OutrosCustos.Text = "0";

            txt_OutrosCustos.Text = util_dados.ConfigNumDecimal(txt_OutrosCustos.Text, 2);

            Calcula_OutrosCustos();
        }

        private void txt_Margem_Leave(object sender, EventArgs e)
        {
            if (txt_Margem.Text.Trim() == string.Empty)
                txt_Margem.Text = "0";

            if (Convert.ToDouble(txt_Margem.Text) < 0 || Convert.ToDouble(txt_Margem.Text) > 99)
            {
                MessageBox.Show("Valor Inválido!\n0% ~ 99%");
                txt_Margem.Text = "0";
            }

            txt_Margem.Text = util_dados.ConfigNumDecimal(txt_Margem.Text, 2);

            double Margem = util_dados.Verifica_Double(txt_Margem.Text);

            switch (Parametro_Venda.Produto_PrecoVenda)
            {
                case Composicao_PrecoVenda.Custo_Final:
                    double CustoFinal = util_dados.Verifica_Double(txt_ValorCompra.Text);
                    CustoFinal += util_dados.Verifica_Double(txt_ValorIPI.Text);
                    CustoFinal += util_dados.Verifica_Double(txt_ValorST.Text);

                    txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(CustoFinal, Margem), 2);
                    break;

                case Composicao_PrecoVenda.Preco_Compra:
                    double ValorCompra = util_dados.Verifica_Double(txt_ValorCompra.Text);
                    double ValorIPI = util_dados.Verifica_Double(txt_ValorIPI.Text);
                    double ValorST = util_dados.Verifica_Double(txt_ValorST.Text);

                    txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(ValorCompra, Margem) + ValorIPI + ValorST, 2);
                    break;
            }
        }

        private void txt_ValorVenda_Leave(object sender, EventArgs e)
        {
            if (txt_ValorVenda.Text.Trim() == string.Empty)
                txt_ValorVenda.Text = "0";

            txt_ValorVenda.Text = util_dados.ConfigNumDecimal(txt_ValorVenda.Text, 2);

            switch (Parametro_Venda.Produto_PrecoVenda)
            {
                case Composicao_PrecoVenda.Custo_Final:
                    double CustoFinal = util_dados.Verifica_Double(txt_ValorCompra.Text);
                    CustoFinal += util_dados.Verifica_Double(txt_ValorIPI.Text);
                    CustoFinal += util_dados.Verifica_Double(txt_ValorST.Text);

                    txt_Margem.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, Convert.ToDouble(txt_ValorVenda.Text)), 2);
                    break;

                case Composicao_PrecoVenda.Preco_Compra:
                    double ValorCompra = util_dados.Verifica_Double(txt_ValorCompra.Text);
                    double ValorIPI = util_dados.Verifica_Double(txt_ValorIPI.Text);
                    double ValorST = util_dados.Verifica_Double(txt_ValorST.Text);
                    txt_Margem.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorCompra, Convert.ToDouble(txt_ValorVenda.Text) - ValorIPI - ValorST), 2);
                    break;
            }
        }
        #endregion

        #region MASKEDBOX
        private void mk_Entrega_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Entrega.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Entrega.Text = Convert.ToString(DateTime.Now);
                mk_Entrega.Focus();
            }

        }

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

        #region DATAGRIDVIEW
        private void dg_Itens_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edita_Item = true;
            Edita_ID = dg_Itens.CurrentRow.Index;

            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = Convert.ToInt32(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ID_Produto"].Value);

            txt_Quantidade.Focus();
            txt_Quantidade.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_Quantidade"].Value, 3);
            txt_ValorCompra.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ValorCompra"].Value, 2);
            txt_ValorIPI.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ValorIPI"].Value, 2);
            txt_ValorST.Text = util_dados.ConfigNumDecimal(dg_Itens.Rows[dg_Itens.CurrentRow.Index].Cells["col_ValorST"].Value, 2);
        }
        #endregion

    }
}
