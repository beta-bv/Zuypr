namespace View.Pages.Register;

public partial class Step5 : ContentPage
{
    // int count = 0;

    public Step5()
    {
        InitializeComponent();
    }

    private void Next(object sender, EventArgs e)
    {
        if (Application.Current != null) Application.Current.MainPage = new AppShell(Step1.User);
    }
}