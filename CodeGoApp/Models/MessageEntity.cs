using CodeGoApp.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeGoApp.Models
{
    public class MessageEntity
    {
        public int Id { get; set; }
/*        [ForeignKey("AppUser")]
        public string SenderId { get;set; }

        [ForeignKey("AppUser")]
        public string RecieverId { get; set; }*/
        
        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }

        [Required]
        public string MessageText { get; set; }
        public DateTime SentTime { get; set; } = DateTime.Now;
    }
}
