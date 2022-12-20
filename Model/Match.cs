using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("matches")]
    [PrimaryKey("Id")]
    public class Match
    {
        public int Id { get; set; }
        public User[] Users { get; set; }
        public List<Message> Messages { get; set; }
        
        // Exists for EF
        public Match(){}

        public Match(User[] users, List<Message> messages)
        {
            Users = users;
            Messages = messages;
        }
    }
}
