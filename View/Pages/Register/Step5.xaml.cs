namespace View.Pages.Register;
using Controller;
using Model;

public partial class Step5 : ContentPage
{
    // int count = 0;
    private static readonly User User = Step1.User;

    public Step5()
    {
        // Final update
        UserDatabaseOperations.UpdateUserInDatabase(User.GetHashCode(), User);
        InitializeComponent();
    }

    private void Next(object sender, EventArgs e)
    {
        if (Application.Current != null) Application.Current.MainPage = new AppShell(Step1.User);
    }
}