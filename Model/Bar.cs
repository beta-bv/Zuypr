using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; }
        public Location Location { get; set; }
    }
}
