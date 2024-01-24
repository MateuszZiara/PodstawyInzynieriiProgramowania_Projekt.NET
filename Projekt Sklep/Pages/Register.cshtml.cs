using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Persistence.Klient;
using System.Collections.Generic;
using Projekt_Sklep.Controllers.Klient;

namespace Projekt_Sklep.Pages
{
    
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Pesel { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string NIP { get; set; }
        [BindProperty]
        public string Login { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string KodPocztowy { get; set; }
        [BindProperty]
        public string Miasto { get; set; }
        [BindProperty]
        public string Wojewodztwo { get; set; }
        [BindProperty]
        public string Panstwo { get; set; }
        
        
        public List<Adres> Addresses { get; set; }

        public void OnGet()
        {
          
        }

        public IActionResult OnPost()
        {
            System.Console.WriteLine($"Name: {Name}");
            System.Console.WriteLine($"LastName: {LastName}");
            System.Console.WriteLine($"Pesel: {Pesel}");
            System.Console.WriteLine($"PhoneNumber: {PhoneNumber}");
            System.Console.WriteLine($"Email: {email}");
            System.Console.WriteLine($"NIP: {NIP}");
            System.Console.WriteLine($"Login: {Login}");
            System.Console.WriteLine($"Password: {Password}");
            System.Console.WriteLine($"KodPocztowy: {KodPocztowy}");
            System.Console.WriteLine($"Miasto: {Miasto}");
            System.Console.WriteLine($"Wojewodztwo: {Wojewodztwo}");
            System.Console.WriteLine($"Panstwo: {Panstwo}");

            KlientEntityController controller = new KlientEntityController();
            KlientEntity klientEntity = new KlientEntity();
            klientEntity.Name = Name;
            klientEntity.LastName = LastName;
            klientEntity.Pesel = Pesel;
            klientEntity.NumerTelefonu = PhoneNumber;
            klientEntity.Email = email;
            klientEntity.NIP = NIP;
            klientEntity.Login = Login;
            klientEntity.Password = Password;
            AdresController adresController = new AdresController();
            var result = adresController.GetAll();
            bool passed = false;
            var okResult = result.Result as OkObjectResult;
            var adresList = okResult?.Value as List<Adres>;
            Guid adresID = Guid.Empty;
            Adres finalAdres = new Adres();
            foreach (Adres adres in adresList)
            {
                if (adres.KodPocztowy == KodPocztowy && adres.Miasto == Miasto && adres.Wojewodztwo == Wojewodztwo && adres.Panstwo == Panstwo)
                {
                    passed = true;
                    adresID = adres.Id;
                    finalAdres = adres;
                }
            }
            
            if (!passed)
            {
                Adres adres = new Adres();
                adres.KodPocztowy = KodPocztowy;
                adres.Miasto = Miasto;
                adres.Wojewodztwo = Wojewodztwo;
                adres.Panstwo = Panstwo;
                adresController.CreateAdresEntity(adres); ;
                foreach (Adres a in adresList)
                {
                    if (a.KodPocztowy == KodPocztowy && a.Miasto == Miasto && a.Wojewodztwo == Wojewodztwo && a.Panstwo == Panstwo)
                    {
                        adres.Id = a.Id;
                    }
                }
                

                if (adres.Id == null || adres.Id == Guid.Empty)
                {
                    Console.WriteLine("Something went wrong with Guid implementation. Its critical but developers dont really care so If it doesn't work it won't anyways.");
                    return null;
                }
                finalAdres = adres;
            }

            if (finalAdres == null || finalAdres.Id == null || finalAdres.Id == Guid.Empty)
            {
                Console.WriteLine("It is really more dangerous error cause errors before should exit the app. If before errors doesn't exit the app and you still see this error it means that devs were drunk as hell. ");
                return null;
            }

            klientEntity.Adres = finalAdres.Id;
            controller.CreateKlientEntity(klientEntity);
            return Redirect("/");
            
        }

        

        public void FormChange(bool state)
        {
 
        }
    }
}
