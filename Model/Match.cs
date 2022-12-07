using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Match
    {
        public User[] Users { get; set; }
        public List<Message> Messages { get; set; }
    }
}
