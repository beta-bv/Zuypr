using Model;

namespace View.Pages;

public partial class Profile : ContentPage
{
    public User MatchUser { get; set; }
    public bool OwnProfile = false;
    public Profile()
    {
        MatchUser = new User("Henk", "hoi@gmail.com", "Neeneenee!", new DateTime(2002, 7, 15));
        MatchUser.Cities = new List<string>();
        MatchUser.Cities.Add("Hoonhorst");
        MatchUser.Cities.Add("Dalfsen");

        Drink testDrink = Drink.GetDummyDrink();

        Drink testDrink2 = Drink.GetDummyDrink();

        MatchUser.AddToFavourites(testDrink);
        MatchUser.AddToFavourites(testDrink2);

        InitializeComponent();
        if (MatchUser.Cities.Count < 2)
        {
            city.Text = "City";
        }
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
        MatchUser.Cities = new List<string>();
        InitializeComponent();
        if (MatchUser.Cities.Count < 2)
        {
            city.Text = "City";
        }
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