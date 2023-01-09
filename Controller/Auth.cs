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
        public static bool removeMatch(User us)
        {
            foreach (Match match in _user.Matches)
            {
                foreach (User user in match.Users)
                {
                    if (us == user)
                    {
                        _user.Matches.Remove(match);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

