using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Contexts;
using ProductAPI.Repositories;
using ProductAPI.Services;

namespace ProductAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                // Use the updated configuration values
                var sqlServerConnectionString = Configuration["ConnectionStrings:SqlServerConnection"];
                if (string.IsNullOrEmpty(sqlServerConnectionString))
                {
                    throw new ArgumentNullException("ConnectionStrings:SqlServerConnection", "SqlServerConnectionString is not configured properly.");
                }
                Console.WriteLine("sql:",sqlServerConnectionString);
                services.AddDbContext<ProductContext>(options =>
                    options.UseSqlServer(sqlServerConnectionString));

                var blobUri = Configuration["BlobService:BlobUri"];
                if (string.IsNullOrEmpty(blobUri))
                {
                    throw new ArgumentNullException("BlobService:BlobUri", "BlobUri is not configured properly.");
                }
                services.AddSingleton(new BlobServiceClient(new Uri(blobUri), new DefaultAzureCredential()));

                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IProductService, ProductService>();

                services.AddControllers();
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, e.g., logging
                Console.WriteLine($"Error in ConfigureServices: {ex.Message}");
                throw; // Re-throw the exception to halt application startup
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
