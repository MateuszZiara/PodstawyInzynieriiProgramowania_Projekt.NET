using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Pages
{
    public class ProfilModel : PageModel
    {
        public void OnGet()
        {
            ViewData["UserName"] = KlientSingleton.Instance.Name;
            ViewData["UserPassword"] = KlientSingleton.Instance.Password;
            ViewData["Email"] = KlientSingleton.Instance.Email;
            ViewData["PhoneNumber"] = KlientSingleton.Instance.NumerTelefonu;
        }
    }
}
