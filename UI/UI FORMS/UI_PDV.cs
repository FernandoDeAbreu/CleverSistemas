using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;
using System.Drawing.Printing;
using Microsoft.Win32;
using System.IO;

namespace Sistema.UI
{
    public partial class UI_PDV : Form
    {
        public UI_PDV()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_Venda BLL_Venda;
        BLL_Pessoa BLL_Pessoa;
        BLL_Parametro BLL_Parametro;
        BLL_Usuario BLL_Usuario;
        BLL_Imagem BLL_Imagem;

        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_Produto_Item Produto_Item;
        DTO_Pessoa Pessoa;
        DTO_Venda Venda;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Parametro Parametro;
        DTO_Usuario Usuario;
        DTO_Imagem Imagem;
        #endregion

        #region VARIAVEIS DIVERSAS
        int ID_Grade = 0;
        int ID_UltimoVenda = 0;
        int obj;

        string DescricaoGrade;

        List<DTO_Produto_Item> lst_Produto;

        DataRow DR;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PONTO DE VENDA";

            DataHora.Enabled = true;
            DataHora.Start();

            Carrega_Parametro();
            CarregaCB();
            Limpa_Campos();

            if (Parametro_Venda.MultiploUsuarioPDV == false)
            {
                cb_ID_UsuarioComissao1.Enabled = false;
                cb_ID_UsuarioComissao1.SelectedValue = Parametro_Usuario.ID_Usuario_Ativo;
            }

            if (Parametro_Venda.Altera_ValorPDV == true)
            {
                txt_ValorFinal.ReadOnly = false;
                txt_ValorFinal.BackColor = Color.LightGray;

              
            }

            lb_Comissao1.Text = Parametro_Venda.Descricao_Comissao;
        }

