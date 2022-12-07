using Model;

namespace View.Pages;

public partial class Profile : ContentPage
{
    public User MatchUser { get; set; }
    public bool OwnProfile = false;
    public Profile()
    {
        MatchUser = new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15));
        InitializeComponent();
        OwnProfile = true;
        if (OwnProfile)
        {
            chat.IsVisible = false;
        }
        BindingContext = this;
    }

    public Profile(User user)
    {
        MatchUser = user;
       
        InitializeComponent();
        if (OwnProfile)
        {
            chat.IsVisible = false;
        }
        BindingContext = this;
    }

    private void ChatButton_Clicked(object sender, EventArgs e)
    {
        //Application.Current.MainPage.Navigation.PushAsync(new ChatScreen());
    }
}