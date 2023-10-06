using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Application.Contracts.Persistence.Marketplace;
using NativeTunes.Domain.MarketplaceAggregate.ValueObjects;

namespace NativeTunes.Application.Marketplace.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool, Error>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IStorageService _storageService;

        public DeleteProductCommandHandler(IProductRepository productRepository, IStorageService storageService)
        {
            _productRepository = productRepository;
            _storageService = storageService;
        }
        public async Task<Result<bool, Error>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.Id, out var idInGuid))
            {
                return new BadRequestError($"Invalid id: {request.Id}");
            }
            var productId = ProductId.Create(idInGuid);
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product is null)
                return new NotFoundError($"Product with Id {request.Id} not found");

            await _storageService.DeleteAsync(product.ImageUrl);

            _productRepository.DeleteProduct(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }
    }
}
