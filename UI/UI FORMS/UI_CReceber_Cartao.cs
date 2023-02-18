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
    public partial class UI_CReceber_Cartao : Sistema.UI.UI_Modelo_Financeiro
    {
        public UI_CReceber_Cartao()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_FluxoCaixa BLL_FluxoCaixa;
        BLL_CReceber BLL_CReceber;
        BLL_Grupo BLL_Grupo;
        BLL_Pagamento BLL_Pagamento;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        string Conta;

        DataRow DR;
        DataRow DRCReceber;

        DataTable DT;

        int Tipo;
        int Parcela;
        int[] ID_Conta;
        int[] ID_Cheque;
        int[] ID_FluxoCaixa;

        DateTime ValidaData;

        bool Seleciona;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_PlanoConta PlanoConta;
        DTO_FluxoCaixa FluxoCaixa;
        DTO_CReceber CReceber;
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
            this.Text = "BAIXA DE CARTÃO (CRÉDITO/DÉBITO) - ANTIGO";

            tabctl.TabPages.Remove(TabPage2);
            tabctl.SelectedTab = TabPage1;

            DG.AutoGenerateColumns = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Exclui.Visible = false;
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Novo.Visible = false;

            CarregaCB();
            cb_Periodo.SelectedIndex = 1;

            mk_Data.Text = DateTime.Now.ToString();
        }

        private void CarregaCB()
        {
            DT = new DataTable();
            BLL_Pagamento = new BLL_Pagamento();
            Pagamento = new DTO_Pagamento();

            Pagamento.FiltraPagamento = true;
            Pagamento.Recebimento = true;
            Pagamento.Descricao = "CARTÃO";

            DataTable _DT = new DataTable();
            DT = BLL_Pagamento.Busca(Pagamento);
            util_dados.CarregaCombo(DT, "Descricao", "ID", cb_ID_Cartao);

            if (DT.Rows.Count > 0)
                cb_ID_Cartao.SelectedIndex = 0;

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
            List<DTO_CReceber> lst_CReceber = new List<DTO_CReceber>();

            string _Doc = string.Empty;
            string obj;

            for (int i = 0; i <= DG.Rows.Count - 1; i++)
                if (Convert.ToBoolean(DG.Rows[i].Cells["col_Seleciona"].Value) == true)
                {
                    CReceber = new DTO_CReceber();

                    CReceber.ID = (int)DG.Rows[i].Cells["col_ID"].Value;
                    //CReceber.ID_Conta = (int)DG.Rows[i].Cells["col_ID_Conta"].Value;
                    _Doc += "(" + DG.Rows[i].Cells["col_ID"].Value + ")";

                    CReceber.Desconto = double.Parse(DG.Rows[i].Cells["col_Desconto"].Value.ToString());
                    // CReceber.Acrescimo = double.Parse(DG.Rows[i].Cells["col_Acrescimo"].Value.ToString());

                    lst_CReceber.Add(CReceber);
                }

            BLL_FluxoCaixa = new BLL_FluxoCaixa();
            FluxoCaixa = new DTO_FluxoCaixa();

            FluxoCaixa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            FluxoCaixa.Emissao = DateTime.Parse(mk_Data.Text);
            FluxoCaixa.Caixa = (int)cb_Caixa.SelectedValue;
            FluxoCaixa.Documento = _Doc;
            FluxoCaixa.ID_Conta = Parametro_Financeiro.ID_Conta_RectoDiverso;
            FluxoCaixa.Credito = double.Parse(txt_Valor.Text);
            FluxoCaixa.Debito = 0;
            FluxoCaixa.Informacao = "RECEBIMENTO " + cb_ID_Cartao.Text;
            FluxoCaixa.Conciliado = true;
            FluxoCaixa.ID_Pagamento = (int)cb_ID_Cartao.SelectedValue;
            FluxoCaixa.Planejamento = false;

            FluxoCaixa.ID = BLL_FluxoCaixa.Grava(FluxoCaixa);

            for (int ii = 0; ii <= lst_CReceber.Count - 1; ii++)
            {
                FluxoCaixa.ID_CReceber = lst_CReceber[ii].ID;
                BLL_FluxoCaixa.Grava_Controle(FluxoCaixa);
            }
            for (int i = 0; i <= lst_CReceber.Count - 1; i++)
            {
                CReceber = new DTO_CReceber();
                BLL_CReceber = new BLL_CReceber();

                CReceber.ID = lst_CReceber[i].ID;
                CReceber.Situacao = 2;
                CReceber.DataBaixa = DateTime.Now;
                CReceber.Desconto = lst_CReceber[i].Desconto;
                CReceber.Acrescimo = lst_CReceber[i].Acrescimo;
                CReceber.Altera_Registro = 6;

                BLL_CReceber.Altera(CReceber);
            }
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
            mk_Data.Text = Data_Baixa.ToString();
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_CReceber = new BLL_CReceber();
            CReceber = new DTO_CReceber();

            CReceber.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            CReceber.Situacao = 1;
            CReceber.ID_PrevisaoPagto = Convert.ToInt32(cb_ID_Cartao.SelectedValue);

            CReceber.Ordena_Por = 4;

            if (mk_DataInicial.Text.Replace(@"/", "").Trim() != string.Empty &&
                     mk_DataFinal.Text.Replace(@"/", "").Trim() != string.Empty)
            {
                if (cb_Periodo.Text == "EMISSÃO")
                {
                    CReceber.Consulta_Emissao.Filtra = true;
                    CReceber.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    CReceber.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }
                if (cb_Periodo.Text == "VENCIMENTO")
                {
                    CReceber.Consulta_Vencimento.Filtra = true;
                    CReceber.Consulta_Vencimento.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                    CReceber.Consulta_Vencimento.Final = Convert.ToDateTime(mk_DataFinal.Text);
                }
            }

            DT = BLL_CReceber.Busca(CReceber);
            DG.DataSource = DT;
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
        #endregion

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
