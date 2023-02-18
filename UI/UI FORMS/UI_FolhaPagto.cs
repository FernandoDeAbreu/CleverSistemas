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
using System.Globalization;

namespace Sistema.UI
{
    public partial class UI_FolhaPagto : Sistema.UI.UI_Modelo
    {
        public UI_FolhaPagto()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Pessoa BLL_Pessoa;
        BLL_Evento BLL_Evento;
        BLL_FolhaPagto BLL_FolhaPagto;
        BLL_Grupo BLL_Grupo;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;

        DateTime ValidaData;

        List<DTO_FolhaPagto_Evento> lst_FolhaPagto_Evento;
        #endregion

        #region ESTRUTURA
        DTO_FolhaPagto FolhaPagto;
        DTO_FolhaPagto_Evento FolhaPagto_Evento;
        DTO_Evento Evento;
        DTO_Grupo Grupo;
        DTO_Pessoa Pessoa;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "FOLHA DE PAGAMENTO";

            dg_Lancamentos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn col_Periodo = new DataGridViewTextBoxColumn();
            col_Periodo.DataPropertyName = "DescricaoPeriodo";
            col_Periodo.HeaderText = "PERÍODO";
            col_Periodo.Width = 120;
            DG.Columns.Add(col_Periodo);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "USUÁRIO";
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Vencimento = new DataGridViewTextBoxColumn();
            col_Vencimento.DataPropertyName = "Vencimento";
            col_Vencimento.HeaderText = "VENCIMENTO";
            col_Vencimento.DefaultCellStyle.Format = "d";
            col_Vencimento.Width = 120;
            DG.Columns.Add(col_Vencimento);

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            Carrega_CB();
            Limpa_Campo();
        }

