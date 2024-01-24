namespace Projekt_Sklep.Models.Klient
{
    public interface IKlientEntityService
    {
        public bool edit(Guid id, string name, string lastname, string pesel, string numertelefonu, string email, string nip, Guid AdresID);
        public (List<Polisy.Polisy>, List<Pojazdy.Pojazdy>) getByPolisaPojazd(Guid Id);

    }
}
