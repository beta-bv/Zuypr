using Controller;
using Model;

dummydb.Initialize();
//Auth.setUser(dummydb.Users[0]);

Auth.setUser(dummydb.GeneratePreferences(new User("Dummy", "dummy@zuypr.com", "EpicPassword1!", new DateTime(2000, 1, 1)), new Dictionary<string, string[]>
{
    ["favs"] = new string[] { "Hertog Jan", "Licor 43", "Guinness" },
    ["like"] = new string[] { "Heineken", "Jager Bomb", "Bacardi", "Martini", "Esbjaerg" },
    ["hate"] = new string[] { "Gin & Tonic", "Mooi Kaap Droë rooi", "Bloody Mary" },
}));

Matcher matcher = new Matcher();
matcher.GeneratePotentialMatches();
