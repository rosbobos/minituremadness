using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MiniatureMadness.Models;

namespace MiniatureMadness.Pages.Account
{
    public class LogoutModel : PageModel
    {
        /// <summary>
        /// Brings in our ApplicationUser model through the SignInManager Identity class.
        /// </summary>
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Constructor method to bring in our ApplicationUser model via the SignInManager Identity class.
        /// </summary>
        /// <param name="signInManager">The SignInManager class with our ApplicationUser model.</param>
        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {

        }

        /// <summary>
        /// Signs out the currently signed in user and redirects to the Home page.
        /// </summary>
        /// <returns>The Home page.</returns>
        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}