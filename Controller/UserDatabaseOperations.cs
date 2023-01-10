using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Controller
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
                User userFromDatabse = db.Users
                    .Include(u => u.Cities)
                    .Include(u => u.Matches)
                    .First(u => u.Email.Equals(user.Email));   //query haalt de user op aan de hand van zijn/haar email
                db.SaveChanges();
                return userFromDatabse;                            // returned de user
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);                 // gooit een exception als er iets mis gaat met de database
                return null;
            }
        }

        /// <summary>
        /// finds users by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static User GetUserFromDatabaseByEmail(String email)
        {
            try
            {
                DatabaseContext db = new DatabaseContext();  //maakt database context aan
                User userFromDatabse = db.Users.First(u => u.Email.Equals(email));   //query haalt de user op aan de hand van zijn/haar email
                return GetUserFromDatabase(userFromDatabse);                            // returned de user
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

                List<City> newCitiesList = new List<City>();
                foreach (City city in user.Cities)
                {
                    if (db.Users.Any(a => a.Cities.Any(b => b.Equals(city))))
                    {
                        // pak de dezelfe stad maar dan uit de databse
                        newCitiesList.Add(db.Users.Where(a => a.Cities.Any(b => b.Equals(city))).FirstOrDefault().Cities.Where(c => c.Equals(city)).FirstOrDefault());
                    }
                    else
                    {
                        newCitiesList.Add(city);
                    }
                }
                user.Cities = newCitiesList;



                //Add the user to the database and save the changes
                db.Users.Add(user);
                db.SaveChanges();

                //User dbuser = db.Users.Include(a => a.Cities).Where(a => a.Email.Equals(user.Email)).FirstOrDefault();

                //foreach (City city in user.Cities)
                //{
                //    dbuser.Cities.Add(city);
                //}

                //foreach (Match match in user.Matches)
                //{
                //    dbuser.Matches.Add(match);
                //}

                Auth.User = GetUserFromDatabase(user);
                //db.SaveChanges();
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
        public static bool UpdateUserInDatabase(int oldUserHash, User newUser)
        {
            DatabaseContext db = new DatabaseContext();

            db.Attach(newUser);
            db.Entry(newUser).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }
    }
}
