using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INFOIBV
{
    public static class ColorExtension
    {
        public static int GetGreyscaleValue(this Color color)
        {
            var r = color.R;
            var g = color.G;
            var b = color.B;

            if (r != b | b != g)
            {
                throw new ArgumentException("Image is not greyscale");
            }
            return r;
        }

        public static int GetBinaryValue(this Color color)
        {
            var greyscale = GetGreyscaleValue(color);
            if (greyscale == 0)
            {
                return 0;
            }
            else
            {
                return 255;
            }
        }
    }
}
