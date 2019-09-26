using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFOIBV.Class
{
    partial class ImageProcessor
    {
        public void Mask( BinaryProcessor mask) {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    this.Image[x,y] *= mask.Image[x,y]/255;
                }
            }
            return;
        }
        public void Layer(BinaryProcessor layer)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var val = layer.Image[x, y] + this.Image[x,y];
                    this.Image[x, y] = (val > 255) ? 255 : val;
                }
            }
            return;
        }
    }
}
