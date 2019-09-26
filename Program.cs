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
                new Threshold(63),
                new Threshold(127),
                new Threshold(191),
                new BandFilter(63,191),
                new NotchFilter(63,191),
                new BandFilter(181,201),
                new NotchFilter(181,201),
                new Dilate(),
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new INFOIBV(ops));
        }
    }
}
