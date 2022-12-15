
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
        BeerOrPilsener,
        CraftBeer,
        IPA,
        Cider,
        WhiteWine,
        RedWine,
        RoseWine,
        SparklingWine,
        Whisky,
        Rum,
        SweetLiqour,
        StrongLiqour,
        Cocktail,
        VodkaMix,
        RumMix,
        Mix
    }

    public class Drink
    {
        public string ImageUrl { get; set; }
        public DrinkType Type { get; set; }
        public string Name { get; set; }
        public double Percentage { get; set; }

        public Drink(string drinkImage, DrinkType drinkType, string drinkName, double percentage)
        {
            ImageUrl = drinkImage;
            Type = drinkType;
            Name = drinkName;
            Percentage = percentage;
        }

        public static Drink GetDummyDrink()
        {
            return new Drink("https://static.ah.nl/dam/product/AHI_43545239363438323836?revLabel=1&rendition=800x800_JPG_Q90&fileType=binary", DrinkType.BeerOrPilsener, "Beer", 10);
        }
    }
}
