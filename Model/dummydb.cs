using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class dummydb
    {
        public static List<User> Users = new List<User>();

        public static void Initialize()
        {
            // Add users
            Users = new List<User>()
            {
                new User("Siem", "siem@email.nl", "EpicPassword1!", new DateTime(2004, 08, 27)),
                new User("Dylan", "dylan@email.nl", "EpicPassword1!", new DateTime(2002, 05, 22)),
                new User("Mark", "mark@email.nl", "EpicPassword1!", new DateTime(2001, 10, 20)),
                new User("Niels", "niels@email.nl", "EpicPassword1!", new DateTime(2003, 02, 03)),
                new User("Stan", "stan@email.nl", "EpicPassword1!", new DateTime(1969, 04, 20)),
                new User("Merijn", "merijn@email.nl", "EpicPassword1!", new DateTime(2003, 04, 10)),
                new User("Thomas", "thomas@email.nl", "EpicPassword1!", new DateTime(2002, 06, 18)),
            };

            foreach (User user in Users)
            {
                // Give users a match with a random user (including themselves lol)
                user.Matches = new List<Match>();
                user.Matches.Add(new Match(new User[] { user, Users[new Random().Next(Users.Count)] }, new List<Message>()));
                

                // Give users a list of cities
                user.Cities = new List<string>()
                {
                    "Raalte",
                    "Heeten",
                    "Zwolle",
                    "Broekland",
                    "Mariënheem",
                };
                user.AddToFavourites(new Drink("dotnet_bot.png"));
            }

            // Add messages to the match
            foreach (User user in Users)
            {
                // Pick random amount of "uh oh, stinky" pairs between 1 and 15

                int amountOfStinky = new Random().Next(1, 15);
                for (int i = 0; i < amountOfStinky; i++)
                {
                    // User 0 sends a message with the text "uh oh"
                    user.Matches[0].Messages.Add(new Message("Hallo!", user.Matches[0].Users[0], DateTime.Now));
                    // User 1 then responds (as expected) with "stinky"
                    user.Matches[0].Messages.Add(new Message("Hoi!", user.Matches[0].Users[1], DateTime.Now));
                }
            }
        }

    }


}
