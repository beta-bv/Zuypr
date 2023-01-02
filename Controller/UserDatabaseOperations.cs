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
                //db.Database.CurrentTransaction.
                User userFromDatabse = db.Users.First(u => u.Email.Equals(user.Email));   //query haalt de user op aan de hand van zijn/haar email
                return userFromDatabse;                            // returned de user
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);                 // gooit een exception als er iets mis gaat met de database
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
            try
            {
                // Open the database connection
                DatabaseContext db = new DatabaseContext();

                // If there is already a user with this email address in the database then throw an error
                if (db.Users.Any(a => a.Email.Equals(user.Email)))
                {
                    throw new Exception("A user with this email address already exists in the database");
                }

                //Add the user to the database and save the changes
                db.Users.Add(user);
                Auth.User = user;
                db.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Database Failure");
            }
            //Auth.User = user;
            //dummydb.Users.Add(user);
            //return true;                                                 //effe ifjes voor als het niet werkt toevoegen
        }

        public static bool RemoveUserFromDatabase()
        {
            DatabaseContext db = new DatabaseContext();
            if (GetUserFromDatabase(Auth.User) != null)
            {
                db.Users.Remove(Auth.User);
                db.SaveChanges();
                Auth.User = null;
                return true;
            }
            return false;
        }
        public static bool RemoveUserFromDatabase(User userToDelete)
        {
            DatabaseContext db = new DatabaseContext();
            if (GetUserFromDatabase(userToDelete) != null)
            {
                db.Users.Remove(userToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public static bool UpdateUserInDatabase(User userNewInfo, User userOldInfo)
        {
            DatabaseContext db = new DatabaseContext();
            //db.Users.Remove(userOldInfo);
            //db.Users.Add(userNewInfo);
            //db.SaveChanges();

            User UserToUpdate = db.Users.Where(a => a.Id == userOldInfo.Id).FirstOrDefault();
            UserToUpdate = userNewInfo;
            db.SaveChanges();

            if (GetUserFromDatabase(userOldInfo) == null)
            {
                return true;
            }
            return false;
        }
    }
}
