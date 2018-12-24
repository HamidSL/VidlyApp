using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VidlyPrototype.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "email_required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "email_required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {

        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "email_required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "password_required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "email_required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "password_required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "password_length", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "confirm_password")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "email_required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "password_required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "password_length", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "confirm_password")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Controller_Accout_Validation), ErrorMessageResourceName = "email_required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
