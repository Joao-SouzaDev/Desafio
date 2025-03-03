using Microsoft.AspNetCore.Identity;

namespace Desafio.AuthService.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        public required string CompanyName { get; set; }
    }
}
