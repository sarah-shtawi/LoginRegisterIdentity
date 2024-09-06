using System.ComponentModel.DataAnnotations;

namespace IdentityLoginRegister.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string Phone {  get; set; }
    }
}
