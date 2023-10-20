using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Klient
{
    public class KlientEntityService : IKlientEntityService
    {
        readonly KlientEntityRepository _entityRepository = new KlientEntityRepository();

        public bool edit(Guid id, string name, string lastname, string pesel, string numertelefonu, string email, string nip, Guid AdresID)
        {
            return _entityRepository.edit(id,AdresID, name, lastname, pesel, numertelefonu, email, nip);
        }
    }
}
