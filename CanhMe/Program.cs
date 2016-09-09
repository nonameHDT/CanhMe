using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanhMe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			/*	Author: nonameHDT
			 *	Email: nonameanbu@gmail.com
			 *  Facebook: https://www.facebook.com/hung.de.tien.175
			 *	Release date: 09/09/2016
			 */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
