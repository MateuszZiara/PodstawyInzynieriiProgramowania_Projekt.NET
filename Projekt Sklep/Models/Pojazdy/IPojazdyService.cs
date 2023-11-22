namespace Projekt_Sklep.Models.Pojazdy
{
    public interface IPojazdyService
    {
        void VINCheck(string VIN);
        void RejestracyjnyChceck(string NrRejestracyjny);
    }
}
