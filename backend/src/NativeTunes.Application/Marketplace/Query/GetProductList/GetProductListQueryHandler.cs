using NativeTunes.Application.Contracts.Persistence.Marketplace;
using NativeTunes.Domain.MarketplaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Marketplace.Query
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, Result<IEnumerable<Product>, Error>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<IEnumerable<Product>, Error>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductListAsync();
            return products.ToList();
        }
    }
}
