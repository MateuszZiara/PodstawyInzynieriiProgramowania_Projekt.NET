using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models.Placowki;
using Projekt_Sklep.Models.Pojazdy;
using System.Text.RegularExpressions;

namespace Projekt_Sklep.Persistence.Pojazdy
{
    public class PojazdyService : IPojazdyService
    {
        readonly PojazdyRepository _entityRepository = new PojazdyRepository();

        void IPojazdyService.VINCheck(string VIN)
        {
            Regex regex = new Regex(@"^[A-HJ-NPR-Z0-9]{17}$");
            Match match = regex.Match(VIN);
            if (match.Success)
            {

            }
            else
            {
                throw new ArgumentException();
            }
        }
        public bool edit(Guid Id, int NrRejestracyjny, string Marka, string Model, int Rocznik, string VIN, bool Uszkodzony, Guid Klient)
        {
            return _entityRepository.edit(Id, NrRejestracyjny,Marka,Model, Rocznik,VIN, Uszkodzony, Klient);
        }
    }
}
