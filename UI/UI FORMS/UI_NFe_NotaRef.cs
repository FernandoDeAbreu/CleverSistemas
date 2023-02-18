using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_NFe_NotaRef : Form
    {
        public UI_NFe_NotaRef()
        {
            InitializeComponent();
        }

        #region PROPRIEDADES
        public bool Edita { get; set; }
        public int _indexEdita { get; set; }
        public NF_Tipo_Ref Tipo { get; set; }
        public List<DTO_NF_Referenciada> lst_NF_Referenciada { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "NOTA REFERENCIADA";

            if (lst_NF_Referenciada == null)
                lst_NF_Referenciada = new List<DTO_NF_Referenciada>();

            cb_UF.SelectedIndex = 0;

            if (Edita == false)
                switch (Tipo)
                {
                    case NF_Tipo_Ref.NFe:
                    case NF_Tipo_Ref.CTE:
                        gb_Chave.Visible = true;
                        break;

                    case NF_Tipo_Ref.NotaFiscal:
                        gb_Notas.Visible = true;
                        break;

                    case NF_Tipo_Ref.CupomFiscal:
                        gb_ECF.Visible = true;
                        break;
                }
            
            if (Edita == true)
                switch (lst_NF_Referenciada[_indexEdita].Tipo)
                {
                    case 1: //NF-E
                        Tipo = NF_Tipo_Ref.NFe;
                        gb_Chave.Visible = true;
                        txt_Chave.Text = lst_NF_Referenciada[_indexEdita].Chave_NFe;
                        break;

                    case 2: //NOTA FISCAL
                        Tipo = NF_Tipo_Ref.NotaFiscal;
                        gb_Notas.Visible = true;
                        txt_Serie.Text = lst_NF_Referenciada[_indexEdita].Serie;
                        txt_ID_NFe.Text = lst_NF_Referenciada[_indexEdita].Numero_NF;
                        mk_DataEmissao.Text = lst_NF_Referenciada[_indexEdita].DataEmissao.ToString();
                        cb_UF.SelectedValue = lst_NF_Referenciada[_indexEdita].UF;
                        txt_CNPJ_CPF.Text = lst_NF_Referenciada[_indexEdita].CNPJ_CPF;
                        break;

                    case 3: //NOTA FISCAL PRODUTOR
                        Tipo = NF_Tipo_Ref.NotaFiscal;
                        gb_Notas.Visible = true;
                        txt_Serie.Text = lst_NF_Referenciada[_indexEdita].Serie;
                        txt_ID_NFe.Text = lst_NF_Referenciada[_indexEdita].Numero_NF;
                        mk_DataEmissao.Text = lst_NF_Referenciada[_indexEdita].DataEmissao.ToString();
                        cb_UF.Text = lst_NF_Referenciada[_indexEdita].UF;
                        txt_CNPJ_CPF.Text = lst_NF_Referenciada[_indexEdita].CNPJ_CPF;
                        break;

                    case 4: //CTE-E
                        Tipo = NF_Tipo_Ref.CTE;
                        gb_Chave.Visible = true;
                        txt_Chave.Text = lst_NF_Referenciada[_indexEdita].Chave_NFe;
                        break;

                    case 5: //CUPOM FISCAL
                        Tipo = NF_Tipo_Ref.CupomFiscal;
                        gb_ECF.Visible = true;
                        txt_NumeroECF.Text = lst_NF_Referenciada[_indexEdita].ECF.ToString();
                        txt_NumeroContador.Text = lst_NF_Referenciada[_indexEdita].Numero_Contador.ToString();
                        cb_ModeloECF.SelectedValue = lst_NF_Referenciada[_indexEdita].Mod_CupomFiscal;
                        break;
                }
        }
        #endregion

        #region RADIONBUTTON
        private void rd_NotaFiscal_CheckedChanged(object sender, EventArgs e)
        {
            gb_Chave.Enabled = false;
            gb_Notas.Enabled = true;
        }

        private void rb_NFE_CheckedChanged(object sender, EventArgs e)
        {
            gb_Chave.Enabled = true;
            gb_Notas.Enabled = false;
        }

        private void rb_CTE_CheckedChanged(object sender, EventArgs e)
        {
            gb_Chave.Enabled = true;
            gb_Notas.Enabled = false;
        }
        #endregion

        #region FORM
        private void UI_NFe_NotaRef_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_NFe_NotaRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Chave.Focused == true ||
              txt_Serie.Focused == true ||
              txt_ID_NFe.Focused == true ||
              txt_NumeroECF.Focused == true ||
              txt_NumeroContador.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = (short)util_dados.NumInteiro(KeyAscii);
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

        #region BUTTON
        private void bt_Adicionar_Click(object sender, EventArgs e)
        {
            DTO_NF_Referenciada NF_Referenciada = new DTO_NF_Referenciada();

            if (Tipo == NF_Tipo_Ref.NFe)
                if (txt_Chave.Text.Length != 44)
                {
                    MessageBox.Show(util_msg.msg_ChaveIncorreta, this.Text);
                    return;
                }
                else
                {
                    NF_Referenciada.Tipo = 1;
                    NF_Referenciada.Chave_NFe = txt_Chave.Text;
                }

            if (Tipo == NF_Tipo_Ref.NotaFiscal)
                if (txt_Serie.Text.Length != 3 ||
                    txt_ID_NFe.Text == string.Empty ||
                    txt_CNPJ_CPF.Text == string.Empty ||
                    mk_DataEmissao.Text.Length != 5)
                {
                    MessageBox.Show(util_msg.msg_Dados_NotaIncorreto, this.Text);
                    return;
                }
                else
                {
                    NF_Referenciada.Tipo = 2;
                    NF_Referenciada.Serie = txt_Serie.Text;
                    NF_Referenciada.Numero_NF = txt_ID_NFe.Text;
                    NF_Referenciada.DataEmissao = Convert.ToDateTime(DateTime.ParseExact(mk_DataEmissao.Text, "MM/yy", null).ToString("dd/MM/yyyy"));
                    NF_Referenciada.UF = cb_UF.Text;
                    NF_Referenciada.CNPJ_CPF = txt_CNPJ_CPF.Text;
                }

            if (Tipo == NF_Tipo_Ref.CTE)
            {
                if (txt_Chave.Text.Length != 44)
                {
                    MessageBox.Show(util_msg.msg_ChaveIncorreta, this.Text);
                    return;
                }
                else
                {
                    NF_Referenciada.Tipo = 4;
                    NF_Referenciada.CTE = txt_Chave.Text;
                }
            }

            if (Tipo == NF_Tipo_Ref.CupomFiscal)
            {
                if (txt_NumeroECF.Text.Length != 3 ||
                    txt_NumeroContador.Text.Length != 6)
                {
                    MessageBox.Show(util_msg.msg_Dados_CupomIncorreto, this.Text);
                    return;
                }
                else
                {
                    NF_Referenciada.Tipo = 5;
                    NF_Referenciada.Mod_CupomFiscal = cb_ModeloECF.Text;
                    NF_Referenciada.Numero_Contador = txt_NumeroContador.Text;
                    NF_Referenciada.ECF = txt_NumeroECF.Text;
                }
            }

            if (Edita == true)
                lst_NF_Referenciada.RemoveAt(_indexEdita);

            lst_NF_Referenciada.Add(NF_Referenciada);

            this.Close();
        }
        #endregion

        #region TEXTBOX
        private void txt_CNPJ_CPF_Leave(object sender, EventArgs e)
        {
            if (util_dados.Conf_strDoc_NFe(txt_CNPJ_CPF.Text).Length == 11)
                txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CPF);

            if (util_dados.Conf_strDoc_NFe(txt_CNPJ_CPF.Text).Length == 14)
                txt_CNPJ_CPF.Text = util_dados.Conf_CPF_CNPJ(txt_CNPJ_CPF.Text, Documento.CNPJ);

            string CNPJ_CPF = util_dados.Conf_strDoc_NFe(txt_CNPJ_CPF.Text);

            if (CNPJ_CPF != string.Empty)
            {
                if (util_dados.Verifica_CPF_CNPJ(txt_CNPJ_CPF.Text) == false)
                {
                    MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
                    txt_CNPJ_CPF.Focus();
                    return;
                }
            }
            else
                MessageBox.Show(util_msg.msg_CPFCNPJ_Invalido, this.Text);
        }
        #endregion
    }
}
