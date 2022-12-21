using Model;
using System.Linq.Expressions;
using Controller;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace View.Pages;

public partial class RegisterPage : ContentPage
{
    private DatabaseContext _db;
    public RegisterPage()
    {
        InitializeComponent();
        _db = new DatabaseContext();
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
                    using (SqlConnection connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=zuypr;User ID=sa;Password=Betaverse01!;Trust Server Certificate=True"))
                    {
                        String query = "INSERT INTO dbo.users (id,Name,Email,Password, DateOfBirth, ProfielImage) VALUES (@id,@Name,@Email,@Password, @DateOfBirth, ProfielImage)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", "2");
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Password", password);
                            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                            command.Parameters.AddWithValue("@ProfielImage", "dotnet_bot.png");

                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                throw new Exception("Error inserting data into Database!");
                        }
                    }
                    Auth.User = Client;
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