using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.ImageOperations
{
    class Threshold : IImageOperation
    {
        public readonly int T;
        public Threshold(int t) {
            T = t;
        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = 3;
            progressBar.Value = 0;
            progressBar.Step = 1;
            var proc = new ImageProcessor(input);
            progressBar.PerformStep();
            var nproc = proc.Threshold(T);

            progressBar.PerformStep();
            var bmp = nproc.GetBitmap();
            progressBar.PerformStep();

            progressBar.Visible = false;
            return bmp;
        }
        public override string ToString()
        {
            return $"Threshold: {T}";
        }
    }
}
