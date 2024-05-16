using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Repositories.Classes;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using EmployeeRequestTrackerAPI.Services.Classes;
using EmployeeRequestTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EmployeeRequestTrackerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Debug.WriteLine(builder.Configuration["TokenKey:JWT"]);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                    };

                });
            #region Database Configuration
            builder.Services.AddDbContext<RequestTrackerContext>(
            options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("defaultConnection"))
            );
            #endregion Database Configuration

            #region Repository Configuration
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            #endregion Repository Configuration

            #region Service Configuration
            builder.Services.AddScoped<IEmployeeService, EmployeeBasicService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            #endregion Service Configuration

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
