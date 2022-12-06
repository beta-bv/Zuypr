using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [PrimaryKey(nameof(City), nameof(Street), nameof(Zipcode), nameof(Number), nameof(Suffix))]
    public class Location
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public int Number { get; set; }
        public string Suffix { get; set; }
    }
}
