using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_Boleto_Remessa : Sistema.UI.UI_Modelo
    {
        public UI_Boleto_Remessa()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Cedente BLL_Cedente;
        BLL_Boleto BLL_Boleto;
        #endregion

        #region ESTRUTURA
        DTO_Cedente Cedente;
        DTO_Boleto Boleto;
        #endregion

        #region VARIAVEIS DIVERSAS
        bool Seleciona = false;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "COBRANÇA BANCÁRIA - REMESSA";

            dg_BoletoRemessa.AutoGenerateColumns = false;

            CarregaCB();

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Novo.Visible = false;
            bt_Anterior.Visible = false;
            bt_Proximo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;
            bt_Exclui.Visible = false;

            tabctl.TabPages.Remove(TabPage2);

            tabctl.SelectedTab = TabPage1;

            cb_Cedente.SelectedIndex = 0;
        }

        private void CarregaCB()
        {
            DataTable _DT = new DataTable();

            BLL_Cedente = new BLL_Cedente();
            Cedente = new DTO_Cedente();
            Cedente.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Cedente.FiltraAtivo = true;
            Cedente.Ativo = true;

            _DT = new DataTable();
            _DT = BLL_Cedente.Busca(Cedente);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Cedente);
            cb_Cedente.SelectedIndex = 0;
        }

        private void Gerar_Remessa()
        {
            try
            {
                if (cb_Cedente.SelectedValue == null ||
                    util_dados.Verifica_int(cb_Cedente.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show(util_msg.msg_NenhumCedente, this.Text);
                    return;
                }

                DataTable _DT = new DataTable();

                #region GERAR REMESSA
                if (ck_GeradoRemessa.Checked == false)
                {
                    BLL_Boleto = new BLL_Boleto();
                    Boleto = new DTO_Boleto();

                    Boleto.Filtra_Remessa = true;
                    Boleto.Remessa = false;

                    Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                    Boleto.ID_Cedente = Convert.ToInt32(cb_Cedente.SelectedValue);

                    _DT = new DataTable();
                    _DT = BLL_Boleto.Busca(Boleto);

                    int aux = 0;

                    for (int i = 0; i <= dg_BoletoRemessa.Rows.Count - 1; i++)
                        if (Convert.ToBoolean(dg_BoletoRemessa.Rows[i].Cells["col_SelecionaRemessa"].Value) == true)
                            aux++;

                    Boleto.ID_Boleto = new int[aux];

                    aux = 0;

                    for (int i = 0; i <= dg_BoletoRemessa.Rows.Count - 1; i++)
                        if (Convert.ToBoolean(dg_BoletoRemessa.Rows[i].Cells["col_SelecionaRemessa"].Value) == true)
                        {
                            Boleto.ID_Boleto[aux] = Convert.ToInt32(dg_BoletoRemessa.Rows[i].Cells["col_ID_BoletoRemessa"].Value);
                            aux++;
                        }
                    
                    Boleto.Emissao = DateTime.Now;
                    Boleto.Movimento_Remessa = 1;
                    Boleto.Arquivo = _DT.Rows[0]["ID_Banco"].ToString().PadLeft(3, '0') + util_dados.Config_Data(DateTime.Now, 22);
                    Boleto.Remessa = true;
                    
                    int ID_Remessa = BLL_Boleto.Grava_Remessa(Boleto);

                    Boleto.ID_Remessa = ID_Remessa;

                    _DT = new DataTable();
                    _DT = BLL_Boleto.Busca_Remessa(Boleto);
                }
                #endregion
                else
                #region REGERAR ARQUIVO
                {
                    int ID_Remessa = util_dados.Verifica_int(dg_BoletoRemessa.Rows[dg_BoletoRemessa.CurrentRow.Index].Cells["col_Arquivo"].Value.ToString().Substring(0, 6));

                    Boleto.ID_Remessa = ID_Remessa;

                    _DT = new DataTable();
                    _DT = BLL_Boleto.Busca_Remessa(Boleto);
                }
                #endregion

                Remessa _Remessa = new Remessa();


                if (_DT.Rows.Count > 0)
                {
                    string Banco = _DT.Rows[0]["ID_Banco"].ToString().PadLeft(3, '0');

                    switch (Banco)
                    {
                        case "033": //SANTANDER
                            _Remessa.Gera_Arq_Remessa240_Santander(_DT, Convert.ToInt32(cb_Cedente.SelectedValue));
                            break;

                        case "237": //BRADESCO
                            _Remessa.Gera_Arq_Remessa400_Bradesco(_DT, Convert.ToInt32(cb_Cedente.SelectedValue));
                            break;

                        case "756": //SICOOB
                            _Remessa.Gera_Arq_Remessa240_Sicoob(_DT, Convert.ToInt32(cb_Cedente.SelectedValue));
                            break;
                    }


                    MessageBox.Show(util_msg.msg_ArquivoGerado, this.Text);

                    Pesquisa();
                }
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
            dg_BoletoRemessa.DataSource = null;

            BLL_Boleto = new BLL_Boleto();
            Boleto = new DTO_Boleto();

            Boleto.Filtra_Remessa = true;
            Boleto.Remessa = ck_GeradoRemessa.Checked;

            Boleto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Boleto.ID_Cedente = Convert.ToInt32(cb_Cedente.SelectedValue);

            DataTable _DT = new DataTable();

            if (ck_GeradoRemessa.Checked == false)
                _DT = BLL_Boleto.Busca(Boleto);
            else
                _DT = BLL_Boleto.Busca_Remessa(Boleto);

            dg_BoletoRemessa.DataSource = _DT;
        }
        #endregion


        #region FORM
        private void UI_Boleto_Remessa_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Boleto_Remessa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region BUTTON
        private void bt_GerarRemessa_Click(object sender, EventArgs e)
        {
            Gerar_Remessa();
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_BoletoRemessa_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_BoletoRemessa.Rows.Count - 1; i++)
                    dg_BoletoRemessa.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_BoletoRemessa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                try
                {
                    //Erase the cell
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    }


                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top + 1, e.CellBounds.Right, e.CellBounds.Top + 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);

                    Image imgChecked = (Image)UI.Properties.Resources._checked;
                    Image imgUnchecked = (Image)UI.Properties.Resources._unchecked;

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

        private void dg_BoletoRemessa_DoubleClick(object sender, EventArgs e)
        {
            if (dg_BoletoRemessa.Rows.Count == 0)
                return;

            if (Convert.ToBoolean(dg_BoletoRemessa.Rows[dg_BoletoRemessa.CurrentRow.Index].Cells["col_SelecionaRemessa"].Value) == true)
            {
                dg_BoletoRemessa.Rows[dg_BoletoRemessa.CurrentRow.Index].Cells["col_SelecionaRemessa"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_BoletoRemessa.Rows[dg_BoletoRemessa.CurrentRow.Index].Cells["col_SelecionaRemessa"].Value) == false)
                dg_BoletoRemessa.Rows[dg_BoletoRemessa.CurrentRow.Index].Cells["col_SelecionaRemessa"].Value = true;
        }
        #endregion


    }
}
