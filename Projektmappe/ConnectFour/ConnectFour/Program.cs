using System;
using System.Windows.Forms;
using VierGewinnt;


//namespace name geändert
namespace ConnectFour
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Connect4Form());
        }
    }
}
