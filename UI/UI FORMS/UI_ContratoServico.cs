using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_ContratoServico : Sistema.UI.UI_Modelo
    {
        public UI_ContratoServico()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region ESTRUTURA
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONTRATO DE SERVIÇO";

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Visible = true;
            bt_Imprime.Enabled = true;

            bt_Visualiza.Visible = true;
            bt_Visualiza.Enabled = true;

            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            tabctl.SelectedTab = TabPage1;

            mk_Emissao.Text = DateTime.Now.ToString();
            mk_InicioContrato.Text = DateTime.Now.ToString();

            Carrega_Pessoa();
        }

        private void Carrega_Pessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = 1;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DataTable _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
            }
            catch (Exception)
            {
            }
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.Usuario_Restrito = true;
            UI_Pessoa_Consulta.TipoPessoa = 1;

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();

        }
        #endregion

        #region MODIFICADORES
        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_Cont_ContratoServico.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_PessoaResponsavel = new DataTable();
            DataTable _DT_Pessoa = new DataTable();
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            Pessoa.TipoPessoa = 2;
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_PessoaResponsavel = BLL_Pessoa.Busca_EmpresaResponsavel(Pessoa);

            string ResponsavelEmitente = "";
            #region CONFIGURA RESPONSAVEL DO EMITENTE
            if (_DT_PessoaResponsavel.Rows.Count > 0)
            {
                int aux = _DT_PessoaResponsavel.Rows.Count;

                if (aux == 1)
                    ResponsavelEmitente = "neste ato por seu representante legal, Sr(a) ";
                else
                    ResponsavelEmitente = "neste ato representado por ";

                for (int i = 0; i <= _DT_PessoaResponsavel.Rows.Count - 1; i++)
                {
                    Pessoa.TipoPessoa = 4;
                    Pessoa.ID = Convert.ToInt32(_DT_PessoaResponsavel.Rows[i]["ID_PessoaResponsavel"]);

                    DataTable _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

                    ResponsavelEmitente += _DT.Rows[0]["Descricao"] + ", portador(a) da Cédula de Identidade RG nº " + _DT.Rows[0]["IE_RG"] + ", CPF nº " + _DT.Rows[0]["CNPJ_CPF"];

                    if (i != _DT_PessoaResponsavel.Rows.Count - 1)
                        ResponsavelEmitente += " e ";
                }
            }
            else
            {
                MessageBox.Show("Não Foi Definido Nenhum Responsável pelo Emissor!", this.Text);
                return;
            }
            #endregion

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            #region INFORMAÇÃO PESSOA
            _DT_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

            string Mensalidade = "R$ " + util_dados.ConfigNumDecimal(_DT_Pessoa.Rows[0]["Mensalidade"], 2) + " (" + util_dados.ValorExtenso(Convert.ToDecimal(_DT_Pessoa.Rows[0]["Mensalidade"])) + ")";
            string Vencimento = _DT_Pessoa.Rows[0]["Vencimento"] + " (" + util_dados.NumeroExtenso(Convert.ToDecimal(_DT_Pessoa.Rows[0]["Vencimento"])) + ")";
            #endregion

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            _DT_PessoaResponsavel = BLL_Pessoa.Busca_PessoaResponsavel(Pessoa);

            string ResponsavelPessoa = "";
            #region CONFIGURA RESPONSAVEL DO CLIENTE
            if (_DT_PessoaResponsavel.Rows.Count > 0)
            {
                int aux = _DT_PessoaResponsavel.Rows.Count;

                if (aux == 1)
                    ResponsavelPessoa = "neste ato por seu representante legal, Sr(a) ";
                else
                    ResponsavelPessoa = "neste ato representado por ";

                for (int i = 0; i <= _DT_PessoaResponsavel.Rows.Count - 1; i++)
                {
                    Pessoa.TipoPessoa = 6;
                    Pessoa.ID = Convert.ToInt32(_DT_PessoaResponsavel.Rows[i]["ID_Pessoa"]);
                    DataTable _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

                    ResponsavelPessoa += _DT.Rows[0]["Descricao"] + ", portador(a) da Cédula de Identidade RG nº " + _DT.Rows[0]["IE_RG"] + ", CPF nº " + _DT.Rows[0]["CNPJ_CPF"];
                    if (i != _DT_PessoaResponsavel.Rows.Count - 1)
                        ResponsavelPessoa += " e ";
                }
            }
            else
            {
                MessageBox.Show("Não Foi Definido Nenhum Responsável pela Empresa!");
                return;
            }
            #endregion

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", _DT_Pessoa);

            ReportParameter p1 = new ReportParameter("Inicio", mk_InicioContrato.Text);
            ReportParameter p2 = new ReportParameter("Emissao", util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4).ToString());
            ReportParameter p3 = new ReportParameter("Vencimento", Vencimento);
            ReportParameter p4 = new ReportParameter("Valor", Mensalidade);
            ReportParameter p5 = new ReportParameter("ResponsavelPessoa", ResponsavelPessoa);
            ReportParameter p6 = new ReportParameter("ResponsavelEmitente", ResponsavelEmitente);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);

            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_Cont_ContratoServico.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            DataTable _DT_Empresa = new DataTable();
            DataTable _DT_PessoaResponsavel = new DataTable();
            DataTable _DT_Pessoa = new DataTable();
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            Pessoa.TipoPessoa = 2;
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            _DT_PessoaResponsavel = BLL_Pessoa.Busca_EmpresaResponsavel(Pessoa);

            string ResponsavelEmitente = "";
            #region CONFIGURA RESPONSAVEL DO EMITENTE
            if (_DT_PessoaResponsavel.Rows.Count > 0)
            {
                int aux = _DT_PessoaResponsavel.Rows.Count;

                if (aux == 1)
                    ResponsavelEmitente = "neste ato por seu representante legal, Sr(a) ";
                else
                    ResponsavelEmitente = "neste ato representado por ";

                for (int i = 0; i <= _DT_PessoaResponsavel.Rows.Count - 1; i++)
                {
                    Pessoa.TipoPessoa = 4;
                    Pessoa.ID = Convert.ToInt32(_DT_PessoaResponsavel.Rows[i]["ID_PessoaResponsavel"]);

                    DataTable _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

                    ResponsavelEmitente += _DT.Rows[0]["Descricao"] + ", portador(a) da Cédula de Identidade RG nº " + _DT.Rows[0]["IE_RG"] + ", CPF nº " + _DT.Rows[0]["CNPJ_CPF"];

                    if (i != _DT_PessoaResponsavel.Rows.Count - 1)
                        ResponsavelEmitente += " e ";
                }
            }
            else
            {
                MessageBox.Show("Não Foi Definido Nenhum Responsável pelo Emissor!", this.Text);
                return;
            }
            #endregion

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);

            #region INFORMAÇÃO PESSOA
            _DT_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

            string Mensalidade = "R$ " + util_dados.ConfigNumDecimal(_DT_Pessoa.Rows[0]["Mensalidade"], 2) + " (" + util_dados.ValorExtenso(Convert.ToDecimal(_DT_Pessoa.Rows[0]["Mensalidade"])) + ")";
            string Vencimento = _DT_Pessoa.Rows[0]["Vencimento"] + " (" + util_dados.NumeroExtenso(Convert.ToDecimal(_DT_Pessoa.Rows[0]["Vencimento"])) + ")";
            #endregion

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            _DT_PessoaResponsavel = BLL_Pessoa.Busca_PessoaResponsavel(Pessoa);

            string ResponsavelPessoa = "";
            #region CONFIGURA RESPONSAVEL DO CLIENTE
            if (_DT_PessoaResponsavel.Rows.Count > 0)
            {
                int aux = _DT_PessoaResponsavel.Rows.Count;

                if (aux == 1)
                    ResponsavelPessoa = "neste ato por seu representante legal, Sr(a) ";
                else
                    ResponsavelPessoa = "neste ato representado por ";

                for (int i = 0; i <= _DT_PessoaResponsavel.Rows.Count - 1; i++)
                {
                    Pessoa.TipoPessoa = 6;
                    Pessoa.ID = Convert.ToInt32(_DT_PessoaResponsavel.Rows[i]["ID_Pessoa"]);
                    DataTable _DT = new DataTable();
                    _DT = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

                    ResponsavelPessoa += _DT.Rows[0]["Descricao"] + ", portador(a) da Cédula de Identidade RG nº " + _DT.Rows[0]["IE_RG"] + ", CPF nº " + _DT.Rows[0]["CNPJ_CPF"];
                    if (i != _DT_PessoaResponsavel.Rows.Count - 1)
                        ResponsavelPessoa += " e ";
                }
            }
            else
            {
                MessageBox.Show("Não Foi Definido Nenhum Responsável pela Empresa!");
                return;
            }
            #endregion

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", _DT_Pessoa);

            ReportParameter p1 = new ReportParameter("Inicio", mk_InicioContrato.Text);
            ReportParameter p2 = new ReportParameter("Emissao", util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4).ToString());
            ReportParameter p3 = new ReportParameter("Vencimento", Vencimento);
            ReportParameter p4 = new ReportParameter("Valor", Mensalidade);
            ReportParameter p5 = new ReportParameter("ResponsavelPessoa", ResponsavelPessoa);
            ReportParameter p6 = new ReportParameter("ResponsavelEmitente", ResponsavelEmitente);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pessoa);

            rpt.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6 });

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
        #endregion

        #region FORM
        private void UI_ContratoServico_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_ContratoServico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion
    }
}
