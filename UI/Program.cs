using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //  Application.Run(new UI_MENU());
            //  Application.Run(new UI.UI_FORMS.UI_PDV_II_FINALIZAR());
            Application.Run(new UI.UI_Login());

        }
    }
}
