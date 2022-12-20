using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("bars")]
    [PrimaryKey("Id")]
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; }
        public Location Location { get; set; }
        
        // Exists for EF
        public Bar()
        {
        }
    }
}
