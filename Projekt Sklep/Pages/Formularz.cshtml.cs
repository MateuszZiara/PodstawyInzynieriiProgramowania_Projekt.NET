using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Pages
{
    public class FormularzModel : PageModel
    {
        public string adresString;
        public void OnGet()
        {
            AdresController adresController = new AdresController();
            var result = adresController.GetAll();
            bool passed = false;
            var okResult = result.Result as OkObjectResult;
            var adresList = okResult?.Value as List<Adres>;
            Adres adres = new Adres();
            foreach (var a in adresList)
            {
                if (a.Id == KlientSingleton.Instance.Adres)
                {
                    adres = a;
                }
            }

            adresString = adres.KodPocztowy + " " + adres.Miasto + " " + adres.Wojewodztwo + " " + adres.Panstwo;
        }
    }
}
