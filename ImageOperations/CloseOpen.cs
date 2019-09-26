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
    class CloseOpen : IImageOperation
    {
        StructuringElement structure;
        public CloseOpen(StructuringElement s)
        {
            structure = s;
        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new ImageProcessor(input);
            p.Close(structure);
            p.Open(structure);
            return p.GetBitmap();
        }
        public override string ToString()
        {
            return $"CloseOpen {structure.ToString()}";
        }
    }
}
