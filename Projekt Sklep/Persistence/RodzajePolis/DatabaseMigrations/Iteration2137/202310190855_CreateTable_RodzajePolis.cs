using FluentMigrator;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.RodzajePolis.DatabaseMigrations.Iteration2137
{
    [Migration(202310190855)]
    public class _202310190855_CreateTable_RodzajePolis : Migration
    {
        readonly string tableName = nameof(Models.RodzajePolis.RodzajePolis);

        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.RodzajePolis.RodzajePolis.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.RodzajePolis.RodzajePolis.Rodzaj)).AsInt32().NotNullable()
                    .WithColumn(nameof(Models.RodzajePolis.RodzajePolis.DataRozpoczecia)).AsDate().NotNullable()
                    .WithColumn(nameof(Models.RodzajePolis.RodzajePolis.DataZakonczenia)).AsDate().NotNullable()
                    .WithColumn(nameof(Models.RodzajePolis.RodzajePolis.CenaPodstawowa)).AsInt32().NotNullable();
            }
        }
        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Table(tableName);
            };
        }

        
    }
}
