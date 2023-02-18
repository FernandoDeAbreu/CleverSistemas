using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Globalization;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Venda_Comissao : Sistema.UI.UI_Modelo
    {
        public UI_Venda_Comissao()
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
        DataTable DTGrupo;
        DataTable DTComissao;
        DataTable DT;
        DataTable DTRelatorio;
        DataTable DTR_Empresa;

        DataRow DR;
        DataRow DRComissao;
        DataRow DRAux;

        int intUsuario;
        int TipoComissao;

        string DescricaoUsuario;

        double TotalVenda;
        double TotalComissao;
        double TotalAcrescimo;
        double TotalDesconto;
        double ValorComissao;
        double TotalFinal;

        DateTime ValidaData;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        DTO_Usuario Usuario;
        DTO_Venda Venda;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "COMISSÃO VENDAS";

            TabPage1.Text = "COMISSÃO VENDAS";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;

            tabctl.SelectedTab = TabPage1;

            mk_DataInicial.Text = util_dados.Config_Data(DateTime.Now, 11).ToString();
            mk_DataFinal.Text = util_dados.Config_Data(DateTime.Now, 12).ToString();

            lb_Comissao1.Text = Parametro_Venda.Descricao_Comissao;

            DTRelatorio = new DataTable("ComissaoRelatorio");
            DTRelatorio.Columns.Add("Data");
            DTRelatorio.Columns.Add("ID_Venda");
            DTRelatorio.Columns.Add("Nome_Razao");
            DTRelatorio.Columns.Add("TotalVenda");
            DTRelatorio.Columns.Add("TotalDesconto");
            DTRelatorio.Columns.Add("TotalAcrescimo");
            DTRelatorio.Columns.Add("TotalFinal");
            DTRelatorio.Columns.Add("ValorComissao");
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

            _DT = new DataTable();

            List<string> aux = new List<string> { "EMISSÃO", "FATURAMENTO" };
            _DT = util_dados.CarregaComboDinamico(1, aux);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Periodo);
            cb_Periodo.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_NFE();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_NFe);
            cb_NFe.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = util_Param.Pesquisa_Fatura();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Situacao);
            cb_Situacao.SelectedIndex = 0;
        }

        public void CarregaUsuario()
        {
            if (Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue) > 0)
            {
                intUsuario = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);
                DescricaoUsuario = cb_ID_UsuarioComissao1.Text;
                return;
            }
        }

        public void CalculaComissao(DataTable DT)
        {
            try
            {
                CarregaUsuario();

                TotalVenda = 0;
                TotalAcrescimo = 0;
                TotalDesconto = 0;
                TotalFinal = 0;
                ValorComissao = 0;

                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    DR = DT.Rows[i];

                    TotalVenda = TotalVenda + Convert.ToDouble(DR["TotalVenda"]);
                    TotalAcrescimo = TotalAcrescimo + Convert.ToDouble(DR["TotalAcrescimo"]);
                    TotalDesconto = TotalDesconto + Convert.ToDouble(DR["TotalDesconto"]);
                    TotalFinal = TotalFinal + Convert.ToDouble(DR["TotalFinal"]);
                    ValorComissao = ValorComissao + Convert.ToDouble(DR["Comissao"]);
                }

                UI_Visualiza_Relatorio frm_rpt;
                string rpt_Nome;
                string Caminhorpt;

                ReportDataSource ds_Empresa;
                ReportDataSource ds_Comissao;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;
                ReportParameter p4;
                ReportParameter p5;
                ReportParameter p6;
                ReportParameter p7;
                ReportParameter p8;
                ReportParameter p9;
                ReportParameter p10;

                DTRelatorio.Rows.Clear();
                TotalComissao = 0;

                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    DRComissao = DT.Rows[i];

                    DR = DTRelatorio.NewRow();
                    DR["Data"] = util_dados.Config_Data(Convert.ToDateTime(DRComissao["Data"]), 3);
                    DR["ID_Venda"] = DRComissao["ID_Venda"];
                    DR["Nome_Razao"] = DRComissao["Nome_Razao"];
                    DR["TotalVenda"] = DRComissao["TotalVenda"];
                    DR["TotalDesconto"] = DRComissao["TotalDesconto"];
                    DR["TotalAcrescimo"] = DRComissao["TotalAcrescimo"];
                    DR["TotalFinal"] = DRComissao["TotalFinal"];
                    DR["ValorComissao"] = DRComissao["Comissao"];
                    DTRelatorio.Rows.Add(DR);
                    DTRelatorio.AcceptChanges();
                }


                frm_rpt = new UI_Visualiza_Relatorio();
                frm_rpt.Show();

                rpt_Nome = "rpt_Venda_Comissao.rdlc";
                Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                ds_Comissao = new ReportDataSource("ds_Comissao", DTRelatorio);

                p1 = new ReportParameter("Vendedor", DescricaoUsuario);
                p2 = new ReportParameter("DataInicial", mk_DataInicial.Text);
                p3 = new ReportParameter("DataFinal", mk_DataFinal.Text);
                p4 = new ReportParameter("QuantidadePedido", Convert.ToString(DTRelatorio.Rows.Count));
                p5 = new ReportParameter("TipoComissao", "COMISSÃO POR PRODUTO");
                p6 = new ReportParameter("TotalVendas", util_dados.ConfigNumDecimal(TotalVenda, 2));
                p7 = new ReportParameter("TotalDesconto", util_dados.ConfigNumDecimal(TotalDesconto, 2));
                p8 = new ReportParameter("TotalAcrescimo", util_dados.ConfigNumDecimal(TotalAcrescimo, 2));
                p9 = new ReportParameter("TotalComissao", util_dados.ConfigNumDecimal(ValorComissao, 2));
                p10 = new ReportParameter("TotalFinal", util_dados.ConfigNumDecimal(TotalFinal, 2));

                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Comissao);
                frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 });

                frm_rpt.rpt_Viewer.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Gerar Relatório: " + ex, "Relatório");
            }

        }
        #endregion

        #region FORM
        private void UI_Venda_Comissao_Load(object sender, EventArgs e)
        {
            Inicia_Form();

            CarregaCB();
        }
        #endregion

        #region MODIFICADORES
        public override void Imprimir()
        {
            try
            {
                if (Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue) > 0)
                    DescricaoUsuario = cb_ID_UsuarioComissao1.Text;

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);

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
                }

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

                DT = BLL_Venda.Busca_Comissao(Venda);

                if (DT.Rows.Count == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                    return;
                }

                TotalVenda = 0;
                TotalAcrescimo = 0;
                TotalDesconto = 0;
                TotalFinal = 0;
                ValorComissao = 0;

                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    DR = DT.Rows[i];

                    TotalVenda = TotalVenda + Convert.ToDouble(DR["TotalVenda"]);
                    TotalAcrescimo = TotalAcrescimo + Convert.ToDouble(DR["TotalAcrescimo"]);
                    TotalDesconto = TotalDesconto + Convert.ToDouble(DR["TotalDesconto"]);
                    TotalFinal = TotalFinal + Convert.ToDouble(DR["TotalFinal"]);
                    ValorComissao = ValorComissao + Convert.ToDouble(DR["Comissao"].ToString());
                }
                LocalReport rpt = new LocalReport();
                string rpt_Nome = "rpt_Venda_Comissao.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.ReportPath = Caminhorpt;

                ReportDataSource ds_Empresa;
                ReportDataSource ds_Comissao;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;
                ReportParameter p4;
                ReportParameter p5;
                ReportParameter p6;
                ReportParameter p7;
                ReportParameter p8;
                ReportParameter p9;
                ReportParameter p10;

                DTRelatorio.Rows.Clear();
                TotalComissao = 0;

                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    DRComissao = DT.Rows[i];

                    DR = DTRelatorio.NewRow();
                    DR["Data"] = util_dados.Config_Data(Convert.ToDateTime(DRComissao["Data"]), 3);
                    DR["ID_Venda"] = DRComissao["ID_Venda"];
                    DR["Nome_Razao"] = DRComissao["Nome_Razao"];
                    DR["TotalVenda"] = DRComissao["TotalVenda"];
                    DR["TotalDesconto"] = DRComissao["TotalDesconto"];
                    DR["TotalAcrescimo"] = DRComissao["TotalAcrescimo"];
                    DR["TotalFinal"] = DRComissao["TotalFinal"];
                    DR["ValorComissao"] = DRComissao["Comissao"];
                    DTRelatorio.Rows.Add(DR);
                    DTRelatorio.AcceptChanges();
                }

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                ds_Comissao = new ReportDataSource("ds_Comissao", DTRelatorio);

                p1 = new ReportParameter("Vendedor", DescricaoUsuario);
                p2 = new ReportParameter("DataInicial", mk_DataInicial.Text);
                p3 = new ReportParameter("DataFinal", mk_DataFinal.Text);
                p4 = new ReportParameter("QuantidadePedido", Convert.ToString(DTRelatorio.Rows.Count));
                p5 = new ReportParameter("TipoComissao", "COMISSÃO POR PRODUTO");
                p6 = new ReportParameter("TotalVendas", util_dados.ConfigNumDecimal(TotalVenda, 2));
                p7 = new ReportParameter("TotalDesconto", util_dados.ConfigNumDecimal(TotalDesconto, 2));
                p8 = new ReportParameter("TotalAcrescimo", util_dados.ConfigNumDecimal(TotalAcrescimo, 2));
                p9 = new ReportParameter("TotalComissao", util_dados.ConfigNumDecimal(ValorComissao, 2));
                p10 = new ReportParameter("TotalFinal", util_dados.ConfigNumDecimal(TotalFinal, 2));

                rpt.DataSources.Add(ds_Empresa);
                rpt.DataSources.Add(ds_Comissao);
                rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 });

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
                if (Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue) > 0)
                {
                    DescricaoUsuario = cb_ID_UsuarioComissao1.Text;
                }


                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Venda.ID_UsuarioComissao1 = Convert.ToInt32(cb_ID_UsuarioComissao1.SelectedValue);

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
                }

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


                DT = BLL_Venda.Busca_Comissao(Venda);

                TotalVenda = 0;
                TotalAcrescimo = 0;
                TotalDesconto = 0;
                TotalFinal = 0;
                ValorComissao = 0;

                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    DR = DT.Rows[i];

                    TotalVenda = TotalVenda + Convert.ToDouble(DR["TotalVenda"]);
                    TotalAcrescimo = TotalAcrescimo + Convert.ToDouble(DR["TotalAcrescimo"]);
                    TotalDesconto = TotalDesconto + Convert.ToDouble(DR["TotalDesconto"]);
                    TotalFinal = TotalFinal + Convert.ToDouble(DR["TotalFinal"]);
                    ValorComissao = ValorComissao + util_dados.Verifica_Double(DR["Comissao"].ToString());
                }

                UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
                rpt.Show();

                string rpt_Nome = "rpt_Venda_Comissao.rdlc";
                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                ReportDataSource ds_Empresa;
                ReportDataSource ds_Comissao;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;
                ReportParameter p4;
                ReportParameter p5;
                ReportParameter p6;
                ReportParameter p7;
                ReportParameter p8;
                ReportParameter p9;
                ReportParameter p10;

                DTRelatorio.Rows.Clear();
                TotalComissao = 0;

                for (int i = 0; i <= DT.Rows.Count - 1; i++)
                {
                    DRComissao = DT.Rows[i];

                    DR = DTRelatorio.NewRow();
                    DR["Data"] = util_dados.Config_Data(Convert.ToDateTime(DRComissao["Data"]), 3);
                    DR["ID_Venda"] = DRComissao["ID_Venda"];
                    DR["Nome_Razao"] = DRComissao["Nome_Razao"];
                    DR["TotalVenda"] = DRComissao["TotalVenda"];
                    DR["TotalDesconto"] = DRComissao["TotalDesconto"];
                    DR["TotalAcrescimo"] = DRComissao["TotalAcrescimo"];
                    DR["TotalFinal"] = DRComissao["TotalFinal"];
                    DR["ValorComissao"] = DRComissao["Comissao"];
                    DTRelatorio.Rows.Add(DR);
                    DTRelatorio.AcceptChanges();
                }

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
                ds_Comissao = new ReportDataSource("ds_Comissao", DTRelatorio);

                p1 = new ReportParameter("Vendedor", DescricaoUsuario);
                p2 = new ReportParameter("DataInicial", mk_DataInicial.Text);
                p3 = new ReportParameter("DataFinal", mk_DataFinal.Text);
                p4 = new ReportParameter("QuantidadePedido", Convert.ToString(DTRelatorio.Rows.Count));
                p5 = new ReportParameter("TipoComissao", "COMISSÃO POR PRODUTO");
                p6 = new ReportParameter("TotalVendas", util_dados.ConfigNumDecimal(TotalVenda, 2));
                p7 = new ReportParameter("TotalDesconto", util_dados.ConfigNumDecimal(TotalDesconto, 2));
                p8 = new ReportParameter("TotalAcrescimo", util_dados.ConfigNumDecimal(TotalAcrescimo, 2));
                p9 = new ReportParameter("TotalComissao", util_dados.ConfigNumDecimal(ValorComissao, 2));
                p10 = new ReportParameter("TotalFinal", util_dados.ConfigNumDecimal(TotalFinal, 2));

                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Comissao);
                rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 });

                rpt.rpt_Viewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MASKEDBOX
        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
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
