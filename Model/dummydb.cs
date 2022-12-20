using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class dummydb
    {
        public static List<User> Users;

        public static List<Drink> Drinks;

        public static void Initialize()
        {
            // Add drinks
            Drinks = new List<Drink>()
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
                new Drink("wild_pig_chardonnay.png", DrinkType.WhiteWine, "Wild Pig Chardonnay", 0.125),
                new Drink("slurp_rose.png", DrinkType.RoseWine, "Slurp! Rose", 0.125),
                new Drink("mooi_kaap_rose.png", DrinkType.RoseWine, "Mooi Kaap Rose", 0.125),
                new Drink("welmoed_rose.png", DrinkType.RoseWine, "Welmoed Rose", 0.125),
                new Drink("undurraga_rose.png", DrinkType.RoseWine, "Undurraga Rose", 0.125),
                new Drink("la_tulipe_rose.png", DrinkType.RoseWine, "La Tulipe Rose", 0.125),
                new Drink("lindemans_rose.png", DrinkType.RoseWine, "Lindeman's Rose", 0.125),
                new Drink("prosecco.png", DrinkType.SparklingWine, "Prosecco", 0.10),
                new Drink("jip_janneke.png", DrinkType.SparklingWine, "Jip & Janneke Champagne", 0.001),
                new Drink("mojito.png", DrinkType.Cocktail, "Mojito", 0.133),
                new Drink("pina_colada.png", DrinkType.Cocktail, "Pina Colada", 0.133),
                new Drink("jagerbomb.png", DrinkType.Mix, "Jager Bomb", 0.07),
                new Drink("gin_tonic.png", DrinkType.Mix, "Gin & Tonic", 0.064),
                new Drink("gimlet.png", DrinkType.Mix, "Gimlet", 0.124),
                new Drink("baco.png", DrinkType.RumMix, "BaCo", 0.08),
                new Drink("dark_n_stormy.png", DrinkType.RumMix, "Dark 'n Stormy", 0.14),
                new Drink("smirnoff_ice.png", DrinkType.VodkaMix, "Smirnoff Ice", 0.04),
                new Drink("bloody_mary.png", DrinkType.VodkaMix, "Bloody Mary", 0.16),
                new Drink("cosmopolitan.png", DrinkType.VodkaMix, "Cosmopolitan", 0.16),
                new Drink("captain_morgan.png", DrinkType.Rum, "Captain Morgan", 0.35),
                new Drink("bacardi.png", DrinkType.Rum, "Bacardi", 0.35),
                new Drink("martini.png", DrinkType.StrongLiqour, "Martini", 0.05),
                new Drink("absinth.png", DrinkType.StrongLiqour, "Absinth", 0.66),
                new Drink("esbjaerg.png", DrinkType.StrongLiqour, "Esbjaerg", 0.40),
                new Drink("absolut_vodka.png", DrinkType.StrongLiqour, "Absolut Vodka", 0.40),
                new Drink("rrey_goose.png", DrinkType.StrongLiqour, "Grey Goose", 0.40),
                new Drink("bombay_gin.png", DrinkType.StrongLiqour, "Bombay Gin", 0.40),
                new Drink("gordons_gin.png", DrinkType.StrongLiqour, "Gordon's Gin", 0.40),
                new Drink("roku_japanese_gin.png", DrinkType.StrongLiqour, "Roku Japanese Gin", 0.40),
                new Drink("southern_comfort.png", DrinkType.StrongLiqour, "Southern Comfort", 0.35),
                new Drink("licor_43.png", DrinkType.SweetLiqour, "Licor 43", 0.31),
                new Drink("limoncello.png", DrinkType.SweetLiqour, "Limoncello", 0.145),
                new Drink("baileys.png", DrinkType.SweetLiqour, "Baileys", 0.17),
                new Drink("cointreau.png", DrinkType.SweetLiqour, "Cointreau", 0.40),
                new Drink("tia_maria.png", DrinkType.SweetLiqour, "Tia Maria", 0.17),
                new Drink("soju.png", DrinkType.SweetLiqour, "Soju", 0.201),
                new Drink("grand_marnier.png", DrinkType.SweetLiqour, "Grand Marnier", 0.201),
                new Drink("malibu.png", DrinkType.SweetLiqour, "Malibu", 0.201),
                new Drink("black_label.png", DrinkType.Whisky, "Black Label", 0.40),
                new Drink("red_label.png", DrinkType.Whisky, "Red Label", 0.40),
                new Drink("famous_grouse.png", DrinkType.Whisky, "Famous Grouse", 0.40),
                new Drink("glen_talloch.png", DrinkType.Whisky, "Glen Talloch", 0.40),
                new Drink("glenfiddich.png", DrinkType.Whisky, "Glenfiddich", 0.40),
                new Drink("jameson.png", DrinkType.Whisky, "Jameson", 0.40),
                new Drink("jack_daniels.png", DrinkType.Whisky, "Jack Daniels", 0.40),
                new Drink("glenlivet.png", DrinkType.Whisky, "Glenlivet", 0.40),
                new Drink("ballantines.png", DrinkType.Whisky, "Ballantine's", 0.40),
                new Drink("chivas_regal.png", DrinkType.Whisky, "Chivas Regal", 0.40),
                new Drink("hibiki_harmony.png", DrinkType.Whisky, "Hibiki Harmony", 0.43),
                new Drink("suntory_toki.png", DrinkType.Whisky, "Suntory Toki", 0.40),
                new Drink("laphroaig.png", DrinkType.Whisky, "Laphroaig", 0.586),
            };

            // Add users WITH drink preferences
            Users = new List<User>()
            {
                GeneratePreferences(new User("Bier Hater", "ik@haat.bier", "Bi3r!H@@t", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                        ["favs"] = new string[] { "Apple Bandit", "Radler", "Desperados" },
                        ["like"] = new string[] { "Slurp! Chardonnay", "BaCo", "Gimlet" },
                        ["hate"] = new string[] { "Gladiator van de Radiator", "Klok op Kamertemperatuur", "Export" },
                }),
                GeneratePreferences(new User("Stan", "stan@email.nl", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan", "Licor 43", "Guinness" },
                    ["like"] = new string[] { "Heineken", "Jager Bomb", "Bacardi", "Martini", "Esbjaerg" },
                    ["hate"] = new string[] { "Gin & Tonic", "Mooi Kaap Droë rooi", "Bloody Mary" },
                }),
                GeneratePreferences(new User("Siem", "siem@email.nl", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan", "Radler" },
                    ["like"] = new string[] { "Mojito", "Absinth", "Cosmopolitan", "Bombay Gin", "Smirnoff Ice" },
                    ["hate"] = new string[] { "Martini", "BaCo", "Slurp! Rose" },
                }),
                GeneratePreferences(new User("Mark", "mark@email.nl", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Heineken", "Desperados", "BaCo" },
                    ["like"] = new string[] { "Captain Morgan", "Grolsch", "Jager Bomb", "Pina Colada", "AH Gluhwein" },
                    ["hate"] = new string[] { "Smirnoff Ice", "Bloody Mary", "Klok op Kamertemperatuur" },
                }),
                GeneratePreferences(new User("Merijn", "merijn@email.nl", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Klok op Kamertemperatuur", "Gladiator van de Radiator", "Absinth" },
                    ["like"] = new string[] { "Welmoed Rose", "Slurp! Rose", "Slurp! Chardonnay", "Mojito", "Brand" },
                    ["hate"] = new string[] { "Gimlet", "Gin & Tonic", "Radler" },
                }),
                GeneratePreferences(new User("Thomas", "thomas@email.nl", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Liefmans", "Apple Bandit" },
                    ["like"] = new string[] { "Grolsch", "Hertog Jan", "Guinness", "Jager Bomb", "Smirnoff Ice" },
                    ["hate"] = new string[] { "AH Gluhwein" },
                }),
                GeneratePreferences(new User("Niels", "niels@email.nl", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan", "Desperados" },
                    ["like"] = new string[] { "Gin & Tonic", "Smirnoff Ice", "Grolsch", "Slurp! Rose" },
                    ["hate"] = new string[] { "AH Gluhwein", "Undurraga Merlot", "Jacobs Creek Merlot" },
                }),
                GeneratePreferences(new User("Dylan", "dylan@email.nl", "EpicPassword1!", new DateTime(1997, 07, 25)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Grand Prestige", "Hibiki Harmony", "Mojito" },
                    ["like"] = new string[] { "Hertog Jan", "Brand", "Soju", "Glenlivet", "Glenfiddich" },
                    ["hate"] = new string[] { "Licor 43", "Jameson", "Jack Daniels" },
                }),
                GeneratePreferences(new User("Karen", "karen.b@zuypr.com", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Gladiator van de Radiator", "Klok op Kamertemperatuur", "Export" },
                    ["like"] = new string[] { "Grolsch", "Amstel", "Kornet", "Heineken", "Hertog Jan" },
                    ["hate"] = new string[] { "Apple Bandit", "Radler", "Desperados" },
                }),
                GeneratePreferences(new User("Bea Tricks", "b.tricks@pils.nl", "IkGaH@rdIkGaL3kker", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Malibu", "Prosecco", "Jager Bomb" },
                    ["like"] = new string[] { "Absinth", "Gin & Tonic", "Fat Bastard Chardonnay", "Black Label", "Amstel" },
                    ["hate"] = new string[] { "Hertog Jan", "AH Gluhwein", "Slurp! Rose" },
                }),
                GeneratePreferences(new User("Amalia", "amalia@pils.nl", "Pr!nc3ssPils", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Absinth" },
                    ["like"] = new string[] { "Red Label" },
                    ["hate"] = new string[] { "Radler", "Apple Bandit" },
                }),
                GeneratePreferences(new User("Alexia", "alexia@pils.nl", "Pr!nc3ssPils", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Martini" },
                    ["like"] = new string[] { "Black Label" },
                    ["hate"] = new string[] { "Grey Goose", "Apple Bandit" },
                }),
                GeneratePreferences(new User("Ariane", "ariane@pils.nl", "Pr!nc3ssPils", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Jip & Janneke Champagne" },
                    ["like"] = new string[] { "Radler 0.0" },
                    ["hate"] = new string[] { "AH Gluhwein" },
                }),
                GeneratePreferences(new User("Prins Pils", "prins@pils.nl", "Pr!nsDerP1lsen", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Amstel" },
                    ["like"] = new string[] { "Brewdog", "Punk IPA", "BaCo", "Captain Morgan", "Martini" },
                    ["hate"] = new string[] { "AH Gluhwein", "Cosmopolitan", "Bloody Mary" },
                }),
                GeneratePreferences(new User("Koning Pils", "koning@pils.nl", "Kon!ngDerP1lsen", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan" },
                    ["like"] = new string[] { "Affligem Blond", "Guinness", "Grand Prestige", "Brand", "Gladiator van de Radiator" },
                    ["hate"] = new string[] { "AH Gluhwein", "Prosecco"},
                })
            };

            foreach (User user in Users)
            {
                // Give users a match with a random user (including themselves lol)
                user.Matches = new List<Match>();
                user.Matches.Add(new Match(new User[] { user, Users[new Random().Next(Users.Count)] }, new List<Message>()));


                // Give users a list of cities
                user.Cities = new List<City>()
                {
                    new ("Raalte"),
                    new ("Heeten"),
                    new ("Zwolle"),
                    new ("Broekland"),
                    new ("Mariënheem")
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

        public static User GeneratePreferences(User user, Dictionary<String, String[]> prefs)
        {
            foreach ((String group, String[] list) in prefs)
            {
                foreach (String name in list)
                {
                    Drink drink = Drinks.FirstOrDefault(a => a.Name == name);
                    if (group == "favs")
                    {
                        user.AddToFavourites(drink);
                    }
                    else if (group == "like")
                    {
                        user.AddToLikes(drink);
                    }
                    else if (group == "hate")
                    {
                        user.AddToDislikes(drink);
                    }
                }
            }
            return user;
        }
    }
}