using INFOIBV.Struct;
using System.Linq;

namespace INFOIBV.Class
{
    partial class BinaryProcessor
    {
        public override void Dilate(StructuringElement structure)
        {
            // We assume that the hotspot of the structuring element is in
            // the middle.
            var hotspotX = (int)(structure.Size) / 2;
            var hotspotY = (int)(structure.Size) / 2;
            var buffer = (int[,])Image.Clone();

            for (int u = 0; u < structure.Size; u++)
            {
                for (int v = 0; v < structure.Size; v++)
                {
                    if (structure[u, v] > 0)
                    {
                        var p = x + u - hotspotX;
                        var q = y + v - hotspotY;

                        if (p >= 0 & q >= 0 & p < Width & q < Height)
                        {
                            ;
                        }
                    }
                }
            }

            var structuredMax = structuredSums.Max();

            if (structuredMax < 0)
            {
                structuredMax = 0;
            }
            else if (structuredMax > 255)
            {
                structuredMax = 255;
            }

            buffer[x, y] = structuredMax;

            Image = buffer;
        }
    }
}
