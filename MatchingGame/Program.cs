/**
 * @author: K. Walther
 * @date: Mar 2019
 * @brief: This program implements a Matching Game based on the tutorial on the Microsoft website:
 * https://docs.microsoft.com/en-us/visualstudio/ide/tutorial-3-create-a-matching-game?view=vs-2017
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
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
            Application.Run(new Form1());
        }
    }
}
