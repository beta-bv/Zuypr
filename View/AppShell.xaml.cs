using Model;
using Controller;

namespace View;

public partial class AppShell : Shell
{
    public AppShell(User user)
    {
        Auth.setUser(user);

        InitializeComponent();
    }
}