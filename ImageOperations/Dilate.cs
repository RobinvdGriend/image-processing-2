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
    class Dilate : IImageOperation
    {
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            progressBar.Visible = false;
            
            var proc = new ImageProcessor(input);
            proc.Dilate(new StructuringElement(StructuringElementShape.Cross, 5));

            return proc.GetBitmap();
        }

        public override string ToString()
        {
            return "Dilate";
        }
    }

}
