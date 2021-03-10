using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuildHouse
{
    public class Interfaces
    {
        public interface IWorker
        {
            public string FullName { get; set; }

        }

        public interface IPart
        {
            public long Priority { get; set; }
        }

    }
}
