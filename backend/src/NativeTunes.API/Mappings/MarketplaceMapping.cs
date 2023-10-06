using AutoMapper;
using NativeTunes.API.Models.Podcasts;
using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Mappings
{
    public class MarketplaceMapping : Profile
    {
        public MarketplaceMapping()
        {
            CreateMap<Domain.MarketplaceAggregate.Product, Models.Marketplace.ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));

            // If CreatedBy is nullable in Podcast, handle null value by ignoring it
            CreateMap<Domain.UserAggregate.User, UserDto>().ReverseMap();
        }
    }
}
