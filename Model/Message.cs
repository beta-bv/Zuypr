using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("messages")]
    [PrimaryKey("Id")]
    public class Message
    {
        public int Id { get; }
        public string Text { get; }
        public User Sender { get; }
        public DateTime TimeSent { get; }
        public User Match { get; }

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