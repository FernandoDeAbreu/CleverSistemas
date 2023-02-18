using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sistema.DTO;
using Sistema.BLL;
using Sistema.UTIL;

namespace Sistema.UI.UI_FORMS
{
    public partial class UI_PDV_II_FINALIZAR : Form
    {
        UI_PDV_II instPDV;
        public UI_PDV_II_FINALIZAR()
        {
            InitializeComponent();
        }
        public UI_PDV_II_FINALIZAR(UI_PDV_II PDV)
        {
            InitializeComponent();
            instPDV = PDV;
        }
       
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        decimal troco ;
        string valorPago = "";
        string nunDigitado = "";
        private void Calculartroco()
        {
            // TROCO
           

            troco = Convert.ToDecimal(tboxValorPago.Text) - Convert.ToDecimal(tboxValorTotal.Text);
           
            if (troco >= 0)
            {
                tboxTroco.Text = Convert.ToString(troco);
            }
        }
        private void calculadora()
        {
            try
            {
                valorPago = valorPago + nunDigitado;
                tboxValorPago.Text = Double.Parse(valorPago).ToString("n2");


            }
            catch (Exception)
            {
                valorPago = "";
                nunDigitado = "";
            }
            Calculartroco();

        }
        private void limparCampos()
        {
            tboxValorPago.Text = "0,00";
            valorPago = "";
            nunDigitado = "";
            tboxTroco.Text = "0,00";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            nunDigitado =  "1";
            calculadora();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            nunDigitado = "2";
            calculadora();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            nunDigitado = "3";
            calculadora();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            nunDigitado = "4";
            calculadora();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            nunDigitado = "5";
            calculadora();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            nunDigitado = "6";
            calculadora();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            nunDigitado = "7";
            calculadora();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            nunDigitado = "8";
            calculadora();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            nunDigitado = "8";
            calculadora();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            nunDigitado = "0";
            calculadora();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            nunDigitado = ",";
            calculadora();
        }
        private void txt_valor_TextChanged(object sender, EventArgs e)
        {

        }
        private void button11_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPix_CheckedChanged(object sender, EventArgs e)
        {
            limparCampos();
            panel2.Enabled = false;
            tboxValorPago.Text = tboxValorTotal.Text;
            instPDV.Moeda = "12";
            Calculartroco();
        }
        private void btnCartao_CheckedChanged(object sender, EventArgs e)
        {
            limparCampos();
            panel2.Enabled = false;
            tboxValorPago.Text = tboxValorTotal.Text;
            instPDV.Moeda = "10";
            Calculartroco();
        }
        private void btnDinheiro_CheckedChanged(object sender, EventArgs e)
        {
            limparCampos();
            panel2.Enabled = true;
            tboxValorPago.Text = tboxValorTotal.Text;
            instPDV.Moeda = "1";
            Calculartroco();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (troco < 0)
            {
                return;
            }
            if (Convert.ToDecimal((tboxValorPago.Text)) <= 0)
            {
                return;
            }
            instPDV.pagamentoEfetuado = "SIM";
            this.Close();
        }
    }
}
