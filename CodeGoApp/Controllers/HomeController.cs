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

        public async Task<IActionResult> Index()
        {
            /*            var id = _userManager.GetUserId(User);
                        appUser = await _userManager.FindByIdAsync(id);
                        if(appUser != null)
                        {
                            return View(appUser);
                        }
                        return NotFound();*/
            var currentUser = await _userManager.GetUserAsync(User);
            var users = _userManager.Users
                .Where(u => u.Id != currentUser.Id)
                .Select(u => new UserViewModel
                {

                    ReceiverId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Languages = u.Languages
                }).ToList();

            return View(users);
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