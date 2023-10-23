namespace Projekt_Sklep.Models.Placowki
{
    public interface IPlacowkiRepository
    {
        public bool edit(Guid Id, int NrPlacowki, string NIP, Guid Adres);
    }
}
