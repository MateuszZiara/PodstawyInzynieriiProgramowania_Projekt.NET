using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace Projekt_Sklep.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }
        
        public void OnGet() // When the page is opened
        {
        }

        public void OnPost() // When the form is submitted
        {
            // Access the form values through the properties
            string email = Email;
            string password = Password;

            // Print the values to the console
            System.Console.WriteLine($"Email: {email}");
            System.Console.WriteLine($"Password: {password}");

        }

        public void FormChange(bool state)
        {
            // Additional method if needed
        }
    }
}