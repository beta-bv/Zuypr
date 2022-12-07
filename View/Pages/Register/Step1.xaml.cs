using Model;

namespace View.Pages.Register;

public partial class Step1 : ContentPage
{
    public static User User { get; set; }

    public Step1(User user)
    {
        User = user;
        InitializeComponent();
        BindingContext = this;
    }

    private async void Next(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Step2());
    }
}