using NHibernate.Linq;

namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntityRepository : IKlientEntityRepository
    {
        public bool edit(Guid id, Guid AdresID, string name, string lastname, string pesel, string numertelefonu, string email, string nip)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<KlientEntity>().Where(x => x.Id == id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {
                    
                        if (name != null)
                            entity.Name = name;

                        if (lastname != null)
                            entity.LastName = lastname;

                        if (pesel != null)
                            entity.Pesel = pesel;

                        if (numertelefonu != null)
                            entity.NumerTelefonu = numertelefonu;

                        if (email != null)
                            entity.Email = email;

                        if (nip != null)
                            entity.NIP = nip;

                        if (AdresID != Guid.Empty)
                            entity.Adres = AdresID;

                        session.SaveOrUpdate(entity);
                        transaction.Commit();

                    }
                }
            }
            
            return true;
        }

        public (List<Polisy.Polisy>, List<Pojazdy.Pojazdy>) getByPolisaPojazd(Guid Id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Polisy.Polisy>().Where(x => x.Klient == Id).ToList();
                    var query2 = session.Query<Pojazdy.Pojazdy>().Where(x => x.Klient == Id).ToList();
                    return (query, query2);
                }
            }
                
        }
    }
}

