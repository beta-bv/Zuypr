using Model;

namespace View.Pages;

public partial class Profile : ContentPage
{
    public User User { get; set; }
    public Profile()
    {
        InitializeComponent();
    }

    public Profile(User user)
    {
        this.User = user;
        InitializeComponent();
    }
}