using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using INFOIBV.Struct;

namespace INFOIBV.ImageOperations
{
    class ImageZ : IImageOperation
    {
        public ImageZ() { }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var w = new BinaryProcessor(input);
            var structure = new StructuringElement(StructuringElementShape.Rectangle, 3);
            var x = (BinaryProcessor)w.Clone();
            var y = (BinaryProcessor)w.Clone();

            x.Dilate(structure);
            y.Erode(structure);
            y.Complement();
            x.And(y);

            return x.GetBitmap();

        }
        public override string ToString()
        {
            return "Image Z";
        }
    }
}
