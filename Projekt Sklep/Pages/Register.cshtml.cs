using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Persistence.Klient;
using System.Collections.Generic;

namespace Projekt_Sklep.Pages
{
    public class RegisterModel : PageModel
    {
        // Dodaj w³aœciwoœæ, która bêdzie przechowywaæ dane adresów
        public List<Adres> Addresses { get; set; }

        public void OnGet()
        {
            // Wywo³aj metodê do pobrania danych adresów z bazy danych
            LoadAddresses();
        }

        public void OnPost()
        {
            // Tu mo¿esz obs³u¿yæ logikê po naciœniêciu przycisku, jeœli jest taka potrzeba
        }

        // Dodaj metodê do pobierania danych adresów z bazy danych
        private void LoadAddresses()
        {
            AdresController addressEntityController = new AdresController();
            var result = addressEntityController.GetAll();

            // SprawdŸ, czy pobranie danych by³o udane
            if (result.Result is OkObjectResult okResult)
            {
                Addresses = okResult.Value as List<Adres>;
            }
        }

        public void FormChange(bool state)
        {
            // Dodatkowa metoda, jeœli jest potrzebna
        }
    }
}
