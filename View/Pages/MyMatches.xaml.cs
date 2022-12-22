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
        if (Users.Count < 1)
        {
            no_found.IsVisible = true;
        }
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

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        ImageButton temp = (ImageButton)sender;
        User usr = (User) temp.BindingContext;
        deleteFrame.BindingContext = usr;
        deleteFrame.IsVisible = true;
        photo.Source = usr.ProfileImage;
        sure.Text = "Are you sure you want to delete " + usr.Name + "?";
    }

    private void no_Clicked(object sender, EventArgs e)
    {
        deleteFrame.IsVisible = false;
    }

    private void yes_Clicked(object sender, EventArgs e)
    {
        Button temp = (Button)sender;
        Users.Remove((User)temp.BindingContext);
        temp.BindingContext = new BindingContext();
        deleteFrame.IsVisible = false;
        InitializeComponent();
        if (Users.Count < 1)
        {
            no_found.IsVisible = true;
        }
    }
}