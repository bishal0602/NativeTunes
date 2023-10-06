using NativeTunes.Domain.MarketplaceAggregate.ValueObjects;
using NativeTunes.Domain.MarketplaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Contracts.Persistence.Marketplace
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Task<Product?> GetProductByIdAsync(ProductId productId);
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<bool> SaveChangesAsync();
    }
}
