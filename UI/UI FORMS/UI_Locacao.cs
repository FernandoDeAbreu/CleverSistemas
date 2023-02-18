using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Locacao : Sistema.UI.UI_Modelo
    {
        public UI_Locacao()
        {
            InitializeComponent();
        }

        #region ESTRUTURA
        DTO_Locacao Locacao;        
        DTO_Pessoa Pessoa;
        DTO_Imovel Imovel;
        DTO_Locacao_Locatario Locacao_Locatario;
        DTO_Locacao_Fiador Locacao_Fiador;
        #endregion

        #region VARIAVEIS DE CLASSE
        BLL_Imovel_Locacao BLL_Imovel_Locacao;
        BLL_Pessoa BLL_Pessoa;
        BLL_Imovel BLL_Imovel;
        #endregion

        #region VARIAVEIS DIVERSAS
        DateTime ValidaData;
        List<DTO_Locacao_Locatario> lst_Locatario;
        List<DTO_Locacao_Fiador> lst_Fiador;

        int obj;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONTRATO DE LOCAÇÃO";

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "IMÓVEL";
            col_Descricao.Width = 400;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            DataGridViewTextBoxColumn col_Endereco = new DataGridViewTextBoxColumn();
            col_Endereco.DataPropertyName = "Endereco";
            col_Endereco.HeaderText = "ENDEREÇO";
            col_Endereco.Width = 400;
            col_Endereco.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Endereco);

            //DG.Columns["Complemento"].DataPropertyName = "ValorTotal";
            //DG.Columns["Complemento"].HeaderText = "Valor Total";
            // DG.Columns["Complemento"].DefaultCellStyle.Format = "C2";
            //DG.Columns["Complemento"].Width = 200;

            Limpa_Campo();
        }

        private void Carrega_CB()
        {
            DataTable _DT = new DataTable();
            BLL_Imovel = new BLL_Imovel();
            Imovel = new DTO_Imovel();
            _DT = BLL_Imovel.Busca(Imovel);
            util_dados.CarregaCombo(_DT, "DescricaoCombo", "ID", cb_ID_Imovel);
            cb_ID_Imovel.SelectedIndex = -1;

            _DT = BLL_Imovel.Busca(Imovel);
            util_dados.CarregaCombo(_DT, "DescricaoCombo", "ID", cb_ID_Imovel_P);
            cb_ID_Imovel_P.SelectedIndex = -1;
        }

        private void CarregaPessoa()
        {
            try
            {
                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                cb_ID_Locatario.DataSource = null;

                Pessoa.TipoPessoa = 8;
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DataTable _DT = new DataTable();

                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Locatario);
                cb_ID_Locatario.SelectedIndex = -1;

                _DT = new DataTable();
                Pessoa.TipoPessoa = 9;
                _DT = BLL_Pessoa.Busca_Nome(Pessoa);
                util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Fiador);
                cb_ID_Fiador.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Limpa_Campo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);

            mk_Data.Text = DateTime.Now.ToString();
            mk_Inicio.Text = DateTime.Now.ToString();
            mk_Termino.Text = DateTime.Now.ToString();

            mk_Inicio_P.Text = DateTime.Now.ToString();
            mk_Termino_P.Text = DateTime.Now.ToString();

            txt_Valor.Text = "0,00";
            txt_DiaVencimento.Text = "1";

            lst_Fiador = new List<DTO_Locacao_Fiador>();
            lst_Locatario = new List<DTO_Locacao_Locatario>();

            Carrega_CB();
            CarregaPessoa();

            DG.DataSource = null;

            dg_Fiador.Rows.Clear();
            dg_Locatario.Rows.Clear();
        }

        private void Carrega_Locatario()
        {
            dg_Locatario.Rows.Clear();

            for (int i = 0; i <= lst_Locatario.Count - 1; i++)
            {
                dg_Locatario.Rows.Add();
                dg_Locatario.Rows[dg_Locatario.Rows.Count - 1].Cells["col_Locatario"].Value = lst_Locatario[i].Descricao_Locatario;
            }
        }

        private void Carrega_Fiador()
        {
            dg_Fiador.Rows.Clear();

            for (int i = 0; i <= lst_Fiador.Count - 1; i++)
            {
                dg_Fiador.Rows.Add();
                dg_Fiador.Rows[dg_Fiador.Rows.Count - 1].Cells["col_Fiador"].Value = lst_Fiador[i].Descricao_Fiador;
            }
        }

        private void Busca_Locacao(int _ID)
        {
            dg_Fiador.Rows.Clear();
            dg_Locatario.Rows.Clear();

            lst_Locatario = null;
            lst_Fiador = null;

            BLL_Imovel_Locacao = new BLL_Imovel_Locacao();
            Locacao = new DTO_Locacao();

            Locacao.ID = _ID;
            DataTable _DT = new DataTable();

            #region LOCATÁRIO
            _DT = BLL_Imovel_Locacao.Busca_Locatario(Locacao);
            if (_DT.Rows.Count > 0)
            {
                lst_Locatario = new List<DTO_Locacao_Locatario>();
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Locacao_Locatario = new DTO_Locacao_Locatario();

                    Locacao_Locatario.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    Locacao_Locatario.ID_Locatario = Convert.ToInt32(_DT.Rows[i]["ID_Locatario"]);
                    Locacao_Locatario.Descricao_Locatario = _DT.Rows[i]["Descricao"].ToString();
                    lst_Locatario.Add(Locacao_Locatario);
                }
                Carrega_Locatario();
            }
            #endregion

            #region FIADOR
            _DT = new DataTable();

            _DT = BLL_Imovel_Locacao.Busca_Fiador(Locacao);
            if (_DT.Rows.Count > 0)
            {
                lst_Fiador = new List<DTO_Locacao_Fiador>();
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Locacao_Fiador = new DTO_Locacao_Fiador();

                    Locacao_Fiador.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    Locacao_Fiador.ID_Fiador = Convert.ToInt32(_DT.Rows[i]["ID_Fiador"]);
                    Locacao_Fiador.Descricao_Fiador = _DT.Rows[i]["Descricao"].ToString();
                    lst_Fiador.Add(Locacao_Fiador);
                }
                Carrega_Fiador();
            }
            #endregion
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Imovel_Locacao = new BLL_Imovel_Locacao();
                Locacao = new DTO_Locacao();

                Locacao.ID = util_dados.Verifica_int(txt_ID.Text);
                Locacao.ID_Imovel = Convert.ToInt32(util_dados.Verifica_int(cb_ID_Imovel.SelectedValue.ToString()));
                Locacao.Data = Convert.ToDateTime(mk_Data.Text);
                Locacao.Inicio = Convert.ToDateTime(mk_Inicio.Text);
                Locacao.Termino = Convert.ToDateTime(mk_Termino.Text);
                Locacao.DiaVencimento = Convert.ToInt32(txt_DiaVencimento.Text);
                Locacao.Valor = Convert.ToDouble(txt_Valor.Text);
                Locacao.Descricao_Test1 = txt_Descricao_Test1.Text;
                Locacao.Descricao_Test2 = txt_Descricao_Test2.Text;
                Locacao.Doc_Test1 = txt_Doc_Test1.Text;
                Locacao.Doc_Test2 = txt_Doc_Test2.Text;
                Locacao.Observacao = txt_Observacao.Text;

                Locacao.Locatario = lst_Locatario;
                Locacao.Fiador = lst_Fiador;

                obj = BLL_Imovel_Locacao.Grava(Locacao);

                if (obj > 0)
                {
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
            BLL_Imovel_Locacao = new BLL_Imovel_Locacao();
            Locacao = new DTO_Locacao();

            Locacao.ID = util_dados.Verifica_int(txt_ID_P.Text);
            Locacao.Consulta_Periodo.Inicial = Convert.ToDateTime(mk_Inicio_P.Text);
            Locacao.Consulta_Periodo.Final = Convert.ToDateTime(mk_Termino_P.Text);

            DataTable _DT = new DataTable();
            _DT = BLL_Imovel_Locacao.Busca(Locacao);
            DG.DataSource = _DT;
            util_dados.CarregaCampo(this, _DT, gb_Cadastro);
        }

        public override void Novo()
        {
            Limpa_Campo();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Locacao_Load(object sender, EventArgs e)
        {
            Inicia_Form();

        }

        private void UI_Locacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_DiaVencimento.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumInteiro(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Valor.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }


        }

        private void UI_Locacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
            {
                Pesquisa();
                Status = StatusForm.Consulta;
                Config_Botao();
            }
        }
        #endregion

        #region TEXTBOX
        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Valor.Text) == 0)
                txt_Valor.Text = "0,00";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) > 0)
                Busca_Locacao(util_dados.Verifica_int(txt_ID.Text));
        }
        #endregion

        #region MASKEDBOX
        private void mk_Data_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data.Text = Convert.ToString(DateTime.Now);
                mk_Data.Focus();
            }
           
        }

        private void mk_Inicio_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Inicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Inicio.Text = Convert.ToString(DateTime.Now);
                mk_Inicio.Focus();
            }
           
        }

        private void mk_Termino_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Termino.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Termino.Text = Convert.ToString(DateTime.Now);
                mk_Termino.Focus();
            }
           
        }

        private void mk_Inicio_P_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Inicio_P.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Inicio_P.Text = Convert.ToString(DateTime.Now);
                mk_Inicio_P.Focus();
            }
           
        }

        private void mk_Termino_P_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Termino_P.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Termino_P.Text = Convert.ToString(DateTime.Now);
                mk_Termino_P.Focus();
            }
           
        }
        #endregion

        #region BUTTON
        private void bt_add_Locatario_Click(object sender, EventArgs e)
        {
            if (lst_Locatario == null)
                lst_Locatario = new List<DTO_Locacao_Locatario>();

            Locacao_Locatario = new DTO_Locacao_Locatario();
            Locacao_Locatario.ID_Locatario = Convert.ToInt32(cb_ID_Locatario.SelectedValue);
            Locacao_Locatario.Descricao_Locatario = cb_ID_Locatario.Text;

            lst_Locatario.Add(Locacao_Locatario);
            Carrega_Locatario();
        }

        private void bt_Remove_Locatario_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                if (lst_Locatario != null)
                {
                    if (lst_Locatario[dg_Locatario.CurrentRow.Index].ID != 0)
                    {
                        BLL_Imovel_Locacao = new BLL_Imovel_Locacao();
                        Locacao = new DTO_Locacao();
                        Locacao_Locatario = new DTO_Locacao_Locatario();
                        Locacao.Locatario = new List<DTO_Locacao_Locatario>();

                        Locacao_Locatario.ID = lst_Locatario[dg_Locatario.CurrentRow.Index].ID;

                        Locacao.Locatario.Add(Locacao_Locatario);

                        BLL_Imovel_Locacao.Exclui_Locatario(Locacao);
                    }
                    lst_Locatario.RemoveAt(dg_Locatario.CurrentRow.Index);
                    Carrega_Locatario();
                }
        }

        private void bt_add_Fiador_Click(object sender, EventArgs e)
        {
            if (lst_Fiador == null)
                lst_Fiador = new List<DTO_Locacao_Fiador>();

            Locacao_Fiador = new DTO_Locacao_Fiador();
            Locacao_Fiador.ID_Fiador = Convert.ToInt32(cb_ID_Fiador.SelectedValue);
            Locacao_Fiador.Descricao_Fiador = cb_ID_Fiador.Text;

            lst_Fiador.Add(Locacao_Fiador);
            Carrega_Fiador();
        }

        private void cb_Remove_Fiador_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                if (lst_Fiador != null)
                {
                    if (lst_Fiador[dg_Fiador.CurrentRow.Index].ID != 0)
                    {
                        BLL_Imovel_Locacao = new BLL_Imovel_Locacao();
                        Locacao = new DTO_Locacao();
                        Locacao_Fiador = new DTO_Locacao_Fiador();
                        Locacao.Fiador = new List<DTO_Locacao_Fiador>();

                        Locacao_Fiador.ID = lst_Fiador[dg_Fiador.CurrentRow.Index].ID;

                        Locacao.Fiador.Add(Locacao_Fiador);

                        BLL_Imovel_Locacao.Exclui_Fiador(Locacao);
                    }
                    lst_Fiador.RemoveAt(dg_Fiador.CurrentRow.Index);
                    Carrega_Fiador();
                }
        }
        #endregion

        private void cb_ID_Imovel_Leave(object sender, EventArgs e)
        {
            if (cb_ID_Imovel.SelectedValue == null)
                return;

            BLL_Imovel = new BLL_Imovel();
            Imovel = new DTO_Imovel();

            Imovel.ID = util_dados.Verifica_int(cb_ID_Imovel.SelectedValue.ToString());
            
            DataTable _DT = new DataTable();

            _DT = BLL_Imovel.Busca(Imovel);
            if (_DT.Rows.Count > 0)
                txt_Valor.Text = util_dados.ConfigNumDecimal(_DT.Rows[0]["Valor"].ToString(), 2);
        }
    }
}
