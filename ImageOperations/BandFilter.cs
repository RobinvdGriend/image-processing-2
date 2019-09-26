using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.ImageOperations
{
    class BandFilter : IImageOperation
    {
        private readonly int _min;
        private readonly int _max;
        public BandFilter(int min, int max)
        {
            if (!(min <= max && min >= 0 && max < 256))
                throw new ArgumentOutOfRangeException($"min: {min} max:{max}");
            _min = min;
            _max = max;
        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new ImageProcessor(input);

            var bp = p.Threshold(_min);
            var bp2 = p.Threshold(_max);

            bp2.Complement();
            bp.And(bp2);

            return bp.GetBitmap();

        }
        public override string ToString()
        {
            return $"Band Filter min:{_min} max:{_max}";
        }
    }
}
