using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.UTIL;
using Sistema.BLL;

namespace Sistema.UI
{
    public partial class UI_Municipio : Sistema.UI.UI_Modelo
    {
        public UI_Municipio()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Municipio BLL_Municipio;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region PROPRIEDADES
        public int Tipo_Municipio { get; set; }
        #endregion

        #region ESTRUTURA
        DTO_Municipio Municipio;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            bt_Anterior.Visible = true;
            bt_Anterior.Enabled = true;

            bt_Proximo.Visible = true;
            bt_Proximo.Enabled = true;

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "DESCRIÇÃO";
            col_Descricao.Width = 400;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            switch (Tipo_Municipio)
            {
                case 1://PAÍS
                    lb_Pais.Visible = false;
                    lb_UF.Visible = false;
                    cb_Pais.Visible = false;
                    cb_UF.Visible = false;
                    lb_PaisP.Visible = false;
                    lb_UFP.Visible = false;
                    cb_PaisP.Visible = false;
                    cb_UFP.Visible = false;
                    lb_Descricao.Text = "PAÍS";
                    this.Text = "CADASTRO PAÍS";
                    this.txt_Codigo.Name = "txt_ID_Pais";
                    gb_Aliquota.Visible = false;
                    break;

                case 2://UF
                    lb_Pais.Visible = false;
                    lb_UF.Visible = false;
                    txt_Codigo.ReadOnly = false;
                    txt_Codigo.BackColor = Color.White;
                    cb_Pais.Visible = false;
                    cb_UF.Visible = false;
                    lb_PaisP.Visible = false;
                    lb_UFP.Visible = false;
                    cb_PaisP.Visible = false;
                    cb_UFP.Visible = false;
                    lb_Descricao.Text = "UF";
                    this.Text = "CADASTRO DE UF";
                    this.txt_Codigo.Name = "txt_ID_UF";
                    gb_Aliquota.Visible = true;
                    dg_Aliquota.AutoGenerateColumns = false;
                    break;
                case 3://MUNICÍPIO
                    AtualizaComboPais();
                    lb_Descricao.Text = "MUNICÍPIO";
                    this.Text = "CADASTRO DE MUNICÍPIO";
                    this.txt_Codigo.Name = "txt_ID_Municipio";
                    gb_Aliquota.Visible = false;
                    break;
            }
        }

        private void AtualizaComboPais()
        {
            BLL_Municipio = new BLL_Municipio();
            Municipio = new DTO_Municipio();

            DataTable _DT = new DataTable();
            _DT = BLL_Municipio.Busca_Pais(Municipio);
            util_dados.CarregaCombo(_DT, "Descricao", "ID_Pais", cb_Pais);
            cb_Pais.SelectedIndex = -1;

            _DT = new DataTable();
            _DT = BLL_Municipio.Busca_Pais(Municipio);
            util_dados.CarregaCombo(_DT, "Descricao", "ID_Pais", cb_PaisP);
            cb_PaisP.SelectedIndex = -1;
        }

