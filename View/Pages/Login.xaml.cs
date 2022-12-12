using Model;
using System.Linq.Expressions;

namespace View.Pages;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    private async void LoginUser(object sender, EventArgs e)
    {
        String password = PasswordFieldL.Text?.Trim();
        String Email = EmailFieldL.Text?.Trim();
    }
}