using FluentMigrator;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Klient.DatabaseMigrations.Iteration2340
{
    [Migration(202305101223)]
    public class _202305101223_CreateTable_Klient : Migration
    {
        readonly string tableName = nameof(KlientEntity);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(KlientEntity.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(KlientEntity.Imie)).AsString().NotNullable()
                    .WithColumn(nameof(KlientEntity.Nazwisko)).AsString().NotNullable();
                   
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
