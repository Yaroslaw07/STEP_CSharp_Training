using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_example
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        

        public ProductType ProductType { get; set; }

        public int TypeId { get; set; }

        public int ProviderId { get; set; }

        public Provider Provider { get; set; } 

        public int Count { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {ProviderId}, {TypeId}, {Count}, {Price}, {Date}";
        }
    }
}
