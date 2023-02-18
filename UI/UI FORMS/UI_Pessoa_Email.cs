using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Pessoa_Email : Form
    {
        public UI_Pessoa_Email()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Municipio BLL_Municipio;
        BLL_Pessoa BLL_Pessoa;
        BLL_Usuario BLL_Usuario;
        BLL_Grupo BLL_Grupo;
        #endregion

        #region VARIAVEIS DIVERSAS
        DataTable DTUsuario;
        DataTable DTPais;
        DataTable DTUF;
        DataTable DTMunicipio;
        DataTable DTR_Pessoa;
        DataTable DTPessoa;

        DataRow DR;

        int tipoPessoa;

        bool Seleciona = false;
        #endregion

        #region PROPRIEDADES
        public string lst_Email { get; set; }
        #endregion

        #region ESTRUTURA
        DTO_Municipio Municipio;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Usuario Usuario;
        DTO_Grupo Grupo;
        DTO_Pessoa_Email Email;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            lb_Descricaotela.Text = "CONSULTA EMAIL";
            this.Text = "CONSULTA EMAIL";

            dg_Email.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Email.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Email.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            AtualizaComboPais();
            cb_Pais.SelectedValue = 1058;
            AtualizaComboEstado();

            DataTable _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
            cb_TipoPessoa.SelectedValue = 1;

            CarregaCB();
        }

        private void CarregaCB()
        {
            try
            {
                BLL_Usuario = new BLL_Usuario();
                Usuario = new DTO_Usuario();

                

                BLL_Grupo = new BLL_Grupo();
                Grupo = new DTO_Grupo();

                DataTable _DT = new DataTable();

                #region GRUPO PESSOA
                switch (Convert.ToInt32(cb_TipoPessoa.SelectedValue))
                {
                    case 1:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        Usuario.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                        Usuario.Filtra_Comissao = true;
                        Usuario.Comissao = true;

                        Usuario.Filtra_Situacao = true;
                        Usuario.Situacao = true;

                        DTUsuario = BLL_Usuario.Busca_Nome(Usuario);
                        util_dados.CarregaCombo(DTUsuario, "Descricao", "ID", cb_ID_Usuario);
                        cb_ID_Usuario.SelectedIndex = -1;

                        //CLIENTE
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Cliente);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;

                    case 2:
                        //EMPRESA
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Empresa);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;

                    case 3:
                        //Fornecedores
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Fornecedor);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;

                    case 4:
                        //Funcionarios
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Funcionario);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;

                    case 5:
                        //Transportadora
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Transportadora);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;
                }                
            }
            catch (Exception)
            {
            }
            #endregion
        }

        private void CarregaPessoa()
        {
            try
            {
                Pessoa = new DTO_Pessoa();
                BLL_Pessoa = new BLL_Pessoa();

                Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                Pessoa.FiltraSituacao = true;
                Pessoa.Situacao = true;

                DTPessoa = BLL_Pessoa.Busca_Nome(Pessoa);

                util_dados.CarregaCombo(DTPessoa, "Descricao", "ID", cb_ID_Pessoa);
                cb_ID_Pessoa.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            cb_TipoPessoa.SelectedValue = UI_Pessoa_Consulta.TipoPessoa;

            CarregaPessoa();

            cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
            cb_ID_Pessoa.Focus();
        }

        private void AtualizaComboPais()
        {
            BLL_Municipio = new BLL_Municipio();
            Municipio = new DTO_Municipio();

            DTPais = BLL_Municipio.Busca_Pais(Municipio);
            util_dados.CarregaCombo(DTPais, "Descricao", "ID_Pais", cb_Pais);
        }

        private void AtualizaComboEstado()
        {
            try
            {
                if (Convert.ToInt32(cb_Pais.SelectedValue) > 0)
                {
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_Pais = Convert.ToInt32(cb_Pais.SelectedValue);

                    DTUF = BLL_Municipio.Busca_UF(Municipio);
                    util_dados.CarregaCombo(DTUF, "Descricao", "ID_UF", cb_UF);
                    cb_UF.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void AtualizaComboMunicipio()
        {
            try
            {
                if (Convert.ToInt32(cb_UF.SelectedValue) > 0)
                {
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_UF = Convert.ToInt32(cb_UF.SelectedValue);

                    DTMunicipio = BLL_Municipio.Busca_Municipio(Municipio);
                    util_dados.CarregaCombo(DTMunicipio, "Descricao", "ID", cb_Municipio);
                    cb_Municipio.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
            }
        }
       
        private void CarregaPessoa(DataTable DT)
        {
            int aux = 0;
            dg_Email.Rows.Clear();

            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                dg_Email.Rows.Add();
                dg_Email.Rows[aux].Cells["col_Pessoa"].Value = DT.Rows[i]["Nome_Razao"];
                dg_Email.Rows[aux].Cells["col_NomeFantasia"].Value = DT.Rows[i]["NomeFantasia"];
                dg_Email.Rows[aux].Cells["col_Email"].Value = DT.Rows[i]["Email"];
                aux++;
            }
        }

        private string CarregaEmail()
        {
            string aux = "";
            for (int i = 0; i <= dg_Email.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Email.Rows[i].Cells["col_Seleciona"].Value) == true)
                    aux += dg_Email.Rows[i].Cells["col_Email"].Value.ToString() + "; ";

            return aux;
        }
        #endregion

        #region MODIFICADORES
        public void Localizar()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Endereco.ID_Municipio = Convert.ToInt32(cb_Municipio.SelectedValue);
            Pessoa.Endereco.Add(Endereco);

            Email.Principal = Convert.ToBoolean(ck_Principal.Checked);
            Pessoa.Email.Add(Email);

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            Pessoa.ID_Usuario = Convert.ToInt32(cb_ID_Usuario.SelectedValue);
            Pessoa.ID_Grupo = Convert.ToInt32(cb_ID_Grupo.SelectedValue);

            DTR_Pessoa = BLL_Pessoa.Busca_EmailEnvio(Pessoa);
            CarregaPessoa(DTR_Pessoa);
        }
        #endregion

        #region BUTTON
        private void bt_Pesquisa_Click(object sender, EventArgs e)
        {
            Localizar();
        }

        private void bt_Seleciona_Click(object sender, EventArgs e)
        {
            lst_Email = CarregaEmail();
            this.Close();
        }
        #endregion

        #region FORM
        private void UI_Pessoa_Email_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Pessoa_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Localizar();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();

        }

        private void UI_Pessoa_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }
        #endregion

        #region COMBOBOX
        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            CarregaCB();
            CarregaPessoa();
        }

        private void cb_Pais_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaComboEstado();
        }

        private void cb_UF_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaComboMunicipio();
        }

        private void cb_ID_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_ID_Usuario.SelectedIndex = -1;

        }

        private void cb_Municipio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                cb_Municipio.SelectedIndex = -1;

        }
        #endregion

        #region DATAGRID
        private void dg_Email_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Email.Rows.Count - 1; i++)
                    dg_Email.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Email_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        #endregion
    }
}
