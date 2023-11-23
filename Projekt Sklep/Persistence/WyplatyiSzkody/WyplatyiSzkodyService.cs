using Projekt_Sklep.Models.WyplatyiSzkody;

namespace Projekt_Sklep.Persistence.WyplatyiSzkody
{
    public class WyplatyiSzkodyService : IWyplatyiSzkodyService
    {
        readonly WyplatyiSzkodyRepository _entityRepository = new WyplatyiSzkodyRepository();

        public bool edit(Guid Id, DateTime DataZgloszenia, int WartoscSzkody, string TypSzkody, bool StatusWyplaty, Guid Klient)
        {
            return _entityRepository.edit(Id, DataZgloszenia, WartoscSzkody,TypSzkody, StatusWyplaty ,Klient);
        }

    }
}
