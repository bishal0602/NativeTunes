namespace NativeTunes.API.Models.Marketplace
{
    public class ProductForCreationDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
        public decimal Price { get; set; }

    }
}
