using Model;
using View.Pages;

namespace View;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        dummydb.Initialize();

        MainPage = new LaunchScreen();
    }
}
