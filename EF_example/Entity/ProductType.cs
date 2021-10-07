using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_example
{
    public class ProductType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("TypeId")]
        public IEnumerable<Product> Products { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }
}
