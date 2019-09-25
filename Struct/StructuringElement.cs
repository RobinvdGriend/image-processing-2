using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INFOIBV.Struct
{
    enum StructuringElementShape
    {
        Cross,
        Rectangle
    }
    struct StructuringElement
    {
        public int[,] Kernel;
        public int Size;

        public StructuringElement(StructuringElementShape shape, int size)
        {
            if (size % 2 != 1)
            {
                throw new ArgumentException("Size should be odd");
            }

            Kernel = new int[size, size];
            Size = size;

            switch (shape)
            {
                case StructuringElementShape.Cross:
                    this.SetCross(size);
                    break;
                case StructuringElementShape.Rectangle:
                    this.SetRectangle(size);
                    break;
                default:
                    throw new ArgumentException("Not a valid shape");
            }
        }

        public StructuringElement(int size)
        {
            Size = size;
            Kernel = new int[size, size];
        }

        public int this[int x, int y]
        {
            get
            {
                return Kernel[x, y];
            }

            private set
            {
                Kernel[x, y] = value;
            }
        }

        public StructuringElement Reflection
        {
            get
            {
                var output = new StructuringElement(Size);
                 
                for (int x = 0; x < Size; x++)
                {
                    for (int y = 0; y < Size; y++)
                    {
                        output[x, y] = this[Size - x, Size - y];
                    }
                }
                return output;
            }
        }

        public void SetRectangle(int size)
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Kernel[x, y] = 255;
                }
            }
        }

        public void SetCross(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Kernel[(int)(size + 0.5) / 2, i] = 255;
                Kernel[i, (int)(size + 0.5) / 2] = 255;
            }
        }
    }
}
