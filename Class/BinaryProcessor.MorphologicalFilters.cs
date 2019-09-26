using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INFOIBV.Class
{
    partial class BinaryProcessor
    {
        protected override int processStructure(int iValue, int sValue)
        {
            return iValue * sValue;
        }
    }
}
