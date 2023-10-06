using AutoMapper;
using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Mappings
{
    public class AuthenticationMapping : Profile
    {
        public AuthenticationMapping()
        {
            CreateMap<Application.Authentication.Common.AuthenticationResponse, Models.Authentication.AuthResponse>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
        }
    }
}
