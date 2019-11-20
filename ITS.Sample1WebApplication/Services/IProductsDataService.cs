using ITS.Sample1WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Sample1WebApplication.Services
{
    public interface IProductsDataService
    {
        //metodi pubblici che un'interfaccia deve andare a implementare. 
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);

        void UpdateProduct(int id, string code, string name);
     
    }
}
