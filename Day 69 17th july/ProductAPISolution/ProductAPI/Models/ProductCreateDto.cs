namespace ProductAPI.Models
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile Pic { get; set; }
    }

}
