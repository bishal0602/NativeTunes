using NativeTunes.Application.Contracts.Persistence.Marketplace;
using NativeTunes.Application.Contracts.Persistence.Podcasts;
using NativeTunes.Domain.MarketplaceAggregate;
using NativeTunes.Domain.MarketplaceAggregate.ValueObjects;
using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Marketplace.Query.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, Result<Product, Error>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductDetailQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<Product, Error>> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out var idInGuid))
            {
                return new BadRequestError($"Invalid id: {request.Id}");
            }
            var productId = ProductId.Create(idInGuid);
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product is null)
                return new NotFoundError($"Product with Id {request.Id} not found");
            return product;
        }
    }
}
