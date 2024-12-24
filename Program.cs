using System;
using System.Windows.Forms;

namespace TpCalculette
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Bibliotheque biblio = new Bibliotheque();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCalculette(biblio));

            // 

        }
    }
}
