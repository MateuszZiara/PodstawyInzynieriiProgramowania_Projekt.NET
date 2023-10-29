namespace Projekt_Sklep.Models.Klient
{
    public interface IKlientEntityRepository
    {
        public bool edit(Guid id, Guid AdresID, string name, string lastname, string pesel, string numertelefonu, string email, string nip);
        public (List<Polisy.Polisy>, List<Pojazdy.Pojazdy>) getByPolisaPojazd(Guid Id);
    }

}
