using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [PrimaryKey(nameof(id))]
    public class Match
    {
        public int id;
        [Required]
        public User[] Users { get; set; }
        public List<Message> Chat { get; set; }
    }
}
