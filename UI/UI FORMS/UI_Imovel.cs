using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;
using System.Text.RegularExpressions;
using System.Net;

namespace Sistema.UI
{
    public partial class UI_Imovel : Sistema.UI.UI_Modelo
    {
        public UI_Imovel()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        BLL_Municipio BLL_Municipio;
        BLL_Pessoa BLL_Pessoa;
        BLL_Imovel BLL_Imovel;
        #endregion

        #region VARIAVEIS DIVERSAS
        List<DTO_Imovel_Custo> lst_Imovel_Custo;
        List<DTO_Imovel_Imagem> lst_Imovel_Imagem;
        List<DTO_Imovel_Vistoria> lst_Imovel_Vistoria;
        List<DTO_Imovel_Proprietario> lst_Imovel_Proprietario;

        int obj;
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        DTO_Municipio Municipio;
        DTO_Pessoa Pessoa;

        DTO_Imovel_Custo Imovel_Custo;
        DTO_Imovel_Imagem Imovel_Imagem;
        DTO_Imovel_Vistoria Imovel_Vistoria;
        DTO_Imovel_Proprietario Imovel_Proprietario;
        DTO_Imovel Imovel;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CADASTRO DE IMÓVEIS";

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 80;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "DESCRIÇÃO";
            col_Descricao.Width = 200;
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);


