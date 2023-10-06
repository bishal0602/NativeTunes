using Microsoft.AspNetCore.Http;
using NativeTunes.Domain.MarketplaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Marketplace.Command.CreateProduct
{
    public record CreateProductCommand(string Title, string? Description, decimal Price, IFormFile ImageFile) : IRequest<Result<Product, Error>> { };

}
