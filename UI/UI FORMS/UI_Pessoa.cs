using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.BLL;
using System.Globalization;
using System.Diagnostics;

namespace Sistema.UI
{
    public partial class UI_Pessoa : Sistema.UI.UI_Modelo
    {
        public UI_Pessoa()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        BLL_Municipio BLL_Municipio;
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        BLL_Parametro BLL_Parametro;
        BLL_Produto BLL_Produto;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;

        DateTime ValidaData;

        List<DTO_Pessoa_Endereco> lst_Pessoa_Endereco;
        List<DTO_Pessoa_Telefone> lst_Pessoa_Telefone;
        List<DTO_Pessoa_Email> lst_Pessoa_Email;
        List<DTO_Pessoa_EmpresaResponsavel> lst_Pessoa_EmpresaResponsavel;

        bool Edita_Endereco = false;
        int ID_Endereco = 0;

        bool Edita_Telefone = false;
        int ID_Telefone = 0;

        bool Edita_Email = false;
        int ID_Email = 0;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_Municipio Municipio;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pessoa_Email Email;
        DTO_Pessoa_EmpresaResponsavel Pessoa_EmpresaResponsavel;
        DTO_Usuario Usuario;
        DTO_Parametro Parametro;
        DTO_Produto Produto;
        #endregion

        #region PROPRIEDADES
        public int TipoPessoa { get; set; }        
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            CarregaCB();

            dg_Endereco.AutoGenerateColumns = false;
            dg_Telefone.AutoGenerateColumns = false;
            dg_Email.AutoGenerateColumns = false;

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            AtualizaComboPais();
            AtualizaComboEstado();

            #region CONFIGURA GRID
            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "NOME/RAZÃO SOCIAL";
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Fantasia = new DataGridViewTextBoxColumn();
            col_Fantasia.DataPropertyName = "NomeFantasia";
            col_Fantasia.HeaderText = "NOME FANTASIA";
            col_Fantasia.Width = 250;
            DG.Columns.Add(col_Fantasia);

            DataGridViewTextBoxColumn col_CPF_CNPJ = new DataGridViewTextBoxColumn();
            col_CPF_CNPJ.DataPropertyName = "CNPJ_CPF";
            col_CPF_CNPJ.HeaderText = "CPF / CNPJ";
            col_CPF_CNPJ.Width = 150;
            DG.Columns.Add(col_CPF_CNPJ);

            switch (TipoPessoa)
            {
                case 4: //FUNCIONÁRIO

                    DataGridViewTextBoxColumn col_Matricula = new DataGridViewTextBoxColumn();
                    col_Matricula.DataPropertyName = "Matricula";
                    col_Matricula.HeaderText = "MATRICULA";
                    col_Matricula.Width = 150;
                    DG.Columns.Add(col_Matricula);

                    break;

              
            }
           

            #endregion

            Limpa_Campo();

            Configura_Pessoa();
        }

        private void Configura_Pessoa()
        {
            switch (TipoPessoa)
            {
                case 1://CLIENTE
                    this.Text = "CADASTRO DE CLIENTE";

                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;

                    lb_InfoVenda.Visible = true;
                    txt_Informacao_Venda.Visible = true;

                    lb_Limite.Visible = true;
                    txt_Limite.Visible = true;

                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.ClienteDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.ClienteDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.ClienteDescricao3;
                    lb_Vendedor.Text = Parametro_Venda.Descricao_Comissao;

                    tabControl1.TabPages.Remove(tabPage6);
                    break;

                case 2://EMPRESA
                    this.Text = "CADASTRO DE EMPRESA";

                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;
                    lb_Vendedor.Visible = false;
                    cb_ID_Usuario.Visible = false;
                    ck_MultiEmpresa.Visible = false;
                    lb_Dia_Faturamento.Visible = false;
                    txt_DiaFaturamento.Visible = false;

                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.EmpresaDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.EmpresaDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.EmpresaDescricao3;
                    lb_Mensalidade.Visible = false;
                    txt_ValorMensalidade.Visible = false;
                    lb_DiaVencimento.Visible = false;
                    txt_DiaFaturamento.Visible = false;

                    tabPage6.Text = "RESPONSÁVEIS";

                    cb_ID_Usuario.Tag = "";
                    break;

                case 3://FORNECEDOR
                    this.Text = "CADASTRO DE FORNECEDOR";

                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;
                    lb_Vendedor.Visible = false;
                    cb_ID_Usuario.Visible = false;

                    lb_InfoVenda.Visible = true;
                    txt_Informacao_Venda.Visible = true;

                    lb_Limite.Visible = true;
                    txt_Limite.Visible = true;

                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.FornecedorDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.FornecedorDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.FornecedorDescricao3;

                    tabControl1.TabPages.Remove(tabPage6);

                    cb_ID_Usuario.Tag = "";
                    break;

                case 4://FUNCIONÁRIO
                    this.Text = "CADASTRO DE FUNCIONÁRIO";
                    lb_Vendedor.Visible = false;
                    cb_ID_Usuario.Visible = false;
                    lb_CEI.Visible = false;
                    txt_CEI.Visible = false;
                    lb_IM.Visible = false;
                    txt_IM.Visible = false;
                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.FuncionarioDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.FuncionarioDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.FuncionarioDescricao3;

                    lb_InfoVenda.Visible = true;
                    txt_Informacao_Venda.Visible = true;

                    lbl_Matricula.Visible = true;
                    txt_Matricula.Visible = true;

                    lb_Limite.Visible = true;
                    txt_Limite.Visible = true;

                    lb_Mensalidade.Visible = false;
                    txt_ValorMensalidade.Visible = false;
                    lb_DiaVencimento.Visible = false;
                    txt_DiaFaturamento.Visible = false;
                    cb_TipoDocumento.SelectedValue = 2;
                    cb_TipoDocumento.Enabled = false;

                    tabControl1.TabPages.Remove(tabPage6);

                    cb_ID_Usuario.Tag = "";
                    txt_Referencia.Tag = "";
                    break;

                case 5://TRANSPORTADORA
                    this.Text = "CADASTRO DE TRANSPORTADORA";

                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;
                    lb_Vendedor.Visible = false;
                    cb_ID_Usuario.Visible = false;
                    lb_CEI.Visible = false;
                    txt_CEI.Visible = false;
                    lb_Dia_Faturamento.Visible = false;
                    txt_DiaFaturamento.Visible = false;

                    lb_InfoVenda.Visible = true;
                    txt_Informacao_Venda.Visible = true;

                    lb_Limite.Visible = true;
                    txt_Limite.Visible = true;

                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.TransportadoraDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.TransportadoraDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.TransportadoraDescricao3;

                    tabControl1.TabPages.Remove(tabPage6);

                    cb_ID_Usuario.Tag = "";
                    break;

                case 6://RESPONSÁVEIS
                    this.Text = "CADASTRO DE RESPONSÁVEL";
                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;
                    lb_IM.Visible = false;
                    txt_IM.Visible = false;
                    lb_Dia_Faturamento.Visible = false;
                    txt_DiaFaturamento.Visible = false;

                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.ClienteDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.ClienteDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.ClienteDescricao3;
                    lb_Vendedor.Text = Parametro_Venda.Descricao_Comissao;
                    cb_TipoDocumento.SelectedValue = 2;
                    cb_TipoDocumento.Enabled = false;

                    cb_ID_Usuario.Tag = "";
                    break;

                case 7://PROPRIETÁRIO
                    this.Text = "CADASTRO DE PROPRIETÁRIO";

                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;
                    lb_Dia_Faturamento.Visible = false;
                    txt_DiaFaturamento.Visible = false;
                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.ClienteDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.ClienteDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.ClienteDescricao3;
                    lb_Vendedor.Text = Parametro_Venda.Descricao_Comissao;

                    tabControl1.TabPages.Remove(tabPage6);
                    break;

                case 8://LOCATÁRIO
                    this.Text = "CADASTRO DE LOCATÁRIO";

                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;
                    lb_IM.Visible = false;
                    txt_IM.Visible = false;
                    lb_Dia_Faturamento.Visible = false;
                    txt_DiaFaturamento.Visible = false;
                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.ClienteDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.ClienteDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.ClienteDescricao3;
                    lb_Vendedor.Text = Parametro_Venda.Descricao_Comissao;

                    tabControl1.TabPages.Remove(tabPage6);
                    break;

                case 9://FIADOR
                    this.Text = "CADASTRO DE FIADOR";

                    lb_CarteiraProfissional.Visible = false;
                    txt_CarteiraProfissional.Visible = false;
                    lb_Pis.Visible = false;
                    txt_PIS.Visible = false;
                    lb_Salario.Visible = false;
                    txt_Salario.Visible = false;
                    lb_IM.Visible = false;
                    txt_IM.Visible = false;
                    lb_Dia_Faturamento.Visible = false;
                    txt_DiaFaturamento.Visible = false;
                    lb_Descricao1.Text = Parametro_CadastroPersonalizado.ClienteDescricao1;
                    lb_Descricao2.Text = Parametro_CadastroPersonalizado.ClienteDescricao2;
                    lb_Descricao3.Text = Parametro_CadastroPersonalizado.ClienteDescricao3;
                    lb_Vendedor.Text = Parametro_Venda.Descricao_Comissao;
                    cb_TipoDocumento.SelectedValue = 2;
                    cb_TipoDocumento.Enabled = false;

                    tabControl1.TabPages.Remove(tabPage6);
                    break;
            }
        }

