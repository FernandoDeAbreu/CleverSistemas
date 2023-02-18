using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;

namespace Sistema.UI
{
    public partial class UI_Pessoa_Relatorio : Sistema.UI.UI_Modelo
    {
        public UI_Pessoa_Relatorio()
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
        DataTable DT;

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
            this.Text = "RELATÓRIO - PESSOAS";

            tabctl.TabPages.Remove(TabPage2);

            bt_Exclui.Visible = false;
            bt_Novo.Visible = false;
            bt_Edita.Visible = false;
            bt_Grava.Visible = false;
            bt_Imprime.Enabled = true;
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
            _Etiqueta.Add("CADASTRO COMPLETO");
            _Etiqueta.Add("LISTA TELEFONE");
            _Etiqueta.Add("LISTA e-MAIL");
            _Etiqueta.Add("LISTA SIMPLES");
            _Etiqueta.Add("CORRESPONDÊNCIA");
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
                BLL_Grupo = new BLL_Grupo();
                Grupo = new DTO_Grupo();

                DataTable _DT = new DataTable();

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
            DataTable DT_Relatorio = new DataTable("Relatorio");
            DT_Relatorio.Columns.Add("ID");
            DT_Relatorio.Columns.Add("Descricao");
            DT_Relatorio.Columns.Add("NomeFantasia");
            DT_Relatorio.Columns.Add("CNPJ_CPF");
            DT_Relatorio.Columns.Add("IE_RG");
            DT_Relatorio.Columns.Add("Logradouro");
            DT_Relatorio.Columns.Add("NumeroEndereco");
            DT_Relatorio.Columns.Add("Bairro");
            DT_Relatorio.Columns.Add("NomeMunicipio");
            DT_Relatorio.Columns.Add("Sigla");
            DT_Relatorio.Columns.Add("CEP");
            DT_Relatorio.Columns.Add("DDD");
            DT_Relatorio.Columns.Add("NumeroTelefone");
            DT_Relatorio.Columns.Add("NumeroTelefoneCompleto");
            DT_Relatorio.Columns.Add("Email");
            DT_Relatorio.Columns.Add("Referencia");
            DT_Relatorio.Columns.Add("Mensalidade");
            DT_Relatorio.Columns.Add("Vencimento");

            DT_Relatorio.Clear();

            for (int i = 0; i <= dg_Etiqueta.Rows.Count - 1; i++)
                if (Convert.ToBoolean(dg_Etiqueta.Rows[i].Cells["col_Imprime"].Value) == true)
                {
                    DR = DT_Relatorio.NewRow();
                    DR["ID"] = DT.Rows[i]["ID"];
                    DR["Descricao"] = DT.Rows[i]["Descricao"];
                    DR["NomeFantasia"] = DT.Rows[i]["NomeFantasia"];
                    DR["CNPJ_CPF"] = DT.Rows[i]["CNPJ_CPF"];
                    DR["IE_RG"] = DT.Rows[i]["IE_RG"];
                    DR["Logradouro"] = DT.Rows[i]["Logradouro"];
                    DR["NumeroEndereco"] = DT.Rows[i]["NumeroEndereco"];
                    DR["Bairro"] = DT.Rows[i]["Bairro"];
                    DR["NomeMunicipio"] = DT.Rows[i]["NomeMunicipio"];
                    DR["Sigla"] = DT.Rows[i]["Sigla"];
                    DR["CEP"] = DT.Rows[i]["CEP"];
                    DR["DDD"] = DT.Rows[i]["DDD"];
                    DR["NumeroTelefone"] = DT.Rows[i]["NumeroTelefone"];

                    Pessoa = new DTO_Pessoa();
                    Pessoa.Telefone = new List<DTO_Pessoa_Telefone>();
                    BLL_Pessoa = new BLL_Pessoa();

                    DataTable _DT = new DataTable();

                    Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
                    Pessoa.ID = Convert.ToInt32(DT.Rows[i]["ID"]);
                    Pessoa.Telefone.Add(new DTO_Pessoa_Telefone());

                    _DT = BLL_Pessoa.Busca_Telefone(Pessoa);

                    for (int y = 0; y < _DT.Rows.Count; y++)
                    {
                        DR["NumeroTelefoneCompleto"] += "(" + DT.Rows[i]["DDD"] + ")" + _DT.Rows[y]["NumeroTelefone"].ToString();

                        if (y + 1 < _DT.Rows.Count)
                            DR["NumeroTelefoneCompleto"] += @" / ";
                    }


                    DR["Email"] = DT.Rows[i]["Email"];
                    DR["Referencia"] = DT.Rows[i]["Referencia"];
                    DR["Mensalidade"] = DT.Rows[i]["Mensalidade"];
                    DR["Vencimento"] = DT.Rows[i]["Vencimento"];

                    DT_Relatorio.Rows.Add(DR);
                    DT_Relatorio.AcceptChanges();
                }

