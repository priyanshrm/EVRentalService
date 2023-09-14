using EVRentalBusiness.Service;
using EVRentalDAL;
using EVRentalDAL.Repositories;
using EVRentalEntity.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<BookingService, BookingService>();

//builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder => {
            builder.AllowAnyOrigin()
            .AllowAnyHeader().AllowAnyMethod();
        });
});

string myKey = "22434D93E000260FE3D5694E95A53027554751F74C1CCB0007D778E0530C30E23F1B3168F7B5BE2490EA73A2407D5FD4CEA5CD73F5FE913EB6FB2FE6A4599489";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(myKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(options =>
//{
//    options.AllowAnyHeader()
//           .AllowAnyMethod()
//           .WithOrigins("http://localhost:3000");
//});

app.UseCors("AllowAnyOriginPolicy");


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
