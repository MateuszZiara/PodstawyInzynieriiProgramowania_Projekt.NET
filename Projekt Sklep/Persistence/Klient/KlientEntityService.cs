using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Klient
{
    public class KlientEntityService : IKlientEntityService
    {
        readonly KlientEntityRepository _entityRepository;

    }
}
