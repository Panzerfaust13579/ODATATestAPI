using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using ODATATestAPI.Data;
using ODATATestAPI.Models;

var builder = WebApplication.CreateSlimBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EnumType<CustomerType>();
modelBuilder.EntitySet<Client>("Clients");

builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents("odata", modelBuilder.GetEdmModel());
    options.EnableQueryFeatures(null);
});

builder.Services.AddDbContext<DataContext>(options =>
options.UseInMemoryDatabase("ODataTestDB"));

var app = builder.Build();
app.MapControllers();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var db = serviceScope.ServiceProvider.GetRequiredService<DataContext>();

    Seeder.SeedData(db);
}

if (app.Environment.IsDevelopment())
{
}

app.Run();

