using View.Pages;

namespace View;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new LaunchScreen();
    }
}
