using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Model
{
    public class User
    {
        private string _name;
        private string _email;
        private DateTime _dateOfBirth;

        public string Name
        {
            get { return _name; }
            set
            {
                if (!IsNameValid(value))
                {
                    throw new Exception("NAME INCORRECT");
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
                    throw new Exception("EMAIL INVALID");
                }
                _email = value;
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (!CheckAge(value) || !IsDateOfBirthValid(value))
                {
                    throw new Exception("INVALID BIRTH DATE");
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


        public User(string name, string email, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            _favourites = new List<Drink>(3);
            _likes = new List<Drink>(5);
            _dislikes = new List<Drink>(3);
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
        /// Verifies that the given date is not in the future.
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
            return new User("dummyUser", "email@email.com", new DateTime(1999, 1, 1));
        }
    }
}