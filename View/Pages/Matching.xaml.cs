using Model;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public User Match { get; }

    public Matching()
    {
        Match = Controller.Auth.getUser();
        InitializeComponent();
    }
}