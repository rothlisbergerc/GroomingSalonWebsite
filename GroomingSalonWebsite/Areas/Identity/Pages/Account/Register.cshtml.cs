using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace GroomingSalonWebsite.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        //public string ReturnUrl { get; set; }

        //public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Need to associate full name with account.")]
            [DisplayName("First Name")]
            [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
            [StringLength(20, MinimumLength = 2)]
            public string AccountFirstName { get; set; }
            [Required(ErrorMessage = "Need to associate full name with account.")]
            [DisplayName("Last Name")]
            [RegularExpression(@"^[a-zA-Z'\s]*$", ErrorMessage = "Can only consist of letters and have at least 2")]
            [StringLength(20, MinimumLength = 2)]
            public string AccountLastName { get; set; }
            [Required(ErrorMessage = "Need to associate phone with account.")]
            [DisplayName("Phone Number")]
            [Phone]
            [RegularExpression(@"^\d+$", ErrorMessage = "Please enter numbers only")]
            [StringLength(10, MinimumLength = 10)]
            public string AccountPhoneNumber { get; set; }

            [Required(ErrorMessage = "Need your email as alternative to login")]
            [DisplayName("Email Address")]
            [DataType(DataType.EmailAddress)]
            public string AccountEmail { get; set; }

            [Required(ErrorMessage = "A username is needed to associate with your account.")]
            [DisplayName("Username")]
            [StringLength(16, MinimumLength = 6)]
            public string AccountName { get; set; }

            [Required(ErrorMessage = "An 8 letter password is required.")]
            [DisplayName("Password")]
            [DataType(DataType.Password)]
            [StringLength(32, MinimumLength = 8)]
            public string AccountPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("AccountPassword", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet()//string returnUrl = null)
        {
            //ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //returnUrl = returnUrl ?? Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.AccountEmail, Email = Input.AccountEmail };
                var result = await _userManager.CreateAsync(user, Input.AccountPassword);
                var acc = new Models.Account { Input = user };
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                   // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                     //   $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.AccountEmail, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
