using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_MDI : Form
    {
        public UI_MDI()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 30);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Iconmaximizar_Click(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 30);
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void Iconrestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(950, 700);
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void Iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region VARIAVEIS DE CLASSE

        private BLL_Usuario_Acesso BLL_Usuario_Acesso;
        private BLL_Imagem BLL_Imagem;
        private BLL_Venda_Mobile BLL_Venda_Mobile;
        private BLL_Sistema BLL_Sistema;

        #endregion VARIAVEIS DE CLASSE

        #region ESTRUTURA

        private DTO_Usuario_Parametros Usuario_Parametros;
        private DTO_Log Conecxao;
        private DTO_Imagem Imagem;
        private DTO_Mobile Mobile;
        private DTO_Sistema Sistema;

        #endregion ESTRUTURA

        #region ROTINAS

        public void AbrirFormEnPanel(object Formhijo)
        {
            Form fh = Formhijo as Form;
            fh.Show();
        }

        private void Inicia_Form()
        {
            BLL_Sistema = new BLL_Sistema();

        

            #region LOGO RELATÓRIO

            BLL_Imagem = new BLL_Imagem();
            Imagem = new DTO_Imagem();
            Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Imagem.Tipo = 1;

            DataTable _DT = new DataTable();

            _DT = BLL_Imagem.Busca(Imagem);
            byte[] bits = (byte[])(_DT.Rows[0][0]);

            MemoryStream memorybits = new MemoryStream(bits);
            Bitmap ImagemConvertida = new Bitmap(memorybits);

            #endregion LOGO RELATÓRIO

            #region LOGO EMPRESA

            Imagem = new DTO_Imagem();
            Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            Imagem.Tipo = 2;

            _DT = new DataTable();

            _DT = BLL_Imagem.Busca(Imagem);

            bits = (byte[])(_DT.Rows[0][0]);
            memorybits = new MemoryStream(bits);
            ImagemConvertida = new Bitmap(memorybits);
            panelContenedor.BackgroundImage = ImagemConvertida;

            #endregion LOGO EMPRESA

            if (Parametro_Usuario.ID_Usuario_Ativo != 0)
            {
                BLL_Usuario_Acesso = new BLL_Usuario_Acesso();
                Usuario_Parametros = new DTO_Usuario_Parametros();

                Usuario_Parametros.ID_Usuario = Parametro_Usuario.ID_Usuario_Ativo;
                Usuario_Parametros.Menu = string.Empty;

                _DT = BLL_Usuario_Acesso.Busca(Usuario_Parametros);

                foreach (ToolStripMenuItem MenuItem in this.menu_Principal.Items)
                {
                    Carrega_Permissao(MenuItem, _DT);
                    foreach (ToolStripMenuItem subitem1 in MenuItem.DropDownItems)
                    {
                        Carrega_Permissao(subitem1, _DT);
                        foreach (ToolStripItem subitem2 in subitem1.DropDownItems)
                        {
                            if (!(subitem2 is ToolStripSeparator))
                            {
                                Carrega_Permissao(subitem2, _DT);
                            }
                        }
                    }
                }
            }

            Sistema = new DTO_Sistema();
            Sistema.ID = 1;
            var dtSistema = BLL_Sistema.Busca(Sistema);

            tss_Empresa.Text = Parametro_Empresa.Razao_Social_Empresa + $"  Versão: {dtSistema.Rows[0]["Versao"]}.{dtSistema.Rows[0]["BD"]}";

            this.Text = Parametro_Empresa.DescricaoEmpresa + " - " + util_msg.Sistema;

            char Letra = char.ToUpper(Parametro_Usuario.Descricao_UsuarioAtivo[0]);
            tss_Usuario.Text = Letra + Parametro_Usuario.Descricao_UsuarioAtivo.Substring(1);

            frenteDeCaixaPDVToolStripMenuItem.Text = "PDV - Frente de Caixa";
            frenteDeCaixaPDV2ToolStripMenuItem.Text = "PDV - Frente de Caixa";

            Tempo();
            MinutoAtualizacao.Enabled = true;
            MinutoAtualizacao.Start();
        }

        private void Carrega_Permissao(ToolStripMenuItem MenuItem, DataTable _DT)
        {
            DataRow[] DR = null;
            try
            {
                DR = _DT.Select("Menu = '" + MenuItem.Name + "'");

                if (DR.Length > 0)
                    MenuItem.Visible = true;
                else
                {
                    MenuItem.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, util_msg.Sistema);
                Application.Exit();
            }
        }

        private void Carrega_Permissao(ToolStripItem MenuItem, DataTable _DT)
        {
            DataRow[] DR = null;
            try
            {
                DR = _DT.Select("Menu = '" + MenuItem.Name + "'");

                if (DR.Length > 0)
                    MenuItem.Visible = true;
                else
                {
                    MenuItem.Visible = false;
                    //Atualiza_Permissao(MenuItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, util_msg.Sistema);
                Application.Exit();
            }
        }

        private void Tempo()
        {
            Minuto.Enabled = true;
            Minuto.Start();
        }

        #endregion ROTINAS

        #region FORM

        private void frm_MDI_Load(object sender, EventArgs e)
        {
            //Theme.ColorTable = new RibbonProfesionalRendererColorTableBlack();

            //MdiClient ctlMDI = (MdiClient)this.Controls[this.Controls.Count - 1];
            //ctlMDI.BackColor = this.BackColor;

            Inicia_Form();

            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void frm_MDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frm_MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        #endregion FORM

        #region TIMER

        private void Minuto_Tick(object sender, EventArgs e)
        {
            try
            {
                //VERIFICA PEDIDOS MOBILE
                DataTable aux;
                BLL_Venda_Mobile = new BLL_Venda_Mobile();
                Mobile = new DTO_Mobile();

                aux = BLL_Venda_Mobile.Busca(Mobile);

                if (aux.Rows.Count > 0 && util_Param.Consulta_Mobile == false)
                {
                    util_Param.Consulta_Mobile = true;
                    MessageBox.Show(util_msg.msg_EfetivaMobile, util_msg.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Minuto.Enabled = false;
                Tempo();
            }
            catch (Exception)
            {
            }
        }

        private void MinutoAtualizacao_Tick(object sender, EventArgs e)
        {
            try
            {
                string Versao_Servidor = string.Empty;

                //VERIFICA ATUALIZAÇÃO DOS TERMINAIS
                BLL_Sistema = new BLL_Sistema();
                Sistema = new DTO_Sistema();

                Sistema.ID = 1;
                DataTable _DT = new DataTable();
                DataRow DR;

                _DT = BLL_Sistema.Busca(Sistema);
                if (_DT.Rows.Count > 0)
                    Versao_Servidor = Convert.ToString(_DT.Rows[0]["Versao"]);

                if (Convert.ToInt32(Versao_Servidor) > Convert.ToInt32(Parametro_Sistema.Versao.Replace(".", "")))
                {
                    MinutoAtualizacao.Enabled = false;
                    MessageBox.Show(util_msg.msg_Atualizacao, util_msg.Sistema);
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion TIMER

        #region MENU PRINCIPAL *CADASTRO*

        #region SUB MENU *USUÁRIO*

        private void CadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Usuario)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Usuario UI_Usuario = new UI_Usuario();
                AbrirFormEnPanel(UI_Usuario);
            }
        }

        private void PermissõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Usuario_Acesso)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            if (aux == false)
            {
                UI_Usuario_Acesso UI_Usuario_Acesso = new UI_Usuario_Acesso();
                AbrirFormEnPanel(UI_Usuario_Acesso);
            }
        }

        private void comissõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Usuario_Comissao)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            if (aux == false)
            {
                UI_Usuario_Comissao UI_Usuario_Comissao = new UI_Usuario_Comissao();
                AbrirFormEnPanel(UI_Usuario_Comissao);
            }
        }

        #endregion SUB MENU *USUÁRIO*

        private void relacionamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Pessoa_Relacionamento)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Pessoa_Relacionamento UI_Pessoa_Relacionamento = new UI_Pessoa_Relacionamento();
                AbrirFormEnPanel(UI_Pessoa_Relacionamento);
            }
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 1;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void responsáveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 6;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void EmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 2;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void FornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 3;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void FuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 4;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void TransportadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 5;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void imóvelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Imovel)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Imovel UI_Imovel = new UI_Imovel();
                AbrirFormEnPanel(UI_Imovel);
            }
        }

        private void proprietárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 7;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void locatárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 8;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void fiadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 9;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        #region SUBMENU *PRODUTO*

        private void cadastroToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Servico)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_Servico UI_Produto_Servico = new UI_Produto_Servico();
                AbrirFormEnPanel(UI_Produto_Servico);
            }
        }

        private void impostosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Imposto)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_Imposto UI_Produto_Imposto = new UI_Produto_Imposto();
                AbrirFormEnPanel(UI_Produto_Imposto);
            }
        }

        private void descontoAtacadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Desconto_Atacado)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Produto_Desconto_Atacado UI_Produto_Desconto_Atacado = new UI_Produto_Desconto_Atacado();
                UI_Produto_Desconto_Atacado.Tipo = Tipo_DescontoProduto.Desconto_Atacado;
                AbrirFormEnPanel(UI_Produto_Desconto_Atacado);
            }
        }

        private void descontoPersonalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Desconto_Atacado)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Produto_Desconto_Atacado UI_Produto_Desconto_Atacado = new UI_Produto_Desconto_Atacado();
                UI_Produto_Desconto_Atacado.Tipo = Tipo_DescontoProduto.Desconto_Pessoa;
                AbrirFormEnPanel(UI_Produto_Desconto_Atacado);
            }
        }

        #endregion SUBMENU *PRODUTO*

        #region SUB MENU *RELATÓRIOS*

        private void cadastroDePessoasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Pessoa_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Pessoa_Relatorio UI_Pessoa_Relatorio = new UI_Pessoa_Relatorio();
                AbrirFormEnPanel(UI_Pessoa_Relatorio);
            }
        }

        private void malaDiretaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Pessoa_Etiqueta)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Pessoa_Etiqueta UI_Pessoa_Etiqueta = new UI_Pessoa_Etiqueta();
                AbrirFormEnPanel(UI_Pessoa_Etiqueta);
            }
        }

        #endregion SUB MENU *RELATÓRIOS*

        private void enviarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Email)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Email UI_Email = new UI_Email();
                AbrirFormEnPanel(UI_Email);
            }
        }

        #endregion MENU PRINCIPAL *CADASTRO*

        #region MENU PRINCIPAL *IMOVEL*

        private void locaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Locacao)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Locacao UI_Locacao = new UI_Locacao();
                AbrirFormEnPanel(UI_Locacao);
            }
        }

        private void baixaDeAluguelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Locacao_Baixa)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Locacao_Baixa UI_Locacao_Baixa = new UI_Locacao_Baixa();
                AbrirFormEnPanel(UI_Locacao_Baixa);
            }
        }

        #region SUBMENU *ADMINISTRATIVO*

        private void contratoDeLocaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Locacao_Contrato)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Locacao_Contrato UI_Locacao_Contrato = new UI_Locacao_Contrato();
                AbrirFormEnPanel(UI_Locacao_Contrato);
            }
        }

        private void contratoDePrestaçãoDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Imovel_ContratoServico)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Imovel_ContratoServico UI_Imovel_ContratoServico = new UI_Imovel_ContratoServico();
                AbrirFormEnPanel(UI_Imovel_ContratoServico);
            }
        }

        private void propostaDeAquisiçãoImovélToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Imovel_Proposta)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Imovel_Proposta UI_Imovel_Proposta = new UI_Imovel_Proposta();
                AbrirFormEnPanel(UI_Imovel_Proposta);
            }
        }

        #endregion SUBMENU *ADMINISTRATIVO*

        #endregion MENU PRINCIPAL *IMOVEL*

        #region MENU PRINCIPAL *EQUIPAMENTOS*

        private void locaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is Locacao.frm_Locacao)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                Locacao.frm_Locacao locacao = new Locacao.frm_Locacao();
                AbrirFormEnPanel(locacao);
            }
        }

        private void geolocalizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is Locacao.frm_Locacao)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                Locacao.frm_Locacao locacao = new Locacao.frm_Locacao();
                locacao.tabPage2.Parent = null;
                AbrirFormEnPanel(locacao);
            }
        }

        #endregion MENU PRINCIPAL *EQUIPAMENTOS*

        #region MENU PRINCIPAL *ESTOQUE*

        private void compraDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Entrada)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Produto_Entrada UI_Produto_Entrada = new UI_Produto_Entrada();
                UI_Produto_Entrada.Tipo = Tipo_Entrada_Produto.Compra;
                AbrirFormEnPanel(UI_Produto_Entrada);
            }
        }

        private void entradaDeProduçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Entrada)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Produto_Entrada UI_Produto_Entrada = new UI_Produto_Entrada();
                UI_Produto_Entrada.Tipo = Tipo_Entrada_Produto.Producao;
                AbrirFormEnPanel(UI_Produto_Entrada);
            }
        }

        private void entradaDeProdutoPorXMLNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Entrada_XML)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Produto_Entrada_XML UI_Produto_Entrada_XML = new UI_Produto_Entrada_XML();
                AbrirFormEnPanel(UI_Produto_Entrada_XML);
            }
        }

        private void atualizaçãoDeValorExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_AtualizaValorXLS)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_AtualizaValorXLS UI_Produto_AtualizaValorXLS = new UI_Produto_AtualizaValorXLS();
                UI_Produto_AtualizaValorXLS.Tipo = 1;
                AbrirFormEnPanel(UI_Produto_AtualizaValorXLS);
            }
        }

        private void ajusteDeEstoqueCorreçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_AjusteEstoque)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_AjusteEstoque UI_Produto_AjusteEstoque = new UI_Produto_AjusteEstoque();
                AbrirFormEnPanel(UI_Produto_AjusteEstoque);
            }
        }

        private void cadastroDeProdutoExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_AtualizaValorXLS)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_AtualizaValorXLS UI_Produto_AtualizaValorXLS = new UI_Produto_AtualizaValorXLS();
                UI_Produto_AtualizaValorXLS.Tipo = 2;
                AbrirFormEnPanel(UI_Produto_AtualizaValorXLS);
            }
        }

        private void gradeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grade)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Grade UI_Grade = new UI_Grade();
                AbrirFormEnPanel(UI_Grade);
            }
        }

        private void reajusteDeValorVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_AjusteValor)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_AjusteValor UI_Produto_AjusteValor = new UI_Produto_AjusteValor();
                AbrirFormEnPanel(UI_Produto_AjusteValor);
            }
        }

        private void controleDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Balanco)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_Balanco UI_Produto_Balanco = new UI_Produto_Balanco();
                AbrirFormEnPanel(UI_Produto_Balanco);
            }
        }

        private void movimentarEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_EstoqueMovimento)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_EstoqueMovimento UI_Produto_EstoqueMovimento = new UI_Produto_EstoqueMovimento();
                AbrirFormEnPanel(UI_Produto_EstoqueMovimento);
            }
        }

        #region SUB MENU *RELATÓRIOS*

        private void etiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Etiqueta)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_Etiqueta UI_Produto_Etiqueta = new UI_Produto_Etiqueta();
                AbrirFormEnPanel(UI_Produto_Etiqueta);
            }
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Produto_Relatorio UI_Produto_Relatorio = new UI_Produto_Relatorio();
                AbrirFormEnPanel(UI_Produto_Relatorio);
            }
        }

        private void resumoDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_ResumoVenda)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_ResumoVenda UI_Produto_ResumoVenda = new UI_Produto_ResumoVenda();
                AbrirFormEnPanel(UI_Produto_ResumoVenda);
            }
        }

        private void movimentaçãoDeProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Produto_Movimento)
                {
                    Frm.BringToFront();
                    aux = true;
                }

            if (aux == false)
            {
                UI_Produto_Movimento UI_Produto_Movimento = new UI_Produto_Movimento();
                AbrirFormEnPanel(UI_Produto_Movimento);
            }
        }

        private void entradaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Produto_Entrada_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }

            if (aux == false)
            {
                UI_Produto_Entrada_Relatorio UI_Produto_Entrada_Relatorio = new UI_Produto_Entrada_Relatorio();
                AbrirFormEnPanel(UI_Produto_Entrada_Relatorio);
            }
        }

        #endregion SUB MENU *RELATÓRIOS*

        #endregion MENU PRINCIPAL *ESTOQUE*

        #region MENU PRINCIPAL *FINANCEIRO*

        private void CaixaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_FluxoCaixa)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }

            if (aux == false)
            {
                UI_FluxoCaixa UI_FluxoCaixa = new UI_FluxoCaixa();
                UI_FluxoCaixa.Tipo_Caixa = 2;
                AbrirFormEnPanel(UI_FluxoCaixa);
            }
        }

        private void LivroCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_FluxoCaixa)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_FluxoCaixa UI_FluxoCaixa = new UI_FluxoCaixa();
                UI_FluxoCaixa.Tipo_Caixa = 1;
                AbrirFormEnPanel(UI_FluxoCaixa);
            }
        }

        private void PlanejamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Financeiro_Planejamento)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Financeiro_Planejamento UI_Financeiro_Planejamento = new UI_Financeiro_Planejamento();
                AbrirFormEnPanel(UI_Financeiro_Planejamento);
            }
        }

        private void ContasÀPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CPagar)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CPagar UI_CPagar = new UI_CPagar();
                UI_CPagar.Tipo = Tipo_Financeiro.Lancamento_Baixa;
                AbrirFormEnPanel(UI_CPagar);
            }
        }

        private void ContasÀReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CReceber)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CReceber UI_CReceber = new UI_CReceber();
                UI_CReceber.Tipo = Tipo_Financeiro.Lancamento_Baixa;
                AbrirFormEnPanel(UI_CReceber);
            }
        }

        private void consultaContasÀPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CPagar)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CPagar UI_CPagar = new UI_CPagar();
                UI_CPagar.Tipo = Tipo_Financeiro.Consulta;
                AbrirFormEnPanel(UI_CPagar);
            }
        }

        private void consultaContasÀReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CReceber)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CReceber UI_CReceber = new UI_CReceber();
                UI_CReceber.Tipo = Tipo_Financeiro.Consulta;
                AbrirFormEnPanel(UI_CReceber);
            }
        }

        private void baixaDeCartãoNovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CReceber_Cartao)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Cartao UI_Cartao = new UI_Cartao();
                AbrirFormEnPanel(UI_Cartao);
            }
        }

        private void baixaDeCartãoCréditoDébitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CReceber_Cartao)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CReceber_Cartao UI_CReceber_Cartao = new UI_CReceber_Cartao();
                AbrirFormEnPanel(UI_CReceber_Cartao);
            }
        }

        private void ControleDeChequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Cheque)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Cheque UI_Cheque = new UI_Cheque();
                AbrirFormEnPanel(UI_Cheque);
            }
        }

        #region SUB MENU *FATURAR*

        private void PedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Fatura)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Venda_Fatura UI_Venda_Fatura = new UI_Venda_Fatura();
                AbrirFormEnPanel(UI_Venda_Fatura);
            }
        }

        #endregion SUB MENU *FATURAR*

        #region SUB MENU *COMISSÕES*

        private void PedidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Comissao)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Venda_Comissao UI_Venda_Comissao = new UI_Venda_Comissao();
                AbrirFormEnPanel(UI_Venda_Comissao);
            }
        }

        #endregion SUB MENU *COMISSÕES*

        #region SUB MENU *RELATÓRIOS*

        private void ContasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CReceber_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CReceber_Relatorio UI_CReceber_Relatorio = new UI_CReceber_Relatorio();
                AbrirFormEnPanel(UI_CReceber_Relatorio);
            }
        }

        private void ContasÀPagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CPagar_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CPagar_Relatorio UI_CPagar_Relatorio = new UI_CPagar_Relatorio();
                AbrirFormEnPanel(UI_CPagar_Relatorio);
            }
        }

        private void fluxoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_FluxoCaixa_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_FluxoCaixa_Relatorio UI_FluxoCaixa_Relatorio = new UI_FluxoCaixa_Relatorio();
                AbrirFormEnPanel(UI_FluxoCaixa_Relatorio);
            }
        }

        private void chequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Cheque_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Cheque_Relatorio UI_Cheque_Relatorio = new UI_Cheque_Relatorio();
                AbrirFormEnPanel(UI_Cheque_Relatorio);
            }
        }

        private void cobrançaBancáriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Boleto_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Boleto_Relatorio UI_Boleto_Relatorio = new UI_Boleto_Relatorio();
                AbrirFormEnPanel(UI_Boleto_Relatorio);
            }
        }

        private void cartaDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Carta_Cobranca)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Carta_Cobranca UI_Carta_Cobranca = new UI_Carta_Cobranca();
                AbrirFormEnPanel(UI_Carta_Cobranca);
            }
        }

        private void cartãoDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Cartao_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Cartao_Relatorio UI_Cartao_Relatorio = new UI_Cartao_Relatorio();
                AbrirFormEnPanel(UI_Cartao_Relatorio);
            }
        }

        #endregion SUB MENU *RELATÓRIOS*

        #region SUB MENU *COBRANÇA BANCÁRIA*

        private void gerarBoletosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Boleto)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Boleto UI_Boleto = new UI_Boleto();
                UI_Boleto.Tipo = Tipo_Boleto.Gerar;

                AbrirFormEnPanel(UI_Boleto);
            }
        }

        private void cobrançaBancáriaMatricialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Boleto)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Boleto UI_Boleto = new UI_Boleto();
                UI_Boleto.Tipo = Tipo_Boleto.Matricial;

                AbrirFormEnPanel(UI_Boleto);
            }
        }

        private void baixarBolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Boleto)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Boleto UI_Boleto = new UI_Boleto();
                UI_Boleto.Tipo = Tipo_Boleto.Baixa;

                AbrirFormEnPanel(UI_Boleto);
            }
        }

        private void tratarRetornoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Boleto_Remessa)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Boleto_Remessa UI_Boleto_Remessa = new UI_Boleto_Remessa();
                AbrirFormEnPanel(UI_Boleto_Remessa);
            }
        }

        private void retornoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Boleto_Retorno)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Boleto_Retorno UI_Boleto_Retorno = new UI_Boleto_Retorno();
                AbrirFormEnPanel(UI_Boleto_Retorno);
            }
        }

        #endregion SUB MENU *COBRANÇA BANCÁRIA*

        private void ReciboAvulsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Recibo)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Recibo UI_Recibo = new UI_Recibo();
                AbrirFormEnPanel(UI_Recibo);
            }
        }

        private void emissãoDeDuplicatasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Duplicata)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Duplicata UI_Duplicata = new UI_Duplicata();
                AbrirFormEnPanel(UI_Duplicata);
            }
        }

        #endregion MENU PRINCIPAL *FINANCEIRO*

        #region MENU PRINCIPAL *VENDAS*

        private void PedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Venda UI_Venda = new UI_Venda();
                UI_Venda.Tipo = 1;
                AbrirFormEnPanel(UI_Venda);
            }
        }

        private void vendaRápidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                }
            }
            if (aux == false)
            {
                UI_Venda UI_Venda = new UI_Venda();
                UI_Venda.Tipo = 0;
                AbrirFormEnPanel(UI_Venda);
            }
        }

        private void frenteDeCaixaPDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI_PDV UI_PDV = new UI_PDV();
            UI_PDV.ShowDialog();
        }

        private void OrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Orcamento)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                }
            }
            if (aux == false)
            {
                UI_Orcamento UI_Orcamento = new UI_Orcamento();
                AbrirFormEnPanel(UI_Orcamento);
            }
        }

        private void frenteDeCaixaPDV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.UI_FORMS.UI_PDV_II UI_PDV = new UI.UI_FORMS.UI_PDV_II();
            UI_PDV.Show();
        }

        #region SUB MENU *MANUTENÇÃO DE VENDAS*

        private void impressãoDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Manutacao)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Venda_Manutacao UI_Venda_Manutacao = new UI_Venda_Manutacao();
                UI_Venda_Manutacao.Tipo_Manutencao = Manutencao_Venda.Impressao;

                AbrirFormEnPanel(UI_Venda_Manutacao);
            }
        }

        private void cancelamentoDeVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Manutacao)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Venda_Manutacao UI_Venda_Manutacao = new UI_Venda_Manutacao();
                UI_Venda_Manutacao.Tipo_Manutencao = Manutencao_Venda.Cancelamento;

                AbrirFormEnPanel(UI_Venda_Manutacao);
            }
        }

        private void conferênciaDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Conferencia)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Venda_Conferencia UI_Venda_Conferencia = new UI_Venda_Conferencia();
                AbrirFormEnPanel(UI_Venda_Conferencia);
            }
        }

        private void devoluçãoDeVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Devolucao)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Venda_Devolucao UI_Venda_Devolucao = new UI_Venda_Devolucao();
                AbrirFormEnPanel(UI_Venda_Devolucao);
            }
        }

        #endregion SUB MENU *MANUTENÇÃO DE VENDAS*

        #region SUB MENU *RELATÓRIOS*

        private void TransporteDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Transporte)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Venda_Transporte UI_Venda_Transporte = new UI_Venda_Transporte();
                AbrirFormEnPanel(UI_Venda_Transporte);
            }
        }

        private void vendasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Venda_Relatorio UI_Venda_Relatorio = new UI_Venda_Relatorio();
                AbrirFormEnPanel(UI_Venda_Relatorio);
            }
        }

        private void resumoProduçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Etiqueta_Producao)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Etiqueta_Producao UI_Etiqueta_Producao = new UI_Etiqueta_Producao();
                AbrirFormEnPanel(UI_Etiqueta_Producao);
            }
        }

        #endregion SUB MENU *RELATÓRIOS*

        #endregion MENU PRINCIPAL *VENDAS*

        #region MENU PRINCIPAL *NF-e*

        private void emitirNotaFiscalAvulsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_NFe_Emissor_Completo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_NFe_Emissor_Completo UI_NFe_Emissor_Completo = new UI_NFe_Emissor_Completo();
                AbrirFormEnPanel(UI_NFe_Emissor_Completo);
            }
        }

        private void notaFiscalDevoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_NFe_Emissor_Completo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_NFe_Emissor_Completo UI_NFe_Emissor_Completo = new UI_NFe_Emissor_Completo();
                UI_NFe_Emissor_Completo.NF_Devolucao = true;
                AbrirFormEnPanel(UI_NFe_Emissor_Completo);
            }
        }

        private void emitirNFeDeVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Venda_NF)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }

            if (aux == false)
            {
                UI_Venda_NF UI_Venda_NF = new UI_Venda_NF();
                UI_Venda_NF.Filtra_Empresa = true;
                AbrirFormEnPanel(UI_Venda_NF);
            }
        }

        private void emitirNFeDeVendaEmpresaDiferenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Venda_NF)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }

            if (aux == false)
            {
                UI_Venda_NF UI_Venda_NF = new UI_Venda_NF();
                UI_Venda_NF.Filtra_Empresa = false;
                AbrirFormEnPanel(UI_Venda_NF);
            }
        }

        private void GerenciarNFeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_NFe_Util)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_NFe_Util UI_NFe_Util = new UI_NFe_Util();
                AbrirFormEnPanel(UI_NFe_Util);
            }
        }

        private void gerenciarCFeSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CFe_Util)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_CFe_Util UI_CFe_Util = new UI_CFe_Util();
                AbrirFormEnPanel(UI_CFe_Util);
            }
        }

        private void notaFiscalConsumidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_NFCe_Emissor_Completo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_NFCe_Emissor_Completo UI_NFCe_Emissor_Completo = new UI_NFCe_Emissor_Completo();
                AbrirFormEnPanel(UI_NFCe_Emissor_Completo);
            }
        }

        private void inutilizarNumeraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_NFe_InutilizaNumero)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }

            if (aux == false)
            {
                UI_NFe_InutilizaNumero UI_NFe_InutilizaNumero = new UI_NFe_InutilizaNumero();
                AbrirFormEnPanel(UI_NFe_InutilizaNumero);
            }
        }

        #region SUB MENU *RELATÓRIOS*

        private void notaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_NFe_CFe_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_NFe_CFe_Relatorio UI_NFe_CFe_Relatorio = new UI_NFe_CFe_Relatorio();
                UI_NFe_CFe_Relatorio.Tipo = Tipo_NF_SAT.NFe;
                AbrirFormEnPanel(UI_NFe_CFe_Relatorio);
            }
        }

        private void cupomFiscalCFeSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_NFe_CFe_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_NFe_CFe_Relatorio UI_NFe_CFe_Relatorio = new UI_NFe_CFe_Relatorio();
                UI_NFe_CFe_Relatorio.Tipo = Tipo_NF_SAT.SAT;
                AbrirFormEnPanel(UI_NFe_CFe_Relatorio);
            }
        }

        private void sintegraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Sintegra)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }

            if (aux == false)
            {
                UI_Sintegra UI_Sintegra = new UI_Sintegra();
                AbrirFormEnPanel(UI_Sintegra);
            }
        }

        #endregion SUB MENU *RELATÓRIOS*

        #endregion MENU PRINCIPAL *NF-e*

        #region MENU PRINCIPAL *CONTÁBIL*

        #region SUB MENU *RELATÓRIOS*

        private void cadastroDeFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Pessoa_Relatorio_CadastroFuncionario)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Pessoa_Relatorio_CadastroFuncionario UI_Pessoa_Relatorio_CadastroFuncionario = new UI_Pessoa_Relatorio_CadastroFuncionario();
                AbrirFormEnPanel(UI_Pessoa_Relatorio_CadastroFuncionario);
            }
        }

        private void contratoDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_ContratoServico)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_ContratoServico UI_ContratoServico = new UI_ContratoServico();
                AbrirFormEnPanel(UI_ContratoServico);
            }
        }

        private void folhaDePagamentoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_FolhaPagto_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_FolhaPagto_Relatorio UI_FolhaPagto_Relatorio = new UI_FolhaPagto_Relatorio();
                AbrirFormEnPanel(UI_FolhaPagto_Relatorio);
            }
        }

        #endregion SUB MENU *RELATÓRIOS*

        #region SUB MENU *FOLHA DE PAGAMENTO*

        private void cadastroDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Evento)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Evento UI_Evento = new UI_Evento();
                AbrirFormEnPanel(UI_Evento);
            }
        }

        private void folhaDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_FolhaPagto)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_FolhaPagto UI_FolhaPagto = new UI_FolhaPagto();
                AbrirFormEnPanel(UI_FolhaPagto);
            }
        }

        #endregion SUB MENU *FOLHA DE PAGAMENTO*

        #region SUB MENU *CONTROLE DE DOCUMENTOS*

        private void gerarControleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_ControleDoc)
                {
                    Frm.BringToFront();
                    aux = true;
                }

            if (aux == false)
            {
                UI_ControleDoc UI_ControleDoc = new UI_ControleDoc();
                UI_ControleDoc.Tipo = 1;
                AbrirFormEnPanel(UI_ControleDoc);
            }
        }

        private void entradaDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_ControleDoc)
                {
                    Frm.BringToFront();
                    aux = true;
                }

            if (aux == false)
            {
                UI_ControleDoc UI_ControleDoc = new UI_ControleDoc();
                UI_ControleDoc.Tipo = 2;
                AbrirFormEnPanel(UI_ControleDoc);
            }
        }

        #endregion SUB MENU *CONTROLE DE DOCUMENTOS*

        #endregion MENU PRINCIPAL *CONTÁBIL*

        #region MENU PRINCIPAL *ORDEM DE SERVIÇO*

        private void OrdemDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Ordem_Servico)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Ordem_Servico UI_Ordem_Servico = new UI_Ordem_Servico();
                AbrirFormEnPanel(UI_Ordem_Servico);
            }
        }

        private void monitorOrdemDeServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Ordem_Servico_Monitor)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Ordem_Servico_Monitor UI_Ordem_Servico_Monitor = new UI_Ordem_Servico_Monitor();
                AbrirFormEnPanel(UI_Ordem_Servico_Monitor);
            }
        }

        #region SUB MENU *RELATÓRIOS*

        private void ordemDeServiçoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Ordem_Servico_Relatorio)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Ordem_Servico_Relatorio UI_Ordem_Servico_Relatorio = new UI_Ordem_Servico_Relatorio();
                AbrirFormEnPanel(UI_Ordem_Servico_Relatorio);
            }
        }

        #endregion SUB MENU *RELATÓRIOS*

        #endregion MENU PRINCIPAL *ORDEM DE SERVIÇO*

        #region MENU PRINCIPAL *CONFIGURAÇÕES*

        #region SUBMENU *CADASTROS GERAIS*

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Cliente;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void TransportadoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Transportadora;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void FornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Fornecedor;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void FuncionárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Funcionario;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void EmpresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Empresa;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void EndereçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Endereco;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void TelefoneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Telefone;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void EmailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_eMail;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void cadastroDeInformaçõesAdicionaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Cadastro_Personalizado;
                AbrirFormEnPanel(UI_Parametro);
            }
        }

        #endregion SUBMENU *CADASTROS GERAIS*

        #region SUBMENU *IMOVEL*

        private void tipoDeCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Custo_Imovel;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void tipoDeImóvelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Imovel;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        #endregion SUBMENU *IMOVEL*

        #region SUBMENU *PRODUTOS, VENDAS, NF-e*

        private void UnidadeProdutoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Unidade;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void gradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Grade;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void GrupoEmNívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_GrupoNivel)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_GrupoNivel UI_GrupoNivel = new UI_GrupoNivel();
                AbrirFormEnPanel(UI_GrupoNivel);
            }
        }

        private void TabelaValorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_TabelaValor)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_TabelaValor UI_TabelaValor = new UI_TabelaValor();
                AbrirFormEnPanel(UI_TabelaValor);
            }
        }

        private void TiposDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_DocumentoCompra;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void CFOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CFOP)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_CFOP UI_CFOP = new UI_CFOP();
                AbrirFormEnPanel(UI_CFOP);
            }
        }

        private void ComodatoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Comodato;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void ImpostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Imposto)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Imposto UI_Imposto = new UI_Imposto();
                AbrirFormEnPanel(UI_Imposto);
            }
        }

        private void tipoDeNotaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_NFe_TipoEmissao)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_NFe_TipoEmissao UI_NFe_TipoEmissao = new UI_NFe_TipoEmissao();
                AbrirFormEnPanel(UI_NFe_TipoEmissao);
            }
        }

        #endregion SUBMENU *PRODUTOS, VENDAS, NF-e*

        #region SUBMENU *FINANCEIRO*

        private void CaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Caixa;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void PlanoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_PlanoConta)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_PlanoConta UI_PlanoConta = new UI_PlanoConta();
                AbrirFormEnPanel(UI_PlanoConta);
            }
        }

        private void TiposDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Pagamento)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Pagamento UI_Pagamento = new UI_Pagamento();
                AbrirFormEnPanel(UI_Pagamento);
            }
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Banco)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                }
            }
            if (aux == false)
            {
                UI_Banco UI_Banco = new UI_Banco();
                AbrirFormEnPanel(UI_Banco);
            }
        }

        private void cedenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Cedente)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                }
            }
            if (aux == false)
            {
                UI_Cedente UI_Cedente = new UI_Cedente();
                AbrirFormEnPanel(UI_Cedente);
            }
        }

        #endregion SUBMENU *FINANCEIRO*

        #region SUBMENU *ORDEM DE SERVIÇO*

        private void AtendimentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Atendimento;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void FabricanteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Fabricante;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void EquipamentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_Equipamento;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        #endregion SUBMENU *ORDEM DE SERVIÇO*

        #region SUBMENU *CONTÁBIL*

        private void tipoFolhaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_FolhaPagto;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void tipoDeDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Grupo)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Grupo UI_Grupo = new UI_Grupo();
                UI_Grupo.Tipo = Tipo_Grupo.Tipo_DocumentoContabil;
                AbrirFormEnPanel(UI_Grupo);
            }
        }

        private void documentosContábeisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_ControleDoc_Tipo)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            if (aux == false)
            {
                UI_ControleDoc_Tipo UI_ControleDoc_Tipo = new UI_ControleDoc_Tipo();
                AbrirFormEnPanel(UI_ControleDoc_Tipo);
            }
        }

        #endregion SUBMENU *CONTÁBIL*

        #region SUBMENU *MUNICIPIOS*

        private void PaísToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Municipio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Municipio UI_Municipio = new UI_Municipio();
                UI_Municipio.Tipo_Municipio = 1;
                AbrirFormEnPanel(UI_Municipio);
            }
        }

        private void UFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Municipio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Municipio UI_Municipio = new UI_Municipio();
                UI_Municipio.Tipo_Municipio = 2;
                AbrirFormEnPanel(UI_Municipio);
            }
        }

        private void MunicípiosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Municipio)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Municipio UI_Municipio = new UI_Municipio();
                UI_Municipio.Tipo_Municipio = 3;
                AbrirFormEnPanel(UI_Municipio);
            }
        }

        #endregion SUBMENU *MUNICIPIOS*

        #region SUBMENU *PARAMETROS*

        private void financeiroToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Financeiro;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void impostosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_NCM)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_NCM UI_NCM = new UI_NCM();
                AbrirFormEnPanel(UI_NCM);
            }
        }

        private void vendasToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Vendas;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void ordemDeServiçoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.OrdemServico;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void mobileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Mobile;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void permissõesDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Usuario;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void cadastrosDiversosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Parametro_Cadastro;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void nFeNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.NFe_NFC_e;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void cFeSATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.SAT;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void imagensSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Imagens;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        private void configuraçãoDeEMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Parametro)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }
            }
            if (aux == false)
            {
                UI_Parametro UI_Parametro = new UI_Parametro();
                UI_Parametro.Tipo = Tipo_Parametro.Config_eMail;

                AbrirFormEnPanel(UI_Parametro);
            }
        }

        #endregion SUBMENU *PARAMETROS*

        #endregion MENU PRINCIPAL *CONFIGURAÇÕES*

        #region MENU PRINCIPAL *MANUTENÇÃO*

        private void AssistênciaRemotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Parametro_Sistema.Caminho_Sistema + @"Sistema\teamviewer.exe");

            string msg = "ENTRE EM CONTATO COM SUPORTE TÉCNICO!\n\n";

            msg += "Informe sua ID!";

            MessageBox.Show(msg, "SUPORTE REMOTO", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void BancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_ManutencaoBD)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_ManutencaoBD UI_ManutencaoBD = new UI_ManutencaoBD();
                AbrirFormEnPanel(UI_ManutencaoBD);
            }
        }

        private void CópiaDeSegurançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Backup)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }

            if (aux == false)
            {
                UI_Backup UI_Backup = new UI_Backup();
                AbrirFormEnPanel(UI_Backup);
            }
        }

        #endregion MENU PRINCIPAL *MANUTENÇÃO*

        #region MENU PRINCIPAL *SAIR*

        private void EncerrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TrocaUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msgbox;
            msgbox = MessageBox.Show(util_msg.msg_TrocadeUsuario, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (msgbox == DialogResult.Yes)
            {
                foreach (Form Frm in this.MdiChildren)
                {
                    Frm.Close();
                    Frm.Dispose();
                }

                this.Dispose();
                UI_Login UI_Login = new UI_Login();
                UI_Login.Show();
            }
        }

        #endregion MENU PRINCIPAL *SAIR*

        #region MENU ACESSO RAPIDO

        private void tsb_CadastroCliente_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_Pessoa)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_Pessoa UI_Pessoa = new UI_Pessoa();
                UI_Pessoa.TipoPessoa = 1;
                AbrirFormEnPanel(UI_Pessoa);
            }
        }

        private void tsb_CadastroProduto_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Produto_Servico)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Produto_Servico UI_Produto_Servico = new UI_Produto_Servico();
                AbrirFormEnPanel(UI_Produto_Servico);
            }
        }

        private void tsb_PDV_Click(object sender, EventArgs e)
        {
            UI_PDV UI_PDV = new UI_PDV();
            UI_PDV.ShowDialog();
        }

        private void tsb_Pedido_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Venda)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Venda UI_Venda = new UI_Venda();
                UI_Venda.Tipo = 1;
                AbrirFormEnPanel(UI_Venda);
            }
        }

        private void tsb_Orcamento_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Orcamento)
                {
                    DialogResult msgbox = MessageBox.Show("Fechar " + Frm.Text + "?", "Fechar Janelas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_Orcamento ui = new UI_Orcamento();
                AbrirFormEnPanel(ui);
            }
        }

        private void tsb_OS_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_Ordem_Servico)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_Ordem_Servico UI_Ordem_Servico = new UI_Ordem_Servico();
                AbrirFormEnPanel(UI_Ordem_Servico);
            }
        }

        private void tsb_Caixa_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_FluxoCaixa)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_FluxoCaixa UI_FluxoCaixa = new UI_FluxoCaixa();
                UI_FluxoCaixa.Tipo_Caixa = 2;
                AbrirFormEnPanel(UI_FluxoCaixa);
            }
        }

        private void tsb_CPagar_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CPagar)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CPagar UI_CPagar = new UI_CPagar();
                UI_CPagar.Tipo = Tipo_Financeiro.Lancamento_Baixa;
                AbrirFormEnPanel(UI_CPagar);
            }
        }

        private void tsb_CReceber_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CReceber)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_CReceber UI_CReceber = new UI_CReceber();
                UI_CReceber.Tipo = Tipo_Financeiro.Lancamento_Baixa;
                AbrirFormEnPanel(UI_CReceber);
            }
        }

        private void tsb_Gerenciador_CFe_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_CFe_Util)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_CFe_Util UI_CFe_Util = new UI_CFe_Util();
                AbrirFormEnPanel(UI_CFe_Util);
            }
        }

        private void tsb_GerenciadorNFe_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_NFe_Util)
                {
                    Frm.BringToFront();
                    aux = true;
                    return;
                }
            }
            if (aux == false)
            {
                UI_NFe_Util UI_NFe_Util = new UI_NFe_Util();
                AbrirFormEnPanel(UI_NFe_Util);
            }
        }

        private void tsb_TrocaUsuario_Click(object sender, EventArgs e)
        {
            DialogResult msgbox;
            msgbox = MessageBox.Show(util_msg.msg_TrocadeUsuario, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msgbox == DialogResult.Yes)
            {
                foreach (Form Frm in this.MdiChildren)
                {
                    Frm.Close();
                    Frm.Dispose();
                }
                this.Dispose();
                UI_Login UI_Login = new UI_Login();
                UI_Login.Show();
            }
        }

        private void tsb_Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion MENU ACESSO RAPIDO

        private void combustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_FROTA_COMBUSTIVEL)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_FROTA_COMBUSTIVEL combustivel = new UI_FROTA_COMBUSTIVEL();
                AbrirFormEnPanel(combustivel);
            }
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_FROTA_VEICULOS)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_FROTA_VEICULOS combustivel = new UI_FROTA_VEICULOS();
                AbrirFormEnPanel(combustivel);
            }
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI_Pessoa UI_Pessoa = new UI_Pessoa();
            UI_Pessoa.TipoPessoa = 1;
            AbrirFormEnPanel(UI_Pessoa);
        }

        private void tabForms_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu_Principal.Dock = DockStyle.Left;
            menu_Principal.BackColor = Color.Azure;
        }

        private void AtualizarBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
                if (Frm is UI_AtualizarBanco)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_FormAberto, Frm.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                    {
                        Frm.BringToFront();
                        aux = true;
                        return;
                    }
                    else
                    {
                        Frm.Close();
                        aux = false;
                    }
                }

            if (aux == false)
            {
                UI_AtualizarBanco atualizar = new UI_AtualizarBanco();
                AbrirFormEnPanel(atualizar);
            }
        }

        private void AbastecimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool aux = false;
            foreach (Form Frm in this.MdiChildren)
            {
                if (Frm is UI_FROTA_ABASTECIMENTO)
                {
                    Frm.BringToFront();
                    aux = true;
                }
            }
            if (aux == false)
            {
                UI_FROTA_ABASTECIMENTO UI_Abastecimento = new UI_FROTA_ABASTECIMENTO();
                AbrirFormEnPanel(UI_Abastecimento);
            }
        }

        private void tss_Usuario_MouseLeave(object sender, EventArgs e)
        {
            tss_Usuario.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void tss_Usuario_MouseEnter(object sender, EventArgs e)
        {
            tss_Usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
        }
    }
}