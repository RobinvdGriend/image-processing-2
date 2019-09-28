using INFOIBV.Class;
using INFOIBV.ImageOperations;
using INFOIBV.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace INFOIBV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var g1 = new StructuringElement(StructuringElementShape.Rectangle, 3); 
            var g2 = new StructuringElement(StructuringElementShape.Rectangle, 23); 
            var g3 = new StructuringElement(StructuringElementShape.Rectangle, 43); 
            var g4 = new StructuringElement(StructuringElementShape.Rectangle, 63); 
            var g5 = new StructuringElement(StructuringElementShape.Rectangle, 83); 

            var s_c_3 = new StructuringElement(StructuringElementShape.Cross, 3);
            var s_r_3 = new StructuringElement(StructuringElementShape.Rectangle, 3);
            var s_c_5 = new StructuringElement(StructuringElementShape.Cross, 5);
            var s_r_5 = new StructuringElement(StructuringElementShape.Rectangle, 5);
            var s_c_7 = new StructuringElement(StructuringElementShape.Cross, 7);
            var s_r_7 = new StructuringElement(StructuringElementShape.Rectangle, 7);
            var s_c_9 = new StructuringElement(StructuringElementShape.Cross, 9);
            var s_r_9 = new StructuringElement(StructuringElementShape.Rectangle, 9);
            var s_r_11 = new StructuringElement(StructuringElementShape.Rectangle, 11);
            var ops = new IImageOperation[]
            {
                new Complement(),
                new Threshold(63),
                new Threshold(127),
                new Threshold(191),
                new BandFilter(63,191),
                new NotchFilter(63,191),
                new BandFilter(181,201),
                new NotchFilter(181,201),
                new Mask(new NotchFilter(63,191)),
                new Dilate(s_r_3),
                new Dilate(s_r_5),
                new Dilate(s_r_7),
                new Dilate(s_r_9),
                new Dilate(s_r_11),
                new Open(g1),
                new Open(g2),
                new Open(g3),
                new Open(g4),
                new Open(g5),
                new BoundaryTrace(s_c_3),
                new BoundaryTrace(s_r_3),
                new BoundaryTrace(s_c_5),
                new BoundaryTrace(s_r_5),
                new BoundaryTrace(s_c_7),
                new BoundaryTrace(s_r_7),
                new BoundaryTrace(s_c_9),
                new BoundaryTrace(s_r_9),
                new OpenClose(s_c_3),
                new OpenClose(s_r_3),
                new OpenClose(s_c_5),
                new OpenClose(s_r_5),
                new OpenClose(s_c_7),
                new OpenClose(s_r_7),
                new OpenClose(s_c_9),
                new OpenClose(s_r_9),
                new CloseOpen(s_c_3),
                new CloseOpen(s_r_3),
                new CloseOpen(s_c_5),
                new CloseOpen(s_r_5),
                new CloseOpen(s_c_7),
                new CloseOpen(s_r_7),
                new CloseOpen(s_c_9),
                new CloseOpen(s_r_9),
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new INFOIBV(ops));
        }
    }
}
