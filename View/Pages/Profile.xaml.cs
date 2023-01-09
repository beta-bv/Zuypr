using Model;
using Controller; 
namespace View.Pages;

public partial class Profile : ContentPage
{
    public User MatchUser { get; set; }
    public List<Drink> Drinks { get; set; }
    public Profile() : this(Auth.User)
    {
    }

    public Profile(User user)
    {
        MatchUser = user;
        Drinks = MatchUser.GetFavourites();
        InitializeComponent();
        if (MatchUser.Cities == null || MatchUser.Cities.Count < 2) //hier effe MatchUser.Cities == null toegevoegd zodat het uberhaupt werkte, geen idee hoe dit hoort te zijn
        {
            city.Text = "City";
        }
        if(Drinks == null || Drinks.Count < 2)   //hier effe Drinks == null toegevoegd zodat het uberhaupt werkte, geen idee hoe dit hoort te zijn
        {
            beverage.Text = "Favourite Beverage";
        }
        if (user.Equals(Controller.Auth.User))
        {
            chat.IsVisible = false;
        }
        BindingContext = this;
    }

    private void ChatButton_Clicked(object sender, EventArgs e)
    {
        foreach(Match match in Controller.Auth.User.Matches)
        {
                if(match.UserB == MatchUser || match.UserA == MatchUser)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(match));
                }
            }
        }
    }