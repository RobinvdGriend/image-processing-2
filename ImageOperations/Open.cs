﻿using INFOIBV.Class;
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
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            progressBar.Visible = false;
            
            var proc = new ImageProcessor(input);
            proc.Open(new StructuringElement(StructuringElementShape.Cross, 3));

            return proc.GetBitmap();
        }

        public override string ToString()
        {
            return "Open";
        }
    }

}
