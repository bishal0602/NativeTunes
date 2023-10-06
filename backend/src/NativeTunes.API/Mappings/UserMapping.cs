using AutoMapper;
using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<Domain.UserAggregate.User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
        }
    }
}
