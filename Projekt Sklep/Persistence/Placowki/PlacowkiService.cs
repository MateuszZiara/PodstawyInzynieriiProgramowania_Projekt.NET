using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models.Placowki;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Persistence.Placowki
{
    public class PlacowkiService : IPlacowkiService
    {
        readonly PlacowkiRepository _entityRepository;

        void IPlacowkiService.NIPCheck(string NIP)
        {
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{2}-\d{2}$");
            Match match = regex.Match(NIP);
            if (match.Success)
            {

            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
