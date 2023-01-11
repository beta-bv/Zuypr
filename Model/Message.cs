using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("messages")]
    [PrimaryKey("Id")]
    public class Message
    {
        public int Id { get; set;}
        public string Text { get; set; }
        public User Sender { get; set; }
        public DateTime TimeSent { get; set; }
        public User Match { get; set; }

        // Exists for EF
        public Message()
        {
        }

        public Message(string text, User sender, DateTime timeSent)
        {
            Text = text;
            Sender = sender;
            TimeSent = timeSent;
        }

        public Message(string text, User sender, DateTime timeSent, User match) : this(text, sender, timeSent)
        {
            Match = match;
        }
    }
}