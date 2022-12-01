namespace View.Pages;

public partial class LaunchScreen : ContentPage
{

    public LaunchScreen()
    {
        InitializeComponent();
    }

    private async void Navigate(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Profile());
    }
}

