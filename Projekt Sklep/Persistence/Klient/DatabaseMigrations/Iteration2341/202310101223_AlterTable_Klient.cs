using FluentMigrator;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Klient.DatabaseMigrations.Iteration2341
{
    [Migration(202310101223)]
    public class _202310101223_AlterTable_Klient : Migration
    {
        readonly string tableName = nameof(KlientEntity);
        public override void Up()
        {
            if (Schema.Table(tableName).Exists())
            {
                Alter.Table(tableName)
                .AddColumn(nameof(KlientEntity.NIP)).AsString().NotNullable()
                .AddColumn(nameof(KlientEntity.REGON)).AsString().NotNullable()
                .AddColumn(nameof(KlientEntity.Nazwa_firmy)).AsString().NotNullable()
                .AddColumn(nameof(KlientEntity.Pan_Pani)).AsString().NotNullable();
            }
        }
        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Column(nameof(KlientEntity.NIP)).FromTable(tableName);
                Delete.Column(nameof(KlientEntity.REGON)).FromTable(tableName);
                Delete.Column(nameof(KlientEntity.Nazwa_firmy)).FromTable(tableName);
                Delete.Column(nameof(KlientEntity.Pan_Pani)).FromTable(tableName);
            }
        }

        
    }
}
