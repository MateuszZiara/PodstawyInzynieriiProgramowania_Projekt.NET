using FluentNHibernate.Mapping;
using Projekt_Sklep.Models.RodzajePolis;

namespace Projekt_Sklep.Models.Wiadomosci
{
    public class WiadomosciMapping : ClassMap<Wiadomosci>
    {
        readonly string tablename = nameof(RodzajePolis);
        public WiadomosciMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Odczytane);
            Map(x => x.DataWyslania);
            Map(x => x.Wiadomosc);
            Map(x => x.Nadawca).CustomType<WiadomosciEnum>();
            Map(x => x.Odbiorca).CustomType<WiadomosciEnum>();
            Map(x => x.Klient);
            Map(x => x.Ubezpieczyciele);
            Table(tablename);
        }
    }
}
