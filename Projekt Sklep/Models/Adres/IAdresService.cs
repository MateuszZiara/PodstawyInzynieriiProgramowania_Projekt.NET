namespace Projekt_Sklep.Models.Adres
{
    public interface IAdresService
    {
        public bool edit(Guid id, string kodPocztowy, string miasto, string wojewodztwo, string panstwo);
    }
}
