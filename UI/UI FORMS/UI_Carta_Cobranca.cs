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
using System.Globalization;
using System.Drawing.Printing;

namespace Sistema.UI
{
    public partial class UI_Carta_Cobranca : Sistema.UI.UI_Modelo
    {
        public UI_Carta_Cobranca()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE       
        BLL_CReceber BLL_CReceber;
        BLL_Pessoa BLL_Pessoa;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        DateTime ValidaData;

        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_CReceber CReceber;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Email Email;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CARTA DE COBRANÇA";

            bt_Proximo.Visible = false;
            bt_Imprime.Enabled = true;
            bt_Visualiza.Enabled = true;
            bt_Anterior.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Exclui.Visible = false;

            mk_DataInicial.Text = "01/01/2000";
            mk_DataFinal.Text = DateTime.Now.ToString();
            mk_Emissao.Text = DateTime.Now.ToString();

            tabctl.TabPages.Remove(TabPage2);
            tabctl.SelectedTab = TabPage1;

            dg_CReceber.AutoGenerateColumns = false;

            CarregaCB();

            cb_Periodo.SelectedIndex = 2;
        }

        private void CarregaCB()
        {
            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoaP);
            cb_TipoPessoaP.SelectedIndex = -1;
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();
                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_PessoaP);
                cb_ID_PessoaP.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Config_DG()
        {
            DateTime DataDG;
            DateTime DataPC = DateTime.Now;
            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
            {
                DataDG = Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Vencimento"].Value);

                if (DataDG < DataPC)
                    dg_CReceber.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

                if (DataDG.ToShortDateString() == DataPC.ToShortDateString())
                    dg_CReceber.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;

                if (Convert.ToString(dg_CReceber.Rows[i].Cells["col_Situacao"].Value) == "PAGO")
                    dg_CReceber.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
            }
        }

        private void Envia_Email()
        {

            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaInfo, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            string strPessoa = string.Empty;
            string strLancamentos = string.Empty;
            string msg = string.Empty;
            string Endereco = string.Empty;

            double _Total = 0;

            int TipoPessoa = 0;
            int ID_Pessoa = 0;
            int aux = 0;
            DataTable _DT;

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    if (aux >= 1)
                        if (strPessoa != dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString())
                        {
                            MessageBox.Show("ATENÇÃO, Carta de Cobrança Somente com Mesma Pessoa!");
                            return;
                        }

                    strPessoa = dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString();
                    ID_Pessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID_Pessoa"].Value);
                    TipoPessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_TipoPessoa"].Value);
                    aux++;
                }

            if (aux == 0)
            {
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                return;
            }

            strLancamentos += "EMISSÃO\t\tDOC.\t\tVENCIMENTO\t\tVALOR\n";

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    strPessoa = dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString();

                    strLancamentos += util_dados.Config_Data(Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Emissao"].Value), 3) + "\t\t";
                    strLancamentos += dg_CReceber.Rows[i].Cells["col_Documento"].Value.ToString() + "\t\t";
                    strLancamentos += util_dados.Config_Data(Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Vencimento"].Value), 3) + "\t\t";
                    strLancamentos += "R$ " + dg_CReceber.Rows[i].Cells["col_ValorLiquido"].Value.ToString() + "\n";

                    _Total += Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_ValorLiquido"].Value);
                }

            msg = util_dados.Config_Data(DateTime.Now, 4).ToString() + "\n";
            msg += util_msg.msg_MsgCartaCobranca.Replace("#pessoa#", strPessoa);
            msg = msg.Replace("#lancamento#", strLancamentos);
            msg = msg.Replace("#total#", util_dados.ConfigNumDecimal(_Total, 2));

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = ID_Pessoa;
            Pessoa.TipoPessoa = TipoPessoa;

            Email.Principal = true;

            Pessoa.Email = new List<DTO_Pessoa_Email>();
            Pessoa.Email.Add(Email);

            _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Email(Pessoa);

            if (_DT.Rows.Count > 0)
                Endereco = _DT.Rows[0]["Email"].ToString();

            UI_Email UI_Email = new UI_Email();
            UI_Email.Assunto = util_msg.msg_AssuntoCartaCobranca;
            UI_Email.Mensagem = msg;
            UI_Email.Endereco = Endereco;

            util_dados.CarregaForm(UI_Email, this.MdiParent);

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    BLL_CReceber = new BLL_CReceber();
                    CReceber = new DTO_CReceber();

                    CReceber.ID = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID"].Value);
                    CReceber.Descricao = " *CARTA COBRANÇA EM " + mk_Emissao.Text + "*";
                    CReceber.Altera_Registro = 8;

                    BLL_CReceber.Altera(CReceber);
                }
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_TipoPessoaP.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;
            CarregaPessoa();

            cb_ID_PessoaP.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_PessoaP.Focus();

        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            try
            {
                BLL_CReceber = new BLL_CReceber();
                CReceber = new DTO_CReceber();
                
                CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                CReceber.GrupoConta = mk_ContaP.Text;
                CReceber.Documento = txt_DocumentoP.Text;
                CReceber.TipoPessoa = Convert.ToInt32(cb_TipoPessoaP.SelectedValue);
                CReceber.ID_Pessoa = Convert.ToInt32(cb_ID_PessoaP.SelectedValue);
                CReceber.Situacao = 1;
                CReceber.Ordena_Por = 2;

                if (cb_Periodo.SelectedIndex == 0)
                {
                    CReceber.Consulta_Baixa.Filtra = true;
                    CReceber.Consulta_Baixa.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    CReceber.Consulta_Baixa.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                if (cb_Periodo.SelectedIndex == 1)
                {
                    CReceber.Consulta_Emissao.Filtra = true;
                    CReceber.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    CReceber.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                if (cb_Periodo.SelectedIndex == 2)
                {
                    CReceber.Consulta_Vencimento.Filtra = true;
                    CReceber.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    CReceber.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }

                DataTable _DT = BLL_CReceber.Busca(CReceber);
                dg_CReceber.DataSource = _DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Visualizar()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaInfo, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            string strPessoa = string.Empty;
            string strLancamentos = string.Empty;
            string msg = string.Empty;
            string Endereco = string.Empty;
            
            int TipoPessoa = 0;
            int ID_Pessoa = 0;
            int aux = 0;
            DataTable _DT;

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    if (aux >= 1)
                        if (strPessoa != dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString())
                        {
                            MessageBox.Show("ATENÇÃO, Carta de Cobrança Somente com Mesma Pessoa!");
                            return;
                        }

                    strPessoa = dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString();
                    ID_Pessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID_Pessoa"].Value);
                    TipoPessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_TipoPessoa"].Value);
                    aux++;
                }

            if (aux == 0)
            {
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                return;
            }

            DataTable _DT_CReceber = new DataTable();
            _DT_CReceber.Columns.Add("Emissao");
            _DT_CReceber.Columns.Add("Documento");
            _DT_CReceber.Columns.Add("Vencimento");
            _DT_CReceber.Columns.Add("Valor", typeof(double));

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    strPessoa = dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString();

                    _DT_CReceber.Rows.Add();

                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Emissao"] = util_dados.Config_Data(Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Emissao"].Value), 3);
                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Documento"] = dg_CReceber.Rows[i].Cells["col_Documento"].Value.ToString();
                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Vencimento"] = util_dados.Config_Data(Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Vencimento"].Value), 3);
                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Valor"] = Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_ValorLiquido"].Value.ToString());
                }
            
            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    BLL_CReceber = new BLL_CReceber();
                    CReceber = new DTO_CReceber();

                    CReceber.ID = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID"].Value);
                    CReceber.Descricao = " *CARTA COBRANÇA EM " + mk_Emissao.Text + "*";
                    CReceber.Altera_Registro = 8;

                    BLL_CReceber.Altera(CReceber);
                }

            UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();
            rpt.Show();

            string rpt_Nome = "rpt_CartaCobranca.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            _DT = new DataTable();

            Pessoa.TipoPessoa = TipoPessoa;
            Pessoa.ID = ID_Pessoa;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            _DT = BLL_Pessoa.Busca(Pessoa);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            Pessoa.TipoPessoa = TipoPessoa;
            Pessoa.ID = ID_Pessoa;

            DataTable DTR_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa", DTR_Pessoa);
            ReportDataSource ds_CReceber = new ReportDataSource("ds_CReceber", _DT_CReceber);

            ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4).ToString());
            ReportParameter p2 = new ReportParameter("Pessoa", strPessoa);

            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
            rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_CReceber);
            rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaInfo, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            string strPessoa = string.Empty;
            string strLancamentos = string.Empty;
            string msg = string.Empty;
            string Endereco = string.Empty;

            int TipoPessoa = 0;
            int ID_Pessoa = 0;
            int aux = 0;
            DataTable _DT;

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    if (aux >= 1)
                        if (strPessoa != dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString())
                        {
                            MessageBox.Show("ATENÇÃO, Carta de Cobrança Somente com Mesma Pessoa!");
                            return;
                        }

                    strPessoa = dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString();
                    ID_Pessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID_Pessoa"].Value);
                    TipoPessoa = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_TipoPessoa"].Value);
                    aux++;
                }

            if (aux == 0)
            {
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                return;
            }

            DataTable _DT_CReceber = new DataTable();
            _DT_CReceber.Columns.Add("Emissao");
            _DT_CReceber.Columns.Add("Documento");
            _DT_CReceber.Columns.Add("Vencimento");
            _DT_CReceber.Columns.Add("Valor", typeof(double));

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    strPessoa = dg_CReceber.Rows[i].Cells["col_Pessoa"].Value.ToString();

                    _DT_CReceber.Rows.Add();

                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Emissao"] = util_dados.Config_Data(Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Emissao"].Value), 3);
                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Documento"] = dg_CReceber.Rows[i].Cells["col_Documento"].Value.ToString();
                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Vencimento"] = util_dados.Config_Data(Convert.ToDateTime(dg_CReceber.Rows[i].Cells["col_Vencimento"].Value), 3);
                    _DT_CReceber.Rows[_DT_CReceber.Rows.Count - 1]["Valor"] = Convert.ToDouble(dg_CReceber.Rows[i].Cells["col_ValorLiquido"].Value.ToString());
                }

            for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    BLL_CReceber = new BLL_CReceber();
                    CReceber = new DTO_CReceber();

                    CReceber.ID = Convert.ToInt32(dg_CReceber.Rows[i].Cells["col_ID"].Value);
                    CReceber.Descricao = " *CARTA COBRANÇA EM " + mk_Emissao.Text + "*";
                    CReceber.Altera_Registro = 8;

                    BLL_CReceber.Altera(CReceber);
                }

            LocalReport rpt = new LocalReport();

            string rpt_Nome = "rpt_CartaCobranca.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            _DT = new DataTable();

            Pessoa.TipoPessoa = TipoPessoa;
            Pessoa.ID = ID_Pessoa;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            _DT = BLL_Pessoa.Busca(Pessoa);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            Pessoa.TipoPessoa = TipoPessoa;
            Pessoa.ID = ID_Pessoa;

            DataTable DTR_Pessoa = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa", DTR_Pessoa);
            ReportDataSource ds_CReceber = new ReportDataSource("ds_CReceber", _DT_CReceber);

            ReportParameter p1 = new ReportParameter("Data", util_dados.Config_Data(Convert.ToDateTime(mk_Emissao.Text), 4).ToString());
            ReportParameter p2 = new ReportParameter("Pessoa", strPessoa);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.DataSources.Add(ds_CReceber);
            rpt.SetParameters(new ReportParameter[] { p1, p2 });

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

        #region COMBOBOX

        private void cb_TipoPessoaP_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaPessoa();
        }

        private void cb_TipoPessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_TipoPessoaP.SelectedIndex = -1;
        }

        private void cb_ID_PessoaP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_PessoaP.SelectedIndex = -1;
        }
        #endregion

        #region FORM
        private void UI_Carta_Cobranca_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Carta_Cobranca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region MASKEDBOX
        private void mk_Emissao_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Emissao.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_Emissao.Text = Convert.ToString(DateTime.Now);
                mk_Emissao.Focus();
            }

        }

        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Trim() == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataInicial.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
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
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }
        }

        #endregion

        #region DATAGRIDVIEW
        private void DG_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Config_DG();
        }

        private void DG_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                    dg_CReceber.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                dg_CReceber.Rows[dg_CReceber.CurrentRow.Index].Cells["col_Seleciona"].Value = true;
        }

        private void DG_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                try
                {
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    }

                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top + 1, e.CellBounds.Right, e.CellBounds.Top + 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);

                    Image imgChecked = (Image)Sistema.UI.Properties.Resources._checked;
                    Image imgUnchecked = (Image)Sistema.UI.Properties.Resources._unchecked;

                    int X = e.CellBounds.Left + ((e.CellBounds.Width - imgChecked.Width) / 2) - 1;
                    int Y = e.CellBounds.Top + ((e.CellBounds.Height - imgChecked.Height) / 2) - 1;

                    if (Seleciona)
                        e.Graphics.DrawImage(imgChecked, X, Y);
                    else
                        e.Graphics.DrawImage(imgUnchecked, X, Y);

                    e.Handled = true;
                }
                catch
                {
                }
            }
        }
        #endregion

        #region BUTTON
        private void bt_PesquisaConta_P_Click(object sender, EventArgs e)
        {
            UI_PlanoConta_Consulta frm = new UI_PlanoConta_Consulta();

            frm.ShowDialog();
            mk_ContaP.Text = frm.Cod_Conta;
        }
        #endregion

        private void bt_Email_Click(object sender, EventArgs e)
        {
            Envia_Email();
        }
    }
}
