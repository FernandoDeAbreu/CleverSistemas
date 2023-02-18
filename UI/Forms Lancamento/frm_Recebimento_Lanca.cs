using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;

namespace Sistema.UI
{
    public partial class frm_Recebimento_Lanca : Form
    {
        public frm_Recebimento_Lanca()
        {
            DTTipoPessoa = new DataTable("TipoPessoa");
            DTTipoPessoa.Columns.Add("ID");
            DTTipoPessoa.Columns.Add("Descricao");

            DT = new DataTable("Cheque");
            DT.Columns.Add("TipoControleCheque");
            DT.Columns.Add("TipoPessoa");
            DT.Columns.Add("ID_Pessoa");
            DT.Columns.Add("Documento");
            DT.Columns.Add("Emissao");
            DT.Columns.Add("Vencimento");
            DT.Columns.Add("Banco");
            DT.Columns.Add("Agencia");
            DT.Columns.Add("Conta");
            DT.Columns.Add("Cheque");
            DT.Columns.Add("Informacao");
            DT.Columns.Add("Valor");

            InitializeComponent();
        }

        #region Propriedades
        public DTO_Pagamento_Lanca Pagamento_Lanca { get; set; }
        #endregion

        #region Variaveis de Classe
        BLL_Banco BLL_Banco;
        BLL_Cheque_Situacao BLL_Cheque_Situacao;
        BLL_PlanoConta BLL_PlanoConta;
        BLL_Cheque BLL_Cheque;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_Pagamento BLL_Pagamento;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region Variaveis Diversas
        string obj;
        string Conta;

        DataRow DR;
        DataTable DTContaSuperior;
        DataTable DTTipoPessoa;
        DataTable DTChequeSituacao;
        DataTable DTPessoa;
        DataTable DTPagamento;
        DataTable DT;
        DataTable DTBanco;

        bool bolCheque;

        DateTime ValidaData;

        int intDiasCheque = 0;
        #endregion

        #region Estrutura
        DTO_Banco Banco;
        DTO_Cheque_Situacao Cheque_Situacao;
        DTO_PlanoConta PlanoConta;
        DTO_Cheque Cheque;
        List<DTO_Cheque> ChequeTemp = new List<DTO_Cheque>();
        DTO_FluxoCaixa FluxoCaixa;
        DTO_Pagamento Pagamento;
        DTO_Pessoa Pessoa;
        DTO_Pagamento Config_Pagamento;
        #endregion

