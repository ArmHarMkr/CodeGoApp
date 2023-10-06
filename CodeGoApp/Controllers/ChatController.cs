using CodeGoApp.Areas.Identity.Data;
using CodeGoApp.Data;
using CodeGoApp.Models;
using CodeGoApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CodeGoApp.Controllers
{
    [Authorize]
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

        //Show message

        //Here the model must be ViewModel not the Model
        public async Task<IActionResult> ShowMessage(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var receiverUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            var messages = await _context.Messages
                .Where(m =>
                    (m.Sender == currentUser && m.Receiver.Id == id) ||
                    (m.Sender.Id == id && m.Receiver == currentUser))
                .OrderBy(m => m.SentTime)
                .ToListAsync();

            
            var viewModel = new ChatViewModel
            {
                CurrentUser = currentUser,
                ReceiverUser = receiverUser,
                Messages = messages,
                NewMessage = new MessageEntity(),
                MsgLastCount = messages.Count()
            };

            return View(viewModel);
        }






        public IActionResult Messenger()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Messenger(string? id, MessageEntity messageEntity)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (id != null)
            {
                var receiverUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
                messageEntity.Sender = currentUser;
                messageEntity.Receiver = receiverUser;
                _context.Messages.Add(messageEntity);

                await _context.SaveChangesAsync();

                return RedirectToAction("ShowMessage", new { id });
            }
            return View();
        }

    }
}