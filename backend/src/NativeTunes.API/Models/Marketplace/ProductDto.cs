using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Models.Marketplace
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Likes { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserDto? CreatedBy { get; set; }
    }

}
