using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.ImageOperations
{
    class Complement : IImageOperation
    {
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = 3;
            progressBar.Value = 0;
            progressBar.Step = 1;
            var proc = new ImageProcessor(input);
            progressBar.PerformStep();
            proc.Complement();
            progressBar.PerformStep();
            proc.Complement();
            progressBar.PerformStep();
            proc.Complement();
            progressBar.PerformStep();

            var bmp = proc.GetBitmap();

            progressBar.PerformStep();
            progressBar.Visible = false;
            return bmp;
        }

        public override string ToString()
        {
            return "Complement";
        }
    }

}
