using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace INFOIBV.Class
{
    class Histogram
    {
        public int[] Values {get;private set;}
        public int UniqueValueCount { get; private set; }

        public Histogram() {
            Values = new int[256];
            UniqueValueCount = 0;
        }
        public Histogram(Bitmap bmp)
        {
            Values = new int[256];
            UniqueValueCount = 0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    var p = bmp.GetPixel(x, y);
                    var i = (p.B + p.G + p.R) / 3;
                    RegisterPixel(i);
                }
            }
        }
        public Histogram(int[,] values)
        {
            Values = new int[256];
            UniqueValueCount = 0;

            foreach (var pixel in values) {
                RegisterPixel(pixel);
            }
        }


        public void RegisterPixel(int intensity) {
            if (Values[intensity]++ == 0)
                UniqueValueCount++;
        }

        public Bitmap RenderHistogram(int pixelWidth) {
            var b = new Bitmap(pixelWidth * 256, 100);
            var max = Values.Max();
            for (int i = 0; i < 256; i++)
            {
                var height = Values[i] * 100 / max;
                for (int j = 0; j < height; j++)
                {
                    for (int a = 0; a < pixelWidth; a++)
                    {
                        b.SetPixel(pixelWidth* i +a, 99 - j, Color.Black);
                    }
                }
            }
            return b;
        }
    }
}
