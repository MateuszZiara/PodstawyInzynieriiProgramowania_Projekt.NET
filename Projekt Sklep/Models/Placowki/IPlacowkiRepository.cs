namespace Projekt_Sklep.Models.Placowki
{
    public interface IPlacowkiRepository
    {
        public bool edit(Guid Id, int NrPlacowki, string NIP, Guid Adres);

        public (List<Ubezpieczyciele.Ubezpieczyciele>, List<Polisy.Polisy>, List<Pojazdy.Pojazdy>, List<Klient.KlientEntity>) getByAgenciPolisyPojazdyOsoby(Guid Id);
    }
}
