using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INFOIBV.Class
{
    public partial class BinaryProcessor : ImageProcessor
    {
        // A BinaryProcessor is an ImageProcessor that holds a binary image
        // and has additional methods that are only defined on binary-valued
        // images. A binary image interprets 0 as 0 and all other values a 1.
        // Calling BinaryProcessor(Bitmap) will only make sense if there are
        // only 2 colors, one of which has pixel value 0. Calling GetBitmap
        // will actively convert all colors to 0 and 255 according to their
        // boolean value.
        public BinaryProcessor(int width, int height) : base(width, height) { }
        public BinaryProcessor(Bitmap bitmap) : base(bitmap.Width,bitmap.Height)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Image[x, y] = bitmap.GetPixel(x, y).GetBinaryValue();
                }
            }
        }

        public override Bitmap GetBitmap()
        {
            var b = new Bitmap(Width, Height);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Image[x, y] == 0)
                    {
                        b.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        b.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }

                }
            }
            return b;
        }

        public override object Clone()
        {
            var res = new BinaryProcessor(Width, Height);
            res.Image = (int[,])this.Image.Clone();
            return res;
        }
    }
}
