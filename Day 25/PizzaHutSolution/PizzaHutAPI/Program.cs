using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Contexts;

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
         
        }
        private static void RegisterServices(IServiceCollection services)
        {

        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
