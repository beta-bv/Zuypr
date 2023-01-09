using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("matches")]
    [PrimaryKey("Id")]
    public class Match
    {
        public int Id { get; set; }
        public User UserA { get; set; }
        public User UserB { get; set; }
        public List<Message> Messages { get; set; }
        
        // Exists for EF
        public Match(){}

        public Match(User userA, User userB)
        {
            //Messages = Database.DB.Messages.Where(m => users.Contains(m.Sender) && users.Contains(m.Match)).ToList();
            Messages = new List<Message>();
            UserB = userB;
            UserA = userA;
        }
    }
}
