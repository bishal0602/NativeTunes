using NativeTunes.Domain.Common;
using NativeTunes.Domain.MarketplaceAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.MarketplaceAggregate
{
    public class Product : AuditableAggregate<ProductId>
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Likes { get; private set; }
        public string ImageUrl { get; private set; }

        private Product() { } // EF Core

        private Product(ProductId id, string title, string? description, decimal price, int likes, string imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Likes = likes;
            ImageUrl = imageUrl;
        }

        public static Product Create(ProductId id, string title, string? description, decimal price, int likes, string imageUrl) => new(id, title, description, price, likes, imageUrl);

        public static Product CreateNew(string title, string? description, decimal price, string imageUrl) => new(ProductId.CreateNew(), title, description, price, 0, imageUrl);
    }
}
