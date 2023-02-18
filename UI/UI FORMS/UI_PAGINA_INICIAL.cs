using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Data.SqlClient;
using Microsoft.Win32;


namespace Sistema.UI
{
    public partial class UI_PAGINA_INICIAL : Form
    {
        int tempo = 250;
        public UI_PAGINA_INICIAL()
        {
            InitializeComponent();
        }


        #region VARIAVEIS DE CLASSE
        BLL_Usuario_Acesso BLL_Usuario_Acesso;
        BLL_Imagem BLL_Imagem;
        BLL_Venda_Mobile BLL_Venda_Mobile;
        BLL_Sistema BLL_Sistema;
        #endregion

        #region ESTRUTURA
        DTO_Usuario_Parametros Usuario_Parametros;
        DTO_Imagem Imagem;
        DTO_Mobile Mobile;
        DTO_Sistema Sistema;
        #endregion

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

               
                #endregion

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
                #endregion
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

        private void Lbl_tempo_de_atualizacao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tempo = 250;
        }
    }
}
