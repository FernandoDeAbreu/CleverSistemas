using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Drawing.Printing;
using System.Globalization;

namespace Sistema.UI
{
    public partial class UI_Ordem_Servico_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Ordem_Servico_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        BLL_OS BLL_OS;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTPessoa;

        DataTable DTR_Empresa;
        DataTable DTR_OS_TotalOS;
        DataTable DTR_OS_ResumoProduto;
        DataTable DTR_OS_ResumoOS;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_GrupoNivel GrupoNivel;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_TabelaValor TabelaValor;
        DTO_Pagamento Pagamento;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Produto Produto;
        DTO_Produto_Estoque Produto_Estoque;
        DTO_Usuario Usuario;
        DTO_OS OS;
        DTO_Produto_Item Produto_Item;
        DTO_Pagamento_Lanca Pagamento_Lanca;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE ORDEM DE SERVIÇO";

            tabctl.TabPages.Remove(TabPage2);
            TabPage1.Text = "RELATÓRIOS DE ORDEM DE SERVIÇO";

            bt_Imprime.Visible = true;
            bt_Visualiza.Visible = true;
            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            mk_DataInicial.Text = util_dados.Config_Data(DateTime.Now, 11).ToString();
            mk_DataFinal.Text = util_dados.Config_Data(DateTime.Now, 12).ToString();

