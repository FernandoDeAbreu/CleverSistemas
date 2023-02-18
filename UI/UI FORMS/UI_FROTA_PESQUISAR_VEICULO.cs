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
    public partial class UI_FROTA_PESQUISAR_VEICULO : Form
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);
        public string rotina;
        UI_FROTA_ABASTECIMENTO inst_abastecimento;


        public UI_FROTA_PESQUISAR_VEICULO(UI_FROTA_ABASTECIMENTO abastecimento)
        {
            InitializeComponent();
            inst_abastecimento = abastecimento;
        }
        private void pesquisar()
        {
            dgv_Veiculo.Rows.Clear();
            string coluna = "";
            if (comboBox1.Text == "PLACA")
            {
                coluna = "PLACA";
            }
            if (comboBox1.Text == "MARCA / MODELO")
            {
                coluna = "MARCAMODELO";

            }

            SqlCommand cmd = new SqlCommand(
              " SELECT                 " +
              " P.ID,                  " +
              " P.RENAVAM,              " +
              " P.RNTRC,                " +
              " P.PLACA,                " +
              " P.ANOMOD,               " +
              " P.ANOFAB,               " +
              " P.CHASSI,               " +
              " P.MARCAMODELO,          " +
              " P.KMINICIAL,            " +
              " P.KMATUAL              " +
              " FROM                   " +
              " FROTA_VEICULO P WHERE P." + coluna + " = @dados", sqlConn);

            cmd.Parameters.Add(new SqlParameter("@dados", textBox1.Text));

            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dgv_Veiculo.Rows.Add();
                dgv_Veiculo.Rows[o].Cells["ID"].Value = dr["ID"].ToString();
                dgv_Veiculo.Rows[o].Cells["RENAVAM"].Value = dr["RENAVAM"].ToString();
                dgv_Veiculo.Rows[o].Cells["RNTRC"].Value = dr["RNTRC"].ToString();
                dgv_Veiculo.Rows[o].Cells["PLACA"].Value = dr["PLACA"].ToString();
                dgv_Veiculo.Rows[o].Cells["ANOMOD"].Value = dr["ANOMOD"].ToString();
                dgv_Veiculo.Rows[o].Cells["ANOFAB"].Value = dr["ANOFAB"].ToString();
                dgv_Veiculo.Rows[o].Cells["CHASSI"].Value = dr["CHASSI"].ToString();
                dgv_Veiculo.Rows[o].Cells["MARCAMODELO"].Value = dr["MARCAMODELO"].ToString();
                dgv_Veiculo.Rows[o].Cells["KMINICIAL"].Value = dr["KMINICIAL"].ToString();
                dgv_Veiculo.Rows[o].Cells["KMATUAL"].Value = dr["KMATUAL"].ToString();

                o++;
            }

            sqlConn.Close();
        }

        private void UI_FROTA_PESQUISAR_VEICULO_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "PLACA";
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            pesquisar();
        }

        private void Dgv_Veiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (rotina == "abastecimento")
                {
                    inst_abastecimento.tbox_codveiculo.Text = dgv_Veiculo.CurrentRow.Cells["ID"].Value.ToString();
                    inst_abastecimento.tbox_veiculo.Text = dgv_Veiculo.CurrentRow.Cells["MARCAMODELO"].Value.ToString() + " | " + dgv_Veiculo.CurrentRow.Cells["PLACA"].Value.ToString();
                }
                this.Close();
            }
            catch (Exception)
            {

               // throw;
            }
        }
    }
}
