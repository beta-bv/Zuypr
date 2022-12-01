using Microsoft.Maui.Layouts;
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
                        throw new Exception("PASSWORD DOES NOT MEET REQUIREMENTS");
                    }
                    // Hash the input string using SHA256
                    _password = HashString(value);
                }
                else
                {
                    throw new Exception("INVALID PASSWORD");
                }
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

        public User(string name, string email, string password, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Password = password;
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
            return new User("dummyUser", "123", "email@email.com", new DateTime(1, 1, 1999));
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
            if (emailOld.Equals(Email) && emailNew != emailOld)
            {
                Email = emailNew;
                return true;
            }
            return false;
        }

        /// <summary>
        /// updates user password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool UpdateUserPassword(string oldPassword, string newPasswordField1, string newPasswordField2) //TODO implement het database gedeelte nog
        {
            if (ComparePasswords(newPasswordField1, newPasswordField2))
            {
                string tempPasswordFieldCombine = newPasswordField1;
                if (Password.Equals(HashString(oldPassword)) && !Password.Equals(HashString(tempPasswordFieldCombine))){
                    Password = newPasswordField1;
                    return true;  
                }
            }
            return false;
        }
    }
}