using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BadMintonBookingRazorWebApp.Pages
{
    public class LoginModel : PageModel
    {
       
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
        }

        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Here you would typically validate the user credentials with your database
            if (Input.Email == "admin@gmail.com" && Input.Password == "admin")
            {              
                return RedirectPermanent("/Index");

            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
 
    
}
