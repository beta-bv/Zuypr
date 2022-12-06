
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum DrinkType
    {
        Beer,
        Wine,
        Liquor
    }
    public class Drink
    {
        public int Id { get; set; }
        public string DrinkImage { get; set; }
        public DrinkType DrinkType { get; set;}
        public string DrinkName { get; set; }
        public float Percentage { get; set; }

        public static Drink GetDummyDrink()
        {
            return new Drink();
        }
    }

}
