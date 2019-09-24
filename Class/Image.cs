using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INFOIBV
{
    class Image
    {
        // An Image is an 2 dimensional array of greyscale pixel values lying in the interval [0,255]
        // It provides constructor methods to create an Image from a System.Drawing.BitMap object
        // Image operations such as morphological filters are implemented as instance methods
        // as they are "things you can do to this image"

        public int Width;
        public int Height;
        int[,] PixelValues;

        public Image(Bitmap bitmap)
        {
            Width = bitmap.Size.Width;
            Height = bitmap.Size.Height;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    PixelValues[x,y] = bitmap.GetPixel(x, y).GetGreyscaleValue();
                }
            }
        }
    }
}
