using FluentNHibernate.Mapping;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Models.Adres
{
    public class AdresMapping : ClassMap<Adres>
    {
        readonly string tablename = nameof(Adres);
        public AdresMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.KodPocztowy);
            Map(x => x.Miasto);
            Map(x => x.Wojewodztwo);
            Map(x => x.Panstwo);
            Table(tablename);
        }
    }
}
