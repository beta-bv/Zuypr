namespace View.Pages;

public partial class MyDrinks : ContentPage
{
    public MyDrinks()
    {
        Console.WriteLine(Controller.Auth.getUser().Name);
        InitializeComponent();
    }
}