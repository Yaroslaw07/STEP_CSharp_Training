using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_example.Logic
{
    public class ProductType_Service : IBasic_Service<ProductType>
    {
        public void Add(Warehouse_Context context, ProductType entity)
        {
            if (entity.Id == default)
            {
                context.ProductTypes.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(Warehouse_Context context, ProductType entity)
        {
            if (isFineToDelete(context, entity))
            {
                context.ProductTypes.Remove(entity);
            }

            context.SaveChanges();
        }

        public bool isFineToAdd(Warehouse_Context context, ProductType entity)
        {
            return true;
        }

        public bool isFineToDelete(Warehouse_Context context, ProductType entity)
        {
            if (!context.Products.Any(_ => _.TypeId == entity.Id))
                return true;
            return false;
        }

        public void Update(Warehouse_Context context, ProductType entity)
        {
               
            if (entity.Id == default)
                context.ProductTypes.Add(entity);
            else
                context.ProductTypes.Update(entity);

            context.SaveChanges();
        }

        

        public ProductType GetTypeWithSmallerCount(Warehouse_Context context)
        {
            var smallerCount = context.Products.Min(_ => _.Count);
            var product = context.Products.Include(_ => _.ProductType).Where(_ => _.Count == smallerCount).FirstOrDefault();

            return product.ProductType;
        }

        public ProductType GetTypeWithBiggerCount(Warehouse_Context context)
        {
            var biggerCount = context.Products.Max(_ => _.Count);
            var product = context.Products.Include(_ => _.ProductType).Where(_ => _.Count == biggerCount).FirstOrDefault();

            return product.ProductType;
        }

        
    }
}
