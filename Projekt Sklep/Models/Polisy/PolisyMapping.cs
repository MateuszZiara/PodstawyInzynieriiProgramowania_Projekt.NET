using FluentNHibernate.Mapping;
using Projekt_Sklep.Models.Klient;
using Projekt_Sklep.Models.Ubezpieczyciele;

namespace Projekt_Sklep.Models.Polisy
{
    public class PolisyMapping : ClassMap<Polisy>
    {
        readonly string tablename = nameof(Polisy);
        public PolisyMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.DataRozpoczecia);
            Map(x => x.DataZakonczenia);
            Map(x => x.Cena);
            Map(x => x.Klient);
            Map(x => x.RodzajePolis);
            Map(x => x.Ubezpieczyciele);
            Map(x => x.Znizki);

            Table(tablename);
        }
    }
}
