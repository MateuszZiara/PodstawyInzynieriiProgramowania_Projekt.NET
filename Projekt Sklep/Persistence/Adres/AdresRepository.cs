using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;
using System.ComponentModel.DataAnnotations;
using static NHibernate.Engine.Query.CallableParser;

namespace Projekt_Sklep.Persistence.Adres
{
    public class AdresRepository : IAdresRepository
    {
        public bool edit(Guid id, string kodPocztowy, string miasto, string wojewodztwo, string panstwo)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Models.Adres.Adres>().Where(x => x.Id == id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {

                        if (kodPocztowy != null)
                            entity.KodPocztowy = kodPocztowy;

                        if (miasto != null)
                            entity.Miasto = miasto;

                        if (wojewodztwo != null)
                            entity.Wojewodztwo = wojewodztwo;

                        if (panstwo != null)
                            entity.Panstwo = panstwo;

                       
                         

                        session.SaveOrUpdate(entity);
                        transaction.Commit();

                    }
                }
            }

            return true;
        }
    }
}
