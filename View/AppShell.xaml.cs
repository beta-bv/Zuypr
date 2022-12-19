using Model;
using Controller;

namespace View;


public partial class AppShell : Shell
{
    public AppShell(User user)
    {
        dummydb.Initialize();

        Auth.setUser(user);

        InitializeComponent();

    }
}