using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.Reporting.WinForms;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Pessoa_Etiqueta : Sistema.UI.UI_Modelo
    {
        public UI_Pessoa_Etiqueta()
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
        DataRow DR;

        bool Seleciona = false;
        #endregion

        #region ESTRUTURA
        DTO_Municipio Municipio;
        DTO_Pessoa Pessoa;
        DTO_Pessoa_Endereco Endereco;
        DTO_Usuario Usuario;
        DTO_Grupo Grupo;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "ETIQUETA - PESSOAS";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Imprime.Visible = false;
            bt_Visualiza.Enabled = true;

            dg_Etiqueta.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Etiqueta.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Etiqueta.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Etiqueta.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Etiqueta.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Etiqueta.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dg_Etiqueta.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            CarregaCB();
            Carrega_UF();
        }

        private void CarregaCB()
        {
            List<string> _Etiqueta = new List<string>();
            _Etiqueta.Add("PIMACO 6280 A4");
            util_dados.CarregaCombo(util_dados.CarregaComboDinamico(_Etiqueta.Count, _Etiqueta), "Descricao", "ID", cb_Etiqueta);

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
            cb_ID_Usuario.SelectedIndex = -1;

            _DT = new DataTable();
            _DT = util_Param.Tipo_Pessoa();
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
        }

        private void Carrega_Grupo()
        {
            try
            {
                DataTable _DT = new DataTable();
                BLL_Grupo = new BLL_Grupo();
                Grupo = new DTO_Grupo();

                switch (util_dados.Verifica_int(cb_TipoPessoa.SelectedValue.ToString()))
                {
                    case 1: //CLIENTE
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Cliente);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;
                    case 2: //EMPRESA
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Empresa);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;
                    case 3: //FORNECEDOR
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Fornecedor);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;
                    case 4: //FUNCIONÁRIO
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Funcionario);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;
                    case 5: //TRANSPORTADORA
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Transportadora);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Grupo.SelectedIndex = -1;
                        break;

                    case 6: //RESPONSÁVEIS
                        Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Cliente);
                        _DT = BLL_Grupo.Busca(Grupo);
                        util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Grupo);
                        cb_ID_Usuario.SelectedIndex = -1;
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Carrega_UF()
        {
            try
            {
                BLL_Municipio = new BLL_Municipio();
                Municipio = new DTO_Municipio();

                DataTable _DT = new DataTable();
                _DT = BLL_Municipio.Busca_UF(Municipio);
                util_dados.CarregaCombo(_DT, "Descricao", "ID_UF", cb_UF);
                cb_UF.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        private void Carrega_Municipio()
        {
            try
            {
                if (Convert.ToInt32(cb_UF.SelectedValue) > 0)
                {
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_UF = Convert.ToInt32(cb_UF.SelectedValue);

                    DataTable _DT = new DataTable();
                    _DT = BLL_Municipio.Busca_Municipio(Municipio);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Municipio);
                    cb_Municipio.SelectedIndex = -1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Carrega_Pessoa(DataTable DT)
        {
            dg_Etiqueta.Rows.Clear();

            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                dg_Etiqueta.Rows.Add();
                dg_Etiqueta.Rows[i].Cells["col_ID_Pessoa"].Value = DT.Rows[i]["ID"];
                dg_Etiqueta.Rows[i].Cells["col_Descricao"].Value = DT.Rows[i]["Descricao"];
                dg_Etiqueta.Rows[i].Cells["col_Endereco"].Value = DT.Rows[i]["Logradouro"] + ", " + DT.Rows[i]["NumeroEndereco"];
                dg_Etiqueta.Rows[i].Cells["Col_Complemento"].Value = DT.Rows[i]["Complemento"];
                dg_Etiqueta.Rows[i].Cells["Col_Bairro"].Value = DT.Rows[i]["Bairro"];
                dg_Etiqueta.Rows[i].Cells["col_Cidade"].Value = DT.Rows[i]["NomeMunicipio"] + "-" + DT.Rows[i]["Sigla"];
                dg_Etiqueta.Rows[i].Cells["col_CEP"].Value = DT.Rows[i]["CEP"];
            }
        }

        private DataTable Carrega_DT()
        {
            bool Inicio = true;
            DataTable DT_Etiqueta = new DataTable("Etiqueta");
            DT_Etiqueta.Columns.Add("ID");
            DT_Etiqueta.Columns.Add("Descricao");
            DT_Etiqueta.Columns.Add("Endereco");
            DT_Etiqueta.Columns.Add("Complemento");
            DT_Etiqueta.Columns.Add("Bairro");
            DT_Etiqueta.Columns.Add("Cidade");
            DT_Etiqueta.Columns.Add("CEP");
            DT_Etiqueta.Clear();

            for (int i = 0; i <= dg_Etiqueta.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Etiqueta.Rows[i].Cells["col_Imprime"].Value) == true)
                    for (int x = 0; x <= Convert.ToInt32(txt_Qtd_Etiqueta.Text) - 1; x++)
                    {
                        if (util_dados.Verifica_int(txt_Inicio.Text) > 0 && Inicio == true)
                        {
                            for (int y = 0; y <= util_dados.Verifica_int(txt_Inicio.Text) - 1; y++)
                            {
                                DR = DT_Etiqueta.NewRow();
                                DR["ID"] = "";
                                DR["Descricao"] = "";
                                DR["Complemento"] = "";
                                DR["Endereco"] = "";
                                DR["Bairro"] = "";
                                DR["Cidade"] = "";
                                DR["CEP"] = "";

                                DT_Etiqueta.Rows.Add(DR);
                                DT_Etiqueta.AcceptChanges();
                            }
                            Inicio = false;
                        }

                        DR = DT_Etiqueta.NewRow();
                        DR["ID"] = dg_Etiqueta.Rows[i].Cells["col_ID_Pessoa"].Value;
                        DR["Descricao"] = dg_Etiqueta.Rows[i].Cells["col_Descricao"].Value;
                        DR["Endereco"] = dg_Etiqueta.Rows[i].Cells["col_Endereco"].Value;
                        DR["Complemento"] = dg_Etiqueta.Rows[i].Cells["Col_Complemento"].Value;
                        DR["Bairro"] = dg_Etiqueta.Rows[i].Cells["col_Bairro"].Value;
                        DR["Cidade"] = dg_Etiqueta.Rows[i].Cells["col_Cidade"].Value;
                        DR["CEP"] = dg_Etiqueta.Rows[i].Cells["col_CEP"].Value;

                        DT_Etiqueta.Rows.Add(DR);
                        DT_Etiqueta.AcceptChanges();
                    }

            return DT_Etiqueta;
        }
        #endregion

        #region MODIFICADORES
        public override void Pesquisa()
        {
            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            Endereco = new DTO_Pessoa_Endereco();

            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Endereco.ID_Municipio = Convert.ToInt32(cb_Municipio.SelectedValue);
            Pessoa.Endereco.Add(Endereco);
            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.Nome_Razao = txt_Descricao.Text;
            Pessoa.ID_Usuario = Convert.ToInt32(cb_ID_Usuario.SelectedValue);
            Pessoa.ID_Grupo = Convert.ToInt32(cb_ID_Grupo.SelectedValue);
            Pessoa.Classifica = 1;

            DataTable _DT = new DataTable();
            _DT = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
            Carrega_Pessoa(_DT);
        }

        public override void Visualizar()
        {
            DataTable _DT_Etiqueta = Carrega_DT();

            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            string rpt_Nome = string.Empty;

            if (cb_Etiqueta.Text == "PIMACO 6280 A4")
                rpt_Nome = "rpt_EtiquetaPessoa_6280.rdlc";


            if (rpt_Nome == string.Empty)
                return;

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            ReportDataSource ds_Produto = new ReportDataSource("ds_MalaDireta", _DT_Etiqueta);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Produto);

            frm_rpt.rpt_Viewer.RefreshReport();
            frm_rpt.Show();
        }
        #endregion

        #region FORM
        private void UI_Pessoa_Etiqueta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Pessoa_Etiqueta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Qtd_Etiqueta.Focused == true ||
                txt_Inicio.Focused == true)
            {
                short KeyAscii = (short)e.KeyChar;
                KeyAscii = Convert.ToInt16(util_dados.NumDecimal(KeyAscii));
                if (KeyAscii == 0)
                    e.Handled = true;
            }
        }

        private void UI_Pessoa_Etiqueta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Pesquisa();
        }
        #endregion

        #region COMBOBOX
        private void cb_UF_SelectedValueChanged(object sender, EventArgs e)
        {
            Carrega_Municipio();
        }

        private void cb_TipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            Carrega_Grupo();
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
        private void dg_Etiqueta_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_Etiqueta.Rows.Count - 1; i++)
                    dg_Etiqueta.Rows[i].Cells[0].Value = Seleciona;
            }
        }

        private void dg_Etiqueta_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dg_Etiqueta_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Convert.ToBoolean(dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Imprime"].Value) == true)
            {
                dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Imprime"].Value = false;
                return;
            }

            if (Convert.ToBoolean(dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Imprime"].Value) == false)
                dg_Etiqueta.Rows[dg_Etiqueta.CurrentRow.Index].Cells["col_Imprime"].Value = true;
        }
        #endregion

        #region TEXTBOX
        private void txt_Inicio_Leave(object sender, EventArgs e)
        {
            if (txt_Inicio.Text.Trim() == string.Empty)
                txt_Inicio.Text = "0";
        }

        private void txt_Qtd_Etiqueta_Leave(object sender, EventArgs e)
        {
            if (txt_Qtd_Etiqueta.Text.Trim() == string.Empty)
                txt_Qtd_Etiqueta.Text = "1";
        }
        #endregion
    }
}
