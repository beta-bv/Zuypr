using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class dummydb
    {
        public static List<User> Users = new List<User>();

        public static List<Drink> Drinks = new List<Drink>()
        {
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Hertog Jan", 0.05),
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Heineken", 0.05),
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Kornet", 0.05),
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Amstel", 0.05),
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Grolsch", 0.05),
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Gladiator van de Radiator", 0.08),
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Klok op Kamertemperatuur", 0.048),
            new Drink("this/is/an/url.png", DrinkType.BeerOrPilsener, "Export", 0.047),
            new Drink("this/is/an/url.png", DrinkType.CraftBeer, "La Choufe", 0.08),
            new Drink("this/is/an/url.png", DrinkType.CraftBeer, "Tripel Karmeliet", 0.084),
            new Drink("this/is/an/url.png", DrinkType.CraftBeer, "Affligem Blond", 0.067),
            new Drink("this/is/an/url.png", DrinkType.CraftBeer, "Skuumkoppe", 0.06),
            new Drink("this/is/an/url.png", DrinkType.CraftBeer, "Guinness", 0.06),
            new Drink("this/is/an/url.png", DrinkType.CraftBeer, "Grand Prestige", 0.086),
            new Drink("this/is/an/url.png", DrinkType.IPA, "Brand", 0.05),
            new Drink("this/is/an/url.png", DrinkType.IPA, "Brewdog", 0.05),
            new Drink("this/is/an/url.png", DrinkType.IPA, "Punk IPA", 0.05),
            new Drink("this/is/an/url.png", DrinkType.Cider, "Radler", 0.02),
            new Drink("this/is/an/url.png", DrinkType.Cider, "Radler 0.0", 0.001),
            new Drink("this/is/an/url.png", DrinkType.Cider, "Apple Bandit", 0.02),
            new Drink("this/is/an/url.png", DrinkType.Cider, "Desperados", 0.045),
            new Drink("this/is/an/url.png", DrinkType.Cider, "Liefmans", 0.05),
            new Drink("this/is/an/url.png", DrinkType.RedWine, "Undurraga Merlot", 0.15),
            new Drink("this/is/an/url.png", DrinkType.RedWine, "Lindeman's Merlot", 0.15),
            new Drink("this/is/an/url.png", DrinkType.RedWine, "AH Gluhwein", 0.15),
            new Drink("this/is/an/url.png", DrinkType.RedWine, "Jacobs Creek Merlot", 0.15),
            new Drink("this/is/an/url.png", DrinkType.RedWine, "Mooi Kaap Droë rooi", 0.15),
            new Drink("this/is/an/url.png", DrinkType.WhiteWine, "Slurp! Chardonnay", 0.125),
            new Drink("this/is/an/url.png", DrinkType.WhiteWine, "Fat Bastard Chardonnay", 0.125),
            new Drink("this/is/an/url.png", DrinkType.WhiteWine, "Jacobs Creek Chardonnay", 0.125),
            new Drink("this/is/an/url.png", DrinkType.WhiteWine, "Mooi Kaap Chardonnay", 0.125),
            new Drink("this/is/an/url.png", DrinkType.WhiteWine, "Wild Pig Chardonnay", 0.125),
            new Drink("this/is/an/url.png", DrinkType.RoseWine, "Slurp! Rose", 0.125),
            new Drink("this/is/an/url.png", DrinkType.RoseWine, "Mooi Kaap Rose", 0.125),
            new Drink("this/is/an/url.png", DrinkType.RoseWine, "Welmoed Rose", 0.125),
            new Drink("this/is/an/url.png", DrinkType.RoseWine, "Undurraga Rose", 0.125),
            new Drink("this/is/an/url.png", DrinkType.RoseWine, "La Tulipe Rose", 0.125),
            new Drink("this/is/an/url.png", DrinkType.RoseWine, "Lindeman's Rose", 0.125),
            new Drink("this/is/an/url.png", DrinkType.SparklingWine, "Prosecco", 0.10),
            new Drink("this/is/an/url.png", DrinkType.SparklingWine, "Jip & Janneke Champagne", 0.001),
            new Drink("this/is/an/url.png", DrinkType.Cocktail, "Mojito", 0.133),
            new Drink("this/is/an/url.png", DrinkType.Cocktail, "Pina Colada", 0.133),
            new Drink("this/is/an/url.png", DrinkType.Mix, "Jager Bomb", 0.07),
            new Drink("this/is/an/url.png", DrinkType.Mix, "Gin & Tonic", 0.064),
            new Drink("this/is/an/url.png", DrinkType.Mix, "Gimlet", 0.124),
            new Drink("this/is/an/url.png", DrinkType.RumMix, "BaCo", 0.08),
            new Drink("this/is/an/url.png", DrinkType.RumMix, "Dark 'n Stormy", 0.14),
            new Drink("this/is/an/url.png", DrinkType.VodkaMix, "Smirnoff Ice", 0.04),
            new Drink("this/is/an/url.png", DrinkType.VodkaMix, "Bloody Mary", 0.16),
            new Drink("this/is/an/url.png", DrinkType.VodkaMix, "Cosmopolitan", 0.16),
            new Drink("this/is/an/url.png", DrinkType.Rum, "Captain Morgan", 0.35),
            new Drink("this/is/an/url.png", DrinkType.Rum, "Bacardi", 0.35),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Martini", 0.05),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Absinth", 0.80),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Esbjaerg", 0.40),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Absolut Vodka", 0.40),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Grey Goose", 0.40),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Bombay Gin", 0.40),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Gordon's Gin", 0.40),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Roku Japanese Gin", 0.40),
            new Drink("this/is/an/url.png", DrinkType.StrongLiqour, "Southern Comfort", 0.35),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Licor 43", 0.31),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Limoncello", 0.145),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Baileys", 0.17),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Cointreau", 0.40),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Tia Maria", 0.17),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Soju", 0.201),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Grand Marnier", 0.201),
            new Drink("this/is/an/url.png", DrinkType.SweetLiqour, "Malibu", 0.201),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Black Label", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Red Label", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Famous Grouse", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Glen Talloch", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Glenfiddich", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Jameson", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Jack Daniels", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Glenlivet", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Ballantine's", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Chivas Regal", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Hibiki Harmony", 0.43),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Suntory Toki", 0.40),
            new Drink("this/is/an/url.png", DrinkType.Whisky, "Laphroaig", 0.586),
        };

        public static void Initialize()
        {
            // Add users
            Users = new List<User>()
            {
                new User("Siem", "siem@email.nl", "EpicPassword1!", new DateTime(2004, 08, 27)),
                new User("Dylan", "dylan@email.nl", "EpicPassword1!", new DateTime(2002, 05, 22)),
                new User("Mark", "mark@email.nl", "EpicPassword1!", new DateTime(2001, 10, 20)),
                new User("Niels", "niels@email.nl", "EpicPassword1!", new DateTime(2003, 02, 03)),
                new User("Stan", "stan@email.nl", "EpicPassword1!", new DateTime(1969, 04, 20)),
                new User("Merijn", "merijn@email.nl", "EpicPassword1!", new DateTime(2003, 04, 10)),
                new User("Thomas", "thomas@email.nl", "EpicPassword1!", new DateTime(2002, 06, 18)),
            };

            foreach (User user in Users)
            {
                // Give users a match with a random user (including themselves lol)
                user.Matches = new List<Match>();
                user.Matches.Add(new Match()
                {
                    Users = new User[] { user, Users[new Random().Next(Users.Count)] },
                    Messages = new List<Message>(),
                });

                // Give users a list of cities
                user.Cities = new List<string>()
                {
                    "Raalte",
                    "Heeten",
                    "Zwolle",
                    "Broekland",
                    "Mariënheem",
                };
            }

            // Add messages to the match
            foreach (User user in Users)
            {
                // Pick random amount of "uh oh, stinky" pairs between 1 and 15
                int amountOfStinky = new Random().Next(1, 15);
                for (int i = 0; i < amountOfStinky; i++)
                {
                    // User 0 sends a message with the text "uh oh"
                    user.Matches[0].Messages.Add(new Message("uh oh", user.Matches[0].Users[0], DateTime.Now));
                    // User 1 then responds (as expected) with "stinky"
                    user.Matches[0].Messages.Add(new Message("stinky", user.Matches[0].Users[1], DateTime.Now));
                }
            }
        }

    }


}
