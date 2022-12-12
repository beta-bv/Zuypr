using Model;
using Controller;
namespace View.Pages;

public partial class MyDrinks : ContentPage
{
    public static User user = Auth.getUser();
    public List<Drink> AllDrinks => dummydb.Drinks;

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
        Drink drink = (Drink)button.BindingContext;
        if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetFavourites()))
        {
            button.IsChecked = false;
        }
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
        Drink drink = (Drink)button.BindingContext;
        if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetLikes()))
        {
            button.IsChecked = false;
        }
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
        Drink drink = (Drink)button.BindingContext;
        if (Auth.getUser().CheckIfListIsFull(Auth.getUser().GetDislikes()))
        {
            button.IsChecked = false;
        }
        user.AddToDislikes(drink);
    }
}