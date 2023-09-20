using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_PAGINA_INICIAL : Form
    {
        private int tempo = 250;

        public UI_PAGINA_INICIAL()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE

        private BLL_Usuario_Acesso BLL_Usuario_Acesso;
        private BLL_Imagem BLL_Imagem;
        private BLL_Venda_Mobile BLL_Venda_Mobile;
        private BLL_Sistema BLL_Sistema;

        #endregion VARIAVEIS DE CLASSE

        #region ESTRUTURA

        private DTO_Usuario_Parametros Usuario_Parametros;
        private DTO_Imagem Imagem;
        private DTO_Mobile Mobile;
        private DTO_Sistema Sistema;

        #endregion ESTRUTURA

        private void UI_PAGINA_INICIAL_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    DataTable _DT_Imagem = new DataTable();
            //    BLL_Imagem = new BLL_Imagem();
            //    Imagem = new DTO_Imagem();
            //    Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
            //    Imagem.Tipo = 2;
            //    _DT_Imagem = BLL_Imagem.Busca(Imagem);
            //    byte[] bits = (byte[])(_DT_Imagem.Rows[0][0]);
            //    MemoryStream memorybits = new MemoryStream(bits);
            //    Bitmap ImagemConvertida = new Bitmap(memorybits);
            //    img_Empresa.Image = ImagemConvertida;

            //}
            //catch (Exception)
            //{
            //    img_Empresa.Image = null;
            //}
            try
            {
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
                this.BackgroundImage = ImagemConvertida;

                #endregion LOGO EMPRESA
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void UI_PAGINA_INICIAL_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Timer_data_hora_Tick(object sender, EventArgs e)
        {
        }

        private void Timer_tempo_atualizacao_Tick(object sender, EventArgs e)
        {
        }
    }
}