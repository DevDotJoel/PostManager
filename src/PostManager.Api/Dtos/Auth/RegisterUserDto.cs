using System.ComponentModel.DataAnnotations;

namespace PostManager.Api.Dtos.Auth
{
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Password2 { get; set; }
    }
}
