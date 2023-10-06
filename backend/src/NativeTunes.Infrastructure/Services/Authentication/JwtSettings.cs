using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Infrastructure.Services.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        [Required]
        public string Secret { get; init; } = null!;
        [Required]
        public int ExpirationTimeInMinutes { get; init; }
        [Required]
        public string Issuer { get; init; } = null!;
        [Required]
        public string Audience { get; init; } = null!;
    }
}
