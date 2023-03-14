using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Se intenta agregar la conexión a base de datos SQL desde el achivo appsettings.json pero no la toma,
//por lo cual se deja la cadena de conexión en el método directamente OnConfiguring de la clase
//ApiRestDbManuelRojasContext generada con el EntityFrameworkCore para el DbContext

//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//    .Build();

//var conexionString = configuration.GetConnectionString("ApiDB");

//builder.Services.AddDbContext<ApiRestDbManuelRojasContext>(options =>
//    options.UseSqlServer(conexionString));

//Se agregan la referencias del Patron Repository pero se omite ya que genera error con la capa de Data
//builder.Services.AddScoped<IAccountRepository, AccountRepositoryService>();
//builder.Services.AddScoped<IClientRepository, ClientRepositoryService>();
//builder.Services.AddScoped<IMovementRepository, MovementRepositoryService>();
//builder.Services.AddScoped<IPersonRepository, PersonRepositoryService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();