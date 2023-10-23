using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Polisy.DatabaseMigrations.Iteration2345
{
    [Migration(202318100005)]
    public class _202321100005_CreateTable_Polisy : Migration
    {
        readonly string tableName = nameof(Models.Polisy.Polisy);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Polisy.Polisy.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Polisy.Polisy.DataRozpoczecia)).AsDateTime().NotNullable()
                    .WithColumn(nameof(Models.Polisy.Polisy.DataZakonczenia)).AsDateTime().NotNullable()
                    .WithColumn(nameof(Models.Polisy.Polisy.Cena)).AsDouble().NotNullable()
                    .WithColumn("Klient").AsGuid().NotNullable()
                    .WithColumn("RodzajePolis").AsGuid().NotNullable()
                    .WithColumn("Ubezpieczyciele").AsGuid().NotNullable()
                    .WithColumn("Znizki").AsGuid().NotNullable();

                Create.ForeignKey("FK_Klient5").FromTable(tableName).ForeignColumn("Klient").ToTable("KlientEntity").PrimaryColumn("Id");
                Create.ForeignKey("FK_RodzajePolis5").FromTable(tableName).ForeignColumn("RodzajePolis").ToTable("RodzajePolis").PrimaryColumn("Id");
                Create.ForeignKey("FK_Ubezpieczyciele335").FromTable(tableName).ForeignColumn("Ubezpieczyciele").ToTable("Ubezpieczyciele").PrimaryColumn("Id");
                Create.ForeignKey("FK_Znizki5").FromTable(tableName).ForeignColumn("Znizki").ToTable("Znizki").PrimaryColumn("Id");

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
