using Microsoft.AspNetCore.Http.HttpResults;
using FluentMigrator;

namespace Projekt_Sklep.Persistence.Wiadomosci.DatabaseMigrations.Iteration2347
{
    [Migration(202325100332)]
    public class _202325100332_CreateTable_Wiadomosci : Migration
    {
        readonly string tableName = nameof(Models.Wiadomosci.Wiadomosci);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Wiadomosci.Wiadomosci.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Wiadomosci.Wiadomosci.Odczytane)).AsBoolean().NotNullable()
                    .WithColumn(nameof(Models.Wiadomosci.Wiadomosci.DataWyslania)).AsDateTime().NotNullable()
                    .WithColumn(nameof(Models.Wiadomosci.Wiadomosci.Wiadomosc)).AsString().Nullable()
                    .WithColumn(nameof(Models.Wiadomosci.Wiadomosci.Nadawca)).AsInt32().NotNullable()
                    .WithColumn(nameof(Models.Wiadomosci.Wiadomosci.Odbiorca)).AsInt32().NotNullable()
                    .WithColumn("Klient").AsGuid().NotNullable()
                    .WithColumn("Ubezpieczyciele").AsGuid().NotNullable()
                    .WithColumn(nameof(Models.Wiadomosci.Wiadomosci.ParentMessage)).AsString().Nullable();

                Create.ForeignKey("FK_Ubezpieczyciele35").FromTable("Wiadomosci").ForeignColumn("Ubezpieczyciele").ToTable("Ubezpieczyciele").PrimaryColumn("Id");
                Create.ForeignKey("FK_Kilent209").FromTable("Wiadomosci").ForeignColumn("Klient").ToTable("KlientEntity").PrimaryColumn("Id");
            }
        }

        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                // Usuń ograniczenie klucza obcego
                Delete.ForeignKey("FK_Klient209").OnTable(tableName);
                Delete.ForeignKey("FK_Ubezpieczyciele305").OnTable(tableName);
                // Usuń tabelę
                Delete.Table(tableName);
            }
        }
    }
}
