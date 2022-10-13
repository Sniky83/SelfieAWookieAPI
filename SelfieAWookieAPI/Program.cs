using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using SelfieAWookie.Core.Selfies.Infrastructures.Loggers;
using SelfieAWookie.Core.Selfies.Infrastructures.Repositories;
using SelfieAWookieAPI.ExtensionMethods;
using SelfieAWookieAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomOptions(builder.Configuration);
builder.Services.AddInjections();
builder.Services.AddCustomSecurity(builder.Configuration);

builder.Logging.AddProvider(new CustomLoggerProvider());

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<SelfiesContext>();

builder.Services.AddDbContext<SelfiesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDatabase"), sqlOptions => {});
});

//Injection de dépendance
//S'il repère un param avec le type "interface" il injecte la "classe" virtuellement.
//builder.Services.AddTransient<ISelfieRepository, DefaultSelfieRepository>();

//builder.Services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();

//Instancie la classe au démarrage puis la garde en mémoire pour la réutiliser
//Pas forcément bien
//builder.Services.AddSingleton(typeof(DefaultSelfieRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LogRequestMiddleware>();

app.UseHttpsRedirection();

//On blinde toute l'API sur cette POLICY
app.UseCors(SecurityMethods.DEFAULT_POLICY);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
