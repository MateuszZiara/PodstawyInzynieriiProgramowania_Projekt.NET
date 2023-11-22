using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models.Placowki;
using Projekt_Sklep.Models.Pojazdy;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Persistence.Pojazdy
{
    public class PojazdyService : IPojazdyService
    {
        readonly PojazdyRepository _entityRepository;

        void IPojazdyService.VINCheck(string VIN)
        {
            Regex regex = new Regex(@"^[A-HJ-NPR-Z0-9]{17}$");
            Match match = regex.Match(VIN);
            if (!match.Success)
            {
                throw new ArgumentException("Wpisany VIN jest niepoprawny.");
            }

        }

        void IPojazdyService.RejestracyjnyChceck(string NrRejestracyjny)
        {
            NrRejestracyjny =  NrRejestracyjny.ToUpper();
            string wyróżnikMiejsca = @"^[A-Z]{2,3}";

            // Znaki losowe (5 lub 4 znaki, bez liter B, D, I, O, Z)
            string znakiLosowe = @"^[A-CEGHJ-KL-NPR-TV-Y0-9]{4,5}$";

            // Łączymy wszystkie elementy w jedno wyrażenie regularne
            string regexPattern = $"{wyróżnikMiejsca}{znakiLosowe}$";

            Regex regex = new Regex(regexPattern);
         Match match = regex.Match(NrRejestracyjny);
            if (!match.Success || NrRejestracyjny.Length>7)
            {
                throw new ArgumentException("Wpisany numer tablicy rejestracyjnej jest niepoprawny.");
            }
        }

    }
}
