using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFOIBV.Class
{
    partial class ImageProcessor
    {
        public BinaryProcessor Threshold(int T) {
            var b = new BinaryProcessor(Width, Height);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    b.Image[x, y] = (this.Image[x, y] >= T) ? 255 : 0;
                }
            }
            return b;
        }
    }
}
