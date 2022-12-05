﻿using Model;
using System.Linq.Expressions;

namespace View.Pages;

public partial class Register : ContentPage
{
    int som = 0;
    public Register()
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
        string name = NameField.Text.Trim();
        string email = EmailField.Text.Trim();
        DateTime dateOfBirth = BirthDateField.Date;
        string password = "";
        if(User.ComparePasswords(PasswordField.Text, PasswordConfirmField.Text))
        {
            ErrorFrame.IsVisible = false;
            password = PasswordField.Text;
            try
            {
                User Client = new User(name, email, password, dateOfBirth);
            }
            catch(Exception ex)
            {
                ErrorLabel.Text = ex.Message;  //note dat dit niet echt de meest veilige zooi is, misschien eigen exception klasse aanmaken om de registratie error te weergeven?
                ErrorFrame.IsVisible = true;
                return;
            }
            await Navigation.PushAsync(new Profile());
        }
        else
        {
            ErrorLabel.Text = "Wachtwoorden komen niet overeen";
            ErrorFrame.IsVisible = true;
        }
    }
}