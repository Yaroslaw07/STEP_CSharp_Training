using System;
using System.Collections.Generic;
using System.Text;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.PartsOfHouse
{
    class Roof : IPart
    {
        public long Priority { get; set; }

        public Roof()
        {
            Priority = 30;
        }
    }
}