        private void TipoDocumento(int intTipo)
        {
            //1 - CNPJ
            //2 = CPF
            if (intTipo == 1)
            {
                lb_NomeFantasia.Visible = true;
                txt_NomeFantasia.Visible = true;
                txt_CNPJ_CPF.MaxLength = 18;
                lb_Nascimento_Fundacao.Text = "Data de Fundação";
                lb_IM.Visible = true;
                txt_IM.Visible = true;
                lb_CEI.Visible = true;
                txt_CEI.Visible = true;
                lb_Descricao.Text = "Razão Social*";
                lb_Conjuge.Visible = false;
                txt_Conjuge.Visible = false;
                lb_Doc_Conjuge.Visible = false;
                txt_CPF_Conjuge.Visible = false;
                lb_RG_Conjuge.Visible = false;
                txt_RG_Conjuge.Visible = false;
                lb_ProfissaoConjuge.Visible = false;
                txt_Profissao_Conjuge.Visible = false;

                if (util_dados.Verifica_int(txt_ID.Text) == 0)
                {
                    txt_CNPJ_CPF.Text = "00.000.000/0000-00";
                    txt_IE_RG.Text = "0";
                }
            }
            else if (intTipo == 2)
            {
                lb_NomeFantasia.Visible = false;
                txt_NomeFantasia.Visible = false;
                txt_CNPJ_CPF.MaxLength = 14;
                lb_Nascimento_Fundacao.Text = "Nascimento";
                lb_IM.Visible = false;
                txt_IM.Visible = false;
                lb_CEI.Visible = false;
                txt_CEI.Visible = false;
                lb_Descricao.Text = "Nome*";
                lb_Conjuge.Visible = true;
                txt_Conjuge.Visible = true;
                lb_Doc_Conjuge.Visible = true;
                txt_CPF_Conjuge.Visible = true;
                lb_RG_Conjuge.Visible = true;
                txt_RG_Conjuge.Visible = true;
                lb_ProfissaoConjuge.Visible = true;
                txt_Profissao_Conjuge.Visible = true;

                if (util_dados.Verifica_int(txt_ID.Text) == 0)
                {
                    txt_CNPJ_CPF.Text = "000.000.000-00";
                    txt_IE_RG.Text = "0";
                }
            }
        }

