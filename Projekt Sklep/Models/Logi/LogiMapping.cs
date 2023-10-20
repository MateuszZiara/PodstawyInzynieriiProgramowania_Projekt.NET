using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Projekt_Sklep.Models.Logi
{
    public class LogiMapping : ClassMap<Logi>
    {

        readonly string tablename = nameof(Models.Logi.Logi);

        public LogiMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.DataZdarzenia);
            Map(x => x.OpisZdarzenia);
            Map(x => x.Klient);
            Map(x => x.Polisa);
            Map(x => x.WyplataiSzkoda);
            Map(x => x.Ubezpieczyciele);
            Table(tablename);
        }
    }
}
