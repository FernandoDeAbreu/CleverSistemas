using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_NFe_Importacao : Form
    {
        public UI_NFe_Importacao()
        {
            InitializeComponent();
        }

        #region Propriedades
        public DTO_NF_Importacao _Importacao { get; set; }
        #endregion

        #region Variaveis de Classe
        BLL_Municipio BLL_Municipio;
        #endregion

        #region Estrutura
        DTO_NF_Adicao Adicao;
        List<DTO_NF_Adicao> List_Adicao;
        DTO_NF_Importacao Importacao;
        DTO_Municipio Municipio;
        #endregion

        #region Variaveis Diversas
        bool Edita_Adi = false;

        int Row_Adi = 0;

        DateTime ValidaData;

        DataTable DT;
        #endregion

        #region Propriedades
        public DTO_NF_Referenciada NF_Referenciada { get; set; }
        #endregion

        #region Rotinas
        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is TextBoxBase)
                {
                    ((TextBoxBase)sender).SelectAll();
                }
            });
        }

        private void DelegateEnterFocus(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is TextBoxBase))
            {
                ctrl.Enter += SelectText_Enter;
                return;
            }
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocus(ctrlChild);
            }
        }

        private void CarregaCB()
        {
            BLL_Municipio = new BLL_Municipio();
            Municipio = new DTO_Municipio();
            DT = BLL_Municipio.Busca_UF(Municipio);

            util_dados.CarregaCombo(DT, "Sigla", "ID_UF", cb_UF);
            cb_UF.SelectedIndex = 0;
        }
        #endregion

        #region Form
        private void frm_NF_DeclaracaoImportacao_Load(object sender, EventArgs e)
        {
            CarregaCB();
        }

        private void frm_NF_DeclaracaoImportacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.DelegateEnterFocus(this);

            if (txt_Num_Adi.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (txt_Desc_Adi.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumDecimal(KeyAscii);
                if (KeyAscii == 0)
                    e.Handled = true;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region TextBox
        private void txt_Desc_Adi_Leave(object sender, EventArgs e)
        {
            if (txt_Desc_Adi.Text == string.Empty)
                txt_Desc_Adi.Text = "0";
            txt_Desc_Adi.Text = util_dados.ConfigNumDecimal(txt_Desc_Adi.Text, 2);
        }
        #endregion

        #region Button
        private void bt_Adiciona_Click(object sender, EventArgs e)
        {
            int aux = 0;
            if (Edita_Adi == false)
            {
                aux = dg_Adi.Rows.Count;
                dg_Adi.Rows.Add();

                dg_Adi.Rows[aux].Cells["col_ID_Adi"].Value = 0;
                dg_Adi.Rows[aux].Cells["col_Num_Adi"].Value = txt_Num_Adi.Text;
                dg_Adi.Rows[aux].Cells["col_Fabri_Adi"].Value = txt_Fabri_Adi.Text;
                dg_Adi.Rows[aux].Cells["col_Desc_Adi"].Value = txt_Desc_Adi.Text;
            }
            else
            {
                dg_Adi.Rows[Row_Adi].Cells["col_ID_Adi"].Value = txt_ID_Adi.Text;
                dg_Adi.Rows[Row_Adi].Cells["col_Num_Adi"].Value = txt_Num_Adi.Text;
                dg_Adi.Rows[Row_Adi].Cells["col_Fabri_Adi"].Value = txt_Fabri_Adi.Text;
                dg_Adi.Rows[Row_Adi].Cells["col_Desc_Adi"].Value = txt_Desc_Adi.Text;
            }
            Row_Adi = 0;
            Edita_Adi = false;
            util_dados.LimpaCampos(this, gb_Adi);
            txt_Desc_Adi.Text = "0,00";
        }

        private void bt_Edita_Adi_Click(object sender, EventArgs e)
        {
            if (dg_Adi.Rows.Count > 0)
            {
                Edita_Adi = true;
                Row_Adi = dg_Adi.CurrentRow.Index;

                txt_ID_Adi.Text = dg_Adi.Rows[Row_Adi].Cells["col_ID_Adi"].Value.ToString();
                txt_Num_Adi.Text = dg_Adi.Rows[Row_Adi].Cells["col_Num_Adi"].Value.ToString();
                txt_Fabri_Adi.Text = dg_Adi.Rows[Row_Adi].Cells["col_Fabri_Adi"].Value.ToString();
                txt_Desc_Adi.Text = dg_Adi.Rows[Row_Adi].Cells["col_Desc_Adi"].Value.ToString();
            }
        }

        private void bt_Exclui_Adi_Click(object sender, EventArgs e)
        {
            if (dg_Adi.Rows.Count > 0)
                return;

            DialogResult msgbox = MessageBox.Show("Confirma Exclusão de Registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            if (util_dados.Verifica_int(dg_Adi.Rows[dg_Adi.CurrentRow.Index].Cells["col_ID_Adi"].Value.ToString().Trim()) > 0)
            {
            }

            dg_Adi.Rows.RemoveAt(dg_Adi.CurrentRow.Index);
        }

        private void bt_Adicionar_Click(object sender, EventArgs e)
        {
            Importacao = new DTO_NF_Importacao();
            Importacao.Adicao = new List<DTO_NF_Adicao>();

            if (dg_Adi.Rows.Count > 0)
            {
                for (int i = 0; i <= dg_Adi.Rows.Count - 1; i++)
                {
                    Adicao = new DTO_NF_Adicao();
                    Adicao.ID = Convert.ToInt32(dg_Adi.Rows[i].Cells["col_ID_Adi"].Value);
                    Adicao.Numero = Convert.ToInt32(dg_Adi.Rows[i].Cells["col_Num_Adi"].Value);
                    Adicao.Codigo = dg_Adi.Rows[i].Cells["col_Fabri_Adi"].Value.ToString();
                    Adicao.Desconto = Convert.ToDouble(dg_Adi.Rows[i].Cells["col_Desc_Adi"].Value);
                    Importacao.Adicao.Add(Adicao);
                }
            }

            Importacao.Documento = txt_Doc.Text;
            Importacao.Data_Registro = Convert.ToDateTime(mk_Data_Registro.Text);
            Importacao.Local = txt_Local.Text;
            Importacao.UF = Convert.ToInt32(cb_UF.SelectedValue);
            Importacao.Data_Desen = Convert.ToDateTime(mk_Data_Desen.Text);
            Importacao.Codigo = txt_Exportador.Text;

            _Importacao = Importacao;
            this.Close();
        }
        #endregion

        #region MaskedBox
        private void mk_Data_Registro_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data_Registro.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data_Registro.Text = Convert.ToString(DateTime.Now);
                mk_Data_Registro.Focus();
            }
           
        }

        private void mk_Data_Desen_Leave(object sender, EventArgs e)
        {
            DateTime.TryParseExact(mk_Data_Desen.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
            if (ValidaData == DateTime.MinValue)
            {
                MessageBox.Show("Data Inválida!", "Erro");
                mk_Data_Desen.Text = Convert.ToString(DateTime.Now);
                mk_Data_Desen.Focus();
            }
           
        }
        #endregion

      
    }
}
