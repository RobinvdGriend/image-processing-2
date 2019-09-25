using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INFOIBV.Class;

namespace INFOIBV.Class
{
    partial class ImageProcessor
    {
        public void Negative() {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Image[x, y] = 255 - Image[x, y];

                }
            }
        }
    }
    
}
