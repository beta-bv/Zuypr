using Model;

namespace View.Pages;

public partial class MyMatches : ContentPage
{
    public List<Match> AllMatches { get; set; }
    public List<User> Users { get; set; }
    public MyMatches()
    {
        AllMatches = Controller.Auth.getUser().Matches;
        Users = new List<User>();
        foreach(Match match in AllMatches)
        {
            foreach(User user in match.Users)
            {
                if(Controller.Auth.getUser() != user) 
                { 
                    Users.Add(user);
                }
            }
        }
        InitializeComponent();
        BindingContext = this;
    }

    private void ProfileImage_OnClicked(object sender, EventArgs e)
    {
        var temp = (ImageButton) sender;
        Application.Current.MainPage.Navigation.PushAsync(new Profile((User)temp.BindingContext));
    }

    private void ChatButton_Clicked(object sender, EventArgs e)
    {
        var temp = (ImageButton) sender;
        Match match = FindMatchFromUser((User)temp.BindingContext);
        if (match != null) { Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(match)); }
    }

    private Match FindMatchFromUser(User user)
    {
        foreach(Match match in AllMatches)
        {
            foreach(User us in match.Users)
            {
                if(user == us)
                {
                    return match;
                }
            }
        }
        return null;
    }
}