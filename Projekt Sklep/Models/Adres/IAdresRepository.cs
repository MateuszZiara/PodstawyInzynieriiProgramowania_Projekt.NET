namespace Projekt_Sklep.Models.Adres
{
    public interface IAdresRepository
    {
        public bool edit(Guid id, string kodPocztowy, string miasto, string wojewodztwo, string panstwo);
    }
}
