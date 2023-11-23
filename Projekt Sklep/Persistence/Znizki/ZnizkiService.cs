using Projekt_Sklep.Models.Znizki;

namespace Projekt_Sklep.Persistence.Znizki
{
    public class ZnizkiService :IZnizkiService
    {
        readonly ZnizkiRepository _entityRepository = new ZnizkiRepository();

        public bool edit(Guid Id, string Dorosly_dziecko, bool Wiek)
        {
            return _entityRepository.edit(Id, Dorosly_dziecko, Wiek);
        }

    }
}
