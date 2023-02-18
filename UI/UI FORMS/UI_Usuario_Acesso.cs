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
    public partial class UI_Usuario_Acesso : Sistema.UI.UI_Modelo
    {
        public UI_Usuario_Acesso()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Usuario_Acesso BLL_Usuario_Acesso;
        BLL_Usuario BLL_Usuario;
        #endregion

        #region VARIAVEIS DIVERSAS;
        DataTable DTPermissao;
        DataTable DTNivel;

        bool Atualiza = false;
        #endregion

        #region ESTRUTURA
        DTO_Usuario_Parametros Usuario_Parametros;
        DTO_Usuario Usuario;
        #endregion

        #region ROTINAS
        private void Carrega_CB()
        {
            BLL_Usuario = new BLL_Usuario();
            Usuario = new DTO_Usuario();
            Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();

            _DT = BLL_Usuario.Busca_Nome(Usuario);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Usuario);
        }

        private void Inicia_Form()
        {
            this.Text = "PERMISSÕES DE ACESSO";

            tabctl.TabPages.Remove(TabPage2);

            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
            bt_Exclui.Visible = false;
            bt_Pesquisa.Visible = false;
            bt_Novo.Visible = false;
            bt_Grava.Visible = false;
            bt_Edita.Visible = false;

            AtualizaGrupo();

            Carrega_CB();
        }

        private void AtualizaGrupo()
        {
            ListViewGroup grupo1 = default(ListViewGroup);
            ListViewItem item1 = default(ListViewItem);
            ListViewItem item2 = default(ListViewItem);
            ListViewItem item3 = default(ListViewItem);

            lts_menu.Columns.Add("Permissões", 150, HorizontalAlignment.Left);
            lts_menu.Columns.Add("SubMenu", 140, HorizontalAlignment.Left);
            lts_menu.Columns.Add("SubMenu", 140, HorizontalAlignment.Left);
            lts_menu.Columns.Add("SubMenu", 140, HorizontalAlignment.Left);
            lts_menu.Columns.Add("SubMenu", 140, HorizontalAlignment.Left);
            lts_menu.Columns.Add("SubMenu", 140, HorizontalAlignment.Left);

            UI_MDI frm = new UI_MDI();
            foreach (ToolStripMenuItem Control in frm.menu_Principal.Items)
            {
                grupo1 = new ListViewGroup(Control.Text.Replace("&", "").Trim());

                item1 = new ListViewItem(Control.Text.Replace("&", "").Trim(), grupo1);
                lts_menu.Groups.AddRange(new ListViewGroup[] { grupo1 });
                item1.Tag = Control.Name;
                lts_menu.Items.AddRange(new ListViewItem[] { item1 });

                AtualizaPermissao(lts_menu.Items.Count, Control.Name);
                foreach (ToolStripMenuItem subItem in Control.DropDownItems)
                {
                    item2 = new ListViewItem(subItem.Text.Replace("&", "").Trim(), grupo1);
                    item2.Tag = subItem.Name;
                    lts_menu.Items.AddRange(new ListViewItem[] { item2 });
                    item1.SubItems.Add(subItem.Text.Replace("&", "").Trim());
                       AtualizaPermissao(lts_menu.Items.Count, subItem.Name);
                    foreach (ToolStripItem subitem1 in subItem.DropDownItems)
                    {
                        if (!(subitem1 is ToolStripSeparator))
                        {
                            item3 = new ListViewItem(subitem1.Text.Replace("&", "").Trim(), grupo1);
                            item2.SubItems.Add(subitem1.Text.Replace("&", "").Trim());
                            item3.Tag = subitem1.Name;
                            lts_menu.Items.AddRange(new ListViewItem[] { item3 });
                           AtualizaPermissao(lts_menu.Items.Count, subitem1.Name);
                        }
                    }
                }
            }
            Atualiza = true;
        }

        private void AtualizaPermissao(int count, string control)
        {
            DataRow[] DR = null ;
            string expression = "Menu = '" + control.Trim() + "'";

            try
            {

                DTPermissao.Select(expression);
                DR = DTPermissao.Select(expression);
                if (DR.Length > 0)
                {
                    lts_menu.Items[count].Checked = true;
                }
                else
                {
                    lts_menu.Items[count].Checked = false;
                }

            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region FORM
        private void UI_Usuario_Acesso_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region LISTVIEW
        private void lts_menu_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            BLL_Usuario_Acesso = new BLL_Usuario_Acesso();
            Usuario_Parametros = new DTO_Usuario_Parametros();

            if (Atualiza == false)
                return;
            try
            {
                if (e.Item.Checked == true)
                {
                    Usuario_Parametros.ID_Usuario = Convert.ToInt32(cb_Usuario.SelectedValue);
                    Usuario_Parametros.Menu = Convert.ToString(e.Item.Tag);

                    BLL_Usuario_Acesso.Grava(Usuario_Parametros);
                }
                else
                {
                    Usuario_Parametros.ID_Usuario = Convert.ToInt32(cb_Usuario.SelectedValue);
                    Usuario_Parametros.Menu = Convert.ToString(e.Item.Tag);

                    BLL_Usuario_Acesso.Exclui(Usuario_Parametros);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }
        #endregion

        #region COMBOBOX
        private void cb_Usuario_Leave(object sender, EventArgs e)
        {
            if (cb_Usuario.SelectedValue.GetType() != typeof(int))
                return;
            txt_ID.Text = Convert.ToString(cb_Usuario.SelectedValue);

            BLL_Usuario_Acesso = new BLL_Usuario_Acesso();
            Usuario_Parametros = new DTO_Usuario_Parametros();

            Usuario_Parametros.ID_Usuario = util_dados.Verifica_int(txt_ID.Text);
            Usuario_Parametros.Menu = string.Empty;

            DTPermissao = BLL_Usuario_Acesso.Busca(Usuario_Parametros);

            Atualiza = false;

            for (int i = 0; i <= lts_menu.Items.Count - 1; i++)
                AtualizaPermissao(i, (string)lts_menu.Items[i].Tag);

            Atualiza = true;
        }
        #endregion
    }
}
