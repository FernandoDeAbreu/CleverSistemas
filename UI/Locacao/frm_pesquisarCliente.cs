using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Sistema.UI.Locacao
{
    public partial class frm_pesquisarCliente : Form
    {
        public frm_pesquisarCliente()
        {
            InitializeComponent();
        }
        private void select()
        {
            string conexao = @"server=DESKTOP-IQFG1J0\SQLEXPRESS; Database=BD.mdf;Integrated Security=SSPI;";
            SqlConnection sqlConn = new SqlConnection(conexao);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("Select * from pessoa where TipoPessoa = 1", sqlConn);

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[o].Cells[0].Value = dr["Nome_Razao"].ToString();

                o++;

            }
            sqlConn.Close();
        }

        private void frm_pesquisarCliente_Load(object sender, EventArgs e)
        {
            select();
        }
    }
}
