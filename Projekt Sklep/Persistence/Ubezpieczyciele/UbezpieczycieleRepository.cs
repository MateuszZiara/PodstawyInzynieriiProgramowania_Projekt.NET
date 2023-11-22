using Projekt_Sklep.Models;
using Projekt_Sklep.Models.Ubezpieczyciele;

namespace Projekt_Sklep.Persistence.Ubezpieczyciele
{
    public class UbezpieczycieleRepository : IUbezpieczycieleRepository
    {

        public bool edit(Guid Id, string Nazwisko, string Email, string Phone, string OsobaKontaktowa, string NazwaFirmy, Guid Placowki)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var query = session.Query<Models.Ubezpieczyciele.Ubezpieczyciele>().Where(x => x.Id == Id).ToList();
                    if (query.Count == 0)
                        return false;
                    foreach (var entity in query)
                    {

                        if (Nazwisko != null)
                            entity.Nazwisko = Nazwisko;


                        if (Email != null)
                            entity.Email = Email;

                        if (Phone != null)
                            entity.Phone = Phone;

                        if (OsobaKontaktowa != null)
                            entity.OsobaKontaktowa = OsobaKontaktowa;

                        if (NazwaFirmy != null)
                            entity.NazwaFirmy = NazwaFirmy;

                        if (Placowki != Guid.Empty)
                            entity.Placowki = Placowki;

                        session.SaveOrUpdate(entity);
                        transaction.Commit();

                    }
                }
            }

            return true;
        }

    }
}
