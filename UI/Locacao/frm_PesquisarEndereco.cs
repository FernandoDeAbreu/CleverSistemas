using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.UI.Locacao
{
    public partial class frm_PesquisarEndereco : Form
    {

        SqlConnection sqlConn = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);
        public string codCliente;
        public string rotina;
        frm_Locacao instLocacao;

        public frm_PesquisarEndereco(frm_Locacao locacao)
        {
            InitializeComponent();
            instLocacao = locacao;
        }

        private void consultarProduto()
        {
            SqlCommand cmd = new SqlCommand("SELECT "+
            " E.ID_Endereco,   " +
            " E.Logradouro,    " +
            " E.NumeroEndereco," +
            " E.Complemento,   " +
            " E.Bairro,        " +
            " E.ID_Municipio,  " +
            " M.Descricao      " +
            " FROM             " +
            " PessoaEndereco E," +
            " Municipios     M " +
            " WHERE            " +
            " E.ID_Municipio = M.ID AND E.TIPOPESSOA = 1 AND E.ID_PESSOA = @Referencia", sqlConn);

            cmd.Parameters.Add(new SqlParameter("@Referencia", codCliente));


            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            int o = 0;
            while (dr.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[o].Cells["ID"].Value = dr["ID_Endereco"].ToString();
                dataGridView1.Rows[o].Cells["LOGRADOURO"].Value = dr["Logradouro"].ToString();
                dataGridView1.Rows[o].Cells["NUM"].Value = dr["NumeroEndereco"].ToString();
                dataGridView1.Rows[o].Cells["BAIRRO"].Value = dr["Bairro"].ToString();
                dataGridView1.Rows[o].Cells["MUNICIPIO"].Value = dr["Descricao"].ToString();
                dataGridView1.Rows[o].Cells["COMPLEMENTO"].Value = dr["Complemento"].ToString();
              

                o++;

            }
            if (o == 0)
            {
                MessageBox.Show("Cliente sem Endereço cadastrado.", "Clever Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            sqlConn.Close();
        }

        private void frm_PesquisarEndereco_Load(object sender, EventArgs e)
        {
            consultarProduto();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (rotina == "LOCACAO")
                {
                    instLocacao.tbox_codEnderecoCliente.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    instLocacao.tbox_EnderecoCliente.Text    = dataGridView1.CurrentRow.Cells["LOGRADOURO"].Value.ToString() + "; Nº: " +
                                                               dataGridView1.CurrentRow.Cells["NUM"].Value.ToString() + "; " +
                                                               dataGridView1.CurrentRow.Cells["BAIRRO"].Value.ToString() + "; " +
                                                               dataGridView1.CurrentRow.Cells["MUNICIPIO"].Value.ToString();
                }
               
                this.Close();
            }
            catch (Exception)
            {

            
            }
        }
    }
}
