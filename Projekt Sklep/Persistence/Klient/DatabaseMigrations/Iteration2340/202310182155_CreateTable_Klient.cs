using FluentMigrator;
using Projekt_Sklep.Models.Adres;
using Projekt_Sklep.Models.Klient;

namespace Projekt_Sklep.Persistence.Klient.DatabaseMigrations.Iteration2340
{
    [Migration(202310182156)]
    public class _202310182156_CreateTable_Klient : Migration
    {
        readonly string tableName = nameof(KlientEntity);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(KlientEntity.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(KlientEntity.Name)).AsString().NotNullable()
                    .WithColumn(nameof(KlientEntity.LastName)).AsString().NotNullable()
                    .WithColumn(nameof(KlientEntity.Pesel)).AsString().NotNullable()
                    .WithColumn(nameof(KlientEntity.NumerTelefonu)).AsString().NotNullable()
                    .WithColumn(nameof(KlientEntity.Email)).AsString().NotNullable()
                    .WithColumn(nameof(KlientEntity.NIP)).AsString().NotNullable()
                    .WithColumn("Adres").AsGuid().NotNullable();
                   // .WithColumn("PolisaID").AsGuid().NotNullable();
                Create.ForeignKey("FK_Adres3").FromTable(tableName).ForeignColumn("Adres").ToTable("Adres").PrimaryColumn("Id");
               // Create.ForeignKey("FK_Polisa2").FromTable("KlientEntity").ForeignColumn("PolisaID").ToTable("Polisa").PrimaryColumn("Id");
                // Moze byc walidacja z FK_Adres/FK_Polisa. Nadac numerki relacjom jak cos
               
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
