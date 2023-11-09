using GerenciadorDeArquivos.Application.ServiceApplications;
using GerenciadorDeArquivos.Common.Application;
using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Common.Domain.Service;
using GerenciadorDeArquivos.Common.Domain.Token;
using GerenciadorDeArquivos.Common.Infrastructure.Repository;
using GerenciadorDeArquivos.Domain.Helpers;
using GerenciadorDeArquivos.Domain.Interfaces.Application;
using GerenciadorDeArquivos.Domain.Interfaces.Repository;
using GerenciadorDeArquivos.Domain.Interfaces.Service;
using GerenciadorDeArquivos.Domain.Services;
using GerenciadorDeArquivos.Repository.Context;
using GerenciadorDeArquivos.Repository.Dapper;
using GerenciadorDeArquivos.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<GerenciadorDeArquivosContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableDetailedErrors());
builder.Services.AddScoped<IUnitOfWork<GerenciadorDeArquivosContext>, GerenciadorDeArquivosContext>();
builder.Services.AddScoped<IUsuarioLogado, UsuarioLogado>();
builder.Services.AddScoped<IUsuarioLogadoRepository, UsuarioLogadoRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<DbSession>();

//Repository
builder.Services.AddTransient(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
builder.Services.AddScoped(typeof(IUsuarioRepository<>), typeof(UsuarioRepository<>));
//builder.Services.AddScoped(typeof(IDashboardRepository<>), typeof(DashboardRepository<>));
builder.Services.AddScoped(typeof(ISistemaMenuRepository<>), typeof(SistemaMenuRepository<>));
builder.Services.AddScoped(typeof(IArquivoRepository<>), typeof(ArquivoRepository<>));

//Service
builder.Services.AddTransient(typeof(IServiceBase<,,>), typeof(ServiceBase<,,>));
builder.Services.AddScoped(typeof(IUsuarioService<>), typeof(UsuarioService<>));
builder.Services.AddScoped(typeof(IAutenticacaoService<>), typeof(AutenticacaoService<>));
//builder.Services.AddScoped(typeof(IDashboardService<>), typeof(DashboardService<>));
builder.Services.AddScoped(typeof(ISistemaMenuService<>), typeof(SistemaMenuService<>));
builder.Services.AddScoped(typeof(IArquivoService<>), typeof(ArquivoService<>));

//Application
builder.Services.AddTransient(typeof(IApplicationBase<,,>), typeof(ApplicationBase<,,>));
builder.Services.AddScoped(typeof(IUsuarioApplication<>), typeof(UsuarioApplication<>));
builder.Services.AddScoped(typeof(IAutenticacaoApplication<>), typeof(AutenticacaoApplication<>));
//builder.Services.AddScoped(typeof(IDashboardApplication<>), typeof(DashboardApplication<>));
builder.Services.AddScoped(typeof(ISistemaMenuApplication<>), typeof(SistemaMenuApplication<>));
builder.Services.AddScoped(typeof(IArquivoApplication<>), typeof(ArquivoApplication<>));

//Inicio Autenticação
var tokenConfiguration = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(builder.Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
builder.Services.AddSingleton(tokenConfiguration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfiguration.Issuer,
        ValidAudience = tokenConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

//Fim Autenticação

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
