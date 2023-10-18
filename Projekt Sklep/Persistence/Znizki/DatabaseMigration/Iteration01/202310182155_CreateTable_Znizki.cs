using FluentMigrator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Projekt_Sklep.Models.Znizki;

namespace Projekt_Sklep.Persistence.Znizki.DatabaseMigration.Iteration01
{
    [Migration(202310182155)]
    public class _202310182155_CreateTable_Znizki : Migration
    {
        readonly string tableName = nameof(Models.Znizki.Znizki);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Znizki.Znizki.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Znizki.Znizki.Dorosly_dziecko)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Znizki.Znizki.Wiek)).AsString().NotNullable();
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
