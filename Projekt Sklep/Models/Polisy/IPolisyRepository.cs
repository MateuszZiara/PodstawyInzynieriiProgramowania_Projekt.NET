namespace Projekt_Sklep.Models.Polisy
{
    public interface IPolisyRepository
    {
        public bool czyAktywna(Guid Id);
    }
}
