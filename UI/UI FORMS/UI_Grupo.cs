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
    public partial class UI_Grupo : Sistema.UI.UI_Modelo
    {
        public UI_Grupo()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Grupo BLL_Grupo;
        #endregion

        #region VARIAVEIS DIVERSAS
        int obj;
        #endregion

        #region PROPRIEDADES
        public Tipo_Grupo Tipo { get; set; }
        #endregion

        #region ESTRUTURA
        DTO_Grupo Grupo;
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            Config_Form();

            DataGridViewTextBoxColumn col_ID = new DataGridViewTextBoxColumn();
            col_ID.DataPropertyName = "ID";
            col_ID.HeaderText = "CÓDIGO";
            col_ID.Width = 70;
            DG.Columns.Add(col_ID);

            DataGridViewTextBoxColumn col_Descricao = new DataGridViewTextBoxColumn();
            col_Descricao.DataPropertyName = "Descricao";
            col_Descricao.HeaderText = "DESCRIÇÃO";
            col_Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DG.Columns.Add(col_Descricao);

            bt_Visualiza.Visible = false;
            bt_Imprime.Visible = false;

            bt_Anterior.Visible = true;
            bt_Proximo.Visible = true;

            bt_Anterior.Enabled = true;
            bt_Proximo.Enabled = true;
        }

        private void Config_Form()
        {
            string _TipoCadastro = string.Empty;

            switch (Tipo)
            {
                case Tipo_Grupo.Tipo_Cliente:
                    _TipoCadastro = "TIPO DE CLIENTE";
                    break;

                case Tipo_Grupo.Tipo_Transportadora:
                    _TipoCadastro = "TIPO DE TRANSPORTADORA";
                    break;

                case Tipo_Grupo.Tipo_Fornecedor:
                    _TipoCadastro = "TIPO DE FORNECEDOR";
                    break;

                case Tipo_Grupo.Tipo_Funcionario:
                    _TipoCadastro = "TIPO DE FUNCIONÁRIO";
                    break;

                case Tipo_Grupo.Tipo_Empresa:
                    _TipoCadastro = "TIPO DE EMPRESA";
                    break;

                case Tipo_Grupo.Tipo_Endereco:
                    _TipoCadastro = "TIPO DE ENDEREÇO";
                    break;

                case Tipo_Grupo.Tipo_Telefone:
                    _TipoCadastro = "TIPO DE TELEFONE";
                    break;

                case Tipo_Grupo.Tipo_eMail:
                    _TipoCadastro = "TIPO DE e-MAIL";
                    break;

                case Tipo_Grupo.Tipo_Caixa:
                    _TipoCadastro = "CAIXA / BANCO";
                    ck_Exibir.Visible = true;
                    ck_Exibir.Text = "ATIVO / EXIBIR PLANEJAMENTO";
                    break;

                case Tipo_Grupo.Tipo_Atendimento:
                    _TipoCadastro = "TIPO DE ATENDIMENTO";
                    break;

                case Tipo_Grupo.Tipo_Fabricante:
                    _TipoCadastro = "FABRICANTE";
                    break;

                case Tipo_Grupo.Tipo_Equipamento:
                    _TipoCadastro = "EQUIPAMENTO";
                    break;

                case Tipo_Grupo.Tipo_Unidade:
                    _TipoCadastro = "UNIDADE DE PRODUTO";
                    txt_Descricao.MaxLength = 6;
                    break;

                case Tipo_Grupo.Tipo_DocumentoCompra:
                    _TipoCadastro = "TIPO DE DOCUMENTO COMPRA";
                    break;

                case Tipo_Grupo.Tipo_Grade:
                    _TipoCadastro = "GRADE";
                    break;

                case Tipo_Grupo.Tipo_Comodato:
                    _TipoCadastro = "TIPO DE CONTRATO COMODATO";
                    break;

                case Tipo_Grupo.Tipo_FolhaPagto:
                    _TipoCadastro = "TIPO DE FOLHA DE PAGAMENTO";
                    break;

                case Tipo_Grupo.Tipo_DocumentoContabil:
                    _TipoCadastro = "TIPO DE DOCUMENTO CONTÁBIL";
                    break;

                case Tipo_Grupo.Tipo_Imovel:
                    _TipoCadastro = "TIPO DE IMÓVEL";
                    break;

                case Tipo_Grupo.Tipo_Custo_Imovel:
                    _TipoCadastro = "TIPO DE CUSTOS DE IMÓVEL";
                    break;
            }
            this.Text = "CADASTRO DE " + _TipoCadastro;
        }
        #endregion

        #region MODIFICADORES
        public override void Gravar()
        {
            try
            {
                BLL_Grupo = new BLL_Grupo();
                Grupo = new DTO_Grupo();

                Grupo.ID = util_dados.Verifica_int(txt_ID.Text);
                Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo);
                Grupo.Descricao = txt_Descricao.Text;
                Grupo.Exibir = ck_Exibir.Checked;

                obj = BLL_Grupo.Grava(Grupo);
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
                BLL_Grupo = new BLL_Grupo();
                Grupo = new DTO_Grupo();

                Grupo.ID = util_dados.Verifica_int(txt_IDP.Text);
                Grupo.Tipo = util_dados.Codigo_TipoGrupo(Tipo);
                Grupo.Descricao = txt_DescricaoP.Text;

                DataTable _DT = new DataTable();
                _DT = BLL_Grupo.Busca(Grupo);

                DG.DataSource = _DT;
                util_dados.CarregaCampo(this, _DT, gb_Cadastro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Excluir()
        {
            DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaExclusao, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.No)
                return;

            try
            {
                BLL_Grupo = new BLL_Grupo();
                Grupo = new DTO_Grupo();

                Grupo.ID = util_dados.Verifica_int(txt_ID.Text);

                BLL_Grupo.Exclui(Grupo);

                MessageBox.Show(util_msg.msg_Exclui, this.Text);

                Pesquisa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        public override void Novo()
        {
            util_dados.LimpaCampos(this, gb_Cadastro);

            tabctl.SelectedTab = TabPage1;

            txt_Descricao.Focus();
        }

        public override void ExibeRegistro()
        {
            tabctl.SelectedTab = TabPage1;
        }
        #endregion

        #region FORM  
        private void UI_Grupo_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }

        private void UI_Grupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 &&
               tabctl.SelectedTab == TabPage2)
                Pesquisa();
        }
        #endregion

        #region TEXTBOX
        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            Config(StatusForm.Consulta);
        }
        #endregion
    }
}
