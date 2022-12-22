
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    [Table("drinks")]
    [PrimaryKey("Id")]
    public class Drink
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DrinkType Type { get; set; }
        public string Name { get; private set; }
        public double Percentage { get; set; }
        
        // Exists for EF
        public Drink()
        {
        }

        public Drink(string imageUrl, DrinkType type, string name, double percentage)
        {
            ImageUrl = imageUrl;
            Type = type;
            Name = name;
            Percentage = percentage;
        }

        public static Drink GetDummyDrink()
        {
            return new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.BeerOrPilsener, "Beer", 10);
        }
    }

}
