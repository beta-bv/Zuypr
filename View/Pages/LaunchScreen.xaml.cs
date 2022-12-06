using Model;

using View.Pages.Register;

namespace View.Pages;

public partial class LaunchScreen : ContentPage
{
    public LaunchScreen()
    {
        InitializeComponent();
    }

    private void Login(object sender, EventArgs e)
    {
        if (Application.Current != null) Application.Current.MainPage = new AppShell(User.GetDummyUser());
    }

    private void Register(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new NavigationPage(new Step0());
        };
    }
}