using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Globalization;

namespace Sistema.UI
{
    public partial class UI_FluxoCaixa : Sistema.UI.UI_Modelo_Financeiro
    {
        public UI_FluxoCaixa()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_PlanoConta BLL_PlanoConta;
        BLL_Grupo BLL_Grupo;
        BLL_Pagamento BLL_Pagamento;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_Banco BLL_Banco;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;

        string Conta;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_PlanoConta PlanoConta;
        DTO_Grupo Grupo;
        DTO_Pagamento Pagamento;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_Banco Banco;
        #endregion

        #region PROPRIEDADES
        public int Tipo_Caixa { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "FLUXO DE CAIXA";

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            tabctl.SelectedTab = TabPage2;

            dg_FluxoCaixa.AutoGenerateColumns = false;

            dg_FluxoCaixa.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_FluxoCaixa.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

            CarregaCB();

            //DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
            //mk_DataInicial.Text = Convert.ToString(Periodo);
            //mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));

            Limpa_Campo();

            switch (Tipo_Caixa)
            {
                case 1:
                    //TODOS CAIXAS
                    cb_CaixaLancamento.SelectedIndex = 0;
                    DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
                    mk_DataInicial.Text = Convert.ToString(Periodo);
                    mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));
                    break;

                case 2:
                    //CAIXA PRINCIPAL
                    cb_CaixaLancamento.SelectedValue = Parametro_Financeiro.ID_Caixa_Principal;
                    cb_CaixaLancamento.Enabled = false;

                    cb_Caixa.SelectedValue = Parametro_Financeiro.ID_Caixa_Principal;
                    cb_Caixa.Enabled = false;

                    bt_Exclui.Visible = false;
                    bt_Edita.Visible = false;
                    bt_Conciliar.Visible = false;

                    mk_DataInicial.ReadOnly = true;
                    mk_DataFinal.ReadOnly = true;
                    mk_Emissao.ReadOnly = true;

                    mk_DataInicial.Text = DateTime.Now.ToString();
                    mk_DataFinal.Text = DateTime.Now.ToString();

                    gb_Transferencia.Visible = false;

                    ck_Planejamento.Visible = false;
                    ck_PlanejamentoP.Visible = false;

                    Pesquisa();
                    break;
            }

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            FluxoCaixa = new DTO_FluxoCaixa();

