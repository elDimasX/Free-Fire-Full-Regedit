using Auth.GG_Winform_Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROYAL_FULL
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //OnProgramStart.Initialize("ROYAL_FULL", "788768", "y2PIW1DIOfEvGvOKhqflV7dGdU3aJNshSqv", "2.0");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
