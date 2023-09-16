using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CodeGoApp.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string CurrentUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Languages { get; set; }
    }
}
