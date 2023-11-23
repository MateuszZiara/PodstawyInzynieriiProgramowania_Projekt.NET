namespace Projekt_Sklep.Models.Znizki
{
    public interface IZnizkiService
    {
        public bool edit(Guid Id, string Dorosly_dziecko, bool Wiek);
    }
}
