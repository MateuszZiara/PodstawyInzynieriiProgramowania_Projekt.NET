using FluentNHibernate.Mapping;
using Projekt_Sklep.Models.RodzajePolis;

namespace Projekt_Sklep.Models.Roszczenia
{
    public class RoszczeniaMapping : ClassMap<Roszczenia>
    {
        readonly string tablename = nameof(Models.Roszczenia.Roszczenia);

        public RoszczeniaMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Opis);
            Map(x => x.StanRoszczenia).CustomType<RoszczeniaEnum>();
            Map(x => x.Ubezpieczyciele);
            Map(x => x.Klient);
            //Map(x => x.Polisa);
            Map(x => x.WyplatyiSzkody);
            Map(x => x.Zalacznik);
            Table(tablename);
        }
    }
}
