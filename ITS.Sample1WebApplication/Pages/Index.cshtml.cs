using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.Sample1WebApplication.Models;
using ITS.Sample1WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ITS.Sample1WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductsDataService _data;

        public DateTime CurrentDate { get; set; }
        public IEnumerable<string> List { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger, 
            IProductsDataService productsDataService)
        {
            _logger = logger;
            _data = productsDataService;
        }

        public void OnGet()
        {
            CurrentDate = DateTime.Today;

            var temp = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                temp.Add($"Prodotto {i}");
            }
            List = temp;

            
            Products = _data.GetProducts();
        }


    }
}
