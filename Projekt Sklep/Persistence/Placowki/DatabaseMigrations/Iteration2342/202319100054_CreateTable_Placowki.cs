using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Placowki.DatabaseMigrations.Iteration2342
{
    [Migration(202319100054)]
    public class _202319100054_CreateTable_Placowki : Migration
    {
        
        readonly string tableName = nameof(Models.Placowki.Placowki);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Placowki.Placowki.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Placowki.Placowki.NIP)).AsString().Nullable()
                    .WithColumn(nameof(Models.Placowki.Placowki.NrPlacowki)).AsInt32().NotNullable();
                Create.ForeignKey("FK_Adres").FromTable("Placowki").ForeignColumn("Id").ToTable("Adres").PrimaryColumn("Id");
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
