namespace View.Pages.Register;

public partial class Step2 : ContentPage
{
    // int count = 0;

    public Step2()
    {
        InitializeComponent();
    }

    private async void Next(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step3());
    }
}