using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Pojazdy.DatabaseMigrations.Iteration420
{
    [Migration(202319101408)]
    public class _202319101408_CreateTable_Pojazdy : Migration
    {
         readonly string tableName = nameof(Models.Pojazdy.Pojazdy);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Pojazdy.Pojazdy.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Pojazdy.Pojazdy.NrRejestracyjny)).AsString().Nullable()
                    .WithColumn(nameof(Models.Pojazdy.Pojazdy.Marka)).AsString().Nullable()
                    .WithColumn(nameof(Models.Pojazdy.Pojazdy.Model)).AsString().Nullable()
                    .WithColumn(nameof(Models.Pojazdy.Pojazdy.Rocznik)).AsString().Nullable()
                    .WithColumn(nameof(Models.Pojazdy.Pojazdy.VIN)).AsString().Nullable()
                    .WithColumn(nameof(Models.Pojazdy.Pojazdy.Uszkodzony)).AsString().Nullable()
                    .WithColumn("Klient").AsGuid().NotNullable();
                    //.WithColumn("Polisa").AsGuid().NotNullable();

               // Create.ForeignKey("FK_Polisa").FromTable("Pojazdy").ForeignColumn("Polisa").ToTable("Polisa").PrimaryColumn("Id");
                Create.ForeignKey("FK_Kilent").FromTable("Pojazdy").ForeignColumn("Klient").ToTable("KlientEntity").PrimaryColumn("Id");
            }
        }

        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                // Usuń ograniczenie klucza obcego
                //Delete.ForeignKey("FK_Polisa").OnTable(tableName);
                Delete.ForeignKey("FK_Klient").OnTable(tableName);
                // Usuń klucz główny
                Delete.PrimaryKey("PK_Pojazdy").FromTable(tableName);
                // Usuń tabelę
                Delete.Table(tableName);
            }
        }
    }
}
