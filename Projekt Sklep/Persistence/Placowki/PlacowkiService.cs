using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models.Placowki;
using Projekt_Sklep.Persistence.Polisy;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Persistence.Placowki
{
    public class PlacowkiService : IPlacowkiService
    {
        readonly PlacowkiRepository _entityRepository = new PlacowkiRepository();

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

        public bool edit(Guid Id, int NrPlacowki, string NIP, Guid Adres)
        {
            return _entityRepository.edit(Id, NrPlacowki, NIP, Adres);
        }

        public (List<Ubezpieczyciele.Ubezpieczyciele>, List<Polisy.Polisy>, List<Pojazdy.Pojazdy>, List<Klient.Klient>) getByAgenciPolisyPojazdyOsoby(Guid Id)
        {
            return _entityRepository.getByAgenciPolisyPojazdyOsoby(Id);
        }
    }
}
