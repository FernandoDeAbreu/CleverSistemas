using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.BLL;

namespace Sistema.UI
{
    public partial class UI_Produto_Servico : Sistema.UI.UI_Modelo
    {
        public UI_Produto_Servico()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        BLL_GrupoNivel BLL_GrupoNivel;
        BLL_Grade BLL_Grade;
        BLL_TabelaValor BLL_TabelaValor;
        BLL_Pessoa BLL_Pessoa;
        BLL_Imposto BLL_Imposto;
        BLL_Produto BLL_Produto;
        BLL_Produto_Entrada BLL_Produto_Entrada;
        BLL_NCM BLL_NCM;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;

        int obj;

        string CaminhoImagem;
        string Conta;

        DataTable DT;

        DateTime ValidaData;

        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_GrupoNivel GrupoNivel;
        DTO_Grade Grade;
        DTO_TabelaValor TabelaValor;
        DTO_Pessoa Pessoa;
        DTO_Imposto Imposto;
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Comissao Comissao;
        DTO_Produto_Valor Valor;
        DTO_Produto PRODUTO_ESTRUTURA;
        DTO_Produto_Entrada Produto_Entrada;
        DTO_NCM NCM;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE PRODUTOS";
            mk_UltimoReajuste.Text = DateTime.Now.ToString();

            switch (Parametro_Venda.Produto_PrecoVenda)
            {
                case Composicao_PrecoVenda.Custo_Final:
                    lb_TipoValorVenda.Text = util_msg.msg_ValorVenda_CustoFinal;
                    break;

                case Composicao_PrecoVenda.Preco_Compra:
                    lb_TipoValorVenda.Text = util_msg.msg_ValorVenda_ValorCompra;
                    break;
            }

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            dg_Fornecedor.AutoGenerateColumns = false;
            dg_TabelaValor.AutoGenerateColumns = false;
            dg_Comissao.AutoGenerateColumns = false;
            dg_Estoque.AutoGenerateColumns = false;
            dg_Estrutura.AutoGenerateColumns = false;

            PRODUTO_ESTRUTURA = new DTO_Produto();

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "DESCRIÇÃO";
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Referencia = new DataGridViewTextBoxColumn();
            col_Referencia.DataPropertyName = "Referencia";
            col_Referencia.Width = 150;
            col_Referencia.HeaderText = "REFERÊNCIA";
            DG.Columns.Add(col_Referencia);

            DataGridViewTextBoxColumn col_Fabricante = new DataGridViewTextBoxColumn();
            col_Fabricante.DataPropertyName = "Fabricante";
            col_Fabricante.Width = 150;
            col_Fabricante.HeaderText = "FABRICANTE";
            DG.Columns.Add(col_Fabricante);

            lb_InfoAdicional1.Text = Parametro_CadastroPersonalizado.Info_Produto1;
            lb_InfoAdicionalP.Text = Parametro_CadastroPersonalizado.Info_Produto1;

            lb_InfoAdicional2.Text = Parametro_CadastroPersonalizado.Info_Produto2;

            cb_ABC.SelectedIndex = 0;

            CarregaCB();
            Busca_UsuarioComissao();
        }

