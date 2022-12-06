using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Chat
    {
        public int Id { get; set; }
        public List<Message> Messages { get; set; } // Or use a queue
    }
}
