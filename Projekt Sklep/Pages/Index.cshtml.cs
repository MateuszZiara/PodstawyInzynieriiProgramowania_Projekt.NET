using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Controllers.Klient;
using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;
using System.Collections.Generic;

namespace Projekt_Sklep.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AdresController _klientController;

        public List<Adres> KlientEntities { get; set; }

        public IndexModel(AdresController klientController)
        {
            _klientController = klientController;
        }

        public void OnGet()
        {
            var result = _klientController.GetAll();

            if (result is ActionResult<IEnumerable<Adres>> actionResult && actionResult.Result is OkObjectResult okObjectResult)
            {
                KlientEntities = (List<Adres>)okObjectResult.Value;
            }
            else
            {
                // Handle the case when the result is not as expected
                // For example, set KlientEntities to an empty list or log a message.
                KlientEntities = new List<Adres>();
            }
        }
    }
}