using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;
using Sistema.NFe;

namespace Sistema.UI
{
    public partial class UI_Parametro : Sistema.UI.UI_Modelo
    {
        public UI_Parametro()
        {
            InitializeComponent();
        }

        #region PROPRIEDADES
        public Tipo_Parametro Tipo;
        #endregion

        #region VARIAVEIS DE CLASSE
        BLL_Parametro BLL_Parametro;
        BLL_Grupo BLL_Grupo;
        BLL_Usuario BLL_Usuario;
        BLL_PlanoConta BLL_PlanoConta;
        BLL_NF_TipoEmissao BLL_NF_TipoEmissao;
        BLL_Imagem BLL_Imagem;
        BLL_Pessoa BLL_Pessoa;
        BLL_TabelaValor BLL_TabelaValor;
        BLL_Pagamento BLL_Pagamento;
        #endregion

        #region ESTRUTURA
        DTO_Parametro Parametro;
        DTO_Grupo Grupo;
        DTO_Usuario Usuario;
        DTO_PlanoConta PlanoConta;
        DTO_NF_TipoEmissao NF_TipoEmissao;
        DTO_Imagem Imagem;
        DTO_Pessoa Pessoa;
        DTO_TabelaValor TabelaValor;
        DTO_CFe_SAT CFe_SAT;
        DTO_CFe_SAT_Retorno CFe_SAT_Retorno;
        DTO_Pagamento Pagamento;
        #endregion

        #region VARIAVEIS DIVERSAS
        string Conta;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PARÂMETROS DE SISTEMA";

            tabctl.SendToBack();

            bt_Novo.Visible = false;
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Edita.Visible = false;

            tabctl.TabPages.Remove(TabPage1);
            tabctl.TabPages.Remove(TabPage2);
            tabctl.TabPages.Remove(tabPage3);
            tabctl.TabPages.Remove(tabPage4);
            tabctl.TabPages.Remove(tabPage5);
            tabctl.TabPages.Remove(tabPage6);
            tabctl.TabPages.Remove(tabPage7);
            tabctl.TabPages.Remove(tabPage8);
            tabctl.TabPages.Remove(tabPage9);
            tabctl.TabPages.Remove(tabPage10);
            tabctl.TabPages.Remove(tabPage11);
            tabctl.TabPages.Remove(tabPage12);

            switch (Tipo)
            {
                case Tipo_Parametro.Financeiro:
                    tabctl.TabPages.Add(TabPage1);

                    Carrega_CB();
                    break;

                case Tipo_Parametro.Vendas:
                    tabctl.TabPages.Add(tabPage3);

                    Carrega_CB();
                    break;

                case Tipo_Parametro.Mobile:
                    tabctl.TabPages.Add(tabPage4);

                    break;

                case Tipo_Parametro.Usuario:
                    tabctl.TabPages.Add(tabPage5);

                    Carrega_Usuario();
                    break;

                case Tipo_Parametro.NFe_NFC_e:
                    tabctl.TabPages.Add(tabPage6);

                    Carrega_CB();
                    break;

                case Tipo_Parametro.Imagens:
                    tabctl.TabPages.Add(tabPage7);

                    Carrega_Imagem();
                    break;

                case Tipo_Parametro.SAT:
                    tabctl.TabPages.Add(tabPage8);

                    Carrega_CB();
                    break;

                case Tipo_Parametro.OrdemServico:
                    tabctl.TabPages.Add(tabPage9);
                    break;

                case Tipo_Parametro.Cadastro_Personalizado:
                    tabctl.TabPages.Add(tabPage10);
                    break;

                case Tipo_Parametro.Config_eMail:
                    tabctl.TabPages.Add(tabPage11);
                    break;

                case Tipo_Parametro.Parametro_Cadastro:
                    tabctl.TabPages.Add(tabPage12);

                    Carrega_CB();
                    break;
            }
        }

        private void Carrega_CB()
        {
            DataTable _DT;

            switch (Tipo)
            {
                #region VENDA
                case Tipo_Parametro.Vendas:
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.TipoPessoa = 1;

                    _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_ConsumidorFinal);

                    BLL_TabelaValor = new BLL_TabelaValor();
                    TabelaValor = new DTO_TabelaValor();

                    _DT = new DataTable();
                    _DT = BLL_TabelaValor.Busca(TabelaValor);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_TabelaVenda);

