using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Cheque : Sistema.UI.UI_Modelo_Financeiro
    {
        public UI_Cheque()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Cheque BLL_Cheque;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_CReceber BLL_CReceber;
        BLL_CPagar BLL_CPagar;
        BLL_Pessoa BLL_Pessoa;
        BLL_Pagamento BLL_Pagamento;
        BLL_Grupo BLL_Grupo;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;

        DataRow DR;

        DataTable DT;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Cheque Cheque;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_CReceber CReceber;
        DTO_CPagar CPagar;
        DTO_Pessoa Pessoa;
        DTO_Pagamento Pagamento;
        DTO_Grupo Grupo;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONTROLE DE CHEQUES";

            DG.AutoGenerateColumns = false;
            dg_Resumo.AutoGenerateColumns = false;

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            Limpa_Campo();
        }

        private void Limpa_Campo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);

            mk_DataInicial.Text = Convert.ToString(DateTime.Now.AddDays(-30));
            mk_DataFinal.Text = Convert.ToString(DateTime.Now.AddDays(30));
            mk_Emissao.Text = Convert.ToString(DateTime.Now);
            mk_Vencimento.Text = Convert.ToString(DateTime.Now);
            mk_DataLancamento.Text = DateTime.Now.ToString();

            txt_Valor.Text = "0,00";
            txt_Total.Text = "0,00";

            cb_TipoPessoa.SelectedIndex = 0;
            cb_Situacao.SelectedIndex = 0;
            cb_Periodo.SelectedIndex = 1;
            cb_TipoPessoa.Focus();

            dg_Resumo.DataSource = null;
            DG.DataSource = null;
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();

            List<string> aux = new List<string> { "TODOS", "DISPONÍVEL", "DEVOLVIDO", "DEPOSITADO", "PAGTO. TERCEIRO", "COMPENSADO" };

            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);

            _DT = util_dados.CarregaComboDinamico(0, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_SituacaoP);

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;

            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);
            Grupo.FiltraExibir = true;
            Grupo.Exibir = true;

            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Caixa);
        }

        private void CarregaPessoa(int intTipoPessoa)
        {
            try
            {
                switch (intTipoPessoa)
                {
                    case 1:
                        BLL_Pessoa = new BLL_Pessoa();
                        Pessoa = new DTO_Pessoa();

                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        Pessoa.FiltraSituacao = true;
                        Pessoa.Situacao = true;

                        DT = new DataTable();
                        DT = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(DT, "Descricao", "ID", cb_ID_Pessoa);
                        cb_ID_Pessoa.SelectedIndex = -1;
                        break;
                    case 2:
                        BLL_Pessoa = new BLL_Pessoa();
                        Pessoa = new DTO_Pessoa();

                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                        Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        DT = new DataTable();
                        DT = BLL_Pessoa.Busca_Nome(Pessoa);
                        util_dados.CarregaCombo(DT, "Descricao", "ID", cb_ID_PessoaP);
                        cb_ID_PessoaP.SelectedIndex = -1;
                        break;
                }
                if (util_dados.Verifica_int(txt_ID_Pessoa.Text) > 0)
                    cb_ID_Pessoa.SelectedValue = util_dados.Verifica_int(txt_ID_Pessoa.Text);
            }
            catch (Exception)
            {
            }
        }

        private void Lanca_Cheque_Devolvido(Tipo_Cheque _Tipo, Tipo_Cheque_Lanca _TipoLancamento)
        {
            try
            {
                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                BLL_Cheque = new BLL_Cheque();

                FluxoCaixa = new DTO_FluxoCaixa();
                Cheque = new DTO_Cheque();

                Cheque.ID = int.Parse(txt_ID.Text);

                DataTable _DT = new DataTable();
                _DT = BLL_Cheque.Busca_Resumo(Cheque);

                int ID_FluxoCaixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_FluxoCaixa"].ToString());
                int ID_Caixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_Caixa"].ToString());
                int ID_Pagamento = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_Pagamento"].ToString());
                int ID_CPagar = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_CPagar"].ToString());
                int ID_CReceber = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_CReceber"].ToString());

                FluxoCaixa.ID = ID_FluxoCaixa;

                FluxoCaixa.Emissao = DateTime.Parse(mk_Emissao.Text);
                FluxoCaixa.Planejamento = false;
                FluxoCaixa.Conciliado = true;

                BLL_FluxoCaixa.Altera_Lancamento_Cheque(FluxoCaixa);

                switch (_TipoLancamento)
                {
                    case Tipo_Cheque_Lanca.DEVOLVIDO_REPRESENTAR:
                        #region FAZ LANÇAMENTO DEVOLUÇÃO DO CHEQUE
                        FluxoCaixa = new DTO_FluxoCaixa();

                        FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                        FluxoCaixa.Caixa = ID_Caixa;
                        FluxoCaixa.Documento = txt_Cheque.Text;
                        FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                        FluxoCaixa.Credito = 0;
                        FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                        FluxoCaixa.Informacao = util_msg.msg_ChequeDevolvido + txt_Cheque.Text;
                        FluxoCaixa.Conciliado = true;
                        FluxoCaixa.ID_Pagamento = ID_Pagamento;
                        FluxoCaixa.Planejamento = false;
                        FluxoCaixa.ID_Cheque = int.Parse(txt_ID.Text);

                        FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                        FluxoCaixa.ID_CPagar = ID_CPagar;
                        FluxoCaixa.ID_CReceber = ID_CReceber;

                        BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                        #endregion

                        #region FAZ LANÇAMENTO DE REPRESENTAÇÃO DE CHEQUE
                        FluxoCaixa = new DTO_FluxoCaixa();

                        FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                        FluxoCaixa.Caixa = ID_Caixa;
                        FluxoCaixa.Documento = txt_Cheque.Text;
                        FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                        FluxoCaixa.Credito = double.Parse(txt_Valor.Text);
                        FluxoCaixa.Debito = 0;
                        FluxoCaixa.Informacao = util_msg.msg_TranfereCheque + txt_Cheque.Text + " (REPRESENTADO)";
                        FluxoCaixa.Conciliado = false;
                        FluxoCaixa.ID_Pagamento = ID_Pagamento;
                        FluxoCaixa.Planejamento = false;
                        FluxoCaixa.ID_Cheque = int.Parse(txt_ID.Text);

                        FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                        FluxoCaixa.ID_CPagar = ID_CPagar;
                        FluxoCaixa.ID_CReceber = ID_CReceber;

                        BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                        #endregion
                        break;

                    case Tipo_Cheque_Lanca.DEVOLVIDO_FINANCEIRO:
                        #region FAZ LANÇAMENTO DEVOLUÇÃO DO CHEQUE
                        if (_Tipo == Tipo_Cheque.DEPOSITADO)
                        {
                            FluxoCaixa = new DTO_FluxoCaixa();

                            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                            FluxoCaixa.Caixa = ID_Caixa;
                            FluxoCaixa.Documento = txt_Cheque.Text;
                            FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                            FluxoCaixa.Credito = 0;
                            FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                            FluxoCaixa.Informacao = util_msg.msg_ChequeDevolvido + txt_Cheque.Text;
                            FluxoCaixa.Conciliado = true;
                            FluxoCaixa.ID_Pagamento = ID_Pagamento;
                            FluxoCaixa.Planejamento = false;
                            FluxoCaixa.ID_Cheque = int.Parse(txt_ID.Text);

                            FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                            FluxoCaixa.ID_CPagar = ID_CPagar;
                            FluxoCaixa.ID_CReceber = ID_CReceber;

                            BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                        }

                        BLL_Cheque = new BLL_Cheque();
                        Cheque = new DTO_Cheque();

                        Cheque.ID = int.Parse(txt_ID.Text);
                        Cheque.Situacao = 2;

                        BLL_Cheque.Altera_Situacao(Cheque);
                        #endregion

                        #region FAZ LANÇAMENTO FINANCEIRO REFERENTE AO CHEQUE
                        if (_Tipo == Tipo_Cheque.DEPOSITADO)
                        {
                            BLL_CReceber = new BLL_CReceber();
                            CReceber = new DTO_CReceber();

                            CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_Lanc_ChequeDevolvido;
                            CReceber.Situacao = 1;
                            CReceber.Documento = "CH " + txt_Cheque.Text;
                            CReceber.Emissao = Convert.ToDateTime(mk_DataLancamento.Text);
                            CReceber.Vencimento = Convert.ToDateTime(mk_DataLancamento.Text);
                            CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                            CReceber.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                            CReceber.Desconto = 0;
                            CReceber.Valor = double.Parse(txt_Valor.Text);
                            CReceber.QuantidadeParcela = 1;
                            CReceber.Parcela = 1;
                            CReceber.Descricao = util_msg.msg_ChequeDevolvido + txt_Cheque.Text;
                            CReceber.Controle = 0;
                            CReceber.Boleto = false;

                            obj = BLL_CReceber.Grava(CReceber);
                        }

                        if (_Tipo == Tipo_Cheque.PAGTOTERCEIRO)
                        {
                            BLL_CPagar = new BLL_CPagar();
                            CPagar = new DTO_CPagar();

                            CPagar.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            CPagar.ID_Conta = Parametro_Financeiro.ID_Conta_Lanc_ChequeDevolvido;
                            CPagar.Situacao = 1;
                            CPagar.Documento = "CH " + txt_Cheque.Text;
                            CPagar.Emissao = Convert.ToDateTime(mk_DataLancamento.Text);
                            CPagar.Vencimento = Convert.ToDateTime(mk_DataLancamento.Text);
                            CPagar.TipoPessoa = 2;
                            CPagar.ID_Pessoa = Parametro_Empresa.ID_Empresa_Ativa;
                            CPagar.Desconto = 0;
                            CPagar.Valor = double.Parse(txt_Valor.Text);
                            CPagar.QuantidadeParcela = 1;
                            CPagar.Parcela = 1;
                            CPagar.Descricao = util_msg.msg_ChequeDevolvido + txt_Cheque.Text;
                            CPagar.Controle = 0;

                            obj = BLL_CPagar.Grava(CPagar);

                            if (Convert.ToInt32(cb_TipoPessoa.SelectedValue) != 2)
                            {
                                BLL_CReceber = new BLL_CReceber();
                                CReceber = new DTO_CReceber();

                                CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_Lanc_ChequeDevolvido;
                                CReceber.Situacao = 1;
                                CReceber.Documento = "CH " + txt_Cheque.Text;
                                CReceber.Emissao = Convert.ToDateTime(mk_DataLancamento.Text);
                                CReceber.Vencimento = Convert.ToDateTime(mk_DataLancamento.Text);
                                CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                                CReceber.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                                CReceber.Desconto = 0;
                                CReceber.Valor = double.Parse(txt_Valor.Text);
                                CReceber.QuantidadeParcela = 1;
                                CReceber.Parcela = 1;
                                CReceber.Descricao = util_msg.msg_ChequeDevolvido + txt_Cheque.Text;
                                CReceber.Controle = 0;
                                CReceber.Boleto = false;

                                obj = BLL_CReceber.Grava(CReceber);
                            }
                        }
                        #endregion
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Transfere_Cheque()
        {
            try
            {
                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                BLL_Cheque = new BLL_Cheque();

                FluxoCaixa = new DTO_FluxoCaixa();
                Cheque = new DTO_Cheque();

                Cheque.ID = int.Parse(txt_ID.Text);

                DataTable _DT = new DataTable();
                _DT = BLL_Cheque.Busca_Resumo(Cheque);

                int ID_FluxoCaixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_FluxoCaixa"].ToString());
                int ID_Caixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_Caixa"].ToString());
                int ID_Pagamento = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_Pagamento"].ToString());

                int ID_CPagar = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_CPagar"].ToString());
                int ID_CReceber = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_CReceber"].ToString());

                FluxoCaixa.ID = ID_FluxoCaixa;

                BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);

                FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                FluxoCaixa.Planejamento = false;
                FluxoCaixa.Conciliado = true;

                BLL_FluxoCaixa.Altera_Lancamento_Cheque(FluxoCaixa);

                if (ID_Caixa != (int)cb_Caixa.SelectedValue)
                {
                    #region DEBITA O CHEQUE DA CONTA Q ELE FOI LANÇADO
                    FluxoCaixa = new DTO_FluxoCaixa();

                    FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                    FluxoCaixa.Caixa = ID_Caixa;
                    FluxoCaixa.Documento = txt_Cheque.Text;
                    FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                    FluxoCaixa.Credito = 0;
                    FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                    FluxoCaixa.Informacao = util_msg.msg_TranfereCheque + txt_Cheque.Text;
                    FluxoCaixa.Conciliado = true;
                    FluxoCaixa.ID_Pagamento = ID_Pagamento;
                    FluxoCaixa.Planejamento = false;
                    FluxoCaixa.ID_Cheque = int.Parse(txt_ID.Text);

                    FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                    FluxoCaixa.ID_CPagar = ID_CPagar;
                    FluxoCaixa.ID_CReceber = ID_CReceber;

                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                    #endregion

                    FluxoCaixa = new DTO_FluxoCaixa();

                    FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                    FluxoCaixa.Caixa = (int)cb_Caixa.SelectedValue;
                    FluxoCaixa.Documento = txt_Cheque.Text;

                    FluxoCaixa.Credito = double.Parse(txt_Valor.Text);
                    FluxoCaixa.Debito = 0;
                    FluxoCaixa.Conciliado = true;
                    FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                    FluxoCaixa.Informacao = util_msg.msg_LancaCheque + txt_Cheque.Text;

                    FluxoCaixa.ID_Pagamento = ID_Pagamento;
                    FluxoCaixa.Planejamento = false;
                    FluxoCaixa.ID_Cheque = int.Parse(txt_ID.Text);

                    FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                    FluxoCaixa.ID_CPagar = ID_CPagar;
                    FluxoCaixa.ID_CReceber = ID_CReceber;

                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Lanca_Cheque()
        {
            try
            {
                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                BLL_Cheque = new BLL_Cheque();

                FluxoCaixa = new DTO_FluxoCaixa();
                Cheque = new DTO_Cheque();

                Cheque.ID = int.Parse(txt_ID.Text);

                DataTable _DT = new DataTable();
                _DT = BLL_Cheque.Busca_Resumo(Cheque);

                int ID_FluxoCaixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_FluxoCaixa"].ToString());
                int ID_Caixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_Caixa"].ToString());
                int ID_Pagamento = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_Pagamento"].ToString());

                int ID_CPagar = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_CPagar"].ToString());
                int ID_CReceber = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_CReceber"].ToString());

                FluxoCaixa.ID = ID_FluxoCaixa;

                BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);

                FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                FluxoCaixa.Planejamento = false;
                FluxoCaixa.Conciliado = true;

                BLL_FluxoCaixa.Altera_Lancamento_Cheque(FluxoCaixa);

                if (ID_Caixa != (int)cb_Caixa.SelectedValue)
                {
                    #region DEBITA O CHEQUE DA CONTA Q ELE FOI LANÇADO
                    FluxoCaixa = new DTO_FluxoCaixa();

                    FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                    FluxoCaixa.Caixa = ID_Caixa;
                    FluxoCaixa.Documento = txt_Cheque.Text;
                    FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                    FluxoCaixa.Credito = 0;
                    FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                    FluxoCaixa.Informacao = util_msg.msg_TranfereCheque + txt_Cheque.Text;
                    FluxoCaixa.Conciliado = true;
                    FluxoCaixa.ID_Pagamento = ID_Pagamento;
                    FluxoCaixa.Planejamento = false;
                    FluxoCaixa.ID_Cheque = int.Parse(txt_ID.Text);

                    FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                    FluxoCaixa.ID_CPagar = ID_CPagar;
                    FluxoCaixa.ID_CReceber = ID_CReceber;

                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                    #endregion

                    FluxoCaixa = new DTO_FluxoCaixa();

                    FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    FluxoCaixa.Emissao = DateTime.Parse(mk_DataLancamento.Text);
                    FluxoCaixa.Caixa = (int)cb_Caixa.SelectedValue;
                    FluxoCaixa.Documento = txt_Cheque.Text;

                    FluxoCaixa.Credito = double.Parse(txt_Valor.Text);
                    FluxoCaixa.Debito = 0;
                    FluxoCaixa.Conciliado = false;
                    FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_TransferenciaValores;
                    FluxoCaixa.Informacao = util_msg.msg_LancaCheque + txt_Cheque.Text;

                    FluxoCaixa.ID_Pagamento = ID_Pagamento;
                    FluxoCaixa.Planejamento = false;
                    FluxoCaixa.ID_Cheque = int.Parse(txt_ID.Text);

                    FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                    FluxoCaixa.ID_CPagar = ID_CPagar;
                    FluxoCaixa.ID_CReceber = ID_CReceber;

                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                }

                Cheque.ID = int.Parse(txt_ID.Text);
                Cheque.Situacao = 3;

                BLL_Cheque.Altera_Situacao(Cheque);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Carrega_Historico(int _ID)
        {
            BLL_Cheque = new BLL_Cheque();
            Cheque = new DTO_Cheque();

            Cheque.ID = _ID;

            DataTable _DT = new DataTable();
            _DT = BLL_Cheque.Busca_Resumo(Cheque);
            dg_Resumo.DataSource = _DT;
        }

        private void Seleciona_Lancamento(int _Tipo_Lancamento)
        {
            //1 - TRANSFERENCIA
            //2 - DEPOSITO
            //3 - DEVOLVIDO - REPRESENTAR
            //4 - DEVOLVIDO - LANÇAR FINANCEIRO

            string msg = string.Empty;
            try
            {
                Tipo_Cheque _Tipo = util_dados.Retorna_TipoCheque(int.Parse(DG.Rows[DG.CurrentRow.Index].Cells["col_Situacao"].Value.ToString()));

                if (_Tipo == Tipo_Cheque.DISPONIVEL ||
                    _Tipo == Tipo_Cheque.DEPOSITADO ||
                    _Tipo == Tipo_Cheque.PAGTOTERCEIRO)
                {
                    if (_Tipo == Tipo_Cheque.DISPONIVEL)
                        if (_Tipo_Lancamento == 2 ||
                            _Tipo_Lancamento == 3)
                            throw new Exception(util_msg.msg_OpcaoInvalida);

                    if (_Tipo_Lancamento == 0 ||
                        _Tipo_Lancamento == 1)
                        if (_Tipo == Tipo_Cheque.DEPOSITADO ||
                       _Tipo == Tipo_Cheque.PAGTOTERCEIRO)
                            throw new Exception(util_msg.msg_OpcaoInvalida);

                    #region CONFIGURA MSG DE CONFIRMAÇÃO
                    switch (_Tipo_Lancamento)
                    {
                        case 1://DEPOSITAR
                            msg += "\n" + DG.Rows[DG.CurrentRow.Index].Cells["col_DescricaoPessoa"].Value.ToString();
                            msg += "\nVALOR R$ " + DG.Rows[DG.CurrentRow.Index].Cells["col_ValorCheque"].Value.ToString();
                            msg += "\nCAIXA " + cb_Caixa.Text;
                            break;
                        case 2://DEVOLVIDO - REPRESENTAR
                            msg += "\nREPRESENTAR CHEQUE " + DG.Rows[DG.CurrentRow.Index].Cells["col_DescricaoPessoa"].Value.ToString();
                            msg += "\nVALOR R$ " + DG.Rows[DG.CurrentRow.Index].Cells["col_ValorCheque"].Value.ToString();
                            break;
                        case 3://DEVOLVIDO - LANÇAR FINANCEIRO
                            msg += "\nDEVOLUÇÃO CHEQUE " + DG.Rows[DG.CurrentRow.Index].Cells["col_DescricaoPessoa"].Value.ToString();
                            msg += "\nVALOR R$ " + DG.Rows[DG.CurrentRow.Index].Cells["col_ValorCheque"].Value.ToString();
                            break;
                    }
                    #endregion

                    DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_Lancamento + msg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;

                    switch (_Tipo_Lancamento)
                    {
                        case 0://TRANSFERIR
                            Transfere_Cheque();
                            break;
                        case 1://DEPOSITAR
                            Lanca_Cheque();
                            break;
                        case 2://DEVOLVIDO - REPRESENTAR
                            Lanca_Cheque_Devolvido(_Tipo, Tipo_Cheque_Lanca.DEVOLVIDO_REPRESENTAR);
                            break;
                        case 3://DEVOLVIDO - LANÇAR FINANCEIRO
                            Lanca_Cheque_Devolvido(_Tipo, Tipo_Cheque_Lanca.DEVOLVIDO_FINANCEIRO);
                            break;
                    }

                    MessageBox.Show(util_msg.msg_Grava, this.Text);

                    Pesquisa();
                }
                else
                    throw new Exception(util_msg.msg_OpcaoInvalida);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
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

                CarregaPessoa(UI_Pessoa_Consulta.TipoPessoa);
                cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_Pessoa.Focus();
            }

            if (tabctl.SelectedTab == TabPage2)
            {
                cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

                CarregaPessoa(UI_Pessoa_Consulta.TipoPessoa);
                cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_PessoaP.Focus();
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
                return;

            BLL_Cheque = new BLL_Cheque();
            Cheque = new DTO_Cheque();

            Cheque.ID = util_dados.Verifica_int(txt_ID.Text);
            Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Cheque.Tipo = Convert.ToInt32(txt_Tipo.Text);
            Cheque.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Cheque.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            Cheque.Documento = txt_Documento.Text;
            Cheque.Emissao = Convert.ToDateTime(mk_Emissao.Text);
            Cheque.Vencimento = Convert.ToDateTime(mk_Vencimento.Text);
            Cheque.Banco = txt_Banco.Text;
            Cheque.Agencia = txt_Agencia.Text;
            Cheque.Conta = txt_Conta.Text;
            Cheque.Cheque = txt_Cheque.Text;
            Cheque.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);
            Cheque.Informacao = txt_Informacao.Text;
            Cheque.Valor = Convert.ToDouble(txt_Valor.Text);

            obj = BLL_Cheque.Grava(Cheque);

            if (obj > 0)
            {
                txt_ID.Text = obj.ToString();
                Config(StatusForm.Consulta);
            }

            MessageBox.Show(util_msg.msg_Grava, this.Text);
        }

        public override void Pesquisa()
        {
            try
            {
                BLL_Cheque = new BLL_Cheque();
                Cheque = new DTO_Cheque();

                Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                /*
                if (Tipo == Tipo_Cheque.Emitido)
                    Cheque.Tipo = 1;
                else
                    Cheque.Tipo = 2;
                */
                Cheque.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                Cheque.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                Cheque.Documento = txt_DocumentoP.Text;
                Cheque.Banco = txt_BancoP.Text;
                Cheque.Agencia = txt_AgenciaP.Text;
                Cheque.Conta = txt_ContaP.Text;
                Cheque.Cheque = txt_ChequeP.Text;
                Cheque.Situacao = Convert.ToInt32(cb_SituacaoP.SelectedValue);

                if (cb_Periodo.SelectedIndex == 0)
                {
                    Cheque.Consulta_Emissao.Filtra = true;
                    Cheque.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Cheque.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                if (cb_Periodo.SelectedIndex == 1)
                {
                    Cheque.Consulta_Vencimento.Filtra = true;
                    Cheque.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    Cheque.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                DataTable _DT = new DataTable();
                _DT = BLL_Cheque.Busca(Cheque);
                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);

                double Total = util_dados.Calcula_Campo_DT(_DT, "Valor");

                txt_Total.Text = util_dados.ConfigNumDecimal(Total, 2);
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
                BLL_Cheque = new BLL_Cheque();
                Cheque = new DTO_Cheque();

                Cheque.ID = util_dados.Verifica_int(txt_ID.Text);
                /*
                if (Tipo == Tipo_Cheque.Emitido)
                    Cheque.Tipo = 1;
                else
                    Cheque.Tipo = 2;
                */
                string msg = string.Empty;

                BLL_Cheque.Exclui(Cheque);
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
        private void UI_Cheque_Load(object sender, EventArgs e)
        {
            CarregaCB();
            Inicia_Form();

            tabctl.SelectedTab = TabPage2;
        }

        private void UI_Cheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
            {
                Pesquisa();
                Status = StatusForm.Consulta;
                Config_Botao();
            }

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
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

        private void cb_TipoPessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_TipoPessoaP.SelectedIndex = -1;
        }

        private void cb_ID_PessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_PessoaP.SelectedIndex = -1; ;
        }
        #endregion

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (txt_Valor.Text == string.Empty)
                txt_Valor.Text = "0";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }

        private void txt_ID_Pessoa_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID_Pessoa.Text) > 0)
                cb_ID_Pessoa.SelectedValue = int.Parse(txt_ID_Pessoa.Text);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) > 0)
            {
                Config(StatusForm.Consulta);
                Carrega_Historico(int.Parse(txt_ID.Text));
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

        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
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
            if (mk_DataFinal.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }

        }

        private void mk_DataLancamento_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataLancamento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataLancamento.Text = Convert.ToString(DateTime.Now);
                mk_DataLancamento.Focus();
            }

        }
        #endregion

        #region BOTTON
        private void bt_Transferencia_Click(object sender, EventArgs e)
        {
            Seleciona_Lancamento(0);
        }

        private void bt_Deposito_Click(object sender, EventArgs e)
        {
            Seleciona_Lancamento(1);
        }

        private void bt_DevolvidoRepresentar_Click(object sender, EventArgs e)
        {
            Seleciona_Lancamento(2);
        }

        private void bt_Devolvido_LancaFinanceiro_Click(object sender, EventArgs e)
        {
            Seleciona_Lancamento(3);
        }

        private void bt_Anterior_Click(object sender, EventArgs e)
        {
            if (DG.Rows.Count == 0 || DG.Rows.Count == 1)
                return;
            if (DG.CurrentRow == null)
                DG.Rows[0].Cells[0].Selected = true;

            int aux = DG.CurrentRow.Index - 1;
            if (aux >= 0)
            {
                DG.Rows[DG.CurrentRow.Index].Cells[0].Selected = false;
                DG.Rows[aux].Cells[0].Selected = true;
            }
        }

        private void bt_Proximo_Click(object sender, EventArgs e)
        {
            if (DG.Rows.Count == 0 || DG.Rows.Count == 1)
                return;
            if (DG.CurrentRow == null)
                DG.Rows[0].Cells[0].Selected = true;

            int aux = DG.CurrentRow.Index + 1;
            if (aux < DG.Rows.Count)
            {
                DG.Rows[DG.CurrentRow.Index].Cells[0].Selected = false;
                DG.Rows[aux].Cells[0].Selected = true;
            }
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region DATAGRID
        private void DG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            {
                if (DG.Columns[e.ColumnIndex].Name == "col_DescricaoSituacao")
                    if (e.Value != null)
                        switch (e.Value.ToString())
                        {
                            case "DISPONÍVEL"://DISPONIVEL
                                DG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                                break;

                            case "DEVOLVIDO"://DEVOLVIDO
                                DG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                                break;

                            case "DEPOSITADO"://DEPOSITADO
                            case "PAGTO. TERCEIRO"://PAGTO. TERCEIRO
                            case "COMPENSADO"://COMPENSADO
                                DG.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
                                break;
                        }
            }
        }


        #endregion

     
    }
}
