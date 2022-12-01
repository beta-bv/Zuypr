using Model;

namespace View.Pages;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }
    private async void RegisterUser(object sender, EventArgs e)
    {
        string name = NameField.Text.Trim();
        string email = EmailField.Text.Trim();
        DateTime dateOfBirth = BirthDateField.Date;
        string password = "";
        if(User.ComparePasswords(PasswordField.Text, PasswordConfirmField.Text))
        {
            password = User.HashString(PasswordField.Text);
            User Client = new User(name, email, password, dateOfBirth);
        }
        else
        {
            new Label() { Text = "de wachtwoorden kwamen niet overeen" };
        }
    }

}