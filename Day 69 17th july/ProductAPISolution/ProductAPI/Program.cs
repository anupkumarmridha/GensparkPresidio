using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Contexts;
using ProductAPI.Repositories;
using ProductAPI.Services;

namespace ProductAPI
{
    public class Program
    {
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration, string sqlServerConnectionString)
        {
            services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(sqlServerConnectionString));
        } 

        private static void AddBlobClient(IServiceCollection services, IConfiguration configuration, string blobServiceConnectionString)
        {
            var blobServiceClient = new BlobServiceClient(blobServiceConnectionString);
            services.AddSingleton(blobServiceClient);
        }

        #region RegisterRepositories
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        #endregion RegisterRepositories

        #region RegisterServices
        private static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<IProductService, ProductService>();

        }
        #endregion RegisterServices
        #region ConfigureServices
        private static void ConfigureServices(
            IServiceCollection services,
            IConfiguration configuration,
            string sqlServerConnectionString,
            string blobServiceConnectionString
            )
        {
            services.AddControllers();

            #region CORS
            services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // Register BlobServiceClient
         

            AddDbContext(services, configuration, sqlServerConnectionString);
            AddBlobClient(services, configuration, blobServiceConnectionString);

            RegisterRepositories(services);
            RegisterServices(services);
        }
        #endregion ConfigureServices
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Retrieve secrets from Azure Key Vault
            var kvUri = configuration["KeyVault:VaultUri"];

            var secretClient = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
            var sqlServerConnectionString = await GetSecretAsync(secretClient, "SqlServerConnectionString");
            await Console.Out.WriteLineAsync(sqlServerConnectionString);

            var blobServiceConnectionString = await GetSecretAsync(secretClient, "BlobServiceBlobUri"); ;
            await Console.Out.WriteLineAsync(blobServiceConnectionString);


            // Add services to the container.
            builder.Services.AddControllers();
            // Add services to the container.
            ConfigureServices(builder.Services, builder.Configuration, sqlServerConnectionString, blobServiceConnectionString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("MyCors");
            app.MapControllers();

            await app.RunAsync();
        }

        private static async Task<string> GetSecretAsync(SecretClient secretClient, string secretName)
        {
            var secret = await secretClient.GetSecretAsync(secretName);
            return secret.Value.Value;
        }
    }
}
