using System;
using System.Collections.Generic;
using System.Text;
using TeamBuildHouse.ToBuildHouse;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.Workers
{
   public class TeamLeader : IWorker
   {
       public string FullName { get; set; }

       public TeamLeader(string fullname)
       {
           FullName = fullname;
       }

       public void Report(BuildingPlan plan)
        {
            Console.WriteLine("TeamLeader " + FullName + "has a report:");

            if (plan.ReleasedParts == null)
            {
                Console.WriteLine("House ready for 0%");

            }
            else
            Console.WriteLine("House ready for " + (plan.ReleasedParts.Count*100)/(plan.PlannedParts.Count + plan.ReleasedParts.Count)+ "%");

            Console.WriteLine("Ready parts");

            foreach(IPart part in plan.ReleasedParts)
            {
                Console.WriteLine("\t" + part.GetType());
            }
        }
   }
}
