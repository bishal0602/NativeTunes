using Microsoft.EntityFrameworkCore;
using NativeTunes.Domain.MarketplaceAggregate.ValueObjects;
using NativeTunes.Domain.MarketplaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeTunes.Application.Contracts.Persistence.Marketplace;

namespace NativeTunes.Infrastructure.Persistence.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly NativeTunesDbContext _context;

        public ProductRepository(NativeTunesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductListAsync()
        {
            return await _context.Products.Include(p => p.CreatedBy).ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(ProductId productId)
        {
            return await _context.Products.Include(p => p.CreatedBy).FirstOrDefaultAsync(p => p.Id == productId);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
