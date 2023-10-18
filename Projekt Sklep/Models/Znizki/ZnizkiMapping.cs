using FluentNHibernate.Mapping;

namespace Projekt_Sklep.Models.Znizki
{
    public class ZnizkiMapping : ClassMap<Znizki>
    {
        readonly string tablename = nameof(Models.Znizki.Znizki);

        public ZnizkiMapping() 
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Dorosly_dziecko);
            Map(x => x.Wiek);
            Table(tablename);
        }
    }
}
