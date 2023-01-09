using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controller.Platforms
{
    public static class UserDatabaseOperations
    {
        /// <summary>
        /// Gets User from the database
        /// </summary>
        /// <returns></returns>
        public static User GetUserFromDatabase(User user)
        {
            return dummydb.Users.Where(a => a.Email == user.Email).FirstOrDefault();
        }

        /// <summary>
        /// finds users by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static User GetUserFromDatabaseByEmail(String email)
        {
            Auth.User = dummydb.Users.Where(a => a.Email == email).FirstOrDefault();
            return Auth.User;
        }

        /// <summary>
        /// Adds user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUserToDatabase(User user)
        {
            dummydb.Users.Add(user);
            Auth.User = user;
            return true; 
        }

        public static bool RemoveUserFromDatabase()
        {
            return dummydb.Users.Remove(Auth.User);
        }
        public static bool RemoveUserFromDatabase(User userToDelete)
        {
            return dummydb.Users.Remove(userToDelete);

        }
        public static bool UpdateUserInDatabase(int oldUserHash, User newUser)
        {

            User olduser = dummydb.Users.Where(a => a.GetHashCode() == oldUserHash).FirstOrDefault();
            dummydb.Users.Remove(olduser);
            dummydb.Users.Add(newUser);
            Auth.User = newUser;
            return true;

            // Genesis 4:20
            //db.Attach(newUser);
            //db.Entry(newUser).State = EntityState.Modified;
            //db.SaveChanges();
        }
    }
}
