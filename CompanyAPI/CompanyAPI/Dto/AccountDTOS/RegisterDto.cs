using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Dto.AccountDTOS
{
    public class RegisterDto
    {
        [Required]

        public string? Username { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
