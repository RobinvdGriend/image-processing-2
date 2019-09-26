using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.ImageOperations
{
    class NotchFilter : IImageOperation
    {
        private readonly int _min;
        private readonly int _max;
        public NotchFilter(int min, int max) {
            if (!(min <= max && min >= 0 && max < 256))
                throw new ArgumentOutOfRangeException($"min: {min} max:{max}");
            _min = min;
            _max = max;
        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new ImageProcessor(input);
            var h1 = p.CalculateHistogram();

            var bp = p.Threshold(_min);
            var h2 = bp.CalculateHistogram();

            var bp2 = p.Threshold(_max);
            var h3 = bp2.CalculateHistogram();

            bp.Complement();
            bp.Or(bp2);
            var h4 = bp.CalculateHistogram();


            return bp.GetBitmap();

        }
        public override string ToString()
        {
            return $"Notch Filter min:{_min} max:{_max}";
        }
    }
}
