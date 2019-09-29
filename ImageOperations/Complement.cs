using INFOIBV.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INFOIBV.ImageOperations
{
    class Complement : IImageOperation
    {
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var proc = new ImageProcessor(input);
            proc.Complement();

            var bmp = proc.GetBitmap();
            return bmp;
        }

        public override string ToString()
        {
            return "Complement";
        }
    }

}
