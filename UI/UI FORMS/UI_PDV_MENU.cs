using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UI_PDV_MENU : Form
    {
        public UI_PDV_MENU()
        {
            InitializeComponent();
        }

        private void UI_PDV_MENU_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }
    }
}
