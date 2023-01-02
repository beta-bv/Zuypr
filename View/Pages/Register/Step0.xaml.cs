using Controller.Platforms;
using Microsoft.Data.SqlClient;
using Model;
using System.Linq.Expressions;

namespace View.Pages.Register;

public partial class Step0 : ContentPage
{
    // int count = 0;

    public User User { get; set; }

    public Step0()
    {
        InitializeComponent();
    }

    private void Back(object sender, EventArgs e)
    {
        if (Application.Current != null) Application.Current.MainPage = new LaunchScreen();
    }

    private async void Next(object sender, EventArgs e)
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
                    if (UserDatabaseOperations.GetUserFromDatabase(Client).Email != EmailField.Text)
                    {
                        UserDatabaseOperations.AddUserToDatabase(Client);
                        await Navigation.PushAsync(new Step1(Client));
                    }
                    else
                    {
                        ErrorLabel.Text = "there is already an account with this email address";
                        ErrorLabel.IsVisible = true;
                    }
                }
                catch (Exception ex)
                {

                    ErrorLabel.Text = ex.Message;  //note dat dit niet echt de meest veilige zooi is, misschien eigen exception klasse aanmaken om de registratie error te weergeven?
                    ErrorFrame.IsVisible = true;
                    return;

                }
                //await Navigation.PushAsync(new Profile());
            }
            else
            {
                ErrorLabel.Text = "Both password fields must be the same";
                ErrorFrame.IsVisible = true;
            }
        }
        catch
        {
            ErrorLabel.Text = "You need to fill in information to register";  //note dat dit niet echt de meest veilige zooi is, misschien eigen exception klasse aanmaken om de registratie error te weergeven?
            ErrorFrame.IsVisible = true;
            return;
        }
    }
}