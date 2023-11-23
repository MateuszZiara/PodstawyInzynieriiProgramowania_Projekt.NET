namespace Projekt_Sklep.Models.RodzajePolis
{
    public interface IRodzajePolisRepository
    {
         public bool edit(Guid Id, RodzajePolisEnum Rodzaj , DateTime DataRozpoczecia, DateTime DataZakonczenia, int CenaPodstawowa);
    }
}
