using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_example.Logic
{
    public class Provider_Service : IBasic_Service<Provider>
    {
        public void Add(Warehouse_Context context, Provider entity)
        {
            if (entity.Id == default)
            {
                context.Providers.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Warehouse_Context context, Provider entity)
        {
            if (isFineToDelete(context, entity))
            {
                context.Providers.Remove(entity);
            }

            context.SaveChanges();
        }

        public bool isFineToAdd(Warehouse_Context context, Provider entity)
        {
            return true;
        }

        public bool isFineToDelete(Warehouse_Context context, Provider entity)
        {
            if (!context.Products.Any(_ => _.ProviderId == entity.Id))
                return true;
            return false;
        }

        public void Update(Warehouse_Context context, Provider entity)
        {
                
            if (entity.Id == default)
                context.Providers.Add(entity);
            else
                context.Providers.Update(entity);

            context.SaveChanges();
        }

        public Provider GetProviderWithSmallerCount(Warehouse_Context context)
        {
            var smallerCount = context.Products.Min(_ => _.Count);
            var product = context.Products.Include(_ => _.Provider).Where(_ => _.Count == smallerCount).FirstOrDefault();

            return product.Provider;
        }

        public Provider GetProviderWithBiggerCount(Warehouse_Context context)
        {
            var biggerCount = context.Products.Max(_ => _.Count);
            var product = context.Products.Include(_ => _.Provider).Where(_ => _.Count == biggerCount).FirstOrDefault();

            return product.Provider;
        }

        


    }
}
