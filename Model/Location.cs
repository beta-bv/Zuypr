using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("locations")]
    [PrimaryKey("Id")]
    // Exists for EF
    public class Location
    {
        public int Id { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public int Number { get; set; }
        public string Suffix { get; set; }

        public Location()
        {
        }
    }
}
