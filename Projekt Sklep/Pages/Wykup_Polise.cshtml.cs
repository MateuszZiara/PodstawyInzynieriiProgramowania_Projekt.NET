using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt_Sklep.Pages
{
    public class Wykup_PoliseModel : PageModel
    {
        [BindProperty]
        public string button { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            
            switch (button)
            {
                case "life":
                    
                    return RedirectToPage("/Wybor_Polisy", new { policyType = "life", additionalData = "dane_dla_zycia" });
                case "car":
                    return RedirectToPage("/Wybor_Polisy", new { policyType = "car", additionalData = "dane_dla_samochodu" });
                case "property":
                    return RedirectToPage("/Wybor_Polisy", new { policyType = "property", additionalData = "dane_dla_nieruchomosci" });
                case "firm":
                    return RedirectToPage("/Wybor_Polisy", new { policyType = "firm", additionalData = "dane_dla_firmy" });
                case "group":
                    return RedirectToPage("/Wybor_Polisy", new { policyType = "group", additionalData = "dane_dla_grupy" });
                default:
                    return RedirectToPage("/Wybor_Polisy");
            }
        }
    }
}
