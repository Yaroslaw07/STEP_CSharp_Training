using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithADO.NET
{
    public struct ColorStatisticItem
    {
        public string NameColor;
        public int Count;

        public override string ToString()
        {
            return (NameColor + " | " + Count);
        }
    }
}
