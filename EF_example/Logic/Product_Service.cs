using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_example.Logic
{
    public class Product_Service : IBasic_Service<Product>
    {
        public void Add(Warehouse_Context context, Product entity)
        {
            if (isFineToAdd(context, entity) && entity.Id == default)
            {
                context.Products.Add(entity);

                context.SaveChanges();
            }
        }

        public void Delete(Warehouse_Context context, Product entity)
        {
            if(entity.Id != default && (context.Products.Find(entity.Id)) == entity)
                context.Products.Remove(entity);

            context.SaveChanges();
        }

        public bool isFineToAdd(Warehouse_Context context, Product entity)
        {
            if (context.ProductTypes.Any(_ => _.Id == entity.TypeId) && (context.Providers.Any(_ => _.Id == entity.ProviderId)))
                return true;
            return false;
        }

        public bool isFineToDelete(Warehouse_Context context, Product entity)
        {
            return true;
        }

        public void Update(Warehouse_Context context, Product entity)
        {
            if (isFineToAdd(context,entity))
            {
                if (context.Products.Any(_ => _.Id == entity.Id))
                    context.Products.Update(entity);
                else
                    context.Products.Add(entity);

                context.SaveChanges();
            }
        }

        public List<Product> GetProductByCountOfDays(Warehouse_Context context, int countOfDays)
        {
            var products = context.Products.Where(_ => (DateTime.Now - _.Date).TotalDays > countOfDays).ToList();

            return products;
        }
    }




}
