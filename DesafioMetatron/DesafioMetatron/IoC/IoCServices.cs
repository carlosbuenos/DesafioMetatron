using DesafioMetatron.Infra.DataBase;
using DesafioMetatron.Infra.Repositories.ConcreteObjects;
using DesafionMetatron.Domain.Builders.ConcreteObjects;
using DesafionMetatron.Domain.Builders.Interfaces;
using DesafionMetatron.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace DesafioMetatron.Api.IoC
{
	public static class IoCServices
	{
		public static void AddInjections(this IServiceCollection services)
		{
			services.AddSingleton<IRegrasParaValidacaoDeSenha, RegrasParaValidacaoDeSenha>();
			services.AddTransient<IUsuarioRepository, UsuarioRepository>();
			services.AddTransient<ICategoriaRepository, CategoriaRepository>();
			services.AddTransient<IListaRepository, ListaRepository>();
			services.AddTransient<ITarefaRepository, TarefaRepository>();
		}

		public static void AddMySql(this IServiceCollection services, IConfiguration configuration)
		{
			var connection = configuration["ConexaoMySql:MySqlConnectionString"];
			services.AddDbContextPool<MetatronContext>(options =>

				options.UseMySQL(connection)
			);
		}

		public static void AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioMetatron.Api", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme.
                    Enter 'Bearer' [space] and then your token in the text input below.
                    Example: 'Bearer jslkjasasiusdosiuas-sadhsajhdsha-qyeqvqheqeqoedoidrf'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				  {
					 new OpenApiSecurityScheme
					 {
					   Reference = new OpenApiReference
					   {
						 Type = ReferenceType.SecurityScheme,
						 Id = "Bearer"
					   }
					  },
					  new string[] { }
					}
				 });

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
		}

		public static void AddAuth(this IServiceCollection services)
		{
			var key = Encoding.UTF8.GetBytes("63dd8125b8ab48658bc4cd968d179f8a");
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
				};
			});
		}
	}
}
