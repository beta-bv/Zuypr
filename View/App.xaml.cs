using Model;
using View.Pages;
using Controller;

namespace View;

public partial class App : Application
{

    public App()
    {
        InitializeComponent();
        Model.City.GetValidCities();
        MainPage = new LaunchScreen();
    }

}
