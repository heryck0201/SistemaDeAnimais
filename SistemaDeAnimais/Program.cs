using Autofac.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemaDeAnimais.Data;
using SistemaDeAnimais.Repositorio;
using SistemaDeAnimais.Repositorio.IRepositorios;
using System.Text;

namespace SistemaDeAnimais
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            //{
            //    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            //}));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            builder.Services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                                   Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemaDeAnimais", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Header de autorização JWT usando o esquema Bearer.\r\n\r\nInforme 'Bearer'[espaço] e o seu token.\r\n\r\nExamplo: \'Bearer 1234abcdef\'",

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string []{}
                    }
                });
            });

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaDeAnimaisContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
                );

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddEntityFrameworkStores<SistemaDeAnimaisContext>()
                            .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
                    ValidIssuer = builder.Configuration["TokenConfiguration:Issue"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                              Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
                });

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IPetRepositorio, PetRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //    c.RoutePrefix = string.Empty;
            //});

            //            app.UseCors(builder => builder
            //.AllowAnyHeader()
            //.AllowAnyMethod()
            //.SetIsOriginAllowed((host) => true)
            //.AllowCredentials());

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}