        private void AtualizaComboEstado()
        {
            try
            {
                BLL_Municipio = new BLL_Municipio();
                Municipio = new DTO_Municipio();

                DataTable _DT = new DataTable();
                Municipio.ID_Pais = Convert.ToInt32(cb_Pais.SelectedValue);
                _DT = BLL_Municipio.Busca_UF(Municipio);
                util_dados.CarregaCombo(_DT, "Descricao", "ID_UF", cb_UF);
                cb_UF.SelectedIndex = -1;

                _DT = new DataTable();
                Municipio.ID_Pais = Convert.ToInt32(cb_PaisP.SelectedValue);
                _DT = BLL_Municipio.Busca_UF(Municipio);
                util_dados.CarregaCombo(_DT, "Descricao", "ID_UF", cb_UFP);
                cb_UFP.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Busca_Aliquota()
        {
            try
            {
                dg_Aliquota.DataSource = null;

                BLL_Municipio = new BLL_Municipio();
                Municipio = new DTO_Municipio();

                DataTable _DT = new DataTable();

                Municipio.ID_UF_Origem = Convert.ToInt32(txt_Codigo.Text);
                Municipio.Tipo_Consulta = 2;
                _DT = BLL_Municipio.Busca_UF_Aliquota_Inter(Municipio);

                if (_DT.Rows.Count > 0)
                    dg_Aliquota.DataSource = _DT;
                else
                {
                    _DT = new DataTable();
                    Municipio.Tipo_Consulta = 3;
                    _DT = BLL_Municipio.Busca_UF_Aliquota_Inter(Municipio);

                    dg_Aliquota.DataSource = _DT;
                }
            }
            catch (Exception)
            {
            }
        }

        private List<DTO_UF_AliquotaICMS> Carrega_Aliquota()
        {
            List<DTO_UF_AliquotaICMS> _lst_AliquotaUF = new List<DTO_UF_AliquotaICMS>();
            DTO_UF_AliquotaICMS AliquotaUF;

            for (int i = 0; i <= dg_Aliquota.Rows.Count - 1; i++)
            {
                AliquotaUF = new DTO_UF_AliquotaICMS();

                AliquotaUF.ID_UF_Destino = Convert.ToInt32(dg_Aliquota.Rows[i].Cells["col_ID_UF_Destino"].Value);
                AliquotaUF.Aliquota = Convert.ToDouble(dg_Aliquota.Rows[i].Cells["col_Aliquota"].Value);

                _lst_AliquotaUF.Add(AliquotaUF);
            }

            return _lst_AliquotaUF;
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                switch (Tipo_Municipio)
                {
                    case 1: //PAÍS
                        BLL_Municipio = new BLL_Municipio();
                        Municipio = new DTO_Municipio();

                        Municipio.ID = util_dados.Verifica_int(txt_ID.Text);
                        Municipio.ID_Pais = util_dados.Verifica_int(txt_Codigo.Text);
                        Municipio.Descricao = txt_Descricao.Text;

                        obj = BLL_Municipio.Grava_Pais(Municipio);

                        if (obj > 0)
                        {
                            Config(StatusForm.Consulta);
                            txt_ID.Text = obj.ToString();
                            MessageBox.Show(util_msg.msg_Grava, this.Text);
                        }
                        break;

                    case 2://UF
                        BLL_Municipio = new BLL_Municipio();
                        Municipio = new DTO_Municipio();

                        Municipio.ID = util_dados.Verifica_int(txt_ID.Text);
                        Municipio.ID_UF = util_dados.Verifica_int(txt_Codigo.Text);
                        Municipio.Aliquota_Interna = Convert.ToDouble(txt_Aliquota_Interna.Text);
                        Municipio.Aliquota_FCP = Convert.ToDouble(txt_Aliquota_FCP.Text);

                        Municipio._lst_AliquotaICMS = Carrega_Aliquota();

                        obj = BLL_Municipio.Grava_UF(Municipio);

                        if (obj > 0)
                        {
                            Config(StatusForm.Consulta);
                            txt_ID.Text = obj.ToString();
                            MessageBox.Show(util_msg.msg_Grava, this.Text);
                        }
                        break;

                    case 3://MUNICÍPIO
                        BLL_Municipio = new BLL_Municipio();
                        Municipio = new DTO_Municipio();

                        Municipio.ID = util_dados.Verifica_int(txt_ID.Text);
                        Municipio.ID_Municipio = util_dados.Verifica_int(txt_Codigo.Text);
                        Municipio.ID_Pais = Convert.ToInt32(cb_Pais.SelectedValue);
                        Municipio.ID_UF = Convert.ToInt32(cb_UF.SelectedValue);
                        Municipio.Descricao = txt_Descricao.Text;

                        obj = BLL_Municipio.Grava_Municipio(Municipio);
                        if (obj > 0)
                        {
                            Config(StatusForm.Consulta);
                            txt_ID.Text = obj.ToString();
                            MessageBox.Show(util_msg.msg_Grava, this.Text);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Pesquisa()
        {
            DataTable _DT = new DataTable();

            switch (Tipo_Municipio)
            {
                case 1:
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_Pais = util_dados.Verifica_int(txt_CodigoP.Text);
                    Municipio.Descricao = txt_DescricaoP.Text;

                    _DT = BLL_Municipio.Busca_Pais(Municipio);
                    DG.DataSource = _DT;
                    util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                    tabctl.SelectedTab = TabPage2;
                    break;

                case 2:
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_Pais = Convert.ToInt32(cb_PaisP.SelectedValue);
                    Municipio.ID_UF = util_dados.Verifica_int(txt_CodigoP.Text);
                    Municipio.Descricao = txt_DescricaoP.Text;

                    _DT = BLL_Municipio.Busca_UF(Municipio);
                    DG.DataSource = _DT;
                    util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                    util_dados.CarregaCampo(this, _DT, gb_Aliquota);
                    tabctl.SelectedTab = TabPage2;
                    break;

                case 3:
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_Pais = Convert.ToInt32(cb_PaisP.SelectedValue);
                    Municipio.ID_UF = Convert.ToInt32(cb_UFP.SelectedValue);
                    Municipio.ID_Municipio = util_dados.Verifica_int(txt_CodigoP.Text);
                    Municipio.Descricao = txt_DescricaoP.Text;

                    _DT = BLL_Municipio.Busca_Municipio(Municipio);
                    DG.DataSource = _DT;
                    util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                    tabctl.SelectedTab = TabPage2;
                    break;
            }
        }

        public override void Excluir()
        {
            DialogResult msgbox;

            try
            {
                switch (Tipo_Municipio)
                {
                    case 1:
                        msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msgbox == DialogResult.No)
                            return;

                        BLL_Municipio = new BLL_Municipio();
                        Municipio = new DTO_Municipio();

                        Municipio.ID_Pais = util_dados.Verifica_int(txt_Codigo.Text);
                        BLL_Municipio.Exclui_Pais(Municipio);
                        break;

                    case 3:
                        msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msgbox == DialogResult.No)
                            return;

                        BLL_Municipio = new BLL_Municipio();
                        Municipio = new DTO_Municipio();

                        Municipio.ID = util_dados.Verifica_int(txt_ID.Text);
                        BLL_Municipio.Exclui_Municipio(Municipio);
                        break;
                }
                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM
        private void UI_Municipio_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Municipio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
            tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F4)
                tabctl.SelectedTab = TabPage1;
        }

        private void UI_Municipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Aliquota_FCP.Focused == true ||
            txt_Aliquota_Interna.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        #endregion

        #region COMBOBOX
        private void cb_Pais_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaComboEstado();
        }

        private void cb_PaisP_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaComboEstado();
        }
        #endregion
        
        #region TEXTBOX
        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            if (Tipo_Municipio == 2)
                Busca_Aliquota();
        }

        private void txt_Aliquota_Interna_Leave(object sender, EventArgs e)
        {
            txt_Aliquota_Interna.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Aliquota_Interna.Text), 2);
        }

        private void txt_Aliquota_FCP_Leave(object sender, EventArgs e)
        {
            txt_Aliquota_FCP.Text = util_dados.ConfigNumDecimal(util_dados.Verifica_Double(txt_Aliquota_FCP.Text), 2);
        }
        #endregion

    }
}
