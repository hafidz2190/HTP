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
        [Required(ErrorMessage = "Username Terdaftar harus diisi")]
        [StringLength(5, ErrorMessage = "{0} minimum {2} karakter.", MinimumLength = 5)]
        [Display(Name = "Username Terdaftar")]
        public string UsernameExisting { get; set; }

        [Required(ErrorMessage = "Username Bpkpd harus diisi")]
        [Display(Name = "Username Bpkpd")]
        public string UsernameBpkpd { get; set; }

        [Required(ErrorMessage = "Email Terdaftar harus diisi")]
        [EmailAddress]
        [Display(Name = "Email Terdaftar")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password harus diisi")]
        [StringLength(100, ErrorMessage = "{0} minimum {2} karakter.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterViewModels
    {

        [Required(ErrorMessage = "Username Terdaftar harus diisi")]
        [StringLength(5, ErrorMessage = "{0} minimum {2} karakter.", MinimumLength = 5)]
        [Display(Name = "Username Terdaftar")]
        public string ExistUsername { get; set; }

        [Required(ErrorMessage = "Username harus diisi")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Terdaftar")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password harus diisi")]
        [StringLength(100, ErrorMessage = "{0} minimum {2} karakter.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Konfirmasi password tidak sesuai.")]
        public string ConfirmPassword { get; set; }
    }

}