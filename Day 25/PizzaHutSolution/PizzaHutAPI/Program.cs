using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PizzaHutAPI.Contexts;
using PizzaHutAPI.Repositories.Classes;
using PizzaHutAPI.Repositories.Interfaces;
using PizzaHutAPI.Services.Classes;
using PizzaHutAPI.Services.Interfaces;
using System.Text;

namespace PizzaHutAPI
{
    

    public class Program
    {
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PizzaHutDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("defaultConnection")));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IStockService, StockService>();
        }

        private static void AddJWTTokenSwaggerGen(IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] { }
                    }
                });
            });
        }
        private static void ValidateToken(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey:JWT"]))
                    };

                });
        }
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            //Token operations
            AddJWTTokenSwaggerGen(services);
            ValidateToken(services, configuration);

            AddDbContext(services, configuration);

            RegisterRepositories(services);
            RegisterServices(services);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
