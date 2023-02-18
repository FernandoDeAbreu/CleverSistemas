using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;
using System.Globalization;
using Microsoft.Reporting.WinForms;

namespace Sistema.UI
{
    public partial class UI_FluxoCaixa_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_FluxoCaixa_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_Banco BLL_Banco;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;

        string _Parametro_Saldo = string.Empty;
        string _Parametro_Limite = string.Empty;
        string _Parametro_SaldoTotal = string.Empty;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_Banco Banco;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE FLUXO DE CAIXA";

            bt_Proximo.Visible = false;
            bt_Anterior.Visible = false;

            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            bt_Novo.Visible = false;
            bt_Pesquisa.Visible = false;

            bt_Visualiza.Enabled = true;
            bt_Imprime.Enabled = true;

            tabctl.TabPages.Remove(TabPage2);
            tabctl.SelectedTab = TabPage1;

            CarregaCB();

            DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
            mk_DataInicial.Text = Convert.ToString(Periodo);
            mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));
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
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Caixa);

            List<string> Tipo = new List<string>();

            Tipo.Add("FLUXO DE CAIXA");
            Tipo.Add("BALANCETE SINTÉTICO POR CAIXA");
            Tipo.Add("BALANCETE SINTÉTICO GERAL");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo), "Descricao", "ID", cb_Tipo);
            cb_Tipo.SelectedIndex = 0;
        }

        private DataTable Carrega_FluxoCaixaSimples()
        {
            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            BLL_Banco = new BLL_Banco();

            FluxoCaixa = new DTO_FluxoCaixa();
            Banco = new DTO_Banco();

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);
            FluxoCaixa.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            FluxoCaixa.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            FluxoCaixa.Conciliado = Convert.ToBoolean(ck_ConciliadoPesquisa.Checked);

            DataTable _DT_Movimento = new DataTable();
            _DT_Movimento = BLL_FluxoCaixa.BuscaSimples(FluxoCaixa);

            double SaldoConta;
            double SaldoLimite;
            double Provisionado = 0;
            double SaldoInicial = 0;
            double Saldo = 0;
            double Credito = 0;
            double Debito = 0;

            _Parametro_Saldo = string.Empty;
            _Parametro_Limite = string.Empty;
            _Parametro_SaldoTotal = string.Empty;

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);
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

            _Parametro_Saldo = util_dados.ConfigNumDecimal(SaldoConta, 2);
            #endregion

            #region CONSULTA SALDO LIMITE CONTA
            Banco.ID_Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);
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
                _Parametro_Limite = util_dados.ConfigNumDecimal(SaldoLimite + SaldoConta, 2);
            else
                _Parametro_Limite = util_dados.ConfigNumDecimal(0, 2);

            if (SaldoConta >= 0)
                _Parametro_Limite = util_dados.ConfigNumDecimal(SaldoLimite, 2);

            _Parametro_SaldoTotal = util_dados.ConfigNumDecimal((SaldoLimite + SaldoConta), 2);

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

                if (Convert.ToBoolean(_DT_Movimento.Rows[i]["Conciliado"]) == true)
                {
                    Saldo = (Saldo + Credito) - Debito;
                    _DT_Movimento.Rows[i]["Saldo"] = Saldo;
                }
            }
            #endregion

            return _DT_Movimento;
        }

        private DataTable Carrega_FluxoCaixaDetalhado()
        {

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            BLL_Banco = new BLL_Banco();

            FluxoCaixa = new DTO_FluxoCaixa();
            Banco = new DTO_Banco();

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);
            FluxoCaixa.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            FluxoCaixa.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            FluxoCaixa.Conciliado = Convert.ToBoolean(ck_ConciliadoPesquisa.Checked);

            DataTable _DT_Movimento = new DataTable();
            _DT_Movimento = BLL_FluxoCaixa.BuscaDetalhado(FluxoCaixa);

            double SaldoConta;
            double SaldoLimite;
            double Provisionado = 0;
            double SaldoInicial = 0;
            double Saldo = 0;
            double Credito = 0;
            double Debito = 0;

            _Parametro_Saldo = string.Empty;
            _Parametro_Limite = string.Empty;
            _Parametro_SaldoTotal = string.Empty;

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);
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

            _Parametro_Saldo = util_dados.ConfigNumDecimal(SaldoConta, 2);
            #endregion

            #region CONSULTA SALDO LIMITE CONTA
            Banco.ID_Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);
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
                _Parametro_Limite = util_dados.ConfigNumDecimal(SaldoLimite + SaldoConta, 2);
            else
                _Parametro_Limite = util_dados.ConfigNumDecimal(0, 2);

            if (SaldoConta >= 0)
                _Parametro_Limite = util_dados.ConfigNumDecimal(SaldoLimite, 2);

            _Parametro_SaldoTotal = util_dados.ConfigNumDecimal((SaldoLimite + SaldoConta), 2);

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
            }
            #endregion

            return _DT_Movimento;
        }

        private DataTable Carrega_FluxoCaixaBalanco()
        {

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            BLL_Banco = new BLL_Banco();

            FluxoCaixa = new DTO_FluxoCaixa();
            Banco = new DTO_Banco();

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            if (Convert.ToInt32(cb_Tipo.SelectedValue) != 3)
                FluxoCaixa.Caixa = Convert.ToInt32(cb_Caixa.SelectedValue);

            FluxoCaixa.GrupoConta = mk_ContaP.Text;
            FluxoCaixa.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
            FluxoCaixa.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
            FluxoCaixa.Conciliado = true;

            DataTable _DT_Movimento = new DataTable();
            _DT_Movimento = BLL_FluxoCaixa.BuscaBalanco(FluxoCaixa);

            return _DT_Movimento;
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {

        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();
            string rpt_Nome = "";

            switch (Convert.ToInt32(cb_Tipo.SelectedValue))
            {
                case 1:
                    rpt_Nome = "rpt_FluxoCaixa.rdlc";
                    break;

                case 2:
                    rpt_Nome = "rpt_BalancoSintetico.rdlc";
                    break;

                case 3:
                    rpt_Nome = "rpt_BalancoSinteticoGeral.rdlc";
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = new DataTable();
            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);

            DataTable _DT_Lancamento = new DataTable();

            switch (Convert.ToInt32(cb_Tipo.SelectedValue))
            {
                case 1:
                    if (ck_ExibirConta.Checked == true)
                        _DT_Lancamento = Carrega_FluxoCaixaDetalhado();
                    else
                        _DT_Lancamento = Carrega_FluxoCaixaSimples();
                    break;

                case 2:
                case 3:
                    _DT_Lancamento = Carrega_FluxoCaixaBalanco();
                    break;
            }
            
            ReportDataSource ds_Fluxo = new ReportDataSource("ds_FluxoCaixa", _DT_Lancamento);

            ReportParameter p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
            ReportParameter p2 = new ReportParameter("Saldo", _Parametro_Saldo);
            ReportParameter p3 = new ReportParameter("SaldoLimite", _Parametro_Limite);
            ReportParameter p4 = new ReportParameter("SaldoTotal", _Parametro_SaldoTotal);
            ReportParameter p5 = new ReportParameter("Caixa", cb_Caixa.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fluxo);
            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5 });

            frm_rpt.rpt_Viewer.RefreshReport();
        }
        #endregion

        #region MASKEDBOX
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
        #endregion

        #region FORM
        private void UI_FluxoCaixa_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaConta_P_Click(object sender, EventArgs e)
        {
            UI_PlanoConta_Consulta frm = new UI_PlanoConta_Consulta();

            frm.ShowDialog();
            mk_ContaP.Text = frm.Cod_Conta;
        }
        #endregion
    }
}
