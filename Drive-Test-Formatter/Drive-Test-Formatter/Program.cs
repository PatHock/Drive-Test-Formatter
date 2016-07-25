using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Drive_Test_Formatter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            XmlData data = new XmlData("\"-76.6119647\",\"39.2840896\",\"13:01:59\",\"\",\"\",\"2118000000.000, 2118001000.000, 2118002000.000, 2118003000.000, 2118004000.000, 2118005000.000, 2118006000.000, 2118007000.000\",\"-82.447, -80.884, -93.029, -96.130, -88.230, -78.940, -78.151, -84.943\",");
            Console.Write(data.fileIndex);
            Console.Write(data.Text);
        }
    }
}