            CarregaCB();
        }

        public void CarregaCB()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();
            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Comissao = true;
            Usuario.Comissao = true;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

            DataTable _DT = new DataTable();
            _DT = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_UsuarioComissao1);
            cb_ID_UsuarioComissao1.SelectedIndex = -1;

            _DT = new DataTable();
            _DT = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_UsuarioComissao1);
            cb_ID_UsuarioComissao1.SelectedIndex = -1;

            _DT = new DataTable();
            List<string> aux = new List<string>();
            aux.Add("RESUMO DE OS SIMPLIFICADO");
            aux.Add("PRODUTOS COMPRADOS POR PESSOA");
            aux.Add("RESUMO DE OS DETALHADO");
            aux.Add("RESUMO DE OS SIMPLIFICADO (MARGEM DE LUCRO)");
            aux.Add("RESUMO DE OS DETALHADO (MARGEM DE LUCRO)");
            aux.Add("PESSOAS SEM COMPRA POR PERÍODO");

            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoRelatorio);
            cb_TipoRelatorio.SelectedIndex = 0;

            List<string> StatusP = new List<string>();
            StatusP.Add("TODOS");
            StatusP.Add("ABERTA");
            StatusP.Add("EM ORÇAMENTO");
            StatusP.Add("APROVADA");
            StatusP.Add("MONTAGEM");
            StatusP.Add("PRONTA");
            StatusP.Add("CONCLUÍDA");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(0, StatusP), "Descricao", "ID", cb_StatusP);
            cb_StatusP.SelectedIndex = 6;

            _DT = new DataTable();
            aux = new List<string> { "TODOS", "ATIVOS", "BLOQUEADOS" };
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_SituacaoPessoa);
            cb_SituacaoPessoa.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedIndex = -1;


            _DT = new DataTable();
            _DT = util_Param.Pesquisa_NFE();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_NFe);
            cb_NFe.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_Fatura();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 0;
        }

        public void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
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

            cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

            CarregaPessoa();
            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {
            try
            {
                LocalReport rpt = new LocalReport();
                string rpt_Nome = string.Empty;

                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    case 1:
                        rpt_Nome = "rpt_OS_ResumoSimples.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_OS_ResumoProduto.rdlc";
                        break;

                    case 3:
                        rpt_Nome = "rpt_OS_Resumo.rdlc";
                        break;

                    case 4:
                        rpt_Nome = "rpt_OS_ResumoSimplesMargem.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_OS_ResumoMargem.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_OS_Inativo.rdlc";
                        break;
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.ID = util_dados.Verifica_int(txt_ID_OS.Text);
                OS.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                OS.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                OS.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                OS.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 3)
                    {
                        OS.Pesquisa_Cancelado = true;
                        OS.Cancelado = true;
                    }
                    else
                    {
                        OS.Pesquisa_Faturado = true;
                        if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                            OS.Faturado = true;
                        else
                            OS.Faturado = false;
                    }
                }

                if (Convert.ToInt32(cb_NFe.SelectedValue) > 0)
                {
                    OS.Pesquisa_EmitidoNFe = true;
                    if (Convert.ToInt32(cb_NFe.SelectedValue) == 1)
                        OS.NFe = true;
                    else
                        OS.NFe = false;
                }

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                        mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    OS.Consulta_Status.Filtra = true;

                    OS.Consulta_Status.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    OS.Consulta_Status.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalOS;
                ReportDataSource ds_ResumoProduto;
                ReportDataSource ds_ResumoPedido;

                ReportParameter p1;
                ReportParameter p2;

                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    #region RESUMO OS
                    case 1:
                        DTR_OS_TotalOS = BLL_OS.Busca_TotalOS(OS);
                        int aux_cont = 0;
                        int aux_ID = 0;
                        for (int i = 0; i <= DTR_OS_TotalOS.Rows.Count - 1; i++)
                        {
                            int aux = int.Parse(DTR_OS_TotalOS.Rows[i]["ID_OS"].ToString());

                            if (aux == aux_ID)
                            {
                                if (aux_cont > 0)
                                {
                                    DTR_OS_TotalOS.Rows[i]["ID_OS"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["Data_Abertura"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["Descricao"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["ValorTotal"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["CustoTotal"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["Faturado"] = DBNull.Value;
                                }
                                else
                                    aux_cont = aux_cont + 1;
                            }
                            else
                            {
                                aux_ID = int.Parse(DTR_OS_TotalOS.Rows[i]["ID_OS"].ToString());
                                aux_cont = aux_cont + 1;
                            }
                        }

                        ds_Empresa = new ReportDataSource("Emitente", DTR_Empresa);
                        ds_TotalOS = new ReportDataSource("ResumoOS", DTR_OS_TotalOS);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("DescricaoPeriodo", cb_StatusP.Text);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_TotalOS);

                        rpt.SetParameters(new ReportParameter[] { p1, p2 });
                        break;
                    #endregion

                    /*
                                        #region RESUMO PRODUTO
                                        case 2:
                                            DTR_OS_ResumoProduto = BLL_OS.Busca_ResumoProduto(OS);

                                            ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                                            ds_ResumoProduto = new ReportDataSource("ds_ResumoProduto", DTR_Pedido_ResumoProduto);

                                            p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                                            rpt.DataSources.Add(ds_Empresa);
                                            rpt.DataSources.Add(ds_ResumoProduto);

                                            rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                                            break;
                                        #endregion


                                        #region RESUMO PEDIDO
                                        case 3:
                                            DTR_Pedido_ResumoPedido = BLL_OS.Busca_ResumoOS(OS);

                                            ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                                            ds_ResumoPedido = new ReportDataSource("ds_ResumoOS", DTR_Pedido_ResumoPedido);

                                            p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                                            rpt.DataSources.Add(ds_Empresa);
                                            rpt.DataSources.Add(ds_ResumoPedido);

                                            rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                                            break;
                                        #endregion
                                            */
                    #region RESUMO OS MARGEM
                    case 4:
                        DTR_OS_TotalOS = BLL_OS.Busca_TotalOS(OS);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_TotalOS = new ReportDataSource("ds_TotalOS", DTR_OS_TotalOS);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("DescricaoPeriodo", cb_StatusP.Text);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_TotalOS);

                        rpt.SetParameters(new ReportParameter[] { p1, p2 });
                        break;
                        #endregion
                        /*
                    #region RESUMO PEDIDO MARGEM
                    case 5:
                        DTR_Pedido_ResumoPedido = BLL_OS.Busca_ResumoOS(OS);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoOS", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoPedido);

                        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region PESSOAS QUE NÃO COMPRAM POR PERIODO
                    case 6:
                        if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 1)
                            OS.PesquisaInativo = false;
                        else
                        {
                            OS.PesquisaInativo = true;
                            if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 2)
                                OS.SituacaoInativo = true;
                            else
                                OS.SituacaoInativo = false;
                        }

                        DataTable _DT = BLL_OS.Busca_Pessoa_Inativo(OS);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_OS_Inativo", _DT);

                        p1 = new ReportParameter("Periodo", txt_DiasOS.Text + " DIAS.");

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoPedido);

                        rpt.SetParameters(new ReportParameter[] { p1 });
                        break;
                        #endregion
                        */
                }

                rpt.Refresh();

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
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Visualizar()
        {
            try
            {
                UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
                rpt.Show();

                string rpt_Nome = string.Empty;

                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    case 1:
                        rpt_Nome = "rpt_OS_ResumoSimples.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_OS_ResumoProduto.rdlc";
                        break;

                    case 3:
                        rpt_Nome = "rpt_OS_Resumo.rdlc";
                        break;

                    case 4:
                        rpt_Nome = "rpt_OS_ResumoSimplesMargem.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_OS_ResumoMargem.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_OS_Inativo.rdlc";
                        break;
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_OS = new BLL_OS();
                OS = new DTO_OS();

                OS.ID = util_dados.Verifica_int(txt_ID_OS.Text);
                OS.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                OS.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                OS.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                OS.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 3)
                    {
                        OS.Pesquisa_Cancelado = true;
                        OS.Cancelado = true;
                    }
                    else
                    {
                        OS.Pesquisa_Faturado = true;
                        if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                            OS.Faturado = true;
                        else
                            OS.Faturado = false;
                    }
                }

                if (Convert.ToInt32(cb_NFe.SelectedValue) > 0)
                {
                    OS.Pesquisa_EmitidoNFe = true;
                    if (Convert.ToInt32(cb_NFe.SelectedValue) == 1)
                        OS.NFe = true;
                    else
                        OS.NFe = false;
                }

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                        mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty &&
                        Convert.ToInt32(cb_StatusP.SelectedValue) > 0)
                {
                    OS.Consulta_Status.Filtra = true;

                    OS.Status_OS = Convert.ToInt32(cb_StatusP.SelectedValue);

                    OS.Consulta_Status.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    OS.Consulta_Status.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalOS;
                ReportDataSource ds_ResumoProduto;
                ReportDataSource ds_ResumoPedido;

                ReportParameter p1;
                ReportParameter p2;


                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    #region RESUMO OS
                    case 1:
                        DTR_OS_TotalOS = BLL_OS.Busca_TotalOS(OS);
                        int aux_cont = 0;
                        int aux_ID = 0;
                        for (int i = 0; i <= DTR_OS_TotalOS.Rows.Count - 1; i++)
                        {
                            int aux = int.Parse(DTR_OS_TotalOS.Rows[i]["ID_OS"].ToString());

                            if (aux == aux_ID)
                            {
                                if (aux_cont > 0)
                                {
                                    DTR_OS_TotalOS.Rows[i]["ID_OS"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["Data_Abertura"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["Descricao"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["ValorTotal"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["CustoTotal"] = DBNull.Value;
                                    DTR_OS_TotalOS.Rows[i]["Faturado"] = DBNull.Value;
                                }
                                else
                                    aux_cont = aux_cont + 1;
                            }
                            else
                            {
                                aux_ID = int.Parse(DTR_OS_TotalOS.Rows[i]["ID_OS"].ToString());
                                aux_cont = aux_cont + 1;
                            }
                        }

                        ds_Empresa = new ReportDataSource("Emitente", DTR_Empresa);
                        ds_TotalOS = new ReportDataSource("ResumoOS", DTR_OS_TotalOS);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("DescricaoPeriodo", cb_StatusP.Text);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_TotalOS);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
                        break;
                    #endregion

                    #region RESUMO PRODUTO
                    case 2:
                        DTR_OS_ResumoProduto = BLL_OS.Busca_ResumoProduto(OS);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoProduto = new ReportDataSource("ds_ResumoProduto", DTR_OS_ResumoProduto);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("DescricaoPeriodo", cb_StatusP.Text);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoProduto);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
                        break;
                    #endregion
                    /*
            #region RESUMO PEDIDO
            case 3:
                DTR_Pedido_ResumoPedido = BLL_OS.Busca_ResumoOS(OS);

                ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                ds_ResumoPedido = new ReportDataSource("ds_ResumoOS", DTR_Pedido_ResumoPedido);

                p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                p2 = new ReportParameter("Comissao1", Parametro_OS.Descricao_Comissao);
                p3 = new ReportParameter("Comissao2", Parametro_OS.Descricao_Comissao);

                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                break;
            #endregion
            */
                    #region RESUMO OS MARGEM
                    case 4:
                        DTR_OS_TotalOS = BLL_OS.Busca_TotalOSResumo(OS);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_TotalOS = new ReportDataSource("ds_TotalOS", DTR_OS_TotalOS);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("DescricaoPeriodo", cb_StatusP.Text);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_TotalOS);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
                        break;
                        #endregion

                        /*
                    #region RESUMO PEDIDO MARGEM
                    case 5:
                        DTR_Pedido_ResumoPedido = BLL_OS.Busca_ResumoOS(OS);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoOS", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_OS.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_OS.Descricao_Comissao);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region PESSOAS QUE NÃO COMPRAM POR PERIODO
                    case 6:
                        OS.Dias_Inativo = Convert.ToInt32(txt_DiasOS.Text);

                        if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 1)
                            OS.PesquisaInativo = false;
                        else
                        {
                            OS.PesquisaInativo = true;
                            if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 2)
                                OS.SituacaoInativo = true;
                            else
                                OS.SituacaoInativo = false;
                        }

                        DataTable _DT = BLL_OS.Busca_Pessoa_Inativo(OS);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_OS_Inativo", _DT);

                        p1 = new ReportParameter("Periodo", txt_DiasOS.Text + " DIAS.");

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });
                        break;
                        #endregion
                        */
                }
                rpt.rpt_Viewer.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region FORM
        private void UI_Ordem_Servico_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Ordem_Servico_Relatorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_DiasVenda.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Ordem_Servico_Relatorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }

        private void cb_TipoRelatorio_SelectedValueChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(cb_TipoRelatorio.SelectedValue.ToString()) == 6)
            {
                gb_VendaInativo.Visible = true;
                gb_Periodo.Visible = false;
            }
            else
            {
                gb_VendaInativo.Visible = false;
                gb_Periodo.Visible = true;
            }
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
    }
}
