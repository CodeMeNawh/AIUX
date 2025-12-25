using System.ComponentModel.DataAnnotations;

namespace AIUX.DTOs
{
    public class RegisterUserDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(10)]
        public string Password { get; set; } = string.Empty;
    }
}