            return DT_Relatorio;
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

            switch (cb_Classificar.Text)
            {
                case "DESCRIÇÃO":
                    Pessoa.Classifica = 1;
                    break;
                case "MUNICÍPIO":
                    Pessoa.Classifica = 2;
                    break;
            }

            DT = new DataTable();
            DT = BLL_Pessoa.Busca_Relatorio_Pessoa(Pessoa);
            Carrega_Pessoa(DT);
        }

        public override void Visualizar()
        {
            DataTable _DT = Carrega_DT();

            UI_Visualiza_Relatorio frm_rpt = new UI_Visualiza_Relatorio();
            frm_rpt.Show();

            string rpt_Nome = "";

            switch (cb_Etiqueta.Text)
            {
                case "CADASTRO COMPLETO":
                    rpt_Nome = "rpt_Pessoa_Relatorio.rdlc";
                    break;

                case "LISTA e-MAIL":
                    rpt_Nome = "rpt_Pessoa_Lista_email.rdlc";
                    break;

                case "LISTA TELEFONE":
                    rpt_Nome = "rpt_Pessoa_Lista_telefone.rdlc";
                    break;

                case "LISTA SIMPLES":
                    rpt_Nome = "rpt_Pessoa_Lista.rdlc";
                    break;

                case "CORRESPONDÊNCIA":
                    rpt_Nome = "rpt_Correspondencia.rdlc";
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", _DT);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);

            frm_rpt.rpt_Viewer.RefreshReport();
        }

        public override void Imprimir()
        {
            DataTable _DT = Carrega_DT();

            LocalReport rpt = new LocalReport();
            string rpt_Nome = "";

            switch (cb_Etiqueta.Text)
            {
                case "CADASTRO COMPLETO":
                    rpt_Nome = "rpt_Pessoa_Relatorio.rdlc";
                    break;

                case "LISTA e-MAIL":
                    rpt_Nome = "rpt_Pessoa_Lista_email.rdlc";
                    break;

                case "LISTA TELEFONE":
                    rpt_Nome = "rpt_Pessoa_Lista_telefone.rdlc";
                    break;

                case "LISTA SIMPLES":
                    rpt_Nome = "rpt_Pessoa_Lista.rdlc";
                    break;

                case "CORRESPONDÊNCIA":
                    rpt_Nome = "rpt_Correspondencia.rdlc";
                    break;
            }

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", _DT_Empresa);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", _DT);

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pessoa);

            rpt.Refresh();

            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            {
                PrintDocument documento = new PrintDocument();
                documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
                documento.PrinterSettings.Copies = EscolheImpressora.PrinterSettings.Copies;
                util_Impressao imp = util_Impressao.Novo(rpt);
                imp.Imprimir(documento, Tipo_Impressao.Retrato);
                imp = null;
            }
        }
        #endregion

        #region FORM
        private void UI_Pessoa_Etiqueta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
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
    }
}
