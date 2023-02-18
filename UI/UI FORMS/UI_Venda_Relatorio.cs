using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Venda_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Venda_Relatorio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        BLL_Venda BLL_Venda;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTUsuario;
        DataTable DTPessoa;

        DataTable DTR_Empresa;
        DataTable DTR_Pedido_TotalVenda;
        DataTable DTR_Pedido_ResumoProduto;
        DataTable DTR_Pedido_ResumoPedido;

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
        DTO_Venda Venda;
        DTO_Produto_Item Produto_Item;
        DTO_Pagamento_Lanca Pagamento_Lanca;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "RELATÓRIO DE VENDAS";

            tabctl.TabPages.Remove(TabPage2);
            TabPage1.Text = "RELATÓRIOS DE VENDAS";


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

            lb_Comissao1.Text = Parametro_Venda.Descricao_Comissao;
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

            DTUsuario = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(DTUsuario, "Descricao", "ID", cb_ID_UsuarioComissao1);
            cb_ID_UsuarioComissao1.SelectedIndex = -1;

            DataTable _DT = new DataTable();
            List<string> aux = new List<string>();
            aux.Add("RESUMO DE VENDAS SIMPLIFICADO");
            aux.Add("PRODUTOS COMPRADOS POR PESSOA");
            aux.Add("RESUMO DE VENDAS DETALHADO");
            aux.Add("RESUMO DE VENDAS SIMPLIFICADO (MARGEM DE LUCRO)");
            aux.Add("RESUMO DE VENDAS DETALHADO (MARGEM DE LUCRO)");
            aux.Add("PESSOAS SEM COMPRA POR PERÍODO");
            aux.Add("MARGEM DE CONTRIBUIÇÃO POR PRODUTO");
            aux.Add("PRODUTOS VENDIDOS POR PERÍODO");

            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoRelatorio);
            cb_TipoRelatorio.SelectedIndex = 0;

            _DT = new DataTable();
            aux = new List<string> { "EMISSÃO", "FATURAMENTO", "ENTREGA" };
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedIndex = 0;

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
                        rpt_Nome = "rpt_Venda_ResumoSimples.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_Venda_ResumoProduto.rdlc";
                        break;

                    case 3:
                        rpt_Nome = "rpt_Venda_Resumo.rdlc";
                        break;

                    case 4:
                        rpt_Nome = "rpt_Venda_ResumoSimplesMargem.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_Venda_ResumoMargem.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_Venda_Inativo.rdlc";
                        break;

                    case 7:
                        rpt_Nome = "rpt_Venda_MC.rdlc";
                        break;

                    case 8:
                        rpt_Nome = "rpt_Venda_Produto.rdlc";
                        break;
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(txt_IDPedido.Text);
                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Venda.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Venda.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 3)
                    {
                        Venda.Pesquisa_Cancelado = true;
                        Venda.Cancelado = true;
                    }
                    else
                    {
                        Venda.Pesquisa_Faturado = true;
                        if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                            Venda.Faturado = true;
                        else
                            Venda.Faturado = false;
                    }
                }

                if (Convert.ToInt32(cb_NFe.SelectedValue) > 0)
                {
                    Venda.Pesquisa_EmitidoNFe = true;
                    if (Convert.ToInt32(cb_NFe.SelectedValue) == 1)
                        Venda.NFe = true;
                    else
                        Venda.NFe = false;
                }

                switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        Venda.Consulta_Emissao.Filtra = true;
                        Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;

                    case "FATURAMENTO":
                        Venda.Consulta_Fatura.Filtra = true;
                        Venda.Consulta_Fatura.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Fatura.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;

                    case "ENTREGA":
                        Venda.Consulta_Entrega.Filtra = true;
                        Venda.Consulta_Entrega.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Entrega.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                }

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalVenda;
                ReportDataSource ds_ResumoProduto;
                ReportDataSource ds_ResumoPedido;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;

                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    #region RESUMO VENDA
                    case 1:
                        DTR_Pedido_TotalVenda = BLL_Venda.Busca_TotalVenda(Venda);
                        int aux_cont = 0;
                        int aux_ID = 0;
                        for (int i = 0; i <= DTR_Pedido_TotalVenda.Rows.Count - 1; i++)
                        {
                            int aux = int.Parse(DTR_Pedido_TotalVenda.Rows[i]["ID_Venda"].ToString());

                            if (aux == aux_ID)
                            {
                                if (aux_cont > 0)
                                {
                                    DTR_Pedido_TotalVenda.Rows[i]["ID_Venda"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["Data"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["Descricao"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["DescricaoUsuarioComissao1"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["DescricaoUsuarioComissao2"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["ValorTotal"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["CustoTotal"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["Faturado"] = DBNull.Value;
                                }
                                else
                                    aux_cont = aux_cont + 1;
                            }
                            else
                            {
                                aux_ID = int.Parse(DTR_Pedido_TotalVenda.Rows[i]["ID_Venda"].ToString());
                                aux_cont = aux_cont + 1;
                            }
                        }

                        ds_Empresa = new ReportDataSource("Emitente", DTR_Empresa);
                        ds_TotalVenda = new ReportDataSource("ResumoVenda", DTR_Pedido_TotalVenda);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_TotalVenda);

                        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO PRODUTO
                    case 2:
                        DTR_Pedido_ResumoProduto = BLL_Venda.Busca_ResumoProduto(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoProduto = new ReportDataSource("ds_ResumoProduto", DTR_Pedido_ResumoProduto);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoProduto);

                        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO PEDIDO
                    case 3:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoVenda", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoPedido);

                        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO VENDA MARGEM
                    case 4:
                        DTR_Pedido_TotalVenda = BLL_Venda.Busca_TotalVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_TotalVenda = new ReportDataSource("ds_TotalVenda", DTR_Pedido_TotalVenda);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_TotalVenda);

                        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO PEDIDO MARGEM
                    case 5:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoVenda", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoPedido);

                        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region PESSOAS QUE NÃO COMPRAM POR PERIODO
                    case 6:
                        if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 1)
                            Venda.PesquisaInativo = false;
                        else
                        {
                            Venda.PesquisaInativo = true;
                            if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 2)
                                Venda.SituacaoInativo = true;
                            else
                                Venda.SituacaoInativo = false;
                        }

                        DataTable _DT = BLL_Venda.Busca_Pessoa_Inativo(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_Venda_Inativo", _DT);

                        p1 = new ReportParameter("Periodo", txt_DiasVenda.Text + " DIAS.");

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoPedido);

                        rpt.SetParameters(new ReportParameter[] { p1 });
                        break;
                    #endregion

                    #region MARGEM DE CONTRIBUIÇÃO POR PRODUTO
                    case 7:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoProduto", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoPedido);

                        rpt.SetParameters(new ReportParameter[] { p1 });
                        break;
                    #endregion

                    #region RESUMO DE VENDA POR PRODUTO
                    case 8:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoProduto", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.DataSources.Add(ds_Empresa);
                        rpt.DataSources.Add(ds_ResumoPedido);

                        rpt.SetParameters(new ReportParameter[] { p1 });
                        break;
                        #endregion
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
                        rpt_Nome = "rpt_Venda_ResumoSimples.rdlc";
                        break;

                    case 2:
                        rpt_Nome = "rpt_Venda_ResumoProduto.rdlc";
                        break;

                    case 3:
                        rpt_Nome = "rpt_Venda_Resumo.rdlc";
                        break;

                    case 4:
                        rpt_Nome = "rpt_Venda_ResumoSimplesMargem.rdlc";
                        break;

                    case 5:
                        rpt_Nome = "rpt_Venda_ResumoMargem.rdlc";
                        break;

                    case 6:
                        rpt_Nome = "rpt_Venda_Inativo.rdlc";
                        break;

                    case 7:
                        rpt_Nome = "rpt_Venda_MC.rdlc";
                        break;

                    case 8:
                        rpt_Nome = "rpt_Venda_Produto.rdlc";
                        break;
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID = util_dados.Verifica_int(txt_IDPedido.Text);
                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Venda.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Venda.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);

                if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                {
                    if (Convert.ToInt32(cb_Situacao.SelectedValue) == 3)
                    {
                        Venda.Pesquisa_Cancelado = true;
                        Venda.Cancelado = true;
                    }
                    else
                    {
                        Venda.Pesquisa_Faturado = true;
                        if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                            Venda.Faturado = true;
                        else
                            Venda.Faturado = false;
                    }
                }

                if (Convert.ToInt32(cb_NFe.SelectedValue) > 0)
                {
                    Venda.Pesquisa_EmitidoNFe = true;
                    if (Convert.ToInt32(cb_NFe.SelectedValue) == 1)
                        Venda.NFe = true;
                    else
                        Venda.NFe = false;
                }

                switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        Venda.Consulta_Emissao.Filtra = true;
                        Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;

                    case "FATURAMENTO":
                        Venda.Consulta_Fatura.Filtra = true;
                        Venda.Consulta_Fatura.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Fatura.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                        
                    case "ENTREGA":
                        Venda.Consulta_Entrega.Filtra = true;
                        Venda.Consulta_Entrega.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Entrega.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                }

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalVenda;
                ReportDataSource ds_ResumoProduto;
                ReportDataSource ds_ResumoPedido;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;
                ReportParameter p4;

                switch (int.Parse(cb_TipoRelatorio.SelectedValue.ToString()))
                {
                    #region RESUMO VENDA
                    case 1:
                        DTR_Pedido_TotalVenda = BLL_Venda.Busca_TotalVenda(Venda);
                        int aux_cont = 0;
                        int aux_ID = 0;
                        for (int i = 0; i <= DTR_Pedido_TotalVenda.Rows.Count - 1; i++)
                        {
                            int aux = int.Parse(DTR_Pedido_TotalVenda.Rows[i]["ID_Venda"].ToString());

                            if (aux == aux_ID)
                            {
                                if (aux_cont > 0)
                                {
                                    DTR_Pedido_TotalVenda.Rows[i]["ID_Venda"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["Data"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["Descricao"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["DescricaoUsuarioComissao1"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["DescricaoUsuarioComissao2"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["ValorTotal"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["CustoTotal"] = DBNull.Value;
                                    DTR_Pedido_TotalVenda.Rows[i]["Faturado"] = DBNull.Value;
                                }
                                else
                                    aux_cont = aux_cont + 1;
                            }
                            else
                            {
                                aux_ID = int.Parse(DTR_Pedido_TotalVenda.Rows[i]["ID_Venda"].ToString());
                                aux_cont = aux_cont + 1;
                            }
                        }

                        ds_Empresa = new ReportDataSource("Emitente", DTR_Empresa);
                        ds_TotalVenda = new ReportDataSource("ResumoVenda", DTR_Pedido_TotalVenda);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_TotalVenda);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO PRODUTO
                    case 2:
                        DTR_Pedido_ResumoProduto = BLL_Venda.Busca_ResumoProduto(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoProduto = new ReportDataSource("ds_ResumoProduto", DTR_Pedido_ResumoProduto);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoProduto);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO PEDIDO
                    case 3:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoVenda", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO VENDA MARGEM
                    case 4:
                        DTR_Pedido_TotalVenda = BLL_Venda.Busca_TotalVendaResumo(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_TotalVenda = new ReportDataSource("ds_TotalVenda", DTR_Pedido_TotalVenda);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);
                        p4 = new ReportParameter("Comissao3", Parametro_Venda.Descricao_Comissao);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_TotalVenda);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region RESUMO PEDIDO MARGEM
                    case 5:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoVenda", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);
                        p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                        p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
                        break;
                    #endregion

                    #region PESSOAS QUE NÃO COMPRAM POR PERIODO
                    case 6:
                        Venda.Dias_Inativo = Convert.ToInt32(txt_DiasVenda.Text);

                        if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 1)
                            Venda.PesquisaInativo = false;
                        else
                        {
                            Venda.PesquisaInativo = true;
                            if (Convert.ToInt32(cb_SituacaoPessoa.SelectedValue) == 2)
                                Venda.SituacaoInativo = true;
                            else
                                Venda.SituacaoInativo = false;
                        }

                        DataTable _DT = BLL_Venda.Busca_Pessoa_Inativo(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_Venda_Inativo", _DT);

                        p1 = new ReportParameter("Periodo", txt_DiasVenda.Text + " DIAS.");

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });
                        break;
                    #endregion

                    #region MARGEM DE CONTRIBUIÇÃO POR PRODUTO
                    case 7:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoProduto", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });
                        break;
                    #endregion

                    #region RESUMO DE VENDA POR PRODUTO
                    case 8:
                        DTR_Pedido_ResumoPedido = BLL_Venda.Busca_ResumoVenda(Venda);

                        ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                        ds_ResumoPedido = new ReportDataSource("ds_ResumoProduto", DTR_Pedido_ResumoPedido);

                        p1 = new ReportParameter("Periodo", mk_DataInicial.Text + " À " + mk_DataFinal.Text);

                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                        rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ResumoPedido);

                        rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1 });
                        break;
                        #endregion
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
        private void UI_Venda_Relatorio_Load(object sender, EventArgs e)
        {
            Inicia_Form();

            CarregaCB();
        }

        private void UI_Venda_Relatorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_DiasVenda.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Venda_Relatorio_KeyDown(object sender, KeyEventArgs e)
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
