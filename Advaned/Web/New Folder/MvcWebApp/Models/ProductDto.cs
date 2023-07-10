using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcWebApp.Models
{
    public class ProductDto
    {
        [Required]
        public decimal Price { get; set; }

        [Required][Range(1, 100)]
        public int Stock { get; set; }

        public void Insert()
        {
            using (ShopEntities shop = new ShopEntities())
            {
                Counter ctr = shop.Counters.Single(c => c.Name == "product");
                int productNo = ++ctr.CurrentValue + 100;
                Product product = Product.CreateProduct(productNo, Price, Stock);

                shop.Products.AddObject(product);
                shop.SaveChanges();
            }
        }
    }
}