using FluentNHibernate.Mapping;

namespace Projekt_Sklep.Models.Placowki
{
    public class PlacowkiMapping: ClassMap<Placowki>
    {

            readonly string tablename = nameof(Models.Placowki.Placowki);

            public PlacowkiMapping()
            {
                Id(x => x.Id).GeneratedBy.Guid();
                Map(x => x.NrPlacowki);
                Map(x => x.NIP);
                Map(x => x.Adres);
                Table(tablename);
            }
    }
}
