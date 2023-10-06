using NativeTunes.Domain.MarketplaceAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Marketplace.Query
{
    public record GetProductListQuery : IRequest<Result<IEnumerable<Product>, Error>>
    {
    }
}
