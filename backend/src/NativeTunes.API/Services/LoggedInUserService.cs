using NativeTunes.Application.Contracts.Services;
using NativeTunes.Domain.UserAggregate.ValueObjects;
using System.Security.Claims;

namespace NativeTunes.API.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserId? UserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                    return null;
                return UserId.Create(new Guid(userId));
            }
        }

    }
}
