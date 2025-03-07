using CalyxAPI_v.beta.Data;
using CalyxAPI_v.beta.Models;
using CalyxAPI_v.beta.Repositories;
using CalyxAPI_v.beta.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<CalyxDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CalyxDbConn"));
});

builder.Services.AddScoped<IPersonRepository, PersonsRepository>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
