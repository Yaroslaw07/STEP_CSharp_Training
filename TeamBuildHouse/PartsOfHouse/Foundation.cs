using System;
using System.Collections.Generic;
using System.Text;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.PartsOfHouse
{
    class Foundation : IPart
    {
        public long Priority { get; set; }

        public Foundation()
        {
            Priority = 90;
        }
    }
}
