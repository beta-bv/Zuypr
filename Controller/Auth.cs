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
            return _user; 
        }
    }
}

