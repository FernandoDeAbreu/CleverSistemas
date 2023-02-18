using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Cartao : Sistema.UI.UI_Modelo_Financeiro
    {
        public UI_Cartao()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_Cartao BLL_Cartao;
        BLL_Grupo BLL_Grupo;
        BLL_Pagamento BLL_Pagamento;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;

        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_PlanoConta PlanoConta;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_Cartao Cartao;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Pessoa_Telefone Telefone;
        DTO_Pagamento_Lanca Pagamento_Lanca;
        DTO_Pagamento Pagamento;
        DTO_Lancamento Lancamento;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "BAIXA DE CARTÃO (CRÉDITO/DÉBITO) - NOVO";

            tabctl.SelectedTab = TabPage1;

            DG.AutoGenerateColumns = false;
            dg_Baixados.AutoGenerateColumns = false;

            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Exclui.Visible = false;
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Novo.Visible = false;

            CarregaCB();
            cb_Periodo.SelectedIndex = 1;

            mk_Data.Text = DateTime.Now.ToString();

            mk_DataInicialP.Text = DateTime.Now.ToString();
            mk_DataFinalP.Text = DateTime.Now.ToString();
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            Pagamento.FiltraPagamento = true;
            Pagamento.Recebimento = true;
            Pagamento.Tipo = 2;

            _DT = new DataTable();
            _DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Cartao);

            if (_DT.Rows.Count > 0)
                cb_ID_Cartao.SelectedIndex = 0;

            _DT = new DataTable();
            _DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_CartaoP);
            //cb_ID_CartaoP.SelectedIndex = -1;

            _DT = new DataTable();
            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Caixa);

            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Caixa);
            if (_DT.Rows.Count > 0)
                cb_Caixa.SelectedIndex = 0;

            List<string> Periodo = new List<string>();
            Periodo.Add("EMISSÃO");
            Periodo.Add("VENCIMENTO");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(Periodo.Count, Periodo), "Descricao", "ID", cb_Periodo);
        }

        private void Realiza_Lancamento()
        {
            FluxoCaixa = new DTO_FluxoCaixa();
            List<DTO_Cartao> lst_Cartao = new List<DTO_Cartao>();
            List<int> lst_ID_CReceber = new List<int>();

            string _Doc = string.Empty;
            int obj;

            for (int i = 0; i <= DG.Rows.Count - 1; i++)
                if (Convert.ToBoolean(DG.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    Cartao = new DTO_Cartao();
                    BLL_Cartao = new BLL_Cartao();

                    Cartao.ID = (int)DG.Rows[i].Cells["col_ID"].Value;

                    #region BUSCA LANÇAMENTO
                    DataTable _DT = new DataTable();

                    _DT = BLL_Cartao.Busca_Lancamento(Cartao);

                    if (_DT.Rows.Count > 0)
                        for (int ii = 0; ii <= _DT.Rows.Count - 1; ii++)
                        {
                            _Doc += "(" + _DT.Rows[ii]["Documento"] + ")";
                            lst_ID_CReceber.Add(Convert.ToInt32(_DT.Rows[ii]["ID_CReceber"]));
                            #endregion
                        }
                    Cartao.Aliquota = double.Parse(DG.Rows[i].Cells["col_Desconto"].Value.ToString());

                    lst_Cartao.Add(Cartao);
                }

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            FluxoCaixa = new DTO_FluxoCaixa();

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Emissao = DateTime.Parse(mk_Data.Text);
            FluxoCaixa.Caixa = (int)cb_Caixa.SelectedValue;
            FluxoCaixa.Documento = _Doc;
            FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_RectoDiverso;
            FluxoCaixa.Credito = double.Parse(txt_ValorLancar.Text);
            FluxoCaixa.Debito = 0;
            FluxoCaixa.Informacao = "RECEBIMENTO " + cb_ID_Cartao.Text;
            FluxoCaixa.Conciliado = true;
            FluxoCaixa.ID_Pagamento = (int)cb_ID_Cartao.SelectedValue;
            FluxoCaixa.Planejamento = false;

            obj = BLL_FluxoCaixa.Grava(FluxoCaixa);

            if (obj > 0)
                FluxoCaixa.ID = obj;

            for (int i = 0; i <= lst_ID_CReceber.Count - 1; i++)
            {
                FluxoCaixa.ID_CReceber = lst_ID_CReceber[i];
                BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
            }

            for (int i = 0; i <= lst_Cartao.Count - 1; i++)
            {
                Cartao = new DTO_Cartao();
                BLL_Cartao = new BLL_Cartao();

                Cartao.ID = lst_Cartao[i].ID;
                Cartao.Baixado = true;
                Cartao.Data_Baixa = DateTime.Now;

                BLL_Cartao.Baixa(Cartao);
            }

            txt_Diferenca.Text = "0,00";
        }

        private void CalculaValor()
        {
            double Total = 0;
            DateTime Data_Baixa = DateTime.Now;

            for (int i = 0; i <= DG.Rows.Count - 1; i++)
                if (Convert.ToBoolean(DG.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    Total = Total + Convert.ToDouble(DG.Rows[i].Cells["col_ValorLiquido"].Value);
                    Data_Baixa = Convert.ToDateTime(DG.Rows[i].Cells["col_Vencimento"].Value);
                }

            txt_Valor.Text = util_dados.ConfigNumDecimal(Total, 2);
            txt_ValorLancar.Text = util_dados.ConfigNumDecimal(Total, 2);
            mk_Data.Text = Data_Baixa.ToString();
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            DataTable _DT = new DataTable();

            BLL_Cartao = new BLL_Cartao();
            Cartao = new DTO_Cartao();

            Cartao.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            if (tabctl.SelectedTab == TabPage1)
            {
                Cartao.Filtra_Baixado = true;
                Cartao.Baixado = false;
                Cartao.ID_Pagamento = util_dados.Verifica_int(cb_ID_Cartao.SelectedValue.ToString());

                if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                         mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    if (cb_Periodo.Text == "EMISSÃO")
                    {
                        Cartao.Consulta_Emissao.Filtra = true;
                        Cartao.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Cartao.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                    if (cb_Periodo.Text == "VENCIMENTO")
                    {
                        Cartao.Consulta_Vencimento.Filtra = true;
                        Cartao.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Cartao.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                    }
                }

                _DT = BLL_Cartao.Busca(Cartao);
                DG.DataSource = _DT;
            }


            if (tabctl.SelectedTab == TabPage2)
            {
                Cartao.Filtra_Baixado = true;
                Cartao.Baixado = true;
                Cartao.ID_Pagamento = util_dados.Verifica_int(cb_ID_CartaoP.SelectedValue.ToString());

                if (mk_DataInicialP.Text.Replace(@"/", "").Trim() != string.Empty &&
                         mk_DataFinalP.Text.Replace(@"/", "").Trim() != string.Empty)
                {
                    if (cb_Periodo.Text == "VENCIMENTO")
                    {
                        Cartao.Consulta_Vencimento.Filtra = true;
                        Cartao.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicialP.Text);
                        Cartao.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinalP.Text);
                    }
                }

                _DT = BLL_Cartao.Busca(Cartao);
                dg_Baixados.DataSource = _DT;
            }
        }
        #endregion

        #region FORM
        private void UI_CReceber_Cartao_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_CReceber_Cartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }

        private void UI_Cartao_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txt_Diferenca.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }
        #endregion

        #region BUTTON
        private void bt_Baixa_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_Lancamento, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                Realiza_Lancamento();

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex, this.Text);
            }
        }
        #endregion

        #region DATAGRIDVIEW
        private void DG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculaValor();
        }

        private void DG_DataSourceChanged(object sender, EventArgs e)
        {
            CalculaValor();
        }

        private void DG_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= DG.Rows.Count - 1; i++)
                    DG.Rows[i].Cells[0].Value = Seleciona;
            }
            CalculaValor();
        }

        private void DG_DoubleClick(object sender, EventArgs e)
        {
            if (DG.Rows.Count == 0)
                return;

            if (Convert.ToBoolean(DG.Rows[DG.CurrentRow.Index].Cells["col_Seleciona"].Value) == true)
            {
                DG.Rows[DG.CurrentRow.Index].Cells["col_Seleciona"].Value = false;
                return;
            }

            if (Convert.ToBoolean(DG.Rows[DG.CurrentRow.Index].Cells["col_Seleciona"].Value) == false)
                DG.Rows[DG.CurrentRow.Index].Cells["col_Seleciona"].Value = true;

            CalculaValor();
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

        #region MASKEDBOX
        private void mk_DataInicial_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicial.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
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
            if (mk_DataFinal.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataFinal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinal.Text = Convert.ToString(DateTime.Now);
                mk_DataFinal.Focus();
            }
        }

        private void mk_DataInicialP_Leave(object sender, EventArgs e)
        {
            if (mk_DataInicialP.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataInicialP.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataInicialP.Text = Convert.ToString(DateTime.Now);
                mk_DataInicialP.Focus();
            }
        }

        private void mk_DataFinalP_Leave(object sender, EventArgs e)
        {
            if (mk_DataFinalP.Text.Replace(@"/", "").Replace(" ", "") == string.Empty)
                return;

            DateTime.TryParseExact(mk_DataFinalP.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_DataFinalP.Text = Convert.ToString(DateTime.Now);
                mk_DataFinalP.Focus();
            }
        }
        #endregion

        private void txt_Diferenca_Leave(object sender, EventArgs e)
        {
            if (txt_Diferenca.Text.Trim() == string.Empty)
                txt_Diferenca.Text = "0";

            txt_Diferenca.Text = util_dados.ConfigNumDecimal(txt_Diferenca.Text, 2);

            double ValorSistema = double.Parse(txt_Valor.Text);
            double Diferenca = double.Parse(txt_Diferenca.Text);

            txt_ValorLancar.Text = util_dados.ConfigNumDecimal(ValorSistema + Diferenca, 2);
        }


    }
}
