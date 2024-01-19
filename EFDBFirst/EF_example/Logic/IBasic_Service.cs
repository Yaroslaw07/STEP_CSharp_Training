using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_example.Logic
{
    interface IBasic_Service<T> where T:class
    {
        public void Add(Warehouse_Context context, T entity);

        public void Update(Warehouse_Context context, T entity);

        public void Delete(Warehouse_Context context, T entity);

        public bool isFineToAdd(Warehouse_Context context, T entity);

        public bool isFineToDelete(Warehouse_Context context, T entity);
    }
}
