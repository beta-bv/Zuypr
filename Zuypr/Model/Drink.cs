
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
        public Bitmap DrinkImage { get; set; }
        public DrinkType DrinkType { get; set;}
        public string DrinkName { get; set; }
        public float Percentage { get; set; }
    }
}
