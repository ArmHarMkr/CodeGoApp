namespace CodeGoApp.Models
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string SenderId { get;set; }
        public string RecieverId { get; set; }
        public string MessageText { get; set; }
        public DateTime SentTime { get; set; } = DateTime.Now;
    }
}
