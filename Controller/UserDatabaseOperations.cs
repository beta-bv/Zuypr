using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                DatabaseContext db = new DatabaseContext();  //maakt database context aan
                User userFromDatabse = db.Users
                .Where(u => u.Email.Equals(user.Email)).First();   //query haalt de user op aan de hand van zijn/haar email
                return userFromDatabse;                            // returned de user
            }
            catch (Exception ex)
            {
                new Exception("Database Failure");                 // gooit een exception als er iets mis gaat met de database
                return null;
            }
        }

        /// <summary>
        /// Adds user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUserToDatabase(User user)
        {
            //try
            //{
            //    // Open the database connection
            //    DatabaseContext dbContext = new DatabaseContext();

            //    // If there is already a user with this email address in the database then throw an error
            //    if (dbContext.Users.Any(a => a.Email.Equals(user.Email)))
            //    {
            //        throw new Exception("A user with this email address already exists in the database");
            //    }

            //    // Add the user to the database and save the changes
            //    dbContext.Users.Add(user);
            //    dbContext.SaveChanges();
            //    return true;
            //}
            //catch
            //{
            //    throw new Exception("Database Failure");
            //}
            Auth.User = user;
            dummydb.Users.Add(user);
            return true;                                                 //effe ifjes voor als het niet werkt toevoegen
        }

        public static bool RemoveUserFromDatabase()
        {
            Auth.User = null;
            //database spul
            return true;
            //DatabaseContext db = new DatabaseContext();
            //if (GetUserFromDatabase(user) != null)
            //{
            //    db.Users.Remove(user);
            //    return true;
            //}
            //return false;
            //}
        }
        public static bool UpdateUserInDatabase(User user)
        {
            Auth.User = user;
            //database spul
            return true;
        }
    }
}
