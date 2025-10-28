using Microsoft.AspNetCore.Identity;

namespace WebApIFaod2025.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
