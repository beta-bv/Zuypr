using System;
using Model;

namespace Controller
{
	public static class Filter
	{
        readonly static User user = Auth.User;

        //Dit wordt straks gekoppeld aan de lijst met potentiele matches die uit het algoritme komen (Input filter).
        public static List<User> Users => Matcher.MatchList;

        //De uiteindelijke lijst potentiele matches die zijn gefilterd op plaats/dorp en leeftijd (Output filter).
        public static List<User> FilteredPotentionalMatches => Users.Where(
                                                            a => user.Cities.Intersect(a.Cities).Count() > 0)
                                                            .Where(x => x.Age >= user.MinimumpreferredAge)
                                                            .Where(x => x.Age <= user.MaximumpreferredAge)
                                                            .ToList();
    }
}