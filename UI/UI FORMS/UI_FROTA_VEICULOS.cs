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
using System.Data.SqlClient;

namespace Sistema.UI
{
    public partial class UI_FROTA_VEICULOS : Form
    {

        SqlConnection sqlConn = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);

        public UI_FROTA_VEICULOS()
        {
            InitializeComponent();
        }
        private void gravar()
        {
            //definição do comando sql
            string sql = " INSERT INTO FROTA_VEICULO (RENAVAM,   " +
                                                  " RNTRC,       " +
                                                  " PLACA,       " +
                                                  " ANOMOD,      " +
                                                  " ANOFAB,      " +
                                                  " CHASSI,      " +
                                                  " MARCAMODELO, " +
                                                  " KMINICIAL,   " +
                                                  " KMATUAL)     " +
                                                  " VALEUS (       " +
                                                  " @RENAVAM,    " +
                                                  " @RNTRC,      " +
                                                  " @PLACA,      " +
                                                  " @ANOMOD,     " +
                                                  " @ANOFAB,     " +
                                                  " @CHASSI,     " +
                                                  " @MARCAMODELO, " +
                                                  " @KMINICIAL,  " +
                                                  " @KMATUAL )    ";

            SqlCommand comando = new SqlCommand(sql, sqlConn);
            comando.Parameters.Add(new SqlParameter("@RENAVAM", txt_renavam.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@RNTRC", tbox_rntrc.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@PLACA", tbox_placa.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@ANOMOD", tbox_anoModelo.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@ANOFAB", tbox_anoFabrica.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@CHASSI", tbox_chassi.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@MARCAMODELO", tbox_marcaModelo.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@KMINICIAL", tbox_kminicial.Text.Trim()));
            comando.Parameters.Add(new SqlParameter("@KMATUAL", tbox_kmfinal.Text.Trim()));

            sqlConn.Open();
            comando.ExecuteNonQuery();
            sqlConn.Close();

            MessageBox.Show("Registro gravado com sucesso", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void atualizar()
        {
            //definição do comando sql
            string sql = " UPDATE FROTA_VEICULO SET RENAVAM     = @RENAVAM,     " +
                                                  " RNTRC       = @RNTRC,       " +
                                                  " PLACA       = @PLACA,       " +
                                                  " ANOMOD      = @ANOMOD,      " +
                                                  " ANOFAB      = @ANOFAB,      " +
                                                  " CHASSI      = @CHASSI,      " +
                                                  " MARCAMODELO = @MARCAMODELO, " +
                                                  " KMINICIAL   = @KMINICIAL,   " +
                                                  " KMATUAL     = @KMATUAL   WHERE ID =  " + txt_ID.Text;
                                    
           
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("@RENAVAM",txt_renavam.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@RNTRC",  tbox_rntrc.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@PLACA",  tbox_placa.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@ANOMOD", tbox_anoModelo.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@ANOFAB", tbox_anoFabrica.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@CHASSI", tbox_chassi.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@MARCAMODELO", tbox_marcaModelo.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@KMINICIAL",   tbox_kminicial.Text.Trim()));
                comando.Parameters.Add(new SqlParameter("@KMATUAL", tbox_kmfinal.Text.Trim()));

            sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();

                MessageBox.Show("Registro gravado com sucesso", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void pesquisar()
        {
            dgv_Veiculo.Rows.Clear();

            SqlCommand cmd = new SqlCommand(
              " SELECT                 " +
              " P.ID,                  " +
              " P.RENAVAM,             " +
              " P.RNTRC,               " +
              " P.PLACA,               " +
              " P.ANOMOD,              " +
              " P.ANOFAB,              " +
              " P.CHASSI,              " +
              " P.MARCAMODELO,         " +
              " P.KMINICIAL,           " +
              " P.KMATUAL              " +
              " FROM                   " +
              " FROTA_VEICULO P    ", sqlConn);


            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dgv_Veiculo.Rows.Add();
                dgv_Veiculo.Rows[o].Cells["ID"].Value          = dr["ID"].ToString();
                dgv_Veiculo.Rows[o].Cells["RENAVAM"].Value     = dr["RENAVAM"].ToString();
                dgv_Veiculo.Rows[o].Cells["RNTRC"].Value       = dr["RNTRC"].ToString();
                dgv_Veiculo.Rows[o].Cells["PLACA"].Value       = dr["PLACA"].ToString();
                dgv_Veiculo.Rows[o].Cells["ANOMOD"].Value      = dr["ANOMOD"].ToString();
                dgv_Veiculo.Rows[o].Cells["ANOFAB"].Value      = dr["ANOFAB"].ToString();
                dgv_Veiculo.Rows[o].Cells["CHASSI"].Value      = dr["CHASSI"].ToString();
                dgv_Veiculo.Rows[o].Cells["MARCAMODELO"].Value = dr["MARCAMODELO"].ToString();
                dgv_Veiculo.Rows[o].Cells["KMINICIAL"].Value   = dr["KMINICIAL"].ToString();
                dgv_Veiculo.Rows[o].Cells["KMATUAL"].Value     = dr["KMATUAL"].ToString();

                o++;
                lbl_quantidade.Text = "Quantidade: " + Convert.ToString(dgv_Veiculo.RowCount);
            }

            sqlConn.Close();
        }

        private void limparCampos()
        {
            txt_ID.Clear();
            txt_renavam.Clear();
            tbox_rntrc.Clear();
            tbox_placa.Clear();
            tbox_anoModelo.Clear();
            tbox_anoFabrica.Clear();
            tbox_chassi.Clear();
            tbox_marcaModelo.Clear();
            tbox_kminicial.Clear();
            tbox_kmfinal.Clear();
        }
        private void apenas_Numeros(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true;
        }

        private void bt_Grava_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text == "")
            {
                gravar();
                pesquisar();
                limparCampos();
            }
            else
            {
                atualizar();
                pesquisar();
                limparCampos();

            }
        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {

          txt_ID.Text           = dgv_Veiculo.CurrentRow.Cells["ID"].Value.ToString();
          txt_renavam.Text      = dgv_Veiculo.CurrentRow.Cells["RENAVAM"].Value.ToString();
          tbox_rntrc.Text       =  dgv_Veiculo.CurrentRow.Cells["RNTRC"].Value.ToString();
          tbox_placa.Text       = dgv_Veiculo.CurrentRow.Cells["PLACA"].Value.ToString();
          tbox_anoModelo.Text   =  dgv_Veiculo.CurrentRow.Cells["ANOMOD"].Value.ToString();
          tbox_anoFabrica.Text  =  dgv_Veiculo.CurrentRow.Cells["ANOFAB"].Value.ToString();
          tbox_chassi.Text      = dgv_Veiculo.CurrentRow.Cells["CHASSI"].Value.ToString();
          tbox_marcaModelo.Text = dgv_Veiculo.CurrentRow.Cells["MARCAMODELO"].Value.ToString();
          tbox_kminicial.Text   = dgv_Veiculo.CurrentRow.Cells["KMINICIAL"].Value.ToString();
          tbox_kmfinal.Text     = dgv_Veiculo.CurrentRow.Cells["KMATUAL"].Value.ToString();
          tabControl1.SelectedIndex = 0;

        }

        private void UI_FROTA_VEICULOS_Load(object sender, EventArgs e)
        {
            pesquisar();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
                      
    
    }
}