        private void CarregaCB()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            DataTable _DT = new DataTable();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Unidade);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_UnidadeTributavel);

            _DT = new DataTable();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Grade);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_GrupoGrade);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = 3;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Pessoa.FiltraSituacao = true;
            Pessoa.Situacao = true;

            _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID_Fornecedor", cb_ID_ProdutoFornecedor);

            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();

            _DT = new DataTable();
            _DT = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Tabela);

            BLL_Imposto = new BLL_Imposto();
            Imposto = new DTO_Imposto();
            Imposto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            _DT = new DataTable();
            _DT = BLL_Imposto.Busca(Imposto);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Imposto);
            cb_ID_Imposto.SelectedIndex = -1;

            List<string> _aux = new List<string>();
            _aux.Add("VALOR");
            _aux.Add("PORCENTAGEM");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, _aux), "Descricao", "ID", cb_ID_TipoComissao);

            _aux = new List<string>();
            _aux.Add("PRODUTO VENDA");
            _aux.Add("PRODUTO LOCAÇÃO");
            _aux.Add("MATÉRIA-PRIMA");
            _aux.Add("SERVIÇO");
            _aux.Add("KIT");
            _aux.Add("IMOBILIZADO / USO PRÓPRIO");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, _aux), "Descricao", "ID", cb_Tipo);

            _aux = new List<string>();
            _aux.Add("TODOS");
            _aux.Add("PRODUTO VENDA");
            _aux.Add("PRODUTO LOCAÇÃO");
            _aux.Add("MATÉRIA-PRIMA");
            _aux.Add("SERVIÇO");
            _aux.Add("KIT");
            _aux.Add("IMOBILIZADO / USO PRÓPRIO");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, _aux), "Descricao", "ID", cb_TipoP);

            _aux = new List<string>();
            _aux.Add("TODOS");
            _aux.Add("ATIVOS");
            _aux.Add("INATIVOS");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, _aux), "Descricao", "ID", cb_Situacao);

            Busca_Produto_Estrutura();
            Carrega_EstoquePadrao();
        }

        private void Busca_Produto_Estrutura()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 2";
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();

            _DT = BLL_Produto.Busca(Produto);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_ProdutoEstrutura);
        }

        private void Busca_UsuarioComissao()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca_Comissao(Produto);

            if (_DT.Rows.Count > 0)
            {
                PRODUTO_ESTRUTURA.Comissao = new List<DTO_Comissao>();

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    DTO_Comissao _Comissao = new DTO_Comissao();
                    _Comissao.ID_Usuario = Convert.ToInt32(_DT.Rows[i]["ID_Usuario"]);
                    _Comissao.DescricaoUsuario = _DT.Rows[i]["Usuario"].ToString();
                    _Comissao.ID_TipoComissao = 0;
                    _Comissao.Comissao = 0;

                    PRODUTO_ESTRUTURA.Comissao.Add(_Comissao);
                }
            }

            Exibe_Comissao();
        }

        private void CalculaValores()
        {
            try
            {
                double vlr_CustoFinal_old = Convert.ToDouble(txt_CustoFinal.Text);

                double Vlr_Compra = Convert.ToDouble(txt_ValorCompra.Text);
                double Vlr_OutrosCustos = Convert.ToDouble(txt_OutrosCustos.Text);
                double Vlr_IPI = Convert.ToDouble(txt_ValorIPI.Text);
                double Vlr_ST = Convert.ToDouble(txt_ValorST.Text);

                double Vlr_CustoFinal = Vlr_Compra + Vlr_OutrosCustos + Vlr_IPI + Vlr_ST;

                txt_CustoFinal.Text = util_dados.ConfigNumDecimal(Vlr_CustoFinal, 2);

                if (vlr_CustoFinal_old != double.Parse(util_dados.ConfigNumDecimal(Vlr_CustoFinal, 2)) &&
                    util_dados.Verifica_int(txt_ID.Text) > 0)
                    MessageBox.Show(util_msg.msg_AtualizeValorVenda, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void CarregaGrupo()
        {
            BLL_GrupoNivel = new BLL_GrupoNivel();
            GrupoNivel = new DTO_GrupoNivel();

            DataTable _DT = new DataTable();

            int Nivel = util_dados.VerificaNivel(mk_Cod_Grupo.Text);

            Conta = util_dados.ConsultaCodigoPai(mk_Cod_Grupo.Text, Nivel);
            //Nivel 1

            if (Conta.Length == 2)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Cod_Grupo.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                    if (i == _DT.Rows.Count - 1)
                        txt_ID_Grupo.Text = _DT.Rows[i]["ID"].ToString();
                }
                txt_DescricaoGrupo.Text = Descricao;

                if (_DT.Rows.Count == 0)
                {
                    txt_ID_Grupo.Text = string.Empty;
                    txt_DescricaoGrupo.Text = string.Empty;
                    return;
                }
                return;
            }
            //Nivel 2
            if (Conta.Length == 4)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Cod_Grupo.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 1)
                {
                    txt_ID_Grupo.Text = string.Empty;
                    txt_DescricaoGrupo.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Grupo.Text = _DT.Rows[i]["ID"].ToString();
                    }

                    txt_DescricaoGrupo.Text = Descricao;
                }
                return;
            }
            //Nivel 3
            if (Conta.Length == 6)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Cod_Grupo.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 2)
                {
                    txt_ID_Grupo.Text = string.Empty;
                    txt_DescricaoGrupo.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Grupo.Text = _DT.Rows[i]["ID"].ToString();
                    }
                    txt_DescricaoGrupo.Text = Descricao;
                }
                return;
            }
            //Nivel 4
            if (Conta.Length == 8)
            {
                GrupoNivel.Nivel = Nivel;
                GrupoNivel.CodigoPai = util_dados.ConsultaCodigoPai(mk_Cod_Grupo.Text, Nivel);

                _DT = BLL_GrupoNivel.Busca(GrupoNivel);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 3)
                {
                    txt_ID_Grupo.Text = string.Empty;
                    txt_DescricaoGrupo.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Grupo.Text = _DT.Rows[i]["ID"].ToString();
                    }
                    txt_DescricaoGrupo.Text = Descricao;
                }
                return;
            }
        }

        private void Carrega_Produto(int ID)
        {
            try
            {
                if (ID == 0)
                    return;

                PRODUTO_ESTRUTURA = new DTO_Produto();

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID = ID;
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                #region VALOR
                DataTable _DT = new DataTable();
                _DT = BLL_Produto.Busca_TabelaValor(Produto);

                PRODUTO_ESTRUTURA.Valor = new List<DTO_Produto_Valor>();

                if (_DT.Rows.Count > 0)
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        DTO_Produto_Valor _aux = new DTO_Produto_Valor();

                        _aux.DescricaoTabela = _DT.Rows[i]["Descricao"].ToString();
                        _aux.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _aux.ID_Tabela = Convert.ToInt32(_DT.Rows[i]["ID_Tabela"]);
                        _aux.UltimoReajuste = Convert.ToDateTime(_DT.Rows[i]["UltimoReajuste"]);
                        _aux.MargemVenda = Convert.ToDouble(_DT.Rows[i]["MargemVenda"]);
                        _aux.ValorVenda = Convert.ToDouble(_DT.Rows[i]["ValorVenda"]);

                        PRODUTO_ESTRUTURA.Valor.Add(_aux);
                    }

                Exibe_Valor();
                #endregion

                #region COMISSÃO
                _DT = new DataTable();
                _DT = BLL_Produto.Busca_Comissao(Produto);

                PRODUTO_ESTRUTURA.Comissao = new List<DTO_Comissao>();

                if (_DT.Rows.Count > 0)
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        DTO_Comissao _aux = new DTO_Comissao();

                        _aux.ID = util_dados.Verifica_int(_DT.Rows[i]["ID"].ToString());
                        _aux.ID_Usuario = Convert.ToInt32(_DT.Rows[i]["ID_Usuario"]);
                        _aux.ID_TipoComissao = util_dados.Verifica_int(_DT.Rows[i]["ID_TipoComissao"].ToString());
                        _aux.Comissao = util_dados.Verifica_Double(_DT.Rows[i]["Comissao"].ToString());
                        _aux.DescricaoComissao = _DT.Rows[i]["TipoComissao"].ToString();
                        _aux.DescricaoUsuario = _DT.Rows[i]["Usuario"].ToString();

                        PRODUTO_ESTRUTURA.Comissao.Add(_aux);
                    }

                Exibe_Comissao();
                #endregion

                #region FORNECEDOR
                _DT = new DataTable();
                _DT = BLL_Produto.Busca_Fornecedor(Produto);

                PRODUTO_ESTRUTURA.Fornecedor = new List<DTO_Produto_Fornecedor>();

                if (_DT.Rows.Count > 0)
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        DTO_Produto_Fornecedor _aux = new DTO_Produto_Fornecedor();

                        _aux.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _aux.ID_Fornecedor = Convert.ToInt32(_DT.Rows[i]["ID_Fornecedor"]);
                        _aux.DescricaoFornecedor = _DT.Rows[i]["Descricao"].ToString();
                        _aux.Codigo_Produto = _DT.Rows[i]["Codigo_Produto"].ToString();

                        PRODUTO_ESTRUTURA.Fornecedor.Add(_aux);
                    }

                Exibe_Fornecedor();
                #endregion

                #region ESTOQUE
                _DT = new DataTable();
                _DT = BLL_Produto.Busca_Estoque(Produto);

                PRODUTO_ESTRUTURA.Estoque = new List<DTO_Produto_Estoque>();

                if (_DT != null &&
                    _DT.Rows.Count > 0)
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        DTO_Produto_Estoque _aux = new DTO_Produto_Estoque();

                        _aux.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _aux.ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID_Grade"]);
                        _aux.Cod_Interno = _DT.Rows[i]["Cod_Interno"].ToString();
                        _aux.Estoque_Minimo = Convert.ToDouble(_DT.Rows[i]["EstoqueMinimo"]);
                        _aux.Estoque_Ideal = Convert.ToDouble(_DT.Rows[i]["EstoqueIdeal"]);
                        _aux.Estoque_Atual = Convert.ToDouble(_DT.Rows[i]["EstoqueAtual"]);
                        _aux.Localizacao = _DT.Rows[i]["Localizacao"].ToString();
                        _aux.DescricaoGrade = _DT.Rows[i]["DescricaoGrade"].ToString();

                        PRODUTO_ESTRUTURA.Estoque.Add(_aux);
                    }

                Exibe_Estoque();
                #endregion

                #region FISCAL
                _DT = new DataTable();
                _DT = BLL_Produto.Busca(Produto);

                PRODUTO_ESTRUTURA.EX_TIPI = _DT.Rows[0]["EX_TIPI"].ToString();
                PRODUTO_ESTRUTURA.CNPJProdutor = _DT.Rows[0]["CNPJProdutor"].ToString();
                PRODUTO_ESTRUTURA.ClasseEnquadramento = _DT.Rows[0]["ClasseEnquadramento"].ToString();
                PRODUTO_ESTRUTURA.Cod_ANP = Convert.ToInt32(_DT.Rows[0]["Cod_ANP"]);
                PRODUTO_ESTRUTURA.ProdutoEspecifico = Convert.ToBoolean(_DT.Rows[0]["ProdutoEspecifico"]);
                PRODUTO_ESTRUTURA.Barra = _DT.Rows[0]["Barra"].ToString();
                PRODUTO_ESTRUTURA.BarraTributavel = _DT.Rows[0]["BarraTributavel"].ToString();
                PRODUTO_ESTRUTURA.ID_Imposto = util_dados.Verifica_int(_DT.Rows[0]["ID_Imposto"].ToString());
                PRODUTO_ESTRUTURA.NCM = _DT.Rows[0]["NCM"].ToString();
                PRODUTO_ESTRUTURA.Controle_Estoque = Convert.ToBoolean(_DT.Rows[0]["Controle_Estoque"]);
                PRODUTO_ESTRUTURA.InfoAdicional1 = _DT.Rows[0]["InfoAdicional1"].ToString();
                PRODUTO_ESTRUTURA.InfoAdicional2 = _DT.Rows[0]["InfoAdicional2"].ToString();
                PRODUTO_ESTRUTURA.ABC = _DT.Rows[0]["ABC"].ToString();
                PRODUTO_ESTRUTURA.ID_CEST = util_dados.Verifica_int(_DT.Rows[0]["ID_CEST"].ToString());
                Exibe_Fiscal();
                Consulta_CEST(util_dados.Verifica_int(_DT.Rows[0]["ID_CEST"].ToString()));
                #endregion

                #region ESTRUTURA
                _DT = new DataTable();
                _DT = BLL_Produto.Busca_Estrutura(Produto);

                PRODUTO_ESTRUTURA.Estrutura = new List<DTO_Produto_Estrutura>();

                if (_DT.Rows.Count > 0)
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        DTO_Produto_Estrutura _aux = new DTO_Produto_Estrutura();

                        _aux.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        _aux.ID_Produto_Estrutura = Convert.ToInt32(_DT.Rows[i]["ID_Produto_Estrutura"]);
                        _aux.ID_Grade_Estrutura = Convert.ToInt32(_DT.Rows[i]["ID_Grade_Estrutura"]);
                        _aux.Quantidade = Convert.ToDouble(_DT.Rows[i]["Quantidade"]);
                        _aux.DescricaoProduto = _DT.Rows[i]["Descricao"].ToString();

                        PRODUTO_ESTRUTURA.Estrutura.Add(_aux);
                    }

                Exibe_Estrutura();
                #endregion

                #region IMAGEM
                CaminhoImagem = null;

                _DT = new DataTable();
                _DT = BLL_Produto.Busca_Imagem(Produto);
                try
                {
                    byte[] bits = (byte[])(_DT.Rows[0][0]);
                    MemoryStream memorybits = new MemoryStream(bits);
                    Bitmap ImagemConvertida = new Bitmap(memorybits);
                    Imagem.Image = ImagemConvertida;
                }
                catch (Exception)
                {
                    Imagem.Image = null;
                }
                #endregion              
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Grava_Estoque()
        {
            for (int i = 0; i <= dg_Estoque.Rows.Count - 1; i++)
            {
                PRODUTO_ESTRUTURA.Estoque[i].Estoque_Atual = Convert.ToDouble(dg_Estoque.Rows[i].Cells["col_EstoqueAtual"].Value);
                PRODUTO_ESTRUTURA.Estoque[i].Estoque_Ideal = Convert.ToDouble(dg_Estoque.Rows[i].Cells["col_EstoqueIdeal"].Value);
                PRODUTO_ESTRUTURA.Estoque[i].Estoque_Minimo = Convert.ToDouble(dg_Estoque.Rows[i].Cells["col_EstoqueMinimo"].Value);
                PRODUTO_ESTRUTURA.Estoque[i].Localizacao = dg_Estoque.Rows[i].Cells["col_Localizacao"].Value.ToString();
            }
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

        private void Carrega_EstoquePadrao()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            DataTable _DT = new DataTable();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Grade);
            _DT = BLL_Grupo.Busca(Grupo);

            int _ID_Grade = 0;

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                if (_DT.Rows[i]["Descricao"].ToString().IndexOf("ÚNICO") != -1)
                    _ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID"]);

            PRODUTO_ESTRUTURA.Estoque = new List<DTO_Produto_Estoque>();

            if (_ID_Grade == 0)
                return;

            BLL_Grade = new BLL_Grade();
            Grade = new DTO_Grade();

            Grade.ID_Grupo = _ID_Grade;

            _DT = new DataTable();
            _DT = BLL_Grade.Busca(Grade);

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                DTO_Produto_Estoque _ProdutoEstoque = new DTO_Produto_Estoque();
                _ProdutoEstoque.DescricaoGrade = _DT.Rows[i]["Descricao"].ToString();
                _ProdutoEstoque.ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID"]);
                _ProdutoEstoque.Cod_Interno = "- - - -" + _DT.Rows[i]["ID"].ToString().PadLeft(2, '0') + Parametro_Empresa.ID_Empresa_Ativa.ToString().PadLeft(2, '0');
                _ProdutoEstoque.Estoque_Minimo = 0;
                _ProdutoEstoque.Estoque_Ideal = 0;
                _ProdutoEstoque.Estoque_Atual = 0;

                PRODUTO_ESTRUTURA.Estoque.Add(_ProdutoEstoque);
            }

            Exibe_Estoque();
        }

        private void Limpa_Campos()
        {
            txt_ValorCompra.Text = "0,00";
            txt_OutrosCustos.Text = "0,00";
            txt_ValorIPI.Text = "0,00";
            txt_ValorST.Text = "0,00";
            txt_CustoFinal.Text = "0,00";
            txt_MargemVenda.Text = "0,00";
            txt_ValorVenda.Text = "0,00";
            txt_Validade.Text = "0";
            txt_Garantia.Text = "0";
            txt_PesoB.Text = "0,000";
            txt_PesoL.Text = "0,000";
            txt_QtEstrutura.Text = "0,000";
            txt_EX_TIPI.Text = "0";
            mk_UltimoReajuste.Text = DateTime.Now.ToString();

            cb_ID_Tabela.SelectedIndex = 0;
            cb_ID_TipoComissao.SelectedIndex = 0;
            cb_ID_GrupoGrade.SelectedIndex = 0;
            cb_Tipo.SelectedIndex = 0;
            cb_UnidadeTributavel.SelectedIndex = 0;

            dg_TabelaValor.Rows.Clear();
            dg_Comissao.Rows.Clear();
            dg_Fornecedor.Rows.Clear();
            dg_Estoque.Rows.Clear();
            dg_Estrutura.Rows.Clear();

            ck_Ativo.Checked = true;
            ck_Controle_Estoque.Checked = true;

            Imagem.Image = null;
            Imagem.ImageLocation = null;

            cb_ABC.SelectedIndex = 0;

            Busca_Produto_Estrutura();
            Busca_UsuarioComissao();
            Carrega_EstoquePadrao();

            tabctl.SelectedTab = TabPage1;
            tabControl1.SelectedTab = tabPage6;
        }

        private void Exibe_Fornecedor()
        {
            dg_Fornecedor.Rows.Clear();

            for (int i = 0; i <= PRODUTO_ESTRUTURA.Fornecedor.Count - 1; i++)
            {
                dg_Fornecedor.Rows.Add();
                dg_Fornecedor.Rows[i].Cells["col_Descricao_Fornecedor"].Value = PRODUTO_ESTRUTURA.Fornecedor[i].DescricaoFornecedor;
                dg_Fornecedor.Rows[i].Cells["col_CodigoProduto"].Value = PRODUTO_ESTRUTURA.Fornecedor[i].Codigo_Produto;
            }
        }

        private void Exibe_Comissao()
        {
            dg_Comissao.Rows.Clear();

            if (PRODUTO_ESTRUTURA.Comissao.Count > 0)
                for (int i = 0; i <= PRODUTO_ESTRUTURA.Comissao.Count - 1; i++)
                {
                    dg_Comissao.Rows.Add();
                    dg_Comissao.Rows[i].Cells["col_Comissao"].Value = PRODUTO_ESTRUTURA.Comissao[i].Comissao;
                    dg_Comissao.Rows[i].Cells["col_TipoComissao"].Value = PRODUTO_ESTRUTURA.Comissao[i].DescricaoComissao;
                    dg_Comissao.Rows[i].Cells["col_Descricao_Usuario"].Value = PRODUTO_ESTRUTURA.Comissao[i].DescricaoUsuario;
                }
        }

        private void Exibe_Valor()
        {
            dg_TabelaValor.Rows.Clear();

            txt_MargemVenda.Text = "0,00";
            txt_ValorVenda.Text = "0,00";

            for (int i = 0; i <= PRODUTO_ESTRUTURA.Valor.Count - 1; i++)
            {
                dg_TabelaValor.Rows.Add();
                dg_TabelaValor.Rows[i].Cells["col_DescricaoTabela"].Value = PRODUTO_ESTRUTURA.Valor[i].DescricaoTabela;
                dg_TabelaValor.Rows[i].Cells["col_MargemVenda"].Value = PRODUTO_ESTRUTURA.Valor[i].MargemVenda;
                dg_TabelaValor.Rows[i].Cells["col_ValorVenda"].Value = PRODUTO_ESTRUTURA.Valor[i].ValorVenda;
                dg_TabelaValor.Rows[i].Cells["col_UltimoReajuste"].Value = PRODUTO_ESTRUTURA.Valor[i].UltimoReajuste;
            }
        }

        private void Exibe_Estoque()
        {
            dg_Estoque.Rows.Clear();

            for (int i = 0; i <= PRODUTO_ESTRUTURA.Estoque.Count - 1; i++)
            {
                dg_Estoque.Rows.Add();
                dg_Estoque.Rows[i].Cells["col_DescricaoGrade"].Value = PRODUTO_ESTRUTURA.Estoque[i].DescricaoGrade;
                dg_Estoque.Rows[i].Cells["col_Cod_Interno"].Value = PRODUTO_ESTRUTURA.Estoque[i].Cod_Interno;
                dg_Estoque.Rows[i].Cells["col_EstoqueMinimo"].Value = PRODUTO_ESTRUTURA.Estoque[i].Estoque_Minimo;
                dg_Estoque.Rows[i].Cells["col_EstoqueIdeal"].Value = PRODUTO_ESTRUTURA.Estoque[i].Estoque_Ideal;
                dg_Estoque.Rows[i].Cells["col_EstoqueAtual"].Value = PRODUTO_ESTRUTURA.Estoque[i].Estoque_Atual;
                dg_Estoque.Rows[i].Cells["col_Localizacao"].Value = PRODUTO_ESTRUTURA.Estoque[i].Localizacao;
            }
        }

        private void Exibe_Estrutura()
        {
            dg_Estrutura.Rows.Clear();

            for (int i = 0; i <= PRODUTO_ESTRUTURA.Estrutura.Count - 1; i++)
            {
                dg_Estrutura.Rows.Add();
                dg_Estrutura.Rows[i].Cells["col_ProdutoEstrutura"].Value = PRODUTO_ESTRUTURA.Estrutura[i].DescricaoProduto;
                dg_Estrutura.Rows[i].Cells["col_Qt_Estrutura"].Value = PRODUTO_ESTRUTURA.Estrutura[i].Quantidade;

            }
        }

        private void Exibe_Fiscal()
        {
            util_dados.LimpaCampos(this, gb_Fiscal_Fornecedor);

            txt_EX_TIPI.Text = PRODUTO_ESTRUTURA.EX_TIPI;
            txt_CNPJProdutor.Text = PRODUTO_ESTRUTURA.CNPJProdutor;
            txt_ClasseEnquadramento.Text = PRODUTO_ESTRUTURA.ClasseEnquadramento;

            ck_ProdutoEspecifico.Checked = PRODUTO_ESTRUTURA.ProdutoEspecifico;
            txt_Cod_ANP.Text = PRODUTO_ESTRUTURA.Cod_ANP.ToString();

            txt_Barra.Text = PRODUTO_ESTRUTURA.Barra;
            txt_BarraTributavel.Text = PRODUTO_ESTRUTURA.BarraTributavel;
            cb_ID_Imposto.SelectedValue = Convert.ToInt32(PRODUTO_ESTRUTURA.ID_Imposto);
            txt_NCM.Text = PRODUTO_ESTRUTURA.NCM;
            ck_Controle_Estoque.Checked = PRODUTO_ESTRUTURA.Controle_Estoque;

            txt_InfoAdicional1.Text = PRODUTO_ESTRUTURA.InfoAdicional1;
            txt_InfoAdicional2.Text = PRODUTO_ESTRUTURA.InfoAdicional2;
            cb_ABC.Text = PRODUTO_ESTRUTURA.ABC;
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = 3;

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            if (UI_Pessoa_Consulta.TipoPessoa != 3)
                return;

            cb_ID_ProdutoFornecedor.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_ProdutoFornecedor.Focus();
        }

        private void Consulta_Produto()
        {
            UI_Produto_Consulta frm = new UI_Produto_Consulta();
            frm.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;

            if (tabctl.SelectedTab == TabPage2)
            {
                txt_DescricaoP.Text = frm.Descricao;

                Pesquisa();
            }

            if (tabControl1.SelectedTab == tabPage7)
                cb_ID_ProdutoEstrutura.SelectedValue = frm.ID_Produto;
        }

        private void Consulta_CEST(int ID_CEST = 0)
        {
            try
            {
                BLL_NCM = new BLL_NCM();
                NCM = new DTO_NCM();

                DataTable _DT = new DataTable();
                DataTable _DT_CEST = new DataTable();

                _DT_CEST.Columns.Add("ID", typeof(int));
                _DT_CEST.Columns.Add("Descricao", typeof(string));

                NCM.NCM = txt_NCM.Text;

                _DT = BLL_NCM.Busca_CEST(NCM);

                if (_DT.Rows.Count == 0)
                {
                    _DT_CEST.Rows.Add();
                    _DT_CEST.Rows[0]["ID"] = 0;
                    _DT_CEST.Rows[0]["Descricao"] = "NÃO SE APLICA";

                    util_dados.CarregaCombo(_DT_CEST, "Descricao", "ID", cb_ID_CEST);
                }
                else
                    util_dados.CarregaCombo(_DT, "DescricaoCompleta", "ID", cb_ID_CEST);

                if (ID_CEST > 0 &&
                    _DT.Rows.Count >= 0)
                    cb_ID_CEST.SelectedValue = ID_CEST;
                else
                    cb_ID_CEST.SelectedValue = 0;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Produto = new BLL_Produto();

                if (PRODUTO_ESTRUTURA == null)
                    PRODUTO_ESTRUTURA = new DTO_Produto();

                Grava_Estoque();
                PRODUTO_ESTRUTURA.lst_ID_Empresa = Busca_lst_Empresa();
                PRODUTO_ESTRUTURA.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                PRODUTO_ESTRUTURA.Ativo = Convert.ToBoolean(ck_Ativo.Checked);
                PRODUTO_ESTRUTURA.ID = util_dados.Verifica_int(txt_ID.Text);
                PRODUTO_ESTRUTURA.ID_Grupo = util_dados.Verifica_int(txt_ID_Grupo.Text);
                PRODUTO_ESTRUTURA.Tipo = cb_Tipo.SelectedValue.ToString();
                PRODUTO_ESTRUTURA.Descricao = txt_Descricao.Text;
                PRODUTO_ESTRUTURA.Referencia = txt_Referencia.Text;
                PRODUTO_ESTRUTURA.Fabricante = txt_Fabricante.Text;
                PRODUTO_ESTRUTURA.Informacao = txt_Informacao.Text;
                PRODUTO_ESTRUTURA.ValorCompra = Convert.ToDouble(txt_ValorCompra.Text);
                PRODUTO_ESTRUTURA.OutrosCustos = Convert.ToDouble(txt_OutrosCustos.Text);
                PRODUTO_ESTRUTURA.ValorIPI = Convert.ToDouble(txt_ValorIPI.Text);
                PRODUTO_ESTRUTURA.ValorST = Convert.ToDouble(txt_ValorST.Text);
                PRODUTO_ESTRUTURA.CustoFinal = Convert.ToDouble(txt_CustoFinal.Text);
                PRODUTO_ESTRUTURA.UnidadeTributavel = Convert.ToInt32(cb_UnidadeTributavel.SelectedValue);
                PRODUTO_ESTRUTURA.Validade = util_dados.Verifica_int(txt_Validade.Text);
                PRODUTO_ESTRUTURA.Garantia = Convert.ToInt32(txt_Garantia.Text);
                PRODUTO_ESTRUTURA.PesoB = Convert.ToDouble(txt_PesoB.Text);
                PRODUTO_ESTRUTURA.PesoL = Convert.ToDouble(txt_PesoL.Text);

                PRODUTO_ESTRUTURA.EX_TIPI = txt_EX_TIPI.Text;
                PRODUTO_ESTRUTURA.CNPJProdutor = txt_CNPJProdutor.Text;
                PRODUTO_ESTRUTURA.ClasseEnquadramento = txt_ClasseEnquadramento.Text;
                PRODUTO_ESTRUTURA.Cod_ANP = util_dados.Verifica_int(txt_Cod_ANP.Text);
                PRODUTO_ESTRUTURA.ProdutoEspecifico = Convert.ToBoolean(ck_ProdutoEspecifico.Checked);
                PRODUTO_ESTRUTURA.Barra = txt_Barra.Text;
                PRODUTO_ESTRUTURA.BarraTributavel = txt_BarraTributavel.Text;
                PRODUTO_ESTRUTURA.ID_Imposto = Convert.ToInt32(cb_ID_Imposto.SelectedValue);
                PRODUTO_ESTRUTURA.NCM = txt_NCM.Text;
                PRODUTO_ESTRUTURA.ID_CEST = Convert.ToInt32(cb_ID_CEST.SelectedValue);
                PRODUTO_ESTRUTURA.Controle_Estoque = ck_Controle_Estoque.Checked;

                PRODUTO_ESTRUTURA.InfoAdicional1 = txt_InfoAdicional1.Text;
                PRODUTO_ESTRUTURA.InfoAdicional2 = txt_InfoAdicional2.Text;

                PRODUTO_ESTRUTURA.ABC = cb_ABC.Text;

                PRODUTO_ESTRUTURA.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                PRODUTO_ESTRUTURA.lst_ID_Empresa = Busca_lst_Empresa();

                #region CARREGA IMAGEM
                if (Imagem.Image != null &&
                    CaminhoImagem != null)
                {
                    FileStream _Imagem = default(FileStream);
                    StreamReader ConfigImagem = default(StreamReader);
                    _Imagem = new FileStream(CaminhoImagem, FileMode.Open, FileAccess.Read, FileShare.Read);
                    ConfigImagem = new StreamReader(_Imagem);
                    byte[] arqByteArray = new byte[_Imagem.Length];
                    _Imagem.Read(arqByteArray, 0, Convert.ToInt32(_Imagem.Length));

                    PRODUTO_ESTRUTURA.Imagem = _Imagem;
                    PRODUTO_ESTRUTURA.ArqByteArray = arqByteArray;
                }
                #endregion

                obj = BLL_Produto.Grava(PRODUTO_ESTRUTURA);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Pesquisa()
        {
            try
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
                Produto.InfoAdicional1 = txt_InfoAdicional1P.Text;

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
                _DT = BLL_Produto.Busca(Produto);

                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                util_dados.CarregaCampo(this, _DT, gb_Valor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            PRODUTO_ESTRUTURA = new DTO_Produto();

            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Valor);
            util_dados.LimpaCampos(this, gb_Fiscal_Fornecedor);
            util_dados.LimpaCampos(this, gb_InfoProduto);
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Produto.Exclui(Produto);

                Pesquisa();

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region MASKEDBOX
        private void mk_Cod_Grupo_TextChanged(object sender, EventArgs e)
        {
            CarregaGrupo();
        }

        private void mk_UltimoReajuste_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_UltimoReajuste.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_UltimoReajuste.Text = Convert.ToString(DateTime.Now);
                mk_UltimoReajuste.Focus();
            }
        }
        #endregion

        #region FORM
        private void UI_Produto_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_ValorCompra.Focused == true ||
                txt_OutrosCustos.Focused == true ||
                txt_CustoFinal.Focused == true ||
                txt_MargemVenda.Focused == true ||
                txt_ValorVenda.Focused == true ||
                txt_ValorCompra.Focused == true ||
                txt_OutrosCustos.Focused == true ||
                txt_PesoB.Focused == true ||
                txt_PesoL.Focused == true ||
                txt_QtEstrutura.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Barra.Focused == true ||
                txt_BarraP.Focused == true ||
                txt_BarraTributavel.Focused == true ||
                txt_Validade.Focused == true ||
                txt_Garantia.Focused == true ||
                txt_NCM.Focused == true ||
                txt_EX_TIPI.Focused == true ||
                txt_Cod_ANP.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F7 &&
                tabctl.SelectedTab == TabPage1 &&
                tabControl1.SelectedTab == tabPage3)
                Consulta_Pessoa();

            if (e.KeyCode == Keys.F10)
                if (tabctl.SelectedTab == TabPage2 ||
                    tabControl1.SelectedTab == tabPage7)
                    Consulta_Produto();
        }
        #endregion

        #region BUTTON
        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Limpa_Campos();
        }

        private void bt_adicionaFornecedor_Click(object sender, EventArgs e)
        {
            if (PRODUTO_ESTRUTURA.Fornecedor == null)
                PRODUTO_ESTRUTURA.Fornecedor = new List<DTO_Produto_Fornecedor>();

            if (util_dados.Verifica_int(cb_ID_ProdutoFornecedor.SelectedValue.ToString()) == 0)
                return;

            for (int i = 0; i <= PRODUTO_ESTRUTURA.Fornecedor.Count - 1; i++)
                if (PRODUTO_ESTRUTURA.Fornecedor[i].ID_Fornecedor == Convert.ToInt32(cb_ID_ProdutoFornecedor.SelectedValue))
                {
                    MessageBox.Show(util_msg.msg_FornecedorProduto, this.Text);
                    return;
                }

            DTO_Produto_Fornecedor Fornecedor = new DTO_Produto_Fornecedor();

            Fornecedor.ID_Fornecedor = Convert.ToInt32(cb_ID_ProdutoFornecedor.SelectedValue);
            Fornecedor.DescricaoFornecedor = cb_ID_ProdutoFornecedor.Text;
            Fornecedor.Codigo_Produto = string.Empty;

            PRODUTO_ESTRUTURA.Fornecedor.Add(Fornecedor);

            Exibe_Fornecedor();
        }

        private void bt_ExcluiFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_Fornecedor.Rows.Count == 0)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (PRODUTO_ESTRUTURA.Fornecedor[dg_Fornecedor.CurrentRow.Index].ID > 0)
                {
                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();
                    Produto.Fornecedor = new List<DTO_Produto_Fornecedor>();

                    DTO_Produto_Fornecedor Fornecedor = new DTO_Produto_Fornecedor();

                    Fornecedor.ID = PRODUTO_ESTRUTURA.Fornecedor[dg_Fornecedor.CurrentRow.Index].ID;

                    Produto.Fornecedor.Add(Fornecedor);

                    BLL_Produto.Exclui_Fornecedor(Produto);
                }

                PRODUTO_ESTRUTURA.Fornecedor.RemoveAt(dg_Fornecedor.CurrentRow.Index);
                Exibe_Fornecedor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_GrupoNivel_Consulta frm = new UI_GrupoNivel_Consulta();
            frm.ShowDialog();
            mk_Cod_Grupo.Text = frm.Cod_Conta;
        }

        private void bt_adicionaComissao_Click(object sender, EventArgs e)
        {
            PRODUTO_ESTRUTURA.Comissao[dg_Comissao.CurrentRow.Index].DescricaoComissao = cb_ID_TipoComissao.Text;
            PRODUTO_ESTRUTURA.Comissao[dg_Comissao.CurrentRow.Index].ID_TipoComissao = Convert.ToInt32(cb_ID_TipoComissao.SelectedValue);
            PRODUTO_ESTRUTURA.Comissao[dg_Comissao.CurrentRow.Index].Comissao = Convert.ToDouble(txt_Comissao.Text);

            Exibe_Comissao();
        }

        private void bt_AdicionaComissaoTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dg_Comissao.Rows.Count - 1; i++)
            {

                PRODUTO_ESTRUTURA.Comissao[i].DescricaoComissao = cb_ID_TipoComissao.Text;
                PRODUTO_ESTRUTURA.Comissao[i].ID_TipoComissao = Convert.ToInt32(cb_ID_TipoComissao.SelectedValue);
                PRODUTO_ESTRUTURA.Comissao[i].Comissao = Convert.ToDouble(txt_Comissao.Text);
            }

            Exibe_Comissao();
        }

        private void bt_AdicionaGrade_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_AlteraGrade, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            if (util_dados.Verifica_int(txt_ID.Text) > 0)
            {
                BLL_Produto = new BLL_Produto();
                DTO_Produto _aux = new DTO_Produto();

                _aux.ID = util_dados.Verifica_int(txt_ID.Text);
                _aux.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                BLL_Produto.Exclui_Estoque(_aux);
            }

            PRODUTO_ESTRUTURA.Estoque = new List<DTO_Produto_Estoque>();

            BLL_Grade = new BLL_Grade();
            Grade = new DTO_Grade();

            Grade.ID_Grupo = Convert.ToInt32(cb_ID_GrupoGrade.SelectedValue);

            DataTable _DT = new DataTable();
            _DT = BLL_Grade.Busca(Grade);

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                DTO_Produto_Estoque _ProdutoEstoque = new DTO_Produto_Estoque();
                _ProdutoEstoque.DescricaoGrade = _DT.Rows[i]["Descricao"].ToString();
                _ProdutoEstoque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                _ProdutoEstoque.ID_Grade = Convert.ToInt32(_DT.Rows[i]["ID"]);
                _ProdutoEstoque.Cod_Interno = "- - - -" + _DT.Rows[i]["ID"].ToString().PadLeft(2, '0') + Parametro_Empresa.ID_Empresa_Ativa.ToString().PadLeft(2, '0');
                _ProdutoEstoque.Estoque_Minimo = 0;
                _ProdutoEstoque.Estoque_Ideal = 0;
                _ProdutoEstoque.Estoque_Atual = 0;

                PRODUTO_ESTRUTURA.Estoque.Add(_ProdutoEstoque);
            }

            Exibe_Estoque();
        }

        private void bt_AdicionaTabelaValor_Click(object sender, EventArgs e)
        {
            if (PRODUTO_ESTRUTURA.Valor == null)
                PRODUTO_ESTRUTURA.Valor = new List<DTO_Produto_Valor>();

            DTO_Produto_Valor _aux = new DTO_Produto_Valor();

            bool _TabelaNova = false;

            for (int i = 0; i <= PRODUTO_ESTRUTURA.Valor.Count - 1; i++)
                if (PRODUTO_ESTRUTURA.Valor[i].ID_Tabela == Convert.ToInt32(cb_ID_Tabela.SelectedValue))
                {
                    PRODUTO_ESTRUTURA.Valor[i].MargemVenda = Convert.ToDouble(txt_MargemVenda.Text);
                    PRODUTO_ESTRUTURA.Valor[i].ValorVenda = Convert.ToDouble(txt_ValorVenda.Text);
                    PRODUTO_ESTRUTURA.Valor[i].UltimoReajuste = Convert.ToDateTime(mk_UltimoReajuste.Text);
                    _TabelaNova = true;
                }

            if (_TabelaNova == false)
            {
                _aux.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                _aux.DescricaoTabela = cb_ID_Tabela.Text;
                _aux.MargemVenda = Convert.ToDouble(txt_MargemVenda.Text);
                _aux.ValorVenda = Convert.ToDouble(txt_ValorVenda.Text);
                _aux.UltimoReajuste = Convert.ToDateTime(mk_UltimoReajuste.Text);

                PRODUTO_ESTRUTURA.Valor.Add(_aux);
            }

            Exibe_Valor();
        }

        private void bt_PesquisaImagem_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisaImagem.Filter = "Image Files (*.jpg)|*.jpg";
                if (PesquisaImagem.ShowDialog() == DialogResult.OK)
                {

                    FileInfo tamanho = new FileInfo(PesquisaImagem.FileName);
                    if (tamanho.Length > 1024000)
                    {
                        MessageBox.Show(util_msg.msg_ImagemGrande + (tamanho.Length / 1024) + " KB", this.Text);
                        return;
                    }

                    CaminhoImagem = PesquisaImagem.FileName;
                    Imagem.ImageLocation = CaminhoImagem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_Excluir_Imagem_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoImagem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                if (util_dados.Verifica_int(txt_ID.Text) > 0)
                {
                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();

                    Produto.ID = Convert.ToInt32(txt_ID.Text);

                    BLL_Produto.Exclui_Imagem(Produto);
                }
                Imagem.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_ADD_Estrutura_Click(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_QtEstrutura.Text) == 0)
            {
                MessageBox.Show(util_msg.msg_Quantidade_Invalida, this.Text);
                return;
            }

            if (Convert.ToInt32(cb_Tipo.SelectedValue) != 5)
            {
                MessageBox.Show(util_msg.msg_TipodeProdutoInvalidoKit, this.Text);
                return;
            }

            if (PRODUTO_ESTRUTURA.Estrutura == null)
                PRODUTO_ESTRUTURA.Estrutura = new List<DTO_Produto_Estrutura>();

            if (util_dados.Verifica_int(cb_ID_ProdutoEstrutura.SelectedValue.ToString()) == 0)
                return;

            bool _aux_Altera = false;

            for (int i = 0; i <= PRODUTO_ESTRUTURA.Estrutura.Count - 1; i++)
                if (PRODUTO_ESTRUTURA.Estrutura[i].ID_Produto_Estrutura == Convert.ToInt32(cb_ID_ProdutoEstrutura.SelectedValue))
                {
                    PRODUTO_ESTRUTURA.Estrutura[i].Quantidade = Convert.ToDouble(txt_QtEstrutura.Text);
                    _aux_Altera = true;
                }

            if (_aux_Altera == false)
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.ID = Convert.ToInt32(cb_ID_ProdutoEstrutura.SelectedValue);

                DataTable _DT = new DataTable();
                _DT = BLL_Produto.Busca_Estoque(Produto);

                if (_DT == null)
                {
                    MessageBox.Show(util_msg.msg_EstoqueNaoCadastrado, this.Text);
                    return;
                }

                int ID_Grade = 0;
                if (_DT.Rows.Count == 1)
                    ID_Grade = Convert.ToInt32(_DT.Rows[0]["ID_Grade"]);
                else
                {
                    MessageBox.Show(util_msg.msg_EstoqueInvalido, this.Text);
                    return;
                }

                DTO_Produto_Estrutura _aux = new DTO_Produto_Estrutura();

                _aux.ID_Produto_Estrutura = Convert.ToInt32(cb_ID_ProdutoEstrutura.SelectedValue);
                _aux.ID_Grade_Estrutura = ID_Grade;
                _aux.DescricaoProduto = cb_ID_ProdutoEstrutura.Text;
                _aux.Quantidade = Convert.ToDouble(txt_QtEstrutura.Text);

                PRODUTO_ESTRUTURA.Estrutura.Add(_aux);
            }

            txt_QtEstrutura.Text = "0,000";

            Exibe_Estrutura();
        }

        private void bt_Remove_Estrutura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_Estrutura.Rows.Count == 0)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (PRODUTO_ESTRUTURA.Estrutura[dg_Estrutura.CurrentRow.Index].ID > 0)
                {
                    BLL_Produto = new BLL_Produto();
                    Produto = new DTO_Produto();
                    Produto.Estrutura = new List<DTO_Produto_Estrutura>();

                    DTO_Produto_Estrutura _aux = new DTO_Produto_Estrutura();

                    _aux.ID = PRODUTO_ESTRUTURA.Estrutura[dg_Estrutura.CurrentRow.Index].ID;

                    Produto.Estrutura.Add(_aux);

                    BLL_Produto.Exclui_Estrutura(Produto);
                }

                PRODUTO_ESTRUTURA.Estrutura.RemoveAt(dg_Estrutura.CurrentRow.Index);
                Exibe_Estrutura();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

               private void bt_PesquisaGrupoP_Click(object sender, EventArgs e)
        {
            UI_GrupoNivel_Consulta frm = new UI_GrupoNivel_Consulta();
            frm.ShowDialog();
            mk_Cod_GrupoP.Text = frm.Cod_Conta;
        }

        private void bt_DuplicarCadastro_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaDuplicar, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            PRODUTO_ESTRUTURA.ID = 0;

            if (PRODUTO_ESTRUTURA.Fornecedor != null)
                for (int i = 0; i <= PRODUTO_ESTRUTURA.Fornecedor.Count - 1; i++)
                    PRODUTO_ESTRUTURA.Fornecedor[i].ID = 0;

            if (PRODUTO_ESTRUTURA.Valor != null)
                for (int i = 0; i <= PRODUTO_ESTRUTURA.Valor.Count - 1; i++)
                    PRODUTO_ESTRUTURA.Valor[i].ID = 0;

            if (PRODUTO_ESTRUTURA.Comissao != null)
                for (int i = 0; i <= PRODUTO_ESTRUTURA.Comissao.Count - 1; i++)
                    PRODUTO_ESTRUTURA.Comissao[i].ID = 0;

            if (PRODUTO_ESTRUTURA.Estoque != null)
                for (int i = 0; i <= PRODUTO_ESTRUTURA.Estoque.Count - 1; i++)
                {
                    PRODUTO_ESTRUTURA.Estoque[i].ID = 0;
                    PRODUTO_ESTRUTURA.Estoque[i].Estoque_Atual = 0;
                    PRODUTO_ESTRUTURA.Estoque[i].Localizacao = string.Empty;
                    Exibe_Estoque();
                }

            if (PRODUTO_ESTRUTURA.Estrutura != null)
                for (int i = 0; i <= PRODUTO_ESTRUTURA.Estrutura.Count - 1; i++)
                    PRODUTO_ESTRUTURA.Estrutura[i].ID = 0;

            txt_ID.Text = "";

            Status = StatusForm.Novo;
            Config_Botao();
        }
        #endregion

        #region TEXTBOX
        private void txt_MargemVenda_Leave(object sender, EventArgs e)
        {
            if (txt_MargemVenda.Text.Trim() == string.Empty)
                txt_MargemVenda.Text = "0";

            if (Convert.ToDouble(txt_MargemVenda.Text) < 0 || Convert.ToDouble(txt_MargemVenda.Text) > 99)
            {
                MessageBox.Show("Valor Inválido!\n0% ~ 99%");
                txt_MargemVenda.Text = "0";
            }

            txt_MargemVenda.Text = util_dados.ConfigNumDecimal(txt_MargemVenda.Text, 2);

            double Margem = Convert.ToDouble(txt_MargemVenda.Text);

            switch (Parametro_Venda.Produto_PrecoVenda)
            {
                case Composicao_PrecoVenda.Custo_Final:
                    double CustoFinal = util_dados.Verifica_Double(txt_ValorCompra.Text);
                    CustoFinal += util_dados.Verifica_Double(txt_ValorIPI.Text);
                    CustoFinal += util_dados.Verifica_Double(txt_ValorST.Text);
                    CustoFinal += util_dados.Verifica_Double(txt_OutrosCustos.Text);

                    txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(CustoFinal, Margem), 2);
                    break;

                case Composicao_PrecoVenda.Preco_Compra:
                    double ValorCompra = util_dados.Verifica_Double(txt_ValorCompra.Text);
                    double ValorIPI = util_dados.Verifica_Double(txt_ValorIPI.Text);
                    double ValorST = util_dados.Verifica_Double(txt_ValorST.Text);
                    double ValorOutrosCustos = util_dados.Verifica_Double(txt_OutrosCustos.Text);

                    txt_ValorVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaValor(ValorCompra, Margem) + ValorIPI + ValorST + ValorOutrosCustos, 2);
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
                    CustoFinal += util_dados.Verifica_Double(txt_OutrosCustos.Text);

                    txt_MargemVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(CustoFinal, Convert.ToDouble(txt_ValorVenda.Text)), 2);
                    break;

                case Composicao_PrecoVenda.Preco_Compra:
                    double ValorCompra = util_dados.Verifica_Double(txt_ValorCompra.Text);
                    double ValorIPI = util_dados.Verifica_Double(txt_ValorIPI.Text);
                    double ValorST = util_dados.Verifica_Double(txt_ValorST.Text);
                    double ValorOutrosCustos = util_dados.Verifica_Double(txt_OutrosCustos.Text);

                    txt_MargemVenda.Text = util_dados.ConfigNumDecimal(util_dados.CalculaMargem(ValorCompra, Convert.ToDouble(txt_ValorVenda.Text) - ValorIPI - ValorST - ValorOutrosCustos), 2);
                    break;
            }
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Carrega_Produto(util_dados.Verifica_int(txt_ID.Text));

            Status = StatusForm.Consulta;
            Config_Botao();
        }

        private void txt_Comissao_Leave(object sender, EventArgs e)
        {
            if (txt_Comissao.Text.Trim() == string.Empty)
                txt_Comissao.Text = "0";

            txt_Comissao.Text = util_dados.ConfigNumDecimal(txt_Comissao.Text, 2);
        }

        private void txt_ValorCompra_Leave(object sender, EventArgs e)
        {
            if (txt_ValorCompra.Text.Trim() == string.Empty)
                txt_ValorCompra.Text = "0";

            txt_ValorCompra.Text = util_dados.ConfigNumDecimal(txt_ValorCompra.Text, 2);

            CalculaValores();
        }

        private void txt_OutrosCustos_Leave(object sender, EventArgs e)
        {
            if (txt_OutrosCustos.Text.Trim() == string.Empty)
                txt_OutrosCustos.Text = "0";

            txt_OutrosCustos.Text = util_dados.ConfigNumDecimal(txt_OutrosCustos.Text, 2);

            CalculaValores();
        }

        private void txt_ValorIPI_Leave(object sender, EventArgs e)
        {
            if (txt_ValorIPI.Text.Trim() == string.Empty)
                txt_ValorIPI.Text = "0";

            txt_ValorIPI.Text = util_dados.ConfigNumDecimal(txt_ValorIPI.Text, 2);

            CalculaValores();
        }

        private void txt_ValorST_Leave(object sender, EventArgs e)
        {
            if (txt_ValorST.Text.Trim() == string.Empty)
                txt_ValorST.Text = "0";

            txt_ValorST.Text = util_dados.ConfigNumDecimal(txt_ValorST.Text, 2);

            CalculaValores();
        }

        private void txt_PesoB_Leave(object sender, EventArgs e)
        {
            if (txt_PesoB.Text.Trim() == string.Empty)
                txt_PesoB.Text = "0";

            txt_PesoB.Text = util_dados.ConfigNumDecimal(txt_PesoB.Text, 3);
        }

        private void txt_PesoL_Leave(object sender, EventArgs e)
        {
            if (txt_PesoL.Text.Trim() == string.Empty)
                txt_PesoL.Text = "0";

            txt_PesoL.Text = util_dados.ConfigNumDecimal(txt_PesoL.Text, 3);
        }

        private void txt_Referencia_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0 &&
                txt_Referencia.Text.Trim() != string.Empty)
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Produto.Consulta_Referencia = true;
                Produto.Referencia = txt_Referencia.Text;

                DataTable DT = BLL_Produto.Busca(Produto);

                if (DT.Rows.Count > 0)
                    MessageBox.Show(util_msg.msg_Produto_Cadastrado, this.Text);
            }
        }

        private void txt_QtEstrutura_Leave(object sender, EventArgs e)
        {
            if (txt_QtEstrutura.Text.Trim() == string.Empty)
                txt_QtEstrutura.Text = "0";

            txt_QtEstrutura.Text = util_dados.ConfigNumDecimal(txt_QtEstrutura.Text, 3);
        }

        private void txt_EX_TIPI_Leave(object sender, EventArgs e)
        {
            if (txt_EX_TIPI.Text.Trim() == string.Empty)
                txt_EX_TIPI.Text = "0";
        }

        private void txt_Barra_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0 &&
              txt_Barra.Text.Trim() != string.Empty)
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Produto.Barra = txt_Barra.Text;

                DataTable DT = BLL_Produto.Busca(Produto);

                if (DT.Rows.Count > 0)
                    MessageBox.Show(util_msg.msg_Produto_Cadastrado, this.Text);
            }
        }

        private void txt_BarraTributavel_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0 &&
              txt_BarraTributavel.Text.Trim() != string.Empty)
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Produto.Barra = txt_BarraTributavel.Text;

                DataTable DT = BLL_Produto.Busca(Produto);

                if (DT.Rows.Count > 0)
                    MessageBox.Show(util_msg.msg_Produto_Cadastrado, this.Text);
            }
        }

        private void txt_NCM_Leave(object sender, EventArgs e)
        {
            Consulta_CEST();
        }
        #endregion

        #region DATAGRID
        private void dg_Estoque_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueMinimo"].Value.ToString().Trim() != string.Empty)
                    dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueMinimo"].Value = util_dados.ConfigNumDecimal(dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueMinimo"].Value, 2);

            }
            catch (Exception)
            {
                dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueMinimo"].Value = 0;
            }

            try
            {
                if (dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueIdeal"].Value.ToString().Trim() != string.Empty)
                    dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueIdeal"].Value = util_dados.ConfigNumDecimal(dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueIdeal"].Value, 2);

            }
            catch (Exception)
            {
                dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueIdeal"].Value = 0;
            }

            try
            {
                if (dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueAtual"].Value.ToString().Trim() != string.Empty)
                    dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueAtual"].Value = util_dados.ConfigNumDecimal(dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueAtual"].Value, 2);
            }
            catch (Exception)
            {
                dg_Estoque.Rows[dg_Estoque.CurrentRow.Index].Cells["col_EstoqueAtual"].Value = 0;
            }
        }




        #endregion
    }
}
