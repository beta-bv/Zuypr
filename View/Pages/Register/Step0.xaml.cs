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

                    await Navigation.PushAsync(new Step1(Client));
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
                //await Navigation.PushAsync(new Profile());
            }
            else
            {
                ErrorLabel.Text = "Wachtwoorden komen niet overeen";
                ErrorFrame.IsVisible = true;
            }
        }
        catch (Exception nullEx)
        {
            ErrorLabel.Text = "Je moet iets invullen om te regristreren";  //note dat dit niet echt de meest veilige zooi is, misschien eigen exception klasse aanmaken om de registratie error te weergeven?
            ErrorFrame.IsVisible = true;
            return;
        }
    }
}