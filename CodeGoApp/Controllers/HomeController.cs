using CodeGoApp.Areas.Identity.Data;
using CodeGoApp.Data;
using CodeGoApp.Models;
using CodeGoApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGoApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            _context = db;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? languages)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var allUsers = _userManager.Users
                .Where(u => u.Id != currentUser.Id)
                .ToList();

            // Filter users based on entered programming languages
            var filteredUsers = allUsers;

            if (!string.IsNullOrEmpty(languages))
            {
                filteredUsers = allUsers
                    .Where(u => u.Languages.Contains(languages, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var usersViewModel = filteredUsers.Select(u => new UserViewModel
            {
                ReceiverId = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Languages = u.Languages
            }).ToList();

            return View(usersViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
