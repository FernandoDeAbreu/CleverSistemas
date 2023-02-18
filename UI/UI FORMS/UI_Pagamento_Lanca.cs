using System;
using System.Collections.Generic;
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
    public partial class UI_Pagamento_Lanca : Form
    {
        public UI_Pagamento_Lanca()
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
        public double Desconto { get; set; }
        public double Acrescimo { get; set; }
        public List<DTO_CPagar> lst_CPagar { get; set; }
        public bool Concluido { get; set; }
        public string Informacao { get; set; }
        #endregion

        #region VARIAVEIS DE CLASSE
        BLL_Grupo_Simples BLL_Grupo_Simples;
        BLL_Cheque BLL_Cheque;
        BLL_Pagamento BLL_Pagamento;
        BLL_CPagar BLL_CPagar;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_Banco BLL_Banco;
        #endregion

        #region VARIAVEIS DIVERSAS
        DTO_Pagamento Pagamento;

        DataRow DR;

        string obj;

        int TipoPagamento;
        int Dia_Pagto;
        int ID_Cheque;

        double Custo_Procentagem;
        double Custo_Valor;
        #endregion

        #region ESTRUTURA
        DTO_Grupo_Simples Grupo_Simples;
        DTO_Cheque Cheque;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_CPagar CPagar;
        DTO_Lancamento Lancamento;
        DTO_Banco Banco;
        List<DTO_Lancamento> Lst_Lancamento;

        #endregion

        #region ROTINAS
        private void Carrega_CB()
        {
            DataTable _DT = new DataTable();
            BLL_Grupo_Simples = new BLL_Grupo_Simples();
            Grupo_Simples = new DTO_Grupo_Simples();

            Grupo_Simples.Tipo = 9;

            _DT = BLL_Grupo_Simples.Busca(Grupo_Simples);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_CaixaBaixa);
            if (_DT.Rows.Count > 0)
                cb_CaixaBaixa.SelectedIndex = 0;

            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            _DT = new DataTable();

            Pagamento.FiltraPagamento = true;
            Pagamento.Pagamento = true;

            _DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Pagamento);

            BLL_Banco = new BLL_Banco();
            Banco = new DTO_Banco();

            _DT = new DataTable();
            _DT = BLL_Banco.Busca(Banco);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Banco);
        }

        private void SelectText_Enter(object sender, System.EventArgs e)
        {
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
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocus(ctrlChild);
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
                    case 4://DINHEIRO
                    case 5://CARTEIRA
                    case 6://OUTROS
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

        private void Carrega_Lancamento()
        {
            #region CONTA LANCAMENTO
            int Conta_Lancamento;

            if (lst_CPagar.Count == 1)
                Conta_Lancamento = lst_CPagar[0].ID_Conta;
            else
                Conta_Lancamento = Parametro_Financeiro.ID_Conta_PagtoDiverso;
            #endregion

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

                    Lancamento.Descricao = cb_Pagamento.Text;
                    Lancamento.Tipo = TipoPagamento;

                    Lancamento.FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Lancamento.FluxoCaixa.Emissao = DateTime.Parse(mk_Baixa.Text);
                    Lancamento.FluxoCaixa.Caixa = (int)cb_CaixaBaixa.SelectedValue;
                    Lancamento.FluxoCaixa.Documento = Documento;
                    Lancamento.FluxoCaixa.ID_Conta = Conta_Lancamento;
                    Lancamento.FluxoCaixa.Credito = 0;
                    Lancamento.FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                    Lancamento.FluxoCaixa.Informacao = "PAGTO " + cb_Pagamento.Text;
                    Lancamento.FluxoCaixa.Conciliado = (bool)ck_Conciliado.Checked;
                    Lancamento.FluxoCaixa.ID_Pagamento = (int)cb_Pagamento.SelectedValue;
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
                        Lancamento.FluxoCaixa.Emissao = DateTime.Parse(mk_Baixa.Text);
                        Lancamento.FluxoCaixa.Caixa = (int)cb_CaixaBaixa.SelectedValue;
                        Lancamento.FluxoCaixa.Documento = txt_Cheque.Text;
                        Lancamento.FluxoCaixa.ID_Conta = Conta_Lancamento;
                        Lancamento.FluxoCaixa.Credito = double.Parse(txt_Valor.Text);
                        Lancamento.FluxoCaixa.Debito = 0;
                        Lancamento.FluxoCaixa.Informacao = util_msg.msg_LancaCheque + txt_Cheque.Text;
                        Lancamento.FluxoCaixa.Conciliado = true;
                        Lancamento.FluxoCaixa.ID_Pagamento = (int)cb_Pagamento.SelectedValue;
                        Lancamento.FluxoCaixa.Planejamento = false;
                        Lancamento.FluxoCaixa.ID_Cheque = ID_Cheque;

                        Lst_Lancamento.Add(Lancamento);
                    }

                    Lancamento = new DTO_Lancamento();
                    Lancamento.FluxoCaixa = new DTO_FluxoCaixa();

                    Lancamento.Descricao = cb_Pagamento.Text;
                    Lancamento.Tipo = TipoPagamento;

                    Lancamento.FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Lancamento.FluxoCaixa.Emissao = DateTime.Parse(mk_Baixa.Text);
                    Lancamento.FluxoCaixa.Caixa = (int)cb_CaixaBaixa.SelectedValue;
                    Lancamento.FluxoCaixa.Documento = Documento;
                    Lancamento.FluxoCaixa.ID_Conta = Conta_Lancamento;
                    Lancamento.FluxoCaixa.Credito = 0;
                    Lancamento.FluxoCaixa.Debito = double.Parse(txt_Valor.Text);
                    Lancamento.FluxoCaixa.Informacao = util_msg.msg_LancaCheque + txt_Cheque.Text;
                    Lancamento.FluxoCaixa.Conciliado = (bool)ck_Conciliado.Checked;
                    Lancamento.FluxoCaixa.ID_Pagamento = (int)cb_Pagamento.SelectedValue;
                    Lancamento.FluxoCaixa.Planejamento = false;
                    Lancamento.FluxoCaixa.ID_Cheque = ID_Cheque;

                    //Lst_Lancamento.Add(Lancamento);

                    //Lancamento = new DTO_Lancamento();
                    Lancamento.Cheque = new DTO_Cheque();

                    Lancamento.Descricao = cb_Pagamento.Text;
                    Lancamento.Tipo = TipoPagamento;

                    Lancamento.Cheque.ID = ID_Cheque;
                    Lancamento.Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Lancamento.Cheque.Tipo = 1;
                    Lancamento.Cheque.TipoPessoa = 2;
                    Lancamento.Cheque.ID_Pessoa = Parametro_Empresa.ID_Empresa_Ativa;
                    Lancamento.Cheque.Documento = Documento;
                    Lancamento.Cheque.Emissao = DateTime.Now;
                    Lancamento.Cheque.Vencimento = DateTime.Parse(mk_Baixa.Text);
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

            dg_Pagamento.Rows.Clear();

            double SubTotal = 0;

            if (Lst_Lancamento.Count > 0)
                for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                {
                    if (Lst_Lancamento[i].Tipo != 0)
                    {
                        dg_Pagamento.Rows.Add();
                        dg_Pagamento.Rows[dg_Pagamento.Rows.Count - 1].Cells["col_Pagamento"].Value = Lst_Lancamento[i].Descricao;
                    }

                    switch (Lst_Lancamento[i].Tipo)
                    {
                        case 1://BOLETO
                        case 2://CARTÃO
                        case 4://DINHEIRO
                        case 5://CARTEIRA
                        case 6://OUTROS
                            dg_Pagamento.Rows[dg_Pagamento.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Debito);
                            SubTotal += Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Debito);
                            break;

                        case 3://CHEQUE
                            dg_Pagamento.Rows[dg_Pagamento.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Debito);
                            dg_Pagamento.Rows[dg_Pagamento.Rows.Count - 1].Cells["col_Cheque"].Value = Lst_Lancamento[i].Cheque.Cheque;
                            dg_Pagamento.Rows[dg_Pagamento.Rows.Count - 1].Cells["col_Vencimento"].Value = Convert.ToDateTime(Lst_Lancamento[i].Cheque.Vencimento);
                            SubTotal += Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Debito);
                            break;
                    }
                }
            txt_Soma.Text = util_dados.ConfigNumDecimal(SubTotal, 2);

            double aux = Convert.ToDouble(txt_ValorTotal.Text) - SubTotal;

            if (aux <= 0)
            {
                lb_Troco.Text = "Troco";
                txt_Diferenca.ForeColor = Color.Red;
                txt_Valor.Text = util_dados.ConfigNumDecimal(0, 2);
                txt_Diferenca.Text = util_dados.ConfigNumDecimal(aux, 2);
                bt_Concluido.Focus();
            }
            else
            {
                lb_Troco.Text = "Diferença";
                txt_Diferenca.ForeColor = Color.Black;
                txt_Valor.Text = util_dados.ConfigNumDecimal(aux, 2);
                txt_Diferenca.Text = util_dados.ConfigNumDecimal(aux, 2);
                cb_Pagamento.Focus();
            }
            ID_Cheque = 0;
        }

        private void Realiza_Lancamento()
        {
            string obj = string.Empty;
            int ID_Cheque = 0;
            try
            {
                if (Lst_Lancamento.Count > 0)
                    for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                        switch (Lst_Lancamento[i].Tipo)
                        {
                            case 0://LANCAMENTO CHEQUE
                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                FluxoCaixa = new DTO_FluxoCaixa();

                                obj = BLL_FluxoCaixa.Grava(Lst_Lancamento[i].FluxoCaixa);
                                break;

                            case 1://BOLETO
                            case 2://CARTÃO
                            case 4://DINHEIRO
                            case 5://CARTEIRA
                            case 6://OUTROS
                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                FluxoCaixa = new DTO_FluxoCaixa();

                                obj = BLL_FluxoCaixa.Grava(Lst_Lancamento[i].FluxoCaixa);

                                if (obj.IndexOf("Salvo") != -1)
                                    FluxoCaixa.ID = Convert.ToInt32(obj.Substring(34));

                                for (int ii = 0; ii <= lst_CPagar.Count - 1; ii++)
                                {
                                    FluxoCaixa.ID_CPagar = lst_CPagar[ii].ID;
                                    BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                                }
                                break;

                            case 3://CHEQUE
                                obj = string.Empty;
                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                BLL_Cheque = new BLL_Cheque();
                                FluxoCaixa = new DTO_FluxoCaixa();

                                obj = BLL_Cheque.Grava(Lst_Lancamento[i].Cheque);
                                if (obj.IndexOf("Salvo") == -1 &&
                                    obj.IndexOf("Sucesso") == -1)
                                {
                                    MessageBox.Show(util_msg.msg_Erro + obj, this.Text);
                                    return;
                                }

                                if (Lst_Lancamento[i].Cheque.ID == 0)
                                    ID_Cheque = Convert.ToInt32(obj.Substring(34));
                                else
                                    ID_Cheque = Lst_Lancamento[i].Cheque.ID;

                                obj = string.Empty;

                                Lst_Lancamento[i].FluxoCaixa.ID_Cheque = ID_Cheque;

                                if (Lst_Lancamento[i].Cheque.Vencimento.Date <= DateTime.Now.Date)
                                {
                                    Lst_Lancamento[i].FluxoCaixa.Conciliado = true;
                                    Lst_Lancamento[i].FluxoCaixa.Planejamento = false;
                                }
                                else
                                {
                                    Lst_Lancamento[i].FluxoCaixa.Conciliado = false;
                                    Lst_Lancamento[i].FluxoCaixa.Planejamento = true;
                                }

                                obj = BLL_FluxoCaixa.Grava(Lst_Lancamento[i].FluxoCaixa);

                                if (obj.IndexOf("Salvo") != -1)
                                    FluxoCaixa.ID = Convert.ToInt32(obj.Substring(34));

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
                    CPagar.DataBaixa = DateTime.Now;
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
        #endregion

        #region FORM
        private void UI_Pagamento_Lanca_Load(object sender, EventArgs e)
        {
            this.DelegateEnterFocus(this);

            mk_Baixa.Text = DateTime.Now.ToString();
            txt_Valor.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(Valor, 2);

            Carrega_CB();

            Lst_Lancamento = new List<DTO_Lancamento>();

            Concluido = false;
        }

        private void UI_Pagamento_Lanca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            //  else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            //Sair();
        }
        #endregion

        #region CHECKBOX
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

        #region BUTTON
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

        private void bt_Concluido_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txt_Diferenca.Text) > 0)
                {
                    MessageBox.Show("Valor inválido!", this.Text);
                    return;
                }

                Realiza_Lancamento();
                Concluido = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

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

        private void bt_Remover_Click(object sender, EventArgs e)
        {
            dg_Pagamento.Rows.Clear();

            Lst_Lancamento = new List<DTO_Lancamento>();

            mk_Baixa.Text = DateTime.Now.ToString();
            txt_Valor.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(Valor, 2);

            lb_Troco.Text = "Diferença";
            txt_Diferenca.ForeColor = Color.Black;
            txt_Diferenca.Text = util_dados.ConfigNumDecimal(Valor, 2); ;
            txt_Soma.Text = "0,00";

            Concluido = false;

            cb_Pagamento.Focus();
        }
        #endregion

        #region COMBOBOX
        private void cb_Pagamento_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int aux = util_dados.Verifica_int(cb_Pagamento.SelectedValue.ToString());
                if (aux == 0)
                    return;

                BLL_Pagamento = new BLL_Pagamento();

                Pagamento = new DTO_Pagamento();

                Pagamento.ID = aux;

                DataTable DT = new DataTable();
                DT = BLL_Pagamento.Busca(Pagamento);

                Pagamento.Tipo = Convert.ToInt32(DT.Rows[0]["Tipo"]);
                TipoPagamento = Convert.ToInt32(DT.Rows[0]["Tipo"]);
                Dia_Pagto = Convert.ToInt32(DT.Rows[0]["Dia_Pagto"]);

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
            }
            catch (Exception)
            {

            }
        }

        private void cb_Banco_Leave(object sender, EventArgs e)
        {

            DataTable _DT = new DataTable();

            BLL_Banco = new BLL_Banco();
            Banco = new DTO_Banco();

            Banco.ID = Convert.ToInt32(cb_Banco.SelectedValue);

            _DT = BLL_Banco.Busca(Banco);

            if (_DT.Rows.Count == 1)
            {
                DR = _DT.Rows[0];
                txt_Banco.Text = Convert.ToString(DR["ID_Banco"]).PadLeft(3, '0');
                txt_Agencia.Text = Convert.ToString(DR["Agencia"]);
                txt_Conta.Text = Convert.ToString(DR["Conta"]);
                cb_CaixaBaixa.SelectedValue = Convert.ToInt32(DR["ID_Caixa"]);
                txt_Pessoa_Cheque.Text = Parametro_Empresa.DescricaoEmpresa;
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

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Valor.Text) == 0)
                txt_Valor.Text = "0";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }
        #endregion
    }
}
