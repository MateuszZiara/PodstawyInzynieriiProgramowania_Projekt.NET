using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.WyplatyiSzkody.DatabaseMigrations.Iteration666
{
    [Migration(202319101533)]
    public class _202319101533_CreateTable_WyplatyiSzkody : Migration
    {
        readonly string tableName = nameof(Models.WyplatyiSzkody.WyplatyiSzkody);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.WyplatyiSzkody.WyplatyiSzkody.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.WyplatyiSzkody.WyplatyiSzkody.DataZgloszenia)).AsString().Nullable()
                    .WithColumn(nameof(Models.WyplatyiSzkody.WyplatyiSzkody.WartoscSzkody)).AsString().Nullable()
                    .WithColumn(nameof(Models.WyplatyiSzkody.WyplatyiSzkody.TypSzkody)).AsString().Nullable()
                    .WithColumn(nameof(Models.WyplatyiSzkody.WyplatyiSzkody.StatusWyplaty)).AsString().Nullable()
                    .WithColumn("Klient").AsGuid().NotNullable();
                //.WithColumn("Polisa").AsGuid().NotNullable();

                // Create.ForeignKey("FK_Polisa").FromTable("Pojazdy").ForeignColumn("Polisa").ToTable("Polisa").PrimaryColumn("Id");
                Create.ForeignKey("FK_Kilent2").FromTable("WyplatyiSzkody").ForeignColumn("Klient").ToTable("KlientEntity").PrimaryColumn("Id");
            }
        }

        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                // Usuń ograniczenie klucza obcego
                //Delete.ForeignKey("FK_Polisa").OnTable(tableName);
                Delete.ForeignKey("FK_Klient2").OnTable(tableName);
                // Usuń klucz główny
                Delete.PrimaryKey("PK_WyplatyiSzkody").FromTable(tableName);
                // Usuń tabelę
                Delete.Table(tableName);
            }
        }
    }
}