        private void Limpa_Campos()
        {
            dg_Itens.Rows.Clear();
            lst_Produto = new List<DTO_Produto_Item>();

            txt_DescricaoProduto.Text = "";
            txt_Quantidade.Text = "1,000";
            txt_ValorFinal.Text = "0,00";
            txt_ValorPedido.Text = "0,00";
            txt_ValorTotal.Text = "0,00";
            txt_Desconto.Text = "0,00";
            txt_CNPJ_CPF.Text = "";
            txt_ID.Text = "";

            txt_ID_Pessoa.Text = Parametro_Venda.ID_ConsumidorFinal.ToString();
            txt_DescricaoPessoa.Text = "CONSUMIDOR FINAL";

            cb_ID_UsuarioComissao1.SelectedValue = Parametro_Usuario.ID_Usuario_Ativo;
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
                Parametro_Venda.Ultimo_Valor = Convert.ToBoolean(_DT.Rows[0]["Ultimo_Valor"]);
                Parametro_Venda.Permitir2Vias = Convert.ToBoolean(_DT.Rows[0]["Permitir2Vias"]);
                Parametro_Venda.Agrupar_Produto = Convert.ToBoolean(_DT.Rows[0]["Agrupar_Produto"]);
                Parametro_Venda.Descricao_Comissao = _DT.Rows[0]["Descricao_Comissao"].ToString();
                Parametro_Venda.Limite_Desconto = Convert.ToDouble(_DT.Rows[0]["Limite_Desconto"]);
                Parametro_Venda.Produto_Marca = Convert.ToBoolean(_DT.Rows[0]["Produto_Marca"]);
                Parametro_Venda.Bloquear_EstoqueNegativo = Convert.ToBoolean(_DT.Rows[0]["Bloquear_EstoqueNegativo"]);
                Parametro_Venda.msg_EstoqueNegativo = Convert.ToBoolean(_DT.Rows[0]["msg_EstoqueNegativo"]);
                Parametro_Venda.Orca_ValorTotal = Convert.ToBoolean(_DT.Rows[0]["Orca_ValorTotal"]);
                Parametro_Venda.MultiploUsuarioPDV = Convert.ToBoolean(_DT.Rows[0]["MultiploUsuarioPDV"]);
                Parametro_Venda.Consulta_RapidaProduto = Convert.ToBoolean(_DT.Rows[0]["Consulta_RapidaProduto"]);
            }
        }

        private void CarregaCB()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();

            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Comissao = true;
            Usuario.Comissao = true;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

            DataTable _DT = new DataTable();
            _DT = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_UsuarioComissao1);
            cb_ID_UsuarioComissao1.SelectedIndex = -1;
        }

        private void Exibe_Item(List<DTO_Produto_Item> _lst_Produto)
        {
            dg_Itens.Rows.Clear();
            double SubTotal = 0;
            double TotalDesconto = 0;

            for (int i = 0; i <= _lst_Produto.Count - 1; i++)
            {
                dg_Itens.Rows.Add();
                dg_Itens.Rows[i].Cells["col_Item"].Value = i + 1;
                dg_Itens.Rows[i].Cells["col_ID_Produto"].Value = _lst_Produto[i].ID_Produto;
                dg_Itens.Rows[i].Cells["col_Descricao_Produto"].Value = _lst_Produto[i].Descricao_Produto;
                dg_Itens.Rows[i].Cells["col_Quantidade"].Value = _lst_Produto[i].Quantidade;
                dg_Itens.Rows[i].Cells["col_Valor"].Value = _lst_Produto[i].ValorVenda;
                dg_Itens.Rows[i].Cells["col_Desconto"].Value = _lst_Produto[i].Desconto;
                dg_Itens.Rows[i].Cells["col_ValorTotal"].Value = _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;

                SubTotal += _lst_Produto[i].Quantidade * _lst_Produto[i].ValorVenda;
                TotalDesconto += _lst_Produto[i].Quantidade * _lst_Produto[i].Desconto;
            }

            dg_Itens.RefreshEdit();

            txt_ValorPedido.Text = util_dados.ConfigNumDecimal(SubTotal, 2);
        }

        private void Pesquisa_Produto(string _Codigo)
        {
            txt_DescricaoProduto.Clear();
            txt_ValorFinal.Clear();
            txt_ValorTotal.Clear();

            if (_Codigo.Trim() == string.Empty)
                return;

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Ativo = true;
            Produto.Consulta_PDV = _Codigo;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 3, 5";
            Produto.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;

            DataTable _DT_Produto = new DataTable();
            _DT_Produto = BLL_Produto.Busca_PDV(Produto);

            if (_DT_Produto.Rows.Count > 1)
            {
                UI_Produto_Consulta frm = new UI_Produto_Consulta();
                frm.ConsultaPDV = true;
                frm.Codigo_ConsultaPDV = _Codigo;

                frm.ShowDialog();

                if (frm.ID_Produto > 0)
                    Produto.ID = frm.ID_Produto;
                else
                {
                    MessageBox.Show("Nenhum produto selecionado!");
                    txt_Cod_Barra.SelectAll();
                    return;
                }
            }

            if (_DT_Produto.Rows.Count == 1)
                Produto.ID = Convert.ToInt32(_DT_Produto.Rows[0]["ID"]);

            if (_DT_Produto.Rows.Count == 0)
            {
                MessageBox.Show("Código não encontrado!");
                txt_Cod_Barra.SelectAll();
                return;
            }

            _DT_Produto = BLL_Produto.Busca_Valor(Produto);
            if (_DT_Produto.Rows.Count == 1)
            {
                txt_DescricaoProduto.Text = _DT_Produto.Rows[0]["Descricao"].ToString();
                txt_ValorFinal.Text = util_dados.ConfigNumDecimal(_DT_Produto.Rows[0]["ValorVenda"].ToString(), 2);
                txt_ValorTotal.Text = util_dados.ConfigNumDecimal((Convert.ToDouble(txt_Quantidade.Text) * Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"])), 2);
            }
        }

        private void Adiciona_Produto(string _Codigo, bool ValorAlterado = false)
        {
            if (_Codigo.Trim() == string.Empty)
                return;

            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Ativo = true;
            Produto.Consulta_PDV = _Codigo;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 3, 5";
            Produto.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;

            List<DTO_Produto_Item> lst_Grade = new List<DTO_Produto_Item>();

            DataTable _DT_Produto = new DataTable();
            _DT_Produto = BLL_Produto.Busca_PDV(Produto);
            if (_DT_Produto.Rows.Count > 1)
            {
                UI_Produto_Consulta frm = new UI_Produto_Consulta();
                frm.ConsultaPDV = true;
                frm.Codigo_ConsultaPDV = _Codigo;

                frm.ShowDialog();

                if (frm.ID_Produto > 0)
                    Produto.ID = frm.ID_Produto;
                else
                {
                    MessageBox.Show("Nenhum produto selecionado!");
                    txt_Cod_Barra.SelectAll();
                    return;
                }
            }

            if (_DT_Produto.Rows.Count == 1)
                Produto.ID = Convert.ToInt32(_DT_Produto.Rows[0]["ID"]);

            if (_DT_Produto.Rows.Count == 0)
            {
                MessageBox.Show("Código não encontrado!");
                txt_Cod_Barra.SelectAll();
                return;
            }

            #region ADICIONA PRODUTO SIMPLES
            if (ValorAlterado == false)
            {
                _DT_Produto = BLL_Produto.Busca_Valor(Produto);
                if (_DT_Produto.Rows.Count == 1)
                {
                    txt_DescricaoProduto.Text = _DT_Produto.Rows[0]["Descricao"].ToString();
                    txt_ValorFinal.Text = util_dados.ConfigNumDecimal(_DT_Produto.Rows[0]["ValorVenda"].ToString(), 2);
                    txt_ValorTotal.Text = util_dados.ConfigNumDecimal((Convert.ToDouble(txt_Quantidade.Text) * Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"])), 2);
                }

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
                    ID_Grade = Convert.ToInt32(_DT.Rows[0]["ID_Grade"]);

                    if (Convert.ToString(_DT.Rows[0]["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
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

                    lst_Grade = new List<DTO_Produto_Item>();
                    lst_Grade = frm.lst_Produto;

                    if (lst_Grade == null)
                    {
                        MessageBox.Show("Selecione uma Grade!");
                        return;
                    }

                    ID_Grade = lst_Grade[0].ID_Grade;
                    DescricaoGrade = " - " + lst_Grade[0].DescricaoGrade;

                    if (Altera_Consulta_Grade == true)
                        Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Quantidade;
                }

                if (ID_Grade > 0)
                    Produto.ID_Grade = ID_Grade;

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

                if (Parametro_Venda.Agrupar_Produto == true)
                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        if (lst_Produto[i].ID_Produto == Convert.ToInt32(_DT.Rows[0]["ID_Produto"]) &&
                           lst_Produto[i].ID_Grade == ID_Grade)
                        {
                            lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + Convert.ToDouble(txt_Quantidade.Text);
                            Exibe_Item(lst_Produto);

                            ID_Grade = 0;
                            txt_Quantidade.Text = "1,000";
                            txt_Cod_Barra.Clear();
                            txt_Cod_Barra.Focus();
                            return;
                        }

                if (lst_Produto == null)
                    lst_Produto = new List<DTO_Produto_Item>();

                BLL_Venda = new BLL_Venda();
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID_Produto = Convert.ToInt32(_DT.Rows[0]["ID_Produto"]);
                Produto_Item.Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                Produto_Item.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;
                Produto_Item.ValorCusto = Convert.ToDouble(_DT_Produto.Rows[0]["CustoFinal"]);
                Produto_Item.ValorProduto = Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"]);
                Produto_Item.Acrescimo = 0;

                #region VERIFICA DESCONTO DE ATACADO
                double _Qtd_aux = Convert.ToDouble(txt_Quantidade.Text);

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                {
                    if (lst_Produto[i].ID_Produto == Convert.ToInt32(_DT.Rows[0]["ID_Produto"]))
                        _Qtd_aux += lst_Produto[i].Quantidade;
                }

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID = Convert.ToInt32(_DT.Rows[0]["ID_Produto"]);
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.Quantidade = _Qtd_aux;
                Produto.Consulta_Quantidade = true;

                DataTable _DT_aux = new DataTable();
                _DT_aux = BLL_Produto.Busca_Desconto(Produto);

                if (_DT_aux.Rows.Count > 0)
                {
                    Produto_Item.Desconto = Convert.ToDouble(util_dados.Calcula_Desc_Acres(_DT_aux.Rows[0]["Desconto"] + "%", _DT_Produto.Rows[0]["ValorVenda"].ToString()));
                    Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text) - Produto_Item.Desconto;
                }
                else
                {
                    Produto_Item.Desconto = 0;
                    Produto_Item.ValorVenda = Convert.ToDouble(txt_ValorFinal.Text);
                }
                #endregion

                if (DescricaoGrade != "ÚNICO")
                    Produto_Item.Descricao_Produto = _DT_Produto.Rows[0]["Descricao"].ToString() + DescricaoGrade;
                else
                    Produto_Item.Descricao_Produto = _DT_Produto.Rows[0]["Descricao"].ToString();

                Produto_Item.Descricao_Saida = "VENDA";
                Produto_Item.TipoSaida = 0;
                Produto_Item.ID_Grade = ID_Grade;

                //VALIDA INFORMAÇÕES
                if (!BLL_Venda.Grava_Item(Produto_Item))
                    return;

                //ADICIONA A LISTA
                lst_Produto.Add(Produto_Item);

                Exibe_Item(lst_Produto);

                ID_Grade = 0;
                txt_Quantidade.Text = "1,000";

                txt_Cod_Barra.Clear();
            }
            #endregion

            #region ADICIONA PRODUTO VALOR ALTERADO
            if (ValorAlterado == true)
            {
                DataTable _DT = new DataTable();
                _DT = BLL_Produto.Busca_Estoque(Produto);
                _DT_Produto = BLL_Produto.Busca_Valor(Produto);

                if (_DT == null)
                {
                    MessageBox.Show("Estoque não cadastrado!");
                    return;
                }

                int TipoProduto = Convert.ToInt32(_DT.Rows[0]["Tipo"]);

                if (_DT.Rows.Count == 1 ||
                    ID_Grade > 0)
                {
                    ID_Grade = Convert.ToInt32(_DT.Rows[0]["ID_Grade"]);

                    if (Convert.ToString(_DT.Rows[0]["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
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

                    lst_Grade = new List<DTO_Produto_Item>();
                    lst_Grade = frm.lst_Produto;

                    if (lst_Grade == null)
                    {
                        MessageBox.Show("Selecione uma Grade!");
                        return;
                    }

                    ID_Grade = lst_Grade[0].ID_Grade;
                    DescricaoGrade = " - " + lst_Grade[0].DescricaoGrade;

                    if (Altera_Consulta_Grade == true)
                        Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Quantidade;
                }

                if (ID_Grade > 0)
                    Produto.ID_Grade = ID_Grade;

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

                if (Parametro_Venda.Agrupar_Produto == true)
                    for (int i = 0; i <= lst_Produto.Count - 1; i++)
                        if (lst_Produto[i].ID_Produto == Convert.ToInt32(_DT.Rows[0]["ID_Produto"]) &&
                           lst_Produto[i].ID_Grade == ID_Grade)
                        {
                            lst_Produto[i].Quantidade = lst_Produto[i].Quantidade + Convert.ToDouble(txt_Quantidade.Text);
                            Exibe_Item(lst_Produto);

                            ID_Grade = 0;
                            txt_Quantidade.Text = "1,000";
                            txt_Cod_Barra.Clear();
                            txt_Cod_Barra.Focus();
                            return;
                        }

                if (lst_Produto == null)
                    lst_Produto = new List<DTO_Produto_Item>();

                BLL_Venda = new BLL_Venda();
                Produto_Item = new DTO_Produto_Item();

                Produto_Item.ID_Produto = Convert.ToInt32(_DT.Rows[0]["ID_Produto"]);
                Produto_Item.Quantidade = Convert.ToDouble(txt_Quantidade.Text);
                Produto_Item.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;
                Produto_Item.ValorCusto = Convert.ToDouble(_DT_Produto.Rows[0]["CustoFinal"]);
                Produto_Item.ValorProduto = Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"]);
                Produto_Item.Acrescimo = 0;

                #region VERIFICA DESCONTO DE ATACADO
                double _Qtd_aux = Convert.ToDouble(txt_Quantidade.Text);

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                {
                    if (lst_Produto[i].ID_Produto == Convert.ToInt32(_DT.Rows[0]["ID_Produto"]))
                        _Qtd_aux += lst_Produto[i].Quantidade;
                }

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID = Convert.ToInt32(_DT.Rows[0]["ID_Produto"]);
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.Quantidade = _Qtd_aux;
                Produto.Consulta_Quantidade = true;

                DataTable _DT_aux = new DataTable();
                _DT_aux = BLL_Produto.Busca_Desconto(Produto);

                if (_DT_aux.Rows.Count > 0)
                {
                    double ValorVenda = Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"]);
                    double ValorFinal = Convert.ToDouble(txt_ValorFinal.Text);

                    if (ValorVenda > ValorFinal)
                    {
                        Produto_Item.Desconto = ValorVenda - ValorFinal;
                        Produto_Item.ValorVenda = ValorFinal;
                    }
                    else
                    {
                        Produto_Item.Desconto = 0;
                        Produto_Item.ValorVenda = ValorFinal;
                    }
                }
                else
                {
                    double ValorVenda = Convert.ToDouble(_DT_Produto.Rows[0]["ValorVenda"]);
                    double ValorFinal = Convert.ToDouble(txt_ValorFinal.Text);

                    if (ValorVenda > ValorFinal)
                    {
                        Produto_Item.Desconto = ValorVenda - ValorFinal;
                        Produto_Item.ValorVenda = ValorFinal;
                    }
                    else
                    {
                        Produto_Item.Acrescimo = ValorFinal - ValorVenda;
                        Produto_Item.ValorVenda = ValorFinal;
                    }
                }
                #endregion

                if (DescricaoGrade != "ÚNICO")
                    Produto_Item.Descricao_Produto = _DT_Produto.Rows[0]["Descricao"].ToString() + DescricaoGrade;
                else
                    Produto_Item.Descricao_Produto = _DT_Produto.Rows[0]["Descricao"].ToString();

                Produto_Item.Descricao_Saida = "VENDA";
                Produto_Item.TipoSaida = 0;
                Produto_Item.ID_Grade = ID_Grade;

                //VALIDA INFORMAÇÕES
                if (!BLL_Venda.Grava_Item(Produto_Item))
                    return;

                //ADICIONA A LISTA
                lst_Produto.Add(Produto_Item);

                Exibe_Item(lst_Produto);

                ID_Grade = 0;
                txt_Quantidade.Text = "1,000";

                txt_Cod_Barra.Clear();
            }
            #endregion
        }

        private void Remove_Produto(int _indexGrid)
        {
            try
            {
                if (dg_Itens.Rows.Count == 0)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (util_dados.Verifica_int(txt_ID.Text) > 0 &&
                    lst_Produto[_indexGrid].ID > 0)
                {
                    BLL_Venda = new BLL_Venda();
                    Venda = new DTO_Venda();
                    Produto_Item = new DTO_Produto_Item();
                    List<DTO_Produto_Item> _Item = new List<DTO_Produto_Item>();

                    Produto_Item.ID = lst_Produto[_indexGrid].ID;
                    Produto_Item.ID_Produto = lst_Produto[_indexGrid].ID_Produto;
                    Produto_Item.ID_Grade = lst_Produto[_indexGrid].ID_Grade;

                    _Item.Add(Produto_Item);

                    Venda.Item = _Item;

                    BLL_Venda.Exclui_Item(Venda);
                }
                else
                {
                    lst_Produto.RemoveAt(_indexGrid);

                    Exibe_Item(lst_Produto);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.TipoPessoa = 1;
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;

            if (Parametro_Usuario.Venda_Restrita == true)
                UI_Pessoa_Consulta.Usuario_Restrito = true;

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = UI_Pessoa_Consulta.ID_Pessoa;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();

            _DT = BLL_Pessoa.Busca(Pessoa);

            if (_DT.Rows.Count > 0)
            {
                txt_CNPJ_CPF.Text = _DT.Rows[0]["CNPJ_CPF"].ToString();

                if (txt_CNPJ_CPF.Text.Length == 11)
                    txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CPF);
                else if (txt_CNPJ_CPF.Text.Length == 14)
                    txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CNPJ);

                txt_ID_Pessoa.Text = _DT.Rows[0]["ID_Pessoa"].ToString();
                txt_DescricaoPessoa.Text = _DT.Rows[0]["Descricao"].ToString();
            }
            else
            {
                txt_ID_Pessoa.Text = "0";
                txt_DescricaoPessoa.Text = "CONSUMIDOR FINAL";
            }

            txt_Cod_Barra.Focus();
        }

        private void Consulta_Produto()
        {
            ID_Grade = 0;

            UI_Produto_Consulta frm = new UI_Produto_Consulta();
            frm.ID_Tabela = Parametro_Venda.ID_TabelaVendaPadrao;

            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;

            if (Parametro_Venda.Altera_ValorPDV == false)
                Adiciona_Produto(frm.ID_Produto.ToString());
            else
            {
                txt_Cod_Barra.Text = frm.ID_Produto.ToString();
                Pesquisa_Produto(frm.ID_Produto.ToString());
            }
        }

        private void Grava_Venda()
        {
            try
            {
                #region GRAVA VENDA
                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.Item = lst_Produto;

                Venda.ID = util_dados.Verifica_int(txt_ID.Text);
                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.TipoPessoa = 1;
                Venda.ID_Pessoa = Convert.ToInt32(txt_ID_Pessoa.Text);
                Venda.Data = DateTime.Now;
                Venda.Entrega = DateTime.Now;
                Venda.DataFatura = DateTime.Now;

                Venda.Informacao = "PDV";

                if (cb_ID_UsuarioComissao1.SelectedValue != null)
                    Venda.ID_UsuarioComissao1 = util_dados.Verifica_int(cb_ID_UsuarioComissao1.SelectedValue.ToString());
                else
                    Venda.ID_UsuarioComissao1 = 0;

                Venda.Comprador = string.Empty;
                Venda.NFe = false;
                Venda.Faturado = true;
                Venda.ID_Pagamento = 0;
                Venda.ID_Parcelamento = 0;
                Venda.CPF_CNPJ = txt_CNPJ_CPF.Text;

                obj = BLL_Venda.Grava(Venda);
                #endregion

                if (obj > 0)
                {
                    Venda.ID = obj;
                    txt_ID.Text = Venda.ID.ToString();
                    ID_UltimoVenda = Venda.ID;
                }
                else
                {
                    MessageBox.Show(util_msg.msg_VendaConcluida, this.Text);
                    return;
                }

                #region LANÇA FINANCEIRO VENDA
                UI_Venda_Lanca frm = new UI_Venda_Lanca();

                frm.Documento = txt_ID.Text;
                frm.TipoPessoa = 1;
                frm.ID_Pessoa = Convert.ToInt32(txt_ID_Pessoa.Text);
                frm.Descricao_Pessoa = txt_DescricaoPessoa.Text;
                frm.Valor = Convert.ToDouble(txt_ValorPedido.Text);
                frm.Emissao = DateTime.Now;
                frm.ID_Pagamento = 0;
                frm.ID_Parcelamento = 0;
                frm.Finaliza_Venda = true;

                frm.ShowDialog();

                if (frm.Concluido == false)
                    return;
                #endregion

                #region ALTERA SITUAÇÃO PEDIDO
                Venda.Faturado = true;
                Venda.DataFatura = DateTime.Now;

                BLL_Venda.Altera_Fatura(Venda);
                #endregion

                #region BAIXA DE ESTOQUE
                DataTable _DT = new DataTable();
                _DT = BLL_Venda.Busca_Item(Venda);

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();
                Produto_Estoque = new DTO_Produto_Estoque();
                Produto.Estoque = new List<DTO_Produto_Estoque>();

                Produto_Item = new DTO_Produto_Item();

                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

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

                if (Parametro_NFe_NFC_SAT.TipoEquipamentoSAT > 0 &&
                    Parametro_Sistema.Terminal_CFe == true)
                {
                    UI_CFe UI_CFe = new UI_CFe();

                    if (Parametro_Venda.CFe_PDV_Cartao == true &&
                        frm.Pagto_Cartao == true)
                    {
                        UI_CFe.ID_Venda = Convert.ToInt32(txt_ID.Text);
                        UI_CFe.CNPJ_CPF_Destinatario = txt_CNPJ_CPF.Text;
                        UI_CFe.ShowDialog();
                    }

                    if (Parametro_Venda.CFe_PDV_Cartao == false)
                    {
                        UI_CFe.ID_Venda = Convert.ToInt32(txt_ID.Text);
                        UI_CFe.CNPJ_CPF_Destinatario = txt_CNPJ_CPF.Text;
                        UI_CFe.ShowDialog();
                    }

                    if (UI_CFe.Concluido == false)
                        Imprime(util_dados.Verifica_int(txt_ID.Text));
                }
                else
                    Imprime(util_dados.Verifica_int(txt_ID.Text));

                Limpa_Campos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Imprime(int ID_Venda)
        {
            if (ID_Venda == 0)
            {
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                return;
            }

            LocalReport rpt = new LocalReport();

            string rpt_Nome = string.Empty;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = ID_Venda;

            DataTable DTR_Venda = BLL_Venda.Busca_Relatorio(Venda);
            DataTable DTR_ItemPedido = BLL_Venda.Busca_Item(Venda);
            DataTable DTR_Financeiro = BLL_Venda.Busca_Financeiro(Venda);

            string Financeiro = string.Empty;
            string TipoPagto = string.Empty;

            if (DTR_Financeiro.Rows.Count > 0)
            {
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
            }
            else
                Financeiro = string.Empty;

            if (DTR_ItemPedido.Rows.Count <= 11 &&
                Parametro_Venda.Permitir2Vias == true &&
                Parametro_Venda.TipoImpressoraTermica == 0)
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

            if (Parametro_Venda.TipoImpressoraTermica == 1)
                rpt_Nome = "rpt_Venda_Termica.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(txt_ID_Pessoa.Text);
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
            ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda_Pedido", DTR_Venda);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item_Pedido", DTR_ItemPedido);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
            ReportParameter p2 = new ReportParameter("TotalPedido", util_dados.ConfigNumDecimal(txt_ValorPedido.Text, 3));
            ReportParameter p3 = new ReportParameter("Vendedor", "");

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pedido);
            rpt.DataSources.Add(ds_ItemPedido);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.DataSources.Add(ds_Endereco);
            rpt.DataSources.Add(ds_Telefone);
            rpt.DataSources.Add(ds_Email);

            rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
            rpt.Refresh();
            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);

                if (Parametro_Venda.TipoImpressoraTermica == 1)
                    imp.Imprimir(documento, Tipo_Impressao.Termica);
                else
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                imp = null;
            }
        }

        private void Cancela_Venda()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_CANC, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
            {
                Limpa_Campos();
            }
        }

        private void Busca_Item(int _ID)
        {
            if (_ID == 0)
                return;

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
                Exibe_Item(lst_Produto);
            else
                dg_Itens.Rows.Clear();
        }

        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                if (sender is UpDownBase)
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                else if (sender is TextBoxBase)
                    ((TextBoxBase)sender).SelectAll();
            });
        }

        private void DelegateEnterFocus(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is TextBoxBase))
            {
                ctrl.Enter += SelectText_Enter;
                return;
            }

            foreach (Control ctrlChild in ctrl.Controls)
                this.DelegateEnterFocus(ctrlChild);
        }

        private void ResumoVenda()
        {
            try
            {
                UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();


                string rpt_Nome = "rpt_Venda_ResumoSimples.rdlc";

                if (Parametro_Venda.TipoImpressoraTermica == 1)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaImpressaoA4, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        rpt_Nome = "rpt_Venda_ResumoSimples_Termica.rdlc";
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT_Empresa = new DataTable();
                _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                /* if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
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
                 }*/

                /*if (Convert.ToInt32(cb_NFe.SelectedValue) > 0)
                {
                    Venda.Pesquisa_EmitidoNFe = true;
                    if (Convert.ToInt32(cb_NFe.SelectedValue) == 1)
                        Venda.NFe = true;
                    else
                        Venda.NFe = false;
                }
                */

                /*switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        Venda.Consulta_Emissao.Filtra = true;
                        Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;

                    case "FATURAMENTO":
                        Venda.Consulta_Fatura.Filtra = true;
                        Venda.Consulta_Fatura.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Fatura.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                }*/

                Venda.Consulta_Fatura.Filtra = true;
                Venda.Consulta_Fatura.Inicial = DateTime.Now;
                Venda.Consulta_Fatura.Final = DateTime.Now;

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalVenda;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;

                DataTable _DT_Venda = new DataTable();

                _DT_Venda = BLL_Venda.Busca_TotalVenda(Venda);
                int aux_cont = 0;
                int aux_ID = 0;
                for (int i = 0; i <= _DT_Venda.Rows.Count - 1; i++)
                {
                    int aux = int.Parse(_DT_Venda.Rows[i]["ID_Venda"].ToString());

                    if (aux == aux_ID)
                    {
                        if (aux_cont > 0)
                        {
                            _DT_Venda.Rows[i]["ID_Venda"] = DBNull.Value;
                            _DT_Venda.Rows[i]["Data"] = DBNull.Value;
                            _DT_Venda.Rows[i]["Descricao"] = DBNull.Value;
                            _DT_Venda.Rows[i]["DescricaoUsuarioComissao1"] = DBNull.Value;
                            _DT_Venda.Rows[i]["DescricaoUsuarioComissao2"] = DBNull.Value;
                            _DT_Venda.Rows[i]["ValorTotal"] = DBNull.Value;
                            _DT_Venda.Rows[i]["CustoTotal"] = DBNull.Value;
                            _DT_Venda.Rows[i]["Faturado"] = DBNull.Value;
                        }
                        else
                            aux_cont = aux_cont + 1;
                    }
                    else
                    {
                        aux_ID = int.Parse(_DT_Venda.Rows[i]["ID_Venda"].ToString());
                        aux_cont = aux_cont + 1;
                    }
                }

                ds_Empresa = new ReportDataSource("Emitente", _DT_Empresa);
                ds_TotalVenda = new ReportDataSource("ResumoVenda", _DT_Venda);

                p1 = new ReportParameter("Periodo", DateTime.Now.ToShortDateString() + " À " + DateTime.Now.ToShortDateString());
                p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_TotalVenda);

                rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

                rpt.rpt_Viewer.RefreshReport();

                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_PDV_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            try
            {
                #region LOGO RELATÓRIO
                BLL_Imagem = new BLL_Imagem();
                Imagem = new DTO_Imagem();
                Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Imagem.Tipo = 1;

                DataTable _DT = new DataTable();

                _DT = BLL_Imagem.Busca(Imagem);
                byte[] bits = (byte[])(_DT.Rows[0][0]);

                MemoryStream memorybits = new MemoryStream(bits);
                Bitmap ImagemConvertida = new Bitmap(memorybits);


                #endregion

                #region LOGO EMPRESA
                Imagem = new DTO_Imagem();
                Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Imagem.Tipo = 2;

                _DT = new DataTable();

                _DT = BLL_Imagem.Busca(Imagem);

                bits = (byte[])(_DT.Rows[0][0]);
                memorybits = new MemoryStream(bits);
                ImagemConvertida = new Bitmap(memorybits);
                pBox_Imagen_Principal.Image = ImagemConvertida;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
            this.DelegateEnterFocus(this);
            lbl_desconto.Visible = false;
            txt_Desconto.Visible = false;

        }

        private void UI_PDV_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1) //FINALIZA VENDA
                Grava_Venda();

            if(e.KeyCode == Keys.F2)
                ResumoVenda();

            if (e.KeyCode == Keys.F3) //CAMPO DESCONTO
            {
                if (Convert.ToDecimal(txt_ValorPedido.Text) > 0)
                {
                    txt_Cod_Barra.Visible = false;
                    lbl_desconto.Visible = true;
                    txt_Desconto.Visible = true;
                    txt_Desconto.Focus();
                }

            }

            if (e.KeyCode == Keys.F5) //PESQUISA PRODUTO
                Consulta_Produto();

            if (e.KeyCode == Keys.F6) //IMPRIME ULTIMA VENDA
                Imprime(ID_UltimoVenda);

            if (e.KeyCode == Keys.F7) //PESQUISA CLIENTE
                Consulta_Pessoa();

            if (e.KeyCode == Keys.Delete) //REMOVE PRODUTO
                try
                {
                    Remove_Produto(Convert.ToInt32(txt_Cod_Barra.Text) - 1);

                }
                catch (Exception)
                {

                 
                }
                

            if (e.KeyCode == Keys.F9) //FINALIZA VENDA
                Cancela_Venda();

            if (e.KeyCode == Keys.F10)
            {
                UI.UI_PDV_MENU a = new UI_PDV_MENU();
                a.ShowDialog();
            }

            if (e.KeyCode == Keys.F12) //FECHAR
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_FecharPDV, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.Yes)
                    this.Close();
            }
        }

        private void UI_PDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) &&
                txt_Cod_Barra.Focused != true)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            //if (txt_CNPJ_CPF.Focused == true)
            //{
            //    short KeyAscii = (short)e.KeyChar;
            //    KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
            //    if (KeyAscii == 0)
            //        e.Handled = true;
            //}

            if (txt_Cod_Barra.Focused == true)
            {

                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0 ||
                    KeyAscii == 13)
                    e.Handled = true;
            }

            if (txt_Desconto.Focused == true)
            {

                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimalPorcentagem(KeyAscii));
                if (KeyAscii == 0 ||
                    KeyAscii == 13)
                    e.Handled = true;
            }
        }
        #endregion

        #region BUTTON
        private void bt_Sair_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_FecharPDV, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                this.Close();
        }

        private void bt_PesquisaPessoa_Click(object sender, EventArgs e)
        {
            Consulta_Pessoa();
        }

        private void bt_PesquisaProduto_Click(object sender, EventArgs e)
        {
            Consulta_Produto();
        }

        private void bt_RemoverItem_Click(object sender, EventArgs e)
        {
            Remove_Produto(dg_Itens.CurrentRow.Index);
        }

        private void bt_Encerrar_Click(object sender, EventArgs e)
        {
            Grava_Venda();
        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            Cancela_Venda();
        }

        private void bt_Imprimir_Click(object sender, EventArgs e)
        {
            Imprime(ID_UltimoVenda);
        }

        private void bt_ResumoVenda_Click(object sender, EventArgs e)
        {
            ResumoVenda();
        }

        private void bt_AddProduto_Click(object sender, EventArgs e)
        {
            Adiciona_Produto(txt_Cod_Barra.Text, true);

            txt_Cod_Barra.Focus();
        }
        #endregion

        #region TIMER
        private void DataHora_Tick(object sender, EventArgs e)
        {
            lb_Data.Text = DateTime.Now.ToShortDateString();
            lb_Horario.Text = DateTime.Now.ToLongTimeString();
            txt_Cod_Barra.Focus();
        }
        #endregion

        #region TEXTBOX
        private void txt_Cod_Barra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space ||
            e.KeyCode == Keys.Multiply) //PESQUISA PRODUTO
            {
                if (util_dados.Verifica_Double(txt_Cod_Barra.Text.Replace("*", "")) > 0)
                    txt_Quantidade.Text = util_dados.ConfigNumDecimal(txt_Cod_Barra.Text, 3);

                txt_Cod_Barra.Text = string.Empty;
                txt_Cod_Barra.Focus();
            }

            if (e.KeyCode == Keys.Enter) //PESQUISA PRODUTO
            {
                Adiciona_Produto(txt_Cod_Barra.Text);
                txt_Cod_Barra.Focus();
            }
        }

        private void txt_Cod_Barra_Leave(object sender, EventArgs e)
        {
            Pesquisa_Produto(txt_Cod_Barra.Text);
        }

        private void txt_CNPJ_CPF_Leave(object sender, EventArgs e)
        {
            if (txt_CNPJ_CPF.Text != string.Empty)
            {
                if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPF.Text) == false)
                {
                    MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                    txt_CNPJ_CPF.Text = "";
                    txt_ID_Pessoa.Text = "";
                    txt_DescricaoPessoa.Text = "";
                    //txt_CNPJ_CPF.Focus();
                    return;
                }

                if (txt_CNPJ_CPF.Text.Length == 11)
                    txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CPF);
                else if (txt_CNPJ_CPF.Text.Length == 14)
                    txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CNPJ);

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = 1;
                Pessoa.CNPJ_CPF = txt_CNPJ_CPF.Text;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca(Pessoa);

                if (_DT.Rows.Count > 0)
                {
                    txt_ID_Pessoa.Text = _DT.Rows[0]["ID_Pessoa"].ToString();
                    txt_DescricaoPessoa.Text = _DT.Rows[0]["Descricao"].ToString();
                }
                else
                {
                    txt_ID_Pessoa.Text = Parametro_Venda.ID_ConsumidorFinal.ToString();
                    txt_DescricaoPessoa.Text = "CONSUMIDOR FINAL";
                }
            }
            else
            {
                txt_ID_Pessoa.Text = Parametro_Venda.ID_ConsumidorFinal.ToString();
                txt_DescricaoPessoa.Text = "CONSUMIDOR FINAL";
            }

        }

        private void txt_Desconto_Leave(object sender, EventArgs e)
        {
            if (Parametro_Usuario.Libera_Desconto == false &&
              util_dados.Verifica_Double(txt_Desconto.Text.ToUpper().Replace("%", "").Replace("P", "")) > 0)
            {
                UI_Senha_Supervidor UI_Senha_Supervidor = new UI_Senha_Supervidor();
                UI_Senha_Supervidor.DescricaoLiberacao = "LIBERAÇÃO DE DESCONTO";
                UI_Senha_Supervidor.Tipo = 1;
                UI_Senha_Supervidor.ShowDialog();

                if (UI_Senha_Supervidor.Liberado == false)
                    txt_Desconto.Text = "0,00";
            }

            if (txt_Desconto.Text.IndexOf('%') != -1 ||
                txt_Desconto.Text.ToUpper().IndexOf("P") != -1)
            {
                double Desconto = 0;
                double Porc_Desconto = util_dados.Verifica_Double(util_dados.ConfigNumDecimal(txt_Desconto.Text.ToUpper().Replace("%", "").Replace("P", ""), 2));

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                {
                    double aux = lst_Produto[i].ValorProduto * (Porc_Desconto / 100);

                    lst_Produto[i].Desconto = aux;
                    lst_Produto[i].ValorVenda = (lst_Produto[i].ValorProduto + lst_Produto[i].Acrescimo) - lst_Produto[i].Desconto;
                    lst_Produto[i].ValorTotal = lst_Produto[i].Quantidade * lst_Produto[i].ValorVenda;

                    Desconto += lst_Produto[i].Quantidade * lst_Produto[i].Desconto;
                }

                txt_Desconto.Text = util_dados.ConfigNumDecimal(Desconto, 2);

            }
            else
            {
                double TotalVenda = 0;
                double TotalVenda_Temp = 0;
                double Porc_Desconto = 0;
                double Desconto = Convert.ToDouble(txt_Desconto.Text);

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                    TotalVenda += lst_Produto[i].Quantidade * (lst_Produto[i].ValorProduto + lst_Produto[i].Acrescimo);

                Porc_Desconto = (Desconto / TotalVenda) * 100;

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                {
                    double aux = util_dados.Verifica_Double(util_dados.ConfigNumDecimal(lst_Produto[i].ValorProduto * (Convert.ToDouble(Porc_Desconto) / 100), 2));

                    lst_Produto[i].Desconto = aux;
                    lst_Produto[i].ValorVenda = (lst_Produto[i].ValorProduto + lst_Produto[i].Acrescimo) - lst_Produto[i].Desconto;
                    lst_Produto[i].ValorTotal = lst_Produto[i].Quantidade * lst_Produto[i].ValorVenda;
                }

                for (int i = 0; i <= lst_Produto.Count - 1; i++)
                    TotalVenda_Temp += Convert.ToDouble(util_dados.ConfigNumDecimal(lst_Produto[i].ValorTotal, 2));

                double Diferenca = Convert.ToDouble(util_dados.ConfigNumDecimal(TotalVenda - TotalVenda_Temp, 2));

                if (Diferenca != Desconto)
                {
                    if (Diferenca > Desconto)
                    {
                        Diferenca = Convert.ToDouble(util_dados.ConfigNumDecimal(Diferenca - Desconto, 2));
                        lst_Produto[0].Desconto = lst_Produto[0].Desconto - (Diferenca);
                    }
                    else
                    {
                        
                        Diferenca = Convert.ToDouble(util_dados.ConfigNumDecimal(Desconto - Diferenca, 2));
                        lst_Produto[0].Desconto = lst_Produto[0].Desconto + (Diferenca);
                    }

                    lst_Produto[0].ValorVenda = (lst_Produto[0].ValorProduto + lst_Produto[0].Acrescimo) - lst_Produto[0].Desconto;
                    lst_Produto[0].ValorTotal = lst_Produto[0].Quantidade * lst_Produto[0].ValorVenda;
                }
                txt_Desconto.Text = util_dados.ConfigNumDecimal(Desconto, 2);
            }

            Exibe_Item(lst_Produto);


            txt_Cod_Barra.Visible = true;
            lbl_desconto.Visible = false;
            txt_Desconto.Visible = false;
            txt_Cod_Barra.Focus();
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Busca_Item(util_dados.Verifica_int(txt_ID.Text));
        }
        #endregion

        private void txt_Quantidade_Leave(object sender, EventArgs e)
        {
            txt_Quantidade.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Quantidade.Text), 3);

            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Quantidade.Text) * util_dados.Verifica_Double(txt_ValorFinal.Text), 2);
        }

        private void txt_ValorFinal_Leave(object sender, EventArgs e)
        {
            txt_ValorFinal.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_ValorFinal.Text), 2);

            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Quantidade.Text) * util_dados.Verifica_Double(txt_ValorFinal.Text), 2);

        }

        private void txt_Quantidade_TextChanged(object sender, EventArgs e)
        {
            txt_Quantidade2.Text = txt_Quantidade.Text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cb_ID_UsuarioComissao1_TextChanged(object sender, EventArgs e)
        {
            lbl_ID_UsuarioComissao1.Text = cb_ID_UsuarioComissao1.Text;
        }
    }
}
