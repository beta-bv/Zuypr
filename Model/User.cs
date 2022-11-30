using Microsoft.Maui.Layouts;
using System.Drawing;

namespace Model
{
    // All the code in this file is included in all platforms.
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        public static bool CheckAge(DateTime date)
        {
            DateTime dateNow = DateTime.Now;

            if (date.AddYears(18).CompareTo(dateNow) > 0)
            {
                return false;
            }
            return true;
        }

        public static bool CheckEmail(string email)
        {
            return true;
        }

        public static bool CheckName(string name)
        {
            return true;
        }

        public static bool IsDateOfBirthValid(DateTime date)
        {
            DateTime dateNow = DateTime.Now;
            if(date > dateNow)
            {
                return false;
            }
            return true;
        }

        public User GetDummyUser() //returned een dummy user voor dummy gebruik
        {
            return new User("dummyUser", "email@email.com", new DateTime(1, 1, 1999));
        }


    }
}