namespace Model
{
    public class Match
    {
        public User[] Users { get; set; }
        public List<Message> Messages { get; set; }

        private readonly DatabaseContext _db;
        private readonly Match _match;

        public Match(User self, User match)
        {
            _db = new DatabaseContext();
            _match = _db.Matches.Where(m => m.Users.Contains(self) && m.Users.Contains(match)).First();

            Users = _match.Users;
            Messages = _match.Messages;
        }

        public void SendMessage(Message message)
        {
            Messages.Add(message);
            _db.SaveChanges();
        }
    }
}
