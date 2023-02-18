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
using System.IO;

namespace Sistema.UI
{
    public partial class UI_Imagem : Form
    {
        public UI_Imagem()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE
        BLL_Produto BLL_Produto;
        #endregion

        #region ESTRUTURA
        DTO_Produto Produto;
        #endregion

        #region PROPRIEDADES
        /// <summary>
        /// <para>1 - IMAGEM PRODUTO</para>
        /// </summary>
        public int Tipo { get; set; }
        public int ID_Produto { get; set; }
        #endregion

        #region ROTINAS
        private void Carrega_Imagem_Produto()
        {
            try
            {
                BLL_Produto = new BLL_Produto();
                Produto = new DTO_Produto();

                Produto.ID = ID_Produto;
                Produto.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT = new DataTable();
                _DT = BLL_Produto.Busca_Imagem(Produto);

                byte[] bits = (byte[])(_DT.Rows[0][0]);
                MemoryStream memorybits = new MemoryStream(bits);
                Bitmap ImagemConvertida = new Bitmap(memorybits);
                pc_Imagem.Image = ImagemConvertida;
            }
            catch (Exception)
            {
                pc_Imagem.Image = null;
            }
        }

        #endregion

        #region FORM
        private void UI_Imagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void UI_Imagem_Load(object sender, EventArgs e)
        {
            switch (Tipo)
            {
                case 1:
                    Carrega_Imagem_Produto();
                    break;
            }
        }
        #endregion
    }
}
