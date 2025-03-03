using System.ComponentModel.DataAnnotations;

namespace Desafio.AuthService.Data.DTO
{
    public class RegisterUserRequest
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Document { get; set; }
        [Required]
        public required string CompanyName { get; set; }
    }
}
