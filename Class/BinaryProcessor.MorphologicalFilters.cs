using INFOIBV.Struct;
using System.Linq;
using System;

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
            var buffer = new BinaryProcessor(this.Width, this.Height);

            for (int u = 0; u < structure.Size; u++)
            {
                for (int v = 0; v < structure.Size; v++)
                {
                    if (structure[u,v] > 0)
                    {
                        buffer.Max(this, u - hotspotX, v - hotspotY);                        
                    }
                }
            }
            this.Image = buffer.Image;
        }

        private void Max(BinaryProcessor image, int u, int v)
        {
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    if (u + x >= 0 & u + x < this.Width & v + y >= 0 & v + y < this.Height)
                    {
                        this[x + u, y + v] = Math.Max(this[x + u, y + v], image[x, y]);
                    }
                }
            }
        }
    }
}
