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
            var p2 = (BinaryProcessor)p.Clone();
            p2.Erode(_se);
            p2.Complement();
            p.And(p2);
            var a = BoundaryPixels(p);
            return p.GetBitmap();
        }

        private List<Point> BoundaryPixels(BinaryProcessor p) {
            var dirs = new List<Tuple<Direction, Point>>() {
                new Tuple<Direction,Point>(Direction.North, new Point(0,-1)),
                new Tuple<Direction,Point>(Direction.NorthEast, new Point(1,-1) ),
                new Tuple<Direction, Point>(Direction.East, new Point(1,0) ),
                new Tuple<Direction, Point>(Direction.SouthEast, new Point(1,1) ),
                new Tuple<Direction, Point>(Direction.South, new Point(0,1) ),
                new Tuple<Direction, Point>(Direction.SouthWest, new Point(-1,1) ),
                new Tuple<Direction, Point>(Direction.West, new Point(-1,0) ),
                new Tuple<Direction, Point>(Direction.NorthWest, new Point(-1,-1) ),
            };

            var point = findFirstPoint(p);
            if (point.X == -1)
                return null;

            var set = new HashSet<Tuple<Point, Direction>>();
            var list = new List<Point>();
            var img = p.Image;
            while (true){
                Tuple<Direction, Point> dir = null;
                foreach (var d in dirs)
                {
                    dir = d;
                    if (img[d.Item2.X + point.X, d.Item2.Y + point.Y] > 0)
                        break;
                }
                var entry = new Tuple<Point, Direction>(point, dir.Item1);
                if (set.Contains(entry))
                    break;
                else {
                    set.Add(entry);
                    var pnt = dir.Item2;
                    list.Add(entry.Item1);
                    point = new Point(point.X + pnt.X, point.Y + pnt.Y);
                }
            }
            return list;
        }

        private Point findFirstPoint(BinaryProcessor p)
        {
            for (int x = 0; x < p.Width; x++)
            {
                for (int y = 0; y < p.Height; y++)
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
