using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Application.Contracts.Persistence.Marketplace;
using NativeTunes.Application.Extensions;
using NativeTunes.Domain.MarketplaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Marketplace.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Product, Error>>
    {
        private readonly IStorageService _storageService;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IStorageService storageService, IProductRepository productRepository)
        {
            _storageService = storageService;
            _productRepository = productRepository;
        }
        public async Task<Result<Product, Error>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await request.ValidateAsync(new CreateProductCommandValidator(), cancellationToken);
            if (validationResult.IsFailure)
                return validationResult.Error;


            // uploading image file
            var coverImageResult = await _storageService.UploadFileAsync("marketplace", request.ImageFile);
            if (coverImageResult.IsFailure)
            {
                return new BadRequestError(coverImageResult.ErrorMessage);
            }

            var product = Product.CreateNew(request.Title, request.Description, request.Price, coverImageResult.Url);

            _productRepository.AddProduct(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }
    }
}
