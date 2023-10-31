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

        public (List<Models.Ubezpieczyciele.Ubezpieczyciele>, List<Models.Polisy.Polisy>, List<Models.Pojazdy.Pojazdy>, List<Models.Klient.KlientEntity>) getByAgenciPolisyPojazdyOsoby(Guid Id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var ubezpieczycieleQuery = session.Query<Models.Ubezpieczyciele.Ubezpieczyciele>().Where(x => x.Placowki == Id).ToList();
                    List<Models.Polisy.Polisy> listaPolis = new List<Models.Polisy.Polisy>();
                    var polisyQuery = session.Query<Models.Polisy.Polisy>();
                    foreach (var model in ubezpieczycieleQuery)
                    {
                        var filtr = polisyQuery.Where(x => x.Ubezpieczyciele == model.Id)
                           .ToList();
                        listaPolis.AddRange(filtr);
                    }
                   
                    List<Models.Klient.KlientEntity> klientList = new List<Models.Klient.KlientEntity>();
                    var klientQuery = session.Query<Models.Klient.KlientEntity>();
                    foreach(var model in listaPolis)
                    {
                        var filtr = klientQuery.Where(x => x.Id == model.Klient).ToList();
                        klientList.AddRange(filtr);
                    }
                    List<Models.Pojazdy.Pojazdy> pojazdyList = new List<Models.Pojazdy.Pojazdy>();
                    var pojazdyQuery = session.Query<Models.Pojazdy.Pojazdy>();
                    foreach(var model in klientList)
                    {
                        var filtr = pojazdyQuery.Where(x => x.Klient == model.Id);
                        
                        pojazdyList.AddRange(filtr);
                    }

                    
                   // var query2 = session.Query<Models.Polisy.Polisy>().Where(x => x.Klient == Id).ToList();
       
                    //var query3 = session.Query<Models.Pojazdy.Pojazdy>().Where(x => x.Klient == Id).ToList();
                   // var query4 = session.Query<Models.Klient.KlientEntity>().Where(x => x.Id == Id).ToList();
                    
                    return (ubezpieczycieleQuery, listaPolis.Distinct().ToList(), pojazdyList.Distinct().ToList(), klientList.Distinct().ToList());
                }
            }

        }

    }
}
