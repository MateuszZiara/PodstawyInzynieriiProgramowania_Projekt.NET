using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Polisy;
using NHibernate.Linq;

namespace Projekt_Sklep.Persistence.Polisy
{
    public class PolisyRepository : IPolisyRepository
    {
        public bool czyAktywna(Guid Id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var item = session.Query<Models.Polisy.Polisy>().FirstOrDefault(x => x.Id == Id);
                    if (item.DataZakonczenia < DateTime.Now)              
                        return false;
                    else
                        return true;
                }
            }
        }

        
    }
}
