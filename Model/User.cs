using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Security.Cryptography;

namespace Model
{
    [Table("users")]
    [PrimaryKey("Id")]
    public class User
    {
        private string _name;
        private string _email;
        private DateTime _dateOfBirth;
        private string _password;
        private int _minimumpreferredAge;
        private int _maximumpreferredAge;

        public int MinimumpreferredAge
        {
            get { return _minimumpreferredAge; } //tests
            set
            {
                if (value! < 0 || value! > 120)
                {
                    throw new ArgumentException("Age is not valid");
                }
                if (value < 18)
                {
                    throw new ArgumentException("The preferred age must be 18 or above");
                }
                if (value > MaximumpreferredAge)
                {
                    throw new ArgumentException("your minimum preferred age cannot be smaller than your maximum preferred age");
                }
                _minimumpreferredAge = value;
            }
        }
        public int MaximumpreferredAge
        {
            get { return _maximumpreferredAge; } //tests
            set
            {
                if (value! < 0 || value! > 120)
                {
                    throw new ArgumentException("Age is not valid");
                }
                if (value < 18)
                {
                    throw new ArgumentException("The preferred age must be above 18");
                }
                if (value < MinimumpreferredAge)
                {
                    throw new ArgumentException("your maximum preferred age cannot be larger than your minimum preferred age");
                }
                _maximumpreferredAge = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (!IsNameValid(value))
                {
                    throw new ArgumentException("The name is not valid");
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
                    throw new ArgumentException("Invalid email address");
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
                        throw new ArgumentException("Password needs to be atleast 8 symbols, with atleast 1 capital letter and 1 special symbol");
                    }
                    // Hash the input string using SHA256
                    _password = HashString(value);
                }
                else
                {
                    throw new ArgumentException("Password is invalid");
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
                    throw new ArgumentException("You cannot select a date from the future");
                }
                else if (!CheckAge(value))
                {
                    throw new ArgumentException("You need to be atleast 18 years old to register");
                }

                _dateOfBirth = value;
            }
        }
        public int Id { get; set; }

        public List<City> Cities { get; set; }
        public string ProfileImage { get; set; }
        public List<Match> Matches { get; set; }
        public List<User> LikedUsers { get; set; }

        // HACK: Holy fuck this is broken
        //--- START FUCKERY ---//
        // Using the backing field feature for EntityFramework
        public string FavouriteListStr { get; private set; }
        public string LikeListStr { get; private set; }
        public string DislikeListStr { get; private set; }

        public int[] FavouriteList
        {
            set
            {
                FavouriteListStr = String.Join(",", value);
            }
        }

        public int[] LikeList
        {
            set
            {
                LikeListStr = String.Join(",", value);
            }
        }

        public int[] DislikeList
        {
            set
            {
                DislikeListStr = String.Join(",", value);
            }
        }

        [NotMapped]
        public List<Drink> Favourites
        {
            get => generateList(FavouriteListStr, new List<Drink>(3));
        }

        [NotMapped]
        public List<Drink> Likes
        {
            get => generateList(LikeListStr, new List<Drink>(5));
        }

        [NotMapped]
        public List<Drink> Dislikes
        {
            get => generateList(DislikeListStr, new List<Drink>(3));
        }

        /// <summary>
        /// Transforms a string of comma-sepparated ints to a List of Drinks
        /// </summary>
        /// <param name="indexStr">The string of comma-sepparated indexes</param>
        /// <param name="drinks">The drink list with capacity</param>
        /// <returns></returns>
        private List<Drink> generateList(string indexStr, List<Drink> drinks)
        {
            if (indexStr != null)
            {
                foreach (int i in indexStr.Split(",").Select(i => Int32.Parse(i)).ToArray())
                {
                    drinks.Add(dummydb.Drinks.ElementAt(i));
                }
            }
            return drinks;
        }

        /// <summary>
        /// Generates a string with comma-sepparated Drink indexes
        /// </summary>
        /// <param name="indexStr">The string of comma-sepparated indexes</param>
        /// <param name="drinks">The drink list with capacity</param>
        /// <returns></returns>
        private int[] GenerateIndexStr(ListTypes type, List<Drink> drinks)
        {
            List<int> indexList = new List<int>();
            foreach (Drink drink in drinks)
            {
                int index = dummydb.Drinks.IndexOf(drink);
                indexList.Add(index);
            }
            return indexList.ToArray();
        }

