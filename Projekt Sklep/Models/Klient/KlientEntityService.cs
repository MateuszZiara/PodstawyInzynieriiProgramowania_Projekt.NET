using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Klient;
namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntityService : IKlientEntityService
    {
        readonly KlientEntityRepository _entityRepository;
        public KlientEntity AddKlientEntity(KlientEntity klientEntity)
        {
            if (klientEntity == null)
            {
                throw new ArgumentException("Invalid data");
            }

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(klientEntity);
                        transaction.Commit();
                        return klientEntity;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
