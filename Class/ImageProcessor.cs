using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using INFOIBV.Struct;

namespace INFOIBV.Class
{
    class ImageProcessor
    {
        // An ImageProcessor holds the image to proces in a 2 dimensional array of greyscale pixel values 
        // lying in the interval [0,255]. It provides constructor methods to create an ImageProcessor from a
        // System.Drawing.BitMap object
        // Image operations such as morphological filters are implemented as instance methods
        // as they are "things you can do to this image"

        public int Width;
        public int Height;
        protected int[,] Image;

        public ImageProcessor(Bitmap bitmap)
        {
            Width = bitmap.Size.Width;
            Height = bitmap.Size.Height;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Image[x,y] = bitmap.GetPixel(x, y).GetGreyscaleValue();
                }
            }
        }
        
        public ImageProcessor(int width, int height)
        {
            Width = width;
            Height = height;
            Image = new int[Width, Height];
        }

        public ImageProcessor()
        {
        }

        public void Invert()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Image[x, y] = -Image[x, y];
                }
            }
        }

        public void Dilate(StructuringElement structure)
        {
            var buffer = (int[,])Image.Clone();

            Image = buffer;
        }
    }
}
