using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ITS.Sample1WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.Sample1WebApplication.Pages.Products
{
    public class EditModel : PageModel
    {

        //scrivo questa riga completa, la seleziono e poi aspetto la lampadina e genero il costruttore. 
        private readonly IProductsDataService _productsDataService;

        public EditModel(IProductsDataService productsDataService)
        {
            _productsDataService = productsDataService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            //REGOLE DI VALIDAZIONE - metadati
            [Display(Name = "Codice")] //etichetta... come voglio che venga visualizzato un dato
            [Required] //questa proprietà è obbligatoria
            [StringLength(5)]

            public string Code { get; set; }
            [Display(Name = "Descrizione")]
            [Required] //questa proprietà è obbligatoria
            [StringLength(25)]
            public string Name { get; set; }
        }



        public void OnGet(int id) //INGRESSO NELLA PAGINA
        {
            var product = _productsDataService.GetProduct(id);
            //la mia proprietà input ora avrà un oggetto con Code e Name
            this.Input = new InputModel
            {
                Code = product.Code,
                Name = product.Name
            };
        }

        public IActionResult OnPost(int id)
        {
            if(ModelState.IsValid) //se il database è connesso allora lo salva
            {
                //questa classe simula l'accesso ai dati
                _productsDataService.UpdateProduct(id, Input.Code, Input.Name);
                return RedirectToPage("/Index");
            }

            //Validazione sia lato server che lato client
            //ModelState.AddModelError("", "Errore nell'aggiornamento del prodotto.");
            //ModelState.AddModelError("Input.Code", "Errore caso");
            return Page();
        }
    }
}