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
        public string ProfileImage { get; set; }
        public List<User> Matches { get; set; }
        private List<Drink> _favourites { get; set; }
        private List<Drink> _likes { get; set; }
        private List<Drink> _dislikes { get; set; }

        public int Age => (DateTime.Now.Month<DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day<DateOfBirth.Day)) ? (DateTime.Now.Year - DateOfBirth.Year) - 1 : DateTime.Now.Year - DateOfBirth.Year;


        public User(string name, string email, string password, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Password = password;
            _favourites = new List<Drink>(3);
            _likes = new List<Drink>(5);
            _dislikes = new List<Drink>(3);
            ProfileImage = "dotnet_bot.png";
        }

        public List<Drink> GetFavourites() {
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
            else {
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
            else {
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