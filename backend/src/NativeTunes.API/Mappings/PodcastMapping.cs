using AutoMapper;
using NativeTunes.API.Models.Podcasts;
using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Mappings
{
    public class PodcastMapping : Profile
    {
        public PodcastMapping()
        {
            CreateMap<Domain.PodcastAggregate.Podcast, PodcastDto>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
          .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
          .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
          .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
          .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.CoverImageUrl))
          .ForMember(dest => dest.PodcastUrl, opt => opt.MapFrom(src => src.PodcastUrl))
          .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
          .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));
        }
    }
}
