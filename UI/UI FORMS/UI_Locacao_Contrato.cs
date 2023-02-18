using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Locacao_Contrato : Sistema.UI.UI_Modelo
    {
        public UI_Locacao_Contrato()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Imovel_Locacao BLL_Imovel_Locacao;
        BLL_Imovel BLL_Imovel;
        #endregion

        #region ESTRUTURA
        DTO_Locacao Locacao;
        DTO_Pessoa Pessoa;
        DTO_Imovel Imovel;
        DTO_Locacao_Locatario Locacao_Locatario;
        DTO_Locacao_Fiador Locacao_Fiador;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONTRATOS / VISTORIAS / NOTIFICAÇÕES";

            TabPage1.Text = "CONTRATOS / VISTORIAS / NOTIFICAÇÕES";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            tabctl.SelectedTab = TabPage1;

            mk_Data.Text = DateTime.Now.ToString();
        }

        private void Carrega_CB()
        {
            DataTable _DT = new DataTable();
            BLL_Imovel_Locacao = new BLL_Imovel_Locacao();
            Locacao = new DTO_Locacao();
            _DT = BLL_Imovel_Locacao.Busca(Locacao);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Imovel);
            cb_ID_Imovel.SelectedIndex = -1;

            List<string> Tipo = new List<string>();
            Tipo.Add("CONTRATO DE LOCAÇÃO (RESIDÊNCIAL)");
            Tipo.Add("CONTRATO DE LOCAÇÃO (COMERCIAL)");
            Tipo.Add("VISTORIA INICIAL");
            Tipo.Add("VISTORIA FINAL");
            Tipo.Add("NOTIFICAÇÃO DENÚNCIA VAZIA");
            Tipo.Add("DIREITO PARA PREFERENCIA PARA COMPRA DE IMÓVEL");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo), "Descricao", "ID", cb_TipoImpressao);
            cb_TipoImpressao.SelectedValue = 1;
        }

        private void Contrato_Locacao_Residencial(Relatorio _Tipo)
        {
            if (_Tipo == Relatorio.Imprime)
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Locacao_ContratoResidencial.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Valor", "R$ " + DT_Locacao.Rows[0]["Valor"] + " (" + util_dados.ValorExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["Valor"])) + ")");
                ReportParameter p3 = new ReportParameter("Dia", DT_Locacao.Rows[0]["DiaVencimento"].ToString().PadLeft(2) + " (" + util_dados.NumeroExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["DiaVencimento"])) + ")");

                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Locador);
                rpt.DataSources.Add(ds_Locatario);
                rpt.DataSources.Add(ds_Fiador);
                rpt.DataSources.Add(ds_Imovel);
                rpt.DataSources.Add(ds_Locacao);

                rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                string Impressora = string.Empty;
                PrintDialog EscolheImpressora = new PrintDialog();
                if (EscolheImpressora.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                    util_Impressao imp = util_Impressao.Novo(rpt);
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                    imp = null;
                }
            }

            if (_Tipo == Relatorio.Visualiza)
            {
                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();

                frm_rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Locacao_ContratoResidencial.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Valor", "R$ " + DT_Locacao.Rows[0]["Valor"] + " (" + util_dados.ValorExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["Valor"])) + ")");
                ReportParameter p3 = new ReportParameter("Dia", DT_Locacao.Rows[0]["DiaVencimento"].ToString().PadLeft(2) + " (" + util_dados.NumeroExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["DiaVencimento"])) + ")");

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locatario);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fiador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imovel);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locacao);

                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                frm_rpt.rpt_Viewer.RefreshReport();
                frm_rpt.Show();
            }
        }

        private void Contrato_Locacao_Comercial(Relatorio _Tipo)
        {
            if (_Tipo == Relatorio.Imprime)
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Locacao_ContratoComercial.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Valor", "R$ " + DT_Locacao.Rows[0]["Valor"] + " (" + util_dados.ValorExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["Valor"])) + ")");
                ReportParameter p3 = new ReportParameter("Dia", DT_Locacao.Rows[0]["DiaVencimento"].ToString().PadLeft(2) + " (" + util_dados.NumeroExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["DiaVencimento"])) + ")");

                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Locador);
                rpt.DataSources.Add(ds_Locatario);
                rpt.DataSources.Add(ds_Fiador);
                rpt.DataSources.Add(ds_Imovel);
                rpt.DataSources.Add(ds_Locacao);

                rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                string Impressora = string.Empty;
                PrintDialog EscolheImpressora = new PrintDialog();
                if (EscolheImpressora.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                    util_Impressao imp = util_Impressao.Novo(rpt);
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                    imp = null;
                }
            }

            if (_Tipo == Relatorio.Visualiza)
            {
                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();

                frm_rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Locacao_ContratoComercial.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Valor", "R$ " + DT_Locacao.Rows[0]["Valor"] + " (" + util_dados.ValorExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["Valor"])) + ")");
                ReportParameter p3 = new ReportParameter("Dia", DT_Locacao.Rows[0]["DiaVencimento"].ToString().PadLeft(2) + " (" + util_dados.NumeroExtenso(Convert.ToDecimal(DT_Locacao.Rows[0]["DiaVencimento"])) + ")");

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locatario);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fiador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imovel);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locacao);

                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                frm_rpt.rpt_Viewer.RefreshReport();
                frm_rpt.Show();
            }
        }

        private void Vistoria_Inicial(Relatorio _Tipo)
        {
            if (_Tipo == Relatorio.Imprime)
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Locacao_Vistoria.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();
                DataTable DT_Vistoria = new DataTable();
                DataTable DT_Imagem = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);
                DT_Vistoria = BLL_Imovel.Busca_Vistoria(Imovel);
                DT_Imagem = BLL_Imovel.Busca_Imagem(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                DataTable DT_Imagem1 = new DataTable();

                DT_Imagem1.Columns.Add(new DataColumn("Informacao"));
                DT_Imagem1.Columns.Add(new DataColumn("Imagem", typeof(Byte[])));

                for (int i = DT_Imagem.Rows.Count; i >= 0; i--)
                    if (i % 2 == 0 &&
                        i > 0)
                    {
                        DT_Imagem1.Rows.Add();
                        DT_Imagem1.Rows[DT_Imagem1.Rows.Count - 1]["Informacao"] = DT_Imagem.Rows[i - 1]["Informacao"];
                        DT_Imagem1.Rows[DT_Imagem1.Rows.Count - 1]["Imagem"] = DT_Imagem.Rows[i - 1]["Imagem"];
                        DT_Imagem.Rows.RemoveAt(i - 1);
                    }

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Vistoria = new ReportDataSource("ds_Vistoria", DT_Vistoria);
                ReportDataSource ds_Imagem = new ReportDataSource("ds_Imagem", DT_Imagem);
                ReportDataSource ds_Imagem1 = new ReportDataSource("ds_Imagem1", DT_Imagem1);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());

                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Vistoria);
                rpt.DataSources.Add(ds_Imagem);
                rpt.DataSources.Add(ds_Imagem1);
                rpt.DataSources.Add(ds_Fiador);
                rpt.DataSources.Add(ds_Imovel);
                rpt.DataSources.Add(ds_Locacao);
                rpt.DataSources.Add(ds_Locador);
                rpt.DataSources.Add(ds_Locatario);

                rpt.SetParameters(new ReportParameter[] { p1 });

                string Impressora = string.Empty;
                PrintDialog EscolheImpressora = new PrintDialog();
                if (EscolheImpressora.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                    util_Impressao imp = util_Impressao.Novo(rpt);
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                    imp = null;
                }
            }

            if (_Tipo == Relatorio.Visualiza)
            {
                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Locacao_Vistoria.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();
                DataTable DT_Vistoria = new DataTable();
                DataTable DT_Imagem = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);
                DT_Vistoria = BLL_Imovel.Busca_Vistoria(Imovel);
                DT_Imagem = BLL_Imovel.Busca_Imagem(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                DataTable DT_Imagem1 = new DataTable();

                DT_Imagem1.Columns.Add(new DataColumn("Informacao"));
                DT_Imagem1.Columns.Add(new DataColumn("Imagem", typeof(Byte[])));

                for (int i = DT_Imagem.Rows.Count; i >= 0; i--)
                    if (i % 2 == 0 &&
                        i > 0)
                    {
                        DT_Imagem1.Rows.Add();
                        DT_Imagem1.Rows[DT_Imagem1.Rows.Count - 1]["Informacao"] = DT_Imagem.Rows[i - 1]["Informacao"];
                        DT_Imagem1.Rows[DT_Imagem1.Rows.Count - 1]["Imagem"] = DT_Imagem.Rows[i - 1]["Imagem"];
                        DT_Imagem.Rows.RemoveAt(i - 1);
                    }

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Vistoria = new ReportDataSource("ds_Vistoria", DT_Vistoria);
                ReportDataSource ds_Imagem = new ReportDataSource("ds_Imagem", DT_Imagem);
                ReportDataSource ds_Imagem1 = new ReportDataSource("ds_Imagem1", DT_Imagem1);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Vistoria);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imagem);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imagem1);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fiador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imovel);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locacao);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locatario);

                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

                frm_rpt.rpt_Viewer.RefreshReport();
                frm_rpt.Show();
            }
        }

        private void Vistoria_Final(Relatorio _Tipo)
        {
            if (_Tipo == Relatorio.Imprime)
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Locacao_Vistoria_Final.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Vistoria", txt_Auxiliar.Text);

                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Fiador);
                rpt.DataSources.Add(ds_Imovel);
                rpt.DataSources.Add(ds_Locacao);
                rpt.DataSources.Add(ds_Locador);
                rpt.DataSources.Add(ds_Locatario);

                rpt.SetParameters(new ReportParameter[] { p1, p2 });

                string Impressora = string.Empty;
                PrintDialog EscolheImpressora = new PrintDialog();
                if (EscolheImpressora.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                    util_Impressao imp = util_Impressao.Novo(rpt);
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                    imp = null;
                }
            }

            if (_Tipo == Relatorio.Visualiza)
            {
                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Locacao_Vistoria_Final.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();
                DataTable DT_Fiador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA FIADOR
                _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Fiador"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 9;
                Pessoa.ListaID = lst_ID;

                DT_Fiador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Fiador = new ReportDataSource("ds_Fiador", DT_Fiador);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Vistoria", txt_Auxiliar.Text);

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Fiador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imovel);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locacao);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locatario);

                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

                frm_rpt.rpt_Viewer.RefreshReport();
                frm_rpt.Show();
            }
        }

        private void Denuncia_Vazia(Relatorio _Tipo)
        {
            if (_Tipo == Relatorio.Imprime)
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Locacao_DenunciaVazia.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());

                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Imovel);
                rpt.DataSources.Add(ds_Locacao);
                rpt.DataSources.Add(ds_Locador);
                rpt.DataSources.Add(ds_Locatario);

                rpt.SetParameters(new ReportParameter[] { p1 });

                string Impressora = string.Empty;
                PrintDialog EscolheImpressora = new PrintDialog();
                if (EscolheImpressora.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                    util_Impressao imp = util_Impressao.Novo(rpt);
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                    imp = null;
                }
            }

            if (_Tipo == Relatorio.Visualiza)
            {
                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Locacao_DenunciaVazia.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imovel);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locacao);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locatario);

                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });

                frm_rpt.rpt_Viewer.RefreshReport();
                frm_rpt.Show();
            }
        }

        private void Preferencia_Compra(Relatorio _Tipo)
        {
            if (_Tipo == Relatorio.Imprime)
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Locacao_PreferenciaCompra.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Valor", txt_Auxiliar.Text);
                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Imovel);
                rpt.DataSources.Add(ds_Locacao);
                rpt.DataSources.Add(ds_Locador);
                rpt.DataSources.Add(ds_Locatario);

                rpt.SetParameters(new ReportParameter[] { p1, p2 });

                string Impressora = string.Empty;
                PrintDialog EscolheImpressora = new PrintDialog();
                if (EscolheImpressora.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument documento = new PrintDocument();
                    documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                    documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                    util_Impressao imp = util_Impressao.Novo(rpt);
                    imp.Imprimir(documento, Tipo_Impressao.Retrato);
                    imp = null;
                }
            }

            if (_Tipo == Relatorio.Visualiza)
            {
                UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
                string rpt_Nome = "rpt_Locacao_PreferenciaCompra.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + @"\" + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                BLL_Imovel = new BLL_Imovel();
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();

                Locacao = new DTO_Locacao();
                Pessoa = new DTO_Pessoa();
                Imovel = new DTO_Imovel();

                DataTable _DT = new DataTable();
                DataTable DT_Empresa = new DataTable();
                DataTable DT_Locacao = new DataTable();
                DataTable DT_Imovel = new DataTable();
                DataTable DT_Locatario = new DataTable();
                DataTable DT_Locador = new DataTable();

                string lst_ID = string.Empty;

                //BUSCA LOCAÇÃO
                Locacao.ID = Convert.ToInt32(cb_ID_Imovel.SelectedValue);
                DT_Locacao = BLL_Imovel_Locacao.Busca(Locacao);

                //BUSCA IMOVEL
                Imovel.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID_Imovel"]);
                DT_Imovel = BLL_Imovel.Busca(Imovel);

                //BUSCA INFORMACAO EMPRESA
                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;
                DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                #region BUSCA LOCADOR
                _DT = BLL_Imovel.Busca_Proprietario(Imovel);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Pessoa"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 7;
                Pessoa.ListaID = lst_ID;

                DT_Locador = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                #region BUSCA LOCATARIO
                Locacao.ID = Convert.ToInt32(DT_Locacao.Rows[0]["ID"]);
                _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);

                lst_ID = string.Empty;
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    lst_ID += _DT.Rows[i]["ID_Locatario"];
                    if (i != _DT.Rows.Count - 1)
                        lst_ID += ", ";
                }

                Pessoa = new DTO_Pessoa();
                Pessoa.TipoPessoa = 8;
                Pessoa.ListaID = lst_ID;

                DT_Locatario = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
                #endregion

                ReportDataSource ds_Empresa = new ReportDataSource("ds_Empresa", DT_Empresa);
                ReportDataSource ds_Imovel = new ReportDataSource("ds_Imovel", DT_Imovel);
                ReportDataSource ds_Locacao = new ReportDataSource("ds_Locacao", DT_Locacao);
                ReportDataSource ds_Locador = new ReportDataSource("ds_Locador", DT_Locador);
                ReportDataSource ds_Locatario = new ReportDataSource("ds_Locatario", DT_Locatario);

                ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Data.Text), 4).ToString());
                ReportParameter p2 = new ReportParameter("Valor", txt_Auxiliar.Text);

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Imovel);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locacao);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locador);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Locatario);

                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

                frm_rpt.rpt_Viewer.RefreshReport();
                frm_rpt.Show();
            }
        }
        #endregion

        #region FORM
        private void UI_Locacao_Contrato_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            Carrega_CB();
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {
            switch (Convert.ToInt32(cb_TipoImpressao.SelectedValue))
            {
                case 1: //CONTRATO DE LOCAÇÃO (RESIDENCIAL)
                    Contrato_Locacao_Residencial(Relatorio.Imprime);
                    break;

                case 2: //CONTRATO DE LOCAÇÃO (COMERCIAL)
                    Contrato_Locacao_Comercial(Relatorio.Imprime);
                    break;

                case 3://VISTORIA INICIAL
                    Vistoria_Inicial(Relatorio.Imprime);
                    break;

                case 4://VISTORIA FINAL
                    Vistoria_Final(Relatorio.Imprime);
                    break;

                case 5://DENUNCIA VAZIA
                    Denuncia_Vazia(Relatorio.Imprime);
                    break;

                case 6://PREFERENCIA COMPRA
                    Preferencia_Compra(Relatorio.Imprime);
                    break;
            }
        }

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            switch (Convert.ToInt32(cb_TipoImpressao.SelectedValue))
            {
                case 1://CONTRATO DE LOCAÇÃO (RESIDENCIAL)
                    Contrato_Locacao_Residencial(Relatorio.Visualiza);
                    break;

                case 2://CONTRATO DE LOCAÇÃO (COMERCIAL)
                    Contrato_Locacao_Comercial(Relatorio.Visualiza);
                    break;

                case 3://VISTORIA INICIAL
                    Vistoria_Inicial(Relatorio.Visualiza);
                    break;

                case 4://VISTORIA FINAL
                    Vistoria_Final(Relatorio.Visualiza);
                    break;
                case 5://DENUNCIA VAZIA
                    Denuncia_Vazia(Relatorio.Visualiza);
                    break;

                case 6://PREFERENCIA COMPRA
                    Preferencia_Compra(Relatorio.Visualiza);
                    break;
            }
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoImpressao_Leave(object sender, EventArgs e)
        {
            lb_Auxiliar.Visible = false;
            txt_Auxiliar.Visible = false;

            switch (Convert.ToInt32(cb_TipoImpressao.SelectedValue))
            {
                case 4:
                    lb_Auxiliar.Visible = true;
                    txt_Auxiliar.Visible = true;
                    break;
                case 6:
                    lb_Auxiliar.Visible = true;
                    lb_Auxiliar.Text = "Descrição do Valor de Venda";
                    txt_Auxiliar.Visible = true;
                    txt_Auxiliar.Multiline = false;
                    break;
            }
        }
        #endregion
    }
}