                    List<string> Grade = new List<string>();
                    Grade.Add("CONSULTA GRADE ÚNICO");
                    Grade.Add("CONSULTA GRADE QUANTIDADE");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Grade), "Descricao", "ID", cb_Consulta_Grade);

                    List<string> Imp_Termica = new List<string>();
                    Imp_Termica.Add("NENHUMA");
                    Imp_Termica.Add("PADRÃO 75/80cm");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, Imp_Termica), "Descricao", "ID", cb_TipoImpressoraTermica);

                    List<string> Imp_Matricial = new List<string>();
                    Imp_Matricial.Add("Modelo 1");
                    Imp_Matricial.Add("Modelo 2");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Imp_Matricial), "Descricao", "ID", cb_Modelo_Matricial);

                    List<string> Desconto_Padrao = new List<string>();
                    Desconto_Padrao.Add("VALOR");
                    Desconto_Padrao.Add("PORCENTAGEM");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Desconto_Padrao), "Descricao", "ID", cb_Desconto_Padrao);

                    List<string> Produto_PrecoVenda = new List<string>();
                    Produto_PrecoVenda.Add("MARGEM SOBRE CUSTO TOTAL");
                    Produto_PrecoVenda.Add("MARGEM SOBRE PREÇO DE VENDA + IPI + ST + OUTROS CUSTOS");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Produto_PrecoVenda), "Descricao", "ID", cb_Produto_PrecoVenda);

                    _DT = new DataTable();
                    BLL_Pagamento = new BLL_Pagamento();
                    Pagamento = new DTO_Pagamento();

                    Pagamento.FiltraPagamento = true;
                    Pagamento.Recebimento = true;

                    _DT = BLL_Pagamento.Busca(Pagamento);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_PagamentoTrocoDevolucao);
                    cb_PagamentoTrocoDevolucao.SelectedIndex = 0;
                    break;
                #endregion

                #region FINANCEIRO
                case Tipo_Parametro.Financeiro:
                    BLL_Grupo = new BLL_Grupo();
                    Grupo = new DTO_Grupo();
                    _DT = new DataTable();

                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Caixa_Principal);

                    BLL_Pagamento = new BLL_Pagamento();
                    Pagamento = new DTO_Pagamento();

                    _DT = new DataTable();
                    _DT = BLL_Pagamento.Busca(Pagamento);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PagtoBoleto);
                    break;
                #endregion

                #region NFe_NFC_e
                case Tipo_Parametro.NFe_NFC_e:
                    List<string> AmbienteNFe = new List<string>();
                    AmbienteNFe.Add("PRODUÇÃO");
                    AmbienteNFe.Add("HOMOLOGAÇÃO - (TESTES)");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, AmbienteNFe), "Descricao", "ID", cb_AmbienteNFe);

                    List<string> Regime = new List<string>();
                    Regime.Add("SIMPLES NACIONAL");
                    Regime.Add("SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DA RECEITA BRUTA");
                    Regime.Add("REGIME NORMAL");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Regime), "Descricao", "ID", cb_RegimeTributario);

                    BLL_NF_TipoEmissao = new BLL_NF_TipoEmissao();
                    NF_TipoEmissao = new DTO_NF_TipoEmissao();

                    NF_TipoEmissao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    _DT = new DataTable();
                    _DT = BLL_NF_TipoEmissao.Busca(NF_TipoEmissao);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo_NFe_Venda);
                    break;
                #endregion

                #region CF-e SAT
                case Tipo_Parametro.SAT:
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                    Pessoa.TipoPessoa = 2;

                    _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Completa(Pessoa);

                    if (_DT.Rows.Count > 0)
                    {
                        txt_CNPJSAT.Text = _DT.Rows[0]["CNPJ_CPF"].ToString() + " - " + _DT.Rows[0]["Sigla"].ToString();
                        txt_ID_UF_SAT.Text = _DT.Rows[0]["ID_UF"].ToString();
                    }

                    List<string> Tipo_Certificado = new List<string>();
                    Tipo_Certificado.Add("AC-SAT/SEFAZ");
                    Tipo_Certificado.Add("ICP-BRASIL");
                    Tipo_Certificado.Add("RENOVAÇÃO ICP-BRASIL");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo_Certificado), "Descricao", "ID", cb_TipoCertificadoSAT);
                    cb_TipoCertificadoSAT.SelectedIndex = 0;

                    List<string> Tipo_SAT = new List<string>();
                    Tipo_SAT.Add("0 - NENHUM");
                    Tipo_SAT.Add("1 - EMULADOR");
                    Tipo_SAT.Add("2 - SAT DESENVOLVIDO .NET");
                    Tipo_SAT.Add("3 - ELGIN LINKER I");
                    Tipo_SAT.Add("4 - BEMATECH x32");
                    Tipo_SAT.Add("5 - BEMATECH x64");
                    Tipo_SAT.Add("6 - ELGIN LINKER II");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, Tipo_SAT), "Descricao", "ID", cb_TipoEquipamentoSAT);
                    cb_TipoEquipamentoSAT.SelectedIndex = 0;

                    List<string> Tipo_RedeSAT = new List<string>();
                    Tipo_RedeSAT.Add("CABO");
                    Tipo_RedeSAT.Add("WIFI");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo_RedeSAT), "Descricao", "ID", cb_TipoRede);
                    cb_TipoRede.SelectedIndex = 0;

                    List<string> Tipo_WIFISAT = new List<string>();
                    Tipo_WIFISAT.Add("NENHUMA");
                    Tipo_WIFISAT.Add("WEP");
                    Tipo_WIFISAT.Add("WPA-PERSONAL");
                    Tipo_WIFISAT.Add("WPA-ENTERPRISE");
                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo_WIFISAT), "Descricao", "ID", cb_TipoSeguranca);
                    cb_TipoSeguranca.SelectedIndex = 0;
                    break;
                #endregion

                #region CADASTRO
                case Tipo_Parametro.Parametro_Cadastro:
                    List<string> Tipo_Pessoa = new List<string>();
                    Tipo_Pessoa.Add("1 - PESSOA JURÍDICA");
                    Tipo_Pessoa.Add("2 - PESSOA FÍSICA");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo_Pessoa), "Descricao", "ID", cb_Cadastro_PessoaPadrao);
                    cb_Cadastro_PessoaPadrao.SelectedIndex = 1;

                    List<string> Tipo_EntradaProduto = new List<string>();
                    Tipo_EntradaProduto.Add("ATUALIZAR MARGEM");
                    Tipo_EntradaProduto.Add("ATUALIZAR VALOR DE VENDA");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo_EntradaProduto), "Descricao", "ID", cb_EntradaProduto);
                    cb_EntradaProduto.SelectedIndex = 1;

                    BLL_Grupo = new BLL_Grupo();
                    Grupo = new DTO_Grupo();
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Endereco);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Endereco_Padrao);
                    cb_Endereco_Padrao.SelectedIndex = 0;

                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Telefone);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Telefone_Padrao);
                    cb_Telefone_Padrao.SelectedIndex = 0;

                    List<string> Decimal_Valor = new List<string>();
                    Decimal_Valor.Add("2 (0,00)");
                    Decimal_Valor.Add("3 (0,000)");
                    Decimal_Valor.Add("4 (0,0000)");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(2, Decimal_Valor), "Descricao", "ID", cb_Decimal_Produto_Valor);
                    cb_Decimal_Produto_Valor.SelectedIndex = 1;

                    List<string> Decimal_Quantidade = new List<string>();
                    Decimal_Quantidade.Add("0 (0)");
                    Decimal_Quantidade.Add("1 (0,0)");
                    Decimal_Quantidade.Add("2 (0,00)");
                    Decimal_Quantidade.Add("3 (0,000)");
                    Decimal_Quantidade.Add("4 (0,0000)");

                    util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, Decimal_Quantidade), "Descricao", "ID", cb_Decimal_Produto_Quantidade);
                    cb_Decimal_Produto_Quantidade.SelectedIndex = 1;
                    break;
                    #endregion
            }
        }

        private void Carrega_Usuario()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();

            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

            DataTable _DT = new DataTable();
            _DT = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Usuario);
        }

        private void CarregaConta()
        {
            BLL_PlanoConta = new BLL_PlanoConta();
            PlanoConta = new DTO_PlanoConta();

            DataTable _DT = new DataTable();

            int Nivel = util_dados.VerificaNivel(mk_Conta.Text);

            Conta = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);
            //Nivel 1

            if (Conta.Length == 2)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

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
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                return;
            }
            //Nivel 2
            if (Conta.Length == 4)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 1)
                {
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                    }

                    txt_DescricaoConta.Text = Descricao;
                }
                return;
            }
            //Nivel 3
            if (Conta.Length == 6)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 2)
                {
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                    }
                    txt_DescricaoConta.Text = Descricao;
                }
                return;
            }
            //Nivel 4
            if (Conta.Length == 8)
            {
                PlanoConta.Nivel = Nivel;
                PlanoConta.CodigoPai = util_dados.ConsultaCodigoPai(mk_Conta.Text, Nivel);

                _DT = BLL_PlanoConta.Busca(PlanoConta);

                string Descricao = string.Empty;

                if (_DT.Rows.Count <= 3)
                {
                    txt_ID_Conta.Text = string.Empty;
                    txt_DescricaoConta.Text = string.Empty;
                    return;
                }
                else
                {
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Descricao += _DT.Rows[i]["CodigoDescritivo"].ToString() + " - " + _DT.Rows[i]["DescricaoConta"].ToString() + Environment.NewLine;
                        if (i == _DT.Rows.Count - 1)
                            txt_ID_Conta.Text = _DT.Rows[i]["ID"].ToString();
                    }
                    txt_DescricaoConta.Text = Descricao;
                }
                return;
            }

        }

        private void Carrega_Imagem()
        {
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

                Img_Relatorio.Image = ImagemConvertida;
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
                img_ImagemSistema.Image = ImagemConvertida;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void AtivarSAT()
        {
            try
            {
                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                CFe_SAT.Funcao = CFe_SAT_Funcao.AtivarSAT;
                CFe_SAT.Tipo_Opcao = Convert.ToInt32(cb_TipoCertificadoSAT.SelectedValue);
                CFe_SAT.CNPJ = txt_CNPJSAT.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 14);
                CFe_SAT.ID_UF = Convert.ToInt32(txt_ID_UF_SAT.Text);
                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void AssociarAssinaturaSAT()
        {
            try
            {
                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                CFe_SAT.Funcao = CFe_SAT_Funcao.AssociarAssinatura;
                CFe_SAT.CNPJ = "08097009000174" + txt_CNPJSAT.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 14);
                CFe_SAT.Assinatura = txt_AssinaturaSAT.Text;

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void AtualizarSoftwareSAT()
        {
            try
            {
                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                CFe_SAT.Funcao = CFe_SAT_Funcao.AtualizarSoftwareSAT;

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void ConsultaSAT()
        {
            try
            {
                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                CFe_SAT.Funcao = CFe_SAT_Funcao.ConsultarSAT;

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void ConsultaStatusOperacional()
        {
            try
            {
                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                CFe_SAT.Funcao = CFe_SAT_Funcao.ConsultarStatusOperacional;

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem + "\n\n" + CFe_SAT_Retorno.StatusOperacional, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Bloqueia_DesbloqueiaSAT(string _aux)
        {
            try
            {
                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                if (_aux == "BLOQUEAR")
                    CFe_SAT.Funcao = CFe_SAT_Funcao.BloquearSAT;

                if (_aux == "DESBLOQUEAR")
                    CFe_SAT.Funcao = CFe_SAT_Funcao.DesbloquearSAT;

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void ConfiguraRedeSAT()
        {
            try
            {
                #region XML CONFIGURAÇÃO
                string XML = "<?xml version='1.0' encoding='UTF-8'?><config>";

                if (cb_TipoRede.Text == "CABO")//ETHERNET                
                    XML += "<tipoInter>ETHE<tipoInter>";
                else
                    XML += "<tipoInter>WIFI<tipoInter>";

                if (cb_TipoSeguranca.Text != "NENHUMA")
                    XML += "<seg>" + cb_TipoSeguranca.Text + "</seg><codigo>" + txt_SenhaWIFI.Text + "</codigo>";

                if (rb_IPFIXO.Checked == true)
                {
                    XML += "<tipoLan>IPFIX</tipoLan>";
                    XML += "<lanIP>" + mk_IP.Text + "</lanIP>";
                    XML += "<lanMask>" + mk_Mascara.Text + "</lanMask>";
                    XML += "<lanGW>" + mk_Gateway.Text + "</lanGW>";
                    XML += "<lanDNS1>" + mk_DNS1.Text + "</lanDNS1>";
                    XML += "<lanDNS2>" + mk_DNS2.Text + "</lanDNS2>";
                }
                else
                    XML += "<tipoLan>DHCP</tipoLan>";

                XML += "</config>";
                #endregion

                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();
                CFe_SAT.XML = XML;

                CFe_SAT.Funcao = CFe_SAT_Funcao.ConfigurarInterfaceDeRede;
                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void TesteFimAFim()
        {
            try
            {
                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                string XML = "<?xml version='1.0' encoding='UTF-8'?> ";
                XML += "<CFe><infCFe versaoDadosEnt='0.06'>";
                XML += "<ide><CNPJ>" + txt_CNPJSAT.Text.Replace(".", "").Replace("/", "").Replace("-", "").Substring(0, 14) + "</CNPJ>";
                XML += "<signAC>" + Parametro_NFe_NFC_SAT.AssinaturaSAT + "</signAC><numeroCaixa>001</numeroCaixa>";
                //XML += "</ide><emit><CNPJ>" + util_dados.Conf_strDoc_NFe(Parametro_Empresa.CNPJ) + "</CNPJ>";
                XML += "</ide><emit><CNPJ>11111111111111</CNPJ><IE>111111111111</IE>";
                XML += "<cRegTribISSQN>1</cRegTribISSQN><indRatISSQN>N</indRatISSQN></emit><dest/>";
                XML += "<det nItem='1'><prod><cProd>01</cProd><xProd>Carne</xProd><CFOP>5000</CFOP><uCom>un</uCom><qCom>1.0000</qCom><vUnCom>2.100</vUnCom><indRegra>A</indRegra></prod>";
                XML += "<imposto><ICMS><ICMS00><Orig>0</Orig><CST>00</CST><pICMS>5.00</pICMS></ICMS00></ICMS><PIS><PISAliq><CST>01</CST><vBC>2.10</vBC><pPIS>1.0000</pPIS></PISAliq></PIS><PISST><vBC>1.10</vBC><pPIS>1.0000</pPIS></PISST><COFINS><COFINSAliq><CST>01</CST><vBC>1.00</vBC><pCOFINS>1.0000</pCOFINS></COFINSAliq></COFINS></imposto>";
                XML += "</det><pgto><MP><cMP>01</cMP><vMP>33.00</vMP></MP></pgto><total/>";
                XML += "</infCFe></CFe>";

                CFe_SAT.XML = XML;
                CFe_SAT.Funcao = CFe_SAT_Funcao.TesteFimAFim;

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Exibe_LogSAT()
        {
            try
            {
                txt_Logs.Clear();

                SAT_ProcessaSAT SAT = new SAT_ProcessaSAT();
                CFe_SAT = new DTO_CFe_SAT();
                CFe_SAT_Retorno = new DTO_CFe_SAT_Retorno();

                CFe_SAT.Funcao = CFe_SAT_Funcao.ExtrairLogs;

                CFe_SAT_Retorno = SAT.Funcao(CFe_SAT);

                if (CFe_SAT_Retorno.Status == true)
                {
                    MessageBox.Show(util_msg.msg_FuncaoSATSucesso + CFe_SAT_Retorno.Mensagem, this.Text);
                    txt_Logs.Text = CFe_SAT_Retorno.Logs;
                }
                else
                    MessageBox.Show(util_msg.msg_FuncaoSATErro + CFe_SAT_Retorno.Mensagem, this.Text);

                if (CFe_SAT_Retorno.Mensagem_SEFAZ != string.Empty)
                    MessageBox.Show(util_msg.msg_MensagemSEFAZ + CFe_SAT_Retorno.Cod_msg_SEFAZ + "-" + CFe_SAT_Retorno.Mensagem_SEFAZ, this.Text);
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
            BLL_Parametro = new BLL_Parametro();
            Parametro = new DTO_Parametro();

            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT;

            switch (Tipo)
            {
                #region FINANCEIRO
                case Tipo_Parametro.Financeiro:
                    Parametro.Tipo = 1;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_Financeiro);
                        util_dados.CarregaCampo(this, _DT, gb_Contas);

                        Parametro_Financeiro.Tarifa_Juros = Convert.ToDouble(_DT.Rows[0]["Juros_Mes"]);
                        Parametro_Financeiro.Tarifa_Multa = Convert.ToDouble(_DT.Rows[0]["Multa"]);
                        Parametro_Financeiro.ID_Conta_TransferenciaValores = Convert.ToInt32(_DT.Rows[0]["ID_ContaTransValor"]);
                        Parametro_Financeiro.ID_Conta_Lanc_ChequeDevolvido = Convert.ToInt32(_DT.Rows[0]["ID_ContaDevolucaoCheque"]);
                        Parametro_Financeiro.ID_Conta_FatVenda = Convert.ToInt32(_DT.Rows[0]["ID_ContaFaturaVenda"]);
                        Parametro_Financeiro.ID_Conta_FatOS = Convert.ToInt32(_DT.Rows[0]["ID_ContaFaturaOS"]);
                        Parametro_Financeiro.ID_Conta_FatCompra = Convert.ToInt32(_DT.Rows[0]["ID_ContaFaturaCompra"]);
                        Parametro_Financeiro.ID_ContaDevolucaoVenda = Convert.ToInt32(_DT.Rows[0]["ID_ContaDevolucaoVenda"]);
                        Parametro_Financeiro.ID_Caixa_Principal = Convert.ToInt32(_DT.Rows[0]["ID_Caixa_Principal"]);
                        Parametro_Financeiro.ID_Conta_PagtoDiverso = Convert.ToInt32(_DT.Rows[0]["ID_Conta_PagtoDiverso"]);
                        Parametro_Financeiro.ID_Conta_RectoDiverso = Convert.ToInt32(_DT.Rows[0]["ID_Conta_RectoDiverso"]);
                        Parametro_Financeiro.ID_Conta_CobrancaBancaria = Convert.ToInt32(_DT.Rows[0]["ID_Conta_CobrancaBancaria"]);
                        Parametro_Financeiro.ID_PagtoBoleto = Convert.ToInt32(_DT.Rows[0]["ID_PagtoBoleto"]);
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                #endregion

                #region VENDAS
                case Tipo_Parametro.Vendas:
                    Parametro.Tipo = 2;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_Vendas);

                        Parametro_Venda.TipoImpressoraTermica = Convert.ToInt32(_DT.Rows[0]["TipoImpressoraTermica"]);
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
                        Parametro_Venda.NaoAlterarVendaFaturada = Convert.ToBoolean(_DT.Rows[0]["NaoAlterarVendaFaturada"]);
                        Parametro_Venda.PagamentoTrocoDevolucao = Convert.ToInt32(_DT.Rows[0]["PagamentoTrocoDevolucao"]);
                        Parametro_Venda.Venda_Matricial = Convert.ToBoolean(_DT.Rows[0]["Venda_Matricial"]);
                        Parametro_Venda.Modelo_Matricial = Convert.ToInt32(_DT.Rows[0]["Modelo_Matricial"]);
                        Parametro_Venda.Desconto_Padrao = Convert.ToInt32(_DT.Rows[0]["Desconto_Padrao"]);
                        Parametro_Venda.Exibe_NFeVenda = Convert.ToBoolean(_DT.Rows[0]["Exibe_NFeVenda"]);
                        Parametro_Venda.ID_TabelaVendaPadrao = Convert.ToInt32(_DT.Rows[0]["ID_TabelaVenda"]);
                        Parametro_Venda.ID_ConsumidorFinal = Convert.ToInt32(_DT.Rows[0]["ID_ConsumidorFinal"]);
                        Parametro_Venda.CFe_Cartao = Convert.ToBoolean(_DT.Rows[0]["CFe_Cartao"]);
                        Parametro_Venda.Venda_ImpressaoDireta = Convert.ToBoolean(_DT.Rows[0]["Venda_ImpressaoDireta"]);
                        Parametro_Venda.CFe_PDV_Cartao = Convert.ToBoolean(_DT.Rows[0]["CFe_PDV_Cartao"]);
                        Parametro_Venda.TipoSaida_Fixo = Convert.ToBoolean(_DT.Rows[0]["TipoSaida_Fixo"]);
                        Parametro_Venda.Qt_Dias_Pesquisa = Convert.ToInt32(_DT.Rows[0]["Qt_Dias_Pesquisa"]);
                        Parametro_Venda.Altera_ValorPDV = Convert.ToBoolean(_DT.Rows[0]["Altera_ValorPDV"]);

                        switch (Convert.ToInt32(_DT.Rows[0]["Produto_PrecoVenda"]))
                        {
                            case 1:
                                Parametro_Venda.Produto_PrecoVenda = Composicao_PrecoVenda.Custo_Final;
                                break;

                            case 2:
                                Parametro_Venda.Produto_PrecoVenda = Composicao_PrecoVenda.Preco_Compra;
                                break;
                        }

                        switch (Convert.ToInt32(_DT.Rows[0]["Consulta_Grade"]))
                        {
                            case 1: //UNICO
                                Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Unico;
                                break;

                            case 2: //QUANTIDADE
                                Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Quantidade;
                                break;
                        }
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                #endregion

                #region MOBILE
                case Tipo_Parametro.Mobile:
                    Parametro.Tipo = 3;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                        util_dados.CarregaCampo(this, _DT, gb_Mobile);
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                #endregion

                #region USUARIO
                case Tipo_Parametro.Usuario:
                    BLL_Usuario = new BLL_Usuario();
                    Usuario = new DTO_Usuario();

                    Usuario.ID = util_dados.Verifica_int(cb_ID_Usuario.SelectedValue.ToString());

                    _DT = new DataTable();
                    _DT = BLL_Usuario.Busca_Parametros(Usuario);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_Param_Usuario);

                        if (Usuario.ID == Parametro_Usuario.ID_Usuario_Ativo)
                        {
                            Parametro_Usuario.Venda_Restrita = Convert.ToBoolean(_DT.Rows[0]["Venda_Restrita"]);
                            Parametro_Usuario.Libera_Desconto = Convert.ToBoolean(_DT.Rows[0]["Libera_Desconto"]);
                            Parametro_Usuario.Venda_Fixa_logado = Convert.ToBoolean(_DT.Rows[0]["Venda_Fixa_logado"]);
                            Parametro_Usuario.Permite_Faturar = Convert.ToBoolean(_DT.Rows[0]["Permite_Faturar"]);
                            Parametro_Usuario.Permite_AterarFaturado = Convert.ToBoolean(_DT.Rows[0]["Permite_AterarFaturado"]);
                            Parametro_Usuario.Visualiza_ResumoVenda = Convert.ToBoolean(_DT.Rows[0]["Visualiza_ResumoVenda"]);
                        }
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);

                    break;
                #endregion

                #region NF-e NFC-e
                case Tipo_Parametro.NFe_NFC_e:
                    Parametro.Tipo = 5;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_NFe);
                        util_dados.CarregaCampo(this, _DT, gb_NFe_SN);

                        Parametro_NFe_NFC_SAT.Regime_Tributario = Convert.ToInt32(_DT.Rows[0]["RegimeTributario"]);
                        Parametro_NFe_NFC_SAT.AmbienteNFe = Convert.ToInt32(_DT.Rows[0]["AmbienteNFe"]);
                        Parametro_NFe_NFC_SAT.CertificadoDigital = _DT.Rows[0]["Certificado_NFe"].ToString();
                        Parametro_NFe_NFC_SAT.Caminho_NFe = Convert.ToString(_DT.Rows[0]["Caminho_NFe"]);
                        Parametro_NFe_NFC_SAT.AmbienteNFe = Convert.ToInt32(_DT.Rows[0]["AmbienteNFe"]);
                        Parametro_NFe_NFC_SAT.Regime_Tributario = Convert.ToInt32(_DT.Rows[0]["RegimeTributario"]);
                        Parametro_NFe_NFC_SAT.Exibe_InfoProd = Convert.ToBoolean(_DT.Rows[0]["Exibe_InfoProduto"]);
                        Parametro_NFe_NFC_SAT.AliquotaICMS = Convert.ToDouble(_DT.Rows[0]["AliquotaCreditoICMS"]);
                        Parametro_NFe_NFC_SAT.Exibe_msgCreditoICMS = Convert.ToBoolean(_DT.Rows[0]["Exibe_msgCreditoICMS"]);
                        Parametro_NFe_NFC_SAT.Exibe_ReferenciaNFe = Convert.ToBoolean(_DT.Rows[0]["Exibe_ReferenciaNFe"]);
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                #endregion

                #region CF-e SAT
                case Tipo_Parametro.SAT:
                    Parametro.Tipo = 6;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_SAT);

                        Parametro_NFe_NFC_SAT.TipoEquipamentoSAT = Convert.ToInt32(_DT.Rows[0]["TipoEquipamentoSAT"]);
                        Parametro_NFe_NFC_SAT.SenhaAtivacaoSAT = _DT.Rows[0]["SenhaAtivacaoSAT"].ToString();
                        Parametro_NFe_NFC_SAT.AssinaturaSAT = _DT.Rows[0]["AssinaturaSAT"].ToString();
                        Parametro_NFe_NFC_SAT.CFe_A4 = Convert.ToBoolean(_DT.Rows[0]["CFe_A4"]);
                        Parametro_NFe_NFC_SAT.Monitor_CFe = Convert.ToBoolean(_DT.Rows[0]["Monitor_CFe"]);
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                #endregion

                #region ORDEM DE SERVIÇO
                case Tipo_Parametro.OrdemServico:
                    Parametro.Tipo = 7;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_OrdemServico);

                        Parametro_OrdemServico.Descricao_Info1 = _DT.Rows[0]["Descricao_Info1"].ToString();
                        Parametro_OrdemServico.Descricao_Info2 = _DT.Rows[0]["Descricao_Info2"].ToString();
                        Parametro_OrdemServico.Descricao_Info3 = _DT.Rows[0]["Descricao_Info3"].ToString();
                        Parametro_OrdemServico.Descricao_Obs1 = _DT.Rows[0]["Descricao_Obs1"].ToString();
                        Parametro_OrdemServico.Descricao_Obs2 = _DT.Rows[0]["Descricao_Obs2"].ToString();
                        Parametro_OrdemServico.Imprime_OS_Equipamento = Convert.ToBoolean(_DT.Rows[0]["Imprime_OS_Equip"]);
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                #endregion

                #region CADASTRO PERSONALIZADO
                case Tipo_Parametro.Cadastro_Personalizado:
                    Parametro.Tipo = 8;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_InfoPessoa);
                        util_dados.CarregaCampo(this, _DT, gb_InfoProduto);

                        Parametro_CadastroPersonalizado.ClienteDescricao1 = _DT.Rows[0]["ClienteDescricao1"].ToString();
                        Parametro_CadastroPersonalizado.ClienteDescricao2 = _DT.Rows[0]["ClienteDescricao2"].ToString();
                        Parametro_CadastroPersonalizado.ClienteDescricao3 = _DT.Rows[0]["ClienteDescricao3"].ToString();
                        Parametro_CadastroPersonalizado.EmpresaDescricao1 = _DT.Rows[0]["EmpresaDescricao1"].ToString();
                        Parametro_CadastroPersonalizado.EmpresaDescricao2 = _DT.Rows[0]["EmpresaDescricao2"].ToString();
                        Parametro_CadastroPersonalizado.EmpresaDescricao3 = _DT.Rows[0]["EmpresaDescricao3"].ToString();
                        Parametro_CadastroPersonalizado.FornecedorDescricao1 = _DT.Rows[0]["FornecedorDescricao1"].ToString();
                        Parametro_CadastroPersonalizado.FornecedorDescricao2 = _DT.Rows[0]["FornecedorDescricao2"].ToString();
                        Parametro_CadastroPersonalizado.FornecedorDescricao3 = _DT.Rows[0]["FornecedorDescricao3"].ToString();
                        Parametro_CadastroPersonalizado.FuncionarioDescricao1 = _DT.Rows[0]["FuncionarioDescricao1"].ToString();
                        Parametro_CadastroPersonalizado.FuncionarioDescricao2 = _DT.Rows[0]["FuncionarioDescricao2"].ToString();
                        Parametro_CadastroPersonalizado.FuncionarioDescricao3 = _DT.Rows[0]["FuncionarioDescricao3"].ToString();
                        Parametro_CadastroPersonalizado.TransportadoraDescricao1 = _DT.Rows[0]["TransportadoraDescricao1"].ToString();
                        Parametro_CadastroPersonalizado.TransportadoraDescricao2 = _DT.Rows[0]["TransportadoraDescricao2"].ToString();
                        Parametro_CadastroPersonalizado.TransportadoraDescricao3 = _DT.Rows[0]["TransportadoraDescricao3"].ToString();
                        Parametro_CadastroPersonalizado.Info_Produto1 = _DT.Rows[0]["Info_Produto1"].ToString();
                        Parametro_CadastroPersonalizado.Info_Produto2 = _DT.Rows[0]["Info_Produto2"].ToString();
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                #endregion

                #region CONFIGURAÇÃO DE EMAIL
                case Tipo_Parametro.Config_eMail:
                    Parametro.Tipo = 9;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                        util_dados.CarregaCampo(this, _DT, gb_ConfigEmail);
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);

                    break;
                #endregion

                #region PARAMETROS DE CADASTRO
                case Tipo_Parametro.Parametro_Cadastro:
                    Parametro.Tipo = 10;

                    _DT = new DataTable();
                    _DT = BLL_Parametro.Busca(Parametro);

                    if (_DT.Rows.Count > 0)
                    {
                        util_dados.CarregaCampo(this, _DT, gb_ParametroCadastro);

                        Parametro_Cadastro.Exibe_DuplicarProduto = Convert.ToBoolean(_DT.Rows[0]["Exibe_DuplicarProduto"]);
                        Parametro_Cadastro.Somente_Maiusculo = Convert.ToBoolean(_DT.Rows[0]["Somente_Maiusculo"]);
                        Parametro_Cadastro.Cadastro_PessoaPadrao = Convert.ToInt32(_DT.Rows[0]["Cadastro_PessoaPadrao"]);
                        Parametro_Cadastro.Endereco_Padrao = Convert.ToInt32(_DT.Rows[0]["Endereco_Padrao"]);
                        Parametro_Cadastro.Telefone_Padrao = Convert.ToInt32(_DT.Rows[0]["Telefone_Padrao"]);
                        Parametro_Cadastro.EntradaProduto = Convert.ToInt32(_DT.Rows[0]["EntradaProduto"]);
                        Parametro_Cadastro.Decimal_Produto_Quantidade = Convert.ToInt32(_DT.Rows[0]["Decimal_Produto_Quantidade"]);
                        Parametro_Cadastro.Decimal_Produto_Valor = Convert.ToInt32(_DT.Rows[0]["Decimal_Produto_Valor"]);
                    }
                    else
                        MessageBox.Show(util_msg.msg_ParamNaoConfigurado, this.Text);
                    break;
                    #endregion
            }
        }

        public override void Gravar()
        {
            try
            {
                BLL_Parametro = new BLL_Parametro();
                Parametro = new DTO_Parametro();

                Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                switch (Tipo)
                {
                    #region FINANCEIRO
                    case Tipo_Parametro.Financeiro:
                        Parametro.Tipo = 1;

                        Parametro.Financeiro = new DTO_Parametro_Financeiro();
                        Parametro.Financeiro.Multa = Convert.ToDouble(txt_Multa.Text);
                        Parametro.Financeiro.Juros_Mes = Convert.ToDouble(txt_Juros_Mes.Text);
                        Parametro.Financeiro.ID_ContaTransValor = Convert.ToInt32(txt_ID_ContaTransValor.Text);
                        Parametro.Financeiro.ID_ContaDevolucaoCheque = Convert.ToInt32(txt_ID_ContaDevolucaoCheque.Text);
                        Parametro.Financeiro.ID_ContaFaturaVenda = Convert.ToInt32(txt_ID_ContaFaturaVenda.Text);
                        Parametro.Financeiro.ID_ContaFaturaOS = Convert.ToInt32(txt_ID_ContaFaturaOS.Text);
                        Parametro.Financeiro.ID_ContaFaturaCompra = Convert.ToInt32(txt_ID_ContaFaturaCompra.Text);
                        Parametro.Financeiro.ID_ContaDevolucaoVenda = Convert.ToInt32(txt_ID_ContaDevolucaoVenda.Text);
                        Parametro.Financeiro.ID_Caixa_Principal = Convert.ToInt32(cb_ID_Caixa_Principal.SelectedValue);
                        Parametro.Financeiro.ID_Conta_PagtoDiverso = Convert.ToInt32(txt_ID_Conta_PagtoDiverso.Text);
                        Parametro.Financeiro.ID_Conta_RectoDiverso = Convert.ToInt32(txt_ID_Conta_RectoDiverso.Text);
                        Parametro.Financeiro.ID_PagtoBoleto = Convert.ToInt32(cb_ID_PagtoBoleto.SelectedValue);
                        Parametro.Financeiro.ID_Conta_CobrancaBancaria = Convert.ToInt32(txt_ID_Conta_CobrancaBancaria.Text);

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region VENDA
                    case Tipo_Parametro.Vendas:
                        Parametro.Tipo = 2;

                        Parametro.Vendas = new DTO_Parametro_Vendas();
                        Parametro.Vendas.DiasBloqueioVenda = Convert.ToInt32(txt_DiasBloqueioVenda.Text);
                        Parametro.Vendas.ID_ConsumidorFinal = util_dados.Verifica_int(cb_ID_ConsumidorFinal.SelectedValue.ToString());
                        Parametro.Vendas.ID_TabelaVenda = Convert.ToInt32(cb_ID_TabelaVenda.SelectedValue);
                        Parametro.Vendas.Consulta_Grade = Convert.ToInt32(cb_Consulta_Grade.SelectedValue);
                        Parametro.Vendas.TipoImpressoraTermica = Convert.ToInt32(cb_TipoImpressoraTermica.SelectedValue);
                        Parametro.Vendas.Ultimo_Valor = Convert.ToBoolean(ck_Ultimo_Valor.Checked);
                        Parametro.Vendas.Permitir2Vias = Convert.ToBoolean(ck_Permitir2Vias.Checked);
                        Parametro.Vendas.Agrupar_Produto = Convert.ToBoolean(ck_Agrupar_Produto.Checked);
                        Parametro.Vendas.Descricao_Comissao = txt_Descricao_Comissao.Text;
                        Parametro.Vendas.Limite_Desconto = Convert.ToDouble(txt_Limite_Desconto.Text);
                        Parametro.Vendas.Produto_Marca = Convert.ToBoolean(ck_Produto_Marca.Checked);
                        Parametro.Vendas.Bloquear_EstoqueNegativo = Convert.ToBoolean(ck_Bloquear_EstoqueNegativo.Checked);
                        Parametro.Vendas.msg_EstoqueNegativo = Convert.ToBoolean(ck_msg_EstoqueNegativo.Checked);
                        Parametro.Vendas.Orca_ValorTotal = Convert.ToBoolean(ck_Orca_ValorTotal.Checked);
                        Parametro.Vendas.MultiploUsuarioPDV = Convert.ToBoolean(ck_MultiploUsuarioPDV.Checked);
                        Parametro.Vendas.Consulta_RapidaProduto = Convert.ToBoolean(ck_Consulta_RapidaProduto.Checked);
                        Parametro.Vendas.NaoAlterarVendaFaturada = Convert.ToBoolean(ck_NaoAlterarVendaFaturada.Checked);
                        Parametro.Vendas.PagamentoTrocoDevolucao = Convert.ToInt32(cb_PagamentoTrocoDevolucao.SelectedValue);
                        Parametro.Vendas.Venda_Matricial = Convert.ToBoolean(ck_Venda_Matricial.Checked);
                        Parametro.Vendas.Modelo_Matricial = Convert.ToInt32(cb_Modelo_Matricial.SelectedValue);
                        Parametro.Vendas.Desconto_Padrao = Convert.ToInt32(cb_Desconto_Padrao.SelectedValue);
                        Parametro.Vendas.Exibe_NFeVenda = Convert.ToBoolean(ck_Exibe_NFeVenda.Checked);

                        Parametro.Vendas.CFe_Cartao = Convert.ToBoolean(ck_CFe_Cartao.Checked);
                        Parametro.Vendas.Venda_ImpressaoDireta = Convert.ToBoolean(ck_Venda_ImpressaoDireta.Checked);
                        Parametro.Vendas.CFe_PDV_Cartao = Convert.ToBoolean(ck_CFe_PDV_Cartao.Checked);
                        Parametro.Vendas.TipoSaida_Fixo = Convert.ToBoolean(ck_TipoSaida_Fixo.Checked);
                        Parametro.Vendas.Qt_Dias_Pesquisa = util_dados.Verifica_int(txt_Qt_Dias_Pesquisa.Text);
                        Parametro.Vendas.Altera_ValorPDV = Convert.ToBoolean(ck_Altera_ValorPDV.Checked);

                        switch (Convert.ToInt32(cb_Produto_PrecoVenda.SelectedValue))
                        {
                            case 1:
                                Parametro.Vendas.Produto_PrecoVenda = Composicao_PrecoVenda.Custo_Final;
                                break;

                            case 2:
                                Parametro.Vendas.Produto_PrecoVenda = Composicao_PrecoVenda.Preco_Compra;
                                break;
                        }

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region MOBILE
                    case Tipo_Parametro.Mobile:
                        Parametro.Tipo = 3;

                        Parametro.Mobile = new DTO_Parametro_Mobile();
                        Parametro.Mobile.HistoricoVenda = Convert.ToInt32(txt_HistoricoVenda.Text);

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region USUÁRIO
                    case Tipo_Parametro.Usuario:
                        BLL_Usuario = new BLL_Usuario();
                        Parametro.Usuario_Parametros = new DTO_Usuario_Parametros();

                        Parametro.Usuario_Parametros.ID_Usuario = util_dados.Verifica_int(cb_ID_Usuario.SelectedValue.ToString());
                        Parametro.Usuario_Parametros.Comissao = Convert.ToBoolean(ck_Comissao.Checked);
                        Parametro.Usuario_Parametros.Venda_Restrita = Convert.ToBoolean(ck_Venda_Restrita.Checked);
                        Parametro.Usuario_Parametros.Libera_Desconto = Convert.ToBoolean(ck_Libera_Desconto.Checked);
                        Parametro.Usuario_Parametros.Venda_Fixa_logado = Convert.ToBoolean(ck_Venda_Fixa_logado.Checked);
                        Parametro.Usuario_Parametros.Permite_Faturar = Convert.ToBoolean(ck_Permite_Faturar.Checked);
                        Parametro.Usuario_Parametros.Permite_AterarFaturado = Convert.ToBoolean(ck_Permite_AterarFaturado.Checked);
                        Parametro.Usuario_Parametros.Visualiza_ResumoVenda = Convert.ToBoolean(ck_Visualiza_ResumoVenda.Checked);

                        BLL_Usuario.Grava_Parametros(Parametro.Usuario_Parametros);

                        Pesquisa();
                        break;
                    #endregion

                    #region NF-e NFC-e
                    case Tipo_Parametro.NFe_NFC_e:
                        Parametro.Tipo = 5;

                        Parametro.NFe_NFCe = new DTO_Parametro_NFe_NFCe();

                        Parametro.NFe_NFCe.AmbienteNFe = Convert.ToInt32(cb_AmbienteNFe.SelectedValue);
                        Parametro.NFe_NFCe.RegimeTributario = Convert.ToInt32(cb_RegimeTributario.SelectedValue);
                        Parametro.NFe_NFCe.Exibe_msgCreditoICMS = ck_Exibe_msgCreditoICMS.Checked;
                        Parametro.NFe_NFCe.AliquotaCreditoICMS = Convert.ToDouble(txt_AliquotaCreditoICMS.Text);
                        Parametro.NFe_NFCe.Caminho_NFe = txt_Caminho_NFe.Text;
                        Parametro.NFe_NFCe.Exibe_Desconto = ck_Exibe_Desconto.Checked;
                        Parametro.NFe_NFCe.Exibe_InfoProduto = ck_Exibe_InfoProduto.Checked;
                        Parametro.NFe_NFCe.Certificado_NFe = txt_Certificado_NFe.Text;
                        Parametro.NFe_NFCe.Tipo_NFe_Venda = Convert.ToInt32(cb_Tipo_NFe_Venda.SelectedValue);
                        Parametro.NFe_NFCe.Exibe_ReferenciaNFe = Convert.ToBoolean(ck_Exibe_ReferenciaNFe.Checked);

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region CF-e SAT
                    case Tipo_Parametro.SAT:
                        Parametro.Tipo = 6;

                        Parametro.CFe_SAT = new DTO_Parametro_CFe_SAT();

                        Parametro.CFe_SAT.TipoEquipamentoSAT = Convert.ToInt32(cb_TipoEquipamentoSAT.SelectedValue);
                        Parametro.CFe_SAT.SenhaAtivacaoSAT = txt_SenhaAtivacaoSAT.Text;
                        Parametro.CFe_SAT.AssinaturaSAT = txt_AssinaturaSAT.Text;
                        Parametro.CFe_SAT.CFe_A4 = ck_CFe_A4.Checked;

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region ORDEM SERVIÇO
                    case Tipo_Parametro.OrdemServico:
                        Parametro.Tipo = 7;

                        Parametro.OrdemServico = new DTO_Parametro_OrdemServico();

                        Parametro.OrdemServico.Descricao_Info1 = txt_Descricao_Info1.Text;
                        Parametro.OrdemServico.Descricao_Info2 = txt_Descricao_Info2.Text;
                        Parametro.OrdemServico.Descricao_Info3 = txt_Descricao_Info3.Text;
                        Parametro.OrdemServico.Descricao_Obs1 = txt_Descricao_Obs1.Text;
                        Parametro.OrdemServico.Descricao_Obs2 = txt_Descricao_Obs2.Text;
                        Parametro.OrdemServico.Imprime_OS_Equip = ck_Imprime_OS_Equip.Checked;

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region CADASTRO PERSONALIZADO
                    case Tipo_Parametro.Cadastro_Personalizado:
                        Parametro.Tipo = 8;

                        Parametro.CadastroPersonalizado = new DTO_Parametro_CadastroPersonalizado();

                        Parametro.CadastroPersonalizado.ClienteDescricao1 = txt_ClienteDescricao1.Text;
                        Parametro.CadastroPersonalizado.ClienteDescricao2 = txt_ClienteDescricao2.Text;
                        Parametro.CadastroPersonalizado.ClienteDescricao3 = txt_ClienteDescricao3.Text;

                        Parametro.CadastroPersonalizado.EmpresaDescricao1 = txt_EmpresaDescricao1.Text;
                        Parametro.CadastroPersonalizado.EmpresaDescricao2 = txt_EmpresaDescricao2.Text;
                        Parametro.CadastroPersonalizado.EmpresaDescricao3 = txt_EmpresaDescricao3.Text;

                        Parametro.CadastroPersonalizado.FornecedorDescricao1 = txt_FornecedorDescricao1.Text;
                        Parametro.CadastroPersonalizado.FornecedorDescricao2 = txt_FornecedorDescricao2.Text;
                        Parametro.CadastroPersonalizado.FornecedorDescricao3 = txt_FornecedorDescricao3.Text;

                        Parametro.CadastroPersonalizado.FuncionarioDescricao1 = txt_FuncionarioDescricao1.Text;
                        Parametro.CadastroPersonalizado.FuncionarioDescricao2 = txt_FuncionarioDescricao2.Text;
                        Parametro.CadastroPersonalizado.FuncionarioDescricao3 = txt_FuncionarioDescricao3.Text;

                        Parametro.CadastroPersonalizado.TransportadoraDescricao1 = txt_TransportadoraDescricao1.Text;
                        Parametro.CadastroPersonalizado.TransportadoraDescricao2 = txt_TransportadoraDescricao2.Text;
                        Parametro.CadastroPersonalizado.TransportadoraDescricao3 = txt_TransportadoraDescricao3.Text;

                        Parametro.CadastroPersonalizado.Info_Produto1 = txt_Info_Produto1.Text;
                        Parametro.CadastroPersonalizado.Info_Produto2 = txt_Info_Produto2.Text;

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region CONFIGURAÇÃO DE EMAIL
                    case Tipo_Parametro.Config_eMail:
                        Parametro.Tipo = 9;

                        Parametro.Config_Email = new DTO_Parametro_Config_Email();

                        Parametro.Config_Email.De = txt_De.Text;
                        Parametro.Config_Email.Email = txt_Email.Text;

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                    #endregion

                    #region PARAMETROS DE CADASTRO
                    case Tipo_Parametro.Parametro_Cadastro:
                        Parametro.Tipo = 10;

                        Parametro.Parametro_Cadastro = new DTO_Parametro_Cadastro();

                        Parametro.Parametro_Cadastro.Exibe_DuplicarProduto = Convert.ToBoolean(ck_Exibe_DuplicarProduto.Checked);
                        Parametro.Parametro_Cadastro.Somente_Maiusculo = Convert.ToBoolean(ck_Somente_Maiusculo.Checked);
                        Parametro.Parametro_Cadastro.Cadastro_PessoaPadrao = Convert.ToInt32(cb_Cadastro_PessoaPadrao.SelectedValue);
                        Parametro.Parametro_Cadastro.Endereco_Padrao = Convert.ToInt32(cb_Endereco_Padrao.SelectedValue);
                        Parametro.Parametro_Cadastro.Telefone_Padrao = Convert.ToInt32(cb_Telefone_Padrao.SelectedValue);
                        Parametro.Parametro_Cadastro.EntradaProduto = Convert.ToInt32(cb_EntradaProduto.SelectedValue);
                        Parametro.Parametro_Cadastro.Decimal_Produto_Quantidade = Convert.ToInt32(cb_Decimal_Produto_Quantidade.SelectedValue);
                        Parametro.Parametro_Cadastro.Decimal_Produto_Valor = Convert.ToInt32(cb_Decimal_Produto_Valor.SelectedValue);

                        BLL_Parametro.Grava(Parametro);

                        Pesquisa();
                        break;
                        #endregion

                }
                MessageBox.Show(util_msg.msg_Grava, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Parametro_Load(object sender, EventArgs e)
        {
            Inicia_Form();

            Pesquisa();
        }

        private void UI_Parametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Multa.Focused == true ||
                txt_Juros_Mes.Focused == true ||
                txt_AliquotaCreditoICMS.Focused == true ||
                txt_Limite_Desconto.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_DiasBloqueioVenda.Focused == true ||
                txt_HistoricoVenda.Focused == true ||
                txt_Qt_Dias_Pesquisa.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Email.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.Email(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_Multa_Leave(object sender, EventArgs e)
        {
            if (txt_Multa.Text.Trim() == string.Empty)
                txt_Multa.Text = "0";

            txt_Multa.Text = util_dados.ConfigNumDecimal(txt_Multa.Text, 2);
        }

        private void txt_Juros_Mes_Leave(object sender, EventArgs e)
        {
            if (txt_Juros_Mes.Text.Trim() == string.Empty)
                txt_Juros_Mes.Text = "0";

            txt_Juros_Mes.Text = util_dados.ConfigNumDecimal(txt_Juros_Mes.Text, 2);
        }

        private void txt_AliquotaCreditoICMS_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaCreditoICMS.Text.Trim() == string.Empty)
                txt_AliquotaCreditoICMS.Text = "0";

            txt_AliquotaCreditoICMS.Text = util_dados.ConfigNumDecimal(txt_AliquotaCreditoICMS.Text, 2);
        }

        private void txt_LimiteDesconto_Leave(object sender, EventArgs e)
        {
            if (txt_Limite_Desconto.Text.Trim() == string.Empty)
                txt_Limite_Desconto.Text = "0";

            txt_Limite_Desconto.Text = util_dados.ConfigNumDecimal(txt_Limite_Desconto.Text, 2);
        }
        #endregion

        #region COMBOBOX
        private void cb_ID_Usuario_Leave(object sender, EventArgs e)
        {
            util_dados.LimpaCampos(this, gb_Param_Usuario);
            Pesquisa();
        }

        private void cb_RegimeTributario_Leave(object sender, EventArgs e)
        {

        }

        private void cb_RegimeTributario_SelectedValueChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(cb_RegimeTributario.SelectedValue.ToString()) == 0)
                return;

            if (Convert.ToInt32(cb_RegimeTributario.SelectedValue) == 1)
                gb_NFe_SN.Enabled = Enabled;

            if (Convert.ToInt32(cb_RegimeTributario.SelectedValue) == 2)
                gb_NFe_SN.Enabled = false;
        }

        private void cb_TipoRede_SelectedValueChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(cb_TipoRede.SelectedValue.ToString()) == 1)
            {
                cb_TipoSeguranca.Enabled = false;
                txt_SenhaWIFI.Enabled = false;
            }
            else
            {
                cb_TipoSeguranca.Enabled = true;
                txt_SenhaWIFI.Enabled = true;
            }
        }

        private void ck_Venda_Fixa_logado_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Venda_Fixa_logado.Checked == true)
                ck_Comissao.Checked = true;
        }

        private void ck_Comissao_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Comissao.Checked == false)
                ck_Venda_Fixa_logado.Checked = false;
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_PlanoConta_Consulta frm = new UI_PlanoConta_Consulta();

            frm.ShowDialog();
            mk_Conta.Text = frm.Cod_Conta;
            CarregaConta();
        }

        private void bt_Trans_Valor_Click(object sender, EventArgs e)
        {
            mk_ContaTransValor.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_ContaTransValor.Text = txt_ID_Conta.Text;
        }

        private void bt_DevolucaoCheque_Click(object sender, EventArgs e)
        {
            mk_ContaDevolucaoCheque.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_ContaDevolucaoCheque.Text = txt_ID_Conta.Text;
        }

        private void bt_FatVenda_Click(object sender, EventArgs e)
        {
            mk_ContaFatVenda.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_ContaFaturaVenda.Text = txt_ID_Conta.Text;
        }

        private void bt_FatOS_Click(object sender, EventArgs e)
        {
            mk_ContaFatOS.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_ContaFaturaOS.Text = txt_ID_Conta.Text;
        }

        private void bt_FaturaCompra_Click(object sender, EventArgs e)
        {
            mk_ContaFatCompra.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_ContaFaturaCompra.Text = txt_ID_Conta.Text;
        }

        private void bt_ContaDevolucaoVenda_Click(object sender, EventArgs e)
        {
            mk_ContaDevolucaoVenda.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_ContaDevolucaoVenda.Text = txt_ID_Conta.Text;
        }

        private void bt_RectoDiverso_Click(object sender, EventArgs e)
        {
            mk_Conta_RectoDiverso.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_Conta_RectoDiverso.Text = txt_ID_Conta.Text;
        }

        private void bt_PagtoDiverso_Click(object sender, EventArgs e)
        {
            mk_Conta_PagtoDiverso.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_Conta_PagtoDiverso.Text = txt_ID_Conta.Text;
        }

        private void bt_CobrancaBancaria_Click(object sender, EventArgs e)
        {
            mk_Conta_CobrancaBancaria.Text = mk_Conta.Text.Replace(" ", "0");
            txt_ID_Conta_CobrancaBancaria.Text = txt_ID_Conta.Text;
        }

        private void bt_Pesquisa_CaminhoNFe_Click(object sender, EventArgs e)
        {
            try
            {
                Pesquisa_Caminho.ShowDialog();
                int TamanhoCaminho = Pesquisa_Caminho.SelectedPath.Length;
                string Barra = (Pesquisa_Caminho.SelectedPath.Substring(TamanhoCaminho - 1));

                if (Barra == @"\")
                    txt_Caminho_NFe.Text = Pesquisa_Caminho.SelectedPath;
                else
                    txt_Caminho_NFe.Text = Pesquisa_Caminho.SelectedPath + @"\";
            }
            catch (Exception)
            {
            }
        }

        private void bt_PesquisaCertificado_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_CertificadoDigital CertificadoDigital = new DTO_CertificadoDigital();
                NFe_CertificadoDigital _Cert = new NFe_CertificadoDigital();

                CertificadoDigital = _Cert.Seleciona_Certificado();
                if (CertificadoDigital.Certificado != null)
                    txt_Certificado_NFe.Text = CertificadoDigital.ResumoCertificado;
                else
                    txt_Certificado_NFe.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void bt_LogoEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisaImagem.Filter = "Image Files (*.jpg)|*.jpg";
                PesquisaImagem.ShowDialog();

                FileInfo tamanho = new FileInfo(PesquisaImagem.FileName);
                if (tamanho.Length > 250000)
                {
                    MessageBox.Show(util_msg.msg_ImagemGrande + (tamanho.Length / 1024) + " KB");
                    return;
                }

                string CaminhoImagem = PesquisaImagem.FileName;

                FileStream _Imagem = default(FileStream);
                StreamReader ConfigImagem = default(StreamReader);
                _Imagem = new FileStream(CaminhoImagem, FileMode.Open, FileAccess.Read, FileShare.Read);
                ConfigImagem = new StreamReader(_Imagem);
                byte[] arqByteArray = new byte[_Imagem.Length];
                _Imagem.Read(arqByteArray, 0, Convert.ToInt32(_Imagem.Length));

                BLL_Imagem = new BLL_Imagem();
                Imagem = new DTO_Imagem();
                Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Imagem.Tipo = 2;
                Imagem.Imagem = _Imagem;
                Imagem.ArqByteArray = arqByteArray;

                BLL_Imagem.Grava(Imagem);

                DataTable _DT = new DataTable();
                _DT = BLL_Imagem.Busca(Imagem);

                byte[] bits = (byte[])(_DT.Rows[0][0]);
                MemoryStream memorybits = new MemoryStream(bits);
                Bitmap ImagemConvertida = new Bitmap(memorybits);
                img_ImagemSistema.Image = ImagemConvertida;

                MessageBox.Show(util_msg.msg_Grava, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_LogoRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisaImagem.Filter = "Image Files (*.jpg)|*.jpg";
                PesquisaImagem.ShowDialog();

                FileInfo tamanho = new FileInfo(PesquisaImagem.FileName);
                if (tamanho.Length > 100000)
                {
                    MessageBox.Show(util_msg.msg_ImagemGrande + (tamanho.Length / 1024) + " KB");
                    return;
                }

                string CaminhoImagem = PesquisaImagem.FileName;

                FileStream _Imagem = default(FileStream);
                StreamReader ConfigImagem = default(StreamReader);
                _Imagem = new FileStream(CaminhoImagem, FileMode.Open, FileAccess.Read, FileShare.Read);
                ConfigImagem = new StreamReader(_Imagem);
                byte[] arqByteArray = new byte[_Imagem.Length];
                _Imagem.Read(arqByteArray, 0, Convert.ToInt32(_Imagem.Length));

                BLL_Imagem = new BLL_Imagem();
                Imagem = new DTO_Imagem();
                Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Imagem.Tipo = 1;
                Imagem.Imagem = _Imagem;
                Imagem.ArqByteArray = arqByteArray;

                BLL_Imagem.Grava(Imagem);

                DataTable _DT = new DataTable();

                _DT = BLL_Imagem.Busca(Imagem);

                byte[] bits = (byte[])(_DT.Rows[0][0]);
                MemoryStream memorybits = new MemoryStream(bits);
                Bitmap ImagemConvertida = new Bitmap(memorybits);
                Img_Relatorio.Image = ImagemConvertida;

                MessageBox.Show(util_msg.msg_Grava, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_SAT_Ativa_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ExecutaFuncaoSAT, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                AtivarSAT();
        }

        private void bt_AssociarAssinatura_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ExecutaFuncaoSAT, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                AssociarAssinaturaSAT();
        }

        private void bt_ConfigurarRedeSAT_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_ConfigRede, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                ConfiguraRedeSAT();
        }

        private void bt_BloquearSAT_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ExecutaFuncaoSAT, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                Bloqueia_DesbloqueiaSAT("BLOQUEAR");
        }

        private void bt_DesbloquearSAT_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ExecutaFuncaoSAT, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                Bloqueia_DesbloqueiaSAT("DESBLOQUEAR");
        }

        private void bt_ConsultarSAT_Click(object sender, EventArgs e)
        {
            ConsultaSAT();
        }

        private void bt_ConsultarStatusOperacional_Click(object sender, EventArgs e)
        {
            ConsultaStatusOperacional();
        }

        private void bt_AtualizaSAT_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ExecutaFuncaoSAT, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                AtualizarSoftwareSAT();
        }

        private void bt_TesteFimAFim_Click(object sender, EventArgs e)
        {
            TesteFimAFim();
        }

        private void bt_OS_PadraoOficina_Click(object sender, EventArgs e)
        {
            txt_Descricao_Info1.Text = "MODELO";
            txt_Descricao_Info2.Text = "COR";
            txt_Descricao_Info3.Text = "PLACA";

            txt_Descricao_Obs1.Text = "KM";
            txt_Descricao_Obs2.Text = "DETALHES";
        }

        private void bt_OS_PadraoInformatica_Click(object sender, EventArgs e)
        {
            txt_Descricao_Info1.Text = "MODELO";
            txt_Descricao_Info2.Text = "Nº SÉRIE";
            txt_Descricao_Info3.Text = "IDENTIFICADOR";

            txt_Descricao_Obs1.Text = "INFORMAÇÕES ADICIONAIS";
            txt_Descricao_Obs2.Text = "DETALHES";
        }

        private void bt_OS_PadraoTecnica_Click(object sender, EventArgs e)
        {
            txt_Descricao_Info1.Text = "MODELO";
            txt_Descricao_Info2.Text = "Nº SÉRIE";
            txt_Descricao_Info3.Text = "IDENTIFICADOR";

            txt_Descricao_Obs1.Text = "INFORMAÇÕES ADICIONAIS";
            txt_Descricao_Obs2.Text = "DETALHES";
        }

        private void bt_LogSAT_Click(object sender, EventArgs e)
        {
            Exibe_LogSAT();
        }
        #endregion

        #region MASKEDBOX
        private void mk_Conta_TextChanged(object sender, EventArgs e)
        {
            CarregaConta();
        }
        #endregion

        #region RADIOBUTTON
        private void rb_DHCP_CheckedChanged(object sender, EventArgs e)
        {
            gb_IP.Enabled = false;
        }

        private void rb_IPFIXO_CheckedChanged(object sender, EventArgs e)
        {
            gb_IP.Enabled = true;
        }
        #endregion
    }
}
