using Model;
using View.Pages;
using Controller;
using Controller.Platforms;

namespace View;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        //dummydb.Initialize();
        try
        {
            User mark = UserDatabaseOperations.GetUserFromDatabaseByEmail("mark@email.nl");
            User merijn = UserDatabaseOperations.GetUserFromDatabaseByEmail("stan@email.nl");
            DatabaseContext db = new DatabaseContext();
            Match CurrentMatch = new Match(merijn, mark);
            merijn.Matches.Add(CurrentMatch);
            mark.Matches.Add(CurrentMatch);
            UserDatabaseOperations.UpdateUserInDatabase(mark);
            UserDatabaseOperations.UpdateUserInDatabase(merijn);
        }
        catch(Exception E) { }
        

        Model.City.GetValidCities();
        MainPage = new LaunchScreen();
    }
}
