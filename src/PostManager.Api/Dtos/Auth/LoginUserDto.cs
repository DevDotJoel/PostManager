using System.ComponentModel.DataAnnotations;

namespace PostManager.Api.Dtos.Auth
{
    public class LoginUserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
