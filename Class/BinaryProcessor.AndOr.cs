using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFOIBV.Class
{
    partial class BinaryProcessor
    {
        public void And(BinaryProcessor Image2) {
            if (Image2.Height != this.Height || Image2.Width != this.Width) 
                throw new ArgumentException("Images should have same dimensions.");

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    this.Image[x, y] *= Image2.Image[x,y]/255;

                }

            }
        }

        public void Or(BinaryProcessor Image2)
        {
            if (Image2.Height != this.Height || Image2.Width != this.Width)
                throw new ArgumentException("Images should have same dimensions.");

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    this.Image[x, y] = (this.Image[x, y] > 0) ? 255 : Image2.Image[x, y];
                }
            }
        }
    }
}
