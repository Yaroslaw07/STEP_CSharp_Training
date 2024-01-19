using System;
using System.Collections.Generic;
using System.Text;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.ToBuildHouse
{
    public class BuildingPlan
    {
        public List<IPart> PlannedParts;

        public List<IPart> ReleasedParts;

        public BuildingPlan(List<IPart> plan)
        {
            PlannedParts = plan;
        }

        public bool IsReady()
        {
            return PlannedParts.Count == 0;
        }
    }
}