        #region Rotinas
        public void CarregaConta()
        {
            BLL_PlanoConta = new BLL_PlanoConta();
            PlanoConta = new DTO_PlanoConta();

            Conta = Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));
            //Nivel 1
            if (Conta.Length == 2)
            {
                PlanoConta.Nivel = Rotinas.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = Rotinas.GravaCodigoDescritivo(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                if (DTContaSuperior.Rows.Count == 0)
                {
                    txt_IDConta.Text = "";
                    txt_DescricaoConta.Text = "";
                    return;
                }
                Rotinas.CarregaCampos(this, DTContaSuperior, gb_GrupoNivel);
                return;
            }
            //Nivel 2
            if (Conta.Length == 4)
            {
                PlanoConta.Nivel = Rotinas.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = Rotinas.GravaCodigoDescritivo(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                if (DTContaSuperior.Rows.Count == 0)
                {
                    txt_IDConta.Text = "";
                    txt_DescricaoConta.Text = "";
                    return;
                }
                Rotinas.CarregaCampos(this, DTContaSuperior, gb_GrupoNivel);
                return;
            }
            //Nivel 3
            if (Conta.Length == 6)
            {
                PlanoConta.Nivel = Rotinas.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = Rotinas.GravaCodigoDescritivo(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                if (DTContaSuperior.Rows.Count == 0)
                {
                    txt_IDConta.Text = "";
                    txt_DescricaoConta.Text = "";
                    return;
                }
                Rotinas.CarregaCampos(this, DTContaSuperior, gb_GrupoNivel);
                return;
            }
            //Nivel 4
            if (Conta.Length == 8)
            {
                PlanoConta.Nivel = Rotinas.Verifica_int(txt_Nivel.Text);
                PlanoConta.CodigoPai = Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                PlanoConta.Nivel = 0;
                PlanoConta.CodigoDescritivo = Rotinas.GravaCodigoDescritivo(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text));
                PlanoConta.CodigoPai = string.Empty;

                DTContaSuperior = BLL_PlanoConta.Busca(PlanoConta);
                if (DTContaSuperior.Rows.Count == 0)
                {
                    txt_IDConta.Text = "";
                    return;
                }
                Rotinas.CarregaCampos(this, DTContaSuperior, gb_GrupoNivel);
                return;
            }
        }

        public void CarregaTipoPessoa()
        {
            DR = DTTipoPessoa.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "Cliente";
            DTTipoPessoa.Rows.Add(DR);
            DTTipoPessoa.AcceptChanges();
            DR = DTTipoPessoa.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "Empresa";
            DTTipoPessoa.Rows.Add(DR);
            DTTipoPessoa.AcceptChanges();
            DR = DTTipoPessoa.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "Fornecedores";
            DTTipoPessoa.Rows.Add(DR);
            DTTipoPessoa.AcceptChanges();
            DR = DTTipoPessoa.NewRow();
            DR["ID"] = "4";
            DR["Descricao"] = "Funcionários";
            DTTipoPessoa.Rows.Add(DR);
            DTTipoPessoa.AcceptChanges();
            DR = DTTipoPessoa.NewRow();
            DR["ID"] = "5";
            DR["Descricao"] = "Transportadora";
            DTTipoPessoa.Rows.Add(DR);
            DTTipoPessoa.AcceptChanges();
        }

        public void CarregaCB()
        {
            BLL_Cheque_Situacao = new BLL_Cheque_Situacao();
            Cheque_Situacao = new DTO_Cheque_Situacao();

            DTChequeSituacao = BLL_Cheque_Situacao.Busca(Cheque_Situacao);
            Rotinas.CarregaCombo(DTChequeSituacao, "Descricao", "ID", cb_Situacao);

            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();
            
            Pagamento.FiltraPagamento = true;
            Pagamento.Recebimento = true;

            DTPagamento = BLL_Pagamento.Busca(Pagamento);
            Rotinas.CarregaCombo(DTPagamento, "Descricao", "ID", cb_Pagamento);
        }

        public void CarregaPessoa(int intTipoPessoa)
        {
            try
            {
                switch (intTipoPessoa)
                {
                    case 1:
                        BLL_Pessoa = new BLL_Pessoa();
                        Pessoa = new DTO_Pessoa();

                        Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                        Pessoa.ID_Empresa = Parametros.IDEmpresa;
                        Pessoa.Situacao = Parametros.SituacaoLiberada;

                        DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                        Rotinas.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
                        break;
                }

            }
            catch (Exception)
            {
            }
        }

        public void SomaValor()
        {
            double aux = 0;

            if (dg_Pagamento.Rows.Count > 0)
                for (int i = 0; i <= dg_Pagamento.Rows.Count - 1; i++)
                    aux = (aux + Convert.ToDouble(dg_Pagamento.Rows[i].Cells["col_Valor"].Value));

            txt_Soma.Text = Rotinas.ConfigNumDecimal(aux, 3);
            txt_Diferenca.Text = Rotinas.ConfigNumDecimal(Convert.ToDouble(txt_ValorTotal.Text) - Convert.ToDouble(txt_Soma.Text), 3);

            if (Convert.ToDouble(txt_Diferenca.Text) < 0)
            {
                lb_Troco.Text = "Troco";
                txt_Diferenca.ForeColor = Color.Red;
            }
            else
            {
                lb_Troco.Text = "Falta";
                txt_Diferenca.ForeColor = Color.Black;
            }
        }

        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            // Executa o método de forma assíncrona - pois o MaskedTextBox já executa um
            // select no evento "Enter" do foco, que acaba desfazendo a seleção.
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is TextBoxBase)
                {
                    ((TextBoxBase)sender).SelectAll();
                }
            });
        }

        private void DelegateEnterFocus(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is TextBoxBase))
            {
                ctrl.Enter += SelectText_Enter;
                return;
            }

            // Chamada recursiva para associar o evento a todos os controles da UI
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocus(ctrlChild);
            }
        }

        private DTO_Pagamento Carrega_Config_Pagamento(DataTable _DT)
        {
            DTO_Pagamento aux = new DTO_Pagamento();
            aux.ID = Convert.ToInt32(_DT.Rows[0]["ID"]);
            //aux.Lanca_Caixa = Convert.ToBoolean(_DT.Rows[0]["Lanca_Caixa"]);
           // aux.Lanca_Financa = Convert.ToBoolean(_DT.Rows[0]["Lanca_Financa"]);
           // aux.Qt_Parcela = Convert.ToInt32(_DT.Rows[0]["Qt_Parcela"]);
            aux.Porc_Custo = Convert.ToDouble(_DT.Rows[0]["Porc_Custo"]);
            aux.Vlr_Custo = Convert.ToDouble(_DT.Rows[0]["Vlr_Custo"]);
            aux.Tipo = Convert.ToInt32(_DT.Rows[0]["Tipo"]);

            return aux;
        }
        #endregion

        #region ComboBox
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa(1);
        }

        private void cb_Pagamento_Leave(object sender, EventArgs e)
        {
            List<string> Descricao_Parcela = new List<string>();
            bolCheque = false;
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            Pagamento.ID = Convert.ToInt32(cb_Pagamento.SelectedValue);

            DT = BLL_Pagamento.Busca(Pagamento);
            if (DT.Rows.Count > 0)
            {
                /*
                Config_Pagamento = new DTO_Pagamento();
                Config_Pagamento = Carrega_Config_Pagamento(DT);

                for (int i = 1; i <= Config_Pagamento.Qt_Parcela; i++)
                    Descricao_Parcela.Add(i.ToString());

                Rotinas.CarregaCombo(Rotinas.CarregaComboDinamico(Config_Pagamento.Qt_Parcela, Descricao_Parcela), "Descricao", "ID", cb_Qt_Parcela);
                cb_Qt_Parcela.SelectedIndex = 0;
                */
                #region PAGAMENTO COM CHEQUE
                if (Config_Pagamento.Tipo == 3)
                {
                    bolCheque = true;

                    BLL_Banco = new BLL_Banco();
                    Banco = new DTO_Banco();
                    Banco.ID_Caixa = Pagamento_Lanca.Caixa;
                    DTBanco = BLL_Banco.Busca(Banco);

                    if (DTBanco.Rows.Count == 1 && Pagamento_Lanca.TipoLancamento == 1)
                    {
                        DR = DTBanco.Rows[0];
                        txt_Banco.Text = Convert.ToString(DR["ID_Banco"]).PadLeft(3, '0');
                        txt_Agencia.Text = Convert.ToString(DR["Agencia"]);
                        txt_Conta.Text = Convert.ToString(DR["Conta"]);
                        txt_Cheque.Text = "";
                    }
                    else
                    {
                        cb_TipoPessoa.SelectedValue = Pagamento_Lanca.TipoPessoa;
                        cb_ID_Pessoa.SelectedValue = Pagamento_Lanca.ID_Pessoa;
                        txt_Banco.Text = "";
                        txt_Agencia.Text = "";
                        txt_Conta.Text = "";
                        txt_Cheque.Text = "";
                    }

                    gb_Cheque.Enabled = true;
                }
                #endregion

                else
                {
                    txt_Banco.Text = "";
                    txt_Agencia.Text = "";
                    txt_Conta.Text = "";
                    txt_Cheque.Text = "";
                    cb_TipoPessoa.SelectedIndex = -1;
                    cb_ID_Pessoa.SelectedIndex = -1;
                    gb_Cheque.Enabled = false;
                }
            }
        }

        private void cb_Situacao_Leave(object sender, EventArgs e)
        {
            intDiasCheque = 0;
            BLL_Cheque_Situacao = new BLL_Cheque_Situacao();
            Cheque_Situacao = new DTO_Cheque_Situacao();

            Cheque_Situacao.ID = Convert.ToInt32(cb_Situacao.SelectedValue);

            DTChequeSituacao = BLL_Cheque_Situacao.Busca(Cheque_Situacao);

            DR = DTChequeSituacao.Rows[0];
            intDiasCheque = Convert.ToInt32(DR["Dias"]);
        }
        #endregion

        #region TextBox
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (txt_Valor.Text == string.Empty)
                txt_Valor.Text = "0";

            txt_Valor.Text = Rotinas.ConfigNumDecimal(txt_Valor.Text, 3);
        }
        #endregion

        #region MaskedBox
        private void mk_GrupoNivel_Leave(object sender, EventArgs e)
        {
            mk_GrupoNivel.Text = mk_GrupoNivel.Text.Replace(" ", "0");
        }

        private void mk_GrupoNivel_TextChanged(object sender, EventArgs e)
        {
            txt_Nivel.Text = Rotinas.VerificaNivel(mk_GrupoNivel.Text);
            if (mk_GrupoNivel.Text.Replace(".", "").Replace(" ", "") != string.Empty)
                if (Convert.ToString(Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text))).Length == 2 | Convert.ToString(Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text))).Length == 4 | (Convert.ToString(Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text))).Length == 6 | Convert.ToString(Rotinas.ConsultaCodigoPai(mk_GrupoNivel.Text, Rotinas.Verifica_int(txt_Nivel.Text))).Length == 8))
                    CarregaConta();
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
            DateTime.TryParseExact(Convert.ToString(DateTime.Now), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
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
            DateTime.TryParseExact(Convert.ToString(DateTime.Now), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
        }
        #endregion

        #region Form
        private void frm_LancaCheque_Load(object sender, EventArgs e)
        {
            dg_Pagamento.AutoGenerateColumns = false;
            cb_ID_Pessoa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CarregaTipoPessoa();
            CarregaCB();

            Rotinas.CarregaCombo(DTTipoPessoa, "Descricao", "ID", cb_TipoPessoa);

            mk_Emissao.Text = DateTime.Now.ToString();
            mk_Vencimento.Text = DateTime.Now.ToString();

            cb_TipoPessoa.SelectedValue = Pagamento_Lanca.TipoPessoa;
            cb_ID_Pessoa.SelectedValue = Pagamento_Lanca.ID_Pessoa;

            if (Pagamento_Lanca.TipoLancamento == 3)
            {
                cb_Qt_Parcela.Enabled = true;
                cb_Pagamento.SelectedValue = Pagamento_Lanca.ID_TipoPagamento;
            }
            else
            {
                cb_Qt_Parcela.Enabled = false;
                cb_Pagamento.SelectedIndex = 0;
            }

            txt_Documento.Text = Pagamento_Lanca.Documento;
            txt_ValorTotal.Text = Rotinas.ConfigNumDecimal(Pagamento_Lanca.ValorTotal, 3);
            cb_Situacao.SelectedValue = Parametros.SituacaoLancarCheque;
            mk_GrupoNivel.Text = Pagamento_Lanca.ContaLancamento;
            txt_Valor.Text = Rotinas.ConfigNumDecimal(Pagamento_Lanca.ValorTotal, 3);

            Pagamento_Lanca.Concluido = false;
            this.DelegateEnterFocus(this);
        }

        private void frm_LancaCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Agencia.Focused == true ||
                txt_Conta.Focused == true ||
                txt_Cheque.Focused == true ||
                txt_Banco.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(Rotinas.NumDocumento(KeyAscii));
                if (KeyAscii == 0)
                {
                    e.Handled = true;
                }
            }

            if (txt_Valor.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(Rotinas.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void frm_Pagamento_Lanca_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Pagamento_Lanca.Concluido == false && Pagamento_Lanca.TipoLancamento == 3)
            {
                DialogResult msgbox;
                msgbox = MessageBox.Show("Atenção, não foi Realizado o Pagamento.\nFechar sem realizar o Pagamento?", "Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    e.Cancel = true;
                else
                    MessageBox.Show("Realize o Faturamento do Pedido!", "Pagamento");
            }
        }
        #endregion

        #region Button
        private void bt_Adiciona_Click(object sender, EventArgs e)
        {
            if (txt_Informacao.Text.Trim() == string.Empty)
                if (bolCheque == false)
                    txt_Informacao.Text = "PAGTO. " + cb_Pagamento.Text;
                else
                    txt_Informacao.Text = "CH. Nº " + txt_Cheque.Text;

            if (bolCheque == true)
            {
                BLL_Cheque = new BLL_Cheque();
                Cheque = new DTO_Cheque();

                Cheque.Tipo = Pagamento_Lanca.TipoLancamento;
                Cheque.ID_Empresa = Parametros.IDEmpresa;
                Cheque.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Cheque.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Cheque.Emissao = Convert.ToDateTime(mk_Emissao.Text);
                Cheque.Vencimento = Convert.ToDateTime(mk_Vencimento.Text);
                Cheque.Banco = txt_Banco.Text;
                Cheque.Agencia = txt_Agencia.Text;
                Cheque.Documento = txt_Documento.Text;
                Cheque.Conta = txt_Conta.Text;
                Cheque.Cheque = txt_Cheque.Text;
                Cheque.Situacao = Convert.ToInt32(cb_Situacao.SelectedValue);
                Cheque.Informacao = txt_InformacaoCheque.Text;
                Cheque.Valor = Convert.ToDouble(txt_Valor.Text);

                obj = BLL_Cheque.Valida(Cheque);

                if (obj != null)
                {
                    MessageBox.Show(obj, "Cheque");
                    return;
                }

                ChequeTemp.Add(Cheque);
            }

            int aux = dg_Pagamento.Rows.Count;
            dg_Pagamento.Rows.Add();

            dg_Pagamento.Rows[aux].Cells["col_Data"].Value = mk_Emissao.Text;
            dg_Pagamento.Rows[aux].Cells["col_Pagamento"].Value = cb_Pagamento.Text;
            dg_Pagamento.Rows[aux].Cells["col_Banco"].Value = txt_Banco.Text;
            dg_Pagamento.Rows[aux].Cells["col_Cheque"].Value = txt_Cheque.Text;
            dg_Pagamento.Rows[aux].Cells["col_Documento"].Value = txt_Documento.Text;
            dg_Pagamento.Rows[aux].Cells["col_Vencimento"].Value = mk_Vencimento.Text;
            dg_Pagamento.Rows[aux].Cells["col_Valor"].Value = txt_Valor.Text;
            dg_Pagamento.Rows[aux].Cells["col_Informacao"].Value = txt_Informacao.Text;
            dg_Pagamento.Rows[aux].Cells["col_Conciliado"].Value = ck_Conciliado.Checked;
            dg_Pagamento.Rows[aux].Cells["col_Conta"].Value = mk_GrupoNivel.Text;
            dg_Pagamento.Rows[aux].Cells["col_ID_Conta"].Value = txt_IDConta.Text;
            dg_Pagamento.Rows[aux].Cells["col_ID_Pagamento"].Value = Convert.ToInt32(cb_Pagamento.SelectedValue);

            if (bolCheque == true)
            {
                dg_Pagamento.Rows[aux].Cells["col_LancamentoCheque"].Value = true;
                dg_Pagamento.Rows[aux].Cells["col_DiasCheque"].Value = intDiasCheque;
            }
            else
            {
                dg_Pagamento.Rows[aux].Cells["col_LancamentoCheque"].Value = false;
                dg_Pagamento.Rows[aux].Cells["col_DiasCheque"].Value = intDiasCheque;
            }

            SomaValor();

            if (Convert.ToDouble(txt_Diferenca.Text) < 0)
                txt_Valor.Text = "0,000";
            else
                txt_Valor.Text = txt_Diferenca.Text;

            txt_Informacao.Text = string.Empty;

            if (double.Parse(txt_Diferenca.Text) <= 0)
                bt_Concluido.Focus();
            else
                cb_Pagamento.Focus();
        }

        private void bt_Concluido_Click(object sender, EventArgs e)
        {
            if (double.Parse(txt_Diferenca.Text) > 0)
            {
                MessageBox.Show("Valor Inválido!");
                return;
            }

            Pagamento_Lanca.ID_FluxoCaixa = new int[dg_Pagamento.Rows.Count];

            BLL_Cheque = new BLL_Cheque();
            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            FluxoCaixa = new DTO_FluxoCaixa();

            for (int i = 0; i <= ChequeTemp.Count - 1; i++)
            {
                obj = BLL_Cheque.Grava(ChequeTemp[i]);
                if (obj.IndexOf("Sucesso") != -1)
                    ChequeTemp[i].ID_Cheque = Convert.ToInt32(obj.Substring(34));
                else
                {
                    MessageBox.Show(obj, "Cheque");
                    return;
                }
            }

            DateTime Vencimento;
            int ID_Conta;
            string Conta;
            double Valor;
            string Informacao;
            bool Conciliado;
            bool Cheque;
            int ID_Cheque;
            string Documento;
            int ID_Pagamento;
            int DiasCheque;
            bool Planejamento;

            int aux = 0;

            for (int i = 0; i <= dg_Pagamento.Rows.Count - 1; i++)
            {
                Vencimento = Convert.ToDateTime(dg_Pagamento.Rows[i].Cells["col_Vencimento"].Value);
                ID_Conta = Convert.ToInt32(dg_Pagamento.Rows[i].Cells["col_ID_Conta"].Value);
                Conta = Convert.ToString(dg_Pagamento.Rows[i].Cells["col_Conta"].Value);
                Valor = Convert.ToDouble(dg_Pagamento.Rows[i].Cells["col_Valor"].Value);
                Informacao = Convert.ToString(dg_Pagamento.Rows[i].Cells["col_Informacao"].Value);
                Conciliado = Convert.ToBoolean(dg_Pagamento.Rows[i].Cells["col_Conciliado"].Value);
                Cheque = Convert.ToBoolean(dg_Pagamento.Rows[i].Cells["col_LancamentoCheque"].Value);
                Documento = Convert.ToString(dg_Pagamento.Rows[i].Cells["col_Documento"].Value);
                ID_Pagamento = Convert.ToInt32(dg_Pagamento.Rows[i].Cells["col_ID_Pagamento"].Value);
                DiasCheque = Convert.ToInt32(dg_Pagamento.Rows[i].Cells["col_DiasCheque"].Value);

                if (Vencimento.Date > DateTime.Now.AddDays(DiasCheque).Date && Cheque == true)
                    Planejamento = true;
                else
                    Planejamento = false;

                if (Cheque == true)
                {
                    ID_Cheque = ChequeTemp[aux].ID_Cheque;
                    aux++;
                }
                else
                    ID_Cheque = 0;

                FluxoCaixa.ID = 0;
                FluxoCaixa.ID_Empresa = Parametros.IDEmpresa;
                FluxoCaixa.Emissao = Vencimento;
                FluxoCaixa.Caixa = Pagamento_Lanca.Caixa;
                FluxoCaixa.Documento = Documento;
                FluxoCaixa.ID_Conta = ID_Conta;
                FluxoCaixa.GrupoConta = Conta;
                FluxoCaixa.Informacao = Informacao;
                FluxoCaixa.ID_Cheque = ID_Cheque;
                FluxoCaixa.Conciliado = Conciliado;
                FluxoCaixa.ID_Pagamento = ID_Pagamento;
                FluxoCaixa.Planejamento = Planejamento;

                if (Pagamento_Lanca.TipoLancamento == 1)
                {
                    FluxoCaixa.Credito = 0;
                    FluxoCaixa.Debito = Valor;
                    obj = BLL_FluxoCaixa.Grava(FluxoCaixa);
                    Pagamento_Lanca.ID_FluxoCaixa[i] = Convert.ToInt32(obj.Substring(34));
                }
                else
                {
                    FluxoCaixa.Credito = Valor;
                    FluxoCaixa.Debito = 0;
                    obj = BLL_FluxoCaixa.Grava(FluxoCaixa);
                    Pagamento_Lanca.ID_FluxoCaixa[i] = Convert.ToInt32(obj.Substring(34));
                }
            }

            if (double.Parse(txt_Diferenca.Text) < 0)
            {
                FluxoCaixa.ID = 0;
                FluxoCaixa.ID_Empresa = Parametros.IDEmpresa;
                FluxoCaixa.Emissao = Convert.ToDateTime(mk_Emissao.Text);
                FluxoCaixa.Caixa = Pagamento_Lanca.Caixa;
                FluxoCaixa.Documento = "";
                FluxoCaixa.Informacao = "TROCO";
                FluxoCaixa.ID_Cheque = 0;
                FluxoCaixa.Conciliado = true;
                FluxoCaixa.ID_Pagamento = 0;
                FluxoCaixa.Planejamento = false;


                if (Pagamento_Lanca.TipoLancamento == 1)
                {
                    FluxoCaixa.ID_Conta = Parametros.ID_ContaPagar;
                    FluxoCaixa.GrupoConta = Parametros.NivelContaPagar;
                    FluxoCaixa.Debito = 0;
                    FluxoCaixa.Credito = (Convert.ToDouble(txt_Diferenca.Text) * -1);

                    BLL_FluxoCaixa.Grava(FluxoCaixa);
                }
                else
                {
                    FluxoCaixa.ID_Conta = Parametros.ID_ContaReceber;
                    FluxoCaixa.GrupoConta = Parametros.NivelContaReceber;
                    FluxoCaixa.Debito = (Convert.ToDouble(txt_Diferenca.Text) * -1);
                    FluxoCaixa.Credito = 0;

                    BLL_FluxoCaixa.Grava(FluxoCaixa);
                }
            }
            Pagamento_Lanca.Concluido = true;
            this.Close();
        }

        private void bt_Exclui_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show("Excluir Lançamento?", "Lançamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            if (Convert.ToBoolean(dg_Pagamento.Rows[dg_Pagamento.CurrentRow.Index].Cells["col_LancamentoCheque"].Value) == true)
                if (dg_Pagamento.Rows.Count > 1)
                    if (dg_Pagamento.CurrentRow.Index == 0)
                        ChequeTemp.RemoveAt(0);
                    else
                        ChequeTemp.RemoveAt(dg_Pagamento.CurrentRow.Index - 1);
                else
                    ChequeTemp.RemoveAt(0);

            dg_Pagamento.Rows.RemoveAt(dg_Pagamento.CurrentRow.Index);

            SomaValor();

            if (Convert.ToDouble(txt_Diferenca.Text) < 0)
                txt_Valor.Text = "0,000";
            else
                txt_Valor.Text = txt_Diferenca.Text;

            txt_Informacao.Text = string.Empty;

            if (double.Parse(txt_Diferenca.Text) <= 0)
                bt_Concluido.Focus();
            else
                cb_Pagamento.Focus();
        }

        private void bt_PesquisaConta_Click(object sender, EventArgs e)
        {
            Parametros.TipoConsultaPlano = 1;
            frm_ConsultaPlano frm = new frm_ConsultaPlano();
            frm.ShowDialog();
            mk_GrupoNivel.Text = Parametros.NivelConta;
        }
        #endregion
    }
}
