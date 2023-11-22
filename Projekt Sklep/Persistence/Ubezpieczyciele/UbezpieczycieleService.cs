using Projekt_Sklep.Models.Ubezpieczyciele;
using Projekt_Sklep.Persistence.Placowki;

namespace Projekt_Sklep.Persistence.Ubezpieczyciele
{
    public class UbezpieczycieleService : IUbezpieczycieleService
    {
        readonly UbezpieczycieleRepository _entityRepository = new UbezpieczycieleRepository();

        public bool edit(Guid Id, string Nazwisko, string Email, string Phone, string OsobaKontaktowa, string NazwaFirmy, Guid Placowki)
        {
            return _entityRepository.edit(Id, Nazwisko, Email, Phone, OsobaKontaktowa, NazwaFirmy, Placowki);
        }
    }
}
