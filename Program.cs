using INFOIBV.Class;
using INFOIBV.ImageOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace INFOIBV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var ops = new IImageOperation[]
            {
                new Complement(),
                new Dilate(),
                new Erode(),
                new Open(),
                new Close(),
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new INFOIBV(ops));
        }
    }
}
