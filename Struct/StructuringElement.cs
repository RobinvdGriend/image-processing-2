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
        public StructuringElementShape Shape;

        public StructuringElement(StructuringElementShape shape, int size)
        {
            if (size % 2 != 1 && size < 3)
            {
                throw new ArgumentException("Size should be odd and at least 3");
            }

            Kernel = new int[size, size];
            Size = size;
            Shape = shape;
            fillKernel();
        }
        private void fillKernel() {
            switch (this.Shape)
            {
                case StructuringElementShape.Cross:
                    this.SetCross(this.Size);
                    break;
                case StructuringElementShape.Rectangle:
                    this.SetRectangle(this.Size);
                    break;
                default:
                    throw new ArgumentException("Not a valid shape");
            }
        }

        public StructuringElement(int size)
        {
            Size = size;
            Kernel = new int[size, size];
            Shape = StructuringElementShape.Rectangle;
            fillKernel();
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
                        output[x, y] = this[Size - x - 1, Size - y - 1];
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
                    Kernel[x, y] = 1;
                }
            }
        }

        public void SetCross(int size)
        {
            var armWidth = size / 3;
            if (size % 3 == 1)
                armWidth++;
            var start = (size - armWidth)/2;
            var end = size - start;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++) {
                    if (x >= start && x < end || y >= start && y < end)
                        Kernel[x, y] = 1;
                }
            }
            return;
        }
        public override string ToString()
        {
            return $"{Shape} {Size}";
        }
    }
}
