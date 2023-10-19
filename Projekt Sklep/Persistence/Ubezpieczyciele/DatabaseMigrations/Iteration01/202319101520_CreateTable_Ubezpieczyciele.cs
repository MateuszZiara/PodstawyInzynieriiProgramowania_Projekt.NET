using FluentMigrator;
using Projekt_Sklep.Models.Ubezpieczyciele;

namespace Projekt_Sklep.Persistence.Ubezpieczyciele.DatabaseMigrations.Iteration01
{
    [Migration(202319101520)]
    public class _202319101520_CreateTable_Ubezpieczyciele : Migration
    {
        readonly string tableName = nameof(Models.Ubezpieczyciele.Ubezpieczyciele);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Ubezpieczyciele.Ubezpieczyciele.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Ubezpieczyciele.Ubezpieczyciele.Nazwisko)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Ubezpieczyciele.Ubezpieczyciele.Phone)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Ubezpieczyciele.Ubezpieczyciele.OsobaKontaktowa)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Ubezpieczyciele.Ubezpieczyciele.NazwaFirmy)).AsString().NotNullable()
                    .WithColumn("Placowki").AsGuid().NotNullable();
                Create.ForeignKey("FK_Placowki").FromTable("Ubezpieczyciele").ForeignColumn("Placowki").ToTable("Placowki").PrimaryColumn("Id");
            }           
        }
        public override void Down()
        {
            throw new NotImplementedException();
        }

       
    }
}
