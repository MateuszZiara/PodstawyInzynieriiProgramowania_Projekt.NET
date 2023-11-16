using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Projekt_Sklep.Controllers.Adres;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddScoped<AdresController>();
// Configure FluentMigrator within ConfigureServices
builder.Services.AddFluentMigratorCore()
               .ConfigureRunner(c =>
               {
                   c.AddSqlServer2016()
                    .WithGlobalConnectionString("Server=localhost\\SQLEXPRESS;Database=Test;Integrated Security=SSPI;Application Name=Projekt Sklep; TrustServerCertificate=true;")
                    .ScanIn(Assembly.GetExecutingAssembly()).For.All();
               })
               .AddLogging(config => config.AddFluentMigratorConsole());

var app = builder.Build();
using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
migrator.ListMigrations();
migrator.MigrateUp();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
     app.UseSwaggerUI();
   app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
   endpoints.MapRazorPages();
});
app.Run();


