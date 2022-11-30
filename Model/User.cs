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

        public User(string name, string email, DateTime dateOfBirth){
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
        public bool CheckAge(DateTime date){
            DateTime dateNow = DateTime.Now;

            if(date.CompareTo(dateNow) < 18)
            {
                return false;
            }
            return true;
        }

        public bool CheckEmail(string email) {
            return true;
        }

        public bool CheckName(string name) {
            return true;
        }

        public User GetDummyUser() //returned een dummy user voor dummy gebruik
        {
            return new User("dummyUser", "email@email.com", new DateTime(1, 1, 1999) );
        }


    }
}