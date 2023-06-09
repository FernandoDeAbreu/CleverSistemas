using System;
using System.Windows.Forms;

namespace Sistema.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //  Application.Run(new UI.UI_FORMS.UI_PDV_II_FINALIZAR());
            //Application.Run(new UI.UI_AtualizarSistema());
              Application.Run(new UI.UI_Login());
        }
    }
}