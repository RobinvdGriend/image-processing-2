using INFOIBV.Class;
using INFOIBV.Struct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.ImageOperations
{
    class Mask : IImageOperation
    {
        private Filter _filter;
        public Mask(Filter filter) {
            _filter = filter;
        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new ImageProcessor(input);
            var s1 = new StructuringElement(StructuringElementShape.Rectangle, 5);
            var s2 = new StructuringElement(StructuringElementShape.Rectangle, 9);
            var mask = new BinaryProcessor(_filter.Process(input,progressBar));
            mask.Close(s1);
            mask.Open(s1);
            p.Mask(mask);

            mask.Dilate(s2);


            var bt = new BoundaryTrace(s1);
            var bmp = bt.Process(mask.GetBitmap(),progressBar);
            var p2 = new BinaryProcessor(bmp);
            //p.Layer(p2);

            return p.GetBitmap();
        }
        public override string ToString()
        {
            return $"BandMask min:{_filter.Min} max:{_filter.Max}";
        }
    }
}
