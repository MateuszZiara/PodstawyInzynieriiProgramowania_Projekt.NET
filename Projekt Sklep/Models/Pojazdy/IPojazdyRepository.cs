namespace Projekt_Sklep.Models.Pojazdy
{
    public interface IPojazdyRepository
    {

        public bool edit(Guid Id, int NrRejestracyjny, string Marka, string Model, int Rocznik, string VIN, bool Uszkodzony, Guid Klient);

    }
}
