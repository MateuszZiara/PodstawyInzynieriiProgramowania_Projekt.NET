using FluentNHibernate.Mapping;

namespace Projekt_Sklep.Models.RodzajePolis
{
    public class RodzajePolisMapping : ClassMap<RodzajePolis>
    {
        readonly string tablename = nameof(RodzajePolis);
        public RodzajePolisMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Rodzaj).CustomType<RodzajePolisEnum>();
            Map(x => x.DataRozpoczecia);
            Map(x => x.DataZakonczenia);
            Map(x => x.CenaPodstawowa);
            Table(tablename);
        }
    }
}
