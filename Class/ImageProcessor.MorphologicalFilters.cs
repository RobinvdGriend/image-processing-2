﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using INFOIBV.Struct;

namespace INFOIBV.Class
{
    partial class ImageProcessor
    {
        public virtual void Dilate(StructuringElement structure)
        {
            // We assume that the hotspot of the structuring element is in
            // the middle.
            var hotspotX = (int)(structure.Size) / 2;
            var hotspotY = (int)(structure.Size) / 2;
            var buffer = (int[,])Image.Clone();
            
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var structuredSums = new List<int>();

                    for (int u = 0; u < structure.Size; u++)
                    {
                        for (int v = 0; v < structure.Size; v++)
                        {
                            if (structure[u,v] > 0)
                            {
                                var p = x + u - hotspotX;
                                var q = y + v - hotspotY;

                                if (p >= 0 & q >= 0 & p < Width & q < Height)
                                {
                                    structuredSums.Add(processStructure(Image[p,q], structure[u,v]));
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
                }
            }
            Image = buffer;
        }
        protected virtual int processStructure(int iValue, int sValue) {
            return iValue + sValue;
        }
        public void Erode(StructuringElement structure)
        {
            this.Complement();
            this.Dilate(structure.Reflection);
            this.Complement();
        }

        public void Open(StructuringElement structure)
        {
            this.Erode(structure);
            this.Dilate(structure);
        }

        public void Close(StructuringElement structure)
        {
            this.Dilate(structure);
            this.Erode(structure);
        }
    }
}
