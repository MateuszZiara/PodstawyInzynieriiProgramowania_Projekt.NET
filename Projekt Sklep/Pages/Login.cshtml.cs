using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Primitives;
using Projekt_Sklep.Controllers.Klient;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Persistence.Klient;

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

        public IActionResult OnPost() // When the form is submitted
        {
            
            // Access the form values through the properties
            string email = Email;
            string password = Password;

            // Print the values to the console
            System.Console.WriteLine($"Email: {email}");
            System.Console.WriteLine($"Password: {password}");
            
            KlientEntityController klientEntityController = new KlientEntityController();
            var result = klientEntityController.GetAll();
            bool passed = false;
            var okResult = result.Result as OkObjectResult;
            var klientList = okResult?.Value as List<Models.Klient.KlientEntity>;
            Console.WriteLine(klientList.Count);
                foreach (KlientEntity klientEntity in klientList)
                {
                    if (klientEntity.Email == Email && klientEntity.Password == Password)
                    {
                        passed = true;
                    KlientSingleton.Instance.Id = klientEntity.Id;
                    KlientSingleton.Instance.Name = klientEntity.Name;
                    KlientSingleton.Instance.LastName = klientEntity.LastName;
                    KlientSingleton.Instance.Pesel = klientEntity.Pesel;
                    KlientSingleton.Instance.NumerTelefonu = klientEntity.NumerTelefonu;
                    KlientSingleton.Instance.Email = klientEntity.Email;
                    KlientSingleton.Instance.NIP = klientEntity.NIP;
                    KlientSingleton.Instance.Login = klientEntity.Login;
                    KlientSingleton.Instance.Password = klientEntity.Password;
                    KlientSingleton.Instance.Adres = klientEntity.Adres;



                        break;
                    }
                }

              
            if (passed)
            {
                Console.WriteLine("Zalogowano");
                return Redirect("/home");
            }
            else
            {
                Console.WriteLine("Złe passy");
            }

            return Redirect("/");
        }

        public void FormChange(bool state)
        {
            // Additional method if needed
        }
    }
}