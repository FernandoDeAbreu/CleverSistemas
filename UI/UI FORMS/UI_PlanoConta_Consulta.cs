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

namespace Sistema.UI
{
    public partial class UI_PlanoConta_Consulta : Form
    {
        public UI_PlanoConta_Consulta()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DIVERSAS
        BLL_PlanoConta BLL_PlanoConta;
        #endregion

        #region ESTRUTURA
        DTO_PlanoConta PlanoConta;
        #endregion

        #region PROPRIEDADES
        public string Cod_Conta { get; set; }
        #endregion

        #region ROTINAS
        private void Inicia_Form()
        {
            this.Text = "CONSULTA PLANO DE CONTAS";

            Cod_Conta = string.Empty;

            dg_Nivel1.AutoGenerateColumns = false;
            dg_Nivel2.AutoGenerateColumns = false;
            dg_Nivel3.AutoGenerateColumns = false;
            dg_Nivel4.AutoGenerateColumns = false;

            CarregaConta(1);
        }

        private void CarregaConta(int intNivel)
        {
            DataTable _DT_N1 = new DataTable();
            DataTable _DT_N2 = new DataTable();
            DataTable _DT_N3 = new DataTable();
            DataTable _DT_N4 = new DataTable();

            BLL_PlanoConta = new BLL_PlanoConta();
            PlanoConta = new DTO_PlanoConta();

            switch (intNivel)
            {

                case 1:
                    PlanoConta.Nivel = 1;
                    _DT_N1 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel1.DataSource = _DT_N1;
                    break;
                case 2:
                    PlanoConta.Nivel = 2;
                    PlanoConta.Plano = txt_Nivel1.Text;
                    _DT_N2 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel2.DataSource = _DT_N2;
                    break;
                case 3:
                    PlanoConta.Nivel = 3;
                    PlanoConta.Plano = txt_Nivel1.Text + txt_Nivel2.Text;
                    _DT_N3 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel3.DataSource = _DT_N3;
                    break;
                case 4:
                    PlanoConta.Nivel = 4;
                    PlanoConta.Plano = txt_Nivel1.Text + txt_Nivel2.Text + txt_Nivel3.Text;
                    _DT_N4 = BLL_PlanoConta.Busca(PlanoConta);
                    dg_Nivel4.DataSource = _DT_N4;
                    break;
            }
        }
        #endregion

        #region FORM
        private void UI_PlanoConta_Consulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (dg_Nivel1.Focused == true & e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Enter)
            {
                dg_Nivel2.Focus();
                return;
            }

            if (dg_Nivel2.Focused == true & e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Enter)
            {
                dg_Nivel3.Focus();
                return;
            }

            if (dg_Nivel3.Focused == true & e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Enter)
            {
                dg_Nivel4.Focus();
                return;
            }

            if (dg_Nivel4.Focused == true & e.KeyCode == Keys.Left)
            {
                dg_Nivel3.Focus();
                return;
            }

            if (dg_Nivel3.Focused == true & e.KeyCode == Keys.Left)
            {
                dg_Nivel2.Focus();
                return;
            }

            if (dg_Nivel2.Focused == true & e.KeyCode == Keys.Left)
            {
                dg_Nivel1.Focus();
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void UI_PlanoConta_Consulta_Load(object sender, EventArgs e)
        {
            Inicia_Form();
        }
        #endregion

        #region BUTTON
        private void bt_Seleciona_Click(object sender, EventArgs e)
        {
            Cod_Conta = txt_Nivel1.Text + txt_Nivel2.Text + txt_Nivel3.Text + txt_Nivel4.Text;
            this.Close();
        }
        #endregion

        #region DATAGRIDVIEW
        private void dg_Nivel1_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel1.Rows.Count == 0)
                txt_Nivel1.Text = "00";
        }

        private void dg_Nivel2_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel2.Rows.Count == 0)
                txt_Nivel2.Text = "00";
        }

        private void dg_Nivel3_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel3.Rows.Count == 0)
                txt_Nivel3.Text = "00";
        }

        private void dg_Nivel4_DataSourceChanged(object sender, EventArgs e)
        {
            if (dg_Nivel4.Rows.Count == 0)
                txt_Nivel4.Text = "00";
        }

        private void dg_Nivel1_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel1.Rows.Count > 0)
                txt_Nivel1.Text = Convert.ToString(dg_Nivel1.Rows[dg_Nivel1.CurrentRow.Index].Cells[0].Value);

            CarregaConta(2);
        }

        private void dg_Nivel2_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel2.Rows.Count > 0)
                txt_Nivel2.Text = Convert.ToString(dg_Nivel2.Rows[dg_Nivel2.CurrentRow.Index].Cells[0].Value);

            CarregaConta(3);
        }

        private void dg_Nivel3_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel3.Rows.Count > 0)
                txt_Nivel3.Text = Convert.ToString(dg_Nivel3.Rows[dg_Nivel3.CurrentRow.Index].Cells[0].Value);

            CarregaConta(4);
        }

        private void dg_Nivel4_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_Nivel4.Rows.Count > 0)
                txt_Nivel4.Text = Convert.ToString(dg_Nivel4.Rows[dg_Nivel4.CurrentRow.Index].Cells[0].Value);
        }
        #endregion

      
    }
}
