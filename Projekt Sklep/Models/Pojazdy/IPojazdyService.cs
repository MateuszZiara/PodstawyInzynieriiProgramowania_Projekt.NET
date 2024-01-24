using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Models.Pojazdy
{
    public interface IPojazdyService
    {
        void VINCheck(string VIN);
        public bool edit(Guid Id, string NrRejestracyjny, string Marka, string Model, int Rocznik, string VIN, bool Uszkodzony, Guid Klient);

        public List<Pojazdy> getAll();

    }
}
