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
        public Chat Chat { get; set; }

        private readonly DatabaseContext _db;
        private readonly Match _match;

        public Match(User self, User match)
        {
            _db = new DatabaseContext();
            _match = _db.Matches.Where(m => m.Users.Contains(self) || m.Users.Contains(match)).First();

            Users = _match.Users;
            Chat = _match.Chat;
        }

        public void SendMessage(Message message)
        {
            _match.Chat.Messages.Add(message);
            _db.SaveChanges();
        }
    }
}
