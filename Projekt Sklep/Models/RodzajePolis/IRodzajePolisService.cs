namespace Projekt_Sklep.Models.RodzajePolis
{
    public interface IRodzajePolisService
    {

         public bool edit(Guid Id, RodzajePolisEnum Rodzaj, DateTime DataRozpoczecia, DateTime DataZakonczenia, int CenaPodstawowa);

    }
}
