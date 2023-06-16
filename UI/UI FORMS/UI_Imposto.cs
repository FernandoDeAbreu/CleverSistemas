using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_Imposto : Sistema.UI.UI_Modelo
    {
        public UI_Imposto()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_CFOP BLL_CFOP;
        BLL_Imposto BLL_Imposto;
        BLL_NF_TipoEmissao BLL_NF_TipoEmissao;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataRow DR;

        int obj;

        bool Seleciona;

        List<DTO_Tributacao> _lst_Tributacao;
        #endregion

        #region ESTRUTURA
        DTO_CFOP CFOP;
        DTO_Imposto Imposto;
        DTO_NF_TipoEmissao NF_TipoEmissao;
        DTO_Tributacao Tributacao;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "IMPOSTOS E TRIBUTAÇÕES";

            dg_Tributacao.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "DESCRIÇÃO";
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            Carrega_CB();

            Limpa_Campos();
        }

        private void Carrega_CB()
        {
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
                cb_CST.SelectedValue = 0;
            }
            #endregion

            #region ICMS REGIME NORMAL
            if (Parametro_NFe_NFC_SAT.Regime_Tributario == 3)
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

            BLL_CFOP = new BLL_CFOP();
            CFOP = new DTO_CFOP();

            CFOP.Busca_CFOP = true;

            DataTable _DT = new DataTable();
            _DT = BLL_CFOP.Busca(CFOP);
            util_dados.CarregaCombo(_DT, "Descricao", "CFOP", cb_CFOP);

            BLL_NF_TipoEmissao = new BLL_NF_TipoEmissao();
            NF_TipoEmissao = new DTO_NF_TipoEmissao();

            NF_TipoEmissao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            _DT = new DataTable();
            _DT = BLL_NF_TipoEmissao.Busca(NF_TipoEmissao);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo_NF);
        }

        private void ConfiguraFiscal()//VERIFICAR PRA REMOVER
        {
            try
            {
                txt_AliquotaICMS.Text = util_dados.ConfigNumDecimal(txt_AliquotaICMS.Text, 3);
                txt_PercentualReducao.Text = util_dados.ConfigNumDecimal(txt_PercentualReducao.Text, 3);
                txt_AliquotaICMSST.Text = util_dados.ConfigNumDecimal(txt_AliquotaICMSST.Text, 3);
                txt_PercentualReducaoST.Text = util_dados.ConfigNumDecimal(txt_PercentualReducaoST.Text, 3);
                txt_MargemVAdicionado.Text = util_dados.ConfigNumDecimal(txt_MargemVAdicionado.Text, 3);
            }
            catch (Exception)
            {
            }
        }

        private void Carrega_UF(int _ID_Tributacao)
        {
            CheckBox ck;

            try
            {
                BLL_Imposto = new BLL_Imposto();
                Imposto = new DTO_Imposto();

                Imposto.ID_Tributacao = _ID_Tributacao;

                DataTable _DT = new DataTable();

                _DT = BLL_Imposto.Busca_UF(Imposto);

                foreach (Control ctl in gb_UF.Controls)
                {
                    ck = (CheckBox)ctl;
                    ck.Checked = false;
                }

                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    DR = _DT.Rows[i];
                    foreach (Control ctl in gb_UF.Controls)
                    {
                        ck = (CheckBox)ctl;
                        if (ck.Text == DR["Sigla"].ToString())
                            ck.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void Carrega_DG_Tributacao()
        {
            dg_Tributacao.Rows.Clear();

            for (int i = 0; i <= _lst_Tributacao.Count - 1; i++)
            {
                dg_Tributacao.Rows.Add();
                dg_Tributacao.Rows[i].Cells["col_TipoEmissao"].Value = _lst_Tributacao[i].DescricaoTipoEmissao;
                dg_Tributacao.Rows[i].Cells["col_CFOP"].Value = _lst_Tributacao[i].CFOP;
                dg_Tributacao.Rows[i].Cells["col_CSTICMS"].Value = _lst_Tributacao[i].CST;
                dg_Tributacao.Rows[i].Cells["col_AliquotaICMS"].Value = _lst_Tributacao[i].AliquotaICMS;
                dg_Tributacao.Rows[i].Cells["col_CSTIPI"].Value = _lst_Tributacao[i].CSTIPI;
                dg_Tributacao.Rows[i].Cells["col_CSTPIS"].Value = _lst_Tributacao[i].CSTPIS;
                dg_Tributacao.Rows[i].Cells["col_CSTCOFINS"].Value = _lst_Tributacao[i].CSTCOFINS;
            }

            if (dg_Tributacao.Rows.Count > 0)
                Edita_Tributo(dg_Tributacao.CurrentRow.Index);
        }

        private void Carrega_Tributacao(int _ID_Imposto)
        {
            _lst_Tributacao = new List<DTO_Tributacao>();

            BLL_Imposto = new BLL_Imposto();
            Imposto = new DTO_Imposto();

            Imposto.ID = _ID_Imposto;

            DataTable _DT = new DataTable();
            _DT = BLL_Imposto.Busca_Tributacao(Imposto);

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Tributacao = new DTO_Tributacao();

                    Tributacao.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);

                    Tributacao.Tipo_NF = Convert.ToInt32(_DT.Rows[i]["Tipo_NF"]);
                    Tributacao.DescricaoTipoEmissao = _DT.Rows[i]["TipoEmissao"].ToString();
                    Tributacao.CFOP = _DT.Rows[i]["CFOP"].ToString();

                    Tributacao.CST = Convert.ToInt32(_DT.Rows[i]["CST"]);
                    Tributacao.Origem = Convert.ToInt32(_DT.Rows[i]["Origem"]);
                    Tributacao.ModalidadeBC = Convert.ToInt32(_DT.Rows[i]["ModalidadeBC"]);
                    Tributacao.AliquotaICMS = Convert.ToDouble(_DT.Rows[i]["AliquotaICMS"]);
                    Tributacao.PercentualReducao = Convert.ToDouble(_DT.Rows[i]["PercentualReducao"]);
                    Tributacao.ModalidadeBCST = Convert.ToInt32(_DT.Rows[i]["ModalidadeBCST"]);
                    Tributacao.AliquotaICMSST = Convert.ToDouble(_DT.Rows[i]["AliquotaICMSST"]);
                    Tributacao.PercentualReducaoST = Convert.ToDouble(_DT.Rows[i]["PercentualReducaoST"]);
                    Tributacao.MargemVLAdicionado = Convert.ToDouble(_DT.Rows[i]["MargemVAdicionado"]);
                    Tributacao.vICMSDeson = Convert.ToDouble(_DT.Rows[i]["vICMSDeson"]);
                    Tributacao.vICMSOp = Convert.ToDouble(_DT.Rows[i]["vICMSOp"]);
                    Tributacao.pDif = Convert.ToDouble(_DT.Rows[i]["pDif"]);
                    Tributacao.vICMSDif = Convert.ToDouble(_DT.Rows[i]["vICMSDif"]);

                    Tributacao.CSTIPI = Convert.ToInt32(_DT.Rows[i]["CSTIPI"]);
                    Tributacao.AliquotaIPI = Convert.ToDouble(_DT.Rows[i]["AliquotaIPI"]);
                    Tributacao.Cod_Enquadramento = _DT.Rows[i]["Cod_Enquadramento"].ToString();

                    Tributacao.CSTPIS = Convert.ToInt32(_DT.Rows[i]["CSTPIS"]);
                    Tributacao.AliquotaPIS = Convert.ToDouble(_DT.Rows[i]["AliquotaPIS"]);
                    Tributacao.AliquotaPISST = Convert.ToDouble(_DT.Rows[i]["AliquotaPISST"]);

                    Tributacao.CSTCOFINS = Convert.ToInt32(_DT.Rows[i]["CSTCOFINS"]);
                    Tributacao.AliquotaCOFINS = Convert.ToDouble(_DT.Rows[i]["AliquotaCOFINS"]);
                    Tributacao.AliquotaCOFINSST = Convert.ToDouble(_DT.Rows[i]["AliquotaCOFINSST"]);

                    #region BUSCA UF REFERENTE AO TRIBUTO
                    /*
                    DataTable _DT_UF = new DataTable();

                    Imposto.ID_Tributacao = Convert.ToInt32(_DT.Rows[i]["ID"]);

                    _DT_UF = BLL_Imposto.Busca_UF(Imposto);
                    if (_DT_UF.Rows.Count > 0)
                    {
                        Tributacao.lst_UF = new int[_DT_UF.Rows.Count];
                        for(int y = 0; y <= _DT_UF.Rows.Count - 1; y++)
                            Tributacao.lst_UF[i] = Convert.ToInt32(_DT_UF.Rows[y]["ID_UF"]);
                    }
                    */
                    #endregion

                    _lst_Tributacao.Add(Tributacao);
                }

            Carrega_DG_Tributacao();
        }

        private int[] Grava_UF()
        {
            CheckBox ck;
            int aux = 0;

            //FAZ A CONTAGEM DE QUANTOS ESTADOS FORAM SELECIONADOS
            foreach (Control ctl in gb_UF.Controls)
            {
                ck = (CheckBox)ctl;
                if (ck.Checked == true)
                    aux++;
            }

            int[] intUF = new int[aux];

            foreach (Control ctl in gb_UF.Controls)
            {
                ck = (CheckBox)ctl;
                if (ck.Checked == true)
                    #region SELECIONA UF
                    switch (ck.Text)
                    {
                        case "AC":
                            intUF[aux - 1] = 12;
                            aux--;
                            break;
                        case "AL":
                            intUF[aux - 1] = 27;
                            aux--;
                            break;
                        case "AP":
                            intUF[aux - 1] = 16;
                            aux--;
                            break;
                        case "AM":
                            intUF[aux - 1] = 13;
                            aux--;
                            break;
                        case "BA":
                            intUF[aux - 1] = 29;
                            aux--;
                            break;
                        case "CE":
                            intUF[aux - 1] = 23;
                            aux--;
                            break;
                        case "DF":
                            intUF[aux - 1] = 53;
                            aux--;
                            break;
                        case "GO":
                            intUF[aux - 1] = 52;
                            aux--;
                            break;
                        case "ES":
                            intUF[aux - 1] = 32;
                            aux--;
                            break;
                        case "MA":
                            intUF[aux - 1] = 21;
                            aux--;
                            break;
                        case "MT":
                            intUF[aux - 1] = 51;
                            aux--;
                            break;
                        case "MS":
                            intUF[aux - 1] = 50;
                            aux--;
                            break;
                        case "MG":
                            intUF[aux - 1] = 31;
                            aux--;
                            break;
                        case "PA":
                            intUF[aux - 1] = 15;
                            aux--;
                            break;
                        case "PB":
                            intUF[aux - 1] = 25;
                            aux--;
                            break;
                        case "PR":
                            intUF[aux - 1] = 41;
                            aux--;
                            break;
                        case "PE":
                            intUF[aux - 1] = 26;
                            aux--;
                            break;
                        case "PI":
                            intUF[aux - 1] = 22;
                            aux--;
                            break;
                        case "RJ":
                            intUF[aux - 1] = 33;
                            aux--;
                            break;
                        case "RN":
                            intUF[aux - 1] = 24;
                            aux--;
                            break;
                        case "RS":
                            intUF[aux - 1] = 43;
                            aux--;
                            break;
                        case "RO":
                            intUF[aux - 1] = 11;
                            aux--;
                            break;
                        case "RR":
                            intUF[aux - 1] = 14;
                            aux--;
                            break;
                        case "SP":
                            intUF[aux - 1] = 35;
                            aux--;
                            break;
                        case "SC":
                            intUF[aux - 1] = 42;
                            aux--;
                            break;
                        case "SE":
                            intUF[aux - 1] = 28;
                            aux--;
                            break;
                        case "TO":
                            intUF[aux - 1] = 17;
                            aux--;
                            break;
                        case "EX":
                            intUF[aux - 1] = 1;
                            aux--;
                            break;
                    }
                #endregion
            }

            return intUF;
        }

        private void Limpa_Campos()
        {
            _lst_Tributacao = null;

            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_ICMS);
            util_dados.LimpaCampos(this, gb_IPI);
            util_dados.LimpaCampos(this, gb_PIS_COFINS);
            util_dados.LimpaCampos(this, gb_Tributacao);
            util_dados.LimpaCampos(this, gb_UF);

            dg_Tributacao.Rows.Clear();
            DG.DataSource = null;

            cb_CST.SelectedIndex = -1;
            cb_CSTPIS.SelectedIndex = -1;
            cb_CSTIPI.SelectedIndex = -1;
            cb_CSTCOFINS.SelectedIndex = -1;
            cb_ModalidadeBC.SelectedIndex = -1;
            cb_ModalidadeBCST.SelectedIndex = -1;

            txt_AliquotaICMS.Text = "0,00";
            txt_PercentualReducao.Text = "0,00";
            txt_AliquotaICMSST.Text = "0,00";
            txt_PercentualReducaoST.Text = "0,00";
            txt_MargemVAdicionado.Text = "0,00";

            txt_AliquotaPIS.Text = "0,00";
            txt_AliquotaPISST.Text = "0,00";
            txt_AliquotaCOFINS.Text = "0,00";
            txt_AliquotaCOFINSST.Text = "0,00";
            txt_AliquotaIPI.Text = "0,00";
            txt_Cod_Enquadramento.Text = "999";
        }

        private void Limpa_Campos_Parcial()
        {
            util_dados.LimpaCampos(this, gb_ICMS);
            util_dados.LimpaCampos(this, gb_IPI);
            util_dados.LimpaCampos(this, gb_PIS_COFINS);
            util_dados.LimpaCampos(this, gb_Tributacao);
            util_dados.LimpaCampos(this, gb_UF);

            cb_CST.SelectedIndex = -1;
            cb_CSTPIS.SelectedIndex = -1;
            cb_CSTIPI.SelectedIndex = -1;
            cb_CSTCOFINS.SelectedIndex = -1;
            cb_ModalidadeBC.SelectedIndex = -1;
            cb_ModalidadeBCST.SelectedIndex = -1;

            txt_AliquotaICMS.Text = "0,00";
            txt_PercentualReducao.Text = "0,00";
            txt_AliquotaICMSST.Text = "0,00";
            txt_PercentualReducaoST.Text = "0,00";
            txt_MargemVAdicionado.Text = "0,00";

            txt_AliquotaPIS.Text = "0,00";
            txt_AliquotaPISST.Text = "0,00";
            txt_AliquotaCOFINS.Text = "0,00";
            txt_AliquotaCOFINSST.Text = "0,00";
            txt_AliquotaIPI.Text = "0,00";
            txt_Cod_Enquadramento.Text = "999";
        }

        private void Adiciona_Tributo()
        {
            if (_lst_Tributacao == null)
                _lst_Tributacao = new List<DTO_Tributacao>();

            Tributacao = new DTO_Tributacao();

            Tributacao.ID = util_dados.Verifica_int(txt_ID_Tributacao.Text);

            Tributacao.Tipo_NF = Convert.ToInt32(cb_Tipo_NF.SelectedValue);
            Tributacao.DescricaoTipoEmissao = cb_Tipo_NF.Text;
            Tributacao.CFOP = cb_CFOP.SelectedValue.ToString();

            Tributacao.CST = Convert.ToInt32(cb_CST.SelectedValue);
            Tributacao.Origem = Convert.ToInt32(cb_Origem.SelectedValue);
            Tributacao.ModalidadeBC = Convert.ToInt32(cb_ModalidadeBC.SelectedValue);
            Tributacao.AliquotaICMS = Convert.ToDouble(txt_AliquotaICMS.Text);
            Tributacao.PercentualReducao = Convert.ToDouble(txt_PercentualReducao.Text);
            Tributacao.ModalidadeBCST = Convert.ToInt32(cb_ModalidadeBCST.SelectedValue);
            Tributacao.AliquotaICMSST = Convert.ToDouble(txt_AliquotaICMSST.Text);
            Tributacao.PercentualReducaoST = Convert.ToDouble(txt_PercentualReducaoST.Text);
            Tributacao.MargemVLAdicionado = Convert.ToDouble(txt_MargemVAdicionado.Text);
            Tributacao.vICMSDeson = 0;
            Tributacao.vICMSOp = 0;
            Tributacao.pDif = 0;
            Tributacao.vICMSDif = 0;

            Tributacao.CSTIPI = Convert.ToInt32(cb_CSTIPI.SelectedValue);
            Tributacao.AliquotaIPI = Convert.ToDouble(txt_AliquotaIPI.Text);
            Tributacao.Cod_Enquadramento = txt_Cod_Enquadramento.Text;

            Tributacao.CSTPIS = Convert.ToInt32(cb_CSTPIS.SelectedValue);
            Tributacao.AliquotaPIS = Convert.ToDouble(txt_AliquotaPIS.Text);
            Tributacao.AliquotaPISST = Convert.ToDouble(txt_AliquotaPISST.Text);

            Tributacao.CSTCOFINS = Convert.ToInt32(cb_CSTCOFINS.SelectedValue);
            Tributacao.AliquotaCOFINS = Convert.ToDouble(txt_AliquotaCOFINS.Text);
            Tributacao.AliquotaCOFINSST = Convert.ToDouble(txt_AliquotaCOFINSST.Text);

            Tributacao.lst_UF = Grava_UF();

            //VERIFICA SE É NOVO TRIBUTO OU ALTERAÇÃO, CASO SEJA ALTERAÇÃO BUSCA O INDICE, REMOVE E ADICIONA NOVAMENTE
            if (Tributacao.ID > 0)
                for (int i = 0; i <= _lst_Tributacao.Count - 1; i++)
                    if (_lst_Tributacao[i].ID == Tributacao.ID)
                        _lst_Tributacao.RemoveAt(i);

            _lst_Tributacao.Add(Tributacao);

            _lst_Tributacao = _lst_Tributacao.OrderBy(c => c.DescricaoTipoEmissao).ToList();

            Carrega_DG_Tributacao();

            Limpa_Campos_Parcial();
        }

        private void Edita_Tributo(int _aux)
        {
            try
            {
                if (_lst_Tributacao == null)
                    return;

                txt_ID_Tributacao.Text = _lst_Tributacao[_aux].ID.ToString();

                cb_Tipo_NF.SelectedValue = _lst_Tributacao[_aux].Tipo_NF;
                cb_CFOP.SelectedValue = _lst_Tributacao[_aux].CFOP;

                cb_CST.SelectedValue = _lst_Tributacao[_aux].CST;
                cb_Origem.SelectedValue = _lst_Tributacao[_aux].Origem;
                cb_ModalidadeBC.SelectedValue = _lst_Tributacao[_aux].ModalidadeBC;
                txt_AliquotaICMS.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].AliquotaICMS, 2);
                txt_PercentualReducao.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].PercentualReducao, 2);
                cb_ModalidadeBCST.SelectedValue = _lst_Tributacao[_aux].ModalidadeBCST;
                txt_AliquotaICMSST.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].AliquotaICMSST, 2);
                txt_PercentualReducaoST.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].PercentualReducaoST, 2);
                txt_MargemVAdicionado.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].MargemVLAdicionado, 2);
                //_lst_Tributacao[_aux].vICMSDeson = 0;
                // _lst_Tributacao[_aux].vICMSOp = 0;
                // _lst_Tributacao[_aux].pDif = 0;
                // _lst_Tributacao[_aux].vICMSDif = 0;

                cb_CSTIPI.SelectedValue = _lst_Tributacao[_aux].CSTIPI;
                txt_AliquotaIPI.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].AliquotaIPI, 2);
                txt_Cod_Enquadramento.Text = _lst_Tributacao[_aux].Cod_Enquadramento;

                cb_CSTPIS.SelectedValue = _lst_Tributacao[_aux].CSTPIS;
                txt_AliquotaPIS.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].AliquotaPIS, 2);
                txt_AliquotaPISST.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].AliquotaPISST, 2);

                cb_CSTCOFINS.SelectedValue = _lst_Tributacao[_aux].CSTCOFINS;
                txt_AliquotaCOFINS.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].AliquotaCOFINS, 2);
                txt_AliquotaCOFINSST.Text = util_dados.ConfigNumDecimal(_lst_Tributacao[_aux].AliquotaCOFINSST, 2);

                Carrega_UF(_lst_Tributacao[_aux].ID);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Imposto = new BLL_Imposto();
                Imposto = new DTO_Imposto();
                Imposto.lst_Tributacao = new List<DTO_Tributacao>();

                Imposto.ID = util_dados.Verifica_int(txt_ID.Text);
                Imposto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Imposto.Descricao = txt_Descricao.Text;

                Imposto.lst_Tributacao = _lst_Tributacao;

                obj = BLL_Imposto.Grava(Imposto);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
                    txt_ID.Text = obj.ToString();
                    MessageBox.Show(util_msg.msg_Grava, this.Text);
                }
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
                BLL_Imposto = new BLL_Imposto();
                Imposto = new DTO_Imposto();
                Imposto.Descricao = txt_DescricaoP.Text;
                Imposto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();
                _DT = BLL_Imposto.Busca(Imposto);

                DG.DataSource = _DT;

                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
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

                BLL_Imposto = new BLL_Imposto();
                Imposto = new DTO_Imposto();
                Imposto.ID = Convert.ToInt32(txt_ID.Text);
                BLL_Imposto.Exclui(Imposto);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            Limpa_Campos();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Imposto_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Imposto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_AliquotaICMS.Focused == true ||
                txt_AliquotaICMSST.Focused == true ||
                txt_PercentualReducao.Focused == true ||
                txt_PercentualReducaoST.Focused == true ||
                txt_MargemVAdicionado.Focused == true ||
                txt_AliquotaIPI.Focused == true ||
                txt_AliquotaPIS.Focused == true ||
                txt_AliquotaPISST.Focused == true ||
                txt_AliquotaCOFINS.Focused == true ||
                txt_AliquotaCOFINSST.Focused == true)
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
        }

        private void UI_Imposto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region TEXTBOX
        private void txt_AliquotaICMS_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaICMS.Text == string.Empty)
                txt_AliquotaICMS.Text = "0";
            txt_AliquotaICMS.Text = util_dados.ConfigNumDecimal(txt_AliquotaICMS.Text, 2);
        }

        private void txt_AliquotaICMSST_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaICMSST.Text == string.Empty)
                txt_AliquotaICMSST.Text = "0";
            txt_AliquotaICMSST.Text = util_dados.ConfigNumDecimal(txt_AliquotaICMSST.Text, 2);
        }

        private void txt_PercentualReducao_Leave(object sender, EventArgs e)
        {
            if (txt_PercentualReducao.Text == string.Empty)
                txt_PercentualReducao.Text = "0";
            txt_PercentualReducao.Text = util_dados.ConfigNumDecimal(txt_PercentualReducao.Text, 2);
        }

        private void txt_PercentualReducaoST_Leave(object sender, EventArgs e)
        {
            if (txt_PercentualReducaoST.Text == string.Empty)
                txt_PercentualReducaoST.Text = "0";
            txt_PercentualReducaoST.Text = util_dados.ConfigNumDecimal(txt_PercentualReducaoST.Text, 2);
        }

        private void txt_MargemVAdicionado_Leave(object sender, EventArgs e)
        {
            if (txt_MargemVAdicionado.Text == string.Empty)
                txt_MargemVAdicionado.Text = "0";
            txt_MargemVAdicionado.Text = util_dados.ConfigNumDecimal(txt_MargemVAdicionado.Text, 2);
        }

        private void txt_AliquotaIPI_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaIPI.Text == string.Empty)
                txt_AliquotaIPI.Text = "0";
            txt_AliquotaIPI.Text = util_dados.ConfigNumDecimal(txt_AliquotaIPI.Text, 2);
        }

        private void txt_AliquotaPIS_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaPIS.Text == string.Empty)
                txt_AliquotaPIS.Text = "0";
            txt_AliquotaPIS.Text = util_dados.ConfigNumDecimal(txt_AliquotaPIS.Text, 2);
        }

        private void txt_AliquotaPISST_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaPISST.Text == string.Empty)
                txt_AliquotaPISST.Text = "0";
            txt_AliquotaPISST.Text = util_dados.ConfigNumDecimal(txt_AliquotaPISST.Text, 2);
        }

        private void txt_AliquotaCOFINS_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaCOFINS.Text == string.Empty)
                txt_AliquotaCOFINS.Text = "0";
            txt_AliquotaCOFINS.Text = util_dados.ConfigNumDecimal(txt_AliquotaCOFINS.Text, 2);
        }

        private void txt_AliquotaCOFINSST_Leave(object sender, EventArgs e)
        {
            if (txt_AliquotaCOFINSST.Text == string.Empty)
                txt_AliquotaCOFINSST.Text = "0";
            txt_AliquotaCOFINSST.Text = util_dados.ConfigNumDecimal(txt_AliquotaCOFINSST.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) > 0)
                Carrega_Tributacao(util_dados.Verifica_int(txt_ID.Text));

            Status = StatusForm.Consulta;
            Config_Botao();
        }
        #endregion

        #region COMBOBOX
        private void cb_CST_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cb_CST.SelectedValue) >= 0)
                {
                    switch (Convert.ToInt32(cb_CST.SelectedValue))
                    {
                        case 0:
                            cb_ModalidadeBC.Enabled = true;
                            txt_AliquotaICMS.Enabled = true;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 10:
                            cb_ModalidadeBC.Enabled = true;
                            txt_AliquotaICMS.Enabled = true;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                        case 20:
                            cb_ModalidadeBC.Enabled = true;
                            txt_AliquotaICMS.Enabled = true;
                            txt_PercentualReducao.Enabled = true;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 30:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                        case 40:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 41:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 50:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 51:
                            cb_ModalidadeBC.Enabled = true;
                            txt_AliquotaICMS.Enabled = true;
                            txt_PercentualReducao.Enabled = true;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 60:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 70:
                            cb_ModalidadeBC.Enabled = true;
                            txt_AliquotaICMS.Enabled = true;
                            txt_PercentualReducao.Enabled = true;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                        case 90:
                            cb_ModalidadeBC.Enabled = true;
                            txt_AliquotaICMS.Enabled = true;
                            txt_PercentualReducao.Enabled = true;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                        case 101:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 102:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 201:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                        case 202:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                        case 203:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                        case 300:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 400:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 500:
                            cb_ModalidadeBC.Enabled = false;
                            txt_AliquotaICMS.Enabled = false;
                            txt_PercentualReducao.Enabled = false;
                            cb_ModalidadeBCST.Enabled = false;
                            txt_AliquotaICMSST.Enabled = false;
                            txt_PercentualReducaoST.Enabled = false;
                            txt_MargemVAdicionado.Enabled = false;
                            break;
                        case 900:
                            cb_ModalidadeBC.Enabled = true;
                            txt_AliquotaICMS.Enabled = true;
                            txt_PercentualReducao.Enabled = true;
                            cb_ModalidadeBCST.Enabled = true;
                            txt_AliquotaICMSST.Enabled = true;
                            txt_PercentualReducaoST.Enabled = true;
                            txt_MargemVAdicionado.Enabled = true;
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region BUTTON
        private void bt_Todos_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Control ctl in gb_UF.Controls)
            {
                CheckBox ck;
                ck = (CheckBox)ctl;
                if (ck.Checked == true)
                    i++;
                else
                    ck.Checked = true;
            }

            if (i == 28)
                foreach (Control ctl in gb_UF.Controls)
                {
                    CheckBox ck;
                    ck = (CheckBox)ctl;
                    if (ck.Checked == true)
                        ck.Checked = false;
                }
        }

        private void bt_AdicionaTributacao_Click(object sender, EventArgs e)
        {
            Adiciona_Tributo();
        }

        private void bt_Remover_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (_lst_Tributacao[dg_Tributacao.CurrentRow.Index].ID > 0)
                {
                    BLL_Imposto = new BLL_Imposto();
                    Imposto = new DTO_Imposto();
                    Imposto.ID_Tributacao = _lst_Tributacao[dg_Tributacao.CurrentRow.Index].ID;
                    BLL_Imposto.Exclui_Tributacao(Imposto);
                }

                _lst_Tributacao.RemoveAt(dg_Tributacao.CurrentRow.Index);

                Carrega_DG_Tributacao();

                MessageBox.Show(util_msg.msg_Exclui, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_EditaTributacao_Click(object sender, EventArgs e)
        {
            //Edita_Tributo(dg_Tributacao.CurrentRow.Index);
        }

        private void bt_NovoTributo_Click(object sender, EventArgs e)
        {
            Limpa_Campos_Parcial();
        }
        #endregion

        #region DATAGRID
        private void dg_Tributacao_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Tributacao.Rows.Count > 0)
                Edita_Tributo(dg_Tributacao.CurrentRow.Index);
        }
        #endregion
    }
}
