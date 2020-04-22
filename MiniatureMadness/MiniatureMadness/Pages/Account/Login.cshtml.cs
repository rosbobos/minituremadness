using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniatureMadness.Models;

namespace MiniatureMadness.Pages.Account
{
    public class LoginModel : PageModel
    {
        /// <summary>
        /// The SignInManager class.
        /// </summary>
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// The data inputted by the user.
        /// </summary>
        [BindProperty]
        public LoginData Input { get; set; }

        /// <summary>
        /// Constructor method to inject the SignInManager class.
        /// </summary>
        /// <param name="signInManager">The SignInManager class.</param>
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        /// <summary>
        /// Method for HTTP GET requests.
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// Method for HTTP Post requests.
        /// </summary>
        /// <returns>A Page or View.</returns>
        public async Task<IActionResult> OnPost()
        {
            // Checks if user data is valid format.
            if (ModelState.IsValid)
            {
                // Attempts to Sign In user with inputted data.
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, false);

                // Checks if user Sign In was successful.
                if (result.Succeeded)
                {
                    // Redirects logged in user to Home page.
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Returns user to Login page with error.
                    ModelState.AddModelError("", "Invalid login attempt!");
                    return Page();
                }
            }

            return Page();
        }

        /// <summary>
        /// The data the user inputted on the Login Page.
        /// </summary>
        public class LoginData
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}