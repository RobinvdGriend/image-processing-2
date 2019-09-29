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
    class ImageY : IImageOperation
    {
        public ImageY() { }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var w = new BinaryProcessor(input);
            var structure = new StructuringElement(StructuringElementShape.Rectangle, 3);

            w.Erode(structure);

            return w.GetBitmap();

        }
        public override string ToString()
        {
            return "Image Y";
        }
    }
}
