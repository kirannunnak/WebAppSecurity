using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace WebApp_UndertheHood.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; } = new Credential();

        public void OnGet()
        {
        }

        public void OnPost()
        {

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
