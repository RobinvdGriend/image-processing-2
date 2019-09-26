﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INFOIBV.Class
{
    partial class BinaryProcessor : ImageProcessor
    {
        // A BinaryProcessor is an ImageProcessor that holds a binary image
        // and has additional methods that are only defined on binary-valued
        // images. A binary image is an image that only holds values 0 and 255.
        // Calling BinaryProcessor(Bitmap) will convert any greyscale image to
        // binary, but will only make sense if the only 2 pixel values are 0 and 255.
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
        public override object Clone()
        {
            var res = new BinaryProcessor(Width, Height);
            res.Image = (int[,])this.Image.Clone();
            return res;
        }
    }
}
