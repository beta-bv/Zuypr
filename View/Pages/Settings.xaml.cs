namespace View.Pages;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
    }
    
    private void Logout(object sender, EventArgs e)
    {
        if (Application.Current != null) Application.Current.MainPage = new LaunchScreen();
        
        
    }
}