using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projekt_Sklep.Models.Pages;

public class index : PageModel
{
    public string imie;
    public void OnGet()
    {
        imie = "Paweł Karaś";
    }
}