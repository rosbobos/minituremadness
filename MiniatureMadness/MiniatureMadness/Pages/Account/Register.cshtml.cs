using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniatureMadness.Models;

namespace MiniatureMadness.Pages.Account
{
    public class RegisterModel : PageModel
    {
        /// <summary>
        /// UserManager class via Dependency Injection.
        /// </summary>
        private UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// SignInManager class via Dependency Injection.
        /// </summary>
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// The data for a new user to register with.
        /// </summary>
        [BindProperty]
        public RegisterData NewUser { get; set; }

        /// <summary>
        /// Constructor method for Dependency Injection.
        /// </summary>
        /// <param name="userManager">The UserManager class.</param>
        /// <param name="signInManager">The SignInManager class.</param>
        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Logic for GET requests.
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// Logic for POST requests.
        /// </summary>
        /// <returns>A view or Page.</returns>
        public async Task<IActionResult> OnPost()
        {
            // Checks if the user input passed front-end validation.
            if (ModelState.IsValid)
            {
                // Create a new ApplicationUser from the inputted data.
                var newUser = new ApplicationUser
                {
                    UserName = NewUser.Email,
                    Email = NewUser.Email,
                    FirstName = NewUser.FirstName,
                    LastName = NewUser.LastName,
                    Birthdate = NewUser.Birthdate
                };

                // Create a new user in the Identity DB.
                var result = await _userManager.CreateAsync(newUser, NewUser.Password);

                // Check if new user was successfully added to DB.
                if (result.Succeeded)
                {
                    //when registration is succesful
                    //user is not yet logged in
                    //claims to hold user information for later use
                    Claim name = new Claim("FullName", $"{newUser.FirstName} {newUser.LastName}");
                    Claim email = new Claim(ClaimTypes.Email, newUser.Email, ClaimValueTypes.Email);
                    Claim birthday = new Claim(ClaimTypes.DateOfBirth, new DateTime(newUser.Birthdate.Year, newUser.Birthdate.Month, newUser.Birthdate.Day).ToString("u"), ClaimValueTypes.DateTime);

                    List<Claim> claims = new List<Claim>()
                    {
                        name, email, birthday
                    };

                    await _userManager.AddClaimsAsync(newUser, claims);
                    // Sign the user in and redirect to the "Home" page.
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // Add errors to model if user was not successfully added to DB.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Return the login page with the errors if all else failed.
            return Page();
        }

        /// <summary>
        /// PageModel / ViewModel for the inputted user data.
        /// </summary>
        public class RegisterData
        {
            /// <summary>
            /// The email address the user inputted.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            /// <summary>
            /// The first name the user inputted.
            /// </summary>
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            /// <summary>
            /// The last name the user inputted.
            /// </summary>
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            /// <summary>
            /// The birthday the user inputted.
            /// </summary>
            [Required]
            [DataType(DataType.Date)]
            public DateTime Birthdate { get; set; }

            /// <summary>
            /// The password the user inputted.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 8)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            /// The confirmation password the user inputted.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The passwords do not match")]
            [Display(Name = "Confirm Password")]
            public string ConfirmPassword { get; set; }
        }
    }
}