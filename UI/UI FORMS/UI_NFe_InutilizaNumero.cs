using System;
using System.Data;
using System.Windows.Forms;
using Sistema.NFe;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_NFe_InutilizaNumero : Sistema.UI.UI_Modelo
    {
        public UI_NFe_InutilizaNumero()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_NF BLL_NF;
        #endregion

        #region ESTRUTURA
        DTO_NF NF;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "INUTILIZAR NÚMERAÇÃO DE NF-e";

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            tabctl.SelectedTab = TabPage1;

            DataGridViewTextBoxColumn col_Data = new DataGridViewTextBoxColumn();
            col_Data.DataPropertyName = "Data";
            col_Data.HeaderText = "DATA";
            col_Data.Width = 100;
            col_Data.DefaultCellStyle.Format = "d";
            DG.Columns.Add(col_Data);

            DataGridViewTextBoxColumn col_Protocolo = new DataGridViewTextBoxColumn();
            col_Protocolo.DataPropertyName = "Protocolo";
            col_Protocolo.HeaderText = "PROTOCOLO";
            col_Protocolo.Width = 300;
            col_Protocolo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Protocolo);


            DataGridViewTextBoxColumn col_Numeracao = new DataGridViewTextBoxColumn();
            col_Numeracao.DataPropertyName = "Numeracao";
            col_Numeracao.HeaderText = "NUMERAÇÃO";
            col_Numeracao.Width = 100;
            DG.Columns.Add(col_Numeracao);

            DataGridViewTextBoxColumn col_Justificativa = new DataGridViewTextBoxColumn();
            col_Justificativa.DataPropertyName = "Justificativa";
            col_Justificativa.HeaderText = "JUSTIFICATIVA";
            col_Justificativa.Width = 400;
            col_Justificativa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Justificativa);
        }

        private void Inutiliza()
        {
            try
            {
                NF = new DTO_NF();
                BLL_NF = new BLL_NF();
                NF.Justificativa = txt_Justificativa.Text;
                NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                NF.NumeracaoInut = txt_Numeracao.Text;
                NF.Serie = util_dados.Verifica_int(txt_Serie.Text);
                NF.Modelo = 55;
                NF.Situacao = 9;

                NFe_ProcessaNFe3 _ProcessaNFe = new NFe_ProcessaNFe3();
                _ProcessaNFe.Inutiliza_Numero(NF.Justificativa, NF.NumeracaoInut, NF.Serie.ToString());

                DataTable _DT = new DataTable();

                if (NF.NumeracaoInut.IndexOf("-") == -1)
                {
                    NF.ID_NFe = Convert.ToInt32(txt_Numeracao.Text);
                    NF.Situacao = 0;

                    _DT = BLL_NF.Busca_NF(NF);

                    if (_DT.Rows.Count > 0)
                    {
                        NF.Situacao = 9;
                        BLL_NF.Altera_Situacao(NF);
                    }
                }
                else
                {
                    string[] _ID_NF = NF.NumeracaoInut.Split('-');

                    for (int i = Convert.ToInt32(_ID_NF[0]); i <= Convert.ToInt32(_ID_NF[1]); i++)
                    {
                        NF.ID_NFe = i;
                        NF.Situacao = 0;

                        _DT = BLL_NF.Busca_NF(NF);

                        if (_DT.Rows.Count > 0)
                        {
                            NF.Situacao = 9;
                            BLL_NF.Altera_Situacao(NF);
                        }
                    }
                }

                MessageBox.Show(util_msg.msg_InutilizacaoSucesso, this.Text);

                Novo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_NF = new BLL_NF();
            NF = new DTO_NF();

            NF.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_NF.Busca_Inutilizacao(NF);

            DG.DataSource = _DT;
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);
        }
        #endregion

        #region FORM
        private void UI_NFe_InutilizaNumero_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_NFe_InutilizaNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
              tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }

        private void UI_NFe_InutilizaNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Serie.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Numeracao.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro_DOC(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }
        #endregion

        #region BUTTON
        private void bt_Inutiliza_Click(object sender, EventArgs e)
        {
            if (txt_Justificativa.Text.Length < 15)
            {
                MessageBox.Show(util_msg.msg_qant_invalido, this.Text);
                return;
            }

            DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_INUT, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                Inutiliza();
        }
        #endregion            
    }
}
