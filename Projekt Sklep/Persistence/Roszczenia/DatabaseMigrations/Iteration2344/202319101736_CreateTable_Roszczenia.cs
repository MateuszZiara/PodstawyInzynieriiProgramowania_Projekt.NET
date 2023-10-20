using FluentMigrator;

namespace Projekt_Sklep.Persistence.Roszczenia.DatabaseMigrations.Iteration2344
{
    [Migration(202319101736)]
    public class _202319101736_CreateTable_Roszczenia : Migration
    {
        readonly string tableName = nameof(Models.Roszczenia.Roszczenia);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Roszczenia.Roszczenia.Id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Roszczenia.Roszczenia.Opis)).AsString().Nullable()
                    .WithColumn(nameof(Models.Roszczenia.Roszczenia.StanRoszczenia)).AsInt32().Nullable()
                    .WithColumn(nameof(Models.Roszczenia.Roszczenia.Zalacznik)).AsBinary().Nullable()
                    .WithColumn("Ubezpieczyciele").AsGuid().NotNullable()
                    .WithColumn("Klient").AsGuid().NotNullable()
                    //.WithColumn("Polisa").AsGuid().NotNullable()
                    .WithColumn("WyplatyiSzkody").AsGuid().NotNullable();
                Create.ForeignKey("FK_Ubezpieczyciele2").FromTable("Roszczenia").ForeignColumn("Ubezpieczyciele").ToTable("Ubezpieczyciele").PrimaryColumn("Id");
                Create.ForeignKey("FK_Klient4").FromTable("Roszczenia").ForeignColumn("Klient").ToTable("KlientEntity").PrimaryColumn("Id");
                //Create.ForeignKey("FK_Polisa").FromTable("Roszczenia").ForeignColumn("Polisa").ToTable("Polisa").PrimaryColumn("Id");
                Create.ForeignKey("FK_WyplatyiSzkody2").FromTable("Roszczenia").ForeignColumn("WyplatyiSzkody").ToTable("WyplatyiSzkody").PrimaryColumn("Id");
            }
        }

        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                // Usuń ograniczenie klucza obcego
                Delete.ForeignKey("FK_Ubezpieczyciele").OnTable(tableName);
                Delete.ForeignKey("FK_Klient").OnTable(tableName);
                Delete.ForeignKey("FK_WyplatyiSzkody").OnTable(tableName);
                // Usuń klucz główny
                Delete.PrimaryKey("PK_Roszczenia").FromTable(tableName);
                // Usuń tabelę
                Delete.Table(tableName);
            }
        }
    }
}
