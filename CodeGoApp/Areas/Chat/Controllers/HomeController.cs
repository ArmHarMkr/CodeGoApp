using CodeGoApp.Areas.Identity.Data;
using CodeGoApp.Data;
using CodeGoApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeGoApp.Areas.Chat.Controllers
{
    [Area("Chat")]
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(AppDbContext _context, UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._signInManager = _signInManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var users = _userManager.Users
                .Where(u => u.Id != currentUser.Id)
                .Select(u => new UserViewModel
                {
                    CurrentUserId = currentUser.Id,
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Languages = u.Languages
                }).ToList();

            return View(users);


        }
    }
}
