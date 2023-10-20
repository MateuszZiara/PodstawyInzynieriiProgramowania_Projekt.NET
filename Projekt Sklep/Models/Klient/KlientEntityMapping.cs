using FluentNHibernate.Mapping;

namespace Projekt_Sklep.Models.Klient
{
    public class KlientEntityMapping : ClassMap<KlientEntity>
    {
        readonly string tablename = nameof(KlientEntity);
        public KlientEntityMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.LastName);
            Map(x => x.Pesel);
            Map(x => x.NumerTelefonu);
            Map(x => x.Email);
            Map(x => x.NIP);
            Map(x => x.Adres);
       
            Table(tablename);
        }
    }
}

