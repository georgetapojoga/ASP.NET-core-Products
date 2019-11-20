using ITS.Sample1WebApplication.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Sample1WebApplication.Services
{
    public class ProductsDataService: IProductsDataService //aggiungere l'interfaccia implementata
    {   private IEnumerable<Product> _products;
        public ProductsDataService(IConfiguration configuration)
        {
            var maxItems = configuration.GetValue<int>("MaxItems");
            var list = new List<Product>();
            for (int i = 0; i < maxItems; i++)
            {
                list.Add(new Product
                {
                    Id = i,
                    Code = $"ABC{i}",
                    Name = $"Prodotto {i}"
                });

                _products = list;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(int id, string code, string name)
        {
            var p = _products.FirstOrDefault(p => p.Id == id);
            p.Code = code;
            p.Name = name;
        }
    }
}