            DataGridViewTextBoxColumn col_Endereco = new DataGridViewTextBoxColumn();
            col_Endereco.DataPropertyName = "Endereco";
            col_Endereco.HeaderText = "ENDEREÇO";
            col_Endereco.Width = 200;
            col_Endereco.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Endereco);

            bt_Proximo.Visible = true;
            bt_Anterior.Visible = true;
            bt_Imprime.Visible = false;
            bt_Visualiza.Visible = false;
        }

        private void Carrega_CB()
        {
            DataTable _DT = new DataTable();

            BLL_Grupo = new BLL_Grupo();
            Grupo = new DTO_Grupo();

            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Imovel);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo_Imovel);

            _DT = new DataTable();
            Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo_Grupo.Tipo_Custo_Imovel);
            _DT = BLL_Grupo.Busca(Grupo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_TipoCusto);

            _DT = new DataTable();
            List<string> _Tipo = new List<string>();
            _Tipo.Add("LOCAÇÃO");
            _Tipo.Add("VENDA");
            _DT = util_dados.CarregaComboDinamico(1, _Tipo);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Tipo);

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();

            cb_ID_Pessoa.DataSource = null;

            Pessoa.TipoPessoa = 7;
            Pessoa.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            Pessoa.FiltraSituacao = true;
            Pessoa.Situacao = true;

            _DT = new DataTable();

            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa);
            cb_ID_Pessoa.SelectedIndex = -1;

            _DT = BLL_Pessoa.Busca_Nome(Pessoa);
            util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_ID_Pessoa_P);
            cb_ID_Pessoa_P.SelectedIndex = -1;
        }

        private void AtualizaComboEstado()
        {
            try
            {
                BLL_Municipio = new BLL_Municipio();
                Municipio = new DTO_Municipio();

                Municipio.ID_Pais = 1058;

                DataTable _DT = new DataTable();
                _DT = BLL_Municipio.Busca_UF(Municipio);
                util_dados.CarregaCombo(_DT, "Descricao", "ID_UF", cb_UF);
            }
            catch (Exception)
            {
            }
        }

        private void AtualizaComboMunicipio()
        {
            try
            {
                if ((int)cb_UF.SelectedValue > 0)
                {
                    BLL_Municipio = new BLL_Municipio();
                    Municipio = new DTO_Municipio();

                    Municipio.ID_UF = Convert.ToInt32(cb_UF.SelectedValue);

                    DataTable _DT = new DataTable();
                    _DT = BLL_Municipio.Busca_Municipio(Municipio);
                    util_dados.CarregaCombo(_DT, "Descricao", "ID", cb_Cidade);
                }
            }
            catch (Exception)
            {
            }
        }

        private void CarregaProprietario()
        {
            dg_Proprietario.Rows.Clear();

            for (int i = 0; i <= lst_Imovel_Proprietario.Count - 1; i++)
            {
                dg_Proprietario.Rows.Add();
                dg_Proprietario.Rows[dg_Proprietario.Rows.Count - 1].Cells["col_Pessoa"].Value = lst_Imovel_Proprietario[i].DescricaoPessoa;
            }
        }

        private void Carrega_Custo()
        {
            dg_Custo.Rows.Clear();

            for (int i = 0; i <= lst_Imovel_Custo.Count - 1; i++)
            {
                dg_Custo.Rows.Add();
                dg_Custo.Rows[dg_Custo.Rows.Count - 1].Cells["col_TipoCusto"].Value = lst_Imovel_Custo[i].DescricaoCusto;
                dg_Custo.Rows[dg_Custo.Rows.Count - 1].Cells["col_Valor"].Value = lst_Imovel_Custo[i].Valor;
            }
        }

        private void Carrega_Vistoria()
        {
            dg_Vistoria.Rows.Clear();

            for (int i = 0; i <= lst_Imovel_Vistoria.Count - 1; i++)
            {
                dg_Vistoria.Rows.Add();
                dg_Vistoria.Rows[dg_Vistoria.Rows.Count - 1].Cells["col_Local"].Value = lst_Imovel_Vistoria[i].Local;
                dg_Vistoria.Rows[dg_Vistoria.Rows.Count - 1].Cells["col_Descricao"].Value = lst_Imovel_Vistoria[i].Descricao;
            }
        }

        private void Carrega_Imagem()
        {
            dg_Foto.Rows.Clear();

            for (int i = 0; i <= lst_Imovel_Imagem.Count - 1; i++)
            {
                dg_Foto.Rows.Add();
                dg_Foto.Rows[dg_Foto.Rows.Count - 1].Cells["col_InformacaoFoto"].Value = lst_Imovel_Imagem[i].Informacao;
                dg_Foto.Rows[dg_Foto.Rows.Count - 1].Cells["col_Foto"].Value = lst_Imovel_Imagem[i].ArqByteArray;
                ((DataGridViewImageColumn)dg_Foto.Columns["col_Foto"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
        }

        private void Busca_Imovel(int _ID)
        {
            dg_Custo.Rows.Clear();
            dg_Vistoria.Rows.Clear();
            dg_Foto.Rows.Clear();
            dg_Proprietario.Rows.Clear();

            BLL_Imovel = new BLL_Imovel();
            Imovel = new DTO_Imovel();

            Imovel.ID = _ID;
            DataTable _DT = new DataTable();

            #region PROPRIETÁRIO
            _DT = BLL_Imovel.Busca_Proprietario(Imovel);
            if (_DT.Rows.Count > 0)
            {
                lst_Imovel_Proprietario = new List<DTO_Imovel_Proprietario>();
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Imovel_Proprietario = new DTO_Imovel_Proprietario();

                    Imovel_Proprietario.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    Imovel_Proprietario.TipoPessoa = Convert.ToInt32(_DT.Rows[i]["TipoPessoa"]);
                    Imovel_Proprietario.ID_Pessoa = Convert.ToInt32(_DT.Rows[i]["ID_Pessoa"]);
                    Imovel_Proprietario.DescricaoPessoa = _DT.Rows[i]["Descricao"].ToString();
                    lst_Imovel_Proprietario.Add(Imovel_Proprietario);
                }
                CarregaProprietario();
            }
            #endregion

            #region IMAGEM
            _DT = new DataTable();
            _DT = BLL_Imovel.Busca_Imagem(Imovel);
            if (_DT.Rows.Count > 0)
            {
                lst_Imovel_Imagem = new List<DTO_Imovel_Imagem>();
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Imovel_Imagem = new DTO_Imovel_Imagem();

                    Imovel_Imagem.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    Imovel_Imagem.Informacao = _DT.Rows[i]["Informacao"].ToString();
                    Imovel_Imagem.ArqByteArray = _DT.Rows[i]["Imagem"];

                    lst_Imovel_Imagem.Add(Imovel_Imagem);
                }
                Carrega_Imagem();
            }
            #endregion

            #region CUSTO
            _DT = new DataTable();
            _DT = BLL_Imovel.Busca_Custo(Imovel);
            if (_DT.Rows.Count > 0)
            {
                lst_Imovel_Custo = new List<DTO_Imovel_Custo>();
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Imovel_Custo = new DTO_Imovel_Custo();

                    Imovel_Custo.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    Imovel_Custo.ID_Tipo = Convert.ToInt32(_DT.Rows[i]["ID_Tipo"]);
                    Imovel_Custo.Valor = Convert.ToDouble(_DT.Rows[i]["Valor"]);
                    Imovel_Custo.DescricaoCusto = _DT.Rows[i]["Descricao"].ToString();

                    lst_Imovel_Custo.Add(Imovel_Custo);
                }
                Carrega_Custo();
            }
            #endregion

            #region VISTORIA
            _DT = new DataTable();
            _DT = BLL_Imovel.Busca_Vistoria(Imovel);
            if (_DT.Rows.Count > 0)
            {
                lst_Imovel_Vistoria = new List<DTO_Imovel_Vistoria>();
                for (int i = 0; i <= _DT.Rows.Count - 1; i++)
                {
                    Imovel_Vistoria = new DTO_Imovel_Vistoria();

                    Imovel_Vistoria.ID = Convert.ToInt32(_DT.Rows[i]["ID"]);
                    Imovel_Vistoria.Local = _DT.Rows[i]["Local"].ToString();
                    Imovel_Vistoria.Descricao = _DT.Rows[i]["Descricao"].ToString();

                    lst_Imovel_Vistoria.Add(Imovel_Vistoria);
                }
                Carrega_Vistoria();
            }
            #endregion

        }

        private void Limpa_Campo()
        {
            DG.DataSource = null;

            util_dados.LimpaCampos(this, gb_Cadastro);
            util_dados.LimpaCampos(this, gb_Endereco);

            lst_Imovel_Custo = null;
            lst_Imovel_Imagem = null;
            lst_Imovel_Proprietario = null;
            lst_Imovel_Vistoria = null;

            dg_Proprietario.Rows.Clear();
            dg_Custo.Rows.Clear();
            dg_Vistoria.Rows.Clear();
            dg_Foto.Rows.Clear();

            Carrega_CB();
            DG.DataSource = null;
            txt_Descricao.Focus();

        }

        private void Consulta_Pessoa()
        {
            UI_Pessoa_Consulta UI_Pessoa_Consulta = new UI_Pessoa_Consulta();
            UI_Pessoa_Consulta.OcultaNovoCadastro = true;
            UI_Pessoa_Consulta.TipoPessoa = 7;

            UI_Pessoa_Consulta.ShowDialog();

            if (UI_Pessoa_Consulta.ID_Pessoa == 0)
                return;

            if (UI_Pessoa_Consulta.TipoPessoa != 7)
                return;

            if (tabctl.SelectedTab == TabPage1)
            {
                cb_ID_Pessoa.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_Pessoa.Focus();
            }

            if (tabctl.SelectedTab == TabPage2)
            {
                cb_ID_Pessoa_P.SelectedValue = UI_Pessoa_Consulta.ID_Pessoa;
                cb_ID_Pessoa_P.Focus();
            }
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                obj = 0;

                BLL_Imovel = new BLL_Imovel();
                Imovel = new DTO_Imovel();
                Imovel.Endereco = new DTO_Imovel_Endereco();

                Imovel.ID = util_dados.Verifica_int(txt_ID.Text);
                Imovel.Descricao = txt_Descricao.Text;
                Imovel.ID_Tipo = Convert.ToInt32(cb_Tipo.SelectedValue);
                Imovel.Tipo_Imovel = Convert.ToInt32(cb_Tipo_Imovel.SelectedValue);
                Imovel.Valor = Convert.ToDouble(txt_Valor.Text);
                Imovel.Comissao_Porc = Convert.ToDouble(txt_Comissao_Porc.Text);
                Imovel.Comissao_Valor = Convert.ToDouble(txt_Comissao_Valor.Text);
                Imovel.Area = Convert.ToDouble(txt_Area.Text);
                Imovel.RGI = txt_RGI.Text;
                Imovel.UC = txt_UC.Text;
                Imovel.CI = txt_CI.Text;
                Imovel.Matricula = txt_Matricula.Text;

                Imovel.Endereco.CEP = mk_CEP.Text;
                Imovel.Endereco.Logradouro = txt_Logradouro.Text;
                Imovel.Endereco.Numero = txt_Numero.Text;
                Imovel.Endereco.Complemento = txt_Complemento.Text;
                Imovel.Endereco.Bairro = txt_Bairro.Text;
                Imovel.Endereco.ID_Municipio = Convert.ToInt32(cb_Cidade.SelectedValue);

                Imovel.Proprietario = lst_Imovel_Proprietario;
                Imovel.Custo = lst_Imovel_Custo;
                Imovel.Vistoria = lst_Imovel_Vistoria;
                Imovel.Imagem = lst_Imovel_Imagem;

                obj = BLL_Imovel.Grava(Imovel);

                if (obj > 0)
                {
                    Config(StatusForm.Consulta);
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
            try
            {
                BLL_Imovel = new BLL_Imovel();
                Imovel = new DTO_Imovel();
                Imovel_Proprietario = new DTO_Imovel_Proprietario();
                Imovel.Proprietario = new List<DTO_Imovel_Proprietario>();

                Imovel.ID = util_dados.Verifica_int(txt_ID_P.Text);
                Imovel.Descricao = txt_Descricao_P.Text;
                Imovel.ID_Tipo = Convert.ToInt32(cb_Tipo_P.SelectedValue);
                Imovel.Tipo_Imovel = Convert.ToInt32(cb_Tipo_Imovel_P.SelectedValue);

                Imovel_Proprietario.TipoPessoa = 7;
                Imovel_Proprietario.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa_P.SelectedValue);

                Imovel.Proprietario.Add(Imovel_Proprietario);

                DataTable _DT = new DataTable();
                _DT = BLL_Imovel.Busca(Imovel);

                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
                util_dados.CarregaCampo(this, _DT, gb_Endereco);
                DG.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        public override void Excluir()
        {
            try
            {
                DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                BLL_Imovel = new BLL_Imovel();
                Imovel = new DTO_Imovel();

                Imovel.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Imovel.Exclui(Imovel);
                MessageBox.Show(util_msg.msg_Grava, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            Limpa_Campo();
            tabctl.SelectedTab = TabPage1;
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }

        private void Consulta_CEP(string _CEP)
        {
            try
            {
                txt_Logradouro.Clear();
                txt_Bairro.Clear();
                cb_UF.SelectedIndex = -1;
                cb_Cidade.SelectedIndex = -1;
                txt_Numero.Clear();
                txt_Complemento.Clear();

                DataSet DS = new DataSet();

                DS.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + _CEP.Replace("-", "").Trim() + "&formato=xml");

                if (DS != null)
                {

                    string _Resultado = DS.Tables[0].Rows[0]["resultado"].ToString();

                    switch (_Resultado)
                    {
                        case "1":
                            txt_Logradouro.Text = DS.Tables[0].Rows[0]["tipo_logradouro"].ToString().ToUpper() + " " + DS.Tables[0].Rows[0]["logradouro"].ToString().ToUpper();
                            txt_Bairro.Text = DS.Tables[0].Rows[0]["bairro"].ToString().ToUpper();
                            cb_UF.SelectedValue = util_dados.Retorna_ID_UF(DS.Tables[0].Rows[0]["uf"].ToString());
                            cb_Cidade.Text = DS.Tables[0].Rows[0]["cidade"].ToString().ToUpper();

                            txt_Numero.Focus();
                            break;

                        case "0":
                        case "2":
                            MessageBox.Show(util_msg.msg_CEP_NaoEncontrado);
                            txt_Logradouro.Focus();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_CEP_NaoEncontrado + "\n" + ex.Message);
            }
        }
        #endregion

        #region FORM
        private void UI_Imovel_Load(object sender, EventArgs e)
        {
            Inicia_Form();

            Limpa_Campo();

            AtualizaComboEstado();

            dg_Foto.RowTemplate.Height = 150;
            dg_Vistoria.RowTemplate.Height = 100;
        }

        private void UI_Imovel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
                tabctl.SelectedTab == TabPage2)
                Pesquisa();

            if (e.KeyCode == Keys.F7)
                Consulta_Pessoa();
        }
        #endregion

        #region BUTTON
        private void bt_AdicionaProprietario_Click(object sender, EventArgs e)
        {
            try
            {
                if (util_dados.Verifica_int(cb_ID_Pessoa.SelectedValue.ToString()) == 0)
                    return;

                if (lst_Imovel_Proprietario == null)
                    lst_Imovel_Proprietario = new List<DTO_Imovel_Proprietario>();

                Imovel_Proprietario = new DTO_Imovel_Proprietario();
                Imovel_Proprietario.TipoPessoa = 7;
                Imovel_Proprietario.ID_Pessoa = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
                Imovel_Proprietario.DescricaoPessoa = cb_ID_Pessoa.Text;

                lst_Imovel_Proprietario.Add(Imovel_Proprietario);
                CarregaProprietario();
            }
            catch (Exception)
            {
            }
        }

        private void bt_RemoveProprietario_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                if (lst_Imovel_Proprietario != null)
                {
                    if (lst_Imovel_Proprietario[dg_Proprietario.CurrentRow.Index].ID != 0)
                    {
                        BLL_Imovel = new BLL_Imovel();
                        Imovel = new DTO_Imovel();
                        Imovel_Proprietario = new DTO_Imovel_Proprietario();
                        Imovel.Proprietario = new List<DTO_Imovel_Proprietario>();

                        Imovel_Proprietario.ID = lst_Imovel_Proprietario[dg_Proprietario.CurrentRow.Index].ID;

                        Imovel.Proprietario.Add(Imovel_Proprietario);

                        BLL_Imovel.Exclui_Proprietario(Imovel);
                    }

                    lst_Imovel_Proprietario.RemoveAt(dg_Proprietario.CurrentRow.Index);
                    CarregaProprietario();
                }
        }

        private void bt_AdicionaCusto_Click(object sender, EventArgs e)
        {
            if (lst_Imovel_Custo == null)
                lst_Imovel_Custo = new List<DTO_Imovel_Custo>();

            Imovel_Custo = new DTO_Imovel_Custo();
            Imovel_Custo.DescricaoCusto = cb_TipoCusto.Text;
            Imovel_Custo.ID_Tipo = Convert.ToInt32(cb_TipoCusto.SelectedValue);
            Imovel_Custo.Valor = Convert.ToDouble(txt_ValorCusto.Text);

            lst_Imovel_Custo.Add(Imovel_Custo);
            Carrega_Custo();
        }

        private void bt_RemoveCusto_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                if (lst_Imovel_Custo != null)
                {
                    if (lst_Imovel_Custo[dg_Custo.CurrentRow.Index].ID != 0)
                    {
                        BLL_Imovel = new BLL_Imovel();
                        Imovel = new DTO_Imovel();
                        Imovel_Custo = new DTO_Imovel_Custo();
                        Imovel.Custo = new List<DTO_Imovel_Custo>();

                        Imovel_Custo.ID = lst_Imovel_Custo[dg_Custo.CurrentRow.Index].ID;

                        Imovel.Custo.Add(Imovel_Custo);

                        BLL_Imovel.Exclui_Custo(Imovel);
                    }
                    lst_Imovel_Custo.RemoveAt(dg_Custo.CurrentRow.Index);
                    Carrega_Custo();
                }
        }

        private void bt_AdicionaVistoria_Click(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID_Vistoria.Text) > 0)
            {
                lst_Imovel_Vistoria[dg_Vistoria.CurrentRow.Index].Local = txt_LocalVistoria.Text;
                lst_Imovel_Vistoria[dg_Vistoria.CurrentRow.Index].Descricao = txt_DescricaoVistoria.Text;
            }
            else
            {

                if (lst_Imovel_Vistoria == null)
                    lst_Imovel_Vistoria = new List<DTO_Imovel_Vistoria>();

                Imovel_Vistoria = new DTO_Imovel_Vistoria();
                Imovel_Vistoria.Local = txt_LocalVistoria.Text;
                Imovel_Vistoria.Descricao = txt_DescricaoVistoria.Text;

                lst_Imovel_Vistoria.Add(Imovel_Vistoria);

            }
            Carrega_Vistoria();

            txt_ID_Vistoria.Text = string.Empty;
            txt_LocalVistoria.Text = string.Empty;
            txt_DescricaoVistoria.Text = string.Empty;
        }

        private void bt_RemoveVistoria_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                if (lst_Imovel_Vistoria != null)
                {
                    if (lst_Imovel_Vistoria[dg_Vistoria.CurrentRow.Index].ID != 0)
                    {
                        BLL_Imovel = new BLL_Imovel();
                        Imovel = new DTO_Imovel();
                        Imovel_Vistoria = new DTO_Imovel_Vistoria();
                        Imovel.Vistoria = new List<DTO_Imovel_Vistoria>();

                        Imovel_Vistoria.ID = lst_Imovel_Vistoria[dg_Vistoria.CurrentRow.Index].ID;

                        Imovel.Vistoria.Add(Imovel_Vistoria);

                        BLL_Imovel.Exclui_Vistoria(Imovel);
                    }
                    lst_Imovel_Vistoria.RemoveAt(dg_Vistoria.CurrentRow.Index);
                    Carrega_Vistoria();

                    txt_ID_Vistoria.Text = string.Empty;
                    txt_LocalVistoria.Text = string.Empty;
                    txt_DescricaoVistoria.Text = string.Empty;
                }
        }

        private void bt_AdicionaFoto_Click(object sender, EventArgs e)
        {
            if (lst_Imovel_Imagem == null)
                lst_Imovel_Imagem = new List<DTO_Imovel_Imagem>();

            FileStream _Imagem = default(FileStream);
            StreamReader ConfigImagem = default(StreamReader);
            _Imagem = new FileStream(txt_CaminhoFoto.Text, FileMode.Open, FileAccess.Read, FileShare.Read);
            ConfigImagem = new StreamReader(_Imagem);
            byte[] arqByteArray = new byte[_Imagem.Length];
            _Imagem.Read(arqByteArray, 0, Convert.ToInt32(_Imagem.Length));

            Imovel_Imagem = new DTO_Imovel_Imagem();
            Imovel_Imagem.Informacao = txt_Informacao.Text;
            Imovel_Imagem.Imagem = _Imagem;
            Imovel_Imagem.ArqByteArray = arqByteArray;

            lst_Imovel_Imagem.Add(Imovel_Imagem);
            Carrega_Imagem();
        }

        private void bt_RemoveFoto_Click(object sender, EventArgs e)
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
                if (lst_Imovel_Imagem != null)
                {
                    if (lst_Imovel_Imagem[dg_Foto.CurrentRow.Index].ID != 0)
                    {
                        BLL_Imovel = new BLL_Imovel();
                        Imovel = new DTO_Imovel();
                        Imovel_Imagem = new DTO_Imovel_Imagem();
                        Imovel.Imagem = new List<DTO_Imovel_Imagem>();

                        Imovel_Imagem.ID = lst_Imovel_Imagem[dg_Foto.CurrentRow.Index].ID;

                        Imovel.Imagem.Add(Imovel_Imagem);

                        BLL_Imovel.Exclui_Imagem(Imovel);
                    }
                    lst_Imovel_Imagem.RemoveAt(dg_Foto.CurrentRow.Index);
                    Carrega_Imagem();
                }
        }

        private void bt_PesquisaFoto_Click(object sender, EventArgs e)
        {
            PesquisaImagem.Filter = "Image Files (*.jpg)|*.jpg";
            PesquisaImagem.ShowDialog();

            FileInfo tamanho = new FileInfo(PesquisaImagem.FileName);/*
                if (tamanho.Length > 100000)
                {
                    MessageBox.Show("Imagem muito grande!");
                    return;
                }*/
            txt_CaminhoFoto.Text = PesquisaImagem.FileName;
        }

        private void bt_Edita_Vistoria_Click(object sender, EventArgs e)
        {
            txt_ID_Vistoria.Text = lst_Imovel_Vistoria[dg_Vistoria.CurrentRow.Index].ID.ToString();
            txt_LocalVistoria.Text = lst_Imovel_Vistoria[dg_Vistoria.CurrentRow.Index].Local.ToString();
            txt_DescricaoVistoria.Text = lst_Imovel_Vistoria[dg_Vistoria.CurrentRow.Index].Descricao.ToString();
        }

        private void bt_BuscaCEP_Click(object sender, EventArgs e)
        {
            Consulta_CEP(mk_CEP.Text);
        }
        #endregion

        #region COMBOBOX
        private void cb_UF_SelectedValueChanged(object sender, EventArgs e)
        {
            AtualizaComboMunicipio();
            if (util_dados.Verifica_int(txt_Cidade.Text) > 0)
                cb_Cidade.SelectedValue = txt_Cidade.Text;
        }
        #endregion

        #region TEXTBOX
        private void txt_ValorCusto_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_ValorCusto.Text) == 0)
                txt_ValorCusto.Text = "0,00";

            txt_ValorCusto.Text = util_dados.ConfigNumDecimal(txt_ValorCusto.Text, 2);
        }

        private void txt_Area_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Area.Text) == 0)
                txt_Area.Text = "0,00";

            txt_Area.Text = util_dados.ConfigNumDecimal(txt_Area.Text, 2);
        }

        private void txt_Comissao_Porc_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Comissao_Porc.Text) == 0)
                txt_Comissao_Porc.Text = "0,00";

            txt_Comissao_Porc.Text = util_dados.ConfigNumDecimal(txt_Comissao_Porc.Text, 2);
        }

        private void txt_Comissao_Valor_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Comissao_Valor.Text) == 0)
                txt_Comissao_Valor.Text = "0,00";

            txt_Comissao_Valor.Text = util_dados.ConfigNumDecimal(txt_Comissao_Valor.Text, 2);
        }

        private void txt_Valor_Leave(object sender, EventArgs e)
        {
            if (util_dados.Verifica_Double(txt_Valor.Text) == 0)
                txt_Valor.Text = "0,00";

            txt_Valor.Text = util_dados.ConfigNumDecimal(txt_Valor.Text, 2);
        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            if (util_dados.Verifica_int(txt_ID.Text) > 0)
                Busca_Imovel(util_dados.Verifica_int(txt_ID.Text));

            Status = StatusForm.Consulta;
            Config_Botao();
        }

        private void txt_Cidade_TextChanged(object sender, EventArgs e)
        {
            AtualizaComboMunicipio();
            if (util_dados.Verifica_int(txt_Cidade.Text) > 0)
                cb_Cidade.SelectedValue = txt_Cidade.Text;
        }
        #endregion
    }
}
