using Controller;
using Model;

User a = Database.UserGet(2);

Console.WriteLine(a.Name);