        /// <summary>
        /// Updates the drinkListString to the new generated string
        /// </summary>
        /// <param name="indexStr">The string of comma-sepparated indexes</param>
        /// <param name="drinks">The drink list with capacity</param>
        /// <returns></returns>
        private bool updateIndexStr(ListTypes type, List<Drink> drinks)
        {
            try
            {
                switch (type)
                {
                    case ListTypes.Favourites:
                        FavouriteList = GenerateIndexStr(type, drinks);
                        break;
                    case ListTypes.Likes:
                        LikeList = GenerateIndexStr(type, drinks);
                        break;
                    case ListTypes.Dislikes:
                        DislikeList = GenerateIndexStr(type, drinks);
                        break;
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        //--- END FUCKERY ---//

        public int Age => (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day)) ? (DateTime.Now.Year - DateOfBirth.Year) - 1 : DateTime.Now.Year - DateOfBirth.Year;

        // Exists for EF
        public User() { }
        public User(string name, string email, string password, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Password = password;

            DatabaseContext db = new DatabaseContext();
            ProfileImage = $"https://avatars.dicebear.com/api/identicon/{name}.png?scale=80";
            Cities = new List<City>();
            Matches = db.Matches.Where(m => m.Users.Contains(this)).ToList();
            LikedUsers = new List<User>();
            MaximumpreferredAge = 120;
            MinimumpreferredAge = 18;
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
        /// Checks if the specified DrinkList can take another drink
        /// </summary>
        /// <param name="drink"></param>
        /// <param name="drinkList"></param>
        /// <returns>bool</returns>
        public bool ListCanTakeDrink(Drink drink, List<Drink> drinkList)
        {
            return !CheckIfInList(drink, drinkList) && !CheckIfListIsFull(drinkList);
        }

        /// <summary>
        /// Add a drink to the list Favourites.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToFavourites(Drink drink)
        {
            List<Drink> drinks = Favourites;
            if (ListCanTakeDrink(drink, drinks))
            {
                RemoveFromDrinkList(drink);
                drinks.Add(drink);
                updateIndexStr(ListTypes.Favourites, drinks);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Add a drink to the list Likes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToLikes(Drink drink)
        {
            List<Drink> drinks = Likes;
            if (ListCanTakeDrink(drink, drinks))
            {
                RemoveFromDrinkList(drink);
                drinks.Add(drink);
                updateIndexStr(ListTypes.Likes, drinks);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Add a drink to the list Dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToDislikes(Drink drink)
        {
            List<Drink> drinks = Dislikes;
            if (ListCanTakeDrink(drink, drinks))
            {
                RemoveFromDrinkList(drink);
                drinks.Add(drink);
                updateIndexStr(ListTypes.Dislikes, drinks);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes a drink from the given list Favourites, Likes or Dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool RemoveFromDrinkList(Drink drink)
        {
            if (Favourites.Contains(drink))
            {
                List<Drink> drinks = Favourites;
                drinks.Remove(drink);
                updateIndexStr(ListTypes.Favourites, drinks);
                return true;
            }
            else if (Likes.Contains(drink))
            {
                List<Drink> drinks = Likes;
                drinks.Remove(drink);
                updateIndexStr(ListTypes.Likes, drinks);
                return true;
            }
            else if (Dislikes.Contains(drink))
            {
                List<Drink> drinks = Dislikes;
                drinks.Remove(drink);
                updateIndexStr(ListTypes.Dislikes, drinks);
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

        public static User GetDummyUser()
        {
            User dummy = new User("dummyUser", "email@a.com", "Wachtwoord!", new DateTime(1999, 1, 1));
            dummy.Cities = new List<City>() { new("Dalfsen"), new("Hoonhorst") };
            return dummy;
        }
    }

    public enum ListTypes
    {
        Favourites,
        Likes,
        Dislikes
    }

}