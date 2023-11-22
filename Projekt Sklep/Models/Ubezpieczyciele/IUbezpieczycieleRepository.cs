namespace Projekt_Sklep.Models.Ubezpieczyciele
{
    public interface IUbezpieczycieleRepository
    {

        public bool edit(Guid Id, string Nazwisko, string Email, string Phone, string OsobaKontaktowa, string NazwaFirmy, Guid Placowki);

    }
}
