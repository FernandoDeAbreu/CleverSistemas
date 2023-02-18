using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;
using System.Runtime.InteropServices;

namespace Sistema.UI
{
    public partial class UI_Boleto : Sistema.UI.UI_Modelo
    {
        public UI_Boleto()
        {
            InitializeComponent();
        }

        #region PROPRIEDADES
        public Tipo_Boleto Tipo { get; set; }
        #endregion

        #region VARIAVEIS DE CLASSE
        BLL_Cedente BLL_Cedente;
        BLL_Grupo BLL_Grupo;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        BLL_Boleto BLL_Boleto;
        #endregion

        #region ESTRUTURA
        DTO_Cedente Cedente;
        DTO_Grupo Grupo;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_CReceber CReceber;
        DTO_Pessoa Pessoa;
        DTO_Boleto Boleto;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTR_Pessoa;
        DataTable DTR_Empresa;
        DataTable DTPessoa;
        DataTable DTR_Imagem;
        DataTable DTBoletoControle;

        DataRow DR;
        DataRow DRBoleto;
        DataRow DRPessoa;

        string ID_Conta;

        DateTime ValidaData;

        bool Seleciona = false;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            dg_CReceber.AutoGenerateColumns = false;
            dg_Boletos.AutoGenerateColumns = false;
            dg_Contas.AutoGenerateColumns = false;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Novo.Visible = false;
            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;

            bt_Visualiza.Text = "GERAR PDF";
            bt_Visualiza.Image = UI.Properties.Resources.bt_pdf;

            tabctl.TabPages.Remove(TabPage2);

            mk_DataBaixa.Text = DateTime.Now.ToString();
            mk_DataPagto.Text = DateTime.Now.ToString();

            mk_DataInicial.Text = DateTime.Now.AddDays(-30).ToString();
            mk_DataFinal.Text = DateTime.Now.AddDays(60).ToString();
            
            CarregaCB();
            
            cb_PeriodoBoleto.SelectedIndex = 2;
            cb_Periodo.SelectedIndex = 2;
            cb_sit_Boleto.SelectedIndex = 1;

            if (Parametro_Empresa.Tipo_Sistema == Tipo_Sistema.Imobiliaria)
            {
                cb_TipoPessoa.SelectedValue = 8;
                cb_TipoPessoaG.SelectedValue = 8;
                cb_TipoPessoaH.SelectedValue = 8;
                cb_TipoPessoaP.SelectedValue = 8;
            }

            switch (Tipo)
            {
                case Tipo_Boleto.Gerar:
                    gb_Baixa.Visible = false;

                    this.Text = "COBRANÇA BANCÁRIA";

                    tabctl.SelectedTab = tabPage5;
                    break;

                case Tipo_Boleto.Matricial:
                    gb_Baixa.Visible = false;
                    bt_Visualiza.Visible = false;
                    gb_Agrupar.Enabled = true;
                    ck_Agrupar.Visible = false;
                    cb_TipoPessoaG.Enabled = false;
                    cb_ID_PessoaG.Enabled = false;
                    mk_VencimentoL.Enabled = false;
                    txt_DescontoG.Enabled = false;
                    txt_AcrescimoG.Enabled = false;

                    this.Text = "COBRANÇA BANCÁRIA";

                    tabctl.SelectedTab = tabPage5;
                    break;

                case Tipo_Boleto.Baixa:
                    tabctl.TabPages.Remove(TabPage1);
                    tabctl.TabPages.Remove(tabPage5);
                    bt_Grava.Visible = false;
                    bt_Edita.Visible = false;
                    bt_Exclui.Visible = false;
                    bt_Novo.Visible = false;
                    bt_Imprime.Visible = false;

                    dg_Boletos.Columns.RemoveAt(0);

                    this.Text = "COBRANÇA BANCÁRIA - BAIXA";

                    tabctl.SelectedTab = tabPage3;
                    break;
            }
        }

        /// <summary>
        /// TIPO CAMPO
        ///<para>1 - COMBO EDITA BOLETO BOLETO (tabpage1)</para> 
        ///<para>2 - COMBO PESQUISA BOLETO (tabpage3) H</para> 
        ///<para>3 - COMBO GERA BOLETO (tabpage5) P</para> 
        ///<para>4 - COMBO GERA BOLETO AGRUPADO (tabpage5) G</para> 
        /// </summary>
        private void CarregaPessoa(int _Tipo)
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                DataTable _DT = new DataTable();

                switch (_Tipo)
                {
                    case 1:
                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

                        _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);

