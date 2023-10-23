using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Placowki;
using NHibernate.Linq;


namespace Projekt_Sklep.Persistence.Placowki
{
    public class PlacowkiRepository : IPlacowkiRepository
    {
        public bool edit(Guid Id, int NrPlacowki, string NIP, Guid Adres)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Models.Placowki.Placowki>().Where(x => x.Id == Id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {

                        if (NrPlacowki != -1)
                            entity.NrPlacowki = NrPlacowki;


                        if (NIP != null)
                            entity.NIP = NIP;

                        if (Adres != Guid.Empty)
                            entity.Adres = Adres;

                        session.SaveOrUpdate(entity);
                        transaction.Commit();

                    }
                }
            }

            return true;
        }

    }
}
