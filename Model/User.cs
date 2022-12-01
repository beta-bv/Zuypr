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
            _favourites = new List<Drink>();
            _likes = new List<Drink>();
            _dislikes = new List<Drink>();
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
        public bool CheckIfInList(Drink drink, List<Drink> drinkList) {

            if (drinkList.Contains(drink))
            {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Checks if a given list Favourites, Likes or dislikes is full.
        /// </summary>
        /// <param name="drinkList"></param>
        /// <returns></returns>
        public bool CheckIfListIsFull(List<Drink> drinkList) {

            int listLength = 0;

            if (drinkList == _favourites)
            {
                listLength = 3;
            }
            else if (drinkList == _likes)
            {
                listLength = 5;
            }
            else if (drinkList == _dislikes)
            {
                listLength = 3;
            }

            if (drinkList.Count() >= listLength)
            {
                return true;
            }
            else {
                return false;
            }

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

            if (AddToDrinkList(drink, _favourites))
            {
                RemoveFromLikes(drink);
                RemoveFromDislikes(drink);
                return true;
            }
            else
            {
                return false;

            }
        }

        /// <summary>
        /// Add a drink to the list _likes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToLikes(Drink drink)
        {

            if (AddToDrinkList(drink, _likes))
            {
                RemoveFromFavourites(drink);
                RemoveFromDislikes(drink);
                return true;
            }
            else
            {
                return false;

            }
        }

        /// <summary>
        /// Add a drink to the list _dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool AddToDislikes(Drink drink)
        {

            if (AddToDrinkList(drink, _dislikes))
            {
                RemoveFromLikes(drink);
                RemoveFromFavourites(drink);
                return true;
            }
            else
            {
                return false;

            }
        }

        /// <summary>
        /// Removes a drink from the given list Favourites, Likes or Dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <param name="drinkList"></param>
        /// <returns></returns>
        public bool RemoveFromDrinkList(Drink drink, List<Drink> drinkList)
        {
            if (CheckIfInList(drink, drinkList))
            {
                drinkList.Remove(drink);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Remove a drink from the list _favourites.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool RemoveFromFavourites(Drink drink)
        {

            if (RemoveFromDrinkList(drink, _favourites))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Remove a drink from the list _likes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool RemoveFromLikes(Drink drink)
        {

            if (RemoveFromDrinkList(drink, _likes))
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        /// <summary>
        /// Remove a drink from the list _dislikes.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool RemoveFromDislikes(Drink drink)
        {

            if (RemoveFromDrinkList(drink, _dislikes))
            {
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