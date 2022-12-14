using Controller;
using Model;
using System.Linq.Expressions;

namespace View.Pages;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
        EmailEditOld.Text = Auth.getUser().Email;
    }

    private void Logout(object sender, EventArgs e)
    {
        if (Application.Current != null) Application.Current.MainPage = new LaunchScreen();

    }

    private void OnEditClicked(object sender, EventArgs e)
    {
        try
        {
            User temp = Auth.getUser();                  //geeft alleen nog geen error message bij het invullen van niks
            temp.Email = EmailEditNew.Text?.Trim();
            ErrorFrameEditPage.IsVisible = false;
            Auth.setUser(temp);
        }
        
        catch (Exception ex)
        {
            ErrorLabelEditPage.Text = ex.Message;
            ErrorFrameEditPage.IsVisible = true;
        }
    }
}