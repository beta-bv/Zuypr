using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("messages")]
    [PrimaryKey("Id")]
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User Sender { get; set; }
        public DateTime TimeSent { get; set; }

        // Exists for EF
        public Message()
        {
        }

        public Message(String text, User sender, DateTime timeSent)
        {
            Text = text;
            Sender = sender;
            TimeSent = timeSent;
        }
    }
}