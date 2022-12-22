using Model;
using Controller;

using View.Pages.Register;

namespace View.Pages;

public partial class LaunchScreen : ContentPage
{
    public LaunchScreen()
    {
        InitializeComponent();
    }

    private async void LoginUser(object sender, EventArgs e)
    {
        ErrorFrameL.IsVisible = false;
        String password = PasswordFieldL?.Text;
        String Email = EmailFieldL.Text?.Trim();
        //if(Model.Database.DB.Users.Any(u => Email == u.Email) && User.HashString(password) == Model.Database.DB.Users.Where(u => Email == u.Email).First().Password)
        //{
        //    User temp = Auth.User = (Model.Database.DB.Users.Where(u => Email == u.Email).First());
        //    Application.Current.MainPage = new AppShell(temp);
        //}
        if (dummydb.Users.Any(u => Email == u.Email) && User.HashString(password) == dummydb.Users.Where(u => Email == u.Email).First().Password)
        {
            User temp = Auth.User = (dummydb.Users.Where(u => Email == u.Email).First());
            Application.Current.MainPage = new AppShell(temp);
        }
        else
        {
            ErrorFrameL.IsVisible = true;
            ErrorLabelL.Text = "de ingevulde gegevens zijn niet correct";
        }
    }

    private void Register(object sender, EventArgs e)
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new NavigationPage(new Step0());
        };
    }
}