        private void CarregaCB()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            DataTable _DT;
            switch (TipoPessoa)
            {
                case 1://CLIENTE 
                case 7://PROPRIETÁRIO
                case 8://LOCATÁRIO
                case 9://FIADOR
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Cliente);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 2://EMPRESA
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Empresa);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 3://FORNECEDOR
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Fornecedor);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 4://FUNCIONÁRIOS
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Funcionario);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 5://TRANSPORTADORA
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Transportadora);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 6://RESPONSAVEIS
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Cliente);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;
            }

            cb_ID_Grupo.SelectedIndex = -1;

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Endereco);
            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoEndereco);

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Telefone);
            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoTelefone);

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_eMail);
            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoEmail);

            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();

            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Comissao = true;
            Usuario.Comissao = true;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

            _DT = new DataTable();
            _DT = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Usuario);
            cb_ID_Usuario.SelectedIndex = -1;

            List<string> _lst_aux = new List<string>();
            _lst_aux.Add("1 - PESSOA JURÍDICA");
            _lst_aux.Add("2 - PESSOA FÍSICA");

            _DT = new DataTable();
            _DT = util_dados.CarregaComboDinamico(1, _lst_aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoDocumento);

            switch (TipoPessoa)
            {
                case 1://CLIENTE 
                case 7://PROPRIETÁRIO
                case 8://LOCATÁRIO
                case 9://FIADOR
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Cliente);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 2://EMPRESA
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Empresa);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 3://FORNECEDOR
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Fornecedor);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 4://FUNCIONÁRIOS
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Funcionario);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 5://TRANSPORTADORA
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Transportadora);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;

                case 6://RESPONSAVEIS
                    Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Cliente);
                    _DT = new DataTable();
                    _DT = BLL_Grupo.Busca(Grupo);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                    break;
            }
            switch (TipoPessoa)
            {
                case 2://EMPRESA
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Pessoa.TipoPessoa = 4;
                    Pessoa.FiltraSituacao = true;
                    Pessoa.Situacao = true;

                    _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
                    break;

                case 6://RESPONSAVEIS
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Pessoa.TipoPessoa = 1;
                    Pessoa.FiltraSituacao = true;
                    Pessoa.Situacao = true;

                    _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
                    break;
            }
        }

        private void AtualizaComboEstado()
        {
            try
            {
                if ((int)cb_Pais.SelectedValue > 0)
                {
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_Pais = Convert.ToInt32(cb_Pais.SelectedValue);

                    DataTable _DT = new DataTable();

                    _DT = BLL_Municipio.Busca_UF(Municipio);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID_UF", cb_UF);

                    if (Convert.ToInt32(cb_Pais.SelectedValue) == 1058)
                        cb_UF.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void AtualizaComboMunicipio()
        {
            try
            {
                if ((int)cb_UF.SelectedValue > 0)
                {
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_UF = Convert.ToInt32(cb_UF.SelectedValue);

                    DataTable _DT = new DataTable();

                    _DT = BLL_Municipio.Busca_Municipio(Municipio);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Municipio);

                    if (Convert.ToInt32(cb_Pais.SelectedValue) == 1058)
                        cb_Municipio.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void AtualizaComboPais()
        {
            BLL_Municipio = new BLL_Municipio();
            Municipio = new DTO_Municipio();

            DataTable _DT = new DataTable();

            _DT = BLL_Municipio.Busca_Pais(Municipio);
            util_dados.CarregaCombo(_DT, "Descricao", "ID_Pais", cb_Pais);
        }

        private void Consulta_CEP(string _CEP)
        {
            try
            {
                txt_Logradouro.Clear();
                txt_Bairro.Clear();
                cb_UF.SelectedIndex = -1;
                cb_Municipio.SelectedIndex = -1;
                txt_NumeroEndereco.Clear();
                txt_Complemento.Clear();

                DataSet DS = new DataSet();

                DS.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + _CEP.Replace("-", "").Trim() + "&formato=xml");

                if (DS != null)
                {

                    string _Resultado = DS.Tables[0].Rows[0]["resultado"].ToString();

                    switch (_Resultado)
                    {
                        case "1":
                            txt_Logradouro.Text = DS.Tables[0].Rows[0]["tipo_logradouro"].ToString().ToUpper() + " " + DS.Tables[0].Rows[0]["logradouro"].ToString().ToUpper();
                            txt_Bairro.Text = DS.Tables[0].Rows[0]["bairro"].ToString().ToUpper();
                            cb_UF.SelectedValue = util_dados.Retorna_ID_UF(DS.Tables[0].Rows[0]["uf"].ToString());
                            cb_Municipio.Text = DS.Tables[0].Rows[0]["cidade"].ToString().ToUpper();

                            txt_NumeroEndereco.Focus();
                            break;

                        case "0":
                        case "2":
                            MessageBox.Show(util_msg.msg_CEP_NaoEncontrado);
                            txt_Logradouro.Focus();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_CEP_NaoEncontrado + "\n" + ex.Message);
            }
        }

        private void Limpa_Campo()
        {
            cb_Pais.SelectedValue = 1058;

            cb_TipoEndereco.SelectedIndex = 0;
            cb_TipoTelefone.SelectedIndex = 0;
            cb_TipoEmail.SelectedIndex = 0;

            ck_Situacao.Checked = true;
            ck_PrincipalEndereco.Checked = true;
            ck_PrincipalTelefone.Checked = true;
            ck_PrincipalEmail.Checked = true;

            switch (TipoPessoa)
            {
                case 1://CLIENTE    
                    cb_TipoDocumento.SelectedValue = Parametro_Cadastro.Cadastro_PessoaPadrao;
                    break;
                case 2://EMPRESA
                case 3://FORNECEDOR
                case 5://TRANSPORTADORA
                case 7://PROPRIETÁRIO
                    cb_TipoDocumento.SelectedValue = 1;
                    break;

                case 4://FUNCIONÁRIO
                case 6://RESPONSÁVEIS
                case 9://FIADOR
                    cb_TipoDocumento.SelectedValue = 2;
                    break;
            }

            mk_Cadastro.Text = Convert.ToString(DateTime.Now);
            mk_Nascimento_Fundacao.Text = "01011990";
            txt_DiaFaturamento.Text = "1";
            txt_Salario.Text = "0,00";
            txt_Limite.Text = "0,00";
            txt_ValorMensalidade.Text = "0,00";

            txt_Descricao.Focus();

            tabctl.SelectedTab = TabPage1;
            tabControl1.SelectedTab = tabPage3;
        }

        private void Carrega_Endereco(List<DTO_Pessoa_Endereco> _lst_Endereco)
        {
            dg_Endereco.Rows.Clear();

            for (int i = 0; i <= _lst_Endereco.Count - 1; i++)
            {
                dg_Endereco.Rows.Add();
                dg_Endereco.Rows[i].Cells["col_EnderecoPrincipal"].Value = _lst_Endereco[i].Principal;
                dg_Endereco.Rows[i].Cells["col_EnderecoTipo"].Value = _lst_Endereco[i].DescricaoTipo;
                dg_Endereco.Rows[i].Cells["col_Logradouro"].Value = _lst_Endereco[i].Logradouro;
                dg_Endereco.Rows[i].Cells["col_EnderecoNumero"].Value = _lst_Endereco[i].Numero;
                dg_Endereco.Rows[i].Cells["col_Complemento"].Value = _lst_Endereco[i].Complemento;
                dg_Endereco.Rows[i].Cells["col_Bairro"].Value = _lst_Endereco[i].Bairro;
                dg_Endereco.Rows[i].Cells["col_CEP"].Value = _lst_Endereco[i].CEP;
                dg_Endereco.Rows[i].Cells["col_Municipio"].Value = _lst_Endereco[i].Descricao_Municipio;
            }

            dg_Endereco.RefreshEdit();
        }

        private void Carrega_Telefone(List<DTO_Pessoa_Telefone> _lst_Telefone)
        {
            dg_Telefone.Rows.Clear();

            for (int i = 0; i <= _lst_Telefone.Count - 1; i++)
            {
                dg_Telefone.Rows.Add();
                dg_Telefone.Rows[i].Cells["col_TelefonePrincipal"].Value = _lst_Telefone[i].Principal;
                dg_Telefone.Rows[i].Cells["col_TelefoneTipo"].Value = _lst_Telefone[i].DescricaoTipo;
                dg_Telefone.Rows[i].Cells["col_DDD"].Value = _lst_Telefone[i].DDD;
                dg_Telefone.Rows[i].Cells["col_TelefoneNumero"].Value = _lst_Telefone[i].Numero;
                dg_Telefone.Rows[i].Cells["col_TelefoneInformacao"].Value = _lst_Telefone[i].Informacao;
            }

            dg_Telefone.RefreshEdit();
        }

        private void Carrega_Email(List<DTO_Pessoa_Email> _lst_Email)
        {
            dg_Email.Rows.Clear();

            for (int i = 0; i <= _lst_Email.Count - 1; i++)
            {
                dg_Email.Rows.Add();
                dg_Email.Rows[i].Cells["col_EmailPrincipal"].Value = _lst_Email[i].Principal;
                dg_Email.Rows[i].Cells["col_EmailTipo"].Value = _lst_Email[i].DescricaoTipo;
                dg_Email.Rows[i].Cells["col_Email"].Value = _lst_Email[i].Email;
                dg_Email.Rows[i].Cells["col_EmailInformacao"].Value = _lst_Email[i].Informacao;
            }

            dg_Email.RefreshEdit();
        }

        private void Carrega_EmpresaResponsavel(List<DTO_Pessoa_EmpresaResponsavel> _lst_EmpresaResponsavel)
        {
            dg_Pessoa.Rows.Clear();

            for (int i = 0; i <= _lst_EmpresaResponsavel.Count - 1; i++)
            {
                dg_Pessoa.Rows.Add();
                dg_Pessoa.Rows[i].Cells["col_PessoaDescricao"].Value = _lst_EmpresaResponsavel[i].Descricao;
            }

            dg_Pessoa.RefreshEdit();
        }

        private void Busca_Informacao(int _ID)
        {
            dg_Endereco.Rows.Clear();
            dg_Telefone.Rows.Clear();
            dg_Email.Rows.Clear();

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            DataTable _DT;

            lst_Pessoa_Endereco = new List<DTO_Pessoa_Endereco>();
            lst_Pessoa_Telefone = new List<DTO_Pessoa_Telefone>();
            lst_Pessoa_Email = new List<DTO_Pessoa_Email>();

            if (_ID > 0)
            {
                Pessoa.ID = _ID;
                Pessoa.TipoPessoa = TipoPessoa;

                #region BUSCA ENDEREÇO
                Endereco.Principal = false;
                Pessoa.Endereco.Add(Endereco);

                _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Endereco(Pessoa);

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Endereco = new DTO_Pessoa_Endereco();

                    Endereco.ID = Convert.ToInt32(_DT.Rows[i]["ID_Endereco"]);
                    Endereco.Principal = Convert.ToBoolean(_DT.Rows[i]["PrincipalEndereco"]);
                    Endereco.Tipo = Convert.ToInt32(_DT.Rows[i]["TipoEndereco"]);
                    Endereco.DescricaoTipo = _DT.Rows[i]["DescricaoTipoEndereco"].ToString();
                    Endereco.Logradouro = _DT.Rows[i]["Logradouro"].ToString();
                    Endereco.Numero = _DT.Rows[i]["NumeroEndereco"].ToString();
                    Endereco.Complemento = _DT.Rows[i]["Complemento"].ToString();
                    Endereco.Bairro = _DT.Rows[i]["Bairro"].ToString();
                    Endereco.ID_Pais = Convert.ToInt32(_DT.Rows[i]["ID_Pais"]);
                    Endereco.ID_UF = Convert.ToInt32(_DT.Rows[i]["ID_UF"]);
                    Endereco.ID_Municipio = Convert.ToInt32(_DT.Rows[i]["ID_Municipio"]);
                    Endereco.CEP = _DT.Rows[i]["CEP"].ToString();
                    Endereco.Descricao_Municipio = _DT.Rows[i]["Municipio_UF"].ToString();

                    lst_Pessoa_Endereco.Add(Endereco);
                }
                #endregion

                #region BUSCA TELEFONE
                _DT = new DataTable();
                Telefone.Principal = false;
                Pessoa.Telefone.Add(Telefone);

                _DT = BLL_Pessoa.Busca_Telefone(Pessoa);
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Telefone = new DTO_Pessoa_Telefone();

                    Telefone.ID = Convert.ToInt32(_DT.Rows[i]["ID_Telefone"]);
                    Telefone.Principal = Convert.ToBoolean(_DT.Rows[i]["PrincipalTelefone"]);
                    Telefone.DescricaoTipo = _DT.Rows[i]["DescricaoTipoTelefone"].ToString();
                    Telefone.DDD = _DT.Rows[i]["DDD"].ToString();
                    Telefone.Numero = _DT.Rows[i]["NumeroTelefone"].ToString();
                    Telefone.Informacao = _DT.Rows[i]["InformacaoTelefone"].ToString();
                    Telefone.Tipo = Convert.ToInt32(_DT.Rows[i]["TipoTelefone"]);

                    lst_Pessoa_Telefone.Add(Telefone);
                }
                #endregion

                #region BUSCA EMAIL
                Email.Principal = false;
                Pessoa.Email.Add(Email);

                _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Email(Pessoa);
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Email = new DTO_Pessoa_Email();

                    Email.ID = Convert.ToInt32(_DT.Rows[i]["ID_Email"]);
                    Email.Principal = Convert.ToBoolean(_DT.Rows[i]["PrincipalEmail"]);
                    Email.DescricaoTipo = _DT.Rows[i]["DescricaoTipoEmail"].ToString();
                    Email.Email = _DT.Rows[i]["Email"].ToString();
                    Email.Informacao = _DT.Rows[i]["InformacaoEmail"].ToString();
                    Email.Tipo = Convert.ToInt32(_DT.Rows[i]["TipoEmail"]);

                    lst_Pessoa_Email.Add(Email);
                }
                #endregion

                #region BUSCA INFORMAÇÕES ADICIONAIS
                _DT = new DataTable();
                _DT = BLL_Pessoa.Busca(Pessoa);

                if (TipoPessoa == 1)
                    cb_ID_Usuario.SelectedValue = util_dados.Verifica_int(_DT.Rows[0]["ID_Usuario"].ToString());

                if (TipoPessoa == 4)
                    txt_Salario.Text = _DT.Rows[0]["Salario"].ToString();

                txt_Referencia.Text = _DT.Rows[0]["Referencia"].ToString();
                txt_Descricao1.Text = _DT.Rows[0]["Descricao1"].ToString();
                txt_Descricao2.Text = _DT.Rows[0]["Descricao2"].ToString();
                txt_Descricao3.Text = _DT.Rows[0]["Descricao3"].ToString();

                txt_Conjuge.Text = _DT.Rows[0]["Conjuge"].ToString();
                txt_CPF_Conjuge.Text = _DT.Rows[0]["CPF_Conjuge"].ToString();
                txt_RG_Conjuge.Text = _DT.Rows[0]["RG_Conjuge"].ToString();
                txt_Profissao_Conjuge.Text = _DT.Rows[0]["Profissao_Conjuge"].ToString();
                txt_Informacao.Text = _DT.Rows[0]["Informacao"].ToString();
                txt_ValorMensalidade.Text = _DT.Rows[0]["ValorMensalidade"].ToString();
                txt_DiaFaturamento.Text = _DT.Rows[0]["DiaFaturamento"].ToString();
                txt_Limite.Text = _DT.Rows[0]["Limite"].ToString();
                txt_Informacao_Venda.Text = _DT.Rows[0]["Informacao_Venda"].ToString();
                txt_Dia_Faturamento.Text = _DT.Rows[0]["Dia_Faturamento"].ToString();

                cb_ID_Grupo.SelectedValue = util_dados.Verifica_int(_DT.Rows[0]["ID_Grupo"].ToString());
                #endregion

                if (lst_Pessoa_Endereco.Count > 0)
                    Carrega_Endereco(lst_Pessoa_Endereco);

                if (lst_Pessoa_Telefone.Count > 0)
                    Carrega_Telefone(lst_Pessoa_Telefone);

                if (lst_Pessoa_Email.Count > 0)
                    Carrega_Email(lst_Pessoa_Email);

                if (TipoPessoa == 6)
                {
                    dg_Pessoa.Rows.Clear();

                    lst_Pessoa_EmpresaResponsavel = new List<DTO_Pessoa_EmpresaResponsavel>();
                    _DT = new DataTable();

                    //Pessoa.TipoPessoa = 1;

                    _DT = BLL_Pessoa.Busca_EmpresaResponsavel(Pessoa);
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Pessoa_EmpresaResponsavel = new DTO_Pessoa_EmpresaResponsavel();

                        Pessoa_EmpresaResponsavel.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        Pessoa_EmpresaResponsavel.TipoPessoa = Convert.ToInt32(_DT.Rows[i]["TipoPessoa"]);
                        Pessoa_EmpresaResponsavel.ID_Pessoa = Convert.ToInt32(_DT.Rows[i]["ID_PessoaResponsavel"]);
                        Pessoa_EmpresaResponsavel.Descricao = _DT.Rows[i]["Descricao"].ToString();

                        lst_Pessoa_EmpresaResponsavel.Add(Pessoa_EmpresaResponsavel);

                        Carrega_EmpresaResponsavel(lst_Pessoa_EmpresaResponsavel);
                    }
                }

                if (TipoPessoa == 2)
                {
                    dg_Pessoa.Rows.Clear();

                    lst_Pessoa_EmpresaResponsavel = new List<DTO_Pessoa_EmpresaResponsavel>();
                    _DT = new DataTable();

                    //Pessoa.TipoPessoa = 2;

                    _DT = BLL_Pessoa.Busca_EmpresaResponsavel(Pessoa);
                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        Pessoa_EmpresaResponsavel = new DTO_Pessoa_EmpresaResponsavel();

                        Pessoa_EmpresaResponsavel.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                        Pessoa_EmpresaResponsavel.TipoPessoa = Convert.ToInt32(_DT.Rows[i]["TipoPessoa"]);
                        Pessoa_EmpresaResponsavel.ID_Pessoa = Convert.ToInt32(_DT.Rows[i]["ID_PessoaResponsavel"]);
                        Pessoa_EmpresaResponsavel.Descricao = _DT.Rows[i]["Descricao"].ToString();

                        lst_Pessoa_EmpresaResponsavel.Add(Pessoa_EmpresaResponsavel);

                        Carrega_EmpresaResponsavel(lst_Pessoa_EmpresaResponsavel);
                    }
                }
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                bool CadastroNovo = false;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                if (util_dados.Verifica_int(txt_ID.Text) == 0)
                {
                    CadastroNovo = true;

                    string CNPJ_CPF = txt_CNPJ_CPF.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace("0", "");
                    if (CNPJ_CPF != string.Empty)
                        if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPF.Text) == false)
                        {
                            MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                            txt_CNPJ_CPF.Text = string.Empty;
                            txt_CNPJ_CPF.Focus();
                            return;
                        }

                    if (util_dados.Verifica_int(txt_ID.Text) == 0 &&
                        txt_CNPJ_CPF.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace("0", "") != string.Empty)
                    {
                        Pessoa.TipoPessoa = TipoPessoa;
                        Pessoa.CNPJ_CPF = txt_CNPJ_CPF.Text;
                        Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        DataTable _DT = new DataTable();
                        _DT = BLL_Pessoa.Busca(Pessoa);
                        if (_DT.Rows.Count > 0)
                        {
                            DialogResult msgbox = MessageBox.Show(util_msg.msg_Pessoa_Cadastrado, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msgbox == DialogResult.No)
                            {
                                txt_CNPJ_CPF.Focus();
                                return;
                            }
                        }
                    }
                }

                string aux = string.Empty;

                if (dg_Endereco.Rows.Count == 0)
                    aux += "ENDEREÇO, *";

                if (dg_Telefone.Rows.Count == 0)
                {
                    aux = aux.Replace("*", "");
                    aux += "TELEFONE, *";

                }

                if (dg_Email.Rows.Count == 0)
                {
                    aux = aux.Replace("*", "");
                    aux += "e-MAIL, *";
                }

                aux = aux.Replace(", *", "");

                if (aux != string.Empty)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_Cadastro_Pessoa_FaltandoContato.Replace("-~~-", aux), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;
                }

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = util_dados.Verifica_int(txt_ID.Text);
                Pessoa.TipoPessoa = TipoPessoa;
                Pessoa.ID_Empresa = (TipoPessoa == 2 ? 0 : (ck_MultiEmpresa.Checked == true ? 0 : Parametro_Empresa.ID_Empresa_Ativa));

                Pessoa.ID_Usuario = Convert.ToInt32(cb_ID_Usuario.SelectedValue);
                Pessoa.Referencia = txt_Referencia.Text;
                Pessoa.Matricula = txt_Matricula.Text;
                Pessoa.Salario = Convert.ToDouble(txt_Salario.Text);
                Pessoa.CarteiraProfissional = txt_CarteiraProfissional.Text;
                Pessoa.PIS = txt_PIS.Text;
                Pessoa.MultiEmpresa = ck_MultiEmpresa.Checked;

                Pessoa.TipoDocumento = Convert.ToInt32(cb_TipoDocumento.SelectedValue);
                Pessoa.CNPJ_CPF = txt_CNPJ_CPF.Text;
                Pessoa.Nome_Razao = txt_Descricao.Text;
                Pessoa.NomeFantasia = txt_NomeFantasia.Text;
                Pessoa.Contato = txt_Contato.Text;
                Pessoa.IE_RG = txt_IE_RG.Text;
                Pessoa.IM = txt_IM.Text;
                Pessoa.Cadastro = Convert.ToDateTime(mk_Cadastro.Text);
                Pessoa.Informacao = txt_Informacao.Text;
                Pessoa.Informacao_Venda = txt_Informacao_Venda.Text;
                Pessoa.Dia_Faturamento = txt_Dia_Faturamento.Text;

                if (cb_ID_Grupo.SelectedValue != null)
                    Pessoa.ID_Grupo = util_dados.Verifica_int(cb_ID_Grupo.SelectedValue.ToString());

                Pessoa.Nascimento_Fundacao = Convert.ToDateTime(mk_Nascimento_Fundacao.Text);
                Pessoa.Ramo_Profissao = txt_Ramo_Profissao.Text;
                Pessoa.Descricao1 = txt_Descricao1.Text;
                Pessoa.Descricao2 = txt_Descricao2.Text;
                Pessoa.Descricao3 = txt_Descricao3.Text;
                Pessoa.Limite = Convert.ToDouble(txt_Limite.Text);
                Pessoa.DiaFaturamento = Convert.ToInt32(txt_DiaFaturamento.Text);
                Pessoa.Situacao = Convert.ToBoolean(ck_Situacao.Checked);
                Pessoa.CEI = txt_CEI.Text;
                Pessoa.ValorMensalidade = Convert.ToDouble(txt_ValorMensalidade.Text);
                Pessoa.Conjuge = txt_Conjuge.Text;
                Pessoa.CPF_Conjuge = txt_CPF_Conjuge.Text;
                Pessoa.RG_Conjuge = txt_RG_Conjuge.Text;
                Pessoa.Profissao_Conjuge = txt_Profissao_Conjuge.Text;

                Pessoa.Endereco = lst_Pessoa_Endereco;
                Pessoa.Telefone = lst_Pessoa_Telefone;
                Pessoa.Email = lst_Pessoa_Email;
                Pessoa.Pessoa_EmpresaResponsavel = lst_Pessoa_EmpresaResponsavel;

                obj = BLL_Pessoa.Grava(Pessoa);

                if (obj != 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();

                    if (CadastroNovo == true &&
                        Pessoa.TipoPessoa == 2)
                    {
                        BLL_Parametro = new BLL_Parametro();
                        Parametro = new DTO_Parametro();

                        Parametro.ID_Empresa = obj;
                        BLL_Parametro.Grava_Padrao(Parametro);

                        BLL_Produto = new BLL_Produto();
                        Produto = new DTO_Produto();

                        Produto.ID_Empresa = obj;
                        Produto.Ativo = true;
                        BLL_Produto.Grava_NovaEmpresa(Produto);
                    }
                }

                MessageBox.Show(util_msg.msg_Grava, this.Text);
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
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = util_dados.Verifica_int(txt_IDP.Text);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Pessoa.TipoPessoa = TipoPessoa;

                string CNPJ_CPF = txt_CNPJ_CPFP.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                if (CNPJ_CPF != string.Empty)
                {
                    if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPFP.Text) == false)
                    {
                        MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                        txt_CNPJ_CPFP.Text = string.Empty;
                        txt_CNPJ_CPFP.Focus();
                        return;
                    }
                    if (CNPJ_CPF.Length == 11)
                        Pessoa.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(CNPJ_CPF, Documento.CPF);

                    if (CNPJ_CPF.Length == 14)
                        Pessoa.CNPJ_CPF = util_dados.Conf_CPF_CNPJ(CNPJ_CPF, Documento.CNPJ);
                }

                Pessoa.Nome_Razao = txt_DescricaoP.Text;
                Pessoa.NomeFantasia = txt_NomeFantasiaP.Text;
                Pessoa.Matricula = txt_MatriculaP.Text;
            
                // Carregar Data Grid

                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca(Pessoa);
                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Endereco);
            util_dados.LimpaCampos(this, gb_Telefone);
            util_dados.LimpaCampos(this, gb_Email);
            util_dados.LimpaCampos(this, gb_InfoAdicional);

            dg_Endereco.Rows.Clear();
            dg_Telefone.Rows.Clear();
            dg_Email.Rows.Clear();

            lst_Pessoa_Email = null;
            lst_Pessoa_Endereco = null;
            lst_Pessoa_Telefone = null;

            if (TipoPessoa == 6)
            {
                dg_Pessoa.Rows.Clear();
                lst_Pessoa_EmpresaResponsavel = null;
            }
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = TipoPessoa;
                Pessoa.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Pessoa.Exclui(Pessoa);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Pesquisa();
             
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

        #region FORM
        private void UI_Pessoa_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Pessoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_IE_RG.Focused == true ||
               txt_CarteiraProfissional.Focused == true ||
               txt_PIS.Focused == true ||
               txt_CEI.Focused == true ||
               txt_CNPJ_CPF.Focused == true ||
               txt_CNPJ_CPFP.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro_DOC(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_DiaFaturamento.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Limite.Focused == true ||
                txt_ValorMensalidade.Focused == true ||
                txt_Salario.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumDecimal(KeyAscii);
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

        private void UI_Pessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region BUTTON
        private void bt_BuscaCEP_Click(object sender, EventArgs e)
        {
            Consulta_CEP(mk_CEP.Text);
        }

        private void bt_adicionaEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Endereco = new DTO_Pessoa_Endereco();

                Endereco.Principal = Convert.ToBoolean(ck_PrincipalEndereco.Checked);
                Endereco.Tipo = Convert.ToInt32(cb_TipoEndereco.SelectedValue);
                Endereco.Logradouro = txt_Logradouro.Text;
                Endereco.Numero = txt_NumeroEndereco.Text;
                Endereco.Complemento = txt_Complemento.Text;
                Endereco.Bairro = txt_Bairro.Text;
                Endereco.ID_Municipio = Convert.ToInt32(cb_Municipio.SelectedValue);
                Endereco.CEP = mk_CEP.Text;

                BLL_Pessoa.Verifica_Endereco(Endereco);

                if (lst_Pessoa_Endereco == null)
                    lst_Pessoa_Endereco = new List<DTO_Pessoa_Endereco>();

                if (ck_PrincipalEndereco.Checked == true)
                    for (int i = 0; i <= lst_Pessoa_Endereco.Count - 1; i++)
                        lst_Pessoa_Endereco[i].Principal = false;

                if (lst_Pessoa_Endereco.Count == 0)
                    ck_PrincipalEndereco.Checked = true;

                if (Edita_Endereco == true)
                {
                    lst_Pessoa_Endereco[ID_Endereco].Principal = Convert.ToBoolean(ck_PrincipalEndereco.Checked);
                    lst_Pessoa_Endereco[ID_Endereco].Tipo = Convert.ToInt32(cb_TipoEndereco.SelectedValue);
                    lst_Pessoa_Endereco[ID_Endereco].DescricaoTipo = cb_TipoEndereco.Text;
                    lst_Pessoa_Endereco[ID_Endereco].Logradouro = txt_Logradouro.Text;
                    lst_Pessoa_Endereco[ID_Endereco].Numero = txt_NumeroEndereco.Text;
                    lst_Pessoa_Endereco[ID_Endereco].Complemento = txt_Complemento.Text;
                    lst_Pessoa_Endereco[ID_Endereco].Bairro = txt_Bairro.Text;
                    lst_Pessoa_Endereco[ID_Endereco].ID_Pais = Convert.ToInt32(cb_Pais.SelectedValue);
                    lst_Pessoa_Endereco[ID_Endereco].ID_UF = Convert.ToInt32(cb_UF.SelectedValue);
                    lst_Pessoa_Endereco[ID_Endereco].ID_Municipio = Convert.ToInt32(cb_Municipio.SelectedValue);
                    lst_Pessoa_Endereco[ID_Endereco].CEP = mk_CEP.Text;
                    lst_Pessoa_Endereco[ID_Endereco].Descricao_Municipio = cb_Municipio.Text + "-" + util_dados.Retorna_UF_Abreviado(Convert.ToInt32(cb_UF.SelectedValue));

                    Edita_Endereco = false;
                    ID_Endereco = 0;
                }
                else
                {
                    Endereco = new DTO_Pessoa_Endereco();

                    Endereco.Principal = Convert.ToBoolean(ck_PrincipalEndereco.Checked);
                    Endereco.Tipo = Convert.ToInt32(cb_TipoEndereco.SelectedValue);
                    Endereco.DescricaoTipo = cb_TipoEndereco.Text;
                    Endereco.Logradouro = txt_Logradouro.Text;
                    Endereco.Numero = txt_NumeroEndereco.Text;
                    Endereco.Complemento = txt_Complemento.Text;
                    Endereco.Bairro = txt_Bairro.Text;
                    Endereco.ID_Pais = Convert.ToInt32(cb_Pais.SelectedValue);
                    Endereco.ID_UF = Convert.ToInt32(cb_UF.SelectedValue);
                    Endereco.ID_Municipio = Convert.ToInt32(cb_Municipio.SelectedValue);
                    Endereco.CEP = mk_CEP.Text;
                    Endereco.Descricao_Municipio = cb_Municipio.Text + "-" + util_dados.Retorna_UF_Abreviado(Convert.ToInt32(cb_UF.SelectedValue));

                    lst_Pessoa_Endereco.Add(Endereco);
                }

                Carrega_Endereco(lst_Pessoa_Endereco);

                util_dados.LimpaCampos(this, gb_Endereco);

                cb_TipoEndereco.SelectedIndex = 0;
                cb_Pais.SelectedValue = 1058;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_AdicionaTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Telefone = new DTO_Pessoa_Telefone();

                if (dg_Telefone.Rows.Count == 0)
                    ck_PrincipalTelefone.Checked = true;

                Telefone.Principal = Convert.ToBoolean(ck_PrincipalTelefone.Checked);
                Telefone.Tipo = Convert.ToInt32(cb_TipoTelefone.SelectedValue);
                Telefone.DDD = txt_DDD.Text;
                Telefone.Numero = txt_NumeroTelefone.Text;
                Telefone.Informacao = txt_InformacaoTelefone.Text;

                BLL_Pessoa.Verifica_Telefone(Telefone);

                if (lst_Pessoa_Telefone == null)
                    lst_Pessoa_Telefone = new List<DTO_Pessoa_Telefone>();

                if (lst_Pessoa_Telefone.Count == 0)
                    ck_PrincipalTelefone.Checked = true;

                if (ck_PrincipalTelefone.Checked == true)
                    for (int i = 0; i <= lst_Pessoa_Telefone.Count - 1; i++)
                        lst_Pessoa_Telefone[i].Principal = false;

                if (Edita_Telefone == true)
                {
                    lst_Pessoa_Telefone[ID_Telefone].Principal = Convert.ToBoolean(ck_PrincipalTelefone.Checked);
                    lst_Pessoa_Telefone[ID_Telefone].Tipo = Convert.ToInt32(cb_TipoTelefone.SelectedValue);
                    lst_Pessoa_Telefone[ID_Telefone].DescricaoTipo = cb_TipoTelefone.Text;
                    lst_Pessoa_Telefone[ID_Telefone].DDD = txt_DDD.Text;
                    lst_Pessoa_Telefone[ID_Telefone].Numero = txt_NumeroTelefone.Text;
                    lst_Pessoa_Telefone[ID_Telefone].Informacao = txt_InformacaoTelefone.Text;

                    Edita_Telefone = false;
                    ID_Telefone = 0;
                }
                else
                {
                    Telefone = new DTO_Pessoa_Telefone();

                    Telefone.Principal = Convert.ToBoolean(ck_PrincipalTelefone.Checked);
                    Telefone.Tipo = Convert.ToInt32(cb_TipoTelefone.SelectedValue);
                    Telefone.DescricaoTipo = cb_TipoTelefone.Text;
                    Telefone.DDD = txt_DDD.Text;
                    Telefone.Numero = txt_NumeroTelefone.Text;
                    Telefone.Informacao = txt_InformacaoTelefone.Text;

                    lst_Pessoa_Telefone.Add(Telefone);
                }

                Carrega_Telefone(lst_Pessoa_Telefone);

                util_dados.LimpaCampos(this, gb_Telefone);

                cb_TipoTelefone.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_AdicionaEmail_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Email = new DTO_Pessoa_Email();

                if (dg_Email.Rows.Count == 0)
                    ck_PrincipalEmail.Checked = true;

                Email.Principal = Convert.ToBoolean(ck_PrincipalEmail.Checked);
                Email.Tipo = Convert.ToInt32(cb_TipoEmail.SelectedValue);
                Email.Email = txt_Email.Text;
                Email.Informacao = txt_InformacaoEmail.Text;

                BLL_Pessoa.Verifica_Email(Email);

                if (lst_Pessoa_Email == null)
                    lst_Pessoa_Email = new List<DTO_Pessoa_Email>();

                if (lst_Pessoa_Email.Count == 0)
                    ck_PrincipalEmail.Checked = true;

                if (ck_PrincipalEmail.Checked == true)
                    for (int i = 0; i <= lst_Pessoa_Email.Count - 1; i++)
                        lst_Pessoa_Email[i].Principal = false;

                if (Edita_Email == true)
                {
                    lst_Pessoa_Email[ID_Email].Principal = Convert.ToBoolean(ck_PrincipalEmail.Checked);
                    lst_Pessoa_Email[ID_Email].Tipo = Convert.ToInt32(cb_TipoEmail.SelectedValue);
                    lst_Pessoa_Email[ID_Email].DescricaoTipo = cb_TipoEmail.Text;
                    lst_Pessoa_Email[ID_Email].Email = txt_Email.Text;
                    lst_Pessoa_Email[ID_Email].Informacao = txt_InformacaoEmail.Text;

                    Edita_Email = false;
                    ID_Email = 0;
                }
                else
                {
                    Email = new DTO_Pessoa_Email();

                    Email.Principal = Convert.ToBoolean(ck_PrincipalEmail.Checked);
                    Email.Tipo = Convert.ToInt32(cb_TipoEmail.SelectedValue);
                    Email.DescricaoTipo = cb_TipoEmail.Text;
                    Email.Email = txt_Email.Text;
                    Email.Informacao = txt_InformacaoEmail.Text;

                    lst_Pessoa_Email.Add(Email);
                }

                Carrega_Email(lst_Pessoa_Email);

                util_dados.LimpaCampos(this, gb_Email);

                cb_TipoEmail.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_EditaEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                ck_PrincipalEndereco.Checked = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].Principal;
                cb_TipoEndereco.SelectedValue = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].Tipo;
                txt_Logradouro.Text = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].Logradouro;
                txt_NumeroEndereco.Text = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].Numero;
                txt_Complemento.Text = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].Complemento;
                txt_Bairro.Text = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].Bairro;
                mk_CEP.Text = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].CEP;
                cb_Pais.SelectedValue = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].ID_Pais;
                cb_UF.SelectedValue = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].ID_UF;
                cb_Municipio.SelectedValue = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].ID_Municipio;

                Edita_Endereco = true;
                ID_Endereco = dg_Endereco.CurrentRow.Index;
            }
            catch (Exception)
            {

            }
           
        }

        private void bt_EditaTelefone_Click(object sender, EventArgs e)
        {
            ck_PrincipalTelefone.Checked = lst_Pessoa_Telefone[dg_Telefone.CurrentRow.Index].Principal;
            cb_TipoTelefone.SelectedValue = lst_Pessoa_Telefone[dg_Telefone.CurrentRow.Index].Tipo;
            txt_DDD.Text = lst_Pessoa_Telefone[dg_Telefone.CurrentRow.Index].DDD;
            txt_NumeroTelefone.Text = lst_Pessoa_Telefone[dg_Telefone.CurrentRow.Index].Numero;
            txt_InformacaoTelefone.Text = lst_Pessoa_Telefone[dg_Telefone.CurrentRow.Index].Informacao;

            Edita_Telefone = true;
            ID_Telefone = dg_Telefone.CurrentRow.Index;
        }

        private void bt_EditaEmail_Click(object sender, EventArgs e)
        {
            ck_PrincipalEmail.Checked = lst_Pessoa_Email[dg_Email.CurrentRow.Index].Principal;
            cb_TipoEmail.SelectedValue = lst_Pessoa_Email[dg_Email.CurrentRow.Index].Tipo;
            txt_Email.Text = lst_Pessoa_Email[dg_Email.CurrentRow.Index].Email;
            txt_InformacaoEmail.Text = lst_Pessoa_Email[dg_Email.CurrentRow.Index].Informacao;

            Edita_Email = true;
            ID_Email = dg_Email.CurrentRow.Index;
        }

        private void bt_ExcluiEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_Pessoa_Endereco == null)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].ID > 0)
                {
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();
                    Endereco = new DTO_Pessoa_Endereco();
                    List<DTO_Pessoa_Endereco> _Endereco = new List<DTO_Pessoa_Endereco>();

                    Endereco.ID = lst_Pessoa_Endereco[dg_Endereco.CurrentRow.Index].ID;
                    Endereco.Principal = false;

                    _Endereco.Add(Endereco);

                    Pessoa.Endereco = _Endereco;

                    BLL_Pessoa.Exclui_Endereco(Pessoa);
                }

                lst_Pessoa_Endereco.RemoveAt(dg_Endereco.CurrentRow.Index);

                Carrega_Endereco(lst_Pessoa_Endereco);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_ExcluiTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_Pessoa_Telefone == null)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (lst_Pessoa_Telefone[dg_Telefone.CurrentRow.Index].ID > 0)
                {
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();
                    Telefone = new DTO_Pessoa_Telefone();
                    List<DTO_Pessoa_Telefone> _Telefone = new List<DTO_Pessoa_Telefone>();

                    Telefone.ID = lst_Pessoa_Telefone[dg_Telefone.CurrentRow.Index].ID;
                    Telefone.Principal = false;

                    _Telefone.Add(Telefone);

                    Pessoa.Telefone = _Telefone;

                    BLL_Pessoa.Exclui_Telefone(Pessoa);
                }

                lst_Pessoa_Telefone.RemoveAt(dg_Telefone.CurrentRow.Index);

                Carrega_Telefone(lst_Pessoa_Telefone);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_ExcluiEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst_Pessoa_Email == null)
                    return;

                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (lst_Pessoa_Email[dg_Email.CurrentRow.Index].ID > 0)
                {
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();
                    Email = new DTO_Pessoa_Email();
                    List<DTO_Pessoa_Email> _Email = new List<DTO_Pessoa_Email>();

                    Email.ID = lst_Pessoa_Email[dg_Email.CurrentRow.Index].ID;
                    Email.Principal = false;

                    _Email.Add(Email);

                    Pessoa.Email = _Email;

                    BLL_Pessoa.Exclui_Email(Pessoa);
                }

                lst_Pessoa_Email.RemoveAt(dg_Email.CurrentRow.Index);

                Carrega_Email(lst_Pessoa_Email);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_NovoEndereco_Click(object sender, EventArgs e)
        {
            util_dados.LimpaCampos(this, gb_Endereco);

            Edita_Endereco = false;
            ID_Endereco = 0;

            cb_TipoEndereco.SelectedIndex = 0;
            cb_Pais.SelectedValue = 1058;
        }

        private void bt_NovoTelefone_Click(object sender, EventArgs e)
        {
            util_dados.LimpaCampos(this, gb_Telefone);

            Edita_Telefone = false;
            ID_Telefone = 0;

            cb_TipoTelefone.SelectedIndex = 0;
        }

        private void bt_NovoEmail_Click(object sender, EventArgs e)
        {
            util_dados.LimpaCampos(this, gb_Email);

            Edita_Email = false;
            ID_Email = 0;

            cb_TipoEmail.SelectedIndex = 0;
        }

        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Limpa_Campo();
        }

        private void bt_adicionaEmpresa_Click(object sender, EventArgs e)
        {
            if (lst_Pessoa_EmpresaResponsavel == null)
                lst_Pessoa_EmpresaResponsavel = new List<DTO_Pessoa_EmpresaResponsavel>();

            for (int i = 0; i <= lst_Pessoa_EmpresaResponsavel.Count - 1; i++)
                if (Convert.ToInt32(cb_ID_Pessoa.SelectedValue) == lst_Pessoa_EmpresaResponsavel[i].ID_Pessoa)
                {
                    MessageBox.Show(util_msg.msg_Empresa_Cadastrado, this.Text);
                    return;
                }

            Pessoa_EmpresaResponsavel = new DTO_Pessoa_EmpresaResponsavel();

            if (TipoPessoa == 6)
                Pessoa_EmpresaResponsavel.TipoPessoa = 1;

            if (TipoPessoa == 2)
                Pessoa_EmpresaResponsavel.TipoPessoa = 4;

            Pessoa_EmpresaResponsavel.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            Pessoa_EmpresaResponsavel.Descricao = cb_ID_Pessoa.Text;

            lst_Pessoa_EmpresaResponsavel.Add(Pessoa_EmpresaResponsavel);

            Carrega_EmpresaResponsavel(lst_Pessoa_EmpresaResponsavel);
        }

        private void bt_ExcluiEmpresa_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                if (util_dados.Verifica_int(txt_ID.Text) > 0 &&
                    lst_Pessoa_EmpresaResponsavel[dg_Pessoa.CurrentRow.Index].ID > 0)
                {
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.TipoPessoa = TipoPessoa;
                    Pessoa.ID = Convert.ToInt32(txt_ID.Text);

                    if (TipoPessoa == 6)
                        Pessoa.TipoPessoa_EmpresaResponsavel = 4;

                    if (TipoPessoa == 2)
                        Pessoa.TipoPessoa_EmpresaResponsavel = 4;

                    Pessoa.ID_EmpresaResponsavel = lst_Pessoa_EmpresaResponsavel[dg_Pessoa.CurrentRow.Index].ID_Pessoa;

                    BLL_Pessoa.Exclui_EmpresaResponsavel(Pessoa);
                }

                lst_Pessoa_EmpresaResponsavel.RemoveAt(dg_Pessoa.CurrentRow.Index);

                Carrega_EmpresaResponsavel(lst_Pessoa_EmpresaResponsavel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region COMBOBOX
        private void cb_Pais_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaComboEstado();
        }

        private void cb_UF_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaComboMunicipio();
        }

        private void cb_TipoDocumento_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_TipoDocumento.SelectedValue != null &&
                    Convert.ToInt32(cb_TipoDocumento.SelectedValue) == 1)
                    TipoDocumento(1);

                if (cb_TipoDocumento.SelectedValue != null &&
                   Convert.ToInt32(cb_TipoDocumento.SelectedValue) == 2)
                    TipoDocumento(2);
            }
            catch (Exception)
            {
            }
        }

        private void cb_ID_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_Usuario.SelectedIndex = -1;
        }

        private void cb_ID_Grupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_Grupo.SelectedIndex = -1;
        }
        #endregion

        #region MASKEDBOX
        private void mk_Cadastro_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Cadastro.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Cadastro.Text = Convert.ToString(DateTime.Now);
                mk_Cadastro.Focus();
            }
        }

        private void mk_Nascimento_Fundacao_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Nascimento_Fundacao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Nascimento_Fundacao.Text = Convert.ToString(DateTime.Now);
                mk_Nascimento_Fundacao.Focus();
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Busca_Informacao(util_dados.Verifica_int(txt_ID.Text));
            Config(StatusForm.Consulta);
        }

        private void txt_DiaFaturamento_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_DiaFaturamento.Text) > 30)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);

                txt_DiaFaturamento.Focus();

                SendKeys.Send("{home}+{end}");
            }
        }

        private void txt_ValorMensalidade_Leave(object sender, EventArgs e)
        {
            if (txt_ValorMensalidade.Text.Trim() == string.Empty)
                txt_ValorMensalidade.Text = "0";

            txt_ValorMensalidade.Text = util_dados.ConfigNumDecimal(txt_ValorMensalidade.Text, 2);
        }

        private void txt_Limite_Leave(object sender, EventArgs e)
        {
            if (txt_Limite.Text.Trim() == string.Empty)
                txt_Limite.Text = "0";

            txt_Limite.Text = util_dados.ConfigNumDecimal(txt_Limite.Text, 2);
        }

        private void txt_CNPJ_CPF_Leave(object sender, EventArgs e)
        {
            string CNPJ_CPF = txt_CNPJ_CPF.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace("0", "");
            if (CNPJ_CPF != string.Empty)
            {
                if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPF.Text) == false)
                {
                    MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                    txt_CNPJ_CPF.Text = string.Empty;
                    txt_CNPJ_CPF.Focus();
                    return;
                }

                if (util_dados.Verifica_int(txt_ID.Text) == 0)
                {
                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.TipoPessoa = TipoPessoa;
                    Pessoa.CNPJ_CPF = txt_CNPJ_CPF.Text;
                    Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    DataTable _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca(Pessoa);

                    if (_DT.Rows.Count > 0)
                        MessageBox.Show(util_msg.msg_CPFCNPJ_JaCadastrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txt_CNPJ_CPF_TextChanged(object sender, EventArgs e)
        {
            if (txt_CNPJ_CPF.Focused == false)
                return;

            txt_CNPJ_CPF.Text = util_dados.Digita_CNPJ_CPF(txt_CNPJ_CPF.Text, Convert.ToInt32(cb_TipoDocumento.SelectedValue));
            SendKeys.Send("{end}");
        }

        private void txt_CEI_TextChanged(object sender, EventArgs e)
        {
            txt_CEI.Text = util_dados.Digita_CEI(txt_CEI.Text);
            SendKeys.Send("{end}");
        }

        private void txt_DDD_TextChanged(object sender, EventArgs e)
        {
            if (txt_DDD.Text.Trim().Length == 2)
                txt_NumeroTelefone.Focus();
        }

        private void txt_CNPJ_CPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back &&
                txt_CNPJ_CPF.Text.Trim() != string.Empty)
            {
                if ((txt_CNPJ_CPF.Text.Substring(txt_CNPJ_CPF.Text.Length - 1) == ".") ||
                (txt_CNPJ_CPF.Text.Substring(txt_CNPJ_CPF.Text.Length - 1) == "-") ||
                (txt_CNPJ_CPF.Text.Substring(txt_CNPJ_CPF.Text.Length - 1) == "/"))
                    txt_CNPJ_CPF.Text = txt_CNPJ_CPF.Text.Substring(0, txt_CNPJ_CPF.Text.Length - 2);
            }

            if (e.KeyCode == Keys.C &&
                ModifierKeys == Keys.Control)
                Clipboard.SetText(util_dados.Retorna_Numero(txt_CNPJ_CPF.Text));
        }

        private void txt_IE_RG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C &&
                ModifierKeys == Keys.Control)
                Clipboard.SetText(util_dados.Retorna_Numero(txt_CNPJ_CPF.Text));

        }

        private void txt_CEI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back &&
                txt_CEI.Text.Trim() != string.Empty)
            {
                if ((txt_CEI.Text.Substring(txt_CEI.Text.Length - 1) == ".") ||
                (txt_CEI.Text.Substring(txt_CEI.Text.Length - 1) == "-") ||
                (txt_CEI.Text.Substring(txt_CEI.Text.Length - 1) == "/"))
                    txt_CEI.Text = txt_CEI.Text.Substring(0, txt_CEI.Text.Length - 2);
            }
        }

        private void txt_CPF_Conjuge_Leave(object sender, EventArgs e)
        {
            string CNPJ_CPF = txt_CPF_Conjuge.Text.Replace(".", "").Replace("/", "").Replace("-", "").Replace("0", "");

            if (CNPJ_CPF != string.Empty)
            {
                if (util_dados.Verifica_CPF_CNPJ(txt_CPF_Conjuge.Text) == false)
                {
                    MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                    txt_CPF_Conjuge.Text = string.Empty;
                    txt_CPF_Conjuge.Focus();
                    return;
                }
            }
        }

        private void txt_CPF_Conjuge_TextChanged(object sender, EventArgs e)
        {
            txt_CPF_Conjuge.Text = util_dados.Digita_CNPJ_CPF(txt_CPF_Conjuge.Text, 2);
            SendKeys.Send("{end}");
        }

        private void txt_CPF_Conjuge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back &&
                txt_CPF_Conjuge.Text.Trim() != string.Empty)
            {
                if ((txt_CPF_Conjuge.Text.Substring(txt_CPF_Conjuge.Text.Length - 1) == ".") ||
                (txt_CPF_Conjuge.Text.Substring(txt_CPF_Conjuge.Text.Length - 1) == "-") ||
                (txt_CPF_Conjuge.Text.Substring(txt_CPF_Conjuge.Text.Length - 1) == "/"))
                    txt_CPF_Conjuge.Text = txt_CPF_Conjuge.Text.Substring(0, txt_CPF_Conjuge.Text.Length - 2);
            }
        }

        private void txt_CNPJ_CPFP_Leave(object sender, EventArgs e)
        {
            string CNPJ_CPF = txt_CNPJ_CPFP.Text.Replace(".", "").Replace("/", "").Replace("-", "");
            if (CNPJ_CPF != string.Empty)
            {
                if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPFP.Text) == false)
                {
                    MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                    txt_CNPJ_CPFP.Text = string.Empty;
                    txt_CNPJ_CPFP.Focus();
                    return;
                }
                if (CNPJ_CPF.Length == 11)
                    txt_CNPJ_CPFP.Text = util_dados.Conf_CPF_CNPJ(CNPJ_CPF, Documento.CPF);

                if (CNPJ_CPF.Length == 14)
                    txt_CNPJ_CPFP.Text = util_dados.Conf_CPF_CNPJ(CNPJ_CPF, Documento.CNPJ);
            }
        }

        private void txt_Dia_Faturamento_Leave(object sender, EventArgs e)
        {
            if (txt_Dia_Faturamento.Text.Trim() != "0" &&
                util_dados.Verifica_int(txt_Dia_Faturamento.Text.Replace("/", "")) == 0)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);

                txt_Dia_Faturamento.Focus();

                SendKeys.Send("{home}+{end}");
            }

            string[] Data = txt_Dia_Faturamento.Text.Split('/');

            for (int i = 0; i <= Data.Length - 1; i++)
            {
                if (Convert.ToInt32(Data[i]) > 30)
                {
                    MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                    txt_Dia_Faturamento.Focus();
                    SendKeys.Send("{home}+{end}");
                    return;
                }
            }
        }
        #endregion

        private void mk_CEP_Leave(object sender, EventArgs e)
        {
            Consulta_CEP(mk_CEP.Text);
        }
    }
}