            BLL_FluxoCaixa.Atualiza_Planejamento();
        }

        private void CarregaCB()
        {
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);
            Grupo.FiltraExibir = true;
            Grupo.Exibir = true;

            DataTable _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_CaixaLancamento);

            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Caixa);

            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_CaixaCreditar);

            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            _DT = new DataTable();
            _DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pagamento);

            _DT = new DataTable();
            _DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_PagamentoTransferencia);
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

        private void Carrega_FluxoCaixaSimples(DataTable _DT_Movimento)
        {
            dg_FluxoCaixa.DataSource = null;

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            BLL_Banco = new BLL_Banco();

            Banco = new DTO_Banco();
            FluxoCaixa = new DTO_FluxoCaixa();

            double SaldoConta;
            double SaldoLimite;
            double Provisionado = 0;
            double SaldoInicial = 0;
            double Saldo = 0;
            double Credito = 0;
            double Debito = 0;

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Caixa = Convert.ToInt32(cb_CaixaLancamento.SelectedValue);
            FluxoCaixa.Conciliado = true;
            FluxoCaixa.Planejamento = false;

            #region CONSULTA SALDO DO CAIXA
            DataTable _DT = new DataTable();
            _DT = BLL_FluxoCaixa.Busca_Saldo(FluxoCaixa);

            if (_DT.Rows.Count > 0 &&
                _DT.Rows[0]["Saldo"].ToString() != string.Empty)
                SaldoConta = Convert.ToDouble(_DT.Rows[0]["Saldo"]);
            else
                SaldoConta = 0;

            txt_Total.Text = util_dados.ConfigNumDecimal(SaldoConta, 2);
            #endregion

            #region CONSULTA SALDO LIMITE CONTA
            Banco.ID_Caixa = Convert.ToInt32(cb_CaixaLancamento.SelectedValue);
            _DT = new DataTable();
            _DT = BLL_Banco.Busca(Banco);
            if (_DT.Rows.Count == 0)
                SaldoLimite = 0;
            else
                SaldoLimite = Convert.ToDouble(_DT.Rows[0]["Limite"]);
            #endregion

            //FAZ O CALCULO DA DIFERENÇA DO SALDO, QUE ESTÁ NO LIVRO CAIXA
            for (int i = 0; i <= _DT_Movimento.Rows.Count - 1; i++)
            {
                Debito = Convert.ToDouble(_DT_Movimento.Rows[i]["Debito"]);
                Credito = Convert.ToDouble(_DT_Movimento.Rows[i]["Credito"]);

                Provisionado = (Provisionado + Credito) - Debito;

                if (Convert.ToBoolean(_DT_Movimento.Rows[i]["Conciliado"]) == true)
                    SaldoInicial = (SaldoInicial + Credito) - Debito;
            }

            #region CALCULA SALDO TOTAL (INCLUINDO LIMITE)
            if (SaldoConta < 0 &&
                SaldoConta >= (SaldoLimite * -1))
                txt_SaldoLimite.Text = util_dados.ConfigNumDecimal(SaldoLimite + SaldoConta, 2);
            else
                txt_SaldoLimite.Text = util_dados.ConfigNumDecimal(0, 2);

            if (SaldoConta >= 0)
                txt_SaldoLimite.Text = util_dados.ConfigNumDecimal(SaldoLimite, 2);

            txt_SaldoTotal.Text = util_dados.ConfigNumDecimal((SaldoLimite + SaldoConta), 2);

            Saldo = SaldoConta - SaldoInicial;
            Provisionado = SaldoConta - SaldoInicial;
            #endregion

            #region CALCULAR VALOR, SALDO E PROVISIONADO
            for (int i = 0; i <= _DT_Movimento.Rows.Count - 1; i++)
            {
                Debito = Convert.ToDouble(_DT_Movimento.Rows[i]["Debito"]);
                Credito = Convert.ToDouble(_DT_Movimento.Rows[i]["Credito"]);

                if (Debito == 0 &&
                    Credito > 0)
                    _DT_Movimento.Rows[i]["Valor"] = util_dados.ConfigNumDecimal(Credito, 2) + " C";

                if (Credito == 0 &&
                    Debito > 0)
                    _DT_Movimento.Rows[i]["Valor"] = util_dados.ConfigNumDecimal(Debito, 2) + " D";

                Provisionado = (Provisionado + Credito) - Debito;
                _DT_Movimento.Rows[i]["Provisionado"] = Provisionado;

                if (_DT_Movimento.Rows[i]["Historico"].ToString().Trim() == string.Empty)
                    _DT_Movimento.Rows[i]["Historico"] = _DT_Movimento.Rows[i]["Informacao"];

                if (Convert.ToBoolean(_DT_Movimento.Rows[i]["Conciliado"]) == true)
                {
                    Saldo = (Saldo + Credito) - Debito;
                    _DT_Movimento.Rows[i]["Saldo"] = Saldo;
                }
            }
            #endregion

            dg_FluxoCaixa.DataSource = _DT_Movimento;
            util_dados.CarregaCampo(this, _DT_Movimento, gb_Cadastro);

            if (_DT_Movimento.Rows.Count > 0)
                dg_FluxoCaixa.CurrentCell = dg_FluxoCaixa.Rows[dg_FluxoCaixa.Rows.Count - 1].Cells[1];
        }

        private void Carrega_FluxoCaixaDetalhado(DataTable _DT_Movimento)
        {
            dg_FluxoCaixa.DataSource = null;

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            BLL_Banco = new BLL_Banco();

            Banco = new DTO_Banco();
            FluxoCaixa = new DTO_FluxoCaixa();

            double SaldoConta;
            double SaldoLimite;
            double Provisionado = 0;
            double SaldoInicial = 0;
            double Saldo = 0;
            double Credito = 0;
            double Debito = 0;

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Caixa = Convert.ToInt32(cb_CaixaLancamento.SelectedValue);
            FluxoCaixa.Conciliado = true;
            FluxoCaixa.Planejamento = false;

            #region CONSULTA SALDO DO CAIXA
            DataTable _DT = new DataTable();
            _DT = BLL_FluxoCaixa.Busca_Saldo(FluxoCaixa);

            if (_DT.Rows.Count > 0 &&
                _DT.Rows[0]["Saldo"].ToString() != string.Empty)
                SaldoConta = Convert.ToDouble(_DT.Rows[0]["Saldo"]);
            else
                SaldoConta = 0;

            txt_Total.Text = util_dados.ConfigNumDecimal(SaldoConta, 2);
            #endregion

            #region CONSULTA SALDO LIMITE CONTA
            Banco.ID_Caixa = Convert.ToInt32(cb_CaixaLancamento.SelectedValue);
            _DT = new DataTable();
            _DT = BLL_Banco.Busca(Banco);
            if (_DT.Rows.Count == 0)
                SaldoLimite = 0;
            else
                SaldoLimite = Convert.ToDouble(_DT.Rows[0]["Limite"]);
            #endregion

            int ID_Fluxo = 0;

            //FAZ O CALCULO DA DIFERENÇA DO SALDO, QUE ESTÁ NO LIVRO CAIXA
            for (int i = 0; i <= _DT_Movimento.Rows.Count - 1; i++)
            {
                if (ID_Fluxo != Convert.ToInt32(_DT_Movimento.Rows[i]["ID"]))
                {
                    Debito = Convert.ToDouble(_DT_Movimento.Rows[i]["Debito"]);
                    Credito = Convert.ToDouble(_DT_Movimento.Rows[i]["Credito"]);

                    Provisionado = (Provisionado + Credito) - Debito;

                    if (Convert.ToBoolean(_DT_Movimento.Rows[i]["Conciliado"]) == true)
                        SaldoInicial = (SaldoInicial + Credito) - Debito;
                }

                ID_Fluxo = Convert.ToInt32(_DT_Movimento.Rows[i]["ID"]);
            }

            #region CALCULA SALDO TOTAL (INCLUINDO LIMITE)
            if (SaldoConta < 0 &&
                SaldoConta >= (SaldoLimite * -1))
                txt_SaldoLimite.Text = util_dados.ConfigNumDecimal(SaldoLimite + SaldoConta, 2);
            else
                txt_SaldoLimite.Text = util_dados.ConfigNumDecimal(0, 2);

            if (SaldoConta >= 0)
                txt_SaldoLimite.Text = util_dados.ConfigNumDecimal(SaldoLimite, 2);

            txt_SaldoTotal.Text = util_dados.ConfigNumDecimal((SaldoLimite + SaldoConta), 2);

            Saldo = SaldoConta - SaldoInicial;
            Provisionado = SaldoConta - SaldoInicial;
            #endregion

            #region CALCULAR VALOR, SALDO E PROVISIONADO
            ID_Fluxo = 0;

            for (int i = 0; i <= _DT_Movimento.Rows.Count - 1; i++)
            {
                #region CONTAS A PAGAR
                if (util_dados.Verifica_int(_DT_Movimento.Rows[i]["IDCP"].ToString()) > 0)
                {
                    Debito = Convert.ToDouble(_DT_Movimento.Rows[i]["Debito"]);
                    Credito = 0;

                    if (ID_Fluxo == Convert.ToInt32(_DT_Movimento.Rows[i]["ID"]))
                    {
                        _DT_Movimento.Rows[i]["Valor"] = string.Empty;
                        _DT_Movimento.Rows[i]["Saldo"] = DBNull.Value;
                        _DT_Movimento.Rows[i]["Provisionado"] = DBNull.Value;
                    }
                    else
                    {
                        _DT_Movimento.Rows[i]["Valor"] = util_dados.ConfigNumDecimal(Debito, 2) + " D";

                        Provisionado = (Provisionado + Credito) - Debito;
                        _DT_Movimento.Rows[i]["Provisionado"] = Provisionado;

                        if (Convert.ToBoolean(_DT_Movimento.Rows[i]["Conciliado"]) == true)
                        {
                            Saldo = (Saldo + Credito) - Debito;
                            _DT_Movimento.Rows[i]["Saldo"] = Saldo;
                        }
                    }

                    _DT_Movimento.Rows[i]["DescricaoContaDetalhado"] = _DT_Movimento.Rows[i]["DescricaoContaCP"];

                    string Historico = string.Empty;
                    Historico += _DT_Movimento.Rows[i]["Informacao"] + " - " + _DT_Movimento.Rows[i]["DescricaoPessoaCP"];
                    Historico += " (R$ " + util_dados.ConfigNumDecimal(_DT_Movimento.Rows[i]["ValorCP"].ToString(), 2) + ")";

                    _DT_Movimento.Rows[i]["Historico"] = Historico;

                    _DT_Movimento.Rows[i]["Documento"] = _DT_Movimento.Rows[i]["IDCP"];

                    ID_Fluxo = Convert.ToInt32(_DT_Movimento.Rows[i]["ID"]);
                }
                #endregion

                #region CONTAS A RECEBER
                if (util_dados.Verifica_int(_DT_Movimento.Rows[i]["IDCR"].ToString()) > 0)
                {
                    Debito = 0;
                    Credito = Convert.ToDouble(_DT_Movimento.Rows[i]["Credito"]);

                    if (ID_Fluxo == Convert.ToInt32(_DT_Movimento.Rows[i]["ID"]))
                    {
                        _DT_Movimento.Rows[i]["Valor"] = string.Empty;
                        _DT_Movimento.Rows[i]["Saldo"] = DBNull.Value;
                        _DT_Movimento.Rows[i]["Provisionado"] = DBNull.Value;
                    }
                    else
                    {
                        _DT_Movimento.Rows[i]["Valor"] = util_dados.ConfigNumDecimal(Credito, 2) + " C";

                        Provisionado = (Provisionado + Credito) - Debito;
                        _DT_Movimento.Rows[i]["Provisionado"] = Provisionado;

                        if (Convert.ToBoolean(_DT_Movimento.Rows[i]["Conciliado"]) == true)
                        {
                            Saldo = (Saldo + Credito) - Debito;
                            _DT_Movimento.Rows[i]["Saldo"] = Saldo;
                        }
                    }

                    _DT_Movimento.Rows[i]["DescricaoContaDetalhado"] = _DT_Movimento.Rows[i]["DescricaoContaCR"];

                    string Historico = string.Empty;
                    Historico += _DT_Movimento.Rows[i]["Informacao"] + " - " + _DT_Movimento.Rows[i]["DescricaoPessoaCR"];
                    Historico += " (R$ " + util_dados.ConfigNumDecimal(_DT_Movimento.Rows[i]["ValorCR"].ToString(), 2) + ")";

                    _DT_Movimento.Rows[i]["Historico"] = Historico;

                    _DT_Movimento.Rows[i]["Documento"] = _DT_Movimento.Rows[i]["IDCR"];

                    ID_Fluxo = Convert.ToInt32(_DT_Movimento.Rows[i]["ID"]);
                }
                #endregion

                #region LANÇAMENTO AVULSO
                if (util_dados.Verifica_int(_DT_Movimento.Rows[i]["IDCP"].ToString()) == 0 &&
                    util_dados.Verifica_int(_DT_Movimento.Rows[i]["IDCR"].ToString()) == 0)
                {

                    Debito = Convert.ToDouble(_DT_Movimento.Rows[i]["Debito"]);
                    Credito = Convert.ToDouble(_DT_Movimento.Rows[i]["Credito"]);

                    if (Debito == 0 &&
                        Credito > 0)
                        _DT_Movimento.Rows[i]["Valor"] = util_dados.ConfigNumDecimal(Credito, 2) + " C";

                    if (Credito == 0 &&
                        Debito > 0)
                        _DT_Movimento.Rows[i]["Valor"] = util_dados.ConfigNumDecimal(Debito, 2) + " D";

                    Provisionado = (Provisionado + Credito) - Debito;
                    _DT_Movimento.Rows[i]["Provisionado"] = Provisionado;

                    if (Convert.ToBoolean(_DT_Movimento.Rows[i]["Conciliado"]) == true)
                    {
                        Saldo = (Saldo + Credito) - Debito;
                        _DT_Movimento.Rows[i]["Saldo"] = Saldo;
                    }

                    ID_Fluxo = Convert.ToInt32(_DT_Movimento.Rows[i]["ID"]);
                }
                #endregion

                if (_DT_Movimento.Rows[i]["Historico"].ToString().Trim() == string.Empty)
                    _DT_Movimento.Rows[i]["Historico"] = _DT_Movimento.Rows[i]["Informacao"];
            }
            #endregion

            dg_FluxoCaixa.DataSource = _DT_Movimento;

            if (_DT_Movimento.Rows.Count > 0)
                dg_FluxoCaixa.CurrentCell = dg_FluxoCaixa.Rows[dg_FluxoCaixa.Rows.Count - 1].Cells[1];
        }

        private void Limpa_Campo()
        {
            mk_Emissao.Text = DateTime.Now.ToString();
            mk_Data.Text = DateTime.Now.ToString();

            cb_Caixa.SelectedIndex = 0;

            cb_ID_Pagamento.SelectedIndex = 0;

            dg_FluxoCaixa.DataSource = null;

            txt_Credito.Text = "0,00";
            txt_Debito.Text = "0,00";

            txt_Total.Text = "0,00";
            txt_SaldoLimite.Text = "0,00";
            txt_SaldoTotal.Text = "0,00";
            txt_Valor.Text = "0,00";

            ck_ExibirConta.Checked = false;
            ck_Conciliado.Checked = false;

            cb_Caixa.Focus();
        }

        private void Transfere_Valor()
        {
            try
            {
                if (Convert.ToInt32(cb_CaixaCreditar.SelectedValue) == Convert.ToInt32(cb_CaixaLancamento.SelectedValue))
                {
                    MessageBox.Show(util_msg.msg_TransferenciaCaixaErro, this.Text);
                    return;
                }

                DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_Lancamento, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                FluxoCaixa = new DTO_FluxoCaixa();

                FluxoCaixa.ID = 0;
                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FluxoCaixa.Emissao = Convert.ToDateTime(mk_Data.Text);
                FluxoCaixa.Caixa = Convert.ToInt32(cb_CaixaLancamento.SelectedValue);
                FluxoCaixa.Documento = "";
                FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                FluxoCaixa.Credito = 0;
                FluxoCaixa.Debito = Convert.ToDouble(txt_Valor.Text);
                FluxoCaixa.Informacao = util_msg.msg_TransfereFluxoCaixaSaida + cb_CaixaCreditar.Text;

                if (txt_Informacao.Text.Trim() != string.Empty)
                    FluxoCaixa.Informacao += " - " + txt_InformacaoTransferencia.Text;

                FluxoCaixa.ID_Cheque = 0;
                FluxoCaixa.Conciliado = true;
                FluxoCaixa.ID_Pagamento = Convert.ToInt32(cb_PagamentoTransferencia.SelectedValue);
                FluxoCaixa.Planejamento = false;

                BLL_FluxoCaixa.Grava(FluxoCaixa);

                FluxoCaixa.ID = 0;
                FluxoCaixa.Caixa = Convert.ToInt32(cb_CaixaCreditar.SelectedValue);
                FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                FluxoCaixa.Credito = Convert.ToDouble(txt_Valor.Text);
                FluxoCaixa.Debito = 0;
                FluxoCaixa.Informacao = util_msg.msg_transrefeFluxoCaixaEntrada + cb_CaixaLancamento.Text;

                if (txt_Informacao.Text.Trim() != string.Empty)
                    FluxoCaixa.Informacao += " - " + txt_InformacaoTransferencia.Text;

                FluxoCaixa.Conciliado = Convert.ToBoolean(ck_ConciliadoCreditar.Checked);
                FluxoCaixa.ID_Pagamento = Convert.ToInt32(cb_PagamentoTransferencia.SelectedValue);

                BLL_FluxoCaixa.Grava(FluxoCaixa);

                MessageBox.Show(util_msg.msg_Grava, this.Text);

                util_dados.LimpaCampos(this, gb_Transferencia);

                mk_Data.Text = DateTime.Now.ToString();
                txt_Valor.Text = "0,00";

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                FluxoCaixa = new DTO_FluxoCaixa();

                FluxoCaixa.ID = util_dados.Verifica_int(txt_ID.Text);
                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FluxoCaixa.Emissao = Convert.ToDateTime(mk_Emissao.Text);
                FluxoCaixa.Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);
                FluxoCaixa.Documento = txt_Documento.Text;
                FluxoCaixa.ID_Conta = util_dados.Verifica_int(txt_ID_Conta.Text);
                FluxoCaixa.Credito = Convert.ToDouble(txt_Credito.Text);
                FluxoCaixa.Debito = Convert.ToDouble(txt_Debito.Text);
                FluxoCaixa.Informacao = txt_Informacao.Text;
                FluxoCaixa.Conciliado = Convert.ToBoolean(ck_Conciliado.Checked);
                FluxoCaixa.ID_Pagamento = Convert.ToInt32(cb_ID_Pagamento.SelectedValue);
                FluxoCaixa.Planejamento = Convert.ToBoolean(ck_Planejamento.Checked);

                obj = BLL_FluxoCaixa.Grava(FluxoCaixa);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }

                cb_CaixaLancamento.SelectedValue = cb_Caixa.SelectedValue;

                Pesquisa();
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
                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                FluxoCaixa = new DTO_FluxoCaixa();

                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FluxoCaixa.Caixa = Convert.ToInt32(cb_CaixaLancamento.SelectedValue);
                FluxoCaixa.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                FluxoCaixa.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                FluxoCaixa.Conciliado = Convert.ToBoolean(ck_ConciliadoPesquisa.Checked);
                FluxoCaixa.Informacao = txt_InformacaoP.Text;
                FluxoCaixa.Planejamento = ck_PlanejamentoP.Checked;

                DataTable _DT = new DataTable();

                if (ck_ExibirConta.Checked == false)
                {
                    _DT = BLL_FluxoCaixa.BuscaSimples(FluxoCaixa);
                    Carrega_FluxoCaixaSimples(_DT);
                }
                else
                {
                    _DT = BLL_FluxoCaixa.BuscaDetalhado(FluxoCaixa);
                    Carrega_FluxoCaixaDetalhado(_DT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                FluxoCaixa = new DTO_FluxoCaixa();

                FluxoCaixa.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_FluxoCaixa.Exclui(FluxoCaixa);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                tabctl.SelectedTab = TabPage2;

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);

            tabctl.SelectedTab = TabPage1;

            Limpa_Campo();
        }

        #endregion

        #region FORM
        private void UI_FluxoCaixa_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_FluxoCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Debito.Focused == true ||
             txt_Credito.Focused == true ||
             txt_Valor.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_FluxoCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_FluxoCaixa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 6)
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

                    Image img = (Image)UI.Properties.Resources.bt_Concluido;

                    int X = e.CellBounds.Left + ((e.CellBounds.Width - img.Width) / 2) - 1;
                    int Y = e.CellBounds.Top + ((e.CellBounds.Height - img.Height) / 2) - 1;

                    e.Graphics.DrawImage(img, X, Y);

                    e.Handled = true;
                }
                catch
                {
                }
            }

            if (e.RowIndex == -1 && e.ColumnIndex == 9)
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

                    Image img = (Image)UI.Properties.Resources.bt_Calcular;

                    int X = e.CellBounds.Left + ((e.CellBounds.Width - img.Width) / 2) - 1;
                    int Y = e.CellBounds.Top + ((e.CellBounds.Height - img.Height) / 2) - 1;

                    e.Graphics.DrawImage(img, X, Y);

                    e.Handled = true;
                }
                catch
                {
                }
            }
        }

        private void dg_FluxoCaixa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null &&
                e.ColumnIndex == 5)
                if (e.Value.ToString().IndexOf("D") != -1)
                    e.CellStyle.ForeColor = Color.Red;
                else
                    e.CellStyle.ForeColor = Color.Blue;

            if (e.Value != null &&
             e.ColumnIndex == 7)
                if (util_dados.Verifica_Double(e.Value.ToString()) >= 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Red;

            if (e.Value != null &&
            e.ColumnIndex == 8)
                if (util_dados.Verifica_Double(e.Value.ToString()) >= 0)
                    e.CellStyle.ForeColor = Color.Blue;
                else
                    e.CellStyle.ForeColor = Color.Red;
        }

        private void dg_FluxoCaixa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dg_FluxoCaixa.Columns["col_Conciliado"].Index)
                {
                    //COLOCA A LINHA SELECIONADA PARA CONCILIAR DEPOIS, PRIMEIRO VERIFICA SE JÁ FOI ALTERADO O VALOR
                    if (dg_FluxoCaixa.Rows[dg_FluxoCaixa.CurrentRow.Index].Cells["col_Alterar"].Value == DBNull.Value ||
                        dg_FluxoCaixa.Rows[dg_FluxoCaixa.CurrentRow.Index].Cells["col_Alterar"].Value == null)
                        dg_FluxoCaixa.Rows[dg_FluxoCaixa.CurrentRow.Index].Cells["col_Alterar"].Value = true;
                    else
                        dg_FluxoCaixa.Rows[dg_FluxoCaixa.CurrentRow.Index].Cells["col_Alterar"].Value = DBNull.Value;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region CHECKBOX
        private void ck_ConciliadoPesquisa_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_ConciliadoPesquisa.Checked == true)
                ck_ConciliadoPesquisa.BackColor = Color.LightGray;
            else
                ck_ConciliadoPesquisa.BackColor = Color.White;
        }

        private void ck_ExibirConta_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_ExibirConta.Checked == true)
            {
                ck_ExibirConta.BackColor = Color.LightGray;
                dg_FluxoCaixa.Columns["col_Conciliado"].ReadOnly = true;
                bt_Conciliar.Enabled = false;
                bt_Edita.Enabled = false;
            }
            else
            {
                ck_ExibirConta.BackColor = Color.White;
                dg_FluxoCaixa.Columns["col_Conciliado"].ReadOnly = false;
                bt_Conciliar.Enabled = true;
                bt_Edita.Enabled = true;
            }
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            UI_PlanoConta_Consulta frm = new UI_PlanoConta_Consulta();

            frm.ShowDialog();
            mk_Conta.Text = frm.Cod_Conta;
        }

        private void bt_Somar_Click(object sender, EventArgs e)
        {
            double Saldo = 0;
            double Credito = 0;
            double Debito = 0;

            for (int i = 0; i <= dg_FluxoCaixa.Rows.Count - 1; i++)
                if (dg_FluxoCaixa.Rows[i].Cells["col_ID"].Value.ToString() != "0" &&
                    Convert.ToBoolean(dg_FluxoCaixa.Rows[i].Cells["col_Soma"].Value) == true)
                {
                    if (dg_FluxoCaixa.Rows[i].Cells["col_Valor"].Value.ToString().IndexOf("D") != -1)
                        Debito = util_dados.Verifica_Double(dg_FluxoCaixa.Rows[i].Cells["col_Valor"].Value.ToString().Replace("D", ""));
                    else
                        Credito = util_dados.Verifica_Double(dg_FluxoCaixa.Rows[i].Cells["col_Valor"].Value.ToString().Replace("C", ""));

                    Saldo = (Saldo + Credito) - Debito;
                }

            txt_SomaParcial.Text = util_dados.ConfigNumDecimal(Saldo, 2);
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            tabctl.SelectedTab = TabPage1;
        }

        private void bt_Conciliar_Click(object sender, EventArgs e)
        {
            try
            {
                int aux;
                if (dg_FluxoCaixa.CurrentRow == null)
                    aux = dg_FluxoCaixa.Rows.Count - 1;
                else
                    aux = dg_FluxoCaixa.CurrentRow.Index;

                UI_Lanca_Data UI_Lanca_Data = new UI_Lanca_Data();
                UI_Lanca_Data.ShowDialog();

                if (UI_Lanca_Data.Lanca == false)
                    return;
                else
                {
                    BLL_FluxoCaixa = new BLL_FluxoCaixa();
                    FluxoCaixa = new DTO_FluxoCaixa();

                    for (int i = 0; i <= dg_FluxoCaixa.Rows.Count - 1; i++)
                        if (dg_FluxoCaixa.Rows[i].Cells["col_Alterar"].Value != DBNull.Value &&
                            dg_FluxoCaixa.Rows[i].Cells["col_Alterar"].Value != null)
                        {
                            bool Conciliado = dg_FluxoCaixa.Rows[i].Cells["col_Conciliado"].Value == DBNull.Value ? false : Convert.ToBoolean(dg_FluxoCaixa.Rows[i].Cells["col_Conciliado"].Value);

                            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            FluxoCaixa.ID = Convert.ToInt32(dg_FluxoCaixa.Rows[i].Cells["col_ID"].Value);
                            FluxoCaixa.Conciliado = Conciliado;
                            FluxoCaixa.Emissao = UI_Lanca_Data.Data;

                            BLL_FluxoCaixa.Altera_Conciliado(FluxoCaixa);
                        }

                    for (int i = 0; i <= dg_FluxoCaixa.Rows.Count - 1; i++)
                        dg_FluxoCaixa.Rows[i].Cells["col_Alterar"].Value = DBNull.Value;
                }
                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        private void dg_FluxoCaixa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int aux;
                if (dg_FluxoCaixa.CurrentRow == null)
                    aux = dg_FluxoCaixa.Rows.Count - 1;
                else
                    aux = dg_FluxoCaixa.CurrentRow.Index;

                UI_Lanca_Data UI_Lanca_Data = new UI_Lanca_Data();
                UI_Lanca_Data.ShowDialog();

                if (UI_Lanca_Data.Lanca == false)
                    return;
                else
                {
                    BLL_FluxoCaixa = new BLL_FluxoCaixa();
                    FluxoCaixa = new DTO_FluxoCaixa();

                    for (int i = 0; i <= dg_FluxoCaixa.Rows.Count - 1; i++)
                        if (dg_FluxoCaixa.Rows[i].Cells["col_Alterar"].Value != DBNull.Value &&
                            dg_FluxoCaixa.Rows[i].Cells["col_Alterar"].Value != null)
                        {
                            bool Conciliado = dg_FluxoCaixa.Rows[i].Cells["col_Conciliado"].Value == DBNull.Value ? false : Convert.ToBoolean(dg_FluxoCaixa.Rows[i].Cells["col_Conciliado"].Value);

                            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            FluxoCaixa.ID = Convert.ToInt32(dg_FluxoCaixa.Rows[i].Cells["col_ID"].Value);
                            FluxoCaixa.Conciliado = Conciliado;
                            FluxoCaixa.Emissao = UI_Lanca_Data.Data;

                            BLL_FluxoCaixa.Altera_Conciliado(FluxoCaixa);
                        }

                    for (int i = 0; i <= dg_FluxoCaixa.Rows.Count - 1; i++)
                        dg_FluxoCaixa.Rows[i].Cells["col_Alterar"].Value = DBNull.Value;
                }
                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_Transferir_Click(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Valor.Text) > 0)
                Transfere_Valor();
        }

        private void bt_Anterior_Click(object sender, EventArgs e)
        {
            if (dg_FluxoCaixa.Rows.Count == 0 || dg_FluxoCaixa.Rows.Count == 1)
                return;

            if (dg_FluxoCaixa.CurrentRow == null)
                dg_FluxoCaixa.Rows[0].Cells[1].Selected = true;

            int aux = dg_FluxoCaixa.CurrentRow.Index - 1;
            if (aux >= 0)
            {
                dg_FluxoCaixa.Rows[dg_FluxoCaixa.CurrentRow.Index].Cells[0].Selected = false;
                dg_FluxoCaixa.Rows[aux].Cells[1].Selected = true;
            }
        }

        private void bt_Proximo_Click(object sender, EventArgs e)
        {
            if (dg_FluxoCaixa.Rows.Count == 0 || dg_FluxoCaixa.Rows.Count == 1)
                return;

            if (dg_FluxoCaixa.CurrentRow == null)
                dg_FluxoCaixa.Rows[0].Cells[1].Selected = true;

            int aux = dg_FluxoCaixa.CurrentRow.Index + 1;
            if (aux < dg_FluxoCaixa.Rows.Count)
            {
                dg_FluxoCaixa.Rows[dg_FluxoCaixa.CurrentRow.Index].Cells[0].Selected = false;
                dg_FluxoCaixa.Rows[aux].Cells[1].Selected = true;
            }
        }
        #endregion

        #region MASKEDBOX
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

        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

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
            if (mk_DataFinal.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }
        }

        private void mk_Conta_TextChanged(object sender, EventArgs e)
        {
            CarregaConta();
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
        #endregion

        #region TEXTBOX
        private void txt_SaldoLimite_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_SaldoLimite.Text) > 0)
                txt_SaldoLimite.ForeColor = Color.Green;
            else
                txt_SaldoLimite.ForeColor = Color.Blue;
        }

        private void txt_Total_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Total.Text) >= 0)
                txt_Total.ForeColor = Color.Blue;
            else
                txt_Total.ForeColor = Color.Red;
        }

        private void txt_SaldoTotal_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_SaldoTotal.Text) >= 0)
                txt_SaldoTotal.ForeColor = Color.Blue;
            else
                txt_SaldoTotal.ForeColor = Color.Red;
        }

        private void txt_Credito_Leave(object sender, EventArgs e)
        {
            if (txt_Credito.Text.Trim() == string.Empty)
                txt_Credito.Text = "0";

            txt_Credito.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(txt_Credito.Text), 2);
        }

        private void txt_Debito_Leave(object sender, EventArgs e)
        {
            if (txt_Debito.Text.Trim() == string.Empty)
                txt_Debito.Text = "0";

            txt_Debito.Text = util_dados.ConfigNumDecimal(Convert.ToDouble(txt_Debito.Text), 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Config(StatusForm.Consulta);
        }

        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (txt_Valor.Text.Trim() == string.Empty)
                txt_Valor.Text = "0";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }
        #endregion

    }
}
