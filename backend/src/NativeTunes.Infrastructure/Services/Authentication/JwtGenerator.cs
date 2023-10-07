using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NativeTunes.Application.Contracts.Services;
using NativeTunes.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Infrastructure.Services.Authentication
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {

            _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            _jwtSettings = jwtOptions.Value ?? throw new ArgumentNullException(nameof(jwtOptions));
        }

        public string CreateToken(User user)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // jwt token identifier
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                notBefore: _dateTimeProvider.Now,
                expires: _dateTimeProvider.Now.AddYears(_jwtSettings.ExpirationTimeInMinutes) // Using year insead of year for demo
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
