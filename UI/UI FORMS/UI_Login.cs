using Microsoft.Win32;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UI.UI_FORMS;
using Sistema.UTIL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_Login : Form
    {
        public UI_Login()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE

        private BLL_Sistema BLL_Sistema;
        private BLL_Backup BLL_Backup;
        private BLL_Pessoa BLL_Pessoa;
        private BLL_Usuario BLL_Usuario;
        private BLL_Parametro BLL_Parametro;

        #endregion VARIAVEIS DE CLASSE

        #region ESTRUTURA

        private DTO_Sistema Sistema;
        private DTO_Pessoa Pessoa;
        private DTO_Usuario Usuario;
        private DTO_Log Log;
        private DTO_Parametro Parametro;

        #endregion ESTRUTURA

        #region ROTINAS

        private void Inicia_Form()
        {
            try
            {
                this.Text = "Bem - vindo ao Clever Software";

                RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);
                RegKey = RegKey.CreateSubKey("SystemSoft");//CRIA SUBCHAVE
                RegKey.SetValue("Versao", Parametro_Sistema.Versao.Replace(".", ""));
                RegKey.Close();

                Lista_Empresa();

                Verifica_Data_Sistema();

                cb_Empresa.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Carrega_Parametro_Sistema()
        {
            string aux = string.Empty;

            DataTable _DT;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            BLL_Parametro = new BLL_Parametro();
            Parametro = new DTO_Parametro();
            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            #region INFORMAÇÕES DA EMPRESA

            _DT = new DataTable();
            Pessoa.TipoPessoa = 2;
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT = BLL_Pessoa.Busca(Pessoa);

            if (_DT.Rows.Count == 0)
                aux += "EMPRESA\n";
            else
            {
                Parametro_Empresa.Razao_Social_Empresa = _DT.Rows[0]["Descricao"].ToString();
                Parametro_Empresa.CNPJ = _DT.Rows[0]["CNPJ_CPF"].ToString();
                Parametro_Empresa.IE = _DT.Rows[0]["IE_RG"].ToString();
            }

            #endregion INFORMAÇÕES DA EMPRESA

            #region PARAMETRO FINANCEIRO

            Parametro.Tipo = 1;

            _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count == 0)
                aux += "FINANCEIRO\n";
            else
            {
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

            #endregion PARAMETRO FINANCEIRO

            #region PARAMETRO DE VENDAS

            Parametro.Tipo = 2;

            _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count == 0)
                aux += "VENDAS\n";
            else
            {
                Parametro_Venda.DiasBloqueioVenda = Convert.ToInt32(_DT.Rows[0]["DiasBloqueioVenda"]);
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

            #endregion PARAMETRO DE VENDAS

            #region NF-e NFC-e

            Parametro.Tipo = 5;

            _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count == 0)
                aux += "NF-e / NFC-e\n";
            else
            {
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

            #endregion NF-e NFC-e

            #region CF-e SAT

            Parametro.Tipo = 6;

            _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count == 0)
                aux += "CF-e SAT\n";
            else
            {
                Parametro_NFe_NFC_SAT.TipoEquipamentoSAT = util_dados.Verifica_int(_DT.Rows[0]["TipoEquipamentoSAT"].ToString());
            }

            #endregion CF-e SAT

            #region ORDEM DE SERVIÇO

            Parametro.Tipo = 7;

            _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count == 0)
                aux += "ORDEM DE SERVIÇO\n";
            else
            {
                Parametro_OrdemServico.Descricao_Info1 = _DT.Rows[0]["Descricao_Info1"].ToString();
                Parametro_OrdemServico.Descricao_Info2 = _DT.Rows[0]["Descricao_Info2"].ToString();
                Parametro_OrdemServico.Descricao_Info3 = _DT.Rows[0]["Descricao_Info3"].ToString();
                Parametro_OrdemServico.Descricao_Obs1 = _DT.Rows[0]["Descricao_Obs1"].ToString();
                Parametro_OrdemServico.Descricao_Obs2 = _DT.Rows[0]["Descricao_Obs2"].ToString();
                Parametro_OrdemServico.Imprime_OS_Equipamento = Convert.ToBoolean(_DT.Rows[0]["Imprime_OS_Equip"]);
            }

            #endregion ORDEM DE SERVIÇO

            #region CADASTRO PERSONALIZADOS

            Parametro.Tipo = 8;

            _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count == 0)
                aux += "CADASTRO PERSONALIZADO\n";
            else
            {
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

            #endregion CADASTRO PERSONALIZADOS

            #region PARAMETROS DE CADASTRO

            Parametro.Tipo = 10;

            _DT = new DataTable();

            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count == 0)
                aux += "PARÂMETROS DE CADASTRO\n";
            else
            {
                Parametro_Cadastro.Exibe_DuplicarProduto = Convert.ToBoolean(_DT.Rows[0]["Exibe_DuplicarProduto"]);
                Parametro_Cadastro.Somente_Maiusculo = Convert.ToBoolean(_DT.Rows[0]["Somente_Maiusculo"]);
                Parametro_Cadastro.Cadastro_PessoaPadrao = Convert.ToInt32(_DT.Rows[0]["Cadastro_PessoaPadrao"]);
                Parametro_Cadastro.Endereco_Padrao = Convert.ToInt32(_DT.Rows[0]["Endereco_Padrao"]);
                Parametro_Cadastro.Telefone_Padrao = Convert.ToInt32(_DT.Rows[0]["Telefone_Padrao"]);
                Parametro_Cadastro.EntradaProduto = Convert.ToInt32(_DT.Rows[0]["EntradaProduto"]);
                Parametro_Cadastro.Decimal_Produto_Quantidade = Convert.ToInt32(_DT.Rows[0]["Decimal_Produto_Quantidade"]);
                Parametro_Cadastro.Decimal_Produto_Valor = Convert.ToInt32(_DT.Rows[0]["Decimal_Produto_Valor"]);
            }

            #endregion PARAMETROS DE CADASTRO

            if (aux != string.Empty)
                MessageBox.Show(util_msg.msg_ParamNaoConfigurado + aux, this.Text);
        }

        private void Carrega_Parametro_Usuario()
        {
            try
            {
                DataTable _DT = new DataTable();

                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();

                Usuario.ID = Parametro_Usuario.ID_Usuario_Ativo;

                _DT = BLL_Usuario.Busca_Parametros(Usuario);

                if (_DT.Rows.Count > 0)
                {
                    Parametro_Usuario.Venda_Restrita = Convert.ToBoolean(_DT.Rows[0]["Venda_Restrita"]);
                    Parametro_Usuario.Libera_Desconto = Convert.ToBoolean(_DT.Rows[0]["Libera_Desconto"]);
                    Parametro_Usuario.Venda_Fixa_logado = Convert.ToBoolean(_DT.Rows[0]["Venda_Fixa_logado"]);
                    Parametro_Usuario.Permite_Faturar = Convert.ToBoolean(_DT.Rows[0]["Permite_Faturar"]);
                    Parametro_Usuario.Permite_AterarFaturado = Convert.ToBoolean(_DT.Rows[0]["Permite_AterarFaturado"]);
                    Parametro_Usuario.Visualiza_ResumoVenda = Convert.ToBoolean(_DT.Rows[0]["Visualiza_ResumoVenda"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_ParamNaoConfigurado + ex.Message, this.Text);
            }
        }

        public void Exibe_Empresa()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = 2;
            DataTable _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID_Empresa", cb_Empresa);
            cb_Empresa.SelectedIndex = 0;
        }

        public void Atualizacao_Sistema()
        {
            string Versao_Servidor = string.Empty;

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);

            BLL_Sistema = new BLL_Sistema();
            Sistema = new DTO_Sistema();

            DataTable _DT = new DataTable();

            Sistema.ID = 1;
            _DT = BLL_Sistema.Busca(Sistema);

            #region ATUALIZA BANCO DE DADOS

            BLL_Sistema = new BLL_Sistema();
            Sistema = new DTO_Sistema();

            int getUltimaVersaoDB = BLL_Sistema.VersaoBD();
            int getUltmaVersaoSistema = BLL_Sistema.VersaoSistema();
            int VersaoBD = Convert.ToInt32(_DT.Rows[0]["BD"]);
            int VersaoSistema = Convert.ToInt32(_DT.Rows[0]["Versao"]);

            Sistema.VersaoAtualBanco = VersaoBD;
            Sistema.VersaoAtualSistema = VersaoSistema;

            try
            {
                if (VersaoBD < getUltimaVersaoDB)
                    BLL_Sistema.Atualiza(Sistema);

                if (VersaoSistema < getUltmaVersaoSistema)
                    BLL_Sistema.Grava(Sistema);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex);
                Application.Exit();
            }

            #endregion ATUALIZA BANCO DE DADOS
        }

        private void Verifica_Data_Sistema()
        {
            string teste = Convert.ToDateTime("01/01/1990").ToString();
            if (teste.IndexOf("01/01/1990") == -1)
            {
                MessageBox.Show("Formato de Data Inválido!\nAltere para o Seguinte Padrão: dd/MM/aaaa.");
                Application.Exit();
            }
        }

        private void Lista_Empresa()
        {
            DataTable _DT = new DataTable();

            _DT.Columns.Add("ID", typeof(int));
            _DT.Columns.Add("Descricao", typeof(string));

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);
            for (int i = 1; i <= 50; i++)
                try
                {
                    if (util_dados.Verifica_int(util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "ID").ToString())) > 0)
                    {
                        _DT.Rows.Add();
                        _DT.Rows[_DT.Rows.Count - 1]["ID"] = i;
                        _DT.Rows[_DT.Rows.Count - 1]["Descricao"] = RegKey.OpenSubKey("SystemSoft", true).GetValue(i + "Empresa").ToString();

                        _DT.AcceptChanges();
                    }
                }
                catch (Exception)
                {
                }
            _DT.DefaultView.Sort = "Descricao Asc";
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Empresa);
        }

        private void Busca_Empresa(int _ID_Empresa)
        {
            try
            {
                RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software", true);

                util_Param.Descricao_Empresa = RegKey.OpenSubKey("SystemSoft", true).GetValue(_ID_Empresa + "Empresa").ToString();

                Parametro_Empresa.ID_Empresa_Ativa = Convert.ToInt32(util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(_ID_Empresa + "ID").ToString()));

                switch (util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(_ID_Empresa + "TipoSistema").ToString()))
                {
                    case "COMERCIAL":
                        Parametro_Empresa.Tipo_Sistema = Tipo_Sistema.Comercial;
                        break;

                    case "IMOBILIARIA":
                        Parametro_Empresa.Tipo_Sistema = Tipo_Sistema.Imobiliaria;
                        break;
                }

                Parametro_Sistema.Caminho_Sistema = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("Sistema").ToString()) + @"\";
                Parametro_Sistema.Caminho_Atualizacao = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue("ServidorAtualizacao").ToString()) + @"\";
                Parametro_Sistema.Caminho_Relatorio = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(_ID_Empresa + "Relatorio").ToString()) + @"\";

                SQL.Servidor = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(_ID_Empresa + "Servidor").ToString());
                SQL.Banco = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(_ID_Empresa + "Banco").ToString());
                SQL.Senha = util_dados.Decriptografa(RegKey.OpenSubKey("SystemSoft", true).GetValue(_ID_Empresa + "Acesso").ToString());

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("NFe") != null)
                    Parametro_Sistema.Terminal_NFe = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("NFe"));

                if (RegKey.OpenSubKey("SystemSoft", true).GetValue("CFe") != null)
                    Parametro_Sistema.Terminal_CFe = Convert.ToBoolean(RegKey.OpenSubKey("SystemSoft", true).GetValue("CFe"));

                try
                {
                    BLL_Sistema = new BLL_Sistema();
                    BLL_Sistema.Verifica_Conexao();
                }
                catch (Exception)
                {
                    throw new Exception(util_msg.msg_Erro_BD);
                }

                Atualizacao_Sistema();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Inicia_Acesso()
        {
            try
            {
                UI_MDI frm_MDI;

                if (txt_Usuario.Text == Parametro_Sistema.Usuario_Config &&
                    txt_Senha.Text == Parametro_Sistema.Acesso_Config)
                {
                    Busca_Empresa(util_dados.Verifica_int(cb_Empresa.SelectedValue.ToString()));

                    Parametro_Sistema.Usuario_Suporte = true;

                    Carrega_Parametro_Sistema();

                    Parametro_Usuario.ID_Usuario_Ativo = 0;

                    frm_MDI = new UI_MDI();
                    frm_MDI.Show();

                    txt_Usuario.Clear();
                    txt_Senha.Clear();
                    this.Hide();
                    return;
                }

                if (string.IsNullOrEmpty(txt_Usuario.Text) ||
                    string.IsNullOrEmpty(txt_Senha.Text))
                {
                    MessageBox.Show(util_msg.msg_Erro_Usuario_Senha_Nulo, this.Text);
                    txt_Usuario.Focus();
                    return;
                }
                if (cb_Empresa.Items.Count == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumEmpresa, this.Text);
                    cb_Empresa.Focus();
                    return;
                }
                if (util_dados.Verifica_int(cb_Empresa.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumEmpresaSelecionada, this.Text);
                    cb_Empresa.Focus();
                    return;
                }

                Busca_Empresa(util_dados.Verifica_int(cb_Empresa.SelectedValue.ToString()));

                Carrega_Parametro_Sistema();

                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();
                Log = new DTO_Log();

                Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Usuario.UsuarioSistema = true;
                Usuario.Descricao = txt_Usuario.Text;
                Usuario.SenhaSistema = txt_Senha.Text;

                Usuario.Filtra_Comissao = false;
                Usuario.Filtra_Situacao = true;
                Usuario.Situacao = true;

                DataTable _DT = new DataTable();

                _DT = BLL_Usuario.Busca_Sistema(Usuario);

                if (_DT.Rows.Count == 0)
                {
                    Parametro_Usuario.ID_Usuario_Ativo = 0;
                    MessageBox.Show(util_msg.msg_Erro_Usuario_Senha_Invalido, this.Text);
                    txt_Usuario.Focus();
                    txt_Usuario.SelectAll();
                    return;
                }

                Parametro_Usuario.ID_Usuario_Ativo = Convert.ToInt32(_DT.Rows[0]["ID"]);
                Parametro_Usuario.Descricao_UsuarioAtivo = _DT.Rows[0]["Descricao"].ToString();

                Parametro_Empresa.DescricaoEmpresa = cb_Empresa.Text;

                Carrega_Parametro_Usuario();

                UI_MDI a = new UI_MDI();
                a.Show();

                this.Hide();

                txt_Usuario.Clear();
                txt_Senha.Clear();

                Log.ID_Usuario = Parametro_Usuario.ID_Usuario_Ativo;
                Log.ID_Empresa = Convert.ToInt32(cb_Empresa.SelectedValue);
                Log.Data = DateTime.Now;
                Log.Terminal = Environment.MachineName + @"\" + Environment.UserName;

                BLL_Usuario.Grava_Log(Log);

                UI_UsuarioConectado usuarioConectado = new UI_UsuarioConectado();
                usuarioConectado.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        #endregion ROTINAS

        #region FORM

        private void UI_Login_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Application.Exit();
            }
        }

        private void UI_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UI_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                UI_ConfiguraAcesso UI_ConfiguraAcesso = new UI_ConfiguraAcesso();
                UI_ConfiguraAcesso.ShowDialog();
            }
        }

        #endregion FORM

        #region BUTTON

        private void bt_Entrar_Click(object sender, EventArgs e)
        {
            Inicia_Acesso();
        }

        private void bt_Cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion BUTTON

        #region TEXTBOX

        private void txt_Senha_Enter(object sender, EventArgs e)
        {
            txt_Senha.SelectAll();
        }

        private void txt_Senha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Inicia_Acesso();
            }
        }

        #endregion TEXTBOX
    }
}