        private void Carrega_CB()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Pessoa.TipoPessoa = 4;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
            cb_ID_Pessoa.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa_P);
            cb_ID_Pessoa_P.SelectedIndex = -1;

            BLL_Evento = new BLL_Evento();
            Evento = new DTO_Evento();

            _DT = new DataTable();
            _DT = BLL_Evento.Busca(Evento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Evento);
            util_dados.CarregaCampo(this, _DT, gb_Lancamentos);
            cb_ID_Evento.SelectedIndex = 0;

            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            _DT = new DataTable();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_FolhaPagto);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo);
            cb_Tipo.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoP);
        }

        private void Carrega_Lancamento()
        {
            double Vencimento = 0;
            double Desconto = 0;
            for (int i = 0; i <= dg_Lancamentos.Rows.Count - 1; i++)
            {
                Vencimento += Convert.ToDouble(dg_Lancamentos.Rows[i].Cells["col_Vencimento"].Value);
                Desconto += Convert.ToDouble(dg_Lancamentos.Rows[i].Cells["col_Desconto"].Value);
            }
            txt_Vencimento.Text = util_dados.ConfigNumDecimal(Vencimento, 2);
            txt_Desconto.Text = util_dados.ConfigNumDecimal(Desconto, 2);
            txt_Total.Text = util_dados.ConfigNumDecimal((Vencimento - Desconto), 2);
        }

        private void Exibe_Evento()
        {
            double Vencimento = 0;
            double Desconto = 0;

            dg_Lancamentos.Rows.Clear();

            for (int i = 0; i <= lst_FolhaPagto_Evento.Count - 1; i++)
            {
                dg_Lancamentos.Rows.Add();
                dg_Lancamentos.Rows[i].Cells["col_DescricaoEvento"].Value = lst_FolhaPagto_Evento[i].Descricao;
                dg_Lancamentos.Rows[i].Cells["col_Vencimento"].Value = lst_FolhaPagto_Evento[i].Vencimento;
                dg_Lancamentos.Rows[i].Cells["col_Desconto"].Value = lst_FolhaPagto_Evento[i].Desconto;

                Vencimento += lst_FolhaPagto_Evento[i].Vencimento;
                Desconto += lst_FolhaPagto_Evento[i].Desconto;
            }

            txt_Vencimento.Text = util_dados.ConfigNumDecimal(Vencimento, 2);
            txt_Desconto.Text = util_dados.ConfigNumDecimal(Desconto, 2);

            txt_Total.Text = util_dados.ConfigNumDecimal(Vencimento - Desconto, 2);
        }

        private void Busca_Item(int _ID)
        {
            FolhaPagto = new DTO_FolhaPagto();
            FolhaPagto.ID = _ID;

            BLL_FolhaPagto = new BLL_FolhaPagto();
            DataTable _DT = new DataTable();

            _DT = BLL_FolhaPagto.Busca_Item(FolhaPagto);

            lst_FolhaPagto_Evento = new List<DTO_FolhaPagto_Evento>();

            if (_DT.Rows.Count > 0)
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {

                    FolhaPagto_Evento = new DTO_FolhaPagto_Evento();

                    FolhaPagto_Evento.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    FolhaPagto_Evento.ID_Evento = Convert.ToInt32(_DT.Rows[i]["ID_Evento"]);
                    FolhaPagto_Evento.ID_Folha = Convert.ToInt32(_DT.Rows[i]["ID_FolhaPagto"]);
                    FolhaPagto_Evento.Vencimento = Convert.ToDouble(_DT.Rows[i]["Vencimento"]);
                    FolhaPagto_Evento.Desconto = Convert.ToDouble(_DT.Rows[i]["Desconto"]);
                    FolhaPagto_Evento.Descricao = _DT.Rows[i]["Descricao"].ToString();
                    FolhaPagto_Evento.Referencia = _DT.Rows[i]["Referencia"].ToString();

                    if (FolhaPagto_Evento.Vencimento == 0)
                        FolhaPagto_Evento.Valor = FolhaPagto_Evento.Desconto;
                    else
                        FolhaPagto_Evento.Valor = FolhaPagto_Evento.Vencimento;

                    lst_FolhaPagto_Evento.Add(FolhaPagto_Evento);
                }

            Exibe_Evento();
        }

        private void Importar_Lancamento()
        {
            FolhaPagto = new DTO_FolhaPagto();
            FolhaPagto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            FolhaPagto.Periodo = Convert.ToDateTime(@"01/" + mk_PeriodoLancar.Text).AddMonths(-1);
            FolhaPagto.Tipo = Convert.ToInt32(cb_Tipo.SelectedValue);

            BLL_FolhaPagto = new BLL_FolhaPagto();

            DataTable _DT = new DataTable();

            _DT = BLL_FolhaPagto.Busca(FolhaPagto);

            if (_DT.Rows.Count > 0)
            {
                FolhaPagto.ID = Convert.ToInt32(_DT.Rows[0]["ID"]);
                _DT = BLL_FolhaPagto.Busca_Item(FolhaPagto);
                if (_DT.Rows.Count == 0)
                    MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                else
                {
                    lst_FolhaPagto_Evento = new List<DTO_FolhaPagto_Evento>();

                    for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                    {
                        FolhaPagto_Evento = new DTO_FolhaPagto_Evento();

                        FolhaPagto_Evento.ID_Evento = Convert.ToInt32(_DT.Rows[i]["ID_Evento"]);
                        FolhaPagto_Evento.Vencimento = Convert.ToDouble(_DT.Rows[i]["Vencimento"]);
                        FolhaPagto_Evento.Desconto = Convert.ToDouble(_DT.Rows[i]["Desconto"]);
                        FolhaPagto_Evento.Descricao = _DT.Rows[i]["Descricao"].ToString();
                        FolhaPagto_Evento.Referencia = _DT.Rows[i]["Referencia"].ToString();

                        if (FolhaPagto_Evento.Vencimento == 0)
                            FolhaPagto_Evento.Valor = FolhaPagto_Evento.Desconto;
                        else
                            FolhaPagto_Evento.Valor = FolhaPagto_Evento.Vencimento;

                        lst_FolhaPagto_Evento.Add(FolhaPagto_Evento);
                    }

                    Exibe_Evento();
                }
            }
            else
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
        }

        private void Limpa_Campo()
        {
            lst_FolhaPagto_Evento = null;
            mk_PeriodoLancar.Text = DateTime.Now.Date.ToString("MM/yyyy");
            mk_Periodo_P.Text = DateTime.Now.Date.ToString("MM/yyyy");
            mk_Vencimento.Text = DateTime.Now.ToString();

            cb_Tipo.SelectedIndex = 0;
            cb_ID_Pessoa.SelectedIndex = 0;

            txt_Desconto.Text = "0,00";
            txt_Vencimento.Text = "0,00";
            txt_Valor.Text = "0,00";
            txt_Total.Text = "0,00";
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                FolhaPagto = new DTO_FolhaPagto();

                FolhaPagto.FolhaPagto_Evento = lst_FolhaPagto_Evento;
                FolhaPagto.ID = util_dados.Verifica_int(txt_ID.Text);
                FolhaPagto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FolhaPagto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                FolhaPagto.Periodo = Convert.ToDateTime(@"01/" + mk_PeriodoLancar.Text);
                FolhaPagto.Vencimento = Convert.ToDateTime(mk_Vencimento.Text);
                FolhaPagto.Tipo = Convert.ToInt32(cb_Tipo.SelectedValue);

                BLL_FolhaPagto = new BLL_FolhaPagto();
                obj = BLL_FolhaPagto.Grava(FolhaPagto);

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
                FolhaPagto = new DTO_FolhaPagto();
                FolhaPagto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                FolhaPagto.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa_P.SelectedValue);
                FolhaPagto.Periodo = Convert.ToDateTime(@"01/" + mk_Periodo_P.Text);
                FolhaPagto.Tipo = Convert.ToInt32(cb_TipoP.SelectedValue);

                BLL_FolhaPagto = new BLL_FolhaPagto();
                DataTable _DT = new DataTable();

                _DT = BLL_FolhaPagto.Busca(FolhaPagto);
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

                FolhaPagto = new DTO_FolhaPagto();
                BLL_FolhaPagto = new BLL_FolhaPagto();
                FolhaPagto.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_FolhaPagto.Exclui(FolhaPagto);

                Pesquisa();

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }

        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
            dg_Lancamentos.Rows.Clear();
            Limpa_Campo();
            //util_dados.LimpaCampos(this, gb_Lancamentos);
        }

        public override void Imprimir()
        {
            if (util_dados.Verifica_int(txt_ID.Text) == 0)
                return;

            LocalReport rpt = new LocalReport();
            string rpt_Nome = "rpt_FolhaPagto.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            FolhaPagto = new DTO_FolhaPagto();
            FolhaPagto.ID = Convert.ToInt32(txt_ID.Text);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = new DataTable();

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_FolhaPagto = new BLL_FolhaPagto();
            DataTable _DT_FolhaPagto = new DataTable();
            DataTable _DT_FolhaPagto_Evento = new DataTable();

            _DT_FolhaPagto = BLL_FolhaPagto.Busca(FolhaPagto);
            _DT_FolhaPagto_Evento = BLL_FolhaPagto.Busca_Item(FolhaPagto);

            if (_DT_FolhaPagto_Evento.Rows.Count < 10)
                for (int i = _DT_FolhaPagto_Evento.Rows.Count; i <= 10; i++)
                    _DT_FolhaPagto_Evento.Rows.Add();

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Folha = new ReportDataSource("ds_Folha", _DT_FolhaPagto);
            ReportDataSource ds_Evento = new ReportDataSource("ds_Eventos", _DT_FolhaPagto_Evento);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Folha);
            rpt.DataSources.Add(ds_Evento);
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

        public override void Visualizar()
        {
            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "rpt_FolhaPagto.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            FolhaPagto = new DTO_FolhaPagto();
            FolhaPagto.ID = Convert.ToInt32(txt_ID.Text);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = new DataTable();

            _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_FolhaPagto = new BLL_FolhaPagto();
            DataTable _DT_FolhaPagto = new DataTable();
            DataTable _DT_FolhaPagto_Evento = new DataTable();

            _DT_FolhaPagto = BLL_FolhaPagto.Busca(FolhaPagto);
            _DT_FolhaPagto_Evento = BLL_FolhaPagto.Busca_Item(FolhaPagto);

            if (_DT_FolhaPagto_Evento.Rows.Count < 10)
                for (int i = _DT_FolhaPagto_Evento.Rows.Count; i <= 10; i++)
                    _DT_FolhaPagto_Evento.Rows.Add();

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Folha = new ReportDataSource("ds_Folha", _DT_FolhaPagto);
            ReportDataSource ds_Eventos = new ReportDataSource("ds_Eventos", _DT_FolhaPagto_Evento);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Folha);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Eventos);

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region BUTTON
        private void bt_Adiciona_Click(object sender, EventArgs e)
        {
            double Vencimento = 0;
            double Desconto = 0;

            if (UTIL.util_dados.Verifica_Double(txt_Valor.Text) == 0)
            {
                MessageBox.Show(util_msg.msg_ValorInvalido, this.Text);
                return;
            }

            if (lst_FolhaPagto_Evento == null)
                lst_FolhaPagto_Evento = new List<DTO_FolhaPagto_Evento>();

            if (txt_Vencimento_Desconto.Text == "Vencimento")
                Vencimento = Convert.ToDouble(txt_Valor.Text);
            else
                Desconto = Convert.ToDouble(txt_Valor.Text);

            for (int i = 0; i <= lst_FolhaPagto_Evento.Count - 1; i++)
                if (lst_FolhaPagto_Evento[i].ID_Evento == Convert.ToInt32(cb_ID_Evento.SelectedValue))
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_AlterarEvento, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;
                    else
                    {
                        lst_FolhaPagto_Evento[i].ID_Evento = Convert.ToInt32(cb_ID_Evento.SelectedValue);
                        lst_FolhaPagto_Evento[i].Vencimento = Vencimento;
                        lst_FolhaPagto_Evento[i].Desconto = Desconto;

                        if (Vencimento == 0)
                            lst_FolhaPagto_Evento[i].Valor = Desconto;
                        else
                            lst_FolhaPagto_Evento[i].Valor = Vencimento;

                        lst_FolhaPagto_Evento[i].Descricao = cb_ID_Evento.Text;

                        cb_ID_Evento.Focus();

                        Exibe_Evento();
                        return;
                    }
                }

            FolhaPagto_Evento = new DTO_FolhaPagto_Evento();
            FolhaPagto_Evento.ID_Evento = Convert.ToInt32(cb_ID_Evento.SelectedValue);
            FolhaPagto_Evento.Vencimento = Vencimento;
            FolhaPagto_Evento.Desconto = Desconto;
            FolhaPagto_Evento.Descricao = cb_ID_Evento.Text;

            if (Vencimento == 0)
                FolhaPagto_Evento.Valor = Desconto;
            else
                FolhaPagto_Evento.Valor = Vencimento;

            lst_FolhaPagto_Evento.Add(FolhaPagto_Evento);

            Exibe_Evento();

            txt_Valor.Text = "0,00";
            cb_ID_Evento.Focus();
        }

        private void bt_Exclui_Click(object sender, EventArgs e)
        {
            try
            {

                if (lst_FolhaPagto_Evento.Count > 0)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusaoItem, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;

                    if (util_dados.Verifica_int(txt_ID.Text) > 0 &&
                        lst_FolhaPagto_Evento[dg_Lancamentos.CurrentRow.Index].ID != 0)
                    {
                        FolhaPagto = new DTO_FolhaPagto();
                        DTO_FolhaPagto_Evento Item = new DTO_FolhaPagto_Evento();
                        List<DTO_FolhaPagto_Evento> FolhaPagto_Evento = new List<DTO_FolhaPagto_Evento>();

                        Item.ID = lst_FolhaPagto_Evento[dg_Lancamentos.CurrentRow.Index].ID;
                        FolhaPagto_Evento.Add(Item);

                        FolhaPagto.FolhaPagto_Evento = FolhaPagto_Evento;

                        BLL_FolhaPagto = new BLL_FolhaPagto();
                        BLL_FolhaPagto.Exclui_Item(FolhaPagto);


                        Busca_Item(Convert.ToInt32(txt_ID.Text));
                    }
                    else
                    {
                        lst_FolhaPagto_Evento.RemoveAt(dg_Lancamentos.CurrentRow.Index);
                        Exibe_Evento();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void bt_Importar_Click(object sender, EventArgs e)
        {
            Importar_Lancamento();
        }

        private void bt_Novo_Click(object sender, EventArgs e)
        {
            Limpa_Campo();
        }
        #endregion

        #region FORM
        private void UI_FolhaPagto_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_FolhaPagto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
               tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }

        private void UI_FolhaPagto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Valor.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) > 0)
                Busca_Item(Convert.ToInt32(txt_ID.Text));

            Config(StatusForm.Consulta);
        }
        #endregion

        #region MASKEDBOX
        private void mk_Vencimento_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Vencimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_Vencimento.Text = Convert.ToString(DateTime.Now);
                mk_Vencimento.Focus();
            }
        }

        private void mk_PeriodoLancar_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact("01/" + mk_PeriodoLancar.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_PeriodoLancar.Text = util_dados.Config_Data(DateTime.Now, 19).ToString();
                mk_PeriodoLancar.Focus();
            }
        }

        private void mk_Periodo_P_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact("01/" + mk_Periodo_P.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show(util_msg.msg_Data_Inválida, this.Text);
                mk_Periodo_P.Text = util_dados.Config_Data(DateTime.Now, 19).ToString();
                mk_Periodo_P.Focus();
            }
        }

        private void mk_Periodo_TextChanged(object sender, EventArgs e)
        {
            if (mk_Periodo.Text != "  /  /")
                mk_PeriodoLancar.Text = util_dados.Config_Data(Convert.ToDateTime(mk_Periodo.Text), 19).ToString();
        }
        #endregion
    }
}
