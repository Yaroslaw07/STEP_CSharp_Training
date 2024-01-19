using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithADO.NET
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public decimal CalorificValue { get; set; }

        public Food (int Id, string Name, string Type, string Color, decimal CalorificValue)
        {
            this.Id = Id;
            this.Name = Name;
            this.Type = Type;
            this.Color = Color;
            this.CalorificValue = CalorificValue;
        }

        public string GetString()
        {
            return (Id + " | " 
                + Name + " | " 
                + Type + " | " 
                + Color + " | " 
                + CalorificValue);
        }

        public override string ToString()
        {
            return GetString();
        }
    }

    
}
