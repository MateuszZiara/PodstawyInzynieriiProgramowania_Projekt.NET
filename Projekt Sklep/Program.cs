using FluentAssertions.Common;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Persistence.Pojazdy;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddScoped<PojazdyService>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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
//trzeba to dodaæ ¿eby móc wykorzystaæ funkcje 

migrator.ListMigrations();
migrator.MigrateUp();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
     app.UseSwaggerUI();
   app.UseDeveloperExceptionPage();
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
   endpoints.MapRazorPages();
});
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");




app.Run();


