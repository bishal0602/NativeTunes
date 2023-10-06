using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Models.Authentication
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
