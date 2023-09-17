using CodeGoApp.Areas.Identity.Data;
using CodeGoApp.Data;
using CodeGoApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeGoApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ChatController(AppDbContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string? id, MessageEntity messageEntity)
        {
            /*            var users = _userManager.Users
                            .Where(u => u.Id != currentUser.Id)
                            .Select(u => new UserViewModel
                            {
                                CurrentUserId = currentUser.Id,
                                ReceiverId = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                Languages = u.Languages
                            }).ToList();*/


            var currentUser = await _userManager.GetUserAsync(User);

            if (id != null)
            {
                var receiverUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

                messageEntity.SenderId = currentUser.Id;
                messageEntity.RecieverId = receiverUser.Id;

                _context.Messages.Add(messageEntity);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Chat");
            }
            return NotFound();
        }

    }
}
