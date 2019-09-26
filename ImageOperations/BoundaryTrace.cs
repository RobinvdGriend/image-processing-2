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
    class BoundaryTrace : IImageOperation
    {
        private StructuringElement _se;
        public BoundaryTrace(StructuringElement se) {
            _se = se;

        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new BinaryProcessor(input);
            var p2 = (BinaryProcessor)p.Clone();
            p2.Erode(_se);
            p2.Complement();
            p.And(p2);
            return p.GetBitmap();
        }

        public override string ToString()
        {
            return $"Boundary trace {_se.ToString()} ";
        }
    }
}
