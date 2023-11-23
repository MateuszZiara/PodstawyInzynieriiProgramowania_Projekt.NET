using Projekt_Sklep.Models;
using Projekt_Sklep.Models.RodzajePolis;

namespace Projekt_Sklep.Persistence.RodzajePolis
{
    public class RodzajePolisRepository
    {
        public bool edit(Guid Id, RodzajePolisEnum Rodzaj, DateTime DataRozpoczecia, DateTime DataZakonczenia, int CenaPodstawowa)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Models.RodzajePolis.RodzajePolis>().Where(x => x.Id == Id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {

                        
                        if (CenaPodstawowa != -1)
                            entity.CenaPodstawowa = CenaPodstawowa;

                        session.SaveOrUpdate(entity);
                        transaction.Commit();

                    }
                }
            }

            return true;
        }

    }
}
