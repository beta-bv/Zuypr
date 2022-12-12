using Model;
using Controller;
namespace View.Pages;

public partial class MyDrinks : ContentPage
{
    public static User user = Auth.getUser();
    public List<Drink> AllDrinks => dummydb.Drinks;
    public List<Drink> AllFavoriteDrinks => user.GetFavourites();
    public List<Drink> AllLikes => user.GetLikes();
    public List<Drink> AllDislikes => user.GetDislikes();

    public MyDrinks()
    {
        InitializeComponent();
        BindingContext = this;
    }

    /// <summary>
    /// When clicked on favorite the selected drink gets added to the favorite list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    async void OnButtonFavoriteClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        //button.BackgroundColor = Colors.DarkGreen;
        Drink drink = (Drink)button.BindingContext;
        user.AddToFavourites(drink);
    }

    /// <summary>
    /// When clicked on like the selected drink gets added to the like list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    async void OnButtonLikeClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        //button.BackgroundColor = Colors.Orange;
        Drink drink = (Drink)button.BindingContext;
        user.AddToLikes(drink);
    }

    /// <summary>
    /// When clicked on dislike the selected drink gets added to the dislike list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    async void OnButtonDislikeClicked(object sender, EventArgs args)
    {
        RadioButton button = (RadioButton)sender;
        //button.BackgroundColor = Colors.Red;
        Drink drink = (Drink)button.BindingContext;
        user.AddToDislikes(drink);
    }
}