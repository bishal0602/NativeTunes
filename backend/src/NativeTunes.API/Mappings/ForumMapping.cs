using AutoMapper;

namespace NativeTunes.API.Mappings
{
    public class ForumMapping : Profile
    {
        public ForumMapping()
        {
            CreateMap<Domain.ForumAggregate.Post, Models.Forum.PostDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
               .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));
        }
    }
}
