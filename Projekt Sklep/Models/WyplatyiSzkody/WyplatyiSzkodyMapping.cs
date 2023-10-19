using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Projekt_Sklep.Models.WyplatyiSzkody
{
    public class WyplatyiSzkodyMapping : ClassMap<WyplatyiSzkody>
    {

        readonly string tablename = nameof(Models.WyplatyiSzkody.WyplatyiSzkody);

        public WyplatyiSzkodyMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.DataZgloszenia);
            Map(x => x.WartoscSzkody);
            Map(x => x.TypSzkody);
            Map(x => x.StatusWyplaty)
            .CustomType<YesNoType>();
            // Map(x => x.Polisa);
            Map(x => x.Klient);
            Table(tablename);
        }
    }
}
