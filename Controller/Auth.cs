using System;
using Model;

namespace Controller
{
    public static class Auth
    {
        private static User _user;

        public static User getUser()
        {
            return _user;
        }

        public static User setUser(User user)
        {
            _user = user;            
            _user.Matches = new List<Match>() { new Match(new User[] { user, dummydb.Users[1] }, new List<Message>()) };
            return _user;
        }
    }
}

