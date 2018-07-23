using System.ComponentModel.DataAnnotations;

namespace POWebClient.Models
{
    public class UserSharedViewModel
    {
        public UserViewModels UserViewModels { get; set; }
        public RegisterViewModels RegisterViewModels { get; set; }
    }
    public class UserViewModels
    {
        [Required(ErrorMessage = "Username harus diisi")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password harus diisi")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class RegisterExistingViewModels
    {
        [Required(ErrorMessage = "Username harus diisi")]
        [StringLength(5, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Username Terdaftar")]
        public string UsernameExisting { get; set; }

        [Required(ErrorMessage = "Username harus diisi")]
        //[StringLength(5, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Username Bpkpd")]
        public string UsernameBpkpd { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Terdaftar")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterViewModels
    {

        [Required(ErrorMessage = "Username harus diisi")]
        [StringLength(5, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Username Terdaftar")]
        public string ExistUsername { get; set; }

        [Required(ErrorMessage = "Username harus diisi")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Terdaftar")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}