namespace Projekt_Sklep.Models.Klient
{
    public interface IKlientEntityService
    {
        public bool edit(Guid id, string name, string lastname, string pesel, string numertelefonu, string email, string nip, Guid AdresID);
    }
}
