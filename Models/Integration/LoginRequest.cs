using System.ComponentModel.DataAnnotations;

namespace jsonapisample.Models.Integration
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
