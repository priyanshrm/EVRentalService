using EVRentalBusiness.Service;
using EVRentalDAL;
using EVRentalDAL.Repositories;
using EVRentalEntity.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var pgsqlconnection = builder.Configuration.GetConnectionString("pgsqlconnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<EVRentalDbContext>(options => options.UseNpgsql(pgsqlconnection));
builder.Services.AddScoped<IElectricVehicleRepository, ElectricVehicleRepository>();
builder.Services.AddScoped<ElectricVehicleService, ElectricVehicleService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
