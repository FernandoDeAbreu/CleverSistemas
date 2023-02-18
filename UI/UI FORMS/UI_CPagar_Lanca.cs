using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_CPagar_Lanca : Form
    {
        public UI_CPagar_Lanca()
        {
            InitializeComponent();
        }

        #region PROPRIEDADES
        public string Documento { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public string Descricao_Pessoa { get; set; }
        public double Valor { get; set; }
        public DateTime Emissao { get; set; }
        public bool Concluido { get; set; }
        public int ID_Pagamento { get; set; }
        public int ID_Parcelamento { get; set; }

        public List<DTO_CPagar> lst_CPagar { get; set; }
        #endregion

        #region VARIAVEIS DE CLASSE
        BLL_Pagamento BLL_Pagamento;
        BLL_CPagar BLL_CPagar;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_Cheque BLL_Cheque;
        BLL_Grupo BLL_Grupo;
        BLL_Banco BLL_Banco;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;
        DateTime DataBaixa = DateTime.Now;

        int TipoPagamento;
        int Dia_Lancamento;
        int ID_Cheque;

        double Custo_Procentagem;
        #endregion

        #region ESTRUTURA
        DTO_Pagamento Pagamento;
        List<DTO_Lancamento> Lst_Lancamento;
        DTO_Lancamento Lancamento;
        DTO_CPagar CPagar;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_Cheque Cheque;
        DTO_Grupo Grupo;
        DTO_Banco Banco;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "BAIXA CONTAS À PAGAR";

            mk_Vencimento.Text = DateTime.Now.ToString();
            mk_DataCheque.Text = DateTime.Now.ToString();
            txt_Valor.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_Diferenca.Text = util_dados.ConfigNumDecimal(Valor, 2);

            CarregaCB();

            Lst_Lancamento = new List<DTO_Lancamento>();

            Concluido = false;

            cb_CaixaBaixa.Focus();

            lstv_Pagamento.Items[0].Focused = true;
            lstv_Pagamento.Items[0].Selected = true;
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            Pagamento.FiltraPagamento = true;
            Pagamento.Pagamento = true;
            Pagamento.FiltraBaixa = true;

            _DT = BLL_Pagamento.Busca(Pagamento);

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                ListViewItem Item = new ListViewItem(_DT.Rows[i]["ID"].ToString());

                Item.SubItems.Add(_DT.Rows[i]["Descricao"].ToString());

                lstv_Pagamento.Items.Add(Item);
            }

            _DT = new DataTable();
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);
            Grupo.FiltraExibir = true;
            Grupo.Exibir = true;

            _DT = BLL_Grupo.Busca(Grupo);

            if (_DT.Rows.Count > 0)
            {
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_CaixaBaixa);
                cb_CaixaBaixa.SelectedIndex = 0;
            }

            BLL_Banco = new BLL_Banco();
            Banco = new DTO_Banco();

            _DT = new DataTable();
            _DT = BLL_Banco.Busca(Banco);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Banco);
        }

        private void Carrega_Lancamento()
        {
            try
            {
                double Valor_Total = Convert.ToDouble(txt_Valor.Text);

                DateTime Data_Inicial = Convert.ToDateTime(mk_Vencimento.Text);
                DataBaixa = Convert.ToDateTime(mk_Vencimento.Text);

                #region CONTA LANCAMENTO
                int Conta_Lancamento;

                if (lst_CPagar.Count == 1)
                    Conta_Lancamento = lst_CPagar[0].ID_Conta;
                else
                    Conta_Lancamento = Parametro_Financeiro.ID_Conta_PagtoDiverso;
                #endregion

                #region LANÇA PREVIA DE PAGAMENTO
                Valida_Dados();

                switch (TipoPagamento)
                {
                    case 1://BOLETO
                    case 2://CARTÃO
                    case 4://DINHEIRO
                    case 5://CARTEIRA
                    case 6://OUTROS
                        Lancamento = new DTO_Lancamento();
                        Lancamento.FluxoCaixa = new DTO_FluxoCaixa();

                        Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                        Lancamento.Tipo = TipoPagamento;

                        Lancamento.FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Lancamento.FluxoCaixa.Emissao = DateTime.Parse(mk_Vencimento.Text);
                        Lancamento.FluxoCaixa.Caixa = (int)cb_CaixaBaixa.SelectedValue;
                        Lancamento.FluxoCaixa.Documento = Documento;
                        Lancamento.FluxoCaixa.ID_Conta = Conta_Lancamento;
                        Lancamento.FluxoCaixa.Credito = 0;
                        Lancamento.FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                        Lancamento.FluxoCaixa.Informacao = "PAGAMENTO " + Lancamento.Descricao;
                        Lancamento.FluxoCaixa.Conciliado = (bool)ck_Conciliado.Checked;
                        Lancamento.FluxoCaixa.ID_Pagamento = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);
                        Lancamento.FluxoCaixa.Planejamento = false;

                        Lst_Lancamento.Add(Lancamento);
                        break;

                    case 3://CHEQUE
                        if (ID_Cheque > 0 &&
                           ck_ChequeTerceiro.Checked == true)
                        {
                            Lancamento = new DTO_Lancamento();
                            Lancamento.FluxoCaixa = new DTO_FluxoCaixa();

                            Lancamento.Tipo = 0;

                            Lancamento.FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            Lancamento.FluxoCaixa.Emissao = DateTime.Parse(mk_Vencimento.Text);
                            Lancamento.FluxoCaixa.Caixa = (int)cb_CaixaBaixa.SelectedValue;
                            Lancamento.FluxoCaixa.Documento = txt_Cheque.Text;
                            Lancamento.FluxoCaixa.ID_Conta = Conta_Lancamento;
                            Lancamento.FluxoCaixa.Credito = double.Parse(txt_Valor.Text);
                            Lancamento.FluxoCaixa.Debito = 0;
                            Lancamento.FluxoCaixa.Conciliado = true;
                            Lancamento.FluxoCaixa.ID_Pagamento = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);
                            Lancamento.FluxoCaixa.Planejamento = false;
                            Lancamento.FluxoCaixa.ID_Cheque = ID_Cheque;

                            Lst_Lancamento.Add(Lancamento);
                        }

                        Lancamento = new DTO_Lancamento();
                        Lancamento.FluxoCaixa = new DTO_FluxoCaixa();

                        Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                        Lancamento.Tipo = TipoPagamento;

                        Lancamento.FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Lancamento.FluxoCaixa.Emissao = DateTime.Parse(mk_DataCheque.Text);
                        Lancamento.FluxoCaixa.Caixa = (int)cb_CaixaBaixa.SelectedValue;
                        Lancamento.FluxoCaixa.Documento = Documento;
                        Lancamento.FluxoCaixa.ID_Conta = Conta_Lancamento;
                        Lancamento.FluxoCaixa.Credito = 0;
                        Lancamento.FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                        Lancamento.FluxoCaixa.Informacao = util_msg.msg_LancaCheque + txt_Cheque.Text;
                        Lancamento.FluxoCaixa.Conciliado = (bool)ck_Conciliado.Checked;
                        Lancamento.FluxoCaixa.ID_Pagamento = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);
                        Lancamento.FluxoCaixa.Planejamento = false;
                        Lancamento.FluxoCaixa.ID_Cheque = ID_Cheque;

                        Lancamento.Cheque = new DTO_Cheque();

                        Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                        Lancamento.Tipo = TipoPagamento;

                        Lancamento.Cheque.ID = ID_Cheque;
                        Lancamento.Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Lancamento.Cheque.Tipo = 1;
                        Lancamento.Cheque.TipoPessoa = 2;
                        Lancamento.Cheque.ID_Pessoa = Parametro_Empresa.ID_Empresa_Ativa;
                        Lancamento.Cheque.Documento = Documento;
                        Lancamento.Cheque.Emissao = DateTime.Parse(mk_Vencimento.Text);
                        Lancamento.Cheque.Vencimento = DateTime.Parse(mk_DataCheque.Text);
                        Lancamento.Cheque.Banco = txt_Banco.Text;
                        Lancamento.Cheque.Agencia = txt_Agencia.Text;
                        Lancamento.Cheque.Conta = txt_Conta.Text;
                        Lancamento.Cheque.Cheque = txt_Cheque.Text;
                        Lancamento.Cheque.Situacao = 4;
                        Lancamento.Cheque.Informacao = txt_Info_Cheque.Text;
                        Lancamento.Cheque.Valor = double.Parse(txt_Valor.Text);

                        Lst_Lancamento.Add(Lancamento);
                        break;
                }
                #endregion

                dg_Pagto_Efetuado.Rows.Clear();

                double SubTotal = 0;

                if (Lst_Lancamento.Count > 0)
                    for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                    {
                        if (Lst_Lancamento[i].Tipo != 0)
                        {
                            dg_Pagto_Efetuado.Rows.Add();
                            dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Pagamento"].Value = Lst_Lancamento[i].Descricao;
                        }

                        switch (Lst_Lancamento[i].Tipo)
                        {
                            case 1://BOLETO      
                            case 2://CARTÃO
                            case 5://CARTEIRA
                            case 6://OUTROS
                            case 4://DINHEIRO
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Debito);
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Vencimento"].Value = Convert.ToDateTime(Lst_Lancamento[i].FluxoCaixa.Emissao);
                                SubTotal += Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Debito);
                                break;

                            case 3://CHEQUE
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].Cheque.Valor);
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Cheque"].Value = Lst_Lancamento[i].Cheque.Cheque;
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Vencimento"].Value = Convert.ToDateTime(Lst_Lancamento[i].Cheque.Vencimento);
                                SubTotal += Convert.ToDouble(Lst_Lancamento[i].Cheque.Valor);
                                break;
                        }
                    }
                ID_Cheque = 0;

                txt_Soma.Text = util_dados.ConfigNumDecimal(SubTotal, 2);

                double aux = Convert.ToDouble(txt_ValorTotal.Text) - SubTotal;

                mk_Vencimento.Text = DateTime.Now.ToString();

                if (aux <= 0)
                {
                    lb_Troco.Text = "TROCO";
                    txt_Diferenca.ForeColor = Color.Red;
                    txt_Diferenca.Text = util_dados.ConfigNumDecimal(aux, 2);
                    bt_Concluido.Focus();
                }
                else
                {
                    lb_Troco.Text = "DIFERENÇA";
                    txt_Diferenca.ForeColor = Color.Black;
                    txt_Valor.Text = util_dados.ConfigNumDecimal(aux, 2);
                    txt_Diferenca.Text = util_dados.ConfigNumDecimal(aux, 2);

                    lstv_Pagamento.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Realiza_Lancamento()
        {
            int ID_Cheque = 0;
            try
            {
                if (Lst_Lancamento.Count > 0)
                    for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                        switch (Lst_Lancamento[i].Tipo)
                        {
                            case 0://LANCAMENTO CHEQUE
                                #region VERIFICA CAIXA QUE ESTA O CHEQUE
                                BLL_Cheque = new BLL_Cheque();
                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                Cheque = new DTO_Cheque();
                                FluxoCaixa = new DTO_FluxoCaixa();
                                Cheque.ID = Lst_Lancamento[i].FluxoCaixa.ID_Cheque;

                                DataTable _DT = new DataTable();
                                _DT = BLL_Cheque.Busca_Resumo(Cheque);

                                int ID_FluxoCaixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_FluxoCaixa"].ToString());
                                int ID_Caixa = int.Parse(_DT.Rows[_DT.Rows.Count - 1]["ID_Caixa"].ToString());

                                FluxoCaixa.ID = ID_FluxoCaixa;
                                FluxoCaixa.Emissao = DateTime.Now;
                                FluxoCaixa.Planejamento = false;
                                FluxoCaixa.Conciliado = true;
                                BLL_FluxoCaixa.Altera_Lancamento_Cheque(FluxoCaixa);
                                #endregion

                                if (ID_Caixa != Lst_Lancamento[i].FluxoCaixa.Caixa)
                                {
                                    FluxoCaixa = new DTO_FluxoCaixa();

                                    FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                    FluxoCaixa.Emissao = Lst_Lancamento[i].FluxoCaixa.Emissao;
                                    FluxoCaixa.Caixa = ID_Caixa;
                                    FluxoCaixa.Documento = Lst_Lancamento[i].FluxoCaixa.Documento;
                                    FluxoCaixa.ID_Conta = Lst_Lancamento[i].FluxoCaixa.ID_Conta;
                                    FluxoCaixa.Credito = 0;
                                    FluxoCaixa.Debito = Lst_Lancamento[i].FluxoCaixa.Credito;
                                    FluxoCaixa.Informacao = util_msg.msg_TranfereCheque + Lst_Lancamento[i].FluxoCaixa.Documento;
                                    FluxoCaixa.Conciliado = true;
                                    FluxoCaixa.ID_Pagamento = Lst_Lancamento[i].FluxoCaixa.ID_Pagamento;
                                    FluxoCaixa.Planejamento = false;
                                    FluxoCaixa.ID_Cheque = Lst_Lancamento[i].FluxoCaixa.ID_Cheque;

                                    BLL_FluxoCaixa.Grava(FluxoCaixa); //DEBITA O CHEQUE DA CONTA Q ELE FOI LANÇADO

                                    FluxoCaixa = new DTO_FluxoCaixa();

                                    FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                    FluxoCaixa.Emissao = Lst_Lancamento[i].FluxoCaixa.Emissao;
                                    FluxoCaixa.Caixa = Lst_Lancamento[i].FluxoCaixa.Caixa;
                                    FluxoCaixa.Documento = Lst_Lancamento[i].FluxoCaixa.Documento;
                                    FluxoCaixa.ID_Conta = Lst_Lancamento[i].FluxoCaixa.ID_Conta;
                                    FluxoCaixa.Credito = Lst_Lancamento[i].FluxoCaixa.Credito;
                                    FluxoCaixa.Debito = 0;
                                    FluxoCaixa.Informacao = util_msg.msg_TranfereCheque + Lst_Lancamento[i].FluxoCaixa.Documento;
                                    FluxoCaixa.Conciliado = true;
                                    FluxoCaixa.ID_Pagamento = Lst_Lancamento[i].FluxoCaixa.ID_Pagamento;
                                    FluxoCaixa.Planejamento = false;
                                    FluxoCaixa.ID_Cheque = Lst_Lancamento[i].FluxoCaixa.ID_Cheque;

                                    BLL_FluxoCaixa.Grava(FluxoCaixa); //CREDITA O CHEQUE NO CAIXA QUE VAI SER LANÇADO
                                }

                                // BLL_FluxoCaixa.Grava(Lst_Lancamento[i].FluxoCaixa);
                                break;

                            case 1://BOLETO
                            case 2://CARTÃO
                            case 4://DINHEIRO
                            case 5://CARTEIRA
                            case 6://OUTROS
                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                FluxoCaixa = new DTO_FluxoCaixa();

                                FluxoCaixa.ID = BLL_FluxoCaixa.Grava(Lst_Lancamento[i].FluxoCaixa);

                                for (int ii = 0; ii <= lst_CPagar.Count - 1; ii++)
                                {
                                    FluxoCaixa.ID_CPagar = lst_CPagar[ii].ID;
                                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                                }
                                break;

                            case 3://CHEQUE
                                int msg = 0;
                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                BLL_Cheque = new BLL_Cheque();
                                FluxoCaixa = new DTO_FluxoCaixa();

                                bool ChequeTerceiro = false;

                                if (Lst_Lancamento[i].Cheque.ID > 0)
                                    ChequeTerceiro = true;

                                if (ChequeTerceiro == false)
                                {
                                    msg = BLL_Cheque.Grava(Lst_Lancamento[i].Cheque);
                                    if (msg == 0)
                                    {
                                        MessageBox.Show(util_msg.msg_Erro, this.Text);
                                        return;
                                    }
                                    Lst_Lancamento[i].FluxoCaixa.Conciliado = false;
                                    ID_Cheque = msg;
                                }
                                else
                                {
                                    BLL_Cheque.Altera_Situacao(Lst_Lancamento[i].Cheque);

                                    Lst_Lancamento[i].FluxoCaixa.Conciliado = true;
                                    ID_Cheque = Lst_Lancamento[i].Cheque.ID;
                                }

                                Lst_Lancamento[i].FluxoCaixa.ID_Cheque = ID_Cheque;

                                if (Lst_Lancamento[i].Cheque.Vencimento.Date <= DateTime.Now.Date)
                                    Lst_Lancamento[i].FluxoCaixa.Planejamento = false;
                                else
                                {
                                    Lst_Lancamento[i].FluxoCaixa.Conciliado = false;
                                    Lst_Lancamento[i].FluxoCaixa.Planejamento = true;
                                }

                                FluxoCaixa.ID = BLL_FluxoCaixa.Grava(Lst_Lancamento[i].FluxoCaixa);

                                for (int ii = 0; ii <= lst_CPagar.Count - 1; ii++)
                                {
                                    FluxoCaixa.ID_CPagar = lst_CPagar[ii].ID;
                                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                                }
                                break;
                        }
                for (int i = 0; i <= lst_CPagar.Count - 1; i++)
                {
                    CPagar = new DTO_CPagar();
                    BLL_CPagar = new BLL_CPagar();

                    CPagar.ID = lst_CPagar[i].ID;
                    CPagar.Situacao = 2;
                    CPagar.DataBaixa = DataBaixa;
                    CPagar.Desconto = lst_CPagar[i].Desconto;
                    CPagar.Acrescimo = lst_CPagar[i].Acrescimo;
                    CPagar.Altera_Registro = 5;

                    BLL_CPagar.Altera(CPagar);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Valida_Dados()
        {
            try
            {
                string msg = string.Empty;

                switch (TipoPagamento)
                {
                    case 1://BOLETO
                    case 2://CARTÃO
                    case 5://CARTEIRA
                    case 6://OUTROS
                    case 4://DINHEIRO
                        break;

                    case 3://CHEQUE
                        if (txt_Cheque.Text.Trim() == string.Empty)
                            msg += "Número Cheque\n";

                        if (txt_Banco.Text.Trim() == string.Empty)
                            msg += "Banco\n";

                        if (txt_Agencia.Text.Trim() == string.Empty)
                            msg += "Agência\n";

                        if (txt_Conta.Text.Trim() == string.Empty)
                            msg += "Conta\n";

                        if (msg != string.Empty)
                            throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        #endregion

        #region FORM
        private void UI_Venda_Lanca_Load(object sender, EventArgs e)
        {
            this.DelegateEnterFocus(this);

            Inicia_Form();
        }

        private void UI_Venda_Lanca_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Concluido == false)
            {
                DialogResult msgbox;
                msgbox = MessageBox.Show(util_msg.msg_ErroLancaPagamento, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void UI_Venda_Lanca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (txt_Banco.Focused == true ||
                txt_Cheque.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }
        #endregion

        #region BUTTON
        private void bt_Adiciona_Click(object sender, EventArgs e)
        {
            try
            {
                Carrega_Lancamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_Concluido_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txt_Diferenca.Text) > 0)
            {
                MessageBox.Show(util_msg.msg_PagamentoIncompleto, this.Text);
                return;
            }

            if (Convert.ToDouble(txt_Diferenca.Text) < 0)
            {
                bool aux = false;

                for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                    if (Lst_Lancamento[i].Tipo == 4)
                        if (Lst_Lancamento[i].FluxoCaixa.Credito <= (Convert.ToDouble(txt_Diferenca.Text) * -1))
                        {
                            MessageBox.Show(util_msg.msg_TrocoInvalido, this.Text);
                            return;
                        }
                        else
                            aux = true;

                for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                    if (Lst_Lancamento[i].Tipo == 3)
                        aux = true;

                if (aux == false)
                {
                    MessageBox.Show(util_msg.msg_TrocoInvalidoDinheiro, this.Text);
                    return;
                }
            }

            Realiza_Lancamento();
            Concluido = true;

            if (Convert.ToDouble(txt_Diferenca.Text) < 0)
            {
                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                FluxoCaixa = new DTO_FluxoCaixa();

                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FluxoCaixa.Emissao = DateTime.Now;
                FluxoCaixa.Caixa = Parametro_Financeiro.ID_Caixa_Principal;
                FluxoCaixa.Documento = string.Empty;
                FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_RectoDiverso;
                FluxoCaixa.Credito = Convert.ToDouble(txt_Diferenca.Text) * -1;
                FluxoCaixa.Debito = 0;
                FluxoCaixa.Informacao = "TROCO - BAIXA CP Nº " + Documento;
                FluxoCaixa.ID_Pagamento = 0;

                FluxoCaixa.Conciliado = true;
                FluxoCaixa.Planejamento = false;

                BLL_FluxoCaixa.Grava(FluxoCaixa);

                MessageBox.Show("TROCO R$ " + txt_Diferenca.Text, this.Text);
            }
            this.Close();
        }

        private void bt_Remover_Click(object sender, EventArgs e)
        {
            dg_Pagto_Efetuado.Rows.Clear();

            Lst_Lancamento = new List<DTO_Lancamento>();

            mk_Vencimento.Text = DateTime.Now.ToString();
            txt_Valor.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(Valor, 2);

            lb_Troco.Text = "DIFERENÇA";
            txt_Diferenca.ForeColor = Color.Black;
            txt_Diferenca.Text = util_dados.ConfigNumDecimal(Valor, 2); ;
            txt_Soma.Text = "0,00";

            Concluido = false;

            lstv_Pagamento.Focus();
        }

        private void bt_PesquisaCheque_Click(object sender, EventArgs e)
        {
            ID_Cheque = 0;

            DataTable _DT = new DataTable();

            UI_Cheque_Consulta frm = new UI_Cheque_Consulta();
            frm.ShowDialog();
            ID_Cheque = frm.ID_Cheque;

            if (ID_Cheque != 0)
            {
                BLL_Cheque = new BLL_Cheque();
                Cheque = new DTO_Cheque();

                Cheque.ID = ID_Cheque;
                Cheque.Tipo = 2;

                _DT = BLL_Cheque.Busca_Resumo(Cheque);

                cb_CaixaBaixa.SelectedValue = Convert.ToInt32(_DT.Rows[0]["ID_Caixa"]);

                _DT = BLL_Cheque.Busca(Cheque);

                txt_Pessoa_Cheque.Text = _DT.Rows[0]["DescricaoPessoa"].ToString();
                txt_Banco.Text = _DT.Rows[0]["Banco"].ToString();
                txt_Agencia.Text = _DT.Rows[0]["Agencia"].ToString();
                txt_Conta.Text = _DT.Rows[0]["Conta"].ToString();
                txt_Cheque.Text = _DT.Rows[0]["Cheque"].ToString();
                txt_Valor.Text = util_dados.ConfigNumDecimal(_DT.Rows[0]["Valor"], 2);
                bt_Adiciona.Focus();
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Valor.Text) == 0)
                txt_Valor.Text = "0";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }
        #endregion

        #region MASKEDBOX
        private void mk_Vencimento_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Vencimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, "Data");
                mk_Vencimento.Text = Convert.ToString(DateTime.Now);
                mk_Vencimento.Focus();
            }
        }

        private void mk_DataCheque_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_DataCheque.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, "Data");
                mk_DataCheque.Text = Convert.ToString(DateTime.Now);
                mk_DataCheque.Focus();
            }
        }
        #endregion

        #region CHECKBOX
        private void ck_Conciliado_Enter(object sender, EventArgs e)
        {
            lb_Conciliado.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ck_Conciliado_Leave(object sender, EventArgs e)
        {
            lb_Conciliado.BorderStyle = BorderStyle.None;
        }

        private void ck_ChequeTerceiro_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_ChequeTerceiro.Checked == true)
            {
                bt_PesquisaCheque.Enabled = true;
                cb_Banco.Enabled = false;
            }
            else
            {
                bt_PesquisaCheque.Enabled = false;
                cb_Banco.Enabled = true;
            }
        }
        #endregion

        #region LISTVIEW
        private void lstv_Pagamento_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            if (lstv_Pagamento.SelectedItems.Count == 0)
                return;

            Pagamento.ID = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);

            if (Pagamento.ID == 0)
                return;

            DataTable _DT = new DataTable();
            _DT = BLL_Pagamento.Busca(Pagamento);

            Pagamento.Tipo = Convert.ToInt32(_DT.Rows[0]["Tipo"]);

            TipoPagamento = Convert.ToInt32(_DT.Rows[0]["Tipo"]);
            Custo_Procentagem = Convert.ToDouble(_DT.Rows[0]["Porc_Custo"]);
            Dia_Lancamento = Convert.ToInt32(_DT.Rows[0]["Dia_Lancamento"]);

            switch (Pagamento.Tipo)
            {
                case 3:
                    gb_Cheque.Enabled = true;
                    txt_Pessoa_Cheque.Text = Descricao_Pessoa;
                    break;
                default:
                    gb_Cheque.Enabled = false;
                    txt_Pessoa_Cheque.Clear();
                    txt_Agencia.Clear();
                    txt_Banco.Clear();
                    txt_Conta.Clear();
                    txt_Cheque.Clear();
                    txt_Info_Cheque.Clear();
                    break;
            }

            if (TipoPagamento == 1 ||
              TipoPagamento == 2 ||
              TipoPagamento == 4 ||
              TipoPagamento == 5)
                ck_Conciliado.Checked = true;
            else
                ck_Conciliado.Checked = false;
        }
        #endregion

        #region COMBOBOX
        private void cb_Banco_Leave(object sender, EventArgs e)
        {
            DataTable _DT = new DataTable();

            BLL_Banco = new BLL_Banco();
            Banco = new DTO_Banco();

            Banco.ID = Convert.ToInt32(cb_Banco.SelectedValue);

            _DT = BLL_Banco.Busca(Banco);

            if (_DT.Rows.Count == 1)
            {
                txt_Banco.Text = Convert.ToString(_DT.Rows[0]["ID_Banco"]).PadLeft(3, '0');
                txt_Agencia.Text = Convert.ToString(_DT.Rows[0]["Agencia"]);
                txt_Conta.Text = Convert.ToString(_DT.Rows[0]["Conta"]);
                cb_CaixaBaixa.SelectedValue = Convert.ToInt32(_DT.Rows[0]["ID_Caixa"]);
                txt_Pessoa_Cheque.Text = Parametro_Empresa.Razao_Social_Empresa;
                txt_Cheque.Text = "";
                txt_Cheque.Focus();
            }
            else
            {
                txt_Banco.Text = "";
                txt_Agencia.Text = "";
                txt_Conta.Text = "";
                txt_Cheque.Text = "";
                txt_Pessoa_Cheque.Text = "";
            }
        }
        #endregion
    }
}
