using NativeTunes.Domain.MarketplaceAggregate;
using NativeTunes.Domain.PodcastAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Marketplace.Query.GetProductDetail
{
    public record GetProductDetailQuery(string Id) : IRequest<Result<Product, Error>>
    {
    }
}
