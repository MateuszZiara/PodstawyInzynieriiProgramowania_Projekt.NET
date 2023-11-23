namespace Projekt_Sklep.Models.Znizki
{
    public interface IZnizkiRepository
    {
        public bool edit(Guid Id, string Dorosly_dziecko, bool Wiek);
    }
}
