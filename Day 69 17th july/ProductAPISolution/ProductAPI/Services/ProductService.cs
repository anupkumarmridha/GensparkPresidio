using Azure.Storage.Blobs;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "product-images";

        public ProductService(IProductRepository repository, BlobServiceClient blobServiceClient)
        {
            _repository = repository;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(Product product, IFormFile pic)
        {
            if (pic != null)
            {
                var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
                await blobContainerClient.CreateIfNotExistsAsync();

                var blobClient = blobContainerClient.GetBlobClient(pic.FileName);
                await blobClient.UploadAsync(pic.OpenReadStream(), true);
                product.PicUrl = blobClient.Uri.ToString();
            }

            await _repository.AddProductAsync(product);
        }
    }

}
