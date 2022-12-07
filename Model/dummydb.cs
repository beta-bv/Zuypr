using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class dummydb
    {
        public static List<User> Users = new List<User>()
        {
            new User("Siem", "siem@email.nl", "EpicPassword1!", new DateTime(2004, 08, 27)),
            new User("Dylan", "dylan@email.nl", "EpicPassword1!", new DateTime(2002, 05, 22)),
            new User("Mark", "mark@email.nl", "EpicPassword1!", new DateTime(2001, 10, 20)),
            new User("Niels", "niels@email.nl", "EpicPassword1!", new DateTime(2003, 02, 03)),
            new User("Stan", "stan@email.nl", "EpicPassword1!", new DateTime(1969, 04, 20)),
            new User("Merijn", "merijn@email.nl", "EpicPassword1!", new DateTime(2003, 04, 10)),
            new User("Thomas", "thomas@email.nl", "EpicPassword1!", new DateTime(2002, 06, 18)),
        };

        public static void Initialize()
        {
            // Give users a matche with a random user
            foreach (User user in Users)
            {
                user.Matches.Add(new Match()
                {
                    Users = new User[] { user, Users[new Random().Next(Users.Count)] },
                    Messages = new List<Message>(),
                });
                user.Cities = new List<string>()
                {
                    "Raalte",
                    "Heeten",
                    "Zwolle",
                    "Broekland",
                    "Mariënheem",
                };
            }
            
            // Add messages to the match
            foreach (User user in Users)
            {
                int amountOfStinky = new Random().Next(15);

                for (int i = 0; i < amountOfStinky; i++)
                {
                    user.Matches[0].Messages.Add(new Message("uh oh", user.Matches[0].Users[0], DateTime.Now));
                    user.Matches[0].Messages.Add(new Message("stinky", user.Matches[0].Users[1], DateTime.Now));
                }
            }
        }

    }

    
}
