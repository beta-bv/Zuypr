using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Match
    {
        public int Id { get; set; }
        public User[] Users { get; set; }
        public List<Message> Chat { get; set; }
    }
}
