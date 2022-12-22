using Model;
using System.Linq.Expressions;
using Controller;

namespace View.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void LoginUser(object sender, EventArgs e)
    {
        ErrorFrameL.IsVisible= false;
        String password = PasswordFieldL?.Text;
        String Email = EmailFieldL.Text?.Trim();
        password = "EpicPassword1!";
        Email = "stan@email.nl";
        if (dummydb.Users.Any(u => Email == u.Email) && User.HashString(password) == dummydb.Users.Where(u => Email == u.Email).First().Password)
        {
            User temp = Auth.setUser(dummydb.Users.Where(u => Email == u.Email).First());
            Application.Current.MainPage = new AppShell(temp);
        }
        else 
        {
            ErrorFrameL.IsVisible= true;
            ErrorLabelL.Text= "de ingevulde gegevens zijn niet correct";
        }
    }
}