
using Fiap.Api.AspNet5.Data;
using Fiap.Api.AspNet5.Repository;
using Fiap.Api.AspNet5.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Fiap.Api.AspNet5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //----------------------------------------------------------------
            var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
            builder.Services.AddDbContext<DataContext>(
                opt => opt.UseSqlServer(connectionString).EnableSensitiveDataLogging(true));
            //----------------------------------------------------------------

            //Injecao de Dependencias
            //----------------------------------------------------------------
            builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            //----------------------------------------------------------------

            //Autenticacao
            //----------------------------------------------------------------
            #region autenticacao
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            builder.Services.AddAuthentication
                ( x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    } 
                )
                .AddJwtBearer
                ( j =>
                    {
                        j.RequireHttpsMetadata = false;
                        j.SaveToken = true;
                        j.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );
            #endregion
            //----------------------------------------------------------------


            builder.Services.AddControllers();
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
        }
    }
}