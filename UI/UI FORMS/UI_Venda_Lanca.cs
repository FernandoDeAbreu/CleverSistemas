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
    public partial class UI_Venda_Lanca : Form
    {
        public UI_Venda_Lanca()
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
        public bool Finaliza_Venda { get; set; }
        public int ID_Pagamento { get; set; }
        public int ID_Parcelamento { get; set; }
        public bool Faturamento_Personalizado { get; set; }
        public string Faturamento { get; set; }
        public bool  Pagto_Cartao { get; set; }
        #endregion

        #region VARIAVEIS DE CLASSE
        BLL_Pagamento BLL_Pagamento;
        BLL_CReceber BLL_CReceber;
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_Cheque BLL_Cheque;
        BLL_Cartao BLL_Cartao;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;

        int TipoPagamento;
        int Dia_Lancamento;
        double Custo_Procentagem;
        #endregion

        #region ESTRUTURA
        DTO_Pagamento Pagamento;
        List<DTO_Lancamento> Lst_Lancamento;
        DTO_Lancamento Lancamento;
        DTO_CReceber CReceber;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_Cheque Cheque;
        DTO_Cartao Cartao;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "PAGAMENTO";

            Pagto_Cartao = false;

            mk_Vencimento.Text = this.Emissao.ToString();
            txt_Valor.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_Diferenca.Text = util_dados.ConfigNumDecimal(Valor, 2);

            CarregaCB();

            Lst_Lancamento = new List<DTO_Lancamento>();

            Concluido = false;

            lstv_Pagamento.Focus();

            lstv_Pagamento.Items[0].Focused = true;
            lstv_Pagamento.Items[0].Selected = true;

            if (this.ID_Pagamento > 0)
                for (int i = 0; i <= lstv_Pagamento.Items.Count - 1; i++)

                    if (Convert.ToInt32(lstv_Pagamento.Items[i].Text) == this.ID_Pagamento)
                    {
                        lstv_Pagamento.Items[i].Focused = true;
                        lstv_Pagamento.Items[i].Selected = true;

                        if (this.ID_Parcelamento > 0)
                        {
                            try
                            {
                                cb_Parcelamento.SelectedValue = this.ID_Parcelamento;
                            }
                            catch (Exception)
                            {
                                cb_Parcelamento.SelectedIndex = 0;
                            }
                        }
                    }

            if (Faturamento_Personalizado == true)
                MessageBox.Show(util_msg.msg_Faturamento_Personalizado + util_dados.Retorna_Dia_Faturamento(Faturamento).ToShortDateString(), this.Text);
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            Pagamento.FiltraPagamento = true;
            Pagamento.Recebimento = true;

            _DT = BLL_Pagamento.Busca(Pagamento);

            for (int i = 0; i <= _DT.Rows.Count - 1; i++)
            {
                ListViewItem Item = new ListViewItem(_DT.Rows[i]["ID"].ToString());

                Item.SubItems.Add(_DT.Rows[i]["Descricao"].ToString());

                lstv_Pagamento.Items.Add(Item);
            }
        }

        private void Carrega_Parcelamento()
        {
            try
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

                mk_Vencimento.Text = this.Emissao.ToString();

                if (Finaliza_Venda == true)
                    switch (Pagamento.Tipo)
                    {
                        case 3:
                            gb_Cheque.Enabled = true;
                            txt_Pessoa_Cheque.Text = Descricao_Pessoa;
                            break;
                        case 1:
                        case 5:
                        case 6:
                            if (Faturamento_Personalizado == true)
                                mk_Vencimento.Text = util_dados.Retorna_Dia_Faturamento(Faturamento).ToString();
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

                _DT = new DataTable();
                _DT = BLL_Pagamento.Busca_Parc(Pagamento);

                if (_DT.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(_DT.Rows[0]["Personalizado"]) == false)
                    {
                        List<string> Parcelamento = new List<string>();

                        string[] Parcela = _DT.Rows[0]["Parcelamento"].ToString().Split('-');

                        if (Parcela.Length == 2)
                        {
                            int ParcelaMinima = Convert.ToInt32(Parcela[0]);
                            int ParcelaMaxima = Convert.ToInt32(Parcela[1]);

                            for (int i = ParcelaMinima; i <= ParcelaMaxima; i++)
                                Parcelamento.Add(i.ToString() + " X");
                        }
                        else
                            Parcelamento.Add(Parcela[0].ToString() + " X");

                        _DT = util_dados.CarregaComboDinamico(1, Parcelamento);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Parcelamento);
                    }
                    else
                    {
                        util_dados.CarregaCombo(_DT, "Parcelamento", "ID", cb_Parcelamento);
                    }
                }
                else
                {
                    List<string> lst = new List<string> { "0" };
                    _DT = util_dados.CarregaComboDinamico(1, lst);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Parcelamento);
                }

                CalculaParcela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void CalculaParcela()
        {
            try
            {
                double Valor_Total = Convert.ToDouble(txt_Valor.Text);
                double Primeira_Parcela = 0;
                double Restante_Parcela = 0;
                DateTime Data_Inicial = Convert.ToDateTime(mk_Vencimento.Text);

                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();

                DataTable _DT = new DataTable();

                if (lstv_Pagamento.SelectedItems.Count == 0)
                    return;

                Pagamento.ID = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);

                _DT = BLL_Pagamento.Busca_Parc(Pagamento);

                if (_DT.Rows.Count > 0)
                {
                    string[] Parcela;

                    int Qt_Parcela = 0;

                    if (txt_ParcelamentoManual.Text != string.Empty)
                    {
                        Qt_Parcela = Convert.ToInt32(txt_ParcelamentoManual.Text);

                        Restante_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((Valor_Total / Qt_Parcela).ToString(), 2));
                        Primeira_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((((Restante_Parcela * Qt_Parcela) - Valor_Total) - Restante_Parcela) * -1, 2));
                    }
                    else
                    {
                        if (Convert.ToBoolean(_DT.Rows[0]["Personalizado"]) == true)
                        {
                            Parcela = cb_Parcelamento.Text.Split('/');
                            Qt_Parcela = Parcela.Length;

                            Restante_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((Valor_Total / Qt_Parcela).ToString(), 2));
                            Primeira_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((((Restante_Parcela * Qt_Parcela) - Valor_Total) - Restante_Parcela) * -1, 2));
                        }
                        else
                        {
                            Qt_Parcela = util_dados.Verifica_int(cb_Parcelamento.Text.Replace(" X", ""));

                            Restante_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((Valor_Total / Qt_Parcela).ToString(), 2));
                            Primeira_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((((Restante_Parcela * Qt_Parcela) - Valor_Total) - Restante_Parcela) * -1, 2));
                        }
                    }

                    string _Aux = string.Empty;

                    if (Primeira_Parcela == Restante_Parcela)
                    {
                        if (Qt_Parcela == 1)
                            _Aux = "1 X R$ " + util_dados.ConfigNumDecimal(Primeira_Parcela, 2);
                        else
                            _Aux = Qt_Parcela.ToString() + " X R$ " + util_dados.ConfigNumDecimal(Primeira_Parcela, 2);
                    }
                    else
                    {
                        _Aux = "1 X R$ " + util_dados.ConfigNumDecimal(Primeira_Parcela, 2);
                        _Aux += Environment.NewLine;
                        _Aux += (Qt_Parcela - 1).ToString() + " X R$ " + util_dados.ConfigNumDecimal(Restante_Parcela, 2);

                    }

                    txt_Parcela.Text = _Aux;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Carrega_Lancamento()
        {
            try
            {
                double Valor_Total = Convert.ToDouble(txt_Valor.Text);
                double Primeira_Parcela = 0;
                double Restante_Parcela = 0;
                double Porc_Custo = 0;
                DateTime Data_Inicial = Convert.ToDateTime(mk_Vencimento.Text);
                bool Periodo_Personalizado = false;
                int Periodo = 0;
                int Qt_Parcela = 0;
                string[] Parcela = new string[0];

                #region CALCULA PARCELAS
                BLL_Pagamento = new BLL_Pagamento();
                Pagamento = new DTO_Pagamento();

                DataTable _DT = new DataTable();

                if (lstv_Pagamento.SelectedItems.Count == 0)
                    return;

                Pagamento.ID = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);

                _DT = BLL_Pagamento.Busca_Parc(Pagamento);

                if (txt_ParcelamentoManual.Text != string.Empty)
                {
                    Qt_Parcela = Convert.ToInt32(txt_ParcelamentoManual.Text);

                    Periodo = 30;

                    Restante_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((Valor_Total / Qt_Parcela).ToString(), 2));
                    Primeira_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((((Restante_Parcela * Qt_Parcela) - Valor_Total) - Restante_Parcela) * -1, 2));
                }
                else
                {
                    if (_DT.Rows.Count > 0)
                        if (Convert.ToBoolean(_DT.Rows[0]["Personalizado"]) == true)
                        {
                            Parcela = cb_Parcelamento.Text.Split('/');
                            Qt_Parcela = Parcela.Length;

                            Periodo_Personalizado = true;

                            Restante_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((Valor_Total / Qt_Parcela).ToString(), 2));
                            Primeira_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((((Restante_Parcela * Qt_Parcela) - Valor_Total) - Restante_Parcela) * -1, 2));
                        }
                        else
                        {
                            Qt_Parcela = util_dados.Verifica_int(cb_Parcelamento.Text.Replace(" X", ""));

                            Periodo = Convert.ToInt32(_DT.Rows[0]["Periodo"]);

                            Restante_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((Valor_Total / Qt_Parcela).ToString(), 2));
                            Primeira_Parcela = Convert.ToDouble(util_dados.ConfigNumDecimal((((Restante_Parcela * Qt_Parcela) - Valor_Total) - Restante_Parcela) * -1, 2));
                        }
                }
                #endregion

                #region LANÇA PREVIA DE PAGAMENTO
                if (Finaliza_Venda == false)
                    TipoPagamento = 7;

                Valida_Dados();

                switch (TipoPagamento)
                {

                    case 2://CARTÃO
                        Lancamento = new DTO_Lancamento();
                        Lancamento.CReceber = new DTO_CReceber();

                        #region CALCULA DESCONTO
                        Porc_Custo += util_dados.Calcula_Porcentagem(Custo_Procentagem, Convert.ToDouble(txt_Valor.Text));
                        Lancamento.CReceber.Desconto = Porc_Custo;
                        Lancamento.CReceber.Valor = Convert.ToDouble(txt_Valor.Text);
                        #endregion

                        Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                        Lancamento.Tipo = 0;

                        Lancamento.CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Lancamento.CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                        Lancamento.CReceber.TipoPessoa = TipoPessoa;
                        Lancamento.CReceber.ID_Pessoa = ID_Pessoa;
                        Lancamento.CReceber.Descricao = "VENDA Nº " + Documento + " - " + Descricao_Pessoa;
                        Lancamento.CReceber.Acrescimo = 0;
                        Lancamento.CReceber.QuantidadeParcela = 1;
                        Lancamento.CReceber.Vencimento = DateTime.Parse(mk_Vencimento.Text);
                        Lancamento.CReceber.Parcela = 1;
                        Lancamento.CReceber.ID_PrevisaoPagto = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);

                        Lst_Lancamento.Add(Lancamento);

                        for (int i = 0; i <= Qt_Parcela - 1; i++)
                        {
                            Lancamento = new DTO_Lancamento();
                            Lancamento.Cartao = new DTO_Cartao();

                            Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                            Lancamento.Tipo = TipoPagamento;

                            #region CALCULA DESCONTO
                            if (i == 0)
                                Lancamento.Cartao.Valor = Primeira_Parcela;
                            else
                                Lancamento.Cartao.Valor = Restante_Parcela;
                            #endregion

                            #region CALCULA PERIODO DE VENCIMENTO
                            if (Periodo_Personalizado == true)
                                Lancamento.Cartao.Vencimento = Data_Inicial.AddDays(Convert.ToInt32(Parcela[i]));
                            else
                                Lancamento.Cartao.Vencimento = Data_Inicial.AddDays((Periodo * i) + Dia_Lancamento);
                            #endregion

                            Lancamento.Cartao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            Lancamento.Cartao.Emissao = DateTime.Now;
                            Lancamento.Cartao.ID_Pagamento = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);
                            Lancamento.Cartao.QuantidadeParcela = Qt_Parcela;
                            Lancamento.Cartao.Parcela = i + 1;
                            Lancamento.Cartao.Valor_Previsao = Convert.ToDouble(txt_Valor.Text);

                            Lst_Lancamento.Add(Lancamento);
                        }

                        Pagto_Cartao = true;
                        break;

                    case 1://BOLETO
                    case 5://CARTEIRA
                    case 6://OUTROS
                    case 7://FATURA VENDA SEM FINALIZAR
                        for (int i = 0; i <= Qt_Parcela - 1; i++)
                        {
                            Lancamento = new DTO_Lancamento();
                            Lancamento.CReceber = new DTO_CReceber();

                            Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                            Lancamento.Tipo = TipoPagamento;

                            #region CALCULA DESCONTO
                            if (i == 0)
                            {
                                Porc_Custo += util_dados.Calcula_Porcentagem(Custo_Procentagem, Primeira_Parcela);
                                Lancamento.CReceber.Desconto = Porc_Custo;
                                Lancamento.CReceber.Valor = Primeira_Parcela;
                            }
                            else
                            {
                                Porc_Custo += util_dados.Calcula_Porcentagem(Custo_Procentagem, Restante_Parcela);
                                Lancamento.CReceber.Desconto = Porc_Custo;
                                Lancamento.CReceber.Valor = Restante_Parcela;
                            }
                            #endregion

                            #region CALCULA PERIODO DE VENCIMENTO
                            if (Periodo_Personalizado == true)
                                Lancamento.CReceber.Vencimento = Data_Inicial.AddDays(Convert.ToInt32(Parcela[i]));
                            else
                                Lancamento.CReceber.Vencimento = Data_Inicial.AddMonths(i);
                            #endregion

                            Lancamento.CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            Lancamento.CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                            Lancamento.CReceber.TipoPessoa = TipoPessoa;
                            Lancamento.CReceber.ID_Pessoa = ID_Pessoa;
                            Lancamento.CReceber.Descricao = "VENDA Nº " + Documento + " - " + Descricao_Pessoa;

                            Lancamento.CReceber.Acrescimo = 0;
                            Lancamento.CReceber.QuantidadeParcela = Qt_Parcela;

                            Lancamento.CReceber.Parcela = i + 1;
                            Lancamento.CReceber.ID_PrevisaoPagto = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);
                            Lst_Lancamento.Add(Lancamento);
                        }
                        break;

                    case 3://CHEQUE
                        Lancamento = new DTO_Lancamento();
                        Lancamento.CReceber = new DTO_CReceber();

                        #region CALCULA DESCONTO
                        Porc_Custo += util_dados.Calcula_Porcentagem(Custo_Procentagem, Convert.ToDouble(txt_Valor.Text));
                        Lancamento.CReceber.Desconto = Porc_Custo;
                        Lancamento.CReceber.Valor = Convert.ToDouble(txt_Valor.Text);
                        #endregion

                        Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                        Lancamento.Tipo = 0;

                        Lancamento.CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Lancamento.CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                        Lancamento.CReceber.TipoPessoa = TipoPessoa;
                        Lancamento.CReceber.ID_Pessoa = ID_Pessoa;
                        Lancamento.CReceber.Descricao = "VENDA Nº " + Documento + " - " + Descricao_Pessoa;
                        Lancamento.CReceber.Acrescimo = 0;
                        Lancamento.CReceber.QuantidadeParcela = 1;
                        Lancamento.CReceber.Vencimento = DateTime.Parse(mk_Vencimento.Text);
                        Lancamento.CReceber.Parcela = 1;
                        Lancamento.CReceber.ID_PrevisaoPagto = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);

                        Lst_Lancamento.Add(Lancamento);

                        int num_cheque = Convert.ToInt32(txt_Cheque.Text);

                        for (int i = 0; i <= Qt_Parcela - 1; i++)
                        {
                            Lancamento = new DTO_Lancamento();
                            Lancamento.Cheque = new DTO_Cheque();
                            Lancamento.FluxoCaixa = new DTO_FluxoCaixa();

                            Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                            Lancamento.Tipo = TipoPagamento;

                            #region LANÇA VALOR
                            if (i == 0)
                                Lancamento.Cheque.Valor = Primeira_Parcela;
                            else
                                Lancamento.Cheque.Valor = Restante_Parcela;
                            #endregion

                            #region CALCULA PERIODO DE VENCIMENTO
                            if (Periodo_Personalizado == true)
                                Lancamento.Cheque.Vencimento = Data_Inicial.AddDays(Convert.ToInt32(Parcela[i]));
                            else
                                Lancamento.Cheque.Vencimento = Data_Inicial.AddMonths(i);
                            #endregion

                            Lancamento.Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                            Lancamento.Cheque.Tipo = 2;
                            Lancamento.Cheque.TipoPessoa = TipoPessoa;
                            Lancamento.Cheque.ID_Pessoa = ID_Pessoa;
                            Lancamento.Cheque.Documento = Documento;
                            Lancamento.Cheque.Emissao = DateTime.Now;
                            Lancamento.Cheque.Banco = txt_Banco.Text;
                            Lancamento.Cheque.Agencia = txt_Agencia.Text;
                            Lancamento.Cheque.Conta = txt_Conta.Text;
                            Lancamento.Cheque.Cheque = num_cheque.ToString();
                            Lancamento.Cheque.Situacao = 1;
                            Lancamento.Cheque.Informacao = txt_Info_Cheque.Text;

                            Lancamento.FluxoCaixa.ID_Pagamento = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);
                            Lancamento.FluxoCaixa.Caixa = Parametro_Financeiro.ID_Caixa_Principal;

                            Lst_Lancamento.Add(Lancamento);

                            num_cheque = num_cheque + 1;
                        }
                        break;

                    case 4://DINHEIRO
                        if (Lst_Lancamento.Count > 0)
                            for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                                if (Lst_Lancamento[i].Tipo == TipoPagamento)
                                {
                                    Lst_Lancamento[i].FluxoCaixa.Credito = Lst_Lancamento[i].FluxoCaixa.Credito + Convert.ToDouble(txt_Valor.Text);
                                    break;
                                }

                        Lancamento = new DTO_Lancamento();
                        Lancamento.FluxoCaixa = new DTO_FluxoCaixa();

                        Lancamento.Descricao = lstv_Pagamento.FocusedItem.SubItems[1].Text;
                        Lancamento.Tipo = TipoPagamento;

                        Lancamento.FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                        Lancamento.FluxoCaixa.Emissao = DateTime.Now;
                        Lancamento.FluxoCaixa.Caixa = Parametro_Financeiro.ID_Caixa_Principal;
                        Lancamento.FluxoCaixa.Documento = Documento;
                        Lancamento.FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                        Lancamento.FluxoCaixa.Credito = Convert.ToDouble(Convert.ToDouble(txt_Valor.Text));
                        Lancamento.FluxoCaixa.Debito = 0;
                        Lancamento.FluxoCaixa.Informacao = "VENDA Nº " + Documento + " - " + Descricao_Pessoa;
                        Lancamento.FluxoCaixa.Conciliado = true;
                        Lancamento.FluxoCaixa.ID_Pagamento = Convert.ToInt32(lstv_Pagamento.FocusedItem.SubItems[0].Text);
                        Lancamento.FluxoCaixa.Planejamento = false;

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
                            case 2://CARTÃO
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Pagamento"].Value = Lst_Lancamento[i].Descricao + " (" + Lst_Lancamento[i].Cartao.QuantidadeParcela + " X)";
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].Cartao.Valor);
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Vencimento"].Value = Convert.ToDateTime(Lst_Lancamento[i].Cartao.Vencimento);
                                SubTotal += Convert.ToDouble(Lst_Lancamento[i].Cartao.Valor);
                                break;

                            case 1://BOLETO                            
                            case 5://CARTEIRA
                            case 6://OUTROS
                            case 7://FATURA VENDA SEM FINALIZAR
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].CReceber.Valor);
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Vencimento"].Value = Convert.ToDateTime(Lst_Lancamento[i].CReceber.Vencimento);
                                SubTotal += Convert.ToDouble(Lst_Lancamento[i].CReceber.Valor);
                                break;

                            case 3://CHEQUE
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].Cheque.Valor);
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Cheque"].Value = Lst_Lancamento[i].Cheque.Cheque;
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Vencimento"].Value = Convert.ToDateTime(Lst_Lancamento[i].Cheque.Vencimento);
                                SubTotal += Convert.ToDouble(Lst_Lancamento[i].Cheque.Valor);
                                break;

                            case 4://DINHEIRO
                                dg_Pagto_Efetuado.Rows[dg_Pagto_Efetuado.Rows.Count - 1].Cells["col_Valor"].Value = Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Credito);
                                SubTotal += Convert.ToDouble(Lst_Lancamento[i].FluxoCaixa.Credito);
                                break;
                        }
                    }
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
            int obj = 0;
            string msg = string.Empty;

            int ID_CReceber = 0;
            int ID_Cheque = 0;
            try
            {
                if (Lst_Lancamento.Count > 0)
                    for (int i = 0; i <= Lst_Lancamento.Count - 1; i++)
                        switch (Lst_Lancamento[i].Tipo)
                        {
                            case 0://BAIXA CHEQUE, LANCAMENTO FINANCEIRO
                                obj = 0;
                                ID_CReceber = 0;

                                BLL_CReceber = new BLL_CReceber();
                                CReceber = new DTO_CReceber();

                                CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                                CReceber.Situacao = 2;
                                CReceber.Documento = Documento;
                                CReceber.Emissao = Emissao;
                                CReceber.Vencimento = Lst_Lancamento[i].CReceber.Vencimento;
                                CReceber.TipoPessoa = TipoPessoa;
                                CReceber.ID_Pessoa = ID_Pessoa;
                                CReceber.Desconto = Lst_Lancamento[i].CReceber.Desconto;
                                CReceber.Valor = Lst_Lancamento[i].CReceber.Valor;
                                CReceber.QuantidadeParcela = Lst_Lancamento[i].CReceber.QuantidadeParcela;
                                CReceber.Parcela = Lst_Lancamento[i].CReceber.Parcela;
                                CReceber.Descricao = util_msg.msg_LancaVenda + Documento;
                                CReceber.Controle = 0;
                                CReceber.Boleto = false;
                                CReceber.DataBaixa = Lst_Lancamento[i].CReceber.Vencimento;
                                CReceber.ID_Venda = Convert.ToInt32(Documento);
                                CReceber.ID_PrevisaoPagto = Lst_Lancamento[i].CReceber.ID_PrevisaoPagto;

                                obj = BLL_CReceber.Grava(CReceber);
                                if (obj == 0)
                                {
                                    MessageBox.Show(util_msg.msg_Erro + obj, this.Text);
                                    return;
                                }

                                CReceber.ID = obj;
                                CReceber.Altera_Registro = 6;
                                BLL_CReceber.Altera(CReceber);

                                ID_CReceber = obj;
                                break;

                            case 2://CARTÃO
                                obj = 0;
                                msg = string.Empty;
                                ID_Cheque = 0;

                                BLL_Cartao = new BLL_Cartao();
                                Cartao = new DTO_Cartao();

                                Cartao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                Cartao.ID_Pagamento = Lst_Lancamento[i].Cartao.ID_Pagamento;
                                Cartao.Emissao = Lst_Lancamento[i].Cartao.Emissao;
                                Cartao.Vencimento = Lst_Lancamento[i].Cartao.Vencimento;
                                Cartao.Valor = Lst_Lancamento[i].Cartao.Valor;
                                Cartao.QuantidadeParcela = Lst_Lancamento[i].Cartao.QuantidadeParcela;
                                Cartao.Parcela = Lst_Lancamento[i].Cartao.Parcela;
                                Cartao.ID_CReceber = ID_CReceber;

                                obj = BLL_Cartao.Grava(Cartao);
                                if (obj == 0)
                                {
                                    MessageBox.Show(util_msg.msg_Erro + obj, this.Text);
                                    return;
                                }
                                break;

                            case 1://BOLETO                            
                            case 5://CARTEIRA
                            case 6://OUTROS
                            case 7://FATURA VENDA SEM FINALIZAR
                                obj = 0;
                                ID_CReceber = 0;

                                BLL_CReceber = new BLL_CReceber();
                                CReceber = new DTO_CReceber();

                                CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                                CReceber.Situacao = 1;
                                CReceber.Documento = Documento;
                                CReceber.Emissao = Emissao;
                                CReceber.Vencimento = Lst_Lancamento[i].CReceber.Vencimento;
                                CReceber.TipoPessoa = TipoPessoa;
                                CReceber.ID_Pessoa = ID_Pessoa;
                                CReceber.Desconto = Lst_Lancamento[i].CReceber.Desconto;
                                CReceber.Valor = Lst_Lancamento[i].CReceber.Valor;
                                CReceber.QuantidadeParcela = Lst_Lancamento[i].CReceber.QuantidadeParcela;
                                CReceber.Parcela = Lst_Lancamento[i].CReceber.Parcela;
                                CReceber.Descricao = util_msg.msg_LancaVenda + Documento;
                                CReceber.Controle = 0;
                                CReceber.Boleto = false;
                                CReceber.ID_Venda = Convert.ToInt32(Documento);
                                CReceber.ID_PrevisaoPagto = Lst_Lancamento[i].CReceber.ID_PrevisaoPagto;

                                obj = BLL_CReceber.Grava(CReceber);
                                if (obj == 0)
                                {
                                    MessageBox.Show(util_msg.msg_Erro + obj, this.Text);
                                    return;
                                }
                                break;

                            case 3://CHEQUE
                                obj = 0;
                                msg = string.Empty;
                                ID_Cheque = 0;

                                BLL_Cheque = new BLL_Cheque();
                                Cheque = new DTO_Cheque();

                                Cheque.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                Cheque.Tipo = 2;
                                Cheque.TipoPessoa = TipoPessoa;
                                Cheque.ID_Pessoa = ID_Pessoa;
                                Cheque.Documento = Documento;
                                Cheque.Emissao = Emissao;
                                Cheque.Vencimento = Lst_Lancamento[i].Cheque.Vencimento;
                                Cheque.Banco = Lst_Lancamento[i].Cheque.Banco;
                                Cheque.Agencia = Lst_Lancamento[i].Cheque.Agencia;
                                Cheque.Conta = Lst_Lancamento[i].Cheque.Conta;
                                Cheque.Cheque = Lst_Lancamento[i].Cheque.Cheque;
                                Cheque.Informacao = util_msg.msg_LancaVenda + Documento + " (" + Lst_Lancamento[i].Cheque.Informacao + ")";
                                Cheque.Valor = Lst_Lancamento[i].Cheque.Valor;

                                Cheque.Situacao = 1;

                                obj = BLL_Cheque.Grava(Cheque);
                                if (obj == 0)
                                {
                                    MessageBox.Show(util_msg.msg_Erro + obj, this.Text);
                                    return;
                                }

                                ID_Cheque = obj;

                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                FluxoCaixa = new DTO_FluxoCaixa();

                                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                FluxoCaixa.Emissao = Lst_Lancamento[i].Cheque.Vencimento;
                                FluxoCaixa.Caixa = Parametro_Financeiro.ID_Caixa_Principal;
                                FluxoCaixa.Documento = Documento;
                                FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                                FluxoCaixa.Credito = Lst_Lancamento[i].Cheque.Valor;
                                FluxoCaixa.Debito = 0;
                                FluxoCaixa.Informacao = util_msg.msg_LancaVenda + Documento + " " + util_msg.msg_LancaCheque + Lst_Lancamento[i].Cheque.Cheque;
                                FluxoCaixa.ID_Cheque = ID_Cheque;
                                FluxoCaixa.ID_Pagamento = Lst_Lancamento[i].FluxoCaixa.ID_Pagamento;

                                if (Lst_Lancamento[i].Cheque.Vencimento.Date.Subtract(DateTime.Now.Date).Days <= Dia_Lancamento)
                                {
                                    FluxoCaixa.Conciliado = false;
                                    FluxoCaixa.Planejamento = false;
                                }
                                else
                                {
                                    FluxoCaixa.Conciliado = false;
                                    FluxoCaixa.Planejamento = true;
                                }

                                FluxoCaixa.ID_CReceber = ID_CReceber;
                                FluxoCaixa.ID_CPagar = 0;

                                FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

                                BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                                break;

                            case 4://DINHEIRO
                                obj = 0;
                                msg = string.Empty;

                                BLL_CReceber = new BLL_CReceber();
                                CReceber = new DTO_CReceber();

                                CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                CReceber.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                                CReceber.Situacao = 2;
                                CReceber.Documento = Documento;
                                CReceber.Emissao = Emissao;
                                CReceber.Vencimento = Lst_Lancamento[i].FluxoCaixa.Emissao;
                                CReceber.TipoPessoa = TipoPessoa;
                                CReceber.ID_Pessoa = ID_Pessoa;
                                CReceber.Desconto = 0;

                                double Diferenca = Convert.ToDouble(txt_Diferenca.Text);

                                if (Diferenca < 0)
                                    CReceber.Valor = Lst_Lancamento[i].FluxoCaixa.Credito + Diferenca;
                                else
                                    CReceber.Valor = Lst_Lancamento[i].FluxoCaixa.Credito;

                                CReceber.QuantidadeParcela = 1;
                                CReceber.Parcela = 1;
                                CReceber.Descricao = util_msg.msg_LancaVenda + Documento;
                                CReceber.Controle = 0;
                                CReceber.DataBaixa = Lst_Lancamento[i].FluxoCaixa.Emissao;
                                CReceber.Boleto = false;
                                CReceber.ID_Venda = Convert.ToInt32(Documento);
                                CReceber.ID_PrevisaoPagto = Lst_Lancamento[i].FluxoCaixa.ID_Pagamento;

                                obj = BLL_CReceber.Grava(CReceber);

                                CReceber.Altera_Registro = 5;
                                BLL_CReceber.Altera(CReceber);

                                if (obj == 0)
                                {
                                    MessageBox.Show(util_msg.msg_Erro + obj, this.Text);
                                    return;
                                }
                                int _CReceber = obj;

                                CReceber.ID = obj;
                                CReceber.Altera_Registro = 6;
                                BLL_CReceber.Altera(CReceber);

                                obj = 0;

                                BLL_FluxoCaixa = new BLL_FluxoCaixa();
                                FluxoCaixa = new DTO_FluxoCaixa();

                                FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                                FluxoCaixa.Emissao = Lst_Lancamento[i].FluxoCaixa.Emissao;
                                FluxoCaixa.Caixa = Parametro_Financeiro.ID_Caixa_Principal;
                                FluxoCaixa.Documento = Documento;
                                FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_FatVenda;
                                FluxoCaixa.Credito = Lst_Lancamento[i].FluxoCaixa.Credito;
                                FluxoCaixa.Debito = 0;
                                FluxoCaixa.Informacao = util_msg.msg_LancaVenda + Documento;
                                FluxoCaixa.Conciliado = true;
                                FluxoCaixa.Planejamento = false;
                                FluxoCaixa.ID_CReceber = _CReceber;
                                FluxoCaixa.ID_CPagar = 0;
                                FluxoCaixa.ID_Pagamento = Lst_Lancamento[i].FluxoCaixa.ID_Pagamento;

                                FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);
                                BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
                                break;
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

        #region COMBOBOX
        private void cb_Parcelamento_SelectedValueChanged(object sender, EventArgs e)
        {
            int aux = util_dados.Verifica_int(cb_Parcelamento.SelectedValue.ToString());
            if (aux == 0)
                return;

            CalculaParcela();
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
                FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_PagtoDiverso;
                FluxoCaixa.Credito = 0;
                FluxoCaixa.Debito = Convert.ToDouble(txt_Diferenca.Text) * -1;
                FluxoCaixa.Informacao = "TROCO - VENDA Nº " + Documento;
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

            Pagto_Cartao = false;

            Lst_Lancamento = new List<DTO_Lancamento>();

            mk_Vencimento.Text = DateTime.Now.ToString();
            txt_Valor.Text = util_dados.ConfigNumDecimal(Valor, 2);
            txt_ValorTotal.Text = util_dados.ConfigNumDecimal(Valor, 2);

            lb_Troco.Text = "Diferença";
            txt_Diferenca.ForeColor = Color.Black;
            txt_Diferenca.Text = util_dados.ConfigNumDecimal(Valor, 2); ;
            txt_Soma.Text = "0,00";

            Concluido = false;

            lstv_Pagamento.Focus();
        }
        #endregion

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Valor.Text) == 0)
                txt_Valor.Text = "0";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);

            CalculaParcela();
        }

        private void txt_ParcelamentoManual_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ParcelamentoManual.Text) == 0)
                txt_ParcelamentoManual.Clear();

            CalculaParcela();
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


            CalculaParcela();
        }
        #endregion

        #region LISTVIEW
        private void lstv_Pagamento_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Carrega_Parcelamento();
        }
        #endregion
    }
}
