using Microsoft.Maui.Layouts;
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
        public List<Drink> Favourites { get; set; }
        public List<Drink> Likes { get; set; }
        public List<Drink> Dislikes { get; set; }

        public User(string name, string email, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
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
        public User GetDummyUser()
        {
            return new User("dummyUser", "email@email.com", new DateTime(1, 1, 1999));
        }
        public User GetUserFromDatabase()
        {
            throw new NotImplementedException();
        }

        public static bool AddUserToDatabase(User user)
        {
            throw new NotImplementedException();
        }

    }
}