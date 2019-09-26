using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.Class
{
    abstract class Filter : IImageOperation
    {
        public readonly int Min;
        public readonly int Max;
        public Filter(int min, int max)
        {
            if (!(min <= max && min >= 0 && max < 256))
                throw new ArgumentOutOfRangeException($"min: {min} max:{max}");
            Min = min;
            Max = max;
        }
        public abstract Bitmap Process(Bitmap input, ProgressBar progressBar);
        public override string ToString()
        {
            return $"Fitler min:{Min} max:{Max}";
        }

    }
}
