using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dto_s
{
    public class LoginCredentialsDTO
    {
        [Required]
        [Length(8, 20)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The password must be at least 8 characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
