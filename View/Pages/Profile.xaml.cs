using Model;
using Controller; 
namespace View.Pages;

public partial class Profile : ContentPage
{
    public User MatchUser { get; set; }
    public List<Drink> Drinks { get; set; }
    public Profile() : this(Auth.getUser())
    {
    }

    public Profile(User user)
    {
        MatchUser = user;
        Drinks = MatchUser.GetFavourites();
        InitializeComponent();
        if (MatchUser.Cities.Count < 2)
        {
            city.Text = "City";
        }
        if(Drinks.Count < 2)
        {
            beverage.Text = "Favourite Beverage";
        }
        if (user.Equals(Controller.Auth.getUser()))
        {
            chat.IsVisible = false;
        }
        BindingContext = this;
    }

    private void ChatButton_Clicked(object sender, EventArgs e)
    {
        foreach(Match match in Controller.Auth.getUser().Matches)
        {
            foreach(User user in match.Users)
            {
                if(user == MatchUser)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(match));
                }
            }
        }
    }
}