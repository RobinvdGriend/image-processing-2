using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using INFOIBV.Struct;

namespace INFOIBV.Class
{
    partial class ImageProcessor : ICloneable
    {
        // An ImageProcessor holds the image to proces in a 2 dimensional array of greyscale pixel values 
        // lying in the interval [0,255]. It provides constructor methods to create an ImageProcessor from a
        // System.Drawing.BitMap object
        // Image operations such as morphological filters are implemented as instance methods
        // as they are "things you can do to this image"

        public int Width;
        public int Height;
        protected int[,] Image { get; private set; }         // x,y
        public Histogram CalculateHistogram() {
            return new Histogram(Image);
        }

        public ImageProcessor(Bitmap bitmap)
        {
            Width = bitmap.Size.Width;
            Height = bitmap.Size.Height;
            Image = new int[Width,Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Image[x, y] = bitmap.GetPixel(x, y).GetGreyscaleValue();
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

        public int this[int x, int y]
        {
            get
            {
                return Image[x, y];
            }
            private set
            {
                if (x < 0 | y < 0 | x >= Width | y >= Width)
                {
                    throw new ArgumentException("Coordinate lies outside of the image.");
                }
                else if (value < 0 | value > 255)
                {
                    throw new ArgumentException("Pixel value is outside of possible values");
                }
                else
                {
                    Image[x, y] = value;
                }
            }
        }
        public Bitmap GetBitmap()
        {
            var b = new Bitmap(Width, Height);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    b.SetPixel(x, y, Color.FromArgb(Image[x, y], Image[x, y], Image[x, y]));
                }
            }
            return b;
        }

        public object Clone()
        {
            var clone = new ImageProcessor(this.Width, this.Height);
            clone.Image = (int[,])this.Image.Clone();
            return clone;
        }
    }
}
