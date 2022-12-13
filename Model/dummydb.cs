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
            new Drink("hertog_jan.png", DrinkType.BeerOrPilsener, "Hertog Jan", 0.05),
            new Drink("heineken.png", DrinkType.BeerOrPilsener, "Heineken", 0.05),
            new Drink("kornuit.png", DrinkType.BeerOrPilsener, "Kornuit", 0.05),
            new Drink("amstel.png", DrinkType.BeerOrPilsener, "Amstel", 0.05),
            new Drink("grolsch.png", DrinkType.BeerOrPilsener, "Grolsch", 0.05),
            new Drink("gladiator.png", DrinkType.BeerOrPilsener, "Gladiator van de Radiator", 0.08),
            new Drink("klok.png", DrinkType.BeerOrPilsener, "Klok op Kamertemperatuur", 0.048),
            new Drink("export.png", DrinkType.BeerOrPilsener, "Export", 0.047),
            new Drink("la_chouffe.png", DrinkType.CraftBeer, "La Choufe", 0.08),
            new Drink("tripel_karmeliet.png", DrinkType.CraftBeer, "Tripel Karmeliet", 0.084),
            new Drink("affligem_blond.png", DrinkType.CraftBeer, "Affligem Blond", 0.067),
            new Drink("skuumkoppe.png", DrinkType.CraftBeer, "Skuumkoppe", 0.06),
            new Drink("guinness.png", DrinkType.CraftBeer, "Guinness", 0.06),
            new Drink("grand_prestige.png", DrinkType.CraftBeer, "Grand Prestige", 0.086),
            new Drink("brand.png", DrinkType.IPA, "Brand", 0.05),
            new Drink("brewdog.png", DrinkType.IPA, "Brewdog", 0.05),
            new Drink("brewdog_punk_ipa.png", DrinkType.IPA, "Punk IPA", 0.05),
            new Drink("radler.png", DrinkType.Cider, "Radler", 0.02),
            new Drink("radler0_0.png", DrinkType.Cider, "Radler 0.0", 0.001),
            new Drink("apple_bandit.png", DrinkType.Cider, "Apple Bandit", 0.02),
            new Drink("desperados.png", DrinkType.Cider, "Desperados", 0.045),
            new Drink("liefmans.png", DrinkType.Cider, "Liefmans", 0.05),
            new Drink("merlot.png", DrinkType.RedWine, "Undurraga Merlot", 0.15),
            new Drink("lindeman.png", DrinkType.RedWine, "Lindeman's Merlot", 0.15),
            new Drink("gluwijn.png", DrinkType.RedWine, "AH Gluhwein", 0.15),
            new Drink("jacob.png", DrinkType.RedWine, "Jacobs Creek Merlot", 0.15),
            new Drink("mooi.png", DrinkType.RedWine, "Mooi Kaap Droë rooi", 0.15),
            new Drink("slurp.png", DrinkType.WhiteWine, "Slurp! Chardonnay", 0.125),
            new Drink("fatbastard.png", DrinkType.WhiteWine, "Fat Bastard Chardonnay", 0.125),
            new Drink("creek.png", DrinkType.WhiteWine, "Jacobs Creek Chardonnay", 0.125),
            new Drink("mooikaap.png", DrinkType.WhiteWine, "Mooi Kaap Droë steen", 0.125),
            new Drink("Wild_Pig_Chardonnay.png", DrinkType.WhiteWine, "Wild Pig Chardonnay", 0.125),
            new Drink("Slurp_Rose.png", DrinkType.RoseWine, "Slurp! Rose", 0.125),
            new Drink("Mooi_Kaap_Rose.png", DrinkType.RoseWine, "Mooi Kaap Rose", 0.125),
            new Drink("Welmoed_Rose.png", DrinkType.RoseWine, "Welmoed Rose", 0.125),
            new Drink("Undurraga_Rose.png", DrinkType.RoseWine, "Undurraga Rose", 0.125),
            new Drink("La_Tulipe_Rose.png", DrinkType.RoseWine, "La Tulipe Rose", 0.125),
            new Drink("Lindemans_Rose.png", DrinkType.RoseWine, "Lindeman's Rose", 0.125),
            new Drink("Prosecco.png", DrinkType.SparklingWine, "Prosecco", 0.10),
            new Drink("Jip_Janneke.png", DrinkType.SparklingWine, "Jip & Janneke Champagne", 0.001),
            new Drink("Mojito.png", DrinkType.Cocktail, "Mojito", 0.133),
            new Drink("Pina Colada.png", DrinkType.Cocktail, "Pina Colada", 0.133),
            new Drink("Jagerbomb.png", DrinkType.Mix, "Jager Bomb", 0.07),
            new Drink("Gin_Tonic.png", DrinkType.Mix, "Gin & Tonic", 0.064),
            new Drink("Gimlet.png", DrinkType.Mix, "Gimlet", 0.124),
            new Drink("BaCo.png", DrinkType.RumMix, "BaCo", 0.08),
            new Drink("Dark_n_Stormy.png", DrinkType.RumMix, "Dark 'n Stormy", 0.14),
            new Drink("Smirnoff_Ice.png", DrinkType.VodkaMix, "Smirnoff Ice", 0.04),
            new Drink("Bloody_Mary.png", DrinkType.VodkaMix, "Bloody Mary", 0.16),
            new Drink("Cosmopolitan.png", DrinkType.VodkaMix, "Cosmopolitan", 0.16),
            new Drink("Captain_Morgan.png", DrinkType.Rum, "Captain Morgan", 0.35),
            new Drink("Bacardi.png", DrinkType.Rum, "Bacardi", 0.35),
            new Drink("Martini.png", DrinkType.StrongLiqour, "Martini", 0.05),
            new Drink("Absinth.png", DrinkType.StrongLiqour, "Absinth", 0.66),
            new Drink("Esbjaerg.png", DrinkType.StrongLiqour, "Esbjaerg", 0.40),
            new Drink("Absolut_Vodka.png", DrinkType.StrongLiqour, "Absolut Vodka", 0.40),
            new Drink("Grey_Goose.png", DrinkType.StrongLiqour, "Grey Goose", 0.40),
            new Drink("Bombay_Gin.png", DrinkType.StrongLiqour, "Bombay Gin", 0.40),
            new Drink("Gordons_Gin.png", DrinkType.StrongLiqour, "Gordon's Gin", 0.40),
            new Drink("Roku_Japanese_Gin.png", DrinkType.StrongLiqour, "Roku Japanese Gin", 0.40),
            new Drink("Southern_Comfort.png", DrinkType.StrongLiqour, "Southern Comfort", 0.35),
            new Drink("Licor_43.png", DrinkType.SweetLiqour, "Licor 43", 0.31),
            new Drink("Limoncello.png", DrinkType.SweetLiqour, "Limoncello", 0.145),
            new Drink("Baileys.png", DrinkType.SweetLiqour, "Baileys", 0.17),
            new Drink("Cointreau.png", DrinkType.SweetLiqour, "Cointreau", 0.40),
            new Drink("Tia_Maria.png", DrinkType.SweetLiqour, "Tia Maria", 0.17),
            new Drink("Soju.png", DrinkType.SweetLiqour, "Soju", 0.201),
            new Drink("Grand_Marnier.png", DrinkType.SweetLiqour, "Grand Marnier", 0.201),
            new Drink("Malibu.png", DrinkType.SweetLiqour, "Malibu", 0.201),
            new Drink("Black_Label.png", DrinkType.Whisky, "Black Label", 0.40),
            new Drink("Red_Label.png", DrinkType.Whisky, "Red Label", 0.40),
            new Drink("Famous_Grouse.png", DrinkType.Whisky, "Famous Grouse", 0.40),
            new Drink("Glen_Talloch.png", DrinkType.Whisky, "Glen Talloch", 0.40),
            new Drink("Glenfiddich.png", DrinkType.Whisky, "Glenfiddich", 0.40),
            new Drink("Jameson.png", DrinkType.Whisky, "Jameson", 0.40),
            new Drink("Jack_Daniels.png", DrinkType.Whisky, "Jack Daniels", 0.40),
            new Drink("Glenlivet.png", DrinkType.Whisky, "Glenlivet", 0.40),
            new Drink("Ballantines.png", DrinkType.Whisky, "Ballantine's", 0.40),
            new Drink("Chivas_Regal.png", DrinkType.Whisky, "Chivas Regal", 0.40),
            new Drink("Hibiki_Harmony.png", DrinkType.Whisky, "Hibiki Harmony", 0.43),
            new Drink("Suntory_Toki.png", DrinkType.Whisky, "Suntory Toki", 0.40),
            new Drink("Laphroaig.png", DrinkType.Whisky, "Laphroaig", 0.586),
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


            // Give users drink prefferences
            for (int i = 0; i < Users.Count(); i++)
            {

                Users[i].AddToFavourites(dummydb.Drinks[0]);
                Users[i].AddToFavourites(dummydb.Drinks[1]);
                Users[i].AddToLikes(dummydb.Drinks[6]);
                Users[i].AddToLikes(dummydb.Drinks[8]);
                Users[i].AddToLikes(dummydb.Drinks[4]);
                Users[i].AddToDislikes(dummydb.Drinks[3]);
                Users[i].AddToDislikes(dummydb.Drinks[5]);
            }

            foreach (User user in Users)
            {
                // Give users a match with a random user (including themselves lol)
                user.Matches = new List<Match>();
                user.Matches.Add(new Match(new User[] { user, Users[new Random().Next(Users.Count)] }, new List<Message>()));
                

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
