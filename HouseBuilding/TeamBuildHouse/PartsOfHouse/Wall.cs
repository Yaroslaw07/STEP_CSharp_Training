using System;
using System.Collections.Generic;
using System.Text;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.PartsOfHouse
{
    class Wall : IPart
    {
        public long Priority { get; set; }

        public Wall()
        {
            Priority = 80;
        }
    }
}
