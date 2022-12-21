using Model;
using System.Linq.Expressions;
using Controller;
using Microsoft.EntityFrameworkCore.Storage;

namespace View.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }
    /// <summary>
    ///  maakt de user aan
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void RegisterUser(object sender, EventArgs e)
    {
        try
        {
            string name = NameField.Text?.Trim();
            string email = EmailField.Text?.Trim();
            DateTime dateOfBirth = BirthDateField.Date;
            string password = "";
            if (User.ComparePasswords(PasswordField.Text, PasswordConfirmField.Text))
            {
                ErrorFrame.IsVisible = false;
                password = PasswordField.Text;
                try
                {
                    User Client = new User(name, email, password, dateOfBirth);
                    Model.Database.DB.Add(Client);
                    Model.Database.DB.SaveChanges();
                    Auth.setUser(Client);
                    Application.Current.MainPage = new AppShell(Client);
                }
                catch (Exception ex)
                {

                    if (ex is ArgumentException)
                    {
                        ErrorLabel.Text = ex.Message;  //note dat dit niet echt de meest veilige zooi is, misschien eigen exception klasse aanmaken om de registratie error te weergeven?
                        ErrorFrame.IsVisible = true;
                        return;
                    }
                }
                await Navigation.PushAsync(new Profile(Controller.Auth.User));
            }
            else
            {
                ErrorLabel.Text = "Wachtwoorden komen niet overeen";
                ErrorFrame.IsVisible = true;
            }
        }
        catch
        {
            ErrorLabel.Text = "Je moet iets invullen om te regristreren";  //note dat dit niet echt de meest veilige zooi is, misschien eigen exception klasse aanmaken om de registratie error te weergeven?
            ErrorFrame.IsVisible = true;
            return;
        }
    }
}