using Controller;
using Model;

User a = Database.UserGet(0);

Console.WriteLine(a.Name);