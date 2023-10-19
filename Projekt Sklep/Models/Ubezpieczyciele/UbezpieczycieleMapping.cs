using FluentNHibernate.Mapping;
using Projekt_Sklep.Models.RodzajePolis;

namespace Projekt_Sklep.Models.Ubezpieczyciele
{
    public class UbezpieczycieleMapping : ClassMap<Ubezpieczyciele>
    {
        readonly string tablename = nameof(Ubezpieczyciele);
        public UbezpieczycieleMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Nazwisko);
            Map(x => x.Email);
            Map(x => x.Phone);
            Map(x => x.OsobaKontaktowa);
            Map(x => x.NazwaFirmy);
            Map(x => x.Placowki);
            Table(tablename);
        }
    }
}
