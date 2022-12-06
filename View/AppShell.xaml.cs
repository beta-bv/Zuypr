using Model;
namespace View;


public partial class AppShell : Shell
{
    public User User { get; private set; }

    public AppShell(User user)
    {
        User = user;
        InitializeComponent();
    }
}