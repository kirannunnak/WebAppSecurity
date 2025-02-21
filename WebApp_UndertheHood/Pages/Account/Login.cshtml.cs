using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;

namespace WebApp_UndertheHood.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; } = new Credential();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (Credential.Username == "admin" && Credential.Password == "admin")
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@gmail.com"),
                    new Claim("Department", "HR"),
                    new Claim("Admin", "true"),
                    new Claim("Manager", "true"),
                    new Claim("EmploymentDate", "2023-01-01")
                };
                var identity = new ClaimsIdentity(Claims, "MyCookie");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

               // var authProperties = new AuthenticationProperties
                //{
                   // IsPersistent = Credential.RememberMe
                //};

                await HttpContext.SignInAsync("MyCookie", claimsPrincipal);

                return RedirectToPage("/Index");
            }
            return Page();
        }

    }

    public class Credential
    {
        [Required]
        [Display(Description = "User Name")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Display(Description = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
