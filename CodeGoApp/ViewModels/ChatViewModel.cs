using CodeGoApp.Areas.Identity.Data;
using CodeGoApp.Models;

namespace CodeGoApp.ViewModels
{
    public class ChatViewModel
    {
        public AppUser CurrentUser { get; set; }
        public AppUser ReceiverUser { get; set; }
        /*public List<MessageEntity> Messages { get; set; } //In List we need to add the Messages from Db, using List.Add()*/
        public List<MessageEntity> Messages { get; set; }
        public MessageEntity NewMessage { get; set; }

    }
}
