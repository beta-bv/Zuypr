using Model;

List<User> Users = User.GetAllUsersFromDatabase();

User Client = new User("Client a", "client@mail.ai", "Th1s1s4Pass!", new DateTime(1998, 12, 2))
    .GeneratePreferences(new Dictionary<string, string[]>
    {
        ["favs"] = new string[] { "Gladiator van de Radiator", "Klok op Kamertemperatuur", "Export" },
        ["like"] = new string[] { "Grolsch", "Amstel", "Kornet", "Heineken", "Hertog Jan" },
        ["hate"] = new string[] { "Apple Bandit", "Radler", "Desperados" },
    });

User Client2 = new User("Client b", "client@mail.ai", "Th1s1s4Pass!", new DateTime(1998, 12, 2))
    .GeneratePreferences(new Dictionary<string, string[]>
    {
        ["favs"] = new string[] { "Malibu", "Prosecco" },
        ["like"] = new string[] { "Absinth", "Gin & Tonic", "Black Label", "Amstel" },
        ["hate"] = new string[] { "Hertog Jan", "Slurp! Rose" },
    });

User Client3 = new User("Client b", "client@mail.ai", "Th1s1s4Pass!", new DateTime(1998, 12, 2))
    .GeneratePreferences(new Dictionary<string, string[]>
    {
        ["favs"] = new string[] { "Absinth" },
        ["like"] = new string[] { "Red Label" },
        ["hate"] = new string[] { "Radler", "Apple Bandit" },
    });

Client.GeneratePotentialMatches();
//Console.WriteLine();
//Client2.GeneratePotentialMatches();
