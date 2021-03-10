using System;
using System.Collections.Generic;
using System.Text;
using TeamBuildHouse.ToBuildHouse;
using static TeamBuildHouse.Interfaces;

namespace TeamBuildHouse.Workers
{
    
    public class Builder : IWorker
    {
        Random rand = new Random();
        public string FullName { get; set; }

        public int Stamina { get; set; }

        public Builder(string fullName)
        {
            FullName = fullName;

            Stamina = rand.Next() % 20 + 80;
        }

        public void Build(BuildingPlan plan)
        {
            long currentPriority = plan.PlannedParts[0].Priority;
            int index = 0;

            for(int i = 1; i < plan.PlannedParts.Count;i++)
            {
                if(currentPriority < plan.PlannedParts[i].Priority)
                {
                    index = i;
                    currentPriority = plan.PlannedParts[i].Priority;
                }
            }
            if (isNeedBreak() == false)
            {
                Console.WriteLine("Builder " + FullName + " do a " + plan.PlannedParts[index].GetType());


                if (plan.ReleasedParts == null)
                {
                    plan.ReleasedParts = new List<IPart> { plan.PlannedParts[index] };
                }
                else
                    plan.ReleasedParts.Add(plan.PlannedParts[index]);
                plan.PlannedParts.RemoveAt(index);
            }
            else
                Console.WriteLine("Builder " + FullName + "have a break");
        }

        private bool isNeedBreak()
        {
            if(rand.Next()%100 > Stamina)
            {
                Stamina += rand.Next() % 11 + 5;
                return true;
            }
            else
            {
                Stamina -= rand.Next() % 11 + 10;
                return false;
            }
        }
    }

}
