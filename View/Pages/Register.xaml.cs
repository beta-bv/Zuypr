using Model;

namespace View.Pages;

public partial class Register : ContentPage
{
    int som = 0;
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
            password = PasswordField.Text;
            User Client = new User(name, email, password, dateOfBirth);
            await Navigation.PushAsync(new Profile());
        }
        else
        {
            if (som != 1)
            {
                RegisterVStack.Children.Add(new Label() { Text = "de wachtwoorden kwamen niet overeen" });
            }
            som++;
        }
    }

}