                        if (util_dados.Verifica_int(txt_ID_Pessoa.Text) > 0)
                            cb_ID_Pessoa.SelectedValue = Convert.ToInt32(txt_ID_Pessoa.Text);
                        break;
                    case 2:
                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaH.SelectedValue);

                        _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PessoaH);
                        cb_ID_PessoaH.SelectedIndex = -1;
                        break;
                    case 3:
                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

                        _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PessoaP);
                        cb_ID_PessoaP.SelectedIndex = -1;
                        break;
                    case 4:
                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaG.SelectedValue);

                        _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PessoaG);
                        cb_ID_PessoaG.SelectedIndex = -1;
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();

            BLL_Cedente = new BLL_Cedente();
            Cedente = new DTO_Cedente();
            Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Cedente.FiltraAtivo = true;
            Cedente.Ativo = true;

            _DT = new DataTable();
            _DT = BLL_Cedente.Busca(Cedente);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Cedente);
            cb_Cedente.SelectedIndex = -1;

            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);
            Grupo.FiltraExibir = true;
            Grupo.Exibir = true;
            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_CaixaBaixa);

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaG);
            cb_TipoPessoaG.SelectedIndex = -1;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaH);
            cb_TipoPessoaH.SelectedIndex = -1;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            switch (Parametro_Empresa.Tipo_Sistema)
            {
                case Tipo_Sistema.Comercial:
                    if (DTBoletoControle.Rows.Count < 15)
                        for (int i = DTBoletoControle.Rows.Count; i <= 15; i++)
                            DTBoletoControle.Rows.Add();


                    if (DTBoletoControle.Rows.Count > 15)
                        for (int i = DTBoletoControle.Rows.Count; i >= 15; i--)
                            DTBoletoControle.Rows.RemoveAt(i - 1);
                    break;

                case Tipo_Sistema.Imobiliaria:
                    if (DTBoletoControle.Rows.Count < 10)
                        for (int i = DTBoletoControle.Rows.Count; i <= 10; i++)
                            DTBoletoControle.Rows.Add();


                    if (DTBoletoControle.Rows.Count > 10)
                        for (int i = DTBoletoControle.Rows.Count; i >= 10; i--)
                            DTBoletoControle.Rows.RemoveAt(i - 1);
                    break;
            }
            e.DataSources.Add(new ReportDataSource("ds_CReceber", DTBoletoControle));
        }

        /// <summary>
        /// <para>1 - ALTERAÇÃO</para>
        /// <para>2 - BAIXA</para>
        /// </summary>
        private void Calcula_Boleto(int _Tipo)
        {
            double Valor = 0;
            double Acrescimo = 0;
            double Desconto = 0;
            double Multa = 0;
            double Juros = 0;

            switch (_Tipo)
            {
                case 1:
                    Valor = Convert.ToDouble(txt_Valor.Text);
                    Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                    Desconto = Convert.ToDouble(txt_Desconto.Text);

                    txt_ValorLiquido.Text = util_dados.ConfigNumDecimal((Valor + Acrescimo) - Desconto, 2);
                    break;

                case 2:
                    Valor = Convert.ToDouble(txt_ValorBoleto.Text);
                    Acrescimo = Convert.ToDouble(txt_AcrescimoB.Text);
                    Desconto = Convert.ToDouble(txt_DescontoB.Text);

                    DateTime Vencimento_Original = Convert.ToDateTime(mk_DataPagto.Text);
                    DateTime Data_Pagto = Convert.ToDateTime(mk_DataBaixa.Text);

                    if (ck_Calcula_Juro.Checked == true)
                    {
                        Multa = util_dados.Calcula_Porcentagem(Parametro_Financeiro.Tarifa_Multa, Valor);
                        Juros = util_dados.Calcula_Juro(Valor, Parametro_Financeiro.Tarifa_Juros, Vencimento_Original, Data_Pagto);
                    }

                    txt_Multa.Text = util_dados.ConfigNumDecimal(Multa, 2);
                    txt_Juros.Text = util_dados.ConfigNumDecimal(Juros, 2);

                    txt_ValorFinal.Text = util_dados.ConfigNumDecimal((Valor + Acrescimo + Multa + Juros) - Desconto, 2);
                    break;
            }
        }

        private void Imprime_Matricial()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaImpressao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            for (int i = 0; i <= dg_Boletos.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Boletos.Rows[i].Cells["col_SelecionaBoleto"].Value) == true)
                {
                    Boleto.ID = Convert.ToInt32(dg_Boletos.Rows[i].Cells["col_ID_Boleto"].Value);
                    Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    if (cb_sit_Boleto.Text == "TODOS")
                        Boleto.Filtra_Liquidado = false;
                    else
                    {
                        Boleto.Filtra_Liquidado = true;
                        if (cb_sit_Boleto.Text == "LIQUIDADOS")
                            Boleto.Liquidado = true;

                        if (cb_sit_Boleto.Text == "EM ABERTO")
                            Boleto.Liquidado = false;
                    }

                    DataTable _DT = new DataTable();
                    _DT = BLL_Boleto.Busca(Boleto);

                    string Juros = util_dados.Boleto_Juros(Convert.ToDouble(_DT.Rows[0]["Valor"]), Convert.ToDouble(_DT.Rows[0]["Juros"]), Convert.ToInt32(_DT.Rows[0]["DiasJuros"]));
                    string Multa = util_dados.Boleto_Multa(Convert.ToDouble(_DT.Rows[0]["Valor"]), Convert.ToDouble(_DT.Rows[0]["Multa"]), Convert.ToInt32(_DT.Rows[0]["DiasMulta"]));
                    string Instrucao_1 = _DT.Rows[0]["Instrucao_1"].ToString();
                    string Instrucao_2 = _DT.Rows[0]["Instrucao_2"].ToString();
                    string Emissao = util_dados.Config_Data(Convert.ToDateTime(_DT.Rows[0]["Emissao"].ToString()), 3).ToString();
                    string Vencimento = util_dados.Config_Data(Convert.ToDateTime(_DT.Rows[0]["Vencimento"].ToString()), 3).ToString();
                    string Valor = util_dados.ConfigNumDecimal(Convert.ToDouble(_DT.Rows[0]["Valor"].ToString()), 2);
                    string Parcela = string.Empty;
                    string Documento = _DT.Rows[0]["Documento"].ToString();

                    if (Documento.IndexOf('(') != -1)
                    {
                        Documento = Documento.Substring(0, Documento.IndexOf('('));

                        Parcela = _DT.Rows[0]["Documento"].ToString();
                        Parcela = Parcela.Substring(Parcela.IndexOf('(')).Replace("(", "").Replace(")", "");
                    }

                    string Avalista = _DT.Rows[0]["Razao_Cedente"].ToString();

                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.TipoPessoa = Convert.ToInt32(_DT.Rows[0]["TipoPessoa"]);
                    Pessoa.ID = Convert.ToInt32(_DT.Rows[0]["ID_Pessoa"]);

                    _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

                    string Sacado = _DT.Rows[0]["Descricao"].ToString();
                    string CNPJ_CPF_Sacado = _DT.Rows[0]["CNPJ_CPF"].ToString();
                    string Endereco1 = _DT.Rows[0]["Logradouro"].ToString() + ", " + _DT.Rows[0]["NumeroEndereco"].ToString() + " " + _DT.Rows[0]["Complemento"].ToString() + " - " + _DT.Rows[0]["Bairro"].ToString();
                    string Endereco2 = "CEP: " + _DT.Rows[0]["CEP"].ToString() + " - " + _DT.Rows[0]["NomeMunicipio"].ToString() + "/" + _DT.Rows[0]["SIGLA"].ToString();

                    string _str_Boleto = string.Empty;


                    _str_Boleto += "\t\t\t\t\t\t\t\t\t\t\t\t" + Vencimento;
                    _str_Boleto += "\n\n\n\n" + Emissao + "\t\t" + Documento;
                    _str_Boleto += "\n\t\t\t\t\t\t" + Parcela + "\t\t\t\t\t\t" + Valor;
                    _str_Boleto += "\n\n" + Juros;
                    _str_Boleto += "\n" + Multa;
                    _str_Boleto += "\n" + Instrucao_1;
                    _str_Boleto += "\n" + Instrucao_2;
                    _str_Boleto += "\n";
                    _str_Boleto += "\n\n\n\t" + Sacado + "\tCNPJ/CPF:" + CNPJ_CPF_Sacado;
                    _str_Boleto += "\n\t" + Endereco1;
                    _str_Boleto += "\n\t" + Endereco2;
                    _str_Boleto += "\n\t\t" + Avalista;

                    _str_Boleto += "\n\n\n\n\n\n\n";

                    _str_Boleto = util_dados.ConfigCampoNFe(_str_Boleto);

                    string Arquivo_txt = Parametro_Sistema.Caminho_Sistema + @"Temp\" + Convert.ToInt32(_DT.Rows[0]["ID"]) + ".txt";

                    StreamWriter GeraTXT = null;
                    GeraTXT = new StreamWriter(Arquivo_txt);
                    GeraTXT.Write(_str_Boleto);
                    GeraTXT.Close();

                    File.Copy(Arquivo_txt, "LPT1", true);

                    File.Delete(Parametro_Sistema.Caminho_Sistema + @"Temp\" + Convert.ToInt32(_DT.Rows[0]["ID"]) + ".txt");
                }
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            if (tabctl.SelectedTab == TabPage1)
            {
                cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                CarregaPessoa(1);
                cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_Pessoa.Focus();
            }

            if (tabctl.SelectedTab == tabPage3)
            {
                cb_TipoPessoaH.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                CarregaPessoa(3);
                cb_ID_PessoaH.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_PessoaH.Focus();
            }

            if (tabctl.SelectedTab == tabPage5)
            {
                cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                CarregaPessoa(3);
                cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_PessoaP.Focus();
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            #region CONSULTA CONTA
            if (tabctl.SelectedTab.Name == tabPage5.Name)
            {
                try
                {
                    BLL_CReceber = new BLL_CReceber();
                    CReceber = new DTO_CReceber();

                    CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    CReceber.GrupoConta = mk_ContaP.Text;
                    CReceber.Documento = txt_DocumentoP.Text;
                    CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                    CReceber.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                    CReceber.Situacao = 1;
                    CReceber.Filtra_Boleto = true;
                    CReceber.Boleto = ck_Gerado.Checked;
                    CReceber.Ordena_Por = 2;

                    /*
                    FILTRO BUSCA (DATA)
                    0 - BAIXA
                    1 - EMISSÃO
                    2 - VENCIMENTO
                    */

                    if (cb_Periodo.SelectedIndex == 0)
                    {
                        CReceber.Consulta_Baixa.Filtra = true;
                        CReceber.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        CReceber.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }

                    if (cb_Periodo.SelectedIndex == 1)
                    {
                        CReceber.Consulta_Emissao.Filtra = true;
                        CReceber.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        CReceber.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }

                    if (cb_Periodo.SelectedIndex == 2)
                    {
                        CReceber.Consulta_Vencimento.Filtra = true;
                        CReceber.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        CReceber.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                    DataTable _DT = new DataTable();
                    _DT = BLL_CReceber.Busca(CReceber);
                    dg_CReceber.DataSource = _DT;
                }
                catch (Exception)
                {
                    MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                }
            }
            #endregion

            #region CONSULTA BOLETOS
            if (tabctl.SelectedTab.Name == tabPage3.Name)
            {
                BLL_Boleto = new BLL_Boleto();
                Boleto = new DTO_Boleto();

                Boleto.TipoPessoa = Convert.ToInt32(cb_TipoPessoaH.SelectedValue);
                Boleto.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaH.SelectedValue);
                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                if (mk_DataInicialP.Text.Replace(@"/", "").Trim() != string.Empty &&
                     mk_DataFinalP.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    if (cb_PeriodoBoleto.SelectedIndex == 0)
                    {
                        Boleto.Consulta_Baixa.Filtra = true;
                        Boleto.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicialP.Text);
                        Boleto.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinalP.Text);
                    }

                    if (cb_PeriodoBoleto.SelectedIndex == 1)
                    {
                        Boleto.Consulta_Emissao.Filtra = true;
                        Boleto.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicialP.Text);
                        Boleto.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinalP.Text);
                    }

                    if (cb_PeriodoBoleto.SelectedIndex == 2)
                    {
                        Boleto.Consulta_Vencimento.Filtra = true;
                        Boleto.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicialP.Text);
                        Boleto.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinalP.Text);
                    }
                }

                if (cb_sit_Boleto.Text == "TODOS")
                    Boleto.Filtra_Liquidado = false;
                else
                {
                    Boleto.Filtra_Liquidado = true;
                    if (cb_sit_Boleto.Text == "LIQUIDADOS")
                        Boleto.Liquidado = true;

                    if (cb_sit_Boleto.Text == "EM ABERTO")
                        Boleto.Liquidado = false;
                }

                Boleto.Filtra_Cancelado = true;
                Boleto.Cancelado = false;

                DataTable _DT = new DataTable();
                _DT = BLL_Boleto.Busca(Boleto);
                dg_Boletos.DataSource = _DT;

                util_dados.CarregaCampo(this, _DT, gb_Boleto);
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);

                Config(StatusForm.Consulta);
            }
            #endregion       
        }

        public override void Gravar()
        {
            try
            {
                int aux = 0;
                for (int i = 0; i <= dg_Boletos.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_Boletos.Rows[i].Cells["col_SelecionaBoleto"].Value) == true)
                        aux++;

                if (aux == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                    return;
                }

                if (aux > 1)
                {
                    MessageBox.Show(util_msg.msg_registroUnico, this.Text);
                    return;
                }

                if (ck_Remessa.Checked == true &&
                    ck_Altera_Data.Checked == false)
                {
                    MessageBox.Show(util_msg.msg_BoletoRemessa, this.Text);
                    return;
                }

                BLL_Boleto = new BLL_Boleto();
                Boleto = new DTO_Boleto();

                Boleto.ID = Convert.ToInt32(txt_ID.Text);
                Boleto.NossoNumero = txt_NossoNumero.Text;
                Boleto.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Boleto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Boleto.Valor = Convert.ToDouble(txt_Valor.Text);
                Boleto.Desconto = Convert.ToDouble(txt_Desconto.Text);
                Boleto.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
                Boleto.Emissao = Convert.ToDateTime(mk_Emissao.Text);
                Boleto.Vencimento = Convert.ToDateTime(mk_Vencimento.Text);
                Boleto.Documento = txt_Documento.Text;
                Boleto.Liquidado = Convert.ToBoolean(ck_Liquidado.Checked);

                if (ck_Remessa.Checked == true)
                {
                    Boleto.Remessa = false;
                    Boleto.Movimento_Remessa = 2;
                }
                else
                {
                    Boleto.Remessa = false;
                    Boleto.Movimento_Remessa = 1;
                }

                int obj = BLL_Boleto.Grava(Boleto);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();

                    #region CRIA IMAGEM CODIDO DE BARRAS BOLETO
                    Boleto = new DTO_Boleto();
                    Boleto.ID = obj;
                    Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    DataTable _DT = new DataTable();

                    _DT = BLL_Boleto.Busca(Boleto);

                    DRBoleto = _DT.Rows[0];
                    Config_Banco Config_Banco;
                    Barra2de5 cb = null;
                    string _NossoNumero = string.Empty;

                    switch (Convert.ToInt32(DRBoleto["ID_Banco"]))
                    {
                        case 33: //SANTANDER
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            cb = new Barra2de5(Config_Banco.Santander_CodigoBarra().ToString(), 1, 50, Config_Banco.Santander_CodigoBarra().ToString().Length);
                            break;

                        case 756: //SICOOB
                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 5, 5);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString());
                            cb = new Barra2de5(Config_Banco.Sicoob_CodigoBarra().ToString(), 1, 50, Config_Banco.Sicoob_CodigoBarra().ToString().Length);
                            break;

                        case 104: //CAIXA
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            cb = new Barra2de5(Config_Banco.Caixa_CodigoBarra().ToString(), 1, 50, Config_Banco.Caixa_CodigoBarra().ToString().Length);
                            break;

                        case 237: //BRADESCO
                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 9, 9);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString(), DRBoleto["Conta"].ToString());
                            cb = new Barra2de5(Config_Banco.Bradesco_CodigoBarra().ToString(), 1, 50, Config_Banco.Bradesco_CodigoBarra().ToString().Length);
                            break;
                    }

                    cb.ToBitmap().Save(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg");

                    FileStream Imagem = default(FileStream);
                    StreamReader ConfigImagem = default(StreamReader);
                    Imagem = new FileStream(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
                    ConfigImagem = new StreamReader(Imagem);
                    byte[] arqByteArray = new byte[Imagem.Length];
                    Imagem.Read(arqByteArray, 0, Convert.ToInt32(Imagem.Length));
                    #endregion

                    Boleto.Imagem = Imagem;
                    Boleto.ArqByteArray = (object)arqByteArray;

                    BLL_Boleto.Grava_Barra(Boleto);
                    Imagem.Dispose();

                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                    tabctl.SelectedTab = tabPage3;
                    Pesquisa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Excluir()
        {
            int aux = 0;

            for (int i = 0; i <= dg_Boletos.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Boletos.Rows[i].Cells["col_SelecionaBoleto"].Value) == true)
                    aux++;

            if (aux == 0)
            {
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                return;
            }

            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, "EXCLUIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                for (int i = 0; i <= dg_Boletos.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_Boletos.Rows[i].Cells["col_SelecionaBoleto"].Value) == true)
                    {
                        BLL_Boleto = new BLL_Boleto();
                        Boleto = new DTO_Boleto();

                        Boleto.ID = Convert.ToInt32(dg_Boletos.Rows[i].Cells["col_ID_Boleto"].Value);

                        if (Convert.ToBoolean(dg_Boletos.Rows[i].Cells["col_RemessaBaixa"].Value.ToString()) == true)
                            Boleto.Remessa = false;
                        else
                            Boleto.Remessa = true;

                        Boleto.Movimento_Remessa = 3;
                        Boleto.Cancelado = true;

                        BLL_Boleto.Exclui(Boleto);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

            MessageBox.Show(util_msg.msg_Exclui, this.Text);
            tabctl.SelectedTab = tabPage3;
            Pesquisa();
        }

        public override void Imprimir()
        {
            #region IMPRIME MATRICIAL
            if (Tipo == Tipo_Boleto.Matricial)
            {
                Imprime_Matricial();

                return;
            }
            #endregion

            bool ImprimiResumo = false;

            DialogResult msgbox = MessageBox.Show(util_msg.msg_ResumoContaBoleto, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                ImprimiResumo = true;

            if (msgbox == DialogResult.Cancel)
                return;

            string rpt_Nome = "";
            string LinhaDigitavel = "";
            string Caminhorpt = "";
            string NossoNumero = "";
            string Resumo = "";
            bool ImpressaoA4 = false;

            LocalReport rpt = new LocalReport();
            util_Impressao imp = new util_Impressao();
            PrintDialog EscolheImpressora = new PrintDialog();
            PrintDocument documento;

            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
            }
            else
                return;

            BLL_Boleto = new BLL_Boleto();
            Boleto = new DTO_Boleto();

            for (int i = 0; i <= dg_Boletos.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Boletos.Rows[i].Cells["col_SelecionaBoleto"].Value) == true)
                {
                    Boleto.ID = Convert.ToInt32(dg_Boletos.Rows[i].Cells["col_ID_Boleto"].Value);
                    Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    if (cb_sit_Boleto.Text == "TODOS")
                        Boleto.Filtra_Liquidado = false;
                    else
                    {
                        Boleto.Filtra_Liquidado = true;
                        if (cb_sit_Boleto.Text == "LIQUIDADOS")
                            Boleto.Liquidado = true;

                        if (cb_sit_Boleto.Text == "EM ABERTO")
                            Boleto.Liquidado = false;
                    }

                    DataTable _DT = new DataTable();
                    _DT = BLL_Boleto.Busca(Boleto);

                    DRBoleto = _DT.Rows[0];

                    Config_Banco Config_Banco;

                    #region IMPRESSÃO A4

                    ImpressaoA4 = true;
                    rpt = new LocalReport();

                    string _NossoNumero = string.Empty;

                    #region CONFIGURAÇÕES DE BANCO
                    switch (Convert.ToInt32(DRBoleto["ID_Banco"]))
                    {
                        #region SANTANDER 033
                        case 33:
                            if (ImprimiResumo == true)
                                rpt_Nome = "rpt_Boleto033.rdlc";
                            else
                                rpt_Nome = "rpt_Boleto033SR.rdlc";

                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            LinhaDigitavel = Config_Banco.Santander_LinhaDigitavel();
                            NossoNumero = Config_Banco.Santander_NossoNumero(DRBoleto["NossoNumero"].ToString());
                            break;
                        #endregion

                        #region SICOOB 756
                        case 756:
                            switch (Parametro_Empresa.Tipo_Sistema)
                            {
                                case Tipo_Sistema.Comercial:
                                    if (ImprimiResumo == true)
                                        rpt_Nome = "rpt_Boleto756.rdlc";
                                    else
                                        rpt_Nome = "rpt_Boleto756SR.rdlc";
                                    break;

                                case Tipo_Sistema.Imobiliaria:
                                    if (ImprimiResumo == true)
                                        rpt_Nome = "rpt_Boleto756_IM.rdlc";
                                    else
                                        rpt_Nome = "rpt_Boleto756SR_IM.rdlc";
                                    break;
                            }
                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 5, 5);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString());
                            LinhaDigitavel = Config_Banco.Sicoob_LinhaDigitavel();
                            NossoNumero = Config_Banco.Sicoob_NossoNumero(DRBoleto["Agencia"].ToString(), DRBoleto["Cod_Cedente"].ToString().PadLeft(10, '0'), _NossoNumero);
                            break;
                        #endregion

                        #region CAIXA 104
                        case 104:
                            if (ImprimiResumo == true)
                                rpt_Nome = "rpt_Boleto104.rdlc";
                            else
                                rpt_Nome = "rpt_Boleto104SR.rdlc";

                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            LinhaDigitavel = Config_Banco.Caixa_LinhaDigitavel();
                            NossoNumero = Config_Banco.Caixa_NossoNumero(DRBoleto["NossoNumero"].ToString(), DRBoleto["Carteira"].ToString());

                            //Inclui digito verificador no codigo do cedente
                            _DT.Rows[0]["Cod_Cedente"] = _DT.Rows[0]["Cod_Cedente"] + "-" + Config_Banco.Caixa_DVCedente(_DT.Rows[0]["Cod_Cedente"].ToString());

                            _DT.AcceptChanges();
                            break;
                        #endregion

                        #region BRADESCO 237
                        case 237:
                            if (ImprimiResumo == true)
                                rpt_Nome = "rpt_Boleto237.rdlc";
                            else
                                rpt_Nome = "rpt_Boleto237SR.rdlc";

                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 9, 9);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString(), DRBoleto["Conta"].ToString());
                            LinhaDigitavel = Config_Banco.Bradesco_LinhaDigitavel();
                            NossoNumero = Config_Banco.Bradesco_NossoNumero(_NossoNumero, DRBoleto["Carteira"].ToString());

                            //Inclui digito verificador no codigo do cedente
                            _DT.Rows[0]["Cod_Cedente"] = _DT.Rows[0]["Cod_Cedente"] + "-" + Config_Banco.Caixa_DVCedente(_DT.Rows[0]["Cod_Cedente"].ToString());

                            _DT.AcceptChanges();
                            break;
                            #endregion
                    }
                    #endregion

                    string Juros = util_dados.Boleto_Juros(Convert.ToDouble(DRBoleto["Valor"]), Convert.ToDouble(DRBoleto["Juros"]), Convert.ToInt32(DRBoleto["DiasJuros"]));
                    string Multa = util_dados.Boleto_Multa(Convert.ToDouble(DRBoleto["Valor"]), Convert.ToDouble(DRBoleto["Multa"]), Convert.ToInt32(DRBoleto["DiasMulta"]));

                    #region BUSCA CONTA
                    Boleto.ID = Convert.ToInt32(DRBoleto["ID_Boleto"]);

                    DTBoletoControle = BLL_Boleto.Busca_Controle(Boleto);

                    if (DTBoletoControle.Rows.Count > 0)
                    {
                        ID_Conta = "";
                        for (int x = 0; x <= DTBoletoControle.Rows.Count - 1; x++)
                        {
                            DR = DTBoletoControle.Rows[x];
                            ID_Conta = ID_Conta + DR["ID_Conta"].ToString();

                            if (x != DTBoletoControle.Rows.Count - 1)
                                ID_Conta = ID_Conta + ", ";
                        }
                        BLL_CReceber = new BLL_CReceber();
                        CReceber = new DTO_CReceber();

                        CReceber.ListaID = ID_Conta;

                        DTBoletoControle = BLL_CReceber.Busca_Resumo(CReceber);

                        if (ImprimiResumo == false)
                            Resumo = DTBoletoControle.Rows[0]["ResumoParcela"].ToString();
                    }
                    #endregion

                    Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                    rpt.ReportPath = Caminhorpt;

                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                    DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                    Pessoa.TipoPessoa = Convert.ToInt32(DRBoleto["TipoPessoa"]);
                    Pessoa.ID = Convert.ToInt32(DRBoleto["ID_Pessoa"]);

                    DTR_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

                    ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                    ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", DTR_Pessoa);
                    ReportDataSource ds_Boleto = new ReportDataSource("ds_Cedente", _DT);
                    ReportDataSource ds_CReceber = new ReportDataSource("ds_CReceber", DTBoletoControle);

                    ReportParameter p1 = new ReportParameter("Juros", Juros);
                    ReportParameter p2 = new ReportParameter("Multa", Multa);
                    ReportParameter p3 = new ReportParameter("LinhaDigitavel", LinhaDigitavel);
                    ReportParameter p4 = new ReportParameter("NossoNumero", NossoNumero);
                    ReportParameter p5 = new ReportParameter("Resumo", Resumo);
                    rpt.DataSources.Add(ds_Empresa);
                    rpt.DataSources.Add(ds_Pessoa);
                    rpt.DataSources.Add(ds_Boleto);
                    rpt.DataSources.Add(ds_CReceber);
                    rpt.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                    rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5 });

                    imp.Cria_lst_Relatorio(rpt);
                }
            #endregion

            if (ImpressaoA4 == true)
            {
                imp.Imprime_lst_Relatorio(documento);
                imp = null;
            }
        }

        //ALTERADO PARA GERAR PDF
        public override void Visualizar()
        {
            bool ImprimiResumo = false;

            DialogResult msgbox = MessageBox.Show(util_msg.msg_ResumoContaBoleto, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                ImprimiResumo = true;

            if (msgbox == DialogResult.Cancel)
                return;

            string rpt_Nome = "";
            string LinhaDigitavel = "";
            string CaminhoArquivo = string.Empty;
            string Caminhorpt = "";
            string NossoNumero = "";
            string Resumo = "";

            LocalReport rpt = new LocalReport();
            util_Impressao imp = new util_Impressao();

            msgbox = new DialogResult();
            msgbox = Pesquisa_Pasta.ShowDialog();

            if (msgbox == DialogResult.Cancel)
                return;

            int TamanhoCaminho = Pesquisa_Pasta.SelectedPath.Length;
            string Barra = Pesquisa_Pasta.SelectedPath.Substring(TamanhoCaminho - 1);

            if (Barra == @"\")
                CaminhoArquivo = Pesquisa_Pasta.SelectedPath;
            else
                CaminhoArquivo = Pesquisa_Pasta.SelectedPath + @"\";

            if (CaminhoArquivo == string.Empty)
                return;

            BLL_Boleto = new BLL_Boleto();
            Boleto = new DTO_Boleto();

            for (int i = 0; i <= dg_Boletos.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Boletos.Rows[i].Cells["col_SelecionaBoleto"].Value) == true)
                {
                    Boleto.ID = Convert.ToInt32(dg_Boletos.Rows[i].Cells["col_ID_Boleto"].Value);
                    Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                    if (cb_sit_Boleto.Text == "TODOS")
                        Boleto.Filtra_Liquidado = false;
                    else
                    {
                        Boleto.Filtra_Liquidado = true;
                        if (cb_sit_Boleto.Text == "LIQUIDADOS")
                            Boleto.Liquidado = true;

                        if (cb_sit_Boleto.Text == "EM ABERTO")
                            Boleto.Liquidado = false;
                    }

                    DataTable _DT = new DataTable();
                    _DT = BLL_Boleto.Busca(Boleto);

                    DRBoleto = _DT.Rows[0];

                    Config_Banco Config_Banco;

                    rpt = new LocalReport();

                    string _NossoNumero = string.Empty;

                    #region CONFIGURAÇÕES DE BANCO
                    switch (Convert.ToInt32(DRBoleto["ID_Banco"]))
                    {
                        #region SANTANDER 033
                        case 33:
                            if (ImprimiResumo == true)
                                rpt_Nome = "rpt_Boleto033.rdlc";
                            else
                                rpt_Nome = "rpt_Boleto033SR.rdlc";

                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            LinhaDigitavel = Config_Banco.Santander_LinhaDigitavel();
                            NossoNumero = Config_Banco.Santander_NossoNumero(DRBoleto["NossoNumero"].ToString());
                            break;
                        #endregion

                        #region SICOOB 756
                        case 756:

                            switch (Parametro_Empresa.Tipo_Sistema)
                            {
                                case Tipo_Sistema.Comercial:
                                    if (ImprimiResumo == true)
                                        rpt_Nome = "rpt_Boleto756.rdlc";
                                    else
                                        rpt_Nome = "rpt_Boleto756SR.rdlc";
                                    break;

                                case Tipo_Sistema.Imobiliaria:
                                    if (ImprimiResumo == true)
                                        rpt_Nome = "rpt_Boleto756_IM.rdlc";
                                    else
                                        rpt_Nome = "rpt_Boleto756SR_IM.rdlc";
                                    break;
                            }

                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 5, 5);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString().Substring(0, 4));
                            LinhaDigitavel = Config_Banco.Sicoob_LinhaDigitavel();
                            NossoNumero = Config_Banco.Sicoob_NossoNumero(DRBoleto["Agencia"].ToString(), DRBoleto["Cod_Cedente"].ToString().PadLeft(10, '0'), _NossoNumero);
                            break;
                        #endregion

                        #region CAIXA 104
                        case 104:
                            if (ImprimiResumo == true)
                                rpt_Nome = "rpt_Boleto104.rdlc";
                            else
                                rpt_Nome = "rpt_Boleto104SR.rdlc";

                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            LinhaDigitavel = Config_Banco.Caixa_LinhaDigitavel();
                            NossoNumero = Config_Banco.Caixa_NossoNumero(DRBoleto["NossoNumero"].ToString(), DRBoleto["Carteira"].ToString());

                            //Inclui digito verificador no codigo do cedente
                            _DT.Rows[0]["Cod_Cedente"] = _DT.Rows[0]["Cod_Cedente"] + "-" + Config_Banco.Caixa_DVCedente(_DT.Rows[0]["Cod_Cedente"].ToString());

                            _DT.AcceptChanges();
                            break;
                        #endregion

                        #region BRADESCO 237
                        case 237:
                            switch (Parametro_Empresa.Tipo_Sistema)
                            {
                                case Tipo_Sistema.Comercial:
                                    if (ImprimiResumo == true)
                                        rpt_Nome = "rpt_Boleto237.rdlc";
                                    else
                                        rpt_Nome = "rpt_Boleto237SR.rdlc";
                                    break;
                                case Tipo_Sistema.Imobiliaria:
                                    if (ImprimiResumo == true)
                                        rpt_Nome = "rpt_Boleto237_IM.rdlc";
                                    else
                                        rpt_Nome = "rpt_Boleto237SR_IM.rdlc";
                                    break;
                            }

                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 9, 9);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString(), DRBoleto["Conta"].ToString());
                            LinhaDigitavel = Config_Banco.Bradesco_LinhaDigitavel();
                            NossoNumero = Config_Banco.Bradesco_NossoNumero(_NossoNumero, DRBoleto["Carteira"].ToString());

                            //Inclui digito verificador no codigo do cedente
                            _DT.Rows[0]["Cod_Cedente"] = _DT.Rows[0]["Cod_Cedente"] + "-" + Config_Banco.Caixa_DVCedente(_DT.Rows[0]["Cod_Cedente"].ToString());

                            _DT.AcceptChanges();
                            break;
                            #endregion
                    }
                    #endregion

                    string Juros = util_dados.Boleto_Juros(Convert.ToDouble(DRBoleto["Valor"]), Convert.ToDouble(DRBoleto["Juros"]), Convert.ToInt32(DRBoleto["DiasJuros"]));
                    string Multa = util_dados.Boleto_Multa(Convert.ToDouble(DRBoleto["Valor"]), Convert.ToDouble(DRBoleto["Multa"]), Convert.ToInt32(DRBoleto["DiasMulta"]));

                    #region BUSCA CONTA
                    Boleto.ID = Convert.ToInt32(DRBoleto["ID_Boleto"]);

                    DTBoletoControle = BLL_Boleto.Busca_Controle(Boleto);

                    if (DTBoletoControle.Rows.Count > 0)
                    {
                        ID_Conta = "";
                        for (int x = 0; x <= DTBoletoControle.Rows.Count - 1; x++)
                        {
                            DR = DTBoletoControle.Rows[x];
                            ID_Conta = ID_Conta + DR["ID_Conta"].ToString();

                            if (x != DTBoletoControle.Rows.Count - 1)
                                ID_Conta = ID_Conta + ", ";
                        }
                        BLL_CReceber = new BLL_CReceber();
                        CReceber = new DTO_CReceber();

                        CReceber.ListaID = ID_Conta;

                        DTBoletoControle = BLL_CReceber.Busca_Resumo(CReceber);

                        if (ImprimiResumo == false)
                            Resumo = DTBoletoControle.Rows[0]["ResumoParcela"].ToString();
                    }
                    #endregion

                    Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                    rpt.ReportPath = Caminhorpt;

                    BLL_Pessoa = new BLL_Pessoa();
                    Pessoa = new DTO_Pessoa();

                    Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                    DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                    Pessoa.TipoPessoa = Convert.ToInt32(DRBoleto["TipoPessoa"]);
                    Pessoa.ID = Convert.ToInt32(DRBoleto["ID_Pessoa"]);

                    DTR_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

                    ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                    ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", DTR_Pessoa);
                    ReportDataSource ds_Boleto = new ReportDataSource("ds_Cedente", _DT);
                    ReportDataSource ds_CReceber = new ReportDataSource("ds_CReceber", DTBoletoControle);

                    ReportParameter p1 = new ReportParameter("Juros", Juros);
                    ReportParameter p2 = new ReportParameter("Multa", Multa);
                    ReportParameter p3 = new ReportParameter("LinhaDigitavel", LinhaDigitavel);
                    ReportParameter p4 = new ReportParameter("NossoNumero", NossoNumero);
                    ReportParameter p5 = new ReportParameter("Resumo", Resumo);
                    rpt.DataSources.Add(ds_Empresa);
                    rpt.DataSources.Add(ds_Pessoa);
                    rpt.DataSources.Add(ds_Boleto);
                    rpt.DataSources.Add(ds_CReceber);
                    rpt.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                    rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5 });

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    byte[] bytes = rpt.Render("Pdf", null, out mimeType, out encoding, out extension, out streamids, out warnings);

                    string NomeArquivo = DTR_Pessoa.Rows[0]["Descricao"].ToString();

                    if (NomeArquivo.Length > 20)
                        NomeArquivo = NomeArquivo.Substring(0, 20);

                    int aux = 0;

                    DirectoryInfo Dir = new DirectoryInfo(CaminhoArquivo);
                    FileInfo[] Files = Dir.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);
                    foreach (FileInfo File in Files)
                    {
                        // Retira o diretório iformado inicialmente
                        string FileName = File.FullName.Replace(Dir.FullName, "");
                        if (FileName.IndexOf(NomeArquivo) != -1)
                            aux++;
                    }

                    if (aux == 0)
                        NomeArquivo = CaminhoArquivo + NomeArquivo + ".pdf";
                    else
                        NomeArquivo = CaminhoArquivo + NomeArquivo + "(" + aux + ").pdf";

                    FileStream fs = new FileStream(NomeArquivo, FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            MessageBox.Show(util_msg.msg_BoletoGerado, this.Text);
        }
        #endregion

        #region FORM
        private void UI_Boleto_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Boleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Acrescimo.Focused == true ||
                txt_Desconto.Focused == true ||
                txt_Valor.Focused ||
                txt_AcrescimoB.Focused == true ||
                txt_DescontoB.Focused == true ||
                txt_ValorG.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Boleto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_PlanoConta_Consulta frm = new UI_PlanoConta_Consulta();
            frm.ShowDialog();
            mk_ContaP.Text = frm.Cod_Conta;
        }

        private void bt_GerarBoleto_Click(object sender, EventArgs e)
        {
            BLL_CReceber = new BLL_CReceber();
            CReceber = new DTO_CReceber();

            if (ck_Agrupar.Checked == true)
            {
                #region BOLETO AGRUPADO
                int aux = 0;

                int[] intID_Conta;

                for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                        aux++;

                intID_Conta = new int[aux];

                for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {
                        intID_Conta[aux - 1] = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID"].Value);
                        aux--;
                    }

                BLL_Boleto = new BLL_Boleto();
                Boleto = new DTO_Boleto();

                Boleto.TipoPessoa = Convert.ToInt32(cb_TipoPessoaG.SelectedValue);
                Boleto.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaG.SelectedValue);
                Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Boleto.ID_Cedente = Convert.ToInt32(cb_Cedente.SelectedValue);
                Boleto.Valor = Convert.ToDouble(txt_ValorG.Text);
                Boleto.Desconto = Convert.ToDouble(txt_DescontoG.Text);
                Boleto.Acrescimo = Convert.ToDouble(txt_AcrescimoG.Text);
                Boleto.Emissao = DateTime.Now;
                Boleto.Vencimento = Convert.ToDateTime(mk_VencimentoL.Text);
                Boleto.Documento = txt_DocumentoL.Text;
                Boleto.Liquidado = false;
                Boleto.Remessa = false;
                Boleto.Movimento_Remessa = 1;

                int obj = BLL_Boleto.Grava(Boleto);

                if (obj > 1)
                {
                    Boleto.ID = obj;
                    Boleto.NossoNumero = cb_Cedente.SelectedValue.ToString().PadLeft(2, '0') + obj.ToString().PadLeft(10, '0');

                    BLL_Boleto.Altera_NossoNumero(Boleto);

                    #region CRIA IMAGEM DO CODIGO DE BARRAS
                    DataTable _DT = new DataTable();
                    _DT = BLL_Boleto.Busca(Boleto);
                    DRBoleto = _DT.Rows[0];

                    Config_Banco Config_Banco;
                    Barra2de5 cb = null;

                    string _NossoNumero = string.Empty;

                    #region CONFIGURAÇÕES DOS BANCOS
                    switch (Convert.ToInt32(DRBoleto["ID_Banco"]))
                    {
                        case 33: //SANTANDER
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            cb = new Barra2de5(Config_Banco.Santander_CodigoBarra().ToString(), 1, 50, Config_Banco.Santander_CodigoBarra().ToString().Length);
                            break;

                        case 756: //SICOOB
                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 5, 5);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString());
                            cb = new Barra2de5(Config_Banco.Sicoob_CodigoBarra().ToString(), 1, 50, Config_Banco.Sicoob_CodigoBarra().ToString().Length);
                            break;

                        case 104: //CAIXA
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                            cb = new Barra2de5(Config_Banco.Caixa_CodigoBarra().ToString(), 1, 50, Config_Banco.Caixa_CodigoBarra().ToString().Length);
                            break;

                        case 237: //BRADESCO
                            _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 9, 9);
                            Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString(), DRBoleto["Conta"].ToString());
                            cb = new Barra2de5(Config_Banco.Bradesco_CodigoBarra().ToString(), 1, 50, Config_Banco.Bradesco_CodigoBarra().ToString().Length);
                            break;
                    }
                    #endregion

                    cb.ToBitmap().Save(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg");

                    FileStream Imagem = default(FileStream);
                    StreamReader ConfigImagem = default(StreamReader);
                    Imagem = new FileStream(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
                    ConfigImagem = new StreamReader(Imagem);
                    byte[] arqByteArray = new byte[Imagem.Length];
                    Imagem.Read(arqByteArray, 0, Convert.ToInt32(Imagem.Length));
                    #endregion

                    Boleto.Imagem = Imagem;
                    Boleto.ArqByteArray = (object)arqByteArray;

                    BLL_Boleto.Grava_Barra(Boleto);
                    Imagem.Dispose();

                    #region ALTERA CRECEBER A GRAVA CONTROLE DE CONTAS
                    for (int x = 0; x <= intID_Conta.Length - 1; x++)
                    {
                        CReceber.ID = Convert.ToInt32(intID_Conta[x]);
                        CReceber.Boleto = true;
                        CReceber.Altera_Registro = 5;

                        Boleto.ID_Conta = intID_Conta[x];

                        BLL_CReceber.Altera(CReceber);
                        BLL_Boleto.Grava_Controle(Boleto);
                    }
                    #endregion
                }
                MessageBox.Show(util_msg.msg_BoletoGerado, this.Text);
                #endregion
            }
            else
            {
                #region BOLETO SIMPLES (1 POR CONTA)
                BLL_Boleto = new BLL_Boleto();

                for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {
                        Boleto = new DTO_Boleto();
                        Boleto.TipoPessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_TipoPessoa"].Value);
                        Boleto.ID_Pessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID_Pessoa"].Value);
                        Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Boleto.ID_Cedente = Convert.ToInt32(cb_Cedente.SelectedValue);
                        Boleto.Valor = Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_Valor"].Value);
                        Boleto.Desconto = Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_Desconto"].Value);
                        Boleto.Acrescimo = Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_Acrescimo"].Value);
                        Boleto.Emissao = DateTime.Now;
                        Boleto.Vencimento = Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Vencimento"].Value);
                        Boleto.Remessa = false;
                        Boleto.Movimento_Remessa = 1;

                        if (Tipo == Tipo_Boleto.Matricial)
                        {
                            if (txt_DocumentoL.Text.Trim() == string.Empty)
                                Boleto.Documento = dg_CReceber.Rows[i].Cells["col_Documento"].Value.ToString() + " (" + dg_CReceber.Rows[i].Cells["col_Parcela"].Value.ToString().Replace("(0)", "") + ")";
                            else
                                Boleto.Documento = txt_DocumentoL.Text + " (" + dg_CReceber.Rows[i].Cells["col_Parcela"].Value.ToString().Replace("(0)", "") + ")";
                        }
                        else
                            Boleto.Documento = dg_CReceber.Rows[i].Cells["col_Documento"].Value.ToString();

                        Boleto.Liquidado = false;

                        int obj = BLL_Boleto.Grava(Boleto);

                        if (obj > 0)
                        {
                            Boleto.ID = obj;
                            Boleto.NossoNumero = cb_Cedente.SelectedValue.ToString().PadLeft(2, '0') + obj.ToString().PadLeft(10, '0');
                            BLL_Boleto.Altera_NossoNumero(Boleto);

                            #region CRIA IMAGEM DO CODIGO DE BARRAS
                            DataTable _DT = new DataTable();
                            _DT = BLL_Boleto.Busca(Boleto);
                            DRBoleto = _DT.Rows[0];

                            Config_Banco Config_Banco;
                            Barra2de5 cb = null;

                            string _NossoNumero = string.Empty;

                            #region CONFIGURAÇÕES DOS BANCOS
                            switch (Convert.ToInt32(DRBoleto["ID_Banco"]))
                            {
                                case 33: //SANTANDER
                                    Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                                    cb = new Barra2de5(Config_Banco.Santander_CodigoBarra().ToString(), 1, 50, Config_Banco.Santander_CodigoBarra().ToString().Length);
                                    break;

                                case 756: //SICOOB
                                    _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 5, 5);
                                    Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString());
                                    cb = new Barra2de5(Config_Banco.Sicoob_CodigoBarra().ToString(), 1, 50, Config_Banco.Sicoob_CodigoBarra().ToString().Length);
                                    break;

                                case 104: //CAIXA
                                    Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), DRBoleto["NossoNumero"].ToString(), Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString());
                                    cb = new Barra2de5(Config_Banco.Caixa_CodigoBarra().ToString(), 1, 50, Config_Banco.Caixa_CodigoBarra().ToString().Length);
                                    break;

                                case 237: //BRADESCO
                                    _NossoNumero = DRBoleto["NossoNumero"].ToString().Substring(0, 2) + DRBoleto["NossoNumero"].ToString().Substring(DRBoleto["NossoNumero"].ToString().Length - 9, 9);
                                    Config_Banco = new Config_Banco(DRBoleto["Carteira"].ToString(), _NossoNumero, Convert.ToDateTime(DRBoleto["Vencimento"]), Convert.ToDouble(DRBoleto["Valor"]), DRBoleto["Cod_Cedente"].ToString(), DRBoleto["ID_Banco"].ToString(), DRBoleto["Agencia"].ToString(), DRBoleto["Conta"].ToString());
                                    cb = new Barra2de5(Config_Banco.Bradesco_CodigoBarra().ToString(), 1, 50, Config_Banco.Bradesco_CodigoBarra().ToString().Length);
                                    break;
                            }
                            #endregion

                            cb.ToBitmap().Save(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg");

                            FileStream Imagem = default(FileStream);
                            StreamReader ConfigImagem = default(StreamReader);
                            Imagem = new FileStream(Parametro_Sistema.Caminho_Sistema + @"Temp\temp.jpg", FileMode.Open, FileAccess.Read, FileShare.Read);
                            ConfigImagem = new StreamReader(Imagem);
                            byte[] arqByteArray = new byte[Imagem.Length];
                            Imagem.Read(arqByteArray, 0, Convert.ToInt32(Imagem.Length));
                            #endregion

                            Boleto.Imagem = Imagem;
                            Boleto.ArqByteArray = (object)arqByteArray;

                            BLL_Boleto.Grava_Barra(Boleto);
                            Imagem.Dispose();

                            #region ALTERA CONTA E GRAVA CONTROLE
                            CReceber.ID = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID"].Value);
                            CReceber.Boleto = true;
                            CReceber.Altera_Registro = 5;

                            BLL_CReceber.Altera(CReceber);
                            Boleto.ID_Conta = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID"].Value);

                            BLL_Boleto.Grava_Controle(Boleto);
                            #endregion
                        }
                    }

                MessageBox.Show("Boletos Gerados com Sucesso!");
                #endregion
            }
            ck_Agrupar.Checked = false;
            Pesquisa();
        }

        private void bt_Baixar_Click(object sender, EventArgs e)
        {
            int[] IDConta = null;
            int ID_FluxoCaixa;

            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaBaixaBoleto, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            BLL_Boleto = new BLL_Boleto();
            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            BLL_CReceber = new BLL_CReceber();

            FluxoCaixa = new DTO_FluxoCaixa();
            CReceber = new DTO_CReceber();
            Boleto = new DTO_Boleto();

            if (dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_ID_Boleto"].Value.ToString().Trim() != string.Empty)
            {
                int ID_Boleto = Convert.ToInt32(dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_ID_Boleto"].Value);
                double Valor = Convert.ToDouble(txt_ValorFinal.Text);

                Boleto.ID = ID_Boleto;
                Boleto.Desconto = Convert.ToDouble(txt_DescontoB.Text);
                Boleto.Acrescimo = Convert.ToDouble(txt_AcrescimoB.Text) + Convert.ToDouble(txt_Juros.Text) + Convert.ToDouble(txt_Multa.Text);
                Boleto.DataBaixa = Convert.ToDateTime(mk_DataBaixa.Text);

                Boleto.Remessa = true;

                Boleto.Movimento_Remessa = 1;

                Boleto.Liquidado = true;

                BLL_Boleto.Baixa(Boleto);

                FluxoCaixa.ID = 0;
                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FluxoCaixa.Emissao = Convert.ToDateTime(mk_DataBaixa.Text);
                FluxoCaixa.Caixa = Convert.ToInt32(cb_CaixaBaixa.SelectedValue);
                FluxoCaixa.Documento = dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_DocBoleto"].Value.ToString();
                FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_CobrancaBancaria;
                FluxoCaixa.Credito = Valor;
                FluxoCaixa.Debito = 0;
                FluxoCaixa.Informacao = "BOLETO Nº " + dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_NossoNumero"].Value.ToString();
                FluxoCaixa.ID_Cheque = 0;
                FluxoCaixa.Conciliado = true;
                FluxoCaixa.ID_Pagamento = Parametro_Financeiro.ID_PagtoBoleto;
                FluxoCaixa.Planejamento = false;

                ID_FluxoCaixa = BLL_FluxoCaixa.Grava(FluxoCaixa);

                DTBoletoControle = BLL_Boleto.Busca_Controle(Boleto);

                #region BAIXA CONTA
                if (DTBoletoControle.Rows.Count > 0)
                {
                    IDConta = new int[DTBoletoControle.Rows.Count];
                    for (int x = 0; x <= DTBoletoControle.Rows.Count - 1; x++)
                    {
                        DR = DTBoletoControle.Rows[x];
                        IDConta[x] = Convert.ToInt32(DR["ID_Conta"]);
                        CReceber.ID = Convert.ToInt32(DR["ID_Conta"]);
                        CReceber.Situacao = 2;
                        CReceber.DataBaixa = Convert.ToDateTime(mk_DataBaixa.Text);
                        if (DTBoletoControle.Rows.Count == 1)
                        {
                            CReceber.Desconto = Convert.ToDouble(txt_DescontoB.Text);
                            CReceber.Acrescimo = Convert.ToDouble(txt_AcrescimoB.Text) + Convert.ToDouble(txt_Juros.Text) + Convert.ToDouble(txt_Multa.Text);
                        }
                        else
                        {
                            CReceber.Desconto = 0;
                            CReceber.Acrescimo = 0;
                        }
                        CReceber.Altera_Registro = 6;

                        BLL_CReceber.Altera(CReceber);
                    }
                }
                #endregion

                #region GRAVA CONTROLE
                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                FluxoCaixa = new DTO_FluxoCaixa();

                for (int x = 0; x <= IDConta.Length - 1; x++)
                {
                    FluxoCaixa.ID = ID_FluxoCaixa;
                    FluxoCaixa.ID_CPagar = 0;
                    FluxoCaixa.ID_CReceber = IDConta[x];

                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                }
                #endregion
            }

            MessageBox.Show(util_msg.msg_Baixa, this.Text);

            Pesquisa();

            txt_AcrescimoB.Text = "0,00";
            txt_DescontoB.Text = "0,00";
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(1);
        }

        private void cb_TipoPessoaH_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(2);
        }

        private void cb_TipoPessoaP_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(3);
        }

        private void cb_TipoPessoaG_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(4);
        }

        private void cb_ID_PessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_PessoaP.SelectedIndex = -1;
        }

        private void cb_ID_PessoaH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_PessoaH.SelectedIndex = -1;
        }
        #endregion

        #region CHECKBOX
        private void ck_Agrupar_CheckedChanged(object sender, EventArgs e)
        {
            int aux = 0;
            double Valor = 0;
            double Desconto = 0;
            double Acrescimo = 0;

            if (ck_Agrupar.Checked == true)
            {
                gb_Agrupar.Enabled = true;

                for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {
                        Valor = Valor + Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_Valor"].Value);
                        Desconto = Desconto + Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_Desconto"].Value);
                        Acrescimo = Acrescimo + Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_Acrescimo"].Value);
                        aux++;
                    }

                if (aux == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                    ck_Agrupar.Checked = false;
                    return;
                }

                for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                    if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                    {
                        cb_TipoPessoaG.SelectedValue = dg_CReceber.Rows[i].Cells["col_TipoPessoa"].Value;
                        cb_ID_PessoaG.Text = dg_CReceber.Rows[i].Cells["col_DescricaoPessoa"].Value.ToString();
                        mk_VencimentoL.Text = dg_CReceber.Rows[i].Cells["col_Vencimento"].Value.ToString();
                        txt_DocumentoL.Text = dg_CReceber.Rows[i].Cells["col_Documento"].Value.ToString();
                        break;
                    }

                txt_DescontoG.Text = util_dados.ConfigNumDecimal(Desconto, 2);
                txt_AcrescimoG.Text = util_dados.ConfigNumDecimal(Acrescimo, 2);
                txt_ValorG.Text = util_dados.ConfigNumDecimal(Valor, 2);
            }
            else
            {
                gb_Agrupar.Enabled = false;
            }
        }

        private void ck_Calcula_Juro_CheckedChanged(object sender, EventArgs e)
        {
            Calcula_Boleto(2);
        }

        private void ck_Remessa_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Remessa.Checked == true)
            {
                txt_Valor.ReadOnly = true;
                txt_Valor.BackColor = Color.White;

                txt_Acrescimo.ReadOnly = true;
                txt_Acrescimo.BackColor = Color.White;

                txt_Desconto.ReadOnly = true;
                txt_Desconto.BackColor = Color.White;

                mk_Emissao.ReadOnly = true;
                mk_Emissao.BackColor = Color.White;

                txt_Documento.ReadOnly = true;
                txt_Documento.BackColor = Color.White;

                cb_TipoPessoa.Enabled = false;
                cb_ID_Pessoa.Enabled = false;
            }
            else
            {
                txt_Valor.ReadOnly = false;
                txt_Valor.BackColor = Color.LightGray;

                txt_Acrescimo.ReadOnly = false;
                txt_Acrescimo.BackColor = Color.LightGray;

                txt_Desconto.ReadOnly = false;
                txt_Desconto.BackColor = Color.LightGray;

                mk_Emissao.ReadOnly = false;
                mk_Emissao.BackColor = Color.LightGray;

                txt_Documento.ReadOnly = false;
                txt_Documento.BackColor = Color.LightGray;

                mk_Vencimento.ReadOnly = false;
                mk_Vencimento.BackColor = Color.LightGray;

                cb_TipoPessoa.Enabled = true;
                cb_ID_Pessoa.Enabled = true;
            }
        }

        private void ck_Altera_Data_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Remessa.Checked == true &&
                ck_Altera_Data.Checked == false)
            {
                mk_Vencimento.ReadOnly = true;
                mk_Vencimento.BackColor = Color.White;
            }
            else
            {
                mk_Vencimento.ReadOnly = false;
                mk_Vencimento.BackColor = Color.LightGray;
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_Boleto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ID_Conta = "";
                BLL_Boleto = new BLL_Boleto();
                Boleto = new DTO_Boleto();

                if (util_dados.Verifica_int(txt_ID_Boleto.Text) > 0)
                {
                    Boleto.ID = Convert.ToInt32(txt_ID_Boleto.Text);

                    DTBoletoControle = BLL_Boleto.Busca_Controle(Boleto);
                    if (DTBoletoControle.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DTBoletoControle.Rows.Count - 1; i++)
                        {
                            DR = DTBoletoControle.Rows[i];
                            ID_Conta = ID_Conta + DR["ID_Conta"].ToString();

                            if (i != DTBoletoControle.Rows.Count - 1)
                                ID_Conta = ID_Conta + ", ";
                        }
                        BLL_CReceber = new BLL_CReceber();
                        CReceber = new DTO_CReceber();

                        CReceber.ListaID = ID_Conta;

                        DTBoletoControle = BLL_CReceber.Busca_Resumo(CReceber);
                        dg_Contas.DataSource = DTBoletoControle;
                    }
                    else
                        dg_Contas.DataSource = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void txt_AcrescimoB_Leave(object sender, EventArgs e)
        {
            if (txt_AcrescimoB.Text.Trim() == string.Empty)
                txt_AcrescimoB.Text = "0";

            txt_AcrescimoB.Text = util_dados.ConfigNumDecimal(txt_AcrescimoB.Text, 2);

            Calcula_Boleto(2);
        }

        private void txt_DescontoB_Leave(object sender, EventArgs e)
        {
            if (txt_DescontoB.Text.Trim() == string.Empty)
                txt_DescontoB.Text = "0";

            txt_DescontoB.Text = util_dados.ConfigNumDecimal(txt_DescontoB.Text, 2);

            Calcula_Boleto(2);
        }

        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (txt_Valor.Text.Trim() == string.Empty)
                txt_Valor.Text = "0";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }

        private void txt_Acrescimo_Leave(object sender, EventArgs e)
        {
            if (txt_Acrescimo.Text.Trim() == string.Empty)
                txt_Acrescimo.Text = "0";

            txt_Acrescimo.Text = util_dados.ConfigNumDecimal(txt_Acrescimo.Text, 2);

            Calcula_Boleto(1);
        }

        private void txt_Desconto_Leave(object sender, EventArgs e)
        {
            if (txt_Desconto.Text.Trim() == string.Empty)
                txt_Desconto.Text = "0";

            txt_Desconto.Text = util_dados.ConfigNumDecimal(txt_Desconto.Text, 2);

            Calcula_Boleto(1);
        }

        private void txt_DescontoG_Leave(object sender, EventArgs e)
        {
            if (txt_DescontoG.Text.Trim() == string.Empty)
                txt_DescontoG.Text = "0";

            txt_DescontoG.Text = util_dados.ConfigNumDecimal(txt_DescontoG.Text, 2);

            //   txt_ValorG.Text = util_dados.ConfigNumDecimal(
        }

        private void txt_AcrescimoG_Leave(object sender, EventArgs e)
        {
            if (txt_AcrescimoG.Text.Trim() == string.Empty)
                txt_AcrescimoG.Text = "0";

            txt_AcrescimoG.Text = util_dados.ConfigNumDecimal(txt_AcrescimoG.Text, 2);
        }

        private void txt_ValorG_Leave(object sender, EventArgs e)
        {
            if (txt_ValorG.Text.Trim() == string.Empty)
                txt_ValorG.Text = "0";

            txt_ValorG.Text = util_dados.ConfigNumDecimal(txt_ValorG.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Status = StatusForm.Consulta;
            Config_Botao();
        }

        private void txt_ID_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region MASKEDBOX
        private void mk_DataBaixa_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataBaixa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataBaixa.Text = Convert.ToString(DateTime.Now);
                mk_DataBaixa.Focus();
            }
        }

        private void mk_DataInicialP_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataInicialP.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataInicialP.Text = Convert.ToString(DateTime.Now);
                mk_DataInicialP.Focus();
            }
        }

        private void mk_DataFinalP_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataFinalP.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinalP.Text = Convert.ToString(DateTime.Now);
                mk_DataFinalP.Focus();
            }
        }

        private void mk_VencimentoL_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_VencimentoL.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_VencimentoL.Text = Convert.ToString(DateTime.Now);
                mk_VencimentoL.Focus();
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

        private void mk_DataPagto_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataPagto.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataPagto.Text = Convert.ToString(DateTime.Now);
                mk_DataPagto.Focus();
            }
        }

        private void mk_Emissao_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Emissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Emissao.Text = Convert.ToString(DateTime.Now);
                mk_Emissao.Focus();
            }
        }

        private void mk_Vencimento_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Vencimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Vencimento.Text = Convert.ToString(DateTime.Now);
                mk_Vencimento.Focus();
            }
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_Boletos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (Tipo == Tipo_Boleto.Baixa)
                return;

            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                try
                {
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    }

                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top + 1, e.CellBounds.Right, e.CellBounds.Top + 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);

                    Image imgChecked = (Image)Sistema.UI.Properties.Resources._checked;
                    Image imgUnchecked = (Image)Sistema.UI.Properties.Resources._unchecked;

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

        private void dg_Boletos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Tipo == Tipo_Boleto.Baixa)
                return;

            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Boletos.Rows.Count - 1; i++)
                    dg_Boletos.Rows[i].Cells[0].Value = Seleciona;
            }
            mk_DataBaixa.Focus();
        }

        private void dg_CReceber_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToBoolean(dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value = true;
        }

        private void dg_Boletos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Tipo == Tipo_Boleto.Baixa)
                return;

            if (dg_Boletos.Rows.Count == 0)
                return;

            if (Convert.ToBoolean(dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_SelecionaBoleto"].Value) == true)
            {
                dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_SelecionaBoleto"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_SelecionaBoleto"].Value) == false)
                dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_SelecionaBoleto"].Value = true;
        }

        private void dg_Boletos_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Boletos.CurrentRow != null)
            {
                mk_DataPagto.Text = dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_VencimentoBoleto"].Value.ToString();
                txt_ValorBoleto.Text = dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_ValorBoleto"].Value.ToString();
                txt_AcrescimoB.Text = dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_AcrescimoBoleto"].Value.ToString();
                txt_DescontoB.Text = dg_Boletos.Rows[dg_Boletos.CurrentRow.Index].Cells["col_DescontoBoleto"].Value.ToString();

                Calcula_Boleto(2);
            }
        }        
        #endregion

        #region TABPAGE
        private void tabctl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabctl.SelectedTab.Name == tabPage3.Name ||
                tabctl.SelectedTab.Name == TabPage1.Name)
            {
                bt_Exclui.Visible = true;

                if (Tipo == Tipo_Boleto.Matricial)
                    bt_Visualiza.Visible = false;
                else
                    bt_Visualiza.Visible = true;

                bt_Imprime.Visible = true;
                bt_Edita.Visible = true;
                bt_Grava.Visible = true;
            }
            else
            {
                bt_Exclui.Visible = false;
                bt_Visualiza.Visible = false;
                bt_Imprime.Visible = false;
                bt_Edita.Visible = false;
                bt_Grava.Visible = false;
            }
        }

        private void TabPage1_Enter(object sender, EventArgs e)
        {
            Calcula_Boleto(1);
        }
        #endregion

    }
}
