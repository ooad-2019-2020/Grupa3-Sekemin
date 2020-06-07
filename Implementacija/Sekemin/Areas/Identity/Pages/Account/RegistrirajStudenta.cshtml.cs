using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Sekemin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Sekemin.Areas.Identity.Pages.Account
{
    public class RegistrirajStudenta:PageModel
    {

        private readonly SignInManager<Osoba> _signInManager;
        private readonly UserManager<Osoba> _userManager;
        private readonly ILogger<RegistrirajStudenta> _logger;
        private readonly IEmailSender _emailSender;

        public RegistrirajStudenta(
            UserManager<Osoba> userManager,
            SignInManager<Osoba> signInManager,
            ILogger<RegistrirajStudenta> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public StudentModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }


        public class StudentModel:RegisterModel.InputModel
        {
            [Required]
            public string Fakultet { get; set; }
            [Required]
            [Display(Name = "Godina studija")]
            public int GodinaStudija { get; set; }

            
        }


        public List<SelectListItem> Fakulteti { get; } = new List<SelectListItem>
            {
                new SelectListItem { Value ="Akademija likovnih umjetnosti", Text = "Akademija likovnih umjetnosti"},
                new SelectListItem { Value ="Akademija scenskih umjetnosti", Text = "Akademija scenskih umjetnosti"},
                new SelectListItem {Value = "Arhitektnosti fakultet", Text = "Arhitektnosti fakultet"},
                new SelectListItem {Value = "Ekonomski fakultet", Text = "Ekonomski fakultet"},
                new SelectListItem {Value = "Elektrotehnički fakultet", Text = "Elektrotehnički fakultet"},
                new SelectListItem {Value = "Fakultet islamskih nauka", Text = "Fakultet islamskih nauka"},
                new SelectListItem {Value = "Fakultet za kriminalistiku", Text = "Fakultet za kriminalistiku"},
                new SelectListItem {Value = "Fakultet političkih nauka", Text = "Fakultet političkih nauka"},
                new SelectListItem {Value = "Fakultet sporta i tjelesnog odgoja", Text = "Fakultet sporta i tjelesnog odgoja"},
                new SelectListItem {Value = "Fakultet za saobraćaj i komunikacije", Text = "Fakultet za saobraćaj i komunikacije"},
                new SelectListItem {Value = "Fakultet zdravstvenih studija", Text = "Fakultet zdravstvenih studija"},
                new SelectListItem {Value = "Farmaceutski fakultet", Text = "Farmaceutski fakultet"},
                new SelectListItem {Value = "Filozofski fakultet", Text = "Filozofski fakultet"},
                new SelectListItem {Value = "Građevinski fakultet", Text = "Građevinski fakultet"},
                new SelectListItem {Value = "Katolički bogoslovni fakultet", Text = "Katolički bogoslovni fakultet"},
                new SelectListItem {Value = "Mašinski fakultet", Text = "Mašinski fakultet"},
                new SelectListItem {Value = "Medicinski fakultet", Text = "Medicinski fakultet"},
                new SelectListItem {Value = "Muzička akademija", Text = "Muzička akademija"},
                new SelectListItem {Value = "Pedagoški fakultet", Text = "Pedagoški fakultet"},
                new SelectListItem {Value = "Poljoprivredno - prehrambeni fakultet", Text = "Poljoprivredno - prehrambeni fakultet"},
                new SelectListItem {Value = "Pravni fakultet", Text = "Pravni fakultet"},
                new SelectListItem {Value = "Prirodno - matematički fakultet", Text = "Prirodno - matematički fakultet"},
                new SelectListItem {Value = "Stomatološki fakultet sa klinikama", Text = "Stomatološki fakultet sa klinikama"},
                new SelectListItem {Value = "Šumarski fakultet", Text = "Šumarski fakultet"},
                new SelectListItem {Value = "Veterinarski fakultet", Text = "Veterinarski fakultet"},
                new SelectListItem {Value = "Institut za historiju", Text = "Institut za historiju"},
                new SelectListItem {Value = "Orijentalni institut", Text = "Institut za jezika"},
                new SelectListItem {Value = "Institut za genetičko inženjerstvo i biotehnologiju", Text = "Institut za genetičko inženjerstvo i biotehnologiju"},
                new SelectListItem {Value = "Institut za istraživanje zločina protiv čovječnosti i međunarodnog prava", Text = "Institut za istraživanje zločina protiv čovječnosti i međunarodnog prava"},

                
            };

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = new Student { UserName = Input.Email, Email = Input.Email, Grad = Input.Grad, Ime = Input.Ime, Prezime = Input.Prezime, DatumRodjenja = Input.DatumRodjenja, Spol = Input.Spol, Uloga = Uloga.Student, Fakultet = Input.Fakultet, GodinaStudija = Input.GodinaStudija };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
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
