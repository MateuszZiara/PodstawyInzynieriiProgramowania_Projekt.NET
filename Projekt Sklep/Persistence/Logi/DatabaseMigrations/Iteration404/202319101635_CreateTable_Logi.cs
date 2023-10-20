using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Logi.DatabaseMigrations.Iteration404
{
    [Migration(202319101635)]
    public class _202319101635_CreateTable_ : Migration
    {
        readonly string tableName = nameof(Models.Logi.Logi);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Logi.Logi.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Logi.Logi.DataZdarzenia)).AsString().Nullable()
                    .WithColumn(nameof(Models.Logi.Logi.OpisZdarzenia)).AsString().Nullable()
                    .WithColumn("Klient").AsGuid().NotNullable()
                    .WithColumn("WyplatyiSzkody").AsGuid().NotNullable()
                    .WithColumn("Ubezpieczyciele").AsGuid().NotNullable()
                    .WithColumn("Polisa").AsGuid().NotNullable();

                Create.ForeignKey("FK_Polisa2").FromTable("Logi").ForeignColumn("Polisa").ToTable("Polisa").PrimaryColumn("Id");
                Create.ForeignKey("FK_Kilent4").FromTable("Logi").ForeignColumn("Klient").ToTable("KlientEntity").PrimaryColumn("Id");
                Create.ForeignKey("FK_WyplatyiSzkody").FromTable("Logi").ForeignColumn("WyplatyiSzkody").ToTable("WyplatyiSzkody").PrimaryColumn("Id");
                Create.ForeignKey("FK_Ubezpieczyciele").FromTable("Logi").ForeignColumn("Ubezpieczyciele").ToTable("Ubezpieczyciele").PrimaryColumn("Id");
            }
        }

        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                // Usuń ograniczenie klucza obcego
                //Delete.ForeignKey("FK_Polisa").OnTable(tableName);
                Delete.ForeignKey("FK_Klient4").OnTable(tableName);
                Delete.ForeignKey("FK_WyplatyiSzkody").OnTable(tableName);
                Delete.ForeignKey("FK_Ubezpieczyciele").OnTable(tableName);
                // Usuń klucz główny
                Delete.PrimaryKey("PK_Logi").FromTable(tableName);
                // Usuń tabelę
                Delete.Table(tableName);
            }
        }
    }
}
