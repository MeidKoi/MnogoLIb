using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models.Accounts
{
    public class RegisterRequest
    {
        [Required]
        public string NicknameUser { get; set; }

        [Required]
        [EmailAddress]
        public string EmailUser { get; set; }

        [Required]
        [MinLength(6)]
        public string PasswordUser { get; set; }

        [Required]
        [Compare("PasswordUser")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }
}