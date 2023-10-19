using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Projekt_Sklep.Models.Pojazdy
{
    public class PojazdyMapping : ClassMap<Pojazdy>
    {

        readonly string tablename = nameof(Models.Pojazdy.Pojazdy);

        public PojazdyMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.NrRejestracyjny);
            Map(x => x.Marka);
            Map(x => x.Model);
            Map(x => x.Rocznik);
            Map(x => x.VIN);
            Map(x => x.Uszkodzony)
            .CustomType<YesNoType>();
            // Map(x => x.Polisa);
            Map(x => x.Klient);
            Table(tablename);
        }
    }
}
