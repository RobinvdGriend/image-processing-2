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
    enum Direction {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
    class BoundaryTrace : IImageOperation
    {
        private StructuringElement _se;
        public BoundaryTrace(StructuringElement se) {
            _se = se;

        }
        public Bitmap Process(Bitmap input, ProgressBar progressBar)
        {
            var p = new BinaryProcessor(input);
            //var p2 = (BinaryProcessor)p.Clone();
            //p2.Erode(_se);
            //p2.Complement();
            //p.And(p2);
            var points = MooreTracing(p);
            var res = "Boundary Pixels \n";
            foreach (var po in points) {
                res += $"\nX: {po.X}, Y: {po.Y}";
            }
            System.Diagnostics.Trace.WriteLine(res);
            return PointsToBitmap(points, p.Width, p.Height);
        }
        private Bitmap PointsToBitmap(List<Point> points, int width, int height)
        {
            var bmp = new Bitmap(width,height);
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0)))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);
            }
            foreach (var point in points)
            {
                bmp.SetPixel(point.X, point.Y, Color.FromArgb(255, 255, 255));
            }
            return bmp;
        }
        private List<Point> MooreTracing(BinaryProcessor p)
        {
            List<Point> boundary = new List<Point>();
            var dirs = new Point[] {
                new Point(0,-1),    // north
                new Point(1,-1),    // north east 
                new Point(1,0),     // east
                new Point(1,1),     // south east
                new Point(0,1),     // south
                new Point(-1,1),    // south west
                new Point(-1,0),    // west
                new Point(-1,-1)    // north west
            };
            var sPoint = findFirstPoint(p);
            boundary.Add(sPoint);

            // initialize boundary trace

            var cDir = 7;       // north west
            var onPoint = sPoint;
            var cPoint = addPoints(onPoint, dirs[cDir]);
            while (cPoint != sPoint)
            {
                if (inBounds(cPoint, p) && p.Image[cPoint.X, cPoint.Y] == 255)
                {
                    boundary.Add(cPoint);
                    onPoint = cPoint;

                    //backtrack
                    cDir = (cDir + 6) % 8;
                    cDir -= cDir % 2;

                    cPoint = addPoints(onPoint, dirs[cDir]);
                }
                else
                {
                    cDir = ++cDir % 8;
                    cPoint = addPoints(onPoint, dirs[cDir]);
                }
            }
            return boundary;
        }
        private bool inBounds(Point p, ImageProcessor proc)
        {
            return p.X >= 0 && p.Y >= 0 && p.X < proc.Width && p.Y < proc.Height;
        }
        private Point addPoints(Point p1, Point p2) {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

                private Point findFirstPoint(BinaryProcessor p)
        {
            for (int y = 0; y < p.Width; y++)
            {
                for (int x = 0; x < p.Height; x++)
                {
                    if (p.Image[x, y] > 0)
                        return new Point(x, y);
                }
            }
            return new Point(-1, -1);
        }

        public override string ToString()
        {
            return $"Boundary trace {_se.ToString()} ";
        }
    }
}
