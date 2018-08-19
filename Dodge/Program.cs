using Dodge.Data;
using Dodge.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge
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
            Application.Run(new StartScreen());

            // For debuggin purpose, run this form first
            //var game = new Game();

            //Application.Run(new Form1(game, new KeyHandler(game), new User()));
        }
    }
}
