using Projekt_Sklep.Models.RodzajePolis;

namespace Projekt_Sklep.Persistence.RodzajePolis
{
    public class RodzajePolisService : IRodzajePolisService
    {
        readonly RodzajePolisRepository _entityRepository = new RodzajePolisRepository();
        public bool edit(Guid Id, RodzajePolisEnum Rodzaj, DateTime DataRozpoczecia, DateTime DataZakonczenia, int CenaPodstawowa)
        {
            return _entityRepository.edit(Id,Rodzaj, DataRozpoczecia, DataZakonczenia, CenaPodstawowa);
        }

    }
}
