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
    class Open : IImageOperation
    {
        private readonly StructuringElement _structure;
        public Open(StructuringElement structure) {
            this._structure = structure;
        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            progressBar.Visible = false;
            
            var proc = new ImageProcessor(input);
            proc.Open(_structure);
            var h = proc.CalculateHistogram();
            System.Diagnostics.Trace.WriteLine($"Unique values: {h.UniqueValueCount}");
            return proc.GetBitmap();
        }

        public override string ToString()
        {
            return "Open " + _structure.ToString();
        }
    }

}
