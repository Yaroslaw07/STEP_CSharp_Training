using EF_example.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse_Context context = new Warehouse_Context();

            Product_Service product_Service = new Product_Service();

            ProductType_Service type_Service = new ProductType_Service();

            Provider_Service provider_Service = new Provider_Service();

            #region {test of insert, update and delete} 
            /*Product product = new Product
            {
                Name = "jojo",
                Count = 312,
                TypeId = 1,
                ProviderId = 1,
                Date = DateTime.Now,
                Price = 34.23M
            };*/

            //product_Service.Delete(context, product);



            /*ProductType type = new ProductType() { Name = "7t" };

            type_Service.Add(context, type);

            ProductType type2 = new ProductType() { Id = 1,Name = "16t" };

            type_Service.Update(context, type2);*/

            //type_Service.Delete(context, type);

            #endregion

            Console.WriteLine(type_Service.GetTypeWithBiggerCount(context).ToString());

            Console.WriteLine(type_Service.GetTypeWithSmallerCount(context).ToString());

            Console.WriteLine(provider_Service.GetProviderWithSmallerCount(context).ToString());

            Console.WriteLine(provider_Service.GetProviderWithBiggerCount(context).ToString());

            foreach(var product in product_Service.GetProductByCountOfDays(context,2))
            {
                Console.WriteLine(product.ToString());
            }

        }


    }
}
