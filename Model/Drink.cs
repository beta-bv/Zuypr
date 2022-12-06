
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
        public string DrinkImage { get; set; }
        public DrinkType DrinkType { get; set;}
        public string DrinkName { get; set; }
        public float Percentage { get; set; }

        public Drink(string drinkImage, DrinkType drinkType, string drinkName, float percentage) {
            DrinkImage = drinkImage;
            DrinkType = drinkType;
            DrinkName = drinkName;
            Percentage = percentage;
        }

        public static Drink GetDummyDrink()
        {
            return new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.Beer, "Beer", 10);
        }
    }

}
