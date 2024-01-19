using System;
using System.Collections.Generic;
using TeamBuildHouse.PartsOfHouse;
using TeamBuildHouse.ToBuildHouse;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Workers.Builder> builders = new List<Workers.Builder>{ new Workers.Builder("Richard Holo"),
                                                                        new Workers.Builder("Nick Flack"),
                                                                        new Workers.Builder("Nick Flack"),
                                                                        new Workers.Builder("Bob Bob")};

            List<Workers.TeamLeader> teamLeaders = new List<Workers.TeamLeader>{ new Workers.TeamLeader("Mile Rick"),
                                                                        new Workers.TeamLeader("Louse Vivil"),};

            Team team = new Team(builders,teamLeaders);

            List<IPart> parts = new List<IPart> { new Door(), new Foundation(), new Roof(), new Window(), new Wall(), new Foundation(), new Wall()};
            BuildingPlan plan = new BuildingPlan(parts);

            team.Construction(plan);
        }
    }
}
