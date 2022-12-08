namespace View.Pages.Register;

public partial class Step4 : ContentPage
{
    // int count = 0;

    public Step4()
    {
        InitializeComponent();
    }

    private async void Next(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step5());
    }
}