using System;
using System.Collections.Generic;
using System.Text;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.ToBuildHouse
{
    public class Team
    {
        public List<Workers.Builder> Builders;

        public List<Workers.TeamLeader> TeamLeaders;

        public Team(List<Workers.Builder> builders,
                    List<Workers.TeamLeader> teamLeaders)
        {
            Builders = builders;

            TeamLeaders = teamLeaders;
        }

        public void Construction(BuildingPlan plan)
        {
            Random random = new Random();
            
            while(!plan.IsReady())
            {
                Builders[random.Next()%Builders.Count].Build(plan);
                if(random.Next()% 2 == 0)
                {
                    TeamLeaders[random.Next()%TeamLeaders.Count].Report(plan);
                }
            }

            TeamLeaders[random.Next() % TeamLeaders.Count].Report(plan);
        }
    }
}
