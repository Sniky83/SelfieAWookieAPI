using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using SelfieAWookie.Core.Selfies.Infrastructures.Repositories;
using SelfieAWookieAPI.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomSecurity(builder.Configuration);

builder.Services.AddDbContext<SelfiesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDatabase"), sqlOptions => {});
});

//Injection de d�pendance
//S'il rep�re un param avec le type "interface" il injecte la "classe" virtuellement.
//builder.Services.AddTransient<ISelfieRepository, DefaultSelfieRepository>();

//builder.Services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();

//Instancie la classe au d�marrage puis la garde en m�moire pour la r�utiliser
//Pas forc�ment bien
//builder.Services.AddSingleton(typeof(DefaultSelfieRepository));

builder.Services.AddInjections();

var app = builder.Build();

//On blinde toute l'API sur cette POLICY
app.UseCors(SecurityMethods.DEFAULT_POLICY);

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
