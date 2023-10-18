using FluentNHibernate.Mapping;

namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntityMapping : ClassMap<KlientEntity>
    {
        readonly string tablename = nameof(KlientEntity);
        public KlientEntityMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Imie);
            Map(x => x.Nazwisko);
            Map(x => x.NIP);
            Map(x => x.REGON);
            Map(x => x.Nazwa_firmy);
            Map(x => x.Pan_Pani);
            Table(tablename);
        }
    }
}
