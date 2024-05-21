using  rsAPIElevador.DataSchema;
using  rsAPIElevador.Repositories;
using  rsAPIElevador.Services;
using  rsAPIElevador.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;
using API.Repositories;
using FluentAssertions.Common;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using rsAPIElevador;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
IdentityModelEventSource.ShowPII = true;


/*
builder.WebHost.UseKestrel(opt =>
{
   opt.ListenAnyIP(5000);
   opt.ListenAnyIP(5001, listOpt =>
    {
        listOpt.UseHttps(builder.Configuration["CertPath"], builder.Configuration["CertPassword"]);
    });
});
*/
/*
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
*/



//builder.Services.AddControllers();
/*
builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 1;  // Configurar la profundidad máxima
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            });
*/
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//builder.Services.AddControllers();
//builder.Services.AddControllers();

//builder.Services.AddControllersWithViews(o => o.SslPort = 5001);
/*
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.DefaultIgnoreCondition =
    JsonIgnoreCondition.WhenWritingNull;
}); */
/*
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.Authority = builder.Configuration.GetValue<string>("REACT_APP_AUTH_SERVER_URL");
            options.Audience = "posts-api";
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false
            };
        });
*/
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("Ldap:Dominio"),
                    ValidAudience = builder.Configuration.GetValue<string>("Ldap:Dominio"),
                    IssuerSigningKey = new SymmetricSecurityKey(
                   //Encoding.UTF8.GetBytes("_configuration[\"Llave_super_secreta\"]")),
                   Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Ldap:Key"))),//definida por nosotros patron al azar
                    ClockSkew = TimeSpan.Zero
                });
// adds an authorization policy to make sure the token is for scope 'api1'
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        //policy.RequireClaim("scope", "posts-api");
    });
});

builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")).EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
builder.Services.AddHealthChecks();


//Services

builder.Services.AddScoped(typeof(ICRUDService<>), typeof(BaseCRUDService<>));
builder.Services.AddScoped<IEV_MaquinaService, EV_MaquinaService>();
builder.Services.AddScoped<IEV_ConservadoraService, EV_ConservadoraService>();
builder.Services.AddScoped<IEV_RespTecnicoService, EV_RespTecnicoService>();
builder.Services.AddScoped<IEV_ObraService, EV_ObraService>();

//Repositories

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IRepository<EV_Conservadora>, EV_ConservadoraRepository>();
builder.Services.AddScoped<IRepository<EV_Obra>, EV_ObraRepository>();
builder.Services.AddScoped<IRepository<EV_Maquina>, EV_MaquinaRepository>();
builder.Services.AddScoped<IRepository<EV_RepTecnico>, EV_RespTenicoRepository>();
builder.Services.AddScoped<IEV_ConservadoraRepository, EV_ConservadoraRepository>();
builder.Services.AddScoped<IEV_MaquinaRepository, EV_MaquinaRepository>();
builder.Services.AddScoped<IEV_RespTecnicoRepository, EV_RespTenicoRepository>();
builder.Services.AddScoped<IEV_ObraRepository, EV_ObraRepository>();

//builder.Services.AddScoped<IRepository<EV_Maquina>, EV_MaquinaRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .SetIsOriginAllowed(origin => true)
        .AllowAnyHeader());
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




/*
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
{
    config.SignIn.RequireConfirmedAccount = false;
    config.SignIn.RequireConfirmedEmail = false;
    config.SignIn.RequireConfirmedPhoneNumber = false;
    config.User.RequireUniqueEmail = true;
    config.Password.RequiredLength = 3;
    config.Password.RequireDigit = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
})
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
builder.Services.AddIdentityServer(options =>
{
    options.IssuerUri = builder.Configuration.GetValue<string>("REACT_APP_AUTH_SERVER_URL");
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients(builder.Configuration))
    .AddAspNetIdentity<ApplicationUser>();

*/

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseRouting();

app.MapControllers();
app.MapControllers().RequireAuthorization("ApiScope");
app.Map("/health", app => app.UseHealthChecks("/health"));

app.UseAuthorization();
// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.Run();
