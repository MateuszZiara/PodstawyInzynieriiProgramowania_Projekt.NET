using FluentMigrator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Adres.DatabaseMigrations.Iteration01
{
    [Migration(202310182154)]
    public class _202310182154_CreateTable_Adres : Migration
    {
        readonly string tableName = nameof(Models.Adres.Adres);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Adres.Adres.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Adres.Adres.KodPocztowy)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Adres.Adres.Miasto)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Adres.Adres.Wojewodztwo)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Adres.Adres.Panstwo)).AsString().NotNullable();
                    
            }
        }
        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Table(tableName);
            }
        }

        
    }
}
