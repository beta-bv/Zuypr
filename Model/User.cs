using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Cryptography;

namespace Model
{
    public class User
    {
        private string _name;
        private string _email;
        private DateTime _dateOfBirth;
        private string _password;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!IsNameValid(value))
                {
                    throw new ArgumentException("Je hebt geen valide naam ingevuld");
                }
                _name = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!new EmailAddressAttribute().IsValid(value))
                {
                    throw new ArgumentException("Je hebt geen valide emailadres ingevuld");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Stores the <see cref="SHA256">SHA256</see> hash of the password
        /// <para>The getter automatically hashes the given password string</para>
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                if (value != null && value != "")
                {
                    // Check for password requirements
                    if (!(value.Length >= 8 && value.Any(char.IsUpper) && value.Any(a => !char.IsLetterOrDigit(a) && !char.IsWhiteSpace(a))))
                    {
                        throw new ArgumentException("Wachtwoord moet minstens acht tekens lang zijn, met minstens één hoofdletter en één speciaal teken");
                    }
                    // Hash the input string using SHA256
                    _password = HashString(value);
                }
                else
                {
                    throw new ArgumentException("Wachtwoord is ongeldig");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (!IsDateOfBirthValid(value))
                {
                    throw new ArgumentException("Je mag geen datum selecteren uit de toekomst");
                }
                else if (!CheckAge(value))
                {
                    throw new ArgumentException("Je moet minstens achttien jaar oud zijn om te mogen regristreren");
                }

                _dateOfBirth = value;
            }
        }

        public List<string> Cities { get; set; }
        public Bitmap ProfielImage { get; set; }
        public List<User> Matches { get; set; }
        private List<Drink> _favourites { get; set; }
        private List<Drink> _likes { get; set; }
        private List<Drink> _dislikes { get; set; }

        public User(string name, string email, string password, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Password = password;
            _favourites = new List<Drink>(3);
            _likes = new List<Drink>(5);
            _dislikes = new List<Drink>(3);
        }

        public List<Drink> GetFavourites()
        {
            return _favourites;
        }

        public List<Drink> GetLikes()
        {
            return _likes;
        }

        public List<Drink> GetDislikes()
        {
            return _dislikes;
        }

        /// <summary>
        /// Checks if a drink already is in a given list Favourites, Likes or dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <param name="drinkList"></param>
        /// <returns></returns>
        public bool CheckIfInList(Drink drink, List<Drink> drinkList)
        {
            return drinkList.Contains(drink);
        }

        /// <summary>
        /// Checks if a given list Favourites, Likes or dislikes is full.
        /// </summary>
        /// <param name="drinkList"></param>
        /// <returns></returns>
        public bool CheckIfListIsFull(List<Drink> drinkList)
        {
            int capacity = drinkList.Capacity;
            int size = drinkList.Count();
            return size == capacity;
        }

        /// <summary>
        /// Adds a drink to a given list Favourites, Likes or dislikes. 
        /// </summary>
        /// <param name="drink"></param>
        /// <param name="drinkList"></param>
        /// <returns></returns>
        public bool AddToDrinkList(Drink drink, List<Drink> drinkList)
        {
            if (CheckIfInList(drink, drinkList) || CheckIfListIsFull(drinkList))
            {
                return false;
            }
            else
            {
                RemoveFromDrinkList(drink);
                drinkList.Add(drink);
                return true;
            }
        }

        /// <summary>
        /// Add a drink to the list _favourites.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToFavourites(Drink drink)
        {
            return AddToDrinkList(drink, _favourites);
        }

        /// <summary>
        /// Add a drink to the list _likes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToLikes(Drink drink)
        {
            return AddToDrinkList(drink, _likes);
        }

        /// <summary>
        /// Add a drink to the list _dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToDislikes(Drink drink)
        {
            return AddToDrinkList(drink, _dislikes);
        }

        /// <summary>
        /// Removes a drink from the given list Favourites, Likes or Dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <param name="drinkList"></param>
        /// <returns></returns>
        public bool RemoveFromDrinkList(Drink drink)
        {
            if (_favourites.Contains(drink))
            {
                _favourites.Remove(drink);
                return true;
            }
            else if (_likes.Contains(drink))
            {
                _likes.Remove(drink);
                return true;
            }
            else if (_dislikes.Contains(drink))
            {
                _dislikes.Remove(drink);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks the age to be 18 or older.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth</param>
        /// <returns></returns>
        public static bool CheckAge(DateTime dateOfBirth)
        {
            DateTime dateNow = DateTime.Now;

            if (dateOfBirth.AddYears(18).CompareTo(dateNow) > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// compares two passwords
        /// </summary>
        /// <param name="password1"></param>
        /// <param name="password2"></param>
        /// <returns></returns>
        public static bool ComparePasswords(string password1, string password2)
        {
            password1 = HashString(password1);
            password2 = HashString(password2);

            if (password1.Equals(password2))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// hashed a given string using SHA256
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string HashString(string stringToHash)
        {
            // Hash the input string using SHA256
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(stringToHash);
            byte[] hashedBytes = SHA256.HashData(textBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", String.Empty);
        }

        /// <summary>
        /// Checks if a name is not empty or longer than 50 characters and only allows letters and spaces.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsNameValid(string name)
        {
            name = name.Trim();
            return (name.Length > 0 && name.Length <= 50 && name.All(a => char.IsLetter(a) || a == ' '));
        }

        /// <summary>
        /// Verifies that the given date is not in the future.x
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateOfBirthValid(DateTime date)
        {
            DateTime dateNow = DateTime.Now;
            return date < dateNow;
        }

        /// <summary>
        /// Creates a dummy user
        /// </summary>
        /// <returns></returns>
        public static User GetDummyUser()
        {
            return new User("dummyUser", "email@hotmail.com", "Pass123!", new DateTime(1999, 1, 1));
        }

        /// <summary>
        /// Gets all Users from the database
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsersFromDatabase()
        {
            List<User> Collection = new List<User>
            {
                new User("Henk", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                    .GeneratePreferences(new Dictionary<string, string[]>
                    {
                        ["favs"] = new string[] { "Brand", "Brewdog", "Punk IPA" },
                        ["like"] = new string[] { "Radler", "La Choufe", "Skuumkoppe", "Heineken", "Slurp! Rose" },
                        ["hate"] = new string[] { "Slurp! Chardonnay", "BaCo", "Gimlet" },
                    }
                ),
                new User("Bier Hater", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                    .GeneratePreferences(new Dictionary<string, string[]>
                    {
                    ["favs"] = new string[] { "Apple Bandit", "Radler", "Desperados" },
                    ["like"] = new string[] { "Slurp! Chardonnay", "BaCo", "Gimlet" },
                    ["hate"] = new string[] { "Gladiator van de Radiator", "Klok op Kamertemperatuur", "Export" },
                    }
                ),
                new User("Willem", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Klok op Kamertemperatuur", "Mojito", "Jager Bomb" },
                    ["like"] = new string[] { "Pina Colada", "BaCo", "Gimlet", "Slurp! Rose", "Amstel" },
                    ["hate"] = new string[] { "AH Gluhwein", "Captain Morgan", "Smirnoff Ice" },
                }),
                new User("Stan", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan", "Licor 43", "Guinness" },
                    ["like"] = new string[] { "Heineken", "Jager Bomb", "Bacardi", "Martini", "Esbjaerg" },
                    ["hate"] = new string[] { "Gin & Tonic", "Mooi Kaap Droë rooi", "Bloody Mary" },
                }),
                new User("Siem", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan", "Radler" },
                    ["like"] = new string[] { "Mojito", "Absinth", "Cosmopolitan", "Bombay Gin", "Smirnoff Ice" },
                    ["hate"] = new string[] { "Martini", "BaCo", "Slurp! Rose" },
                }),
                new User("Mark", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Heineken", "Desperados", "BaCo" },
                    ["like"] = new string[] { "Captain Morgan", "Grolsch", "Jager Bomb", "Pina Colada", "AH Gluhwein" },
                    ["hate"] = new string[] { "Smirnoff Ice", "Bloody Mary", "Klok op Kamertemperatuur" },
                }),
                new User("Merijn", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Klok op Kamertemperatuur", "Gladiator van de Radiator", "Absinth" },
                    ["like"] = new string[] { "Welmoed Rose", "Slurp! Rose", "Slurp! Chardonnay", "Mojito", "Brand" },
                    ["hate"] = new string[] { "Gimlet", "Gin & Tonic", "Radler" },
                }),
                new User("Thomas", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Liefmans", "Apple Bandit" },
                    ["like"] = new string[] { "Grolsch", "Hertog Jan", "Guinness", "Jager Bomb", "Smirnoff Ice" },
                    ["hate"] = new string[] { "AH Gluhwein" },
                }),
                new User("Niels", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan", "Desperados" },
                    ["like"] = new string[] { "Gin & Tonic", "Smirnoff Ice", "Grolsch", "Slurp! Rose" },
                    ["hate"] = new string[] { "AH Gluhwein", "Undurraga Merlot", "Jacobs Creek Merlot" },
                }),
                new User("Dylan", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Grand Prestige", "Hibiki Harmony", "Mojito" },
                    ["like"] = new string[] { "Hertog Jan", "Brand", "Soju", "Glenlivet", "Glenfiddich" },
                    ["hate"] = new string[] { "Licor 43", "Jameson", "Jack Daniels" },
                }),
                new User("Bea Tricks", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Malibu", "Prosecco", "Jager Bomb" },
                    ["like"] = new string[] { "Absinth", "Gin & Tonic", "Fat Bastard Chardonnay", "Black Label", "Amstel" },
                    ["hate"] = new string[] { "Hertog Jan", "AH Gluhwein", "Slurp! Rose" },
                }),
                new User("Karen", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Gladiator van de Radiator", "Klok op Kamertemperatuur", "Export" },
                    ["like"] = new string[] { "Grolsch", "Amstel", "Kornet", "Heineken", "Hertog Jan" },
                    ["hate"] = new string[] { "Apple Bandit", "Radler", "Desperados" },
                }),
                new User("Amalia", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Absinth" },
                    ["like"] = new string[] { "Red Label" },
                    ["hate"] = new string[] { "Radler", "Apple Bandit" },
                }),
                new User("Alexia", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Martini" },
                    ["like"] = new string[] { "Black Label" },
                    ["hate"] = new string[] { "Grey Goose", "Apple Bandit" },
                }),
                new User("Ariane", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Jip & Janneke Champagne" },
                    ["like"] = new string[] { "Radler 0.0" },
                    ["hate"] = new string[] { "AH Gluhwein" },
                }),
                new User("Prins Pils", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Amstel" },
                    ["like"] = new string[] { "Brewdog", "Punk IPA", "BaCo", "Captain Morgan", "Martini" },
                    ["hate"] = new string[] { "AH Gluhwein", "Cosmopolitan", "Bloody Mary" },
                }),
                new User("Koning Pils", "a@a.a", "w8Woord!", new DateTime(2000, 1, 1))
                .GeneratePreferences(new Dictionary<string, string[]>
                {
                    ["favs"] = new string[] { "Hertog Jan" },
                    ["like"] = new string[] { "Affligem Blond", "Guinness", "Grand Prestige", "Brand", "Gladiator van de Radiator" },
                    ["hate"] = new string[] { "AH Gluhwein", "Prosecco"},
                })
            };

            return Collection;
        }

        public User GeneratePreferences(Dictionary<String, String[]> prefs)
        {
            List<Drink> drinks = Drink.getAllDrinks();

            foreach ((String group, String[] list) in prefs)
            {
                foreach (String name in list)
                {
                    Drink drink = drinks.FirstOrDefault(a => a.Name == name);
                    if (group == "favs")
                    {
                        this.AddToFavourites(drink);
                    }
                    else if (group == "like")
                    {
                        this.AddToLikes(drink);
                    }
                    else if (group == "hate")
                    {
                        this.AddToDislikes(drink);
                    }
                }
            }
            return this;
        }

        public List<User> GeneratePotentialMatches()
        {
            double passing_score = 0.56;
            List<User> Collection = new List<User>();

            Console.WriteLine($"total: {GetAllUsersFromDatabase().Count}");

            foreach (User user in GetAllUsersFromDatabase())
            {
                // TODO: Some matches are still scored above 100% due to some fuckery with matching drink types
                // TODO: Fix later???
                // FIXME: Holy fuck this is broken
                double score = this.GetMatchScore(user);

                Console.WriteLine($"{user.Name} > {score}");

                if (score >= passing_score)
                {
                    Collection.Add(user);
                }
            }

            Console.WriteLine($"matches: {Collection.Count}");

            return Collection;
        }


        /// <summary>
        /// Checks whether a list of drinks of another user includes the drinks from your own list
        /// </summary>
        /// <param name="myDrinks">A list of drinks</param>
        /// <param name="theirDrinks">A list of drinks</param>
        /// <param name="points">Defines how many points a match is worth</param>
        /// <returns>Returns the earned points</returns>
        private static double GetExactDrinkMatches(List<Drink> myDrinks, List<Drink> theirDrinks, double points)
        {
            double score = 0;

            foreach (Drink myDrink in myDrinks)
            {
                if (theirDrinks.Contains(myDrink))
                {
                    score += points;
                }
            }
            return score;
        }

        /// <summary>
        /// Checks whether a list of drinkstypes of another user includes the drinktypes from your own list
        /// </summary>
        /// <param name="myTypes">A list of drinks</param>
        /// <param name="theirTypes">A list of drinks</param>
        /// <param name="multiplier">Defines how many points the type match should be multiplied with</param>
        /// <returns>Returns the earned points</returns>
        private static double GetTypeDrinkMatches(Dictionary<DrinkType, int> myTypes, Dictionary<DrinkType, int> theirTypes, double multiplier)
        {
            double score = 0;
            foreach ((DrinkType type, int myCount) in myTypes)
            {
                if (theirTypes.ContainsKey(type))
                {
                    int theirCount = theirTypes[type];
                    if (myCount <= theirCount)
                    {
                        score += myCount * multiplier;
                    }
                    else
                    {
                        score += theirCount * multiplier;
                    }
                }
            }
            return score;
        }

        /// <summary>
        /// Calculates the similarity between the current and provided user.
        /// </summary>
        /// <param name="user">The user to base the similarity on</param>
        /// <returns>Returns the score of the match</returns>
        public double GetMatchScore(User user)
        {
            // Setting how much influence on the final score each type of match has
            // Exact matches are worth 60%
            // TODO: Adjust scores where needed
            double exact_match_influence = 0.80;
            double type_match_influence = 1.0 - exact_match_influence;
            double favourite_influence = 0.6;
            double liked_influence = 0.3;
            double disliked_influence = 0.3;

            double exact_points = 0.0;
            double type_points = 0.0;
            double score = 0.0;

            // How much a certain match is rewarded or penalized
            double positive_match_score = 1.0;
            double semi_positive_match_score = 0.75;
            double negative_match_score = -1.0;
            double semi_negative_match_score = -0.5;

            List<Drink> myFavourites = this.GetFavourites();
            List<Drink> myLikes = this.GetLikes();
            List<Drink> myDislikes = this.GetDislikes();

            // Creating a dictionary with totals of each drinktype
            // Example:
            // myLikedTypes => {
            //     [DrinkType.Mix] = 2,
            //     [DrinkType.IPA] = 1,
            //     [DrinkType.CraftBeer] = 1,
            // };
            // theirDislikedTypes => {
            //     [DrinkType.RedWine] = 2,
            //     [DrinkType.SweetLiqour] = 1
            // };
            Dictionary<DrinkType, int> myFavouriteTypes = myFavourites.GroupBy(d => d.Type)
                .Select(t => new { t.Key, value = t.Count() })
                .ToDictionary(pair => pair.Key, pair => pair.value);
            Dictionary<DrinkType, int> myLikedTypes = myLikes.GroupBy(d => d.Type)
                .Select(t => new { t.Key, value = t.Count() })
                .ToDictionary(pair => pair.Key, pair => pair.value);
            Dictionary<DrinkType, int> myDislikedTypes = myDislikes.GroupBy(d => d.Type)
                .Select(t => new { t.Key, value = t.Count() })
                .ToDictionary(pair => pair.Key, pair => pair.value);

            Dictionary<DrinkType, int> theirFavouriteTypes = user.GetFavourites().GroupBy(d => d.Type)
                .Select(t => new { t.Key, value = t.Count() })
                .ToDictionary(pair => pair.Key, pair => pair.value);
            Dictionary<DrinkType, int> theirLikedTypes = user.GetLikes().GroupBy(d => d.Type)
                .Select(t => new { t.Key, value = t.Count() })
                .ToDictionary(pair => pair.Key, pair => pair.value);
            Dictionary<DrinkType, int> theirDislikedTypes = user.GetDislikes().GroupBy(d => d.Type)
                .Select(t => new { t.Key, value = t.Count() })
                .ToDictionary(pair => pair.Key, pair => pair.value);

            // _score_range      = The range of points a specific comparison can have.
            // _score_normalizer = Absolute value for the lowest possible score
            //                     Will be added to the calculated score to be able to
            //                     project it on the range. So we don't have negative
            //                     numbers
            double favo_exact_score_range = Math.Abs(myFavourites.Count * negative_match_score - myFavourites.Count * positive_match_score);
            double favo_type_score_range = Math.Abs(myFavourites.Count * negative_match_score - myFavourites.Count * positive_match_score - Math.Min(myFavourites.Count, myLikes.Count) * semi_positive_match_score);
            double favo_score_normalizer = Math.Abs(myFavourites.Count * negative_match_score);

            double like_exact_score_range = Math.Abs(myLikes.Count * negative_match_score - myLikes.Count * positive_match_score);
            double like_type_score_range = Math.Abs(myLikes.Count * negative_match_score - myLikes.Count * positive_match_score - Math.Min(myFavourites.Count, myLikes.Count) * semi_positive_match_score);
            double like_score_normalizer = Math.Abs(myLikes.Count * negative_match_score);

            double hate_score_range = Math.Abs(myDislikes.Count * negative_match_score - myDislikes.Count * positive_match_score);
            double hate_score_normalizer = Math.Abs(myDislikes.Count * negative_match_score);

            // Leaving the writeLine statements in for future debugging
            //Console.WriteLine($"fER{favo_exact_score_range} fTR{favo_type_score_range} fN{favo_score_normalizer}");

            // Calculating the score between 2 lists for exact matches
            double f_exact_score = 0;
            f_exact_score += GetExactDrinkMatches(myFavourites, user.GetFavourites(), positive_match_score);
            f_exact_score += GetExactDrinkMatches(myFavourites, user.GetLikes(), semi_positive_match_score);
            f_exact_score += GetExactDrinkMatches(myFavourites, user.GetDislikes(), negative_match_score);

            double l_exact_score = 1;
            l_exact_score += GetExactDrinkMatches(myLikes, user.GetFavourites(), semi_positive_match_score);
            l_exact_score += GetExactDrinkMatches(myLikes, user.GetLikes(), positive_match_score);
            l_exact_score += GetExactDrinkMatches(myLikes, user.GetDislikes(), negative_match_score);

            double d_exact_score = 1;
            d_exact_score += GetExactDrinkMatches(myDislikes, user.GetFavourites(), negative_match_score);
            d_exact_score += GetExactDrinkMatches(myDislikes, user.GetLikes(), semi_negative_match_score);
            d_exact_score += GetExactDrinkMatches(myDislikes, user.GetDislikes(), positive_match_score);

            // Calculating the exact match percentage for each List
            //Console.WriteLine($"Exact Matches");
            //Console.WriteLine($"{favo_exact_score_range} > {like_exact_score_range} > {hate_score_range}");
            //Console.WriteLine($"Favo > {f_exact_score} + {favo_score_normalizer}");
            //Console.WriteLine($"Like > {l_exact_score} + {like_score_normalizer}");
            //Console.WriteLine($"Hate > {d_exact_score} + {hate_score_normalizer}");
            //Console.WriteLine();

            f_exact_score = 1.0 / favo_exact_score_range * (f_exact_score + favo_score_normalizer);
            l_exact_score = 1.0 / like_exact_score_range * (l_exact_score + like_score_normalizer);
            d_exact_score = 1.0 / hate_score_range * (d_exact_score + hate_score_normalizer);
            exact_points += favourite_influence * (1.0 * f_exact_score);
            exact_points += liked_influence * (1.0 * l_exact_score);
            exact_points += disliked_influence * (1.0 * d_exact_score);

            // Calculating the score between 2 lists for similar drinktypes
            double f_type_score = 0;
            f_type_score += GetTypeDrinkMatches(myFavouriteTypes, theirFavouriteTypes, positive_match_score);
            f_type_score += GetTypeDrinkMatches(myFavouriteTypes, theirLikedTypes, semi_positive_match_score);
            f_type_score += GetTypeDrinkMatches(myFavouriteTypes, theirDislikedTypes, negative_match_score);

            double l_type_score = 0;
            l_type_score += GetTypeDrinkMatches(myLikedTypes, theirFavouriteTypes, semi_positive_match_score);
            l_type_score += GetTypeDrinkMatches(myLikedTypes, theirLikedTypes, positive_match_score);
            l_type_score += GetTypeDrinkMatches(myLikedTypes, theirDislikedTypes, negative_match_score);

            double d_type_score = 0;
            d_type_score += GetTypeDrinkMatches(myDislikedTypes, theirFavouriteTypes, negative_match_score);
            d_type_score += GetTypeDrinkMatches(myDislikedTypes, theirLikedTypes, semi_negative_match_score);
            d_type_score += GetTypeDrinkMatches(myDislikedTypes, theirDislikedTypes, positive_match_score);

            // Calculating the exact match percentage for each List
            //Console.WriteLine($"Type Matches");
            //Console.WriteLine($"{favo_type_score_range} > {like_type_score_range} > {hate_score_range}");
            //Console.WriteLine($"Favo > {f_type_score} + {favo_score_normalizer}");
            //Console.WriteLine($"Like > {l_type_score} + {like_score_normalizer}");
            //Console.WriteLine($"Hate > {d_type_score} + {hate_score_normalizer}");
            //Console.WriteLine();

            f_type_score = 1.0 / favo_type_score_range * (f_type_score + favo_score_normalizer);
            l_type_score = 1.0 / like_type_score_range * (l_type_score + like_score_normalizer);
            d_type_score = 1.0 / hate_score_range * (d_type_score + hate_score_normalizer);
            type_points += favourite_influence * (1.0 * f_type_score);
            type_points += liked_influence * (1.0 * l_type_score);
            type_points += disliked_influence * (1.0 * d_type_score);

            //Console.WriteLine($"{type_points}");

            // Final score calculations
            // Each score is multiplied with its influence on the final score.
            score += exact_match_influence * exact_points;
            //score += type_match_influence * type_points;
            score = Math.Round(score, 5);

            return score;
        }

        /// <summary>
        /// Gets User from the database
        /// </summary>
        /// <returns></returns>
        public User GetUserFromDatabase(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUserToDatabase(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates user email
        /// </summary>
        /// <param name="emailNew"></param>
        /// <param name="emailOld"></param>
        /// <returns></returns>
        public bool UpdateUserEmail(string emailNew, string emailOld) //TODO implement het database gedeelte nog
        {
            if (emailOld.Equals(Email) && !emailNew.Equals(emailOld))
            {
                Email = emailNew;
                return true;
            }
            return false;
        }

        /// <summary>
        /// update de password van de gebruiker 
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPasswordField1"></param>
        /// <param name="newPasswordField2"></param>
        /// <returns></returns>
        public bool UpdateUserPassword(string oldPassword, string newPasswordField1, string newPasswordField2) //TODO implement het database gedeelte nog
        {
            if (ComparePasswords(newPasswordField1, newPasswordField2))
            {
                string tempPasswordFieldCombine = newPasswordField1;
                if (Password.Equals(HashString(oldPassword)) && !Password.Equals(HashString(tempPasswordFieldCombine)))
                {
                    Password = newPasswordField1;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveUser()
        {
            throw new NotImplementedException();
        }
    }
}