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
    public partial class UI_FROTA_COMBUSTIVEL : Form
    {
        SqlConnection sqlConn = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);

        public UI_FROTA_COMBUSTIVEL()
        {
            InitializeComponent();
        }

        private void limparCampos()
        {
            txt_Descricao.Clear();
            txt_ID.Clear();
            pesquisar();
        }
        private void gravar()
        {


            //definição do comando sql
            string sql = "INSERT INTO FROTA_COMBUSTIVEL( " +
                                    "DESCRICAO ) " +
                                    " VALUES ( " +
                                    "@DESCRICAO )";

            try
            {
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("@DESCRICAO", txt_Descricao.Text));
               
                sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();

                MessageBox.Show("Registro gravado com sucesso","Clever Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);

                limparCampos();

            }
            catch
            {
                
            }
            finally
            {

            }
        }

        private void atualizar()
        {

            string sql = "UPDATE FROTA_COMBUSTIVEL SET DESCRICAO = @DESCRICAO WHERE ID = @ID ";

            try
            {
                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("@ID",       txt_ID.Text));
                comando.Parameters.Add(new SqlParameter("@DESCRICAO", txt_Descricao.Text));

                sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();
                MessageBox.Show("Registro gravado com sucesso", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limparCampos();
            }
            catch
            {
                throw new Exception(util_msg.msg_DAL_Erro_Grava);
            }

        }

        private void pesquisar()
        {
            dgv_Combustivel.Rows.Clear();

            SqlCommand cmd = new SqlCommand(
              " SELECT                 " +
              " P.ID,                  " +
              " P.Descricao            " +
              " FROM                   " +
              " FROTA_COMBUSTIVEL P    ", sqlConn);
          

            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
              dgv_Combustivel.Rows.Add();
              dgv_Combustivel.Rows[o].Cells["ID"].Value = dr["ID"].ToString();
              dgv_Combustivel.Rows[o].Cells["DESCRICAO"].Value = dr["DESCRICAO"].ToString();
            
                o++;

            }
           
            sqlConn.Close();
        }

        private void bt_Grava_Click(object sender, EventArgs e)
        {
            if (txt_Descricao.Text == "")
            {
                MessageBox.Show("Campo descrição é obrigatorio.", "Clever Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txt_ID.Text == "")
            {
                gravar();
            }
            else
            {
                atualizar();
            }
        

        }

        private void bt_Edita_Click(object sender, EventArgs e)
        {
            try
            {
                txt_ID.Text = dgv_Combustivel.CurrentRow.Cells["ID"].Value.ToString();
                txt_Descricao.Text = dgv_Combustivel.CurrentRow.Cells["DESCRICAO"].Value.ToString();
                tabControl1.SelectedIndex = 0;

            }
            catch (Exception)
            {

               
            }
        }

        private void UI_FROTA_COMBUSTIVEL_Load(object sender, EventArgs e)
        {
            pesquisar();
        }
    }
}
