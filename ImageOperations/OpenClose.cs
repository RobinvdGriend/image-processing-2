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
    class OpenClose : IImageOperation
    {
        StructuringElement structure; 
        public OpenClose(StructuringElement s) {
            structure = s;
        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new ImageProcessor(input);
            p.Open(structure);
            p.Close(structure);
            return p.GetBitmap();
        }
        public override string ToString()
        {
            return $"OpenClose {structure.ToString()}";
        }
    }
}
