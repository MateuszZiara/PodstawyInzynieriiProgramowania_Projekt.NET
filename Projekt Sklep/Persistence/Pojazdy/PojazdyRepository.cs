using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Pojazdy;

namespace Projekt_Sklep.Persistence.Pojazdy
{
    public class PojazdyRepository : IPojazdyRepository
    {

        public bool edit(Guid Id, int NrRejestracyjny, string Marka, string Model, int Rocznik, string VIN, bool Uszkodzony, Guid Klient)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Models.Pojazdy.Pojazdy>().Where(x => x.Id == Id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {

                        if (NrRejestracyjny != -1)
                            entity.NrRejestracyjny = NrRejestracyjny;

                        

                        if (Marka != null)
                            entity.Marka = Marka;

                        if (Model != null)
                            entity.Model = Model;

                        if (Rocznik != -1)
                            entity.Rocznik = Rocznik;

                        if (VIN != null)
                            entity.VIN = VIN;


                        if (Klient != Guid.Empty)
                            entity.Klient = Klient;

                        session.SaveOrUpdate(entity);
                        transaction.Commit();

                    }
                }
            }

            return true;
        }

    }
}
