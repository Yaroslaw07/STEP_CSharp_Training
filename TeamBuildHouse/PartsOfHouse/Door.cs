using System;
using System.Collections.Generic;
using System.Text;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.PartsOfHouse
{
    class Door : IPart
    {
        public long Priority { get; set; }

        public Door()
        {
            Priority = 50;
        }
    }
}
