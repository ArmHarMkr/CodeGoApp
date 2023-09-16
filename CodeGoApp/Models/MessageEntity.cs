namespace CodeGoApp.Models
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public int SenderId { get;set; }
        public int RecieverId { get; set; }
        public string MessageText { get; set; }
        public DateTime SentTime { get; set; } = DateTime.Now;
    }
}
