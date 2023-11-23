using Projekt_Sklep.Models;
using Projekt_Sklep.Models.WyplatyiSzkody;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Sklep.Persistence.WyplatyiSzkody
{
    public class WyplatyiSzkodyRepository : IWyplatyiSzkodyRepository
    {

        public bool edit(Guid Id, DateTime DataZgloszenia, int WartoscSzkody, string TypSzkody,bool StatusWyplaty, Guid Klient)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Models.WyplatyiSzkody.WyplatyiSzkody>().Where(x => x.Id == Id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {

                        if (DataZgloszenia != null)
                            entity.DataZgloszenia = DataZgloszenia;



                        if (WartoscSzkody != -1)
                            entity.WartoscSzkody = WartoscSzkody;

                        if (TypSzkody != null)
                            entity.TypSzkody = TypSzkody;


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
