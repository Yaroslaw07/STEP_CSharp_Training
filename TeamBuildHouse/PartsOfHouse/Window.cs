using System;
using System.Collections.Generic;
using System.Text;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.PartsOfHouse
{
    class Window : IPart
    {
        public long Priority { get; set; }

        public Window()
        {
            Priority = 60;
        }
    }
}
