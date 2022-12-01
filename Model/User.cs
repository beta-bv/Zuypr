<<<<<<< Updated upstream
﻿using System.Drawing;
=======
﻿using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
>>>>>>> Stashed changes

namespace Model
{
    // All the code in this file is included in all platforms.
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public List<string> Cities { get; set; }
        public Bitmap ProfielImage { get; set; }
        public List<User> Matches { get; set; }
<<<<<<< Updated upstream
        public List<Drink> Favourites { get; set; }
        public List<Drink> Likes { get; set; }
        public List<Drink> Dislikes { get; set; }
=======

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
>>>>>>> Stashed changes
    }
}