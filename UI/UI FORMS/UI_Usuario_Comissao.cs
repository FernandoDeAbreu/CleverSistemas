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

namespace Sistema.UI
{
    public partial class UI_Usuario_Comissao : Sistema.UI.UI_Modelo
    {
        public UI_Usuario_Comissao()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Usuario BLL_Usuario;
        #endregion

        #region VARIAVEIS DIVERSAS
        string obj;

        DataRow DR;
        #endregion

        #region ESTRUTURA
        DTO_Usuario Usuario;
        DTO_Comissao Comissao;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            tabctl.TabPages.Remove(TabPage2);

            this.Text = "COMISSÃO DE USUÁRIO";

            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;

            dg_Comissao.AutoGenerateColumns = false;

            dg_Comissao.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Comissao.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Comissao.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;


            lb_Usuario.Text = Parametro_Venda.Descricao_Comissao;

            CarregaCB();
        }

        private void CarregaCB()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();

            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Usuario.Filtra_Comissao = true;
            Usuario.Comissao = true;

            Usuario.Filtra_Situacao = true;
            Usuario.Situacao = true;

            DataTable _DT = new DataTable();

            _DT = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Usuario);

            List<string> TipoComissao = new List<string>();
            TipoComissao.Add("VALOR");
            TipoComissao.Add("PORCENTAGEM");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, TipoComissao), "Descricao", "ID", cb_ID_TipoComissao);

            List<string> Tipo = new List<string>();
            Tipo.Add("DEFINIR");
            Tipo.Add("AUMENTAR");
            Tipo.Add("DIMINUIR");

            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(1, Tipo), "Descricao", "ID", cb_Tipo);

        }

        private void CarregaValor(DataTable DT, int Tipo)
        {
            switch (Tipo)
            {
                #region COMISSÃO
                case 1:
                    dg_Comissao.Rows.Clear();
                    if (DT.Columns.Count == 2)
                        for (int i = 0; i <= DT.Rows.Count - 1; i++)
                        {
                            dg_Comissao.Rows.Add();
                            dg_Comissao.Rows[i].Cells["col_DescricaoProduto"].Value = DT.Rows[i]["Produto"];
                            dg_Comissao.Rows[i].Cells["col_TipoComissao"].Value = "";
                            dg_Comissao.Rows[i].Cells["col_Comissao"].Value = 0;
                            dg_Comissao.Rows[i].Cells["col_ID_Comissao"].Value = 0;
                            dg_Comissao.Rows[i].Cells["col_ID_Produto"].Value = DT.Rows[i]["ID_Produto"];
                            dg_Comissao.Rows[i].Cells["col_ID_TipoComissao"].Value = 0;
                        }
                    else
                        for (int i = 0; i <= DT.Rows.Count - 1; i++)
                        {
                            dg_Comissao.Rows.Add();
                            dg_Comissao.Rows[i].Cells["col_DescricaoProduto"].Value = DT.Rows[i]["Produto"];
                            dg_Comissao.Rows[i].Cells["col_TipoComissao"].Value = DT.Rows[i]["TipoComissao"].ToString() == string.Empty ? "" : DT.Rows[i]["TipoComissao"];
                            dg_Comissao.Rows[i].Cells["col_Comissao"].Value = DT.Rows[i]["Comissao"].ToString() == string.Empty ? 0 : DT.Rows[i]["Comissao"];
                            dg_Comissao.Rows[i].Cells["col_ID_Comissao"].Value = DT.Rows[i]["ID"].ToString() == string.Empty ? 0 : DT.Rows[i]["ID"];
                            dg_Comissao.Rows[i].Cells["col_ID_Produto"].Value = DT.Rows[i]["ID_Produto"].ToString() == string.Empty ? 0 : DT.Rows[i]["ID_Produto"];
                            dg_Comissao.Rows[i].Cells["col_ID_TipoComissao"].Value = DT.Rows[i]["ID_TipoComissao"].ToString() == string.Empty ? 0 : DT.Rows[i]["ID_TipoComissao"];
                        }
                    break;
                #endregion
            }
        }

        private List<DTO_Comissao> Grava_Comissao()
        {
            Comissao = new DTO_Comissao();
            List<DTO_Comissao> _Comissao = new List<DTO_Comissao>();

            for (int i = 0; i <= dg_Comissao.Rows.Count - 1; i++)
            {
                Comissao = new DTO_Comissao();
                Comissao.ID = Convert.ToInt32(dg_Comissao.Rows[i].Cells["col_ID_Comissao"].Value);
                Comissao.ID_Produto = Convert.ToInt32(dg_Comissao.Rows[i].Cells["col_ID_Produto"].Value);
                Comissao.ID_TipoComissao = Convert.ToInt32(dg_Comissao.Rows[i].Cells["col_ID_TipoComissao"].Value);
                Comissao.Comissao = Convert.ToDouble(dg_Comissao.Rows[i].Cells["col_Comissao"].Value);
                _Comissao.Add(Comissao);
            }
            return _Comissao;
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_Confirma_Alteracao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();

                Usuario.lst_Comissao = Grava_Comissao();

                Usuario.ID = util_dados.Verifica_int(cb_ID_Usuario.SelectedValue.ToString());

                BLL_Usuario.Grava_Comissao(Usuario);

                MessageBox.Show(util_msg.msg_Grava, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Pesquisa()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();
            Usuario.ID = util_dados.Verifica_int(cb_ID_Usuario.SelectedValue.ToString());

            DataTable _DT = new DataTable();

            _DT = BLL_Usuario.Busca_Comissao(Usuario);
            CarregaValor(_DT, 1);
        }
        #endregion

        #region FORM
        private void UI_Usuario_Comissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Comissao.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumDecimal(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Usuario_Comissao_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region BUTTON
        private void bt_ComissaoUnico_Click(object sender, EventArgs e)
        {
            Double Comissao = 0;

            switch (Convert.ToInt32(cb_Tipo.SelectedValue))
            {
                case 1: //DEFINIR
                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_ID_TipoComissao"].Value = cb_ID_TipoComissao.SelectedValue;
                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_Comissao"].Value = Convert.ToDouble(txt_Comissao.Text);
                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_TipoComissao"].Value = cb_ID_TipoComissao.Text;

                    break;

                case 2: //AUMENTAR
                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_ID_TipoComissao"].Value = cb_ID_TipoComissao.SelectedValue;

                    Comissao = Convert.ToDouble(dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_Comissao"].Value) + Convert.ToDouble(txt_Comissao.Text);

                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_Comissao"].Value = Comissao;
                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_TipoComissao"].Value = cb_ID_TipoComissao.Text;

                    break;
                case 3: //DIMINUIR
                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_ID_TipoComissao"].Value = cb_ID_TipoComissao.SelectedValue;

                    Comissao = Convert.ToDouble(dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_Comissao"].Value) - Convert.ToDouble(txt_Comissao.Text);

                    if (Comissao < 0)
                        Comissao = 0;

                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_Comissao"].Value = Comissao;
                    dg_Comissao.Rows[dg_Comissao.CurrentRow.Index].Cells["col_TipoComissao"].Value = cb_ID_TipoComissao.Text;

                    break;
            }
        }

        private void bt_ComissaoTodos_Click(object sender, EventArgs e)
        {
            Double Comissao = 0;
            for (int i = 0; i <= dg_Comissao.Rows.Count - 1; i++)
                switch (Convert.ToInt32(cb_Tipo.SelectedValue))
                {
                    case 1: //DEFINIR
                        dg_Comissao.Rows[i].Cells["col_ID_TipoComissao"].Value = cb_ID_TipoComissao.SelectedValue;
                        dg_Comissao.Rows[i].Cells["col_Comissao"].Value = Convert.ToDouble(txt_Comissao.Text);
                        dg_Comissao.Rows[i].Cells["col_TipoComissao"].Value = cb_ID_TipoComissao.Text;

                        break;

                    case 2: //AUMENTAR
                        dg_Comissao.Rows[i].Cells["col_ID_TipoComissao"].Value = cb_ID_TipoComissao.SelectedValue;

                        Comissao = Convert.ToDouble(dg_Comissao.Rows[i].Cells["col_Comissao"].Value) + Convert.ToDouble(txt_Comissao.Text);

                        dg_Comissao.Rows[i].Cells["col_Comissao"].Value = Comissao;
                        dg_Comissao.Rows[i].Cells["col_TipoComissao"].Value = cb_ID_TipoComissao.Text;

                        break;
                    case 3: //DIMINUIR
                        dg_Comissao.Rows[i].Cells["col_ID_TipoComissao"].Value = cb_ID_TipoComissao.SelectedValue;

                        Comissao = Convert.ToDouble(dg_Comissao.Rows[i].Cells["col_Comissao"].Value) - Convert.ToDouble(txt_Comissao.Text);

                        if (Comissao < 0)
                            Comissao = 0;

                        dg_Comissao.Rows[i].Cells["col_Comissao"].Value = Comissao;
                        dg_Comissao.Rows[i].Cells["col_TipoComissao"].Value = cb_ID_TipoComissao.Text;

                        break;
                }
        }
        #endregion

        #region TEXTBOX
        private void txt_Comissao_Leave(object sender, EventArgs e)
        {
            if (txt_Comissao.Text == string.Empty)
                txt_Comissao.Text = "0";
            txt_Comissao.Text = util_dados.ConfigNumDecimal(txt_Comissao.Text, 2);
        }
        #endregion

        #region COMBOBOX
        private void cb_ID_Usuario_SelectedValueChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(cb_ID_Usuario.SelectedValue.ToString()) > 0)
                Pesquisa();
        }
        #endregion
    }
}
