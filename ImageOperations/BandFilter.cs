using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.ImageOperations
{
    class BandFilter : Filter
    {
        public BandFilter(int min, int max) : base(min,max) { }
        public override Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new ImageProcessor(input);

            var bp = p.Threshold(Min);
            var bp2 = p.Threshold(Max);

            bp2.Complement();
            bp.And(bp2);

            return bp.GetBitmap();

        }
        public override string ToString()
        {
            return "Bandpass" + base.ToString();
        }
    }
}
