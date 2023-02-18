using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_NFe_Produto : Form
    {
        public UI_NFe_Produto()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        BLL_TabelaValor BLL_TabelaValor;
        BLL_CFOP BLL_CFOP;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DT;

        DataRow DR;

        int ID_Grade;

        string DescricaoGrade;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        DTO_TabelaValor TabelaValor;
        DTO_CFOP CFOP;
        List<DTO_NF_Importacao> _Importacao = new List<DTO_NF_Importacao>();
        #endregion

        #region PROPRIEDADES
        public List<DTO_NF_Itens> lst_Itens { get; set; }
        public bool Edita { get; set; }
        public int _indexEdita { get; set; }

        public int ID_UF { get; set; }
        public int Tipo_NF { get; set; }
        public int Regime_Trib { get; set; }
        public double AliquotaCredito { get; set; }
        public bool ExibeDesconto { get; set; }

        public bool Produto_Novo { get; set; }

        public bool Consumidor_Final { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "ADICIONAR PRODUTO";
            CarregaCB();

            if (lst_Itens == null)
                lst_Itens = new List<DTO_NF_Itens>();

            if (Edita == true)
            {
                cb_ID_Tabela.SelectedValue = lst_Itens[_indexEdita].ID_Tabela;
                cb_ID_Produto.SelectedValue = lst_Itens[_indexEdita].ID_Produto;

                cb_ID_Produto.Focus();

                txt_Quantidade.Text = util_dados.ConfigNumDecimal(lst_Itens[_indexEdita].Quantidade, 3);
                txt_ValorUnitario.Text = util_dados.ConfigNumDecimal(lst_Itens[_indexEdita].ValorUnitario, 2);
                txt_Desconto.Text = util_dados.ConfigNumDecimal(lst_Itens[_indexEdita].Desconto, 2);
                txt_Acrescimo.Text = util_dados.ConfigNumDecimal(lst_Itens[_indexEdita].Acrescimo, 2);
                txt_Frete.Text = util_dados.ConfigNumDecimal(lst_Itens[_indexEdita].Frete, 2);
                txt_Seguro.Text = util_dados.ConfigNumDecimal(lst_Itens[_indexEdita].Seguro, 2);
                txt_InformacaoAdicional.Text = lst_Itens[_indexEdita].InformacaoAdicional;

                SomaItem();

                txt_Quantidade.Focus();
            }
            txt_Quantidade.Text = util_dados.ConfigNumDecimal(1, Parametro_Cadastro.Decimal_Produto_Quantidade);
            txt_ValorUnitario.Text = util_dados.ConfigNumDecimal(0, Parametro_Cadastro.Decimal_Produto_Valor);
            txt_Desconto.Text = util_dados.ConfigNumDecimal(0, Parametro_Cadastro.Decimal_Produto_Valor);
        }

        private void CarregaCB()
        {
            DataTable _DT;

            BLL_TabelaValor = new BLL_TabelaValor();
            TabelaValor = new DTO_TabelaValor();

            _DT = new DataTable();
            _DT = BLL_TabelaValor.Busca(TabelaValor);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Tabela);
            cb_ID_Tabela.SelectedIndex = 0;

            BLL_CFOP = new BLL_CFOP();
            CFOP = new DTO_CFOP();

            CFOP.Busca_CFOP = true;

            _DT = new DataTable();

            _DT = BLL_CFOP.Busca(CFOP);
            util_dados.CarregaCombo(_DT, "Descricao", "CFOP", cb_CFOP);

            #region ICMS
            DataTable _ICMS;

            #region ICMS SIMPLES NACIONAL
            if (Parametro_NFe_NFC_SAT.Regime_Tributario == 1)
            {
                _ICMS = new DataTable();
                _ICMS.Columns.Add("ID");
                _ICMS.Columns.Add("Descricao");

                DR = _ICMS.NewRow();
                DR["ID"] = "101";
                DR["Descricao"] = "101 - Tributada com Permissão de Crédito";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "102";
                DR["Descricao"] = "102 - Tributada sem Permissão de Crédito";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "103";
                DR["Descricao"] = "103 - Isenção do ICMS para faixa de receita bruta";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "201";
                DR["Descricao"] = "201 - Tributada com permissão de crédito e com cobrança do ICMS por Substituição Tributária";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "202";
                DR["Descricao"] = "202 - Tributada sem permissão de crédito e com cobrança do ICMS por substituição Tributária";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "203";
                DR["Descricao"] = "203 - Isenção do ICMS para faixa de receita bruta e com cobrança do ICMS por Substituição Tributária";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "300";
                DR["Descricao"] = "300 - Imune";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "400";
                DR["Descricao"] = "400 - Não Tributada";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "500";
                DR["Descricao"] = "500 - ICMS cobrado anteriormente por substituição tributária ou por antecipação";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "900";
                DR["Descricao"] = "900 - Outros";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                util_dados.CarregaCombo(_ICMS, "Descricao", "ID", cb_CST);
                cb_CST.SelectedIndex = 0;
            }
            #endregion

            #region ICMS REGIME NORMAL
            if (Parametro_NFe_NFC_SAT.Regime_Tributario == 2 ||
                Parametro_NFe_NFC_SAT.Regime_Tributario == 3)
            {
                _ICMS = new DataTable();
                _ICMS.Columns.Add("ID");
                _ICMS.Columns.Add("Descricao");

                DR = _ICMS.NewRow();
                DR["ID"] = "0";
                DR["Descricao"] = "00 - Tributada integralmente";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "10";
                DR["Descricao"] = "10 - Tributada e com cobrança do ICMS por Substituição Tributária";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "20";
                DR["Descricao"] = "20 - Com Redução de Base de Cálculo";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "30";
                DR["Descricao"] = "30 - Isenta ou não Tributada e com Cobrança do ICMS por Substituição Tributária";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "40";
                DR["Descricao"] = "40 - Isenta";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "41";
                DR["Descricao"] = "41 - Não Tributada";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "50";
                DR["Descricao"] = "50 - Suspenção";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "51";
                DR["Descricao"] = "51 - Diferimento";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "60";
                DR["Descricao"] = "60 - ICMS Cobrado Anteriormente por Substituição Tributária";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR["ID"] = "70";
                DR["Descricao"] = "70 - Com redução de Base de Cálculo e Cobrança do ICMS por Substituição Tributária";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                DR = _ICMS.NewRow();
                DR["ID"] = "90";
                DR["Descricao"] = "90 - Outros";
                _ICMS.Rows.Add(DR);
                _ICMS.AcceptChanges();
                DR = _ICMS.NewRow();
                util_dados.CarregaCombo(_ICMS, "Descricao", "ID", cb_CST);
                cb_CST.SelectedValue = 0;
            }
            #endregion
            #endregion

            #region PIS
            DataTable _PIS = new DataTable();
            _PIS.Columns.Add("ID");
            _PIS.Columns.Add("Descricao");

            DR = _PIS.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "01 - Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "02 - Operação Tributável (base de cálculo = valor da operação(alíquota diferenciada))";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "03 - Operação Tributável (base de cálculo = quantidade vendida X alíquota por unidade de produto)";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "4";
            DR["Descricao"] = "04 - Operação Tributável (tributação monofásica (alíquota zero))";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "5";
            DR["Descricao"] = "05 - Operação Tributável (Substituição Tributária)";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "6";
            DR["Descricao"] = "06 - Operação Tributável (alíquota zero)";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "7";
            DR["Descricao"] = "07 - Operação Isenta de Contribuição";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "8";
            DR["Descricao"] = "08 - Operação Sem Incidêndia de Contribuição";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "9";
            DR["Descricao"] = "09 - Operação com Suspensão da Contribuição";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "49";
            DR["Descricao"] = "49 - Outras Operações de Saída";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "50";
            DR["Descricao"] = "50 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "51";
            DR["Descricao"] = "51 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "52";
            DR["Descricao"] = "52 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "53";
            DR["Descricao"] = "53 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não Tributadas no Mercado Interno";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "54";
            DR["Descricao"] = "54 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "55";
            DR["Descricao"] = "55 - Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "56";
            DR["Descricao"] = "56 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não Tributadas no Mercado Interno e de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "60";
            DR["Descricao"] = "60 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "61";
            DR["Descricao"] = "61 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "62";
            DR["Descricao"] = "62 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "63";
            DR["Descricao"] = "63 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Tributada e Não Tributada no Mercado Interno";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "64";
            DR["Descricao"] = "64 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Tributada no Mercado Interno e de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "65";
            DR["Descricao"] = "65 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Não Tributada no Mercado Interno e de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "66";
            DR["Descricao"] = "66 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Tributada e Não Tributada no Mercado Interno e de Exportação";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "67";
            DR["Descricao"] = "67 - Crédito Presumido - Outras Operações";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "70";
            DR["Descricao"] = "70 - Operaçao de Aquisição sem Direito a Crédito";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "71";
            DR["Descricao"] = "71 - Operaçao de Aquisição com Isenção";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "72";
            DR["Descricao"] = "72 - Operaçao de Aquisição com Suspensão";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "73";
            DR["Descricao"] = "73 - Operaçao de Aquisição a Alíquota Zero";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "74";
            DR["Descricao"] = "74 - Operaçao de Aquisição sem Incidência da Contribuição";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "75";
            DR["Descricao"] = "75 - Operaçao de Aquisição por Substituição Tributária";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "98";
            DR["Descricao"] = "98 - Outras Operações de Entrada";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            DR = _PIS.NewRow();
            DR["ID"] = "99";
            DR["Descricao"] = "99 - Outras Operações";
            _PIS.Rows.Add(DR);
            _PIS.AcceptChanges();
            util_dados.CarregaCombo(_PIS, "Descricao", "ID", cb_CSTPIS);
            #endregion

            #region COFINS
            DataTable _COFINS = new DataTable();
            _COFINS.Columns.Add("ID");
            _COFINS.Columns.Add("Descricao");

            DR = _COFINS.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "01 - Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "02 - Operação Tributável (base de cálculo = valor da operação(alíquota diferenciada))";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "03 - Operação Tributável (base de cálculo = quantidade vendida X alíquota por unidade de produto)";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "4";
            DR["Descricao"] = "04 - Operação Tributável (tributação monofásica (alíquota zero))";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "5";
            DR["Descricao"] = "05 - Operação Tributável (Substituição Tributária)";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "6";
            DR["Descricao"] = "06 - Operação Tributável (alíquota zero)";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "7";
            DR["Descricao"] = "07 - Operação Isenta de Contribuição";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "8";
            DR["Descricao"] = "08 - Operação Sem Incidêndia de Contribuição";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "9";
            DR["Descricao"] = "09 - Operação com Suspensão da Contribuição";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "49";
            DR["Descricao"] = "49 - Outras Operações de Saída";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "50";
            DR["Descricao"] = "50 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "51";
            DR["Descricao"] = "51 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "52";
            DR["Descricao"] = "52 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "53";
            DR["Descricao"] = "53 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não Tributadas no Mercado Interno";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "54";
            DR["Descricao"] = "54 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "55";
            DR["Descricao"] = "55 - Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "56";
            DR["Descricao"] = "56 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não Tributadas no Mercado Interno e de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "60";
            DR["Descricao"] = "60 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "61";
            DR["Descricao"] = "61 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "62";
            DR["Descricao"] = "62 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "63";
            DR["Descricao"] = "63 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Tributada e Não Tributada no Mercado Interno";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "64";
            DR["Descricao"] = "64 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Tributada no Mercado Interno e de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "65";
            DR["Descricao"] = "65 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Não Tributada no Mercado Interno e de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "66";
            DR["Descricao"] = "66 - Crédito Presumido - Operação de Aquisição Vinculada a Receita Tributada e Não Tributada no Mercado Interno e de Exportação";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "67";
            DR["Descricao"] = "67 - Crédito Presumido - Outras Operações";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "70";
            DR["Descricao"] = "70 - Operaçao de Aquisição sem Direito a Crédito";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "71";
            DR["Descricao"] = "71 - Operaçao de Aquisição com Isenção";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "72";
            DR["Descricao"] = "72 - Operaçao de Aquisição com Suspensão";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "73";
            DR["Descricao"] = "73 - Operaçao de Aquisição a Alíquota Zero";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "74";
            DR["Descricao"] = "74 - Operaçao de Aquisição sem Incidência da Contribuição";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "75";
            DR["Descricao"] = "75 - Operaçao de Aquisição por Substituição Tributária";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "98";
            DR["Descricao"] = "98 - Outras Operações de Entrada";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            DR = _COFINS.NewRow();
            DR["ID"] = "99";
            DR["Descricao"] = "99 - Outras Operações";
            _COFINS.Rows.Add(DR);
            _COFINS.AcceptChanges();
            util_dados.CarregaCombo(_COFINS, "Descricao", "ID", cb_CSTCOFINS);
            #endregion

            #region ORIGEM
            DataTable _Origem = new DataTable();
            _Origem.Columns.Add("ID");
            _Origem.Columns.Add("Descricao");

            DR = _Origem.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "0 - Nacional - Exceto indicadas no códigos 3, 4, 5 e 8";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "1 - Estrangeira - Importação Direta";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "2 - Estrangeira - Adquirida no Mercado Interno";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "3 - Nacional - com Conteúdo de Importação superior a 40% e inferior ou igual a 70%";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "4";
            DR["Descricao"] = "4 - Nacional - cuja produção tenha sido feita em conformidade";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "5";
            DR["Descricao"] = "5 - Nacional - com Conteúdo de Importação inferior a 40%";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "6";
            DR["Descricao"] = "6 - Estrangeira - Imp. direta, sem similar nacional, na lista da CAMEX";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "7";
            DR["Descricao"] = "7 - Estrangeira - Adq. Interno, sem similar nacional, na lista da CAMEX";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            DR = _Origem.NewRow();
            DR["ID"] = "8";
            DR["Descricao"] = "8 - Nacional - Mercadoria ou bem com Conteúdo de Importação superior a 70%";
            _Origem.Rows.Add(DR);
            _Origem.AcceptChanges();
            util_dados.CarregaCombo(_Origem, "Descricao", "ID", cb_Origem);
            cb_Origem.SelectedValue = 0;
            #endregion

            #region MODALIDADE BASE DE CALCULO
            DataTable _ModalidadeBC = new DataTable();
            _ModalidadeBC.Columns.Add("ID");
            _ModalidadeBC.Columns.Add("Descricao");

            DR = _ModalidadeBC.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "0 - Margem Valor Agregado (%)";
            _ModalidadeBC.Rows.Add(DR);
            _ModalidadeBC.AcceptChanges();
            DR = _ModalidadeBC.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "1 - Pauta (Valor)";
            _ModalidadeBC.Rows.Add(DR);
            _ModalidadeBC.AcceptChanges();
            DR = _ModalidadeBC.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "2 - Preço Tabelado Máximo (Valor)";
            _ModalidadeBC.Rows.Add(DR);
            _ModalidadeBC.AcceptChanges();
            DR = _ModalidadeBC.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "3 - Valor da Operação";
            _ModalidadeBC.Rows.Add(DR);
            _ModalidadeBC.AcceptChanges();
            util_dados.CarregaCombo(_ModalidadeBC, "Descricao", "ID", cb_ModalidadeBC);
            #endregion

            #region MODALIDADE BASE DE CALCULO ST
            DataTable _ModalidadeBCST = new DataTable();
            _ModalidadeBCST.Columns.Add("ID");
            _ModalidadeBCST.Columns.Add("Descricao");

            DR = _ModalidadeBCST.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "0 - Preço Tabelado ou Máximo Sugerido";
            _ModalidadeBCST.Rows.Add(DR);
            _ModalidadeBCST.AcceptChanges();
            DR = _ModalidadeBCST.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "1 - Lista Negativa (Valor)";
            _ModalidadeBCST.Rows.Add(DR);
            _ModalidadeBCST.AcceptChanges();
            DR = _ModalidadeBCST.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "2 - Lista Positiva (Valor)";
            _ModalidadeBCST.Rows.Add(DR);
            _ModalidadeBCST.AcceptChanges();
            DR = _ModalidadeBCST.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "3 - Lista Neutra (Valor)";
            _ModalidadeBCST.Rows.Add(DR);
            _ModalidadeBCST.AcceptChanges();
            DR = _ModalidadeBCST.NewRow();
            DR["ID"] = "4";
            DR["Descricao"] = "4 - Margem Valor Agregado (%)";
            _ModalidadeBCST.Rows.Add(DR);
            _ModalidadeBCST.AcceptChanges();
            DR = _ModalidadeBCST.NewRow();
            DR["ID"] = "5";
            DR["Descricao"] = "5 - Pauta (Valor)";
            _ModalidadeBCST.Rows.Add(DR);
            _ModalidadeBCST.AcceptChanges();
            util_dados.CarregaCombo(_ModalidadeBCST, "Descricao", "ID", cb_ModalidadeBCST);
            #endregion

            #region IPI
            DataTable _IPI = new DataTable();
            _IPI.Columns.Add("ID");
            _IPI.Columns.Add("Descricao");

            DR = _IPI.NewRow();
            DR["ID"] = "0";
            DR["Descricao"] = "00 - Entrada com recuperação de crédito";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "1";
            DR["Descricao"] = "01 - Entrada Tributada com Alíquota zero";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "2";
            DR["Descricao"] = "02 - Entrada Isenta";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "3";
            DR["Descricao"] = "03 - Entrada não-tributada";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "4";
            DR["Descricao"] = "04 - Entrada imune";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "5";
            DR["Descricao"] = "05 - Entrada com suspensão";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "49";
            DR["Descricao"] = "49 - Outras entradas";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "50";
            DR["Descricao"] = "50 - Saída Tributada";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "51";
            DR["Descricao"] = "51 - Saída tributada com alíquota zero";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "52";
            DR["Descricao"] = "52 - Saída isenta";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "53";
            DR["Descricao"] = "53 - Saída não tributada";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "54";
            DR["Descricao"] = "54 - Saída imune";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "55";
            DR["Descricao"] = "55 - Saída com suspensão";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();
            DR = _IPI.NewRow();
            DR["ID"] = "99";
            DR["Descricao"] = "99 - Outras Saídas";
            _IPI.Rows.Add(DR);
            _IPI.AcceptChanges();

            util_dados.CarregaCombo(_IPI, "Descricao", "ID", cb_CSTIPI);
            #endregion
        }

        private void Carrega_MotDesonerado(int _CST)
        {
            DataTable _MotDesonerado;

            switch (_CST)
            {
                case 20:
                    _MotDesonerado = new DataTable();
                    _MotDesonerado.Columns.Add("ID");
                    _MotDesonerado.Columns.Add("Descricao");

                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "3";
                    DR["Descricao"] = "3 - Uso na Agropecuária";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "9";
                    DR["Descricao"] = "9 - Outros";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "12";
                    DR["Descricao"] = "12 - Órgão de Fomento e Desenvolvimento Agropecuário";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();

                    util_dados.CarregaCombo(_MotDesonerado, "Descricao", "ID", cb_MotivoDesonerado);
                    cb_MotivoDesonerado.SelectedIndex = 0;
                    break;

                case 30:
                    _MotDesonerado = new DataTable();
                    _MotDesonerado.Columns.Add("ID");
                    _MotDesonerado.Columns.Add("Descricao");

                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "6";
                    DR["Descricao"] = "6 - Utilitários e Motocicletas da Amazônia Ocidental e Áreas de Livre Comércio";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "7";
                    DR["Descricao"] = "7 - SUFRAMA";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "9";
                    DR["Descricao"] = "9 - Outros";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();

                    util_dados.CarregaCombo(_MotDesonerado, "Descricao", "ID", cb_MotivoDesonerado);
                    cb_MotivoDesonerado.SelectedIndex = 0;
                    break;

                case 40:
                    _MotDesonerado = new DataTable();
                    _MotDesonerado.Columns.Add("ID");
                    _MotDesonerado.Columns.Add("Descricao");

                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "1";
                    DR["Descricao"] = "1 - Táxi";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "3";
                    DR["Descricao"] = "3 - Produtor Agropecuário";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "4";
                    DR["Descricao"] = "4 - Frotista / Locadora";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "5";
                    DR["Descricao"] = "5 - Diplomático / Consular";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "6";
                    DR["Descricao"] = "6 - Utilitários e Motocicletas da Amazônia Ocidental e Áreas de Livre Comércio";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "7";
                    DR["Descricao"] = "7 - SUFRAMA";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "8";
                    DR["Descricao"] = "8 - Venda Orgão Público";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "9";
                    DR["Descricao"] = "9 - Outros";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "10";
                    DR["Descricao"] = "10 - Deficiente Condutor";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "11";
                    DR["Descricao"] = "11 - Deficiente Não Condutor";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();

                    util_dados.CarregaCombo(_MotDesonerado, "Descricao", "ID", cb_MotivoDesonerado);
                    cb_MotivoDesonerado.SelectedIndex = 0;
                    break;

                case 70:
                    _MotDesonerado = new DataTable();
                    _MotDesonerado.Columns.Add("ID");
                    _MotDesonerado.Columns.Add("Descricao");

                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "3";
                    DR["Descricao"] = "3 - Produtor Agropecuário";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "9";
                    DR["Descricao"] = "9 - Outros";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "12";
                    DR["Descricao"] = "12 - Órgão de Fomento e Desenvolvimento Agropecuário";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();

                    util_dados.CarregaCombo(_MotDesonerado, "Descricao", "ID", cb_MotivoDesonerado);
                    cb_MotivoDesonerado.SelectedIndex = 0;
                    break;

                case 90:
                    _MotDesonerado = new DataTable();
                    _MotDesonerado.Columns.Add("ID");
                    _MotDesonerado.Columns.Add("Descricao");

                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "3";
                    DR["Descricao"] = "3 - Produtor Agropecuário";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "9";
                    DR["Descricao"] = "9 - Outros";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();
                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "12";
                    DR["Descricao"] = "12 - Órgão de Fomento e Desenvolvimento Agropecuário";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();

                    util_dados.CarregaCombo(_MotDesonerado, "Descricao", "ID", cb_MotivoDesonerado);
                    cb_MotivoDesonerado.SelectedIndex = 0;
                    break;

                default:
                    _MotDesonerado = new DataTable();
                    _MotDesonerado.Columns.Add("ID");
                    _MotDesonerado.Columns.Add("Descricao");

                    DR = _MotDesonerado.NewRow();
                    DR["ID"] = "0";
                    DR["Descricao"] = "0 - Não se Aplica";
                    _MotDesonerado.Rows.Add(DR);
                    _MotDesonerado.AcceptChanges();

                    util_dados.CarregaCombo(_MotDesonerado, "Descricao", "ID", cb_MotivoDesonerado);
                    cb_MotivoDesonerado.SelectedValue = 0;
                    break;
            }
        }

        private void Busca_Produto(int _ID)
        {
            try
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID = _ID;
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Produto.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);
                Produto.Consulta_Tipo = true;
                Produto.Tipo = "1, 2, 4";
                Produto.ID_UF = ID_UF;
                Produto.Tipo_NF = Tipo_NF;

                DataTable _DT = new DataTable();
                _DT = BLL_Produto.Busca_Valor_Imposto(Produto);

                if (_DT.Rows.Count > 0)
                {
                    txt_ValorUnitario.Text = util_dados.ConfigNumDecimal(_DT.Rows[0]["ValorVenda"], Parametro_Cadastro.Decimal_Produto_Valor);
                    txt_NCM.Text = _DT.Rows[0]["NCM"].ToString();
                }
                CarregaTributacao(_DT);
                SomaItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void CarregaProduto()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();

            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Produto.Consulta_Ativo = true;
            Produto.Ativo = true;
            Produto.Consulta_Tipo = true;
            Produto.Tipo = "1, 3, 4, 5";

            DataTable _DT = new DataTable();
            _DT = BLL_Produto.Busca(Produto);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Produto);
            cb_ID_Produto.SelectedIndex = -1;
        }

        private void CarregaTributacao(DataTable _DT)
        {
            util_dados.LimpaCampos(this, gb_ICMS);
            util_dados.LimpaCampos(this, gb_IPI);
            util_dados.LimpaCampos(this, gb_IPI_Info);
            util_dados.LimpaCampos(this, gb_PIS);
            util_dados.LimpaCampos(this, gb_COFINS);

            if (_DT.Rows.Count == 0)
            {
                MessageBox.Show("Não Existe Imposto Cadastrado Para este Produto!", "NF-e");
                return;
            }

            if (Consumidor_Final == true)
                switch (_DT.Rows[0]["CST"].ToString())
                {
                    case "101":
                        cb_CST.SelectedValue = "102";
                        break;
                    case "201":
                    case "202":
                        cb_CST.SelectedValue = "500";
                        break;
                    case "10":
                    case "70":
                        cb_CST.SelectedValue = "60";
                        break;
                    default:
                        cb_CST.SelectedValue = _DT.Rows[0]["CST"];
                        break;
                }
            else
                cb_CST.SelectedValue = _DT.Rows[0]["CST"];

            cb_Origem.SelectedValue = _DT.Rows[0]["Origem"];
            cb_ModalidadeBC.SelectedValue = _DT.Rows[0]["ModalidadeBC"];
            cb_ModalidadeBCST.SelectedValue = _DT.Rows[0]["ModalidadeBCST"];
            txt_AliquotaICMS.Text = _DT.Rows[0]["AliquotaICMS"].ToString();
            txt_AliquotaICMSST.Text = _DT.Rows[0]["AliquotaICMSST"].ToString();
            txt_PercentualReducao.Text = _DT.Rows[0]["PercentualReducao"].ToString();
            txt_PercentualReducaoST.Text = _DT.Rows[0]["PercentualReducaoST"].ToString();
            txt_MargemVAdicionado.Text = _DT.Rows[0]["MargemVAdicionado"].ToString();

            txt_ClasseEnquadramento.Text = _DT.Rows[0]["ClasseEnquadramento"].ToString();
            txt_CNPJProdutor.Text = _DT.Rows[0]["CNPJProdutor"].ToString();
            txt_EX_TIPI.Text = _DT.Rows[0]["EX_TIPI"].ToString();

            cb_CSTIPI.SelectedValue = _DT.Rows[0]["CSTIPI"];
            txt_AliquotaIPI.Text = _DT.Rows[0]["AliquotaIPI"].ToString();
            txt_Cod_Enquadramento.Text = _DT.Rows[0]["Cod_Enquadramento"].ToString();

            cb_CSTPIS.SelectedValue = _DT.Rows[0]["CSTPIS"];
            txt_AliquotaPIS.Text = _DT.Rows[0]["AliquotaPIS"].ToString();
            txt_AliquotaPISST.Text = _DT.Rows[0]["AliquotaPISST"].ToString();

            cb_CSTCOFINS.SelectedValue = _DT.Rows[0]["CSTCOFINS"];
            txt_AliquotaCOFINS.Text = _DT.Rows[0]["AliquotaCOFINS"].ToString();
            txt_AliquotaCOFINSST.Text = _DT.Rows[0]["AliquotaCOFINSST"].ToString();

            if (Consumidor_Final == true)
                switch (_DT.Rows[0]["CST"].ToString())
                {
                    case "6102":
                        cb_CFOP.SelectedValue = "6108";
                        break;
                    default:
                        cb_CFOP.SelectedValue = _DT.Rows[0]["CFOP"].ToString();
                        break;
                }
            else
                cb_CFOP.SelectedValue = _DT.Rows[0]["CFOP"].ToString();

            txt_ICMSDesonerado.Text = "0,00";
        }

        private void SomaItem()
        {
            try
            {
                double vlr_Produto = Convert.ToDouble(txt_ValorUnitario.Text);
                double vlr_Desconto = Convert.ToDouble(txt_Desconto.Text);
                double vlr_Seguro = Convert.ToDouble(txt_Seguro.Text);
                double vlr_Frete = Convert.ToDouble(txt_Frete.Text);
                double vlr_Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);

                double Quantidade = Convert.ToDouble(txt_Quantidade.Text);

                double vlr_FinalProduto = (vlr_Produto - vlr_Desconto);
                double vlr_TotalProduto = Quantidade * vlr_FinalProduto;

                double vlr_BC = (vlr_TotalProduto + vlr_Seguro + vlr_Frete + vlr_Acrescimo);

                txt_ValorFinal.Text = util_dados.ConfigNumDecimal(vlr_FinalProduto, Parametro_Cadastro.Decimal_Produto_Valor);
                txt_ValorTotal.Text = util_dados.ConfigNumDecimal(vlr_BC, 2);

                txt_BC_COFINS.Text = util_dados.ConfigNumDecimal(vlr_BC, 2);
                txt_BC_IPI.Text = util_dados.ConfigNumDecimal(vlr_BC, 2);
                txt_BC_PIS.Text = util_dados.ConfigNumDecimal(vlr_BC, 2);
                txt_BCICMS.Text = util_dados.ConfigNumDecimal(vlr_BC, 2);
            }
            catch (Exception)
            {
            }
        }

        private void CarregaImportacao()
        {
            dg_Import.Rows.Clear();
            int aux = 0;
            if (_Importacao.Count > 0)
                for (int i = 0; i <= _Importacao.Count - 1; i++)
                {
                    dg_Import.Rows.Add();
                    dg_Import.Rows[aux].Cells["col_ID_Import"].Value = _Importacao[i].ID;
                    dg_Import.Rows[aux].Cells["col_Doc_Import"].Value = _Importacao[i].Documento;
                    dg_Import.Rows[aux].Cells["col_Data_Registro"].Value = _Importacao[i].Data_Registro;
                    dg_Import.Rows[aux].Cells["col_Local_Import"].Value = _Importacao[i].Local;
                    dg_Import.Rows[aux].Cells["col_Data_Desen"].Value = _Importacao[i].Data_Desen;
                    aux++;
                }
        }

        private void Pesquisa_Produto()
        {
            UI_Produto_Consulta frm = new UI_Produto_Consulta();
            frm.ShowDialog();

            if (frm.ID_Produto == 0)
                return;

            cb_ID_Produto.Focus();
            cb_ID_Produto.SelectedValue = frm.ID_Produto;
            txt_ID_Produto.Text = frm.ID_Produto.ToString();

            txt_Quantidade.Focus();
        }

        private void Adicionar_Produto()
        {
            BLL_Produto = new BLL_Produto();
            Produto = new DTO_Produto();
            Produto.ID = Convert.ToInt32(cb_ID_Produto.SelectedValue);
            Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            List<DTO_Produto_Item> lst_Grade = new List<DTO_Produto_Item>();

            DT = BLL_Produto.Busca_Estoque(Produto);
            if (DT == null)
            {
                MessageBox.Show("Estoque Não Cadastrado!");
                return;
            }

            if (DT.Rows.Count == 1)
            {
                DR = DT.Rows[0];
                ID_Grade = Convert.ToInt32(DR["ID_Grade"]);

                if (Convert.ToString(DR["DescricaoGrade"]).ToUpper().Replace("Ú", "U").IndexOf("UNICO") == -1)
                    DescricaoGrade = " - " + Convert.ToString(DR["DescricaoGrade"]);
                else
                    DescricaoGrade = string.Empty;
            }
            else
            {
                bool Altera_Consulta_Grade = false;

                if (Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Quantidade)
                {
                    Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Unico;
                    Altera_Consulta_Grade = true;
                }

                UI_Produto_Consulta_Grade frm = new UI_Produto_Consulta_Grade();
                frm.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
                frm.Descricao = cb_ID_Produto.Text;

                frm.ShowDialog();

                lst_Grade = new List<DTO_Produto_Item>();
                lst_Grade = frm.lst_Produto;

                if (lst_Grade == null)
                {
                    MessageBox.Show("Selecione uma Grade!");
                    return;
                }

                if (Parametro_Venda.Tipo_ConsultaGrade == Consulta_Grade.Unico)
                {
                    ID_Grade = lst_Grade[0].ID_Grade;
                    DescricaoGrade = " - " + lst_Grade[0].DescricaoGrade;
                }

                if (Altera_Consulta_Grade == true)
                    Parametro_Venda.Tipo_ConsultaGrade = Consulta_Grade.Quantidade;
            }

            double BC_ICMS = Convert.ToDouble(txt_BCICMS.Text);

            DTO_NF_Itens _NF_Item = new DTO_NF_Itens();

            if (Edita == true)
                _NF_Item.ID = lst_Itens[_indexEdita].ID;

            _NF_Item.ID_Produto = Convert.ToInt32(cb_ID_Produto.SelectedValue);
            _NF_Item.Quantidade = Convert.ToDouble(txt_Quantidade.Text);
            _NF_Item.ID_Tabela = Convert.ToInt32(cb_ID_Tabela.SelectedValue);

            _NF_Item.Descricao = cb_ID_Produto.Text.ToString() + DescricaoGrade;
            _NF_Item.ID_Grade = ID_Grade;


            if (ExibeDesconto == true)
            {
                _NF_Item.ValorUnitario = Convert.ToDouble(txt_ValorUnitario.Text);
                _NF_Item.ValorTotal = Convert.ToDouble(txt_ValorTotal.Text);
                _NF_Item.Desconto = Convert.ToDouble(txt_Desconto.Text);
            }
            else
            {
                _NF_Item.ValorUnitario = Convert.ToDouble(txt_ValorFinal.Text);
                _NF_Item.ValorTotal = Convert.ToDouble(txt_ValorTotal.Text);
                _NF_Item.Desconto = 0;
            }

            _NF_Item.Acrescimo = Convert.ToDouble(txt_Acrescimo.Text);
            _NF_Item.TipoVendaProduto = 0;
            _NF_Item.Frete = Convert.ToDouble(txt_Frete.Text);
            _NF_Item.Seguro = Convert.ToDouble(txt_Seguro.Text);
            _NF_Item.CFOP = cb_CFOP.SelectedValue.ToString();
            _NF_Item.InformacaoAdicional = txt_InformacaoAdicional.Text;
            _NF_Item.NCM = txt_NCM.Text;

            _NF_Item.Quantidade_Selo = 0; //VERIFICAR ESTA INFORMAÇÃO
            _NF_Item.ClasseEnquadramento = txt_ClasseEnquadramento.Text;
            _NF_Item.CNPJProdutor = txt_CNPJProdutor.Text;
            _NF_Item.Codigo_Selo = txt_Cod_Enquadramento.Text;
            _NF_Item.EX_TIPI = txt_EX_TIPI.Text;

            _NF_Item.CSTIPI = cb_CSTIPI.SelectedValue.ToString();
            _NF_Item.AliquotaIPI = Convert.ToDouble(txt_AliquotaIPI.Text);
            _NF_Item.ValorIPI = Convert.ToDouble(txt_BC_IPI.Text) * (Convert.ToDouble(txt_AliquotaIPI.Text) / 100);

            _NF_Item.IPIDevolvido = Convert.ToDouble(txt_ValorIPIDevolvido.Text);
            _NF_Item.Per_IPIDevolvido = Convert.ToDouble(txt_PercentualDevolvido.Text);

            if (Regime_Trib == 3)
                _NF_Item.CST = cb_CST.SelectedValue.ToString();
            else
                _NF_Item.CSOSN = cb_CST.SelectedValue.ToString();


            _NF_Item.Origem = Convert.ToInt32(cb_Origem.SelectedValue);
            _NF_Item.ModalidadeBC = util_dados.Verifica_int(cb_ModalidadeBC.SelectedValue.ToString());
            _NF_Item.ModalidadeBCST = util_dados.Verifica_int(cb_ModalidadeBCST.SelectedValue.ToString());
            _NF_Item.MotivoDesonerado = util_dados.Verifica_int(cb_MotivoDesonerado.SelectedValue.ToString());

            _NF_Item.AliquotaICMS = Convert.ToDouble(txt_AliquotaICMS.Text);
            _NF_Item.AliquotaICMSST = Convert.ToDouble(txt_AliquotaICMSST.Text);
            _NF_Item.PercentualReducao = Convert.ToDouble(txt_PercentualReducao.Text);
            _NF_Item.PercentualReducaoST = Convert.ToDouble(txt_PercentualReducaoST.Text);
            _NF_Item.MargemVLAdicionado = Convert.ToDouble(txt_MargemVAdicionado.Text);

            if (Regime_Trib == 3)
                #region REGIME NORMAL
                switch (_NF_Item.CST)
                {
                    case "0":
                        _NF_Item.ValorBC = BC_ICMS;
                        _NF_Item.ValorBCST = 0;
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = util_dados.CalculaAliquota(BC_ICMS, Convert.ToDouble(txt_AliquotaICMS.Text));
                        _NF_Item.ValorICMSST = 0;
                        _NF_Item.ValorICMSSTRet = 0;
                        break;
                    case "10":
                        _NF_Item.ValorBC = BC_ICMS;
                        _NF_Item.ValorBCST = util_dados.CalculaBCST(BC_ICMS, Convert.ToDouble(txt_AliquotaICMSST.Text), Convert.ToDouble(txt_MargemVAdicionado.Text), Convert.ToDouble(txt_PercentualReducaoST.Text));
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = util_dados.CalculaAliquota(BC_ICMS, Convert.ToDouble(txt_AliquotaICMS.Text));
                        _NF_Item.ValorICMSST = util_dados.CalculaAliquota(_NF_Item.ValorBCST, Convert.ToDouble(txt_AliquotaICMSST.Text));
                        _NF_Item.ValorICMSSTRet = 0;
                        break;
                    case "20":
                        _NF_Item.ValorBC = util_dados.CalculaBC(BC_ICMS, Convert.ToDouble(txt_PercentualReducao.Text));
                        _NF_Item.ValorBCST = 0;
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = util_dados.CalculaAliquota(_NF_Item.ValorBC, Convert.ToDouble(txt_AliquotaICMS.Text));
                        _NF_Item.ValorICMSST = 0;
                        _NF_Item.ValorICMSSTRet = 0;
                        _NF_Item.ValorICMSDesonerado = Convert.ToDouble(txt_ICMSDesonerado.Text);
                        break;
                    case "30":
                        _NF_Item.ValorBC = 0;
                        _NF_Item.ValorBCST = util_dados.CalculaBCST(BC_ICMS, Convert.ToDouble(txt_AliquotaICMSST.Text), Convert.ToDouble(txt_MargemVAdicionado.Text), Convert.ToDouble(txt_PercentualReducaoST.Text));
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = 0;
                        _NF_Item.ValorICMSST = util_dados.CalculaAliquota(_NF_Item.ValorBCST, Convert.ToDouble(txt_AliquotaICMSST.Text));
                        _NF_Item.ValorICMSSTRet = 0;
                        _NF_Item.ValorICMSDesonerado = Convert.ToDouble(txt_ICMSDesonerado.Text);
                        break;
                    case "40":
                    case "41":
                    case "50":
                        _NF_Item.ValorBC = 0;
                        _NF_Item.ValorBCST = 0;
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = 0;
                        _NF_Item.ValorICMSST = 0;
                        _NF_Item.ValorICMSSTRet = 0;
                        _NF_Item.ValorICMSDesonerado = Convert.ToDouble(txt_ICMSDesonerado.Text);
                        break;
                    case "51":
                        _NF_Item.ValorBC = 0;  //CONFIGURAR DEPOIS
                        _NF_Item.ValorBCST = 0; //CONFIGURAR DEPOIS
                        _NF_Item.ValorBCSTRet = 0; //CONFIGURAR DEPOIS
                        _NF_Item.ValorICMS = 0; //CONFIGURAR DEPOIS
                        _NF_Item.ValorICMSST = 0; //CONFIGURAR DEPOIS
                        _NF_Item.ValorICMSSTRet = 0; //CONFIGURAR DEPOIS
                        _NF_Item.ValorICMSOperacao = 0; //CONFIGURAR DEPOIS
                        _NF_Item.PercentualDiferimento = 0; //CONFIGURAR DEPOIS
                        _NF_Item.ValorICMSDeferido = 0; //CONFIGURAR DEPOIS
                        break;
                    case "60":
                        _NF_Item.ValorBC = 0;
                        _NF_Item.ValorBCST = 0;
                        _NF_Item.ValorBCSTRet = BC_ICMS;
                        _NF_Item.ValorICMS = 0;
                        _NF_Item.ValorICMSST = 0;
                        _NF_Item.ValorICMSSTRet = util_dados.CalculaAliquota(BC_ICMS, Convert.ToDouble(txt_AliquotaICMS.Text));
                        break;
                    case "70":
                    case "90":
                        _NF_Item.ValorBC = util_dados.CalculaBC(BC_ICMS, Convert.ToDouble(txt_PercentualReducao.Text));
                        _NF_Item.ValorBCST = util_dados.CalculaBCST(BC_ICMS, Convert.ToDouble(txt_AliquotaICMSST.Text), Convert.ToDouble(txt_MargemVAdicionado.Text), Convert.ToDouble(txt_PercentualReducaoST.Text));
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = util_dados.CalculaAliquota(_NF_Item.ValorBC, Convert.ToDouble(txt_AliquotaICMS.Text));
                        _NF_Item.ValorICMSST = util_dados.CalculaAliquota(_NF_Item.ValorBCST, Convert.ToDouble(txt_AliquotaICMSST.Text));
                        _NF_Item.ValorICMSSTRet = 0;
                        _NF_Item.ValorICMSDesonerado = Convert.ToDouble(txt_ICMSDesonerado.Text);
                        break;
                }
            #endregion
            else
                #region SIMPLES NACIONAL
                switch (_NF_Item.CSOSN)
                {
                    case "101":
                        _NF_Item.AliquotaCredito = AliquotaCredito;
                        _NF_Item.ValorCredito = util_dados.CalculaAliquota(BC_ICMS, AliquotaCredito);
                        break;
                    case "102":
                    case "103":
                    case "300":
                    case "400":
                        break;
                    case "201":
                        _NF_Item.AliquotaCredito = Parametro_NFe_NFC_SAT.AliquotaICMS;
                        _NF_Item.ValorCredito = util_dados.CalculaAliquota(BC_ICMS, Parametro_NFe_NFC_SAT.AliquotaICMS);
                        _NF_Item.ValorBC = 0;
                        _NF_Item.ValorBCST = util_dados.CalculaBCST(BC_ICMS, _NF_Item.AliquotaICMSST, _NF_Item.MargemVLAdicionado, _NF_Item.PercentualReducaoST);
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = 0;
                        _NF_Item.ValorICMSST = util_dados.CalculaAliquotaST(BC_ICMS, _NF_Item.ValorBCST, _NF_Item.AliquotaICMS, _NF_Item.AliquotaICMSST);
                        _NF_Item.ValorICMSSTRet = 0;
                        break;
                    case "202":
                    case "203":
                        _NF_Item.ValorBC = 0;
                        _NF_Item.ValorBCST = util_dados.CalculaBCST(BC_ICMS, _NF_Item.AliquotaICMSST, _NF_Item.MargemVLAdicionado, _NF_Item.PercentualReducaoST);
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = 0;
                        _NF_Item.ValorICMSST = util_dados.CalculaAliquotaST(BC_ICMS, _NF_Item.ValorBCST, _NF_Item.AliquotaICMS, _NF_Item.AliquotaICMSST);
                        _NF_Item.ValorICMSSTRet = 0;
                        break;
                    case "500":
                        _NF_Item.ValorBC = 0;
                        _NF_Item.ValorBCST = 0;
                        _NF_Item.ValorBCSTRet = BC_ICMS;
                        _NF_Item.ValorICMS = 0;
                        _NF_Item.ValorICMSST = 0;
                        _NF_Item.ValorICMSSTRet = util_dados.CalculaAliquota(BC_ICMS, Convert.ToDouble(txt_AliquotaICMS.Text));
                        break;
                    case "900":
                        _NF_Item.AliquotaCredito = AliquotaCredito;
                        _NF_Item.AliquotaCredito = util_dados.CalculaAliquota(BC_ICMS, AliquotaCredito);
                        _NF_Item.ValorBC = util_dados.CalculaBC(BC_ICMS, Convert.ToDouble(txt_PercentualReducao.Text));
                        _NF_Item.ValorBCST = util_dados.CalculaBCST(BC_ICMS, _NF_Item.AliquotaICMSST, _NF_Item.MargemVLAdicionado, _NF_Item.PercentualReducaoST);
                        _NF_Item.ValorBCSTRet = 0;
                        _NF_Item.ValorICMS = util_dados.CalculaAliquota(_NF_Item.ValorBC, Convert.ToDouble(txt_AliquotaICMS.Text));
                        _NF_Item.ValorICMSST = util_dados.CalculaAliquotaST(BC_ICMS, _NF_Item.ValorBCST, _NF_Item.AliquotaICMS, _NF_Item.AliquotaICMSST);
                        _NF_Item.ValorICMSSTRet = 0;
                        break;
                }
            #endregion

            _NF_Item.ValorBCII = Convert.ToDouble(txt_ValorBCII.Text);
            _NF_Item.ValorDesII = Convert.ToDouble(txt_DesII.Text);
            _NF_Item.ValorII = Convert.ToDouble(txt_ValorII.Text);
            _NF_Item.ValorIOF = Convert.ToDouble(txt_ValorIOF.Text);

            _NF_Item.CSTPIS = cb_CSTPIS.SelectedValue.ToString();
            _NF_Item.AliquotaPIS = Convert.ToDouble(txt_AliquotaPIS.Text);
            _NF_Item.ValorAliquotaPIS = 0;
            _NF_Item.ValorPIS = util_dados.CalculaAliquota(Convert.ToDouble(txt_BC_PIS.Text), Convert.ToDouble(txt_AliquotaPIS.Text));

            _NF_Item.CSTCOFINS = cb_CSTCOFINS.SelectedValue.ToString();
            _NF_Item.AliquotaCOFINS = Convert.ToDouble(txt_AliquotaCOFINS.Text);
            _NF_Item.ValorAliquotaCOFINS = 0;
            _NF_Item.ValorCOFINS = util_dados.CalculaAliquota(Convert.ToDouble(txt_BC_COFINS.Text), Convert.ToDouble(txt_AliquotaCOFINS.Text));

            if (Edita == true)
                lst_Itens.RemoveAt(_indexEdita);

            lst_Itens.Add(_NF_Item);

            if (Edita == false)
                Produto_Novo = true;

            this.Close();
        }

        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
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
        #endregion

        #region BUTTON
        private void bt_Adiciona_Click(object sender, EventArgs e)
        {
            UI_NFe_Importacao UI_NFe_Importacao = new UI_NFe_Importacao();
            UI_NFe_Importacao.ShowDialog();

            if (UI_NFe_Importacao._Importacao != null)
                _Importacao.Add(UI_NFe_Importacao._Importacao);

            CarregaImportacao();
        }

        private void bt_Concluido_Click(object sender, EventArgs e)
        {
            Adicionar_Produto();
        }

        private void bt_PesquisaProduto_Click(object sender, EventArgs e)
        {
            Pesquisa_Produto();
        }
        #endregion

        #region FORM
        private void UI_NFe_Produto_Load(object sender, EventArgs e)
        {
            this.DelegateEnterFocus(this);

            Inicia_Form();
        }

        private void UI_NFe_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Quantidade.Focused == true ||
                txt_Desconto.Focused == true ||
                txt_Acrescimo.Focused == true ||
                txt_ValorFinal.Focused == true ||
                txt_Seguro.Focused == true ||
                txt_Frete.Focused == true ||
                txt_AliquotaICMS.Focused == true ||
                txt_AliquotaICMSST.Focused == true ||
                txt_PercentualReducao.Focused == true ||
                txt_PercentualReducaoST.Focused == true ||
                txt_MargemVAdicionado.Focused == true ||
                txt_AliquotaIPI.Focused == true ||
                txt_AliquotaPIS.Focused == true ||
                txt_AliquotaPISST.Focused == true ||
                txt_AliquotaCOFINS.Focused == true ||
                txt_AliquotaCOFINSST.Focused == true ||
                txt_ValorUnitario.Focused == true ||
                txt_BCICMS.Focused == true ||
                txt_BC_PIS.Focused == true ||
                txt_BC_IPI.Focused == true ||
                txt_BC_COFINS.Focused == true ||
                txt_ICMSDesonerado.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumDecimal(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Cod_Enquadramento.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void UI_NFe_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
                Pesquisa_Produto();

            if (e.KeyCode == Keys.F5)
                Adicionar_Produto();
        }
        #endregion

        #region COMBOBOX
        private void cb_ID_Tabela_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaProduto();
        }

        private void cb_CST_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_CST.SelectedValue != null &&
                util_dados.Verifica_int(cb_CST.SelectedValue.ToString()) > 0)
                Carrega_MotDesonerado(util_dados.Verifica_int(cb_CST.SelectedValue.ToString()));
        }

        private void cb_ID_Produto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cb_ID_Produto.SelectedValue.GetType() == typeof(int) &&
                    Convert.ToInt32(cb_ID_Produto.SelectedValue) > 0)
                    Busca_Produto(Convert.ToInt32(cb_ID_Produto.SelectedValue));
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_Quantidade_Leave(object sender, EventArgs e)
        {
            txt_Quantidade.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Quantidade.Text), Parametro_Cadastro.Decimal_Produto_Quantidade);

            SomaItem();
        }

        private void txt_ValorUnitario_Leave(object sender, EventArgs e)
        {
            txt_ValorUnitario.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_ValorUnitario.Text), Parametro_Cadastro.Decimal_Produto_Valor);

            SomaItem();
        }

        private void txt_Acrescimo_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Acrescimo.Text) == 0)
                txt_Acrescimo.Text = "0";

            txt_Acrescimo.Text = util_dados.ConfigNumDecimal(txt_Acrescimo.Text, 2);

            SomaItem();
        }

        private void txt_Desconto_Leave(object sender, EventArgs e)
        {
            txt_Desconto.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Desconto.Text), Parametro_Cadastro.Decimal_Produto_Valor);

            SomaItem();
        }

        private void txt_Seguro_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Seguro.Text) == 0)
                txt_Seguro.Text = "0";

            txt_Seguro.Text = util_dados.ConfigNumDecimal(txt_Seguro.Text, 2);

            SomaItem();
        }

        private void txt_Frete_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Frete.Text) == 0)
                txt_Frete.Text = "0";

            txt_Frete.Text = util_dados.ConfigNumDecimal(txt_Frete.Text, 2);

            SomaItem();
        }

        private void txt_AliquotaICMS_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_AliquotaICMS.Text) == 0)
                txt_AliquotaICMS.Text = "0";

            txt_AliquotaICMS.Text = util_dados.ConfigNumDecimal(txt_AliquotaICMS.Text, 2);
        }

        private void txt_AliquotaICMSST_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_AliquotaICMSST.Text) == 0)
                txt_AliquotaICMSST.Text = "0";

            txt_AliquotaICMSST.Text = util_dados.ConfigNumDecimal(txt_AliquotaICMSST.Text, 2);
        }

        private void txt_PercentualReducao_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_PercentualReducao.Text) == 0)
                txt_PercentualReducao.Text = "0";

            txt_PercentualReducao.Text = util_dados.ConfigNumDecimal(txt_PercentualReducao.Text, 2);
        }

        private void txt_PercentualReducaoST_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_PercentualReducaoST.Text) == 0)
                txt_PercentualReducaoST.Text = "0";

            txt_PercentualReducaoST.Text = util_dados.ConfigNumDecimal(txt_PercentualReducaoST.Text, 2);
        }

        private void txt_MargemVAdicionado_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_MargemVAdicionado.Text) == 0)
                txt_MargemVAdicionado.Text = "0";

            txt_MargemVAdicionado.Text = util_dados.ConfigNumDecimal(txt_MargemVAdicionado.Text, 2);
        }

        private void txt_AliquotaIPI_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_AliquotaIPI.Text) == 0)
                txt_AliquotaIPI.Text = "0";

            txt_AliquotaIPI.Text = util_dados.ConfigNumDecimal(txt_AliquotaIPI.Text, 2);
        }

        private void txt_AliquotaPIS_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_AliquotaPIS.Text) == 0)
                txt_AliquotaPIS.Text = "0";

            txt_AliquotaPIS.Text = util_dados.ConfigNumDecimal(txt_AliquotaPIS.Text, 2);
        }

        private void txt_AliquotaPISST_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_AliquotaPISST.Text) == 0)
                txt_AliquotaPISST.Text = "0";

            txt_AliquotaPISST.Text = util_dados.ConfigNumDecimal(txt_AliquotaPISST.Text, 2);
        }

        private void txt_AliquotaCOFINS_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_AliquotaCOFINS.Text) == 0)
                txt_AliquotaCOFINS.Text = "0";

            txt_AliquotaCOFINS.Text = util_dados.ConfigNumDecimal(txt_AliquotaCOFINS.Text, 2);
        }

        private void txt_AliquotaCOFINSST_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_AliquotaCOFINSST.Text) == 0)
                txt_AliquotaCOFINSST.Text = "0";

            txt_AliquotaCOFINSST.Text = util_dados.ConfigNumDecimal(txt_AliquotaCOFINSST.Text, 2);
        }

        private void txt_ValorBCII_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorBCII.Text) == 0)
                txt_ValorBCII.Text = "0";

            txt_ValorBCII.Text = util_dados.ConfigNumDecimal(txt_ValorBCII.Text, 2);
        }

        private void txt_DesII_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_DesII.Text) == 0)
                txt_DesII.Text = "0";

            txt_DesII.Text = util_dados.ConfigNumDecimal(txt_DesII.Text, 2);
        }

        private void txt_ValorII_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorII.Text) == 0)
                txt_ValorII.Text = "0";

            txt_ValorII.Text = util_dados.ConfigNumDecimal(txt_ValorII.Text, 2);
        }

        private void txt_ValorIOF_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorIOF.Text) == 0)
                txt_ValorIOF.Text = "0";

            txt_ValorIOF.Text = util_dados.ConfigNumDecimal(txt_ValorIOF.Text, 2);
        }

        private void txt_ICMSDesonerado_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ICMSDesonerado.Text) == 0)
                txt_ICMSDesonerado.Text = "0";

            txt_ICMSDesonerado.Text = util_dados.ConfigNumDecimal(txt_ICMSDesonerado.Text, 2);
        }

        private void txt_PercentualDevolvido_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_PercentualDevolvido.Text) == 0)
                txt_PercentualDevolvido.Text = "0";

            txt_PercentualDevolvido.Text = util_dados.ConfigNumDecimal(txt_PercentualDevolvido.Text, 2);
        }

        private void txt_ValorIPIDevolvido_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorIPIDevolvido.Text) == 0)
                txt_ValorIPIDevolvido.Text = "0";

            txt_ValorIPIDevolvido.Text = util_dados.ConfigNumDecimal(txt_ValorIPIDevolvido.Text, 2);
        }
        #endregion       
    }
}
