using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [PrimaryKey(nameof(Text), nameof(TimeSent))]
    public class Message
    {
        public Message(String text, User sender, DateTime timeSent) {
            Text = text;
            Sender = sender;
            TimeSent = timeSent;
        }
        public string Text { get; set; }
        public User Sender { get; set; }
        public DateTime TimeSent { get; set; }
        
    }
}
